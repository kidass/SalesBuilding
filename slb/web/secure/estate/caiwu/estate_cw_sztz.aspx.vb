Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_cw_sztz
    ' 
    ' �������ʣ�
    '     I/O
    '
    ' ���������� 
    '   ������̨֧�ʡ�����ģ��
    '----------------------------------------------------------------

    Partial Class estate_cw_sztz
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateCwSztz
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateCwSztz
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdZJF��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_ZJF As String = "chkZJF"
        Private Const m_cstrDataGridInDIV_ZJF As String = "divZJF"
        Private m_intFixedColumns_ZJF As Integer

        '----------------------------------------------------------------
        '����������grdFK��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_FK As String = "chkFK"
        Private Const m_cstrDataGridInDIV_FK As String = "divFK"
        Private m_intFixedColumns_FK As Integer

        '----------------------------------------------------------------
        '����������grdQTFY��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_QTFY As String = "chkQTFY"
        Private Const m_cstrDataGridInDIV_QTFY As String = "divQTFY"
        Private m_intFixedColumns_QTFY As Integer

        '----------------------------------------------------------------
        '��ǰ��������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet_ZJF As Josco.JSOA.Common.Data.estateCaiwuData
        Private m_strQuery_ZJF As String
        Private m_intRows_ZJF As Integer
        Private m_objDataSet_FK As Josco.JSOA.Common.Data.estateCaiwuData
        Private m_strQuery_FK As String
        Private m_intRows_FK As Integer
        Private m_objDataSet_QTFY As Josco.JSOA.Common.Data.estateCaiwuData
        Private m_strQuery_QTFY As String
        Private m_intRows_QTFY As Integer

        '----------------------------------------------------------------
        '����ģ��˽�ò���
        '----------------------------------------------------------------

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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateCwSztz)
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
                    Me.htxtDivLeftZJF.Value = .htxtDivLeftZJF
                    Me.htxtDivTopZJF.Value = .htxtDivTopZJF
                    Me.htxtDivLeftFK.Value = .htxtDivLeftFK
                    Me.htxtDivTopFK.Value = .htxtDivTopFK
                    Me.htxtDivLeftQTFY.Value = .htxtDivLeftQTFY
                    Me.htxtDivTopQTFY.Value = .htxtDivTopQTFY

                    Me.htxtZJFQuery.Value = .htxtZJFQuery
                    Me.htxtZJFRows.Value = .htxtZJFRows
                    Me.htxtZJFSort.Value = .htxtZJFSort
                    Me.htxtZJFSortColumnIndex.Value = .htxtZJFSortColumnIndex
                    Me.htxtZJFSortType.Value = .htxtZJFSortType

                    Me.htxtFKQuery.Value = .htxtFKQuery
                    Me.htxtFKRows.Value = .htxtFKRows
                    Me.htxtFKSort.Value = .htxtFKSort
                    Me.htxtFKSortColumnIndex.Value = .htxtFKSortColumnIndex
                    Me.htxtFKSortType.Value = .htxtFKSortType

                    Me.htxtQTFYQuery.Value = .htxtQTFYQuery
                    Me.htxtQTFYRows.Value = .htxtQTFYRows
                    Me.htxtQTFYSort.Value = .htxtQTFYSort
                    Me.htxtQTFYSortColumnIndex.Value = .htxtQTFYSortColumnIndex
                    Me.htxtQTFYSortType.Value = .htxtQTFYSortType

                    Try
                        Me.grdZJF.PageSize = .grdZJFPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdZJF.CurrentPageIndex = .grdZJFCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdZJF.SelectedIndex = .grdZJFSelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdFK.PageSize = .grdFKPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdFK.CurrentPageIndex = .grdFKCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdFK.SelectedIndex = .grdFKSelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdQTFY.PageSize = .grdQTFYPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdQTFY.CurrentPageIndex = .grdQTFYCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdQTFY.SelectedIndex = .grdQTFYSelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.txtJYBH.Text = .txtJYBH

                    Me.txtFK_JF_SR.Text = .txtFK_JF_SR
                    Me.txtFK_JF_ZC.Text = .txtFK_JF_ZC
                    Me.txtFK_JF_YE.Text = .txtFK_JF_YE
                    Me.txtFK_YF_SR.Text = .txtFK_YF_SR
                    Me.txtFK_YF_ZC.Text = .txtFK_YF_ZC
                    Me.txtFK_YF_YE.Text = .txtFK_YF_YE
                    Me.txtFK_HT_SR.Text = .txtFK_HT_SR
                    Me.txtFK_HT_ZC.Text = .txtFK_HT_ZC
                    Me.txtFK_HT_YE.Text = .txtFK_HT_YE

                    Me.txtZJF_JF_SR.Text = .txtZJF_JF_SR
                    Me.txtZJF_JF_ZC.Text = .txtZJF_JF_ZC
                    Me.txtZJF_JF_YE.Text = .txtZJF_JF_YE
                    Me.txtZJF_YF_SR.Text = .txtZJF_YF_SR
                    Me.txtZJF_YF_ZC.Text = .txtZJF_YF_ZC
                    Me.txtZJF_YF_YE.Text = .txtZJF_YF_YE
                    Me.txtZJF_HT_SR.Text = .txtZJF_HT_SR
                    Me.txtZJF_HT_ZC.Text = .txtZJF_HT_ZC
                    Me.txtZJF_HT_YE.Text = .txtZJF_HT_YE

                    Me.txtQTFY_JF_SR.Text = .txtQTFY_JF_SR
                    Me.txtQTFY_JF_ZC.Text = .txtQTFY_JF_ZC
                    Me.txtQTFY_JF_YE.Text = .txtQTFY_JF_YE
                    Me.txtQTFY_YF_SR.Text = .txtQTFY_YF_SR
                    Me.txtQTFY_YF_ZC.Text = .txtQTFY_YF_ZC
                    Me.txtQTFY_YF_YE.Text = .txtQTFY_YF_YE
                    Me.txtQTFY_HT_SR.Text = .txtQTFY_HT_SR
                    Me.txtQTFY_HT_ZC.Text = .txtQTFY_HT_ZC
                    Me.txtQTFY_HT_YE.Text = .txtQTFY_HT_YE

                    Me.txtZKSH_YJKS.Text = .txtZKSH_YJKS
                    Me.txtZKSH_YJZZ.Text = .txtZKSH_YJZZ
                    Me.txtZKSH_EJKS.Text = .txtZKSH_EJKS
                    Me.txtZKSH_EJZZ.Text = .txtZKSH_EJZZ
                    Me.txtZKSH_SJKS.Text = .txtZKSH_SJKS
                    Me.txtZKSH_SJZZ.Text = .txtZKSH_SJZZ

                    Me.txtZKSH_SFBZ.Text = .txtZKSH_SFBZ
                    Me.txtZKSH_HTYS.Text = .txtZKSH_HTYS
                    Me.txtZKSH_HTZK.Text = .txtZKSH_HTZK
                    Me.txtZKSH_LJSS.Text = .txtZKSH_LJSS
                    Me.txtZKSH_YE.Text = .txtZKSH_YE
                    Me.txtZKSH_YJSH.Text = .txtZKSH_YJSH
                    Me.txtZKSH_EJSH.Text = .txtZKSH_EJSH
                    Me.txtZKSH_SJSH.Text = .txtZKSH_SJSH
                    Me.txtZKSH_BZXX.Text = .txtZKSH_BZXX
                    Me.rblZKSH_JA.SelectedIndex = .rblZKSH_JA_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateCwSztz

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftZJF = Me.htxtDivLeftZJF.Value
                    .htxtDivTopZJF = Me.htxtDivTopZJF.Value
                    .htxtDivLeftFK = Me.htxtDivLeftFK.Value
                    .htxtDivTopFK = Me.htxtDivTopFK.Value
                    .htxtDivLeftQTFY = Me.htxtDivLeftQTFY.Value
                    .htxtDivTopQTFY = Me.htxtDivTopQTFY.Value

                    .htxtZJFQuery = Me.htxtZJFQuery.Value
                    .htxtZJFRows = Me.htxtZJFRows.Value
                    .htxtZJFSort = Me.htxtZJFSort.Value
                    .htxtZJFSortColumnIndex = Me.htxtZJFSortColumnIndex.Value
                    .htxtZJFSortType = Me.htxtZJFSortType.Value

                    .htxtFKQuery = Me.htxtFKQuery.Value
                    .htxtFKRows = Me.htxtFKRows.Value
                    .htxtFKSort = Me.htxtFKSort.Value
                    .htxtFKSortColumnIndex = Me.htxtFKSortColumnIndex.Value
                    .htxtFKSortType = Me.htxtFKSortType.Value

                    .htxtQTFYQuery = Me.htxtQTFYQuery.Value
                    .htxtQTFYRows = Me.htxtQTFYRows.Value
                    .htxtQTFYSort = Me.htxtQTFYSort.Value
                    .htxtQTFYSortColumnIndex = Me.htxtQTFYSortColumnIndex.Value
                    .htxtQTFYSortType = Me.htxtQTFYSortType.Value

                    .grdZJFPageSize = Me.grdZJF.PageSize
                    .grdZJFCurrentPageIndex = Me.grdZJF.CurrentPageIndex
                    .grdZJFSelectedIndex = Me.grdZJF.SelectedIndex

                    .grdFKPageSize = Me.grdFK.PageSize
                    .grdFKCurrentPageIndex = Me.grdFK.CurrentPageIndex
                    .grdFKSelectedIndex = Me.grdFK.SelectedIndex

                    .grdQTFYPageSize = Me.grdQTFY.PageSize
                    .grdQTFYCurrentPageIndex = Me.grdQTFY.CurrentPageIndex
                    .grdQTFYSelectedIndex = Me.grdQTFY.SelectedIndex

                    .txtJYBH = Me.txtJYBH.Text

                    .txtFK_JF_SR = Me.txtFK_JF_SR.Text
                    .txtFK_JF_ZC = Me.txtFK_JF_ZC.Text
                    .txtFK_JF_YE = Me.txtFK_JF_YE.Text
                    .txtFK_YF_SR = Me.txtFK_YF_SR.Text
                    .txtFK_YF_ZC = Me.txtFK_YF_ZC.Text
                    .txtFK_YF_YE = Me.txtFK_YF_YE.Text
                    .txtFK_HT_SR = Me.txtFK_HT_SR.Text
                    .txtFK_HT_ZC = Me.txtFK_HT_ZC.Text
                    .txtFK_HT_YE = Me.txtFK_HT_YE.Text

                    .txtZJF_JF_SR = Me.txtZJF_JF_SR.Text
                    .txtZJF_JF_ZC = Me.txtZJF_JF_ZC.Text
                    .txtZJF_JF_YE = Me.txtZJF_JF_YE.Text
                    .txtZJF_YF_SR = Me.txtZJF_YF_SR.Text
                    .txtZJF_YF_ZC = Me.txtZJF_YF_ZC.Text
                    .txtZJF_YF_YE = Me.txtZJF_YF_YE.Text
                    .txtZJF_HT_SR = Me.txtZJF_HT_SR.Text
                    .txtZJF_HT_ZC = Me.txtZJF_HT_ZC.Text
                    .txtZJF_HT_YE = Me.txtZJF_HT_YE.Text

                    .txtQTFY_JF_SR = Me.txtQTFY_JF_SR.Text
                    .txtQTFY_JF_ZC = Me.txtQTFY_JF_ZC.Text
                    .txtQTFY_JF_YE = Me.txtQTFY_JF_YE.Text
                    .txtQTFY_YF_SR = Me.txtQTFY_YF_SR.Text
                    .txtQTFY_YF_ZC = Me.txtQTFY_YF_ZC.Text
                    .txtQTFY_YF_YE = Me.txtQTFY_YF_YE.Text
                    .txtQTFY_HT_SR = Me.txtQTFY_HT_SR.Text
                    .txtQTFY_HT_ZC = Me.txtQTFY_HT_ZC.Text
                    .txtQTFY_HT_YE = Me.txtQTFY_HT_YE.Text

                    .txtZKSH_YJKS = Me.txtZKSH_YJKS.Text
                    .txtZKSH_YJZZ = Me.txtZKSH_YJZZ.Text
                    .txtZKSH_EJKS = Me.txtZKSH_EJKS.Text
                    .txtZKSH_EJZZ = Me.txtZKSH_EJZZ.Text
                    .txtZKSH_SJKS = Me.txtZKSH_SJKS.Text
                    .txtZKSH_SJZZ = Me.txtZKSH_SJZZ.Text

                    .txtZKSH_SFBZ = Me.txtZKSH_SFBZ.Text
                    .txtZKSH_HTYS = Me.txtZKSH_HTYS.Text
                    .txtZKSH_HTZK = Me.txtZKSH_HTZK.Text
                    .txtZKSH_LJSS = Me.txtZKSH_LJSS.Text
                    .txtZKSH_YE = Me.txtZKSH_YE.Text
                    .txtZKSH_YJSH = Me.txtZKSH_YJSH.Text
                    .txtZKSH_EJSH = Me.txtZKSH_EJSH.Text
                    .txtZKSH_SJSH = Me.txtZKSH_SJSH.Text
                    .txtZKSH_BZXX = Me.txtZKSH_BZXX.Text
                    .rblZKSH_JA_SelectedIndex = Me.rblZKSH_JA.SelectedIndex
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
                Dim objIEstateEsHetongZksh As Josco.JSOA.BusinessFacade.IEstateEsHetongZksh = Nothing
                Try
                    objIEstateEsHetongZksh = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongZksh)
                Catch ex As Exception
                    objIEstateEsHetongZksh = Nothing
                End Try
                If Not (objIEstateEsHetongZksh Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongZksh.SafeRelease(objIEstateEsHetongZksh)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsHetongJssList As Josco.JSOA.BusinessFacade.IEstateEsHetongJssList = Nothing
                Try
                    objIEstateEsHetongJssList = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongJssList)
                Catch ex As Exception
                    objIEstateEsHetongJssList = Nothing
                End Try
                If Not (objIEstateEsHetongJssList Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongJssList.SafeRelease(objIEstateEsHetongJssList)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateCwSssfSh As Josco.JSOA.BusinessFacade.IEstateCwSssfSh = Nothing
                Try
                    objIEstateCwSssfSh = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateCwSssfSh)
                Catch ex As Exception
                    objIEstateCwSssfSh = Nothing
                End Try
                If Not (objIEstateCwSssfSh Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateCwSssfSh.SafeRelease(objIEstateCwSssfSh)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateCwSssf As Josco.JSOA.BusinessFacade.IEstateCwSssf = Nothing
                Try
                    objIEstateCwSssf = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateCwSssf)
                Catch ex As Exception
                    objIEstateCwSssf = Nothing
                End Try
                If Not (objIEstateCwSssf Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateCwSssf.SafeRelease(objIEstateCwSssf)
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateCwSztz)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateCwSztz)
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

                Me.m_strQuery_ZJF = Me.htxtZJFQuery.Value
                Me.m_intRows_ZJF = objPulicParameters.getObjectValue(Me.htxtZJFRows.Value, 0)
                Me.m_intFixedColumns_ZJF = objPulicParameters.getObjectValue(Me.htxtZJFFixed.Value, 0)

                Me.m_strQuery_FK = Me.htxtFKQuery.Value
                Me.m_intRows_FK = objPulicParameters.getObjectValue(Me.htxtFKRows.Value, 0)
                Me.m_intFixedColumns_FK = objPulicParameters.getObjectValue(Me.htxtFKFixed.Value, 0)

                Me.m_strQuery_QTFY = Me.htxtQTFYQuery.Value
                Me.m_intRows_QTFY = objPulicParameters.getObjectValue(Me.htxtQTFYRows.Value, 0)
                Me.m_intFixedColumns_QTFY = objPulicParameters.getObjectValue(Me.htxtQTFYFixed.Value, 0)
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
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub














        '----------------------------------------------------------------
        ' ��ȡgrdZJFҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_ZJF( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu

            getModuleData_ZJF = False

            Try
                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtZJFSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(Me.m_objDataSet_ZJF)

                '�̶���������
                Dim strSFDM As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM
                Dim strWhere As String = ""
                strWhere = "(" + strSFDM + " = '" + Josco.JsKernal.Common.jsoaConfiguration.ES_SFDM_ZJF_TOP + "'"
                strWhere = strWhere + " or " + strSFDM + " like '" + Josco.JsKernal.Common.jsoaConfiguration.ES_SFDM_ZJF_TOP + ".%')"

                '���¼�������
                If objsystemEstateCaiwu.getDataSet_ES_SSSF(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_ZJF) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_ZJF.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_ZJF.Tables(strTable)
                    Me.htxtZJFRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_ZJF = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)

            getModuleData_ZJF = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdFKҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_FK( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu

            getModuleData_FK = False

            Try
                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtFKSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(Me.m_objDataSet_FK)

                '�̶���������
                Dim strSFDM As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM
                Dim strWhere As String = ""
                strWhere = "(" + strSFDM + " = '" + Josco.JsKernal.Common.jsoaConfiguration.ES_SFDM_FK_TOP + "'"
                strWhere = strWhere + " or " + strSFDM + " like '" + Josco.JsKernal.Common.jsoaConfiguration.ES_SFDM_FK_TOP + ".%')"

                '���¼�������
                If objsystemEstateCaiwu.getDataSet_ES_SSSF(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_FK) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_FK.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_FK.Tables(strTable)
                    Me.htxtFKRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_FK = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)

            getModuleData_FK = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdQTFYҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_QTFY( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu

            getModuleData_QTFY = False

            Try
                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtQTFYSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(Me.m_objDataSet_QTFY)

                '�̶���������
                Dim strSFDM As String = "a." + Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM
                Dim strWhere As String = ""
                strWhere = "not ((" + strSFDM + " = '" + Josco.JsKernal.Common.jsoaConfiguration.ES_SFDM_FK_TOP + "'"
                strWhere = strWhere + " or " + strSFDM + " like '" + Josco.JsKernal.Common.jsoaConfiguration.ES_SFDM_FK_TOP + ".%')"
                strWhere = strWhere + " or (" + strSFDM + " = '" + Josco.JsKernal.Common.jsoaConfiguration.ES_SFDM_ZJF_TOP + "'"
                strWhere = strWhere + " or " + strSFDM + " like '" + Josco.JsKernal.Common.jsoaConfiguration.ES_SFDM_ZJF_TOP + ".%'))"

                '���¼�������
                If objsystemEstateCaiwu.getDataSet_ES_SSSF(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_QTFY) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_QTFY.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_QTFY.Tables(strTable)
                    Me.htxtQTFYRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_QTFY = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)

            getModuleData_QTFY = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Exit Function

        End Function














        '----------------------------------------------------------------
        ' ��ʾgrdZJF������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_ZJF( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_ZJF = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtZJFSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtZJFSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_ZJF Is Nothing Then
                    Me.grdZJF.DataSource = Nothing
                Else
                    With Me.m_objDataSet_ZJF.Tables(strTable)
                        Me.grdZJF.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_ZJF.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdZJF, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdZJF)
                    With Me.grdZJF.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdZJF.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdZJF, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_ZJF) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_ZJF = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdFK������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_FK( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_FK = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtFKSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtFKSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_FK Is Nothing Then
                    Me.grdFK.DataSource = Nothing
                Else
                    With Me.m_objDataSet_FK.Tables(strTable)
                        Me.grdFK.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_FK.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdFK, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdFK)
                    With Me.grdFK.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdFK.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdFK, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_FK) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_FK = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdQTFY������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_QTFY( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_QTFY = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtQTFYSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtQTFYSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_QTFY Is Nothing Then
                    Me.grdQTFY.DataSource = Nothing
                Else
                    With Me.m_objDataSet_QTFY.Tables(strTable)
                        Me.grdQTFY.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_QTFY.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdQTFY, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdQTFY)
                    With Me.grdQTFY.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdQTFY.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdQTFY, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_QTFY) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_QTFY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾZJF��ص�ȫ����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_ZJF( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_ZJF = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_ZJF(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ��������
                Dim strSFDM As String = Josco.JsKernal.Common.jsoaConfiguration.ES_SFDM_ZJF_TOP
                Dim dblZJF_JF(2) As Double
                Dim dblZJF_YF(2) As Double
                Dim dblZJF_HT(2) As Double
                If objsystemEstateCaiwu.getHetongBeiyongjin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_S, strSFDM, dblZJF_JF(0), dblZJF_YF(0)) = False Then
                    GoTo errProc
                End If
                If objsystemEstateCaiwu.getHetongBeiyongjin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_F, strSFDM, dblZJF_JF(1), dblZJF_YF(1)) = False Then
                    GoTo errProc
                End If
                '****************************************************
                dblZJF_JF(2) = dblZJF_JF(0) - dblZJF_JF(1)
                dblZJF_YF(2) = dblZJF_YF(0) - dblZJF_YF(1)
                '****************************************************
                dblZJF_HT(0) = dblZJF_JF(0) + dblZJF_YF(0)
                dblZJF_HT(1) = dblZJF_JF(1) + dblZJF_YF(1)
                dblZJF_HT(2) = dblZJF_JF(2) + dblZJF_YF(2)
                '****************************************************
                Me.txtZJF_JF_SR.Text = dblZJF_JF(0).ToString("#,###.00")
                Me.txtZJF_JF_ZC.Text = dblZJF_JF(1).ToString("#,###.00")
                Me.txtZJF_JF_YE.Text = dblZJF_JF(2).ToString("#,###.00")
                '****************************************************
                Me.txtZJF_YF_SR.Text = dblZJF_YF(0).ToString("#,###.00")
                Me.txtZJF_YF_ZC.Text = dblZJF_YF(1).ToString("#,###.00")
                Me.txtZJF_YF_YE.Text = dblZJF_YF(2).ToString("#,###.00")
                '****************************************************
                Me.txtZJF_HT_SR.Text = dblZJF_HT(0).ToString("#,###.00")
                Me.txtZJF_HT_ZC.Text = dblZJF_HT(1).ToString("#,###.00")
                Me.txtZJF_HT_YE.Text = dblZJF_HT(2).ToString("#,###.00")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_ZJF = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾFK��ص�ȫ����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_FK( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_FK = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_FK(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ��������
                Dim strSFDM As String = Josco.JsKernal.Common.jsoaConfiguration.ES_SFDM_FK_TOP
                Dim dblFK_JF(2) As Double
                Dim dblFK_YF(2) As Double
                Dim dblFK_HT(2) As Double
                If objsystemEstateCaiwu.getHetongBeiyongjin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_S, strSFDM, dblFK_JF(0), dblFK_YF(0)) = False Then
                    GoTo errProc
                End If
                If objsystemEstateCaiwu.getHetongBeiyongjin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_F, strSFDM, dblFK_JF(1), dblFK_YF(1)) = False Then
                    GoTo errProc
                End If
                '****************************************************
                dblFK_JF(2) = dblFK_JF(0) - dblFK_JF(1)
                dblFK_YF(2) = dblFK_YF(0) - dblFK_YF(1)
                '****************************************************
                dblFK_HT(0) = dblFK_JF(0) + dblFK_YF(0)
                dblFK_HT(1) = dblFK_JF(1) + dblFK_YF(1)
                dblFK_HT(2) = dblFK_JF(2) + dblFK_YF(2)
                '****************************************************
                Me.txtFK_JF_SR.Text = dblFK_JF(0).ToString("#,###.00")
                Me.txtFK_JF_ZC.Text = dblFK_JF(1).ToString("#,###.00")
                Me.txtFK_JF_YE.Text = dblFK_JF(2).ToString("#,###.00")
                '****************************************************
                Me.txtFK_YF_SR.Text = dblFK_YF(0).ToString("#,###.00")
                Me.txtFK_YF_ZC.Text = dblFK_YF(1).ToString("#,###.00")
                Me.txtFK_YF_YE.Text = dblFK_YF(2).ToString("#,###.00")
                '****************************************************
                Me.txtFK_HT_SR.Text = dblFK_HT(0).ToString("#,###.00")
                Me.txtFK_HT_ZC.Text = dblFK_HT(1).ToString("#,###.00")
                Me.txtFK_HT_YE.Text = dblFK_HT(2).ToString("#,###.00")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_FK = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾQTFY��ص�ȫ����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_QTFY( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_QTFY = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_QTFY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ��������
                Dim strSFDM As String = Josco.JsKernal.Common.jsoaConfiguration.ES_SFDM_FK_TOP
                strSFDM = strSFDM + Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate + Josco.JsKernal.Common.jsoaConfiguration.ES_SFDM_ZJF_TOP
                Dim dblQTFY_JF(2) As Double
                Dim dblQTFY_YF(2) As Double
                Dim dblQTFY_HT(2) As Double
                If objsystemEstateCaiwu.getHetongBeiyongjin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_S, strSFDM, True, dblQTFY_JF(0), dblQTFY_YF(0)) = False Then
                    GoTo errProc
                End If
                If objsystemEstateCaiwu.getHetongBeiyongjin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_F, strSFDM, True, dblQTFY_JF(1), dblQTFY_YF(1)) = False Then
                    GoTo errProc
                End If
                '****************************************************
                dblQTFY_JF(2) = dblQTFY_JF(0) - dblQTFY_JF(1)
                dblQTFY_YF(2) = dblQTFY_YF(0) - dblQTFY_YF(1)
                '****************************************************
                dblQTFY_HT(0) = dblQTFY_JF(0) + dblQTFY_YF(0)
                dblQTFY_HT(1) = dblQTFY_JF(1) + dblQTFY_YF(1)
                dblQTFY_HT(2) = dblQTFY_JF(2) + dblQTFY_YF(2)
                '****************************************************
                Me.txtQTFY_JF_SR.Text = dblQTFY_JF(0).ToString("#,###.00")
                Me.txtQTFY_JF_ZC.Text = dblQTFY_JF(1).ToString("#,###.00")
                Me.txtQTFY_JF_YE.Text = dblQTFY_JF(2).ToString("#,###.00")
                '****************************************************
                Me.txtQTFY_YF_SR.Text = dblQTFY_YF(0).ToString("#,###.00")
                Me.txtQTFY_YF_ZC.Text = dblQTFY_YF(1).ToString("#,###.00")
                Me.txtQTFY_YF_YE.Text = dblQTFY_YF(2).ToString("#,###.00")
                '****************************************************
                Me.txtQTFY_HT_SR.Text = dblQTFY_HT(0).ToString("#,###.00")
                Me.txtQTFY_HT_ZC.Text = dblQTFY_HT(1).ToString("#,###.00")
                Me.txtQTFY_HT_YE.Text = dblQTFY_HT(2).ToString("#,###.00")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_QTFY = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
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
        ' ��ʾ�������������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_Main( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objestateErshouData As Josco.JSOA.Common.Data.estateErshouData
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_Main = False

            Try
                '��ʾ�ۿ����ǩ��
                Dim intSHLX As Integer = 0
                Dim strSHQM As String = ""
                Me.txtZKSH_YJSH.Text = ""
                Me.txtZKSH_EJSH.Text = ""
                Me.txtZKSH_SJSH.Text = ""
                If strQRSH <> "" Then
                    intSHLX = Josco.JSOA.Common.Data.estateErshouData.enumZhekouShenheType.YJ
                    If objsystemEstateErshou.getHetongZhekouSHQM(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, intSHLX, strSHQM) = False Then
                        GoTo errProc
                    End If
                    Me.txtZKSH_YJSH.Text = strSHQM
                    intSHLX = Josco.JSOA.Common.Data.estateErshouData.enumZhekouShenheType.EJ
                    If objsystemEstateErshou.getHetongZhekouSHQM(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, intSHLX, strSHQM) = False Then
                        GoTo errProc
                    End If
                    Me.txtZKSH_EJSH.Text = strSHQM
                    intSHLX = Josco.JSOA.Common.Data.estateErshouData.enumZhekouShenheType.SJ
                    If objsystemEstateErshou.getHetongZhekouSHQM(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, intSHLX, strSHQM) = False Then
                        GoTo errProc
                    End If
                    Me.txtZKSH_SJSH.Text = strSHQM
                End If

                '��ʾ�ۿ����ޡ�����
                Dim dblSX As Double = 0
                Dim dblXX As Double = 0
                intSHLX = Josco.JSOA.Common.Data.estateErshouData.enumZhekouShenheType.YJ
                If objsystemEstateErshou.getHetongZhekouSXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, intSHLX, dblSX, dblXX) = False Then
                    GoTo errProc
                End If
                Me.txtZKSH_YJKS.Text = (dblSX * 100).ToString("#.00")
                Me.txtZKSH_YJZZ.Text = (dblXX * 100).ToString("#.00")
                intSHLX = Josco.JSOA.Common.Data.estateErshouData.enumZhekouShenheType.EJ
                If objsystemEstateErshou.getHetongZhekouSXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, intSHLX, dblSX, dblXX) = False Then
                    GoTo errProc
                End If
                Me.txtZKSH_EJKS.Text = (dblSX * 100).ToString("#.00")
                Me.txtZKSH_EJZZ.Text = (dblXX * 100).ToString("#.00")
                intSHLX = Josco.JSOA.Common.Data.estateErshouData.enumZhekouShenheType.SJ
                If objsystemEstateErshou.getHetongZhekouSXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, intSHLX, dblSX, dblXX) = False Then
                    GoTo errProc
                End If
                Me.txtZKSH_SJKS.Text = (dblSX * 100).ToString("#.00")
                Me.txtZKSH_SJZZ.Text = (dblXX * 100).ToString("#.00")

                '��ͬ�᰸��
                Dim blnComplete As Boolean = False
                Me.rblZKSH_JA.SelectedIndex = -1
                If strQRSH <> "" Then
                    If objsystemEstateErshou.isHetongComplete(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, blnComplete) = False Then
                        GoTo errProc
                    End If
                    If blnComplete = True Then
                        Me.rblZKSH_JA.SelectedIndex = 1
                    Else
                        Me.rblZKSH_JA.SelectedIndex = 0
                    End If
                End If

                '��ʾ��ͬ��Ϣ
                Me.txtZKSH_SFBZ.Text = ""
                Me.txtZKSH_HTYS.Text = ""
                Me.txtZKSH_HTZK.Text = ""
                Me.txtZKSH_LJSS.Text = ""
                Me.txtZKSH_YE.Text = ""
                Me.txtZKSH_BZXX.Text = ""
                Dim dblJYJE As Double = 0.0
                Dim dblJYZK As Double = 0.0
                Dim dblJSZE As Double = 0.0
                Dim dblDLF As Double = 0.0

                '===============================================================================================================
                'zengxianglin 2008-11-18
                Dim strYWLX As String = ""
                '����ҵ������
                If objsystemEstateErshou.getYWLX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strYWLX) = False Then
                    GoTo errProc
                End If
                Select Case strYWLX
                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_MM
                        '����ҵ��
                        If objsystemEstateErshou.getDataSet_ES_QRS_MM(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, "", objestateErshouData) = False Then
                            GoTo errProc
                        End If
                        With objestateErshouData.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_MM)
                            If .Rows.Count > 0 Then
                                dblJYJE = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JYZJG), 0.0)
                                dblJYZK = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_DLFZK), 0.0)
                                dblDLF = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_JFDLF), 0.0)
                                dblDLF += objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_MM_YFDLF), 0.0)
                                Me.txtZKSH_SFBZ.Text = (dblJYJE * Josco.JsKernal.Common.jsoaConfiguration.ES_ZJFJFBZ_MM).ToString("#,###.00")
                                Me.txtZKSH_HTZK.Text = (dblJYZK * 100).ToString("#.00")
                                Me.txtZKSH_HTYS.Text = (dblDLF * dblJYZK).ToString("#,###.00")
                            End If
                        End With
                        If objsystemEstateErshou.getHetongJiesuanSum(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, dblJSZE) = False Then
                            GoTo errProc
                        End If
                        Me.txtZKSH_LJSS.Text = dblJSZE.ToString("#,###.00")
                        Me.txtZKSH_YE.Text = (dblDLF * dblJYZK - dblJSZE).ToString("#,###.00")

                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_ZL
                        '����ҵ��
                        If objsystemEstateErshou.getDataSet_ES_QRS_ZL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, "", objestateErshouData) = False Then
                            GoTo errProc
                        End If
                        With objestateErshouData.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_ZL)
                            If .Rows.Count > 0 Then
                                dblJYJE = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JYYZJ), 0.0)
                                dblJYZK = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DLFZK), 0.0)
                                dblDLF = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFDLF), 0.0)
                                dblDLF += objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFDLF), 0.0)
                                Me.txtZKSH_SFBZ.Text = (dblJYJE * Josco.JsKernal.Common.jsoaConfiguration.ES_ZJFJFBZ_ZL).ToString("#,###.00")
                                Me.txtZKSH_HTZK.Text = (dblJYZK * 100).ToString("#.00")
                                Me.txtZKSH_HTYS.Text = (dblDLF * dblJYZK).ToString("#,###.00")
                            End If
                        End With
                        If objsystemEstateErshou.getHetongJiesuanSum(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, dblJSZE) = False Then
                            GoTo errProc
                        End If
                        Me.txtZKSH_LJSS.Text = dblJSZE.ToString("#,###.00")
                        Me.txtZKSH_YE.Text = (dblDLF * dblJYZK - dblJSZE).ToString("#,###.00")

                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_QT
                        '����ҵ��
                        If objsystemEstateErshou.getDataSet_ES_QRS_QT(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, "", objestateErshouData) = False Then
                            GoTo errProc
                        End If
                        With objestateErshouData.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_QT)
                            If .Rows.Count > 0 Then
                                dblJYJE = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JYZJG), 0.0)
                                dblJYZK = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_DLFZK), 0.0)
                                dblDLF = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_JFDLF), 0.0)
                                dblDLF += objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_QT_YFDLF), 0.0)
                                Me.txtZKSH_SFBZ.Text = (dblJYJE * Josco.JsKernal.Common.jsoaConfiguration.ES_ZJFJFBZ_QT).ToString("#,###.00")
                                Me.txtZKSH_HTZK.Text = (dblJYZK * 100).ToString("#.00")
                                Me.txtZKSH_HTYS.Text = (dblDLF * dblJYZK).ToString("#,###.00")
                            End If
                        End With
                        If objsystemEstateErshou.getHetongJiesuanSum(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, dblJSZE) = False Then
                            GoTo errProc
                        End If
                        Me.txtZKSH_LJSS.Text = dblJSZE.ToString("#,###.00")
                        Me.txtZKSH_YE.Text = (dblDLF * dblJYZK - dblJSZE).ToString("#,###.00")

                    Case Else
                End Select
                'zengxianglin 2008-11-18
                '===============================================================================================================

                '��ʾ����
                Me.btnJSQK.Visible = (Me.m_strQRSH <> "")
                Me.btnSJSZ.Visible = (Me.m_strQRSH <> "")
                Me.btnSZSH.Visible = (Me.m_strQRSH <> "")
                Me.btnZKSH.Visible = (Me.m_strQRSH <> "")
                'zengxianglin 2010-12-29
                Me.btnPLSH.Visible = (Me.m_strQRSH <> "") And Me.m_blnPrevilegeParams(2)
                'zengxianglin 2010-12-29
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objestateErshouData)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_Main = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JSOA.BusinessFacade.systemEstateCaiwu.SafeRelease(objsystemEstateCaiwu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objestateErshouData)
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
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtZJF_JF_SR)
                    objControlProcess.doTranslateKey(Me.txtZJF_JF_ZC)
                    objControlProcess.doTranslateKey(Me.txtZJF_JF_YE)
                    objControlProcess.doTranslateKey(Me.txtZJF_YF_SR)
                    objControlProcess.doTranslateKey(Me.txtZJF_YF_ZC)
                    objControlProcess.doTranslateKey(Me.txtZJF_YF_YE)
                    objControlProcess.doTranslateKey(Me.txtZJF_HT_SR)
                    objControlProcess.doTranslateKey(Me.txtZJF_HT_ZC)
                    objControlProcess.doTranslateKey(Me.txtZJF_HT_YE)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtFK_JF_SR)
                    objControlProcess.doTranslateKey(Me.txtFK_JF_ZC)
                    objControlProcess.doTranslateKey(Me.txtFK_JF_YE)
                    objControlProcess.doTranslateKey(Me.txtFK_YF_SR)
                    objControlProcess.doTranslateKey(Me.txtFK_YF_ZC)
                    objControlProcess.doTranslateKey(Me.txtFK_YF_YE)
                    objControlProcess.doTranslateKey(Me.txtFK_HT_SR)
                    objControlProcess.doTranslateKey(Me.txtFK_HT_ZC)
                    objControlProcess.doTranslateKey(Me.txtFK_HT_YE)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtQTFY_JF_SR)
                    objControlProcess.doTranslateKey(Me.txtQTFY_JF_ZC)
                    objControlProcess.doTranslateKey(Me.txtQTFY_JF_YE)
                    objControlProcess.doTranslateKey(Me.txtQTFY_YF_SR)
                    objControlProcess.doTranslateKey(Me.txtQTFY_YF_ZC)
                    objControlProcess.doTranslateKey(Me.txtQTFY_YF_YE)
                    objControlProcess.doTranslateKey(Me.txtQTFY_HT_SR)
                    objControlProcess.doTranslateKey(Me.txtQTFY_HT_ZC)
                    objControlProcess.doTranslateKey(Me.txtQTFY_HT_YE)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtJYBH)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtZKSH_YJKS)
                    objControlProcess.doTranslateKey(Me.txtZKSH_YJZZ)
                    objControlProcess.doTranslateKey(Me.txtZKSH_EJKS)
                    objControlProcess.doTranslateKey(Me.txtZKSH_EJZZ)
                    objControlProcess.doTranslateKey(Me.txtZKSH_SJKS)
                    objControlProcess.doTranslateKey(Me.txtZKSH_SJZZ)
                    '***************************************************************
                    objControlProcess.doTranslateKey(Me.txtZKSH_SFBZ)
                    objControlProcess.doTranslateKey(Me.txtZKSH_HTYS)
                    objControlProcess.doTranslateKey(Me.txtZKSH_HTZK)
                    objControlProcess.doTranslateKey(Me.txtZKSH_LJSS)
                    objControlProcess.doTranslateKey(Me.txtZKSH_YE)
                    objControlProcess.doTranslateKey(Me.txtZKSH_YJSH)
                    objControlProcess.doTranslateKey(Me.txtZKSH_EJSH)
                    objControlProcess.doTranslateKey(Me.txtZKSH_SJSH)
                    objControlProcess.doTranslateKey(Me.txtZKSH_BZXX)

                    '��ʾ��������
                    If Me.showJiaoyiInfo(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If

                    '��ʾ����
                    If Me.getModuleData_ZJF(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_ZJF(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_FK(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_FK(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_QTFY(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_QTFY(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_Main(strErrMsg, Me.m_strQRSH) = False Then
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
        Sub grdZJF_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdZJF.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_ZJF + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_ZJF > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_ZJF - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdZJF.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Sub grdFK_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdFK.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_FK + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_FK > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_FK - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdFK.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Sub grdQTFY_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdQTFY.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_QTFY + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_QTFY > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_QTFY - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdQTFY.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdZJF_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdZJF.SortCommand

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
                If Me.getModuleData_ZJF(strErrMsg, Me.m_strQRSH) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                With Me.m_objDataSet_ZJF.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                With Me.m_objDataSet_ZJF.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtZJFSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtZJFSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtZJFSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_ZJF(strErrMsg, Me.m_strQRSH) = False Then
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

        Private Sub grdFK_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdFK.SortCommand

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
                If Me.getModuleData_FK(strErrMsg, Me.m_strQRSH) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                With Me.m_objDataSet_FK.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                With Me.m_objDataSet_FK.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtFKSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtFKSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtFKSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_FK(strErrMsg, Me.m_strQRSH) = False Then
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

        Private Sub grdQTFY_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdQTFY.SortCommand

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
                If Me.getModuleData_QTFY(strErrMsg, Me.m_strQRSH) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                With Me.m_objDataSet_QTFY.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                With Me.m_objDataSet_QTFY.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtQTFYSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtQTFYSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtQTFYSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_QTFY(strErrMsg, Me.m_strQRSH) = False Then
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

        Private Sub btnSelect_JYBH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_JYBH.Click
            Me.doSelect_JYBH("btnSelect_JYBH")
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

        Private Sub doOpen_SSSF(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.m_strQRSH = "" Then
                    strErrMsg = "����û��ָ��[ȷ�����]��"
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
                Dim objIEstateCwSssf As Josco.JSOA.BusinessFacade.IEstateCwSssf = Nothing
                Dim strUrl As String = ""
                objIEstateCwSssf = New Josco.JSOA.BusinessFacade.IEstateCwSssf
                With objIEstateCwSssf
                    .iQRSH = Me.m_strQRSH
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
                Session.Add(strNewSessionId, objIEstateCwSssf)

                strUrl = ""
                strUrl += "estate_cw_sssf.aspx"
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

        Private Sub doOpen_CWSH(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.m_strQRSH = "" Then
                    strErrMsg = "����û��ָ��[ȷ�����]��"
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
                Dim objIEstateCwSssfSh As Josco.JSOA.BusinessFacade.IEstateCwSssfSh = Nothing
                Dim strUrl As String = ""
                objIEstateCwSssfSh = New Josco.JSOA.BusinessFacade.IEstateCwSssfSh
                With objIEstateCwSssfSh
                    .iQRSH = Me.m_strQRSH
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
                Session.Add(strNewSessionId, objIEstateCwSssfSh)

                strUrl = ""
                strUrl += "estate_cw_sssf_sh.aspx"
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

        Private Sub doOpen_JSQK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.m_strQRSH = "" Then
                    strErrMsg = "����û��ָ��[ȷ�����]��"
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
                Dim objIEstateEsHetongJssList As Josco.JSOA.BusinessFacade.IEstateEsHetongJssList = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongJssList = New Josco.JSOA.BusinessFacade.IEstateEsHetongJssList
                With objIEstateEsHetongJssList
                    .iQRSH = Me.m_strQRSH
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
                Session.Add(strNewSessionId, objIEstateEsHetongJssList)

                strUrl = ""
                strUrl += "../ershou/estate_es_hetong_jss_list.aspx"
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

        Private Sub doOpen_ZKSH(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.m_strQRSH = "" Then
                    strErrMsg = "����û��ָ��[ȷ�����]��"
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
                Dim objIEstateEsHetongZksh As Josco.JSOA.BusinessFacade.IEstateEsHetongZksh = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongZksh = New Josco.JSOA.BusinessFacade.IEstateEsHetongZksh
                With objIEstateEsHetongZksh
                    .iQRSH = Me.m_strQRSH
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
                Session.Add(strNewSessionId, objIEstateEsHetongZksh)

                strUrl = ""
                strUrl += "../ershou/estate_es_hetong_zksh.aspx"
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

        'zengxianglin 2010-12-29 ����
        Private Sub doPLSH(ByVal strControlId As String)

            Dim objNewData As System.Collections.Specialized.NameValueCollection = Nothing
            Dim objsystemEstateCaiwu As New Josco.JSOA.BusinessFacade.systemEstateCaiwu
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer = 0

            Try
                intStep = 1
                '���ѡ��
                Dim intSelected As Integer = 0
                Dim intColIndex(9) As Integer
                Dim strValue As String = ""
                Dim strWYBS As String = ""
                Dim i As Integer
                For i = 0 To Me.grdFK.Items.Count - 1 Step 1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdFK.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FK) = True Then
                        intSelected = intSelected + 1
                    End If
                Next
                For i = 0 To Me.grdZJF.Items.Count - 1 Step 1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdZJF.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_ZJF) = True Then
                        intSelected = intSelected + 1
                    End If
                Next
                For i = 0 To Me.grdQTFY.Items.Count - 1 Step 1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdQTFY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_QTFY) = True Then
                        intSelected = intSelected + 1
                    End If
                Next
                If intSelected < 1 Then
                    strErrMsg = "����û��ѡ���κο���(ѡ������[����]��[�н��]��[��������]���ĵ�1�еķ����д�)��"
                    GoTo errProc
                End If

                'ȷ��
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "���棺��ȷ��ѡ����[" + intSelected.ToString + "]�ʿ������������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '�ش��ǡ�
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intSelected = 0
                    '׼������
                    objNewData = New System.Collections.Specialized.NameValueCollection
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS, "")
                    objNewData.Add(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH, "")

                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdFK, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSH)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdFK, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS)
                    intColIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdFK, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH)

                    intColIndex(3) = objDataGridProcess.getDataGridColumnIndex(Me.grdZJF, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSH)
                    intColIndex(4) = objDataGridProcess.getDataGridColumnIndex(Me.grdZJF, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS)
                    intColIndex(5) = objDataGridProcess.getDataGridColumnIndex(Me.grdZJF, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH)

                    intColIndex(6) = objDataGridProcess.getDataGridColumnIndex(Me.grdQTFY, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSH)
                    intColIndex(7) = objDataGridProcess.getDataGridColumnIndex(Me.grdQTFY, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS)
                    intColIndex(8) = objDataGridProcess.getDataGridColumnIndex(Me.grdQTFY, Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH)

                    For i = 0 To Me.grdFK.Items.Count - 1 Step 1
                        strValue = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdFK.Items(i), intColIndex(0)), "")
                        If strValue = "" Then
                            strValue = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdFK.Items(i), intColIndex(1)), "")
                            objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS) = strValue
                            strWYBS = strValue
                            strValue = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdFK.Items(i), intColIndex(2)), "")
                            objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH) = strValue
                            If objsystemEstateCaiwu.doShenhe_ES_SSSF(strErrMsg, MyBase.UserId, MyBase.UserPassword, True, objNewData) = False Then
                                GoTo errProc
                            End If
                            intSelected += 1
                        End If
                    Next

                    For i = 0 To Me.grdZJF.Items.Count - 1 Step 1
                        strValue = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdZJF.Items(i), intColIndex(3)), "")
                        If strValue = "" Then
                            strValue = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdZJF.Items(i), intColIndex(4)), "")
                            objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS) = strValue
                            strWYBS = strValue
                            strValue = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdZJF.Items(i), intColIndex(5)), "")
                            objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH) = strValue
                            If objsystemEstateCaiwu.doShenhe_ES_SSSF(strErrMsg, MyBase.UserId, MyBase.UserPassword, True, objNewData) = False Then
                                GoTo errProc
                            End If
                            intSelected += 1
                        End If
                    Next

                    For i = 0 To Me.grdQTFY.Items.Count - 1 Step 1
                        strValue = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdQTFY.Items(i), intColIndex(6)), "")
                        If strValue = "" Then
                            strValue = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdQTFY.Items(i), intColIndex(7)), "")
                            objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS) = strValue
                            strWYBS = strValue
                            strValue = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdQTFY.Items(i), intColIndex(8)), "")
                            objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH) = strValue
                            If objsystemEstateCaiwu.doShenhe_ES_SSSF(strErrMsg, MyBase.UserId, MyBase.UserPassword, True, objNewData) = False Then
                                GoTo errProc
                            End If
                            intSelected += 1
                        End If
                    Next

                    'ˢ����ʾ
                    If Me.getModuleData_FK(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_FK(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_ZJF(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_ZJF(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_QTFY(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_QTFY(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If

                    '��ʾ�ɹ�
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ���ɹ���[" + intSelected.ToString + "]�ʿ��")
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

        Private Sub btnSJSZ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSJSZ.Click
            Me.doOpen_SSSF("btnSJSZ")
        End Sub

        Private Sub btnSZSH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSZSH.Click
            Me.doOpen_CWSH("btnSZSH")
        End Sub

        Private Sub btnJSQK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJSQK.Click
            Me.doOpen_JSQK("btnJSQK")
        End Sub

        Private Sub btnZKSH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnZKSH.Click
            Me.doOpen_ZKSH("btnZKSH")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnPLSH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPLSH.Click
            Me.doPLSH("btnPLSH")
        End Sub

    End Class

End Namespace

