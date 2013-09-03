Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_czrz
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   ������鿴��ת�������
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowCzrz����
    '----------------------------------------------------------------

    Public Class flow_czrz
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZCZRZDeSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZCZRZSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZCZRZMoveFirst As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZCZRZMovePrev As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZCZRZMoveNext As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZCZRZMoveLast As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZCZRZGotoPage As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtCZRZPageIndex As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkCZCZRZSetPageSize As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtCZRZPageSize As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblCZRZGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents txtCZRZSearch_CZR As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCZRZSearch_CZSM As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCZRZSearch_CZSJMin As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCZRZSearch_CZSJMax As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnCZRZSearch As System.Web.UI.WebControls.Button
        Protected WithEvents grdCZRZ As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
        Protected WithEvents btnClose As System.Web.UI.WebControls.Button
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents popMessageObject As Josco.Web.PopMessage
        Protected WithEvents htxtCZRZFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtSessionIdQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCZRZQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCZRZRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCZRZSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCZRZSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtCZRZSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftCZRZ As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopCZRZ As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowCzrz
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowCzrz
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdCZRZ��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_CZRZ As String = "chkCZRZ"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_CZRZ As String = "divCZRZ"
        '����Ҫ����������
        Private m_intFixedColumns_CZRZ As Integer

        '----------------------------------------------------------------
        'Ҫ���ʵ�����
        '----------------------------------------------------------------
        Private m_objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
        Private m_objDataSet_CZRZ As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_CZRZ As String '��¼m_objDataSet_CZRZ������
        Private m_intRows_CZRZ As Integer '��¼m_objDataSet_CZRZ��DefaultView��¼��














        '----------------------------------------------------------------
        ' ��ԭģ���ֳ���Ϣ���ͷ���Ӧ����Դ
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtCZRZQuery.Value = .htxtCZRZQuery
                    Me.htxtCZRZRows.Value = .htxtCZRZRows
                    Me.htxtCZRZSort.Value = .htxtCZRZSort
                    Me.htxtCZRZSortColumnIndex.Value = .htxtCZRZSortColumnIndex
                    Me.htxtCZRZSortType.Value = .htxtCZRZSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftCZRZ.Value = .htxtDivLeftCZRZ
                    Me.htxtDivTopCZRZ.Value = .htxtDivTopCZRZ

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtCZRZPageIndex.Text = .txtCZRZPageIndex
                    Me.txtCZRZPageSize.Text = .txtCZRZPageSize

                    Me.txtCZRZSearch_CZSM.Text = .txtCZRZSearch_CZSM
                    Me.txtCZRZSearch_CZR.Text = .txtCZRZSearch_CZR
                    Me.txtCZRZSearch_CZSJMin.Text = .txtCZRZSearch_CZSJMin
                    Me.txtCZRZSearch_CZSJMax.Text = .txtCZRZSearch_CZSJMax

                    Try
                        Me.grdCZRZ.PageSize = .grdCZRZPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdCZRZ.CurrentPageIndex = .grdCZRZCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdCZRZ.SelectedIndex = .grdCZRZSelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowCzrz

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtCZRZQuery = Me.htxtCZRZQuery.Value
                    .htxtCZRZRows = Me.htxtCZRZRows.Value
                    .htxtCZRZSort = Me.htxtCZRZSort.Value
                    .htxtCZRZSortColumnIndex = Me.htxtCZRZSortColumnIndex.Value
                    .htxtCZRZSortType = Me.htxtCZRZSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftCZRZ = Me.htxtDivLeftCZRZ.Value
                    .htxtDivTopCZRZ = Me.htxtDivTopCZRZ.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .txtCZRZPageIndex = Me.txtCZRZPageIndex.Text
                    .txtCZRZPageSize = Me.txtCZRZPageSize.Text

                    .txtCZRZSearch_CZSM = Me.txtCZRZSearch_CZSM.Text
                    .txtCZRZSearch_CZR = Me.txtCZRZSearch_CZR.Text
                    .txtCZRZSearch_CZSJMin = Me.txtCZRZSearch_CZSJMin.Text
                    .txtCZRZSearch_CZSJMax = Me.txtCZRZSearch_CZSJMax.Text

                    .grdCZRZPageSize = Me.grdCZRZ.PageSize
                    .grdCZRZCurrentPageIndex = Me.grdCZRZ.CurrentPageIndex
                    .grdCZRZSelectedIndex = Me.grdCZRZ.SelectedIndex
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
                        Me.htxtCZRZQuery.Value = objISjcxCxtj.oQueryString
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowCzrz)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowCzrz)
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
                Me.m_intFixedColumns_CZRZ = objPulicParameters.getObjectValue(Me.htxtCZRZFixed.Value, 0)
                Me.m_intRows_CZRZ = objPulicParameters.getObjectValue(Me.htxtCZRZRows.Value, 0)
                Me.m_strQuery_CZRZ = Me.htxtCZRZQuery.Value

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
        ' ��ȡgrdCZRZ����������(Ĭ�ϱ�ǰ׺a.)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_CZRZ( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess

            getQueryString_CZRZ = False
            strQuery = ""

            Try
                '��������˵��������
                Dim strCZSM As String
                strCZSM = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CAOZUORIZHI_CZSM
                If Me.txtCZRZSearch_CZSM.Text.Length > 0 Then Me.txtCZRZSearch_CZSM.Text = Me.txtCZRZSearch_CZSM.Text.Trim()
                If Me.txtCZRZSearch_CZSM.Text <> "" Then
                    Me.txtCZRZSearch_CZSM.Text = objPulicParameters.getNewSearchString(Me.txtCZRZSearch_CZSM.Text)
                    If strQuery = "" Then
                        strQuery = strCZSM + " like '" + Me.txtCZRZSearch_CZSM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strCZSM + " like '" + Me.txtCZRZSearch_CZSM.Text + "%'"
                    End If
                End If

                '���������ˡ�����
                Dim strCZR As String
                strCZR = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CAOZUORIZHI_CZR
                If Me.txtCZRZSearch_CZR.Text.Length > 0 Then Me.txtCZRZSearch_CZR.Text = Me.txtCZRZSearch_CZR.Text.Trim()
                If Me.txtCZRZSearch_CZR.Text <> "" Then
                    Me.txtCZRZSearch_CZR.Text = objPulicParameters.getNewSearchString(Me.txtCZRZSearch_CZR.Text)
                    If strQuery = "" Then
                        strQuery = strCZR + " like '" + Me.txtCZRZSearch_CZR.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strCZR + " like '" + Me.txtCZRZSearch_CZR.Text + "%'"
                    End If
                End If

                '��������ʱ�䡱����
                Dim strCZSJ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strCZSJ = "a." + Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_CAOZUORIZHI_CZSJ
                If Me.txtCZRZSearch_CZSJMin.Text.Length > 0 Then Me.txtCZRZSearch_CZSJMin.Text = Me.txtCZRZSearch_CZSJMin.Text.Trim()
                If Me.txtCZRZSearch_CZSJMax.Text.Length > 0 Then Me.txtCZRZSearch_CZSJMax.Text = Me.txtCZRZSearch_CZSJMax.Text.Trim()
                If Me.txtCZRZSearch_CZSJMin.Text <> "" And Me.txtCZRZSearch_CZSJMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtCZRZSearch_CZSJMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtCZRZSearch_CZSJMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtCZRZSearch_CZSJMin.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                        Me.txtCZRZSearch_CZSJMax.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                    Else
                        Me.txtCZRZSearch_CZSJMin.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                        Me.txtCZRZSearch_CZSJMax.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                    End If
                    If strQuery = "" Then
                        strQuery = strCZSJ + " between '" + Me.txtCZRZSearch_CZSJMin.Text + "' and '" + Me.txtCZRZSearch_CZSJMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strCZSJ + " between '" + Me.txtCZRZSearch_CZSJMin.Text + "' and '" + Me.txtCZRZSearch_CZSJMax.Text + "'"
                    End If
                ElseIf Me.txtCZRZSearch_CZSJMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtCZRZSearch_CZSJMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Me.txtCZRZSearch_CZSJMin.Text = Format(dateMin, "yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strCZSJ + " >= '" + Me.txtCZRZSearch_CZSJMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strCZSJ + " >= '" + Me.txtCZRZSearch_CZSJMin.Text + "'"
                    End If
                ElseIf Me.txtCZRZSearch_CZSJMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtCZRZSearch_CZSJMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Me.txtCZRZSearch_CZSJMax.Text = Format(dateMax, "yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strCZSJ + " <= '" + Me.txtCZRZSearch_CZSJMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strCZSJ + " <= '" + Me.txtCZRZSearch_CZSJMax.Text + "'"
                    End If
                Else
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_CZRZ = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdCZRZҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       ����������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_CZRZ( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CAOZUORIZHI

            getModuleData_CZRZ = False

            Try
                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtCZRZSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                If Not (Me.m_objDataSet_CZRZ Is Nothing) Then
                    Me.m_objDataSet_CZRZ.Dispose()
                    Me.m_objDataSet_CZRZ = Nothing
                End If

                '���¼�������
                If Me.m_objsystemFlowObject.getCaozuorizhiData(strErrMsg, strWhere, Me.m_objDataSet_CZRZ) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_CZRZ.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_CZRZ.Tables(strTable)
                    Me.htxtCZRZRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_CZRZ = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_CZRZ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdCZRZ����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_CZRZ(ByRef strErrMsg As String) As Boolean

            searchModuleData_CZRZ = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_CZRZ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_CZRZ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_CZRZ = strQuery
                Me.htxtCZRZQuery.Value = Me.m_strQuery_CZRZ

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_CZRZ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdCZRZ������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_CZRZ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CAOZUORIZHI

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_CZRZ = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtCZRZSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtCZRZSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_CZRZ Is Nothing Then
                    Me.grdCZRZ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_CZRZ.Tables(strTable)
                        Me.grdCZRZ.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_CZRZ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdCZRZ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdCZRZ)
                    With Me.grdCZRZ.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdCZRZ.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdCZRZ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_CZRZ) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_CZRZ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdCZRZ�������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_CZRZ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CAOZUORIZHI

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_CZRZ = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_CZRZ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_CZRZ.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblCZRZGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdCZRZ, .Count)

                    '��ʾҳ���������
                    Me.lnkCZCZRZMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdCZRZ, .Count)
                    Me.lnkCZCZRZMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdCZRZ, .Count)
                    Me.lnkCZCZRZMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdCZRZ, .Count)
                    Me.lnkCZCZRZMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdCZRZ, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZCZRZDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZCZRZSelectAll.Enabled = blnEnabled
                    Me.lnkCZCZRZGotoPage.Enabled = blnEnabled
                    Me.lnkCZCZRZSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_CZRZ = True
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
                    objControlProcess.doTranslateKey(Me.txtCZRZPageIndex)
                    objControlProcess.doTranslateKey(Me.txtCZRZPageSize)
                    objControlProcess.doTranslateKey(Me.txtCZRZSearch_CZR)
                    objControlProcess.doTranslateKey(Me.txtCZRZSearch_CZSM)
                    objControlProcess.doTranslateKey(Me.txtCZRZSearch_CZSJMin)
                    objControlProcess.doTranslateKey(Me.txtCZRZSearch_CZSJMax)
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '��ʾģ�鼶����
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ����
                If Me.getModuleData_CZRZ(strErrMsg, Me.m_strQuery_CZRZ) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_CZRZ(strErrMsg) = False Then
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
                    If Me.m_objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + Me.m_objsystemFlowObject.FlowData.WJBS + "]��[ǿ�Ʊ༭��־]��") = False Then
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
        'ʵ�ֶ�grdCZRZ�����С��еĹ̶�
        Sub grdCZRZ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdCZRZ.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_CZRZ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_CZRZ > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_CZRZ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdCZRZ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdCZRZ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCZRZ.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblCZRZGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdCZRZ, Me.m_intRows_CZRZ)
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

        Private Sub grdCZRZ_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdCZRZ.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CAOZUORIZHI

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
                If Me.getModuleData_CZRZ(strErrMsg, Me.m_strQuery_CZRZ) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                strOldCommand = Me.m_objDataSet_CZRZ.Tables(strTable).DefaultView.Sort

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                Me.m_objDataSet_CZRZ.Tables(strTable).DefaultView.Sort = strFinalCommand

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtCZRZSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtCZRZSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtCZRZSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_CZRZ(strErrMsg) = False Then
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




        Private Sub doMoveFirst_CZRZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_CZRZ(strErrMsg, Me.m_strQuery_CZRZ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdCZRZ.PageCount)
                Me.grdCZRZ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_CZRZ(strErrMsg) = False Then
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

        Private Sub doMoveLast_CZRZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_CZRZ(strErrMsg, Me.m_strQuery_CZRZ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdCZRZ.PageCount - 1, Me.grdCZRZ.PageCount)
                Me.grdCZRZ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_CZRZ(strErrMsg) = False Then
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

        Private Sub doMoveNext_CZRZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_CZRZ(strErrMsg, Me.m_strQuery_CZRZ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdCZRZ.CurrentPageIndex + 1, Me.grdCZRZ.PageCount)
                Me.grdCZRZ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_CZRZ(strErrMsg) = False Then
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

        Private Sub doMovePrevious_CZRZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_CZRZ(strErrMsg, Me.m_strQuery_CZRZ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdCZRZ.CurrentPageIndex - 1, Me.grdCZRZ.PageCount)
                Me.grdCZRZ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_CZRZ(strErrMsg) = False Then
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

        Private Sub doGotoPage_CZRZ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtCZRZPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_CZRZ(strErrMsg, Me.m_strQuery_CZRZ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdCZRZ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_CZRZ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtCZRZPageIndex.Text = (Me.grdCZRZ.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_CZRZ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtCZRZPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_CZRZ(strErrMsg, Me.m_strQuery_CZRZ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdCZRZ.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_CZRZ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtCZRZPageSize.Text = (Me.grdCZRZ.PageSize).ToString()

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

        Private Sub doSelectAll_CZRZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdCZRZ, 0, Me.m_cstrCheckBoxIdInDataGrid_CZRZ, True) = False Then
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

        Private Sub doDeSelectAll_CZRZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdCZRZ, 0, Me.m_cstrCheckBoxIdInDataGrid_CZRZ, False) = False Then
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

        Private Sub doSearch_CZRZ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_CZRZ(strErrMsg) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_CZRZ(strErrMsg) = False Then
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

        Private Sub lnkCZCZRZMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZCZRZMoveFirst.Click
            Me.doMoveFirst_CZRZ("lnkCZCZRZMoveFirst")
        End Sub

        Private Sub lnkCZCZRZMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZCZRZMoveLast.Click
            Me.doMoveLast_CZRZ("lnkCZCZRZMoveLast")
        End Sub

        Private Sub lnkCZCZRZMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZCZRZMoveNext.Click
            Me.doMoveNext_CZRZ("lnkCZCZRZMoveNext")
        End Sub

        Private Sub lnkCZCZRZMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZCZRZMovePrev.Click
            Me.doMovePrevious_CZRZ("lnkCZCZRZMovePrev")
        End Sub

        Private Sub lnkCZCZRZGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZCZRZGotoPage.Click
            Me.doGotoPage_CZRZ("lnkCZCZRZGotoPage")
        End Sub

        Private Sub lnkCZCZRZSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZCZRZSetPageSize.Click
            Me.doSetPageSize_CZRZ("lnkCZCZRZSetPageSize")
        End Sub

        Private Sub lnkCZCZRZSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZCZRZSelectAll.Click
            Me.doSelectAll_CZRZ("lnkCZCZRZSelectAll")
        End Sub

        Private Sub lnkCZCZRZDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZCZRZDeSelectAll.Click
            Me.doDeSelectAll_CZRZ("lnkCZCZRZDeSelectAll")
        End Sub

        Private Sub btnCZRZSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCZRZSearch.Click
            Me.doSearch_CZRZ("btnCZRZSearch")
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

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_CAOZUORIZHI

            Try
                '��ȡ����
                If Me.getModuleData_CZRZ(strErrMsg, Me.m_strQuery_CZRZ) = False Then
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
                    .iQueryTable = Me.m_objDataSet_CZRZ.Tables(strTable)
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
