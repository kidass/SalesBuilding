Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_rs_renyuanjiagou_del
    ' 
    ' �������ʣ�
    '     I/O
    '
    ' ���������� 
    '   ������Ա����������ģ��
    '
    ' ���ļ�¼��
    '     zengxianglin 2009-05-14 ����
    '     zengxianglin 2010-01-05 ����
    '----------------------------------------------------------------

    Partial Class estate_rs_renyuanjiagou_mdfy
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub



        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14


        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14


        'zengxianglin 2008-10-14
        'Protected WithEvents btnViewJG As System.Web.UI.WebControls.Button
        'zengxianglin 2008-10-14


        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        'zengxianglin 2008-10-14

        'zengxianglin 2008-11-18
        'zengxianglin 2008-11-18

        'zengxianglin 2008-11-22
        'zengxianglin 2008-11-22

        'zengxianglin 2010-01-05
        'zengxianglin 2010-01-05

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
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_renyuanjiagou_previlege_param"
        Private m_blnPrevilegeParams(4) As Boolean

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Mdfy
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Mdfy
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdRY��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdRY As String = "chkRY"
        Private Const m_cstrDataGridInDIV_grdRY As String = "divRY"
        Private m_intFixedColumns_grdRY As Integer
        'zengxianglin 2008-10-14
        Private m_intRows_grdRY As Integer
        'zengxianglin 2008-10-14

        '----------------------------------------------------------------
        '����������grdXJ��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdXJ As String = "chkXJ"
        Private Const m_cstrDataGridInDIV_grdXJ As String = "divXJ"
        Private m_intFixedColumns_grdXJ As Integer
        'zengxianglin 2008-10-14
        Private m_intRows_grdXJ As Integer
        'zengxianglin 2008-10-14

        '----------------------------------------------------------------
        '����������grdNXJ��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdNXJ As String = "chkNXJ"
        Private Const m_cstrDataGridInDIV_grdNXJ As String = "divNXJ"
        Private m_intFixedColumns_grdNXJ As Integer
        'zengxianglin 2008-10-14
        Private m_intRows_grdNXJ As Integer
        'zengxianglin 2008-10-14

        '----------------------------------------------------------------
        '��ǰ��������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet_RY As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_XJ As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_NXJ As Josco.JSOA.Common.Data.estateRenshiXingyeData

        '----------------------------------------------------------------
        '��������
        '----------------------------------------------------------------
        Private m_blnEnforced_XJ As Boolean
        Private m_blnEnforced_NXJ As Boolean











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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Mdfy)
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
                    Me.htxtDivLeftRY.Value = .htxtDivLeftRY
                    Me.htxtDivTopRY.Value = .htxtDivTopRY
                    Me.htxtDivLeftXJ.Value = .htxtDivLeftXJ
                    Me.htxtDivTopXJ.Value = .htxtDivTopXJ
                    Me.htxtDivLeftNXJ.Value = .htxtDivLeftNXJ
                    Me.htxtDivTopNXJ.Value = .htxtDivTopNXJ

                    Me.htxtSessionIdQuery_RY.Value = .htxtSessionIdQuery_RY
                    Me.htxtQuery_RY.Value = .htxtQuery_RY
                    Try
                        Me.grdRY.PageSize = .grdRY_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdRY.CurrentPageIndex = .grdRY_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdRY.SelectedIndex = .grdRY_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.htxtSessionIdQuery_NXJ.Value = .htxtSessionIdQuery_NXJ
                    Me.htxtQuery_NXJ.Value = .htxtQuery_NXJ
                    Me.htxtSessionId_NXJ.Value = .htxtSessionId_NXJ
                    Try
                        Me.grdNXJ.PageSize = .grdNXJ_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdNXJ.CurrentPageIndex = .grdNXJ_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdNXJ.SelectedIndex = .grdNXJ_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.htxtSessionId_XJ.Value = .htxtSessionId_XJ
                    Try
                        Me.grdXJ.PageSize = .grdXJ_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdXJ.CurrentPageIndex = .grdXJ_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdXJ.SelectedIndex = .grdXJ_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.ddlYDYY.SelectedIndex = .ddlYDYY_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlZJDM.SelectedIndex = .ddlZJDM_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.rblRYZT.SelectedIndex = .rblRYZT_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblSFZB.SelectedIndex = .rblSFZB_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.txtSJLD.Text = .txtSJLD
                    Me.htxtSJLD.Value = .htxtSJLD
                    Me.txtSSDW.Text = .txtSSDW
                    Me.htxtSSDW.Value = .htxtSSDW
                    'zengxianglin 2008-10-14
                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, Me.txtSSDW.Text)
                    Try
                        Me.ddlSSFZ.SelectedIndex = .ddlSSFZ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    'zengxianglin 2008-10-14
                    Me.txtSXSJ.Text = .txtSXSJ
                    Me.chkTZNXJ.Checked = .chkTJNXJ_Checked
                    Me.chkTZYXJ.Checked = .chkTJYXJ_Checked

                    Me.txtSJLD_XJ.Text = .txtSJLD_XJ
                    Me.htxtSJLD_XJ.Value = .htxtSJLD_XJ

                    Me.txtSearch_RY_RYDM.Text = .txtSearch_RY_RYDM
                    Me.txtSearch_RY_ZJDM.Text = .txtSearch_RY_ZJDM
                    Me.txtSearch_RY_RYMC.Text = .txtSearch_RY_RYMC
                    Me.txtSearch_RY_DWMC.Text = .txtSearch_RY_DWMC

                    Me.txtSearch_NXJ_RYDM.Text = .txtSearch_NXJ_RYDM
                    Me.txtSearch_NXJ_ZJDM.Text = .txtSearch_NXJ_ZJDM
                    Me.txtSearch_NXJ_RYMC.Text = .txtSearch_NXJ_RYMC
                    Me.txtSearch_NXJ_DWMC.Text = .txtSearch_NXJ_DWMC

                    'zengxianglin 2008-10-14
                    Me.txtRYPageIndex.Text = .txtRYPageIndex
                    Me.txtRYPageSize.Text = .txtRYPageSize
                    Me.htxtRYRows.Value = .htxtRYRows

                    Me.txtXJPageIndex.Text = .txtXJPageIndex
                    Me.txtXJPageSize.Text = .txtXJPageSize
                    Me.htxtXJRows.Value = .htxtXJRows

                    Me.txtNXJPageIndex.Text = .txtNXJPageIndex
                    Me.txtNXJPageSize.Text = .txtNXJPageSize
                    Me.htxtNXJRows.Value = .htxtNXJRows
                    'zengxianglin 2008-10-14

                    'zengxianglin 2008-10-14
                    Me.txtZZDM_XJ.Text = .txtZZDM_XJ
                    Me.htxtZZDM_XJ.Value = .htxtZZDM_XJ
                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ_XJ, Me.txtZZDM_XJ.Text)
                    Try
                        Me.ddlSSFZ_XJ.SelectedIndex = .ddlSSFZ_XJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlZJDM_XJ.SelectedIndex = .ddlZJDM_XJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlYDYY_XJ.SelectedIndex = .ddlYDYY_XJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblRYZT_XJ.SelectedIndex = .rblRYZT_XJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblSFZB_XJ.SelectedIndex = .rblSFZB_XJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    'zengxianglin 2008-10-14

                    'zengxianglin 2008-10-14
                    Me.txtZZDM_NXJ.Text = .txtZZDM_NXJ
                    Me.htxtZZDM_NXJ.Value = .htxtZZDM_NXJ
                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ_NXJ, Me.txtZZDM_NXJ.Text)
                    Try
                        Me.ddlSSFZ_NXJ.SelectedIndex = .ddlSSFZ_NXJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlZJDM_NXJ.SelectedIndex = .ddlZJDM_NXJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlYDYY_NXJ.SelectedIndex = .ddlYDYY_NXJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblRYZT_NXJ.SelectedIndex = .rblRYZT_NXJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblSFZB_NXJ.SelectedIndex = .rblSFZB_NXJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    'zengxianglin 2008-10-14

                    'zengxianglin 2008-11-18
                    Me.txtZGDW.Text = .txtZGDW
                    Me.htxtZGDW.Value = .htxtZGDW
                    Me.txtZGDW_XJ.Text = .txtZGDW_XJ
                    Me.htxtZGDW_XJ.Value = .htxtZGDW_XJ
                    Me.txtZGDW_NXJ.Text = .txtZGDW_NXJ
                    Me.htxtZGDW_NXJ.Value = .htxtZGDW_NXJ
                    'zengxianglin 2008-11-18
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Mdfy

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftRY = Me.htxtDivLeftRY.Value
                    .htxtDivTopRY = Me.htxtDivTopRY.Value
                    .htxtDivLeftNXJ = Me.htxtDivLeftNXJ.Value
                    .htxtDivTopNXJ = Me.htxtDivTopNXJ.Value

                    .htxtSessionIdQuery_RY = Me.htxtSessionIdQuery_RY.Value
                    .htxtQuery_RY = Me.htxtQuery_RY.Value

                    .grdRY_PageSize = Me.grdRY.PageSize
                    .grdRY_CurrentPageIndex = Me.grdRY.CurrentPageIndex
                    .grdRY_SelectedIndex = Me.grdRY.SelectedIndex

                    .htxtSessionIdQuery_NXJ = Me.htxtSessionIdQuery_NXJ.Value
                    .htxtQuery_NXJ = Me.htxtQuery_NXJ.Value
                    .htxtSessionId_NXJ = Me.htxtSessionId_NXJ.Value
                    .grdNXJ_PageSize = Me.grdNXJ.PageSize
                    .grdNXJ_CurrentPageIndex = Me.grdNXJ.CurrentPageIndex
                    .grdNXJ_SelectedIndex = Me.grdNXJ.SelectedIndex

                    .htxtSessionId_XJ = Me.htxtSessionId_XJ.Value
                    .grdXJ_PageSize = Me.grdXJ.PageSize
                    .grdXJ_CurrentPageIndex = Me.grdXJ.CurrentPageIndex
                    .grdXJ_SelectedIndex = Me.grdXJ.SelectedIndex

                    .ddlYDYY_SelectedIndex = Me.ddlYDYY.SelectedIndex
                    .ddlZJDM_SelectedIndex = Me.ddlZJDM.SelectedIndex
                    .ddlSSFZ_SelectedIndex = Me.ddlSSFZ.SelectedIndex

                    .rblRYZT_SelectedIndex = Me.rblRYZT.SelectedIndex
                    .rblSFZB_SelectedIndex = Me.rblSFZB.SelectedIndex
                    .txtSJLD = Me.txtSJLD.Text
                    .htxtSJLD = Me.htxtSJLD.Value
                    .txtSSDW = Me.txtSSDW.Text
                    .htxtSSDW = Me.htxtSSDW.Value
                    .txtSXSJ = Me.txtSXSJ.Text
                    .chkTJNXJ_Checked = Me.chkTZNXJ.Checked
                    .chkTJYXJ_Checked = Me.chkTZYXJ.Checked

                    .txtSJLD_XJ = Me.txtSJLD_XJ.Text
                    .htxtSJLD_XJ = Me.htxtSJLD_XJ.Value

                    .txtSearch_RY_RYDM = Me.txtSearch_RY_RYDM.Text
                    .txtSearch_RY_ZJDM = Me.txtSearch_RY_ZJDM.Text
                    .txtSearch_RY_RYMC = Me.txtSearch_RY_RYMC.Text
                    .txtSearch_RY_DWMC = Me.txtSearch_RY_DWMC.Text

                    .txtSearch_NXJ_RYDM = Me.txtSearch_NXJ_RYDM.Text
                    .txtSearch_NXJ_ZJDM = Me.txtSearch_NXJ_ZJDM.Text
                    .txtSearch_NXJ_RYMC = Me.txtSearch_NXJ_RYMC.Text
                    .txtSearch_NXJ_DWMC = Me.txtSearch_NXJ_DWMC.Text

                    'zengxianglin 2008-10-14
                    .txtRYPageIndex = Me.txtRYPageIndex.Text
                    .txtRYPageSize = Me.txtRYPageSize.Text
                    .htxtRYRows = Me.htxtRYRows.Value

                    .txtXJPageIndex = Me.txtXJPageIndex.Text
                    .txtXJPageSize = Me.txtXJPageSize.Text
                    .htxtXJRows = Me.htxtXJRows.Value

                    .txtNXJPageIndex = Me.txtNXJPageIndex.Text
                    .txtNXJPageSize = Me.txtNXJPageSize.Text
                    .htxtNXJRows = Me.htxtNXJRows.Value
                    'zengxianglin 2008-10-14

                    'zengxianglin 2008-10-14
                    .txtZZDM_XJ = Me.txtZZDM_XJ.Text
                    .htxtZZDM_XJ = Me.htxtZZDM_XJ.Value
                    .ddlSSFZ_XJ_SelectedIndex = Me.ddlSSFZ_XJ.SelectedIndex
                    .ddlZJDM_XJ_SelectedIndex = Me.ddlZJDM_XJ.SelectedIndex
                    .ddlYDYY_XJ_SelectedIndex = Me.ddlYDYY_XJ.SelectedIndex
                    .rblRYZT_XJ_SelectedIndex = Me.rblRYZT_XJ.SelectedIndex
                    .rblSFZB_XJ_SelectedIndex = Me.rblSFZB_XJ.SelectedIndex
                    'zengxianglin 2008-10-14

                    'zengxianglin 2008-10-14
                    .txtZZDM_NXJ = Me.txtZZDM_NXJ.Text
                    .htxtZZDM_NXJ = Me.htxtZZDM_NXJ.Value
                    .ddlSSFZ_NXJ_SelectedIndex = Me.ddlSSFZ_NXJ.SelectedIndex
                    .ddlZJDM_NXJ_SelectedIndex = Me.ddlZJDM_NXJ.SelectedIndex
                    .ddlYDYY_NXJ_SelectedIndex = Me.ddlYDYY_NXJ.SelectedIndex
                    .rblRYZT_NXJ_SelectedIndex = Me.rblRYZT_NXJ.SelectedIndex
                    .rblSFZB_NXJ_SelectedIndex = Me.rblSFZB_NXJ.SelectedIndex
                    'zengxianglin 2008-10-14

                    'zengxianglin 2008-11-18
                    .txtZGDW = Me.txtZGDW.Text
                    .htxtZGDW = Me.htxtZGDW.Value
                    .txtZGDW_XJ = Me.txtZGDW_XJ.Text
                    .htxtZGDW_XJ = Me.htxtZGDW_XJ.Value
                    .txtZGDW_NXJ = Me.txtZGDW_NXJ.Text
                    .htxtZGDW_NXJ = Me.htxtZGDW_NXJ.Value
                    'zengxianglin 2008-11-18
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
                Dim objIDmxzZzjg As Josco.JsKernal.BusinessFacade.IDmxzZzjg = Nothing
                Try
                    objIDmxzZzjg = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzZzjg)
                Catch ex As Exception
                    objIDmxzZzjg = Nothing
                End Try
                If Not (objIDmxzZzjg Is Nothing) Then
                    If objIDmxzZzjg.oExitMode = True Then
                        Dim strZZMC As String = ""
                        Dim strZZDM As String = ""
                        Select Case objIDmxzZzjg.iSourceControlId.ToUpper()
                            Case "btnSelectZZDM".ToUpper()
                                strZZMC = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                    Me.htxtSSDW.Value = strZZDM
                                    Me.txtSSDW.Text = strZZMC
                                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, strZZMC)
                                End If

                                'zengxianglin 2008-10-14
                            Case "btnSelectZZDM_XJ".ToUpper()
                                strZZMC = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                    Me.htxtZZDM_XJ.Value = strZZDM
                                    Me.txtZZDM_XJ.Text = strZZMC
                                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ_XJ, strZZMC)
                                End If
                            Case "btnSelectZZDM_NXJ".ToUpper()
                                strZZMC = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                    Me.htxtZZDM_NXJ.Value = strZZDM
                                    Me.txtZZDM_NXJ.Text = strZZMC
                                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ_NXJ, strZZMC)
                                End If
                                'zengxianglin 2008-10-14

                                'zengxianglin 2008-11-18
                            Case "btnSelectZGDW".ToUpper()
                                strZZMC = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                    Me.htxtZGDW.Value = strZZDM
                                    Me.txtZGDW.Text = strZZMC
                                End If
                            Case "btnSelectZGDW_XJ".ToUpper()
                                strZZMC = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                    Me.htxtZGDW_XJ.Value = strZZDM
                                    Me.txtZGDW_XJ.Text = strZZMC
                                End If
                            Case "btnSelectZGDW_NXJ".ToUpper()
                                strZZMC = objIDmxzZzjg.oBumenList
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                    Me.htxtZGDW_NXJ.Value = strZZDM
                                    Me.txtZGDW_NXJ.Text = strZZMC
                                End If
                                'zengxianglin 2008-11-18
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzZzjg.SafeRelease(objIDmxzZzjg)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateRsRenyuanJiagou_Rela As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela = Nothing
                Try
                    objIEstateRsRenyuanJiagou_Rela = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela)
                Catch ex As Exception
                    objIEstateRsRenyuanJiagou_Rela = Nothing
                End Try
                If Not (objIEstateRsRenyuanJiagou_Rela Is Nothing) Then
                    If objIEstateRsRenyuanJiagou_Rela.oExitMode = True Then
                        Select Case objIEstateRsRenyuanJiagou_Rela.iSourceControlId.ToUpper()
                            Case "btnSelectSJLD_XJ".ToUpper()
                                Me.htxtSJLD_XJ.Value = objIEstateRsRenyuanJiagou_Rela.oRYDM
                                Me.txtSJLD_XJ.Text = objIEstateRsRenyuanJiagou_Rela.oRYZM
                            Case "btnSelectSJLD".ToUpper()
                                Me.htxtSJLD.Value = objIEstateRsRenyuanJiagou_Rela.oRYDM
                                Me.txtSJLD.Text = objIEstateRsRenyuanJiagou_Rela.oRYZM
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela.SafeRelease(objIEstateRsRenyuanJiagou_Rela)
                    Exit Try
                End If

                '=================================================================
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
                Try
                    objISjcxCxtj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.ISjcxCxtj)
                Catch ex As Exception
                    objISjcxCxtj = Nothing
                End Try
                If Not (objISjcxCxtj Is Nothing) Then
                    If objISjcxCxtj.oExitMode = True Then
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
                        Select Case objISjcxCxtj.iSourceControlId.ToUpper
                            Case "btnSearchFull_RY".ToUpper
                                Me.htxtQuery_RY.Value = objISjcxCxtj.oQueryString
                                If Me.htxtSessionIdQuery_RY.Value.Trim = "" Then
                                    Me.htxtSessionIdQuery_RY.Value = objPulicParameters.getNewGuid()
                                Else
                                    Try
                                        objQueryData = CType(Session(Me.htxtSessionIdQuery_RY.Value), Josco.JsKernal.Common.Data.QueryData)
                                    Catch ex As Exception
                                        objQueryData = Nothing
                                    End Try
                                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                                End If
                                Session.Add(Me.htxtSessionIdQuery_RY.Value, objISjcxCxtj.oDataSetTJ)
                                Me.m_blnEnforced_XJ = True
                            Case "btnSearchFull_NXJ".ToUpper
                                Me.htxtQuery_NXJ.Value = objISjcxCxtj.oQueryString
                                If Me.htxtSessionIdQuery_NXJ.Value.Trim = "" Then
                                    Me.htxtSessionIdQuery_NXJ.Value = objPulicParameters.getNewGuid()
                                Else
                                    Try
                                        objQueryData = CType(Session(Me.htxtSessionIdQuery_NXJ.Value), Josco.JsKernal.Common.Data.QueryData)
                                    Catch ex As Exception
                                        objQueryData = Nothing
                                    End Try
                                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                                End If
                                Session.Add(Me.htxtSessionIdQuery_NXJ.Value, objISjcxCxtj.oDataSetTJ)
                                Me.m_blnEnforced_NXJ = True
                            Case Else
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
        Private Function getInterfaceParameters(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Mdfy)
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
                Me.m_blnEnforced_XJ = False
                Me.m_blnEnforced_NXJ = False

                '��ȡ�ָ��ֳ�����
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_Mdfy)
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

                Me.m_intFixedColumns_grdRY = objPulicParameters.getObjectValue(Me.htxtRYFixed.Value, 0)
                Me.m_intFixedColumns_grdXJ = objPulicParameters.getObjectValue(Me.htxtXJFixed.Value, 0)
                Me.m_intFixedColumns_grdNXJ = objPulicParameters.getObjectValue(Me.htxtNXJFixed.Value, 0)

                'zengxianglin 2008-10-14
                Me.m_intRows_grdRY = objPulicParameters.getObjectValue(Me.htxtRYRows.Value, 0)
                Me.m_intRows_grdXJ = objPulicParameters.getObjectValue(Me.htxtXJRows.Value, 0)
                Me.m_intRows_grdNXJ = objPulicParameters.getObjectValue(Me.htxtNXJRows.Value, 0)
                'zengxianglin 2008-10-14
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
                Dim objDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
                If Me.htxtSessionId_XJ.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_XJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_XJ.Value)
                End If
                If Me.htxtSessionId_NXJ.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_NXJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_NXJ.Value)
                End If

                Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
                If Me.htxtSessionIdQuery_RY.Value.Trim <> "" Then
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQuery_RY.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQuery_RY.Value)
                End If
                If Me.htxtSessionIdQuery_NXJ.Value.Trim <> "" Then
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQuery_NXJ.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQuery_NXJ.Value)
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub










        '----------------------------------------------------------------
        ' ��ȡgrdRY��������(Ĭ�ϱ�ǰ׺a.)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_RY( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_RY = False
            strQuery = ""

            Try
                '����Ա��������
                Dim strRYDM As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM
                If Me.txtSearch_RY_RYDM.Text.Length > 0 Then Me.txtSearch_RY_RYDM.Text = Me.txtSearch_RY_RYDM.Text.Trim()
                If Me.txtSearch_RY_RYDM.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strRYDM + " like '" + Me.txtSearch_RY_RYDM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strRYDM + " like '" + Me.txtSearch_RY_RYDM.Text + "%'"
                    End If
                End If

                '��ְ����������
                Dim strZJDM As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM
                If Me.txtSearch_RY_ZJDM.Text.Length > 0 Then Me.txtSearch_RY_ZJDM.Text = Me.txtSearch_RY_ZJDM.Text.Trim()
                If Me.txtSearch_RY_ZJDM.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strZJDM + " like '" + Me.txtSearch_RY_ZJDM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strZJDM + " like '" + Me.txtSearch_RY_ZJDM.Text + "%'"
                    End If
                End If

                '����Ա��������
                Dim strRYMC As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC
                If Me.txtSearch_RY_RYMC.Text.Length > 0 Then Me.txtSearch_RY_RYMC.Text = Me.txtSearch_RY_RYMC.Text.Trim()
                If Me.txtSearch_RY_RYMC.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strRYMC + " like '" + Me.txtSearch_RY_RYMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strRYMC + " like '" + Me.txtSearch_RY_RYMC.Text + "%'"
                    End If
                End If

                '����Ա��������
                Dim strSSDWMC As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC
                If Me.txtSearch_RY_DWMC.Text.Length > 0 Then Me.txtSearch_RY_DWMC.Text = Me.txtSearch_RY_DWMC.Text.Trim()
                If Me.txtSearch_RY_DWMC.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strSSDWMC + " like '" + Me.txtSearch_RY_DWMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strSSDWMC + " like '" + Me.txtSearch_RY_DWMC.Text + "%'"
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_RY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdRYҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       �������ַ���
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_RY( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye

            getModuleData_RY = False

            Try
                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_RY)

                '���¼�������
                If objsystemEstateRenshiXingye.getDataSet_RYJG_RY_In(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objDataSet_RY) = False Then
                    GoTo errProc
                End If

                'zengxianglin 2008-10-14
                '�������
                With Me.m_objDataSet_RY.Tables(strTable)
                    Me.htxtRYRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_grdRY = .DefaultView.Count
                End With
                'zengxianglin 2008-10-14
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)

            getModuleData_RY = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdRY����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_RY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU

            searchModuleData_RY = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_RY(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_RY(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.htxtQuery_RY.Value = strQuery
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_RY = True
            Exit Function
errProc:
            Exit Function

        End Function











        '----------------------------------------------------------------
        ' ��ȡgrdXJҪ��ʾ������
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       �������ַ���
        '     blnEnforced    ��True-���»�ȡ���� False-���ȴӻ����ȡ����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_XJ( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String, _
            ByVal blnEnforced As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_XJ = False

            Try
                '����grdRY�еĵ�ǰ������
                Dim intColIndex As Integer = 0
                Dim strSJLD As String = ""
                If Me.grdRY.Items.Count > 0 And Me.grdRY.SelectedIndex >= 0 Then
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM)
                    strSJLD = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                End If
                '��ȡָ����Ա��ֱ���¼�
                If strWhere = "" Then
                    strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD + " = '" + strSJLD + "'"
                Else
                    strWhere = strWhere + " and " + "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD + " = '" + strSJLD + "'"
                End If

                '�ͷŻ�������
                If blnEnforced = True Then
                    If Me.htxtSessionId_XJ.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_XJ = CType(Session.Item(Me.htxtSessionId_XJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                        Catch ex As Exception
                            Me.m_objDataSet_XJ = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_XJ)
                        Session.Remove(Me.htxtSessionId_XJ.Value)
                        Me.htxtSessionId_XJ.Value = ""
                    End If
                Else
                End If

                '��ȡ��������
                If Me.htxtSessionId_XJ.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_XJ = CType(Session.Item(Me.htxtSessionId_XJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_XJ)
                    '���¼�������
                    'zengxianglin 2008-10-14
                    If objsystemEstateRenshiXingye.getDataSet_RYJG_RY_In(strErrMsg, MyBase.UserId, MyBase.UserPassword, True, strWhere, Me.m_objDataSet_XJ) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-10-14
                    '��������
                    Me.htxtSessionId_XJ.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_XJ.Value, Me.m_objDataSet_XJ)
                End If

                'zengxianglin 2008-10-14
                '�������
                With Me.m_objDataSet_XJ.Tables(strTable)
                    Me.htxtXJRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_grdXJ = .DefaultView.Count
                End With
                'zengxianglin 2008-10-14
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getModuleData_XJ = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function











        '----------------------------------------------------------------
        ' ��ȡgrdNXJ��������(Ĭ�ϱ�ǰ׺a.)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_NXJ( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_NXJ = False
            strQuery = ""

            Try
                '����Ա��������
                Dim strRYDM As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM
                If Me.txtSearch_NXJ_RYDM.Text.Length > 0 Then Me.txtSearch_NXJ_RYDM.Text = Me.txtSearch_NXJ_RYDM.Text.Trim()
                If Me.txtSearch_NXJ_RYDM.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strRYDM + " like '" + Me.txtSearch_NXJ_RYDM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strRYDM + " like '" + Me.txtSearch_NXJ_RYDM.Text + "%'"
                    End If
                End If

                '��ְ����������
                Dim strZJDM As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM
                If Me.txtSearch_NXJ_ZJDM.Text.Length > 0 Then Me.txtSearch_NXJ_ZJDM.Text = Me.txtSearch_NXJ_ZJDM.Text.Trim()
                If Me.txtSearch_NXJ_ZJDM.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strZJDM + " like '" + Me.txtSearch_NXJ_ZJDM.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strZJDM + " like '" + Me.txtSearch_NXJ_ZJDM.Text + "%'"
                    End If
                End If

                '����Ա��������
                Dim strRYMC As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC
                If Me.txtSearch_NXJ_RYMC.Text.Length > 0 Then Me.txtSearch_NXJ_RYMC.Text = Me.txtSearch_NXJ_RYMC.Text.Trim()
                If Me.txtSearch_NXJ_RYMC.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strRYMC + " like '" + Me.txtSearch_NXJ_RYMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strRYMC + " like '" + Me.txtSearch_NXJ_RYMC.Text + "%'"
                    End If
                End If

                '����Ա��������
                Dim strSSDWMC As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC
                If Me.txtSearch_NXJ_DWMC.Text.Length > 0 Then Me.txtSearch_NXJ_DWMC.Text = Me.txtSearch_NXJ_DWMC.Text.Trim()
                If Me.txtSearch_NXJ_DWMC.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strSSDWMC + " like '" + Me.txtSearch_NXJ_DWMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strSSDWMC + " like '" + Me.txtSearch_NXJ_DWMC.Text + "%'"
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_NXJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdNXJҪ��ʾ������
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       �������ַ���
        '     blnEnforced    ��True-���»�ȡ���� False-���ȴӻ����ȡ����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_NXJ( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String, _
            ByVal blnEnforced As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_NXJ = False

            Try
                '�ͷŻ�������
                If blnEnforced = True Then
                    If Me.htxtSessionId_NXJ.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_NXJ = CType(Session.Item(Me.htxtSessionId_NXJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                        Catch ex As Exception
                            Me.m_objDataSet_NXJ = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_NXJ)
                        Session.Remove(Me.htxtSessionId_NXJ.Value)
                        Me.htxtSessionId_NXJ.Value = ""
                    End If
                Else
                End If

                '��ȡ��������
                If Me.htxtSessionId_NXJ.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_NXJ = CType(Session.Item(Me.htxtSessionId_NXJ.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_NXJ)
                    If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                        Me.m_objDataSet_NXJ = New Josco.JSOA.Common.Data.estateRenshiXingyeData(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_V_RS_RENYUANJIAGOU)
                    Else
                        '���¼�������
                        'zengxianglin 2008-10-14
                        If objsystemEstateRenshiXingye.getDataSet_RYJG_RY_In(strErrMsg, MyBase.UserId, MyBase.UserPassword, True, strWhere, Me.m_objDataSet_NXJ) = False Then
                            GoTo errProc
                        End If
                        'zengxianglin 2008-10-14
                    End If
                    '��������
                    Me.htxtSessionId_NXJ.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_NXJ.Value, Me.m_objDataSet_NXJ)
                End If

                'zengxianglin 2008-10-14
                '�������
                With Me.m_objDataSet_NXJ.Tables(strTable)
                    Me.htxtNXJRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_grdNXJ = .DefaultView.Count
                End With
                'zengxianglin 2008-10-14
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getModuleData_NXJ = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdNXJ����
        '     strErrMsg      �����ش�����Ϣ
        '     blnEnforced    ��True-���»�ȡ, Flase-���ȴӻ����ȡ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_NXJ( _
            ByRef strErrMsg As String, _
            ByVal blnEnforced As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU

            searchModuleData_NXJ = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_NXJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_NXJ(strErrMsg, strQuery, blnEnforced) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.htxtQuery_NXJ.Value = strQuery
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_NXJ = True
            Exit Function
errProc:
            Exit Function

        End Function












        '----------------------------------------------------------------
        ' ��ʾgrdRY���������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_RY_Rela(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_RY_Rela = False

            Try
                '��ʾ��Ա��Ŀ
                With Me.m_objDataSet_RY.Tables(strTable)
                    Me.lblRYSM_RY.Text = .DefaultView.Count.ToString
                End With

                '��ʾ��������
                Dim intColIndex As Integer = 0
                Dim strValue As String = ""
                If Me.grdRY.SelectedIndex >= 0 Then
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ)
                    Me.txtKSSJ.Text = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW)
                    Me.htxtSSDW_Old.Value = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC)
                    Me.txtSSDW_Old.Text = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)

                    'zengxianglin 2008-11-18
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW)
                    Me.htxtZGDW_Old.Value = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC)
                    Me.txtZGDW_Old.Text = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                    'zengxianglin 2008-11-18

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD)
                    Me.htxtSJLD_Old.Value = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLDMC)
                    Me.txtSJLD_Old.Text = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                    Me.ddlZJDM_Old.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZJDM_Old, strValue)

                    '=========֣�� 2008-7-23 �޸�===============
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                    'zengxianglin 2008-10-14
                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ_Old, Me.txtSSDW_Old.Text)
                    'zengxianglin 2008-10-14
                    Me.ddlSSFZ_Old.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSSFZ_Old, strValue)
                    '=========֣�� 2008-7-23 �޸�===============

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                    Me.rblRYZT_Old.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYZT_Old, strValue)

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                    Me.rblSFZB_Old.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFZB_Old, strValue)
                Else
                    Me.txtKSSJ.Text = ""
                    Me.htxtSSDW_Old.Value = ""
                    Me.txtSSDW_Old.Text = ""
                    'zengxianglin 2008-11-18
                    Me.htxtZGDW_Old.Value = ""
                    Me.txtZGDW_Old.Text = ""
                    'zengxianglin 2008-11-18
                    'zengxianglin 2008-10-14
                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ_Old, Me.txtSSDW_Old.Text)
                    Me.ddlZJDM_Old.SelectedIndex = -1
                    'zengxianglin 2008-10-14
                    Me.htxtSJLD_Old.Value = ""
                    Me.txtSJLD_Old.Text = ""
                    Me.rblRYZT_Old.SelectedIndex = -1
                    Me.rblSFZB_Old.SelectedIndex = -1
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)

            showDataGridInfo_RY_Rela = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdRY������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_RY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess

            showDataGridInfo_RY = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_RY Is Nothing Then
                    Me.grdRY.DataSource = Nothing
                Else
                    With Me.m_objDataSet_RY.Tables(strTable)
                        Me.grdRY.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_RY.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdRY, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdRY.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdRY, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY) = False Then
                '    GoTo errProc
                'End If

                '��ʾ�������
                If Me.showDataGridInfo_RY_Rela(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)

            showDataGridInfo_RY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Exit Function

        End Function

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' ��ʾgrdRY�����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-06 ���� Optional ByVal blnEnforced As Boolean = False
        '----------------------------------------------------------------
        Private Function showModuleData_RY( _
            ByRef strErrMsg As String, _
            Optional ByVal blnEnforced As Boolean = False) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_RY = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_RY(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_RY.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblRYGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdRY, .Count)

                    '��ʾҳ���������
                    Me.lnkCZRYMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdRY, .Count)
                    Me.lnkCZRYMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdRY, .Count)
                    Me.lnkCZRYMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdRY, .Count)
                    Me.lnkCZRYMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdRY, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZRYDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZRYSelectAll.Enabled = blnEnabled
                    Me.lnkCZRYGotoPage.Enabled = blnEnabled
                    Me.lnkCZRYSetPageSize.Enabled = blnEnabled
                End With

                'zengxianglin 2008-11-06
                'ͬ��ֱ���¼�
                If blnEnforced = True Then
                    If Me.getModuleData_XJ(strErrMsg, "", True) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_XJ(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
                'zengxianglin 2008-11-06
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_RY = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function
        'zengxianglin 2008-10-14

        '----------------------------------------------------------------
        ' ��ʾgrdXJ������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_XJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_XJ = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_XJ Is Nothing Then
                    Me.grdXJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_XJ.Tables(strTable)
                        Me.grdXJ.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_XJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdXJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdXJ.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                'zengxianglin 2008-10-14
                ''�ָ������е�CheckBox״̬
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdXJ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdXJ) = False Then
                '    GoTo errProc
                'End If
                'zengxianglin 2008-10-14

                '��ʾ��Ա��Ŀ
                With Me.m_objDataSet_XJ.Tables(strTable)
                    Me.lblRYSM_XJ.Text = .DefaultView.Count.ToString
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_XJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' ��ʾgrdXJ�����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_XJ( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_XJ = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_XJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_XJ.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblXJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdXJ, .Count)

                    '��ʾҳ���������
                    Me.lnkCZXJMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdXJ, .Count)
                    Me.lnkCZXJMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdXJ, .Count)
                    Me.lnkCZXJMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdXJ, .Count)
                    Me.lnkCZXJMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdXJ, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZXJDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZXJSelectAll.Enabled = blnEnabled
                    Me.lnkCZXJGotoPage.Enabled = blnEnabled
                    Me.lnkCZXJSetPageSize.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_XJ = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function
        'zengxianglin 2008-10-14

        '----------------------------------------------------------------
        ' ��ʾgrdNXJ������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_NXJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_NXJ = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_NXJ Is Nothing Then
                    Me.grdNXJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_NXJ.Tables(strTable)
                        Me.grdNXJ.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_NXJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdNXJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdNXJ.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdNXJ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdNXJ) = False Then
                    GoTo errProc
                End If

                '��ʾ��Ա��Ŀ
                With Me.m_objDataSet_NXJ.Tables(strTable)
                    Me.lblRYSM_NXJ.Text = .DefaultView.Count.ToString
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_NXJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' ��ʾgrdNXJ�����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_NXJ( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_NXJ = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_NXJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_NXJ.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblNXJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdNXJ, .Count)

                    '��ʾҳ���������
                    Me.lnkCZNXJMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdNXJ, .Count)
                    Me.lnkCZNXJMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdNXJ, .Count)
                    Me.lnkCZNXJMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdNXJ, .Count)
                    Me.lnkCZNXJMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdNXJ, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZNXJDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZNXJSelectAll.Enabled = blnEnabled
                    Me.lnkCZNXJGotoPage.Enabled = blnEnabled
                    Me.lnkCZNXJSetPageSize.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_NXJ = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function
        'zengxianglin 2008-10-14











        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' ��grdXJ��ǰ����Ϣ��ʾ����������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showEditPanel_XJ( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showEditPanel_XJ = False

            Try
                '���
                Me.htxtZZDM_XJ.Value = ""
                Me.txtZZDM_XJ.Text = ""
                'zengxianglin 2008-11-18
                Me.htxtZGDW_XJ.Value = ""
                Me.txtZGDW_XJ.Text = ""
                'zengxianglin 2008-11-18
                Me.htxtSJLD_XJ.Value = ""
                Me.txtSJLD_XJ.Text = ""
                Me.ddlSSFZ_XJ.SelectedIndex = -1
                Me.ddlZJDM_XJ.SelectedIndex = -1
                Me.ddlYDYY_XJ.SelectedIndex = -1
                Me.rblRYZT_XJ.SelectedIndex = -1
                Me.rblSFZB_XJ.SelectedIndex = -1

                '���
                If Me.grdXJ.SelectedIndex < 0 Then
                    Exit Try
                End If
                Dim intIndex As Integer = Me.grdXJ.SelectedIndex

                '��ʾ
                Dim intColIndex As Integer
                Dim strValue As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW)
                Me.htxtZZDM_XJ.Value = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC)
                Me.txtZZDM_XJ.Text = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ_XJ, Me.txtZZDM_XJ.Text)

                'zengxianglin 2008-11-18
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW)
                Me.htxtZGDW_XJ.Value = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC)
                Me.txtZGDW_XJ.Text = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                'zengxianglin 2008-11-18

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD)
                Me.htxtSJLD_XJ.Value = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLDMC)
                Me.txtSJLD_XJ.Text = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                Me.ddlZJDM_XJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZJDM_XJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                Me.ddlSSFZ_XJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSSFZ_XJ, strValue, True)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                Me.ddlYDYY_XJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlYDYY_XJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                Me.rblRYZT_XJ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYZT_XJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdXJ.Items(intIndex), intColIndex)
                Me.rblSFZB_XJ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFZB_XJ, strValue)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanel_XJ = True
            Exit Function
errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        ' ��grdNXJ��ǰ����Ϣ��ʾ����������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showEditPanel_NXJ( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showEditPanel_NXJ = False

            Try
                '���
                Me.htxtZZDM_NXJ.Value = ""
                Me.txtZZDM_NXJ.Text = ""
                'zengxianglin 2008-11-18
                Me.htxtZGDW_NXJ.Value = ""
                Me.txtZGDW_NXJ.Text = ""
                'zengxianglin 2008-11-18
                Me.ddlSSFZ_NXJ.SelectedIndex = -1
                Me.ddlZJDM_NXJ.SelectedIndex = -1
                Me.ddlYDYY_NXJ.SelectedIndex = -1
                Me.rblRYZT_NXJ.SelectedIndex = -1
                Me.rblSFZB_NXJ.SelectedIndex = -1

                '���
                If Me.grdNXJ.SelectedIndex < 0 Then
                    Exit Try
                End If
                Dim intIndex As Integer = Me.grdNXJ.SelectedIndex

                '��ʾ
                Dim intColIndex As Integer
                Dim strValue As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdNXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW)
                Me.htxtZZDM_NXJ.Value = objDataGridProcess.getDataGridCellValue(Me.grdNXJ.Items(intIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdNXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC)
                Me.txtZZDM_NXJ.Text = objDataGridProcess.getDataGridCellValue(Me.grdNXJ.Items(intIndex), intColIndex)
                Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ_NXJ, Me.txtZZDM_NXJ.Text)

                'zengxianglin 2008-11-18
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdNXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW)
                Me.htxtZGDW_NXJ.Value = objDataGridProcess.getDataGridCellValue(Me.grdNXJ.Items(intIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdNXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC)
                Me.txtZGDW_NXJ.Text = objDataGridProcess.getDataGridCellValue(Me.grdNXJ.Items(intIndex), intColIndex)
                'zengxianglin 2008-11-18

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdNXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdNXJ.Items(intIndex), intColIndex)
                Me.ddlZJDM_NXJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZJDM_NXJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdNXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdNXJ.Items(intIndex), intColIndex)
                Me.ddlSSFZ_NXJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSSFZ_NXJ, strValue, True)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdNXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdNXJ.Items(intIndex), intColIndex)
                Me.ddlYDYY_NXJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlYDYY_NXJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdNXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdNXJ.Items(intIndex), intColIndex)
                Me.rblRYZT_NXJ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYZT_NXJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdNXJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdNXJ.Items(intIndex), intColIndex)
                Me.rblSFZB_NXJ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFZB_NXJ, strValue)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanel_NXJ = True
            Exit Function
errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function
        'zengxianglin 2008-10-14

        '----------------------------------------------------------------
        ' ��ʾ����ģ����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_Main(ByRef strErrMsg As String) As Boolean

            showModuleData_Main = False

            Try

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
        ' ���䶯ԭ�������б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-22 ���ӽӿ�[strWhere]
        '----------------------------------------------------------------
        Private Function doFillYdyyList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList, _
            Optional ByVal strWhere As String = "") As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_BIANDONGYUANYIN
            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillYdyyList = False
            strErrMsg = ""

            Try
                '���
                If objDropDownList Is Nothing Then
                    strErrMsg = "����[doFillYdyyList]�ӿڲ�������ȷ��"
                    GoTo errProc
                End If

                '��ȡ����
                'zengxianglin 2008-11-22
                'If objsystemEstateRenshiGeneral.getDataSet_BiandongYuanyin(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiGeneralData) = False Then
                '    GoTo errProc
                'End If
                If objsystemEstateRenshiGeneral.getDataSet_BiandongYuanyin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiGeneralData) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-22

                '��������б�
                objDropDownList.Items.Clear()

                '�������
                Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
                Dim strCode As String = ""
                Dim strName As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objestateRenshiGeneralData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYMC), "")

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
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)

            doFillYdyyList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���ְ�������б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doFillZjdmList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

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
                'zengxianglin 2010-01-05
                Dim strWhere As String = ""
                strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_JBSZ + " > 0"
                'zengxianglin 2010-01-05
                If objsystemEstateRenshiXingye.getDataSet_ZhijiDingyi(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiXingyeData) = False Then
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
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)

            doFillZjdmList = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            Exit Function

        End Function

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

        '----------------------------------------------------------------
        ' ��ԭ��ԭʼֵ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doResetToOrg(ByRef strErrMsg As String) As Boolean

            doResetToOrg = False
            strErrMsg = ""

            Try
                Me.rblRYZT.SelectedIndex = Me.rblRYZT_Old.SelectedIndex
                Me.rblSFZB.SelectedIndex = Me.rblSFZB_Old.SelectedIndex
                Me.ddlZJDM.SelectedIndex = Me.ddlZJDM_Old.SelectedIndex

                Me.txtSJLD.Text = Me.txtSJLD_Old.Text
                Me.htxtSJLD.Value = Me.htxtSJLD_Old.Value
                Me.txtSSDW.Text = Me.txtSSDW_Old.Text
                Me.htxtSSDW.Value = Me.htxtSSDW_Old.Value

                'zengxianglin 2008-11-18
                Me.txtZGDW.Text = Me.txtZGDW_Old.Text
                Me.htxtZGDW.Value = Me.htxtZGDW_Old.Value
                'zengxianglin 2008-11-18

                'zengxianglin 2008-10-14
                Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, Me.txtSSDW.Text)
                Try
                    Me.ddlSSFZ.SelectedIndex = Me.ddlSSFZ_Old.SelectedIndex
                Catch ex As Exception
                End Try
                'zengxianglin 2008-10-14
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doResetToOrg = True
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

            Try
                '���ڵ�һ�ε���ҳ��ʱִ��
                If Me.IsPostBack = False Then
                    '��ʾPannel(�����Ƿ�ص���ʼ����ʾpanelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                    With objControlProcess
                        .doTranslateKey(Me.txtSearch_RY_DWMC)
                        .doTranslateKey(Me.txtSearch_RY_RYDM)
                        .doTranslateKey(Me.txtSearch_RY_ZJDM)
                        .doTranslateKey(Me.txtSearch_RY_RYMC)

                        .doTranslateKey(Me.txtSearch_NXJ_DWMC)
                        .doTranslateKey(Me.txtSearch_NXJ_RYDM)
                        .doTranslateKey(Me.txtSearch_NXJ_ZJDM)
                        .doTranslateKey(Me.txtSearch_NXJ_RYMC)

                        .doTranslateKey(Me.txtSJLD)
                        .doTranslateKey(Me.txtSJLD_Old)
                        .doTranslateKey(Me.txtSSDW)
                        .doTranslateKey(Me.txtSSDW_Old)
                        'zengxianglin 2008-11-18
                        .doTranslateKey(Me.txtZGDW)
                        .doTranslateKey(Me.txtZGDW_Old)
                        'zengxianglin 2008-11-18
                        .doTranslateKey(Me.txtSXSJ)
                        .doTranslateKey(Me.txtKSSJ)
                        .doTranslateKey(Me.ddlYDYY)
                        .doTranslateKey(Me.ddlZJDM)
                        .doTranslateKey(Me.ddlZJDM_Old)

                        .doTranslateKey(Me.txtSJLD_XJ)
                        'zengxianglin 2008-10-14
                        .doTranslateKey(Me.txtZZDM_XJ)
                        'zengxianglin 2008-11-18
                        .doTranslateKey(Me.txtZGDW_XJ)
                        'zengxianglin 2008-11-18
                        .doTranslateKey(Me.ddlSSFZ_XJ)
                        .doTranslateKey(Me.ddlZJDM_XJ)
                        .doTranslateKey(Me.ddlYDYY_XJ)
                        'zengxianglin 2008-10-14

                        'zengxianglin 2008-10-14
                        .doTranslateKey(Me.txtZZDM_NXJ)
                        'zengxianglin 2008-11-18
                        .doTranslateKey(Me.txtZGDW_NXJ)
                        'zengxianglin 2008-11-18
                        .doTranslateKey(Me.ddlSSFZ_NXJ)
                        .doTranslateKey(Me.ddlZJDM_NXJ)
                        .doTranslateKey(Me.ddlYDYY_NXJ)
                        'zengxianglin 2008-10-14

                        'zengxianglin 2008-10-14
                        .doTranslateKey(Me.txtRYPageIndex)
                        .doTranslateKey(Me.txtRYPageSize)
                        .doTranslateKey(Me.txtXJPageIndex)
                        .doTranslateKey(Me.txtXJPageSize)
                        .doTranslateKey(Me.txtNXJPageIndex)
                        .doTranslateKey(Me.txtNXJPageSize)
                        'zengxianglin 2008-10-14
                    End With

                    '��ʾMain
                    If Me.showModuleData_Main(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾgrdRY
                    'zengxianglin 2008-11-06
                    If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                        GoTo errProc
                    End If
                    If Me.m_blnSaveScence = False Then
                        If Me.showModuleData_RY(strErrMsg, True) = False Then
                            GoTo errProc
                        End If
                    Else
                        If Me.showModuleData_RY(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        '��ʾgrdXJ
                        If Me.getModuleData_XJ(strErrMsg, "", Me.m_blnEnforced_XJ) = False Then
                            GoTo errProc
                        End If
                        If Me.showModuleData_XJ(strErrMsg) = False Then
                            GoTo errProc
                        End If
                    End If
                    'zengxianglin 2008-11-06

                    '��ʾgrdNXJ
                    If Me.getModuleData_NXJ(strErrMsg, Me.htxtQuery_NXJ.Value, Me.m_blnEnforced_NXJ) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_NXJ(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '���ʼֵ
                    If Me.m_blnSaveScence = False Then
                        Me.txtSXSJ.Text = Now.ToString("yyyy-MM-dd")
                        Me.doResetToOrg(strErrMsg)
                    End If
                Else
                    '��ȡ��������
                    If Me.getModuleData_XJ(strErrMsg, "", False) = False Then
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
                    'zengxianglin 2008-11-22
                    'If Me.doFillYdyyList(strErrMsg, Me.ddlYDYY) = False Then
                    '    GoTo errProc
                    'End If
                    Dim strWhere As String = ""
                    strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM + " like '" + Me.htxtBDYY_NBTZ.Value + "%'"
                    If Me.doFillYdyyList(strErrMsg, Me.ddlYDYY, strWhere) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-22
                    If Me.doFillZjdmList(strErrMsg, Me.ddlZJDM) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillZjdmList(strErrMsg, Me.ddlZJDM_Old) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-10-14
                    If Me.doFillZjdmList(strErrMsg, Me.ddlZJDM_XJ) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillYdyyList(strErrMsg, Me.ddlYDYY_XJ) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillZjdmList(strErrMsg, Me.ddlZJDM_NXJ) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillYdyyList(strErrMsg, Me.ddlYDYY_NXJ) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-10-14
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
        Sub grdRY_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdRY.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdRY + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdRY > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdRY - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdRY.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdXJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdXJ.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdXJ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdXJ > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdXJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdXJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdNXJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdNXJ.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdNXJ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdNXJ > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdNXJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdNXJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdRY_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRY.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                'zengxianglin 2008-10-14
                '��ʾ��¼λ��
                Me.lblRYGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdRY, Me.m_intRows_grdRY)
                'zengxianglin 2008-10-14

                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_RY_Rela(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_XJ(strErrMsg, "", True) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_XJ(strErrMsg) = False Then
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

        'zengxianglin 2008-10-14
        Private Sub grdXJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdXJ.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblXJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdXJ, Me.m_intRows_grdXJ)

                ''ͬ����ʾ��Ϣ
                'If Me.showEditPanel_XJ(strErrMsg) = False Then
                '    GoTo errProc
                'End If
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
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private Sub grdNXJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdNXJ.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblNXJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdNXJ, Me.m_intRows_grdNXJ)

                ''ͬ����ʾ��Ϣ
                'If Me.showEditPanel_NXJ(strErrMsg) = False Then
                '    GoTo errProc
                'End If
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
        'zengxianglin 2008-10-14










        'zengxianglin 2008-10-14
        Private Sub doMoveFirst_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                'zengxianglin 2008-11-06
                If Me.showModuleData_RY(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-06
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

        Private Sub doMoveLast_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.PageCount - 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                'zengxianglin 2008-11-06
                If Me.showModuleData_RY(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-06
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

        Private Sub doMoveNext_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.CurrentPageIndex + 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                'zengxianglin 2008-11-06
                If Me.showModuleData_RY(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-06
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

        Private Sub doMovePrevious_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.CurrentPageIndex - 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                'zengxianglin 2008-11-06
                If Me.showModuleData_RY(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-06
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

        Private Sub doGotoPage_RY(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtRYPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdRY.CurrentPageIndex = intPageIndex

                'zengxianglin 2008-11-06
                If Me.showModuleData_RY(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-06

                '��Ϣͬ��
                Me.txtRYPageIndex.Text = (Me.grdRY.CurrentPageIndex + 1).ToString()
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

        Private Sub doSetPageSize_RY(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtRYPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdRY.PageSize = intPageSize

                'zengxianglin 2008-11-06
                If Me.showModuleData_RY(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-06

                '��Ϣͬ��
                Me.txtRYPageSize.Text = (Me.grdRY.PageSize).ToString()
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

        Private Sub doSelectAll_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdRY, 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY, True) = False Then
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

        Private Sub doDeSelectAll_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdRY, 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY, False) = False Then
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

        Private Sub lnkCZRYMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMoveFirst.Click
            Me.doMoveFirst_RY("lnkCZRYMoveFirst")
        End Sub

        Private Sub lnkCZRYMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMoveLast.Click
            Me.doMoveLast_RY("lnkCZRYMoveLast")
        End Sub

        Private Sub lnkCZRYMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMoveNext.Click
            Me.doMoveNext_RY("lnkCZRYMoveNext")
        End Sub

        Private Sub lnkCZRYMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYMovePrev.Click
            Me.doMovePrevious_RY("lnkCZRYMovePrev")
        End Sub

        Private Sub lnkCZRYGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYGotoPage.Click
            Me.doGotoPage_RY("lnkCZRYGotoPage")
        End Sub

        Private Sub lnkCZRYSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYSetPageSize.Click
            Me.doSetPageSize_RY("lnkCZRYSetPageSize")
        End Sub

        Private Sub lnkCZRYSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYSelectAll.Click
            Me.doSelectAll_RY("lnkCZRYSelectAll")
        End Sub

        Private Sub lnkCZRYDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRYDeSelectAll.Click
            Me.doDeSelectAll_RY("lnkCZRYDeSelectAll")
        End Sub
        'zengxianglin 2008-10-14










        'zengxianglin 2008-10-14
        Private Sub doMoveFirst_XJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_XJ(strErrMsg, "", Me.m_blnEnforced_XJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdXJ.PageCount)
                Me.grdXJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_XJ(strErrMsg) = False Then
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

        Private Sub doMoveLast_XJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_XJ(strErrMsg, "", Me.m_blnEnforced_XJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdXJ.PageCount - 1, Me.grdXJ.PageCount)
                Me.grdXJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_XJ(strErrMsg) = False Then
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

        Private Sub doMoveNext_XJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_XJ(strErrMsg, "", Me.m_blnEnforced_XJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdXJ.CurrentPageIndex + 1, Me.grdXJ.PageCount)
                Me.grdXJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_XJ(strErrMsg) = False Then
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

        Private Sub doMovePrevious_XJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_XJ(strErrMsg, "", Me.m_blnEnforced_XJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdXJ.CurrentPageIndex - 1, Me.grdXJ.PageCount)
                Me.grdXJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_XJ(strErrMsg) = False Then
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

        Private Sub doGotoPage_XJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtXJPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_XJ(strErrMsg, "", Me.m_blnEnforced_XJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdXJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_XJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtXJPageIndex.Text = (Me.grdXJ.CurrentPageIndex + 1).ToString()
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

        Private Sub doSetPageSize_XJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtXJPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_XJ(strErrMsg, "", Me.m_blnEnforced_XJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdXJ.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_XJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtXJPageSize.Text = (Me.grdXJ.PageSize).ToString()
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

        Private Sub doSelectAll_XJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdXJ, 0, Me.m_cstrCheckBoxIdInDataGrid_grdXJ, True) = False Then
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

        Private Sub doDeSelectAll_XJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdXJ, 0, Me.m_cstrCheckBoxIdInDataGrid_grdXJ, False) = False Then
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

        Private Sub lnkCZXJMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJMoveFirst.Click
            Me.doMoveFirst_XJ("lnkCZXJMoveFirst")
        End Sub

        Private Sub lnkCZXJMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJMoveLast.Click
            Me.doMoveLast_XJ("lnkCZXJMoveLast")
        End Sub

        Private Sub lnkCZXJMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJMoveNext.Click
            Me.doMoveNext_XJ("lnkCZXJMoveNext")
        End Sub

        Private Sub lnkCZXJMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJMovePrev.Click
            Me.doMovePrevious_XJ("lnkCZXJMovePrev")
        End Sub

        Private Sub lnkCZXJGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJGotoPage.Click
            Me.doGotoPage_XJ("lnkCZXJGotoPage")
        End Sub

        Private Sub lnkCZXJSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJSetPageSize.Click
            Me.doSetPageSize_XJ("lnkCZXJSetPageSize")
        End Sub

        Private Sub lnkCZXJSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJSelectAll.Click
            Me.doSelectAll_XJ("lnkCZXJSelectAll")
        End Sub

        Private Sub lnkCZXJDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXJDeSelectAll.Click
            Me.doDeSelectAll_XJ("lnkCZXJDeSelectAll")
        End Sub
        'zengxianglin 2008-10-14

        Private Sub btnSelAll_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_XJ.Click
            Me.doSelectAll_XJ("btnSelAll_XJ")
        End Sub

        Private Sub btnDeSelAll_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_XJ.Click
            Me.doDeSelectAll_XJ("btnDeSelAll_XJ")
        End Sub










        'zengxianglin 2008-10-14
        Private Sub doMoveFirst_NXJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_NXJ(strErrMsg, Me.htxtQuery_NXJ.Value, Me.m_blnEnforced_NXJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdNXJ.PageCount)
                Me.grdNXJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NXJ(strErrMsg) = False Then
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

        Private Sub doMoveLast_NXJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_NXJ(strErrMsg, Me.htxtQuery_NXJ.Value, Me.m_blnEnforced_NXJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdNXJ.PageCount - 1, Me.grdNXJ.PageCount)
                Me.grdNXJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NXJ(strErrMsg) = False Then
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

        Private Sub doMoveNext_NXJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_NXJ(strErrMsg, Me.htxtQuery_NXJ.Value, Me.m_blnEnforced_NXJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdNXJ.CurrentPageIndex + 1, Me.grdNXJ.PageCount)
                Me.grdNXJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NXJ(strErrMsg) = False Then
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

        Private Sub doMovePrevious_NXJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_NXJ(strErrMsg, Me.htxtQuery_NXJ.Value, Me.m_blnEnforced_NXJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdNXJ.CurrentPageIndex - 1, Me.grdNXJ.PageCount)
                Me.grdNXJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NXJ(strErrMsg) = False Then
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

        Private Sub doGotoPage_NXJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtNXJPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_NXJ(strErrMsg, Me.htxtQuery_NXJ.Value, Me.m_blnEnforced_NXJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdNXJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NXJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtNXJPageIndex.Text = (Me.grdNXJ.CurrentPageIndex + 1).ToString()
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

        Private Sub doSetPageSize_NXJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtNXJPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_NXJ(strErrMsg, Me.htxtQuery_NXJ.Value, Me.m_blnEnforced_NXJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdNXJ.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_NXJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtNXJPageSize.Text = (Me.grdNXJ.PageSize).ToString()
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

        Private Sub doSelectAll_NXJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdNXJ, 0, Me.m_cstrCheckBoxIdInDataGrid_grdNXJ, True) = False Then
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

        Private Sub doDeSelectAll_NXJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdNXJ, 0, Me.m_cstrCheckBoxIdInDataGrid_grdNXJ, False) = False Then
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

        Private Sub lnkCZNXJMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNXJMoveFirst.Click
            Me.doMoveFirst_NXJ("lnkCZNXJMoveFirst")
        End Sub

        Private Sub lnkCZNXJMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNXJMoveLast.Click
            Me.doMoveLast_NXJ("lnkCZNXJMoveLast")
        End Sub

        Private Sub lnkCZNXJMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNXJMoveNext.Click
            Me.doMoveNext_NXJ("lnkCZNXJMoveNext")
        End Sub

        Private Sub lnkCZNXJMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNXJMovePrev.Click
            Me.doMovePrevious_NXJ("lnkCZNXJMovePrev")
        End Sub

        Private Sub lnkCZNXJGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNXJGotoPage.Click
            Me.doGotoPage_NXJ("lnkCZNXJGotoPage")
        End Sub

        Private Sub lnkCZNXJSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNXJSetPageSize.Click
            Me.doSetPageSize_NXJ("lnkCZNXJSetPageSize")
        End Sub

        Private Sub lnkCZNXJSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNXJSelectAll.Click
            Me.doSelectAll_NXJ("lnkCZNXJSelectAll")
        End Sub

        Private Sub lnkCZNXJDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNXJDeSelectAll.Click
            Me.doDeSelectAll_NXJ("lnkCZNXJDeSelectAll")
        End Sub
        'zengxianglin 2008-10-14

        Private Sub btnSelAll_NXJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_NXJ.Click
            Me.doSelectAll_NXJ("btnSelAll_NXJ")
        End Sub

        Private Sub btnDeSelAll_NXJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_NXJ.Click
            Me.doDeSelectAll_NXJ("btnDeSelAll_NXJ")
        End Sub












        'zengxianglin 2008-10-14 ����
        'zengxianglin 2010-01-05 ����
        Private Sub doSaveSJLD_XJ(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            strErrMsg = ""

            Try
                '���
                If Me.grdXJ.Items.Count < 1 Then
                    strErrMsg = "����[doSaveSJLD_XJ]�����б���û�����ݣ�"
                    GoTo errProc
                End If
                If Me.grdXJ.SelectedIndex < 0 Then
                    strErrMsg = "����[doSaveSJLD_XJ]�����б���û�����ݣ�"
                    GoTo errProc
                End If
                If Me.ddlZJDM_XJ.SelectedIndex < 0 Then
                    strErrMsg = "����[doSaveSJLD_XJ]û��ָ��[��ְ��]��"
                    GoTo errProc
                End If
                If Me.ddlYDYY_XJ.SelectedIndex < 0 Then
                    strErrMsg = "����[doSaveSJLD_XJ]û��ָ��[�䶯ԭ��]��"
                    GoTo errProc
                End If
                If Me.rblRYZT_XJ.SelectedIndex < 0 Then
                    strErrMsg = "����[doSaveSJLD_XJ]û��ָ��[������Ա]��[��ʽְ��]��"
                    GoTo errProc
                End If
                If Me.rblSFZB_XJ.SelectedIndex < 0 Then
                    strErrMsg = "����[doSaveSJLD_XJ]û��ָ��[������Ա]��[������Ա]��"
                    GoTo errProc
                End If
                If Me.htxtZZDM_XJ.Value.Trim = "" Then
                    strErrMsg = "����[doSaveSJLD_XJ]û��ָ��[�µ�λ]��"
                    GoTo errProc
                End If
                'zengxianglin 2008-10-14
                'If Me.htxtSJLD_XJ.Value.Trim = "" Then
                '    strErrMsg = "����û��ָ��[���쵼]��"
                '    GoTo errProc
                'End If
                'zengxianglin 2008-10-14
                Dim strSSFZ As String = ""
                If Me.ddlSSFZ_XJ.SelectedIndex >= 0 Then
                    strSSFZ = Me.ddlSSFZ_XJ.SelectedItem.Text
                End If

                '��ȡ��Ӧ������
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim i As Integer = Me.grdXJ.SelectedIndex
                Dim intRecPos As Integer = 0
                intRecPos = -1
                intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdXJ.CurrentPageIndex, Me.grdXJ.PageSize)
                objDataRow = Nothing
                objDataRow = Me.m_objDataSet_XJ.Tables(strTable).DefaultView.Item(intRecPos).Row

                'д����Ϣ
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD) = Me.htxtSJLD_XJ.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLDMC) = Me.txtSJLD_XJ.Text
                'zengxianglin 2008-10-14
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW) = Me.htxtZZDM_XJ.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC) = Me.txtZZDM_XJ.Text
                'zengxianglin 2008-11-18
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW) = Me.htxtZGDW_XJ.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC) = Me.txtZGDW_XJ.Text
                'zengxianglin 2008-11-18
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM) = Me.ddlZJDM_XJ.SelectedItem.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC) = Me.ddlZJDM_XJ.SelectedItem.Text.Split("|".ToCharArray)(1)
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ) = strSSFZ
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYY) = Me.ddlYDYY_XJ.SelectedItem.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYYMC) = Me.ddlYDYY_XJ.SelectedItem.Text.Split("|".ToCharArray)(1)
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB) = objPulicParameters.getObjectValue(Me.rblSFZB_XJ.SelectedValue, 1)
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT) = objPulicParameters.getObjectValue(Me.rblRYZT_XJ.SelectedValue, 2)
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZTMC) = Me.rblRYZT_XJ.SelectedItem.Text
                'zengxianglin 2008-10-14

                '��ʾ
                If Me.showModuleData_XJ(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        'zengxianglin 2008-10-14 ����
        'zengxianglin 2010-01-05 ����
        Private Sub doSaveSJLD_NXJ(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            strErrMsg = ""

            Try
                '���
                If Me.grdRY.Items.Count < 1 Then
                    strErrMsg = "����[doSaveSJLD_NXJ]û����Ա��Ϣ��"
                    GoTo errProc
                End If
                If Me.grdRY.SelectedIndex < 0 Then
                    strErrMsg = "����[doSaveSJLD_NXJ]û����Ա��Ϣ��"
                    GoTo errProc
                End If
                If Me.grdNXJ.Items.Count < 1 Then
                    strErrMsg = "����[doSaveSJLD_NXJ]�����б���û�����ݣ�"
                    GoTo errProc
                End If
                If Me.grdNXJ.SelectedIndex < 0 Then
                    strErrMsg = "����[doSaveSJLD_NXJ]�����б���û�����ݣ�"
                    GoTo errProc
                End If
                If Me.ddlZJDM_NXJ.SelectedIndex < 0 Then
                    strErrMsg = "����[doSaveSJLD_NXJ]û��ָ��[��ְ��]��"
                    GoTo errProc
                End If
                If Me.ddlYDYY_NXJ.SelectedIndex < 0 Then
                    strErrMsg = "����[doSaveSJLD_XJ]û��ָ��[�䶯ԭ��]��"
                    GoTo errProc
                End If
                If Me.rblRYZT_NXJ.SelectedIndex < 0 Then
                    strErrMsg = "����[doSaveSJLD_XJ]û��ָ��[������Ա]��[��ʽְ��]��"
                    GoTo errProc
                End If
                If Me.rblSFZB_NXJ.SelectedIndex < 0 Then
                    strErrMsg = "����[doSaveSJLD_XJ]û��ָ��[������Ա]��[������Ա]��"
                    GoTo errProc
                End If
                If Me.htxtZZDM_NXJ.Value.Trim = "" Then
                    strErrMsg = "����[doSaveSJLD_NXJ]û��ָ��[�µ�λ]��"
                    GoTo errProc
                End If
                Dim strSSFZ As String = ""
                If Me.ddlSSFZ_NXJ.SelectedIndex >= 0 Then
                    strSSFZ = Me.ddlSSFZ_NXJ.SelectedItem.Text
                End If

                '��ȡ��Ա��Ϣ
                Dim strSJLDMC As String = ""
                Dim strSJLD As String = ""
                Dim intIndex As Integer
                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM)
                strSJLD = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intIndex)
                intIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC)
                strSJLDMC = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intIndex)

                '��ȡ����
                If Me.getModuleData_NXJ(strErrMsg, Me.htxtQuery_NXJ.Value, False) = False Then
                    GoTo errProc
                End If

                '��ȡ��Ӧ������
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim i As Integer = Me.grdNXJ.SelectedIndex
                Dim intRecPos As Integer = 0
                intRecPos = -1
                intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdNXJ.CurrentPageIndex, Me.grdNXJ.PageSize)
                objDataRow = Nothing
                objDataRow = Me.m_objDataSet_NXJ.Tables(strTable).DefaultView.Item(intRecPos).Row

                'д����Ϣ
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD) = strSJLD
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLDMC) = strSJLDMC
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW) = Me.htxtZZDM_NXJ.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC) = Me.txtZZDM_NXJ.Text
                'zengxianglin 2008-11-18
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW) = Me.htxtZGDW_NXJ.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC) = Me.txtZGDW_NXJ.Text
                'zengxianglin 2008-11-18
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM) = Me.ddlZJDM_NXJ.SelectedItem.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC) = Me.ddlZJDM_NXJ.SelectedItem.Text.Split("|".ToCharArray)(1)
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ) = strSSFZ
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYY) = Me.ddlYDYY_NXJ.SelectedItem.Value
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYYMC) = Me.ddlYDYY_NXJ.SelectedItem.Text.Split("|".ToCharArray)(1)
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB) = objPulicParameters.getObjectValue(Me.rblSFZB_NXJ.SelectedValue, 1)
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT) = objPulicParameters.getObjectValue(Me.rblRYZT_NXJ.SelectedValue, 2)
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZTMC) = Me.rblRYZT_NXJ.SelectedItem.Text

                '��ʾ
                If Me.showModuleData_NXJ(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doReset(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.doResetToOrg(strErrMsg) = False Then
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

        Private Sub doDelete_NXJ(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '��ȡ����
                If Me.getModuleData_NXJ(strErrMsg, Me.htxtQuery_NXJ.Value, False) = False Then
                    GoTo errProc
                End If

                'ɾ��ѡ����
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdNXJ.Items.Count
                For i = intCount - 1 To 0 Step -1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdNXJ.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdNXJ) = True Then
                        With Me.m_objDataSet_NXJ.Tables(strTable)
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdNXJ.CurrentPageIndex, Me.grdNXJ.PageSize)
                            objDataRow = Nothing
                            objDataRow = .DefaultView.Item(intRecPos).Row
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                        End With
                    End If
                Next

                '������ʾ
                If Me.showModuleData_NXJ(strErrMsg) = False Then
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

        Private Sub btnSaveSJLD_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveSJLD_XJ.Click
            Me.doSaveSJLD_XJ("btnSaveSJLD_XJ")
        End Sub

        Private Sub btnSaveSJLD_NXJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveSJLD_NXJ.Click
            Me.doSaveSJLD_NXJ("btnSaveSJLD_NXJ")
        End Sub

        Private Sub btnDelete_NXJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_NXJ.Click
            Me.doDelete_NXJ("btnDelete_NXJ")
        End Sub

        Private Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
            Me.doReset("btnReset")
        End Sub










        'zengxianglin 2008-10-14
        Private Sub doJSFZLB(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, Me.txtSSDW.Text) = False Then
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
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private Sub doJSFZLB_XJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ_XJ, Me.txtZZDM_XJ.Text) = False Then
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
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private Sub doJSFZLB_NXJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ_NXJ, Me.txtZZDM_NXJ.Text) = False Then
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
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private Sub doGetSJLD_XJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.showEditPanel_XJ(strErrMsg) = False Then
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
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private Sub doGetSJLD_NXJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.showEditPanel_NXJ(strErrMsg) = False Then
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
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private Sub btnJSFZLB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJSFZLB.Click
            Me.doJSFZLB("btnJSFZLB")
        End Sub
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private Sub btnJSFZLB_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJSFZLB_XJ.Click
            Me.doJSFZLB_XJ("btnJSFZLB_XJ")
        End Sub
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private Sub btnJSFZLB_NXJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJSFZLB_NXJ.Click
            Me.doJSFZLB_NXJ("btnJSFZLB_NXJ")
        End Sub
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private Sub btnGetSJLD_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetSJLD_XJ.Click
            Me.doGetSJLD_XJ("btnGetSJLD_XJ")
        End Sub
        'zengxianglin 2008-10-14

        'zengxianglin 2008-10-14
        Private Sub btnGetSJLD_NXJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetSJLD_NXJ.Click
            Me.doGetSJLD_NXJ("btnGetSJLD_NXJ")
        End Sub
        'zengxianglin 2008-10-14










        Private Sub doSearch_RY(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.searchModuleData_RY(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_RY(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_XJ(strErrMsg, "", True) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_XJ(strErrMsg) = False Then
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

        Private Sub doSearch_NXJ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.searchModuleData_NXJ(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_NXJ(strErrMsg) = False Then
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

        Private Sub doSearchFull_RY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '��ȡ����
                If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
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
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj = Nothing
                Dim strUrl As String = ""
                objISjcxCxtj = New Josco.JsKernal.BusinessFacade.ISjcxCxtj
                With objISjcxCxtj
                    .iQueryTable = Me.m_objDataSet_RY.Tables(strTable)
                    Try
                        If Me.htxtSessionIdQuery_RY.Value.Trim <> "" Then
                            .iDataSetTJ = CType(Session(Me.htxtSessionIdQuery_RY.Value), Josco.JsKernal.Common.Data.QueryData)
                        Else
                            .iDataSetTJ = Nothing
                        End If
                    Catch ex As Exception
                        .iDataSetTJ = Nothing
                    End Try
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
                Dim strNewSessionId As String = ""
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

        Private Sub doSearchFull_NXJ(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '��ȡ����
                If Me.getModuleData_NXJ(strErrMsg, Me.htxtQuery_NXJ.Value, False) = False Then
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
                Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj = Nothing
                Dim strUrl As String = ""
                objISjcxCxtj = New Josco.JsKernal.BusinessFacade.ISjcxCxtj
                With objISjcxCxtj
                    .iQueryTable = Me.m_objDataSet_NXJ.Tables(strTable)
                    Try
                        If Me.htxtSessionIdQuery_NXJ.Value.Trim <> "" Then
                            .iDataSetTJ = CType(Session(Me.htxtSessionIdQuery_NXJ.Value), Josco.JsKernal.Common.Data.QueryData)
                        Else
                            .iDataSetTJ = Nothing
                        End If
                    Catch ex As Exception
                        .iDataSetTJ = Nothing
                    End Try
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
                Dim strNewSessionId As String = ""
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

        Private Sub btnSearch_RY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch_RY.Click
            Me.doSearch_RY("btnSearch_RY")
        End Sub

        Private Sub btnSearch_NXJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch_NXJ.Click
            Me.doSearch_NXJ("btnSearch_NXJ")
        End Sub

        Private Sub btnSearchFull_RY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchFull_RY.Click
            Me.doSearchFull_RY("btnSearchFull_RY")
        End Sub

        Private Sub btnSearchFull_NXJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchFull_NXJ.Click
            Me.doSearchFull_NXJ("btnSearchFull_NXJ")
        End Sub











        Private Sub doSelectSJLD_XJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                'zengxianglin 2008-11-18
                '���
                If Me.txtSXSJ.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[�䶯ʱ��]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtSXSJ.Text) = False Then
                    strErrMsg = "������Ч��[�䶯ʱ��]��"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-18

                '�����ֳ�����
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIEstateRsRenyuanJiagou_Rela As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela = Nothing
                Dim strUrl As String = ""
                objIEstateRsRenyuanJiagou_Rela = New Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela
                With objIEstateRsRenyuanJiagou_Rela
                    'zengxianglin 2008-11-18
                    '.iTime = Now.ToString("yyyy-MM-dd")
                    .iTime = Me.txtSXSJ.Text
                    'zengxianglin 2008-11-18
                    'zengxianglin 2008-10-14
                    .iAllowNull = True
                    'zengxianglin 2008-10-14
                    .iMode = 1

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
                Session.Add(strNewSessionId, objIEstateRsRenyuanJiagou_Rela)
                strUrl = ""
                strUrl += "estate_rs_renyuanjiagou_rela.aspx"
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

        Private Sub doSelectSJLD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                'zengxianglin 2008-11-18
                '���
                If Me.txtSXSJ.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[�䶯ʱ��]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtSXSJ.Text) = False Then
                    strErrMsg = "������Ч��[�䶯ʱ��]��"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-18

                '�����ֳ�����
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIEstateRsRenyuanJiagou_Rela As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela = Nothing
                Dim strUrl As String = ""
                objIEstateRsRenyuanJiagou_Rela = New Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela
                With objIEstateRsRenyuanJiagou_Rela
                    'zengxianglin 2008-11-18
                    '.iTime = Now.ToString("yyyy-MM-dd")
                    .iTime = Me.txtSXSJ.Text
                    'zengxianglin 2008-11-18
                    'zengxianglin 2008-10-14
                    .iAllowNull = True
                    'zengxianglin 2008-10-14
                    .iMode = 1

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
                Session.Add(strNewSessionId, objIEstateRsRenyuanJiagou_Rela)
                strUrl = ""
                strUrl += "estate_rs_renyuanjiagou_rela.aspx"
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

        Private Sub doSelectZZDM(ByVal strControlId As String)

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

        Private Sub doSelectZZDM_XJ(ByVal strControlId As String)

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

        Private Sub doSelectZZDM_NXJ(ByVal strControlId As String)

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
        Private Sub doSelectZGDW(ByVal strControlId As String)

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
                    .iAllowNull = True
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

        'zengxianglin 2008-11-18
        Private Sub doSelectZGDW_XJ(ByVal strControlId As String)

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
                    .iAllowNull = True
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

        'zengxianglin 2008-11-18
        Private Sub doSelectZGDW_NXJ(ByVal strControlId As String)

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
                    .iAllowNull = True
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

        Private Sub btnSelectSJLD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectSJLD.Click
            Me.doSelectSJLD("btnSelectSJLD")
        End Sub

        Private Sub btnSelectSJLD_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectSJLD_XJ.Click
            Me.doSelectSJLD_XJ("btnSelectSJLD_XJ")
        End Sub

        Private Sub btnSelectZZDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZZDM.Click
            Me.doSelectZZDM("btnSelectZZDM")
        End Sub

        Private Sub btnSelectZZDM_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZZDM_XJ.Click
            Me.doSelectZZDM_XJ("btnSelectZZDM_XJ")
        End Sub

        Private Sub btnSelectZZDM_NXJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZZDM_NXJ.Click
            Me.doSelectZZDM_NXJ("btnSelectZZDM_NXJ")
        End Sub

        'zengxianglin 2008-11-18
        Private Sub btnSelectZGDW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZGDW.Click
            Me.doSelectZGDW("btnSelectZGDW")
        End Sub
        Private Sub btnSelectZGDW_XJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZGDW_XJ.Click
            Me.doSelectZGDW_XJ("btnSelectZGDW_XJ")
        End Sub
        Private Sub btnSelectZGDW_NXJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZGDW_NXJ.Click
            Me.doSelectZGDW_NXJ("btnSelectZGDW_NXJ")
        End Sub
        'zengxianglin 2008-11-18












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

        'zengxianglin 2008-10-14 ����
        'zengxianglin 2010-01-05 ����
        Private Sub doOK(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objEnvInfo As System.Collections.Specialized.NameValueCollection = Nothing
            Dim objDataSet_MM As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objDataSet_XJ As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objOldData As System.Data.DataRow = Nothing
            Dim objNewData As System.Data.DataRow = Nothing
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 1

            Try
                'zengxianglin 2009-05-14
                '���䶯ʱ��
                Dim strBDSJ As String = ""
                strBDSJ = Me.txtSXSJ.Text.Trim
                If strBDSJ = "" Then
                    strErrMsg = "����û������[����ʱ��]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(strBDSJ) = False Then
                    strErrMsg = "����[" + strBDSJ + "]����Ч�����ڣ�"
                    GoTo errProc
                End If
                Dim objBDSJ As System.DateTime = CType(strBDSJ, System.DateTime)
                If objBDSJ < Now.AddDays(-100) Then
                    strErrMsg = "����[" + strBDSJ + "]����[100]�죬��Щ���ݲ����ٵ�����"
                    GoTo errProc
                End If
                'zengxianglin 2009-05-14
                'zengxianglin 2010-01-05
                '����Ƿ񳬳��涨ִ�е����ޣ�
                Dim intBZXL As Integer
                If objsystemEstateRenshiXingye.getBZXL_RSJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtSXSJ.Text, intBZXL) = False Then
                    GoTo errProc
                End If
                If intBZXL <> 1 Then
                    strErrMsg = "����[" + strBDSJ + "]�����涨ִ�е����ޣ�"
                    GoTo errProc
                End If
                'zengxianglin 2010-01-05

                intStep = 1
                '���
                If Me.grdRY.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[������Ա]��"
                    GoTo errProc
                End If
                If Me.txtSXSJ.Text.Trim = "" Then
                    strErrMsg = "����δָ��[����ʱ��]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtSXSJ.Text) = False Then
                    strErrMsg = "������Ч��[����ʱ��]��"
                    GoTo errProc
                End If
                Me.txtSXSJ.Text = CType(Me.txtSXSJ.Text, System.DateTime).ToString("yyyy-MM-dd")
                If Me.rblRYZT.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[��Ա״̬]��"
                    GoTo errProc
                End If
                If Me.rblSFZB.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[�Ƿ�ռ��]��"
                    GoTo errProc
                End If
                If Me.ddlZJDM.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[ְ��]��"
                    GoTo errProc
                End If
                If Me.ddlYDYY.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[�䶯ԭ��]��"
                    GoTo errProc
                End If
                If Me.htxtSSDW.Value.Trim = "" Then
                    strErrMsg = "����û��ѡ��[��ְ��λ]��"
                    GoTo errProc
                End If

                'zengxianglin 2008-10-14
                Dim strRYDM_MM As String = ""
                Dim strRYMC_MM As String = ""
                Dim intColIndex As Integer
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM)
                strRYDM_MM = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC)
                strRYMC_MM = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(Me.grdRY.SelectedIndex), intColIndex)
                '������䶯����Ϣ
                If CType(Me.txtSXSJ.Text, System.DateTime) <= CType(Me.txtKSSJ.Text, System.DateTime) Then
                    strErrMsg = "����[" + strRYMC_MM + "]��[��Чʱ��]>=[�䶯ʱ��]��"
                    GoTo errProc
                End If
                If Me.htxtSJLD.Value.Trim <> "" Then
                    If strRYDM_MM = Me.htxtSJLD.Value.Trim Then
                        strErrMsg = "����[" + strRYMC_MM + "]��[�ϼ��쵼]������Ϊ�Լ���"
                        GoTo errProc
                    End If
                End If
                'zengxianglin 2008-10-14

                'zengxianglin 2008-10-14
                '����¼���Ա��Ϣ
                '���[�䶯ʱ��]�Ƿ���[ֱ������]��[��Чʱ��]��ͻ��
                '���[�ϼ��쵼]������Ϊ�Լ���
                Dim intRecPos As Integer
                Dim intCols As Integer
                Dim intRows As Integer
                Dim i As Integer
                Dim j As Integer
                Dim strKSSJ As String = ""
                Dim strSJLD As String = ""
                Dim strRYDM As String = ""
                Dim strRYMC As String = ""
                If Me.chkTZYXJ.Checked = True Then
                    With Me.m_objDataSet_XJ.Tables(strTable)
                        intRows = .DefaultView.Count
                        For i = 0 To intRows - 1 Step 1
                            strKSSJ = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ), "", "yyyy-MM-dd")
                            strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM), "")
                            strSJLD = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD), "")
                            strRYMC = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC), "")
                            If CType(Me.txtSXSJ.Text, System.DateTime) <= CType(strKSSJ, System.DateTime) Then
                                strErrMsg = "����ֱ��������Ա[" + strRYMC + "]��[��Чʱ��]>=[�䶯ʱ��]��"
                                GoTo errProc
                            End If
                            If strRYDM = strSJLD Then
                                strErrMsg = "����ֱ��������Ա[" + strRYMC + "]��[�ϼ��쵼]������Ϊ�Լ���"
                                GoTo errProc
                            End If
                        Next
                    End With
                End If

                '����µ��¼���Ա��Ϣ
                If Me.getModuleData_NXJ(strErrMsg, Me.htxtQuery_NXJ.Value, False) = False Then
                    GoTo errProc
                End If
                If Me.chkTZNXJ.Checked = True Then
                    With Me.m_objDataSet_NXJ.Tables(strTable)
                        intRows = .DefaultView.Count
                        For i = 0 To intRows - 1 Step 1
                            strKSSJ = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ), "", "yyyy-MM-dd")
                            strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM), "")
                            strSJLD = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD), "")
                            strRYMC = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC), "")
                            If CType(Me.txtSXSJ.Text, System.DateTime) <= CType(strKSSJ, System.DateTime) Then
                                strErrMsg = "�����µ�������Ա[" + strRYMC + "]��[��Чʱ��]>=[�䶯ʱ��]��"
                                GoTo errProc
                            End If
                            If strRYDM = strSJLD Then
                                strErrMsg = "�����µ�������Ա[" + strRYMC + "]��[�ϼ��쵼]������Ϊ�Լ���"
                                GoTo errProc
                            End If
                            If strRYDM = strRYDM_MM Then
                                strErrMsg = "�����µ�������Ա[" + strRYMC + "]�Ĳ��ܺ��Լ���"
                                GoTo errProc
                            End If
                        Next
                    End With
                End If

                'ѯ��
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ������������д��ȷ����/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��ʾ��ش��ǡ����Ŵ���
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                        GoTo errProc
                    End If

                    '׼������
                    objEnvInfo = New System.Collections.Specialized.NameValueCollection
                    objEnvInfo.Add("BDSJ", Me.txtSXSJ.Text)
                    objEnvInfo.Add("BDYY", Me.ddlYDYY.SelectedItem.Value)
                    objEnvInfo.Add("BDYYMC", Me.ddlYDYY.SelectedItem.Text.Split("|".ToCharArray)(1))

                    '׼�����䶯������
                    objDataSet_MM = New Josco.JSOA.Common.Data.estateRenshiXingyeData(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_V_RS_RENYUANJIAGOU)
                    With Me.grdRY
                        intRecPos = objDataGridProcess.getRecordPosition(.SelectedIndex, .CurrentPageIndex, .PageSize)
                    End With
                    With Me.m_objDataSet_RY.Tables(strTable)
                        objOldData = .DefaultView.Item(intRecPos).Row
                    End With
                    Dim objDataRow As System.Data.DataRow = Nothing
                    objDataRow = objDataSet_MM.Tables(strTable).NewRow
                    With Me.m_objDataSet_RY.Tables(strTable)
                        intCols = .Columns.Count
                        For i = 0 To intCols - 1 Step 1
                            objDataRow.Item(i) = .DefaultView.Item(intRecPos).Item(i)
                        Next
                        If Me.rblRYZT.SelectedValue = "2" Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT) = 2
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZTMC) = Josco.JSOA.Common.Data.estateRenshiXingyeData.getRenyuanZhuangtaiName(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumRenyuanZhuangtai.Ruzhi)
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT) = 1
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZTMC) = Josco.JSOA.Common.Data.estateRenshiXingyeData.getRenyuanZhuangtaiName(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumRenyuanZhuangtai.Shiyong)
                        End If
                        If Me.rblSFZB.SelectedValue = "1" Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB) = 1
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB) = 0
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW) = Me.htxtSSDW.Value
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC) = Me.txtSSDW.Text
                        'zengxianglin 2008-11-18
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW) = Me.htxtZGDW.Value
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC) = Me.txtZGDW.Text
                        'zengxianglin 2008-11-18
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM) = Me.ddlZJDM.SelectedItem.Value
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC) = Me.ddlZJDM.SelectedItem.Text.Split("|".ToCharArray)(1)
                        If Me.ddlSSFZ.SelectedIndex < 0 Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ) = ""
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ) = Me.ddlSSFZ.SelectedItem.Text
                        End If
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD) = Me.htxtSJLD.Value
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLDMC) = Me.txtSJLD.Text
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYY) = Me.ddlYDYY.SelectedItem.Value
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYYMC) = Me.ddlYDYY.SelectedItem.Text.Split("|".ToCharArray)(1)
                    End With
                    objDataSet_MM.Tables(strTable).Rows.Add(objDataRow)
                    With objDataSet_MM.Tables(strTable)
                        objNewData = .DefaultView.Item(0).Row
                    End With

                    '׼��ֱ���¼�������
                    objDataSet_XJ = New Josco.JSOA.Common.Data.estateRenshiXingyeData(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_V_RS_RENYUANJIAGOU)
                    If Me.chkTZYXJ.Checked = True Then
                        With Me.m_objDataSet_XJ.Tables(strTable)
                            intRows = .DefaultView.Count
                            intCols = .Columns.Count
                            For i = 0 To intRows - 1 Step 1
                                objDataRow = objDataSet_XJ.Tables(strTable).NewRow
                                For j = 0 To intCols - 1 Step 1
                                    objDataRow.Item(j) = .DefaultView.Item(i).Item(j)
                                Next
                                objDataSet_XJ.Tables(strTable).Rows.Add(objDataRow)
                            Next
                        End With
                    End If

                    '׼��ֱ���¼�������
                    If Me.chkTZNXJ.Checked = True Then
                        With Me.m_objDataSet_NXJ.Tables(strTable)
                            intRows = .DefaultView.Count
                            intCols = .Columns.Count
                            For i = 0 To intRows - 1 Step 1
                                objDataRow = objDataSet_XJ.Tables(strTable).NewRow
                                For j = 0 To intCols - 1 Step 1
                                    objDataRow.Item(j) = .DefaultView.Item(i).Item(j)
                                Next
                                objDataSet_XJ.Tables(strTable).Rows.Add(objDataRow)
                            Next
                        End With
                    End If

                    '����¼���Ա�������Ƿ�����ظ��������
                    With objDataSet_XJ.Tables(strTable)
                        Dim strRYDM1 As String = ""
                        Dim strRYMC1 As String = ""
                        intRows = .DefaultView.Count
                        For i = 0 To intRows - 1 Step 1
                            strRYDM = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM), "")
                            strRYMC = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC), "")
                            With objDataSet_XJ.Tables(strTable)
                                For j = i + 1 To intRows - 1 Step 1
                                    strRYDM1 = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYDM), "")
                                    strRYMC1 = objPulicParameters.getObjectValue(.DefaultView.Item(j).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC), "")
                                    If strRYDM = strRYDM1 Then
                                        strErrMsg = "�����¼���Ա������[" + strRYMC + "]�����ظ���"
                                        GoTo errProc
                                    End If
                                Next
                            End With
                        Next
                    End With

                    '��������
                    'If objsystemEstateRenshiXingye.doAdjust_RenyuanJiagou( _
                    '    strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                    '     objEnvInfo, objOldData, objNewData, objDataSet_XJ, Nothing) = False Then
                    '    GoTo errProc
                    'End If

                    '��¼��־
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[" + strRYDM + "]������[���µ���]��")

                    'ˢ����ʾ
                    If Me.getModuleData_RY(strErrMsg, Me.htxtQuery_RY.Value) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_RY(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_XJ(strErrMsg, "", True) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_XJ(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_NXJ(strErrMsg, Me.htxtQuery_NXJ.Value, True) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_NXJ(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_MM)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_XJ)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objEnvInfo)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_MM)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_XJ)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objEnvInfo)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        'zengxianglin 2008-10-14
        'Private Sub btnViewJG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewJG.Click
        '    Dim strUrl As String = "estate_rs_renyuanjiagou.aspx"
        '    Response.Redirect(strUrl)
        'End Sub
        'zengxianglin 2008-10-14

    End Class

End Namespace
