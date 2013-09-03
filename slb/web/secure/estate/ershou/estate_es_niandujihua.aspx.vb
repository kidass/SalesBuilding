Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_es_niandujihua
    ' 
    ' �������ʣ�
    '     ��������
    '
    ' ���������� 
    '   �����ز�_B_����_������ȼƻ�������ģ��
    '----------------------------------------------------------------

    Public Class estate_es_niandujihua
        Inherits Josco.JsKernal.web.PageBase


  

#Region " Web ������������ɵĴ��� "

            '�õ����� Web ���������������ġ�
            <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
            Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
            Protected WithEvents lnkMLAddNew As System.Web.UI.WebControls.LinkButton
            Protected WithEvents lnkMLUpdate As System.Web.UI.WebControls.LinkButton
            Protected WithEvents lnkMLDelete As System.Web.UI.WebControls.LinkButton
            Protected WithEvents lnkMLRefresh As System.Web.UI.WebControls.LinkButton
            Protected WithEvents lnkMLClose As System.Web.UI.WebControls.LinkButton
            Protected WithEvents txtSearch_JHND As System.Web.UI.WebControls.TextBox
            Protected WithEvents txtSearch_JHLX As System.Web.UI.WebControls.TextBox
            Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
            Protected WithEvents grdObjects As System.Web.UI.WebControls.DataGrid
            Protected WithEvents lnkCZDeSelectAll As System.Web.UI.WebControls.LinkButton
            Protected WithEvents lnkCZSelectAll As System.Web.UI.WebControls.LinkButton
            Protected WithEvents lnkCZMoveFirst As System.Web.UI.WebControls.LinkButton
            Protected WithEvents lnkCZMovePrev As System.Web.UI.WebControls.LinkButton
            Protected WithEvents lnkCZMoveNext As System.Web.UI.WebControls.LinkButton
            Protected WithEvents lnkCZMoveLast As System.Web.UI.WebControls.LinkButton
            Protected WithEvents lnkCZGotoPage As System.Web.UI.WebControls.LinkButton
            Protected WithEvents txtPageIndex As System.Web.UI.WebControls.TextBox
            Protected WithEvents lnkCZSetPageSize As System.Web.UI.WebControls.LinkButton
            Protected WithEvents txtPageSize As System.Web.UI.WebControls.TextBox
            Protected WithEvents lblGridLocInfo As System.Web.UI.WebControls.Label
            Protected WithEvents txtJHND As System.Web.UI.WebControls.TextBox
        Protected WithEvents rblJHLX As System.Web.UI.WebControls.RadioButtonList
            Protected WithEvents btnSave As System.Web.UI.WebControls.Button
            Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
            Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
            Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
            Protected WithEvents btnGoBack As System.Web.UI.WebControls.Button
            Protected WithEvents panelError As System.Web.UI.WebControls.Panel
            Protected WithEvents popMessageObject As Josco.Web.PopMessage
            Protected WithEvents htxtOBJECTSFixed As System.Web.UI.HtmlControls.HtmlInputHidden
            Protected WithEvents htxtCurrentPage As System.Web.UI.HtmlControls.HtmlInputHidden
            Protected WithEvents htxtCurrentRow As System.Web.UI.HtmlControls.HtmlInputHidden
            Protected WithEvents htxtEditMode As System.Web.UI.HtmlControls.HtmlInputHidden
            Protected WithEvents htxtEditType As System.Web.UI.HtmlControls.HtmlInputHidden
            Protected WithEvents htxtQuery As System.Web.UI.HtmlControls.HtmlInputHidden
            Protected WithEvents htxtRows As System.Web.UI.HtmlControls.HtmlInputHidden
            Protected WithEvents htxtSort As System.Web.UI.HtmlControls.HtmlInputHidden
            Protected WithEvents htxtSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
            Protected WithEvents htxtSortType As System.Web.UI.HtmlControls.HtmlInputHidden
            Protected WithEvents htxtDivLeftObject As System.Web.UI.HtmlControls.HtmlInputHidden
            Protected WithEvents htxtDivTopObject As System.Web.UI.HtmlControls.HtmlInputHidden
            Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
            Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtJHED As System.Web.UI.WebControls.TextBox
        Protected WithEvents rblSearch_JHLX As System.Web.UI.WebControls.RadioButtonList

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
        Private m_cstrRelativePathToImage As String = "../../../"


        '----------------------------------------------------------------
        'ģ����Ȩ����
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_es_niandujihua_previlege_param"
        Private m_blnPrevilegeParams(4) As Boolean

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateNianduJihua
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateNianduJihua
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdObjects��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid As String = "chkObjects"
        Private Const m_cstrDataGridInDIV As String = "divObjects"
        Private m_intFixedColumns As Integer

        '----------------------------------------------------------------
        '��ǰ��������ݼ�
        '----------------------------------------------------------------
        Private m_objestatErshouDataT As Josco.JSOA.Common.Data.estateErshouDataT
        Private m_strQuery As String
        Private m_intRows As Integer

        '----------------------------------------------------------------
        '����ģ��˽�ò���
        '----------------------------------------------------------------
        '��ϸ�༭ģʽ
        Private m_objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        '�Ƿ�Ϊ�༭״̬
        Private m_blnEditMode As Boolean
        '����༭ģʽǰ��¼��ҳλ��
        Private m_intCurrentPageIndex As Integer
        '����༭ģʽǰ��¼����λ��
        Private m_intCurrentSelectIndex As Integer


        Private Sub doGoBack(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strSessionId As String
                Dim strUrl As String
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                If strSessionId Is Nothing Then strSessionId = ""
                If strSessionId <> "" Then
                    Try
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateNianduJihua)
                    Catch ex As Exception
                        Me.m_objInterface = Nothing
                    End Try
                Else
                    Me.m_objInterface = Nothing
                End If
                If Not (Me.m_objInterface Is Nothing) Then
                    '���÷��ز���
                    '���ص�����ģ�飬�����ӷ��ز���
                    'Ҫ���ص�SessionId
                    strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    'SessionId���ӵ����ص�Url
                    strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                Else
                    strUrl = Josco.JsKernal.Common.jsoaConfiguration.GeneralReturnUrl
                End If
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

        Private Sub btnGoBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGoBack.Click
            Me.doGoBack("btnGoBack")
        End Sub





        '----------------------------------------------------------------
        ' ��ȡȨ�޲���
        '     strErrMsg          �����ش�����Ϣ
        '     blnContinueExecute ���Ƿ����ִ�к�������
        ' ����
        '     True               ���ɹ�
        '     False              ��ʧ��
        '----------------------------------------------------------------
        Private Function getPrevilegeParams( _
            ByRef strErrMsg As String, _
            ByRef blnContinueExecute As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemAppManager As New Josco.JsKernal.BusinessFacade.systemAppManager
            Dim objMokuaiQXData As Josco.JsKernal.Common.Data.AppManagerData

            getPrevilegeParams = False
            blnContinueExecute = False

            Try
                Dim intCount As Integer
                Dim i As Integer

                '���ݵ�¼�û���ȡģ��Ȩ������
                If MyBase.UserId.ToUpper() = "SA" Then
                    '����ԱȨ��
                    intCount = Me.m_blnPrevilegeParams.Length
                    For i = 0 To intCount - 1 Step 1
                        Me.m_blnPrevilegeParams(i) = True
                    Next
                    blnContinueExecute = True
                    Exit Try
                Else
                    '��ͨ�û�Ȩ��
                    If objsystemAppManager.getDBUserMokuaiQXData(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserId, objMokuaiQXData) = False Then
                        GoTo errProc
                    End If
                End If

                '���Ȩ��
                Dim strFirstParamValue As String
                Dim strParamValue As String
                Dim strParamName As String
                Dim strMKMC As String
                Dim strFilter As String
                strMKMC = Josco.JsKernal.Common.Data.AppManagerData.FIELD_GL_B_YINGYONGXITONG_MOKUAIQX_MKMC
                With objMokuaiQXData.Tables(Josco.JsKernal.Common.Data.AppManagerData.TABLE_GL_B_YINGYONGXITONG_MOKUAIQX)
                    intCount = Me.m_blnPrevilegeParams.Length
                    For i = 0 To intCount - 1 Step 1
                        '���������
                        strParamName = i.ToString()
                        If strParamName.Length < 2 Then strParamName = "0" + strParamName
                        strParamName = Me.m_cstrPrevilegeParamPrefix + strParamName

                        '��ȡ����ֵ
                        With objPulicParameters
                            strParamValue = .getObjectValue(Josco.JsKernal.Common.jsoaSecureConfiguration.ReadSetting(strParamName, ""), "")
                        End With
                        If i = 0 Then strFirstParamValue = strParamValue

                        '��ȡ������Ӧ��Ȩ��
                        strFilter = strMKMC + " = '" + strParamValue + "'"
                        .DefaultView.RowFilter = strFilter
                        If .DefaultView.Count > 0 Then
                            Me.m_blnPrevilegeParams(i) = True
                        Else
                            Me.m_blnPrevilegeParams(i) = False
                        End If
                    Next

                End With

                '�Ƿ����ִ��
                If Me.m_blnPrevilegeParams(0) = True Then
                    blnContinueExecute = True
                Else
                    Me.panelError.Visible = True
                    Me.lblMessage.Text = "������û��[" + strFirstParamValue + "]��ִ��Ȩ�ޣ�����ϵͳ����Ա��ϵ��лл��"
                    Me.panelMain.Visible = Not Me.panelError.Visible
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemAppManager.SafeRelease(objsystemAppManager)
            Josco.JsKernal.Common.Data.AppManagerData.SafeRelease(objMokuaiQXData)

            getPrevilegeParams = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemAppManager.SafeRelease(objsystemAppManager)
            Josco.JsKernal.Common.Data.AppManagerData.SafeRelease(objMokuaiQXData)
            Exit Function

        End Function



        '----------------------------------------------------------------
        ' ��ԭģ���ֳ���Ϣ���ͷ���Ӧ����Դ
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftObject.Value = .htxtDivLeftObject
                    Me.htxtDivTopObject.Value = .htxtDivTopObject

                    Me.htxtCurrentPage.Value = .htxtCurrentPage
                    Me.htxtCurrentRow.Value = .htxtCurrentRow
                    Me.htxtEditMode.Value = .htxtEditMode
                    Me.htxtEditType.Value = .htxtEditType

                    Me.htxtQuery.Value = .htxtQuery
                    Me.htxtRows.Value = .htxtRows
                    Me.htxtSort.Value = .htxtSort
                    Me.htxtSortColumnIndex.Value = .htxtSortColumnIndex
                    Me.htxtSortType.Value = .htxtSortType

                    Me.txtJHND.Text = .txtJHND
                    Me.rblJHLX.SelectedIndex = .rblJHLX_SelectedIndex
                    Me.txtJHED.Text = .txtJHED

                    Me.txtSearch_JHND.Text = .txtSearch_JHND
                    Me.rblSearch_JHLX.SelectedIndex = .rblSearch_JHLX_SelectedIndex

                    Me.txtPageIndex.Text = .txtPageIndex
                    Me.txtPageSize.Text = .txtPageSize
                    Try
                        Me.grdObjects.PageSize = .grdObjects_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdObjects.CurrentPageIndex = .grdObjects_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdObjects.SelectedIndex = .grdObjects_SelectedIndex
                    Catch ex As Exception
                    End Try
                End With

                '�ͷ���Դ
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing

            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' ����ģ���ֳ���Ϣ��������Ӧ��SessionId
        '----------------------------------------------------------------
        Private Function saveModuleInformation() As String

            Dim strSessionId As String = ""

            saveModuleInformation = ""

            Try
                '����SessionId
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strSessionId = .getNewGuid()
                End With
                If strSessionId = "" Then
                    Exit Try
                End If

                '��������
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateNianduJihua

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftObject = Me.htxtDivLeftObject.Value
                    .htxtDivTopObject = Me.htxtDivTopObject.Value

                    .htxtCurrentPage = Me.htxtCurrentPage.Value
                    .htxtCurrentRow = Me.htxtCurrentRow.Value
                    .htxtEditMode = Me.htxtEditMode.Value
                    .htxtEditType = Me.htxtEditType.Value

                    .htxtQuery = Me.htxtQuery.Value
                    .htxtRows = Me.htxtRows.Value
                    .htxtSort = Me.htxtSort.Value
                    .htxtSortColumnIndex = Me.htxtSortColumnIndex.Value
                    .htxtSortType = Me.htxtSortType.Value

                    '.txtMMDM = Me.txtMMDM.Text
                    '.txtMMMC = Me.txtMMMC.Text

                    '.txtSearch_MMDM = Me.txtSearch_MMDM.Text
                    '.txtSearch_MMMC = Me.txtSearch_MMMC.Text
                    .txtJHND = Me.txtJHND.Text
                    .rblJHLX_SelectedIndex = Me.rblJHLX.SelectedIndex
                    .txtJHED = Me.txtJHED.Text

                    .rblSearch_JHLX_SelectedIndex = Me.rblSearch_JHLX.SelectedIndex
                    .txtSearch_JHND = Me.txtSearch_JHND.Text

                    .txtPageIndex = Me.txtPageIndex.Text
                    .txtPageSize = Me.txtPageSize.Text
                    .grdObjects_PageSize = Me.grdObjects.PageSize
                    .grdObjects_CurrentPageIndex = Me.grdObjects.CurrentPageIndex
                    .grdObjects_SelectedIndex = Me.grdObjects.SelectedIndex
                End With

                '�������
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            saveModuleInformation = strSessionId
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ӵ���ģ���л�ȡ����
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getDataFromCallModule = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ͷŽӿڲ���
        '----------------------------------------------------------------
        Private Sub releaseInterfaceParameters()

            Try
                If Not (Me.m_objInterface Is Nothing) Then
                    If Me.m_objInterface.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputOnly Then
                        Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                        Me.m_objInterface.Dispose()
                        Me.m_objInterface = Nothing
                    End If
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub


        '----------------------------------------------------------------
        ' ��ȡ�ӿڲ���
        '----------------------------------------------------------------
        Private Function getInterfaceParameters(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateNianduJihua)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    'û���нӿڲ���
                Else
                    Me.m_blnInterface = True
                    '�нӿڲ���
                End If

                '��ȡ�ָ��ֳ�����
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateNianduJihua)
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

                With objPulicParameters
                    '�Ƿ��ڱ༭״̬
                    Me.m_blnEditMode = .getObjectValue(Me.htxtEditMode.Value, False)

                    '����༭ģʽǰ��¼��ҳλ��
                    Me.m_intCurrentPageIndex = .getObjectValue(Me.htxtCurrentPage.Value, 0)

                    '����༭ģʽǰ��¼����λ��
                    Me.m_intCurrentSelectIndex = .getObjectValue(Me.htxtCurrentRow.Value, -1)

                    '��ǰ�༭ģʽ
                    Dim intEditType As Integer
                    intEditType = .getObjectValue(Me.htxtEditType.Value, 0)
                    Try
                        Me.m_objenumEditType = CType(intEditType, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType)
                    Catch ex As Exception
                        Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    End Try

                    '������
                    Me.m_strQuery = Me.htxtQuery.Value

                    '��¼��
                    Me.m_intRows = .getObjectValue(Me.htxtRows.Value, 0)

                    Me.m_intFixedColumns = .getObjectValue(Me.htxtOBJECTSFixed.Value, 0)
                End With


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

            Catch ex As Exception

            End Try

            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' ��ȡģ����������(Ĭ�ϱ�ǰ׺a.)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString = False
            strQuery = ""

            Try
                '���ƻ��������
                Dim strJHND As String = "a." + Josco.JSOA.Common.Data.estateErshouDataT.FIELD_ESTATE_ERSHOU_B_ES_NIANDUJIHUA_JHND
                If Me.txtSearch_JHND.Text.Length > 0 Then Me.txtSearch_JHND.Text = Me.txtSearch_JHND.Text.Trim()
                If Me.txtSearch_JHND.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strJHND + " like '" + Me.txtSearch_JHND.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJHND + " like '" + Me.txtSearch_JHND.Text + "%'"
                    End If
                End If

                '���ƻ���������
                Dim strJHLX As String = "a." + Josco.JSOA.Common.Data.estateErshouDataT.FIELD_ESTATE_ERSHOU_B_ES_NIANDUJIHUA_JHLX
                If Me.rblSearch_JHLX.SelectedIndex > -1 Then
                    If Me.rblSearch_JHLX.SelectedIndex = 0 Then
                        If strQuery = "" Then
                            strQuery = strJHLX + " & 0x1=1"
                        Else
                            strQuery = strQuery + " and " + strJHLX + " & 0x1=1"
                        End If
                    ElseIf Me.rblSearch_JHLX.SelectedIndex = 1 Then
                        If strQuery = "" Then
                            strQuery = strJHLX + " & 0x2=2"
                        Else
                            strQuery = strQuery + " and " + strJHLX + " & 0x2=2"
                        End If
                    End If
                End If
                
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡģ��Ҫ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       �������ַ���
        '     blnEditMode    ����ǰ�༭״̬
        '     objenumEditType����ϸ����ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouDataT.TABLE_ESTATE_ERSHOU_B_ES_NIANDUJIHUA
            Dim objsystemEstateErshouT As New Josco.JSOA.BusinessFacade.systemEstateErshouT

            getModuleData = False

            Try
                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateErshouDataT.SafeRelease(Me.m_objestatErshouDataT)

                '���¼�������
                With objsystemEstateErshouT
                    If .getDataSet_EsNianduJihua(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objestatErshouDataT) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ�Sort�ַ���
                With Me.m_objestatErshouDataT.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                If blnEditMode = False Then '�鿴ģʽ
                    With Me.m_objestatErshouDataT.Tables(strTable)
                        .DefaultView.AllowNew = False
                    End With
                Else '�༭ģʽ
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            '����1���ռ�¼
                            With Me.m_objestatErshouDataT.Tables(strTable)
                                .DefaultView.AllowNew = True
                                .DefaultView.AddNew()
                            End With
                        Case Else
                            With Me.m_objestatErshouDataT.Tables(strTable)
                                .DefaultView.AllowNew = False
                            End With
                    End Select
                End If

                '�������
                With Me.m_objestatErshouDataT.Tables(strTable)
                    Me.htxtRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshouT.SafeRelease(objsystemEstateErshouT)

            getModuleData = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshouT.SafeRelease(objsystemEstateErshouT)
            Exit Function

        End Function


        '----------------------------------------------------------------
        ' ������Ļ����������������
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ����ǰ�༭״̬
        '     objenumEditType����ϸ����ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            searchModuleData = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData(strErrMsg, strQuery, blnEditMode, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery = strQuery
                Me.htxtQuery.Value = Me.m_strQuery

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData = True
            Exit Function

errProc:
            Exit Function

        End Function


        '----------------------------------------------------------------
        ' ��ʾDataGrid������
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ����ǰ�༭״̬
        '     objenumEditType����ϸ����ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouDataT.TABLE_ESTATE_ERSHOU_B_ES_NIANDUJIHUA
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objestatErshouDataT Is Nothing Then
                    Me.grdObjects.DataSource = Nothing
                Else
                    With Me.m_objestatErshouDataT.Tables(strTable)
                        Me.grdObjects.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objestatErshouDataT.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdObjects, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '����Ǳ༭ģʽ
                If blnEditMode = True Then
                    '�ƶ�������¼
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            With Me.m_objestatErshouDataT.Tables(strTable)
                                Dim intPageIndex As Integer
                                Dim intSelectIndex As Integer
                                If objDataGridProcess.doMoveToRecord(Me.grdObjects.AllowPaging, Me.grdObjects.PageSize, .DefaultView.Count - 1, intPageIndex, intSelectIndex) = False Then
                                    strErrMsg = "�����޷��ƶ������"
                                    GoTo errProc
                                End If
                                Try
                                    Me.grdObjects.CurrentPageIndex = intPageIndex
                                    Me.grdObjects.SelectedIndex = intSelectIndex
                                Catch ex As Exception
                                End Try
                            End With
                        Case Else
                    End Select
                End If

                '����������
                Me.grdObjects.AllowSorting = Not blnEditMode

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdObjects)
                    With Me.grdObjects.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdObjects.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdObjects, Request, 0, Me.m_cstrCheckBoxIdInDataGrid) = False Then
                    GoTo errProc
                End If

                '����Ǳ༭ģʽ
                If blnEditMode = True Then
                    'ʹ������
                    If objDataGridProcess.doEnabledDataGrid(strErrMsg, Me.grdObjects, Not blnEditMode) = False Then
                        GoTo errProc
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function



        '----------------------------------------------------------------
        ' ��ʾ�༭��������(��������ǰ��������ʾ)
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ����ǰ�༭״̬
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showEditPanelInfo( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showEditPanelInfo = False

            Try
                If blnEditMode = False Then
                    '�鿴״̬
                    If Me.grdObjects.Items.Count < 1 Or Me.grdObjects.SelectedIndex < 0 Then
                        Me.txtJHND.Text = ""
                        Me.txtJHED.Text = ""
                        Me.rblJHLX.SelectedIndex = -1
                    Else
                        Dim intColIndex(3) As Integer
                        intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.estateErshouDataT.FIELD_ESTATE_ERSHOU_B_ES_NIANDUJIHUA_JHND)
                        intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.estateErshouDataT.FIELD_ESTATE_ERSHOU_B_ES_NIANDUJIHUA_JHED)
                        intColIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.estateErshouDataT.FIELD_ESTATE_ERSHOU_B_ES_NIANDUJIHUA_JHLX)
                        Me.txtJHND.Text = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(Me.grdObjects.SelectedIndex), intColIndex(0))
                        Dim strJhlx As String = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(Me.grdObjects.SelectedIndex), intColIndex(2))
                        If CType(strJhlx, Integer) = 1 Then
                            Me.rblJHLX.SelectedIndex = 0
                        ElseIf CType(strJhlx, Integer) = 2 Then
                            Me.rblJHLX.SelectedIndex = 1
                        End If
                        Me.txtJHED.Text = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(Me.grdObjects.SelectedIndex), intColIndex(1))
                        End If
                End If

                'ʹ�ܿؼ�
                With objControlProcess
                    .doEnabledControl(Me.txtJHND, blnEditMode)
                    .doEnabledControl(Me.txtJHED, blnEditMode)
                    .doEnabledControl(Me.rblJHLX, blnEditMode)
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanelInfo = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function


        '----------------------------------------------------------------
        ' ��ʾ����ģ�����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ����ǰ�༭״̬
        '     objenumEditType����ϸ����ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouDataT.TABLE_ESTATE_ERSHOU_B_ES_NIANDUJIHUA
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo(strErrMsg, blnEditMode, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objestatErshouDataT.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdObjects, .Count)
                    '��ʾҳ���������
                    Me.lnkCZMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdObjects, .Count) And (Not blnEditMode)
                    Me.lnkCZMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdObjects, .Count) And (Not blnEditMode)
                    Me.lnkCZMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdObjects, .Count) And (Not blnEditMode)
                    Me.lnkCZMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdObjects, .Count) And (Not blnEditMode)
                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZDeSelectAll.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZSelectAll.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZGotoPage.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZSetPageSize.Enabled = blnEnabled And (Not blnEditMode)
                    With objControlProcess
                        .doEnabledControl(Me.txtPageSize, Not blnEditMode)
                        .doEnabledControl(Me.txtPageIndex, Not blnEditMode)
                    End With

                    With objControlProcess
                        .doEnabledControl(Me.txtSearch_JHND, Not blnEditMode)
                        .doEnabledControl(Me.rblSearch_JHLX, Not blnEditMode)
                    End With
                    Me.btnSearch.Enabled = Not blnEditMode
                End With

                '��ʾ���봰��Ϣ
                If Me.showEditPanelInfo(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If

                '��ʾ��������
                Me.lnkMLAddNew.Enabled = (Not blnEditMode And Me.m_blnPrevilegeParams(1))
                Me.lnkMLUpdate.Enabled = (Not blnEditMode And Me.m_blnPrevilegeParams(2))
                Me.lnkMLDelete.Enabled = (Not blnEditMode And Me.m_blnPrevilegeParams(3))
                Me.lnkMLRefresh.Enabled = (Not blnEditMode And Me.m_blnPrevilegeParams(4))
                Me.lnkMLClose.Enabled = (Not blnEditMode)
                Me.btnSave.Enabled = blnEditMode
                Me.btnCancel.Enabled = blnEditMode

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
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
                Try
                    '���ó�ʼ��ʾ�ľ�̬��Ϣ

                    '���ݽӿڲ������ò�������Ӱ��Ĳ�����״̬

                    '��ʾPannel(�����Ƿ�ص���ʼ����ʾpanelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                    With objControlProcess
                        .doTranslateKey(Me.txtPageIndex)
                        .doTranslateKey(Me.txtPageSize)
                        .doTranslateKey(Me.txtSearch_JHLX)
                        .doTranslateKey(Me.txtSearch_JHND)
                        '.doTranslateKey(Me.rblSearch_JHLX)
                        .doTranslateKey(Me.txtJHED)
                        .doTranslateKey(Me.txtJHND)
                        '.doTranslateKey(Me.rblJHLX)
                    End With

                    '��ȡ����
                    If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                    '��ʾ����
                    If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            End If

            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            initializeControls = True
            Exit Function

errProc:
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function



        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            '�ڴ˴����ó�ʼ��ҳ���û�����

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim strUrl As String

            'Ԥ����
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
            End If

            '���Ȩ��(�����Ƿ�ط���)
            Dim blnDo As Boolean
            If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                GoTo errProc
            End If
            If blnDo = False Then
                GoTo normExit
            End If

            '��ȡ�ӿڲ���
            If Me.getInterfaceParameters(strErrMsg) = False Then
                GoTo errProc
            End If

            '�ؼ���ʼ��
            If Me.initializeControls(strErrMsg) = False Then
                GoTo errProc
            End If

            '��¼�����־
            If Me.IsPostBack = False Then
                If Me.m_blnSaveScence = False Then
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]������[����_������ò]�ֵ䣡")
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



        '----------------------------------------------------------------
        '�����¼�������
        '----------------------------------------------------------------
        'ʵ�ֶ������С��еĹ̶�
        Sub grdObjects_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdObjects.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV + ".scrollTop)")
                    Next
                End If

                If Me.m_intFixedColumns > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdObjects.ID + "Locked"
                    Next
                End If

            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdObjects_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdObjects.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                With New Josco.JsKernal.web.DataGridProcess
                    Me.lblGridLocInfo.Text = .getDataGridLocation(Me.grdObjects, Me.m_intRows)
                End With
                'ͬ����ʾ�༭����Ϣ
                If Me.showEditPanelInfo(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub grdObjects_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdObjects.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_ZHENGZHIMIANMAO
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
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                With Me.m_objestatErshouDataT.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                With Me.m_objestatErshouDataT.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doMoveFirst(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdObjects.PageCount)
                Me.grdObjects.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doMoveLast(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdObjects.PageCount - 1, Me.grdObjects.PageCount)
                Me.grdObjects.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdObjects.CurrentPageIndex + 1, Me.grdObjects.PageCount)
                Me.grdObjects.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdObjects.CurrentPageIndex - 1, Me.grdObjects.PageCount)
                Me.grdObjects.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doGotoPage(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdObjects.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtPageIndex.Text = (Me.grdObjects.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdObjects.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtPageSize.Text = (Me.grdObjects.PageSize).ToString()

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

        Private Sub doSelectAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdObjects, 0, Me.m_cstrCheckBoxIdInDataGrid, True) = False Then
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdObjects, 0, Me.m_cstrCheckBoxIdInDataGrid, False) = False Then
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

        Private Sub doSearch(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub lnkCZMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZMoveFirst.Click
            Me.doMoveFirst("lnkCZMoveFirst")
        End Sub

        Private Sub lnkCZMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZMoveLast.Click
            Me.doMoveLast("lnkCZMoveLast")
        End Sub

        Private Sub lnkCZMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZMoveNext.Click
            Me.doMoveNext("lnkCZMoveNext")
        End Sub

        Private Sub lnkCZMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZMovePrev.Click
            Me.doMovePrevious("lnkCZMovePrev")
        End Sub

        Private Sub lnkCZGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZGotoPage.Click
            Me.doGotoPage("lnkCZGotoPage")
        End Sub

        Private Sub lnkCZSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSetPageSize.Click
            Me.doSetPageSize("lnkCZSetPageSize")
        End Sub

        Private Sub lnkCZSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSelectAll.Click
            Me.doSelectAll("lnkCZSelectAll")
        End Sub

        Private Sub lnkCZDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZDeSelectAll.Click
            Me.doDeSelectAll("lnkCZDeSelectAll")
        End Sub

        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Me.doSearch("btnSearch")
        End Sub






        '----------------------------------------------------------------
        'ģ���������������
        '----------------------------------------------------------------
        Private Sub doAddNew(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '���ñ༭ģʽ
                Me.m_blnEditMode = True
                Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                Me.m_intCurrentPageIndex = Me.grdObjects.CurrentPageIndex
                Me.m_intCurrentSelectIndex = Me.grdObjects.SelectedIndex



                '���������Ϣ
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()
                Me.htxtEditType.Value = CType(Me.m_objenumEditType, Integer).ToString()
                Me.htxtCurrentPage.Value = Me.m_intCurrentPageIndex.ToString()
                Me.htxtCurrentRow.Value = Me.m_intCurrentSelectIndex.ToString()

                '����༭״̬
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ʾ��Ϣ
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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



        Private Sub doUpdate(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '���ñ༭ģʽ
                Me.m_blnEditMode = True
                Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                Me.m_intCurrentPageIndex = Me.grdObjects.CurrentPageIndex
                Me.m_intCurrentSelectIndex = Me.grdObjects.SelectedIndex

               

                '���������Ϣ
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()
                Me.htxtEditType.Value = CType(Me.m_objenumEditType, Integer).ToString()
                Me.htxtCurrentPage.Value = Me.m_intCurrentPageIndex.ToString()
                Me.htxtCurrentRow.Value = Me.m_intCurrentSelectIndex.ToString()

                '����༭״̬
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ʾ��Ϣ
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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



        Private Sub doSave(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouDataT.TABLE_ESTATE_ERSHOU_B_ES_NIANDUJIHUA
            Dim objsystemEstateErshouT As New Josco.JSOA.BusinessFacade.systemEstateErshouT
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ȡ����Ϣ
                Dim objNewData As New System.Collections.Specialized.NameValueCollection
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouDataT.FIELD_ESTATE_ERSHOU_B_ES_NIANDUJIHUA_WYBS, "")
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouDataT.FIELD_ESTATE_ERSHOU_B_ES_NIANDUJIHUA_JHND, Me.txtJHND.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouDataT.FIELD_ESTATE_ERSHOU_B_ES_NIANDUJIHUA_JHED, Me.txtJHED.Text)
                If Me.rblJHLX.SelectedIndex = 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouDataT.FIELD_ESTATE_ERSHOU_B_ES_NIANDUJIHUA_JHLX, "1")
                ElseIf Me.rblJHLX.SelectedIndex = 1 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateErshouDataT.FIELD_ESTATE_ERSHOU_B_ES_NIANDUJIHUA_JHLX, "2")
                End If


                '��ȡ����Ϣ
                Dim objOldData As System.Data.DataRow
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        objOldData = Nothing
                    Case Else
                        '��ȡ����
                        If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                            GoTo errProc
                        End If

                        Dim intPos As Integer
                        With New Josco.JsKernal.web.DataGridProcess
                            intPos = .getRecordPosition(Me.grdObjects.SelectedIndex, Me.grdObjects.CurrentPageIndex, Me.grdObjects.PageSize)
                        End With
                        With Me.m_objestatErshouDataT.Tables(strTable)
                            objOldData = .DefaultView.Item(intPos).Row
                        End With
                End Select

                '������Ϣ
                With objsystemEstateErshouT
                    If .doSaveData_EsNianduJihua(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData, objNewData, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                End With

                '��¼�����־
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_������ȼƻ�]�ֵ���������[" + Me.txtJHND.Text + "-" + Me.rblJHLX.SelectedItem.Text + "]��")
                    Case Else
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]������[����_������ȼƻ�]�ֵ䣡")
                End Select

                '�������ñ༭ģʽ
                Me.m_blnEditMode = False
                Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect

                '���������Ϣ
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()
                Me.htxtEditType.Value = CType(Me.m_objenumEditType, Integer).ToString()

                '���ü�¼λ��
                '����ɹ���ͣ���ڵ�ǰλ��

                '���»�ȡ����
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ʾ��Ϣ
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshouT.SafeRelease(objsystemEstateErshouT)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshouT.SafeRelease(objsystemEstateErshouT)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub



        Private Sub doCancel(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                '��ʾ��Ϣ
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷʵ׼��ȡ������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��ʾ��ش��ǡ����Ŵ���
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    'ȡ���༭
                    Me.m_blnEditMode = False
                    Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect

                    '���������Ϣ
                    Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()
                    Me.htxtEditType.Value = CType(Me.m_objenumEditType, Integer).ToString()

                    '�ָ����༭ǰ�ļ�¼λ��
                    Try
                        Me.grdObjects.CurrentPageIndex = Me.m_intCurrentPageIndex
                        Me.grdObjects.SelectedIndex = Me.m_intCurrentSelectIndex
                    Catch ex As Exception
                    End Try

                    '����Ǳ༭״̬
                    If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If

                    '��ʾ��Ϣ
                    If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
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



        Private Sub doDelete(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouDataT.TABLE_ESTATE_ERSHOU_B_ES_NIANDUJIHUA
            Dim objsystemEstateErshouT As New Josco.JSOA.BusinessFacade.systemEstateErshouT
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '���ѡ��
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer
                intRows = Me.grdObjects.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdObjects.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid) = True Then
                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "����δѡ��Ҫɾ�������ݣ�"
                        GoTo errProc
                    End If
                End If

                'ѯ��
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷʵ׼��ɾ��ѡ����[" + intSelect.ToString() + "]����������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��ʾ��ش��ǡ����Ŵ���
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��ȡ����
                    If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If

                    '���ɾ��
                    Dim objOldData As System.Data.DataRow
                    Dim intColIndex As Integer
                    Dim strJHND As String = ""
                    Dim intPos As Integer
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.estateErshouDataT.FIELD_ESTATE_ERSHOU_B_ES_NIANDUJIHUA_JHND)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdObjects.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid) = True Then
                            strJHND = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(i), intColIndex)

                            '��ȡҪɾ��������
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdObjects.CurrentPageIndex, Me.grdObjects.PageSize)
                            objOldData = Nothing
                            With Me.m_objestatErshouDataT.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            'ɾ������
                            If objsystemEstateErshouT.doDeleteData_EsNianduJihua(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData) = False Then
                                GoTo errProc
                            End If

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[�ز�_B_����_������ȼƻ�]�ֵ���ɾ����[" + strJHND + "]��")
                        End If
                    Next

                    '���»�ȡ����
                    If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If

                    'ˢ��������ʾ
                    If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshouT.SafeRelease(objsystemEstateErshouT)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshouT.SafeRelease(objsystemEstateErshouT)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub



        Private Sub doRefresh(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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


        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strSessionId As String
                Dim strUrl As String
                If Me.m_blnInterface = True Then
                    '���÷��ز���

                    '���ص�����ģ�飬�����ӷ��ز���
                    'Ҫ���ص�SessionId
                    strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    'SessionId���ӵ����ص�Url
                    strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                Else
                    strUrl = Josco.JsKernal.Common.jsoaConfiguration.GeneralReturnUrl
                End If

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



        Private Sub lnkMLRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLRefresh.Click
            Me.doRefresh("lnkMLRefresh")
        End Sub

        Private Sub lnkMLAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLAddNew.Click
            Me.doAddNew("lnkMLAddNew")
        End Sub

        Private Sub lnkMLUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLUpdate.Click
            Me.doUpdate("lnkMLUpdate")
        End Sub

        Private Sub lnkMLDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLDelete.Click
            Me.doDelete("lnkMLDelete")
        End Sub

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Me.doSave("btnSave")
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub lnkMLClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLClose.Click
            Me.doClose("lnkMLClose")
        End Sub


    End Class

End Namespace

