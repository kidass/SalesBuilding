Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_es_bb_esnddb
    ' 
    ' �������ʣ�
    '     ��������
    '
    ' ���������� 
    '   ���н鲿����ҵ����ȶԱȴ���ģ��
    '----------------------------------------------------------------

    Partial Class estate_es_bb_esnddb
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub








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
        'Url����Excelģ��Ŀ¼·��
        Private m_cstrUrlBaseToExcelMB As String = "/template/excel/"
        'Url���������ļ�Ŀ¼·��
        Private m_cstrUrlBaseToDownloadFile As String = "/temp/downloadfile/"

        '----------------------------------------------------------------
        'ģ����Ȩ����
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_es_baobiao_previlege_param"
        Private m_blnPrevilegeParams(27) As Boolean

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsBbEsNddb
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsBbEsNddb
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdContent��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid As String = "chkContent"
        Private Const m_cstrDataGridInDIV As String = "divContent"
        Private m_intFixedColumns As Integer

        '----------------------------------------------------------------
        '��ǰ���������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet As System.Data.DataSet
        Private m_strQuery As String
        Private m_intRows As Integer

        '----------------------------------------------------------------
        '����ģ��˽�ò���
        '----------------------------------------------------------------
        Private m_strGlbmSqlList As String
        Private m_blnIsFHRY As Boolean








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
                If Me.m_blnPrevilegeParams(0) = True And Me.m_blnPrevilegeParams(17) = True Then
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

            Dim strErrMsg As String = ""

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.htxtQuery.Value = .htxtQuery
                    Me.htxtRows.Value = .htxtRows
                    Me.htxtSort.Value = .htxtSort
                    Me.htxtSortColumnIndex.Value = .htxtSortColumnIndex
                    Me.htxtSortType.Value = .htxtSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftContent.Value = .htxtDivLeftContent
                    Me.htxtDivTopContent.Value = .htxtDivTopContent

                    Me.txtPageIndex.Text = .txtPageIndex
                    Me.txtPageSize.Text = .txtPageSize

                    Try
                        Me.ddlZZDM.SelectedIndex = .ddlZZDM_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlYWLX.SelectedIndex = .ddlYWLX_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlTJZB.SelectedIndex = .ddlTJZB_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlType.SelectedIndex = .ddlType_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.txtKSND.Text = .txtKSND
                    Me.txtZZND.Text = .txtZZND
                    Me.txtYJZR.Text = .txtYJZR

                    Me.htxtSessionIdBuffer.Value = .htxtSessionIdBuffer
                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Try
                        Me.grdContent.PageSize = .grdContentPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdContent.CurrentPageIndex = .grdContentCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdContent.SelectedIndex = .grdContentSelectedIndex
                    Catch ex As Exception
                    End Try
                End With

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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsBbEsNddb

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtQuery = Me.htxtQuery.Value
                    .htxtRows = Me.htxtRows.Value
                    .htxtSort = Me.htxtSort.Value
                    .htxtSortColumnIndex = Me.htxtSortColumnIndex.Value
                    .htxtSortType = Me.htxtSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftContent = Me.htxtDivLeftContent.Value
                    .htxtDivTopContent = Me.htxtDivTopContent.Value

                    .txtPageIndex = Me.txtPageIndex.Text
                    .txtPageSize = Me.txtPageSize.Text

                    .ddlZZDM_SelectedIndex = Me.ddlZZDM.SelectedIndex
                    .ddlYWLX_SelectedIndex = Me.ddlYWLX.SelectedIndex
                    .ddlTJZB_SelectedIndex = Me.ddlTJZB.SelectedIndex
                    .ddlType_SelectedIndex = Me.ddlType.SelectedIndex
                    .txtKSND = Me.txtKSND.Text
                    .txtZZND = Me.txtZZND.Text
                    .txtYJZR = Me.txtYJZR.Text

                    .htxtSessionIdBuffer = Me.htxtSessionIdBuffer.Value
                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .grdContentPageSize = Me.grdContent.PageSize
                    .grdContentCurrentPageIndex = Me.grdContent.CurrentPageIndex
                    .grdContentSelectedIndex = Me.grdContent.SelectedIndex
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.IsPostBack = True Then
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

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            strErrMsg = ""

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsBbEsNddb)
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

                '����Ĭ�ϲ�ѯ���ƣ�����ֻ�ܿ�����λ���¼���λ��Ʊ��
                Dim blnFHBZ As Boolean = True
                Dim strList As String = ""
                If objsystemEstateRenshiXingye.getBumenSqlList(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserId, Now.ToString("yyyy-MM-dd"), strList, blnFHBZ) = False Then
                    GoTo errProc
                End If
                If blnFHBZ = True And strList <> "" Then
                    Me.m_blnIsFHRY = True
                    Me.m_strGlbmSqlList = strList
                Else
                    Me.m_blnIsFHRY = False
                    Me.m_strGlbmSqlList = ""
                End If
                '����б�
                If Me.IsPostBack = False Then
                    If Me.doFillZzdmList(strErrMsg, Me.ddlZZDM) = False Then
                        GoTo errProc
                    End If
                End If

                '��ȡ�ָ��ֳ�����
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsBbEsNddb)
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

                    '��������ģ�鷵�غ����Ϣ��ͬʱ�ͷ���Ӧ��Դ
                    If Me.getDataFromCallModule(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
                Me.m_intFixedColumns = objPulicParameters.getObjectValue(Me.htxtContentFixed.Value, 0)
                Me.m_intRows = objPulicParameters.getObjectValue(Me.htxtRows.Value, 0)
                Me.m_strQuery = Me.htxtQuery.Value
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getInterfaceParameters = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ͷű�ģ�黺��Ĳ���
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
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

                If Me.htxtSessionIdBuffer.Value.Trim <> "" Then
                    Dim objBufferData As Josco.JSOA.Common.Data.estateErshouData = Nothing
                    Try
                        objBufferData = CType(Session(Me.htxtSessionIdBuffer.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        objBufferData = Nothing
                    End Try
                    If Not (objBufferData Is Nothing) Then
                        objBufferData.Dispose()
                        objBufferData = Nothing
                    End If
                    Session.Remove(Me.htxtSessionIdBuffer.Value)
                    Me.htxtSessionIdBuffer.Value = ""
                End If
            Catch ex As Exception
            End Try

        End Sub













        '----------------------------------------------------------------
        ' ��ȡgrdContent��������(rowfilter��ʽ)
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
        ' ��鱨������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ����Ч
        '     False          ����Ч
        '----------------------------------------------------------------
        Private Function doCheckParam(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doCheckParam = False
            Try
                If Me.txtKSND.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[��ʼ���]��"
                    Exit Try
                End If
                If objPulicParameters.isIntegerString(Me.txtKSND.Text) = False Then
                    strErrMsg = "������Ч��[��ʼ���]��"
                    Exit Try
                End If
                Dim intKSND As Integer = CType(Me.txtKSND.Text, Integer)
                If intKSND <= 0 Or intKSND > 9999 Then
                    strErrMsg = "������Ч��[��ʼ���]��"
                    Exit Try
                End If

                If Me.txtZZND.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[��ֹ���]��"
                    Exit Try
                End If
                If objPulicParameters.isIntegerString(Me.txtZZND.Text) = False Then
                    strErrMsg = "������Ч��[��ֹ���]��"
                    Exit Try
                End If
                Dim intZZND As Integer = CType(Me.txtZZND.Text, Integer)
                If intZZND <= 0 Or intZZND > 9999 Then
                    strErrMsg = "������Ч��[��ֹ���]��"
                    Exit Try
                End If

                If Me.txtYJZR.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[�½�ֹ��]��"
                    Exit Try
                End If
                If objPulicParameters.isIntegerString(Me.txtYJZR.Text) = False Then
                    strErrMsg = "������Ч��[�½�ֹ��]��"
                    Exit Try
                End If
                Dim intYJZR As Integer = CType(Me.txtYJZR.Text, Integer)
                If intYJZR <= 0 Or intYJZR > 28 Then
                    strErrMsg = "������Ч��[�½�ֹ��]��"
                    Exit Try
                End If

                If Me.ddlType.SelectedIndex < 0 Then
                    strErrMsg = "����û��ָ��[ͳ������]��"
                    Exit Try
                End If
                If objPulicParameters.isIntegerString(Me.ddlType.SelectedItem.Value) = False Then
                    strErrMsg = "������Ч��[ͳ������]��"
                    Exit Try
                End If

                If Me.m_blnIsFHRY = True Then
                    If Me.ddlZZDM.SelectedIndex < 0 Then
                        strErrMsg = "����û��ָ��[ͳ�Ʋ���]��"
                        Exit Try
                    End If
                End If

                doCheckParam = True
            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡ��������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ����Ч
        '     False          ����Ч
        '----------------------------------------------------------------
        Private Function getReportParam( _
            ByRef strErrMsg As String, _
            ByRef intKSND As Integer, _
            ByRef intZZND As Integer, _
            ByRef intYJZR As Integer, _
            ByRef intType As Integer, _
            ByRef strYWLX As String, _
            ByRef strBMDM As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getReportParam = False
            intKSND = 0
            intZZND = 0
            intYJZR = 0
            intType = 0
            strYWLX = ""
            strBMDM = ""

            Try
                '���
                If Me.doCheckParam(strErrMsg) = False Then
                    GoTo errProc
                End If

                '����
                intKSND = objPulicParameters.getObjectValue(Me.txtKSND.Text, 0)
                intZZND = objPulicParameters.getObjectValue(Me.txtZZND.Text, 0)
                intYJZR = objPulicParameters.getObjectValue(Me.txtYJZR.Text, 0)
                intType = objPulicParameters.getObjectValue(Me.ddlType.SelectedItem.Value, 0)
                If Me.ddlYWLX.SelectedIndex >= 0 Then
                    strYWLX = Me.ddlYWLX.SelectedItem.Value
                End If
                If Me.ddlZZDM.SelectedIndex > 0 Then
                    strBMDM = Me.ddlZZDM.SelectedItem.Value
                End If
                Dim intValue As Integer
                If intKSND > intZZND Then
                    intValue = intZZND
                    intZZND = intKSND
                    intKSND = intValue
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getReportParam = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdContentҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       �������ַ���
        '     blnEnfored     ��ǿ�����¼���
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String, _
            ByVal blnEnfored As Boolean) As Boolean

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim intTable As Integer = CType(Me.ddlTJZB.SelectedItem.Value, Integer)

            getModuleData = False

            Try
                Dim intKSND As Integer
                Dim intZZND As Integer
                Dim intYJZR As Integer
                Dim intType As Integer
                Dim strYWLX As String = ""
                Dim strBMDM As String = ""

                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�������
                If blnEnfored = True Then
                    If Me.htxtSessionIdBuffer.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet = CType(Session(Me.htxtSessionIdBuffer.Value), System.Data.DataSet)
                        Catch ex As Exception
                            Me.m_objDataSet = Nothing
                        End Try
                        Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(Me.m_objDataSet)
                        Session.Remove(Me.htxtSessionIdBuffer.Value)
                        Me.htxtSessionIdBuffer.Value = ""
                    End If
                End If

                '��������
                If Me.htxtSessionIdBuffer.Value.Trim <> "" Then
                    '�ӻ����ȡ����
                    Me.m_objDataSet = CType(Session(Me.htxtSessionIdBuffer.Value), System.Data.DataSet)
                Else
                    '���»�ȡ����
                    Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(Me.m_objDataSet)

                    '�״ν���
                    If Me.IsPostBack = False Then
                        '����������
                        Me.m_objDataSet = New Josco.JSOA.Common.Data.estateErshouData(Josco.JSOA.Common.Data.estateErshouData.enumTableType.DC_VT_ES_BB_NDDB)
                        Dim objDataTable As System.Data.DataTable = Nothing
                        Dim intCount As Integer = 5
                        Dim i As Integer
                        For i = 0 To intCount - 1 Step 1
                            objDataTable = Me.m_objDataSet.Tables(0).Clone()
                            objDataTable.TableName = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_VT_ES_BB_NDDB + "_" + i.ToString()
                            Me.m_objDataSet.Tables.Add(objDataTable)
                        Next
                    Else
                        '��ȡ����
                        If Me.getReportParam(strErrMsg, intKSND, intZZND, intYJZR, intType, strYWLX, strBMDM) = False Then
                            GoTo errProc
                        End If
                        '���¼�������
                        If objsystemEstateErshou.getDataSet_BB_ESNDDB(strErrMsg, MyBase.UserId, MyBase.UserPassword, intKSND, intZZND, intYJZR, intType, strYWLX, strBMDM, Me.m_objDataSet) = False Then
                            GoTo errProc
                        End If
                    End If

                    '��������
                    Me.htxtSessionIdBuffer.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionIdBuffer.Value, Me.m_objDataSet)
                End If

                '�ָ������ַ���
                With Me.m_objDataSet.Tables(intTable)
                    .DefaultView.RowFilter = strWhere
                End With

                '�ָ�Sort�ַ���
                With Me.m_objDataSet.Tables(intTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet.Tables(intTable)
                    Me.htxtRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdContent����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData( _
            ByRef strErrMsg As String) As Boolean

            searchModuleData = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String = ""
                If Me.getQueryString(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData(strErrMsg, strQuery, False) = False Then
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
        ' ��ʾgrdContent������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo( _
            ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim intTable As Integer = CType(Me.ddlTJZB.SelectedItem.Value, Integer)

            showDataGridInfo = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
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
                If Me.m_objDataSet Is Nothing Then
                    Me.grdContent.DataSource = Nothing
                Else
                    With Me.m_objDataSet.Tables(intTable)
                        Me.grdContent.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet.Tables(intTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdContent, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdContent)
                    With Me.grdContent.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdContent.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdContent, Request, 0, Me.m_cstrCheckBoxIdInDataGrid) = False Then
                '    GoTo errProc
                'End If
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
        ' ��ʾgrdContent��صĿ�����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData( _
            ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim intTable As Integer = CType(Me.ddlTJZB.SelectedItem.Value, Integer)

            showModuleData = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet.Tables(intTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdContent, .Count)

                    '��ʾҳ���������
                    Me.lnkCZMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdContent, .Count)
                    Me.lnkCZMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdContent, .Count)
                    Me.lnkCZMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdContent, .Count)
                    Me.lnkCZMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdContent, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZSelectAll.Enabled = blnEnabled
                    Me.lnkCZGotoPage.Enabled = blnEnabled
                    Me.lnkCZSetPageSize.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾ����ģ�����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showMainData( _
            ByRef strErrMsg As String) As Boolean

            showMainData = False

            Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showMainData = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �����֯���������б���
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б���
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doFillZzdmList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIJIGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objDataSet As Josco.JsKernal.Common.Data.CustomerData = Nothing

            doFillZzdmList = False
            strErrMsg = ""

            Try
                '���
                If objDropDownList Is Nothing Then
                    strErrMsg = "����[doFillZzdmList]�ӿڲ�������ȷ��"
                    GoTo errProc
                End If

                '��ȡ����
                Dim strWhere As String = ""
                strWhere = "a." + Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_SFFH + " &0x1 = 0x1" + vbCr
                If Me.m_strGlbmSqlList <> "" Then
                    strWhere = strWhere + " and " + "a." + Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZDM + " in (" + Me.m_strGlbmSqlList + ")" + vbCr
                End If
                If objsystemCustomer.getBumenData(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, True, True, objDataSet) = False Then
                    GoTo errProc
                End If

                '��������б�
                objDropDownList.Items.Clear()
                If Me.m_blnIsFHRY = False Then
                    objDropDownList.Items.Add("")
                End If

                '�������
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objDataSet.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIJIGOU_ZZMC), "")
                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strCode + "|" + strName
                        objListItem.Value = strCode
                        objDropDownList.Items.Add(objListItem)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.CustomerData.SafeRelease(objDataSet)

            doFillZzdmList = True
            Exit Function
errProc:
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.CustomerData.SafeRelease(objDataSet)
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
                    '��ʾPannel(�����Ƿ�ص���ʼ����ʾpanelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                    '=======================================================================
                    objControlProcess.doTranslateKey(Me.txtPageIndex)
                    objControlProcess.doTranslateKey(Me.txtPageSize)
                    '=======================================================================
                    objControlProcess.doTranslateKey(Me.txtKSND)
                    objControlProcess.doTranslateKey(Me.txtZZND)
                    objControlProcess.doTranslateKey(Me.txtYJZR)
                    objControlProcess.doTranslateKey(Me.ddlType)
                    objControlProcess.doTranslateKey(Me.ddlTJZB)
                    objControlProcess.doTranslateKey(Me.ddlYWLX)
                    objControlProcess.doTranslateKey(Me.ddlZZDM)
                    '=======================================================================

                    '��ȡ����
                    If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                        GoTo errProc
                    End If
                    '��ʾ����
                    If Me.showModuleData(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showMainData(strErrMsg) = False Then
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

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim blnDo As Boolean

            'Ԥ����
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
            End If

            '���Ȩ��(�����Ƿ�ط���)
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
        Sub grdContent_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdContent.ItemDataBound

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
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
                        e.Item.Cells(i).CssClass = Me.grdContent.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

        End Sub

        Private Sub grdContent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdContent.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '��ʾ��¼λ��
                Me.lblGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdContent, Me.m_intRows)
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

        Private Sub grdContent_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdContent.SortCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intTable As Integer = CType(Me.ddlTJZB.SelectedItem.Value, Integer)

            Try
                Dim objenumSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
                Dim objDataGridItem As System.Web.UI.WebControls.DataGridItem = Nothing
                Dim strFinalCommand As String = ""
                Dim strOldCommand As String = ""
                Dim strUniqueId As String = ""
                Dim intColumnIndex As Integer

                '��ȡ����
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                With Me.m_objDataSet.Tables(intTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                With Me.m_objDataSet.Tables(intTable)
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
                If Me.showModuleData(strErrMsg) = False Then
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
            Dim intPageIndex As Integer
            Dim strErrMsg As String

            Try
                '��ȡ����
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdContent.PageCount)
                Me.grdContent.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doMoveLast(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intPageIndex As Integer
            Dim strErrMsg As String

            Try
                '��ȡ����
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdContent.PageCount - 1, Me.grdContent.PageCount)
                Me.grdContent.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doMoveNext(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdContent.CurrentPageIndex + 1, Me.grdContent.PageCount)
                Me.grdContent.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doMovePrevious(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdContent.CurrentPageIndex - 1, Me.grdContent.PageCount)
                Me.grdContent.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdContent.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtPageIndex.Text = (Me.grdContent.CurrentPageIndex + 1).ToString()
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
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdContent.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtPageSize.Text = (Me.grdContent.PageSize).ToString()
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdContent, 0, Me.m_cstrCheckBoxIdInDataGrid, True) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doDeSelectAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdContent, 0, Me.m_cstrCheckBoxIdInDataGrid, False) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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














        '----------------------------------------------------------------
        'ģ���������������
        '----------------------------------------------------------------
        Private Sub doSearch(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData(strErrMsg) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg) = False Then
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
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                If Me.m_blnInterface = True Then
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

        Private Sub doJsbbsj(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '������
                If Me.doCheckParam(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                If Me.getModuleData(strErrMsg, Me.m_strQuery, True) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData(strErrMsg) = False Then
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

        Private Sub doExport(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objColors As System.Collections.Specialized.ListDictionary = Nothing
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataTable As System.Data.DataTable = Nothing
            Dim strErrMsg As String = ""

            Try
                '������
                If Me.doCheckParam(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                If Me.getModuleData(strErrMsg, Me.m_strQuery, False) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Dim intKSND As Integer
                Dim intZZND As Integer
                Dim intYJZR As Integer
                Dim intType As Integer
                Dim strYWLX As String = ""
                Dim strBMDM As String = ""
                If Me.getReportParam(strErrMsg, intKSND, intZZND, intYJZR, intType, strYWLX, strBMDM) = False Then
                    GoTo errProc
                End If
                Dim strType As String = Me.ddlType.SelectedItem.Text
                Dim strBMMC As String = ""
                If Me.ddlZZDM.SelectedIndex >= 0 Then
                    strBMMC = Me.ddlZZDM.SelectedItem.Text
                    If strBMMC <> "" Then
                        strBMMC = strBMMC.Split("|".ToCharArray)(1)
                    End If
                End If
                If strBMMC = "" Then strBMMC = "���в���"
                Dim strYWMC As String = ""
                If Me.ddlYWLX.SelectedIndex >= 0 Then
                    strYWMC = Me.ddlYWLX.SelectedItem.Text
                End If
                If strYWMC = "" Then strYWMC = "ȫ��"

                '׼��Excel�ļ�
                Dim strDesExcelPath As String = Request.ApplicationPath + Me.m_cstrUrlBaseToDownloadFile
                Dim strSrcExcelSpec As String = Request.ApplicationPath + Me.m_cstrUrlBaseToExcelMB + "������ҵ_���ֱ���_�н鲿����ҵ����ȶԱ�.xls"
                Dim strDesExcelFile As String = ""
                Dim strDesExcelSpec As String = ""
                strDesExcelPath = Server.MapPath(strDesExcelPath)
                strSrcExcelSpec = Server.MapPath(strSrcExcelSpec)
                If objBaseLocalFile.doCopyToTempFile(strErrMsg, strSrcExcelSpec, strDesExcelPath, strDesExcelFile) = False Then
                    GoTo errProc
                End If
                strDesExcelSpec = objBaseLocalFile.doMakePath(strDesExcelPath, strDesExcelFile)

                '�����ļ�
                Dim strMacroValue As String = ""
                Dim strMacroName As String = ""
                Dim objDataRow As System.Data.DataRow = Nothing
                objDataTable = New System.Data.DataTable
                With objDataTable.Columns
                    .Add("��ʼ���", GetType(System.Int32))
                    .Add("��ֹ���", GetType(System.Int32))
                    .Add("ͳ������", GetType(System.String))
                    .Add("ҵ������", GetType(System.String))
                    .Add("ͳ�Ʋ���", GetType(System.String))
                End With
                objDataRow = objDataTable.NewRow
                objDataRow.Item("��ʼ���") = intKSND
                objDataRow.Item("��ֹ���") = intZZND
                objDataRow.Item("ͳ������") = strType
                objDataRow.Item("ҵ������") = strYWMC
                objDataRow.Item("ͳ�Ʋ���") = strBMMC
                objDataTable.Rows.Add(objDataRow)
                '�������
                If objsystemEstateErshou.doExportToExcel(strErrMsg, objDataTable, strDesExcelSpec, "D_����") = False Then
                    GoTo errProc
                End If
                If objsystemEstateErshou.doExportToExcel(strErrMsg, Me.m_objDataSet.Tables(0), strDesExcelSpec, "D_���") = False Then
                    GoTo errProc
                End If
                If objsystemEstateErshou.doExportToExcel(strErrMsg, Me.m_objDataSet.Tables(1), strDesExcelSpec, "D_����") = False Then
                    GoTo errProc
                End If
                If objsystemEstateErshou.doExportToExcel(strErrMsg, Me.m_objDataSet.Tables(2), strDesExcelSpec, "D_����") = False Then
                    GoTo errProc
                End If
                If objsystemEstateErshou.doExportToExcel(strErrMsg, Me.m_objDataSet.Tables(3), strDesExcelSpec, "D_������") = False Then
                    GoTo errProc
                End If
                If objsystemEstateErshou.doExportToExcel(strErrMsg, Me.m_objDataSet.Tables(4), strDesExcelSpec, "D_���ҷ�") = False Then
                    GoTo errProc
                End If
                If objsystemEstateErshou.doExportToExcel(strErrMsg, Me.m_objDataSet.Tables(5), strDesExcelSpec, "D_���׶�") = False Then
                    GoTo errProc
                End If

                '����ʱExcel�ļ�
                Dim strUrl As String = Request.ApplicationPath + Me.m_cstrUrlBaseToDownloadFile + strDesExcelFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataTable)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objColors)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataTable)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objColors)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
        End Sub

        Private Sub lnkMLSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLSearch.Click
            Me.doSearch("lnkMLSearch")
        End Sub

        Private Sub lnkMLJsbbsj_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLJsbbsj.Click
            Me.doJsbbsj("lnkMLJsbbsj")
        End Sub

        Private Sub lnkMLExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLExport.Click
            Me.doExport("lnkMLExport")
        End Sub

        Private Sub lnkMLReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLReturn.Click
            Me.doClose("lnkMLReturn")
        End Sub

    End Class

End Namespace