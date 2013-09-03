Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_es_hetongzl_info
    ' 
    ' �������ʣ�
    '     I/O
    '
    ' ���������� 
    '   �������޺�ͬ����Ϣ������ģ��
    '
    ' ���ļ�¼��
    '     zengxianglin 2010-01-06 ����
    '     zengxianglin 2010-01-13 ����
    '     zengxianglin 2010-12-26 ����
    '----------------------------------------------------------------

    Partial Class estate_es_hetongzl_info
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'zengxianglin 2008-11-22
        'zengxianglin 2008-11-22
        'zengxianglin 2008-11-25
        'zengxianglin 2008-11-25










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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsHetongZlInfo
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdWYXX��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdWYXX As String = "chkWYXX"
        Private Const m_cstrDataGridInDIV_grdWYXX As String = "divWYXX"
        Private m_intFixedColumns_grdWYXX As Integer

        '----------------------------------------------------------------
        '����������grdYWRY��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdYWRY As String = "chkYWRY"
        Private Const m_cstrDataGridInDIV_grdYWRY As String = "divYWRY"
        Private m_intFixedColumns_grdYWRY As Integer

        '----------------------------------------------------------------
        '����������grdZLQX��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdZLQX As String = "chkZLQX"
        Private Const m_cstrDataGridInDIV_grdZLQX As String = "divZLQX"
        Private m_intFixedColumns_grdZLQX As Integer

        '----------------------------------------------------------------
        '��ǰ��������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet_MAINQRS As Josco.JSOA.Common.Data.estateErshouData
        Private m_objDataSet_MAINHT As Josco.JSOA.Common.Data.estateErshouData
        Private m_objDataSet_WYXX As Josco.JSOA.Common.Data.estateErshouData
        Private m_objDataSet_YWRY As Josco.JSOA.Common.Data.estateErshouData
        Private m_objDataSet_ZLQX As Josco.JSOA.Common.Data.estateErshouData

        '----------------------------------------------------------------
        '��������
        '----------------------------------------------------------------
        Private m_objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_blnEditMode As Boolean
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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo)
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
                    Me.htxtDivLeftWYXX.Value = .htxtDivLeftWYXX
                    Me.htxtDivTopWYXX.Value = .htxtDivTopWYXX
                    Me.htxtDivLeftYWRY.Value = .htxtDivLeftYWRY
                    Me.htxtDivTopYWRY.Value = .htxtDivTopYWRY
                    Me.htxtDivLeftZLQX.Value = .htxtDivLeftZLQX
                    Me.htxtDivTopZLQX.Value = .htxtDivTopZLQX

                    Me.htxtSessionId_WYXX.Value = .htxtSessionId_WYXX
                    Try
                        Me.grdWYXX.PageSize = .grdWYXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdWYXX.CurrentPageIndex = .grdWYXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdWYXX.SelectedIndex = .grdWYXX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.htxtSessionId_YWRY.Value = .htxtSessionId_YWRY
                    Try
                        Me.grdYWRY.PageSize = .grdYWRY_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYWRY.CurrentPageIndex = .grdYWRY_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdYWRY.SelectedIndex = .grdYWRY_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.htxtSessionId_ZLQX.Value = .htxtSessionId_ZLQX
                    Try
                        Me.grdZLQX.PageSize = .grdZLQX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdZLQX.CurrentPageIndex = .grdZLQX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdZLQX.SelectedIndex = .grdZLQX_SelectedIndex
                    Catch ex As Exception
                    End Try

                    '****************************************************************
                    Try
                        Me.ddlJFZJLB.SelectedIndex = .ddlJFZJLB_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlYFZJLB.SelectedIndex = .ddlYFZJLB_SelectedIndex
                    Catch ex As Exception
                    End Try
                    '****************************************************************
                    Try
                        Me.rblZJTGYD.SelectedIndex = .rblZJTGYD_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblFZFSYD.SelectedIndex = .rblFZFSYD_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.rblSFZFYD.SelectedIndex = .rblSFZFYD_SelectedIndex
                    Catch ex As Exception
                    End Try
                    '****************************************************************
                    Me.htxtWYBS.Value = .htxtWYBS
                    Me.htxtQRSH.Value = .htxtQRSH
                    Me.htxtDGRQ.Value = .htxtDGRQ
                    Me.txtJLRQ.Text = .txtJLRQ
                    Me.txtFWDZ.Text = .txtFWDZ
                    Me.txtJYZMJ.Text = .txtJYZMJ
                    Me.txtJYZZJ.Text = .txtJYZZJ
                    Me.txtJYYZJ.Text = .txtJYYZJ
                    Me.txtZLBZJ.Text = .txtZLBZJ
                    Me.txtJFDLF.Text = .txtJFDLF
                    Me.txtYFDLF.Text = .txtYFDLF
                    Me.txtDLFZK.Text = .txtDLFZK
                    Me.txtZQYS.Text = .txtZQYS
                    Me.txtJZR.Text = .txtJZR
                    Me.txtZNJBL.Text = .txtZNJBL
                    Me.txtNDZBL.Text = .txtNDZBL
                    Me.txtJLZKSM.Text = .txtJLZKSM
                    '****************************************************************
                    Me.txtJFDLR.Text = .txtJFDLR
                    Me.txtJFLXDH.Text = .txtJFLXDH
                    Me.txtJFLXDZ.Text = .txtJFLXDZ
                    Me.txtJFMC.Text = .txtJFMC
                    Me.txtJFZZHM.Text = .txtJFZZHM
                    '****************************************************************
                    Me.txtYFDLR.Text = .txtYFDLR
                    Me.txtYFLXDH.Text = .txtYFLXDH
                    Me.txtYFLXDZ.Text = .txtYFLXDZ
                    Me.txtYFMC.Text = .txtYFMC
                    Me.txtYFZZHM.Text = .txtYFZZHM

                    '****************************************************************
                    Me.htxtHTWYBS.Value = .htxtHTWYBS
                    Me.htxtHTZT.Value = .htxtHTZT
                    Me.txtHTBH.Text = .txtHTBH
                    Me.txtHTRQ.Text = .txtHTRQ
                    'zengxianglin 2008-11-22
                    Me.txtTJRQ.Text = .txtTJRQ
                    'zengxianglin 2008-11-22
                    'zengxianglin 2008-11-25
                    Me.txtAJFH.Text = .txtAJFH
                    'zengxianglin 2008-11-25
                    'zengxianglin 2008-11-25
                    .txtAJFH = Me.txtAJFH.Text
                    'zengxianglin 2008-11-25
                    Me.txtBZXX.Text = .txtBZXX
                    '****************************************************************
                    Me.ddlFKFS.SelectedIndex = .ddlFKFS_SelectedIndex

                    '****************************************************************
                    Me.txtQX_JZR.Text = .txtQX_JZR
                    Me.txtQX_KSRQ.Text = .txtQX_KSRQ
                    Me.txtQX_YZJE.Text = .txtQX_YZJE
                    Me.txtQX_ZZRQ.Text = .txtQX_ZZRQ
                    Me.txtQX_YZZE.Text = .txtQX_YZZE
                    Me.txtQX_ZQYS.Text = .txtQX_ZQYS
                    '****************************************************************
                    Me.rblQX_JZFS.SelectedIndex = .rblQX_JZFS_SelectedIndex

                    'zengxianglin 2010-12-28
                    Me.txtKYBH.Text = .txtKYBH
                    Me.txtCCDZ.Text = .txtCCDZ
                    Me.txtCCF.Text = .txtCCF
                    Me.txtSSYJ.Text = .txtSSYJ
                    Me.txtHZYJ.Text = .txtHZYJ
                    Me.txtYZQN.Text = .txtYZQN
                    Me.txtYYQT.Text = .txtYYQT
                    Me.txtYZDY.Text = .txtYZDY
                    Me.txtMJQN.Text = .txtMJQN
                    Me.txtKYQT.Text = .txtKYQT
                    Me.txtKHDY.Text = .txtKHDY
                    Me.rblYZQC.SelectedIndex = .rblYZQC_SelectedIndex
                    Me.rblYZLY.SelectedIndex = .rblYZLY_SelectedIndex
                    Me.rblSYWY.SelectedIndex = .rblSYWY_SelectedIndex
                    Me.rblMJQC.SelectedIndex = .rblMJQC_SelectedIndex
                    Me.rblKHLY.SelectedIndex = .rblKHLY_SelectedIndex
                    Me.txtZLKS.Text = .txtZLKS
                    Me.txtZLJS.Text = .txtZLJS
                    Me.rblSDMQ.SelectedIndex = .rblSDMQ_SelectedIndex
                    Me.rblDHF.SelectedIndex = .rblDHF_SelectedIndex
                    Me.rblGLF.SelectedIndex = .rblGLF_SelectedIndex
                    Me.rblZLFP.SelectedIndex = .rblZLFP_SelectedIndex
                    Me.htxtHTBZ.Value = .htxtHTBZ
                    Me.txtJCRQ.Text = .txtJCRQ
                    Me.txtHZRQ.Text = .txtHZRQ
                    Me.txtHZJE.Text = .txtHZJE
                    Me.chkHTHZ.Checked = .chkHTHZ_Checked
                    Me.chkHTJC.Checked = .chkHTJC_Checked
                    'zengxianglin 2010-12-28
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsHetongZlInfo

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftWYXX = Me.htxtDivLeftWYXX.Value
                    .htxtDivTopWYXX = Me.htxtDivTopWYXX.Value
                    .htxtDivLeftYWRY = Me.htxtDivLeftYWRY.Value
                    .htxtDivTopYWRY = Me.htxtDivTopYWRY.Value
                    .htxtDivLeftZLQX = Me.htxtDivLeftZLQX.Value
                    .htxtDivTopZLQX = Me.htxtDivTopZLQX.Value

                    .htxtSessionId_WYXX = Me.htxtSessionId_WYXX.Value
                    .grdWYXX_PageSize = Me.grdWYXX.PageSize
                    .grdWYXX_CurrentPageIndex = Me.grdWYXX.CurrentPageIndex
                    .grdWYXX_SelectedIndex = Me.grdWYXX.SelectedIndex

                    .htxtSessionId_YWRY = Me.htxtSessionId_YWRY.Value
                    .grdYWRY_PageSize = Me.grdYWRY.PageSize
                    .grdYWRY_CurrentPageIndex = Me.grdYWRY.CurrentPageIndex
                    .grdYWRY_SelectedIndex = Me.grdYWRY.SelectedIndex

                    .htxtSessionId_ZLQX = Me.htxtSessionId_ZLQX.Value
                    .grdZLQX_PageSize = Me.grdZLQX.PageSize
                    .grdZLQX_CurrentPageIndex = Me.grdZLQX.CurrentPageIndex
                    .grdZLQX_SelectedIndex = Me.grdZLQX.SelectedIndex

                    '****************************************************************
                    .ddlJFZJLB_SelectedIndex = Me.ddlJFZJLB.SelectedIndex
                    .ddlYFZJLB_SelectedIndex = Me.ddlYFZJLB.SelectedIndex
                    '****************************************************************
                    .rblZJTGYD_SelectedIndex = Me.rblZJTGYD.SelectedIndex
                    .rblFZFSYD_SelectedIndex = Me.rblFZFSYD.SelectedIndex
                    .rblSFZFYD_SelectedIndex = Me.rblSFZFYD.SelectedIndex
                    '****************************************************************
                    .htxtWYBS = Me.htxtWYBS.Value
                    .htxtQRSH = Me.htxtQRSH.Value
                    .htxtDGRQ = Me.htxtDGRQ.Value
                    .txtFWDZ = Me.txtFWDZ.Text
                    .txtJLRQ = Me.txtJLRQ.Text
                    .txtJYZZJ = Me.txtJYZZJ.Text
                    .txtJYYZJ = Me.txtJYYZJ.Text
                    .txtZLBZJ = Me.txtZLBZJ.Text
                    .txtJYZMJ = Me.txtJYZMJ.Text
                    .txtJFDLF = Me.txtJFDLF.Text
                    .txtYFDLF = Me.txtYFDLF.Text
                    .txtDLFZK = Me.txtDLFZK.Text
                    .txtZQYS = Me.txtZQYS.Text
                    .txtJZR = Me.txtJZR.Text
                    .txtZNJBL = Me.txtZNJBL.Text
                    .txtNDZBL = Me.txtNDZBL.Text
                    .txtJLZKSM = Me.txtJLZKSM.Text
                    '****************************************************************
                    .txtJFDLR = Me.txtJFDLR.Text
                    .txtJFLXDH = Me.txtJFLXDH.Text
                    .txtJFLXDZ = Me.txtJFLXDZ.Text
                    .txtJFMC = Me.txtJFMC.Text
                    .txtJFZZHM = Me.txtJFZZHM.Text
                    '****************************************************************
                    .txtYFDLR = Me.txtYFDLR.Text
                    .txtYFLXDH = Me.txtYFLXDH.Text
                    .txtYFLXDZ = Me.txtYFLXDZ.Text
                    .txtYFMC = Me.txtYFMC.Text
                    .txtYFZZHM = Me.txtYFZZHM.Text

                    '****************************************************************
                    .htxtHTWYBS = Me.htxtHTWYBS.Value
                    .htxtHTZT = Me.htxtHTZT.Value
                    .txtHTBH = Me.txtHTBH.Text
                    .txtHTRQ = Me.txtHTRQ.Text
                    'zengxianglin 2008-11-22
                    .txtTJRQ = Me.txtTJRQ.Text
                    'zengxianglin 2008-11-22
                    .txtBZXX = Me.txtBZXX.Text
                    '****************************************************************
                    .ddlFKFS_SelectedIndex = Me.ddlFKFS.SelectedIndex

                    '****************************************************************
                    .txtQX_JZR = Me.txtQX_JZR.Text
                    .txtQX_KSRQ = Me.txtQX_KSRQ.Text
                    .txtQX_YZJE = Me.txtQX_YZJE.Text
                    .txtQX_ZZRQ = Me.txtQX_ZZRQ.Text
                    .txtQX_YZZE = Me.txtQX_YZZE.Text
                    .txtQX_ZQYS = Me.txtQX_ZQYS.Text
                    '****************************************************************
                    .rblQX_JZFS_SelectedIndex = Me.rblQX_JZFS.SelectedIndex

                    'zengxianglin 2010-12-28
                    .txtKYBH = Me.txtKYBH.Text
                    .txtCCDZ = Me.txtCCDZ.Text
                    .txtCCF = Me.txtCCF.Text
                    .txtSSYJ = Me.txtSSYJ.Text
                    .txtHZYJ = Me.txtHZYJ.Text
                    .txtYZQN = Me.txtYZQN.Text
                    .txtYYQT = Me.txtYYQT.Text
                    .txtYZDY = Me.txtYZDY.Text
                    .txtMJQN = Me.txtMJQN.Text
                    .txtKYQT = Me.txtKYQT.Text
                    .txtKHDY = Me.txtKHDY.Text
                    .rblYZQC_SelectedIndex = Me.rblYZQC.SelectedIndex
                    .rblYZLY_SelectedIndex = Me.rblYZLY.SelectedIndex
                    .rblSYWY_SelectedIndex = Me.rblSYWY.SelectedIndex
                    .rblMJQC_SelectedIndex = Me.rblMJQC.SelectedIndex
                    .rblKHLY_SelectedIndex = Me.rblKHLY.SelectedIndex
                    .txtZLKS = Me.txtZLKS.Text
                    .txtZLJS = Me.txtZLJS.Text
                    .rblSDMQ_SelectedIndex = Me.rblSDMQ.SelectedIndex
                    .rblDHF_SelectedIndex = Me.rblDHF.SelectedIndex
                    .rblGLF_SelectedIndex = Me.rblGLF.SelectedIndex
                    .rblZLFP_SelectedIndex = Me.rblZLFP.SelectedIndex
                    .htxtHTBZ = Me.htxtHTBZ.Value
                    .txtJCRQ = Me.txtJCRQ.Text
                    .txtHZRQ = Me.txtHZRQ.Text
                    .txtHZJE = Me.txtHZJE.Text
                    .chkHTHZ_Checked = Me.chkHTHZ.Checked
                    .chkHTJC_Checked = Me.chkHTJC.Checked
                    'zengxianglin 2010-12-28
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

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objRYJGXX As System.Collections.Specialized.NameValueCollection = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsHetongWc As Josco.JSOA.BusinessFacade.IEstateEsHetongWc = Nothing
                Try
                    objIEstateEsHetongWc = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongWc)
                Catch ex As Exception
                    objIEstateEsHetongWc = Nothing
                End Try
                If Not (objIEstateEsHetongWc Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongWc.SafeRelease(objIEstateEsHetongWc)
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
                Dim objIEstateCwSztz As Josco.JSOA.BusinessFacade.IEstateCwSztz = Nothing
                Try
                    objIEstateCwSztz = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateCwSztz)
                Catch ex As Exception
                    objIEstateCwSztz = Nothing
                End Try
                If Not (objIEstateCwSztz Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateCwSztz.SafeRelease(objIEstateCwSztz)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsHetongBl As Josco.JSOA.BusinessFacade.IEstateEsHetongBl = Nothing
                Try
                    objIEstateEsHetongBl = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongBl)
                Catch ex As Exception
                    objIEstateEsHetongBl = Nothing
                End Try
                If Not (objIEstateEsHetongBl Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongBl.SafeRelease(objIEstateEsHetongBl)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsHetongSh As Josco.JSOA.BusinessFacade.IEstateEsHetongSh = Nothing
                Try
                    objIEstateEsHetongSh = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongSh)
                Catch ex As Exception
                    objIEstateEsHetongSh = Nothing
                End Try
                If Not (objIEstateEsHetongSh Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongSh.SafeRelease(objIEstateEsHetongSh)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsHetongFpbl As Josco.JSOA.BusinessFacade.IEstateEsHetongFpbl = Nothing
                Try
                    objIEstateEsHetongFpbl = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongFpbl)
                Catch ex As Exception
                    objIEstateEsHetongFpbl = Nothing
                End Try
                If Not (objIEstateEsHetongFpbl Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongFpbl.SafeRelease(objIEstateEsHetongFpbl)
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
                Dim objIEstateCwYsyf As Josco.JSOA.BusinessFacade.IEstateCwYsyf = Nothing
                Try
                    objIEstateCwYsyf = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateCwYsyf)
                Catch ex As Exception
                    objIEstateCwYsyf = Nothing
                End Try
                If Not (objIEstateCwYsyf Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateCwYsyf.SafeRelease(objIEstateCwYsyf)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsQrsZlWuye As Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye = Nothing
                Try
                    objIEstateEsQrsZlWuye = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye)
                Catch ex As Exception
                    objIEstateEsQrsZlWuye = Nothing
                End Try
                If Not (objIEstateEsQrsZlWuye Is Nothing) Then
                    If objIEstateEsQrsZlWuye.oExitMode = True Then
                        Select Case objIEstateEsQrsZlWuye.iSourceControlId.ToUpper()
                            Case "btnAddNew_WYXX".ToUpper(), "btnUpdate_WYXX".ToUpper()
                                Dim strFWDZ As String = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ)
                                Try
                                    Me.m_objDataSet_WYXX = CType(Session(Me.htxtSessionId_WYXX.Value), Josco.JSOA.Common.Data.estateErshouData)
                                Catch ex As Exception
                                    Me.m_objDataSet_WYXX = Nothing
                                End Try
                                If Not (Me.m_objDataSet_WYXX Is Nothing) Then
                                    Dim strOldFilter As String = ""
                                    Dim strNewFilter As String = ""
                                    With Me.m_objDataSet_WYXX.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_ZL)
                                        Dim objDataRow As System.Data.DataRow = Nothing
                                        Select Case objIEstateEsQrsZlWuye.iMode
                                            Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                                Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                                '�Ƿ����?
                                                strOldFilter = .DefaultView.RowFilter
                                                '����filter
                                                strNewFilter = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ + " = '" + strFWDZ + "'"
                                                .DefaultView.RowFilter = strNewFilter
                                                If .DefaultView.Count < 1 Then
                                                    '�����ڣ�
                                                    objDataRow = .NewRow()
                                                    .Rows.Add(objDataRow)
                                                End If
                                                '��ԭfilter
                                                .DefaultView.RowFilter = strOldFilter
                                            Case Else
                                                Dim intPos As Integer = -1
                                                intPos = objDataGridProcess.getRecordPosition(objIEstateEsQrsZlWuye.iRowNo, Me.grdWYXX.CurrentPageIndex, Me.grdWYXX.PageSize)
                                                objDataRow = .DefaultView.Item(intPos).Row
                                        End Select
                                        If Not (objDataRow Is Nothing) Then
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBS) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBS)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBM) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBM)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_QRSH) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_QRSH)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZH) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZH)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZDZ) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZDZ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_MJ) = objPulicParameters.getObjectValue(objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_MJ), 0.0)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YZJ) = objPulicParameters.getObjectValue(objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YZJ), 0.0)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZX) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LC) = objPulicParameters.getObjectValue(objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LC), 0)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LL) = objPulicParameters.getObjectValue(objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LL), 0)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JG) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JG)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGMC) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGMC)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZ) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZMC) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZMC)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQY) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQY)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQYMC) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQYMC)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_BZXX) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_BZXX)
                                            'zengxianglin 2010-12-26
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FYBH) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FYBH)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LP) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LP)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LD) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LD)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DY) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DY)
                                            If objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ) = "" Then
                                                objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ) = System.DBNull.Value
                                            Else
                                                objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ)
                                            End If
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_KJLX) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_KJLX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWXZ) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWXZ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXDC) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXDC)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXNX) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXNX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZYYX) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZYYX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JJSB) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JJSB)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LYJT) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LYJT)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWJG) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWJG)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGLX) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGLX)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGFS) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGFS)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LG) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LG)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WSSL) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WSSL)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YTSL) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YTSL)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_HYMJ) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_HYMJ)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DTSL) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DTSL)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LCHS) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LCHS)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LPQS) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LPQS)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXX) = objIEstateEsQrsZlWuye.oValues(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXX)
                                            'zengxianglin 2010-12-26

                                            '���¼����������
                                            Dim dblMJ As Double = 0
                                            Dim dblJE As Double = 0
                                            If Me.getQRSInfoWyxxRela(strErrMsg, Me.m_objDataSet_WYXX, strFWDZ, dblMJ, dblJE) = True Then
                                                Me.txtFWDZ.Text = strFWDZ
                                                Me.txtJYZMJ.Text = dblMJ.ToString("#,###.00")
                                                Me.txtJYYZJ.Text = dblJE.ToString("#,###.00")
                                                'zengxianglin 2008-11-25
                                                'If Me.doComputeDLF(strErrMsg) = False Then
                                                '    '����
                                                'End If
                                                'zengxianglin 2008-11-25
                                            End If
                                        End If
                                    End With
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye.SafeRelease(objIEstateEsQrsZlWuye)
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
                            Case "btnAddNew_YWRY".ToUpper()
                                Dim strRYDM As String = objIDmxzRyxx.oRYDM
                                Dim strRYMC As String = objIDmxzRyxx.oRYZM
                                Dim strZZDM As String = objIDmxzRyxx.oZZDM
                                Dim strZZMC As String = objIDmxzRyxx.oZZMC
                                Dim intTDBH As Integer = 0
                                Dim strZJDM As String = ""
                                Dim strZJMC As String = ""
                                'zengxianglin 2008-10-14
                                Dim strSSFZ As String = ""
                                If objsystemEstateErshou.getRYJGXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strRYDM, Me.txtHTRQ.Text, objRYJGXX) = True Then
                                    If Not (objRYJGXX Is Nothing) Then
                                        strZZDM = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM), "")
                                        strZZMC = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC), "")
                                        strZJDM = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ), "")
                                        strZJMC = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC), "")
                                        strSSFZ = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ), "")
                                        'zengxianglin 2010-01-13
                                        intTDBH = objPulicParameters.getObjectValue(objRYJGXX(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH), 0)
                                        'zengxianglin 2010-01-13
                                    End If
                                End If
                                'zengxianglin 2008-10-14
                                Try
                                    Me.m_objDataSet_YWRY = CType(Session(Me.htxtSessionId_YWRY.Value), Josco.JSOA.Common.Data.estateErshouData)
                                Catch ex As Exception
                                    Me.m_objDataSet_YWRY = Nothing
                                End Try
                                If Not (Me.m_objDataSet_YWRY Is Nothing) Then
                                    Dim strOldFilter As String = ""
                                    Dim strNewFilter As String = ""
                                    Dim blnDo As Boolean = False
                                    With Me.m_objDataSet_YWRY.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL)
                                        '�Ƿ����?
                                        strOldFilter = .DefaultView.RowFilter
                                        '����filter
                                        strNewFilter = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM + " = '" + strRYDM + "'"
                                        .DefaultView.RowFilter = strNewFilter
                                        If .DefaultView.Count < 1 Then
                                            Dim objDataRow As System.Data.DataRow = Nothing
                                            '�����ڣ�
                                            objDataRow = .NewRow()
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYDM) = strRYDM
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYMC) = strRYMC
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWDM) = strZZDM
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_DWMC) = strZZMC
                                            'zengxianglin 2008-10-14
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_SSFZ) = strSSFZ
                                            'zengxianglin 2008-10-14
                                            'zengxianglin 2010-01-13
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_TDBH) = intTDBH
                                            'zengxianglin 2010-01-13
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL) = 1.0
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJ) = strZJDM
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_RYZJMC) = strZJMC
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZ) = 1
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZMC) = Josco.JSOA.Common.Data.estateErshouData.getYejiStatusName(1)
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJ) = -1
                                            objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZGBJMC) = Josco.JSOA.Common.Data.estateErshouData.getZhiguanStatusName(-1)
                                            .Rows.Add(objDataRow)
                                            blnDo = True
                                        End If
                                        '��ԭfilter
                                        .DefaultView.RowFilter = strOldFilter
                                    End With
                                    '�����������
                                    If blnDo = True Then
                                        If Me.doComputeFPBL(strErrMsg) = False Then
                                            '����
                                        End If
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

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objRYJGXX)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objRYJGXX)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    'û���нӿڲ���
                    Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    Me.m_strQRSH = ""
                Else
                    Me.m_blnInterface = True
                    '�нӿڲ���
                    Me.m_objenumEditType = Me.m_objInterface.iMode
                    Me.m_strQRSH = Me.m_objInterface.iQRSH
                End If
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Me.m_blnEditMode = True
                    Case Else
                        Me.m_blnEditMode = False
                End Select
                If Me.m_strQRSH = "" Then
                    blnContinue = False
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = "����û���ṩ��ģ�����Ľӿڣ�"
                    Exit Try
                End If

                '��ȡ�ָ��ֳ�����
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsHetongZlInfo)
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
                Me.m_intFixedColumns_grdWYXX = objPulicParameters.getObjectValue(Me.htxtWYXXFixed.Value, 0)
                Me.m_intFixedColumns_grdYWRY = objPulicParameters.getObjectValue(Me.htxtYWRYFixed.Value, 0)
                Me.m_intFixedColumns_grdZLQX = objPulicParameters.getObjectValue(Me.htxtZLQXFixed.Value, 0)
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

            Dim strErrMsg As String = ""

            Try
                Dim objDataSet As Josco.JSOA.Common.Data.estateErshouData = Nothing
                If Me.htxtSessionId_WYXX.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_WYXX.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_WYXX.Value)
                    Me.htxtSessionId_WYXX.Value = ""
                End If
                If Me.htxtSessionId_YWRY.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_YWRY.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_YWRY.Value)
                    Me.htxtSessionId_YWRY.Value = ""
                End If
                If Me.htxtSessionId_ZLQX.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_ZLQX.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_ZLQX.Value)
                    Me.htxtSessionId_ZLQX.Value = ""
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub













        '----------------------------------------------------------------
        ' ���¼�����˵ķ������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doComputeFPBL(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doComputeFPBL = False
            strErrMsg = ""

            Try
                Dim intCount As Integer = 0
                Dim dblFPBL As Double = 0
                Dim dblLeft As Double = 1
                Dim i As Integer = 0
                With Me.m_objDataSet_YWRY.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL)
                    dblFPBL = CType((1.0 / .Rows.Count).ToString("#.00"), Double)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        If i = intCount - 1 Then
                            .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL) = dblLeft
                        Else
                            .Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_FPBL) = dblFPBL
                        End If
                        dblLeft = dblLeft - dblFPBL
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doComputeFPBL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���ݵ�ǰ���׶˰�ѷ�ʽ������ԵĴ����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doComputeDLF(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim dblJE As Double = 0.0

            doComputeDLF = False
            strErrMsg = ""

            Try
                dblJE = objPulicParameters.getObjectValue(Me.txtJYYZJ.Text, 0.0)
                Me.txtZLBZJ.Text = (dblJE * 2.0).ToString("#,###.00")
                Select Case Me.rblSFZFYD.SelectedIndex
                    Case 0
                        Me.txtJFDLF.Text = (dblJE * 1.0).ToString("#,###.00")
                        Me.txtYFDLF.Text = (dblJE * 0.0).ToString("#,###.00")
                    Case 1
                        Me.txtJFDLF.Text = (dblJE * 1.0).ToString("#,###.00")
                        Me.txtYFDLF.Text = (dblJE * 0.0).ToString("#,###.00")
                    Case 2
                        Me.txtJFDLF.Text = (dblJE * 0.0).ToString("#,###.00")
                        Me.txtYFDLF.Text = (dblJE * 1.0).ToString("#,###.00")
                End Select
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doComputeDLF = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �����������ݻ�ȡȷ�����������
        '     strErrMsg      �����ش�����Ϣ
        '     objData        �����������
        '     dblZZJ         �������
        '     dblZZQ         ��������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQRSInfoZlqxRela( _
            ByRef strErrMsg As String, _
            ByVal objData As Josco.JSOA.Common.Data.estateErshouData, _
            ByRef dblZZJ As Double, _
            ByRef dblZZQ As Double) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_ZULINQIXIAN
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQRSInfoZlqxRela = False
            strErrMsg = ""
            dblZZJ = 0
            dblZZQ = 0

            Try
                '���
                If objData Is Nothing Then
                    Exit Try
                End If
                If objData.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If objData.Tables(strTable).Rows.Count < 1 Then
                    Exit Try
                End If

                '����
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        dblZZJ += objPulicParameters.getObjectValue(.Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_YZZE), 0.0)
                        dblZZQ += objPulicParameters.getObjectValue(.Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZQYS), 0.0)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQRSInfoZlqxRela = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������ҵ���ݻ�ȡȷ�����������
        '     strErrMsg      �����ش�����Ϣ
        '     objData        �����������
        '     strFWDZ        ���ϳɵķ��ݵ�ַ
        '     dblMJ          �������
        '     dblJE          ���ܽ��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQRSInfoWyxxRela( _
            ByRef strErrMsg As String, _
            ByVal objData As Josco.JSOA.Common.Data.estateErshouData, _
            ByRef strFWDZ As String, _
            ByRef dblMJ As Double, _
            ByRef dblJE As Double) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_ZL
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQRSInfoWyxxRela = False
            strErrMsg = ""
            strFWDZ = ""
            dblMJ = 0
            dblJE = 0

            Try
                '���
                If objData Is Nothing Then
                    Exit Try
                End If
                If objData.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If objData.Tables(strTable).Rows.Count < 1 Then
                    Exit Try
                End If

                '����
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                With objData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        If strFWDZ = "" Then
                            strFWDZ = objPulicParameters.getObjectValue(.Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ), "")
                        Else
                            strFWDZ = strFWDZ + strSep + objPulicParameters.getObjectValue(.Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ), "")
                        End If

                        dblMJ += objPulicParameters.getObjectValue(.Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_MJ), 0.0)

                        dblJE += objPulicParameters.getObjectValue(.Rows(i)(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YZJ), 0.0)
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQRSInfoWyxxRela = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡҪ��ʾ����������Ϣ(ȷ���鲿��)
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_MAINQRS( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_ZL
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_MAINQRS = False

            Try
                '���
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_MAINQRS)

                '���¼�������
                If objsystemEstateErshou.getDataSet_ES_QRS_ZL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, "", Me.m_objDataSet_MAINQRS) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_MAINQRS = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡҪ��ʾ����������Ϣ(��ͬ����)
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_MAINHT( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_MAINHT = False

            Try
                '���
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_MAINHT)

                '���¼�������
                If objsystemEstateErshou.getDataSet_ES_HETONG(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, "", Me.m_objDataSet_MAINHT) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_MAINHT = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdWYXXҪ��ʾ������
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     strWhere       �������ַ���
        '     blnEditMode    ��True-�༭ False-�鿴
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_WYXX( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_ZL
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_WYXX = False

            Try
                '���
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim

                '��ȡ����
                If blnEditMode = True Then
                    If Me.htxtSessionId_WYXX.Value.Trim <> "" Then
                        '�ӻ����л�ȡ����
                        Me.m_objDataSet_WYXX = CType(Session.Item(Me.htxtSessionId_WYXX.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Else
                        '�ͷ���Դ
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_WYXX)
                        '���¼�������
                        If objsystemEstateErshou.getDataSet_ES_WUYE_ZL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_WYXX) = False Then
                            GoTo errProc
                        End If
                        '��������
                        Me.htxtSessionId_WYXX.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtSessionId_WYXX.Value, Me.m_objDataSet_WYXX)
                    End If
                Else
                    '�ͷŻ�������
                    If Me.htxtSessionId_WYXX.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_WYXX = CType(Session.Item(Me.htxtSessionId_WYXX.Value), Josco.JSOA.Common.Data.estateErshouData)
                        Catch ex As Exception
                            Me.m_objDataSet_WYXX = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_WYXX)
                        Session.Remove(Me.htxtSessionId_WYXX.Value)
                        Me.htxtSessionId_WYXX.Value = ""
                    End If
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_WYXX)
                    '���¼�������
                    If objsystemEstateErshou.getDataSet_ES_WUYE_ZL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_WYXX) = False Then
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

            getModuleData_WYXX = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdYWRYҪ��ʾ������
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     strWhere       �������ַ���
        '     blnEditMode    ��True-�༭ False-�鿴
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_YWRY( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_YWRY = False

            Try
                '���
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim
                Dim strQuery As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FPBL_ZTBZ + " & 1 = 1"
                If strWhere = "" Then
                    strWhere = strQuery
                Else
                    strWhere = strWhere + " and " + strQuery
                End If

                '��ȡ����
                If blnEditMode = True Then
                    If Me.htxtSessionId_YWRY.Value.Trim <> "" Then
                        '�ӻ����л�ȡ����
                        Me.m_objDataSet_YWRY = CType(Session.Item(Me.htxtSessionId_YWRY.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Else
                        '�ͷ���Դ
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_YWRY)
                        '���¼�������
                        If objsystemEstateErshou.getDataSet_ES_HETONG_FPBL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_YWRY) = False Then
                            GoTo errProc
                        End If
                        '��������
                        Me.htxtSessionId_YWRY.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtSessionId_YWRY.Value, Me.m_objDataSet_YWRY)
                    End If
                Else
                    '�ͷŻ�������
                    If Me.htxtSessionId_YWRY.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_YWRY = CType(Session.Item(Me.htxtSessionId_YWRY.Value), Josco.JSOA.Common.Data.estateErshouData)
                        Catch ex As Exception
                            Me.m_objDataSet_YWRY = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_YWRY)
                        Session.Remove(Me.htxtSessionId_YWRY.Value)
                        Me.htxtSessionId_YWRY.Value = ""
                    End If
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_YWRY)
                    '���¼�������
                    If objsystemEstateErshou.getDataSet_ES_HETONG_FPBL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_YWRY) = False Then
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

            getModuleData_YWRY = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdZLQXҪ��ʾ������
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     strWhere       �������ַ���
        '     blnEditMode    ��True-�༭ False-�鿴
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_ZLQX( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_ZULINQIXIAN
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getModuleData_ZLQX = False

            Try
                '���
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim

                '��ȡ����
                If blnEditMode = True Then
                    If Me.htxtSessionId_ZLQX.Value.Trim <> "" Then
                        '�ӻ����л�ȡ����
                        Me.m_objDataSet_ZLQX = CType(Session.Item(Me.htxtSessionId_ZLQX.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Else
                        '�ͷ���Դ
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_ZLQX)
                        '���¼�������
                        If objsystemEstateErshou.getDataSet_ES_ZulinQixian(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_ZLQX) = False Then
                            GoTo errProc
                        End If
                        '��������
                        Me.htxtSessionId_ZLQX.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtSessionId_ZLQX.Value, Me.m_objDataSet_ZLQX)
                    End If
                Else
                    '�ͷŻ�������
                    If Me.htxtSessionId_ZLQX.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_ZLQX = CType(Session.Item(Me.htxtSessionId_ZLQX.Value), Josco.JSOA.Common.Data.estateErshouData)
                        Catch ex As Exception
                            Me.m_objDataSet_ZLQX = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_ZLQX)
                        Session.Remove(Me.htxtSessionId_ZLQX.Value)
                        Me.htxtSessionId_ZLQX.Value = ""
                    End If
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_ZLQX)
                    '���¼�������
                    If objsystemEstateErshou.getDataSet_ES_ZulinQixian(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_ZLQX) = False Then
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

            getModuleData_ZLQX = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function











        '----------------------------------------------------------------
        ' ��ʾgrdWYXX������
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_WYXX( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_ZL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_WYXX = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_WYXX Is Nothing Then
                    Me.grdWYXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_WYXX.Tables(strTable)
                        Me.grdWYXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_WYXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdWYXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdWYXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdWYXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdWYXX) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_WYXX = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdYWRY������
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_YWRY( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_YWRY = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_YWRY Is Nothing Then
                    Me.grdYWRY.DataSource = Nothing
                Else
                    With Me.m_objDataSet_YWRY.Tables(strTable)
                        Me.grdYWRY.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_YWRY.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdYWRY, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdYWRY.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdYWRY, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdYWRY) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_YWRY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdZLQX������
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_ZLQX( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_ZULINQIXIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_ZLQX = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_ZLQX Is Nothing Then
                    Me.grdZLQX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_ZLQX.Tables(strTable)
                        Me.grdZLQX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_ZLQX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdZLQX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdZLQX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdZLQX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdZLQX) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_ZLQX = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾģ������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        '     blnEnforced    ��ǿ��������ʾ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-25 ���ӽӿ�[blnEnforced]
        '----------------------------------------------------------------
        Private Function showEditPanel_MAIN( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean, _
            Optional ByVal blnEnforced As Boolean = False) As Boolean

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim strTable As String = ""

            showEditPanel_MAIN = False
            strErrMsg = ""

            Try
                '��ʾֵ
                Dim strValue As String = ""
                Dim intValue As Integer = 0

                'zengxianglin 2008-11-25
                'If (Me.IsPostBack = False And Me.m_blnSaveScence = False) Then
                If (Me.IsPostBack = False And Me.m_blnSaveScence = False) Or blnEnforced = True Then
                    'zengxianglin 2008-11-25

                    strTable = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_ZL
                    With Me.m_objDataSet_MAINQRS.Tables(strTable)
                        If .Rows.Count < 1 Then
                            '���ÿ�ֵ
                            Me.ddlJFZJLB.SelectedIndex = -1
                            Me.ddlYFZJLB.SelectedIndex = -1
                            '*****************************************************************************************************************
                            Me.rblZJTGYD.SelectedIndex = -1
                            Me.rblFZFSYD.SelectedIndex = -1
                            Me.rblSFZFYD.SelectedIndex = -1
                            '*****************************************************************************************************************
                            Me.htxtWYBS.Value = ""
                            Me.htxtQRSH.Value = ""
                            Me.htxtDGRQ.Value = ""
                            Me.txtFWDZ.Text = ""
                            Me.txtJLRQ.Text = ""
                            Me.txtJYZMJ.Text = ""
                            Me.txtJYZZJ.Text = ""
                            Me.txtJYYZJ.Text = ""
                            Me.txtZLBZJ.Text = ""
                            Me.txtJFDLF.Text = ""
                            Me.txtYFDLF.Text = ""
                            Me.txtDLFZK.Text = ""
                            Me.txtZQYS.Text = ""
                            Me.txtJZR.Text = ""
                            Me.txtZNJBL.Text = ""
                            Me.txtNDZBL.Text = ""
                            Me.txtJLZKSM.Text = ""
                            Me.txtBZXX.Text = ""
                            '*****************************************************************************************************************
                            Me.txtJFDLR.Text = ""
                            Me.txtJFLXDH.Text = ""
                            Me.txtJFLXDZ.Text = ""
                            Me.txtJFMC.Text = ""
                            Me.txtJFZZHM.Text = ""
                            '*****************************************************************************************************************
                            Me.txtYFDLR.Text = ""
                            Me.txtYFLXDH.Text = ""
                            Me.txtYFLXDZ.Text = ""
                            Me.txtYFMC.Text = ""
                            Me.txtYFZZHM.Text = ""
                            'zengxianglin 2010-12-28
                            Me.txtKYBH.Text = ""
                            Me.txtCCDZ.Text = ""
                            Me.txtCCF.Text = ""
                            Me.txtSSYJ.Text = ""
                            Me.txtHZYJ.Text = ""
                            Me.txtYZQN.Text = ""
                            Me.txtYYQT.Text = ""
                            Me.txtYZDY.Text = ""
                            Me.txtMJQN.Text = ""
                            Me.txtKYQT.Text = ""
                            Me.txtKHDY.Text = ""
                            Me.rblYZQC.SelectedIndex = -1
                            Me.rblYZLY.SelectedIndex = -1
                            Me.rblSYWY.SelectedIndex = -1
                            Me.rblMJQC.SelectedIndex = -1
                            Me.rblKHLY.SelectedIndex = -1
                            Me.txtZLKS.Text = ""
                            Me.txtZLJS.Text = ""
                            Me.rblSDMQ.SelectedIndex = -1
                            Me.rblDHF.SelectedIndex = -1
                            Me.rblGLF.SelectedIndex = -1
                            Me.rblZLFP.SelectedIndex = -1
                            'zengxianglin 2010-12-28
                        Else
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFZJLX), "")
                            Me.ddlJFZJLB.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlJFZJLB, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFZJLX), "")
                            Me.ddlYFZJLB.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlYFZJLB, strValue)
                            '*****************************************************************************************************************
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZJTGYD), "")
                            Me.rblZJTGYD.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblZJTGYD, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SFZFYD), "")
                            Me.rblSFZFYD.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFZFYD, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_FZFSYD), "")
                            Me.rblFZFSYD.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblFZFSYD, strValue)
                            '*****************************************************************************************************************
                            Me.htxtWYBS.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_WYBS), "")
                            Me.htxtQRSH.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_QRSH), "")
                            Me.htxtDGRQ.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DGRQ), "", "yyyy-MM-dd")
                            '*****************************************************************************************************************
                            Me.txtFWDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_FWDZ), "")
                            Me.txtJFDLF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFDLF), 0.0).ToString("#,###.00")
                            Me.txtYFDLF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFDLF), 0.0).ToString("#,###.00")
                            Me.txtDLFZK.Text = (objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DLFZK), 0.0) * 100).ToString("#.00")
                            Me.txtJYZZJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JYZZJ), 0.0).ToString("#,###.00")
                            Me.txtJYYZJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JYYZJ), 0.0).ToString("#,###.00")
                            Me.txtZLBZJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLBZJ), 0.0).ToString("#,###.00")
                            Me.txtJYZMJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JYZMJ), 0.0).ToString("#,###.00")
                            Me.txtJLRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JHJLRQ), "", "yyyy-MM-dd")
                            Me.txtZQYS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZQYS), "")
                            Me.txtJZR.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JZR), "")
                            Me.txtZNJBL.Text = (objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZNJBL), 0.0) * 100).ToString("#.00")
                            Me.txtNDZBL.Text = (objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_NDZBL), 0.0) * 100).ToString("#.00")
                            Me.txtJLZKSM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JLZKSM), "")
                            Me.txtBZXX.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_BZXX), "")
                            '*****************************************************************************************************************
                            Me.txtJFDLR.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFDLR), "")
                            Me.txtJFLXDH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFLXDH), "")
                            Me.txtJFLXDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFLXDZ), "")
                            Me.txtJFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFMC), "")
                            Me.txtJFZZHM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFZZHM), "")
                            '*****************************************************************************************************************
                            Me.txtYFDLR.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFDLR), "")
                            Me.txtYFLXDH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFLXDH), "")
                            Me.txtYFLXDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFLXDZ), "")
                            Me.txtYFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFMC), "")
                            Me.txtYFZZHM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFZZHM), "")
                            'zengxianglin 2010-12-28
                            Me.txtKYBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KYBH), "")
                            Me.txtCCDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_CCDZ), "")
                            Me.txtCCF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_CCF), 0.0).ToString("#,##0.00")
                            Me.txtSSYJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SSYJ), 0.0).ToString("#,##0.00")
                            Me.txtHZYJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_HZYJ), 0.0).ToString("#,##0.00")
                            Me.txtYZQN.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZQN), "")
                            Me.txtYYQT.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YYQT), "")
                            Me.txtYZDY.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZDY), "")
                            Me.txtMJQN.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_MJQN), "")
                            Me.txtKYQT.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KYQT), "")
                            Me.txtKHDY.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KHDY), "")
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZQC), "")
                            Me.rblYZQC.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblYZQC, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZLY), "")
                            Me.rblYZLY.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblYZLY, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SYWY), "")
                            Me.rblSYWY.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSYWY, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_MJQC), "")
                            Me.rblMJQC.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblMJQC, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KHLY), "")
                            Me.rblKHLY.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblKHLY, strValue)

                            Me.txtZLKS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLKS), "", "yyyy-MM-dd")
                            Me.txtZLJS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLJS), "", "yyyy-MM-dd")
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SDMQ), "")
                            Me.rblSDMQ.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSDMQ, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DHF), "")
                            Me.rblDHF.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblDHF, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_GLF), "")
                            Me.rblGLF.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblGLF, strValue)
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLFP), "")
                            Me.rblZLFP.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblZLFP, strValue)
                            'zengxianglin 2010-12-28
                        End If
                    End With

                    '����ͬ��Ϣ
                    strTable = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG
                    With Me.m_objDataSet_MAINHT.Tables(strTable)
                        If .Rows.Count < 1 Then
                            Me.htxtHTWYBS.Value = ""
                            Me.htxtHTZT.Value = ""
                            Me.txtHTBH.Text = ""
                            Me.txtHTRQ.Text = ""
                            'zengxianglin 2008-11-22
                            Me.txtTJRQ.Text = ""
                            'zengxianglin 2008-11-22
                            'zengxianglin 2008-11-25
                            Me.txtAJFH.Text = ""
                            'zengxianglin 2008-11-25
                            Me.ddlFKFS.SelectedIndex = -1
                            'zengxianglin 2010-12-28
                            Me.htxtHTBZ.Value = ""
                            Me.txtJCRQ.Text = ""
                            Me.txtHZRQ.Text = ""
                            Me.txtHZJE.Text = ""
                            Me.chkHTHZ.Checked = False
                            Me.chkHTJC.Checked = False
                            'zengxianglin 2010-12-28
                        Else
                            Me.htxtHTWYBS.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_WYBS), "")
                            Me.htxtHTZT.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTZT), "")
                            Me.txtHTBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBH), "")
                            Me.txtHTRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTRQ), "", "yyyy-MM-dd")
                            'zengxianglin 2008-11-22
                            Me.txtTJRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_TJRQ), "", "yyyy-MM-dd")
                            'zengxianglin 2008-11-22
                            'zengxianglin 2008-11-25
                            Me.txtAJFH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_AJFH), "", "#,##0.00", True)
                            'zengxianglin 2008-11-25
                            Me.txtBZXX.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BZXX), "")
                            strValue = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FKFS), "")
                            Me.ddlFKFS.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlFKFS, strValue)
                            'zengxianglin 2010-12-28
                            Me.htxtHTBZ.Value = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBZ), "")
                            Me.txtJCRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JCRQ), "", "yyyy-MM-dd")
                            Me.txtHZRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HZRQ), "", "yyyy-MM-dd")
                            Me.txtHZJE.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HZJE), "", "#,##0.00", True)
                            intValue = objPulicParameters.getObjectValue(Me.htxtHTBZ.Value, 0)
                            If (intValue And &H1) = &H1 Then Me.chkHTJC.Checked = True
                            If (intValue And &H2) = &H2 Then Me.chkHTHZ.Checked = True
                            'zengxianglin 2010-12-28
                        End If
                    End With

                    'zengxianglin 2008-11-25
                    Select Case Me.m_objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '���ó�ʼֵ
                            If objsystemEstateErshou.getNewHTBH_ZL(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtHTBH.Text) = False Then
                                GoTo errProc
                            End If
                            Me.txtTJRQ.Text = Now.ToString("yyyy-MM-dd")
                            'zengxianglin 2010-12-28
                            'Me.txtJFDLF.Text = ""
                            'Me.txtYFDLF.Text = ""
                            'zengxianglin 2010-12-28
                    End Select
                    'zengxianglin 2008-11-25
                End If

                '��������
                '*****************************************************************************************************************
                objControlProcess.doEnabledControl(Me.ddlJFZJLB, blnEditMode)
                objControlProcess.doEnabledControl(Me.ddlYFZJLB, blnEditMode)
                '*****************************************************************************************************************
                objControlProcess.doEnabledControl(Me.rblZJTGYD, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblFZFSYD, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSFZFYD, blnEditMode)
                '*****************************************************************************************************************
                objControlProcess.doEnabledControl(Me.txtFWDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJYZZJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJYYZJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZLBZJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFDLF, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFDLF, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtDLFZK, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJYZMJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZQYS, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJZR, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZNJBL, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtNDZBL, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJLRQ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJLZKSM, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtBZXX, blnEditMode)
                '*****************************************************************************************************************
                objControlProcess.doEnabledControl(Me.txtJFDLR, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFLXDH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFLXDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFMC, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJFZZHM, blnEditMode)
                '*****************************************************************************************************************
                objControlProcess.doEnabledControl(Me.txtYFDLR, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFLXDH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFLXDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFMC, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYFZZHM, blnEditMode)
                '*****************************************************************************************************************
                'zengxianglin 2008-11-27
                objControlProcess.doEnabledControl(Me.txtHTBH, False)
                'zengxianglin 2008-11-27
                objControlProcess.doEnabledControl(Me.txtHTRQ, blnEditMode)
                'zengxianglin 2008-11-22
                objControlProcess.doEnabledControl(Me.txtTJRQ, False)
                'zengxianglin 2008-11-22
                'zengxianglin 2008-11-25
                objControlProcess.doEnabledControl(Me.txtAJFH, False)
                'zengxianglin 2008-11-25
                objControlProcess.doEnabledControl(Me.ddlFKFS, blnEditMode)
                '*****************************************************************************************************************
                'zengxianglin 2010-12-28
                objControlProcess.doEnabledControl(Me.txtKYBH, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtCCDZ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtCCF, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtSSYJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtHZYJ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYZQN, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYYQT, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtYZDY, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtMJQN, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtKYQT, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtKHDY, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblYZQC, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblYZLY, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSYWY, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblMJQC, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblKHLY, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZLKS, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtZLJS, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblSDMQ, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblDHF, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblGLF, blnEditMode)
                objControlProcess.doEnabledControl(Me.rblZLFP, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtJCRQ, False)
                objControlProcess.doEnabledControl(Me.txtHZRQ, False)
                objControlProcess.doEnabledControl(Me.txtHZJE, False)
                objControlProcess.doEnabledControl(Me.chkHTJC, False)
                objControlProcess.doEnabledControl(Me.chkHTHZ, False)
                'zengxianglin 2010-12-28
                Me.btnAddNew_WYXX.Visible = blnEditMode
                Me.btnUpdate_WYXX.Visible = blnEditMode
                Me.btnDelete_WYXX.Visible = blnEditMode
                Me.btnAddNew_YWRY.Visible = blnEditMode
                Me.btnDelete_YWRY.Visible = blnEditMode
                Me.btnAddNew_ZLQX.Visible = blnEditMode
                Me.btnUpdate_ZLQX.Visible = blnEditMode
                Me.btnDelete_ZLQX.Visible = blnEditMode
                Me.btnCompute_ZLQX.Visible = blnEditMode
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanel_MAIN = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '============֣���޸�0623================
        '----------------------------------------------------------------
        ' ��ʾgrdZLQX��صı༭������(��������ǰ��������ʾ)
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     blnEditMode    ����ǰ�༭״̬
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showEditPanelInfo_ZLQX( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim strValue As String = ""

            showEditPanelInfo_ZLQX = False

            Try

                '�鿴״̬
                If Me.grdZLQX.Items.Count < 1 Or Me.grdZLQX.SelectedIndex < 0 Then
                    Me.rblQX_JZFS.SelectedIndex = -1
                    Me.txtQX_KSRQ.Text = ""
                    Me.txtQX_ZZRQ.Text = ""
                    Me.txtQX_YZJE.Text = ""
                    Me.txtQX_JZR.Text = ""
                    Me.txtQX_YZZE.Text = ""
                    Me.txtQX_ZQYS.Text = ""
                Else
                    Dim intColIndex As Integer = -1

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdZLQX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_JZFS)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdZLQX.Items(Me.grdZLQX.SelectedIndex), intColIndex)
                    Me.rblQX_JZFS.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblQX_JZFS, strValue)

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdZLQX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_KSRQ)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdZLQX.Items(Me.grdZLQX.SelectedIndex), intColIndex)
                    Me.txtQX_KSRQ.Text = objPulicParameters.getObjectValue(strValue, "", "yyyy-MM-dd")

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdZLQX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZZRQ)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdZLQX.Items(Me.grdZLQX.SelectedIndex), intColIndex)
                    Me.txtQX_ZZRQ.Text = objPulicParameters.getObjectValue(strValue, "", "yyyy-MM-dd")

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdZLQX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_YZJE)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdZLQX.Items(Me.grdZLQX.SelectedIndex), intColIndex)
                    Me.txtQX_YZJE.Text = strValue

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdZLQX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_JZR)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdZLQX.Items(Me.grdZLQX.SelectedIndex), intColIndex)
                    Me.txtQX_JZR.Text = strValue

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdZLQX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_YZZE)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdZLQX.Items(Me.grdZLQX.SelectedIndex), intColIndex)
                    Me.txtQX_YZZE.Text = strValue

                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdZLQX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZQYS)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdZLQX.Items(Me.grdZLQX.SelectedIndex), intColIndex)
                    Me.txtQX_ZQYS.Text = strValue
                End If

                'ʹ�ܿؼ�
                objControlProcess.doEnabledControl(Me.txtQX_KSRQ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtQX_ZZRQ, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtQX_YZJE, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtQX_JZR, blnEditMode)
                objControlProcess.doEnabledControl(Me.txtQX_YZZE, blnEditMode)
                '*********************************************************************
                objControlProcess.doEnabledControl(Me.rblQX_JZFS, True)
                objControlProcess.doEnabledControl(Me.txtQX_ZQYS, True)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanelInfo_ZLQX = True
            Exit Function
errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function
        '============֣���޸�0623================

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

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            showModuleData_MAIN = False

            Try
                Me.btnOK.Visible = blnEditMode
                Me.btnCancel.Visible = blnEditMode

                Me.btnClose.Visible = Not blnEditMode
                Me.btnFPBL.Visible = Not blnEditMode
                Me.btnSHQK.Visible = Not blnEditMode
                Me.btnSJSZ.Visible = Not blnEditMode
                Me.btnYSYF.Visible = Not blnEditMode
                Me.btnSZTZ.Visible = Not blnEditMode
                Me.btnJSQK.Visible = Not blnEditMode
                Me.btnBAQK.Visible = Not blnEditMode
                Me.btnHTJA.Visible = Not blnEditMode
                'zengxianglin 2008-11-25
                Dim blnComplete As Boolean = False
                If objsystemEstateErshou.isHetongComplete(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strQRSH, blnComplete) = False Then
                End If
                Me.btnAJFH.Visible = Not blnEditMode And Me.m_blnPrevilegeParams(12) And blnComplete = False
                'zengxianglin 2008-11-25
                'zengxianglin 2010-12-30
                Me.btnJCHT.Visible = (Not blnEditMode) And (Me.m_blnPrevilegeParams(14))
                Me.btnBJHZ.Visible = (Not blnEditMode) And (Me.m_blnPrevilegeParams(15))
                'zengxianglin 2010-12-30
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            showModuleData_MAIN = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
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
                    '*****************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.ddlJFZJLB)
                    objControlProcess.doTranslateKey(Me.ddlYFZJLB)
                    '*****************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.txtFWDZ)
                    objControlProcess.doTranslateKey(Me.txtJYZZJ)
                    objControlProcess.doTranslateKey(Me.txtJYYZJ)
                    objControlProcess.doTranslateKey(Me.txtZLBZJ)
                    objControlProcess.doTranslateKey(Me.txtJFDLF)
                    objControlProcess.doTranslateKey(Me.txtYFDLF)
                    objControlProcess.doTranslateKey(Me.txtDLFZK)
                    objControlProcess.doTranslateKey(Me.txtZQYS)
                    objControlProcess.doTranslateKey(Me.txtJZR)
                    objControlProcess.doTranslateKey(Me.txtZNJBL)
                    objControlProcess.doTranslateKey(Me.txtNDZBL)
                    objControlProcess.doTranslateKey(Me.txtJLZKSM)
                    objControlProcess.doTranslateKey(Me.txtJLRQ)
                    objControlProcess.doTranslateKey(Me.txtBZXX)
                    '*****************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.txtJFDLR)
                    objControlProcess.doTranslateKey(Me.txtJFLXDH)
                    objControlProcess.doTranslateKey(Me.txtJFLXDZ)
                    objControlProcess.doTranslateKey(Me.txtJFMC)
                    objControlProcess.doTranslateKey(Me.txtJFZZHM)
                    '*****************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.txtYFDLR)
                    objControlProcess.doTranslateKey(Me.txtYFLXDH)
                    objControlProcess.doTranslateKey(Me.txtYFLXDZ)
                    objControlProcess.doTranslateKey(Me.txtYFMC)
                    objControlProcess.doTranslateKey(Me.txtYFZZHM)
                    '*****************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.txtHTBH)
                    objControlProcess.doTranslateKey(Me.txtHTRQ)
                    'zengxianglin 2008-11-22
                    objControlProcess.doTranslateKey(Me.txtTJRQ)
                    'zengxianglin 2008-11-22
                    'zengxianglin 2008-11-25
                    objControlProcess.doTranslateKey(Me.txtAJFH)
                    'zengxianglin 2008-11-25
                    objControlProcess.doTranslateKey(Me.ddlFKFS)
                    '*****************************************************************************************************************
                    objControlProcess.doTranslateKey(Me.txtQX_JZR)
                    objControlProcess.doTranslateKey(Me.txtQX_KSRQ)
                    objControlProcess.doTranslateKey(Me.txtQX_YZJE)
                    objControlProcess.doTranslateKey(Me.txtQX_YZZE)
                    objControlProcess.doTranslateKey(Me.txtQX_ZQYS)
                    objControlProcess.doTranslateKey(Me.txtQX_ZZRQ)
                    'zengxianglin 2010-12-27
                    objControlProcess.doTranslateKey(Me.txtKYBH)
                    objControlProcess.doTranslateKey(Me.txtCCDZ)
                    objControlProcess.doTranslateKey(Me.txtCCF)
                    objControlProcess.doTranslateKey(Me.txtSSYJ)
                    objControlProcess.doTranslateKey(Me.txtHZYJ)
                    objControlProcess.doTranslateKey(Me.txtYZQN)
                    objControlProcess.doTranslateKey(Me.txtYYQT)
                    objControlProcess.doTranslateKey(Me.txtYZDY)
                    objControlProcess.doTranslateKey(Me.txtMJQN)
                    objControlProcess.doTranslateKey(Me.txtKYQT)
                    objControlProcess.doTranslateKey(Me.txtKHDY)
                    objControlProcess.doTranslateKey(Me.txtZLKS)
                    objControlProcess.doTranslateKey(Me.txtZLJS)
                    objControlProcess.doTranslateKey(Me.txtJCRQ)
                    objControlProcess.doTranslateKey(Me.txtHZRQ)
                    objControlProcess.doTranslateKey(Me.txtHZJE)
                    'zengxianglin 2010-12-27

                    If Me.getModuleData_MAINQRS(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_MAINHT(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showEditPanel_MAIN(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    If Me.getModuleData_WYXX(strErrMsg, Me.m_strQRSH, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_WYXX(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    If Me.getModuleData_YWRY(strErrMsg, Me.m_strQRSH, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_YWRY(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    If Me.getModuleData_ZLQX(strErrMsg, Me.m_strQRSH, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_ZLQX(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    If Me.showModuleData_MAIN(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    '���ʼ����
                    'zengxianglin 2008-11-25
                    'If Me.m_blnSaveScence = False Then
                    '    Select Case Me.m_objenumEditType
                    '        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                    '            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                    '            Me.txtHTRQ.Text = Now.ToString("yyyy-MM-dd")
                    '            If Me.doComputeDLF(strErrMsg) = False Then
                    '                '����
                    '            End If
                    '        Case Else
                    '    End Select
                    'End If
                    'zengxianglin 2008-11-25
                Else
                    If Me.getModuleData_WYXX(strErrMsg, Me.m_strQRSH, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_YWRY(strErrMsg, Me.m_strQRSH, "", Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_ZLQX(strErrMsg, Me.m_strQRSH, "", Me.m_blnEditMode) = False Then
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
            Dim strErrMsg As String = ""
            Dim strUrl As String = ""
            Dim blnDo As Boolean = False

            Try
                'Ԥ����
                If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                    Exit Sub
                End If

                'zengxianglin 2008-11-25
                '����Ȩ��
                If Me.getPrevilegeParams(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2008-11-25

                '����б�
                If Me.IsPostBack = False Then
                    If Me.doFillFkfsList(strErrMsg, Me.ddlFKFS, False) = False Then
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
        Sub grdWYXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdWYXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdWYXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdWYXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdWYXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdWYXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdYWRY_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdYWRY.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdYWRY + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdYWRY > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdYWRY - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdYWRY.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdZLQX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdZLQX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdZLQX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdZLQX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdZLQX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdZLQX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        '============֣���޸�0623================
        Private Sub grdZLQX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdZLQX.SelectedIndexChanged
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                'ͬ����ʾ
                If Me.showEditPanelInfo_ZLQX(strErrMsg, Me.m_strQRSH, Me.m_blnEditMode) = False Then
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
        '============֣���޸�0623================

        Private Sub grdWYXX_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdWYXX.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '��λ
                Me.grdWYXX.SelectedIndex = e.Item.ItemIndex

                '����
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        Me.doOpen_WYXX(strControlId)
                    Case Else
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

        Private Sub doDelete_WYXX(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_WUYE_ZL
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                'ɾ��ѡ����
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdWYXX.Items.Count
                For i = intCount - 1 To 0 Step -1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdWYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdWYXX) = True Then
                        With Me.m_objDataSet_WYXX.Tables(strTable)
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdWYXX.CurrentPageIndex, Me.grdWYXX.PageSize)
                            objDataRow = Nothing
                            objDataRow = .DefaultView.Item(intRecPos).Row
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                        End With
                    End If
                Next

                '������ʾ
                If Me.showDataGridInfo_WYXX(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

                '���¼����������
                Dim strFWDZ As String = ""
                Dim dblMJ As Double = 0
                Dim dblJE As Double = 0
                If Me.getQRSInfoWyxxRela(strErrMsg, Me.m_objDataSet_WYXX, strFWDZ, dblMJ, dblJE) = True Then
                    Me.txtFWDZ.Text = strFWDZ
                    Me.txtJYZMJ.Text = dblMJ.ToString("#,###.00")
                    Me.txtJYYZJ.Text = dblJE.ToString("#,###.00")
                    'zengxianglin 2008-11-25
                    'If Me.doComputeDLF(strErrMsg) = False Then
                    '    '����
                    'End If
                    'zengxianglin 2008-11-25
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

        Private Sub doDelete_ZLQX(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_ZULINQIXIAN
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                'ɾ��ѡ����
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdZLQX.Items.Count
                For i = intCount - 1 To 0 Step -1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdZLQX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdZLQX) = True Then
                        With Me.m_objDataSet_ZLQX.Tables(strTable)
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdZLQX.CurrentPageIndex, Me.grdZLQX.PageSize)
                            objDataRow = Nothing
                            objDataRow = .DefaultView.Item(intRecPos).Row
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                        End With
                    End If
                Next

                '������ʾ
                If Me.showDataGridInfo_ZLQX(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

                '���¼����������
                Dim dblZZJ As Double = 0
                Dim dblZZQ As Double = 0
                If Me.getQRSInfoZlqxRela(strErrMsg, Me.m_objDataSet_ZLQX, dblZZJ, dblZZQ) = False Then
                    GoTo errProc
                End If
                Me.txtJYZZJ.Text = dblZZJ.ToString("#,###.00")
                Me.txtZQYS.Text = CType(dblZZQ, Integer).ToString
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

        Private Sub doDelete_YWRY(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_FPBL
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                'ɾ��ѡ����
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdYWRY.Items.Count
                For i = intCount - 1 To 0 Step -1
                    If objDataGridProcess.isDataGridItemChecked(Me.grdYWRY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdYWRY) = True Then
                        With Me.m_objDataSet_YWRY.Tables(strTable)
                            intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdYWRY.CurrentPageIndex, Me.grdYWRY.PageSize)
                            objDataRow = Nothing
                            objDataRow = .DefaultView.Item(intRecPos).Row
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                        End With
                    End If
                Next

                '�����������
                If Me.doComputeFPBL(strErrMsg) = False Then
                    '����
                End If

                '������ʾ
                If Me.showDataGridInfo_YWRY(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doAddNew_YWRY(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                'zengxianglin 2008-10-14
                If Me.txtHTRQ.Text.Trim = "" Then
                    strErrMsg = "������������[��ͬ����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtHTRQ.Text) = False Then
                    strErrMsg = "������Ч��[��ͬ����]��"
                    GoTo errProc
                End If
                'zengxianglin 2008-10-14

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

        Private Sub doOK(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objNewDataQRS As New System.Collections.Specialized.NameValueCollection
            Dim objNewDataHT As New System.Collections.Specialized.NameValueCollection
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim strQRSH As String = ""
            Dim strHTBH As String = ""

            Try
                '���
                If Me.grdWYXX.Items.Count < 1 Then
                    strErrMsg = "���󣺱�������ָ��һ����ҵ��"
                    GoTo errProc
                End If
                If Me.grdYWRY.Items.Count < 1 Then
                    strErrMsg = "���󣺱�������ָ��һ��ҵ��Ա��"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-25
                If Me.txtJFDLF.Text.Trim = "" Then
                    strErrMsg = "���󣺱���ָ��[�׷������]��"
                    GoTo errProc
                End If
                If Me.txtYFDLF.Text.Trim = "" Then
                    strErrMsg = "���󣺱���ָ��[�ҷ������]��"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-25
                'zengxianglin 2010-12-28
                If Me.txtZLKS.Text.Trim <> "" Then
                    If objPulicParameters.isDatetimeString(Me.txtZLKS.Text) = False Then
                        strErrMsg = "������Ч�����޿�ʼʱ��[" + Me.txtZLKS.Text + "]��"
                        GoTo errProc
                    End If
                End If
                If Me.txtZLJS.Text.Trim <> "" Then
                    If objPulicParameters.isDatetimeString(Me.txtZLJS.Text) = False Then
                        strErrMsg = "������Ч�����޽���ʱ��[" + Me.txtZLJS.Text + "]��"
                        GoTo errProc
                    End If
                End If
                'zengxianglin 2010-12-28

                Dim intValue As Integer = 0
                Dim dblValue As Double = 0
                '׼���ӿ�����(ȷ���鲿��)
                objNewDataQRS.Clear()
                '********************************************************************************************************************
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_WYBS, Me.htxtWYBS.Value.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_QRSH, Me.htxtQRSH.Value.Trim)
                '********************************************************************************************************************
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_FWDZ, Me.txtFWDZ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JYZZJ, Me.txtJYZZJ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JYYZJ, Me.txtJYYZJ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLBZJ, Me.txtZLBZJ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JYZMJ, Me.txtJYZMJ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFDLF, Me.txtJFDLF.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFDLF, Me.txtYFDLF.Text.Trim)
                dblValue = objPulicParameters.getObjectValue(Me.txtDLFZK.Text, 0.0) / 100.0
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DLFZK, dblValue.ToString("#.00"))
                dblValue = objPulicParameters.getObjectValue(Me.txtZNJBL.Text, 0.0) / 100.0
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZNJBL, dblValue.ToString("#.00"))
                dblValue = objPulicParameters.getObjectValue(Me.txtNDZBL.Text, 0.0) / 100.0
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_NDZBL, dblValue.ToString("#.00"))
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZQYS, Me.txtZQYS.Text)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JZR, Me.txtJZR.Text)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JLZKSM, Me.txtJLZKSM.Text)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JHJLRQ, Me.txtJLRQ.Text)
                '********************************************************************************************************************
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFDLR, Me.txtJFDLR.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFLXDH, Me.txtJFLXDH.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFLXDZ, Me.txtJFLXDZ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFMC, Me.txtJFMC.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFZZHM, Me.txtJFZZHM.Text.Trim)
                '********************************************************************************************************************
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFDLR, Me.txtYFDLR.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFLXDH, Me.txtYFLXDH.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFLXDZ, Me.txtYFLXDZ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFMC, Me.txtYFMC.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFZZHM, Me.txtYFZZHM.Text.Trim)
                '********************************************************************************************************************
                If Me.rblZJTGYD.SelectedIndex > 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZJTGYD, Me.rblZJTGYD.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZJTGYD, "0")
                End If
                '********************************************************************************************************************
                If Me.rblSFZFYD.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SFZFYD, Me.rblSFZFYD.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SFZFYD, "0")
                End If
                '********************************************************************************************************************
                If Me.rblFZFSYD.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_FZFSYD, Me.rblFZFSYD.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_FZFSYD, "0")
                End If
                '********************************************************************************************************************
                If Me.ddlJFZJLB.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFZJLX, Me.ddlJFZJLB.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_JFZJLX, "0")
                End If
                '********************************************************************************************************************
                If Me.ddlYFZJLB.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFZJLX, Me.ddlYFZJLB.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YFZJLX, "0")
                End If
                '********************************************************************************************************************
                'zengxianglin 2010-12-27
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KYBH, Me.txtKYBH.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_CCDZ, Me.txtCCDZ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_CCF, Me.txtCCF.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SSYJ, Me.txtSSYJ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_HZYJ, Me.txtHZYJ.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZQN, Me.txtYZQN.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YYQT, Me.txtYYQT.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZDY, Me.txtYZDY.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_MJQN, Me.txtMJQN.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KYQT, Me.txtKYQT.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KHDY, Me.txtKHDY.Text.Trim)
                If Me.rblYZQC.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZQC, Me.rblYZQC.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZQC, "")
                End If
                If Me.rblYZLY.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZLY, Me.rblYZLY.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_YZLY, "")
                End If
                If Me.rblSYWY.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SYWY, Me.rblSYWY.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SYWY, "")
                End If
                If Me.rblMJQC.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_MJQC, Me.rblMJQC.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_MJQC, "")
                End If
                If Me.rblKHLY.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KHLY, Me.rblKHLY.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_KHLY, "")
                End If
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLKS, Me.txtZLKS.Text.Trim)
                objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLJS, Me.txtZLJS.Text.Trim)
                If Me.rblSDMQ.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SDMQ, Me.rblSDMQ.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_SDMQ, "")
                End If
                If Me.rblDHF.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DHF, Me.rblDHF.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_DHF, "")
                End If
                If Me.rblGLF.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_GLF, Me.rblGLF.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_GLF, "")
                End If
                If Me.rblZLFP.SelectedIndex >= 0 Then
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLFP, Me.rblZLFP.SelectedValue)
                Else
                    objNewDataQRS.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZLFP, "")
                End If
                If Me.txtZQYS.Text.Trim = "" Then
                    If Me.txtZLKS.Text.Trim <> "" And Me.txtZLJS.Text.Trim <> "" Then
                        Me.txtZQYS.Text = (System.Math.Abs(Microsoft.VisualBasic.DateDiff(Microsoft.VisualBasic.DateInterval.Month, CType(Me.txtZLKS.Text, System.DateTime), CType(Me.txtZLJS.Text, System.DateTime))) + 1).ToString
                        objNewDataQRS(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_QUERENSHU_ZL_ZQYS) = Me.txtZQYS.Text
                    End If
                End If
                'zengxianglin 2010-12-27

                '׼���ӿ�����(��ͬ����)
                objNewDataHT.Clear()
                '********************************************************************************************************************
                '������δ���������
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_DJRDM, MyBase.UserId)
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_DJRMC, MyBase.UserZM)
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_DJRQ, Now.ToString("yyyy-MM-dd"))
                '********************************************************************************************************************
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_WYBS, Me.htxtHTWYBS.Value.Trim)
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_QRSH, Me.htxtQRSH.Value.Trim)
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTZT, Me.htxtHTZT.Value.Trim)
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBH, Me.txtHTBH.Text.Trim)
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTRQ, Me.txtHTRQ.Text.Trim)
                'zengxianglin 2008-11-22
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_TJRQ, Me.txtTJRQ.Text.Trim)
                'zengxianglin 2008-11-22
                'zengxianglin 2008-11-25
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_AJFH, Me.txtAJFH.Text.Trim)
                'zengxianglin 2008-11-25
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_BZXX, Me.txtBZXX.Text.Trim)
                '********************************************************************************************************************
                objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTLX, "0") 'δ��
                '********************************************************************************************************************
                If Me.ddlFKFS.SelectedIndex >= 0 Then
                    objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FKFS, Me.ddlFKFS.SelectedValue)
                Else
                    objNewDataHT.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_FKFS, "")
                End If

                '��ȡȷ��������
                If Me.getModuleData_MAINQRS(strErrMsg, Me.m_strQRSH) = False Then
                    GoTo errProc
                End If
                '��������
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        objNewDataHT(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTZT) = CType(Josco.JSOA.Common.Data.estateErshouData.enumHetongStatus.Weishen, Integer).ToString
                        objNewDataHT(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_WYBS) = ""
                        objNewDataHT(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBH) = ""
                        If objsystemEstateErshou.doSaveData_ES_HETONG(strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                            Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_ZL, _
                            objNewDataHT, Nothing, _
                            objNewDataQRS, _
                            Me.m_objDataSet_MAINQRS.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_ZL).Rows(0), _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Me.m_objDataSet_WYXX, Me.m_objDataSet_YWRY, Me.m_objDataSet_ZLQX) = False Then
                            GoTo errProc
                        End If
                        '��¼�����־
                        strHTBH = objNewDataHT(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBH)
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_��ͬ]��������[" + strHTBH + "]��")

                    Case Else
                        '��ȡ����
                        If Me.getModuleData_MAINHT(strErrMsg, Me.m_strQRSH) = False Then
                            GoTo errProc
                        End If
                        '��������
                        Dim objDataRow As System.Data.DataRow = Nothing
                        With Me.m_objDataSet_MAINHT.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG)
                            If .Rows.Count < 1 Then
                                strErrMsg = "����û�к�ͬ��"
                                GoTo errProc
                            Else
                                objDataRow = .Rows(0)
                            End If
                        End With
                        If objsystemEstateErshou.doSaveData_ES_HETONG(strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                            Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_ZL, _
                            objNewDataHT, objDataRow, _
                            objNewDataQRS, _
                            Me.m_objDataSet_MAINQRS.Tables(Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_QUERENSHU_ZL).Rows(0), _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate, _
                            Me.m_objDataSet_WYXX, Me.m_objDataSet_YWRY, Me.m_objDataSet_ZLQX) = False Then
                            GoTo errProc
                        End If
                        '��¼�����־
                        strHTBH = objNewDataQRS(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_HTBH)
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_��ͬ]��[�޸�]��[" + strHTBH + "]��")
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

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewDataQRS)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewDataHT)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewDataQRS)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewDataHT)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOpen_YSYF(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.htxtQRSH.Value.Trim = "" Then
                    strErrMsg = "����û��ѡ��[ȷ����]��"
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
                Dim objIEstateCwYsyf As Josco.JSOA.BusinessFacade.IEstateCwYsyf = Nothing
                Dim strUrl As String = ""
                objIEstateCwYsyf = New Josco.JSOA.BusinessFacade.IEstateCwYsyf
                With objIEstateCwYsyf
                    .iQRSH = Me.htxtQRSH.Value
                    .iCanModify = True
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
                Session.Add(strNewSessionId, objIEstateCwYsyf)
                strUrl = ""
                strUrl += "../caiwu/estate_cw_ysyf.aspx"
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

        Private Sub doOpen_SSSF(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.htxtQRSH.Value.Trim = "" Then
                    strErrMsg = "����û��ѡ��[ȷ����]��"
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
                    .iQRSH = Me.htxtQRSH.Value
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
                strUrl += "../caiwu/estate_cw_sssf.aspx"
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

        Private Sub doOpen_WYXX(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objValues As New System.Collections.Specialized.NameValueCollection
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.grdWYXX.SelectedIndex < 0 Then
                    strErrMsg = "����û����ҵ����"
                    GoTo errProc
                End If

                '׼���ӿ�
                Dim i As Integer = Me.grdWYXX.SelectedIndex
                Dim intColIndex As Integer = -1
                Dim strValue As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBS, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBM)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBM, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_QRSH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_QRSH, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_MJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_MJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YZJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YZJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JG, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LL, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZX, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQY, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQYMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQYMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_BZXX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_BZXX, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZH, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZDZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZDZ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ, strValue)

                'zengxianglin 2010-12-26
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FYBH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FYBH, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LP)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LP, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LD)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LD, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DY, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LG, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_KJLX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_KJLX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWXZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWXZ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXDC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXDC, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXNX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXNX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZYYX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZYYX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JJSB)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JJSB, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LYJT)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LYJT, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWJG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWJG, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGLX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGLX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGFS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGFS, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WSSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WSSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YTSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YTSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_HYMJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_HYMJ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DTSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DTSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LCHS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LCHS, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LPQS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LPQS, strValue)
                'zengxianglin 2010-12-26

                '�����ֳ�����
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIEstateEsQrsZlWuye As Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye = Nothing
                Dim strUrl As String = ""
                objIEstateEsQrsZlWuye = New Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye
                With objIEstateEsQrsZlWuye
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iRowNo = Me.grdWYXX.SelectedIndex
                    .iQRSH = Me.htxtQRSH.Value
                    .iValues = objValues
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
                Session.Add(strNewSessionId, objIEstateEsQrsZlWuye)
                strUrl = ""
                strUrl += "estate_es_qrszl_wuye.aspx"
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
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objValues)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doUpdate_WYXX(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objValues As New System.Collections.Specialized.NameValueCollection
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.grdWYXX.SelectedIndex < 0 Then
                    strErrMsg = "����û����ҵ����"
                    GoTo errProc
                End If

                '׼���ӿ�
                Dim i As Integer = Me.grdWYXX.SelectedIndex
                Dim intColIndex As Integer = -1
                Dim strValue As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBS, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBM)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYBM, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_QRSH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_QRSH, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_MJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_MJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YZJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YZJ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JG, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LL, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZX, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXZMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQY, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQYMC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_SZQYMC, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_BZXX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_BZXX, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZH, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZDZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FCZDZ, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWDZ, strValue)

                'zengxianglin 2010-12-26
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WYXX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FYBH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FYBH, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LP)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LP, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LD)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LD, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DY, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JCSJ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LG, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_KJLX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_KJLX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWXZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWXZ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXDC)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXDC, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXNX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZXNX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZYYX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_ZYYX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JJSB)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JJSB, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LYJT)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LYJT, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWJG)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_FWJG, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGLX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGLX, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGFS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_JGFS, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WSSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_WSSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YTSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_YTSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_HYMJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_HYMJ, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DTSL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_DTSL, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LCHS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LCHS, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdWYXX, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LPQS)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdWYXX.Items(i), intColIndex)
                objValues.Add(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_WUYE_ZL_LPQS, strValue)
                'zengxianglin 2010-12-26

                '�����ֳ�����
                Dim strSessionId As String = ""
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIEstateEsQrsZlWuye As Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye = Nothing
                Dim strUrl As String = ""
                objIEstateEsQrsZlWuye = New Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye
                With objIEstateEsQrsZlWuye
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    .iRowNo = Me.grdWYXX.SelectedIndex
                    .iQRSH = Me.htxtQRSH.Value
                    .iValues = objValues
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
                Session.Add(strNewSessionId, objIEstateEsQrsZlWuye)
                strUrl = ""
                strUrl += "estate_es_qrszl_wuye.aspx"
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
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objValues)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doAddNew_WYXX(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objValues As New System.Collections.Specialized.NameValueCollection
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
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
                Dim objIEstateEsQrsZlWuye As Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye = Nothing
                Dim strUrl As String = ""
                objIEstateEsQrsZlWuye = New Josco.JSOA.BusinessFacade.IEstateEsQrsZlWuye
                With objIEstateEsQrsZlWuye
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    .iQRSH = Me.htxtQRSH.Value
                    .iValues = Nothing
                    .iRowNo = -1
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
                Session.Add(strNewSessionId, objIEstateEsQrsZlWuye)
                strUrl = ""
                strUrl += "estate_es_qrszl_wuye.aspx"
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
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objValues)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doAddNew_ZLQX(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_ZULINQIXIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataRow As System.Data.DataRow
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.txtQX_KSRQ.Text.Trim = "" Then
                    strErrMsg = "����û������[��ʼ����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtQX_KSRQ.Text) = False Then
                    strErrMsg = "������Ч��[��ʼ����]��"
                    GoTo errProc
                End If
                Me.txtQX_KSRQ.Text = objPulicParameters.getObjectValue(Me.txtQX_KSRQ.Text, "", "yyyy-MM-dd")

                If Me.txtQX_ZZRQ.Text.Trim = "" Then
                    strErrMsg = "����û������[��ֹ����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtQX_ZZRQ.Text) = False Then
                    strErrMsg = "������Ч��[��ֹ����]��"
                    GoTo errProc
                End If
                Me.txtQX_ZZRQ.Text = objPulicParameters.getObjectValue(Me.txtQX_ZZRQ.Text, "", "yyyy-MM-dd")

                If Me.txtQX_YZJE.Text.Trim = "" Then
                    strErrMsg = "����û������[�����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtQX_YZJE.Text) = False Then
                    strErrMsg = "������Ч��[�����]��"
                    GoTo errProc
                End If

                If Me.txtQX_YZZE.Text.Trim = "" Then
                    strErrMsg = "����û������[����ܶ�]��"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtQX_YZZE.Text) = False Then
                    strErrMsg = "������Ч��[����ܶ�]��"
                    GoTo errProc
                End If

                If Me.txtQX_ZQYS.Text.Trim = "" Then
                    strErrMsg = "����û������[����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtQX_ZQYS.Text) = False Then
                    strErrMsg = "������Ч��[����]��"
                    GoTo errProc
                End If

                If Me.txtQX_JZR.Text.Trim = "" Then
                    strErrMsg = "����û������[������]��"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtQX_JZR.Text) = False Then
                    strErrMsg = "������Ч��[������]��"
                    GoTo errProc
                End If
                Dim intValue As Integer = objPulicParameters.getObjectValue(Me.txtQX_JZR.Text, 1)
                If intValue < 0 Or intValue > 31 Then
                    strErrMsg = "������Ч��[������]��"
                    GoTo errProc
                End If

                If Me.rblQX_JZFS.SelectedIndex < 0 Then
                    strErrMsg = "����û������[���ⷽ��]��"
                    GoTo errProc
                End If

                '�����ص���
                Dim strOldFilter As String = ""
                Dim strNewFilter As String = ""
                With Me.m_objDataSet_ZLQX.Tables(strTable)
                    strOldFilter = .DefaultView.RowFilter

                    Try
                        strNewFilter = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_KSRQ + " >= #" + Me.txtQX_KSRQ.Text + "#"
                        strNewFilter = strNewFilter + " and " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_KSRQ + " <= #" + Me.txtQX_ZZRQ.Text + "#"
                        .DefaultView.RowFilter = strNewFilter
                        If .DefaultView.Count > 0 Then
                            .DefaultView.RowFilter = strOldFilter
                            strErrMsg = "���������ص���"
                            GoTo errProc
                        End If

                        strNewFilter = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZZRQ + " >= #" + Me.txtQX_KSRQ.Text + "#"
                        strNewFilter = strNewFilter + " and " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZZRQ + " <= #" + Me.txtQX_ZZRQ.Text + "#"
                        .DefaultView.RowFilter = strNewFilter
                        If .DefaultView.Count > 0 Then
                            .DefaultView.RowFilter = strOldFilter
                            strErrMsg = "���������ص���"
                            GoTo errProc
                        End If

                        strNewFilter = "#" + Me.txtQX_KSRQ.Text + "# >= " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_KSRQ
                        strNewFilter = strNewFilter + " and " + "#" + Me.txtQX_KSRQ.Text + "# <= " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZZRQ
                        .DefaultView.RowFilter = strNewFilter
                        If .DefaultView.Count > 0 Then
                            .DefaultView.RowFilter = strOldFilter
                            strErrMsg = "���������ص���"
                            GoTo errProc
                        End If

                        strNewFilter = "#" + Me.txtQX_ZZRQ.Text + "# >= " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_KSRQ
                        strNewFilter = strNewFilter + " and " + "#" + Me.txtQX_ZZRQ.Text + "# <= " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZZRQ
                        .DefaultView.RowFilter = strNewFilter
                        If .DefaultView.Count > 0 Then
                            .DefaultView.RowFilter = strOldFilter
                            strErrMsg = "���������ص���"
                            GoTo errProc
                        End If
                    Catch ex As Exception
                        .DefaultView.RowFilter = strOldFilter
                        strErrMsg = ex.Message
                        GoTo errProc
                    End Try

                    .DefaultView.RowFilter = strOldFilter
                End With

                '����
                With Me.m_objDataSet_ZLQX.Tables(strTable)
                    objDataRow = .NewRow()
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_WYBS) = objPulicParameters.getNewGuid()
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_QRSH) = Me.m_strQRSH
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_KSRQ) = CType(Me.txtQX_KSRQ.Text, System.DateTime)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZZRQ) = CType(Me.txtQX_ZZRQ.Text, System.DateTime)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_YZJE) = CType(Me.txtQX_YZJE.Text, Double)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_YZZE) = CType(Me.txtQX_YZZE.Text, Double)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZQYS) = CType(Me.txtQX_ZQYS.Text, Double)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_JZR) = CType(Me.txtQX_JZR.Text, Integer)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_JZFS) = CType(Me.rblQX_JZFS.SelectedValue, Integer)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_JZFSMC) = Me.rblQX_JZFS.SelectedItem.Text
                    .Rows.Add(objDataRow)
                End With

                '������ʾ
                If Me.showDataGridInfo_ZLQX(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

                '���¼����������
                Dim dblZZJ As Double = 0
                Dim dblZZQ As Double = 0
                If Me.getQRSInfoZlqxRela(strErrMsg, Me.m_objDataSet_ZLQX, dblZZJ, dblZZQ) = False Then
                    GoTo errProc
                End If
                Me.txtJYZZJ.Text = dblZZJ.ToString("#,###.00")
                Me.txtZQYS.Text = CType(dblZZQ, Integer).ToString
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

        Private Sub doUpdate_ZLQX(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_ZULINQIXIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataRow As System.Data.DataRow
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.grdZLQX.SelectedIndex < 0 Then
                    strErrMsg = "����û�����ݿɸģ�"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdZLQX.SelectedIndex
                Dim intPos As Integer = 0

                If Me.txtQX_KSRQ.Text.Trim = "" Then
                    strErrMsg = "����û������[��ʼ����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtQX_KSRQ.Text) = False Then
                    strErrMsg = "������Ч��[��ʼ����]��"
                    GoTo errProc
                End If
                Me.txtQX_KSRQ.Text = objPulicParameters.getObjectValue(Me.txtQX_KSRQ.Text, "", "yyyy-MM-dd")

                If Me.txtQX_ZZRQ.Text.Trim = "" Then
                    strErrMsg = "����û������[��ֹ����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtQX_ZZRQ.Text) = False Then
                    strErrMsg = "������Ч��[��ֹ����]��"
                    GoTo errProc
                End If
                Me.txtQX_ZZRQ.Text = objPulicParameters.getObjectValue(Me.txtQX_ZZRQ.Text, "", "yyyy-MM-dd")

                If Me.txtQX_YZJE.Text.Trim = "" Then
                    strErrMsg = "����û������[�����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtQX_YZJE.Text) = False Then
                    strErrMsg = "������Ч��[�����]��"
                    GoTo errProc
                End If

                If Me.txtQX_YZZE.Text.Trim = "" Then
                    strErrMsg = "����û������[����ܶ�]��"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtQX_YZZE.Text) = False Then
                    strErrMsg = "������Ч��[����ܶ�]��"
                    GoTo errProc
                End If

                If Me.txtQX_ZQYS.Text.Trim = "" Then
                    strErrMsg = "����û������[����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtQX_ZQYS.Text) = False Then
                    strErrMsg = "������Ч��[����]��"
                    GoTo errProc
                End If

                If Me.txtQX_JZR.Text.Trim = "" Then
                    strErrMsg = "����û������[������]��"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtQX_JZR.Text) = False Then
                    strErrMsg = "������Ч��[������]��"
                    GoTo errProc
                End If
                Dim intValue As Integer = objPulicParameters.getObjectValue(Me.txtQX_JZR.Text, 1)
                If intValue < 0 Or intValue > 31 Then
                    strErrMsg = "������Ч��[������]��"
                    GoTo errProc
                End If

                If Me.rblQX_JZFS.SelectedIndex < 0 Then
                    strErrMsg = "����û������[���ⷽ��]��"
                    GoTo errProc
                End If

                '��ȡ��ǰ��
                Dim strWYBS As String = ""
                With Me.m_objDataSet_ZLQX.Tables(strTable)
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdZLQX.CurrentPageIndex, Me.grdZLQX.PageSize)
                    objDataRow = .DefaultView.Item(intPos).Row
                    strWYBS = objPulicParameters.getObjectValue(objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_WYBS), "")
                End With

                '�����ص���
                Dim strOldFilter As String = ""
                Dim strNewFilter As String = ""
                With Me.m_objDataSet_ZLQX.Tables(strTable)
                    strOldFilter = .DefaultView.RowFilter

                    Try
                        strNewFilter = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_KSRQ + " >= #" + Me.txtQX_KSRQ.Text + "#"
                        strNewFilter = strNewFilter + " and " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_KSRQ + " <= #" + Me.txtQX_ZZRQ.Text + "#"
                        strNewFilter = strNewFilter + " and " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_WYBS + " <> '" + strWYBS + "'"
                        .DefaultView.RowFilter = strNewFilter
                        If .DefaultView.Count > 0 Then
                            .DefaultView.RowFilter = strOldFilter
                            strErrMsg = "���������ص���"
                            GoTo errProc
                        End If

                        strNewFilter = Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZZRQ + " >= #" + Me.txtQX_KSRQ.Text + "#"
                        strNewFilter = strNewFilter + " and " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZZRQ + " <= #" + Me.txtQX_ZZRQ.Text + "#"
                        strNewFilter = strNewFilter + " and " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_WYBS + " <> '" + strWYBS + "'"
                        .DefaultView.RowFilter = strNewFilter
                        If .DefaultView.Count > 0 Then
                            .DefaultView.RowFilter = strOldFilter
                            strErrMsg = "���������ص���"
                            GoTo errProc
                        End If

                        strNewFilter = "#" + Me.txtQX_KSRQ.Text + "# >= " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_KSRQ
                        strNewFilter = strNewFilter + " and " + "#" + Me.txtQX_KSRQ.Text + "# <= " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZZRQ
                        strNewFilter = strNewFilter + " and " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_WYBS + " <> '" + strWYBS + "'"
                        .DefaultView.RowFilter = strNewFilter
                        If .DefaultView.Count > 0 Then
                            .DefaultView.RowFilter = strOldFilter
                            strErrMsg = "���������ص���"
                            GoTo errProc
                        End If

                        strNewFilter = "#" + Me.txtQX_ZZRQ.Text + "# >= " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_KSRQ
                        strNewFilter = strNewFilter + " and " + "#" + Me.txtQX_ZZRQ.Text + "# <= " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZZRQ
                        strNewFilter = strNewFilter + " and " + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_WYBS + " <> '" + strWYBS + "'"
                        .DefaultView.RowFilter = strNewFilter
                        If .DefaultView.Count > 0 Then
                            .DefaultView.RowFilter = strOldFilter
                            strErrMsg = "���������ص���"
                            GoTo errProc
                        End If
                    Catch ex As Exception
                        .DefaultView.RowFilter = strOldFilter
                        strErrMsg = ex.Message
                        GoTo errProc
                    End Try

                    .DefaultView.RowFilter = strOldFilter
                End With

                '����
                With Me.m_objDataSet_ZLQX.Tables(strTable)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_KSRQ) = CType(Me.txtQX_KSRQ.Text, System.DateTime)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZZRQ) = CType(Me.txtQX_ZZRQ.Text, System.DateTime)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_YZJE) = CType(Me.txtQX_YZJE.Text, Double)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_YZZE) = CType(Me.txtQX_YZZE.Text, Double)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_ZQYS) = CType(Me.txtQX_ZQYS.Text, Double)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_JZR) = CType(Me.txtQX_JZR.Text, Integer)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_JZFS) = CType(Me.rblQX_JZFS.SelectedValue, Integer)
                    objDataRow(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_ZULINQIXIAN_JZFSMC) = Me.rblQX_JZFS.SelectedItem.Text
                End With

                '������ʾ
                If Me.showDataGridInfo_ZLQX(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

                '���¼����������
                Dim dblZZJ As Double = 0
                Dim dblZZQ As Double = 0
                If Me.getQRSInfoZlqxRela(strErrMsg, Me.m_objDataSet_ZLQX, dblZZJ, dblZZQ) = False Then
                    GoTo errProc
                End If
                Me.txtJYZZJ.Text = dblZZJ.ToString("#,###.00")
                Me.txtZQYS.Text = CType(dblZZQ, Integer).ToString
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

        Private Sub doComputeZLQX(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_ZULINQIXIAN
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim objDataRow As System.Data.DataRow
            Dim strErrMsg As String = ""

            Try
                Dim intJZFF As Integer = 0
                Dim dblYZJ As Double = 0

                If Me.txtQX_KSRQ.Text.Trim = "" Then
                    strErrMsg = "����û������[��ʼ����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtQX_KSRQ.Text) = False Then
                    strErrMsg = "������Ч��[��ʼ����]��"
                    GoTo errProc
                End If
                Me.txtQX_KSRQ.Text = objPulicParameters.getObjectValue(Me.txtQX_KSRQ.Text, "", "yyyy-MM-dd")

                If Me.txtQX_ZZRQ.Text.Trim = "" Then
                    strErrMsg = "����û������[��ֹ����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtQX_ZZRQ.Text) = False Then
                    strErrMsg = "������Ч��[��ֹ����]��"
                    GoTo errProc
                End If
                Me.txtQX_ZZRQ.Text = objPulicParameters.getObjectValue(Me.txtQX_ZZRQ.Text, "", "yyyy-MM-dd")

                If Me.txtQX_YZJE.Text.Trim = "" Then
                    strErrMsg = "����û������[�����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isFloatString(Me.txtQX_YZJE.Text) = False Then
                    strErrMsg = "������Ч��[�����]��"
                    GoTo errProc
                End If
                dblYZJ = objPulicParameters.getObjectValue(Me.txtQX_YZJE.Text, 0.0)

                If Me.rblQX_JZFS.SelectedIndex < 0 Then
                    strErrMsg = "����û������[���ⷽ��]��"
                    GoTo errProc
                End If
                intJZFF = objPulicParameters.getObjectValue(Me.rblQX_JZFS.SelectedValue, 0)

                Dim dblZZJ As Double = 0
                Dim dblZZQ As Double = 0
                If objsystemEstateErshou.getZujinAndZuqi(strErrMsg, Me.txtQX_KSRQ.Text, Me.txtQX_ZZRQ.Text, dblYZJ, intJZFF, dblZZJ, dblZZQ) = False Then
                    GoTo errProc
                End If
                Me.txtQX_YZZE.Text = dblZZJ.ToString("#,###")
                Me.txtQX_ZQYS.Text = CType(dblZZQ, Integer).ToString
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

        Private Sub doOpen_FPBL(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.htxtQRSH.Value.Trim = "" Then
                    strErrMsg = "����û��ѡ��[ȷ����]��"
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
                Dim objIEstateEsHetongFpbl As Josco.JSOA.BusinessFacade.IEstateEsHetongFpbl = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongFpbl = New Josco.JSOA.BusinessFacade.IEstateEsHetongFpbl
                With objIEstateEsHetongFpbl
                    .iQRSH = Me.htxtQRSH.Value
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
                Session.Add(strNewSessionId, objIEstateEsHetongFpbl)
                strUrl = ""
                strUrl += "estate_es_hetong_fpbl.aspx"
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

        Private Sub doOpen_SHQK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.htxtQRSH.Value.Trim = "" Then
                    strErrMsg = "����û��ѡ��[ȷ����]��"
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
                Dim objIEstateEsHetongSh As Josco.JSOA.BusinessFacade.IEstateEsHetongSh = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongSh = New Josco.JSOA.BusinessFacade.IEstateEsHetongSh
                With objIEstateEsHetongSh
                    .iQRSH = Me.htxtQRSH.Value
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
                Session.Add(strNewSessionId, objIEstateEsHetongSh)
                strUrl = ""
                strUrl += "estate_es_hetong_sh.aspx"
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

        Private Sub doOpen_BAQK(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.htxtQRSH.Value.Trim = "" Then
                    strErrMsg = "����û��ѡ��[ȷ����]��"
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
                Dim objIEstateEsHetongBl As Josco.JSOA.BusinessFacade.IEstateEsHetongBl = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongBl = New Josco.JSOA.BusinessFacade.IEstateEsHetongBl
                With objIEstateEsHetongBl
                    .iQRSH = Me.htxtQRSH.Value
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
                Session.Add(strNewSessionId, objIEstateEsHetongBl)
                strUrl = ""
                strUrl += "estate_es_hetong_bl.aspx"
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

        Private Sub doOpen_SZTZ(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.htxtQRSH.Value.Trim = "" Then
                    strErrMsg = "����û��ѡ��[ȷ����]��"
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
                Dim objIEstateCwSztz As Josco.JSOA.BusinessFacade.IEstateCwSztz = Nothing
                Dim strUrl As String = ""
                objIEstateCwSztz = New Josco.JSOA.BusinessFacade.IEstateCwSztz
                With objIEstateCwSztz
                    .iQRSH = Me.htxtQRSH.Value
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
                Session.Add(strNewSessionId, objIEstateCwSztz)
                strUrl = ""
                strUrl += "../caiwu/estate_cw_sztz.aspx"
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

        Private Sub doOpen_JSQK(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.htxtQRSH.Value.Trim = "" Then
                    strErrMsg = "����û��ѡ��[ȷ����]��"
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
                    .iQRSH = Me.htxtQRSH.Value
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
                strUrl += "estate_es_hetong_jss_list.aspx"
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

        Private Sub doOpen_HTJA(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.htxtQRSH.Value.Trim = "" Then
                    strErrMsg = "����û��ѡ��[ȷ����]��"
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
                Dim objIEstateEsHetongWc As Josco.JSOA.BusinessFacade.IEstateEsHetongWc = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongWc = New Josco.JSOA.BusinessFacade.IEstateEsHetongWc
                With objIEstateEsHetongWc
                    .iQRSH = Me.htxtQRSH.Value
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
                Session.Add(strNewSessionId, objIEstateEsHetongWc)
                strUrl = ""
                strUrl += "estate_es_hetong_wc.aspx"
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

        'zengxianglin 2008-11-25
        Private Sub doAJFH(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                '���
                If Me.htxtQRSH.Value.Trim = "" Then
                    strErrMsg = "����û��[ȷ����]��"
                    GoTo errProc
                End If

                intStep = 1
                '������Ϣ
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doInputBox(Me.popMessageObject, "�����밴�ҷ��صĽ�", strControlId, intStep)
                    Exit Try
                End If

                intStep = 2
                '����
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��ȡ�������
                    Dim strAJFH As String = ""
                    Dim dblAJFH As Double = 0
                    strAJFH = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)
                    '����������
                    If strAJFH = "" Then
                        strErrMsg = "����û���������֣�"
                        GoTo errProc
                    End If
                    If objPulicParameters.isFloatString(strAJFH) = False Then
                        strErrMsg = "����[" + strAJFH + "]����Ч�����֣�"
                        GoTo errProc
                    End If
                    dblAJFH = objPulicParameters.getObjectValue(strAJFH, 0.0)
                    '����
                    If objsystemEstateErshou.doUpdateData_ES_HETONG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtQRSH.Value, dblAJFH) = False Then
                        GoTo errProc
                    End If
                    '��ʾ
                    If Me.getModuleData_MAINQRS(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_MAINHT(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showEditPanel_MAIN(strErrMsg, Me.m_blnEditMode, True) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub
        Private Sub btnAJFH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAJFH.Click
            Me.doAJFH("btnAJFH")
        End Sub
        'zengxianglin 2008-11-25

        'zengxianglin 2010-12-30
        Private Sub doJCHT(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                '���
                If Me.htxtQRSH.Value.Trim = "" Then
                    strErrMsg = "����û��[ȷ����]��"
                    GoTo errProc
                End If
                If Me.txtJCRQ.Text.Trim <> "" Then
                    strErrMsg = "���󣺺�ͬ�Ѿ�����ˣ�"
                    GoTo errProc
                End If

                intStep = 1
                'ȷ����Ϣ
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "���棺��ȷ��Ҫ�������ͬ��ȷ��/ȡ������", strControlId, intStep)
                    Exit Try
                End If

                intStep = 2
                '����
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '����
                    If objsystemEstateErshou.doMarkJiechu_ES_HETONG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtQRSH.Value) = False Then
                        GoTo errProc
                    End If
                    '��ʾ
                    If Me.getModuleData_MAINQRS(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_MAINHT(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showEditPanel_MAIN(strErrMsg, Me.m_blnEditMode, True) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub
        Private Sub btnJCHT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJCHT.Click
            Me.doJCHT("btnJCHT")
        End Sub
        'zengxianglin 2010-12-30

        'zengxianglin 2010-12-30
        Private Sub doBJHZ(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                '���
                If Me.htxtQRSH.Value.Trim = "" Then
                    strErrMsg = "����û��[ȷ����]��"
                    GoTo errProc
                End If
                If Me.txtHZRQ.Text.Trim <> "" Then
                    strErrMsg = "���󣺺�ͬ�Ѿ�����˻��ˣ�"
                    GoTo errProc
                End If

                intStep = 1
                '������Ϣ
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doInputBox(Me.popMessageObject, "�������ͬȷ���Ļ��˽�", strControlId, intStep)
                    Exit Try
                End If

                intStep = 2
                '����
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��ȡ�������
                    Dim strHZJE As String = ""
                    Dim dblHZJE As Double = 0
                    strHZJE = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)
                    '����������
                    If strHZJE = "" Then
                        strErrMsg = "����û���������֣�"
                        GoTo errProc
                    End If
                    If objPulicParameters.isFloatString(strHZJE) = False Then
                        strErrMsg = "����[" + strHZJE + "]����Ч�����֣�"
                        GoTo errProc
                    End If
                    dblHZJE = objPulicParameters.getObjectValue(strHZJE, 0.0)
                    '����
                    If objsystemEstateErshou.doMarkHuaizhang_ES_HETONG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtQRSH.Value, dblHZJE) = False Then
                        GoTo errProc
                    End If
                    '��ʾ
                    If Me.getModuleData_MAINQRS(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.getModuleData_MAINHT(strErrMsg, Me.m_strQRSH) = False Then
                        GoTo errProc
                    End If
                    If Me.showEditPanel_MAIN(strErrMsg, Me.m_blnEditMode, True) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub
        Private Sub btnBJHZ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBJHZ.Click
            Me.doBJHZ("btnBJHZ")
        End Sub
        'zengxianglin 2010-12-30

        Private Sub btnDelete_WYXX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_WYXX.Click
            Me.doDelete_WYXX("btnDelete_WYXX")
        End Sub

        Private Sub btnDelete_YWRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_YWRY.Click
            Me.doDelete_YWRY("btnDelete_YWRY")
        End Sub

        Private Sub btnDelete_ZLQX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_ZLQX.Click
            Me.doDelete_ZLQX("btnDelete_ZLQX")
        End Sub

        Private Sub btnAddNew_WYXX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_WYXX.Click
            Me.doAddNew_WYXX("btnAddNew_WYXX")
        End Sub

        Private Sub btnAddNew_YWRY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_YWRY.Click
            Me.doAddNew_YWRY("btnAddNew_YWRY")
        End Sub

        Private Sub btnAddNew_ZLQX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_ZLQX.Click
            Me.doAddNew_ZLQX("btnAddNew_ZLQX")
        End Sub

        Private Sub btnUpdate_WYXX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate_WYXX.Click
            Me.doUpdate_WYXX("btnUpdate_WYXX")
        End Sub

        Private Sub btnUpdate_ZLQX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate_ZLQX.Click
            Me.doUpdate_ZLQX("btnUpdate_ZLQX")
        End Sub

        Private Sub btnCompute_ZLQX_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCompute_ZLQX.Click
            Me.doComputeZLQX("btnCompute_ZLQX")
        End Sub

        Private Sub btnYSYF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYSYF.Click
            Me.doOpen_YSYF("btnYSYF")
        End Sub

        Private Sub btnSZTZ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSZTZ.Click
            Me.doOpen_SZTZ("btnSZTZ")
        End Sub

        Private Sub btnJSQK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJSQK.Click
            Me.doOpen_JSQK("btnJSQK")
        End Sub

        Private Sub btnSJSZ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSJSZ.Click
            Me.doOpen_SSSF("btnSJSZ")
        End Sub

        Private Sub btnFPBL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFPBL.Click
            Me.doOpen_FPBL("btnFPBL")
        End Sub

        Private Sub btnSHQK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSHQK.Click
            Me.doOpen_SHQK("btnSHQK")
        End Sub

        Private Sub btnBAQK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBAQK.Click
            Me.doOpen_BAQK("btnBAQK")
        End Sub

        Private Sub btnHTJA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHTJA.Click
            Me.doOpen_HTJA("btnHTJA")
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
