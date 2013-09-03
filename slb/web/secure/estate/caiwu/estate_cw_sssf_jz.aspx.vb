Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_cw_sssf_jz
    ' 
    ' �������ʣ�
    '     I/O
    '
    ' ���������� 
    '   ����ʵ����֧��ת������ģ��
    '----------------------------------------------------------------

    Partial Class estate_cw_sssf_jz
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
        Private m_cstrPrevilegeParamPrefix As String = "estate_cw_sssf_previlege_param"
        Private m_blnPrevilegeParams(4) As Boolean

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateCwSssfJz
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateCwSssfJz
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdSJSZ��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_SJSZ As String = "chkSJSZ"
        Private Const m_cstrDataGridInDIV_SJSZ As String = "divSJSZ"
        Private m_intFixedColumns_SJSZ As Integer

        '----------------------------------------------------------------
        '��ǰ��������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet_SJSZ As Josco.JSOA.Common.Data.estateCaiwuData
        Private m_strQuery_SJSZ As String
        Private m_intRows_SJSZ As Integer

        '----------------------------------------------------------------
        '�ӿڲ���
        '----------------------------------------------------------------
        Private m_strOrgQRSH As String
        Private m_strQRSH As String

        Public ReadOnly Property propQRSH() As String
            Get
                propQRSH = Me.m_strOrgQRSH
            End Get
        End Property













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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateCwSssfJz)
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
                    Me.htxtDivLeftMain.Value = .htxtDivLeftMain
                    Me.htxtDivTopMain.Value = .htxtDivTopMain
                    Me.htxtDivLeftSJSZ.Value = .htxtDivLeftSJSZ
                    Me.htxtDivTopSJSZ.Value = .htxtDivTopSJSZ

                    Me.htxtSJSZQuery.Value = .htxtSJSZQuery
                    Me.htxtSJSZRows.Value = .htxtSJSZRows
                    Me.htxtSJSZSort.Value = .htxtSJSZSort
                    Me.htxtSJSZSortColumnIndex.Value = .htxtSJSZSortColumnIndex
                    Me.htxtSJSZSortType.Value = .htxtSJSZSortType

                    Me.txtSJSZSearch_PJHM.Text = .txtSJSZSearch_PJHM
                    Me.txtSJSZSearch_FSRQMax.Text = .txtSJSZSearch_FSRQMax
                    Me.txtSJSZSearch_FSRQMin.Text = .txtSJSZSearch_FSRQMin
                    Me.ddlSJSZSearch_SFDM.SelectedIndex = .ddlSJSZSearch_SFDM_SelectedIndex
                    Me.ddlSJSZSearch_SFBZ.SelectedIndex = .ddlSJSZSearch_SFBZ_SelectedIndex
                    Me.ddlSJSZSearch_SFDX.SelectedIndex = .ddlSJSZSearch_SFDX_SelectedIndex
                    Me.ddlSJSZSearch_SHBZ.SelectedIndex = .ddlSJSZSearch_SHBZ_SelectedIndex
                    Me.ddlSJSZSearch_SFSH.SelectedIndex = .ddlSJSZSearch_SFSH_SelectedIndex

                    Me.txtSJSZPageIndex.Text = .txtSJSZPageIndex
                    Me.txtSJSZPageSize.Text = .txtSJSZPageSize
                    Try
                        Me.grdSJSZ.PageSize = .grdSJSZPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSJSZ.CurrentPageIndex = .grdSJSZCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSJSZ.SelectedIndex = .grdSJSZSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtSJSZSessionIdQuery.Value = .htxtSJSZSessionIdQuery

                    Me.ddlSFDM.SelectedIndex = .ddlSFDM_SelectedIndex
                    Me.rblSFBZ.SelectedIndex = .rblSFBZ_SelectedIndex
                    Me.rblSFDX.SelectedIndex = .rblSFDX_SelectedIndex
                    Me.txtFSJE.Text = .txtFSJE

                    Me.txtJYBH.Text = .txtJYBH
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateCwSssfJz

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftSJSZ = Me.htxtDivLeftSJSZ.Value
                    .htxtDivTopSJSZ = Me.htxtDivTopSJSZ.Value

                    .htxtSJSZQuery = Me.htxtSJSZQuery.Value
                    .htxtSJSZRows = Me.htxtSJSZRows.Value
                    .htxtSJSZSort = Me.htxtSJSZSort.Value
                    .htxtSJSZSortColumnIndex = Me.htxtSJSZSortColumnIndex.Value
                    .htxtSJSZSortType = Me.htxtSJSZSortType.Value

                    .txtSJSZSearch_PJHM = Me.txtSJSZSearch_PJHM.Text
                    .txtSJSZSearch_FSRQMax = Me.txtSJSZSearch_FSRQMax.Text
                    .txtSJSZSearch_FSRQMin = Me.txtSJSZSearch_FSRQMin.Text
                    .ddlSJSZSearch_SFDM_SelectedIndex = Me.ddlSJSZSearch_SFDM.SelectedIndex
                    .ddlSJSZSearch_SFBZ_SelectedIndex = Me.ddlSJSZSearch_SFBZ.SelectedIndex
                    .ddlSJSZSearch_SFDX_SelectedIndex = Me.ddlSJSZSearch_SFDX.SelectedIndex
                    .ddlSJSZSearch_SHBZ_SelectedIndex = Me.ddlSJSZSearch_SHBZ.SelectedIndex
                    .ddlSJSZSearch_SFSH_SelectedIndex = Me.ddlSJSZSearch_SFSH.SelectedIndex

                    .txtSJSZPageIndex = Me.txtSJSZPageIndex.Text
                    .txtSJSZPageSize = Me.txtSJSZPageSize.Text
                    .grdSJSZPageSize = Me.grdSJSZ.PageSize
                    .grdSJSZCurrentPageIndex = Me.grdSJSZ.CurrentPageIndex
                    .grdSJSZSelectedIndex = Me.grdSJSZ.SelectedIndex
                    .htxtSJSZSessionIdQuery = Me.htxtSJSZSessionIdQuery.Value

                    .ddlSFDM_SelectedIndex = Me.ddlSFDM.SelectedIndex
                    .rblSFBZ_SelectedIndex = Me.rblSFBZ.SelectedIndex
                    .rblSFDX_SelectedIndex = Me.rblSFDX.SelectedIndex
                    .txtFSJE = Me.txtFSJE.Text

                    .txtJYBH = Me.txtJYBH.Text
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
                Dim objIEstateEsXzJyxx As Josco.JSOA.BusinessFacade.IEstateEsXzJyxx = Nothing
                Try
                    objIEstateEsXzJyxx = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsXzJyxx)
                Catch ex As Exception
                    objIEstateEsXzJyxx = Nothing
                End Try
                If Not (objIEstateEsXzJyxx Is Nothing) Then
                    If objIEstateEsXzJyxx.oExitMode = True Then
                        Select Case objIEstateEsXzJyxx.iSourceControlId.ToUpper
                            Case "btnSelect_JYBH".ToUpper
                                Me.txtJYBH.Text = objIEstateEsXzJyxx.oJYBH
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsXzJyxx.SafeRelease(objIEstateEsXzJyxx)
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
                        Select Case objISjcxCxtj.iSourceControlId.ToUpper
                            Case "btnSJSZSearch_Full".ToUpper()
                                Me.htxtSJSZQuery.Value = objISjcxCxtj.oQueryString
                                If Me.htxtSJSZSessionIdQuery.Value.Trim = "" Then
                                    Me.htxtSJSZSessionIdQuery.Value = objPulicParameters.getNewGuid()
                                Else
                                    Try
                                        objQueryData = CType(Session(Me.htxtSJSZSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                                    Catch ex As Exception
                                        objQueryData = Nothing
                                    End Try
                                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                                End If
                                Session.Add(Me.htxtSJSZSessionIdQuery.Value, objISjcxCxtj.oDataSetTJ)
                        End Select
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
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateCwSssfJz)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    'û���нӿڲ���
                    Me.m_strOrgQRSH = ""
                Else
                    Me.m_blnInterface = True
                    '�нӿڲ���
                    Me.m_strOrgQRSH = Me.m_objInterface.iQRSH
                End If
                If Me.m_strOrgQRSH <> "" Then
                    Dim blnIS As Boolean = False
                    If objsystemEstateErshou.isQrshExist(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strOrgQRSH, blnIS) = False Then
                        GoTo errProc
                    End If
                    If blnIS = False Then
                        Me.m_strOrgQRSH = ""
                    End If
                End If

                '��ȡ�ָ��ֳ�����
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateCwSssfJz)
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

                '�ӿ�+����ϲ�
                If Me.m_strOrgQRSH <> "" Then
                    Me.m_strQRSH = Me.m_strOrgQRSH
                Else
                    Me.m_strQRSH = Me.txtJYBH.Text
                End If

                Me.m_strQuery_SJSZ = Me.htxtSJSZQuery.Value
                Me.m_intRows_SJSZ = objPulicParameters.getObjectValue(Me.htxtSJSZRows.Value, 0)
                Me.m_intFixedColumns_SJSZ = objPulicParameters.getObjectValue(Me.htxtSJSZFixed.Value, 0)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getInterfaceParameters = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ͷű�ģ�黺��Ĳ���
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                If Me.htxtSJSZSessionIdQuery.Value.Trim <> "" Then
                    Try
                        objQueryData = CType(Session(Me.htxtSJSZSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSJSZSessionIdQuery.Value)
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
        Private Function getQueryString_SJSZ( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_SJSZ = False
            strQuery = ""

            Try
                '����Ʊ�ݺ��롱����
                Dim strPJHM As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_PJHM
                If Me.txtSJSZSearch_PJHM.Text.Length > 0 Then Me.txtSJSZSearch_PJHM.Text = Me.txtSJSZSearch_PJHM.Text.Trim()
                If Me.txtSJSZSearch_PJHM.Text <> "" Then
                    Me.txtSJSZSearch_PJHM.Text = objPulicParameters.getNewSearchString(Me.txtSJSZSearch_PJHM.Text)
                    If strQuery = "" Then
                        strQuery = strPJHM + " like '" + Me.txtSJSZSearch_PJHM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strPJHM + " like '" + Me.txtSJSZSearch_PJHM.Text + "%'"
                    End If
                End If

                '�������������
                Dim strSHBZ As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZMC
                Select Case Me.ddlSJSZSearch_SHBZ.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSHBZ + " = '" + Me.ddlSJSZSearch_SHBZ.SelectedItem.Text + "'"
                        Else
                            strQuery = strQuery + " and " + strSHBZ + " = '" + Me.ddlSJSZSearch_SHBZ.SelectedItem.Text + "'"
                        End If
                End Select

                '������Ч������
                Dim strSFSH As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFSH
                Select Case Me.ddlSJSZSearch_SFSH.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFSH + " = '" + Me.ddlSJSZSearch_SFSH.SelectedItem.Text + "'"
                        Else
                            strQuery = strQuery + " and " + strSFSH + " = '" + Me.ddlSJSZSearch_SFSH.SelectedItem.Text + "'"
                        End If
                End Select

                '����˰�Ѵ��롱����
                Dim strSFDM As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM
                Select Case Me.ddlSJSZSearch_SFDM.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFDM + " like '" + Me.ddlSJSZSearch_SFDM.SelectedValue + "%'"
                        Else
                            strQuery = strQuery + " and " + strSFDM + " like '" + Me.ddlSJSZSearch_SFDM.SelectedValue + "%'"
                        End If
                End Select

                '�����ո���־������
                Dim strSFBZ As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ
                Select Case Me.ddlSJSZSearch_SFBZ.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFBZ + " = '" + Me.ddlSJSZSearch_SFBZ.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strSFBZ + " = '" + Me.ddlSJSZSearch_SFBZ.SelectedValue + "'"
                        End If
                End Select

                '�����ո���������
                Dim strSFDX As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX
                Select Case Me.ddlSJSZSearch_SFDX.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFDX + " = '" + Me.ddlSJSZSearch_SFDX.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strSFDX + " = '" + Me.ddlSJSZSearch_SFDX.SelectedValue + "'"
                        End If
                End Select

                '�����������ڡ�����
                Dim strFSRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strFSRQ = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSRQ
                If Me.txtSJSZSearch_FSRQMin.Text.Length > 0 Then Me.txtSJSZSearch_FSRQMin.Text = Me.txtSJSZSearch_FSRQMin.Text.Trim()
                If Me.txtSJSZSearch_FSRQMax.Text.Length > 0 Then Me.txtSJSZSearch_FSRQMax.Text = Me.txtSJSZSearch_FSRQMax.Text.Trim()
                If Me.txtSJSZSearch_FSRQMin.Text <> "" And Me.txtSJSZSearch_FSRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtSJSZSearch_FSRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtSJSZSearch_FSRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtSJSZSearch_FSRQMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtSJSZSearch_FSRQMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtSJSZSearch_FSRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtSJSZSearch_FSRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strFSRQ + " between '" + Me.txtSJSZSearch_FSRQMin.Text + "' and '" + Me.txtSJSZSearch_FSRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strFSRQ + " between '" + Me.txtSJSZSearch_FSRQMin.Text + "' and '" + Me.txtSJSZSearch_FSRQMax.Text + "'"
                    End If
                ElseIf Me.txtSJSZSearch_FSRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtSJSZSearch_FSRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtSJSZSearch_FSRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strFSRQ + " >= '" + Me.txtSJSZSearch_FSRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strFSRQ + " >= '" + Me.txtSJSZSearch_FSRQMin.Text + "'"
                    End If
                ElseIf Me.txtSJSZSearch_FSRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtSJSZSearch_FSRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtSJSZSearch_FSRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strFSRQ + " <= '" + Me.txtSJSZSearch_FSRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strFSRQ + " <= '" + Me.txtSJSZSearch_FSRQMax.Text + "'"
                    End If
                Else
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_SJSZ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdSJSZҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     strWhere       �������ַ���
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_SJSZ( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu

            getModuleData_SJSZ = False

            Try
                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtSJSZSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(Me.m_objDataSet_SJSZ)

                '���¼�������
                If objsystemEstateCaiwu.getDataSet_ES_SSSF(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_SJSZ) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_SJSZ.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_SJSZ.Tables(strTable)
                    Me.htxtSJSZRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_SJSZ = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)

            getModuleData_SJSZ = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdSJSZ����
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_SJSZ( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            searchModuleData_SJSZ = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_SJSZ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_SJSZ(strErrMsg, strQRSH, strQuery) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_SJSZ = strQuery
                Me.htxtSJSZQuery.Value = Me.m_strQuery_SJSZ

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_SJSZ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdSJSZ������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_SJSZ( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_SJSZ = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtSJSZSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtSJSZSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_SJSZ Is Nothing Then
                    Me.grdSJSZ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_SJSZ.Tables(strTable)
                        Me.grdSJSZ.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_SJSZ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdSJSZ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdSJSZ)
                    With Me.grdSJSZ.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdSJSZ.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdSJSZ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_SJSZ) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_SJSZ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾ�༭��������(��������ǰ��������ʾ)
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showEditPanelInfo( _
            ByRef strErrMsg As String) As Boolean

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim strValue As String = ""

            showEditPanelInfo = False

            Try
                'If Me.IsPostBack = False And Me.m_blnSaveScence = True Then
                '    Exit Try
                'End If

                '�鿴״̬
                If Me.grdSJSZ.Items.Count < 1 Or Me.grdSJSZ.SelectedIndex < 0 Then
                    Me.ddlSFDM.SelectedIndex = -1
                    Me.rblSFDX.SelectedIndex = -1
                    Me.rblSFBZ.SelectedIndex = -1
                    Me.txtFSJE.Text = ""
                Else
                    Dim intColIndex As Integer = -1

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                    Me.ddlSFDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSFDM, strValue)

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                    Me.rblSFDX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFDX, strValue)

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                    Me.rblSFBZ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFBZ, strValue)

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(Me.grdSJSZ.SelectedIndex), intColIndex)
                    Me.txtFSJE.Text = objPulicParameters.getObjectValue(strValue, 0.0).ToString("#,###.00")
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanelInfo = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾSJSZ��ص�ȫ����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_SJSZ( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_SJSZ = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_SJSZ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_SJSZ.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblSJSZGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdSJSZ, .Count)

                    '��ʾҳ���������
                    Me.lnkCZSJSZMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdSJSZ, .Count)
                    Me.lnkCZSJSZMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdSJSZ, .Count)
                    Me.lnkCZSJSZMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdSJSZ, .Count)
                    Me.lnkCZSJSZMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdSJSZ, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZSJSZDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZSJSZSelectAll.Enabled = blnEnabled
                    Me.lnkCZSJSZGotoPage.Enabled = blnEnabled
                    Me.lnkCZSJSZSetPageSize.Enabled = blnEnabled
                End With

                'ͬ����ʾ
                If Me.showEditPanelInfo(strErrMsg) = False Then
                    GoTo errProc
                End If
                '��ʾ���ý�
                If Me.showBeiyongjin(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If

                '��ʾ��������
                Me.btnOK.Visible = Me.m_blnPrevilegeParams(1) And Me.m_strQRSH <> ""
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_SJSZ = True
            Exit Function

errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���˰�������б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        '     blnAddBlank    ����ӿհ���Ŀ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doFillSfdmList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_SHUIFEIMULU
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

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
                If blnAddBlank = True Then
                    objDropDownList.Items.Add("")
                End If

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
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillSfdmList = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾ���ý���Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showBeiyongjin( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu

            showBeiyongjin = False
            strErrMsg = ""

            Try
                '���㱸�ý�
                Dim dblValue() As Double = {0.0, 0.0}
                If strQRSH = "" Then
                    Me.txtBYJ_JF.Text = ""
                    Me.txtBYJ_YF.Text = ""
                    Me.txtBYJ_HT.Text = ""
                Else
                    If objsystemEstateCaiwu.getHetongBeiyongjin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, dblValue(0), dblValue(1)) = False Then
                        GoTo errProc
                    End If
                    Me.txtBYJ_JF.Text = dblValue(0).ToString("#,###.00")
                    Me.txtBYJ_YF.Text = dblValue(1).ToString("#,###.00")
                    Me.txtBYJ_HT.Text = (dblValue(0) + dblValue(1)).ToString("#,###.00")
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)

            showBeiyongjin = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾ��ͬ��Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showJiaoyiInfo( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objestateErshouData As Josco.JSOA.Common.Data.estateErshouData

            showJiaoyiInfo = False
            strErrMsg = ""

            Try
                '��ȡ��Ϣ
                If objsystemEstateErshou.getDataSet_ES_JYXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, "", objestateErshouData) = False Then
                    GoTo errProc
                End If

                '��ʼ����Ϣ
                Me.lblJYBH.Text = ""
                Me.lblJYRQ.Text = ""
                Me.lblJFMC.Text = ""
                Me.lblJYJG.Text = ""
                Me.lblHTBH.Text = ""
                Me.lblHTRQ.Text = ""
                Me.lblYFMC.Text = ""
                Me.lblJYMJ.Text = ""
                Me.lblWYDZ.Text = ""
                Me.lblJFDLF.Text = ""
                Me.lblYFDLF.Text = ""

                '��ʾ��Ϣ
                With objestateErshouData.Tables(strTable)
                    If .Rows.Count < 1 Then
                        Exit Try
                    End If
                    Me.lblJYBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH), "")
                    Me.lblJYRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYRQ), "", "yyyy-MM-dd")
                    Me.lblJFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_YZMC), "")
                    Me.lblJYJG.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYJG), 0.0).ToString("#,###.00")
                    Me.lblHTBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTBH), "")
                    Me.lblHTRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTRQ), "", "yyyy-MM-dd")
                    Me.lblYFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_KHMC), "")
                    Me.lblJYMJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYMJ), 0.0).ToString("#,###.00")
                    Me.lblWYDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_WYDZ), "")
                    Me.lblJFDLF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JFDLF), 0.0).ToString("#,###.00")
                    Me.lblYFDLF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_YFDLF), 0.0).ToString("#,###.00")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objestateErshouData)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)

            showJiaoyiInfo = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objestateErshouData)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
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
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtSJSZPageIndex)
                    objControlProcess.doTranslateKey(Me.txtSJSZPageSize)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtSJSZSearch_PJHM)
                    objControlProcess.doTranslateKey(Me.txtSJSZSearch_FSRQMin)
                    objControlProcess.doTranslateKey(Me.txtSJSZSearch_FSRQMax)
                    objControlProcess.doTranslateKey(Me.ddlSJSZSearch_SFDM)
                    objControlProcess.doTranslateKey(Me.ddlSJSZSearch_SFBZ)
                    objControlProcess.doTranslateKey(Me.ddlSJSZSearch_SFDX)
                    objControlProcess.doTranslateKey(Me.ddlSJSZSearch_SHBZ)
                    objControlProcess.doTranslateKey(Me.ddlSJSZSearch_SFSH)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtFSJE)
                    objControlProcess.doTranslateKey(Me.ddlSFDM)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtJYBH)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtBYJ_JF)
                    objControlProcess.doTranslateKey(Me.txtBYJ_YF)
                    objControlProcess.doTranslateKey(Me.txtBYJ_HT)

                    '��ʾ��������
                    If Me.showJiaoyiInfo(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If

                    '��ȡ����
                    If Me.m_blnSaveScence = False Then
                        If Me.searchModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
                            GoTo errProc
                        End If
                    Else
                        If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                            GoTo errProc
                        End If
                    End If
                    '��ʾ����
                    If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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

            '����б�
            If Me.IsPostBack = False Then
                If Me.doFillSfdmList(strErrMsg, Me.ddlSFDM, False) = False Then
                    GoTo errProc
                End If
                If Me.doFillSfdmList(strErrMsg, Me.ddlSJSZSearch_SFDM, True) = False Then
                    GoTo errProc
                End If
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
        Sub grdSJSZ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdSJSZ.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_SJSZ + ".scrollTop)")
                    Next
                End If

                If Me.m_intFixedColumns_SJSZ > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_SJSZ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdSJSZ.ID + "Locked"
                    Next
                End If

            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdSJSZ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSJSZ.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblSJSZGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdSJSZ, Me.m_intRows_SJSZ)
                'ͬ��
                If Me.showEditPanelInfo(strErrMsg) = False Then
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

        Private Sub grdSJSZ_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdSJSZ.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
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
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                With Me.m_objDataSet_SJSZ.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                With Me.m_objDataSet_SJSZ.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtSJSZSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtSJSZSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtSJSZSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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













        Private Sub doMoveFirst_SJSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdSJSZ.PageCount)
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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

        Private Sub doMoveLast_SJSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSJSZ.PageCount - 1, Me.grdSJSZ.PageCount)
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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

        Private Sub doMoveNext_SJSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSJSZ.CurrentPageIndex + 1, Me.grdSJSZ.PageCount)
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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

        Private Sub doMovePrevious_SJSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdSJSZ.CurrentPageIndex - 1, Me.grdSJSZ.PageCount)
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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

        Private Sub doGotoPage_SJSZ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtSJSZPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdSJSZ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtSJSZPageIndex.Text = (Me.grdSJSZ.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_SJSZ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtSJSZPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdSJSZ.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtSJSZPageSize.Text = (Me.grdSJSZ.PageSize).ToString()

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

        Private Sub doSelectAll_SJSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdSJSZ, 0, Me.m_cstrCheckBoxIdInDataGrid_SJSZ, True) = False Then
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

        Private Sub doDeSelectAll_SJSZ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdSJSZ, 0, Me.m_cstrCheckBoxIdInDataGrid_SJSZ, False) = False Then
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

        Private Sub doSearch_SJSZ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_SJSZ(strErrMsg, Me.m_strQRSH) = False Then
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

        Private Sub lnkCZSJSZMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZMoveFirst.Click
            Me.doMoveFirst_SJSZ("lnkCZSJSZMoveFirst")
        End Sub

        Private Sub lnkCZSJSZMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZMoveLast.Click
            Me.doMoveLast_SJSZ("lnkCZSJSZMoveLast")
        End Sub

        Private Sub lnkCZSJSZMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZMoveNext.Click
            Me.doMoveNext_SJSZ("lnkCZSJSZMoveNext")
        End Sub

        Private Sub lnkCZSJSZMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZMovePrev.Click
            Me.doMovePrevious_SJSZ("lnkCZSJSZMovePrev")
        End Sub

        Private Sub lnkCZSJSZGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZGotoPage.Click
            Me.doGotoPage_SJSZ("lnkCZSJSZGotoPage")
        End Sub

        Private Sub lnkCZSJSZSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZSetPageSize.Click
            Me.doSetPageSize_SJSZ("lnkCZSJSZSetPageSize")
        End Sub

        Private Sub lnkCZSJSZSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZSelectAll.Click
            Me.doSelectAll_SJSZ("lnkCZSJSZSelectAll")
        End Sub

        Private Sub lnkCZSJSZDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZSJSZDeSelectAll.Click
            Me.doDeSelectAll_SJSZ("lnkCZSJSZDeSelectAll")
        End Sub

        Private Sub btnSJSZSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSJSZSearch.Click
            Me.doSearch_SJSZ("btnSJSZSearch")
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

        Private Sub doSearch_Full_SJSZ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU

            Try
                '��ȡ����
                If Me.getModuleData_SJSZ(strErrMsg, Me.m_strQRSH, Me.m_strQuery_SJSZ) = False Then
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
                    If Me.htxtSJSZSessionIdQuery.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtSJSZSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_SJSZ.Tables(strTable)
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

        Private Sub doSelect_JYBH(ByVal strControlId As String)

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
                Dim objIEstateEsXzJyxx As Josco.JSOA.BusinessFacade.IEstateEsXzJyxx = Nothing
                Dim strUrl As String = ""
                objIEstateEsXzJyxx = New Josco.JSOA.BusinessFacade.IEstateEsXzJyxx
                With objIEstateEsXzJyxx
                    .iAllowNull = False
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
                Session.Add(strNewSessionId, objIEstateEsXzJyxx)

                strUrl = ""
                strUrl += "../ershou/estate_es_xz_jyxx.aspx"
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

        Private Sub doOK(ByVal strControlId As String)

            Dim objNewData As System.Collections.Specialized.NameValueCollection = Nothing
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 0

            Try
                Dim strValue As String = ""
                Dim strWYBS As String = ""
                intStep = 1
                '���
                If Me.grdSJSZ.SelectedIndex < 0 Then
                    strErrMsg = "����û�з��ÿɽ�ת��"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdSJSZ.SelectedIndex
                Dim intColIndex As Integer = 0
                If Me.ddlSFDM.SelectedIndex < 0 Then
                    strErrMsg = "����û��ָ��ת��ķ��ã�"
                    GoTo errProc
                End If
                If Me.rblSFBZ.SelectedIndex < 0 Then
                    strErrMsg = "����û��ָ��ת����ա�����"
                    GoTo errProc
                End If
                'zengxianglin 2008-12-04
                Dim strSFBZ As String = Me.rblSFBZ.SelectedItem.Value
                Select Case strSFBZ
                    Case Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_F
                        If Me.m_blnPrevilegeParams(3) = False Then
                            strErrMsg = "������û�и����Ȩ�ޣ�"
                            GoTo errProc
                        End If
                End Select
                'zengxianglin 2008-12-04
                If Me.rblSFDX.SelectedIndex < 0 Then
                    strErrMsg = "����û��ָ��ת��ļס��ң�"
                    GoTo errProc
                End If
                If Me.txtFSJE.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��ת��Ľ�"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtFSJE.Text) = False Then
                    strErrMsg = "������Ч��ת���"
                    GoTo errProc
                End If
                Dim dblFSJE As Double = 0
                dblFSJE = objPulicParameters.getObjectValue(Me.txtFSJE.Text, 0.0)
                If dblFSJE <= 0 Then
                    strErrMsg = "����ת�������>0��"
                    GoTo errProc
                End If
                'zengxianglin 2010-12-30
                Dim strSFDX_Old As String = ""
                Dim strSFBZ_Old As String = ""
                Dim strSFDM_Old As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX)
                strSFDX_Old = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex), "")
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ)
                strSFBZ_Old = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex), "")
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM)
                strSFDM_Old = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex), "")
                'zengxianglin 2010-12-30
                Dim dblYFSJE As Double = 0
                'zengxianglin 2010-12-30
                'intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE)
                'dblYFSJE = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex), 0.0)
                If objsystemEstateCaiwu.getBalance(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, strSFDM_Old, strSFDX_Old, dblYFSJE) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2010-12-30
                If dblFSJE > dblYFSJE Then
                    strErrMsg = "����ת����[" + dblFSJE.ToString("#,###.00") + "]����[" + dblYFSJE.ToString("#,###.00") + "]��"
                    GoTo errProc
                End If
                Dim strSFDM As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM)
                strSFDM = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex), "")
                If strSFDM = Me.ddlSFDM.SelectedValue Then
                    strErrMsg = "���󣺷���δ�����仯��"
                    GoTo errProc
                End If
                'zengxianglin 2010-12-30
                '���[�ո�����]����,��[�ո���־]���ܸı�!
                If Me.rblSFDX.SelectedValue.ToUpper = strSFDX_Old.ToUpper Then
                    If Me.rblSFBZ.SelectedValue.ToUpper <> strSFBZ_Old Then
                        strErrMsg = "����ͬһ�ͻ��Ŀ���[��]��[��]����ת����ֻ��ͨ�����ֳ��������ͨ����ת����"
                        GoTo errProc
                    End If
                End If
                If strSFBZ_Old = Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_F Then
                    strErrMsg = "����ֻ�ܶ��տ���н�ת����"
                    GoTo errProc
                End If
                'zengxianglin 2010-12-30

                'ȷ��
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "���棺һ��ȷ�Ͻ�ֻ��ͨ��[����]�����Ҫ��������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '�ش��ǡ�
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '׼������
                    objNewData = New System.Collections.Specialized.NameValueCollection
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS, strValue)
                    strWYBS = strValue
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSJSZ, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSJSZ.Items(i), intColIndex)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH, strValue)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM, Me.ddlSFDM.SelectedValue)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC, Me.ddlSFDM.SelectedItem.Text.Split("|".ToCharArray)(1))
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE, Me.txtFSJE.Text)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX, Me.rblSFDX.SelectedValue)
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ, Me.rblSFBZ.SelectedValue)

                    If Me.rblSFDX.SelectedValue.ToUpper = strSFDX_Old.ToUpper Then
                        'ͬһ�ͻ���ת�����������͸ı�
                        If objsystemEstateCaiwu.doJiezhuan_ES_SSSF(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData) = False Then
                            GoTo errProc
                        End If
                    Else
                        '��ͬ�ͻ����ת����
                        If Me.rblSFBZ.SelectedValue.ToUpper = strSFBZ_Old.ToUpper Then
                            '[��]��[��]���䣺��->��
                            If objsystemEstateCaiwu.doJiezhuan_ES_SSSF_TFX(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData) = False Then
                                GoTo errProc
                            End If
                        Else
                            '[��]��[��]�ı䣺��->��
                            If objsystemEstateCaiwu.doJiezhuan_ES_SSSF_BTFX(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData) = False Then
                                GoTo errProc
                            End If
                        End If
                    End If

                    '��¼�����־
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_ʵ��ʵ��]�ж�[" + strWYBS + "]ִ����[��ת]��")

                    '����
                    Dim strSessionId As String = ""
                    Dim strUrl As String = ""
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
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnSJSZSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSJSZSearch_Full.Click
            Me.doSearch_Full_SJSZ("btnSJSZSearch_Full")
        End Sub

        Private Sub btnSelect_JYBH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_JYBH.Click
            Me.doSelect_JYBH("btnSelect_JYBH")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace

