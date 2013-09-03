Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_es_xz_jyxx
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   ��ѡ��ҵ������Ϣ
    '
    ' QueryString���������� 
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IEstateEsXzJyxx����
    '----------------------------------------------------------------

    Partial Class estate_es_xz_jyxx
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
        Private m_cstrRelativePathToImage As String = "../../"

        '----------------------------------------------------------------
        'ģ����Ȩ����
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsXzJyxx
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsXzJyxx
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdJYXX��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_JYXX As String = "chkJYXX"
        Private Const m_cstrDataGridInDIV_JYXX As String = "divJYXX"
        Private m_intFixedColumns_JYXX As Integer

        '----------------------------------------------------------------
        'Ҫ���ʵ�����
        '----------------------------------------------------------------
        Private m_objDataSet_JYXX As Josco.JSOA.Common.Data.estateErshouData
        Private m_strQuery_JYXX As String
        Private m_intRows_JYXX As Integer

        '----------------------------------------------------------------
        '�ӿ�����
        '----------------------------------------------------------------
        Private m_blnQxControl As Boolean

        '----------------------------------------------------------------
        '�ӿ�����
        '----------------------------------------------------------------
        Private m_blnAllowNull As Boolean











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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsXzJyxx)
                    Catch ex As Exception
                        Me.m_objInterface = Nothing
                    End Try
                Else
                    Me.m_objInterface = Nothing
                End If
                If Not (Me.m_objInterface Is Nothing) Then
                    '���÷��ز���
                    Me.m_objInterface.oExitMode = False
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
        ' ��ԭģ���ֳ���Ϣ���ͷ���Ӧ����Դ
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.htxtJYXXQuery.Value = .htxtJYXXQuery
                    Me.htxtJYXXRows.Value = .htxtJYXXRows
                    Me.htxtJYXXSort.Value = .htxtJYXXSort
                    Me.htxtJYXXSortColumnIndex.Value = .htxtJYXXSortColumnIndex
                    Me.htxtJYXXSortType.Value = .htxtJYXXSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftJYXX.Value = .htxtDivLeftJYXX
                    Me.htxtDivTopJYXX.Value = .htxtDivTopJYXX

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtJYXXPageIndex.Text = .txtJYXXPageIndex
                    Me.txtJYXXPageSize.Text = .txtJYXXPageSize

                    Me.txtJYXXSearch_KHMC.Text = .txtJYXXSearch_KHMC
                    Me.txtJYXXSearch_YZMC.Text = .txtJYXXSearch_YZMC
                    Me.txtJYXXSearch_JYBH.Text = .txtJYXXSearch_JYBH
                    Me.txtJYXXSearch_WYDZ.Text = .txtJYXXSearch_WYDZ
                    Me.txtJYXXSearch_JYRQMin.Text = .txtJYXXSearch_JYRQMin
                    Me.txtJYXXSearch_JYRQMax.Text = .txtJYXXSearch_JYRQMax
                    Me.txtJYXXSearch_HTRQMin.Text = .txtJYXXSearch_HTRQMin
                    Me.txtJYXXSearch_HTRQMax.Text = .txtJYXXSearch_HTRQMax

                    Try
                        Me.grdJYXX.PageSize = .grdJYXXPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJYXX.CurrentPageIndex = .grdJYXXCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJYXX.SelectedIndex = .grdJYXXSelectedIndex
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
                If strSessionId = "" Then
                    Exit Try
                End If

                '��������
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsXzJyxx

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtJYXXQuery = Me.htxtJYXXQuery.Value
                    .htxtJYXXRows = Me.htxtJYXXRows.Value
                    .htxtJYXXSort = Me.htxtJYXXSort.Value
                    .htxtJYXXSortColumnIndex = Me.htxtJYXXSortColumnIndex.Value
                    .htxtJYXXSortType = Me.htxtJYXXSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftJYXX = Me.htxtDivLeftJYXX.Value
                    .htxtDivTopJYXX = Me.htxtDivTopJYXX.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .txtJYXXPageIndex = Me.txtJYXXPageIndex.Text
                    .txtJYXXPageSize = Me.txtJYXXPageSize.Text

                    .txtJYXXSearch_KHMC = Me.txtJYXXSearch_KHMC.Text
                    .txtJYXXSearch_YZMC = Me.txtJYXXSearch_YZMC.Text
                    .txtJYXXSearch_WYDZ = Me.txtJYXXSearch_WYDZ.Text
                    .txtJYXXSearch_JYBH = Me.txtJYXXSearch_JYBH.Text
                    .txtJYXXSearch_JYRQMin = Me.txtJYXXSearch_JYRQMin.Text
                    .txtJYXXSearch_JYRQMax = Me.txtJYXXSearch_JYRQMax.Text
                    .txtJYXXSearch_HTRQMin = Me.txtJYXXSearch_HTRQMin.Text
                    .txtJYXXSearch_HTRQMax = Me.txtJYXXSearch_HTRQMax.Text

                    .grdJYXXPageSize = Me.grdJYXX.PageSize
                    .grdJYXXCurrentPageIndex = Me.grdJYXX.CurrentPageIndex
                    .grdJYXXSelectedIndex = Me.grdJYXX.SelectedIndex

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
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                        Me.htxtJYXXQuery.Value = objISjcxCxtj.oQueryString
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

        End Sub

        '----------------------------------------------------------------
        ' ��ȡ�ӿڲ���(û�нӿڲ�������ʾ������Ϣҳ��)
        '----------------------------------------------------------------
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getInterfaceParameters = False
            blnContinue = True

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsXzJyxx)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try

                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    'û���нӿڲ���
                Else
                    Me.m_blnInterface = True
                    '�нӿڲ���
                    Me.m_blnAllowNull = Me.m_objInterface.iAllowNull
                End If
                If Me.m_blnInterface = False Then
                    blnContinue = False
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = "����û���ṩ��ģ����Ҫ�Ľӿ���Ϣ��"
                    Exit Try
                End If

                '�����Ƿ���в鿴����
                Dim blnIS As Boolean = True
                If objsystemCustomer.isFenghangRenyuan(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserId, blnIS) = False Then
                    GoTo errProc
                End If
                Me.m_blnQxControl = blnIS

                '��ȡ�ָ��ֳ�����
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsXzJyxx)
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
                Me.m_intFixedColumns_JYXX = objPulicParameters.getObjectValue(Me.htxtJYXXFixed.Value, 0)
                Me.m_intRows_JYXX = objPulicParameters.getObjectValue(Me.htxtJYXXRows.Value, 0)
                Me.m_strQuery_JYXX = Me.htxtJYXXQuery.Value

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

        End Sub













        '----------------------------------------------------------------
        ' ��ȡgrdJYXX����������(Ĭ�ϱ�ǰ׺a.)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_JYXX( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_JYXX = False
            strQuery = ""

            Try
                '�����ͻ����ơ�����
                Dim strKHMC As String
                strKHMC = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_KHMC
                If Me.txtJYXXSearch_KHMC.Text.Length > 0 Then Me.txtJYXXSearch_KHMC.Text = Me.txtJYXXSearch_KHMC.Text.Trim()
                If Me.txtJYXXSearch_KHMC.Text <> "" Then
                    Me.txtJYXXSearch_KHMC.Text = objPulicParameters.getNewSearchString(Me.txtJYXXSearch_KHMC.Text)
                    If strQuery = "" Then
                        strQuery = strKHMC + " like '" + Me.txtJYXXSearch_KHMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strKHMC + " like '" + Me.txtJYXXSearch_KHMC.Text + "%'"
                    End If
                End If

                '����ҵ�����ơ�����
                Dim strYZMC As String
                strYZMC = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_YZMC
                If Me.txtJYXXSearch_YZMC.Text.Length > 0 Then Me.txtJYXXSearch_YZMC.Text = Me.txtJYXXSearch_YZMC.Text.Trim()
                If Me.txtJYXXSearch_YZMC.Text <> "" Then
                    Me.txtJYXXSearch_YZMC.Text = objPulicParameters.getNewSearchString(Me.txtJYXXSearch_YZMC.Text)
                    If strQuery = "" Then
                        strQuery = strYZMC + " like '" + Me.txtJYXXSearch_YZMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strYZMC + " like '" + Me.txtJYXXSearch_YZMC.Text + "%'"
                    End If
                End If

                '�������ױ�š�����
                Dim strJYBH As String
                strJYBH = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH
                If Me.txtJYXXSearch_JYBH.Text.Length > 0 Then Me.txtJYXXSearch_JYBH.Text = Me.txtJYXXSearch_JYBH.Text.Trim()
                If Me.txtJYXXSearch_JYBH.Text <> "" Then
                    Me.txtJYXXSearch_JYBH.Text = objPulicParameters.getNewSearchString(Me.txtJYXXSearch_JYBH.Text)
                    If strQuery = "" Then
                        strQuery = strJYBH + " like '" + Me.txtJYXXSearch_JYBH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJYBH + " like '" + Me.txtJYXXSearch_JYBH.Text + "%'"
                    End If
                End If

                '������ҵ��ַ������
                Dim strWYDZ As String
                strWYDZ = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_WYDZ
                If Me.txtJYXXSearch_WYDZ.Text.Length > 0 Then Me.txtJYXXSearch_WYDZ.Text = Me.txtJYXXSearch_WYDZ.Text.Trim()
                If Me.txtJYXXSearch_WYDZ.Text <> "" Then
                    Me.txtJYXXSearch_WYDZ.Text = objPulicParameters.getNewSearchString(Me.txtJYXXSearch_WYDZ.Text)
                    If strQuery = "" Then
                        strQuery = strWYDZ + " like '" + Me.txtJYXXSearch_WYDZ.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strWYDZ + " like '" + Me.txtJYXXSearch_WYDZ.Text + "%'"
                    End If
                End If

                '�����������ڡ�����
                Dim strJYRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strJYRQ = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYRQ
                If Me.txtJYXXSearch_JYRQMin.Text.Length > 0 Then Me.txtJYXXSearch_JYRQMin.Text = Me.txtJYXXSearch_JYRQMin.Text.Trim()
                If Me.txtJYXXSearch_JYRQMax.Text.Length > 0 Then Me.txtJYXXSearch_JYRQMax.Text = Me.txtJYXXSearch_JYRQMax.Text.Trim()
                If Me.txtJYXXSearch_JYRQMin.Text <> "" And Me.txtJYXXSearch_JYRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtJYXXSearch_JYRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtJYXXSearch_JYRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtJYXXSearch_JYRQMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtJYXXSearch_JYRQMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtJYXXSearch_JYRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtJYXXSearch_JYRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strJYRQ + " between '" + Me.txtJYXXSearch_JYRQMin.Text + "' and '" + Me.txtJYXXSearch_JYRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJYRQ + " between '" + Me.txtJYXXSearch_JYRQMin.Text + "' and '" + Me.txtJYXXSearch_JYRQMax.Text + "'"
                    End If
                ElseIf Me.txtJYXXSearch_JYRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtJYXXSearch_JYRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtJYXXSearch_JYRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strJYRQ + " >= '" + Me.txtJYXXSearch_JYRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJYRQ + " >= '" + Me.txtJYXXSearch_JYRQMin.Text + "'"
                    End If
                ElseIf Me.txtJYXXSearch_JYRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtJYXXSearch_JYRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtJYXXSearch_JYRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strJYRQ + " <= '" + Me.txtJYXXSearch_JYRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJYRQ + " <= '" + Me.txtJYXXSearch_JYRQMax.Text + "'"
                    End If
                Else
                End If

                '������ͬ���ڡ�����
                Dim strHTRQ As String
                strHTRQ = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTRQ
                If Me.txtJYXXSearch_HTRQMin.Text.Length > 0 Then Me.txtJYXXSearch_HTRQMin.Text = Me.txtJYXXSearch_HTRQMin.Text.Trim()
                If Me.txtJYXXSearch_HTRQMax.Text.Length > 0 Then Me.txtJYXXSearch_HTRQMax.Text = Me.txtJYXXSearch_HTRQMax.Text.Trim()
                If Me.txtJYXXSearch_HTRQMin.Text <> "" And Me.txtJYXXSearch_HTRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtJYXXSearch_HTRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtJYXXSearch_HTRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtJYXXSearch_HTRQMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtJYXXSearch_HTRQMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtJYXXSearch_HTRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtJYXXSearch_HTRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strHTRQ + " between '" + Me.txtJYXXSearch_HTRQMin.Text + "' and '" + Me.txtJYXXSearch_HTRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " between '" + Me.txtJYXXSearch_HTRQMin.Text + "' and '" + Me.txtJYXXSearch_HTRQMax.Text + "'"
                    End If
                ElseIf Me.txtJYXXSearch_HTRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtJYXXSearch_HTRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtJYXXSearch_HTRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strHTRQ + " >= '" + Me.txtJYXXSearch_HTRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " >= '" + Me.txtJYXXSearch_HTRQMin.Text + "'"
                    End If
                ElseIf Me.txtJYXXSearch_HTRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtJYXXSearch_HTRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtJYXXSearch_HTRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strHTRQ + " <= '" + Me.txtJYXXSearch_HTRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " <= '" + Me.txtJYXXSearch_HTRQMax.Text + "'"
                    End If
                Else
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_JYXX = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdJYXXҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       ����������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_JYXX( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_JYXX = False

            Try
                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtJYXXSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_JYXX)

                '���¼�������
                If objsystemEstateErshou.getDataSet_ES_JYXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_blnQxControl, Me.m_objDataSet_JYXX) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_JYXX.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_JYXX.Tables(strTable)
                    Me.htxtJYXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_JYXX = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_JYXX = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdJYXX����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_JYXX(ByRef strErrMsg As String) As Boolean

            searchModuleData_JYXX = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_JYXX(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_JYXX(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_JYXX = strQuery
                Me.htxtJYXXQuery.Value = Me.m_strQuery_JYXX

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_JYXX = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdJYXX������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_JYXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_JYXX = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = 0
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtJYXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtJYXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_JYXX Is Nothing Then
                    Me.grdJYXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_JYXX.Tables(strTable)
                        Me.grdJYXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_JYXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdJYXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdJYXX)
                    With Me.grdJYXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '����ѡ����
                Me.grdJYXX.Columns(0).Visible = False

                '������
                Me.grdJYXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                ''�ָ������е�CheckBox״̬
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdJYXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_JYXX) = False Then
                '    GoTo errProc
                'End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_JYXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdJYXX�������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_JYXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_JYXX = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_JYXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_JYXX.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblJYXXGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdJYXX, .Count)

                    '��ʾҳ���������
                    Me.lnkCZJYXXMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdJYXX, .Count)
                    Me.lnkCZJYXXMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdJYXX, .Count)
                    Me.lnkCZJYXXMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdJYXX, .Count)
                    Me.lnkCZJYXXMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdJYXX, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZJYXXDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZJYXXSelectAll.Enabled = blnEnabled
                    Me.lnkCZJYXXGotoPage.Enabled = blnEnabled
                    Me.lnkCZJYXXSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_JYXX = True
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
                Me.btnNull.Visible = Me.m_blnAllowNull

                Me.lnkCZJYXXSelectAll.Enabled = False
                Me.lnkCZJYXXDeSelectAll.Enabled = False

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

                '��ʾ��ʾ
                Me.lblSelectMode.Text = ""

                'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                objControlProcess.doTranslateKey(Me.txtJYXXPageIndex)
                objControlProcess.doTranslateKey(Me.txtJYXXPageSize)
                '************************************************
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_YZMC)
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_KHMC)
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_JYBH)
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_WYDZ)
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_JYRQMin)
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_JYRQMax)
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_HTRQMin)
                objControlProcess.doTranslateKey(Me.txtJYXXSearch_HTRQMax)
                '************************************************

                '��ʾģ�鼶����
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '���ʼֵ
                If Me.m_blnSaveScence = False Then
                    Me.txtJYXXSearch_JYRQMin.Text = Now.Year.ToString + "-01-01"
                    If Me.searchModuleData_JYXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                        GoTo errProc
                    End If
                End If
                If Me.showModuleData_JYXX(strErrMsg) = False Then
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
            Dim blnDo As Boolean

            'Ԥ����
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
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

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_JYXX)
        End Sub












        '----------------------------------------------------------------
        '�����¼�������
        '----------------------------------------------------------------
        'ʵ�ֶ�grdJYXX�����С��еĹ̶�
        Sub grdJYXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdJYXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_JYXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_JYXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_JYXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdJYXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdJYXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdJYXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblJYXXGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdJYXX, Me.m_intRows_JYXX)
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

        Private Sub grdJYXX_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdJYXX.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
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
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                strOldCommand = Me.m_objDataSet_JYXX.Tables(strTable).DefaultView.Sort

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                Me.m_objDataSet_JYXX.Tables(strTable).DefaultView.Sort = strFinalCommand

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtJYXXSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtJYXXSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtJYXXSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_JYXX(strErrMsg) = False Then
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












        Private Sub doMoveFirst_JYXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdJYXX.PageCount)
                Me.grdJYXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_JYXX(strErrMsg) = False Then
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

        Private Sub doMoveLast_JYXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdJYXX.PageCount - 1, Me.grdJYXX.PageCount)
                Me.grdJYXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_JYXX(strErrMsg) = False Then
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

        Private Sub doMoveNext_JYXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdJYXX.CurrentPageIndex + 1, Me.grdJYXX.PageCount)
                Me.grdJYXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_JYXX(strErrMsg) = False Then
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

        Private Sub doMovePrevious_JYXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdJYXX.CurrentPageIndex - 1, Me.grdJYXX.PageCount)
                Me.grdJYXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_JYXX(strErrMsg) = False Then
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

        Private Sub doGotoPage_JYXX(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtJYXXPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdJYXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_JYXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtJYXXPageIndex.Text = (Me.grdJYXX.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_JYXX(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtJYXXPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdJYXX.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_JYXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtJYXXPageSize.Text = (Me.grdJYXX.PageSize).ToString()

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

        Private Sub doSelectAll_JYXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdJYXX, 0, Me.m_cstrCheckBoxIdInDataGrid_JYXX, True) = False Then
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

        Private Sub doDeSelectAll_JYXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdJYXX, 0, Me.m_cstrCheckBoxIdInDataGrid_JYXX, False) = False Then
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

        Private Sub doSearch_JYXX(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_JYXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_JYXX(strErrMsg) = False Then
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

        Private Sub lnkCZJYXXMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXMoveFirst.Click
            Me.doMoveFirst_JYXX("lnkCZJYXXMoveFirst")
        End Sub

        Private Sub lnkCZJYXXMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXMoveLast.Click
            Me.doMoveLast_JYXX("lnkCZJYXXMoveLast")
        End Sub

        Private Sub lnkCZJYXXMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXMoveNext.Click
            Me.doMoveNext_JYXX("lnkCZJYXXMoveNext")
        End Sub

        Private Sub lnkCZJYXXMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXMovePrev.Click
            Me.doMovePrevious_JYXX("lnkCZJYXXMovePrev")
        End Sub

        Private Sub lnkCZJYXXGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXGotoPage.Click
            Me.doGotoPage_JYXX("lnkCZJYXXGotoPage")
        End Sub

        Private Sub lnkCZJYXXSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXSetPageSize.Click
            Me.doSetPageSize_JYXX("lnkCZJYXXSetPageSize")
        End Sub

        Private Sub lnkCZJYXXSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXSelectAll.Click
            Me.doSelectAll_JYXX("lnkCZJYXXSelectAll")
        End Sub

        Private Sub lnkCZJYXXDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZJYXXDeSelectAll.Click
            Me.doDeSelectAll_JYXX("lnkCZJYXXDeSelectAll")
        End Sub

        Private Sub btnJYXXSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJYXXSearch.Click
            Me.doSearch_JYXX("btnJYXXSearch")
        End Sub












        Private Sub doSearchFull(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI

            Try
                '��ȡ����
                If Me.getModuleData_JYXX(strErrMsg, Me.m_strQuery_JYXX) = False Then
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
                    .iQueryTable = Me.m_objDataSet_JYXX.Tables(strTable)
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

        Private Sub btnJYXXSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJYXXSearch_Full.Click
            Me.doSearchFull("btnJYXXSearch_Full")
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
                    Me.m_objInterface.oExitMode = False
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

        Private Sub doOK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '���
                If Me.grdJYXX.SelectedIndex < 0 Then
                    strErrMsg = "����û���κν��ף�"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdJYXX.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strValue As String = ""

                '���ز���
                If Me.m_blnInterface = True Then
                    With Me.m_objInterface
                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdJYXX.Items(i), intColIndex)
                        .oJYBH = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTBH)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdJYXX.Items(i), intColIndex)
                        .oHTBH = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_WYBS)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdJYXX.Items(i), intColIndex)
                        .oWYBS = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTWYBS)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdJYXX.Items(i), intColIndex)
                        .oHTWYBS = strValue
                    End With
                End If

                '���ش���
                Dim strSessionId As String
                Dim strUrl As String
                If Me.m_blnInterface = True Then
                    '���÷��ز���
                    Me.m_objInterface.oExitMode = True
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

        Private Sub doNull(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '���ش���
                Dim strSessionId As String
                Dim strUrl As String
                If Me.m_blnInterface = True Then
                    '���÷��ز���
                    Me.m_objInterface.oExitMode = True
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

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        Private Sub btnNull_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNull.Click
            Me.doNull("btnNull")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace
