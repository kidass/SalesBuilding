Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_lzqk
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   ������鿴��ת�������
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowLzqk����
    '----------------------------------------------------------------

    Public Class flow_lzqk
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZLZXXDeSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZLZXXSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZLZXXMoveFirst As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZLZXXMovePrev As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZLZXXMoveNext As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZLZXXMoveLast As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZLZXXGotoPage As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtLZXXPageIndex As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkCZLZXXSetPageSize As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtLZXXPageSize As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblLZXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents txtLZXXSearch_FSR As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLZXXSearch_JSR As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLZXXSearch_BLSY As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLZXXSearch_WCRQMin As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLZXXSearch_WCRQMax As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnLZXXSearch As System.Web.UI.WebControls.Button
        Protected WithEvents grdLZXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnCKYJ As System.Web.UI.WebControls.Button
        Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
        Protected WithEvents btnClose As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtLZXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtLZXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtLZXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtLZXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtLZXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtLZXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftLZXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopLZXX As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowLzqk
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowLzqk
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdLZXX��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_LZXX As String = "chkLZXX"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_LZXX As String = "divLZXX"
        '����Ҫ����������
        Private m_intFixedColumns_LZXX As Integer

        '----------------------------------------------------------------
        'Ҫ���ʵ�����
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_LZXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_LZXX As String '��¼m_objDataSet_LZXX������
        Private m_intRows_LZXX As Integer '��¼m_objDataSet_LZXX��DefaultView��¼��












        '----------------------------------------------------------------
        ' ��ԭģ���ֳ���Ϣ���ͷ���Ӧ����Դ
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtLZXXQuery.Value = .htxtLZXXQuery
                    Me.htxtLZXXRows.Value = .htxtLZXXRows
                    Me.htxtLZXXSort.Value = .htxtLZXXSort
                    Me.htxtLZXXSortColumnIndex.Value = .htxtLZXXSortColumnIndex
                    Me.htxtLZXXSortType.Value = .htxtLZXXSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftLZXX.Value = .htxtDivLeftLZXX
                    Me.htxtDivTopLZXX.Value = .htxtDivTopLZXX

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtLZXXPageIndex.Text = .txtLZXXPageIndex
                    Me.txtLZXXPageSize.Text = .txtLZXXPageSize

                    Me.txtLZXXSearch_FSR.Text = .txtLZXXSearch_FSR
                    Me.txtLZXXSearch_JSR.Text = .txtLZXXSearch_JSR
                    Me.txtLZXXSearch_BLSY.Text = .txtLZXXSearch_BLSY
                    Me.txtLZXXSearch_WCRQMin.Text = .txtLZXXSearch_WCRQMin
                    Me.txtLZXXSearch_WCRQMax.Text = .txtLZXXSearch_WCRQMax

                    Try
                        Me.grdLZXX.PageSize = .grdLZXXPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdLZXX.CurrentPageIndex = .grdLZXXCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdLZXX.SelectedIndex = .grdLZXXSelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowLzqk

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtLZXXQuery = Me.htxtLZXXQuery.Value
                    .htxtLZXXRows = Me.htxtLZXXRows.Value
                    .htxtLZXXSort = Me.htxtLZXXSort.Value
                    .htxtLZXXSortColumnIndex = Me.htxtLZXXSortColumnIndex.Value
                    .htxtLZXXSortType = Me.htxtLZXXSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftLZXX = Me.htxtDivLeftLZXX.Value
                    .htxtDivTopLZXX = Me.htxtDivTopLZXX.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .txtLZXXPageIndex = Me.txtLZXXPageIndex.Text
                    .txtLZXXPageSize = Me.txtLZXXPageSize.Text

                    .txtLZXXSearch_FSR = Me.txtLZXXSearch_FSR.Text
                    .txtLZXXSearch_JSR = Me.txtLZXXSearch_JSR.Text
                    .txtLZXXSearch_BLSY = Me.txtLZXXSearch_BLSY.Text
                    .txtLZXXSearch_WCRQMin = Me.txtLZXXSearch_WCRQMin.Text
                    .txtLZXXSearch_WCRQMax = Me.txtLZXXSearch_WCRQMax.Text

                    .grdLZXXPageSize = Me.grdLZXX.PageSize
                    .grdLZXXCurrentPageIndex = Me.grdLZXX.CurrentPageIndex
                    .grdLZXXSelectedIndex = Me.grdLZXX.SelectedIndex
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
                Dim objIFlowSpyj As Josco.JSOA.BusinessFacade.IFlowSpyj
                Try
                    objIFlowSpyj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowSpyj)
                Catch ex As Exception
                    objIFlowSpyj = Nothing
                End Try
                If Not (objIFlowSpyj Is Nothing) Then
                    '�ͷ���Դ
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIFlowSpyj.Dispose()
                    objIFlowSpyj = Nothing
                    Exit Try
                End If

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
                        Me.htxtLZXXQuery.Value = objISjcxCxtj.oQueryString
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowLzqk)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowLzqk)
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
                Me.m_intFixedColumns_LZXX = objPulicParameters.getObjectValue(Me.htxtLZXXFixed.Value, 0)
                Me.m_intRows_LZXX = objPulicParameters.getObjectValue(Me.htxtLZXXRows.Value, 0)
                Me.m_strQuery_LZXX = Me.htxtLZXXQuery.Value

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
        ' ��ȡgrdLZXX����������(Ĭ�ϱ�ǰ׺a.)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_LZXX( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess

            getQueryString_LZXX = False
            strQuery = ""

            Try
                '���������ˡ�����
                Dim strFSR As String
                strFSR = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_FSR
                If Me.txtLZXXSearch_FSR.Text.Length > 0 Then Me.txtLZXXSearch_FSR.Text = Me.txtLZXXSearch_FSR.Text.Trim()
                If Me.txtLZXXSearch_FSR.Text <> "" Then
                    Me.txtLZXXSearch_FSR.Text = objPulicParameters.getNewSearchString(Me.txtLZXXSearch_FSR.Text)
                    If strQuery = "" Then
                        strQuery = strFSR + " like '" + Me.txtLZXXSearch_FSR.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strFSR + " like '" + Me.txtLZXXSearch_FSR.Text + "%'"
                    End If
                End If

                '���������ˡ�����
                Dim strJSR As String
                strJSR = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSR
                If Me.txtLZXXSearch_JSR.Text.Length > 0 Then Me.txtLZXXSearch_JSR.Text = Me.txtLZXXSearch_JSR.Text.Trim()
                If Me.txtLZXXSearch_JSR.Text <> "" Then
                    Me.txtLZXXSearch_JSR.Text = objPulicParameters.getNewSearchString(Me.txtLZXXSearch_JSR.Text)
                    If strQuery = "" Then
                        strQuery = strJSR + " like '" + Me.txtLZXXSearch_JSR.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJSR + " like '" + Me.txtLZXXSearch_JSR.Text + "%'"
                    End If
                End If

                '�����������ˡ�����
                Dim strBLSY As String
                strBLSY = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZL
                If Me.txtLZXXSearch_BLSY.Text.Length > 0 Then Me.txtLZXXSearch_BLSY.Text = Me.txtLZXXSearch_BLSY.Text.Trim()
                If Me.txtLZXXSearch_BLSY.Text <> "" Then
                    Me.txtLZXXSearch_BLSY.Text = objPulicParameters.getNewSearchString(Me.txtLZXXSearch_BLSY.Text)
                    If strQuery = "" Then
                        strQuery = strBLSY + " like '" + Me.txtLZXXSearch_BLSY.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strBLSY + " like '" + Me.txtLZXXSearch_BLSY.Text + "%'"
                    End If
                End If

                '����������ڡ�����
                Dim strWCRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strWCRQ = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_WCRQ
                If Me.txtLZXXSearch_WCRQMin.Text.Length > 0 Then Me.txtLZXXSearch_WCRQMin.Text = Me.txtLZXXSearch_WCRQMin.Text.Trim()
                If Me.txtLZXXSearch_WCRQMax.Text.Length > 0 Then Me.txtLZXXSearch_WCRQMax.Text = Me.txtLZXXSearch_WCRQMax.Text.Trim()
                If Me.txtLZXXSearch_WCRQMin.Text <> "" And Me.txtLZXXSearch_WCRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtLZXXSearch_WCRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtLZXXSearch_WCRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtLZXXSearch_WCRQMin.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                        Me.txtLZXXSearch_WCRQMax.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                    Else
                        Me.txtLZXXSearch_WCRQMin.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                        Me.txtLZXXSearch_WCRQMax.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                    End If
                    If strQuery = "" Then
                        strQuery = strWCRQ + " between '" + Me.txtLZXXSearch_WCRQMin.Text + "' and '" + Me.txtLZXXSearch_WCRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWCRQ + " between '" + Me.txtLZXXSearch_WCRQMin.Text + "' and '" + Me.txtLZXXSearch_WCRQMax.Text + "'"
                    End If
                ElseIf Me.txtLZXXSearch_WCRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtLZXXSearch_WCRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Me.txtLZXXSearch_WCRQMin.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strWCRQ + " >= '" + Me.txtLZXXSearch_WCRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWCRQ + " >= '" + Me.txtLZXXSearch_WCRQMin.Text + "'"
                    End If
                ElseIf Me.txtLZXXSearch_WCRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtLZXXSearch_WCRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Me.txtLZXXSearch_WCRQMax.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strWCRQ + " <= '" + Me.txtLZXXSearch_WCRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strWCRQ + " <= '" + Me.txtLZXXSearch_WCRQMax.Text + "'"
                    End If
                Else
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_LZXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdLZXXҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       ����������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_LZXX( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE

            getModuleData_LZXX = False

            Try
                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtLZXXSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                If Not (Me.m_objDataSet_LZXX Is Nothing) Then
                    Me.m_objDataSet_LZXX.Dispose()
                    Me.m_objDataSet_LZXX = Nothing
                End If

                '���¼�������
                If Me.m_objsystemFlowObject.getLZQKDataSet(strErrMsg, Me.m_objInterface.iBLR, strWhere, Me.m_objDataSet_LZXX) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_LZXX.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_LZXX.Tables(strTable)
                    Me.htxtLZXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_LZXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_LZXX = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdLZXX����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_LZXX(ByRef strErrMsg As String) As Boolean

            searchModuleData_LZXX = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_LZXX(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_LZXX(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_LZXX = strQuery
                Me.htxtLZXXQuery.Value = Me.m_strQuery_LZXX

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_LZXX = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdLZXX������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_LZXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_LZXX = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtLZXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtLZXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_LZXX Is Nothing Then
                    Me.grdLZXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_LZXX.Tables(strTable)
                        Me.grdLZXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_LZXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdLZXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdLZXX)
                    With Me.grdLZXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdLZXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdLZXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_LZXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_LZXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdLZXX�������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_LZXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_LZXX = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_LZXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_LZXX.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblLZXXGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdLZXX, .Count)

                    '��ʾҳ���������
                    Me.lnkCZLZXXMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdLZXX, .Count)
                    Me.lnkCZLZXXMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdLZXX, .Count)
                    Me.lnkCZLZXXMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdLZXX, .Count)
                    Me.lnkCZLZXXMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdLZXX, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZLZXXDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZLZXXSelectAll.Enabled = blnEnabled
                    Me.lnkCZLZXXGotoPage.Enabled = blnEnabled
                    Me.lnkCZLZXXSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_LZXX = True
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
                    objControlProcess.doTranslateKey(Me.txtLZXXPageIndex)
                    objControlProcess.doTranslateKey(Me.txtLZXXPageSize)
                    objControlProcess.doTranslateKey(Me.txtLZXXSearch_FSR)
                    objControlProcess.doTranslateKey(Me.txtLZXXSearch_JSR)
                    objControlProcess.doTranslateKey(Me.txtLZXXSearch_BLSY)
                    objControlProcess.doTranslateKey(Me.txtLZXXSearch_WCRQMin)
                    objControlProcess.doTranslateKey(Me.txtLZXXSearch_WCRQMax)
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '��ʾģ�鼶����
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ����
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_LZXX(strErrMsg) = False Then
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
                    If Me.m_objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + Me.m_objsystemFlowObject.FlowData.WJBS + "]��[�ļ���ת���]��") = False Then
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
        'ʵ�ֶ�grdLZXX�����С��еĹ̶�
        Sub grdLZXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdLZXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_LZXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_LZXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_LZXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdLZXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdLZXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdLZXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblLZXXGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdLZXX, Me.m_intRows_LZXX)
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

        Private Sub grdLZXX_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdLZXX.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE

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
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                strOldCommand = Me.m_objDataSet_LZXX.Tables(strTable).DefaultView.Sort

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                Me.m_objDataSet_LZXX.Tables(strTable).DefaultView.Sort = strFinalCommand

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtLZXXSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtLZXXSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtLZXXSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_LZXX(strErrMsg) = False Then
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




        Private Sub doMoveFirst_LZXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdLZXX.PageCount)
                Me.grdLZXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_LZXX(strErrMsg) = False Then
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

        Private Sub doMoveLast_LZXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdLZXX.PageCount - 1, Me.grdLZXX.PageCount)
                Me.grdLZXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_LZXX(strErrMsg) = False Then
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

        Private Sub doMoveNext_LZXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdLZXX.CurrentPageIndex + 1, Me.grdLZXX.PageCount)
                Me.grdLZXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_LZXX(strErrMsg) = False Then
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

        Private Sub doMovePrevious_LZXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdLZXX.CurrentPageIndex - 1, Me.grdLZXX.PageCount)
                Me.grdLZXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_LZXX(strErrMsg) = False Then
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

        Private Sub doGotoPage_LZXX(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtLZXXPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdLZXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_LZXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtLZXXPageIndex.Text = (Me.grdLZXX.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_LZXX(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtLZXXPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdLZXX.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_LZXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtLZXXPageSize.Text = (Me.grdLZXX.PageSize).ToString()

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

        Private Sub doSelectAll_LZXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdLZXX, 0, Me.m_cstrCheckBoxIdInDataGrid_LZXX, True) = False Then
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

        Private Sub doDeSelectAll_LZXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdLZXX, 0, Me.m_cstrCheckBoxIdInDataGrid_LZXX, False) = False Then
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

        Private Sub doSearch_LZXX(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_LZXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_LZXX(strErrMsg) = False Then
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

        Private Sub lnkCZLZXXMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXMoveFirst.Click
            Me.doMoveFirst_LZXX("lnkCZLZXXMoveFirst")
        End Sub

        Private Sub lnkCZLZXXMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXMoveLast.Click
            Me.doMoveLast_LZXX("lnkCZLZXXMoveLast")
        End Sub

        Private Sub lnkCZLZXXMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXMoveNext.Click
            Me.doMoveNext_LZXX("lnkCZLZXXMoveNext")
        End Sub

        Private Sub lnkCZLZXXMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXMovePrev.Click
            Me.doMovePrevious_LZXX("lnkCZLZXXMovePrev")
        End Sub

        Private Sub lnkCZLZXXGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXGotoPage.Click
            Me.doGotoPage_LZXX("lnkCZLZXXGotoPage")
        End Sub

        Private Sub lnkCZLZXXSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXSetPageSize.Click
            Me.doSetPageSize_LZXX("lnkCZLZXXSetPageSize")
        End Sub

        Private Sub lnkCZLZXXSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXSelectAll.Click
            Me.doSelectAll_LZXX("lnkCZLZXXSelectAll")
        End Sub

        Private Sub lnkCZLZXXDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZLZXXDeSelectAll.Click
            Me.doDeSelectAll_LZXX("lnkCZLZXXDeSelectAll")
        End Sub

        Private Sub btnLZXXSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLZXXSearch.Click
            Me.doSearch_LZXX("btnLZXXSearch")
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

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_JIAOJIE

            Try
                '��ȡ����
                If Me.getModuleData_LZXX(strErrMsg, Me.m_strQuery_LZXX) = False Then
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
                    .iQueryTable = Me.m_objDataSet_LZXX.Tables(strTable)
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

        Private Sub doChakanSPYJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            Try
                '��ȡ������
                Dim intColIndex As Integer = 0
                Dim strJSR As String = ""
                If Me.grdLZXX.Items.Count > 0 Then
                    If Me.grdLZXX.SelectedIndex >= 0 Then
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdLZXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JSR)
                        strJSR = objDataGridProcess.getDataGridCellValue(Me.grdLZXX.Items(Me.grdLZXX.SelectedIndex), intColIndex)
                    End If
                End If

                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowSpyj As Josco.JSOA.BusinessFacade.IFlowSpyj
                Dim strUrl As String
                objIFlowSpyj = New Josco.JSOA.BusinessFacade.IFlowSpyj
                With objIFlowSpyj
                    .iFlowTypeName = Me.m_objInterface.iFlowTypeName
                    .iWJBS = Me.m_objInterface.iWJBS
                    .iBLR = Me.m_objInterface.iBLR
                    .iSPR = strJSR

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
                Session.Add(strNewSessionId, objIFlowSpyj)
                strUrl = ""
                strUrl += "flow_spyj.aspx"
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

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Me.doSearchFull("btnSearch")
        End Sub

        Private Sub btnCKYJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCKYJ.Click
            Me.doChakanSPYJ("btnCKYJ")
        End Sub

    End Class

End Namespace
