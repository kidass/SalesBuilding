Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_rs_rskp_info
    ' 
    ' �������ʣ�
    '     �ɱ����ã�Ҳ�ɵ�������ģ��
    '
    ' ���������� 
    '   �����������Ͽ�Ƭ������ģ��
    '----------------------------------------------------------------

    Partial Class estate_rs_rskp_info
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub



        '***************************************************************************
        'zengxianglin 2009-01-12
        'zengxianglin 2009-01-12

        '***************************************************************************


        '***************************************************************************

        '***************************************************************************




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
        'Ӧ�ø����filecache�����·��
        Private m_cstrPathRootToCache As String = "temp/filecache/"
        'Ӧ�ø����ziyuan/image/rskp�����·��
        Private m_cstrPathRootToRskpImage As String = "ziyuan/image/rskp/"

        '----------------------------------------------------------------
        'ģ����Ȩ����
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_rskp_previlege_param"
        Private m_blnPrevilegeParams(2) As Boolean

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsRskpInfo
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsRskpInfo
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdJTCY��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdJTCY As String = "chkJTCY"
        Private Const m_cstrDataGridInDIV_grdJTCY As String = "divJTCY"
        Private m_intFixedColumns_grdJTCY As Integer
        Private Const m_cstrControlIdInDataGrid_grdJTCY_ddlJTCY_XYGX As String = "ddlJTCY_XYGX"
        Private Const m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_CYXM As String = "txtJTCY_CYXM"
        Private Const m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_CSNY As String = "txtJTCY_CSNY"
        Private Const m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_FWDW As String = "txtJTCY_FWDW"
        Private Const m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_DRZW As String = "txtJTCY_DRZW"
        Private Const m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_XZDZ As String = "txtJTCY_XZDZ"

        '----------------------------------------------------------------
        '����������grdXXJL��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdXXJL As String = "chkXXJL"
        Private Const m_cstrDataGridInDIV_grdXXJL As String = "divXXJL"
        Private m_intFixedColumns_grdXXJL As Integer
        Private Const m_cstrControlIdInDataGrid_grdXXJL_ddlXXJL_XXLX As String = "ddlXXJL_XXLX"
        Private Const m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_KSSJ As String = "txtXXJL_KSSJ"
        Private Const m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_JSSJ As String = "txtXXJL_JSSJ"
        Private Const m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_XXYX As String = "txtXXJL_XXYX"
        Private Const m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_XXZY As String = "txtXXJL_XXZY"
        Private Const m_cstrControlIdInDataGrid_grdXXJL_ddlXXJL_XXJG As String = "ddlXXJL_XXJG"

        '----------------------------------------------------------------
        '����������grdGZJL��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdGZJL As String = "chkGZJL"
        Private Const m_cstrDataGridInDIV_grdGZJL As String = "divGZJL"
        Private m_intFixedColumns_grdGZJL As Integer
        Private Const m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_KSSJ As String = "txtGZJL_KSSJ"
        Private Const m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_JSSJ As String = "txtGZJL_JSSJ"
        Private Const m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_FWDW As String = "txtGZJL_FWDW"
        Private Const m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_DRZW As String = "txtGZJL_DRZW"

        '----------------------------------------------------------------
        '��ǰ��������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet_MAIN As Josco.JSOA.Common.Data.estateRenshiGeneralData
        Private m_objDataSet_JTCY As Josco.JSOA.Common.Data.estateRenshiGeneralData
        Private m_objDataSet_XXJL As Josco.JSOA.Common.Data.estateRenshiGeneralData
        Private m_objDataSet_GZJL As Josco.JSOA.Common.Data.estateRenshiGeneralData

        '----------------------------------------------------------------
        '��������
        '----------------------------------------------------------------
        Private m_objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_blnEditMode As Boolean
        Private m_strRYDM As String

        Public ReadOnly Property propTPWZ() As String
            Get
                Try
                    If Me.htxtUploadFile.Value.Trim <> "" Then
                        propTPWZ = Request.ApplicationPath + "/" + Me.htxtUploadFile.Value.Trim
                    Else
                        propTPWZ = Request.ApplicationPath + "/" + Me.htxtRYXPWZ.Value.Trim
                    End If
                Catch ex As Exception
                    propTPWZ = ""
                End Try
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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsRskpInfo)
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
                    Me.htxtDivLeftJTCY.Value = .htxtDivLeftJTCY
                    Me.htxtDivTopJTCY.Value = .htxtDivTopJTCY
                    Me.htxtDivLeftXXJL.Value = .htxtDivLeftXXJL
                    Me.htxtDivTopXXJL.Value = .htxtDivTopXXJL
                    Me.htxtDivLeftGZJL.Value = .htxtDivLeftGZJL
                    Me.htxtDivTopGZJL.Value = .htxtDivTopGZJL

                    Me.htxtSessionId_JTCY.Value = .htxtSessionId_JTCY
                    Try
                        Me.grdJTCY.PageSize = .grdJTCY_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJTCY.CurrentPageIndex = .grdJTCY_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJTCY.SelectedIndex = .grdJTCY_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.htxtSessionId_XXJL.Value = .htxtSessionId_XXJL
                    Try
                        Me.grdXXJL.PageSize = .grdXXJL_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdXXJL.CurrentPageIndex = .grdXXJL_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdXXJL.SelectedIndex = .grdXXJL_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.htxtSessionId_GZJL.Value = .htxtSessionId_GZJL
                    Try
                        Me.grdGZJL.PageSize = .grdGZJL_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGZJL.CurrentPageIndex = .grdGZJL_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGZJL.SelectedIndex = .grdGZJL_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.ddlJSZC.SelectedIndex = .ddlJSZC_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlXL.SelectedIndex = .ddlXL_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlXW.SelectedIndex = .ddlXW_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlXXLX.SelectedIndex = .ddlXW_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlZYZG.SelectedIndex = .ddlZYZG_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlZZMM.SelectedIndex = .ddlZZMM_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.rblCYFYZT.SelectedIndex = .rblCYFYZT_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.rblGRFYZT.SelectedIndex = .rblGRFYZT_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.rblHYZK.SelectedIndex = .rblHYZK_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblRYXB.SelectedIndex = .rblRYXB_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblSYZK.SelectedIndex = .rblSYZK_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblZZQK1.SelectedIndex = .rblZZQK1_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblZZQK2.SelectedIndex = .rblZZQK2_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblHKZT.SelectedIndex = .rblHKZT_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblRYQYTX.SelectedIndex = .rblRYQYTX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.chkBRSDSZ.Checked = .chkBRSDSZ_Checked
                    Me.chkHYZK.Checked = .chkHYZK_Checked
                    Me.chkSFJZGB.Checked = .chkSFJZGB_Checked
                    Me.chkSFLDSZ.Checked = .chkSFLDSZ_Checked
                    Me.chkSFGHCY.Checked = .chkSFGHCY_Checked
                    Me.chkSFSGGB.Checked = .chkSFSGGB_Checked

                    Me.htxtUploadFile.Value = .htxtUploadFile
                    Me.htxtRYXPWZ.Value = .htxtRYXPWZ
                    Me.htxtBM.Value = .htxtBM
                    Me.htxtWYBS.Value = .htxtWYBS

                    Me.txtBYSJ.Text = .txtBYSJ
                    Me.txtBYYX.Text = .txtBYYX
                    Me.txtBYZY.Text = .txtBYZY
                    Me.txtCSNY.Text = .txtCSNY
                    Me.txtCYFYSM.Text = .txtCYFYSM
                    Me.txtGRFYJS.Text = .txtGRFYJS
                    Me.txtGRFYJS.Text = .txtGRFYJS
                    Me.txtGRFYKS.Text = .txtGRFYKS
                    Me.txtGRFYSM.Text = .txtGRFYSM
                    Me.txtHJDZ.Text = .txtHJDZ
                    Me.txtJG.Text = .txtJG
                    Me.txtMZ.Text = .txtMZ
                    Me.txtRDSJ.Text = .txtRDSJ
                    Me.txtRYDM.Text = .txtRYDM
                    Me.txtRYXM.Text = .txtRYXM
                    Me.txtXZDZ.Text = .txtXZDZ
                    Me.txtYJDZ.Text = .txtYJDZ
                    Me.txtZJZG.Text = .txtZJZG
                    Me.txtRBDWSJ.Text = .txtRBDWSJ
                    Me.txtCJGZSJ.Text = .txtCJGZSJ
                    'zengxianglin 2009-01-12
                    Me.txtTXSJ.Text = .txtTXSJ
                    'zengxianglin 2009-01-12
                    Me.txtZCQDSJ.Text = .txtZCQDSJ
                    'zengxianglin 2009-01-07
                    Me.txtZGQDSJ.Text = .txtZGQDSJ
                    'zengxianglin 2009-01-07
                    Me.txtYWM.Text = .txtYWM
                    Me.txtSJHM.Text = .txtSJHM
                    Me.txtZZDH.Text = .txtZZDH
                    Me.txtSFZH.Text = .txtSFZH
                    Me.txtZZGX.Text = .txtZZGX
                    Me.txtBM.Text = .txtBM
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsRskpInfo

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftJTCY = Me.htxtDivLeftJTCY.Value
                    .htxtDivTopJTCY = Me.htxtDivTopJTCY.Value
                    .htxtDivLeftXXJL = Me.htxtDivLeftXXJL.Value
                    .htxtDivTopXXJL = Me.htxtDivTopXXJL.Value
                    .htxtDivLeftGZJL = Me.htxtDivLeftGZJL.Value
                    .htxtDivTopGZJL = Me.htxtDivTopGZJL.Value

                    .htxtSessionId_JTCY = Me.htxtSessionId_JTCY.Value
                    .grdJTCY_PageSize = Me.grdJTCY.PageSize
                    .grdJTCY_CurrentPageIndex = Me.grdJTCY.CurrentPageIndex
                    .grdJTCY_SelectedIndex = Me.grdJTCY.SelectedIndex

                    .htxtSessionId_XXJL = Me.htxtSessionId_XXJL.Value
                    .grdXXJL_PageSize = Me.grdXXJL.PageSize
                    .grdXXJL_CurrentPageIndex = Me.grdXXJL.CurrentPageIndex
                    .grdXXJL_SelectedIndex = Me.grdXXJL.SelectedIndex

                    .htxtSessionId_GZJL = Me.htxtSessionId_GZJL.Value
                    .grdGZJL_PageSize = Me.grdGZJL.PageSize
                    .grdGZJL_CurrentPageIndex = Me.grdGZJL.CurrentPageIndex
                    .grdGZJL_SelectedIndex = Me.grdGZJL.SelectedIndex

                    .ddlJSZC_SelectedIndex = Me.ddlJSZC.SelectedIndex
                    .ddlXL_SelectedIndex = Me.ddlXL.SelectedIndex
                    .ddlXW_SelectedIndex = Me.ddlXW.SelectedIndex
                    .ddlXXLX_SelectedIndex = Me.ddlXXLX.SelectedIndex
                    .ddlZYZG_SelectedIndex = Me.ddlZYZG.SelectedIndex
                    .ddlZZMM_SelectedIndex = Me.ddlZZMM.SelectedIndex

                    .rblCYFYZT_SelectedIndex = Me.rblCYFYZT.SelectedIndex
                    .rblGRFYZT_SelectedIndex = Me.rblGRFYZT.SelectedIndex
                    .rblHYZK_SelectedIndex = Me.rblHYZK.SelectedIndex
                    .rblRYXB_SelectedIndex = Me.rblRYXB.SelectedIndex
                    .rblSYZK_SelectedIndex = Me.rblSYZK.SelectedIndex
                    .rblZZQK1_SelectedIndex = Me.rblZZQK1.SelectedIndex
                    .rblZZQK2_SelectedIndex = Me.rblZZQK2.SelectedIndex
                    .rblHKZT_SelectedIndex = Me.rblHKZT.SelectedIndex
                    .rblRYQYTX_SelectedIndex = Me.rblRYQYTX.SelectedIndex

                    .chkBRSDSZ_Checked = Me.chkBRSDSZ.Checked
                    .chkHYZK_Checked = Me.chkHYZK.Checked
                    .chkSFJZGB_Checked = Me.chkSFJZGB.Checked
                    .chkSFLDSZ_Checked = Me.chkSFLDSZ.Checked
                    .chkSFSGGB_Checked = Me.chkSFSGGB.Checked
                    .chkSFGHCY_Checked = Me.chkSFGHCY.Checked

                    .htxtUploadFile = Me.htxtUploadFile.Value
                    .htxtRYXPWZ = Me.htxtRYXPWZ.Value
                    .htxtBM = Me.htxtBM.Value
                    .htxtWYBS = Me.htxtWYBS.Value

                    .txtBYSJ = Me.txtBYSJ.Text
                    .txtBYYX = Me.txtBYYX.Text
                    .txtBYZY = Me.txtBYZY.Text
                    .txtCSNY = Me.txtCSNY.Text
                    .txtCYFYSM = Me.txtCYFYSM.Text
                    .txtGRFYJS = Me.txtGRFYJS.Text
                    .txtGRFYKS = Me.txtGRFYKS.Text
                    .txtGRFYSM = Me.txtGRFYSM.Text
                    .txtHJDZ = Me.txtHJDZ.Text
                    .txtJG = Me.txtJG.Text
                    .txtMZ = Me.txtMZ.Text
                    .txtRDSJ = Me.txtRDSJ.Text
                    .txtRYDM = Me.txtRYDM.Text
                    .txtRYXM = Me.txtRYXM.Text
                    .txtXZDZ = Me.txtXZDZ.Text
                    .txtYJDZ = Me.txtYJDZ.Text
                    .txtZJZG = Me.txtZJZG.Text

                    .txtRBDWSJ = Me.txtRBDWSJ.Text
                    .txtCJGZSJ = Me.txtCJGZSJ.Text
                    'zengxianglin 2009-01-12
                    .txtTXSJ = Me.txtTXSJ.Text
                    'zengxianglin 2009-01-12
                    .txtZCQDSJ = Me.txtZCQDSJ.Text
                    'zengxianglin 2009-01-07
                    .txtZGQDSJ = Me.txtZGQDSJ.Text
                    'zengxianglin 2009-01-07
                    .txtYWM = Me.txtYWM.Text
                    .txtSJHM = Me.txtSJHM.Text
                    .txtZZDH = Me.txtZZDH.Text
                    .txtSFZH = Me.txtSFZH.Text
                    .txtZZGX = Me.txtZZGX.Text
                    .txtBM = Me.txtBM.Text
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
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateRsRskpLdht As Josco.JSOA.BusinessFacade.IEstateRsRskpLdht = Nothing
                Try
                    objIEstateRsRskpLdht = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsRskpLdht)
                Catch ex As Exception
                    objIEstateRsRskpLdht = Nothing
                End Try
                If Not (objIEstateRsRskpLdht Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsRskpLdht.SafeRelease(objIEstateRsRskpLdht)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateRsRskpYdjl As Josco.JSOA.BusinessFacade.IEstateRsRskpYdjl = Nothing
                Try
                    objIEstateRsRskpYdjl = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsRskpYdjl)
                Catch ex As Exception
                    objIEstateRsRskpYdjl = Nothing
                End Try
                If Not (objIEstateRsRskpYdjl Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsRskpYdjl.SafeRelease(objIEstateRsRskpYdjl)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateRsRskpPxjl As Josco.JSOA.BusinessFacade.IEstateRsRskpPxjl = Nothing
                Try
                    objIEstateRsRskpPxjl = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsRskpPxjl)
                Catch ex As Exception
                    objIEstateRsRskpPxjl = Nothing
                End Try
                If Not (objIEstateRsRskpPxjl Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsRskpPxjl.SafeRelease(objIEstateRsRskpPxjl)
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
                        Select Case objIDmxzZzjg.iSourceControlId.ToUpper()
                            Case "btnSelect_BM".ToUpper()
                                Dim strMC As String = objIDmxzZzjg.oBumenList
                                Dim strDM As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strMC, strDM) = True Then
                                    Me.htxtBM.Value = strDM
                                    Me.txtBM.Text = strMC
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
                        Select Case objIDmxzRyxx.iSourceControlId.ToUpper()
                            Case "btnSelect_RYDM".ToUpper()
                                Me.txtRYDM.Text = objIDmxzRyxx.oRYDM
                                Me.txtRYXM.Text = objIDmxzRyxx.oRYZM
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

            getInterfaceParameters = False

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsRskpInfo)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    'û���нӿڲ���
                    Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    Me.m_strRYDM = ""
                Else
                    Me.m_blnInterface = True
                    '�нӿڲ���
                    Me.m_objenumEditType = Me.m_objInterface.iMode
                    Me.m_strRYDM = Me.m_objInterface.iRYDM
                End If
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Me.m_blnEditMode = True
                    Case Else
                        Me.m_blnEditMode = False
                End Select

                '��ȡ�ָ��ֳ�����
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsRskpInfo)
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
                Me.m_intFixedColumns_grdJTCY = objPulicParameters.getObjectValue(Me.htxtJTCYFixed.Value, 0)
                Me.m_intFixedColumns_grdXXJL = objPulicParameters.getObjectValue(Me.htxtXXJLFixed.Value, 0)
                Me.m_intFixedColumns_grdGZJL = objPulicParameters.getObjectValue(Me.htxtGZJLFixed.Value, 0)
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
        Private Function doDeleteTempFiles(ByRef strErrMsg As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            doDeleteTempFiles = False
            strErrMsg = ""

            Try
                'û�л���
                If Me.htxtUploadFile.Value.Trim = "" Then
                    Exit Try
                End If

                '���
                Dim strFileSpec As String = ""
                strFileSpec = Server.MapPath(Request.ApplicationPath + "/" + Me.htxtUploadFile.Value)
                If objBaseLocalFile.doDeleteFile(strErrMsg, strFileSpec) = False Then
                    GoTo errProc
                End If

                '��ԭ
                Me.htxtUploadFile.Value = ""
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            doDeleteTempFiles = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ͷű�ģ�黺��Ĳ���
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Dim strErrMsg As String = ""

            Try
                Dim objDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
                If Me.htxtSessionId_JTCY.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_JTCY.Value), Josco.JSOA.Common.Data.estateRenshiGeneralData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_JTCY.Value)
                    Me.htxtSessionId_JTCY.Value = ""
                End If
                If Me.htxtSessionId_XXJL.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_XXJL.Value), Josco.JSOA.Common.Data.estateRenshiGeneralData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_XXJL.Value)
                    Me.htxtSessionId_XXJL.Value = ""
                End If
                If Me.htxtSessionId_GZJL.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_GZJL.Value), Josco.JSOA.Common.Data.estateRenshiGeneralData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_GZJL.Value)
                    Me.htxtSessionId_GZJL.Value = ""
                End If

                '��������ļ�
                If Me.doDeleteTempFiles(strErrMsg) = False Then
                    '����
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub









        '----------------------------------------------------------------
        ' ��ȡҪ��ʾ����������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strRYDM        ����Ա����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_MAIN( _
            ByRef strErrMsg As String, _
            ByVal strRYDM As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_RENSHIKAPIAN
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral

            getModuleData_MAIN = False

            Try
                '���
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(Me.m_objDataSet_MAIN)

                '���¼�������
                Dim strWhere As String = "a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYDM + " = '" + strRYDM + "'"
                If objsystemEstateRenshiGeneral.getDataSet_RSKP(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objDataSet_MAIN) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)

            getModuleData_MAIN = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdJTCYҪ��ʾ������
        '     strErrMsg      �����ش�����Ϣ
        '     strRYDM        ����Ա����
        '     strWhere       �������ַ���
        '     blnEditMode    ��True-�༭ False-�鿴
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_JTCY( _
            ByRef strErrMsg As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_JIATINGCHENGYUAN
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_JTCY = False

            Try
                '���
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '��ȡ����
                If blnEditMode = True Then
                    If Me.htxtSessionId_JTCY.Value.Trim <> "" Then
                        '�ӻ����л�ȡ����
                        Me.m_objDataSet_JTCY = CType(Session.Item(Me.htxtSessionId_JTCY.Value), Josco.JSOA.Common.Data.estateRenshiGeneralData)
                    Else
                        '�ͷ���Դ
                        Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(Me.m_objDataSet_JTCY)
                        '���¼�������
                        If objsystemEstateRenshiGeneral.getDataSet_RSKP_JTCY(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strWhere, Me.m_objDataSet_JTCY) = False Then
                            GoTo errProc
                        End If
                        '��������
                        Me.htxtSessionId_JTCY.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtSessionId_JTCY.Value, Me.m_objDataSet_JTCY)
                    End If
                Else
                    '�ͷŻ�������
                    If Me.htxtSessionId_JTCY.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_JTCY = CType(Session.Item(Me.htxtSessionId_JTCY.Value), Josco.JSOA.Common.Data.estateRenshiGeneralData)
                        Catch ex As Exception
                            Me.m_objDataSet_JTCY = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(Me.m_objDataSet_JTCY)
                        Session.Remove(Me.htxtSessionId_JTCY.Value)
                        Me.htxtSessionId_JTCY.Value = ""
                    End If
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(Me.m_objDataSet_JTCY)
                    '���¼�������
                    If objsystemEstateRenshiGeneral.getDataSet_RSKP_JTCY(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strWhere, Me.m_objDataSet_JTCY) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getModuleData_JTCY = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdXXJLҪ��ʾ������
        '     strErrMsg      �����ش�����Ϣ
        '     strRYDM        ����Ա����
        '     strWhere       �������ַ���
        '     blnEditMode    ��True-�༭ False-�鿴
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_XXJL( _
            ByRef strErrMsg As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUEXIJINGLI
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_XXJL = False

            Try
                '���
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '��ȡ����
                If blnEditMode = True Then
                    If Me.htxtSessionId_XXJL.Value.Trim <> "" Then
                        '�ӻ����л�ȡ����
                        Me.m_objDataSet_XXJL = CType(Session.Item(Me.htxtSessionId_XXJL.Value), Josco.JSOA.Common.Data.estateRenshiGeneralData)
                    Else
                        '�ͷ���Դ
                        Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(Me.m_objDataSet_XXJL)
                        '���¼�������
                        If objsystemEstateRenshiGeneral.getDataSet_RSKP_XXJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strWhere, Me.m_objDataSet_XXJL) = False Then
                            GoTo errProc
                        End If
                        '��������
                        Me.htxtSessionId_XXJL.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtSessionId_XXJL.Value, Me.m_objDataSet_XXJL)
                    End If
                Else
                    '�ͷŻ�������
                    If Me.htxtSessionId_XXJL.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_XXJL = CType(Session.Item(Me.htxtSessionId_XXJL.Value), Josco.JSOA.Common.Data.estateRenshiGeneralData)
                        Catch ex As Exception
                            Me.m_objDataSet_XXJL = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(Me.m_objDataSet_XXJL)
                        Session.Remove(Me.htxtSessionId_XXJL.Value)
                        Me.htxtSessionId_XXJL.Value = ""
                    End If
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(Me.m_objDataSet_XXJL)
                    '���¼�������
                    If objsystemEstateRenshiGeneral.getDataSet_RSKP_XXJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strWhere, Me.m_objDataSet_XXJL) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getModuleData_XXJL = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdGZJLҪ��ʾ������
        '     strErrMsg      �����ش�����Ϣ
        '     strRYDM        ����Ա����
        '     strWhere       �������ַ���
        '     blnEditMode    ��True-�༭ False-�鿴
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_GZJL( _
            ByRef strErrMsg As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_GONGZUOJINGLI
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_GZJL = False

            Try
                '���
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '��ȡ����
                If blnEditMode = True Then
                    If Me.htxtSessionId_GZJL.Value.Trim <> "" Then
                        '�ӻ����л�ȡ����
                        Me.m_objDataSet_GZJL = CType(Session.Item(Me.htxtSessionId_GZJL.Value), Josco.JSOA.Common.Data.estateRenshiGeneralData)
                    Else
                        '�ͷ���Դ
                        Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(Me.m_objDataSet_GZJL)
                        '���¼�������
                        If objsystemEstateRenshiGeneral.getDataSet_RSKP_GZJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strWhere, Me.m_objDataSet_GZJL) = False Then
                            GoTo errProc
                        End If
                        '��������
                        Me.htxtSessionId_GZJL.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtSessionId_GZJL.Value, Me.m_objDataSet_GZJL)
                    End If
                Else
                    '�ͷŻ�������
                    If Me.htxtSessionId_GZJL.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_GZJL = CType(Session.Item(Me.htxtSessionId_GZJL.Value), Josco.JSOA.Common.Data.estateRenshiGeneralData)
                        Catch ex As Exception
                            Me.m_objDataSet_GZJL = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(Me.m_objDataSet_GZJL)
                        Session.Remove(Me.htxtSessionId_GZJL.Value)
                        Me.htxtSessionId_GZJL.Value = ""
                    End If
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(Me.m_objDataSet_GZJL)
                    '���¼�������
                    If objsystemEstateRenshiGeneral.getDataSet_RSKP_GZJL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, strWhere, Me.m_objDataSet_GZJL) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getModuleData_GZJL = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function










        '----------------------------------------------------------------
        ' ��ʾgrdJTCY������
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_JTCY( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_JIATINGCHENGYUAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_JTCY = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_JTCY Is Nothing Then
                    Me.grdJTCY.DataSource = Nothing
                Else
                    With Me.m_objDataSet_JTCY.Tables(strTable)
                        Me.grdJTCY.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_JTCY.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdJTCY, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdJTCY.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdJTCY, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdJTCY) = False Then
                    GoTo errProc
                End If

                '��ʾδ�󶨵���������
                If Me.showDataGridUnboundInfo_JTCY(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_JTCY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdXXJL������
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_XXJL( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUEXIJINGLI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_XXJL = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_XXJL Is Nothing Then
                    Me.grdXXJL.DataSource = Nothing
                Else
                    With Me.m_objDataSet_XXJL.Tables(strTable)
                        Me.grdXXJL.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_XXJL.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdXXJL, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdXXJL.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdXXJL, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdXXJL) = False Then
                    GoTo errProc
                End If

                '��ʾ����δ������
                If Me.showDataGridUnboundInfo_XXJL(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_XXJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdGZJL������
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_GZJL( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_GONGZUOJINGLI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_GZJL = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_GZJL Is Nothing Then
                    Me.grdGZJL.DataSource = Nothing
                Else
                    With Me.m_objDataSet_GZJL.Tables(strTable)
                        Me.grdGZJL.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_GZJL.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdGZJL, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdGZJL.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdGZJL, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGZJL) = False Then
                    GoTo errProc
                End If

                '��ʾ����δ������
                If Me.showDataGridUnboundInfo_GZJL(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_GZJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdJTCY�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_JTCY( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_JIATINGCHENGYUAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_JTCY = False
            strErrMsg = ""

            Try
                '��ʾδ������
                Dim objDropDownList As System.Web.UI.WebControls.DropDownList = Nothing
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdJTCY.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdJTCY.CurrentPageIndex, Me.grdJTCY.PageSize)
                    objDataRow = Me.m_objDataSet_JTCY.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���ddlJTCY_XYGX
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdJTCY.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJTCY_ddlJTCY_XYGX), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        objControlProcess.doTranslateKey(objDropDownList)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_XYGX), "")
                        If strValue = "" Then
                            objDropDownList.SelectedIndex = -1
                        Else
                            objDropDownList.SelectedIndex = objDropDownListProcess.getSelectedItem(objDropDownList, strValue)
                        End If
                        objControlProcess.doEnabledControl(objDropDownList, blnEditMode)
                    End If

                    '���txtJTCY_CYXM
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdJTCY.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_CYXM), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_CYXM), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���txtJTCY_CSNY
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdJTCY.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_CSNY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_CSNY), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���txtJTCY_FWDW
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdJTCY.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_FWDW), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_FWDW), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���txtJTCY_DRZW
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdJTCY.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_DRZW), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_DRZW), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���txtJTCY_XZDZ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdJTCY.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_XZDZ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_XJDZ), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showDataGridUnboundInfo_JTCY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdXXJL�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_XXJL( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUEXIJINGLI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_XXJL = False
            strErrMsg = ""

            Try
                '��ʾδ������
                Dim objDropDownList As System.Web.UI.WebControls.DropDownList = Nothing
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdXXJL.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdXXJL.CurrentPageIndex, Me.grdXXJL.PageSize)
                    objDataRow = Me.m_objDataSet_XXJL.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���ddlXXJL_XXLX
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_ddlXXJL_XXLX), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        objControlProcess.doTranslateKey(objDropDownList)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_XXLX), "")
                        If strValue = "" Then
                            objDropDownList.SelectedIndex = -1
                        Else
                            objDropDownList.SelectedIndex = objDropDownListProcess.getSelectedItem(objDropDownList, strValue)
                        End If
                        objControlProcess.doEnabledControl(objDropDownList, blnEditMode)
                    End If

                    '���txtXXJL_KSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_KSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        'zengxianglin 2009-01-12
                        'strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_KSNY), "")
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_KSNY), "", "yyyy-MM-dd")
                        'zengxianglin 2009-01-12
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���txtXXJL_JSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_JSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        'zengxianglin 2009-01-12
                        'strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_ZZNY), "")
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_ZZNY), "", "yyyy-MM-dd")
                        'zengxianglin 2009-01-12
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���txtXXJL_XXYX
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_XXYX), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_XXYX), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���txtXXJL_XXZY
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_XXZY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_XXZY), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���ddlXXJL_XXJG
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_ddlXXJL_XXJG), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        objControlProcess.doTranslateKey(objDropDownList)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_XXJG), "")
                        If strValue = "" Then
                            objDropDownList.SelectedIndex = -1
                        Else
                            objDropDownList.SelectedIndex = objDropDownListProcess.getSelectedItem(objDropDownList, strValue)
                        End If
                        objControlProcess.doEnabledControl(objDropDownList, blnEditMode)
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showDataGridUnboundInfo_XXJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdGZJL�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_GZJL( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_GONGZUOJINGLI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_GZJL = False
            strErrMsg = ""

            Try
                '��ʾδ������
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGZJL.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGZJL.CurrentPageIndex, Me.grdGZJL.PageSize)
                    objDataRow = Me.m_objDataSet_GZJL.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���txtGZJL_KSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_KSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_GONGZUOJINGLI_KSNY), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���txtGZJL_JSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_JSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_GONGZUOJINGLI_ZZNY), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���txtGZJL_FWDW
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_FWDW), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_GONGZUOJINGLI_FWDW), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���txtGZJL_DRZW
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_DRZW), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_GONGZUOJINGLI_DRZW), "")
                        If strValue = "" Then
                            objTextBox.Text = ""
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showDataGridUnboundInfo_GZJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����grdJTCY�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnValid       ��true-ִ����Ч�Լ��,false-��ִ��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_JTCY( _
            ByRef strErrMsg As String, _
            ByVal blnValid As Boolean, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_JIATINGCHENGYUAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_JTCY = False
            strErrMsg = ""

            Try
                '�鿴ģʽ�����ñ���
                If blnEditMode = False Then
                    Exit Try
                End If

                '����δ������
                Dim objDropDownList As System.Web.UI.WebControls.DropDownList = Nothing
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdJTCY.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdJTCY.CurrentPageIndex, Me.grdJTCY.PageSize)
                    objDataRow = Me.m_objDataSet_JTCY.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '����ddlJTCY_XYGX
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdJTCY.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJTCY_ddlJTCY_XYGX), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        If objDropDownList.SelectedIndex >= 0 Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_XYGX) = objDropDownList.SelectedValue
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_XYGX) = ""
                        End If
                    End If

                    '����txtJTCY_CYXM
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdJTCY.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_CYXM), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_CYXM) = objTextBox.Text.Trim
                    End If

                    '����txtJTCY_CSNY
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdJTCY.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_CSNY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_CSNY) = objTextBox.Text.Trim
                    End If

                    '����txtJTCY_FWDW
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdJTCY.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_FWDW), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_FWDW) = objTextBox.Text.Trim
                    End If

                    '����txtJTCY_DRZW
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdJTCY.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_DRZW), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_DRZW) = objTextBox.Text.Trim
                    End If

                    '����txtJTCY_XZDZ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdJTCY.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdJTCY_txtJTCY_XZDZ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_XJDZ) = objTextBox.Text.Trim
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_JTCY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����grdXXJL�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnValid       ��true-ִ����Ч�Լ��,false-��ִ��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_XXJL( _
            ByRef strErrMsg As String, _
            ByVal blnValid As Boolean, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUEXIJINGLI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_XXJL = False
            strErrMsg = ""

            Try
                '�鿴ģʽ�����ñ���
                If blnEditMode = False Then
                    Exit Try
                End If

                '����δ������
                Dim objDropDownList As System.Web.UI.WebControls.DropDownList = Nothing
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdXXJL.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdXXJL.CurrentPageIndex, Me.grdXXJL.PageSize)
                    objDataRow = Me.m_objDataSet_XXJL.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '����ddlXXJL_XXLX
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_ddlXXJL_XXLX), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        If objDropDownList.SelectedIndex >= 0 Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_XXLX) = objDropDownList.SelectedValue
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_XXLX) = ""
                        End If
                    End If

                    '����txtXXJL_KSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_KSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        'zengxianglin 2009-01-12
                        If blnValid = True Then
                            If objTextBox.Text.Trim = "" Then
                                strErrMsg = "����û������[��ʼ����]��"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(objTextBox.Text) = False Then
                                strErrMsg = "����[" + objTextBox.Text.Trim + "]����Ч�����ڣ�"
                                GoTo errProc
                            End If
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_KSNY) = objTextBox.Text.Trim
                        Else
                            If objTextBox.Text.Trim = "" Then
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_KSNY) = System.DBNull.Value
                            Else
                                If objPulicParameters.isDatetimeString(objTextBox.Text) = False Then
                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_KSNY) = System.DBNull.Value
                                Else
                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_KSNY) = objTextBox.Text.Trim
                                End If
                            End If
                        End If
                        'zengxianglin 2009-01-12
                    End If

                    '����txtXXJL_JSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_JSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        'zengxianglin 2009-01-12
                        If blnValid = True Then
                            If objTextBox.Text.Trim = "" Then
                                strErrMsg = "����û������[��ֹ����]��"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(objTextBox.Text) = False Then
                                strErrMsg = "����[" + objTextBox.Text.Trim + "]����Ч�����ڣ�"
                                GoTo errProc
                            End If
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_ZZNY) = objTextBox.Text.Trim
                        Else
                            If objTextBox.Text.Trim = "" Then
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_ZZNY) = System.DBNull.Value
                            Else
                                If objPulicParameters.isDatetimeString(objTextBox.Text) = False Then
                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_ZZNY) = System.DBNull.Value
                                Else
                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_ZZNY) = objTextBox.Text.Trim
                                End If
                            End If
                        End If
                        'zengxianglin 2009-01-12
                    End If

                    '����txtXXJL_XXYX
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_XXYX), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_XXYX) = objTextBox.Text.Trim
                    End If

                    '����txtXXJL_XXZY
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_txtXXJL_XXZY), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_XXZY) = objTextBox.Text.Trim
                    End If

                    '����ddlXXJL_XXJG
                    objDropDownList = Nothing
                    objDropDownList = CType(Me.grdXXJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdXXJL_ddlXXJL_XXJG), System.Web.UI.WebControls.DropDownList)
                    If Not (objDropDownList Is Nothing) Then
                        If objDropDownList.SelectedIndex >= 0 Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_XXJG) = objDropDownList.SelectedValue
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_XXJG) = ""
                        End If
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_XXJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����grdGZJL�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnValid       ��true-ִ����Ч�Լ��,false-��ִ��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_GZJL( _
            ByRef strErrMsg As String, _
            ByVal blnValid As Boolean, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_GONGZUOJINGLI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_GZJL = False
            strErrMsg = ""

            Try
                '�鿴ģʽ�����ñ���
                If blnEditMode = False Then
                    Exit Try
                End If

                '����δ������
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGZJL.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGZJL.CurrentPageIndex, Me.grdGZJL.PageSize)
                    objDataRow = Me.m_objDataSet_GZJL.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '����txtGZJL_KSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_KSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_GONGZUOJINGLI_KSNY) = objTextBox.Text.Trim
                    End If

                    '����txtGZJL_JSSJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_JSSJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_GONGZUOJINGLI_ZZNY) = objTextBox.Text.Trim
                    End If

                    '����txtGZJL_FWDW
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_FWDW), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_GONGZUOJINGLI_FWDW) = objTextBox.Text.Trim
                    End If

                    '����txtGZJL_DRZW
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGZJL.Items(i).FindControl(Me.m_cstrControlIdInDataGrid_grdGZJL_txtGZJL_DRZW), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_GONGZUOJINGLI_DRZW) = objTextBox.Text.Trim
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_GZJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾģ������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showEditPanel_MAIN( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_RENSHIKAPIAN
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showEditPanel_MAIN = False
            strErrMsg = ""

            Try
                '��ʾֵ
                Dim strValue As String = ""
                Dim intValue As Integer = 0
                If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                    With Me.m_objDataSet_MAIN.Tables(strTable)
                        If .Rows.Count < 1 Then
                            '���ÿ�ֵ
                            Me.ddlJSZC.SelectedIndex = -1
                            Me.ddlXL.SelectedIndex = -1
                            Me.ddlXW.SelectedIndex = -1
                            Me.ddlXXLX.SelectedIndex = -1
                            Me.ddlZYZG.SelectedIndex = -1
                            Me.ddlZZMM.SelectedIndex = -1

                            Me.rblCYFYZT.SelectedIndex = -1
                            Me.rblGRFYZT.SelectedIndex = -1
                            Me.rblHYZK.SelectedIndex = -1
                            Me.rblRYXB.SelectedIndex = -1
                            Me.rblSYZK.SelectedIndex = -1
                            Me.rblZZQK1.SelectedIndex = -1
                            Me.rblZZQK2.SelectedIndex = -1
                            Me.rblHKZT.SelectedIndex = -1
                            Me.rblRYQYTX.SelectedIndex = -1

                            Me.chkBRSDSZ.Checked = False
                            Me.chkHYZK.Checked = False
                            Me.chkSFJZGB.Checked = False
                            Me.chkSFLDSZ.Checked = False
                            Me.chkSFSGGB.Checked = False
                            Me.chkSFGHCY.Checked = False

                            Me.htxtUploadFile.Value = ""
                            Me.htxtRYXPWZ.Value = ""
                            Me.htxtBM.Value = ""
                            Me.htxtWYBS.Value = ""

                            Me.txtBYSJ.Text = ""
                            Me.txtBYYX.Text = ""
                            Me.txtBYZY.Text = ""
                            Me.txtCSNY.Text = ""
                            Me.txtCYFYSM.Text = ""
                            Me.txtGRFYJS.Text = ""
                            Me.txtGRFYKS.Text = ""
                            Me.txtGRFYSM.Text = ""
                            Me.txtHJDZ.Text = ""
                            Me.txtJG.Text = ""
                            Me.txtMZ.Text = ""
                            Me.txtRDSJ.Text = ""
                            Me.txtRYDM.Text = ""
                            Me.txtRYXM.Text = ""
                            Me.txtXZDZ.Text = ""
                            Me.txtYJDZ.Text = ""
                            Me.txtZJZG.Text = ""
                            Me.txtRBDWSJ.Text = ""
                            Me.txtCJGZSJ.Text = ""
                            'zengxianglin 2009-01-12
                            Me.txtTXSJ.Text = ""
                            'zengxianglin 2009-01-12
                            Me.txtZCQDSJ.Text = ""
                            'zengxianglin 2009-01-07
                            Me.txtZGQDSJ.Text = ""
                            'zengxianglin 2009-01-07
                            Me.txtYWM.Text = ""
                            Me.txtSJHM.Text = ""
                            Me.txtZZDH.Text = ""
                            Me.txtSFZH.Text = ""
                            Me.txtZZGX.Text = ""
                            Me.txtBM.Text = ""
                        Else
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JSZC), "")
                            Me.ddlJSZC.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlJSZC, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXL), "")
                            Me.ddlXL.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlXL, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXW), "")
                            Me.ddlXW.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlXW, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_XXLX), "")
                            Me.ddlXXLX.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlXXLX, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZYZG), "")
                            Me.ddlZYZG.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZYZG, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZMM), "")
                            Me.ddlZZMM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZZMM, strValue)

                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CYFYZT), "")
                            Me.rblCYFYZT.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblCYFYZT, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYZT), "")
                            Me.rblGRFYZT.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblGRFYZT, strValue)

                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SYZK), "")
                            Me.rblSYZK.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSYZK, strValue)
                            intValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HYZK), 0)
                            Me.rblHYZK.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblHYZK, (intValue And 3).ToString)
                            Me.chkHYZK.Checked = (intValue And 4) = 4
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_XB), "")
                            Me.rblRYXB.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYXB, strValue)
                            intValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JZQK), 0)
                            Me.rblZZQK1.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblZZQK1, (intValue And 3).ToString)
                            Me.rblZZQK2.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblZZQK2, (intValue And 12).ToString)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HKZT), "")
                            Me.rblHKZT.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblHKZT, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYQYTX), "")
                            Me.rblRYQYTX.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYQYTX, strValue)

                            Select Case objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BRSDSZ), "")
                                Case "1"
                                    Me.chkBRSDSZ.Checked = True
                                Case Else
                                    Me.chkBRSDSZ.Checked = False
                            End Select
                            Select Case objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFJZGB), "")
                                Case "1"
                                    Me.chkSFJZGB.Checked = True
                                Case Else
                                    Me.chkSFJZGB.Checked = False
                            End Select
                            Select Case objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFLDSZ), "")
                                Case "1"
                                    Me.chkSFLDSZ.Checked = True
                                Case Else
                                    Me.chkSFLDSZ.Checked = False
                            End Select
                            Select Case objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFGHCY), "")
                                Case "1"
                                    Me.chkSFGHCY.Checked = True
                                Case Else
                                    Me.chkSFGHCY.Checked = False
                            End Select
                            Select Case objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFSGGB), "")
                                Case "1"
                                    Me.chkSFSGGB.Checked = True
                                Case Else
                                    Me.chkSFSGGB.Checked = False
                            End Select

                            Me.htxtUploadFile.Value = ""
                            Me.htxtRYXPWZ.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYXPWZ), "")
                            Me.htxtBM.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BMDM), "")
                            Me.htxtWYBS.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_WYBS), "")

                            Me.txtBYSJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BYSJ), "", "yyyy-MM-dd")
                            Me.txtBYYX.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BYYX), "")
                            Me.txtBYZY.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BYZY), "")
                            Me.txtCSNY.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CSRQ), "", "yyyy-MM-dd")
                            Me.txtCYFYSM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CYFYSM), "")
                            Me.txtGRFYJS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYJS), "", "yyyy-MM-dd")
                            Me.txtGRFYKS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYKS), "", "yyyy-MM-dd")
                            Me.txtGRFYSM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYSM), "")
                            Me.txtHJDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HJDZ), "")
                            Me.txtJG.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JG), "")
                            Me.txtMZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_MZ), "")
                            Me.txtRDSJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RDSJ), "", "yyyy-MM-dd")
                            Me.txtRYDM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYDM), "")
                            Me.txtRYXM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_XM), "")
                            Me.txtXZDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_XZDZ), "")
                            Me.txtYJDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_YJDZ), "")
                            Me.txtZJZG.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZJZG), "")
                            Me.txtRBDWSJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RBDWSJ), "", "yyyy-MM-dd")
                            Me.txtCJGZSJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CJGZSJ), "", "yyyy-MM-dd")
                            'zengxianglin 2009-01-12
                            Me.txtTXSJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_TXSJ), "", "yyyy-MM-dd")
                            'zengxianglin 2009-01-12
                            Me.txtZCQDSJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZCQDSJ), "", "yyyy-MM-dd")
                            'zengxianglin 2009-01-07
                            Me.txtZGQDSJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ), "", "yyyy-MM-dd")
                            'zengxianglin 2009-01-07
                            Me.txtYWM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_YWXM), "")
                            Me.txtSJHM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SJHM), "")
                            Me.txtZZDH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZDH), "")
                            Me.txtSFZH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFZH), "")
                            Me.txtZZGX.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZGX), "")
                            Me.txtBM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BMMC), "")
                        End If
                    End With
                End If

                '��������
                objControlProcess.doEnabledControl(Me.ddlJSZC, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlXL, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlXW, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlXXLX, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlZYZG, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlZZMM, blnEditMode)

                objControlProcess.doEnabledControl(Me.rblCYFYZT, blnEditMode)
                'zengxianglin 2009-01-07
                objControlProcess.doEnabledControl(Me.rblGRFYZT, blnEditMode)
                'zengxianglin 2009-01-07
                objControlProcess.doEnabledControl(Me.rblHYZK, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblRYXB, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSYZK, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblZZQK1, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblZZQK2, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblHKZT, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblRYQYTX, blnEditMode)

                objControlProcess.doEnabledControl(Me.chkBRSDSZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.chkHYZK, blnEditMode)
                objControlProcess.doEnabledControl(Me.chkSFJZGB, blnEditMode)
                objControlProcess.doEnabledControl(Me.chkSFLDSZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.chkSFSGGB, blnEditMode)
                objControlProcess.doEnabledControl(Me.chkSFGHCY, blnEditMode)

                objControlProcess.doEnabledControl(Me.txtBYSJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBYYX, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBYZY, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtCSNY, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtCYFYSM, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtGRFYJS, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtGRFYKS, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtGRFYSM, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtHJDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJG, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtMZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtRDSJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtRYDM, False)
                objControlProcess.doEnabledControl(Me.txtRYXM, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtXZDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYJDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZJZG, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtRBDWSJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtCJGZSJ, blnEditMode)
                'zengxianglin 2009-01-12
                objControlProcess.doEnabledControl(Me.txtTXSJ, blnEditMode)
                'zengxianglin 2009-01-12
                objControlProcess.doEnabledControl(Me.txtZCQDSJ, blnEditMode)
                'zengxianglin 2009-01-07
                objControlProcess.doEnabledControl(Me.txtZGQDSJ, blnEditMode)
                'zengxianglin 2009-01-07
                objControlProcess.doEnabledControl(Me.txtYWM, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtSJHM, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZZDH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtSFZH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZZGX, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBM, False)

                Me.btnSelect_RYDM.Visible = blnEditMode
                Me.btnSelect_BM.Visible = blnEditMode

                Me.btnAddNew_GZJL.Visible = blnEditMode And Me.m_blnPrevilegeParams(1)
                Me.btnAddNew_JTCY.Visible = blnEditMode And Me.m_blnPrevilegeParams(1)
                Me.btnAddNew_XXJL.Visible = blnEditMode And Me.m_blnPrevilegeParams(1)

                Me.btnDelete_GZJL.Visible = blnEditMode And Me.m_blnPrevilegeParams(1)
                Me.btnDelete_JTCY.Visible = blnEditMode And Me.m_blnPrevilegeParams(1)
                Me.btnDelete_XXJL.Visible = blnEditMode And Me.m_blnPrevilegeParams(1)

                Me.lnkUpload.Visible = blnEditMode And Me.m_blnPrevilegeParams(1)

                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                    Case Else
                        Me.btnSelect_RYDM.Visible = False
                End Select
                Me.filePicture.Visible = blnEditMode
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanel_MAIN = True
            Exit Function
errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾģ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_MAIN( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            showModuleData_MAIN = False

            Try
                Me.btnOK.Visible = blnEditMode And Me.m_blnPrevilegeParams(1)
                Me.btnCancel.Visible = blnEditMode

                Me.btnClose.Visible = Not blnEditMode
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
        ' ���ѧ�������б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doFillXueliList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUELIHUAFEN
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillXueliList = False
            strErrMsg = ""

            Try
                '���
                If objDropDownList Is Nothing Then
                    strErrMsg = "����[doFillXueliList]�ӿڲ�������ȷ��"
                    GoTo errProc
                End If

                '��ȡ����
                If objsystemEstateRenshiGeneral.getDataSet_XueliHuafen(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiGeneralData) = False Then
                    GoTo errProc
                End If

                '��������б�
                objDropDownList.Items.Clear()
                objDropDownList.Items.Add("")

                '�������
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUELIHUAFEN_XLDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUELIHUAFEN_XLMC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillXueliList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���ѧλ�����б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doFillXueweiList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUEWEIHUAFEN
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillXueweiList = False
            strErrMsg = ""

            Try
                '���
                If objDropDownList Is Nothing Then
                    strErrMsg = "����[doFillXueweiList]�ӿڲ�������ȷ��"
                    GoTo errProc
                End If

                '��ȡ����
                If objsystemEstateRenshiGeneral.getDataSet_XueweiHuafen(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiGeneralData) = False Then
                    GoTo errProc
                End If

                '��������б�
                objDropDownList.Items.Clear()
                objDropDownList.Items.Add("")

                '�������
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEWEIHUAFEN_XWDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEWEIHUAFEN_XWMC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillXueweiList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���������ò�����б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doFillZzmmList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_ZHENGZHIMIANMAO
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillZzmmList = False
            strErrMsg = ""

            Try
                '���
                If objDropDownList Is Nothing Then
                    strErrMsg = "����[doFillZzmmList]�ӿڲ�������ȷ��"
                    GoTo errProc
                End If

                '��ȡ����
                If objsystemEstateRenshiGeneral.getDataSet_ZhengzhiMianmao(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiGeneralData) = False Then
                    GoTo errProc
                End If

                '��������б�
                objDropDownList.Items.Clear()
                objDropDownList.Items.Add("")

                '�������
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHENGZHIMIANMAO_MMDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHENGZHIMIANMAO_MMMC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillZzmmList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���ִҵ�ʸ������б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doFillZyzgList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_ZHIYEZIGE
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillZyzgList = False
            strErrMsg = ""

            Try
                '���
                If objDropDownList Is Nothing Then
                    strErrMsg = "����[doFillZyzgList]�ӿڲ�������ȷ��"
                    GoTo errProc
                End If

                '��ȡ����
                If objsystemEstateRenshiGeneral.getDataSet_ZhiyeZige(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiGeneralData) = False Then
                    GoTo errProc
                End If

                '��������б�
                objDropDownList.Items.Clear()
                objDropDownList.Items.Add("")

                '�������
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIYEZIGE_ZGDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIYEZIGE_ZGMC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillZyzgList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��似��ְ�������б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doFillJszcList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_JISHUZHICHENG
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillJszcList = False
            strErrMsg = ""

            Try
                '���
                If objDropDownList Is Nothing Then
                    strErrMsg = "����[doFillJszcList]�ӿڲ�������ȷ��"
                    GoTo errProc
                End If

                '��ȡ����
                If objsystemEstateRenshiGeneral.getDataSet_JishuZhicheng(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiGeneralData) = False Then
                    GoTo errProc
                End If

                '��������б�
                objDropDownList.Items.Clear()
                objDropDownList.Items.Add("")

                '�������
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JISHUZHICHENG_ZCDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JISHUZHICHENG_ZCMC), "")

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

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillJszcList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʼ���ؼ�
        '----------------------------------------------------------------
        Private Function initializeControls(ByRef strErrMsg As String) As Boolean

            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            initializeControls = False

            Try
                '���ڵ�һ�ε���ҳ��ʱִ��
                If Me.IsPostBack = False Then
                    '��ʾPannel(�����Ƿ�ص���ʼ����ʾpanelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                    objControlProcess.doTranslateKey(Me.ddlJSZC)
                    objControlProcess.doTranslateKey(Me.ddlXL)
                    objControlProcess.doTranslateKey(Me.ddlXW)
                    objControlProcess.doTranslateKey(Me.ddlXXLX)
                    objControlProcess.doTranslateKey(Me.ddlZYZG)
                    objControlProcess.doTranslateKey(Me.ddlZZMM)

                    objControlProcess.doTranslateKey(Me.txtBYSJ)
                    objControlProcess.doTranslateKey(Me.txtBYYX)
                    objControlProcess.doTranslateKey(Me.txtBYZY)
                    objControlProcess.doTranslateKey(Me.txtCSNY)
                    objControlProcess.doTranslateKey(Me.txtCYFYSM)
                    objControlProcess.doTranslateKey(Me.txtGRFYJS)
                    objControlProcess.doTranslateKey(Me.txtGRFYKS)
                    objControlProcess.doTranslateKey(Me.txtGRFYSM)
                    objControlProcess.doTranslateKey(Me.txtHJDZ)
                    objControlProcess.doTranslateKey(Me.txtJG)
                    objControlProcess.doTranslateKey(Me.txtMZ)
                    objControlProcess.doTranslateKey(Me.txtRDSJ)
                    objControlProcess.doTranslateKey(Me.txtRYDM)
                    objControlProcess.doTranslateKey(Me.txtRYXM)
                    objControlProcess.doTranslateKey(Me.txtXZDZ)
                    objControlProcess.doTranslateKey(Me.txtYJDZ)
                    objControlProcess.doTranslateKey(Me.txtZJZG)
                    objControlProcess.doTranslateKey(Me.txtRBDWSJ)
                    objControlProcess.doTranslateKey(Me.txtCJGZSJ)
                    'zengxianglin 2009-01-12
                    objControlProcess.doTranslateKey(Me.txtTXSJ)
                    'zengxianglin 2009-01-12
                    objControlProcess.doTranslateKey(Me.txtZCQDSJ)
                    'zengxianglin 2009-01-07
                    objControlProcess.doTranslateKey(Me.txtZGQDSJ)
                    'zengxianglin 2009-01-07
                    objControlProcess.doTranslateKey(Me.txtYWM)
                    objControlProcess.doTranslateKey(Me.txtSJHM)
                    objControlProcess.doTranslateKey(Me.txtZZDH)
                    objControlProcess.doTranslateKey(Me.txtSFZH)
                    objControlProcess.doTranslateKey(Me.txtZZGX)
                    objControlProcess.doTranslateKey(Me.txtBM)

                    '���ʼֵ

                    '��ʾMain
                    If Me.showModuleData_MAIN(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_MAIN(strErrMsg, Me.m_strRYDM) = False Then
                        GoTo errProc
                    End If
                    If Me.showEditPanel_MAIN(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    If Me.getModuleData_JTCY(strErrMsg, Me.m_strRYDM, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_JTCY(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    If Me.getModuleData_XXJL(strErrMsg, Me.m_strRYDM, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_XXJL(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    If Me.getModuleData_GZJL(strErrMsg, Me.m_strRYDM, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_GZJL(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                Else
                    '��ȡ��������
                    If Me.getModuleData_JTCY(strErrMsg, Me.m_strRYDM, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_XXJL(strErrMsg, Me.m_strRYDM, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_GZJL(strErrMsg, Me.m_strRYDM, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

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

            Try
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
                    If Me.doFillJszcList(strErrMsg, Me.ddlJSZC) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillXueliList(strErrMsg, Me.ddlXL) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillXueweiList(strErrMsg, Me.ddlXW) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillZyzgList(strErrMsg, Me.ddlZYZG) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillZzmmList(strErrMsg, Me.ddlZZMM) = False Then
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
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try
normExit:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub











        '---------------------------------------------------------------------------------------------------------------------------
        '�����¼�������
        '---------------------------------------------------------------------------------------------------------------------------
        Sub grdJTCY_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdJTCY.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdJTCY + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdJTCY > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdJTCY - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdJTCY.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdXXJL_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdXXJL.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdXXJL + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdXXJL > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdXXJL - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdXXJL.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdGZJL_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdGZJL.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdGZJL + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdGZJL > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdGZJL - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdGZJL.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub











        Private Sub doCancel(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 1

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

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
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

        Private Sub doDelete_JTCY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_JIATINGCHENGYUAN
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���滺������
                If Me.saveDataGridUnboundInfo_JTCY(strErrMsg, True, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
                'ɾ��ѡ����
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdJTCY.Items.Count
                For i = intCount - 1 To 0 Step -1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdJTCY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdJTCY) = True Then
                        With Me.m_objDataSet_JTCY.Tables(strTable)
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdJTCY.CurrentPageIndex, Me.grdJTCY.PageSize)
                            objDataRow = Nothing
                            objDataRow = .DefaultView.Item(intRecPos).Row
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                        End With
                    End If
                Next
                '������ʾ
                If Me.showDataGridInfo_JTCY(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doDelete_XXJL(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUEXIJINGLI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���滺������
                If Me.saveDataGridUnboundInfo_XXJL(strErrMsg, False, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
                'ɾ��ѡ����
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdXXJL.Items.Count
                For i = intCount - 1 To 0 Step -1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdXXJL.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdXXJL) = True Then
                        With Me.m_objDataSet_XXJL.Tables(strTable)
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdXXJL.CurrentPageIndex, Me.grdXXJL.PageSize)
                            objDataRow = Nothing
                            objDataRow = .DefaultView.Item(intRecPos).Row
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                        End With
                    End If
                Next
                '������ʾ
                If Me.showDataGridInfo_XXJL(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doDelete_GZJL(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_GONGZUOJINGLI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���滺������
                If Me.saveDataGridUnboundInfo_GZJL(strErrMsg, True, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
                'ɾ��ѡ����
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGZJL.Items.Count
                For i = intCount - 1 To 0 Step -1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdGZJL.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdGZJL) = True Then
                        With Me.m_objDataSet_GZJL.Tables(strTable)
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGZJL.CurrentPageIndex, Me.grdGZJL.PageSize)
                            objDataRow = Nothing
                            objDataRow = .DefaultView.Item(intRecPos).Row
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                        End With
                    End If
                Next
                '������ʾ
                If Me.showDataGridInfo_GZJL(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doAddNew_JTCY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_JIATINGCHENGYUAN
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���滺������
                If Me.saveDataGridUnboundInfo_JTCY(strErrMsg, True, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
                '����
                With Me.m_objDataSet_JTCY.Tables(strTable)
                    .Rows.Add(.NewRow())
                End With
                '������ʾ
                If Me.showDataGridInfo_JTCY(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doAddNew_XXJL(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUEXIJINGLI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���滺������
                If Me.saveDataGridUnboundInfo_XXJL(strErrMsg, False, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
                '����
                With Me.m_objDataSet_XXJL.Tables(strTable)
                    .Rows.Add(.NewRow())
                End With
                '������ʾ
                If Me.showDataGridInfo_XXJL(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doAddNew_GZJL(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_GONGZUOJINGLI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���滺������
                If Me.saveDataGridUnboundInfo_GZJL(strErrMsg, True, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
                '����
                With Me.m_objDataSet_GZJL.Tables(strTable)
                    .Rows.Add(.NewRow())
                End With
                '������ʾ
                If Me.showDataGridInfo_GZJL(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doSelect_BM(ByVal strControlId As String)

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
                    .iMultiSelect = False
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

        Private Sub doUploadFile(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.filePicture.PostedFile Is Nothing Then
                    'û���ϴ��ļ�
                    Exit Try
                End If
                If Me.filePicture.PostedFile.FileName Is Nothing Then
                    'û���ϴ��ļ�
                    Exit Try
                End If
                If Me.filePicture.PostedFile.FileName.Trim = "" Then
                    'û���ϴ��ļ�
                    Exit Try
                End If

                '��������ļ�
                Dim strFileSpec As String = ""
                If Me.doDeleteTempFiles(strErrMsg) = False Then
                    '�γ������ļ�
                End If

                '�����ϴ��ļ�������Ŀ¼
                Dim strHttpPath As String = ""
                Dim strFileName As String = ""
                strFileSpec = Me.filePicture.PostedFile.FileName
                If objBaseLocalFile.doCreateTempFile(strErrMsg, strFileSpec, True, strFileName) = False Then
                    GoTo errProc
                End If
                strHttpPath = Me.m_cstrPathRootToCache + strFileName
                strFileSpec = Server.MapPath(Request.ApplicationPath + "/" + strHttpPath)
                Me.filePicture.PostedFile.SaveAs(strFileSpec)
                Me.htxtUploadFile.Value = strHttpPath
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOK(ByVal strControlId As String)

            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objNewData As New System.Collections.Specialized.NameValueCollection
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���滺������
                If Me.saveDataGridUnboundInfo_JTCY(strErrMsg, True, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
                If Me.saveDataGridUnboundInfo_XXJL(strErrMsg, True, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If
                If Me.saveDataGridUnboundInfo_GZJL(strErrMsg, True, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

                '�ϴ��ļ�
                Dim strBasePath As String = Me.m_cstrPathRootToRskpImage
                Dim strSrcLocFileSpec As String = ""
                Me.doUploadFile(strControlId)
                If Me.htxtUploadFile.Value.Trim <> "" Then
                    strSrcLocFileSpec = Server.MapPath(Request.ApplicationPath + "/" + Me.htxtUploadFile.Value)
                End If

                '׼���ӿ�����
                objNewData.Clear()
                '********************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_WYBS, Me.htxtWYBS.Value.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BMDM, Me.htxtBM.Value.Trim)
                '********************************************************************************************************************
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BYSJ, Me.txtBYSJ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BYYX, Me.txtBYYX.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BYZY, Me.txtBYZY.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CSRQ, Me.txtCSNY.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CYFYSM, Me.txtCYFYSM.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYJS, Me.txtGRFYJS.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYKS, Me.txtGRFYKS.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYSM, Me.txtGRFYSM.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HJDZ, Me.txtHJDZ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JG, Me.txtJG.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_MZ, Me.txtMZ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RDSJ, Me.txtRDSJ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYDM, Me.txtRYDM.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_XM, Me.txtRYXM.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_XZDZ, Me.txtXZDZ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_YJDZ, Me.txtYJDZ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZJZG, Me.txtZJZG.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RBDWSJ, Me.txtRBDWSJ.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CJGZSJ, Me.txtCJGZSJ.Text.Trim)
                'zengxianglin 2009-01-12
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_TXSJ, Me.txtTXSJ.Text.Trim)
                'zengxianglin 2009-01-12
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZCQDSJ, Me.txtZCQDSJ.Text.Trim)
                'zengxianglin 2009-01-07
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ, Me.txtZGQDSJ.Text.Trim)
                'zengxianglin 2009-01-07
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_YWXM, Me.txtYWM.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SJHM, Me.txtSJHM.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZDH, Me.txtZZDH.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFZH, Me.txtSFZH.Text.Trim)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZGX, Me.txtZZGX.Text.Trim)
                '********************************************************************************************************************
                If Me.chkSFGHCY.Checked = True Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFGHCY, "1")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFGHCY, "0")
                End If
                If Me.chkSFSGGB.Checked = True Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFSGGB, "1")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFSGGB, "0")
                End If
                If Me.chkSFLDSZ.Checked = True Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFLDSZ, "1")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFLDSZ, "0")
                End If
                If Me.chkSFJZGB.Checked = True Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFJZGB, "1")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFJZGB, "0")
                End If
                If Me.chkBRSDSZ.Checked = True Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BRSDSZ, "1")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BRSDSZ, "0")
                End If
                '********************************************************************************************************************
                Dim intValue As Integer = 0
                Select Case Me.rblHYZK.SelectedIndex
                    Case 0, 1
                        intValue = CType(Me.rblHYZK.SelectedValue, Integer)
                    Case Else
                End Select
                If Me.chkHYZK.Checked = True Then
                    intValue += 4
                End If
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HYZK, intValue.ToString)
                '********************************************************************************************************************
                If Me.rblCYFYZT.SelectedIndex > 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CYFYZT, Me.rblCYFYZT.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CYFYZT, "0")
                End If
                If Me.rblGRFYZT.SelectedIndex > 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYZT, Me.rblGRFYZT.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYZT, "0")
                End If
                '********************************************************************************************************************
                If Me.rblRYXB.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_XB, Me.rblRYXB.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_XB, "��")
                End If
                '********************************************************************************************************************
                If Me.rblSYZK.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SYZK, Me.rblSYZK.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SYZK, "0")
                End If
                '********************************************************************************************************************
                If Me.rblZZQK1.SelectedIndex >= 0 Then
                    Select Case Me.rblZZQK1.SelectedValue
                        Case "1"
                            Select Case Me.rblZZQK2.SelectedIndex
                                Case 0, 1
                                    intValue = 1
                                    intValue = intValue + CType(Me.rblZZQK2.SelectedValue, Integer)
                                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JZQK, intValue.ToString)
                                Case Else
                                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JZQK, Me.rblZZQK1.SelectedValue)
                            End Select
                        Case Else
                            objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JZQK, Me.rblZZQK1.SelectedValue)
                    End Select
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JZQK, "0")
                End If
                '********************************************************************************************************************
                If Me.rblHKZT.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HKZT, Me.rblHKZT.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HKZT, "0")
                End If
                '********************************************************************************************************************
                If Me.rblRYQYTX.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYQYTX, Me.rblRYQYTX.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYQYTX, "0")
                End If
                '********************************************************************************************************************
                If Me.ddlJSZC.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JSZC, Me.ddlJSZC.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JSZC, "")
                End If
                '********************************************************************************************************************
                If Me.ddlXL.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXL, Me.ddlXL.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXL, "")
                End If
                '********************************************************************************************************************
                If Me.ddlXW.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXW, Me.ddlXW.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXW, "")
                End If
                '********************************************************************************************************************
                If Me.ddlXXLX.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_XXLX, Me.ddlXXLX.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_XXLX, "")
                End If
                '********************************************************************************************************************
                If Me.ddlZYZG.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZYZG, Me.ddlZYZG.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZYZG, "")
                End If
                '********************************************************************************************************************
                If Me.ddlZZMM.SelectedIndex >= 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZMM, Me.ddlZZMM.SelectedValue)
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZMM, "")
                End If

                '��������
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        objNewData(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_WYBS) = ""
                        If objsystemEstateRenshiGeneral.doSaveData_RSKP(strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                            objNewData, Nothing, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                             strSrcLocFileSpec, Request.ApplicationPath, strBasePath, Server, _
                             Me.m_objDataSet_JTCY, _
                             Me.m_objDataSet_XXJL, _
                             Me.m_objDataSet_GZJL) = False Then
                            GoTo errProc
                        End If
                    Case Else
                        '��ȡ����
                        If Me.getModuleData_MAIN(strErrMsg, Me.m_strRYDM) = False Then
                            GoTo errProc
                        End If
                        '��������
                        Dim objDataRow As System.Data.DataRow = Nothing
                        With Me.m_objDataSet_MAIN.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_RENSHIKAPIAN)
                            If .Rows.Count < 1 Then
                                objNewData(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_WYBS) = ""
                                If objsystemEstateRenshiGeneral.doSaveData_RSKP(strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                                    objNewData, Nothing, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                     strSrcLocFileSpec, Request.ApplicationPath, strBasePath, Server, _
                                     Me.m_objDataSet_JTCY, _
                                     Me.m_objDataSet_XXJL, _
                                     Me.m_objDataSet_GZJL) = False Then
                                    GoTo errProc
                                End If
                            Else
                                objDataRow = .Rows(0)
                                If objsystemEstateRenshiGeneral.doSaveData_RSKP(strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                                    objNewData, objDataRow, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate, _
                                     strSrcLocFileSpec, Request.ApplicationPath, strBasePath, Server, _
                                     Me.m_objDataSet_JTCY, _
                                     Me.m_objDataSet_XXJL, _
                                     Me.m_objDataSet_GZJL) = False Then
                                    GoTo errProc
                                End If
                            End If
                        End With
                End Select

                '���ش���
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
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOpen_PXJL(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        strErrMsg = "�����뱣�����ִ�У�"
                        GoTo errProc
                    Case Else
                End Select

                '�����ֳ�����
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIEstateRsRskpPxjl As Josco.JSOA.BusinessFacade.IEstateRsRskpPxjl = Nothing
                Dim strUrl As String = ""
                objIEstateRsRskpPxjl = New Josco.JSOA.BusinessFacade.IEstateRsRskpPxjl
                With objIEstateRsRskpPxjl
                    .iRYDM = Me.txtRYDM.Text.Trim
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
                Session.Add(strNewSessionId, objIEstateRsRskpPxjl)
                strUrl = ""
                strUrl += "estate_rs_rskp_pxjl.aspx"
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

        Private Sub doOpen_YDJL(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        strErrMsg = "�����뱣�����ִ�У�"
                        GoTo errProc
                    Case Else
                End Select

                '�����ֳ�����
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIEstateRsRskpYdjl As Josco.JSOA.BusinessFacade.IEstateRsRskpYdjl = Nothing
                Dim strUrl As String = ""
                objIEstateRsRskpYdjl = New Josco.JSOA.BusinessFacade.IEstateRsRskpYdjl
                With objIEstateRsRskpYdjl
                    .iRYDM = Me.txtRYDM.Text.Trim
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
                Session.Add(strNewSessionId, objIEstateRsRskpYdjl)
                strUrl = ""
                strUrl += "estate_rs_rskp_ydjl.aspx"
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

        Private Sub doOpen_LDHT(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        strErrMsg = "�����뱣�����ִ�У�"
                        GoTo errProc
                    Case Else
                End Select

                '�����ֳ�����
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIEstateRsRskpLdht As Josco.JSOA.BusinessFacade.IEstateRsRskpLdht = Nothing
                Dim strUrl As String = ""
                objIEstateRsRskpLdht = New Josco.JSOA.BusinessFacade.IEstateRsRskpLdht
                With objIEstateRsRskpLdht
                    .iRYDM = Me.txtRYDM.Text.Trim
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
                Session.Add(strNewSessionId, objIEstateRsRskpLdht)
                strUrl = ""
                strUrl += "estate_rs_rskp_ldht.aspx"
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

        Private Sub btnSelect_BM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_BM.Click
            Me.doSelect_BM("btnSelect_BM")
        End Sub

        Private Sub btnSelect_RYDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_RYDM.Click
            Me.doSelect_RYDM("btnSelect_RYDM")
        End Sub

        Private Sub lnkML_PXJL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkML_PXJL.Click
            Me.doOpen_PXJL("lnkML_PXJL")
        End Sub

        Private Sub lnkML_YDJL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkML_YDJL.Click
            Me.doOpen_YDJL("lnkML_YDJL")
        End Sub

        Private Sub lnkML_LDHT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkML_LDHT.Click
            Me.doOpen_LDHT("lnkML_LDHT")
        End Sub

        Private Sub lnkUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkUpload.Click
            Me.doUploadFile("lnkUpload")
        End Sub

        Private Sub btnDelete_JTCY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_JTCY.Click
            Me.doDelete_JTCY("btnDelete_JTCY")
        End Sub

        Private Sub btnDelete_XXJL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_XXJL.Click
            Me.doDelete_XXJL("btnDelete_XXJL")
        End Sub

        Private Sub btnDelete_GZJL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_GZJL.Click
            Me.doDelete_GZJL("btnDelete_GZJL")
        End Sub

        Private Sub btnAddNew_JTCY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_JTCY.Click
            Me.doAddNew_JTCY("btnAddNew_JTCY")
        End Sub

        Private Sub btnAddNew_XXJL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_XXJL.Click
            Me.doAddNew_XXJL("btnAddNew_XXJL")
        End Sub

        Private Sub btnAddNew_GZJL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_GZJL.Click
            Me.doAddNew_GZJL("btnAddNew_GZJL")
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

    End Class

End Namespace
