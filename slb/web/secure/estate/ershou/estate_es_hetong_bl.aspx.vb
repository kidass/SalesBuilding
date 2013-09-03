Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_es_hetong_bl
    ' 
    ' �������ʣ�
    '     I/O
    '
    ' ���������� 
    '   ������ͬ�참������ģ��
    '----------------------------------------------------------------

    Partial Class estate_es_hetong_bl
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
        Private m_cstrPrevilegeParamPrefix As String = "estate_es_hetong_previlege_param"
        Private m_blnPrevilegeParams(15) As Boolean

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsHetongBl
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsHetongBl
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdBAJH��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_BAJH As String = "chkBAJH"
        Private Const m_cstrDataGridInDIV_BAJH As String = "divBAJH"
        Private m_intFixedColumns_BAJH As Integer
        Private Const m_cstrControlInDataGrid_BAJH_chkJH_TX As String = "chkJH_TX"
        Private Const m_cstrControlInDataGrid_BAJH_txtJH_JHKS As String = "txtJH_JHKS"
        Private Const m_cstrControlInDataGrid_BAJH_txtJH_JHJS As String = "txtJH_JHJS"
        Private Const m_cstrControlInDataGrid_BAJH_txtJH_JBRY As String = "txtJH_JBRY"
        Private Const m_cstrControlInDataGrid_BAJH_htxtJH_JBRY As String = "htxtJH_JBRY"
        Private Const m_cstrControlInDataGrid_BAJH_btnJH_SelectJBRY As String = "btnJH_SelectJBRY"
        Private Const m_cstrControlInDataGrid_BAJH_txtJH_JBDW As String = "txtJH_JBDW"
        Private Const m_cstrControlInDataGrid_BAJH_htxtJH_JBDW As String = "htxtJH_JBDW"
        Private Const m_cstrControlInDataGrid_BAJH_btnJH_SelectJBDW As String = "btnJH_SelectJBDW"
        Private Const m_cstrControlInDataGrid_BAJH_txtJH_GZNR As String = "txtJH_GZNR"
        Private Const m_cstrControlInDataGrid_BAJH_btnJH_SelectRow As String = "btnJH_SelectRow"

        '----------------------------------------------------------------
        '����������grdBLJL��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_BLJL As String = "chkBLJL"
        Private Const m_cstrDataGridInDIV_BLJL As String = "divBLJL"
        Private m_intFixedColumns_BLJL As Integer

        '----------------------------------------------------------------
        '��ǰ��������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet_BAJH As Josco.JSOA.Common.Data.estateErshouData
        Private m_strQuery_BAJH As String
        Private m_intRows_BAJH As Integer
        Private m_objDataSet_BLJL As Josco.JSOA.Common.Data.estateErshouData
        Private m_strQuery_BLJL As String
        Private m_intRows_BLJL As Integer

        '----------------------------------------------------------------
        '����ģ��˽�ò���
        '----------------------------------------------------------------
        Private m_objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_intCurrentSelectIndex As Integer
        Private m_intCurrentPageIndex As Integer
        Private m_blnEditMode As Boolean
        Private m_blnComplete As Boolean
        Private m_blnEnforced As Boolean

        '----------------------------------------------------------------
        '�ӿڲ���
        '----------------------------------------------------------------
        Private m_strOrgQRSH As String
        Private m_strQRSH As String

        Public ReadOnly Property propOrgQRSH() As String
            Get
                propOrgQRSH = Me.m_strOrgQRSH
            End Get
        End Property

        Public ReadOnly Property propQRSH() As String
            Get
                propQRSH = Me.m_strQRSH
            End Get
        End Property

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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsHetongBl)
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
                    Me.htxtDivLeftBAJH.Value = .htxtDivLeftBAJH
                    Me.htxtDivTopBAJH.Value = .htxtDivTopBAJH
                    Me.htxtDivLeftBLJL.Value = .htxtDivLeftBLJL
                    Me.htxtDivTopBLJL.Value = .htxtDivTopBLJL

                    Me.htxtCurrentPage.Value = .htxtCurrentPage
                    Me.htxtCurrentRow.Value = .htxtCurrentRow
                    Me.htxtEditMode.Value = .htxtEditMode
                    Me.htxtEditType.Value = .htxtEditType

                    Me.htxtBAJHQuery.Value = .htxtBAJHQuery
                    Me.htxtBAJHRows.Value = .htxtBAJHRows
                    Me.htxtBAJHSort.Value = .htxtBAJHSort
                    Me.htxtBAJHSortColumnIndex.Value = .htxtBAJHSortColumnIndex
                    Me.htxtBAJHSortType.Value = .htxtBAJHSortType

                    Me.htxtBLJLQuery.Value = .htxtBLJLQuery
                    Me.htxtBLJLRows.Value = .htxtBLJLRows
                    Me.htxtBLJLSort.Value = .htxtBLJLSort
                    Me.htxtBLJLSortColumnIndex.Value = .htxtBLJLSortColumnIndex
                    Me.htxtBLJLSortType.Value = .htxtBLJLSortType

                    Me.ddlBAJHSearch_TXBZ.SelectedIndex = .ddlBAJHSearch_TXBZ_SelectedIndex
                    Me.txtBAJHSearch_JHKSMax.Text = .txtBAJHSearch_JHKSMax
                    Me.txtBAJHSearch_JHKSMin.Text = .txtBAJHSearch_JHKSMin
                    Me.txtBAJHSearch_JHJSMax.Text = .txtBAJHSearch_JHJSMax
                    Me.txtBAJHSearch_JHJSMin.Text = .txtBAJHSearch_JHJSMin
                    Me.txtBAJHSearch_JBRY.Text = .txtBAJHSearch_JBRY
                    Me.txtBAJHSearch_JBDW.Text = .txtBAJHSearch_JBDW
                    Me.txtBAJHSearch_GZNR.Text = .txtBAJHSearch_GZNR

                    Me.txtBAJHPageIndex.Text = .txtBAJHPageIndex
                    Me.txtBAJHPageSize.Text = .txtBAJHPageSize
                    Try
                        Me.grdBAJH.PageSize = .grdBAJHPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdBAJH.CurrentPageIndex = .grdBAJHCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdBAJH.SelectedIndex = .grdBAJHSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtBAJHSessionIdQuery.Value = .htxtBAJHSessionIdQuery

                    Try
                        Me.grdBLJL.PageSize = .grdBLJLPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdBLJL.CurrentPageIndex = .grdBLJLCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdBLJL.SelectedIndex = .grdBLJLSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtBLJLSessionIdQuery.Value = .htxtBLJLSessionIdQuery

                    Me.htxtSJ_WYBS.Value = .htxtSJ_WYBS
                    Me.htxtSJ_QRSH.Value = .htxtSJ_QRSH
                    Me.htxtSJ_JHBS.Value = .htxtSJ_JHBS
                    Me.htxtSJ_JBRY.Value = .htxtSJ_JBRY
                    Me.htxtSJ_JBDW.Value = .htxtSJ_JBDW
                    Me.txtSJ_JBRY.Text = .txtSJ_JBRY
                    Me.txtSJ_JBDW.Text = .txtSJ_JBDW
                    Me.txtSJ_BLRQ.Text = .txtSJ_BLRQ
                    Me.txtSJ_BLQK.Text = .txtSJ_BLQK

                    Me.txtJYBH.Text = .txtJYBH

                    Me.rblJH_TX.SelectedIndex = .rblJH_TX_SelectedIndex
                    Me.txtJH_BWTS.Text = .txtJH_BWTS
                    Me.txtJH_KBTS.Text = .txtJH_KBTS

                    Me.htxtSessionIdBAJH.Value = .htxtSessionIdBAJH
                    Me.htxtRowNoBAJH.Value = .htxtRowNoBAJH
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsHetongBl

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftBAJH = Me.htxtDivLeftBAJH.Value
                    .htxtDivTopBAJH = Me.htxtDivTopBAJH.Value
                    .htxtDivLeftBLJL = Me.htxtDivLeftBLJL.Value
                    .htxtDivTopBLJL = Me.htxtDivTopBLJL.Value

                    .htxtCurrentPage = Me.htxtCurrentPage.Value
                    .htxtCurrentRow = Me.htxtCurrentRow.Value
                    .htxtEditMode = Me.htxtEditMode.Value
                    .htxtEditType = Me.htxtEditType.Value

                    .htxtBAJHQuery = Me.htxtBAJHQuery.Value
                    .htxtBAJHRows = Me.htxtBAJHRows.Value
                    .htxtBAJHSort = Me.htxtBAJHSort.Value
                    .htxtBAJHSortColumnIndex = Me.htxtBAJHSortColumnIndex.Value
                    .htxtBAJHSortType = Me.htxtBAJHSortType.Value

                    .htxtBLJLQuery = Me.htxtBLJLQuery.Value
                    .htxtBLJLRows = Me.htxtBLJLRows.Value
                    .htxtBLJLSort = Me.htxtBLJLSort.Value
                    .htxtBLJLSortColumnIndex = Me.htxtBLJLSortColumnIndex.Value
                    .htxtBLJLSortType = Me.htxtBLJLSortType.Value

                    .ddlBAJHSearch_TXBZ_SelectedIndex = Me.ddlBAJHSearch_TXBZ.SelectedIndex
                    .txtBAJHSearch_JHKSMax = Me.txtBAJHSearch_JHKSMax.Text
                    .txtBAJHSearch_JHKSMin = Me.txtBAJHSearch_JHKSMin.Text
                    .txtBAJHSearch_JHJSMax = Me.txtBAJHSearch_JHJSMax.Text
                    .txtBAJHSearch_JHJSMin = Me.txtBAJHSearch_JHJSMin.Text
                    .txtBAJHSearch_JBRY = Me.txtBAJHSearch_JBRY.Text
                    .txtBAJHSearch_JBDW = Me.txtBAJHSearch_JBDW.Text
                    .txtBAJHSearch_GZNR = Me.txtBAJHSearch_GZNR.Text

                    .txtBAJHPageIndex = Me.txtBAJHPageIndex.Text
                    .txtBAJHPageSize = Me.txtBAJHPageSize.Text
                    .grdBAJHPageSize = Me.grdBAJH.PageSize
                    .grdBAJHCurrentPageIndex = Me.grdBAJH.CurrentPageIndex
                    .grdBAJHSelectedIndex = Me.grdBAJH.SelectedIndex
                    .htxtBAJHSessionIdQuery = Me.htxtBAJHSessionIdQuery.Value

                    .htxtSJ_WYBS = Me.htxtSJ_WYBS.Value
                    .htxtSJ_QRSH = Me.htxtSJ_QRSH.Value
                    .htxtSJ_JHBS = Me.htxtSJ_JHBS.Value
                    .htxtSJ_JBRY = Me.htxtSJ_JBRY.Value
                    .htxtSJ_JBDW = Me.htxtSJ_JBDW.Value
                    .txtSJ_JBRY = Me.txtSJ_JBRY.Text
                    .txtSJ_JBDW = Me.txtSJ_JBDW.Text
                    .txtSJ_BLRQ = Me.txtSJ_BLRQ.Text
                    .txtSJ_BLQK = Me.txtSJ_BLQK.Text

                    .txtJYBH = Me.txtJYBH.Text

                    .rblJH_TX_SelectedIndex = Me.rblJH_TX.SelectedIndex
                    .txtJH_BWTS = Me.txtJH_BWTS.Text
                    .txtJH_KBTS = Me.txtJH_KBTS.Text

                    .htxtSessionIdBAJH = Me.htxtSessionIdBAJH.Value
                    .htxtRowNoBAJH = Me.htxtRowNoBAJH.Value
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
                Dim objIDmxzJbdm As Josco.JsKernal.BusinessFacade.IDmxzJbdm = Nothing
                Try
                    objIDmxzJbdm = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzJbdm)
                Catch ex As Exception
                    objIDmxzJbdm = Nothing
                End Try
                If Not (objIDmxzJbdm Is Nothing) Then
                    If objIDmxzJbdm.oExitMode = True Then
                        Select Case objIDmxzJbdm.iSourceControlId.ToUpper
                            Case "btnAddNew_JH".ToUpper
                                '���뵽���ݼ���
                                If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, False) = True Then
                                    Dim objDataRow As System.Data.DataRow = Nothing
                                    Dim strXMMC As String = ""
                                    Dim intCount As Integer
                                    Dim i As Integer
                                    intCount = objIDmxzJbdm.oDataSet.Tables(0).DefaultView.Count
                                    For i = 0 To intCount - 1 Step 1
                                        With objIDmxzJbdm.oDataSet.Tables(0).DefaultView
                                            strXMMC = objPulicParameters.getObjectValue(.Item(i).Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_BAXM_XMMC), "")
                                        End With
                                        With Me.m_objDataSet_BAJH.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANANJIHUA)
                                            objDataRow = .NewRow()
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_GZNR) = strXMMC
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_TXBZ) = 1
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_TXBZMC) = objPulicParameters.CharTrue
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_KBTS) = 1
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_BWTS) = 1
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBRY) = MyBase.UserId
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBRYMC) = MyBase.UserXM
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDW) = MyBase.UserBmdm
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDWMC) = MyBase.UserBmmc
                                            .Rows.Add(objDataRow)
                                        End With
                                    Next
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzJbdm.SafeRelease(objIDmxzJbdm)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsXzHtxx As Josco.JSOA.BusinessFacade.IEstateEsXzHtxx = Nothing
                Try
                    objIEstateEsXzHtxx = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsXzHtxx)
                Catch ex As Exception
                    objIEstateEsXzHtxx = Nothing
                End Try
                If Not (objIEstateEsXzHtxx Is Nothing) Then
                    If objIEstateEsXzHtxx.oExitMode = True Then
                        Select Case objIEstateEsXzHtxx.iSourceControlId.ToUpper
                            Case "btnSelect_JYBH".ToUpper
                                Me.txtJYBH.Text = objIEstateEsXzHtxx.oJYBH
                                'ǿ��ˢ������
                                Me.m_blnEnforced = True
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsXzHtxx.SafeRelease(objIEstateEsXzHtxx)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIDmxzZzjg As Josco.JsKernal.BusinessFacade.IDmxzZzjg = Nothing
                Try
                    objIDmxzZzjg = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzZzjg)
                Catch ex As Exception
                    objIDmxzZzjg = Nothing
                End Try
                If Not (objIDmxzZzjg Is Nothing) Then
                    If objIDmxzZzjg.oExitMode = True Then
                        Select Case objIDmxzZzjg.iSourceControlId.ToUpper
                            Case "btnSelect_SJ_JBDW".ToUpper
                                Me.txtSJ_JBDW.Text = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtSJ_JBDW.Text, Me.htxtSJ_JBDW.Value) = False Then
                                    Me.htxtSJ_JBDW.Value = ""
                                End If
                            Case "btnJH_SelectJBDW".ToUpper
                                If Me.htxtRowNoBAJH.Value.Trim <> "" Then
                                    If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, False) = True Then
                                        Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANANJIHUA
                                        Try
                                            Dim intRecPos As Integer = CType(Me.htxtRowNoBAJH.Value, Integer)
                                            Dim strZZMC As String = objIDmxzZzjg.oBumenList
                                            Dim strZZDM As String = ""
                                            If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                                With Me.m_objDataSet_BAJH.Tables(strTable).DefaultView
                                                    .Item(intRecPos).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDW) = strZZDM
                                                    .Item(intRecPos).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDWMC) = strZZMC
                                                End With
                                            End If
                                        Catch ex As Exception
                                        End Try
                                    End If
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzZzjg.SafeRelease(objIDmxzZzjg)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIDmxzRyxx As Josco.JsKernal.BusinessFacade.IDmxzRyxx = Nothing
                Try
                    objIDmxzRyxx = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzRyxx)
                Catch ex As Exception
                    objIDmxzRyxx = Nothing
                End Try
                If Not (objIDmxzRyxx Is Nothing) Then
                    If objIDmxzRyxx.oExitMode = True Then
                        Select Case objIDmxzRyxx.iSourceControlId.ToUpper
                            Case "btnSelect_SJ_JBRY".ToUpper
                                Me.htxtSJ_JBRY.Value = objIDmxzRyxx.oRYDM
                                Me.txtSJ_JBRY.Text = objIDmxzRyxx.oRYZM
                                Me.htxtSJ_JBDW.Value = objIDmxzRyxx.oZZDM
                                Me.txtSJ_JBDW.Text = objIDmxzRyxx.oZZMC
                            Case "btnJH_SelectJBRY".ToUpper
                                If Me.htxtRowNoBAJH.Value.Trim <> "" Then
                                    If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, False) = True Then
                                        Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANANJIHUA
                                        Try
                                            Dim intRecPos As Integer = CType(Me.htxtRowNoBAJH.Value, Integer)
                                            With Me.m_objDataSet_BAJH.Tables(strTable).DefaultView
                                                .Item(intRecPos).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBRY) = objIDmxzRyxx.oRYDM
                                                .Item(intRecPos).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBRYMC) = objIDmxzRyxx.oRYMC
                                                .Item(intRecPos).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDW) = objIDmxzRyxx.oZZDM
                                                .Item(intRecPos).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDWMC) = objIDmxzRyxx.oZZMC
                                            End With
                                        Catch ex As Exception
                                        End Try
                                    End If
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzRyxx.SafeRelease(objIDmxzRyxx)
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
                            Case "btnBAJHSearch_Full".ToUpper()
                                Me.htxtBAJHQuery.Value = objISjcxCxtj.oQueryString
                                If Me.htxtBAJHSessionIdQuery.Value.Trim = "" Then
                                    Me.htxtBAJHSessionIdQuery.Value = objPulicParameters.getNewGuid()
                                Else
                                    Try
                                        objQueryData = CType(Session(Me.htxtBAJHSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                                    Catch ex As Exception
                                        objQueryData = Nothing
                                    End Try
                                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                                End If
                                Session.Add(Me.htxtBAJHSessionIdQuery.Value, objISjcxCxtj.oDataSetTJ)
                                'ǿ��ˢ������
                                Me.m_blnEnforced = True
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsHetongBl)
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
                Dim blnIS As Boolean = False
                If Me.m_strOrgQRSH <> "" Then
                    If objsystemEstateErshou.isQrshExist(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strOrgQRSH, blnIS) = False Then
                        GoTo errProc
                    End If
                    If blnIS = False Then
                        Me.m_strOrgQRSH = ""
                    End If
                End If
                '��ǲ�ǿ��ˢ������
                Me.m_blnEnforced = False

                '��ȡ�ָ��ֳ�����
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsHetongBl)
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

                '�Ƿ����
                If Me.m_strQRSH <> "" Then
                    If objsystemEstateErshou.isHetongComplete(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, blnIS) = False Then
                        blnIS = True
                    End If
                Else
                    blnIS = True
                End If
                Me.m_blnComplete = blnIS

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

                Me.m_strQuery_BAJH = Me.htxtBAJHQuery.Value
                Me.m_intRows_BAJH = objPulicParameters.getObjectValue(Me.htxtBAJHRows.Value, 0)
                Me.m_intFixedColumns_BAJH = objPulicParameters.getObjectValue(Me.htxtBAJHFixed.Value, 0)

                Me.m_strQuery_BLJL = Me.htxtBLJLQuery.Value
                Me.m_intRows_BLJL = objPulicParameters.getObjectValue(Me.htxtBLJLRows.Value, 0)
                Me.m_intFixedColumns_BLJL = objPulicParameters.getObjectValue(Me.htxtBLJLFixed.Value, 0)
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
                If Me.htxtBAJHSessionIdQuery.Value.Trim <> "" Then
                    Try
                        objQueryData = CType(Session(Me.htxtBAJHSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtBAJHSessionIdQuery.Value)
                End If
                If Me.htxtBLJLSessionIdQuery.Value.Trim <> "" Then
                    Try
                        objQueryData = CType(Session(Me.htxtBLJLSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtBLJLSessionIdQuery.Value)
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
        Private Function getQueryString_BAJH( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_BAJH = False
            strQuery = ""

            Try
                '����������Ա������
                Dim strJBRY As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBRYMC
                If Me.txtBAJHSearch_JBRY.Text.Length > 0 Then Me.txtBAJHSearch_JBRY.Text = Me.txtBAJHSearch_JBRY.Text.Trim()
                If Me.txtBAJHSearch_JBRY.Text <> "" Then
                    Me.txtBAJHSearch_JBRY.Text = objPulicParameters.getNewSearchString(Me.txtBAJHSearch_JBRY.Text)
                    If strQuery = "" Then
                        strQuery = strJBRY + " like '" + Me.txtBAJHSearch_JBRY.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJBRY + " like '" + Me.txtBAJHSearch_JBRY.Text + "%'"
                    End If
                End If

                '�������쵥λ������
                Dim strJBDW As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDWMC
                If Me.txtBAJHSearch_JBDW.Text.Length > 0 Then Me.txtBAJHSearch_JBDW.Text = Me.txtBAJHSearch_JBDW.Text.Trim()
                If Me.txtBAJHSearch_JBDW.Text <> "" Then
                    Me.txtBAJHSearch_JBDW.Text = objPulicParameters.getNewSearchString(Me.txtBAJHSearch_JBDW.Text)
                    If strQuery = "" Then
                        strQuery = strJBDW + " like '" + Me.txtBAJHSearch_JBDW.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJBDW + " like '" + Me.txtBAJHSearch_JBDW.Text + "%'"
                    End If
                End If

                '�����������ݡ�����
                Dim strGZNR As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_GZNR
                If Me.txtBAJHSearch_GZNR.Text.Length > 0 Then Me.txtBAJHSearch_GZNR.Text = Me.txtBAJHSearch_GZNR.Text.Trim()
                If Me.txtBAJHSearch_GZNR.Text <> "" Then
                    Me.txtBAJHSearch_GZNR.Text = objPulicParameters.getNewSearchString(Me.txtBAJHSearch_GZNR.Text)
                    If strQuery = "" Then
                        strQuery = strGZNR + " like '" + Me.txtBAJHSearch_GZNR.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strGZNR + " like '" + Me.txtBAJHSearch_GZNR.Text + "%'"
                    End If
                End If

                '�������ѱ�־������
                Dim strTXBZ As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_TXBZ
                Select Case Me.ddlBAJHSearch_TXBZ.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strTXBZ + " = " + Me.ddlBAJHSearch_TXBZ.SelectedValue
                        Else
                            strQuery = strQuery + " and " + strTXBZ + " = " + Me.ddlBAJHSearch_TXBZ.SelectedValue
                        End If
                End Select

                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime

                '�����ƻ���ʼ������
                Dim strJHKS As String
                strJHKS = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JHKS
                If Me.txtBAJHSearch_JHKSMin.Text.Length > 0 Then Me.txtBAJHSearch_JHKSMin.Text = Me.txtBAJHSearch_JHKSMin.Text.Trim()
                If Me.txtBAJHSearch_JHKSMax.Text.Length > 0 Then Me.txtBAJHSearch_JHKSMax.Text = Me.txtBAJHSearch_JHKSMax.Text.Trim()
                If Me.txtBAJHSearch_JHKSMin.Text <> "" And Me.txtBAJHSearch_JHKSMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtBAJHSearch_JHKSMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtBAJHSearch_JHKSMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtBAJHSearch_JHKSMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtBAJHSearch_JHKSMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtBAJHSearch_JHKSMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtBAJHSearch_JHKSMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strJHKS + " between '" + Me.txtBAJHSearch_JHKSMin.Text + "' and '" + Me.txtBAJHSearch_JHKSMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJHKS + " between '" + Me.txtBAJHSearch_JHKSMin.Text + "' and '" + Me.txtBAJHSearch_JHKSMax.Text + "'"
                    End If
                ElseIf Me.txtBAJHSearch_JHKSMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtBAJHSearch_JHKSMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtBAJHSearch_JHKSMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strJHKS + " >= '" + Me.txtBAJHSearch_JHKSMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJHKS + " >= '" + Me.txtBAJHSearch_JHKSMin.Text + "'"
                    End If
                ElseIf Me.txtBAJHSearch_JHKSMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtBAJHSearch_JHKSMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtBAJHSearch_JHKSMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strJHKS + " <= '" + Me.txtBAJHSearch_JHKSMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJHKS + " <= '" + Me.txtBAJHSearch_JHKSMax.Text + "'"
                    End If
                Else
                End If

                '�����ƻ�����������
                Dim strJHJS As String
                strJHJS = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JHJS
                If Me.txtBAJHSearch_JHJSMin.Text.Length > 0 Then Me.txtBAJHSearch_JHJSMin.Text = Me.txtBAJHSearch_JHJSMin.Text.Trim()
                If Me.txtBAJHSearch_JHJSMax.Text.Length > 0 Then Me.txtBAJHSearch_JHJSMax.Text = Me.txtBAJHSearch_JHJSMax.Text.Trim()
                If Me.txtBAJHSearch_JHJSMin.Text <> "" And Me.txtBAJHSearch_JHJSMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtBAJHSearch_JHJSMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtBAJHSearch_JHJSMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtBAJHSearch_JHJSMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtBAJHSearch_JHJSMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtBAJHSearch_JHJSMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtBAJHSearch_JHJSMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strJHJS + " between '" + Me.txtBAJHSearch_JHJSMin.Text + "' and '" + Me.txtBAJHSearch_JHJSMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJHJS + " between '" + Me.txtBAJHSearch_JHJSMin.Text + "' and '" + Me.txtBAJHSearch_JHJSMax.Text + "'"
                    End If
                ElseIf Me.txtBAJHSearch_JHJSMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtBAJHSearch_JHJSMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtBAJHSearch_JHJSMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strJHJS + " >= '" + Me.txtBAJHSearch_JHJSMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJHJS + " >= '" + Me.txtBAJHSearch_JHJSMin.Text + "'"
                    End If
                ElseIf Me.txtBAJHSearch_JHJSMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtBAJHSearch_JHJSMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtBAJHSearch_JHJSMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strJHJS + " <= '" + Me.txtBAJHSearch_JHJSMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJHJS + " <= '" + Me.txtBAJHSearch_JHJSMax.Text + "'"
                    End If
                Else
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_BAJH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdBAJHҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     strWhere       �������ַ���
        '     blnEnforced    ��ǿ��ˢ������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByVal blnEnforced As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANANJIHUA
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_BAJH = False

            Try
                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtBAJHSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                'ǿ��ˢ�����ݣ�
                If blnEnforced = True Then
                    If Me.htxtSessionIdBAJH.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_BAJH = CType(Session(Me.htxtSessionIdBAJH.Value), Josco.JSOA.Common.Data.estateErshouData)
                        Catch ex As Exception
                            Me.m_objDataSet_BAJH = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_BAJH)
                        Session.Remove(Me.htxtSessionIdBAJH.Value)
                        Me.htxtSessionIdBAJH.Value = ""
                    End If
                End If

                '�ӻ����ȡ����
                If Me.htxtSessionIdBAJH.Value.Trim <> "" Then
                    Try
                        Me.m_objDataSet_BAJH = CType(Session(Me.htxtSessionIdBAJH.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        Me.m_objDataSet_BAJH = Nothing
                    End Try
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_BAJH)
                    '���¼�������
                    If objsystemEstateErshou.getDataSet_ES_HETONG_BAJH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_BAJH) = False Then
                        GoTo errProc
                    End If
                    '��������
                    Me.htxtSessionIdBAJH.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionIdBAJH.Value, Me.m_objDataSet_BAJH)
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_BAJH.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_BAJH.Tables(strTable)
                    Me.htxtBAJHRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_BAJH = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_BAJH = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����grdBAJH�ĵ�ǰ�л�ȡJHBS
        '     strErrMsg      �����ش�����Ϣ
        '     strJHBS        ���ƻ���ʶ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getJHBS( _
            ByRef strErrMsg As String, _
            ByRef strJHBS As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getJHBS = False
            strErrMsg = ""
            strJHBS = ""

            Try
                If Me.grdBAJH.SelectedIndex >= 0 Then
                    Dim i As Integer = Me.grdBAJH.SelectedIndex
                    Dim intColIndex As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBAJH, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_WYBS)
                    strJHBS = objDataGridProcess.getDataGridCellValue(Me.grdBAJH.Items(i), intColIndex)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getJHBS = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdBLJLҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     strWhere       �������ַ���
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_BLJL( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANLIJILU
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_BLJL = False

            Try
                '��ȡ���ƻ���ʶ��
                Dim strJHBS As String = ""
                If Me.getJHBS(strErrMsg, strJHBS) = False Then
                    GoTo errProc
                End If

                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtBLJLSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_BLJL)

                '���¼�������
                If objsystemEstateErshou.getDataSet_ES_HETONG_BLJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strJHBS, strWhere, Me.m_objDataSet_BLJL) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_BLJL.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_BLJL.Tables(strTable)
                    Me.htxtBLJLRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_BLJL = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_BLJL = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdBAJH����
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     blnEnforced    ��ǿ�����¼�������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal blnEnforced As Boolean) As Boolean

            searchModuleData_BAJH = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_BAJH(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_BAJH(strErrMsg, strQRSH, strQuery, blnEnforced) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_BAJH = strQuery
                Me.htxtBAJHQuery.Value = Me.m_strQuery_BAJH
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_BAJH = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����grdBAJH�еķǰ����ݵ����ݼ�
        '     strErrMsg      �����ش�����Ϣ
        '     blnCheck       �����������Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_BAJH( _
            ByRef strErrMsg As String, _
            ByVal blnCheck As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANANJIHUA
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_BAJH = False
            strErrMsg = ""

            Try
                '��ʾδ������
                Dim objHidden As System.Web.UI.HtmlControls.HtmlInputHidden = Nothing
                Dim objCheckBox As System.Web.UI.WebControls.CheckBox = Nothing
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdBAJH.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdBAJH.CurrentPageIndex, Me.grdBAJH.PageSize)
                    objDataRow = Me.m_objDataSet_BAJH.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���chkJH_TX
                    objCheckBox = Nothing
                    objCheckBox = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_chkJH_TX), System.Web.UI.WebControls.CheckBox)
                    If Not (objCheckBox Is Nothing) Then
                        If blnCheck = True Then
                            '�����
                        End If
                        If objCheckBox.Checked = True Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_TXBZ) = 1
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_TXBZMC) = objPulicParameters.CharTrue
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_TXBZ) = 0
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_TXBZMC) = objPulicParameters.CharFalse
                        End If
                    End If

                    '���txtJH_JHKS
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_txtJH_JHKS), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            If objTextBox.Text.Trim = "" Then
                                strErrMsg = "����û������[��ʼ����]��"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(objTextBox.Text) = False Then
                                strErrMsg = "����[" + objTextBox.Text + "]����Ч�����ڣ�"
                                GoTo errProc
                            End If
                        End If
                        If objPulicParameters.isDatetimeString(objTextBox.Text) = True Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JHKS) = CType(objTextBox.Text, System.DateTime)
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JHKS) = System.DBNull.Value
                        End If
                    End If

                    '���txtJH_JHJS
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_txtJH_JHJS), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            If objTextBox.Text.Trim = "" Then
                                strErrMsg = "����û������[��������]��"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(objTextBox.Text) = False Then
                                strErrMsg = "����[" + objTextBox.Text + "]����Ч�����ڣ�"
                                GoTo errProc
                            End If
                        End If
                        If objPulicParameters.isDatetimeString(objTextBox.Text) = True Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JHJS) = CType(objTextBox.Text, System.DateTime)
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JHJS) = System.DBNull.Value
                        End If
                    End If

                    '���txtJH_JBRY
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_txtJH_JBRY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            If objTextBox.Text.Trim = "" Then
                                strErrMsg = "����û������[������Ա]��"
                                GoTo errProc
                            End If
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBRYMC) = objPulicParameters.getObjectValue(objTextBox.Text, "")
                    End If
                    '���htxtJH_JBRY
                    objHidden = Nothing
                    objHidden = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_htxtJH_JBRY), System.Web.UI.HtmlControls.HtmlInputHidden)
                    If Not (objHidden Is Nothing) Then
                        If blnCheck = True Then
                            '�����
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBRY) = objPulicParameters.getObjectValue(objHidden.Value, "")
                    End If

                    '���txtJH_JBDW
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_txtJH_JBDW), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            If objTextBox.Text.Trim = "" Then
                                strErrMsg = "����û������[���쵥λ]��"
                                GoTo errProc
                            End If
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDWMC) = objPulicParameters.getObjectValue(objTextBox.Text, "")
                    End If
                    '���htxtJH_JBDW
                    objHidden = Nothing
                    objHidden = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_htxtJH_JBDW), System.Web.UI.HtmlControls.HtmlInputHidden)
                    If Not (objHidden Is Nothing) Then
                        If blnCheck = True Then
                            '�����
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDW) = objPulicParameters.getObjectValue(objHidden.Value, "")
                    End If

                    '���txtJH_GZNR
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_txtJH_GZNR), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            If objTextBox.Text.Trim = "" Then
                                strErrMsg = "����û������[��������]��"
                                GoTo errProc
                            End If
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_GZNR) = objPulicParameters.getObjectValue(objTextBox.Text, "")
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_BAJH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdBAJH�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_BAJH( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANANJIHUA
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_BAJH = False
            strErrMsg = ""

            Try
                '��ʾδ������
                Dim objHidden As System.Web.UI.HtmlControls.HtmlInputHidden = Nothing
                Dim objCheckBox As System.Web.UI.WebControls.CheckBox = Nothing
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objButton As System.Web.UI.WebControls.Button = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdBAJH.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdBAJH.CurrentPageIndex, Me.grdBAJH.PageSize)
                    objDataRow = Me.m_objDataSet_BAJH.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���chkJH_TX
                    objCheckBox = Nothing
                    objCheckBox = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_chkJH_TX), System.Web.UI.WebControls.CheckBox)
                    If Not (objCheckBox Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_TXBZ), "")
                        If strValue = "1" Then
                            objCheckBox.Checked = True
                        Else
                            objCheckBox.Checked = False
                        End If
                        objControlProcess.doEnabledControl(objCheckBox, Not blnEditMode)
                    End If

                    '���txtJH_JHKS
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_txtJH_JHKS), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JHKS), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, Not blnEditMode)
                    End If

                    '���txtJH_JHJS
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_txtJH_JHJS), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JHJS), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, Not blnEditMode)
                    End If

                    '���txtJH_JBRY
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_txtJH_JBRY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBRYMC), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, Not blnEditMode)
                    End If
                    objButton = Nothing
                    objButton = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_btnJH_SelectJBRY), System.Web.UI.WebControls.Button)
                    If Not (objButton Is Nothing) Then
                        objControlProcess.doEnabledControl(objButton, Not blnEditMode)
                    End If
                    '���htxtJH_JBRY
                    objHidden = Nothing
                    objHidden = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_htxtJH_JBRY), System.Web.UI.HtmlControls.HtmlInputHidden)
                    If Not (objHidden Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBRY), "")
                        objHidden.Value = strValue
                    End If

                    '���txtJH_JBDW
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_txtJH_JBDW), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDWMC), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, Not blnEditMode)
                    End If
                    objButton = Nothing
                    objButton = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_btnJH_SelectJBDW), System.Web.UI.WebControls.Button)
                    If Not (objButton Is Nothing) Then
                        objControlProcess.doEnabledControl(objButton, Not blnEditMode)
                    End If
                    '���htxtJH_JBDW
                    objHidden = Nothing
                    objHidden = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_htxtJH_JBDW), System.Web.UI.HtmlControls.HtmlInputHidden)
                    If Not (objHidden Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDW), "")
                        objHidden.Value = strValue
                    End If

                    '���txtJH_GZNR
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_txtJH_GZNR), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_GZNR), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, Not blnEditMode)
                    End If

                    objButton = Nothing
                    objButton = CType(Me.grdBAJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_BAJH_btnJH_SelectRow), System.Web.UI.WebControls.Button)
                    If Not (objButton Is Nothing) Then
                        objControlProcess.doEnabledControl(objButton, Not blnEditMode)
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showDataGridUnboundInfo_BAJH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdBAJH������
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ����ǰ�༭״̬
        '     objenumEditType����ϸ����ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_BAJH( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANANJIHUA
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_BAJH = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtBAJHSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtBAJHSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_BAJH Is Nothing Then
                    Me.grdBAJH.DataSource = Nothing
                Else
                    With Me.m_objDataSet_BAJH.Tables(strTable)
                        Me.grdBAJH.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_BAJH.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdBAJH, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '����������
                Me.grdBAJH.AllowSorting = Not blnEditMode

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdBAJH)
                    With Me.grdBAJH.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdBAJH.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                ''�ָ������е�CheckBox״̬
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdBAJH, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_BAJH) = False Then
                '    GoTo errProc
                'End If
                '��ʾδ������
                If Me.showDataGridUnboundInfo_BAJH(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_BAJH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdBLJL������
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ����ǰ�༭״̬
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_BLJL( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANLIJILU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_BLJL = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtBLJLSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtBLJLSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_BLJL Is Nothing Then
                    Me.grdBLJL.DataSource = Nothing
                Else
                    With Me.m_objDataSet_BLJL.Tables(strTable)
                        Me.grdBLJL.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_BLJL.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdBLJL, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '����������
                Me.grdBLJL.AllowSorting = Not blnEditMode

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdBLJL)
                    With Me.grdBLJL.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdBLJL.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdBLJL, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_BLJL) = False Then
                    GoTo errProc
                End If

                '����Ǳ༭ģʽ
                If blnEditMode = True Then
                    'ʹ������
                    If objDataGridProcess.doEnabledDataGrid(strErrMsg, Me.grdBLJL, Not blnEditMode) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_BLJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdBLJL��صı༭������(��������ǰ��������ʾ)
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     blnEditMode    ����ǰ�༭״̬
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showEditPanelInfo_BLJL( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim strValue As String = ""

            showEditPanelInfo_BLJL = False

            Try
                If Not (Me.IsPostBack = False And Me.m_blnSaveScence = True) Then
                    '�鿴״̬
                    If Me.grdBLJL.Items.Count < 1 Or Me.grdBLJL.SelectedIndex < 0 Then
                        Me.htxtSJ_WYBS.Value = ""
                        Me.htxtSJ_QRSH.Value = ""
                        Me.htxtSJ_JHBS.Value = ""
                        Me.htxtSJ_JBRY.Value = ""
                        Me.htxtSJ_JBDW.Value = ""
                        Me.txtSJ_JBRY.Text = ""
                        Me.txtSJ_JBDW.Text = ""
                        Me.txtSJ_BLRQ.Text = ""
                        Me.txtSJ_BLQK.Text = ""
                    Else
                        Dim intColIndex As Integer = -1

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBLJL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_WYBS)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdBLJL.Items(Me.grdBLJL.SelectedIndex), intColIndex)
                        Me.htxtSJ_WYBS.Value = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBLJL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_QRSH)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdBLJL.Items(Me.grdBLJL.SelectedIndex), intColIndex)
                        Me.htxtSJ_QRSH.Value = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBLJL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_JHBS)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdBLJL.Items(Me.grdBLJL.SelectedIndex), intColIndex)
                        Me.htxtSJ_JHBS.Value = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBLJL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_JBRY)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdBLJL.Items(Me.grdBLJL.SelectedIndex), intColIndex)
                        Me.htxtSJ_JBRY.Value = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBLJL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_JBDW)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdBLJL.Items(Me.grdBLJL.SelectedIndex), intColIndex)
                        Me.htxtSJ_JBDW.Value = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBLJL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_BLRQ)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdBLJL.Items(Me.grdBLJL.SelectedIndex), intColIndex)
                        Me.txtSJ_BLRQ.Text = objPulicParameters.getObjectValue(strValue, "", "yyyy-MM-dd")

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBLJL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_JBRYMC)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdBLJL.Items(Me.grdBLJL.SelectedIndex), intColIndex)
                        Me.txtSJ_JBRY.Text = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBLJL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_JBDWMC)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdBLJL.Items(Me.grdBLJL.SelectedIndex), intColIndex)
                        Me.txtSJ_JBDW.Text = strValue

                        intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBLJL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_BLQK)
                        strValue = objDataGridProcess.getDataGridCellValue(Me.grdBLJL.Items(Me.grdBLJL.SelectedIndex), intColIndex)
                        Me.txtSJ_BLQK.Text = strValue
                    End If
                Else
                    '�༭״̬
                    '�Զ��ָ�����
                End If

                'ʹ�ܿؼ�
                objControlProcess.doEnabledControl(Me.txtSJ_BLRQ, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.txtSJ_JBRY, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.txtSJ_JBDW, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.txtSJ_BLQK, Not blnEditMode)

                Me.btnSelect_SJ_JBRY.Visible = Not blnEditMode And strQRSH <> ""
                Me.btnSelect_SJ_JBDW.Visible = Not blnEditMode And strQRSH <> ""
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanelInfo_BLJL = True
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
        ' ��ʾBAJH��ص�ȫ����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     blnEditMode    ����ǰ�༭״̬
        '     objenumEditType����ϸ����ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal blnEditMode As Boolean, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANANJIHUA
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_BAJH = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_BAJH(strErrMsg, blnEditMode, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_BAJH.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblBAJHGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdBAJH, .Count)

                    '��ʾҳ���������
                    Me.lnkCZBAJHMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdBAJH, .Count) And (Not blnEditMode)
                    Me.lnkCZBAJHMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdBAJH, .Count) And (Not blnEditMode)
                    Me.lnkCZBAJHMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdBAJH, .Count) And (Not blnEditMode)
                    Me.lnkCZBAJHMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdBAJH, .Count) And (Not blnEditMode)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZBAJHDeSelectAll.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZBAJHSelectAll.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZBAJHGotoPage.Enabled = blnEnabled And (Not blnEditMode)
                    Me.lnkCZBAJHSetPageSize.Enabled = blnEnabled And (Not blnEditMode)
                End With

                objControlProcess.doEnabledControl(Me.txtBAJHPageSize, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBAJHPageIndex, Not blnEditMode)

                objControlProcess.doEnabledControl(Me.ddlBAJHSearch_TXBZ, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBAJHSearch_JHKSMax, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBAJHSearch_JHKSMin, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBAJHSearch_JHJSMax, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBAJHSearch_JHJSMin, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBAJHSearch_JBRY, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBAJHSearch_JBDW, Not blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBAJHSearch_GZNR, Not blnEditMode)
                Me.btnBAJHSearch.Enabled = Not blnEditMode
                Me.btnBAJHSearch_Full.Enabled = Not blnEditMode

                '��ʾͬ����Ϣ
                If Me.getModuleData_BLJL(strErrMsg, strQRSH, Me.m_strQuery_BLJL) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_BLJL(strErrMsg, strQRSH, blnEditMode) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_Main(strErrMsg, strQRSH, blnEditMode) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_BAJH = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾBLJL��ص�ȫ����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     blnEditMode    ����ǰ�༭״̬
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_BLJL( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANLIJILU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_BLJL = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_BLJL(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If
                '��ʾ�༭����Ϣ
                If Me.showEditPanelInfo_BLJL(strErrMsg, strQRSH, blnEditMode) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_BLJL = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾ������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     blnEditMode    ����ǰ�༭״̬
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_Main( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal blnEditMode As Boolean) As Boolean

            showModuleData_Main = False

            Try
                Me.btnAddNew_JH.Visible = strQRSH <> "" And (Not blnEditMode) And Me.m_blnPrevilegeParams(8) And (Not Me.m_blnComplete)
                Me.btnDelete_JH.Visible = strQRSH <> "" And (Not blnEditMode) And Me.m_blnPrevilegeParams(8) And (Not Me.m_blnComplete)
                Me.btnUpdate_JH.Visible = Me.btnAddNew_JH.Visible

                Me.btnAddNew_SJ.Visible = strQRSH <> "" And (Not blnEditMode) And Me.m_blnPrevilegeParams(8) And (Not Me.m_blnComplete)
                Me.btnUpdate_SJ.Visible = strQRSH <> "" And (Not blnEditMode) And Me.m_blnPrevilegeParams(8) And (Not Me.m_blnComplete)
                Me.btnDelete_SJ.Visible = strQRSH <> "" And (Not blnEditMode) And Me.m_blnPrevilegeParams(8) And (Not Me.m_blnComplete)

                Me.btnKSBL.Visible = strQRSH <> "" And (Not blnEditMode) And Me.m_blnPrevilegeParams(8) And (Not Me.m_blnComplete)
                Me.btnBLWB.Visible = strQRSH <> "" And (Not blnEditMode) And Me.m_blnPrevilegeParams(8) And (Not Me.m_blnComplete)
                Me.btnGBTX.Visible = strQRSH <> "" And (Not blnEditMode) And Me.m_blnPrevilegeParams(8) And (Not Me.m_blnComplete)
                Me.btnSZTX.Visible = strQRSH <> "" And (Not blnEditMode) And Me.m_blnPrevilegeParams(8) And (Not Me.m_blnComplete)

                'zengxianglin 2009-01-02
                Me.btnAJBJ.Visible = strQRSH <> "" And (Not blnEditMode) And Me.m_blnPrevilegeParams(10) And (Not Me.m_blnComplete)
                'zengxianglin 2009-01-02

                Me.btnSelect_JYBH.Visible = Not blnEditMode
                Me.btnClose.Visible = Not blnEditMode
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

            '���ڵ�һ�ε���ҳ��ʱִ��
            If Me.IsPostBack = False Then
                Try
                    '��ʾPannel(�����Ƿ�ص���ʼ����ʾpanelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtBAJHPageIndex)
                    objControlProcess.doTranslateKey(Me.txtBAJHPageSize)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.ddlBAJHSearch_TXBZ)
                    objControlProcess.doTranslateKey(Me.txtBAJHSearch_JHKSMin)
                    objControlProcess.doTranslateKey(Me.txtBAJHSearch_JHKSMax)
                    objControlProcess.doTranslateKey(Me.txtBAJHSearch_JHJSMin)
                    objControlProcess.doTranslateKey(Me.txtBAJHSearch_JHJSMax)
                    objControlProcess.doTranslateKey(Me.txtBAJHSearch_JBRY)
                    objControlProcess.doTranslateKey(Me.txtBAJHSearch_JBDW)
                    objControlProcess.doTranslateKey(Me.txtBAJHSearch_GZNR)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtJYBH)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtSJ_JBRY)
                    objControlProcess.doTranslateKey(Me.txtSJ_JBDW)
                    objControlProcess.doTranslateKey(Me.txtSJ_BLRQ)

                    '��ȡ����
                    If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-06
                    If Me.showModuleData_Main(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-06
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            Else
                '��ȡ���ݼ�
                If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, False) = False Then
                    GoTo errProc
                End If
                '�Զ�������������
                If Me.saveDataGridUnboundInfo_BAJH(strErrMsg, False) = False Then
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

            '���Ȩ��(�����Ƿ�ط���)
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
        Sub grdBAJH_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdBAJH.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_BAJH + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_BAJH > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_BAJH - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdBAJH.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Sub grdBLJL_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdBLJL.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_BLJL + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_BLJL > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_BLJL - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdBLJL.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdBAJH_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBAJH.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblBAJHGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdBAJH, Me.m_intRows_BAJH)
                'ͬ����ʾ
                If Me.getModuleData_BLJL(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BLJL) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_BLJL(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_Main(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode) = False Then
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

        Private Sub grdBLJL_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBLJL.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                'ͬ����ʾ
                If Me.showEditPanelInfo_BLJL(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode) = False Then
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

        Private Sub grdBAJH_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdBAJH.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANANJIHUA
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
                If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                With Me.m_objDataSet_BAJH.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                With Me.m_objDataSet_BAJH.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtBAJHSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtBAJHSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtBAJHSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub grdBLJL_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdBLJL.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANLIJILU
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
                If Me.getModuleData_BLJL(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BLJL) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                With Me.m_objDataSet_BLJL.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                With Me.m_objDataSet_BLJL.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtBLJLSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtBLJLSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtBLJLSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_BLJL(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode) = False Then
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

        Private Sub grdBAJH_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdBAJH.ItemCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANANJIHUA
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '���㵱ǰ��
                Dim intRecPos As Integer
                With Me.grdBAJH
                    intRecPos = objDataGridProcess.getRecordPosition(e.Item.ItemIndex, .CurrentPageIndex, .PageSize)
                End With

                'ִ�в���
                Select Case e.CommandName.ToUpper
                    Case "btnJH_SelectJBRY".ToUpper
                        Me.htxtRowNoBAJH.Value = intRecPos.ToString
                        Me.doSelect_JBRY("btnJH_SelectJBRY")
                    Case "btnJH_SelectJBDW".ToUpper
                        Me.htxtRowNoBAJH.Value = intRecPos.ToString
                        Me.doSelect_JBDW("btnJH_SelectJBDW")
                    Case "btnJH_SelectRow".ToUpper
                        Me.grdBAJH.SelectedIndex = e.Item.ItemIndex
                        '��ʾ��¼λ��
                        Me.lblBAJHGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdBAJH, Me.m_intRows_BAJH)
                        'ͬ����ʾ
                        If Me.getModuleData_BLJL(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BLJL) = False Then
                            GoTo errProc
                        End If
                        If Me.showModuleData_BLJL(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode) = False Then
                            GoTo errProc
                        End If
                        If Me.showModuleData_Main(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode) = False Then
                            GoTo errProc
                        End If
                End Select
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















        Private Sub doMoveFirst_BAJH(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdBAJH.PageCount)
                Me.grdBAJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doMoveLast_BAJH(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdBAJH.PageCount - 1, Me.grdBAJH.PageCount)
                Me.grdBAJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doMoveNext_BAJH(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdBAJH.CurrentPageIndex + 1, Me.grdBAJH.PageCount)
                Me.grdBAJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doMovePrevious_BAJH(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdBAJH.CurrentPageIndex - 1, Me.grdBAJH.PageCount)
                Me.grdBAJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doGotoPage_BAJH(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtBAJHPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdBAJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtBAJHPageIndex.Text = (Me.grdBAJH.CurrentPageIndex + 1).ToString()
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

        Private Sub doSetPageSize_BAJH(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtBAJHPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdBAJH.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtBAJHPageSize.Text = (Me.grdBAJH.PageSize).ToString()
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

        Private Sub doSelectAll_BAJH(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdBAJH, 0, Me.m_cstrCheckBoxIdInDataGrid_BAJH, True) = False Then
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

        Private Sub doDeSelectAll_BAJH(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdBAJH, 0, Me.m_cstrCheckBoxIdInDataGrid_BAJH, False) = False Then
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

        Private Sub doSearch_BAJH(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_BAJH(strErrMsg, Me.m_strQRSH, True) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub lnkCZBAJHMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBAJHMoveFirst.Click
            Me.doMoveFirst_BAJH("lnkCZBAJHMoveFirst")
        End Sub

        Private Sub lnkCZBAJHMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBAJHMoveLast.Click
            Me.doMoveLast_BAJH("lnkCZBAJHMoveLast")
        End Sub

        Private Sub lnkCZBAJHMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBAJHMoveNext.Click
            Me.doMoveNext_BAJH("lnkCZBAJHMoveNext")
        End Sub

        Private Sub lnkCZBAJHMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBAJHMovePrev.Click
            Me.doMovePrevious_BAJH("lnkCZBAJHMovePrev")
        End Sub

        Private Sub lnkCZBAJHGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBAJHGotoPage.Click
            Me.doGotoPage_BAJH("lnkCZBAJHGotoPage")
        End Sub

        Private Sub lnkCZBAJHSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBAJHSetPageSize.Click
            Me.doSetPageSize_BAJH("lnkCZBAJHSetPageSize")
        End Sub

        Private Sub lnkCZBAJHSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBAJHSelectAll.Click
            Me.doSelectAll_BAJH("lnkCZBAJHSelectAll")
        End Sub

        Private Sub lnkCZBAJHDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZBAJHDeSelectAll.Click
            Me.doDeSelectAll_BAJH("lnkCZBAJHDeSelectAll")
        End Sub

        Private Sub btnBAJHSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBAJHSearch.Click
            Me.doSearch_BAJH("btnBAJHSearch")
        End Sub












        Private Sub doSearch_Full_BAJH(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANANJIHUA
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strErrMsg As String = ""

            Try
                '��ȡ����
                If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
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
                    If Me.htxtBAJHSessionIdQuery.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtBAJHSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_BAJH.Tables(strTable)
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

        Private Sub btnBAJHSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBAJHSearch_Full.Click
            Me.doSearch_Full_BAJH("btnBAJHSearch_Full")
        End Sub













        Private Sub doSelect_JBRY(ByVal strControlId As String)

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
                Dim objIDmxzRyxx As Josco.JsKernal.BusinessFacade.IDmxzRyxx = Nothing
                Dim strUrl As String = ""
                objIDmxzRyxx = New Josco.JsKernal.BusinessFacade.IDmxzRyxx
                With objIDmxzRyxx
                    .iAllowNull = False
                    .iMultiSelect = False
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
                Session.Add(strNewSessionId, objIDmxzRyxx)
                strUrl = ""
                strUrl += "../../dmxz/dmxz_ryxx.aspx"
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

        Private Sub doSelect_JBDW(ByVal strControlId As String)

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
                    .iAllowNull = False
                    .iMultiSelect = False
                    .iAllowInput = False
                    .iBumenList = ""
                    .iSelectFFFW = False
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
                Dim objIEstateEsXzHtxx As Josco.JSOA.BusinessFacade.IEstateEsXzHtxx = Nothing
                Dim strUrl As String = ""
                objIEstateEsXzHtxx = New Josco.JSOA.BusinessFacade.IEstateEsXzHtxx
                With objIEstateEsXzHtxx
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
                Session.Add(strNewSessionId, objIEstateEsXzHtxx)
                strUrl = ""
                strUrl += "../ershou/estate_es_xz_htxx.aspx"
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

        Private Sub btnSelect_SJ_JBRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_SJ_JBRY.Click
            Me.doSelect_JBRY("btnSelect_SJ_JBRY")
        End Sub

        Private Sub btnSelect_SJ_JBDW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_SJ_JBDW.Click
            Me.doSelect_JBDW("btnSelect_SJ_JBDW")
        End Sub

        Private Sub btnSelect_JYBH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_JYBH.Click
            Me.doSelect_JYBH("btnSelect_JYBH")
        End Sub














        '----------------------------------------------------------------
        'ģ���������������
        '----------------------------------------------------------------
        Private Sub doAddNew_JH(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objsystemEstateCommon As New Josco.JSOA.BusinessFacade.systemEstateCommon
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.m_strQRSH.Trim = "" Then
                    strErrMsg = "����û��ѡ��[ȷ����]��"
                    GoTo errProc
                End If

                '����ҵ������
                Dim strYWLX As String = ""
                If objsystemEstateErshou.getYWLX(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, strYWLX) = False Then
                    GoTo errProc
                End If
                Select Case strYWLX
                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_MM
                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_ZL
                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_QT
                    Case Else
                        strErrMsg = "������Ч��[ҵ������]��"
                        GoTo errProc
                End Select

                '�����ֳ�����
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                Dim objIDmxzJbdm As Josco.JsKernal.BusinessFacade.IDmxzJbdm = Nothing
                Dim strUrl As String = ""
                objIDmxzJbdm = New Josco.JsKernal.BusinessFacade.IDmxzJbdm
                With objIDmxzJbdm
                    Dim strFName As String = Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_BAXM_XMDM
                    Dim strSQL As String = objsystemEstateCommon.getTableSQL_BAXM()
                    Dim strArray(2) As String
                    Dim intPos As Integer
                    intPos = strSQL.IndexOf("order by")
                    If intPos >= 0 Then
                        strArray(0) = strSQL.Substring(0, intPos - 1)
                        strArray(1) = strSQL.Substring(intPos)
                    Else
                        strArray(0) = strSQL
                        strArray(1) = ""
                    End If
                    .iCodeField = Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_BAXM_XMDM
                    .iNameField = Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_BAXM_XMMC
                    .iTitle = "ѡ��참��Ŀ"
                    .iAllowInput = False
                    .iAllowNull = False
                    .iMultiSelect = True
                    .iColWidth = "50%" + strSep + "50%"
                    Select Case strYWLX
                        Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_MM
                            .iRowSourceSQL = strArray(0) + " where " + strFName + " like '" + Me.htxtBAXM_MM.Value + "%' " + strArray(1)
                        Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_ZL
                            .iRowSourceSQL = strArray(0) + " where " + strFName + " like '" + Me.htxtBAXM_ZL.Value + "%' " + strArray(1)
                        Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_QT
                            .iRowSourceSQL = strArray(0) + " where " + strFName + " like '" + Me.htxtBAXM_QT.Value + "%' " + strArray(1)
                        Case Else
                            strErrMsg = "������Ч��[ҵ������]��"
                            GoTo errProc
                    End Select
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
                Session.Add(strNewSessionId, objIDmxzJbdm)
                strUrl = ""
                strUrl += "../../dmxz/dmxz_jbdm.aspx"
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
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JSOA.BusinessFacade.systemEstateCommon.SafeRelease(objsystemEstateCommon)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doUpdate_JH(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '���
                If Me.saveDataGridUnboundInfo_BAJH(strErrMsg, True) = False Then
                    GoTo errProc
                End If

                '����
                If objsystemEstateErshou.doSaveData_ES_HETONG_BAJH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, Me.m_objDataSet_BAJH) = False Then
                    GoTo errProc
                End If

                'ˢ����ʾ
                If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, True) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doDelete_JH(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANANJIHUA
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '���ѡ��
                If Me.grdBAJH.SelectedIndex < 0 Then
                    strErrMsg = "����û�����ݣ�"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdBAJH.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strWYBS As String = ""
                Dim strQRSH As String = ""
                Dim strSHBZ As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBAJH, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_WYBS)
                strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdBAJH.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBAJH, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_QRSH)
                strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdBAJH.Items(i), intColIndex)

                'ѯ��
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷʵ׼��ɾ��ѡ����ҵ������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��ʾ��ش��ǡ����Ŵ���
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    'ɾ������
                    If strWYBS = "" Then
                        Dim objDataRow As System.Data.DataRow = Nothing
                        Dim intRecPos As Integer
                        With Me.grdBAJH
                            intRecPos = objDataGridProcess.getRecordPosition(.SelectedIndex, .CurrentPageIndex, .PageSize)
                        End With
                        With Me.m_objDataSet_BAJH.Tables(strTable)
                            objDataRow = .DefaultView.Item(intRecPos).Row
                            .Rows.Remove(objDataRow)
                        End With
                    Else
                        If objsystemEstateErshou.doDeleteData_ES_HETONG_BAJH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS) = False Then
                            GoTo errProc
                        End If
                        '��¼�����־
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_��ͬ_�참]��[ɾ��]��[" + strWYBS + "]��")
                    End If

                    '��ʾ����
                    'zengxianglin 2008-12-04
                    'If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
                    '    GoTo errProc
                    'End If
                    If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, True) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-12-04
                    If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
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

        Private Sub doAddNew_SJ(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANLIJILU
            Dim objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '���
                If Me.grdBAJH.SelectedIndex < 0 Then
                    strErrMsg = "����û�мƻ���"
                    GoTo errProc
                End If
                '����ƻ���ʶ
                Dim strJHWYBS As String = ""
                Dim intColIndex As Integer
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBAJH, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_WYBS)
                strJHWYBS = objDataGridProcess.getDataGridCellValue(Me.grdBAJH.Items(Me.grdBAJH.SelectedIndex), intColIndex)
                If strJHWYBS = "" Then
                    strErrMsg = "����û�мƻ���"
                    GoTo errProc
                End If

                objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                '���
                If Me.txtSJ_BLRQ.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[��������]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtSJ_BLRQ.Text) = False Then
                    strErrMsg = "������Ч��[��������]��"
                    GoTo errProc
                End If
                If Me.htxtSJ_JBRY.Value.Trim = "" Then
                    strErrMsg = "����û��ָ��[������Ա]��"
                    GoTo errProc
                End If
                If Me.htxtSJ_JBDW.Value.Trim = "" Then
                    strErrMsg = "����û��ָ��[���쵥λ]��"
                    GoTo errProc
                End If
                If Me.txtSJ_BLQK.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[�������]��"
                    GoTo errProc
                End If

                '��ȡ����Ϣ
                Dim objNewData As New System.Collections.Specialized.NameValueCollection
                '***************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_WYBS, Me.htxtSJ_WYBS.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_QRSH, Me.htxtSJ_QRSH.Value)
                '***************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_BLRQ, Me.txtSJ_BLRQ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_BLQK, Me.txtSJ_BLQK.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_JBRY, Me.htxtSJ_JBRY.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_JBDW, Me.htxtSJ_JBDW.Value)
                '***************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_JHBS, Me.htxtSJ_JHBS.Value)
                '***************************************************************************************************************

                '��ȡ����Ϣ
                Dim objOldData As System.Data.DataRow = Nothing
                Dim intPos As Integer = 0
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        objOldData = Nothing
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_JHBS) = strJHWYBS
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_QRSH) = Me.m_strQRSH
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_WYBS) = ""
                    Case Else
                        '��ȡ����
                        If Me.getModuleData_BLJL(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BLJL) = False Then
                            GoTo errProc
                        End If
                        intPos = objDataGridProcess.getRecordPosition(Me.grdBLJL.SelectedIndex, Me.grdBLJL.CurrentPageIndex, Me.grdBLJL.PageSize)
                        With Me.m_objDataSet_BLJL.Tables(strTable)
                            objOldData = .DefaultView.Item(intPos).Row
                        End With
                End Select

                '������Ϣ
                If objsystemEstateErshou.doSaveData_ES_HETONG_BLJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If
                Dim strWYBS As String = objNewData.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_WYBS)

                '��¼�����־
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_��ͬ_�참��¼]��������[" + strWYBS + "]��")
                    Case Else
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]������[����_��ͬ_�참��¼]��[" + strWYBS + "]�����ݣ�")
                End Select

                '��ʾ����
                If Me.getModuleData_BLJL(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BLJL) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_BLJL(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode) = False Then
                    GoTo errProc
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

        Private Sub doUpdate_SJ(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANLIJILU
            Dim objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '���
                If Me.grdBAJH.SelectedIndex < 0 Then
                    strErrMsg = "����û�мƻ���"
                    GoTo errProc
                End If
                '����ƻ���ʶ
                Dim strJHWYBS As String = ""
                Dim intColIndex As Integer
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBAJH, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_WYBS)
                strJHWYBS = objDataGridProcess.getDataGridCellValue(Me.grdBAJH.Items(Me.grdBAJH.SelectedIndex), intColIndex)
                If strJHWYBS = "" Then
                    strErrMsg = "����û�мƻ���"
                    GoTo errProc
                End If

                objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                '���
                If Me.grdBLJL.SelectedIndex < 0 Then
                    strErrMsg = "����û��[�����¼]��"
                    GoTo errProc
                End If
                If Me.txtSJ_BLRQ.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[��������]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtSJ_BLRQ.Text) = False Then
                    strErrMsg = "������Ч��[��������]��"
                    GoTo errProc
                End If
                If Me.htxtSJ_JBRY.Value.Trim = "" Then
                    strErrMsg = "����û��ָ��[������Ա]��"
                    GoTo errProc
                End If
                If Me.htxtSJ_JBDW.Value.Trim = "" Then
                    strErrMsg = "����û��ָ��[���쵥λ]��"
                    GoTo errProc
                End If
                If Me.txtSJ_BLQK.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[�������]��"
                    GoTo errProc
                End If

                '��ȡ����Ϣ
                Dim objNewData As New System.Collections.Specialized.NameValueCollection
                '***************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_WYBS, Me.htxtSJ_WYBS.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_QRSH, Me.htxtSJ_QRSH.Value)
                '***************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_BLRQ, Me.txtSJ_BLRQ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_BLQK, Me.txtSJ_BLQK.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_JBRY, Me.htxtSJ_JBRY.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_JBDW, Me.htxtSJ_JBDW.Value)
                '***************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_JHBS, Me.htxtSJ_JHBS.Value)
                '***************************************************************************************************************

                '��ȡ����Ϣ
                Dim objOldData As System.Data.DataRow = Nothing
                Dim intPos As Integer = 0
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        objOldData = Nothing
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_JHBS) = strJHWYBS
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_QRSH) = Me.m_strQRSH
                        objNewData(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_WYBS) = ""
                    Case Else
                        '��ȡ����
                        If Me.getModuleData_BLJL(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BLJL) = False Then
                            GoTo errProc
                        End If
                        intPos = objDataGridProcess.getRecordPosition(Me.grdBLJL.SelectedIndex, Me.grdBLJL.CurrentPageIndex, Me.grdBLJL.PageSize)
                        With Me.m_objDataSet_BLJL.Tables(strTable)
                            objOldData = .DefaultView.Item(intPos).Row
                        End With
                End Select

                '������Ϣ
                If objsystemEstateErshou.doSaveData_ES_HETONG_BLJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If
                Dim strWYBS As String = objNewData.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_WYBS)

                '��¼�����־
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_��ͬ_�참��¼]��������[" + strWYBS + "]��")
                    Case Else
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]������[����_��ͬ_�참��¼]��[" + strWYBS + "]�����ݣ�")
                End Select

                '��ʾ����
                If Me.getModuleData_BLJL(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BLJL) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_BLJL(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode) = False Then
                    GoTo errProc
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

        Private Sub doDelete_SJ(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_BANLIJILU
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '���ѡ��
                If Me.grdBLJL.SelectedIndex < 0 Then
                    strErrMsg = "����û�����ݣ�"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdBLJL.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strWYBS As String = ""
                Dim strQRSH As String = ""
                Dim strSHBZ As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBLJL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_WYBS)
                strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdBLJL.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBLJL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANLIJILU_QRSH)
                strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdBLJL.Items(i), intColIndex)

                'ѯ��
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷʵ׼��ɾ��ѡ���ļ�¼����/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��ʾ��ش��ǡ����Ŵ���
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    'ɾ������
                    If objsystemEstateErshou.doDeleteData_ES_HETONG_BLJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS) = False Then
                        GoTo errProc
                    End If

                    '��¼�����־
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_��ͬ_�참��¼]��[ɾ��]��[" + strWYBS + "]��")

                    '��ʾ����
                    If Me.getModuleData_BLJL(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BLJL) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_BLJL(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doKSBL(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer = 0
            Dim strKSRQ As String = ""
            Dim strErrMsg As String

            Try
                intStep = 1
                '���
                If Me.grdBAJH.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[ҵ��]��"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdBAJH.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strSJKS As String = ""
                Dim strWYBS As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBAJH, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_SJKS)
                strSJKS = objDataGridProcess.getDataGridCellValue(Me.grdBAJH.Items(i), intColIndex)
                If strSJKS <> "" Then
                    strErrMsg = "�����Ѿ���ǿ�ʼ����"
                    GoTo errProc
                End If
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBAJH, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_WYBS)
                strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdBAJH.Items(i), intColIndex)

                intStep = 2
                '���롰��ʼ���ڡ�
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doInputBox(Me.popMessageObject, "�����뿪ʼ��������(yyyy-MM-dd)��", strControlId, intStep, Now.ToString("yyyy-MM-dd"))
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '��������
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��ȡ����ֵ
                    strKSRQ = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)
                    If strKSRQ = "" Then
                        strErrMsg = "����û��ָ��[��ʼ����]��"
                        GoTo errProc
                    End If
                    If objPulicParameters.isDatetimeString(strKSRQ) = False Then
                        strErrMsg = "������Ч��[��ʼ����]��"
                        GoTo errProc
                    End If

                    '���
                    If objsystemEstateErshou.doMarkBegin_ES_HETONG_BAJH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS, strKSRQ) = False Then
                        GoTo errProc
                    End If

                    '��ʾ
                    'zengxianglin 2008-11-26
                    'If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
                    '    GoTo errProc
                    'End If
                    If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, True) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-26
                    If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doBLWB(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer = 0
            Dim strJSRQ As String = ""
            Dim strErrMsg As String

            Try
                intStep = 1
                '���
                If Me.grdBAJH.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[ҵ��]��"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdBAJH.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strSJJS As String = ""
                Dim strWYBS As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBAJH, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_SJJS)
                strSJJS = objDataGridProcess.getDataGridCellValue(Me.grdBAJH.Items(i), intColIndex)
                If strSJJS <> "" Then
                    strErrMsg = "�����Ѿ���ǰ�����ϣ�"
                    GoTo errProc
                End If
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBAJH, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_WYBS)
                strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdBAJH.Items(i), intColIndex)

                intStep = 2
                '���롰�������ڡ�
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doInputBox(Me.popMessageObject, "����������������(yyyy-MM-dd)��", strControlId, intStep, Now.ToString("yyyy-MM-dd"))
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '��������
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��ȡ����ֵ
                    strJSRQ = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)
                    If strJSRQ = "" Then
                        strErrMsg = "����û��ָ��[��������]��"
                        GoTo errProc
                    End If
                    If objPulicParameters.isDatetimeString(strJSRQ) = False Then
                        strErrMsg = "������Ч��[��������]��"
                        GoTo errProc
                    End If

                    '���
                    If objsystemEstateErshou.doMarkComplete_ES_HETONG_BAJH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS, strJSRQ) = False Then
                        GoTo errProc
                    End If

                    '��ʾ
                    'zengxianglin 2008-11-26
                    'If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
                    '    GoTo errProc
                    'End If
                    If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, True) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-26
                    If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doGBTX(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer = 0
            Dim strJSRQ As String = ""
            Dim strErrMsg As String

            Try
                intStep = 1
                '���
                If Me.grdBAJH.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[ҵ��]��"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdBAJH.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strTXBZ As String = ""
                Dim strWYBS As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBAJH, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_TXBZ)
                strTXBZ = objDataGridProcess.getDataGridCellValue(Me.grdBAJH.Items(i), intColIndex)
                If strTXBZ = "0" Then
                    strErrMsg = "���������Ѿ��رգ�"
                    GoTo errProc
                End If
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBAJH, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_WYBS)
                strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdBAJH.Items(i), intColIndex)

                intStep = 2
                'ѯ��
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "���棺��ȷ��Ҫ�رձ�ҵ�����������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '��������
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '�������
                    If objsystemEstateErshou.doClearTixing_ES_HETONG_BAJH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS) = False Then
                        GoTo errProc
                    End If

                    '��ʾ
                    'zengxianglin 2008-11-26
                    'If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
                    '    GoTo errProc
                    'End If
                    If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, True) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-26
                    If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doSZTX(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer = 0
            Dim strJSRQ As String = ""
            Dim strErrMsg As String

            Try
                intStep = 1
                '���
                If Me.grdBAJH.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[ҵ��]��"
                    GoTo errProc
                End If
                If Me.txtJH_KBTS.Text.Trim = "" Then
                    strErrMsg = "����û������[��ʼ��������]��������"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtJH_KBTS.Text) = False Then
                    strErrMsg = "������Ч��[��ʼ��������]��������"
                    GoTo errProc
                End If
                If Me.txtJH_BWTS.Text.Trim = "" Then
                    strErrMsg = "����û������[�����������]��������"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtJH_BWTS.Text) = False Then
                    strErrMsg = "������Ч��[�����������]��������"
                    GoTo errProc
                End If
                Dim intKBTS As Integer = objPulicParameters.getObjectValue(Me.txtJH_KBTS.Text, 0)
                Dim intBWTS As Integer = objPulicParameters.getObjectValue(Me.txtJH_BWTS.Text, 0)
                Dim i As Integer = Me.grdBAJH.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strTXBZ As String = ""
                Dim strWYBS As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdBAJH, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BANANJIHUA_WYBS)
                strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdBAJH.Items(i), intColIndex)

                intStep = 2
                'ѯ��
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "���棺��ȷ��Ҫ���ո����Ĳ���������������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '��������
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��������
                    If objsystemEstateErshou.doSetupTixing_ES_HETONG_BAJH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWYBS, intKBTS, intBWTS) = False Then
                        GoTo errProc
                    End If

                    '��ʾ
                    'zengxianglin 2008-11-26
                    'If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
                    '    GoTo errProc
                    'End If
                    If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, True) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-26
                    If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub doAJBJ(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer = 0
            Dim strErrMsg As String

            Try
                intStep = 1
                '���
                If Me.m_strQRSH = "" Then
                    strErrMsg = "����û��ָ��[��ͬ]��"
                    GoTo errProc
                End If

                intStep = 2
                'ѯ��
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "���棺��ȷ������ͬȫ��������ϣ����԰������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '��������
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '���
                    If objsystemEstateErshou.doMarkComplete_ES_HETONG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If

                    '��ʾ
                    If Me.getModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_strQuery_BAJH, Me.m_blnEnforced) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_BAJH(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode, Me.m_objenumEditType) = False Then
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

        Private Sub btnAddNew_JH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_JH.Click
            Me.doAddNew_JH("btnAddNew_JH")
        End Sub

        Private Sub btnUpdate_JH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate_JH.Click
            Me.doUpdate_JH("btnUpdate_JH")
        End Sub

        Private Sub btnDelete_JH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_JH.Click
            Me.doDelete_JH("btnDelete_JH")
        End Sub

        Private Sub btnAddNew_SJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_SJ.Click
            Me.doAddNew_SJ("btnAddNew_SJ")
        End Sub

        Private Sub btnUpdate_SJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate_SJ.Click
            Me.doUpdate_SJ("btnUpdate_SJ")
        End Sub

        Private Sub btnDelete_SJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_SJ.Click
            Me.doDelete_SJ("btnDelete_SJ")
        End Sub

        Private Sub btnKSBL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKSBL.Click
            Me.doKSBL("btnKSBL")
        End Sub

        Private Sub btnBLWB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBLWB.Click
            Me.doBLWB("btnBLWB")
        End Sub

        Private Sub btnGBTX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGBTX.Click
            Me.doGBTX("btnGBTX")
        End Sub

        Private Sub btnSZTX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSZTX.Click
            Me.doSZTX("btnSZTX")
        End Sub

        Private Sub btnAJBJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAJBJ.Click
            Me.doAJBJ("btnAJBJ")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace

