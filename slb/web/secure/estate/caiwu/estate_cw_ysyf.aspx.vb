Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_cw_ysyf
    ' 
    ' �������ʣ�
    '     I/O
    '
    ' ���������� 
    '   ��һ�㡰�ո���ƻ�������ģ��
    '----------------------------------------------------------------

    Partial Class estate_cw_ysyf
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
        Private m_cstrPrevilegeParamPrefix As String = "estate_cw_ysyf_previlege_param"
        Private m_blnPrevilegeParams(1) As Boolean

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateCwYsyf
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateCwYsyf
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdYSYFJH��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid As String = "chkYSYFJH"
        Private Const m_cstrDataGridInDIV As String = "divYSYFJH"
        Private m_intFixedColumns_YSYFJH As Integer

        '----------------------------------------------------------------
        '��ǰ��������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet_YSYFJH As Josco.JSOA.Common.Data.estateCaiwuData
        Private m_strQuery_YSYFJH As String
        Private m_intRows_YSYFJH As Integer

        '----------------------------------------------------------------
        '����ģ��˽�ò���
        '----------------------------------------------------------------
        Private m_objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_blnEditMode As Boolean
        Private m_intCurrentPageIndex As Integer
        Private m_intCurrentSelectIndex As Integer
        Private m_strFixQuery As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFZT + " = 1"

        '----------------------------------------------------------------
        '�ӿڲ���
        '----------------------------------------------------------------
        Private m_blnCanModify As Boolean
        Private m_strQRSH As String

        Public ReadOnly Property propEditMode() As Boolean
            Get
                propEditMode = Me.m_blnEditMode
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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateCwYsyf)
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
                    Me.htxtDivLeftYSYFJH.Value = .htxtDivLeftYSYFJH
                    Me.htxtDivTopYSYFJH.Value = .htxtDivTopYSYFJH

                    Me.htxtCurrentPage.Value = .htxtCurrentPage
                    Me.htxtCurrentRow.Value = .htxtCurrentRow
                    Me.htxtEditMode.Value = .htxtEditMode
                    Me.htxtEditType.Value = .htxtEditType

                    Me.htxtYSYFJHQuery.Value = .htxtYSYFJHQuery
                    Me.htxtYSYFJHRows.Value = .htxtYSYFJHRows
                    Me.htxtYSYFJHSort.Value = .htxtYSYFJHSort
                    Me.htxtYSYFJHSortColumnIndex.Value = .htxtYSYFJHSortColumnIndex
                    Me.htxtYSYFJHSortType.Value = .htxtYSYFJHSortType

                    Me.ddlFKFS.SelectedIndex = .ddlFKFS_SelectedIndex
                    Me.chkQCXY.Checked = .chkQCXY_Checked

                    Me.ddlSFDM.SelectedIndex = .ddlSFDM_SelectedIndex
                    Me.rblSFBZ.SelectedIndex = .rblSFBZ_SelectedIndex
                    Me.rblSFDX.SelectedIndex = .rblSFDX_SelectedIndex
                    Me.txtQTMS.Text = .txtQTMS
                    Me.txtYSJE.Text = .txtYSJE
                    Me.txtYSRQ.Text = .txtYSRQ
                    Me.htxtSFZT.Value = .htxtSFZT
                    Me.htxtWYBS.Value = .htxtWYBS
                    Me.htxtQRSH.Value = .htxtQRSH

                    Me.txtYSYFJHSearch_YSRQMax.Text = .txtYSYFJHSearch_YSRQMax
                    Me.txtYSYFJHSearch_YSRQMin.Text = .txtYSYFJHSearch_YSRQMin
                    Me.ddlYSYFJHSearch_SFDM.SelectedIndex = .ddlYSYFJHSearch_SFDM_SelectedIndex
                    Me.ddlYSYFJHSearch_SFBZ.SelectedIndex = .ddlYSYFJHSearch_SFBZ_SelectedIndex
                    Me.ddlYSYFJHSearch_SFDX.SelectedIndex = .ddlYSYFJHSearch_SFDX_SelectedIndex

                    Me.txtYSYFJHPageIndex.Text = .txtYSYFJHPageIndex
                    Me.txtYSYFJHPageSize.Text = .txtYSYFJHPageSize

                    Try
                        Me.grdYSYFJH.PageSize = .grdYSYFJHPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYSYFJH.CurrentPageIndex = .grdYSYFJHCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYSYFJH.SelectedIndex = .grdYSYFJHSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateCwYsyf

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftYSYFJH = Me.htxtDivLeftYSYFJH.Value
                    .htxtDivTopYSYFJH = Me.htxtDivTopYSYFJH.Value

                    .htxtCurrentPage = Me.htxtCurrentPage.Value
                    .htxtCurrentRow = Me.htxtCurrentRow.Value
                    .htxtEditMode = Me.htxtEditMode.Value
                    .htxtEditType = Me.htxtEditType.Value

                    .htxtYSYFJHQuery = Me.htxtYSYFJHQuery.Value
                    .htxtYSYFJHRows = Me.htxtYSYFJHRows.Value
                    .htxtYSYFJHSort = Me.htxtYSYFJHSort.Value
                    .htxtYSYFJHSortColumnIndex = Me.htxtYSYFJHSortColumnIndex.Value
                    .htxtYSYFJHSortType = Me.htxtYSYFJHSortType.Value

                    .ddlFKFS_SelectedIndex = Me.ddlFKFS.SelectedIndex
                    .chkQCXY_Checked = Me.chkQCXY.Checked

                    .ddlSFDM_SelectedIndex = Me.ddlSFDM.SelectedIndex
                    .rblSFBZ_SelectedIndex = Me.rblSFBZ.SelectedIndex
                    .rblSFDX_SelectedIndex = Me.rblSFDX.SelectedIndex
                    .txtQTMS = Me.txtQTMS.Text
                    .txtYSJE = Me.txtYSJE.Text
                    .txtYSRQ = Me.txtYSRQ.Text
                    .htxtSFZT = Me.htxtSFZT.Value
                    .htxtWYBS = Me.htxtWYBS.Value
                    .htxtQRSH = Me.htxtQRSH.Value

                    .txtYSYFJHSearch_YSRQMax = Me.txtYSYFJHSearch_YSRQMax.Text
                    .txtYSYFJHSearch_YSRQMin = Me.txtYSYFJHSearch_YSRQMin.Text
                    .ddlYSYFJHSearch_SFDM_SelectedIndex = Me.ddlYSYFJHSearch_SFDM.SelectedIndex
                    .ddlYSYFJHSearch_SFBZ_SelectedIndex = Me.ddlYSYFJHSearch_SFBZ.SelectedIndex
                    .ddlYSYFJHSearch_SFDX_SelectedIndex = Me.ddlYSYFJHSearch_SFDX.SelectedIndex

                    .txtYSYFJHPageIndex = Me.txtYSYFJHPageIndex.Text
                    .txtYSYFJHPageSize = Me.txtYSYFJHPageSize.Text

                    .grdYSYFJHPageSize = Me.grdYSYFJH.PageSize
                    .grdYSYFJHCurrentPageIndex = Me.grdYSYFJH.CurrentPageIndex
                    .grdYSYFJHSelectedIndex = Me.grdYSYFJH.SelectedIndex
                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value
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
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
                Try
                    objISjcxCxtj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.ISjcxCxtj)
                Catch ex As Exception
                    objISjcxCxtj = Nothing
                End Try
                If Not (objISjcxCxtj Is Nothing) Then
                    If objISjcxCxtj.oExitMode = True Then
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                        Me.htxtYSYFJHQuery.Value = objISjcxCxtj.oQueryString
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
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateCwYsyf)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    'û���нӿڲ���
                    Me.m_strQRSH = ""
                    Me.m_blnCanModify = False
                Else
                    Me.m_blnInterface = True
                    '�нӿڲ���
                    Me.m_blnCanModify = Me.m_objInterface.iCanModify
                    Me.m_strQRSH = Me.m_objInterface.iQRSH
                End If
                Dim blnIS As Boolean = False
                If objsystemEstateErshou.isQrshExist(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, blnIS) = False Then
                    GoTo errProc
                End If
                If blnIS = False Then
                    blnContinue = False
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = "����û���ṩ��ģ����Ҫ����Ϣ��ȷ���鲻���ڣ�"
                    Exit Try
                End If

                '��ȡ�ָ��ֳ�����
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateCwYsyf)
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

                '�Ƿ��ڱ༭״̬
                Me.m_blnEditMode = objPulicParameters.getObjectValue(Me.htxtEditMode.Value, False)
                '����༭ģʽǰ��¼��ҳλ��
                Me.m_intCurrentPageIndex = objPulicParameters.getObjectValue(Me.htxtCurrentPage.Value, 0)
                '����༭ģʽǰ��¼����λ��
                Me.m_intCurrentSelectIndex = objPulicParameters.getObjectValue(Me.htxtCurrentRow.Value, -1)
                '��ǰ�༭ģʽ
                Dim intEditType As Integer
                intEditType = objPulicParameters.getObjectValue(Me.htxtEditType.Value, 0)
                Try
                    Me.m_objenumEditType = CType(intEditType, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType)
                Catch ex As Exception
                    Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                End Try

                Me.m_strQuery_YSYFJH = Me.htxtYSYFJHQuery.Value
                Me.m_intRows_YSYFJH = objPulicParameters.getObjectValue(Me.htxtYSYFJHRows.Value, 0)
                Me.m_intFixedColumns_YSYFJH = objPulicParameters.getObjectValue(Me.htxtYSYFJHFixed.Value, 0)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getInterfaceParameters = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
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
        Private Function getQueryString_YSYFJH( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_YSYFJH = False
            strQuery = ""

            Try
                '����˰�Ѵ��롱����
                Dim strSFDM As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDM
                Select Case Me.ddlYSYFJHSearch_SFDM.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFDM + " like '" + Me.ddlYSYFJHSearch_SFDM.SelectedValue + "%'"
                        Else
                            strQuery = strQuery + " and " + strSFDM + " like '" + Me.ddlYSYFJHSearch_SFDM.SelectedValue + "%'"
                        End If
                End Select

                '�����ո���־������
                Dim strSFBZ As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFBZ
                Select Case Me.ddlYSYFJHSearch_SFBZ.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFBZ + " = '" + Me.ddlYSYFJHSearch_SFBZ.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strSFBZ + " = '" + Me.ddlYSYFJHSearch_SFBZ.SelectedValue + "'"
                        End If
                End Select

                '�����ո���������
                Dim strSFDX As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDX
                Select Case Me.ddlYSYFJHSearch_SFDX.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strSFDX + " = '" + Me.ddlYSYFJHSearch_SFDX.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strSFDX + " = '" + Me.ddlYSYFJHSearch_SFDX.SelectedValue + "'"
                        End If
                End Select

                '����Ӧ�����ڡ�����
                Dim strYSRQ As String
                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime
                strYSRQ = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSRQ
                If Me.txtYSYFJHSearch_YSRQMin.Text.Length > 0 Then Me.txtYSYFJHSearch_YSRQMin.Text = Me.txtYSYFJHSearch_YSRQMin.Text.Trim()
                If Me.txtYSYFJHSearch_YSRQMax.Text.Length > 0 Then Me.txtYSYFJHSearch_YSRQMax.Text = Me.txtYSYFJHSearch_YSRQMax.Text.Trim()
                If Me.txtYSYFJHSearch_YSRQMin.Text <> "" And Me.txtYSYFJHSearch_YSRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtYSYFJHSearch_YSRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtYSYFJHSearch_YSRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtYSYFJHSearch_YSRQMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtYSYFJHSearch_YSRQMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtYSYFJHSearch_YSRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtYSYFJHSearch_YSRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strYSRQ + " between '" + Me.txtYSYFJHSearch_YSRQMin.Text + "' and '" + Me.txtYSYFJHSearch_YSRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strYSRQ + " between '" + Me.txtYSYFJHSearch_YSRQMin.Text + "' and '" + Me.txtYSYFJHSearch_YSRQMax.Text + "'"
                    End If
                ElseIf Me.txtYSYFJHSearch_YSRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtYSYFJHSearch_YSRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtYSYFJHSearch_YSRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strYSRQ + " >= '" + Me.txtYSYFJHSearch_YSRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strYSRQ + " >= '" + Me.txtYSYFJHSearch_YSRQMin.Text + "'"
                    End If
                ElseIf Me.txtYSYFJHSearch_YSRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtYSYFJHSearch_YSRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtYSYFJHSearch_YSRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strYSRQ + " <= '" + Me.txtYSYFJHSearch_YSRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strYSRQ + " <= '" + Me.txtYSYFJHSearch_YSRQMax.Text + "'"
                    End If
                Else
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_YSYFJH = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdYSYFJHҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     strWhere       �������ַ���
        '     blnEditMode    ����ǰ�༭״̬
        '     objenumEditType����ϸ����ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_YSYFJH( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_YINGSHOUYINGFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu

            getModuleData_YSYFJH = False

            Try
                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtYSYFJHSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(Me.m_objDataSet_YSYFJH)

                'Ĭ��������һ��ƻ�
                If strWhere = "" Then
                    strWhere = Me.m_strFixQuery
                Else
                    strWhere = strWhere + " and " + Me.m_strFixQuery
                End If

                '���¼�������
                If objsystemEstateCaiwu.getDataSet_ES_YSYF(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_YSYFJH) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_YSYFJH.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                If blnEditMode = False Then '�鿴ģʽ
                    With Me.m_objDataSet_YSYFJH.Tables(strTable)
                        .DefaultView.AllowNew = False
                    End With
                Else '�༭ģʽ
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            '����1���ռ�¼
                            With Me.m_objDataSet_YSYFJH.Tables(strTable)
                                .DefaultView.AllowNew = True
                                .DefaultView.AddNew()
                            End With
                        Case Else
                            With Me.m_objDataSet_YSYFJH.Tables(strTable)
                                .DefaultView.AllowNew = False
                            End With
                    End Select
                End If

                '�������
                With Me.m_objDataSet_YSYFJH.Tables(strTable)
                    Me.htxtYSYFJHRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_YSYFJH = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)

            getModuleData_YSYFJH = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdYSYFJH����
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     blnEditMode    ����ǰ�༭״̬
        '     objenumEditType����ϸ����ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_YSYFJH( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            searchModuleData_YSYFJH = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_YSYFJH(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_YSYFJH(strErrMsg, strQRSH, strQuery, blnEditMode, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_YSYFJH = strQuery
                Me.htxtYSYFJHQuery.Value = Me.m_strQuery_YSYFJH

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_YSYFJH = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdYSYFJH������
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_YINGSHOUYINGFU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtYSYFJHSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtYSYFJHSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_YSYFJH Is Nothing Then
                    Me.grdYSYFJH.DataSource = Nothing
                Else
                    With Me.m_objDataSet_YSYFJH.Tables(strTable)
                        Me.grdYSYFJH.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_YSYFJH.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdYSYFJH, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '����Ǳ༭ģʽ
                If blnEditMode = True Then
                    '�ƶ�������¼
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            With Me.m_objDataSet_YSYFJH.Tables(strTable)
                                Dim intPageIndex As Integer
                                Dim intSelectIndex As Integer
                                If objDataGridProcess.doMoveToRecord(Me.grdYSYFJH.AllowPaging, Me.grdYSYFJH.PageSize, .DefaultView.Count - 1, intPageIndex, intSelectIndex) = False Then
                                    strErrMsg = "�����޷��ƶ������"
                                    GoTo errProc
                                End If
                                Try
                                    Me.grdYSYFJH.CurrentPageIndex = intPageIndex
                                    Me.grdYSYFJH.SelectedIndex = intSelectIndex
                                Catch ex As Exception
                                End Try
                            End With
                        Case Else
                    End Select
                End If

                '����������
                Me.grdYSYFJH.AllowSorting = Not blnEditMode

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdYSYFJH)
                    With Me.grdYSYFJH.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdYSYFJH.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdYSYFJH, Request, 0, Me.m_cstrCheckBoxIdInDataGrid) = False Then
                    GoTo errProc
                End If

                '����Ǳ༭ģʽ
                If blnEditMode = True Then
                    'ʹ������
                    If objDataGridProcess.doEnabledDataGrid(strErrMsg, Me.grdYSYFJH, Not blnEditMode) = False Then
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
        '     strQRSH        ��ȷ�����
        '     blnEditMode    ����ǰ�༭״̬
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showEditPanelInfo( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim strValue As String = ""

            showEditPanelInfo = False

            Try
                If blnEditMode = False Then
                    '�鿴״̬
                    If Me.grdYSYFJH.Items.Count < 1 Or Me.grdYSYFJH.SelectedIndex < 0 Then
                        Me.ddlSFDM.SelectedIndex = -1
                        Me.rblSFDX.SelectedIndex = -1
                        Me.rblSFBZ.SelectedIndex = -1
                        Me.htxtWYBS.Value = ""
                        Me.htxtQRSH.Value = ""
                        Me.htxtSFZT.Value = "1"
                        Me.txtQTMS.Text = ""
                        Me.txtYSJE.Text = ""
                        Me.txtYSRQ.Text = ""
                    Else
                        Dim intColIndex As Integer = -1

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdYSYFJH, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDM)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdYSYFJH.Items(Me.grdYSYFJH.SelectedIndex), intColIndex)
                        Me.ddlSFDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSFDM, strValue)

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdYSYFJH, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDX)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdYSYFJH.Items(Me.grdYSYFJH.SelectedIndex), intColIndex)
                        Me.rblSFDX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFDX, strValue)

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdYSYFJH, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFBZ)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdYSYFJH.Items(Me.grdYSYFJH.SelectedIndex), intColIndex)
                        Me.rblSFBZ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFBZ, strValue)

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdYSYFJH, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdYSYFJH.Items(Me.grdYSYFJH.SelectedIndex), intColIndex)
                        Me.htxtWYBS.Value = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdYSYFJH, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QRSH)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdYSYFJH.Items(Me.grdYSYFJH.SelectedIndex), intColIndex)
                        Me.htxtQRSH.Value = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdYSYFJH, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFZT)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdYSYFJH.Items(Me.grdYSYFJH.SelectedIndex), intColIndex)
                        Me.htxtSFZT.Value = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdYSYFJH, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdYSYFJH.Items(Me.grdYSYFJH.SelectedIndex), intColIndex)
                        Me.txtYSJE.Text = objPulicParameters.getObjectValue(strValue, 0.0).ToString("#,###.00")

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdYSYFJH, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSRQ)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdYSYFJH.Items(Me.grdYSYFJH.SelectedIndex), intColIndex)
                        Me.txtYSRQ.Text = objPulicParameters.getObjectValue(strValue, "", "yyyy-MM-dd")

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdYSYFJH, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QTMS)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdYSYFJH.Items(Me.grdYSYFJH.SelectedIndex), intColIndex)
                        Me.txtQTMS.Text = strValue
                    End If
                Else
                    '�༭״̬
                    '�Զ��ָ�����
                End If

                'ʹ�ܿؼ�
                objControlProcess.doEnabledControl(Me.ddlFKFS, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.chkQCXY, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.btnMakeJH, Not blnEditMode)

                objControlProcess.doEnabledControl(Me.ddlSFDM, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSFBZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSFDX, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtQTMS, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYSJE, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYSRQ, blnEditMode)
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
        ' ��ʾ����ģ�����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strRYDM        ����Ա����
        '     blnEditMode    ����ǰ�༭״̬
        '     objenumEditType����ϸ����ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData( _
            ByRef strErrMsg As String, _
            ByVal strRYDM As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_YINGSHOUYINGFU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo(strErrMsg, blnEditMode, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_YSYFJH.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblYSYFJHGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdYSYFJH, .Count)

                    '��ʾҳ���������
                    Me.lnkCZYSYFJHMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdYSYFJH, .Count) And (Not blnEditMode)
                    Me.lnkCZYSYFJHMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdYSYFJH, .Count) And (Not blnEditMode)
                    Me.lnkCZYSYFJHMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdYSYFJH, .Count) And (Not blnEditMode)
                    Me.lnkCZYSYFJHMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdYSYFJH, .Count) And (Not blnEditMode)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZYSYFJHDeSelectAll.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZYSYFJHSelectAll.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZYSYFJHGotoPage.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZYSYFJHSetPageSize.Enabled = blnEnabled And (Not blnEditMode)

                    objControlProcess.doEnabledControl(Me.txtYSYFJHPageSize, Not blnEditMode)
                    objControlProcess.doEnabledControl(Me.txtYSYFJHPageIndex, Not blnEditMode)

                    objControlProcess.doEnabledControl(Me.txtYSYFJHSearch_YSRQMax, Not blnEditMode)
                    objControlProcess.doEnabledControl(Me.txtYSYFJHSearch_YSRQMin, Not blnEditMode)
                    objControlProcess.doEnabledControl(Me.ddlYSYFJHSearch_SFDM, Not blnEditMode)
                    objControlProcess.doEnabledControl(Me.ddlYSYFJHSearch_SFBZ, Not blnEditMode)
                    objControlProcess.doEnabledControl(Me.ddlYSYFJHSearch_SFDX, Not blnEditMode)

                    Me.btnYSYFJHSearch.Enabled = Not blnEditMode
                    Me.btnYSYFJHSearch_Full.Enabled = Not blnEditMode
                End With

                '��ʾ���봰��Ϣ
                If Me.showEditPanelInfo(strErrMsg, strRYDM, blnEditMode) = False Then
                    GoTo errProc
                End If

                '��ʾ��������
                Me.btnAddNew.Visible = (Not blnEditMode) And Me.m_blnPrevilegeParams(1) And Me.m_blnCanModify
                Me.btnUpdate.Visible = (Not blnEditMode) And Me.m_blnPrevilegeParams(1) And Me.m_blnCanModify
                Me.btnDelete.Visible = (Not blnEditMode) And Me.m_blnPrevilegeParams(1) And Me.m_blnCanModify
                Me.btnMakeJH.Visible = (Not blnEditMode) And Me.m_blnPrevilegeParams(1) And Me.m_blnCanModify
                Me.btnPrint.Visible = (Not blnEditMode)
                Me.btnClose.Enabled = (Not blnEditMode)

                Me.btnSave.Visible = blnEditMode
                Me.btnCancel.Visible = blnEditMode

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
        ' ��丶�ʽ�����б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        '     blnAddBlank    ����ӿհ���Ŀ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doFillFkfsList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillFkfsList = False
            strErrMsg = ""

            Try
                '���
                If objDropDownList Is Nothing Then
                    strErrMsg = "����[doFillFkfsList]�ӿڲ�������ȷ��"
                    GoTo errProc
                End If

                '��ȡ����
                'Dim strWhere As String = "a." + Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMX + " <> 1"
                Dim strWhere As String = ""
                If objsystemEstateCommon.getDataSet_YingshouYingfuMoban(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateCommonData) = False Then
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
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBMC), "")

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

            doFillFkfsList = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objestateCommonData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
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

                    '���ʼ���ʽ
                    If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                        Me.ddlFKFS.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlFKFS, objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_FKFS), ""))
                    End If
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
                    objControlProcess.doTranslateKey(Me.txtYSYFJHPageIndex)
                    objControlProcess.doTranslateKey(Me.txtYSYFJHPageSize)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtYSYFJHSearch_YSRQMin)
                    objControlProcess.doTranslateKey(Me.txtYSYFJHSearch_YSRQMax)
                    objControlProcess.doTranslateKey(Me.ddlYSYFJHSearch_SFDM)
                    objControlProcess.doTranslateKey(Me.ddlYSYFJHSearch_SFBZ)
                    objControlProcess.doTranslateKey(Me.ddlYSYFJHSearch_SFDX)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtQTMS)
                    objControlProcess.doTranslateKey(Me.txtYSJE)
                    objControlProcess.doTranslateKey(Me.txtYSRQ)
                    objControlProcess.doTranslateKey(Me.ddlSFDM)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.ddlFKFS)

                    '��ʾ��������
                    If Me.showJiaoyiInfo(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If

                    '��ȡ����
                    If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                    '��ʾ����
                    If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
                If Me.doFillFkfsList(strErrMsg, Me.ddlFKFS, False) = False Then
                    GoTo errProc
                End If
                If Me.doFillSfdmList(strErrMsg, Me.ddlSFDM, False) = False Then
                    GoTo errProc
                End If
                If Me.doFillSfdmList(strErrMsg, Me.ddlYSYFJHSearch_SFDM, True) = False Then
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
        'ʵ�ֶ������С��еĹ̶�
        Sub grdYSYFJH_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdYSYFJH.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV + ".scrollTop)")
                    Next
                End If

                If Me.m_intFixedColumns_YSYFJH > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_YSYFJH - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdYSYFJH.ID + "Locked"
                    Next
                End If

            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdYSYFJH_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdYSYFJH.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblYSYFJHGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdYSYFJH, Me.m_intRows_YSYFJH)
                'ͬ����ʾ�༭����Ϣ
                If Me.showEditPanelInfo(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode) = False Then
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

        Private Sub grdYSYFJH_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdYSYFJH.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_YINGSHOUYINGFU
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
                If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                With Me.m_objDataSet_YSYFJH.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                With Me.m_objDataSet_YSYFJH.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtYSYFJHSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtYSYFJHSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtYSYFJHSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
                If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdYSYFJH.PageCount)
                Me.grdYSYFJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
                If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdYSYFJH.PageCount - 1, Me.grdYSYFJH.PageCount)
                Me.grdYSYFJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
                If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdYSYFJH.CurrentPageIndex + 1, Me.grdYSYFJH.PageCount)
                Me.grdYSYFJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
                If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdYSYFJH.CurrentPageIndex - 1, Me.grdYSYFJH.PageCount)
                Me.grdYSYFJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
            intPageIndex = objPulicParameters.getObjectValue(Me.txtYSYFJHPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdYSYFJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtYSYFJHPageIndex.Text = (Me.grdYSYFJH.CurrentPageIndex + 1).ToString()

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
            intPageSize = objPulicParameters.getObjectValue(Me.txtYSYFJHPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdYSYFJH.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtYSYFJHPageSize.Text = (Me.grdYSYFJH.PageSize).ToString()

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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdYSYFJH, 0, Me.m_cstrCheckBoxIdInDataGrid, True) = False Then
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdYSYFJH, 0, Me.m_cstrCheckBoxIdInDataGrid, False) = False Then
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
                If Me.searchModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub lnkCZYSYFJHMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYSYFJHMoveFirst.Click
            Me.doMoveFirst("lnkCZYSYFJHMoveFirst")
        End Sub

        Private Sub lnkCZYSYFJHMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYSYFJHMoveLast.Click
            Me.doMoveLast("lnkCZYSYFJHMoveLast")
        End Sub

        Private Sub lnkCZYSYFJHMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYSYFJHMoveNext.Click
            Me.doMoveNext("lnkCZYSYFJHMoveNext")
        End Sub

        Private Sub lnkCZYSYFJHMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYSYFJHMovePrev.Click
            Me.doMovePrevious("lnkCZYSYFJHMovePrev")
        End Sub

        Private Sub lnkCZYSYFJHGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYSYFJHGotoPage.Click
            Me.doGotoPage("lnkCZYSYFJHGotoPage")
        End Sub

        Private Sub lnkCZYSYFJHSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYSYFJHSetPageSize.Click
            Me.doSetPageSize("lnkCZYSYFJHSetPageSize")
        End Sub

        Private Sub lnkCZYSYFJHSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYSYFJHSelectAll.Click
            Me.doSelectAll("lnkCZYSYFJHSelectAll")
        End Sub

        Private Sub lnkCZYSYFJHDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZYSYFJHDeSelectAll.Click
            Me.doDeSelectAll("lnkCZYSYFJHDeSelectAll")
        End Sub

        Private Sub btnYSYFJHSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYSYFJHSearch.Click
            Me.doSearch("btnYSYFJHSearch")
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
                Me.m_intCurrentPageIndex = Me.grdYSYFJH.CurrentPageIndex
                Me.m_intCurrentSelectIndex = Me.grdYSYFJH.SelectedIndex

                '���������Ϣ
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()
                Me.htxtEditType.Value = CType(Me.m_objenumEditType, Integer).ToString()
                Me.htxtCurrentPage.Value = Me.m_intCurrentPageIndex.ToString()
                Me.htxtCurrentRow.Value = Me.m_intCurrentSelectIndex.ToString()

                '����༭״̬
                If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ʾ��Ϣ
                If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
                '���
                If Me.grdYSYFJH.Items.Count < 1 Then
                    strErrMsg = "����û�����ݿ��޸ģ�"
                    GoTo errProc
                End If

                '���ñ༭ģʽ
                Me.m_blnEditMode = True
                Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                Me.m_intCurrentPageIndex = Me.grdYSYFJH.CurrentPageIndex
                Me.m_intCurrentSelectIndex = Me.grdYSYFJH.SelectedIndex

                '���������Ϣ
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()
                Me.htxtEditType.Value = CType(Me.m_objenumEditType, Integer).ToString()
                Me.htxtCurrentPage.Value = Me.m_intCurrentPageIndex.ToString()
                Me.htxtCurrentRow.Value = Me.m_intCurrentSelectIndex.ToString()

                '����༭״̬
                If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ʾ��Ϣ
                If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_YINGSHOUYINGFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ȡ����Ϣ
                Dim objNewData As New System.Collections.Specialized.NameValueCollection
                '***************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS, Me.htxtWYBS.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QRSH, Me.htxtQRSH.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFZT, Me.htxtSFZT.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSRQ, Me.txtYSRQ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE, Me.txtYSJE.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QTMS, Me.txtQTMS.Text)
                '***************************************************************************************************************
                '�����治���������
                objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_KSRQ, "")
                objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JSRQ, "")
                objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JZYF, "0")
                objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JZQJ, "")

                '***************************************************************************************************************
                If Me.ddlSFDM.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDM, Me.ddlSFDM.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDM, "")
                End If

                '***************************************************************************************************************
                If Me.rblSFDX.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDX, Me.rblSFDX.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDX, "")
                End If

                '***************************************************************************************************************
                If Me.rblSFBZ.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFBZ, Me.rblSFBZ.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFBZ, "")
                End If

                '��ȡ����Ϣ
                Dim objOldData As System.Data.DataRow = Nothing
                Dim intPos As Integer = 0
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        objOldData = Nothing
                        objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS) = ""
                        objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QRSH) = Me.m_strQRSH
                        objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFZT) = "1"
                    Case Else
                        '��ȡ����
                        If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                            GoTo errProc
                        End If
                        intPos = objDataGridProcess.getRecordPosition(Me.grdYSYFJH.SelectedIndex, Me.grdYSYFJH.CurrentPageIndex, Me.grdYSYFJH.PageSize)
                        With Me.m_objDataSet_YSYFJH.Tables(strTable)
                            objOldData = .DefaultView.Item(intPos).Row
                        End With
                End Select

                '������Ϣ
                If objsystemEstateCaiwu.doSaveData_ES_YSYF(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData, objNewData, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��¼�����־
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_Ӧ��Ӧ��]�����������ݣ�")
                    Case Else
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]������[����_Ӧ��Ӧ��]�е����ݣ�")
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
                If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ʾ��Ϣ
                If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
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
                        Me.grdYSYFJH.CurrentPageIndex = Me.m_intCurrentPageIndex
                        Me.grdYSYFJH.SelectedIndex = Me.m_intCurrentSelectIndex
                    Catch ex As Exception
                    End Try

                    '����Ǳ༭״̬
                    If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If

                    '��ʾ��Ϣ
                    If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_YINGSHOUYINGFU
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
                intRows = Me.grdYSYFJH.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdYSYFJH.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid) = True Then
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
                    Dim intColIndex As Integer = 0
                    Dim strWYBS As String = ""
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdYSYFJH, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdYSYFJH.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid) = True Then
                            '��ȡ��Ϣ
                            strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdYSYFJH.Items(i), intColIndex)

                            'ɾ������
                            If objsystemEstateCaiwu.doDeleteData_ES_YSYF(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS) = False Then
                                GoTo errProc
                            End If

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]ɾ����[����_Ӧ��Ӧ��]�е�[" + strWYBS + "]��")
                        End If
                    Next

                    '���»�ȡ����
                    If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If

                    'ˢ��������ʾ
                    If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doMakeJH(ByVal strControlId As String)

            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                '���
                If Me.ddlFKFS.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[���ʽ]��"
                    GoTo errProc
                End If

                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    If Me.chkQCXY.Checked = True Then
                        objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ��Ҫ������мƻ���������/�񣩣�", strControlId, intStep)
                        Exit Try
                    End If
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��ʾ��Ϣ
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷʵ��Ϣ׼ȷ��Ҫ������������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��ʾ��ش��ǡ����Ŵ���
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '����
                    If objsystemEstateCaiwu.doMakeYSYF(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, Me.ddlFKFS.SelectedValue, Me.chkQCXY.Checked) = False Then
                        GoTo errProc
                    End If

                    '������ʾ
                    If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                End If
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

        Private Sub doSearchFull(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_YINGSHOUYINGFU

            Try
                '��ȡ����
                If Me.getModuleData_YSYFJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_YSYFJH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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
                    .iQueryTable = Me.m_objDataSet_YSYFJH.Tables(strTable)
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

        Private Sub btnYSYFJHSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYSYFJHSearch_Full.Click
            Me.doSearchFull("btnYSYFJHSearch_Full")
        End Sub

        Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
            Me.doAddNew("btnAddNew")
        End Sub

        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Me.doUpdate("btnUpdate")
        End Sub

        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Me.doDelete("btnDelete")
        End Sub

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Me.doSave("btnSave")
        End Sub

        Private Sub btnMakeJH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMakeJH.Click
            Me.doMakeJH("btnMakeJH")
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace

