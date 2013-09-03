Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_gg_yingshouyingfumoban
    ' 
    ' �������ʣ�
    '     ��������
    '
    ' ���������� 
    '   �����ز�_B_����_Ӧ��Ӧ��ģ�桱���봦��ģ��
    '----------------------------------------------------------------

    Partial Class estate_gg_yingshouyingfumoban
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

        '----------------------------------------------------------------
        'ģ����Ȩ����
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_gg_yingshouyingfumoban_previlege_param"
        Private m_blnPrevilegeParams(4) As Boolean

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateGgYingshouYingfuMoban
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateGgYingshouYingfuMoban
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
        Private m_objestateCommonData As Josco.JSOA.Common.Data.estateCommonData
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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateGgYingshouYingfuMoban)
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

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery
                    Me.htxtCurrentPage.Value = .htxtCurrentPage
                    Me.htxtCurrentRow.Value = .htxtCurrentRow
                    Me.htxtEditMode.Value = .htxtEditMode
                    Me.htxtEditType.Value = .htxtEditType

                    Me.htxtQuery.Value = .htxtQuery
                    Me.htxtRows.Value = .htxtRows
                    Me.htxtSort.Value = .htxtSort
                    Me.htxtSortColumnIndex.Value = .htxtSortColumnIndex
                    Me.htxtSortType.Value = .htxtSortType

                    Me.txtMBDM.Text = .txtMBDM
                    Me.txtMBMC.Text = .txtMBMC
                    Try
                        Me.ddlSFDM.SelectedIndex = .ddlSFDM_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblSFDX.SelectedIndex = .rblSFDX_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblSFBZ.SelectedIndex = .rblSFBZ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblSFMX.SelectedIndex = .rblSFMX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.txtSearch_MBDM.Text = .txtSearch_MBDM
                    Me.txtSearch_MBMC.Text = .txtSearch_MBMC

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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateGgYingshouYingfuMoban

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftObject = Me.htxtDivLeftObject.Value
                    .htxtDivTopObject = Me.htxtDivTopObject.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value
                    .htxtCurrentPage = Me.htxtCurrentPage.Value
                    .htxtCurrentRow = Me.htxtCurrentRow.Value
                    .htxtEditMode = Me.htxtEditMode.Value
                    .htxtEditType = Me.htxtEditType.Value

                    .htxtQuery = Me.htxtQuery.Value
                    .htxtRows = Me.htxtRows.Value
                    .htxtSort = Me.htxtSort.Value
                    .htxtSortColumnIndex = Me.htxtSortColumnIndex.Value
                    .htxtSortType = Me.htxtSortType.Value

                    .txtMBDM = Me.txtMBDM.Text
                    .txtMBMC = Me.txtMBMC.Text
                    .ddlSFDM_SelectedIndex = Me.ddlSFDM.SelectedIndex
                    .rblSFDX_SelectedIndex = Me.rblSFDX.SelectedIndex
                    .rblSFBZ_SelectedIndex = Me.rblSFBZ.SelectedIndex
                    .rblSFMX_SelectedIndex = Me.rblSFMX.SelectedIndex

                    .txtSearch_MBDM = Me.txtSearch_MBDM.Text
                    .txtSearch_MBMC = Me.txtSearch_MBMC.Text

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
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
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
                        Me.htxtQuery.Value = objISjcxCxtj.oQueryString
                        If Me.htxtSessionIdQuery.Value.Trim = "" Then
                            Me.htxtSessionIdQuery.Value = objPulicParameters.getNewGuid()
                        Else
                            Try
                                objQueryData = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                            Catch ex As Exception
                                objQueryData = Nothing
                            End Try
                            Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                        End If
                        Session.Add(Me.htxtSessionIdQuery.Value, objISjcxCxtj.oDataSetTJ)
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.ISjcxCxtj.SafeRelease(objISjcxCxtj)
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateGgYingshouYingfuMoban)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateGgYingshouYingfuMoban)
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
                If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQuery.Value)
                End If
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
                '����������
                Dim strMBDM As String = "a." + Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM
                If Me.txtSearch_MBDM.Text.Length > 0 Then Me.txtSearch_MBDM.Text = Me.txtSearch_MBDM.Text.Trim()
                If Me.txtSearch_MBDM.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strMBDM + " like '" + Me.txtSearch_MBDM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strMBDM + " like '" + Me.txtSearch_MBDM.Text + "%'"
                    End If
                End If

                '����������
                Dim strMBMC As String = "a." + Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBMC
                If Me.txtSearch_MBMC.Text.Length > 0 Then Me.txtSearch_MBMC.Text = Me.txtSearch_MBMC.Text.Trim()
                If Me.txtSearch_MBMC.Text <> "" Then
                    Me.txtSearch_MBMC.Text = objPulicParameters.getNewSearchString(Me.txtSearch_MBMC.Text)
                    If strQuery = "" Then
                        strQuery = strMBMC + " like '" + Me.txtSearch_MBMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strMBMC + " like '" + Me.txtSearch_MBMC.Text + "%'"
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon

            getModuleData = False

            Try
                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateCommonData.SafeRelease(Me.m_objestateCommonData)

                '���¼�������
                With objsystemEstateCommon
                    If .getDataSet_YingshouYingfuMoban(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objestateCommonData) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ�Sort�ַ���
                With Me.m_objestateCommonData.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                If blnEditMode = False Then '�鿴ģʽ
                    With Me.m_objestateCommonData.Tables(strTable)
                        .DefaultView.AllowNew = False
                    End With
                Else '�༭ģʽ
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            '����1���ռ�¼
                            With Me.m_objestateCommonData.Tables(strTable)
                                .DefaultView.AllowNew = True
                                .DefaultView.AddNew()
                            End With
                        Case Else
                            With Me.m_objestateCommonData.Tables(strTable)
                                .DefaultView.AllowNew = False
                            End With
                    End Select
                End If

                '�������
                With Me.m_objestateCommonData.Tables(strTable)
                    Me.htxtRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)

            getModuleData = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN
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
                If Me.m_objestateCommonData Is Nothing Then
                    Me.grdObjects.DataSource = Nothing
                Else
                    With Me.m_objestateCommonData.Tables(strTable)
                        Me.grdObjects.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objestateCommonData.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdObjects, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '����Ǳ༭ģʽ
                If blnEditMode = True Then
                    '�ƶ�������¼
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            With Me.m_objestateCommonData.Tables(strTable)
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

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showEditPanelInfo = False

            Try
                If blnEditMode = False Then
                    '�鿴״̬
                    If Me.grdObjects.Items.Count < 1 Or Me.grdObjects.SelectedIndex < 0 Then
                        Me.txtMBDM.Text = ""
                        Me.txtMBMC.Text = ""
                        Me.ddlSFDM.SelectedIndex = -1
                        Me.rblSFDX.SelectedIndex = -1
                        Me.rblSFBZ.SelectedIndex = -1
                        Me.rblSFMX.SelectedIndex = -1
                    Else
                        Dim intColIndex(6) As Integer
                        Dim strValue As String = ""
                        intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM)
                        intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBMC)
                        intColIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFDM)
                        intColIndex(3) = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFDX)
                        intColIndex(4) = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFBZ)
                        intColIndex(5) = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMX)
                        Me.txtMBDM.Text = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(Me.grdObjects.SelectedIndex), intColIndex(0))
                        Me.txtMBMC.Text = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(Me.grdObjects.SelectedIndex), intColIndex(1))

                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(Me.grdObjects.SelectedIndex), intColIndex(2))
                        Me.ddlSFDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSFDM, strValue)

                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(Me.grdObjects.SelectedIndex), intColIndex(3))
                        Me.rblSFDX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFDX, strValue)

                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(Me.grdObjects.SelectedIndex), intColIndex(4))
                        Me.rblSFBZ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFBZ, strValue)

                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(Me.grdObjects.SelectedIndex), intColIndex(5))
                        Me.rblSFMX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFMX, strValue)
                    End If
                Else
                    '�༭״̬
                    '�Զ��ָ�����
                End If

                'ʹ�ܿؼ�
                With objControlProcess
                    .doEnabledControl(Me.txtMBDM, blnEditMode)
                    .doEnabledControl(Me.txtMBMC, blnEditMode)
                    .doEnabledControl(Me.ddlSFDM, blnEditMode)
                    .doEnabledControl(Me.rblSFDX, blnEditMode)
                    .doEnabledControl(Me.rblSFBZ, blnEditMode)
                    .doEnabledControl(Me.rblSFMX, blnEditMode)
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanelInfo = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo(strErrMsg, blnEditMode, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objestateCommonData.Tables(strTable).DefaultView
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
                        .doEnabledControl(Me.txtSearch_MBDM, Not blnEditMode)
                        .doEnabledControl(Me.txtSearch_MBMC, Not blnEditMode)
                    End With
                    Me.btnSearch.Enabled = Not blnEditMode
                    Me.btnSearchFull.Enabled = Not blnEditMode
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
                        .doTranslateKey(Me.txtSearch_MBDM)
                        .doTranslateKey(Me.txtSearch_MBMC)
                        .doTranslateKey(Me.txtMBDM)
                        .doTranslateKey(Me.txtMBMC)
                        .doTranslateKey(Me.ddlSFDM)
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

        '----------------------------------------------------------------
        ' ���˰�������б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doFillSfdmList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_SHUIFEIMULU
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objestateCommonData As Josco.JSOA.Common.Data.estateCommonData

            doFillSfdmList = False
            strErrMsg = ""

            Try
                '���
                If objDropDownList Is Nothing Then
                    strErrMsg = "����[doFillSfdmList]�ӿڲ�������ȷ��"
                    GoTo errProc
                End If

                '��ȡ����
                If objsystemEstateCommon.getDataSet_ShuifeiMulu(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateCommonData) = False Then
                    GoTo errProc
                End If

                '��������б�
                objDropDownList.Items.Clear()

                '�������
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateCommonData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFMC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)

            doFillSfdmList = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
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

            '���Ȩ��(�����Ƿ�ط���)
            Dim blnDo As Boolean
            If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                GoTo errProc
            End If
            If blnDo = False Then
                GoTo normExit
            End If

            'Ԥ������б�
            If Me.IsPostBack = False Then
                If Me.doFillSfdmList(strErrMsg, Me.ddlSFDM) = False Then
                    GoTo errProc
                End If
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
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]������[�ز�_Ӧ��Ӧ��ģ��]�ֵ䣡")
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN
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
                With Me.m_objestateCommonData.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                With Me.m_objestateCommonData.Tables(strTable)
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

        Private Sub doSearchFull(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN

            Try
                '��ȡ����
                If Me.getModuleData(strErrMsg, Me.m_strQuery, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
                    .iQueryTable = Me.m_objestateCommonData.Tables(strTable)
                    .iFixQuery = ""

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = True Then
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
                    Else
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strSessionId
                    End If
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
                strUrl += "../../sjcx/sjcx_cxtj.aspx"
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

        Private Sub btnSearchFull_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchFull.Click
            Me.doSearchFull("btnSearchFull")
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '���
                If Me.ddlSFDM.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[˰��]��"
                    GoTo errProc
                End If
                If Me.rblSFDX.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[����]��"
                    GoTo errProc
                End If
                If Me.rblSFBZ.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[�ո�]��"
                    GoTo errProc
                End If
                If Me.rblSFMX.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[��ϸ��Ŀ]��"
                    GoTo errProc
                End If

                '��ȡ����Ϣ
                Dim objNewData As New System.Collections.Specialized.NameValueCollection
                objNewData.Add(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM, Me.txtMBDM.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBMC, Me.txtMBMC.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFDM, Me.ddlSFDM.SelectedItem.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFDX, Me.rblSFDX.SelectedItem.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFBZ, Me.rblSFBZ.SelectedItem.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMX, Me.rblSFMX.SelectedItem.Value)

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
                        With Me.m_objestateCommonData.Tables(strTable)
                            objOldData = .DefaultView.Item(intPos).Row
                        End With
                End Select

                '������Ϣ
                With objsystemEstateCommon
                    If .doSaveData_YingshouYingfuMoban(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData, objNewData, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                End With

                '��¼�����־
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[�ز�_Ӧ��Ӧ��ģ��]�ֵ���������[" + Me.txtMBMC.Text + "]��")
                    Case Else
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]������[�ز�_Ӧ��Ӧ��ģ��]�ֵ䣡")
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

            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
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
                    Dim strMBMC As String = ""
                    Dim intPos As Integer
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdObjects, Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdObjects.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid) = True Then
                            strMBMC = objDataGridProcess.getDataGridCellValue(Me.grdObjects.Items(i), intColIndex)

                            '��ȡҪɾ��������
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdObjects.CurrentPageIndex, Me.grdObjects.PageSize)
                            objOldData = Nothing
                            With Me.m_objestateCommonData.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            'ɾ������
                            If objsystemEstateCommon.doDeleteData_YingshouYingfuMoban(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData) = False Then
                                GoTo errProc
                            End If

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteAuditPZInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[�ز�_Ӧ��Ӧ��ģ��]�ֵ���ɾ����[" + strMBMC + "]��")
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

            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
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

