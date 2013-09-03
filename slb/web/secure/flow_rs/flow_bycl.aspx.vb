Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_bycl
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   �����������ļ����ļ���������
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowBycl����
    '----------------------------------------------------------------

    Public Class flow_bycl
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lblWSCXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdWSCXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnSendRequest As System.Web.UI.WebControls.Button
        Protected WithEvents btnShouRequest As System.Web.UI.WebControls.Button
        Protected WithEvents btnSendTongzhi As System.Web.UI.WebControls.Button
        Protected WithEvents lblSGWXXGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdSGWXX As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnPizhun As System.Web.UI.WebControls.Button
        Protected WithEvents btnJujue As System.Web.UI.WebControls.Button
        Protected WithEvents btnZhuanfa As System.Web.UI.WebControls.Button
        Protected WithEvents btnHasRead As System.Web.UI.WebControls.Button
        Protected WithEvents btnRefresh As System.Web.UI.WebControls.Button
        Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtWSCXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSGWXXFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtValueB As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtValueA As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWSCXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWSCXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWSCXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWSCXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtWSCXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSGWXXQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSGWXXRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSGWXXSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSGWXXSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSGWXXSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftWSCXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopWSCXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftSGWXX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopSGWXX As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowBycl
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowBycl
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        'ģ��������ݲ���
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_WSCXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_WSCXX As String '��¼m_objDataSet_WSCXX������
        Private m_intRows_WSCXX As Integer '��¼m_objDataSet_WSCXX��DefaultView��¼��
        Private m_objDataSet_SGWXX As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_SGWXX As String '��¼m_objDataSet_SGWXX������
        Private m_intRows_SGWXX As Integer '��¼m_objDataSet_SGWXX��DefaultView��¼��

        '----------------------------------------------------------------
        '����������grdWSCXX��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_WSCXX As String = "chkWSCXX"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_WSCXX As String = "divWSCXX"
        '����Ҫ����������
        Private m_intFixedColumns_WSCXX As Integer

        '----------------------------------------------------------------
        '����������grdSGWXX��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_SGWXX As String = "chkSGWXX"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_SGWXX As String = "divSGWXX"
        '����Ҫ����������
        Private m_intFixedColumns_SGWXX As Integer

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
                    Me.htxtValueA.Value = .htxtValueA
                    Me.htxtValueB.Value = .htxtValueB

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftWSCXX.Value = .htxtDivLeftWSCXX
                    Me.htxtDivTopWSCXX.Value = .htxtDivTopWSCXX
                    Me.htxtDivLeftSGWXX.Value = .htxtDivLeftSGWXX
                    Me.htxtDivTopSGWXX.Value = .htxtDivTopSGWXX

                    Me.htxtWSCXXQuery.Value = .htxtWSCXXQuery
                    Me.htxtWSCXXRows.Value = .htxtWSCXXRows
                    Me.htxtWSCXXSort.Value = .htxtWSCXXSort
                    Me.htxtWSCXXSortColumnIndex.Value = .htxtWSCXXSortColumnIndex
                    Me.htxtWSCXXSortType.Value = .htxtWSCXXSortType

                    Me.htxtSGWXXQuery.Value = .htxtSGWXXQuery
                    Me.htxtSGWXXRows.Value = .htxtSGWXXRows
                    Me.htxtSGWXXSort.Value = .htxtSGWXXSort
                    Me.htxtSGWXXSortColumnIndex.Value = .htxtSGWXXSortColumnIndex
                    Me.htxtSGWXXSortType.Value = .htxtSGWXXSortType

                    Try
                        Me.grdWSCXX.PageSize = .grdWSCXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdWSCXX.CurrentPageIndex = .grdWSCXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdWSCXX.SelectedIndex = .grdWSCXX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdSGWXX.PageSize = .grdSGWXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSGWXX.CurrentPageIndex = .grdSGWXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSGWXX.SelectedIndex = .grdSGWXX_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowBycl

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtValueA = Me.htxtValueA.Value
                    .htxtValueB = Me.htxtValueB.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftWSCXX = Me.htxtDivLeftWSCXX.Value
                    .htxtDivTopWSCXX = Me.htxtDivTopWSCXX.Value
                    .htxtDivLeftSGWXX = Me.htxtDivLeftSGWXX.Value
                    .htxtDivTopSGWXX = Me.htxtDivTopSGWXX.Value

                    .htxtWSCXXQuery = Me.htxtWSCXXQuery.Value
                    .htxtWSCXXRows = Me.htxtWSCXXRows.Value
                    .htxtWSCXXSort = Me.htxtWSCXXSort.Value
                    .htxtWSCXXSortColumnIndex = Me.htxtWSCXXSortColumnIndex.Value
                    .htxtWSCXXSortType = Me.htxtWSCXXSortType.Value

                    .htxtSGWXXQuery = Me.htxtSGWXXQuery.Value
                    .htxtSGWXXRows = Me.htxtSGWXXRows.Value
                    .htxtSGWXXSort = Me.htxtSGWXXSort.Value
                    .htxtSGWXXSortColumnIndex = Me.htxtSGWXXSortColumnIndex.Value
                    .htxtSGWXXSortType = Me.htxtSGWXXSortType.Value

                    .grdWSCXX_PageSize = Me.grdWSCXX.PageSize
                    .grdWSCXX_CurrentPageIndex = Me.grdWSCXX.CurrentPageIndex
                    .grdWSCXX_SelectedIndex = Me.grdWSCXX.SelectedIndex

                    .grdSGWXX_PageSize = Me.grdSGWXX.PageSize
                    .grdSGWXX_CurrentPageIndex = Me.grdSGWXX.CurrentPageIndex
                    .grdSGWXX_SelectedIndex = Me.grdSGWXX.SelectedIndex

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
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            Try
                If Me.IsPostBack = True Then Exit Try

                '=========================================================================================================================================================
                Dim objIDmxzZzry As Josco.JsKernal.BusinessFacade.IDmxzZzry
                Try
                    objIDmxzZzry = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzZzry)
                Catch ex As Exception
                    objIDmxzZzry = Nothing
                End Try
                If Not (objIDmxzZzry Is Nothing) Then
                    '��ȡ��Ϣ
                    Dim strSourceControl As String = objIDmxzZzry.iSourceControlId.ToUpper
                    Dim blnExitMode As Boolean = objIDmxzZzry.oExitMode
                    Dim strList As String = objIDmxzZzry.oRenyuanList
                    '�ͷ���Դ
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIDmxzZzry.Dispose()
                    objIDmxzZzry = Nothing
                    If blnExitMode = True Then
                        Dim intJJXH As Integer
                        Select Case strSourceControl
                            Case "btnSendRequest".ToUpper
                                If Me.doSendBuyueRequest(strErrMsg, Me.m_objInterface.iBLR, strList) = False Then
                                    GoTo errProc
                                End If
                                objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ�����Ѿ���[" + strList + "]�����ļ���������")
                            Case "btnSendTongzhi".ToUpper
                                If Me.doSendBuyueTongzhi(strErrMsg, Me.m_objInterface.iBLR, strList, Me.htxtValueA.Value) = False Then
                                    GoTo errProc
                                End If
                                Me.htxtValueA.Value = ""
                                objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ�����Ѿ���[" + strList + "]�����ļ�����֪ͨ��")
                            Case "btnZhuanfa".ToUpper
                                intJJXH = objPulicParameters.getObjectValue(Me.htxtValueA.Value, 0)
                                If Me.doZhuanfaBuyueRequest(strErrMsg, intJJXH, strList) = False Then
                                    GoTo errProc
                                End If
                                Me.htxtValueA.Value = ""
                                objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ�����Ѿ���[" + strList + "]ת�����ļ���������")
                            Case Else
                        End Select
                    End If
                    Exit Try
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowBycl)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowBycl)
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
                Me.m_intFixedColumns_WSCXX = objPulicParameters.getObjectValue(Me.htxtWSCXXFixed.Value, 0)
                Me.m_intRows_WSCXX = objPulicParameters.getObjectValue(Me.htxtWSCXXRows.Value, 0)
                Me.m_strQuery_WSCXX = Me.htxtWSCXXQuery.Value

                Me.m_intFixedColumns_SGWXX = objPulicParameters.getObjectValue(Me.htxtSGWXXFixed.Value, 0)
                Me.m_intRows_SGWXX = objPulicParameters.getObjectValue(Me.htxtSGWXXRows.Value, 0)
                Me.m_strQuery_SGWXX = Me.htxtSGWXXQuery.Value

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
        ' ��ȡ�����ͳ����Ĳ�����Ϣ���ݼ�
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       ����������(a.)
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_WSCXX( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            getModuleData_WSCXX = False

            Try
                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtWSCXXSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                If Not (Me.m_objDataSet_WSCXX Is Nothing) Then
                    Me.m_objDataSet_WSCXX.Dispose()
                    Me.m_objDataSet_WSCXX = Nothing
                End If

                '���¼�������
                If Me.m_objsystemFlowObject.getBuyueSendData(strErrMsg, Me.m_objInterface.iBLR, strWhere, Me.m_objDataSet_WSCXX) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_WSCXX.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_WSCXX.Tables(strTable)
                    Me.htxtWSCXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_WSCXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_WSCXX = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡ�����յ����Ĳ�����Ϣ���ݼ�
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       ����������(a.)
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_SGWXX( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            getModuleData_SGWXX = False

            Try
                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtSGWXXSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                If Not (Me.m_objDataSet_SGWXX Is Nothing) Then
                    Me.m_objDataSet_SGWXX.Dispose()
                    Me.m_objDataSet_SGWXX = Nothing
                End If

                '���¼�������
                If Me.m_objsystemFlowObject.getBuyueRecvData(strErrMsg, Me.m_objInterface.iBLR, strWhere, Me.m_objDataSet_SGWXX) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_SGWXX.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_SGWXX.Tables(strTable)
                    Me.htxtSGWXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_SGWXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_SGWXX = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdWSCXX������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_WSCXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            showDataGridInfo_WSCXX = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtWSCXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtWSCXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_WSCXX Is Nothing Then
                    Me.grdWSCXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_WSCXX.Tables(strTable)
                        Me.grdWSCXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_WSCXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdWSCXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdWSCXX)
                    With Me.grdWSCXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdWSCXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdWSCXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_WSCXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_WSCXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdSGWXX������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_SGWXX(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE

            showDataGridInfo_SGWXX = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtSGWXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtSGWXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_SGWXX Is Nothing Then
                    Me.grdSGWXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_SGWXX.Tables(strTable)
                        Me.grdSGWXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_SGWXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdSGWXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdSGWXX)
                    With Me.grdSGWXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdSGWXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdSGWXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_SGWXX) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_SGWXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdWSCXX���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_WSCXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_VT_WENJIANBUYUE
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_WSCXX = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_WSCXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                Me.lblWSCXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdWSCXX, Me.m_intRows_WSCXX) + ")"

                '�С����ͳ���
                Dim strOldFilter As String
                Dim strFilter As String
                With Me.m_objDataSet_WSCXX.Tables(strTable)
                    If .Rows.Count > 0 Then
                        Me.btnShouRequest.Enabled = True
                    Else
                        Me.btnShouRequest.Enabled = False
                    End If
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_WSCXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���ݵ�ǰ����ʾ������Ϣ(grdSGWXX)
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showCommand_SGWXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showCommand_SGWXX = False
            strErrMsg = ""

            Try
                '�С��͸��ҡ�
                Dim intColIndex As Integer
                Dim strBLZL As String = ""
                Dim strBLZT As String = ""
                If Me.grdSGWXX.Items.Count > 0 Then
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(Me.grdSGWXX.SelectedIndex), intColIndex)
                    If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = True Then
                        Me.btnPizhun.Enabled = False
                        Me.btnJujue.Enabled = False
                        Me.btnZhuanfa.Enabled = False
                        Me.btnHasRead.Enabled = False
                    Else
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZL)
                        strBLZL = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(Me.grdSGWXX.SelectedIndex), intColIndex)
                        Select Case strBLZL
                            Case Josco.JSOA.Common.Workflow.BaseFlowObject.TASK_BYQQ
                                Me.btnPizhun.Enabled = True
                                Me.btnJujue.Enabled = True
                                Me.btnZhuanfa.Enabled = True
                                Me.btnHasRead.Enabled = False
                            Case Else
                                Me.btnPizhun.Enabled = False
                                Me.btnJujue.Enabled = False
                                Me.btnZhuanfa.Enabled = False
                                Me.btnHasRead.Enabled = True
                        End Select
                    End If
                Else
                    Me.btnPizhun.Enabled = False
                    Me.btnJujue.Enabled = False
                    Me.btnZhuanfa.Enabled = False
                    Me.btnHasRead.Enabled = False
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showCommand_SGWXX = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdSGWXX���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_SGWXX(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_SGWXX = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_SGWXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                Me.lblSGWXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdSGWXX, Me.m_intRows_SGWXX) + ")"

                '��ʾ������Ϣ
                If Me.showCommand_SGWXX(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_SGWXX = True
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
                'һ������
                Me.btnSendRequest.Enabled = True
                Me.btnSendTongzhi.Enabled = True

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

                    '��ʾgrdWSCXX
                    If Me.getModuleData_WSCXX(strErrMsg, Me.m_strQuery_WSCXX) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_WSCXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ȡ����
                    If Me.getModuleData_SGWXX(strErrMsg, Me.m_strQuery_SGWXX) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_SGWXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾMain
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




        '---------------------------------------------------------------------------------------------------------------------------
        '�����¼�������
        '---------------------------------------------------------------------------------------------------------------------------
        Sub grdWSCXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdWSCXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_WSCXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_WSCXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_WSCXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdWSCXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdWSCXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdWSCXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblWSCXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdWSCXX, Me.m_intRows_WSCXX) + ")"

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

        Private Sub grdWSCXX_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdWSCXX.SortCommand

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
                If Me.getModuleData_WSCXX(strErrMsg, Me.m_strQuery_WSCXX) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                strOldCommand = Me.m_objDataSet_WSCXX.Tables(strTable).DefaultView.Sort

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                Me.m_objDataSet_WSCXX.Tables(strTable).DefaultView.Sort = strFinalCommand

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtWSCXXSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtWSCXXSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtWSCXXSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_WSCXX(strErrMsg) = False Then
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

        Sub grdSGWXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdSGWXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_SGWXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_SGWXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_SGWXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdSGWXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdSGWXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSGWXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblSGWXXGridLocInfo.Text = "(" + objDataGridProcess.getDataGridLocation(Me.grdSGWXX, Me.m_intRows_SGWXX) + ")"

                'ͬ������
                If Me.showCommand_SGWXX(strErrMsg) = False Then
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

        Private Sub grdSGWXX_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdSGWXX.SortCommand

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
                If Me.getModuleData_SGWXX(strErrMsg, Me.m_strQuery_SGWXX) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                strOldCommand = Me.m_objDataSet_SGWXX.Tables(strTable).DefaultView.Sort

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                Me.m_objDataSet_SGWXX.Tables(strTable).DefaultView.Sort = strFinalCommand

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtSGWXXSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtSGWXXSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtSGWXXSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_SGWXX(strErrMsg) = False Then
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

        '----------------------------------------------------------------
        ' strFSR��strJSRList���Ͳ�������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strFSR               ��������
        '     strJSRList           ���������б�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Private Function doSendBuyueRequest( _
            ByRef strErrMsg As String, _
            ByVal strFSR As String, _
            ByVal strJSRList As String) As Boolean

            doSendBuyueRequest = False
            strErrMsg = ""

            Try
                '���
                If strFSR Is Nothing Then strFSR = ""
                strFSR = strFSR.Trim
                If strFSR = "" Then
                    strErrMsg = "����δָ�������ˣ�"
                    GoTo errProc
                End If
                If strJSRList Is Nothing Then strJSRList = ""
                strJSRList = strJSRList.Trim
                If strJSRList = "" Then
                    strErrMsg = "����δָ�������ˣ�"
                    GoTo errProc
                End If

                '����������
                Dim strArray() As String
                strArray = strJSRList.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray)

                '��ȡ��������š�
                Dim strFSXH As String
                If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                    GoTo errProc
                End If

                '�������
                Dim intCount As Integer
                Dim i As Integer
                intCount = strArray.Length
                For i = 0 To intCount - 1 Step 1
                    If Me.m_objsystemFlowObject.doSendBuyueRequest(strErrMsg, strFSXH, strFSR, strArray(i), "") = False Then
                        GoTo errProc
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doSendBuyueRequest = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Sub doSendBuyueRequest(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '������Խ��в��ĵ���Ա�б�SQL
                Dim strXZSQL As String
                If Me.m_objsystemFlowObject.getAllJsrSql(strErrMsg, Me.m_objInterface.iBLR, strXZSQL) = False Then
                    GoTo errProc
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
                    .iSendRestrict = False
                    .iSelectMode = False
                    .iAllowInput = False
                    .iAllowNull = False
                    .iMultiSelect = True
                    .iSelectBMMC = False
                    .iSelectFFFW = False
                    .iRenyuanList = ""
                    .iRestrictRenyuanList = True
                    .iRestrictRenyuanListSQL = strXZSQL

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

        Private Sub doShouBuyueRequest(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '���ѡ��
                Dim intColIndex As Integer
                Dim strBLZT As String
                Dim intSelect As Integer
                Dim intRows As Integer
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    intRows = Me.grdWSCXX.Items.Count
                    intSelect = 0
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdWSCXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_WSCXX) = True Then
                            strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intColIndex)
                            If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = False Then
                                intSelect += 1
                            End If
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "����û��ѡ������������ת�������󣬻�ѡ��Ķ��Ѿ����꣡"
                        GoTo errProc
                    End If
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ��Ҫ�ջ�ѡ����[" + intSelect.ToString + "]����������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                'ѯ��
                Dim strUserList As String = ""
                Dim intIndex(3) As Integer
                Dim strValue(3) As String
                Dim intJJXH As Integer
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    intIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JSR)
                    intIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JJXH)
                    intRows = Me.grdWSCXX.Items.Count
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdWSCXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_WSCXX) = True Then
                            strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intIndex(0))
                            If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = False Then
                                strValue(1) = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intIndex(1))
                                strValue(2) = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intIndex(2))
                                intJJXH = objPulicParameters.getObjectValue(strValue(2), 0)
                                If Me.m_objsystemFlowObject.doShouhuiBuyueRequest(strErrMsg, intJJXH) = False Then
                                    GoTo errProc
                                End If
                                If strUserList = "" Then
                                    strUserList = strValue(1)
                                Else
                                    strUserList = strUserList + objPulicParameters.CharSeparate + strValue(1)
                                End If
                            End If
                        End If
                    Next

                    '��ʾ
                    If Me.getModuleData_WSCXX(strErrMsg, Me.m_strQuery_WSCXX) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_WSCXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾ
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ���Ѿ��ջ����͸�[" + strUserList + "]�Ĳ�������")
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

        '2010-04-09 LJ
        Private Sub doShouBuyueTongzhi(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '���ѡ��
                Dim intColIndex As Integer
                Dim strBLZT As String
                Dim intSelect As Integer
                Dim intRows As Integer
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    intRows = Me.grdWSCXX.Items.Count
                    intSelect = 0
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdWSCXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_WSCXX) = True Then
                            strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intColIndex)
                            If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = False Then
                                intSelect += 1
                            End If
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "����û��ѡ������������ת�������󣬻�ѡ��Ķ��Ѿ����꣡"
                        GoTo errProc
                    End If
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ��Ҫ�ջ�ѡ����[" + intSelect.ToString + "]����������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                'ѯ��
                Dim strUserList As String = ""
                Dim intIndex(3) As Integer
                Dim strValue(3) As String
                Dim intJJXH As Integer
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    intIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JSR)
                    intIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdWSCXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JJXH)
                    intRows = Me.grdWSCXX.Items.Count
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdWSCXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_WSCXX) = True Then
                            strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intIndex(0))
                            If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = False Then
                                strValue(1) = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intIndex(1))
                                strValue(2) = objDataGridProcess.getDataGridCellValue(Me.grdWSCXX.Items(i), intIndex(2))
                                intJJXH = objPulicParameters.getObjectValue(strValue(2), 0)
                                If Me.m_objsystemFlowObject.doShouhuiBuyueTongzhi(strErrMsg, intJJXH) = False Then
                                    GoTo errProc
                                End If
                                If strUserList = "" Then
                                    strUserList = strValue(1)
                                Else
                                    strUserList = strUserList + objPulicParameters.CharSeparate + strValue(1)
                                End If
                            End If
                        End If
                    Next

                    '��ʾ
                    If Me.getModuleData_WSCXX(strErrMsg, Me.m_strQuery_WSCXX) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_WSCXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾ
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ���Ѿ��ջ����͸�[" + strUserList + "]�Ĳ�������")
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

        '----------------------------------------------------------------
        ' strFSR��strJSRList���Ͳ���ͬ־
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strFSR               ��������
        '     strJSRList           ���������б�
        '     strJJSM              ����ע
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Private Function doSendBuyueTongzhi( _
            ByRef strErrMsg As String, _
            ByVal strFSR As String, _
            ByVal strJSRList As String, _
            ByVal strJJSM As String) As Boolean

            doSendBuyueTongzhi = False
            strErrMsg = ""

            Try
                '���
                If strFSR Is Nothing Then strFSR = ""
                strFSR = strFSR.Trim
                If strFSR = "" Then
                    strErrMsg = "����δָ�������ˣ�"
                    GoTo errProc
                End If
                If strJSRList Is Nothing Then strJSRList = ""
                strJSRList = strJSRList.Trim
                If strJSRList = "" Then
                    strErrMsg = "����δָ�������ˣ�"
                    GoTo errProc
                End If
                If strJJSM Is Nothing Then strJJSM = ""
                strJJSM = strJJSM.Trim

                '����������
                Dim strArray() As String
                strArray = strJSRList.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray)

                '��ȡ��������š�
                Dim strFSXH As String
                If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                    GoTo errProc
                End If

                '�������
                Dim intCount As Integer
                Dim i As Integer
                intCount = strArray.Length
                For i = 0 To intCount - 1 Step 1
                    If Me.m_objsystemFlowObject.doSendBuyueTongzhi(strErrMsg, strFSXH, strFSR, strArray(i), strJJSM) = False Then
                        GoTo errProc
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doSendBuyueTongzhi = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Sub doSendBuyueTongzhi(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '������ע����
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    'LJ 2008-07-3
                    objMessageProcess.doInputBox(Me.popMessageObject, "��������ע����", strControlId, intStep, " ")
                    'LJ 2008-07-3
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��ȡ����ֵ
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��ע����
                    Me.htxtValueA.Value = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)

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
                        .iSelectMode = False
                        .iAllowInput = False
                        .iAllowNull = False
                        .iMultiSelect = True
                        .iSelectBMMC = False
                        .iSelectFFFW = False

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

        Private Sub doPizhunBuyueRequest(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '���ѡ��
                Dim intColIndex As Integer
                Dim strBLZT As String
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    If Me.grdSGWXX.Items.Count < 1 Then
                        strErrMsg = "������û�н����κ�����"
                        GoTo errProc
                    End If
                    If Me.grdSGWXX.SelectedIndex < 0 Then
                        strErrMsg = "������û�н����κ�����"
                        GoTo errProc
                    End If
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    i = Me.grdSGWXX.SelectedIndex
                    strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intColIndex)
                    If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = True Then
                        strErrMsg = "���󣺵�ǰ�����Ѵ�����ϣ������ٴ���"
                        GoTo errProc
                    End If
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ��Ҫͬ�⵱ǰ��������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                'ѯ��
                Dim strUserList As String = ""
                Dim intIndex(3) As Integer
                Dim strValue(3) As String
                Dim strFSXH As String
                Dim intJJXH As Integer
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                        GoTo errProc
                    End If
                    intIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    intIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JSR)
                    intIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JJXH)
                    i = Me.grdSGWXX.SelectedIndex
                    strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(0))
                    If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = False Then
                        strValue(1) = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(1))
                        strValue(2) = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(2))
                        intJJXH = objPulicParameters.getObjectValue(strValue(2), 0)
                        If Me.m_objsystemFlowObject.doPizhunBuyueRequest(strErrMsg, intJJXH, strFSXH) = False Then
                            GoTo errProc
                        End If
                        strUserList = strValue(1)
                    End If

                    '��ʾ
                    If Me.getModuleData_SGWXX(strErrMsg, Me.m_strQuery_SGWXX) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_SGWXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾ
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ������׼�˵�ǰ�ļ��������󣬲���[" + strUserList + "]������֪ͨ��Ϣ��")
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

        Private Sub doJujueBuyueRequest(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '���ѡ��
                Dim intColIndex As Integer
                Dim strBLZT As String
                Dim i As Integer
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    If Me.grdSGWXX.Items.Count < 1 Then
                        strErrMsg = "������û�н����κ�����"
                        GoTo errProc
                    End If
                    If Me.grdSGWXX.SelectedIndex < 0 Then
                        strErrMsg = "������û�н����κ�����"
                        GoTo errProc
                    End If
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    i = Me.grdSGWXX.SelectedIndex
                    strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intColIndex)
                    If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = True Then
                        strErrMsg = "���󣺵�ǰ�����Ѵ�����ϣ������ٴ���"
                        GoTo errProc
                    End If
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ��Ҫ�ܾ���ǰ��������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                'ѯ��
                Dim strUserList As String = ""
                Dim intIndex(3) As Integer
                Dim strValue(3) As String
                Dim strFSXH As String
                Dim intJJXH As Integer
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                        GoTo errProc
                    End If
                    intIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                    intIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JSR)
                    intIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JJXH)
                    i = Me.grdSGWXX.SelectedIndex
                    strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(0))
                    If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = False Then
                        strValue(1) = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(1))
                        strValue(2) = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(2))
                        intJJXH = objPulicParameters.getObjectValue(strValue(2), 0)
                        If Me.m_objsystemFlowObject.doJujueBuyueRequest(strErrMsg, intJJXH, strFSXH) = False Then
                            GoTo errProc
                        End If
                        strUserList = strValue(1)
                    End If

                    'ˢ����ʾ
                    If Me.getModuleData_SGWXX(strErrMsg, Me.m_strQuery_SGWXX) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_SGWXX(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾ
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ�����ܾ��˵�ǰ�ļ��������󣬲���[" + strUserList + "]������֪ͨ��Ϣ��")
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

        '----------------------------------------------------------------
        ' intJJXH�Ľ�������strZFJSRת����������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     intJJXH              ����ǰ���Ӻ�
        '     strZFJSR             ��ת���������б�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Private Function doZhuanfaBuyueRequest( _
            ByRef strErrMsg As String, _
            ByVal intJJXH As Integer, _
            ByVal strZFJSR As String) As Boolean

            doZhuanfaBuyueRequest = False
            strErrMsg = ""

            Try
                '���
                If strZFJSR Is Nothing Then strZFJSR = ""
                strZFJSR = strZFJSR.Trim
                If strZFJSR = "" Then
                    strErrMsg = "����δָ��ת�������ˣ�"
                    GoTo errProc
                End If

                '��ȡ��������š�
                Dim strFSXH As String
                If Me.m_objsystemFlowObject.getNewFSXH(strErrMsg, strFSXH) = False Then
                    GoTo errProc
                End If

                '�������
                If Me.m_objsystemFlowObject.doZhuanfaBuyueRequest(strErrMsg, intJJXH, strFSXH, strZFJSR) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doZhuanfaBuyueRequest = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Sub doZhuanfaBuyueRequest(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '���ѡ��
                Dim intColIndex(3) As Integer
                Dim strValue(3) As String
                Dim i As Integer
                If Me.grdSGWXX.Items.Count < 1 Then
                    strErrMsg = "������û�н����κ�����"
                    GoTo errProc
                End If
                If Me.grdSGWXX.SelectedIndex < 0 Then
                    strErrMsg = "������û�н����κ�����"
                    GoTo errProc
                End If
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JJXH)
                i = Me.grdSGWXX.SelectedIndex
                strValue(0) = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intColIndex(0))
                If Me.m_objsystemFlowObject.isTaskComplete(strValue(0)) = True Then
                    strErrMsg = "���������Ѿ�������ϣ������ٴ���"
                    GoTo errProc
                End If
                strValue(1) = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intColIndex(1))
                strValue(2) = strValue(1)
                Me.htxtValueA.Value = strValue(2)

                '������Խ��в��ĵ���Ա�б�SQL
                Dim strXZSQL As String
                If Me.m_objsystemFlowObject.getAllJsrSql(strErrMsg, Me.m_objInterface.iBLR, strXZSQL) = False Then
                    GoTo errProc
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
                    .iSendRestrict = False
                    .iSelectMode = False
                    .iAllowInput = False
                    .iAllowNull = False
                    .iMultiSelect = True
                    .iSelectBMMC = False
                    .iSelectFFFW = False
                    .iRenyuanList = ""
                    .iRestrictRenyuanList = True
                    .iRestrictRenyuanListSQL = strXZSQL

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
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Me.htxtValueA.Value = ""
            Exit Sub

        End Sub

        Private Sub doReadBuyueTongzhi(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strNewSessionId As String
            Dim strMSessionId As String
            Dim intStep As Integer

            Try
                '���ѡ��
                Dim intColIndex As Integer
                Dim strBLZT As String
                Dim i As Integer
                If Me.grdSGWXX.Items.Count < 1 Then
                    strErrMsg = "������û�н����κ�֪ͨ��"
                    GoTo errProc
                End If
                If Me.grdSGWXX.SelectedIndex < 0 Then
                    strErrMsg = "������û�н����κ�֪ͨ��"
                    GoTo errProc
                End If
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                i = Me.grdSGWXX.SelectedIndex
                strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intColIndex)
                If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = True Then
                    strErrMsg = "���󣺵�ǰ֪ͨ�Ѵ�����ϣ������ٴ���"
                    GoTo errProc
                End If

                'ѯ��
                Dim intIndex(3) As Integer
                Dim strValue(3) As String
                Dim intJJXH As Integer
                intIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_BLZT)
                intIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdSGWXX, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_VT_WENJIANBUYUE_JJXH)
                i = Me.grdSGWXX.SelectedIndex
                strBLZT = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(0))
                If Me.m_objsystemFlowObject.isTaskComplete(strBLZT) = False Then
                    strValue(1) = objDataGridProcess.getDataGridCellValue(Me.grdSGWXX.Items(i), intIndex(1))
                    intJJXH = objPulicParameters.getObjectValue(strValue(1), 0)
                    If Me.m_objsystemFlowObject.doReadBuyueTongzhi(strErrMsg, intJJXH) = False Then
                        GoTo errProc
                    End If
                End If

                '��ʾ
                If Me.getModuleData_SGWXX(strErrMsg, Me.m_strQuery_SGWXX) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_SGWXX(strErrMsg) = False Then
                    GoTo errProc
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

        Private Sub doRefresh(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.getModuleData_WSCXX(strErrMsg, Me.m_strQuery_WSCXX) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_WSCXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                If Me.getModuleData_SGWXX(strErrMsg, Me.m_strQuery_SGWXX) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_SGWXX(strErrMsg) = False Then
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

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnSendRequest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendRequest.Click
            Me.doSendBuyueRequest("btnSendRequest")
        End Sub

        Private Sub btnShouRequest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShouRequest.Click
            '2010-04-09 LJ
            'Me.doShouBuyueRequest("btnShouRequest")
            Me.doShouBuyueTongzhi("btnShouRequest")
            '2010-04-09 LJ
        End Sub

        Private Sub btnSendTongzhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendTongzhi.Click
            Me.doSendBuyueTongzhi("btnSendTongzhi")
        End Sub

        Private Sub btnPizhun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPizhun.Click
            Me.doPizhunBuyueRequest("btnPizhun")
        End Sub

        Private Sub btnJujue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJujue.Click
            Me.doJujueBuyueRequest("btnJujue")
        End Sub

        Private Sub btnZhuanfa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnZhuanfa.Click
            Me.doZhuanfaBuyueRequest("btnZhuanfa")
        End Sub

        Private Sub btnHasRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHasRead.Click
            Me.doReadBuyueTongzhi("btnHasRead")
        End Sub

        Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            Me.doRefresh("btnRefresh")
        End Sub

    End Class

End Namespace
