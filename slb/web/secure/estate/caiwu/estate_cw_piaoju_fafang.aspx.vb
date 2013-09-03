Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_cw_piaoju_fafang
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   ��Ʊ�ݷ��Ź���
    '
    ' QueryString���������� 
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IEstateCwPiaojuFafang����
    ' ���ļ�¼��
    '     zengxianglin 2009-05-17 ����
    '----------------------------------------------------------------

    Partial Class estate_cw_piaoju_fafang
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub




        'zengxianglin 2008-11-18
        'zengxianglin 2008-11-18





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
        Private m_cstrPrevilegeParamPrefix As String = "estate_cw_piaoju_previlege_param"
        Private m_blnPrevilegeParams(3) As Boolean

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateCwPiaojuFafang
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateCwPiaojuFafang
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdPIAOJU��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_PIAOJU As String = "chkPIAOJU"
        Private Const m_cstrDataGridInDIV_PIAOJU As String = "divPIAOJU"
        Private m_intFixedColumns_PIAOJU As Integer

        '----------------------------------------------------------------
        'Ҫ���ʵ�����
        '----------------------------------------------------------------
        Private m_objDataSet_PIAOJU As Josco.JSOA.Common.Data.estateCaiwuData
        Private m_strQuery_PIAOJU As String
        Private m_intRows_PIAOJU As Integer











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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateCwPiaojuFafang)
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
                If Me.m_blnPrevilegeParams(0) = True And Me.m_blnPrevilegeParams(1) = True Then
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
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtPIAOJUQuery.Value = .htxtPIAOJUQuery
                    Me.htxtPIAOJURows.Value = .htxtPIAOJURows
                    Me.htxtPIAOJUSort.Value = .htxtPIAOJUSort
                    Me.htxtPIAOJUSortColumnIndex.Value = .htxtPIAOJUSortColumnIndex
                    Me.htxtPIAOJUSortType.Value = .htxtPIAOJUSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftPIAOJU.Value = .htxtDivLeftPIAOJU
                    Me.htxtDivTopPIAOJU.Value = .htxtDivTopPIAOJU

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtPIAOJUPageIndex.Text = .txtPIAOJUPageIndex
                    Me.txtPIAOJUPageSize.Text = .txtPIAOJUPageSize

                    Me.txtPIAOJUSearch_PJPH.Text = .txtPIAOJUSearch_PJPH
                    Me.txtPIAOJUSearch_FGFHMC.Text = .txtPIAOJUSearch_FGFHMC
                    Me.txtPIAOJUSearch_FFRQMin.Text = .txtPIAOJUSearch_FFRQMin
                    Me.txtPIAOJUSearch_FFRQMax.Text = .txtPIAOJUSearch_FFRQMax
                    Me.txtPIAOJUSearch_PJHM.Text = .txtPIAOJUSearch_PJHM
                    Me.ddlPIAOJUSearch_ZTBZ.SelectedIndex = .ddlPIAOJUSearch_ZTBZ_SelectedIndex
                    'zengxianglin 2008-05-17
                    Me.ddlPIAOJUSearch_HXBZ.SelectedIndex = .ddlPIAOJUSearch_HXBZ_SelectedIndex
                    'zengxianglin 2008-05-17

                    Me.txtFGFH.Text = .txtFGFH
                    Me.htxtFGFH.Value = .htxtFGFH
                    Me.txtPJQZ.Text = .txtPJQZ
                    'zengxianglin 2008-11-18
                    Me.txtFFPC.Text = .txtFFPC
                    'zengxianglin 2008-11-18
                    Me.txtKSHM.Text = .txtKSHM
                    Me.txtZZHM.Text = .txtZZHM
                    Me.ddlPJLX.SelectedIndex = .ddlPJLX_SelectedIndex

                    Try
                        Me.grdPIAOJU.PageSize = .grdPIAOJUPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdPIAOJU.CurrentPageIndex = .grdPIAOJUCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdPIAOJU.SelectedIndex = .grdPIAOJUSelectedIndex
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strSessionId As String = ""

            saveModuleInformation = ""

            Try
                '����SessionId
                strSessionId = objPulicParameters.getNewGuid()
                If strSessionId = "" Then Exit Try

                '��������
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateCwPiaojuFafang

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtPIAOJUQuery = Me.htxtPIAOJUQuery.Value
                    .htxtPIAOJURows = Me.htxtPIAOJURows.Value
                    .htxtPIAOJUSort = Me.htxtPIAOJUSort.Value
                    .htxtPIAOJUSortColumnIndex = Me.htxtPIAOJUSortColumnIndex.Value
                    .htxtPIAOJUSortType = Me.htxtPIAOJUSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftPIAOJU = Me.htxtDivLeftPIAOJU.Value
                    .htxtDivTopPIAOJU = Me.htxtDivTopPIAOJU.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .txtPIAOJUPageIndex = Me.txtPIAOJUPageIndex.Text
                    .txtPIAOJUPageSize = Me.txtPIAOJUPageSize.Text

                    .txtPIAOJUSearch_PJPH = Me.txtPIAOJUSearch_PJPH.Text
                    .txtPIAOJUSearch_FGFHMC = Me.txtPIAOJUSearch_FGFHMC.Text
                    .txtPIAOJUSearch_PJHM = Me.txtPIAOJUSearch_PJHM.Text
                    .txtPIAOJUSearch_FFRQMin = Me.txtPIAOJUSearch_FFRQMin.Text
                    .txtPIAOJUSearch_FFRQMax = Me.txtPIAOJUSearch_FFRQMax.Text
                    .ddlPIAOJUSearch_ZTBZ_SelectedIndex = Me.ddlPIAOJUSearch_ZTBZ.SelectedIndex
                    'zengxianglin 2008-05-17
                    .ddlPIAOJUSearch_HXBZ_SelectedIndex = Me.ddlPIAOJUSearch_HXBZ.SelectedIndex
                    'zengxianglin 2008-05-17

                    .txtFGFH = Me.txtFGFH.Text
                    .htxtFGFH = Me.htxtFGFH.Value
                    .txtPJQZ = Me.txtPJQZ.Text
                    'zengxianglin 2008-11-18
                    .txtFFPC = Me.txtFFPC.Text
                    'zengxianglin 2008-11-18
                    .txtKSHM = Me.txtKSHM.Text
                    .txtZZHM = Me.txtZZHM.Text
                    .ddlPJLX_SelectedIndex = Me.ddlPJLX.SelectedIndex

                    .grdPIAOJUPageSize = Me.grdPIAOJU.PageSize
                    .grdPIAOJUCurrentPageIndex = Me.grdPIAOJU.CurrentPageIndex
                    .grdPIAOJUSelectedIndex = Me.grdPIAOJU.SelectedIndex
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
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIDmxzZzjg As Josco.JsKernal.BusinessFacade.IDmxzZzjg
                Try
                    objIDmxzZzjg = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzZzjg)
                Catch ex As Exception
                    objIDmxzZzjg = Nothing
                End Try
                If Not (objIDmxzZzjg Is Nothing) Then
                    If objIDmxzZzjg.oExitMode = True Then
                        Select Case objIDmxzZzjg.iSourceControlId.ToUpper
                            Case "btnSelect_ZZDM".ToUpper
                                Dim strZZDM As String = ""
                                Me.txtFGFH.Text = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtFGFH.Text, strZZDM) = True Then
                                    Me.htxtFGFH.Value = strZZDM
                                Else
                                    Me.htxtFGFH.Value = ""
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzZzjg.SafeRelease(objIDmxzZzjg)
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
                        Me.htxtPIAOJUQuery.Value = objISjcxCxtj.oQueryString
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateCwPiaojuFafang)
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
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateCwPiaojuFafang)
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
                Me.m_intFixedColumns_PIAOJU = objPulicParameters.getObjectValue(Me.htxtPIAOJUFixed.Value, 0)
                Me.m_intRows_PIAOJU = objPulicParameters.getObjectValue(Me.htxtPIAOJURows.Value, 0)
                Me.m_strQuery_PIAOJU = Me.htxtPIAOJUQuery.Value
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
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQuery.Value)
                End If
            Catch ex As Exception
            End Try

        End Sub













        '----------------------------------------------------------------
        ' ��ȡgrdPIAOJU����������(Ĭ�ϱ�ǰ׺a.)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_PIAOJU( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_PIAOJU = False
            strQuery = ""

            Try
                '����Ʊ�����š�����
                Dim strPJPH As String
                strPJPH = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_PJPH
                If Me.txtPIAOJUSearch_PJPH.Text.Length > 0 Then Me.txtPIAOJUSearch_PJPH.Text = Me.txtPIAOJUSearch_PJPH.Text.Trim()
                If Me.txtPIAOJUSearch_PJPH.Text <> "" Then
                    If objPulicParameters.isIntegerString(Me.txtPIAOJUSearch_PJPH.Text) = False Then
                        strErrMsg = "����[����]���������֣�"
                        GoTo errProc
                    End If
                    If strQuery = "" Then
                        strQuery = strPJPH + " = " + Me.txtPIAOJUSearch_PJPH.Text
                    Else
                        strQuery = strQuery + " and " + strPJPH + " = " + Me.txtPIAOJUSearch_PJPH.Text
                    End If
                End If

                '�����������С�����
                Dim strFGFH As String
                strFGFH = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_FGFHMC
                If Me.txtPIAOJUSearch_FGFHMC.Text.Length > 0 Then Me.txtPIAOJUSearch_FGFHMC.Text = Me.txtPIAOJUSearch_FGFHMC.Text.Trim()
                If Me.txtPIAOJUSearch_FGFHMC.Text <> "" Then
                    Me.txtPIAOJUSearch_FGFHMC.Text = objPulicParameters.getNewSearchString(Me.txtPIAOJUSearch_FGFHMC.Text)
                    If strQuery = "" Then
                        strQuery = strFGFH + " like '" + Me.txtPIAOJUSearch_FGFHMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strFGFH + " like '" + Me.txtPIAOJUSearch_FGFHMC.Text + "%'"
                    End If
                End If

                '�����������ڡ�����
                Dim strFFRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strFFRQ = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_FFRQ
                If Me.txtPIAOJUSearch_FFRQMin.Text.Length > 0 Then Me.txtPIAOJUSearch_FFRQMin.Text = Me.txtPIAOJUSearch_FFRQMin.Text.Trim()
                If Me.txtPIAOJUSearch_FFRQMax.Text.Length > 0 Then Me.txtPIAOJUSearch_FFRQMax.Text = Me.txtPIAOJUSearch_FFRQMax.Text.Trim()
                If Me.txtPIAOJUSearch_FFRQMin.Text <> "" And Me.txtPIAOJUSearch_FFRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtPIAOJUSearch_FFRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��[��������]��"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtPIAOJUSearch_FFRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��[��������]��"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtPIAOJUSearch_FFRQMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtPIAOJUSearch_FFRQMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtPIAOJUSearch_FFRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtPIAOJUSearch_FFRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strFFRQ + " between '" + Me.txtPIAOJUSearch_FFRQMin.Text + "' and '" + Me.txtPIAOJUSearch_FFRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strFFRQ + " between '" + Me.txtPIAOJUSearch_FFRQMin.Text + "' and '" + Me.txtPIAOJUSearch_FFRQMax.Text + "'"
                    End If
                ElseIf Me.txtPIAOJUSearch_FFRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtPIAOJUSearch_FFRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��[��������]��"
                        GoTo errProc
                    End Try
                    Me.txtPIAOJUSearch_FFRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strFFRQ + " >= '" + Me.txtPIAOJUSearch_FFRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strFFRQ + " >= '" + Me.txtPIAOJUSearch_FFRQMin.Text + "'"
                    End If
                ElseIf Me.txtPIAOJUSearch_FFRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtPIAOJUSearch_FFRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��[��������]��"
                        GoTo errProc
                    End Try
                    Me.txtPIAOJUSearch_FFRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strFFRQ + " <= '" + Me.txtPIAOJUSearch_FFRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strFFRQ + " <= '" + Me.txtPIAOJUSearch_FFRQMax.Text + "'"
                    End If
                Else
                End If

                '����Ʊ�ݺ��롱����
                Dim strPJHM As String
                strPJHM = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_PJHM
                If Me.txtPIAOJUSearch_PJHM.Text.Length > 0 Then Me.txtPIAOJUSearch_PJHM.Text = Me.txtPIAOJUSearch_PJHM.Text.Trim()
                If Me.txtPIAOJUSearch_PJHM.Text <> "" Then
                    Me.txtPIAOJUSearch_PJHM.Text = objPulicParameters.getNewSearchString(Me.txtPIAOJUSearch_PJHM.Text)
                    If strQuery = "" Then
                        strQuery = strPJHM + " like '" + Me.txtPIAOJUSearch_PJHM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strPJHM + " like '" + Me.txtPIAOJUSearch_PJHM.Text + "%'"
                    End If
                End If

                '����״̬��־������
                Dim strZTBZ As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_ZTBZ
                Select Case Me.ddlPIAOJUSearch_ZTBZ.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strZTBZ + " = " + Me.ddlPIAOJUSearch_ZTBZ.SelectedValue
                        Else
                            strQuery = strQuery + " and " + strZTBZ + " = " + Me.ddlPIAOJUSearch_ZTBZ.SelectedValue
                        End If
                End Select

                'zengxianglin 2009-05-17
                '����������־������
                Dim strHXBZ As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_HXBZ
                Select Case Me.ddlPIAOJUSearch_HXBZ.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strHXBZ + " = " + Me.ddlPIAOJUSearch_HXBZ.SelectedValue
                        Else
                            strQuery = strQuery + " and " + strHXBZ + " = " + Me.ddlPIAOJUSearch_HXBZ.SelectedValue
                        End If
                End Select
                'zengxianglin 2009-05-17
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_PIAOJU = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdPIAOJUҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       ����������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_PIAOJU( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu

            getModuleData_PIAOJU = False

            Try
                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtPIAOJUSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(Me.m_objDataSet_PIAOJU)

                '���¼�������
                If objsystemEstateCaiwu.getDataSet_PJSY(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objDataSet_PIAOJU) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_PIAOJU.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_PIAOJU.Tables(strTable)
                    Me.htxtPIAOJURows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_PIAOJU = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)

            getModuleData_PIAOJU = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdPIAOJU����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_PIAOJU(ByRef strErrMsg As String) As Boolean

            searchModuleData_PIAOJU = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_PIAOJU(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_PIAOJU(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_PIAOJU = strQuery
                Me.htxtPIAOJUQuery.Value = Me.m_strQuery_PIAOJU
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_PIAOJU = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdPIAOJU������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_PIAOJU(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_PIAOJU = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = 0
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtPIAOJUSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtPIAOJUSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_PIAOJU Is Nothing Then
                    Me.grdPIAOJU.DataSource = Nothing
                Else
                    With Me.m_objDataSet_PIAOJU.Tables(strTable)
                        Me.grdPIAOJU.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_PIAOJU.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdPIAOJU, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdPIAOJU)
                    With Me.grdPIAOJU.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdPIAOJU.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdPIAOJU, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_PIAOJU = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdPIAOJU�������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_PIAOJU(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_PIAOJU = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_PIAOJU(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_PIAOJU.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblPIAOJUGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdPIAOJU, .Count)

                    '��ʾҳ���������
                    Me.lnkCZPIAOJUMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdPIAOJU, .Count)
                    Me.lnkCZPIAOJUMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdPIAOJU, .Count)
                    Me.lnkCZPIAOJUMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdPIAOJU, .Count)
                    Me.lnkCZPIAOJUMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdPIAOJU, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZPIAOJUDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZPIAOJUSelectAll.Enabled = blnEnabled
                    Me.lnkCZPIAOJUGotoPage.Enabled = blnEnabled
                    Me.lnkCZPIAOJUSetPageSize.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_PIAOJU = True
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
                Me.btnDelete.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnFafang.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnShouhui.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnHexiao.Visible = Me.m_blnPrevilegeParams(1)
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

            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            initializeControls = False

            '���ڵ�һ�ε���ҳ��ʱִ��
            If Me.IsPostBack = False Then
                '��ʾPannel
                Me.panelMain.Visible = True
                Me.panelError.Visible = Not Me.panelMain.Visible

                'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                objControlProcess.doTranslateKey(Me.txtPIAOJUPageIndex)
                objControlProcess.doTranslateKey(Me.txtPIAOJUPageSize)
                '************************************************
                objControlProcess.doTranslateKey(Me.txtPIAOJUSearch_FGFHMC)
                objControlProcess.doTranslateKey(Me.txtPIAOJUSearch_PJPH)
                objControlProcess.doTranslateKey(Me.txtPIAOJUSearch_FFRQMin)
                objControlProcess.doTranslateKey(Me.txtPIAOJUSearch_FFRQMax)
                objControlProcess.doTranslateKey(Me.txtPIAOJUSearch_PJHM)
                '************************************************
                objControlProcess.doTranslateKey(Me.ddlPIAOJUSearch_ZTBZ)
                'zengxianglin 2009-05-17
                objControlProcess.doTranslateKey(Me.ddlPIAOJUSearch_HXBZ)
                'zengxianglin 2009-05-17
                '************************************************
                objControlProcess.doTranslateKey(Me.ddlPJLX)
                '************************************************
                objControlProcess.doTranslateKey(Me.txtZZHM)
                objControlProcess.doTranslateKey(Me.txtPJQZ)
                'zengxianglin 2008-11-18
                objControlProcess.doTranslateKey(Me.txtFFPC)
                'zengxianglin 2008-11-18
                objControlProcess.doTranslateKey(Me.txtFGFH)
                objControlProcess.doTranslateKey(Me.txtKSHM)

                '��ʾģ�鼶����
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '���ʼֵ
                If Me.m_blnSaveScence = False Then
                    Me.txtPIAOJUSearch_FFRQMin.Text = Now.ToString("yyyy-MM-dd")
                    Me.txtPIAOJUSearch_FFRQMax.Text = ""
                    '��ʾ����
                    If Me.searchModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    '��ʾ����
                    If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            End If

            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            initializeControls = True
            Exit Function
errProc:
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim strUrl As String

            Dim strUserID As String
            Dim strPassword As String
            Dim strNewPassword As String
            Dim intStep As Integer

            Dim objsystemCustomer As Josco.JsKernal.BusinessFacade.systemCustomer = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objCustomerData As Josco.JsKernal.Common.Data.CustomerData = Nothing

            strUserID = CStr(Request.QueryString("ID"))
            strPassword = CStr(Request.QueryString("password"))

            If strUserID <> "" Then
                strPassword = CStr(Request.QueryString("password"))

                '��֤
                objsystemCustomer = New Josco.JsKernal.BusinessFacade.systemCustomer
                If objsystemCustomer.doVerifyUserPassword(strErrMsg, strUserID, strPassword, strNewPassword) = False Then
                    GoTo errProc
                End If

                '��ȡ�û���Ϣ`
                If objsystemCustomer.getRenyuanData(strErrMsg, strUserID, strPassword, "0011", objCustomerData) = False Then
                    GoTo errProc
                End If

                '��¼ƾ֤
                System.Web.Security.FormsAuthentication.SetAuthCookie("*", False)

                '�����û���Ϣ
                MyBase.Customer = objCustomerData
                MyBase.UserId = strUserID
                MyBase.UserOrgPassword = strPassword
                MyBase.UserPassword = strNewPassword
                MyBase.UserEnterTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
                MyBase.LastScanTime_Chat = ""
                MyBase.LastScanTime_Notice = ""

                '������볤��
                If MyBase.doCheckPassword() = True Then
                    Exit Sub
                End If
            End If

            'Ԥ����
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
            End If

            '���Ȩ��
            Dim blnDo As Boolean
            If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                GoTo errProc
            End If
            If blnDo = False Then
                GoTo normExit
            End If

            '��ȡ�ӿڲ���
            If Me.getInterfaceParameters(strErrMsg, blnDo) = False Then
                GoTo errProc
            End If
            If blnDo = False Then
                GoTo normExit
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
        'ʵ�ֶ�grdPIAOJU�����С��еĹ̶�
        Sub grdPIAOJU_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdPIAOJU.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_PIAOJU + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_PIAOJU > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_PIAOJU - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdPIAOJU.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdPIAOJU_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPIAOJU.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblPIAOJUGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdPIAOJU, Me.m_intRows_PIAOJU)
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

        Private Sub grdPIAOJU_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdPIAOJU.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
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
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                strOldCommand = Me.m_objDataSet_PIAOJU.Tables(strTable).DefaultView.Sort

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                Me.m_objDataSet_PIAOJU.Tables(strTable).DefaultView.Sort = strFinalCommand

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtPIAOJUSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtPIAOJUSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtPIAOJUSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
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












        Private Sub doMoveFirst_PIAOJU(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdPIAOJU.PageCount)
                Me.grdPIAOJU.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
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

        Private Sub doMoveLast_PIAOJU(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdPIAOJU.PageCount - 1, Me.grdPIAOJU.PageCount)
                Me.grdPIAOJU.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
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

        Private Sub doMoveNext_PIAOJU(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdPIAOJU.CurrentPageIndex + 1, Me.grdPIAOJU.PageCount)
                Me.grdPIAOJU.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
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

        Private Sub doMovePrevious_PIAOJU(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdPIAOJU.CurrentPageIndex - 1, Me.grdPIAOJU.PageCount)
                Me.grdPIAOJU.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
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

        Private Sub doGotoPage_PIAOJU(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtPIAOJUPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdPIAOJU.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtPIAOJUPageIndex.Text = (Me.grdPIAOJU.CurrentPageIndex + 1).ToString()
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

        Private Sub doSetPageSize_PIAOJU(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtPIAOJUPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdPIAOJU.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtPIAOJUPageSize.Text = (Me.grdPIAOJU.PageSize).ToString()
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

        Private Sub doSelectAll_PIAOJU(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdPIAOJU, 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU, True) = False Then
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

        Private Sub doDeSelectAll_PIAOJU(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdPIAOJU, 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU, False) = False Then
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

        Private Sub doSearch_PIAOJU(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_PIAOJU(strErrMsg) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_PIAOJU(strErrMsg) = False Then
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

        Private Sub lnkCZPIAOJUMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUMoveFirst.Click
            Me.doMoveFirst_PIAOJU("lnkCZPIAOJUMoveFirst")
        End Sub

        Private Sub lnkCZPIAOJUMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUMoveLast.Click
            Me.doMoveLast_PIAOJU("lnkCZPIAOJUMoveLast")
        End Sub

        Private Sub lnkCZPIAOJUMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUMoveNext.Click
            Me.doMoveNext_PIAOJU("lnkCZPIAOJUMoveNext")
        End Sub

        Private Sub lnkCZPIAOJUMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUMovePrev.Click
            Me.doMovePrevious_PIAOJU("lnkCZPIAOJUMovePrev")
        End Sub

        Private Sub lnkCZPIAOJUGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUGotoPage.Click
            Me.doGotoPage_PIAOJU("lnkCZPIAOJUGotoPage")
        End Sub

        Private Sub lnkCZPIAOJUSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUSetPageSize.Click
            Me.doSetPageSize_PIAOJU("lnkCZPIAOJUSetPageSize")
        End Sub

        Private Sub lnkCZPIAOJUSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUSelectAll.Click
            Me.doSelectAll_PIAOJU("lnkCZPIAOJUSelectAll")
        End Sub

        Private Sub lnkCZPIAOJUDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZPIAOJUDeSelectAll.Click
            Me.doDeSelectAll_PIAOJU("lnkCZPIAOJUDeSelectAll")
        End Sub

        Private Sub btnPIAOJUSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPIAOJUSearch.Click
            Me.doSearch_PIAOJU("btnPIAOJUSearch")
        End Sub











        Private Sub doSelect_ZZDM(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '�����ֳ�����
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIDmxzZzjg As Josco.JsKernal.BusinessFacade.IDmxzZzjg = Nothing
                Dim strUrl As String = ""
                objIDmxzZzjg = New Josco.JsKernal.BusinessFacade.IDmxzZzjg
                With objIDmxzZzjg
                    .iAllowInput = False
                    .iMultiSelect = False
                    .iAllowNull = False
                    .iSelectFFFW = False
                    .iBumenList = ""
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
                Session.Add(strNewSessionId, objIDmxzZzjg)
                strUrl = ""
                strUrl += "../../dmxz/dmxz_zzjg.aspx"
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

        'zengxianglin 2008-11-18
        Private Sub doJSPC(ByVal strControlId As String)

            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '���
                If Me.htxtFGFH.Value.Trim = "" Then
                    strErrMsg = "����û��ָ��[����]��"
                    GoTo errProc
                End If

                '����
                Dim strPJPH As String = ""
                If objsystemEstateCaiwu.getNewPjph(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtFGFH.Value, strPJPH) = False Then
                    GoTo errProc
                End If
                Me.txtFFPC.Text = strPJPH
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub
        'zengxianglin 2008-11-18

        'zengxianglin 2008-11-18
        Private Sub btnJSPC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJSPC.Click
            Me.doJSPC("btnJSPC")
        End Sub
        'zengxianglin 2008-11-18

        Private Sub btnSelect_ZZDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_ZZDM.Click
            Me.doSelect_ZZDM("btnSelect_ZZDM")
        End Sub










        Private Sub doSearchFull(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strErrMsg As String = ""

            Try
                '��ȡ����
                If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
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
                    .iQueryTable = Me.m_objDataSet_PIAOJU.Tables(strTable)
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

        Private Sub btnPIAOJUSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPIAOJUSearch_Full.Click
            Me.doSearchFull("btnPIAOJUSearch_Full")
        End Sub













        '----------------------------------------------------------------
        'ģ���������������
        '----------------------------------------------------------------
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

        Private Sub doDelete(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
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
                intRows = Me.grdPIAOJU.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdPIAOJU.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU) = True Then
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
                    '���ɾ��
                    Dim intColIndex(2) As Integer
                    Dim strWYBS As String = ""
                    Dim strPJHM As String = ""
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdPIAOJU, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_WYBS)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdPIAOJU, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_WYPJHM)
                    intRows = Me.grdPIAOJU.Items.Count
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdPIAOJU.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU) = True Then
                            strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdPIAOJU.Items(i), intColIndex(0))
                            strPJHM = objDataGridProcess.getDataGridCellValue(Me.grdPIAOJU.Items(i), intColIndex(1))

                            'ɾ������
                            If objsystemEstateCaiwu.doPiaoju_Delete(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS) = False Then
                                GoTo errProc
                            End If

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_����Ʊ��]��ɾ����[" + strPJHM + "]�����ϣ�")
                        End If
                    Next

                    '���»�ȡ����
                    If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                        GoTo errProc
                    End If

                    'ˢ��������ʾ
                    If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doShouhui(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
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
                intRows = Me.grdPIAOJU.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdPIAOJU.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU) = True Then
                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "����δѡ��Ҫ�ջص�����(ֻ���ջ�[δʹ��]��Ʊ��)��"
                        GoTo errProc
                    End If
                End If

                'ѯ��
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷʵ׼���ջ�ѡ����[" + intSelect.ToString() + "]����������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��ʾ��ش��ǡ����Ŵ���
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '����ջ�
                    Dim intColIndex(2) As Integer
                    Dim strWYBS As String = ""
                    Dim strPJHM As String = ""
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdPIAOJU, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_WYBS)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdPIAOJU, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_WYPJHM)
                    intRows = Me.grdPIAOJU.Items.Count
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdPIAOJU.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU) = True Then
                            strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdPIAOJU.Items(i), intColIndex(0))
                            strPJHM = objDataGridProcess.getDataGridCellValue(Me.grdPIAOJU.Items(i), intColIndex(1))

                            '�ջش���
                            If objsystemEstateCaiwu.doPiaoju_Mark(strErrMsg, _
                                MyBase.UserId, MyBase.UserPassword, _
                                strWYBS, _
                                 Josco.JSOA.Common.Data.estateCaiwuData.enumPiaojuStatus.Shouhui, _
                                 Nothing) = False Then
                                GoTo errProc
                            End If

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_����Ʊ��]���ջ���[" + strPJHM + "]�����ϣ�")
                        End If
                    Next

                    '���»�ȡ����
                    If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                        GoTo errProc
                    End If

                    'ˢ��������ʾ
                    If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doFafang(ByVal strControlId As String)

            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 0

            Try
                '���
                intStep = 1
                If Me.htxtFGFH.Value.Trim = "" Then
                    strErrMsg = "����û������[��������]��"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-18
                If Me.txtFFPC.Text.Trim = "" Then
                    strErrMsg = "����û������[����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtFFPC.Text) = False Then
                    strErrMsg = "������Ч��[����]��"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-18
                If Me.txtKSHM.Text.Trim = "" Then
                    strErrMsg = "����û������[��ʼ����]��"
                    GoTo errProc
                End If
                If Me.txtZZHM.Text.Trim = "" Then
                    strErrMsg = "����û������[��������]��"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtKSHM.Text) = False Then
                    strErrMsg = "������Ч��[��ʼ����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtZZHM.Text) = False Then
                    strErrMsg = "������Ч��[��������]��"
                    GoTo errProc
                End If
                Dim strPJLX As String = ""
                If Me.ddlPJLX.SelectedIndex >= 0 Then
                    strPJLX = Me.ddlPJLX.SelectedValue
                End If
                Dim intMin As Integer = objPulicParameters.getObjectValue(Me.txtKSHM.Text, 0)
                Dim intMax As Integer = objPulicParameters.getObjectValue(Me.txtZZHM.Text, 0)

                'ѯ��
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ���������������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '����
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '¼�ô���
                    If objsystemEstateCaiwu.doPiaoju_Fafang(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtPJQZ.Text.Trim, intMin, intMax, strPJLX, Me.htxtFGFH.Value.Trim, Me.txtFFPC.Text) = False Then
                        GoTo errProc
                    End If

                    '��ʾ
                    Me.txtPIAOJUSearch_FFRQMin.Text = Now.ToString("yyyy-MM-dd")
                    Me.txtPIAOJUSearch_FFRQMax.Text = ""
                    Me.ddlPIAOJUSearch_ZTBZ.SelectedIndex = -1
                    Me.txtPIAOJUSearch_FGFHMC.Text = ""
                    Me.txtPIAOJUSearch_PJHM.Text = ""
                    Me.txtPIAOJUSearch_PJPH.Text = ""
                    If Me.searchModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ������ɹ���")
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        'zengxianglin 2009-05-17
        Private Sub doHexiao(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
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
                intRows = Me.grdPIAOJU.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdPIAOJU.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU) = True Then
                            intSelect += 1
                        End If
                    Next
                    If intSelect < 1 Then
                        strErrMsg = "����δѡ��Ҫ������Ʊ��(ֻ�ܺ���[��ʹ��|������]��Ʊ��)��"
                        GoTo errProc
                    End If
                End If

                'ѯ��
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷʵ׼������ѡ����[" + intSelect.ToString() + "]��Ʊ������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��ʾ��ش��ǡ����Ŵ���
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '�������
                    Dim intColIndex(2) As Integer
                    Dim strWYBS As String = ""
                    Dim strPJHM As String = ""
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdPIAOJU, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_WYBS)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdPIAOJU, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_WYPJHM)
                    intRows = Me.grdPIAOJU.Items.Count
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdPIAOJU.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_PIAOJU) = True Then
                            strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdPIAOJU.Items(i), intColIndex(0))
                            strPJHM = objDataGridProcess.getDataGridCellValue(Me.grdPIAOJU.Items(i), intColIndex(1))

                            '��������
                            If objsystemEstateCaiwu.doPiaoju_Hexiao(strErrMsg, _
                                MyBase.UserId, MyBase.UserPassword, _
                                strWYBS, _
                                 MyBase.UserId, _
                                 Now.ToString("yyyy-MM-dd HH:mm:ss")) = False Then
                                GoTo errProc
                            End If

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_����Ʊ��]�к�����[" + strPJHM + "]��Ʊ�ݣ�")
                        End If
                    Next

                    '���»�ȡ����
                    If Me.getModuleData_PIAOJU(strErrMsg, Me.m_strQuery_PIAOJU) = False Then
                        GoTo errProc
                    End If
                    'ˢ��������ʾ
                    If Me.showModuleData_PIAOJU(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub
        'zengxianglin 2009-05-17

        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Me.doDelete("btnDelete")
        End Sub

        Private Sub btnFafang_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFafang.Click
            Me.doFafang("btnFafang")
        End Sub

        Private Sub btnShouhui_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShouhui.Click
            Me.doShouhui("btnShouhui")
        End Sub

        'zengxianglin 2009-05-17
        Private Sub btnHexiao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHexiao.Click
            Me.doHexiao("btnHexiao")
        End Sub
        'zengxianglin 2009-05-17

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace
