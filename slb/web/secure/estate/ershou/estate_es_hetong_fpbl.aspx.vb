Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_es_hetong_fpbl
    ' 
    ' �������ʣ�
    '     I/O
    '
    ' ���������� 
    '   ������ͬ�����������������ģ��
    ' 
    ' ���ļ�¼��
    '     zengxianglin 2010-01-06 ����
    '     zengxianglin 2010-03-22 ����
    '----------------------------------------------------------------

    Partial Class estate_es_hetong_fpbl
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        'zengxianglin 2010-01-06
        'zengxianglin 2010-01-06
        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14



        'zengxianglin 2010-01-06
        'zengxianglin 2010-01-06
        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14





        'zengxianglin 2010-03-22
        'zengxianglin 2010-03-22

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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsHetongFpbl
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsHetongFpbl
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdSYBL��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_SYBL As String = "chkSYBL"
        Private Const m_cstrDataGridInDIV_SYBL As String = "divSYBL"
        Private m_intFixedColumns_SYBL As Integer

        '----------------------------------------------------------------
        '����������grdGYBL��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_GYBL As String = "chkGYBL"
        Private Const m_cstrDataGridInDIV_GYBL As String = "divGYBL"
        Private m_intFixedColumns_GYBL As Integer

        '----------------------------------------------------------------
        '��ǰ��������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet_SYBL As Josco.JSOA.Common.Data.estateErshouData
        Private m_objDataSet_GYBL As Josco.JSOA.Common.Data.estateErshouData

        '----------------------------------------------------------------
        '�ӿڲ���
        '----------------------------------------------------------------
        'zengxianglin 2009-02-24
        Private m_blnEnforcedEdit As Boolean
        'zengxianglin 2009-02-24
        Private m_strQRSH As String

        '----------------------------------------------------------------
        '����ģ��˽�ò���
        '----------------------------------------------------------------
        'zengxianglin 2008-11-22
        Private m_blnEditMode_GY As Boolean
        'zengxianglin 2008-11-22
        Private m_blnEditMode As Boolean
        'zengxianglin 2008-10-14
        Private m_strHTRQ As String
        'zengxianglin 2008-10-14

        Public ReadOnly Property propEditMode() As Boolean
            Get
                propEditMode = Me.m_blnEditMode
            End Get
        End Property

        'zengxianglin 2008-11-22
        Public ReadOnly Property propEditMode_GY() As Boolean
            Get
                propEditMode_GY = Me.m_blnEditMode_GY
            End Get
        End Property
        'zengxianglin 2008-11-22











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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsHetongFpbl)
                    Catch ex As Exception
                        Me.m_objInterface = Nothing
                    End Try
                Else
                    Me.m_objInterface = Nothing
                End If
                If Not (Me.m_objInterface Is Nothing) Then
                    '���÷��ز���
                    '���ص�����ģ�飬�����ӷ��ز���
                    Me.m_objInterface.oExitMode = False
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

            Dim strErrMsg As String = ""

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftMain.Value = .htxtDivLeftMain
                    Me.htxtDivTopMain.Value = .htxtDivTopMain
                    Me.htxtDivLeftSYBL.Value = .htxtDivLeftSYBL
                    Me.htxtDivTopSYBL.Value = .htxtDivTopSYBL
                    Me.htxtDivLeftGYBL.Value = .htxtDivLeftGYBL
                    Me.htxtDivTopGYBL.Value = .htxtDivTopGYBL

                    Me.htxtSY_RYDM.Value = .htxtSY_RYDM
                    Me.htxtSY_DWDM.Value = .htxtSY_DWDM
                    Me.txtSY_RYDM.Text = .txtSY_RYDM
                    Me.txtSY_DWDM.Text = .txtSY_DWDM
                    'zengxianglin 2010-01-06
                    Me.txtSY_TDBH.Text = .txtSY_TDBH
                    'zengxianglin 2010-01-06
                    Me.txtSY_FPBL.Text = .txtSY_FPBL
                    Me.ddlSY_ZJDM.SelectedIndex = .ddlSY_ZJDM_SelectedIndex
                    'zengxianglin 2008-10-14
                    Me.doFillSsfzList(strErrMsg, Me.ddlSY_SSFZ, Me.txtSY_DWDM.Text)
                    Try
                        Me.ddlSY_SSFZ.SelectedIndex = .ddlSY_SSFZ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    'zengxianglin 2008-10-14

                    Me.htxtGY_RYDM.Value = .htxtGY_RYDM
                    Me.htxtGY_DWDM.Value = .htxtGY_DWDM
                    Me.txtGY_RYDM.Text = .txtGY_RYDM
                    Me.txtGY_DWDM.Text = .txtGY_DWDM
                    'zengxianglin 2010-01-06
                    Me.txtGY_TDBH.Text = .txtGY_TDBH
                    'zengxianglin 2010-01-06
                    Me.txtGY_FPBL.Text = .txtGY_FPBL
                    Me.rblGY_ZGBZ.SelectedIndex = .rblGY_ZGBZ_SelectedIndex
                    Me.ddlGY_ZJDM.SelectedIndex = .ddlGY_ZJDM_SelectedIndex
                    'zengxianglin 2008-10-14
                    Me.doFillSsfzList(strErrMsg, Me.ddlGY_SSFZ, Me.txtGY_DWDM.Text)
                    Try
                        Me.ddlGY_SSFZ.SelectedIndex = .ddlGY_SSFZ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    'zengxianglin 2008-10-14

                    Try
                        Me.grdSYBL.PageSize = .grdSYBLPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSYBL.CurrentPageIndex = .grdSYBLCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSYBL.SelectedIndex = .grdSYBLSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtSessionIdSYBL.Value = .htxtSessionIdSYBL

                    Try
                        Me.grdGYBL.PageSize = .grdGYBLPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYBL.CurrentPageIndex = .grdGYBLCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYBL.SelectedIndex = .grdGYBLSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtSessionIdGYBL.Value = .htxtSessionIdGYBL
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsHetongFpbl

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftSYBL = Me.htxtDivLeftSYBL.Value
                    .htxtDivTopSYBL = Me.htxtDivTopSYBL.Value

                    .htxtSY_RYDM = Me.htxtSY_RYDM.Value
                    .htxtSY_DWDM = Me.htxtSY_DWDM.Value
                    .txtSY_RYDM = Me.txtSY_RYDM.Text
                    .txtSY_DWDM = Me.txtSY_DWDM.Text
                    'zengxianglin 2010-01-06
                    .txtSY_TDBH = Me.txtSY_TDBH.Text
                    'zengxianglin 2010-01-06
                    .txtSY_FPBL = Me.txtSY_FPBL.Text
                    .ddlSY_ZJDM_SelectedIndex = Me.ddlSY_ZJDM.SelectedIndex
                    'zengxianglin 2008-10-14
                    .ddlSY_SSFZ_SelectedIndex = Me.ddlSY_SSFZ.SelectedIndex
                    'zengxianglin 2008-10-14

                    .htxtGY_RYDM = Me.htxtGY_RYDM.Value
                    .htxtGY_DWDM = Me.htxtGY_DWDM.Value
                    .txtGY_RYDM = Me.txtGY_RYDM.Text
                    .txtGY_DWDM = Me.txtGY_DWDM.Text
                    'zengxianglin 2010-01-06
                    .txtGY_TDBH = Me.txtGY_TDBH.Text
                    'zengxianglin 2010-01-06
                    .txtGY_FPBL = Me.txtGY_FPBL.Text
                    .rblGY_ZGBZ_SelectedIndex = Me.rblGY_ZGBZ.SelectedIndex
                    .ddlGY_ZJDM_SelectedIndex = Me.ddlGY_ZJDM.SelectedIndex
                    'zengxianglin 2008-10-14
                    .ddlGY_SSFZ_SelectedIndex = Me.ddlGY_SSFZ.SelectedIndex
                    'zengxianglin 2008-10-14

                    .grdSYBLPageSize = Me.grdSYBL.PageSize
                    .grdSYBLCurrentPageIndex = Me.grdSYBL.CurrentPageIndex
                    .grdSYBLSelectedIndex = Me.grdSYBL.SelectedIndex
                    .htxtSessionIdSYBL = Me.htxtSessionIdSYBL.Value

                    .grdGYBLPageSize = Me.grdGYBL.PageSize
                    .grdGYBLCurrentPageIndex = Me.grdGYBL.CurrentPageIndex
                    .grdGYBLSelectedIndex = Me.grdGYBL.SelectedIndex
                    .htxtSessionIdGYBL = Me.htxtSessionIdGYBL.Value
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

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objRYJGXX As System.Collections.Specialized.NameValueCollection = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                'zengxianglin 2010-01-06
                '==========================================================================================================================================================
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Try
                    objIEstateRsXzTeam = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsXzTeam)
                Catch ex As Exception
                    objIEstateRsXzTeam = Nothing
                End Try
                If Not (objIEstateRsXzTeam Is Nothing) Then
                    If objIEstateRsXzTeam.oExitMode = True Then
                        Select Case objIEstateRsXzTeam.iSourceControlId.ToUpper()
                            Case "btnSelect_SY_TDBH".ToUpper()
                                If objIEstateRsXzTeam.oDataSet Is Nothing Then
                                    Me.txtSY_TDBH.Text = ""
                                Else
                                    With objIEstateRsXzTeam.oDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH)
                                        If .Rows.Count < 1 Then
                                            Me.txtSY_TDBH.Text = ""
                                        Else
                                            Me.txtSY_TDBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH), "")
                                        End If
                                    End With
                                End If
                            Case "btnSelect_GY_TDBH".ToUpper()
                                If objIEstateRsXzTeam.oDataSet Is Nothing Then
                                    Me.txtGY_TDBH.Text = ""
                                Else
                                    With objIEstateRsXzTeam.oDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH)
                                        If .Rows.Count < 1 Then
                                            Me.txtGY_TDBH.Text = ""
                                        Else
                                            Me.txtGY_TDBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH), "")
                                        End If
                                    End With
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsXzTeam.SafeRelease(objIEstateRsXzTeam)
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
                            Case "btnSelect_SY_DWDM".ToUpper
                                Me.txtSY_DWDM.Text = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtSY_DWDM.Text, Me.htxtSY_DWDM.Value) = False Then
                                    Me.htxtSY_DWDM.Value = ""
                                End If
                                'zengxianglin 2008-10-14
                                Me.doFillSsfzList(strErrMsg, Me.ddlSY_SSFZ, Me.txtSY_DWDM.Text)
                                'zengxianglin 2008-10-14
                            Case "btnSelect_GY_DWDM".ToUpper
                                Me.txtGY_DWDM.Text = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtGY_DWDM.Text, Me.htxtGY_DWDM.Value) = False Then
                                    Me.htxtGY_DWDM.Value = ""
                                End If
                                'zengxianglin 2008-10-14
                                Me.doFillSsfzList(strErrMsg, Me.ddlGY_SSFZ, Me.txtGY_DWDM.Text)
                                'zengxianglin 2008-10-14
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
                            Case "btnSelect_SY_RYDM".ToUpper
                                Me.htxtSY_RYDM.Value = objIDmxzRyxx.oRYDM
                                Me.txtSY_RYDM.Text = objIDmxzRyxx.oRYZM
                                Me.htxtSY_DWDM.Value = objIDmxzRyxx.oZZDM
                                Me.txtSY_DWDM.Text = objIDmxzRyxx.oZZMC
                                Dim strZJDM As String = ""
                                Dim strZJMC As String = ""
                                'zengxianglin 2008-10-14
                                Dim strSSFZ As String = ""
                                'If objsystemEstateErshou.getZjdmAndZjmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtSY_RYDM.Value, strZJDM, strZJMC) = True Then
                                '    Me.ddlSY_ZJDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSY_ZJDM, strZJDM)
                                'End If
                                If objsystemEstateErshou.getRYJGXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtSY_RYDM.Value, Me.m_strHTRQ, objRYJGXX) = True Then
                                    If Not (objRYJGXX Is Nothing) Then
                                        Me.htxtSY_DWDM.Value = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM), "")
                                        Me.txtSY_DWDM.Text = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC), "")
                                        strZJDM = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ), "")
                                        strZJMC = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC), "")
                                        Me.ddlSY_ZJDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSY_ZJDM, strZJDM)
                                        strSSFZ = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ), "")
                                        Me.doFillSsfzList(strErrMsg, Me.ddlSY_SSFZ, Me.txtSY_DWDM.Text)
                                        Me.ddlSY_SSFZ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSY_SSFZ, strSSFZ, True)
                                        'zengxianglin 2010-01-06
                                        Me.txtSY_TDBH.Text = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH), "")
                                        'zengxianglin 2010-01-06
                                    End If
                                End If
                            Case "btnSelect_GY_RYDM".ToUpper
                                Me.htxtGY_RYDM.Value = objIDmxzRyxx.oRYDM
                                Me.txtGY_RYDM.Text = objIDmxzRyxx.oRYZM
                                Me.htxtGY_DWDM.Value = objIDmxzRyxx.oZZDM
                                Me.txtGY_DWDM.Text = objIDmxzRyxx.oZZMC
                                Dim strZJDM As String = ""
                                Dim strZJMC As String = ""
                                'zengxianglin 2008-10-14
                                Dim strSSFZ As String = ""
                                'If objsystemEstateErshou.getZjdmAndZjmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtGY_RYDM.Value, strZJDM, strZJMC) = True Then
                                '    Me.ddlGY_ZJDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlGY_ZJDM, strZJDM)
                                'End If
                                If objsystemEstateErshou.getRYJGXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtGY_RYDM.Value, Me.m_strHTRQ, objRYJGXX) = True Then
                                    If Not (objRYJGXX Is Nothing) Then
                                        Me.htxtGY_DWDM.Value = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM), "")
                                        Me.txtGY_DWDM.Text = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC), "")
                                        strZJDM = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ), "")
                                        strZJMC = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC), "")
                                        Me.ddlGY_ZJDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlGY_ZJDM, strZJDM)
                                        strSSFZ = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ), "")
                                        Me.doFillSsfzList(strErrMsg, Me.ddlGY_SSFZ, Me.txtGY_DWDM.Text)
                                        Me.ddlGY_SSFZ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlGY_SSFZ, strSSFZ, True)
                                        'zengxianglin 2010-01-06
                                        Me.txtGY_TDBH.Text = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH), "")
                                        'zengxianglin 2010-01-06
                                    End If
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzRyxx.SafeRelease(objIDmxzRyxx)
                    Exit Try
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objRYJGXX)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objRYJGXX)
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
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getInterfaceParameters = False
            blnContinue = True

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsHetongFpbl)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    'û���нӿڲ���
                    Me.m_strQRSH = ""
                    'zengxianglin 2009-02-24
                    Me.m_blnEnforcedEdit = False
                    'zengxianglin 2009-02-24
                Else
                    Me.m_blnInterface = True
                    '�нӿڲ���
                    Me.m_strQRSH = Me.m_objInterface.iQRSH
                    'zengxianglin 2009-02-24
                    Me.m_blnEnforcedEdit = Me.m_objInterface.iEnforcedEdit
                    'zengxianglin 2009-02-24
                End If
                If Me.m_strQRSH = "" Then
                    blnContinue = False
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = "����û���ṩ��ģ����Ҫ�Ľӿڣ�"
                    Exit Try
                End If
                'zengxianglin 2008-10-14
                If objsystemEstateErshou.getHtrqByQrsh(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, Me.m_strHTRQ) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-10-14

                '��ͬ��ɣ�
                Dim blnIS As Boolean = False
                If objsystemEstateErshou.isHetongComplete(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, blnIS) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2009-02-24
                If Me.m_blnEnforcedEdit = True Then
                    'zengxianglin 2009-02-24
                    Me.m_blnEditMode = True
                    Me.m_blnEditMode_GY = True
                    'zengxianglin 2009-02-24
                Else
                    Me.m_blnEditMode = Me.m_blnPrevilegeParams(1)
                    Me.m_blnEditMode = Me.m_blnEditMode Or Me.m_blnPrevilegeParams(2)
                    Me.m_blnEditMode = Me.m_blnEditMode Or Me.m_blnPrevilegeParams(3)
                    Me.m_blnEditMode = Me.m_blnEditMode Or Me.m_blnPrevilegeParams(4)
                    Me.m_blnEditMode = Me.m_blnEditMode And (Not blnIS)
                    'zengxianglin 2008-11-22
                    Me.m_blnEditMode_GY = Me.m_blnEditMode And Me.m_blnPrevilegeParams(11)
                    'zengxianglin 2008-11-22
                End If
                'zengxianglin 2009-02-24

                '��ȡ�ָ��ֳ�����
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsHetongFpbl)
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

                Me.m_intFixedColumns_SYBL = objPulicParameters.getObjectValue(Me.htxtSYBLFixed.Value, 0)
                Me.m_intFixedColumns_GYBL = objPulicParameters.getObjectValue(Me.htxtGYBLFixed.Value, 0)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)

            getInterfaceParameters = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ͷű�ģ�黺��Ĳ���
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                If Me.htxtSessionIdSYBL.Value.Trim <> "" Then
                    Dim objTempData As Josco.JSOA.Common.Data.estateErshouData
                    Try
                        objTempData = CType(Session(Me.htxtSessionIdSYBL.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        objTempData = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objTempData)
                    Session.Remove(Me.htxtSessionIdSYBL.Value)
                End If

                If Me.htxtSessionIdGYBL.Value.Trim <> "" Then
                    Dim objTempData As Josco.JSOA.Common.Data.estateErshouData
                    Try
                        objTempData = CType(Session(Me.htxtSessionIdGYBL.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        objTempData = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objTempData)
                    Session.Remove(Me.htxtSessionIdGYBL.Value)
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub














        '----------------------------------------------------------------
        ' ��ȡgrdSYBLҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_SYBL( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_SYBL = False

            Try
                If Me.htxtSessionIdSYBL.Value.Trim <> "" Then
                    Try
                        Me.m_objDataSet_SYBL = CType(Session(Me.htxtSessionIdSYBL.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        Me.m_objDataSet_SYBL = Nothing
                        strErrMsg = ex.Message
                        GoTo errProc
                    End Try
                Else
                    '������˽Ӷ
                    Dim strWhere As String = ""
                    strWhere = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZ + " & 1 = 1"

                    '��ȡ����
                    If objsystemEstateErshou.getDataSet_ES_HETONG_FPBL(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, strWhere, Me.m_objDataSet_SYBL) = False Then
                        GoTo errProc
                    End If

                    '��������
                    Dim strSessionId As String = objPulicParameters.getNewGuid()
                    Session.Add(strSessionId, Me.m_objDataSet_SYBL)
                    Me.htxtSessionIdSYBL.Value = strSessionId
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_SYBL = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdGYBLҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_GYBL( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_GYBL = False

            Try
                If Me.htxtSessionIdGYBL.Value.Trim <> "" Then
                    Try
                        Me.m_objDataSet_GYBL = CType(Session(Me.htxtSessionIdGYBL.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        Me.m_objDataSet_GYBL = Nothing
                        strErrMsg = ex.Message
                        GoTo errProc
                    End Try
                Else
                    '������˽Ӷ
                    Dim strWhere As String = ""
                    strWhere = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZ + " & 1 = 0"

                    '��ȡ����
                    If objsystemEstateErshou.getDataSet_ES_HETONG_FPBL(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, strWhere, Me.m_objDataSet_GYBL) = False Then
                        GoTo errProc
                    End If

                    '��������
                    Dim strSessionId As String = objPulicParameters.getNewGuid()
                    Session.Add(strSessionId, Me.m_objDataSet_GYBL)
                    Me.htxtSessionIdGYBL.Value = strSessionId
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_GYBL = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdSYBL������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_SYBL( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_SYBL = False

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_SYBL Is Nothing Then
                    Me.grdSYBL.DataSource = Nothing
                Else
                    With Me.m_objDataSet_SYBL.Tables(strTable)
                        Me.grdSYBL.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_SYBL.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdSYBL, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdSYBL.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                ''�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdSYBL, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_SYBL) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_SYBL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdGYBL������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_GYBL( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_GYBL = False

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_GYBL Is Nothing Then
                    Me.grdGYBL.DataSource = Nothing
                Else
                    With Me.m_objDataSet_GYBL.Tables(strTable)
                        Me.grdGYBL.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_GYBL.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdGYBL, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdGYBL.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                ''�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdGYBL, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_GYBL) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_GYBL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾSYBL�༭��������(��������ǰ��������ʾ)
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showEditPanelInfo_SYBL( _
            ByRef strErrMsg As String) As Boolean

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim strValue As String = ""

            showEditPanelInfo_SYBL = False

            Try
                'ͨ���ֳ��ָ��õ�
                If Me.IsPostBack = False And Me.m_blnSaveScence = True Then
                    Exit Try
                End If

                '�������
                If Me.grdSYBL.Items.Count < 1 Or Me.grdSYBL.SelectedIndex < 0 Then
                    Me.ddlSY_ZJDM.SelectedIndex = -1
                    Me.txtSY_DWDM.Text = ""
                    'zengxianglin 2010-01-06
                    Me.txtSY_TDBH.Text = ""
                    'zengxianglin 2010-01-06
                    Me.txtSY_FPBL.Text = ""
                    Me.txtSY_RYDM.Text = ""
                    Me.htxtSY_DWDM.Value = ""
                    Me.htxtSY_RYDM.Value = ""
                    'zengxianglin 2008-10-14
                    Me.ddlSY_SSFZ.SelectedIndex = -1
                    'zengxianglin 2008-10-14
                Else
                    Dim intColIndex As Integer = -1

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSYBL.Items(Me.grdSYBL.SelectedIndex), intColIndex)
                    Me.ddlSY_ZJDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSY_ZJDM, strValue)

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSYBL.Items(Me.grdSYBL.SelectedIndex), intColIndex)
                    Me.txtSY_DWDM.Text = objPulicParameters.getObjectValue(strValue, "")
                    'zengxianglin 2010-01-06
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSYBL.Items(Me.grdSYBL.SelectedIndex), intColIndex)
                    Me.txtSY_TDBH.Text = objPulicParameters.getObjectValue(strValue, "")
                    'zengxianglin 2010-01-06
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSYBL.Items(Me.grdSYBL.SelectedIndex), intColIndex)
                    Me.htxtSY_DWDM.Value = objPulicParameters.getObjectValue(strValue, "")

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYMC)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSYBL.Items(Me.grdSYBL.SelectedIndex), intColIndex)
                    Me.txtSY_RYDM.Text = objPulicParameters.getObjectValue(strValue, "")
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSYBL.Items(Me.grdSYBL.SelectedIndex), intColIndex)
                    Me.htxtSY_RYDM.Value = objPulicParameters.getObjectValue(strValue, "")

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSYBL.Items(Me.grdSYBL.SelectedIndex), intColIndex)
                    strValue = strValue.Replace("%", "")
                    Me.txtSY_FPBL.Text = objPulicParameters.getObjectValue(strValue, 0.0).ToString("#.00")

                    'zengxianglin 2008-10-14
                    Me.doFillSsfzList(strErrMsg, Me.ddlSY_SSFZ, Me.txtSY_DWDM.Text)
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdSYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdSYBL.Items(Me.grdSYBL.SelectedIndex), intColIndex)
                    Me.ddlSY_SSFZ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSY_SSFZ, strValue, True)
                    'zengxianglin 2008-10-14
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

            showEditPanelInfo_SYBL = True
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
        ' ��ʾGYBL�༭��������(��������ǰ��������ʾ)
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showEditPanelInfo_GYBL( _
            ByRef strErrMsg As String) As Boolean

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim strValue As String = ""

            showEditPanelInfo_GYBL = False

            Try
                'ͨ���ֳ��ָ��õ�
                If Me.IsPostBack = False And Me.m_blnSaveScence = True Then
                    Exit Try
                End If

                '�������
                If Me.grdGYBL.Items.Count < 1 Or Me.grdGYBL.SelectedIndex < 0 Then
                    Me.ddlGY_ZJDM.SelectedIndex = -1
                    Me.rblGY_ZGBZ.SelectedIndex = -1
                    Me.txtGY_DWDM.Text = ""
                    'zengxianglin 2010-01-06
                    Me.txtGY_TDBH.Text = ""
                    'zengxianglin 2010-01-06
                    Me.txtGY_FPBL.Text = ""
                    Me.txtGY_RYDM.Text = ""
                    Me.htxtGY_DWDM.Value = ""
                    Me.htxtGY_RYDM.Value = ""
                    'zengxianglin 2008-10-14
                    Me.ddlGY_SSFZ.SelectedIndex = -1
                    'zengxianglin 2008-10-14
                Else
                    Dim intColIndex As Integer = -1

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdGYBL.Items(Me.grdGYBL.SelectedIndex), intColIndex)
                    Me.ddlGY_ZJDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlGY_ZJDM, strValue)

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJ)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdGYBL.Items(Me.grdGYBL.SelectedIndex), intColIndex)
                    Me.rblGY_ZGBZ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblGY_ZGBZ, strValue)

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdGYBL.Items(Me.grdGYBL.SelectedIndex), intColIndex)
                    Me.txtGY_DWDM.Text = objPulicParameters.getObjectValue(strValue, "")
                    'zengxianglin 2010-01-06
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdGYBL.Items(Me.grdGYBL.SelectedIndex), intColIndex)
                    Me.txtGY_TDBH.Text = objPulicParameters.getObjectValue(strValue, "")
                    'zengxianglin 2010-01-06
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdGYBL.Items(Me.grdGYBL.SelectedIndex), intColIndex)
                    Me.htxtGY_DWDM.Value = objPulicParameters.getObjectValue(strValue, "")

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYMC)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdGYBL.Items(Me.grdGYBL.SelectedIndex), intColIndex)
                    Me.txtGY_RYDM.Text = objPulicParameters.getObjectValue(strValue, "")
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdGYBL.Items(Me.grdGYBL.SelectedIndex), intColIndex)
                    Me.htxtGY_RYDM.Value = objPulicParameters.getObjectValue(strValue, "")

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdGYBL.Items(Me.grdGYBL.SelectedIndex), intColIndex)
                    strValue = strValue.Replace("%", "")
                    Me.txtGY_FPBL.Text = objPulicParameters.getObjectValue(strValue, 0.0).ToString("#.00")

                    'zengxianglin 2008-10-14
                    Me.doFillSsfzList(strErrMsg, Me.ddlGY_SSFZ, Me.txtGY_DWDM.Text)
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYBL, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdGYBL.Items(Me.grdGYBL.SelectedIndex), intColIndex)
                    Me.ddlGY_SSFZ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlGY_SSFZ, strValue, True)
                    'zengxianglin 2008-10-14
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

            showEditPanelInfo_GYBL = True
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
        ' ��ʾSYBL����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_SYBL( _
            ByRef strErrMsg As String) As Boolean

            showModuleData_SYBL = False

            Try
                If Me.showDataGridInfo_SYBL(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showEditPanelInfo_SYBL(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showModuleData_SYBL = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾGYBL����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_GYBL( _
            ByRef strErrMsg As String) As Boolean

            showModuleData_GYBL = False

            Try
                If Me.showDataGridInfo_GYBL(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showEditPanelInfo_GYBL(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showModuleData_GYBL = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾ����ģ�����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-22 ����Ӷ��˽Ӷ�ĵ���Ȩ�޷ֿ�
        '----------------------------------------------------------------
        Private Function showModuleData_Main( _
            ByRef strErrMsg As String) As Boolean

            showModuleData_Main = False

            Try
                Me.btnMake.Visible = Me.m_blnEditMode_GY
                Me.btnAddNew_GY.Visible = Me.m_blnEditMode_GY
                Me.btnDelete_GY.Visible = Me.m_blnEditMode_GY
                Me.btnUpdate_GY.Visible = Me.m_blnEditMode_GY

                Me.btnOK.Visible = Me.m_blnEditMode
                Me.btnAddNew_SY.Visible = Me.m_blnEditMode
                Me.btnDelete_SY.Visible = Me.m_blnEditMode
                Me.btnUpdate_SY.Visible = Me.m_blnEditMode
                'zengxianglin 2010-03-22
                Me.btnSYBL.Visible = Me.m_blnEditMode
                'zengxianglin 2010-03-22
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
        ' ���ְ�������б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        '     blnAddBlank    ��True-�ӿ���
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doFillZjdmList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal blnAddBlank As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_ZHIJIDINGYI
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillZjdmList = False
            strErrMsg = ""

            Try
                '���
                If objDropDownList Is Nothing Then
                    strErrMsg = "����[doFillZjdmList]�ӿڲ�������ȷ��"
                    GoTo errProc
                End If

                '��ȡ����
                'zengxianglin 2010-01-06
                Dim strWhere As String = ""
                strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_JBSZ + " > 0"
                'zengxianglin 2010-01-06
                If objsystemEstateRenshiXingye.getDataSet_ZhijiDingyi(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiXingyeData) = False Then
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
                With objestateRenshiXingyeData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJMC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillZjdmList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' ����·�����������б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        '     strZZMC        ����λ����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doFillSsfzList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            ByVal strZZMC As String) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.CustomerData.TABLE_GG_B_ZUZHIFENZU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objCustomerData As Josco.JsKernal.Common.Data.CustomerData = Nothing

            doFillSsfzList = False
            strErrMsg = ""

            Try
                '���
                If objDropDownList Is Nothing Then
                    strErrMsg = "����[doFillYdyyList]�ӿڲ�������ȷ��"
                    GoTo errProc
                End If
                If strZZMC Is Nothing Then strZZMC = ""
                strZZMC = strZZMC.Trim

                '��������б�
                objDropDownList.Items.Clear()
                objDropDownList.Items.Add("")
                If strZZMC = "" Then
                    Exit Try
                End If

                '��ȡ����
                If objsystemCustomer.getFenzuDataByFhmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, objCustomerData) = False Then
                    GoTo errProc
                End If

                '�������
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objCustomerData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIFENZU_FZMC), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.CustomerData.FIELD_GG_B_ZUZHIFENZU_FZMC), "")

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Text = strName
                        objListItem.Value = strName
                        objDropDownList.Items.Add(objListItem)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.CustomerData.SafeRelease(objCustomerData)

            doFillSsfzList = True
            Exit Function
errProc:
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.CustomerData.SafeRelease(objCustomerData)
            Exit Function

        End Function
        'zengxianglin 2008-10-14

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
                    objControlProcess.doTranslateKey(Me.txtGY_RYDM)
                    objControlProcess.doTranslateKey(Me.txtGY_DWDM)
                    'zengxianglin 2010-01-06
                    objControlProcess.doTranslateKey(Me.txtGY_TDBH)
                    'zengxianglin 2010-01-06
                    objControlProcess.doTranslateKey(Me.txtGY_FPBL)
                    objControlProcess.doTranslateKey(Me.ddlGY_ZJDM)
                    'zengxianglin 2008-10-14
                    objControlProcess.doTranslateKey(Me.ddlGY_SSFZ)
                    'zengxianglin 2008-10-14
                    '*******************************************************
                    objControlProcess.doTranslateKey(Me.txtSY_RYDM)
                    objControlProcess.doTranslateKey(Me.txtSY_DWDM)
                    'zengxianglin 2010-01-06
                    objControlProcess.doTranslateKey(Me.txtSY_TDBH)
                    'zengxianglin 2010-01-06
                    objControlProcess.doTranslateKey(Me.txtSY_FPBL)
                    objControlProcess.doTranslateKey(Me.ddlSY_ZJDM)
                    'zengxianglin 2008-10-14
                    objControlProcess.doTranslateKey(Me.ddlSY_SSFZ)
                    'zengxianglin 2008-10-14
                    '*******************************************************

                    '��ʾ����
                    If Me.getModuleData_SYBL(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_SYBL(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_GYBL(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_GYBL(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_Main(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            Else
                If Me.getModuleData_SYBL(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_GYBL(strErrMsg) = False Then
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

            '����б�
            If Me.IsPostBack = False Then
                If Me.doFillZjdmList(strErrMsg, Me.ddlGY_ZJDM, False) = False Then
                    GoTo errProc
                End If
                If Me.doFillZjdmList(strErrMsg, Me.ddlSY_ZJDM, False) = False Then
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
        Sub grdSYBL_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdSYBL.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_SYBL + ".scrollTop)")
                    Next
                End If

                If Me.m_intFixedColumns_SYBL > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_SYBL - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdSYBL.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Sub grdGYBL_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdGYBL.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_GYBL + ".scrollTop)")
                    Next
                End If

                If Me.m_intFixedColumns_GYBL > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_GYBL - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdGYBL.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdSYBL_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSYBL.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.showEditPanelInfo_SYBL(strErrMsg) = False Then
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

        Private Sub grdGYBL_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGYBL.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.showEditPanelInfo_GYBL(strErrMsg) = False Then
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












        Private Sub doSelect_RYDM(ByVal strControlId As String)

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

        Private Sub doSelect_DWDM(ByVal strControlId As String)

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

        'zengxianglin 2010-01-06 ����
        Private Sub doSelect_SY_TDBH(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.txtSY_DWDM.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[��λ]��"
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
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Dim strUrl As String = ""
                objIEstateRsXzTeam = New Josco.JSOA.BusinessFacade.IEstateRsXzTeam
                With objIEstateRsXzTeam
                    .iMultiSelect = False
                    .iAllowNull = True
                    .iJCSJ = Me.m_strHTRQ
                    .iFixQuery = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_SSDW + " = '" + Me.htxtSY_DWDM.Value + "'"

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
                Session.Add(strNewSessionId, objIEstateRsXzTeam)
                strUrl = ""
                strUrl += "../renshi/estate_rs_xz_team.aspx"
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

        'zengxianglin 2010-01-06 ����
        Private Sub doSelect_GY_TDBH(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.txtGY_DWDM.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[��λ]��"
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
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Dim strUrl As String = ""
                objIEstateRsXzTeam = New Josco.JSOA.BusinessFacade.IEstateRsXzTeam
                With objIEstateRsXzTeam
                    .iMultiSelect = False
                    .iAllowNull = True
                    .iJCSJ = Me.m_strHTRQ
                    .iFixQuery = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_SSDW + " = '" + Me.htxtGY_DWDM.Value + "'"

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
                Session.Add(strNewSessionId, objIEstateRsXzTeam)
                strUrl = ""
                strUrl += "../renshi/estate_rs_xz_team.aspx"
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

        Private Sub btnSelect_SY_DWDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_SY_DWDM.Click
            Me.doSelect_DWDM("btnSelect_SY_DWDM")
        End Sub

        Private Sub btnSelect_GY_DWDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_GY_DWDM.Click
            Me.doSelect_DWDM("btnSelect_GY_DWDM")
        End Sub

        Private Sub btnSelect_SY_RYDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_SY_RYDM.Click
            Me.doSelect_RYDM("btnSelect_SY_RYDM")
        End Sub

        Private Sub btnSelect_GY_RYDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_GY_RYDM.Click
            Me.doSelect_RYDM("btnSelect_GY_RYDM")
        End Sub

        'zengxianglin 2010-01-06 ����
        Private Sub btnSelect_GY_TDBH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_GY_TDBH.Click
            Me.doSelect_GY_TDBH("btnSelect_GY_TDBH")
        End Sub

        'zengxianglin 2010-01-06 ����
        Private Sub btnSelect_SY_TDBH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_SY_TDBH.Click
            Me.doSelect_SY_TDBH("btnSelect_SY_TDBH")
        End Sub












        '----------------------------------------------------------------
        'ģ���������������
        '----------------------------------------------------------------
        Private Sub doAddNew_SY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataRow As System.Data.DataRow
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.htxtSY_DWDM.Value.Trim = "" Then
                    strErrMsg = "����û��ָ��[��λ]"
                    GoTo errProc
                End If
                If Me.htxtSY_RYDM.Value.Trim = "" Then
                    strErrMsg = "����û��ָ��[��Ա]"
                    GoTo errProc
                End If
                If Me.ddlSY_ZJDM.SelectedIndex < 0 Then
                    strErrMsg = "����û��ָ��[ְ��]"
                    GoTo errProc
                End If
                If Me.txtSY_FPBL.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[����]"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtSY_FPBL.Text) = False Then
                    strErrMsg = "������Ч��[����]"
                    GoTo errProc
                End If
                Dim dblFPBL As Double = objPulicParameters.getObjectValue(Me.txtSY_FPBL.Text, 0.0)
                dblFPBL = dblFPBL / 100
                'zengxianglin 2010-01-06
                If Me.txtSY_TDBH.Text.Trim <> "" Then
                    If objPulicParameters.isIntegerString(Me.txtSY_TDBH.Text) = False Then
                        strErrMsg = "������Ч��[�Ŷ�][" + Me.txtSY_TDBH.Text + "]"
                        GoTo errProc
                    End If
                End If
                'zengxianglin 2010-01-06

                '��Ա�Ƿ���ڣ�
                Dim strOldFilter As String = ""
                Dim strNewFilter As String = ""
                With Me.m_objDataSet_SYBL.Tables(strTable)
                    strOldFilter = .DefaultView.RowFilter

                    strNewFilter = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM + " = '" + Me.htxtSY_RYDM.Value + "'"
                    .DefaultView.RowFilter = strNewFilter
                    If .DefaultView.Count > 0 Then
                        .DefaultView.RowFilter = strOldFilter
                        strErrMsg = "������Ա�Ѿ����ڣ�"
                        GoTo errProc
                    End If

                    .DefaultView.RowFilter = strOldFilter
                End With

                '����
                With Me.m_objDataSet_SYBL.Tables(strTable)
                    objDataRow = .NewRow()

                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_WYBS) = objPulicParameters.getNewGuid()
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_QRSH) = Me.m_strQRSH
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM) = Me.htxtSY_DWDM.Value
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC) = Me.txtSY_DWDM.Text
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL) = dblFPBL
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM) = Me.htxtSY_RYDM.Value
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYMC) = Me.txtSY_RYDM.Text
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ) = Me.ddlSY_ZJDM.SelectedValue
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC) = Me.ddlSY_ZJDM.SelectedItem.Text.Split("|".ToCharArray)(1)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJ) = -1
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJMC) = Josco.JSOA.Common.Data.estateErshouData.getZhiguanStatusName(-1)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZ) = 1
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZMC) = Josco.JSOA.Common.Data.estateErshouData.getYejiStatusName(1)
                    'zengxianglin 2008-10-14
                    If Me.ddlSY_SSFZ.SelectedIndex < 0 Then
                        objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ) = ""
                    Else
                        objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ) = Me.ddlSY_SSFZ.SelectedItem.Text
                    End If
                    'zengxianglin 2008-10-14
                    'zengxianglin 2010-01-06
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH) = objPulicParameters.getObjectValue(Me.txtSY_TDBH.Text, 0)
                    'zengxianglin 2010-01-06

                    .Rows.Add(objDataRow)
                End With

                '��ʾ
                If Me.showDataGridInfo_SYBL(strErrMsg) = False Then
                    GoTo errProc
                End If
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

        Private Sub doAddNew_GY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataRow As System.Data.DataRow
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.htxtGY_DWDM.Value.Trim = "" Then
                    strErrMsg = "����û��ָ��[��λ]"
                    GoTo errProc
                End If
                If Me.htxtGY_RYDM.Value.Trim = "" Then
                    strErrMsg = "����û��ָ��[��Ա]"
                    GoTo errProc
                End If
                If Me.ddlGY_ZJDM.SelectedIndex < 0 Then
                    strErrMsg = "����û��ָ��[ְ��]"
                    GoTo errProc
                End If
                If Me.txtGY_FPBL.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[����]"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtGY_FPBL.Text) = False Then
                    strErrMsg = "������Ч��[����]"
                    GoTo errProc
                End If
                Dim dblFPBL As Double = objPulicParameters.getObjectValue(Me.txtGY_FPBL.Text, 0.0)
                dblFPBL = dblFPBL / 100
                If Me.rblGY_ZGBZ.SelectedIndex < 0 Then
                    strErrMsg = "����û��ָ��[ֱ��Э��]"
                    GoTo errProc
                End If
                Dim intZGBJ As Integer = 0
                intZGBJ = objPulicParameters.getObjectValue(Me.rblGY_ZGBZ.SelectedValue, 0)
                'zengxianglin 2010-01-06
                If Me.txtGY_TDBH.Text.Trim <> "" Then
                    If objPulicParameters.isIntegerString(Me.txtGY_TDBH.Text) = False Then
                        strErrMsg = "������Ч��[�Ŷ�][" + Me.txtGY_TDBH.Text + "]"
                        GoTo errProc
                    End If
                End If
                'zengxianglin 2010-01-06

                '����
                With Me.m_objDataSet_GYBL.Tables(strTable)
                    objDataRow = .NewRow()

                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_WYBS) = objPulicParameters.getNewGuid()
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_QRSH) = Me.m_strQRSH
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM) = Me.htxtGY_DWDM.Value
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC) = Me.txtGY_DWDM.Text
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL) = dblFPBL
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM) = Me.htxtGY_RYDM.Value
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYMC) = Me.txtGY_RYDM.Text
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ) = Me.ddlGY_ZJDM.SelectedValue
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC) = Me.ddlGY_ZJDM.SelectedItem.Text.Split("|".ToCharArray)(1)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJ) = intZGBJ
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJMC) = Josco.JSOA.Common.Data.estateErshouData.getZhiguanStatusName(intZGBJ)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZ) = 0
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZMC) = Josco.JSOA.Common.Data.estateErshouData.getYejiStatusName(0)
                    'zengxianglin 2008-10-14
                    If Me.ddlGY_SSFZ.SelectedIndex < 0 Then
                        objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ) = ""
                    Else
                        objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ) = Me.ddlGY_SSFZ.SelectedItem.Text
                    End If
                    'zengxianglin 2008-10-14
                    'zengxianglin 2010-01-06
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH) = objPulicParameters.getObjectValue(Me.txtGY_TDBH.Text, 0)
                    'zengxianglin 2010-01-06

                    .Rows.Add(objDataRow)
                End With

                '��ʾ
                If Me.showDataGridInfo_GYBL(strErrMsg) = False Then
                    GoTo errProc
                End If
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

        Private Sub doUpdate_SY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataRow As System.Data.DataRow
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.grdSYBL.SelectedIndex < 0 Then
                    strErrMsg = "����û�����ݿɸģ�"
                    GoTo errProc
                End If
                If Me.htxtSY_DWDM.Value.Trim = "" Then
                    strErrMsg = "����û��ָ��[��λ]"
                    GoTo errProc
                End If
                If Me.htxtSY_RYDM.Value.Trim = "" Then
                    strErrMsg = "����û��ָ��[��Ա]"
                    GoTo errProc
                End If
                If Me.ddlSY_ZJDM.SelectedIndex < 0 Then
                    strErrMsg = "����û��ָ��[ְ��]"
                    GoTo errProc
                End If
                If Me.txtSY_FPBL.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[����]"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtSY_FPBL.Text) = False Then
                    strErrMsg = "������Ч��[����]"
                    GoTo errProc
                End If
                Dim dblFPBL As Double = objPulicParameters.getObjectValue(Me.txtSY_FPBL.Text, 0.0)
                dblFPBL = dblFPBL / 100
                'zengxianglin 2010-01-06
                If Me.txtSY_TDBH.Text.Trim <> "" Then
                    If objPulicParameters.isIntegerString(Me.txtSY_TDBH.Text) = False Then
                        strErrMsg = "������Ч��[�Ŷ�][" + Me.txtSY_TDBH.Text + "]"
                        GoTo errProc
                    End If
                End If
                'zengxianglin 2010-01-06

                '��ȡ��ǰ��
                Dim i As Integer = Me.grdSYBL.SelectedIndex
                Dim intPos As Integer = 0
                With Me.m_objDataSet_SYBL.Tables(strTable)
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdSYBL.CurrentPageIndex, Me.grdSYBL.PageSize)
                    objDataRow = .DefaultView.Item(intPos).Row
                End With
                Dim strWYBS As String = ""
                strWYBS = objPulicParameters.getObjectValue(objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_WYBS), "")

                '��Ա�Ƿ���ڣ�
                Dim strOldFilter As String = ""
                Dim strNewFilter As String = ""
                With Me.m_objDataSet_SYBL.Tables(strTable)
                    strOldFilter = .DefaultView.RowFilter

                    strNewFilter = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM + " = '" + Me.htxtSY_RYDM.Value + "'"
                    strNewFilter = strNewFilter + " and " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_WYBS + " <> '" + strWYBS + "'"
                    .DefaultView.RowFilter = strNewFilter
                    If .DefaultView.Count > 0 Then
                        .DefaultView.RowFilter = strOldFilter
                        strErrMsg = "������Ա�Ѿ����ڣ�"
                        GoTo errProc
                    End If

                    .DefaultView.RowFilter = strOldFilter
                End With

                '����
                With Me.m_objDataSet_SYBL.Tables(strTable)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM) = Me.htxtSY_DWDM.Value
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC) = Me.txtSY_DWDM.Text
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL) = dblFPBL
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM) = Me.htxtSY_RYDM.Value
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYMC) = Me.txtSY_RYDM.Text
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ) = Me.ddlSY_ZJDM.SelectedValue
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC) = Me.ddlSY_ZJDM.SelectedItem.Text.Split("|".ToCharArray)(1)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJ) = -1
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJMC) = Josco.JSOA.Common.Data.estateErshouData.getZhiguanStatusName(-1)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZ) = 1
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZMC) = Josco.JSOA.Common.Data.estateErshouData.getYejiStatusName(1)
                    'zengxianglin 2008-10-14
                    If Me.ddlSY_SSFZ.SelectedIndex < 0 Then
                        objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ) = ""
                    Else
                        objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ) = Me.ddlSY_SSFZ.SelectedItem.Text
                    End If
                    'zengxianglin 2008-10-14
                    'zengxianglin 2010-01-06
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH) = objPulicParameters.getObjectValue(Me.txtSY_TDBH.Text, 0)
                    'zengxianglin 2010-01-06
                End With

                '��ʾ
                If Me.showDataGridInfo_SYBL(strErrMsg) = False Then
                    GoTo errProc
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

        Private Sub doUpdate_GY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataRow As System.Data.DataRow
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.grdGYBL.SelectedIndex < 0 Then
                    strErrMsg = "����û�����ݿɸģ�"
                    GoTo errProc
                End If
                If Me.htxtGY_DWDM.Value.Trim = "" Then
                    strErrMsg = "����û��ָ��[��λ]"
                    GoTo errProc
                End If
                If Me.htxtGY_RYDM.Value.Trim = "" Then
                    strErrMsg = "����û��ָ��[��Ա]"
                    GoTo errProc
                End If
                If Me.ddlGY_ZJDM.SelectedIndex < 0 Then
                    strErrMsg = "����û��ָ��[ְ��]"
                    GoTo errProc
                End If
                If Me.txtGY_FPBL.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[����]"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtGY_FPBL.Text) = False Then
                    strErrMsg = "������Ч��[����]"
                    GoTo errProc
                End If
                Dim dblFPBL As Double = objPulicParameters.getObjectValue(Me.txtGY_FPBL.Text, 0.0)
                dblFPBL = dblFPBL / 100
                If Me.rblGY_ZGBZ.SelectedIndex < 0 Then
                    strErrMsg = "����û��ָ��[ֱ��Э��]"
                    GoTo errProc
                End If
                Dim intZGBJ As Integer = objPulicParameters.getObjectValue(Me.rblGY_ZGBZ.SelectedValue, 0)
                'zengxianglin 2010-01-06
                If Me.txtGY_TDBH.Text.Trim <> "" Then
                    If objPulicParameters.isIntegerString(Me.txtGY_TDBH.Text) = False Then
                        strErrMsg = "������Ч��[�Ŷ�][" + Me.txtGY_TDBH.Text + "]"
                        GoTo errProc
                    End If
                End If
                'zengxianglin 2010-01-06

                '��ȡ��ǰ��
                Dim i As Integer = Me.grdGYBL.SelectedIndex
                Dim intPos As Integer = 0
                With Me.m_objDataSet_GYBL.Tables(strTable)
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdGYBL.CurrentPageIndex, Me.grdGYBL.PageSize)
                    objDataRow = .DefaultView.Item(intPos).Row
                End With

                '����
                With Me.m_objDataSet_GYBL.Tables(strTable)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM) = Me.htxtGY_DWDM.Value
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC) = Me.txtGY_DWDM.Text
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL) = dblFPBL
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM) = Me.htxtGY_RYDM.Value
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYMC) = Me.txtGY_RYDM.Text
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ) = Me.ddlGY_ZJDM.SelectedValue
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC) = Me.ddlGY_ZJDM.SelectedItem.Text.Split("|".ToCharArray)(1)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJ) = intZGBJ
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJMC) = Josco.JSOA.Common.Data.estateErshouData.getZhiguanStatusName(intZGBJ)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZ) = 0
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZMC) = Josco.JSOA.Common.Data.estateErshouData.getYejiStatusName(0)
                    'zengxianglin 2008-10-14
                    If Me.ddlGY_SSFZ.SelectedIndex < 0 Then
                        objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ) = ""
                    Else
                        objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ) = Me.ddlGY_SSFZ.SelectedItem.Text
                    End If
                    'zengxianglin 2008-10-14
                    'zengxianglin 2010-01-06
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH) = objPulicParameters.getObjectValue(Me.txtGY_TDBH.Text, 0)
                    'zengxianglin 2010-01-06
                End With

                '��ʾ
                If Me.showDataGridInfo_GYBL(strErrMsg) = False Then
                    GoTo errProc
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

        Private Sub doDelete_SY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataRow As System.Data.DataRow
            Dim strErrMsg As String = ""

            Try
                '���
                Dim intCount As Integer = 0
                Dim intPos As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdSYBL.Items.Count
                For i = intCount - 1 To 0 Step -1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdSYBL.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_SYBL) = True Then
                        intPos = objDataGridProcess.getRecordPosition(i, Me.grdSYBL.CurrentPageIndex, Me.grdSYBL.PageSize)
                        With Me.m_objDataSet_SYBL.Tables(strTable)
                            objDataRow = .DefaultView.Item(intPos).Row
                            .Rows.Remove(objDataRow)
                        End With
                    End If
                Next

                '��ʾ
                If Me.showDataGridInfo_SYBL(strErrMsg) = False Then
                    GoTo errProc
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

        Private Sub doDelete_GY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataRow As System.Data.DataRow
            Dim strErrMsg As String = ""

            Try
                '���
                Dim intCount As Integer = 0
                Dim intPos As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGYBL.Items.Count
                For i = intCount - 1 To 0 Step -1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdGYBL.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_GYBL) = True Then
                        intPos = objDataGridProcess.getRecordPosition(i, Me.grdGYBL.CurrentPageIndex, Me.grdGYBL.PageSize)
                        With Me.m_objDataSet_GYBL.Tables(strTable)
                            objDataRow = .DefaultView.Item(intPos).Row
                            .Rows.Remove(objDataRow)
                        End With
                    End If
                Next

                '��ʾ
                If Me.showDataGridInfo_GYBL(strErrMsg) = False Then
                    GoTo errProc
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

        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strSessionId As String
                Dim strUrl As String
                If Me.m_blnInterface = True Then
                    '���÷��ز���
                    '���ص�����ģ�飬�����ӷ��ز���
                    Me.m_objInterface.oExitMode = False
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

        Private Sub doMake(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataSet_GY As Josco.JSOA.Common.Data.estateErshouData = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataRow As System.Data.DataRow
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.grdSYBL.Items.Count < 1 Then
                    strErrMsg = "����û��[ҵ��Ա]���ݿɲο���"
                    GoTo errProc
                End If

                '�Զ����㹫Ӷ��Ϣ
                If objsystemEstateErshou.getGongyongInfo(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, Me.m_objDataSet_SYBL, objDataSet_GY) = False Then
                    GoTo errProc
                End If
                If objDataSet_GY Is Nothing Then
                    Exit Try
                End If
                If objDataSet_GY.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                'zengxianglin 2008-12-06
                '�����������
                With Me.m_objDataSet_GYBL.Tables(strTable)
                    .Rows.Clear()
                End With
                'zengxianglin 2008-12-06

                '����
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = objDataSet_GY.Tables(strTable).Rows.Count
                For i = 0 To intCount - 1 Step 1
                    With Me.m_objDataSet_GYBL.Tables(strTable)
                        objDataRow = .NewRow()
                        With objDataSet_GY.Tables(strTable)
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_WYBS) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_WYBS)
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_QRSH) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_QRSH)
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM)
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC)
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL)
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM)
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYMC) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYMC)
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ)
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC)
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJ) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJ)
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJMC) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJMC)
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZ) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZ)
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZMC) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZMC)
                            'zengxianglin 2008-10-14
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ)
                            'zengxianglin 2008-10-14
                            'zengxianglin 2010-01-06
                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH) = .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH)
                            'zengxianglin 2010-01-06
                        End With
                        .Rows.Add(objDataRow)
                    End With
                Next

                '��ʾ
                If Me.showModuleData_GYBL(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objDataSet_GY)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objDataSet_GY)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOK(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer = 0

            Try
                intStep = 1
                '���
                Dim blnValid As Boolean = False
                If objsystemEstateErshou.doVerify_ES_HETONG_FPBL(strErrMsg, Me.m_objDataSet_SYBL, blnValid) = False Then
                    GoTo errProc
                End If
                If blnValid = False Then
                    strErrMsg = "��������ҵ����Ա�ķ������֮��Ӧ����1��"
                    GoTo errProc
                End If

                intStep = 2
                'ȷ�ϣ�
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ������������ȷ����/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '����
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '����
                    'zengxianglin 2008-11-22
                    'If objsystemEstateErshou.doSaveData_ES_HETONG_FPBL(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, Me.m_objDataSet_SYBL, Me.m_objDataSet_GYBL) = False Then
                    '    GoTo errProc
                    'End If
                    If Me.btnMake.Visible = True Then
                        If objsystemEstateErshou.doSaveData_ES_HETONG_FPBL(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, Me.m_objDataSet_SYBL, Me.m_objDataSet_GYBL) = False Then
                            GoTo errProc
                        End If
                    Else
                        If objsystemEstateErshou.doSaveData_ES_HETONG_FPBL(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, Me.m_objDataSet_SYBL, Nothing) = False Then
                            GoTo errProc
                        End If
                    End If
                    'zengxianglin 2008-11-22

                    '��¼�����־
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_��ͬ]��[����]��[" + Me.m_strQRSH + "]��[�������]��")

                    '����
                    Dim strSessionId As String
                    Dim strUrl As String
                    If Me.m_blnInterface = True Then
                        '���÷��ز���
                        '���ص�����ģ�飬�����ӷ��ز���
                        Me.m_objInterface.oExitMode = False
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

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        'zengxianglin 2010-03-22 ����
        Private Sub doSYBL(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objRYJGXX As System.Collections.Specialized.NameValueCollection = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataRow As System.Data.DataRow
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.grdSYBL.Items.Count < 1 Then
                    strErrMsg = "����û��˽Ӷ���ݣ�"
                    GoTo errProc
                End If

                '�������¼���˽Ӷ��Ա����
                Dim i, intCount As Integer
                Dim strRYDM As String = ""
                With Me.m_objDataSet_SYBL.Tables(strTable)
                    intCount = .DefaultView.Count
                    For i = 0 To intCount - 1 Step 1
                        '������Ա����
                        strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM), "")
                        objDataRow = .DefaultView.Item(i).Row
                        '�����ͬ����ʱ�����Ա����
                        If objsystemEstateErshou.getRYJGXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, Me.m_strHTRQ, objRYJGXX) = False Then
                            GoTo errProc
                        End If
                        If objRYJGXX Is Nothing Then
                            strErrMsg = "���󣺲��ܼ���˽Ӷ��Ա���ݣ�"
                            GoTo errProc
                        End If
                        '��������
                        objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM) = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM), "")
                        objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC) = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC), "")
                        objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ) = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ), "")
                        objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC) = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC), "")
                        objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ) = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ), "")
                        objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH) = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH), 0)
                        '�������
                        Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objRYJGXX)
                    Next
                End With

                '��ʾ
                If Me.showDataGridInfo_SYBL(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�ɹ�
                objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ������˽Ӷ��Ա����ͬ����ϣ�")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objRYJGXX)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objRYJGXX)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub
        'zengxianglin 2010-03-22 ����

        Private Sub btnAddNew_SY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_SY.Click
            Me.doAddNew_SY("btnAddNew_SY")
        End Sub

        Private Sub btnUpdate_SY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate_SY.Click
            Me.doUpdate_SY("btnUpdate_SY")
        End Sub

        Private Sub btnDelete_SY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_SY.Click
            Me.doDelete_SY("btnDelete_SY")
        End Sub

        Private Sub btnAddNew_GY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_GY.Click
            Me.doAddNew_GY("btnAddNew_GY")
        End Sub

        Private Sub btnUpdate_GY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate_GY.Click
            Me.doUpdate_GY("btnUpdate_GY")
        End Sub

        Private Sub btnDelete_GY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_GY.Click
            Me.doDelete_GY("btnDelete_GY")
        End Sub

        Private Sub btnMake_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMake.Click
            Me.doMake("btnMake")
        End Sub

        'zengxianglin 2010-03-22 ����
        Private Sub btnSYBL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSYBL.Click
            Me.doSYBL("btnSYBL")
        End Sub
        'zengxianglin 2010-03-22 ����

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace
