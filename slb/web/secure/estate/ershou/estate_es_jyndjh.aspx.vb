Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_es_jyndjh
    ' 
    ' �������ʣ�
    '     I/O
    '
    ' ���������� 
    '   ������ȼƻ�����ģ��
    '----------------------------------------------------------------

    Partial Class estate_es_jyndjh
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton








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
        '��ӡģ�������Ӧ�ø���·��
        Private m_cstrExcelMBRelativePathToAppRoot As String = "/template/excel/"
        '��ӡ�ļ�����Ŀ¼�����Ӧ�ø���·��
        Private m_cstrPrintCacheRelativePathToAppRoot As String = "/temp/printcache/"

        '----------------------------------------------------------------
        'ģ����Ȩ����
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_es_jyndjh_previlege_param"
        Private m_blnPrevilegeParams(4) As Boolean

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsJyndjh
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsJyndjh
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdNDJH��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_NDJH As String = "chkNDJH"
        Private Const m_cstrDataGridInDIV_NDJH As String = "divNDJH"
        Private m_intFixedColumns_NDJH As Integer

        '----------------------------------------------------------------
        '��ǰ��������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet_NDJH As Josco.JSOA.Common.Data.estateErshouData
        Private m_strQuery_NDJH As String
        Private m_intRows_NDJH As Integer

        '----------------------------------------------------------------
        '����ģ��˽�ò���
        '----------------------------------------------------------------











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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsJyndjh)
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
                    Me.htxtDivLeftNDJH.Value = .htxtDivLeftNDJH
                    Me.htxtDivTopNDJH.Value = .htxtDivTopNDJH

                    Me.htxtNDJHQuery.Value = .htxtNDJHQuery
                    Me.htxtNDJHRows.Value = .htxtNDJHRows
                    Me.htxtNDJHSort.Value = .htxtNDJHSort
                    Me.htxtNDJHSortColumnIndex.Value = .htxtNDJHSortColumnIndex
                    Me.htxtNDJHSortType.Value = .htxtNDJHSortType

                    Me.txtNDJHSearch_JHNDMax.Text = .txtNDJHSearch_JHNDMax
                    Me.txtNDJHSearch_JHNDMin.Text = .txtNDJHSearch_JHNDMin
                    Me.txtNDJHSearch_JHDLFMax.Text = .txtNDJHSearch_JHDLFMax
                    Me.txtNDJHSearch_JHDLFMin.Text = .txtNDJHSearch_JHDLFMin
                    Me.ddlNDJHSearch_JHLX.SelectedIndex = .ddlNDJHSearch_JHLX_SelectedIndex

                    Me.txtNDJHPageIndex.Text = .txtNDJHPageIndex
                    Me.txtNDJHPageSize.Text = .txtNDJHPageSize

                    Try
                        Me.grdNDJH.PageSize = .grdNDJHPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdNDJH.CurrentPageIndex = .grdNDJHCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdNDJH.SelectedIndex = .grdNDJHSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtJHND.Text = .txtJHND
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Dim strSessionId As String = ""

            saveModuleInformation = ""

            Try
                '����SessionId
                strSessionId = objPulicParameters.getNewGuid()
                If strSessionId = "" Then
                    Exit Try
                End If

                '��������
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsJyndjh

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftNDJH = Me.htxtDivLeftNDJH.Value
                    .htxtDivTopNDJH = Me.htxtDivTopNDJH.Value

                    .htxtNDJHQuery = Me.htxtNDJHQuery.Value
                    .htxtNDJHRows = Me.htxtNDJHRows.Value
                    .htxtNDJHSort = Me.htxtNDJHSort.Value
                    .htxtNDJHSortColumnIndex = Me.htxtNDJHSortColumnIndex.Value
                    .htxtNDJHSortType = Me.htxtNDJHSortType.Value

                    .txtNDJHSearch_JHNDMax = Me.txtNDJHSearch_JHNDMax.Text
                    .txtNDJHSearch_JHNDMin = Me.txtNDJHSearch_JHNDMin.Text
                    .txtNDJHSearch_JHDLFMax = Me.txtNDJHSearch_JHDLFMax.Text
                    .txtNDJHSearch_JHDLFMin = Me.txtNDJHSearch_JHDLFMin.Text
                    .ddlNDJHSearch_JHLX_SelectedIndex = Me.ddlNDJHSearch_JHLX.SelectedIndex

                    .txtNDJHPageIndex = Me.txtNDJHPageIndex.Text
                    .txtNDJHPageSize = Me.txtNDJHPageSize.Text

                    .grdNDJHPageSize = Me.grdNDJH.PageSize
                    .grdNDJHCurrentPageIndex = Me.grdNDJH.CurrentPageIndex
                    .grdNDJHSelectedIndex = Me.grdNDJH.SelectedIndex
                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .txtJHND = Me.txtJHND.Text
                End With

                '�������
                Session.Add(strSessionId, Me.m_objSaveScence)
            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            saveModuleInformation = strSessionId
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ӵ���ģ���л�ȡ����
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsJyndjhInfo As Josco.JSOA.BusinessFacade.IEstateEsJyndjhInfo = Nothing
                Try
                    objIEstateEsJyndjhInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsJyndjhInfo)
                Catch ex As Exception
                    objIEstateEsJyndjhInfo = Nothing
                End Try
                If Not (objIEstateEsJyndjhInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsJyndjhInfo.SafeRelease(objIEstateEsJyndjhInfo)
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
                        Me.htxtNDJHQuery.Value = objISjcxCxtj.oQueryString
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
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
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
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getInterfaceParameters = False

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsJyndjh)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsJyndjh)
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

                Me.m_intFixedColumns_NDJH = objPulicParameters.getObjectValue(Me.htxtNDJHFixed.Value, 0)
                Me.m_intRows_NDJH = objPulicParameters.getObjectValue(Me.htxtNDJHRows.Value, 0)
                Me.m_strQuery_NDJH = Me.htxtNDJHQuery.Value
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)

            getInterfaceParameters = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
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
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQuery.Value)
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub














        '----------------------------------------------------------------
        ' ��ȡgrdNDJH��������(Ĭ�ϱ�ǰ׺a.)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_NDJH( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_NDJH = False
            strQuery = ""

            Try
                '�����ƻ����͡�����
                Dim strJHLX As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHLX
                Select Case Me.ddlNDJHSearch_JHLX.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strJHLX + " = '" + Me.ddlNDJHSearch_JHLX.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strJHLX + " = '" + Me.ddlNDJHSearch_JHLX.SelectedValue + "'"
                        End If
                    Case Else
                End Select

                Dim dblMin As Double
                Dim dblMax As Double
                Dim intMin As Integer
                Dim intMax As Integer

                '�����ƻ���ȡ�����
                Dim strJHND As String
                strJHND = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHND
                If Me.txtNDJHSearch_JHNDMin.Text.Length > 0 Then Me.txtNDJHSearch_JHNDMin.Text = Me.txtNDJHSearch_JHNDMin.Text.Trim()
                If Me.txtNDJHSearch_JHNDMax.Text.Length > 0 Then Me.txtNDJHSearch_JHNDMax.Text = Me.txtNDJHSearch_JHNDMax.Text.Trim()
                If Me.txtNDJHSearch_JHNDMin.Text <> "" And Me.txtNDJHSearch_JHNDMax.Text <> "" Then
                    Try
                        intMin = CType(Me.txtNDJHSearch_JHNDMin.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "������Ч����ȣ�"
                        GoTo errProc
                    End Try
                    Try
                        intMax = CType(Me.txtNDJHSearch_JHNDMax.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "������Ч����ȣ�"
                        GoTo errProc
                    End Try
                    If intMin > intMax Then
                        Me.txtNDJHSearch_JHNDMin.Text = intMax.ToString
                        Me.txtNDJHSearch_JHNDMax.Text = intMin.ToString
                    Else
                        Me.txtNDJHSearch_JHNDMin.Text = intMin.ToString
                        Me.txtNDJHSearch_JHNDMax.Text = intMax.ToString
                    End If
                    If strQuery = "" Then
                        strQuery = strJHND + " between " + Me.txtNDJHSearch_JHNDMin.Text + " and " + Me.txtNDJHSearch_JHNDMax.Text
                    Else
                        strQuery = strQuery + " and " + strJHND + " between " + Me.txtNDJHSearch_JHNDMin.Text + " and " + Me.txtNDJHSearch_JHNDMax.Text
                    End If
                ElseIf Me.txtNDJHSearch_JHNDMin.Text <> "" Then
                    Try
                        intMin = CType(Me.txtNDJHSearch_JHNDMin.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "������Ч����ȣ�"
                        GoTo errProc
                    End Try
                    Me.txtNDJHSearch_JHNDMin.Text = intMin.ToString
                    If strQuery = "" Then
                        strQuery = strJHND + " >= " + Me.txtNDJHSearch_JHNDMin.Text
                    Else
                        strQuery = strQuery + " and " + strJHND + " >= " + Me.txtNDJHSearch_JHNDMin.Text
                    End If
                ElseIf Me.txtNDJHSearch_JHNDMax.Text <> "" Then
                    Try
                        intMax = CType(Me.txtNDJHSearch_JHNDMax.Text, Integer)
                    Catch ex As Exception
                        strErrMsg = "������Ч����ȣ�"
                        GoTo errProc
                    End Try
                    Me.txtNDJHSearch_JHNDMax.Text = intMax.ToString
                    If strQuery = "" Then
                        strQuery = strJHND + " <= " + Me.txtNDJHSearch_JHNDMax.Text
                    Else
                        strQuery = strQuery + " and " + strJHND + " <= " + Me.txtNDJHSearch_JHNDMax.Text
                    End If
                Else
                End If

                '�����ƻ�����ѡ�����
                Dim strJHDLF As String
                strJHDLF = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHDLF
                If Me.txtNDJHSearch_JHDLFMin.Text.Length > 0 Then Me.txtNDJHSearch_JHDLFMin.Text = Me.txtNDJHSearch_JHDLFMin.Text.Trim()
                If Me.txtNDJHSearch_JHDLFMax.Text.Length > 0 Then Me.txtNDJHSearch_JHDLFMax.Text = Me.txtNDJHSearch_JHDLFMax.Text.Trim()
                If Me.txtNDJHSearch_JHDLFMin.Text <> "" And Me.txtNDJHSearch_JHDLFMax.Text <> "" Then
                    Try
                        dblMin = CType(Me.txtNDJHSearch_JHDLFMin.Text, Double)
                    Catch ex As Exception
                        strErrMsg = "������Ч�Ĵ���ѣ�"
                        GoTo errProc
                    End Try
                    Try
                        dblMax = CType(Me.txtNDJHSearch_JHDLFMax.Text, Double)
                    Catch ex As Exception
                        strErrMsg = "������Ч�Ĵ���ѣ�"
                        GoTo errProc
                    End Try
                    If dblMin > dblMax Then
                        Me.txtNDJHSearch_JHDLFMin.Text = dblMax.ToString
                        Me.txtNDJHSearch_JHDLFMax.Text = dblMin.ToString
                    Else
                        Me.txtNDJHSearch_JHDLFMin.Text = dblMin.ToString
                        Me.txtNDJHSearch_JHDLFMax.Text = dblMax.ToString
                    End If
                    If strQuery = "" Then
                        strQuery = strJHDLF + " between " + Me.txtNDJHSearch_JHDLFMin.Text + " and " + Me.txtNDJHSearch_JHDLFMax.Text
                    Else
                        strQuery = strQuery + " and " + strJHDLF + " between " + Me.txtNDJHSearch_JHDLFMin.Text + " and " + Me.txtNDJHSearch_JHDLFMax.Text
                    End If
                ElseIf Me.txtNDJHSearch_JHDLFMin.Text <> "" Then
                    Try
                        dblMin = CType(Me.txtNDJHSearch_JHDLFMin.Text, Double)
                    Catch ex As Exception
                        strErrMsg = "������Ч�Ĵ���ѣ�"
                        GoTo errProc
                    End Try
                    Me.txtNDJHSearch_JHDLFMin.Text = dblMin.ToString
                    If strQuery = "" Then
                        strQuery = strJHDLF + " >= " + Me.txtNDJHSearch_JHDLFMin.Text
                    Else
                        strQuery = strQuery + " and " + strJHDLF + " >= " + Me.txtNDJHSearch_JHDLFMin.Text
                    End If
                ElseIf Me.txtNDJHSearch_JHDLFMax.Text <> "" Then
                    Try
                        dblMax = CType(Me.txtNDJHSearch_JHDLFMax.Text, Double)
                    Catch ex As Exception
                        strErrMsg = "������Ч�Ĵ���ѣ�"
                        GoTo errProc
                    End Try
                    Me.txtNDJHSearch_JHDLFMax.Text = dblMax.ToString
                    If strQuery = "" Then
                        strQuery = strJHDLF + " <= " + Me.txtNDJHSearch_JHDLFMax.Text
                    Else
                        strQuery = strQuery + " and " + strJHDLF + " <= " + Me.txtNDJHSearch_JHDLFMax.Text
                    End If
                Else
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_NDJH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdNDJHҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       �������ַ���
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_NDJH( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_JYNDJH
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_NDJH = False

            Try
                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtNDJHSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_NDJH)

                '���¼�������
                If objsystemEstateErshou.getDataSet_ES_JYNDJH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objDataSet_NDJH) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_NDJH.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_NDJH.Tables(strTable)
                    Me.htxtNDJHRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_NDJH = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_NDJH = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdNDJH����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_NDJH( _
            ByRef strErrMsg As String) As Boolean

            searchModuleData_NDJH = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_NDJH(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_NDJH(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_NDJH = strQuery
                Me.htxtNDJHQuery.Value = Me.m_strQuery_NDJH
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_NDJH = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdNDJH������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_NDJH( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_JYNDJH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_NDJH = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtNDJHSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtNDJHSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_NDJH Is Nothing Then
                    Me.grdNDJH.DataSource = Nothing
                Else
                    With Me.m_objDataSet_NDJH.Tables(strTable)
                        Me.grdNDJH.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_NDJH.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdNDJH, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdNDJH)
                    With Me.grdNDJH.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdNDJH.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                ''�ָ������е�CheckBox״̬
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdNDJH, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_NDJH) = False Then
                '    GoTo errProc
                'End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_NDJH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdNDJH���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_NDJH( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_JYNDJH
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_NDJH = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_NDJH(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_NDJH.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblNDJHGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdNDJH, .Count)

                    '��ʾҳ���������
                    Me.lnkCZNDJHMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdNDJH, .Count)
                    Me.lnkCZNDJHMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdNDJH, .Count)
                    Me.lnkCZNDJHMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdNDJH, .Count)
                    Me.lnkCZNDJHMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdNDJH, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZNDJHDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZNDJHSelectAll.Enabled = blnEnabled
                    Me.lnkCZNDJHGotoPage.Enabled = blnEnabled
                    Me.lnkCZNDJHSetPageSize.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_NDJH = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾģ���ܿ���Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_MAIN( _
            ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_MAIN = False

            Try
                Me.btnAddNew.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnUpdate.Visible = Me.m_blnPrevilegeParams(2)
                Me.btnDelete.Visible = Me.m_blnPrevilegeParams(3)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_MAIN = True
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
                    '��ʾPannel(�����Ƿ�ص���ʼ����ʾpanelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                    '********************************************************
                    objControlProcess.doTranslateKey(Me.txtNDJHPageIndex)
                    objControlProcess.doTranslateKey(Me.txtNDJHPageSize)
                    '********************************************************
                    objControlProcess.doTranslateKey(Me.txtNDJHSearch_JHNDMin)
                    objControlProcess.doTranslateKey(Me.txtNDJHSearch_JHNDMax)
                    objControlProcess.doTranslateKey(Me.txtNDJHSearch_JHDLFMin)
                    objControlProcess.doTranslateKey(Me.txtNDJHSearch_JHDLFMax)
                    objControlProcess.doTranslateKey(Me.ddlNDJHSearch_JHLX)
                    '********************************************************
                    objControlProcess.doTranslateKey(Me.txtJHND)
                    '********************************************************

                    If Me.getModuleData_NDJH(strErrMsg, Me.m_strQuery_NDJH) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_NDJH(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_MAIN(strErrMsg) = False Then
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
            Dim strErrMsg As String
            Dim strUrl As String
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
        'ʵ�ֶ������С��еĹ̶�
        Sub grdNDJH_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdNDJH.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_NDJH + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_NDJH > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_NDJH - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdNDJH.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdNDJH_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdNDJH.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblNDJHGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdNDJH, Me.m_intRows_NDJH)
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

        Private Sub grdNDJH_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdNDJH.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_JYNDJH
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
                If Me.getModuleData_NDJH(strErrMsg, Me.m_strQuery_NDJH) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                With Me.m_objDataSet_NDJH.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                With Me.m_objDataSet_NDJH.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtNDJHSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtNDJHSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtNDJHSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_NDJH(strErrMsg) = False Then
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
                If Me.getModuleData_NDJH(strErrMsg, Me.m_strQuery_NDJH) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdNDJH.PageCount)
                Me.grdNDJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NDJH(strErrMsg) = False Then
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
                If Me.getModuleData_NDJH(strErrMsg, Me.m_strQuery_NDJH) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdNDJH.PageCount - 1, Me.grdNDJH.PageCount)
                Me.grdNDJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NDJH(strErrMsg) = False Then
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
                If Me.getModuleData_NDJH(strErrMsg, Me.m_strQuery_NDJH) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdNDJH.CurrentPageIndex + 1, Me.grdNDJH.PageCount)
                Me.grdNDJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NDJH(strErrMsg) = False Then
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
                If Me.getModuleData_NDJH(strErrMsg, Me.m_strQuery_NDJH) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdNDJH.CurrentPageIndex - 1, Me.grdNDJH.PageCount)
                Me.grdNDJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NDJH(strErrMsg) = False Then
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
            intPageIndex = objPulicParameters.getObjectValue(Me.txtNDJHPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_NDJH(strErrMsg, Me.m_strQuery_NDJH) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdNDJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NDJH(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtNDJHPageIndex.Text = (Me.grdNDJH.CurrentPageIndex + 1).ToString()
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
            intPageSize = objPulicParameters.getObjectValue(Me.txtNDJHPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_NDJH(strErrMsg, Me.m_strQuery_NDJH) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdNDJH.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_NDJH(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtNDJHPageSize.Text = (Me.grdNDJH.PageSize).ToString()
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdNDJH, 0, Me.m_cstrCheckBoxIdInDataGrid_NDJH, True) = False Then
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdNDJH, 0, Me.m_cstrCheckBoxIdInDataGrid_NDJH, False) = False Then
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
                If Me.searchModuleData_NDJH(strErrMsg) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_NDJH(strErrMsg) = False Then
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

        Private Sub lnkCZNDJHMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHMoveFirst.Click
            Me.doMoveFirst("lnkCZNDJHMoveFirst")
        End Sub

        Private Sub lnkCZNDJHMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHMoveLast.Click
            Me.doMoveLast("lnkCZNDJHMoveLast")
        End Sub

        Private Sub lnkCZNDJHMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHMoveNext.Click
            Me.doMoveNext("lnkCZNDJHMoveNext")
        End Sub

        Private Sub lnkCZNDJHMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHMovePrev.Click
            Me.doMovePrevious("lnkCZNDJHMovePrev")
        End Sub

        Private Sub lnkCZNDJHGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHGotoPage.Click
            Me.doGotoPage("lnkCZNDJHGotoPage")
        End Sub

        Private Sub lnkCZNDJHSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHSetPageSize.Click
            Me.doSetPageSize("lnkCZNDJHSetPageSize")
        End Sub

        Private Sub lnkCZNDJHSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHSelectAll.Click
            Me.doSelectAll("lnkCZNDJHSelectAll")
        End Sub

        Private Sub lnkCZNDJHDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHDeSelectAll.Click
            Me.doDeSelectAll("lnkCZNDJHDeSelectAll")
        End Sub

        Private Sub btnNDJHSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNDJHSearch.Click
            Me.doSearch("btnNDJHSearch")
        End Sub











        '----------------------------------------------------------------
        'ģ���������������
        '----------------------------------------------------------------
        Private Sub doAddNew(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.txtJHND.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[�ƻ����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtJHND.Text) = False Then
                    strErrMsg = "������Ч��[�ƻ����]��"
                    GoTo errProc
                End If
                '�Ƿ��ƶ��ƻ���
                Dim intJHND As Integer = CType(Me.txtJHND.Text, Integer)
                Dim blnHas As Boolean
                If objsystemEstateErshou.isJyndjhExisted(strErrMsg, MyBase.UserId, MyBase.UserPassword, intJHND, blnHas) = False Then
                    GoTo errProc
                End If
                If blnHas = True Then
                    strErrMsg = "����[" + Me.txtJHND.Text + "]��ȵļƻ��Ѿ����ڣ�"
                    GoTo errProc
                End If

                '�����ֳ�����
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim strUrl As String = ""
                Dim objIEstateEsJyndjhInfo As Josco.JSOA.BusinessFacade.IEstateEsJyndjhInfo = Nothing
                objIEstateEsJyndjhInfo = New Josco.JSOA.BusinessFacade.IEstateEsJyndjhInfo
                With objIEstateEsJyndjhInfo
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    .iJHND = Me.txtJHND.Text
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
                Dim strNewSessionId As String = ""
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateEsJyndjhInfo)
                strUrl = ""
                strUrl += "estate_es_jyndjh_info.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doUpdate(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.txtJHND.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[�ƻ����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtJHND.Text) = False Then
                    strErrMsg = "������Ч��[�ƻ����]��"
                    GoTo errProc
                End If
                '�Ƿ��ƶ��ƻ���
                Dim intJHND As Integer = CType(Me.txtJHND.Text, Integer)
                Dim blnHas As Boolean
                If objsystemEstateErshou.isJyndjhExisted(strErrMsg, MyBase.UserId, MyBase.UserPassword, intJHND, blnHas) = False Then
                    GoTo errProc
                End If
                If blnHas = False Then
                    strErrMsg = "����[" + Me.txtJHND.Text + "]��ȵļƻ���û���ƶ���"
                    GoTo errProc
                End If

                '�����ֳ�����
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim strUrl As String = ""
                Dim objIEstateEsJyndjhInfo As Josco.JSOA.BusinessFacade.IEstateEsJyndjhInfo = Nothing
                objIEstateEsJyndjhInfo = New Josco.JSOA.BusinessFacade.IEstateEsJyndjhInfo
                With objIEstateEsJyndjhInfo
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    .iJHND = Me.txtJHND.Text
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
                Dim strNewSessionId As String = ""
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateEsJyndjhInfo)
                strUrl = ""
                strUrl += "estate_es_jyndjh_info.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOpen(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.txtJHND.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[�ƻ����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtJHND.Text) = False Then
                    strErrMsg = "������Ч��[�ƻ����]��"
                    GoTo errProc
                End If
                '�Ƿ��ƶ��ƻ���
                Dim intJHND As Integer = CType(Me.txtJHND.Text, Integer)
                Dim blnHas As Boolean
                If objsystemEstateErshou.isJyndjhExisted(strErrMsg, MyBase.UserId, MyBase.UserPassword, intJHND, blnHas) = False Then
                    GoTo errProc
                End If
                If blnHas = False Then
                    strErrMsg = "����[" + Me.txtJHND.Text + "]��ȵļƻ���û���ƶ���"
                    GoTo errProc
                End If

                '�����ֳ�����
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim strUrl As String = ""
                Dim objIEstateEsJyndjhInfo As Josco.JSOA.BusinessFacade.IEstateEsJyndjhInfo = Nothing
                objIEstateEsJyndjhInfo = New Josco.JSOA.BusinessFacade.IEstateEsJyndjhInfo
                With objIEstateEsJyndjhInfo
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iJHND = Me.txtJHND.Text
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
                Dim strNewSessionId As String = ""
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateEsJyndjhInfo)
                strUrl = ""
                strUrl += "estate_es_jyndjh_info.aspx"
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId
                Response.Redirect(strUrl)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doDelete(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_JYNDJH
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '���
                If Me.txtJHND.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[�ƻ����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtJHND.Text) = False Then
                    strErrMsg = "������Ч��[�ƻ����]��"
                    GoTo errProc
                End If
                Dim intJHND As Integer = CType(Me.txtJHND.Text, Integer)

                'ѯ��
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷʵ׼��ɾ��[" + Me.txtJHND.Text + "]��ȵļƻ�����/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��ʾ��ش��ǡ����Ŵ���
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    'ɾ������
                    If objsystemEstateErshou.doDeleteData_ES_JYNDJH(strErrMsg, MyBase.UserId, MyBase.UserPassword, intJHND) = False Then
                        GoTo errProc
                    End If

                    '��¼�����־
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_��ȼƻ�]��[ɾ��]��[" + Me.txtJHND.Text + "]��ȵļƻ���")

                    '���»�ȡ����
                    If Me.getModuleData_NDJH(strErrMsg, Me.m_strQuery_NDJH) = False Then
                        GoTo errProc
                    End If
                    'ˢ��������ʾ
                    If Me.showModuleData_NDJH(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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

        Private Sub doSearchFull(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_JYNDJH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strErrMsg As String = ""

            Try
                '��ȡ����
                If Me.getModuleData_NDJH(strErrMsg, Me.m_strQuery_NDJH) = False Then
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
                    .iQueryTable = Me.m_objDataSet_NDJH.Tables(strTable)
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

        Private Sub btnNDJHSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNDJHSearch_Full.Click
            Me.doSearchFull("btnNDJHSearch_Full")
        End Sub

        Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
            Me.doAddNew("btnAddNew")
        End Sub

        Private Sub btnOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOpen.Click
            Me.doOpen("btnOpen")
        End Sub

        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Me.doUpdate("btnUpdate")
        End Sub

        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Me.doDelete("btnDelete")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace
