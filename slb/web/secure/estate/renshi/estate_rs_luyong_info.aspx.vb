Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_rs_luyong_info
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   ������¼����������Ϣ����
    '     �½�ʱ��������ɺ��Զ���������ӿڵ�iWJBS��iEditMode���ȴ��û���������
    '         ���ȡ������ֱ�ӷ����ϼ���
    '     �༭ʱ�����۱����ȡ�����ȴ��û���������
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IEstateRsLuyongInfo����
    ' ���ļ�¼��
    '     zengxianglin 2009-05-21 ����
    '----------------------------------------------------------------

    Partial Class estate_rs_luyong_info
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
        '�ļ����غ�Ļ���·��
        Private m_cstrUrlBaseToFileCache As String = "/temp/filecache/"
        '��׼���ģ��Ŀ¼
        Private m_cstrUrlBaseToWordTemplate As String = "/template/word/"
        'Ӧ�ø����ziyuan/image/rskp�����·��
        Private m_cstrPathRootToRskpImage As String = "ziyuan/image/rskp/"
        'Ӧ�ø����ziyuan/image/rskp�����·��
        Private m_cstrPathRootToGrllImage As String = "ziyuan/image/grll/"

        '----------------------------------------------------------------
        'ģ����Ȩ����
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsLuyongInfo
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        'ģ��������ݲ���(��������ġ�����������ļ�ͳһ������)
        '----------------------------------------------------------------
        Private m_objsystemFlowObjectRenshiLuyong As Josco.JSOA.BusinessFacade.systemFlowObjectRenshiLuyong
        Private m_objDataSet_FJ As Josco.JsKernal.Common.Data.FlowData
        Private m_strSessionID_FJ As String
        Private m_objDataSet_XGWJ As Josco.JsKernal.Common.Data.FlowData
        Private m_strSessionID_XGWJ As String
        Private m_objDataSet_RYXX As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_strSessionID_RYXX As String

        '----------------------------------------------------------------
        '����������grdFJ��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_FJ As String = "chkFJ"
        Private Const m_cstrDataGridInDIV_FJ As String = "divFJ"
        Private m_intFixedColumns_FJ As Integer

        '----------------------------------------------------------------
        '����������grdXGWJ��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_XGWJ As String = "chkXGWJ"
        Private Const m_cstrDataGridInDIV_XGWJ As String = "divXGWJ"
        Private m_intFixedColumns_XGWJ As Integer

        '----------------------------------------------------------------
        '����������grdRYXX��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_RYXX As String = "chkRYXX"
        Private Const m_cstrDataGridInDIV_RYXX As String = "divRYXX"
        Private m_intFixedColumns_RYXX As Integer

        '----------------------------------------------------------------
        'ģ����������
        '----------------------------------------------------------------
        Private m_objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_blnEditMode As Boolean
        Private m_strGJFileName As String  '���������ļ�����(���ļ���)
        Private m_blnEnforeEdit As Boolean 'ǿ�Ʊ༭ģʽ

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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo)
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.txtJLBH.Text = .txtJLBH
                    Me.txtRYDM.Text = .txtRYDM
                    Me.txtRYXM.Text = .txtRYXM
                    Me.txtRYNN.Text = .txtRYNN
                    Me.txtNFPBM.Text = .txtNFPBM
                    Me.txtNDRZW.Text = .txtNDRZW
                    Me.txtNBDRQ.Text = .txtNBDRQ
                    Me.txtZPSM.Text = .txtZPSM
                    Me.txtXYRYS.Text = .txtXYRYS
                    Me.txtDBRYS.Text = .txtDBRYS
                    Me.rblRYXB.SelectedIndex = .rblRYXB_SelectedIndex
                    Me.ddlXL.SelectedIndex = .ddlXL_SelectedIndex

                    Me.ddlJJCD.SelectedIndex = .ddlJJCD_SelectedIndex
                    Me.ddlMMDJ.SelectedIndex = .ddlMMDJ_SelectedIndex
                    Me.txtJGDZ.Text = .txtJGDZ
                    Me.txtWJNF.Text = .txtWJNF
                    Me.txtWJXH.Text = .txtWJXH
                    Me.txtWJBT.Text = .txtWJBT
                    Me.txtDBRS.Text = .txtDBRS
                    Me.txtBZXX.Text = .txtBZXX
                    Me.chkDDSZ.Checked = .chkDDSZ_Checked
                    Me.txtJBDW.Text = .txtJBDW
                    Me.txtJBRY.Text = .txtJBRY
                    Me.txtJBRQ.Text = .txtJBRQ
                    Me.txtLSH.Text = .txtLSH
                    Me.htxtWJBS.Value = .htxtWJBS

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftContent.Value = .htxtDivLeftContent
                    Me.htxtDivTopContent.Value = .htxtDivTopContent
                    Me.htxtDivLeftQFYJ.Value = .htxtDivLeftQFYJ
                    Me.htxtDivTopQFYJ.Value = .htxtDivTopQFYJ
                    Me.htxtDivLeftFHYJ.Value = .htxtDivLeftFHYJ
                    Me.htxtDivTopFHYJ.Value = .htxtDivTopFHYJ
                    Me.htxtDivLeftHQYJ.Value = .htxtDivLeftHQYJ
                    Me.htxtDivTopHQYJ.Value = .htxtDivTopHQYJ
                    Me.htxtDivLeftSHYJ.Value = .htxtDivLeftSHYJ
                    Me.htxtDivTopSHYJ.Value = .htxtDivTopSHYJ
                    Me.htxtDivLeftFJ.Value = .htxtDivLeftFJ
                    Me.htxtDivTopFJ.Value = .htxtDivTopFJ
                    Me.htxtDivLeftXGWJ.Value = .htxtDivLeftXGWJ
                    Me.htxtDivTopXGWJ.Value = .htxtDivTopXGWJ
                    Me.htxtDivLeftRYXX.Value = .htxtDivLeftRYXX
                    Me.htxtDivTopRYXX.Value = .htxtDivTopRYXX

                    Me.htxtEditMode.Value = .htxtEditMode
                    Me.htxtEditType.Value = .htxtEditType
                    Me.htxtZWNRFileName.Value = .htxtZWNRFileName
                    Me.htxtEnforeEdit.Value = .htxtEnforeEdit

                    Me.htxtSessionIDFJ.Value = .htxtSessionIDFJ
                    Me.htxtSessionIDXGWJ.Value = .htxtSessionIDXGWJ
                    Me.htxtSessionIDRYXX.Value = .htxtSessionIDRYXX

                    Me.htxtFJSort.Value = .htxtFJSort
                    Me.htxtFJSortColumnIndex.Value = .htxtFJSortColumnIndex
                    Me.htxtFJSortType.Value = .htxtFJSortType

                    Me.htxtXGWJSort.Value = .htxtXGWJSort
                    Me.htxtXGWJSortColumnIndex.Value = .htxtXGWJSortColumnIndex
                    Me.htxtXGWJSortType.Value = .htxtXGWJSortType

                    Me.htxtRYXXSort.Value = .htxtRYXXSort
                    Me.htxtRYXXSortColumnIndex.Value = .htxtRYXXSortColumnIndex
                    Me.htxtRYXXSortType.Value = .htxtRYXXSortType

                    Me.htxtSelectMenuID.Value = .htxtSelectMenuID

                    Try
                        Me.grdFJ.SelectedIndex = .grdFJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdFJ.PageSize = .grdFJ_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdFJ.CurrentPageIndex = .grdFJ_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Me.m_objDataSet_FJ = .objDataSet_FJ

                    Try
                        Me.grdXGWJ.SelectedIndex = .grdXGWJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdXGWJ.PageSize = .grdXGWJ_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdXGWJ.CurrentPageIndex = .grdXGWJ_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Me.m_objDataSet_XGWJ = .objDataSet_XGWJ

                    Try
                        Me.grdRYXX.SelectedIndex = .grdRYXX_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdRYXX.PageSize = .grdRYXX_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdRYXX.CurrentPageIndex = .grdRYXX_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Me.m_objDataSet_RYXX = .objDataSet_RYXX
                End With

                '�ͷ���Դ
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing

            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

        End Sub

        '----------------------------------------------------------------
        ' ����ģ���ֳ���Ϣ��������Ӧ��SessionId
        '----------------------------------------------------------------
        Private Function saveModuleInformation() As String

            Dim strSessionId As String = ""
            Dim strErrMsg As String

            saveModuleInformation = ""

            Try
                '����SessionId
                With New Josco.JsKernal.Common.Utilities.PulicParameters
                    strSessionId = .getNewGuid()
                End With
                If strSessionId = "" Then Exit Try

                '��������
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsLuyongInfo

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .txtJLBH = Me.txtJLBH.Text
                    .txtRYDM = Me.txtRYDM.Text
                    .txtRYXM = Me.txtRYXM.Text
                    .txtRYNN = Me.txtRYNN.Text
                    .txtNFPBM = Me.txtNFPBM.Text
                    .txtNDRZW = Me.txtNDRZW.Text
                    .txtNBDRQ = Me.txtNBDRQ.Text
                    .txtZPSM = Me.txtZPSM.Text
                    .txtXYRYS = Me.txtXYRYS.Text
                    .txtDBRYS = Me.txtDBRYS.Text
                    .rblRYXB_SelectedIndex = Me.rblRYXB.SelectedIndex
                    .ddlXL_SelectedIndex = Me.ddlXL.SelectedIndex

                    .ddlJJCD_SelectedIndex = Me.ddlJJCD.SelectedIndex
                    .ddlMMDJ_SelectedIndex = Me.ddlMMDJ.SelectedIndex
                    .txtJGDZ = Me.txtJGDZ.Text
                    .txtWJNF = Me.txtWJNF.Text
                    .txtWJXH = Me.txtWJXH.Text
                    .txtWJBT = Me.txtWJBT.Text
                    .txtDBRS = Me.txtDBRS.Text
                    .txtBZXX = Me.txtBZXX.Text
                    .chkDDSZ_Checked = Me.chkDDSZ.Checked
                    .txtJBDW = Me.txtJBDW.Text
                    .txtJBRY = Me.txtJBRY.Text
                    .txtJBRQ = Me.txtJBRQ.Text
                    .txtLSH = Me.txtLSH.Text
                    .htxtWJBS = Me.htxtWJBS.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftQFYJ = Me.htxtDivLeftQFYJ.Value
                    .htxtDivTopQFYJ = Me.htxtDivTopQFYJ.Value
                    .htxtDivLeftContent = Me.htxtDivLeftContent.Value
                    .htxtDivTopContent = Me.htxtDivTopContent.Value
                    .htxtDivLeftHQYJ = Me.htxtDivLeftHQYJ.Value
                    .htxtDivTopHQYJ = Me.htxtDivTopHQYJ.Value
                    .htxtDivLeftSHYJ = Me.htxtDivLeftSHYJ.Value
                    .htxtDivTopSHYJ = Me.htxtDivTopSHYJ.Value
                    .htxtDivLeftFHYJ = Me.htxtDivLeftFHYJ.Value
                    .htxtDivTopFHYJ = Me.htxtDivTopFHYJ.Value
                    .htxtDivLeftFJ = Me.htxtDivLeftFJ.Value
                    .htxtDivTopFJ = Me.htxtDivTopFJ.Value
                    .htxtDivLeftXGWJ = Me.htxtDivLeftXGWJ.Value
                    .htxtDivTopXGWJ = Me.htxtDivTopXGWJ.Value
                    .htxtDivLeftRYXX = Me.htxtDivLeftRYXX.Value
                    .htxtDivTopRYXX = Me.htxtDivTopRYXX.Value

                    .htxtEditMode = Me.htxtEditMode.Value
                    .htxtEditType = Me.htxtEditType.Value
                    .htxtZWNRFileName = Me.htxtZWNRFileName.Value
                    .htxtEnforeEdit = Me.htxtEnforeEdit.Value

                    .htxtSessionIDFJ = Me.htxtSessionIDFJ.Value
                    .htxtSessionIDXGWJ = Me.htxtSessionIDXGWJ.Value
                    .htxtSessionIDRYXX = Me.htxtSessionIDRYXX.Value

                    .htxtFJSort = Me.htxtFJSort.Value
                    .htxtFJSortColumnIndex = Me.htxtFJSortColumnIndex.Value
                    .htxtFJSortType = Me.htxtFJSortType.Value

                    .htxtXGWJSort = Me.htxtXGWJSort.Value
                    .htxtXGWJSortColumnIndex = Me.htxtXGWJSortColumnIndex.Value
                    .htxtXGWJSortType = Me.htxtXGWJSortType.Value

                    .htxtRYXXSort = Me.htxtRYXXSort.Value
                    .htxtRYXXSortColumnIndex = Me.htxtRYXXSortColumnIndex.Value
                    .htxtRYXXSortType = Me.htxtRYXXSortType.Value

                    .htxtSelectMenuID = Me.htxtSelectMenuID.Value

                    .grdFJ_SelectedIndex = Me.grdFJ.SelectedIndex
                    .grdFJ_PageSize = Me.grdFJ.PageSize
                    .grdFJ_CurrentPageIndex = Me.grdFJ.CurrentPageIndex
                    .objDataSet_FJ = Me.m_objDataSet_FJ

                    .grdXGWJ_SelectedIndex = Me.grdXGWJ.SelectedIndex
                    .grdXGWJ_PageSize = Me.grdXGWJ.PageSize
                    .grdXGWJ_CurrentPageIndex = Me.grdXGWJ.CurrentPageIndex
                    .objDataSet_XGWJ = Me.m_objDataSet_XGWJ

                    .grdRYXX_SelectedIndex = Me.grdRYXX.SelectedIndex
                    .grdRYXX_PageSize = Me.grdRYXX.PageSize
                    .grdRYXX_CurrentPageIndex = Me.grdRYXX.CurrentPageIndex
                    .objDataSet_RYXX = Me.m_objDataSet_RYXX
                End With

                '�������
                Session.Add(strSessionId, Me.m_objSaveScence)

            Catch ex As Exception
            End Try

            saveModuleInformation = strSessionId

        End Function

        '----------------------------------------------------------------
        ' �ӵ���ģ���л�ȡ����
        '----------------------------------------------------------------
        Private Function getDataFromCallModule(ByRef strErrMsg As String) As Boolean

            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            Dim intXZBZ As Integer = Josco.JsKernal.Common.Data.FlowData.enumFileDownloadStatus.HasDownload
            Dim intLBBS As Integer = Josco.JsKernal.Common.Data.FlowData.enumXGWJLB.FujianFile
            Dim objDataRow As System.Data.DataRow

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim strWhere As String = ""

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                'zengxianglin 2009-05-21
                '==========================================================================================================================================================
                Dim objIEstateRsGrllInfo As Josco.JSOA.BusinessFacade.IEstateRsGrllInfo
                Try
                    objIEstateRsGrllInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsGrllInfo)
                Catch ex As Exception
                    objIEstateRsGrllInfo = Nothing
                End Try
                If Not (objIEstateRsGrllInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsGrllInfo.SafeRelease(objIEstateRsGrllInfo)
                    Exit Try
                End If
                'zengxianglin 2009-05-21

                '==========================================================================================================================================================
                Dim objIDmxzJbdm As Josco.JsKernal.BusinessFacade.IDmxzJbdm
                Try
                    objIDmxzJbdm = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IDmxzJbdm)
                Catch ex As Exception
                    objIDmxzJbdm = Nothing
                End Try
                If Not (objIDmxzJbdm Is Nothing) Then
                    If objIDmxzJbdm.oExitMode = True Then
                        Select Case objIDmxzJbdm.iSourceControlId.ToUpper
                            Case "btnSelect_JLBH".ToUpper
                                Me.txtJLBH.Text = objIDmxzJbdm.oNameValue
                                Me.txtRYDM.Text = objIDmxzJbdm.oCodeValue
                                '��ȡ������Ϣ
                                strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_RYDM + " = '" + Me.txtRYDM.Text + "'"
                                If objsystemEstateRenshiXingye.getDataSet_GRLL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiXingyeData) = True Then
                                    With objestateRenshiXingyeData.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_GERENLVLI)
                                        If .Rows.Count > 0 Then
                                            Me.txtRYXM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XM), "")
                                            Me.rblRYXB.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYXB, objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_XB), ""))
                                            Me.txtRYNN.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_NN), "")
                                            Me.ddlXL.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlXL, objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_ZGXLMC), ""))
                                            'zengxianglin 2009-05-16
                                            Me.txtNFPBM.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_GERENLVLI_NYBMMC), "")
                                            If Me.txtNFPBM.Text.Trim <> "" Then
                                                '������֯����
                                                Dim strZZDM As String = ""
                                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtNFPBM.Text, strZZDM) = True Then
                                                    '���㶨������
                                                    If strZZDM <> "" Then
                                                        strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_SSDW + " = '" + strZZDM + "'"
                                                        If objsystemEstateRenshiXingye.getDataSet_RYJG_DW(strErrMsg, MyBase.UserId, MyBase.UserPassword, Now, strWhere, objestateRenshiXingyeData) = True Then
                                                            With objestateRenshiXingyeData.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RENYUANJIAGOU_DW)
                                                                If .Rows.Count > 0 Then
                                                                    Me.txtXYRYS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_SJBZ), "")
                                                                    Me.txtDBRYS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_BZRS), "")
                                                                End If
                                                            End With
                                                        End If
                                                    End If
                                                End If
                                            End If
                                            'zengxianglin 2009-05-16
                                        End If
                                    End With
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzJbdm.SafeRelease(objIDmxzJbdm)
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
                                Me.txtNFPBM.Text = objIDmxzZzjg.oBumenList
                                '������֯����
                                Dim strZZDM As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtNFPBM.Text, strZZDM) = True Then
                                    '���㶨������
                                    If strZZDM <> "" Then
                                        strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_SSDW + " = '" + strZZDM + "'"
                                        If objsystemEstateRenshiXingye.getDataSet_RYJG_DW(strErrMsg, MyBase.UserId, MyBase.UserPassword, Now, strWhere, objestateRenshiXingyeData) = True Then
                                            With objestateRenshiXingyeData.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_RENYUANJIAGOU_DW)
                                                If .Rows.Count > 0 Then
                                                    Me.txtXYRYS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_SJBZ), "")
                                                    Me.txtDBRYS.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_RENYUANJIAGOU_DW_BZRS), "")
                                                End If
                                            End With
                                        End If
                                    End If
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzZzjg.SafeRelease(objIDmxzZzjg)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowCkdbqk As Josco.JsKernal.BusinessFacade.IFlowCkdbqk
                Try
                    objIFlowCkdbqk = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowCkdbqk)
                Catch ex As Exception
                    objIFlowCkdbqk = Nothing
                End Try
                If Not (objIFlowCkdbqk Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowCkdbqk.SafeRelease(objIFlowCkdbqk)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowCkcbqk As Josco.JsKernal.BusinessFacade.IFlowCkcbqk
                Try
                    objIFlowCkcbqk = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowCkcbqk)
                Catch ex As Exception
                    objIFlowCkcbqk = Nothing
                End Try
                If Not (objIFlowCkcbqk Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowCkcbqk.SafeRelease(objIFlowCkcbqk)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowSpyjtx As Josco.JsKernal.BusinessFacade.IFlowSpyjtx
                Try
                    objIFlowSpyjtx = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowSpyjtx)
                Catch ex As Exception
                    objIFlowSpyjtx = Nothing
                End Try
                If Not (objIFlowSpyjtx Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowSpyjtx.SafeRelease(objIFlowSpyjtx)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowBycl As Josco.JsKernal.BusinessFacade.IFlowBycl
                Try
                    objIFlowBycl = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowBycl)
                Catch ex As Exception
                    objIFlowBycl = Nothing
                End Try
                If Not (objIFlowBycl Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowBycl.SafeRelease(objIFlowBycl)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowByqk As Josco.JsKernal.BusinessFacade.IFlowByqk
                Try
                    objIFlowByqk = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowByqk)
                Catch ex As Exception
                    objIFlowByqk = Nothing
                End Try
                If Not (objIFlowByqk Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowByqk.SafeRelease(objIFlowByqk)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowCzrz As Josco.JsKernal.BusinessFacade.IFlowCzrz
                Try
                    objIFlowCzrz = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowCzrz)
                Catch ex As Exception
                    objIFlowCzrz = Nothing
                End Try
                If Not (objIFlowCzrz Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowCzrz.SafeRelease(objIFlowCzrz)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowSpyj As Josco.JsKernal.BusinessFacade.IFlowSpyj
                Try
                    objIFlowSpyj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowSpyj)
                Catch ex As Exception
                    objIFlowSpyj = Nothing
                End Try
                If Not (objIFlowSpyj Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowSpyj.SafeRelease(objIFlowSpyj)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowLzqk As Josco.JsKernal.BusinessFacade.IFlowLzqk
                Try
                    objIFlowLzqk = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowLzqk)
                Catch ex As Exception
                    objIFlowLzqk = Nothing
                End Try
                If Not (objIFlowLzqk Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowLzqk.SafeRelease(objIFlowLzqk)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowDubanjg As Josco.JsKernal.BusinessFacade.IFlowDubanjg
                Try
                    objIFlowDubanjg = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowDubanjg)
                Catch ex As Exception
                    objIFlowDubanjg = Nothing
                End Try
                If Not (objIFlowDubanjg Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowDubanjg.SafeRelease(objIFlowDubanjg)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowDuban As Josco.JsKernal.BusinessFacade.IFlowDuban
                Try
                    objIFlowDuban = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowDuban)
                Catch ex As Exception
                    objIFlowDuban = Nothing
                End Try
                If Not (objIFlowDuban Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowDuban.SafeRelease(objIFlowDuban)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowCuiban As Josco.JsKernal.BusinessFacade.IFlowCuiban
                Try
                    objIFlowCuiban = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowCuiban)
                Catch ex As Exception
                    objIFlowCuiban = Nothing
                End Try
                If Not (objIFlowCuiban Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowCuiban.SafeRelease(objIFlowCuiban)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowImportZS As Josco.JsKernal.BusinessFacade.IFlowImportZS
                Try
                    objIFlowImportZS = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowImportZS)
                Catch ex As Exception
                    objIFlowImportZS = Nothing
                End Try
                If Not (objIFlowImportZS Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowImportZS.SafeRelease(objIFlowImportZS)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowImportQP As Josco.JsKernal.BusinessFacade.IFlowImportQP
                Try
                    objIFlowImportQP = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowImportQP)
                Catch ex As Exception
                    objIFlowImportQP = Nothing
                End Try
                If Not (objIFlowImportQP Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowImportQP.SafeRelease(objIFlowImportQP)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowTuihui As Josco.JsKernal.BusinessFacade.IFlowTuihui
                Try
                    objIFlowTuihui = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowTuihui)
                Catch ex As Exception
                    objIFlowTuihui = Nothing
                End Try
                If Not (objIFlowTuihui Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowTuihui.SafeRelease(objIFlowTuihui)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowShouhui As Josco.JsKernal.BusinessFacade.IFlowShouhui
                Try
                    objIFlowShouhui = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowShouhui)
                Catch ex As Exception
                    objIFlowShouhui = Nothing
                End Try
                If Not (objIFlowShouhui Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowShouhui.SafeRelease(objIFlowShouhui)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowReceive As Josco.JsKernal.BusinessFacade.IFlowReceive
                Try
                    objIFlowReceive = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowReceive)
                Catch ex As Exception
                    objIFlowReceive = Nothing
                End Try
                If Not (objIFlowReceive Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowReceive.SafeRelease(objIFlowReceive)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowSend As Josco.JsKernal.BusinessFacade.IFlowSend
                Try
                    objIFlowSend = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowSend)
                Catch ex As Exception
                    objIFlowSend = Nothing
                End Try
                If Not (objIFlowSend Is Nothing) Then
                    Dim blnReturn As Boolean = objIFlowSend.oExitMode
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowSend.SafeRelease(objIFlowSend)
                    '�������������ϼ���������
                    If blnReturn = True Then
                        '���÷��ز���
                        Me.m_objInterface.oExitMode = False
                        '���ص�����ģ�飬�����ӷ��ز���
                        'Ҫ���ص�SessionId
                        Dim strSessionId As String
                        strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                        'SessionId���ӵ����ص�Url
                        Dim strUrl As String
                        strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                        '�ͷ�ģ����Դ
                        Me.releaseModuleParameters()
                        Me.releaseInterfaceParameters()
                        '����
                        Response.Redirect(strUrl)
                    End If
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowXgwjfjInfo As Josco.JsKernal.BusinessFacade.IFlowXgwjfjInfo
                Try
                    objIFlowXgwjfjInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowXgwjfjInfo)
                Catch ex As Exception
                    objIFlowXgwjfjInfo = Nothing
                End Try
                If Not (objIFlowXgwjfjInfo Is Nothing) Then
                    If objIFlowXgwjfjInfo.oExitMode = True Then
                        Select Case objIFlowXgwjfjInfo.iEditType
                            Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                                objDataRow = objIFlowXgwjfjInfo.iRow
                                objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJYS) = objPulicParameters.getObjectValue(objIFlowXgwjfjInfo.oWJYS, 1)
                                objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ) = objIFlowXgwjfjInfo.oWJWZ
                                objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT) = objIFlowXgwjfjInfo.oWJSM
                                If objIFlowXgwjfjInfo.oBDWJ <> "" Then
                                    objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ) = objIFlowXgwjfjInfo.oBDWJ
                                    objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XZBZ) = intXZBZ.ToString()
                                End If
                            Case Else
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowXgwjfjInfo.SafeRelease(objIFlowXgwjfjInfo)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowFujianInfo As Josco.JsKernal.BusinessFacade.IFlowFujianInfo
                Try
                    objIFlowFujianInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowFujianInfo)
                Catch ex As Exception
                    objIFlowFujianInfo = Nothing
                End Try
                If Not (objIFlowFujianInfo Is Nothing) Then
                    If objIFlowFujianInfo.oExitMode = True Then
                        Select Case objIFlowFujianInfo.iEditType
                            Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                                objDataRow = objIFlowFujianInfo.iRow
                                objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS) = objPulicParameters.getObjectValue(objIFlowFujianInfo.oWJYS, 1)
                                objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ) = objIFlowFujianInfo.oWJWZ
                                objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM) = objIFlowFujianInfo.oWJSM
                                If objIFlowFujianInfo.oBDWJ <> "" Then
                                    objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ) = objIFlowFujianInfo.oBDWJ
                                    objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XZBZ) = intXZBZ.ToString()
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowFujianInfo.SafeRelease(objIFlowFujianInfo)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowXgwj As Josco.JsKernal.BusinessFacade.IFlowXgwj
                Try
                    objIFlowXgwj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowXgwj)
                Catch ex As Exception
                    objIFlowXgwj = Nothing
                End Try
                If Not (objIFlowXgwj Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowXgwj.SafeRelease(objIFlowXgwj)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowFujian As Josco.JsKernal.BusinessFacade.IFlowFujian
                Try
                    objIFlowFujian = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowFujian)
                Catch ex As Exception
                    objIFlowFujian = Nothing
                End Try
                If Not (objIFlowFujian Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowFujian.SafeRelease(objIFlowFujian)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowEditWord As Josco.JsKernal.BusinessFacade.IFlowEditWord
                Try
                    objIFlowEditWord = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JsKernal.BusinessFacade.IFlowEditWord)
                Catch ex As Exception
                    objIFlowEditWord = Nothing
                End Try
                If Not (objIFlowEditWord Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IFlowEditWord.SafeRelease(objIFlowEditWord)
                    Exit Try
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ͷŽӿڲ���(ģ���޷�������ʱ��)
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try

                '�����нӿڲ���
                Me.m_blnInterface = False
                If m_objInterface Is Nothing Then
                    '��ʾ������Ϣ
                    strErrMsg = "��ģ������ṩ����ӿڲ�����"
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = strErrMsg
                    blnContinue = False
                    Exit Try
                End If
                Me.m_blnInterface = True

                '�ӿڲ������
                Select Case Me.m_objInterface.iEditMode
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                    Case Else
                        If Me.m_objInterface.iWJBS.Trim() = "" Then
                            '��ʾ������Ϣ
                            strErrMsg = "��ģ������ṩ����[�ļ���ʶ]�ӿڲ�����"
                            Me.panelError.Visible = True
                            Me.panelMain.Visible = Not Me.panelError.Visible
                            Me.lblMessage.Text = strErrMsg
                            blnContinue = False
                            Exit Try
                        End If
                End Select

                '��������������
                Dim strWJBS As String = Me.m_objInterface.iWJBS
                If Me.getModuleData_Main(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If

                '��ȡ�ָ��ֳ�����
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsLuyongInfo)
                    Catch ex As Exception
                        Me.m_objSaveScence = Nothing
                    End Try
                    If Me.m_objSaveScence Is Nothing Then
                        Me.m_blnSaveScence = False
                    Else
                        Me.m_blnSaveScence = True
                    End If

                    If Me.m_objSaveScence Is Nothing Then
                        '���ǵ�������ģ�鷵��
                        Me.htxtEditType.Value = CType(Me.m_objInterface.iEditMode, Integer).ToString()
                    End If

                    '�ָ��ֳ��������ͷŸ���Դ
                    Me.restoreModuleInformation(strSessionId)

                    '�������ģ�鷵�غ����Ϣ��ͬʱ�ͷ���Ӧ��Դ
                    If Me.getDataFromCallModule(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

                '��ȡ��������
                Me.m_intFixedColumns_RYXX = objPulicParameters.getObjectValue(Me.htxtRYXXFixed.Value, 0)
                Me.m_intFixedColumns_XGWJ = objPulicParameters.getObjectValue(Me.htxtXGWJFixed.Value, 0)
                Me.m_intFixedColumns_FJ = objPulicParameters.getObjectValue(Me.htxtFJFixed.Value, 0)

                Try
                    Me.m_objenumEditType = CType(Me.htxtEditType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType)
                Catch ex As Exception
                    Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                End Try
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        Me.m_blnEditMode = True
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        Me.m_blnEditMode = True
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Me.m_blnEditMode = True
                    Case Else
                        Me.m_blnEditMode = False
                End Select
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()

                Me.m_strSessionID_RYXX = objPulicParameters.getObjectValue(Me.htxtSessionIDRYXX.Value, "")
                Me.m_strSessionID_XGWJ = objPulicParameters.getObjectValue(Me.htxtSessionIDXGWJ.Value, "")
                Me.m_strSessionID_FJ = objPulicParameters.getObjectValue(Me.htxtSessionIDFJ.Value, "")
                Me.m_strGJFileName = objPulicParameters.getObjectValue(Me.htxtZWNRFileName.Value, "")

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
        ' �ͷű�ģ�黺��Ĳ���(ģ�鷵��ʱ��)
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                Dim objFlowData As Josco.JsKernal.Common.Data.FlowData
                If Me.m_strSessionID_FJ <> "" Then
                    Try
                        objFlowData = CType(Session.Item(Me.m_strSessionID_FJ), Josco.JsKernal.Common.Data.FlowData)
                    Catch ex As Exception
                        objFlowData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.FlowData.SafeRelease(objFlowData)
                    Session.Remove(Me.m_strSessionID_FJ)
                End If
                If Me.m_strSessionID_XGWJ <> "" Then
                    Try
                        objFlowData = CType(Session.Item(Me.m_strSessionID_XGWJ), Josco.JsKernal.Common.Data.FlowData)
                    Catch ex As Exception
                        objFlowData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.FlowData.SafeRelease(objFlowData)
                    Session.Remove(Me.m_strSessionID_XGWJ)
                End If

                Dim objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData
                If Me.m_strSessionID_RYXX <> "" Then
                    Try
                        objestateRenshiXingyeData = CType(Session.Item(Me.m_strSessionID_RYXX), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objestateRenshiXingyeData = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
                    Session.Remove(Me.m_strSessionID_RYXX)
                End If

            Catch ex As Exception
            End Try

        End Sub












        '----------------------------------------------------------------
        ' ����strWJBS��ȡ�ļ���Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWJBS        ���ļ���ʶ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_Main( _
            ByRef strErrMsg As String, _
            ByVal strWJBS As String) As Boolean

            getModuleData_Main = False

            Try
                '��������������
                Dim strType As String = Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWCODE
                Dim strName As String = Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWNAME
                Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject
                objsystemFlowObject = Josco.JsKernal.BusinessFacade.systemFlowObject.Create(strType, strName)
                Me.m_objsystemFlowObjectRenshiLuyong = CType(objsystemFlowObject, Josco.JSOA.BusinessFacade.systemFlowObjectRenshiLuyong)

                '�����������ʼ�����������
                If Me.m_objsystemFlowObjectRenshiLuyong.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, True) = False Then
                    GoTo errProc
                End If

                '�����ִ�еĲ���
                If Me.m_objsystemFlowObjectRenshiLuyong.getCanExecuteCommand(strErrMsg, MyBase.UserId, MyBase.UserXM, MyBase.UserBmdm) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_Main = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����strWJBS��ȡgrdFJҪ��ʾ�ĸ�����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWJBS        ���ļ���ʶ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_FJ( _
            ByRef strErrMsg As String, _
            ByVal strWJBS As String) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_FUJIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_FJ = False

            Try
                '�Ǳ༭ģʽʱ�״ν��룺���ֳ���ԭ��ϢΪ׼(�����״ν�������)
                If Me.m_blnSaveScence = True And Me.m_blnEditMode = True Then
                    Exit Try
                End If

                '����Ǳ༭ģʽ����ӻ����л�ȡ����
                If Me.m_strSessionID_FJ <> "" And Me.m_blnEditMode = True Then
                    Me.m_objDataSet_FJ = CType(Session.Item(Me.m_strSessionID_FJ), Josco.JsKernal.Common.Data.FlowData)
                Else
                    '����Sort�ַ���
                    Dim strSort As String
                    strSort = Me.htxtFJSort.Value
                    If strSort.Length > 0 Then strSort = strSort.Trim

                    '�ͷ���Դ
                    Josco.JsKernal.Common.Data.FlowData.SafeRelease(Me.m_objDataSet_FJ)

                    '���¼�������
                    If Me.m_objsystemFlowObjectRenshiLuyong.getFujianData(strErrMsg, Me.m_objDataSet_FJ) = False Then
                        GoTo errProc
                    End If

                    '�ָ�Sort�ַ���
                    With Me.m_objDataSet_FJ.Tables(strTable)
                        .DefaultView.Sort = strSort
                    End With

                    '������л�������
                    If Me.m_strSessionID_FJ <> "" Then
                        Dim objFlowData As Josco.JsKernal.Common.Data.FlowData
                        objFlowData = CType(Session.Item(Me.m_strSessionID_FJ), Josco.JsKernal.Common.Data.FlowData)
                        Josco.JsKernal.Common.Data.FlowData.SafeRelease(objFlowData)
                        Session.Remove(Me.m_strSessionID_FJ)
                        Me.m_strSessionID_FJ = ""
                        Me.htxtSessionIDFJ.Value = Me.m_strSessionID_FJ
                    End If
                    If Me.m_blnEditMode = True Then
                        '����Ǳ༭״̬���򻺴�����
                        Me.m_strSessionID_FJ = objPulicParameters.getNewGuid()
                        Session.Add(Me.m_strSessionID_FJ, Me.m_objDataSet_FJ)
                        Me.htxtSessionIDFJ.Value = Me.m_strSessionID_FJ
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_FJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����strWJBS��ȡgrdXGWJҪ��ʾ�������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWJBS        ���ļ���ʶ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_XGWJ( _
            ByRef strErrMsg As String, _
            ByVal strWJBS As String) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_XGWJ = False

            Try
                '�Ǳ༭ģʽʱ�״ν��룺���ֳ���ԭ��ϢΪ׼(�����״ν�������)
                If Me.m_blnSaveScence = True And Me.m_blnEditMode = True Then
                    Exit Try
                End If

                '����Ǳ༭ģʽ����ӻ����л�ȡ����
                If Me.m_strSessionID_XGWJ <> "" And Me.m_blnEditMode = True Then
                    Me.m_objDataSet_XGWJ = CType(Session.Item(Me.m_strSessionID_XGWJ), Josco.JsKernal.Common.Data.FlowData)
                Else
                    '����Sort�ַ���
                    Dim strSort As String
                    strSort = Me.htxtXGWJSort.Value
                    If strSort.Length > 0 Then strSort = strSort.Trim

                    '�ͷ���Դ
                    Josco.JsKernal.Common.Data.FlowData.SafeRelease(Me.m_objDataSet_XGWJ)

                    '���¼�������
                    If Me.m_objsystemFlowObjectRenshiLuyong.getXgwjData(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
                        GoTo errProc
                    End If

                    '�ָ�Sort�ַ���
                    With Me.m_objDataSet_XGWJ.Tables(strTable)
                        .DefaultView.Sort = strSort
                    End With

                    '������л�������
                    If Me.m_strSessionID_XGWJ <> "" Then
                        Dim objFlowData As Josco.JsKernal.Common.Data.FlowData
                        objFlowData = CType(Session.Item(Me.m_strSessionID_XGWJ), Josco.JsKernal.Common.Data.FlowData)
                        Josco.JsKernal.Common.Data.FlowData.SafeRelease(objFlowData)
                        Session.Remove(Me.m_strSessionID_XGWJ)
                        Me.m_strSessionID_XGWJ = ""
                        Me.htxtSessionIDXGWJ.Value = Me.m_strSessionID_XGWJ
                    End If
                    If Me.m_blnEditMode = True Then
                        '����Ǳ༭״̬���򻺴�����
                        Me.m_strSessionID_XGWJ = objPulicParameters.getNewGuid()
                        Session.Add(Me.m_strSessionID_XGWJ, Me.m_objDataSet_XGWJ)
                        Me.htxtSessionIDXGWJ.Value = Me.m_strSessionID_XGWJ
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_XGWJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����strWJBS��ȡgrdRYXXҪ��ʾ�������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWJBS        ���ļ���ʶ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_RYXX( _
            ByRef strErrMsg As String, _
            ByVal strWJBS As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI_RENYUANXINXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_RYXX = False

            Try
                '�Ǳ༭ģʽʱ�״ν��룺���ֳ���ԭ��ϢΪ׼(�����״ν�������)
                If Me.m_blnSaveScence = True And Me.m_blnEditMode = True Then
                    Exit Try
                End If

                '����Ǳ༭ģʽ����ӻ����л�ȡ����
                If Me.m_strSessionID_RYXX <> "" And Me.m_blnEditMode = True Then
                    Me.m_objDataSet_RYXX = CType(Session.Item(Me.m_strSessionID_RYXX), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '����Sort�ַ���
                    Dim strSort As String
                    strSort = Me.htxtRYXXSort.Value
                    If strSort.Length > 0 Then strSort = strSort.Trim

                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_RYXX)

                    '���¼�������
                    If Me.m_objsystemFlowObjectRenshiLuyong.getDataSet_RYXX(strErrMsg, Me.m_objDataSet_RYXX) = False Then
                        GoTo errProc
                    End If

                    '�ָ�Sort�ַ���
                    With Me.m_objDataSet_RYXX.Tables(strTable)
                        .DefaultView.Sort = strSort
                    End With

                    '������л�������
                    If Me.m_strSessionID_RYXX <> "" Then
                        Dim objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData
                        objestateRenshiXingyeData = CType(Session.Item(Me.m_strSessionID_RYXX), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
                        Session.Remove(Me.m_strSessionID_RYXX)
                        Me.m_strSessionID_RYXX = ""
                        Me.htxtSessionIDRYXX.Value = Me.m_strSessionID_RYXX
                    End If
                    If Me.m_blnEditMode = True Then
                        '����Ǳ༭״̬���򻺴�����
                        Me.m_strSessionID_RYXX = objPulicParameters.getNewGuid()
                        Session.Add(Me.m_strSessionID_RYXX, Me.m_objDataSet_RYXX)
                        Me.htxtSessionIDRYXX.Value = Me.m_strSessionID_RYXX
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_RYXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function














        '----------------------------------------------------------------
        ' ��ʾgrdFJ������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_FJ( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_FUJIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_FJ = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtFJSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtFJSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_FJ Is Nothing Then
                    Me.grdFJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_FJ.Tables(strTable)
                        Me.grdFJ.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_FJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdFJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdFJ)
                    With Me.grdFJ.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdFJ.DataBind()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_FJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdXGWJ������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_XGWJ( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_XGWJ = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtXGWJSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtXGWJSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_XGWJ Is Nothing Then
                    Me.grdXGWJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_XGWJ.Tables(strTable)
                        Me.grdXGWJ.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdXGWJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdXGWJ)
                    With Me.grdXGWJ.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdXGWJ.DataBind()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_XGWJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdRYXX������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_RYXX( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI_RENYUANXINXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_RYXX = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtRYXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtRYXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_RYXX Is Nothing Then
                    Me.grdRYXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_RYXX.Tables(strTable)
                        Me.grdRYXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_RYXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdRYXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdRYXX)
                    With Me.grdRYXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdRYXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdRYXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_RYXX = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾ�༭��������
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ����ǰ�༭״̬
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showEditPanelInfo( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess
            Dim objBaseFlowRenshiLuyong As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess

            showEditPanelInfo = False

            Try
                objBaseFlowRenshiLuyong = CType(Me.m_objsystemFlowObjectRenshiLuyong.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)

                If Me.m_blnSaveScence = True And Me.m_blnEditMode = True Then
                    '�Ǳ༭ģʽʱ�״ν��룺���ֳ���ԭ��ϢΪ׼(�����״ν�������)
                Else
                    If Me.IsPostBack = False Or (Me.IsPostBack = True And Me.m_blnEditMode = False) Then
                        '�״ν����鿴״̬�µĻط�����Ҫ������ʾ����
                        Me.ddlJJCD.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlJJCD, objBaseFlowRenshiLuyong.JJCD)
                        Me.ddlMMDJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlMMDJ, objBaseFlowRenshiLuyong.MMDJ)
                        Me.txtJGDZ.Text = objBaseFlowRenshiLuyong.JGDZ
                        Me.txtWJNF.Text = objBaseFlowRenshiLuyong.WJNF
                        Me.txtWJXH.Text = objBaseFlowRenshiLuyong.WJXH
                        Me.txtWJBT.Text = objBaseFlowRenshiLuyong.WJBT
                        Me.txtDBRS.Text = objBaseFlowRenshiLuyong.DBRS.ToString
                        Me.txtBZXX.Text = objBaseFlowRenshiLuyong.BEIZ
                        If objBaseFlowRenshiLuyong.DDSZ = 1 Then
                            Me.chkDDSZ.Checked = True
                        Else
                            Me.chkDDSZ.Checked = False
                        End If
                        Me.txtJBDW.Text = objBaseFlowRenshiLuyong.ZBDW
                        Me.txtJBRY.Text = objBaseFlowRenshiLuyong.NGR
                        Me.txtJBRQ.Text = objPulicParameters.doDateToString(objBaseFlowRenshiLuyong.NGRQ, "yyyy-MM-dd")
                        Me.txtLSH.Text = objBaseFlowRenshiLuyong.LSH
                        Me.htxtWJBS.Value = objBaseFlowRenshiLuyong.WJBS

                        '����ʱ�Զ�����ȱʡֵ
                        Select Case Me.m_objenumEditType
                            Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                '���ó�ʼֵ
                                Me.txtJGDZ.Text = MyBase.UserBmmc
                                Me.txtWJNF.Text = Year(Now).ToString()
                                Dim strWJXH As String = ""
                                If Me.m_objsystemFlowObjectRenshiLuyong.getNewWjxh(strErrMsg, Me.txtJGDZ.Text, Me.txtWJNF.Text, strWJXH) = False Then
                                Else
                                    Me.txtWJXH.Text = strWJXH
                                End If
                                Me.txtJBDW.Text = MyBase.UserBmmc
                                Me.txtJBRY.Text = MyBase.UserXM
                                Me.txtJBRQ.Text = Now.ToString("yyyy-MM-dd")
                                Dim strLSH As String = ""
                                If Me.m_objsystemFlowObjectRenshiLuyong.getNewLSH(strErrMsg, strLSH) = False Then
                                    Me.txtLSH.Text = ""
                                Else
                                    Me.txtLSH.Text = strLSH
                                End If
                                If Me.m_objsystemFlowObjectRenshiLuyong.getNewWJBS(strErrMsg, strLSH) = False Then
                                    Me.htxtWJBS.Value = ""
                                Else
                                    Me.htxtWJBS.Value = strLSH
                                End If
                            Case Else
                        End Select
                    Else
                        '����������ؼ�ֵ�Զ��ָ�
                    End If
                End If

                '�����ļ�������ʱ����
                Me.lblQFR.Text = objBaseFlowRenshiLuyong.QFR

                '�������ڸ�ʽ
                If Me.txtJBRQ.Text <> "" Then
                    Me.txtJBRQ.Text = System.DateTime.Parse(Me.txtJBRQ.Text).ToString("yyyy-MM-dd")
                End If

                'ʹ�ܿؼ�
                With objControlProcess
                    .doEnabledControl(Me.ddlJJCD, blnEditMode)
                    .doEnabledControl(Me.ddlMMDJ, blnEditMode)
                    .doEnabledControl(Me.txtJGDZ, blnEditMode)
                    .doEnabledControl(Me.txtWJNF, blnEditMode)
                    .doEnabledControl(Me.txtWJXH, blnEditMode)
                    .doEnabledControl(Me.txtWJBT, blnEditMode)
                    .doEnabledControl(Me.txtDBRS, blnEditMode)
                    .doEnabledControl(Me.txtBZXX, blnEditMode)
                    .doEnabledControl(Me.chkDDSZ, blnEditMode)

                    '�������������
                    .doEnabledControl(Me.txtLSH, False)
                    .doEnabledControl(Me.txtJBDW, False)
                    .doEnabledControl(Me.txtJBRY, False)
                    .doEnabledControl(Me.txtJBRQ, False)
                End With

                '��Ա��Ϣ������
                With objControlProcess
                    .doEnabledControl(Me.txtJLBH, blnEditMode)
                    .doEnabledControl(Me.txtRYDM, blnEditMode)
                    .doEnabledControl(Me.txtRYXM, blnEditMode)
                    .doEnabledControl(Me.txtRYNN, blnEditMode)
                    .doEnabledControl(Me.txtNFPBM, blnEditMode)
                    .doEnabledControl(Me.txtNDRZW, blnEditMode)
                    .doEnabledControl(Me.txtNBDRQ, blnEditMode)
                    .doEnabledControl(Me.txtZPSM, blnEditMode)
                    .doEnabledControl(Me.txtXYRYS, blnEditMode)
                    .doEnabledControl(Me.txtDBRYS, blnEditMode)
                    .doEnabledControl(Me.rblRYXB, blnEditMode)
                    .doEnabledControl(Me.ddlXL, blnEditMode)
                End With
                Me.btnSelect_JLBH.Visible = blnEditMode
                Me.btnSelect_ZZDM.Visible = blnEditMode
                Me.btnRYXX_AddNew.Visible = blnEditMode
                Me.btnRYXX_Delete.Visible = blnEditMode
                Me.btnRYXX_Update.Visible = blnEditMode
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanelInfo = True
            Exit Function

errProc:
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ʹ�����еĲ�������
        '     blnEnabled     ������
        '----------------------------------------------------------------
        Private Sub doEnabledFileCommands(ByVal blnEnabled As Boolean)

            Try
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuJJCL_FSWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuJJCL_THWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuJJCL_JSWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuJJCL_SHWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuJJCL_WTBL").Enabled = blnEnabled
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuFILE_BCWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuFILE_QXXG").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuFILE_SXWJ").Enabled = blnEnabled
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuSPCL_TXYJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_BDPS").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_BYBL").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_BLWB").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_WYYZ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_ZHBL").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_JXBL").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_ZFWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuSPCL_QYWJ").Enabled = blnEnabled
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuCBDB_CBWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuCBDB_DBWJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuCBDB_DBJG").Enabled = blnEnabled
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuXXCY_CYYJ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuXXCY_CKLZ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuXXCY_CKBY").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuXXCY_CKRZ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuXXCY_CKCB").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuXXCY_CKDB").Enabled = blnEnabled
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuXXDY_DYGZ").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuXXDY_DYBJ").Enabled = blnEnabled
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuQTCL_WJBY").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuQTCL_BWTX").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuQTCL_DRQP").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuQTCL_DRZS").Enabled = blnEnabled
                Me.mnuMain.FindItemById("mnuQTCL_WJBJ").Enabled = blnEnabled
                'zengxianglin 2009-05-16
                Me.mnuMain.FindItemById("mnuQTCL_RYLY").Enabled = blnEnabled
                'zengxianglin 2009-05-16
                '**********************************************************************
                Me.mnuMain.FindItemById("mnuFHSJ").Enabled = blnEnabled
                '**********************************************************************

                '**********************************************************************
                'ǩ���������
                Me.lnkCZQSYJ_QF.Enabled = blnEnabled
                Me.lnkCZQSYJ_FH.Enabled = blnEnabled
                Me.lnkCZQSYJ_HQ.Enabled = blnEnabled
                Me.lnkCZQSYJ_SH.Enabled = blnEnabled
                '**********************************************************************

                '�ļ��ڲ�����
                Me.lnkCZCYGJ.Enabled = blnEnabled
                Me.lnkCZCYFJ.Enabled = blnEnabled
                Me.lnkCZCYXGWJ.Enabled = blnEnabled
                Me.lnkCZCYQPWJ.Enabled = blnEnabled
                Me.lnkCZCYZSWJ.Enabled = blnEnabled

            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' ʹ�����еĲ�������
        '     blnEnabled     ������
        '----------------------------------------------------------------
        Private Sub doSetVisibleCommands()

            Try
                Exit Try

                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuJJCL_FSWJ").Visible = Me.mnuMain.FindItemById("mnuJJCL_FSWJ").Enabled
                Me.mnuMain.FindItemById("mnuJJCL_THWJ").Visible = Me.mnuMain.FindItemById("mnuJJCL_THWJ").Enabled
                Me.mnuMain.FindItemById("mnuJJCL_JSWJ").Visible = Me.mnuMain.FindItemById("mnuJJCL_JSWJ").Enabled
                Me.mnuMain.FindItemById("mnuJJCL_SHWJ").Visible = Me.mnuMain.FindItemById("mnuJJCL_SHWJ").Enabled
                Me.mnuMain.FindItemById("mnuJJCL_WTBL").Visible = Me.mnuMain.FindItemById("mnuJJCL_WTBL").Enabled
                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuFILE_XGWJ").Visible = Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled
                Me.mnuMain.FindItemById("mnuFILE_BCWJ").Visible = Me.mnuMain.FindItemById("mnuFILE_BCWJ").Enabled
                Me.mnuMain.FindItemById("mnuFILE_QXXG").Visible = Me.mnuMain.FindItemById("mnuFILE_QXXG").Enabled
                Me.mnuMain.FindItemById("mnuFILE_SXWJ").Visible = Me.mnuMain.FindItemById("mnuFILE_SXWJ").Enabled
                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuSPCL_TXYJ").Visible = Me.mnuMain.FindItemById("mnuSPCL_TXYJ").Enabled
                Me.mnuMain.FindItemById("mnuSPCL_BDPS").Visible = Me.mnuMain.FindItemById("mnuSPCL_BDPS").Enabled
                Me.mnuMain.FindItemById("mnuSPCL_BYBL").Visible = Me.mnuMain.FindItemById("mnuSPCL_BYBL").Enabled
                Me.mnuMain.FindItemById("mnuSPCL_BLWB").Visible = Me.mnuMain.FindItemById("mnuSPCL_BLWB").Enabled
                Me.mnuMain.FindItemById("mnuSPCL_WYYZ").Visible = Me.mnuMain.FindItemById("mnuSPCL_WYYZ").Enabled
                Me.mnuMain.FindItemById("mnuSPCL_ZHBL").Visible = Me.mnuMain.FindItemById("mnuSPCL_ZHBL").Enabled
                Me.mnuMain.FindItemById("mnuSPCL_JXBL").Visible = Me.mnuMain.FindItemById("mnuSPCL_JXBL").Enabled
                Me.mnuMain.FindItemById("mnuSPCL_ZFWJ").Visible = Me.mnuMain.FindItemById("mnuSPCL_ZFWJ").Enabled
                Me.mnuMain.FindItemById("mnuSPCL_QYWJ").Visible = Me.mnuMain.FindItemById("mnuSPCL_QYWJ").Enabled
                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuCBDB_CBWJ").Visible = Me.mnuMain.FindItemById("mnuCBDB_CBWJ").Enabled
                Me.mnuMain.FindItemById("mnuCBDB_DBWJ").Visible = Me.mnuMain.FindItemById("mnuCBDB_DBWJ").Enabled
                Me.mnuMain.FindItemById("mnuCBDB_DBJG").Visible = Me.mnuMain.FindItemById("mnuCBDB_DBJG").Enabled
                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuXXCY_CYYJ").Visible = Me.mnuMain.FindItemById("mnuXXCY_CYYJ").Enabled
                Me.mnuMain.FindItemById("mnuXXCY_CKLZ").Visible = Me.mnuMain.FindItemById("mnuXXCY_CKLZ").Enabled
                Me.mnuMain.FindItemById("mnuXXCY_CKBY").Visible = Me.mnuMain.FindItemById("mnuXXCY_CKBY").Enabled
                Me.mnuMain.FindItemById("mnuXXCY_CKRZ").Visible = Me.mnuMain.FindItemById("mnuXXCY_CKRZ").Enabled
                Me.mnuMain.FindItemById("mnuXXCY_CKCB").Visible = Me.mnuMain.FindItemById("mnuXXCY_CKCB").Enabled
                Me.mnuMain.FindItemById("mnuXXCY_CKDB").Visible = Me.mnuMain.FindItemById("mnuXXCY_CKDB").Enabled
                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuXXDY_DYGZ").Visible = Me.mnuMain.FindItemById("mnuXXDY_DYGZ").Enabled
                Me.mnuMain.FindItemById("mnuXXDY_DYBJ").Visible = Me.mnuMain.FindItemById("mnuXXDY_DYBJ").Enabled
                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuQTCL_WJBY").Visible = Me.mnuMain.FindItemById("mnuQTCL_WJBY").Enabled
                Me.mnuMain.FindItemById("mnuQTCL_BWTX").Visible = Me.mnuMain.FindItemById("mnuQTCL_BWTX").Enabled
                Me.mnuMain.FindItemById("mnuQTCL_DRQP").Visible = Me.mnuMain.FindItemById("mnuQTCL_DRQP").Enabled
                Me.mnuMain.FindItemById("mnuQTCL_DRZS").Visible = Me.mnuMain.FindItemById("mnuQTCL_DRZS").Enabled
                Me.mnuMain.FindItemById("mnuQTCL_WJBJ").Visible = Me.mnuMain.FindItemById("mnuQTCL_WJBJ").Enabled
                'zengxianglin 2009-05-16
                Me.mnuMain.FindItemById("mnuQTCL_RYLY").Visible = Me.mnuMain.FindItemById("mnuQTCL_RYLY").Enabled
                'zengxianglin 2009-05-16
                '******************************************************************************************************
                Me.mnuMain.FindItemById("mnuFHSJ").Visible = Me.mnuMain.FindItemById("mnuFHSJ").Enabled
                '******************************************************************************************************

            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' ��ʾ�Ķ�״̬�µĲ���
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_ReadMode(ByRef strErrMsg As String) As Boolean

            Dim objBaseFlowRenshiLuyong As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
            Dim blnEditMode As Boolean = False

            showModuleData_ReadMode = False

            Try
                '��Ա��Ϣ������

                '��������ʼ��
                objBaseFlowRenshiLuyong = CType(Me.m_objsystemFlowObjectRenshiLuyong.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)

                'ʹ������
                doEnabledFileCommands(False)

                '�������
                Me.lnkCZCYGJ.Enabled = Not blnEditMode
                Me.lnkCZCYGJ.Text = "���ĸ��"
                Me.lnkCZCYFJ.Enabled = Not blnEditMode
                Me.lnkCZCYFJ.Text = "���ĸ���"
                Me.lnkCZCYXGWJ.Enabled = Not blnEditMode
                Me.lnkCZCYXGWJ.Text = "��������ļ�"
                Me.lnkCZCYQPWJ.Enabled = Not blnEditMode And (objBaseFlowRenshiLuyong.HJWJ <> "")
                Me.lnkCZCYZSWJ.Enabled = Not blnEditMode And (objBaseFlowRenshiLuyong.PJYJ <> "")

                '
                '�����ļ�Ӱ�������
                '
                'ˢ���ļ�
                Me.mnuMain.FindItemById("mnuFILE_SXWJ").Enabled = Not blnEditMode
                '�����ϼ�
                Me.mnuMain.FindItemById("mnuFHSJ").Enabled = Not blnEditMode

                '
                '�����Ƚ��գ�
                '
                If Me.m_objsystemFlowObjectRenshiLuyong.pmMustJieshou = True Then
                    '�����ļ�
                    Me.mnuMain.FindItemById("mnuJJCL_JSWJ").Enabled = Not blnEditMode
                    Exit Try
                End If

                '
                '��������
                '
                With Me.m_objsystemFlowObjectRenshiLuyong
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuJJCL_FSWJ").Enabled = .mlFSWJ
                    Me.mnuMain.FindItemById("mnuJJCL_THWJ").Enabled = .mlTHWJ
                    Me.mnuMain.FindItemById("mnuJJCL_JSWJ").Enabled = .mlJSWJ
                    Me.mnuMain.FindItemById("mnuJJCL_SHWJ").Enabled = .mlSHWJ
                    Me.mnuMain.FindItemById("mnuJJCL_WTBL").Enabled = .mlFSWJ
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled = .mlXGWJ
                    Me.mnuMain.FindItemById("mnuFILE_BCWJ").Enabled = .mlBCWJ
                    Me.mnuMain.FindItemById("mnuFILE_QXXG").Enabled = .mlQXXG
                    Me.mnuMain.FindItemById("mnuFILE_SXWJ").Enabled = .mlSXWJ
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuSPCL_TXYJ").Enabled = .mlTXYJ
                    Me.mnuMain.FindItemById("mnuSPCL_BDPS").Enabled = .mlBDPS
                    Me.mnuMain.FindItemById("mnuSPCL_BYBL").Enabled = .mlBYBL
                    Me.mnuMain.FindItemById("mnuSPCL_BLWB").Enabled = .mlBLWB
                    Me.mnuMain.FindItemById("mnuSPCL_WYYZ").Enabled = .mlWYYZ
                    Me.mnuMain.FindItemById("mnuSPCL_ZHBL").Enabled = .mlZHBL
                    Me.mnuMain.FindItemById("mnuSPCL_JXBL").Enabled = .mlJXBL
                    Me.mnuMain.FindItemById("mnuSPCL_ZFWJ").Enabled = .mlZFWJ
                    Me.mnuMain.FindItemById("mnuSPCL_QYWJ").Enabled = .mlQYWJ
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuCBDB_CBWJ").Enabled = .mlCBWJ
                    Me.mnuMain.FindItemById("mnuCBDB_DBWJ").Enabled = .mlDBWJ
                    Me.mnuMain.FindItemById("mnuCBDB_DBJG").Enabled = .mlDBJG
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuXXCY_CYYJ").Enabled = .mlCYYJ
                    Me.mnuMain.FindItemById("mnuXXCY_CKLZ").Enabled = .mlCKLZ
                    Me.mnuMain.FindItemById("mnuXXCY_CKRZ").Enabled = .mlCKRZ
                    Me.mnuMain.FindItemById("mnuXXCY_CKBY").Enabled = .mlCKBY
                    Me.mnuMain.FindItemById("mnuXXCY_CKCB").Enabled = .mlCKCB
                    Me.mnuMain.FindItemById("mnuXXCY_CKDB").Enabled = .mlCKDB
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuXXDY_DYGZ").Enabled = .mlDYGZ
                    Me.mnuMain.FindItemById("mnuXXDY_DYBJ").Enabled = .mlDYBJ
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuQTCL_WJBY").Enabled = .mlWJBY
                    Me.mnuMain.FindItemById("mnuQTCL_BWTX").Enabled = .mlWJBY
                    Me.mnuMain.FindItemById("mnuQTCL_DRQP").Enabled = .mlDRQP
                    Me.mnuMain.FindItemById("mnuQTCL_DRZS").Enabled = .mlDRZS
                    Me.mnuMain.FindItemById("mnuQTCL_WJBJ").Enabled = .mlWJBJ
                    'zengxianglin 2009-05-16
                    Me.mnuMain.FindItemById("mnuQTCL_RYLY").Enabled = .mlRYLY
                    'zengxianglin 2009-05-16
                    '********************************************************
                    Me.mnuMain.FindItemById("mnuFHSJ").Enabled = .mlFHSJ
                    '********************************************************

                    '********************************************************
                    Me.lnkCZQSYJ_QF.Enabled = .pmQSYJ_QF
                    Me.lnkCZQSYJ_FH.Enabled = .pmQSYJ_FH
                    Me.lnkCZQSYJ_HQ.Enabled = .pmQSYJ_HQ
                    Me.lnkCZQSYJ_SH.Enabled = .pmQSYJ_SH
                    '********************************************************
                    Me.m_blnEnforeEdit = .pmEnforeEdit
                    Me.htxtEnforeEdit.Value = Me.m_blnEnforeEdit.ToString()
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showModuleData_ReadMode = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾ�༭״̬�µĲ���
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_EditMode(ByRef strErrMsg As String) As Boolean

            Dim objBaseFlowRenshiLuyong As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
            Dim blnEditMode As Boolean = True

            showModuleData_EditMode = False

            Try
                '��������ʼ��
                objBaseFlowRenshiLuyong = CType(Me.m_objsystemFlowObjectRenshiLuyong.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)

                'ʹ������
                doEnabledFileCommands(False)

                '�������
                Me.lnkCZCYGJ.Enabled = blnEditMode
                Me.lnkCZCYGJ.Text = "�༭���"
                Me.lnkCZCYFJ.Enabled = blnEditMode
                Me.lnkCZCYFJ.Text = "�༭����"
                Me.lnkCZCYXGWJ.Enabled = blnEditMode
                Me.lnkCZCYXGWJ.Text = "�༭����ļ�"
                Me.lnkCZCYQPWJ.Enabled = blnEditMode And (objBaseFlowRenshiLuyong.HJWJ <> "")
                Me.lnkCZCYZSWJ.Enabled = blnEditMode And (objBaseFlowRenshiLuyong.PJYJ <> "")

                '�ļ�����
                Me.mnuMain.FindItemById("mnuFILE_BCWJ").Enabled = blnEditMode
                Me.mnuMain.FindItemById("mnuFILE_QXXG").Enabled = blnEditMode

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showModuleData_EditMode = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾǩ���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ����ǰ�༭״̬
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showOpinion( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseFlowRenshiLuyong As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
            Dim objOpinionData As Josco.JsKernal.Common.Data.FlowData
            Dim strQSYJ As String = ""
            Dim strBJYJ As String = ""
            Dim strYJLX As String = ""

            showOpinion = False

            Try
                objBaseFlowRenshiLuyong = CType(Me.m_objsystemFlowObjectRenshiLuyong.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)

                '��ȡ�ɲ鿴�����
                If Me.m_objsystemFlowObjectRenshiLuyong.getOpinionData(strErrMsg, MyBase.UserXM, objOpinionData) = False Then
                    GoTo errProc
                End If

                '��ʾǩ�����
                strYJLX = objBaseFlowRenshiLuyong.TASK_QFWJ
                If Me.m_objsystemFlowObjectRenshiLuyong.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblQFYJ.Text = strQSYJ
                Me.lnkCZQSYJ_QFBJ.Visible = Not blnEditMode And (strBJYJ <> "")

                '��ʾ�������
                strYJLX = objBaseFlowRenshiLuyong.TASK_FHWJ
                If Me.m_objsystemFlowObjectRenshiLuyong.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblFHYJ.Text = strQSYJ
                Me.lnkCZQSYJ_FHBJ.Visible = Not blnEditMode And (strBJYJ <> "")

                '��ʾ��ǩ���
                strYJLX = objBaseFlowRenshiLuyong.TASK_HQWJ
                If Me.m_objsystemFlowObjectRenshiLuyong.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblHQYJ.Text = strQSYJ
                Me.lnkCZQSYJ_HQBJ.Visible = Not blnEditMode And (strBJYJ <> "")

                '��ʾ������
                strYJLX = objBaseFlowRenshiLuyong.TASK_SHWJ
                If Me.m_objsystemFlowObjectRenshiLuyong.getOpinion(strErrMsg, objOpinionData, strYJLX, strQSYJ, strBJYJ) = False Then
                    GoTo errProc
                End If
                strQSYJ = objPulicParameters.doConvertToHtml(strQSYJ)
                Me.lblSHYJ.Text = strQSYJ
                Me.lnkCZQSYJ_SHBJ.Visible = Not blnEditMode And (strBJYJ <> "")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.FlowData.SafeRelease(objOpinionData)

            showOpinion = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.FlowData.SafeRelease(objOpinionData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾ����ģ�����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ����ǰ�༭״̬
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_Main( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            showModuleData_Main = False

            Try
                '��ʾ���봰��Ϣ
                If Me.showEditPanelInfo(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If

                '��ʾ�����Ϣ
                If Me.showOpinion(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If

                '��ʾ��������
                If blnEditMode = True Then
                    If Me.showModuleData_EditMode(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    If Me.showModuleData_ReadMode(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

                '��������״̬��������
                Me.doSetVisibleCommands()

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
        ' ��ȡ��ǰ��¼������ֵ
        '     strErrMsg      �����ش�����Ϣ
        '     objNewData     �����ص�ǰ��¼������ֵ��NameValueCollection
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getCurrentRecordNew( _
            ByRef strErrMsg As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            objNewData = Nothing

            Try
                objNewData = New System.Collections.Specialized.NameValueCollection

                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJBS, Me.htxtWJBS.Value)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_LSH, Me.txtLSH.Text)

                If Me.chkDDSZ.Checked = True Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_DDSZ, "1")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_DDSZ, "0")
                End If

                If Me.ddlJJCD.SelectedIndex < 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JJCD, "")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JJCD, Me.ddlJJCD.SelectedItem.Text)
                End If

                If Me.ddlMMDJ.SelectedIndex < 0 Then
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_MMDJ, "")
                Else
                    objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_MMDJ, Me.ddlMMDJ.SelectedItem.Text)
                End If

                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JGDZ, Me.txtJGDZ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJNF, Me.txtWJNF.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJXH, Me.txtWJXH.Text)

                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JBRY, Me.txtJBRY.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JBRQ, Me.txtJBRQ.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JBDW, Me.txtJBDW.Text)

                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJBT, Me.txtWJBT.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_DBRS, Me.txtDBRS.Text)
                objNewData.Add(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_BZXX, Me.txtBZXX.Text)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getCurrentRecordNew = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objNewData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���õ�ǰ��¼������ֵ
        '     strErrMsg      �����ش�����Ϣ
        '     objNewData     ����ǰ��¼������ֵ��NameValueCollection
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function setCurrentRecordNew( _
            ByRef strErrMsg As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess

            Try
                Me.htxtWJBS.Value = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJBS), "")
                Me.txtLSH.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_LSH), "")
                If objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_DDSZ), 0) = 1 Then
                    Me.chkDDSZ.Checked = True
                Else
                    Me.chkDDSZ.Checked = False
                End If

                Me.ddlJJCD.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlJJCD, objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JJCD), ""))
                Me.ddlMMDJ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlMMDJ, objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_MMDJ), ""))

                Me.txtJGDZ.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JGDZ), "")
                Me.txtWJNF.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJNF), "")
                Me.txtWJXH.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJXH), "")

                Me.txtJBRY.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JBRY), "")
                Me.txtJBRQ.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JBRQ), "")
                Me.txtJBDW.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JBDW), "")

                Me.txtWJBT.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJBT), "")
                Me.txtDBRS.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_DBRS), "")
                Me.txtBZXX.Text = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_BZXX), "")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)

            setCurrentRecordNew = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ɾ�����ػ����ص�Web����������ʱ�ļ�
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doDeleteCacheFile(ByRef strErrMsg As String) As Boolean

            doDeleteCacheFile = False

            If Me.doDeleteCacheFile_GJ(strErrMsg) = False Then
                '���Բ��ɹ����γ������ļ���
            End If
            If Me.m_objsystemFlowObjectRenshiLuyong.doDeleteCacheFile_FJ(strErrMsg, Me.m_objDataSet_FJ) = False Then
                '���Բ��ɹ����γ������ļ���
            End If
            If Me.m_objsystemFlowObjectRenshiLuyong.doDeleteCacheFile_XGWJ(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
                '���Բ��ɹ����γ������ļ���
            End If

            doDeleteCacheFile = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ɾ���������ļ�
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doDeleteCacheFile_GJ(ByRef strErrMsg As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            doDeleteCacheFile_GJ = False

            Try
                If Me.m_strGJFileName <> "" Then
                    'ɾ����ʱ�����ļ�
                    Dim strGJPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                    Dim strFilePath As String = objBaseLocalFile.doMakePath(strGJPath, Me.m_strGJFileName)
                    If objBaseLocalFile.doDeleteFile(strErrMsg, strFilePath) = False Then
                        '���Բ��ɹ���������������
                    End If
                End If

                'ǿ�����»�ȡ�ļ���
                Me.htxtZWNRFileName.Value = ""
                Me.m_strGJFileName = ""

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            doDeleteCacheFile_GJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʼ���ؼ�
        '----------------------------------------------------------------
        Private Function initializeControls(ByRef strErrMsg As String) As Boolean

            initializeControls = False

            Try
                Dim strWJBS As String = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS

                '���ڵ�һ�ε���ҳ��ʱִ��
                If Me.IsPostBack = False Then
                    '��ʾPannel(�����Ƿ�ص���ʼ����ʾpanelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                    With New Josco.JsKernal.web.ControlProcess
                        .doTranslateKey(Me.ddlJJCD)
                        .doTranslateKey(Me.ddlMMDJ)
                        .doTranslateKey(Me.txtJGDZ)
                        .doTranslateKey(Me.txtWJNF)
                        .doTranslateKey(Me.txtWJXH)
                        .doTranslateKey(Me.txtWJBT)
                        .doTranslateKey(Me.txtDBRS)
                        .doTranslateKey(Me.txtBZXX)
                        .doTranslateKey(Me.txtJBDW)
                        .doTranslateKey(Me.txtJBRY)
                        .doTranslateKey(Me.txtJBRQ)
                        .doTranslateKey(Me.txtLSH)

                        .doTranslateKey(Me.txtJLBH)
                        .doTranslateKey(Me.txtRYDM)
                        .doTranslateKey(Me.txtRYXM)
                        .doTranslateKey(Me.txtRYNN)
                        .doTranslateKey(Me.txtNFPBM)
                        .doTranslateKey(Me.txtNDRZW)
                        .doTranslateKey(Me.txtNBDRQ)
                        .doTranslateKey(Me.txtZPSM)
                        .doTranslateKey(Me.txtXYRYS)
                        .doTranslateKey(Me.txtDBRYS)
                        .doTranslateKey(Me.ddlXL)
                    End With
                End If

                If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

                If Me.getModuleData_FJ(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_FJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                If Me.getModuleData_XGWJ(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_XGWJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                If Me.getModuleData_RYXX(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_RYXX(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            initializeControls = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��䡰���ܵȼ��������б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doFillMMDJList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.MimidengjiData.TABLE_GW_B_MIMIDENGJI
            Dim objsystemMimidengji As New Josco.JsKernal.BusinessFacade.systemMimidengji
            Dim objMimidengjiData As Josco.JsKernal.Common.Data.MimidengjiData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillMMDJList = False
            strErrMsg = ""

            Try
                '���
                If objDropDownList Is Nothing Then
                    strErrMsg = "����[doFillMMDJList]�ӿڲ�������ȷ��"
                    GoTo errProc
                End If

                '��ȡ����
                If objsystemMimidengji.getMimidengjiData(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objMimidengjiData) = False Then
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
                With objMimidengjiData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.MimidengjiData.FIELD_GW_B_MIMIDENGJI_MMDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.MimidengjiData.FIELD_GW_B_MIMIDENGJI_MMDJ), "")

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

            Josco.JsKernal.BusinessFacade.systemMimidengji.SafeRelease(objsystemMimidengji)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.MimidengjiData.SafeRelease(objMimidengjiData)

            doFillMMDJList = True
            Exit Function

errProc:
            Josco.JsKernal.BusinessFacade.systemMimidengji.SafeRelease(objsystemMimidengji)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.MimidengjiData.SafeRelease(objMimidengjiData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��䡰�����̶ȡ������б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doFillJJCDList( _
            ByRef strErrMsg As String, _
            ByVal objDropDownList As System.Web.UI.WebControls.DropDownList) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.JinjichengduData.TABLE_GW_B_JINJICHENGDU
            Dim objsystemJinjichengdu As New Josco.JsKernal.BusinessFacade.systemJinjichengdu
            Dim objJinjichengduData As Josco.JsKernal.Common.Data.JinjichengduData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            doFillJJCDList = False
            strErrMsg = ""

            Try
                '���
                If objDropDownList Is Nothing Then
                    strErrMsg = "����[doFillJJCDList]�ӿڲ�������ȷ��"
                    GoTo errProc
                End If

                '��ȡ����
                If objsystemJinjichengdu.getJinjichengduData(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objJinjichengduData) = False Then
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
                With objJinjichengduData.Tables(strTable)
                    intCount = .Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strCode = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.JinjichengduData.FIELD_GW_B_JINJICHENGDU_JJDM), "")
                        strName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.JinjichengduData.FIELD_GW_B_JINJICHENGDU_JJCD), "")

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

            Josco.JsKernal.BusinessFacade.systemJinjichengdu.SafeRelease(objsystemJinjichengdu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.JinjichengduData.SafeRelease(objJinjichengduData)

            doFillJJCDList = True
            Exit Function

errProc:
            Josco.JsKernal.BusinessFacade.systemJinjichengdu.SafeRelease(objsystemJinjichengdu)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.JinjichengduData.SafeRelease(objJinjichengduData)
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
                        objListItem.Text = strName
                        objListItem.Value = strName
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

            doFillXueliList = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objestateRenshiGeneralData)
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

                '����б��
                If Me.IsPostBack = False Then
                    If Me.doFillJJCDList(strErrMsg, Me.ddlJJCD) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillMMDJList(strErrMsg, Me.ddlMMDJ) = False Then
                        GoTo errProc
                    End If
                    If Me.doFillXueliList(strErrMsg, Me.ddlXL) = False Then
                        GoTo errProc
                    End If
                End If

                '��ȡ�ӿڲ���
                Dim blnContinue As Boolean
                If Me.getInterfaceParameters(strErrMsg, blnContinue) = False Then
                    GoTo errProc
                End If
                If blnContinue = False Then
                    Exit Try
                End If

                '�ؼ���ʼ��
                If Me.initializeControls(strErrMsg) = False Then
                    GoTo errProc
                End If

                '�Ƿ񵯳����ս���
                If Me.IsPostBack = False And Me.m_blnSaveScence = False Then
                    '�״ν���
                    If Me.m_blnEditMode = False Then
                        '�鿴ģʽ
                        If Me.m_objInterface.iWJBS <> "" Then
                            '�Զ�����Լ����ļ�����
                            If Me.m_objsystemFlowObjectRenshiLuyong.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                                GoTo errProc
                            End If
                        End If
                        If Me.m_objsystemFlowObjectRenshiLuyong.mlJSWJ = True Then
                            '�Զ������ļ�
                            Me.htxtSelectMenuID.Value = "mnuJJCL_JSWJ"
                            If Me.doReceiveFile(strErrMsg, "lnkMenu") = False Then
                                GoTo errProc
                            End If
                        End If
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

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Josco.JSOA.BusinessFacade.systemFlowObjectRenshiLuyong.SafeRelease(Me.m_objsystemFlowObjectRenshiLuyong)
        End Sub











        '----------------------------------------------------------------
        '�����¼�������
        '----------------------------------------------------------------
        'ʵ�ֶ�grdFJ�����С��еĹ̶�
        Sub grdFJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdFJ.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_FJ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_FJ > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_FJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdFJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdFJ_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdFJ.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '��λ
                Me.grdFJ.SelectedIndex = e.Item.ItemIndex

                '����
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        '�򿪸������ݲ鿴��༭
                        If Me.m_blnEditMode = True Then
                            '�༭ģʽ��
                            If Me.doOpenFJ(strErrMsg, strControlId, True, False) = False Then
                                GoTo errProc
                            End If
                        Else
                            '�鿴ģʽ��
                            Dim blnAutoEnter As Boolean
                            If Me.m_objsystemFlowObjectRenshiLuyong.getCanAutoEnterEditMode( _
                                strErrMsg, _
                                MyBase.UserId, _
                                Me.m_blnEditMode, _
                                Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled, _
                                Me.m_blnEnforeEdit, _
                                blnAutoEnter) = False Then
                                GoTo errProc
                            End If
                            If Me.doOpenFJ(strErrMsg, strControlId, blnAutoEnter, blnAutoEnter) = False Then
                                GoTo errProc
                            End If
                        End If

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

        'ʵ�ֶ�grdXGWJ�����С��еĹ̶�
        Sub grdXGWJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdXGWJ.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_XGWJ + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_XGWJ > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_XGWJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdXGWJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdXGWJ_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdXGWJ.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '��λ
                Me.grdXGWJ.SelectedIndex = e.Item.ItemIndex

                '����
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        '�򿪸������ݲ鿴��༭
                        If Me.m_blnEditMode = True Then
                            '�༭ģʽ��
                            If Me.doOpenXGWJ(strErrMsg, strControlId, True, False) = False Then
                                GoTo errProc
                            End If
                        Else
                            '�鿴ģʽ��
                            Dim blnAutoEnter As Boolean
                            If Me.m_objsystemFlowObjectRenshiLuyong.getCanAutoEnterEditMode( _
                                strErrMsg, _
                                MyBase.UserId, _
                                Me.m_blnEditMode, _
                                Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled, _
                                Me.m_blnEnforeEdit, _
                                blnAutoEnter) = False Then
                                GoTo errProc
                            End If
                            If Me.doOpenXGWJ(strErrMsg, strControlId, blnAutoEnter, blnAutoEnter) = False Then
                                GoTo errProc
                            End If
                        End If

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

        'ʵ�ֶ�grdRYXX�����С��еĹ̶�
        Sub grdRYXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdRYXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_RYXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_RYXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_RYXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdRYXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        'zengxianglin 2009-05-21
        Private Sub grdRYXX_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdRYXX.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '��λ
                Me.grdRYXX.SelectedIndex = e.Item.ItemIndex

                '����
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        Me.doOpen_Grll(strControlId)
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
        'zengxianglin 2009-05-21














        Private Function doRefreshData(ByRef strErrMsg As String) As Boolean

            doRefreshData = False

            Try
                '��������������
                Dim strWJBS As String = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                Josco.JSOA.BusinessFacade.systemFlowObjectRenshiLuyong.SafeRelease(Me.m_objsystemFlowObjectRenshiLuyong)

                If Me.getModuleData_Main(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

                If Me.getModuleData_FJ(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_FJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                If Me.getModuleData_XGWJ(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_XGWJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                If Me.getModuleData_RYXX(strErrMsg, strWJBS) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_RYXX(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doRefreshData = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ֱ�Ӵ򿪸������ݽ��в鿴��༭
        '     strErrMsg            �����ش�����Ϣ
        '     strControlId         ������ÿؼ����뱾����
        '     blnEditMode          ��=True���༭,False-�鿴
        '     blnAutoSave          ��=True���˳���������ʱ�Զ����渽�����ݵ����ݿ⣬False-�����浽���ݿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Private Function doOpenFJ( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal blnEditMode As Boolean, _
            ByVal blnAutoSave As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            Dim objIFlowFujianInfo As Josco.JsKernal.BusinessFacade.IFlowFujianInfo
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim objDataRow As System.Data.DataRow

            doOpenFJ = False

            Try
                '���
                If Me.grdFJ.SelectedIndex < 0 Then
                    strErrMsg = "����û�е�ǰ������Ϣ��"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_FJ.Tables(Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    intRow = objDataGridProcess.getRecordPosition(Me.grdFJ.SelectedIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                End With
                If objDataRow Is Nothing Then
                    strErrMsg = "����û��ѡ��Ҫ�򿪵ĸ�����"
                    GoTo errProc
                End If

                '����ļ��Ƿ��͹���
                Dim blnHasSendOnce As Boolean
                If Me.m_objsystemFlowObjectRenshiLuyong.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                objIFlowFujianInfo = New Josco.JsKernal.BusinessFacade.IFlowFujianInfo
                With objIFlowFujianInfo
                    'һ����Ϣ
                    If blnEditMode = True Then
                        .iEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    Else
                        .iEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    End If
                    .iEnforeEdit = Me.m_blnEnforeEdit
                    .iAutoSave = blnAutoSave
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiLuyong.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iRow = objDataRow
                    .iWJXH = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XSXH), "")
                    .iWJWZ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ), "")
                    .iWJSM = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM), "")
                    .iWJYS = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS), "")
                    .iBDWJ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ), "")

                    .iSourceControlId = strControlId
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
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowFujianInfo)
                strUrl = ""
                strUrl += "../../flow/flow_fujian_info.aspx"
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
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doOpenFJ = True
            Exit Function

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doRefresh(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            doRefresh = False
            strErrMsg = ""

            Try
                If Me.doRefreshData(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doRefresh = True
            Exit Function

errProc:
            Exit Function

        End Function

        Private Function doCancel(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doCancel = False
            strErrMsg = ""

            Try
                'ѯ��
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "���棺��ȷ��Ҫȡ��¼�����������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '���ش���
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    Select Case Me.m_objInterface.iEditMode
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '���������ʱ��ֱ���˻�

                            '��������ļ�
                            If Me.doDeleteCacheFile(strErrMsg) = False Then
                                '���Բ��ɹ����γ������ļ���
                            End If

                            '���÷��ز���
                            Me.m_objInterface.oExitMode = False
                            '���ص�����ģ�飬�����ӷ��ز���
                            'Ҫ���ص�SessionId
                            Dim strSessionId As String
                            strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                            'SessionId���ӵ����ص�Url
                            Dim strUrl As String
                            strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                            '�ͷ�ģ����Դ
                            Me.releaseModuleParameters()
                            Me.releaseInterfaceParameters()
                            '����
                            Response.Redirect(strUrl)
                        Case Else
                            '����ļ��༭����
                            If Me.m_objsystemFlowObjectRenshiLuyong.doLockFile(strErrMsg, "", False) = False Then
                                GoTo errProc
                            End If

                            '����鿴״̬
                            Me.m_objInterface.iEditMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                            Dim intTemp As Integer = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                            Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                            Me.htxtEditType.Value = intTemp.ToString()
                            Me.m_blnEditMode = False
                            Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()

                            'ǿ�����»�ȡ�ļ���
                            If Me.doDeleteCacheFile(strErrMsg) = False Then
                                '���Բ��ɹ����γ������ļ���
                            End If

                            'ˢ����ʾ
                            If Me.doRefreshData(strErrMsg) = False Then
                                GoTo errProc
                            End If
                    End Select
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doCancel = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doClose(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            doClose = False
            strErrMsg = ""

            Try
                '��������ļ�
                If Me.doDeleteCacheFile(strErrMsg) = False Then
                    '���Բ��ɹ����γ������ļ���
                End If

                '���÷��ز���
                Me.m_objInterface.oExitMode = False
                '���ص�����ģ�飬�����ӷ��ز���
                'Ҫ���ص�SessionId
                Dim strSessionId As String
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                'SessionId���ӵ����ص�Url
                Dim strUrl As String
                strUrl = Me.m_objInterface.getReturnUrl(Server, Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId, strSessionId)
                '�ͷ�ģ����Դ
                Me.releaseModuleParameters()
                Me.releaseInterfaceParameters()
                '����
                Response.Redirect(strUrl)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doClose = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �����޸��ļ�������
        '----------------------------------------------------------------
        Private Function doModify(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doModify = False
            strErrMsg = ""

            Try
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '�ļ����
                    Dim strWJBS As String = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    If strWJBS = "" Then
                        strErrMsg = "����û���ļ����б༭��"
                        GoTo errProc
                    End If

                    '�Զ�����Լ��Ը��ļ��ı༭����
                    If Me.m_objsystemFlowObjectRenshiLuyong.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                        GoTo errProc
                    End If

                    '�������
                    Dim strBMMC As String
                    Dim strRYMC As String
                    Dim blnDo As Boolean
                    If Me.m_objsystemFlowObjectRenshiLuyong.getFileLocked(strErrMsg, blnDo, strBMMC, strRYMC) = False Then
                        GoTo errProc
                    End If
                    If blnDo = True Then
                        strErrMsg = "����[" + strBMMC + "]��λ��[" + strRYMC + "]��Ա���ڱ༭���ļ������Ժ��ٽ��б༭��"
                        GoTo errProc
                    End If

                    '�Ƿ񶨸�?
                    If Me.m_blnEnforeEdit = True Then
                        Dim strTitle As String
                        strTitle = ""
                        strTitle = strTitle + "��ʾ���ļ��Ѿ����壬��������쵼����������޸��й����ݣ�"
                        strTitle = strTitle + vbCr
                        strTitle = strTitle + "    �ɰ� <��> ��ť����ǿ�б༭��"
                        strTitle = strTitle + vbCr
                        strTitle = strTitle + vbCr
                        strTitle = strTitle + "    ��ϵͳ�������Ĳ����Զ���¼������"
                        strTitle = strTitle + vbCr
                        strTitle = strTitle + vbCr
                        strTitle = strTitle + "    Ҫ�鿴ϵͳ��¼������밴<�鿴��־>��"
                        objMessageProcess.doConfirmMessage(Me.popMessageObject, strTitle, strControlId, intStep)
                        Exit Try
                    End If
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '����༭״̬
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��ȡӦ����Ϣ
                    Dim blnOK As Boolean = True

                    '׼���༭
                    If blnOK = True Then
                        '���б༭����
                        If Me.m_objsystemFlowObjectRenshiLuyong.doLockFile(strErrMsg, MyBase.UserId, True) = False Then
                            GoTo errProc
                        End If

                        '����༭״̬
                        Me.m_objInterface.iEditMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Dim intTemp As Integer = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                        Me.htxtEditType.Value = intTemp.ToString()
                        Me.m_blnEditMode = True
                        Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()

                        'ǿ�����»�ȡ�ļ���
                        If Me.doDeleteCacheFile(strErrMsg) = False Then
                            '���Բ��ɹ����γ������ļ���
                        End If

                        '������ʾ
                        If Me.doRefreshData(strErrMsg) = False Then
                            GoTo errProc
                        End If
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doModify = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doSave(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
            Dim objNewData As System.Collections.Specialized.NameValueCollection
            Dim objOldData As Josco.JsKernal.Common.Workflow.BaseFlowObject
            Dim strWJBS As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objParams As New System.Collections.Specialized.ListDictionary
            Dim objOldXGWJData As Josco.JsKernal.Common.Data.FlowData
            Dim objOldFJData As Josco.JsKernal.Common.Data.FlowData

            doSave = False
            strErrMsg = ""

            Try
                '��ȡ��¼��ֵ
                If Me.getCurrentRecordNew(strErrMsg, objNewData) = False Then
                    GoTo errProc
                End If

                '��ȡ��¼��ֵ
                objOldData = Me.m_objsystemFlowObjectRenshiLuyong.FlowData
                objenumEditType = Me.m_objInterface.iEditMode

                '��ȡ����ļ�
                Dim strGJPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                Dim strGJFile As String = Me.m_strGJFileName
                If strGJFile <> "" Then
                    strGJFile = objBaseLocalFile.doMakePath(strGJPath, strGJFile)
                End If

                '��ȡԭ����������ļ�����
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                    Case Else
                        If Me.m_objsystemFlowObjectRenshiLuyong.getFujianData(strErrMsg, objOldFJData) = False Then
                            GoTo errProc
                        End If
                        If Me.m_objsystemFlowObjectRenshiLuyong.getXgwjData(strErrMsg, objOldXGWJData) = False Then
                            GoTo errProc
                        End If
                End Select

                '׼���������
                objParams.Clear()
                objParams.Add(0, Me.m_objDataSet_RYXX)

                '��������
                With Me.m_objsystemFlowObjectRenshiLuyong
                    If .doSaveFileVariantParam( _
                        strErrMsg, _
                        MyBase.UserId, MyBase.UserPassword, _
                        MyBase.UserXM, _
                        .pmEnforeEdit, _
                        objNewData, objOldData, objenumEditType, _
                        strGJFile, _
                        Me.m_objDataSet_FJ, Me.m_objDataSet_XGWJ, objParams) = False Then
                        GoTo errProc
                    End If
                End With
                strWJBS = objNewData(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJBS)

                'д�����־
                Select Case Me.m_objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        If Me.m_objsystemFlowObjectRenshiLuyong.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "������[" + strWJBS + "]�ļ���") = False Then
                            '����
                        End If
                    Case Else
                        If Me.m_objsystemFlowObjectRenshiLuyong.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�Ķ���[" + strWJBS + "]�ļ���") = False Then
                            '����
                        End If
                        If Me.m_objsystemFlowObjectRenshiLuyong.doWriteUserLog_Fujian(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, Me.m_objDataSet_FJ, objOldFJData) = False Then
                            '����
                        End If
                        If Me.m_objsystemFlowObjectRenshiLuyong.doWriteUserLog_XGWJ(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, Me.m_objDataSet_XGWJ, objOldXGWJData) = False Then
                            '����
                        End If
                End Select

                '����鿴״̬
                Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS = strWJBS
                Me.m_objInterface.iEditMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                Me.m_objInterface.iWJBS = strWJBS
                Dim intTemp As Integer = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                Me.m_objenumEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                Me.htxtEditType.Value = intTemp.ToString()
                Me.m_blnEditMode = False
                Me.htxtEditMode.Value = Me.m_blnEditMode.ToString()

                'ǿ�����»�ȡ�ļ���
                If Me.doDeleteCacheFile(strErrMsg) = False Then
                    '���Բ��ɹ����γ������ļ���
                End If

                'ˢ����ʾ
                If Me.doRefreshData(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objParams)
            Josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            Josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldFJData)

            doSave = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objParams)
            Josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            Josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldFJData)
            Exit Function

        End Function

        Private Sub doOpenFJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowFujian As Josco.JsKernal.BusinessFacade.IFlowFujian
            Dim blnHasSendOnce As Boolean = False
            Dim strNewSessionId As String
            Dim strSessionId As String

            Try
                '�ļ����͹���
                If Me.m_objsystemFlowObjectRenshiLuyong.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                objIFlowFujian = New Josco.JsKernal.BusinessFacade.IFlowFujian
                With objIFlowFujian
                    'һ����Ϣ
                    If Me.m_blnEditMode = True Then
                        .iEditMode = Me.m_blnEditMode
                        .iAutoSave = False
                    Else
                        Dim blnAutoEnter As Boolean
                        If Me.m_objsystemFlowObjectRenshiLuyong.getCanAutoEnterEditMode( _
                            strErrMsg, _
                            MyBase.UserId, _
                            Me.m_blnEditMode, _
                            Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled, _
                            Me.m_blnEnforeEdit, _
                            blnAutoEnter) = False Then
                            GoTo errProc
                        End If
                        .iEditMode = blnAutoEnter
                        .iAutoSave = blnAutoEnter
                    End If
                    .iEnforeEdit = Me.m_blnEnforeEdit
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiLuyong.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iDataSet_FJ = Me.m_objDataSet_FJ

                    .iSourceControlId = strControlId
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
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowFujian)
                strUrl = ""
                strUrl += "../../flow/flow_fujian.aspx"
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

        '----------------------------------------------------------------
        ' ֱ�Ӵ򿪾��������ļ��ĸ������ݽ��в鿴��༭
        '     strErrMsg            �����ش�����Ϣ
        '     strControlId         ������ÿؼ����뱾����
        '     blnEditMode          ��=True���༭,False-�鿴
        '     blnAutoSave          ��=True���˳���������ʱ�Զ����渽�����ݵ����ݿ⣬False-�����浽���ݿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Private Function doOpenXGWJ_FJ( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal blnEditMode As Boolean, _
            ByVal blnAutoSave As Boolean) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            Dim objIFlowXgwjfjInfo As Josco.JsKernal.BusinessFacade.IFlowXgwjfjInfo
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim objDataRow As System.Data.DataRow

            doOpenXGWJ_FJ = False

            Try
                '���
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "����û�е�ǰ������Ϣ��"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(Me.grdXGWJ.SelectedIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                End With
                If objDataRow Is Nothing Then
                    strErrMsg = "����û��ѡ��Ҫ�򿪵ĸ�����"
                    GoTo errProc
                End If

                '����ļ��Ƿ��͹���
                Dim blnHasSendOnce As Boolean
                If Me.m_objsystemFlowObjectRenshiLuyong.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                objIFlowXgwjfjInfo = New Josco.JsKernal.BusinessFacade.IFlowXgwjfjInfo
                With objIFlowXgwjfjInfo
                    'һ����Ϣ
                    If blnEditMode = True Then
                        .iEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    Else
                        .iEditType = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    End If
                    .iEnforeEdit = Me.m_blnEnforeEdit
                    .iAutoSave = blnAutoSave
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiLuyong.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iRow = objDataRow
                    .iWJXH = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH), "")
                    .iWJWZ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ), "")
                    .iWJSM = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT), "")
                    .iWJYS = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJYS), "")
                    .iBDWJ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ), "")

                    .iSourceControlId = strControlId
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
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowXgwjfjInfo)
                strUrl = ""
                strUrl += "../../flow/flow_xgwjfj_info.aspx"
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
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doOpenXGWJ_FJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���ļ�
        '     strErrMsg      �����ش�����Ϣ
        '     strControlId   ����ǰ�����ؼ�ID
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doOpenXGWJ_LJ( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject

            Dim strISessionId As String = ""
            Dim strMSessionId As String = ""
            Dim strUrl As String

            doOpenXGWJ_LJ = False

            Try
                '��鵱ǰѡ��
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "����û�е�ǰ�ļ���"
                    GoTo errProc
                End If

                '��ȡ�ļ���ʶ���ļ�����
                Dim strFlowTypeName As String
                Dim strWJBS As String
                Dim strNGR As String
                Dim intColIndex(3) As Integer
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdXGWJ, Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBS)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdXGWJ, Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJLX)
                intColIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdXGWJ, Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_NGR)
                strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdXGWJ.Items(Me.grdXGWJ.SelectedIndex), intColIndex(0))
                strFlowTypeName = objDataGridProcess.getDataGridCellValue(Me.grdXGWJ.Items(Me.grdXGWJ.SelectedIndex), intColIndex(1))
                strNGR = objDataGridProcess.getDataGridCellValue(Me.grdXGWJ.Items(Me.grdXGWJ.SelectedIndex), intColIndex(2))
                If strWJBS = "" Then
                    strErrMsg = "����û�е�ǰ�ļ���"
                    GoTo errProc
                End If
                If strFlowTypeName = "" Then
                    strErrMsg = "���󣺵�ǰ�ļ����Ͳ���ȷ��"
                    GoTo errProc
                End If

                '����ָ������������
                Dim strType As String
                Dim strName As String
                strType = Josco.JsKernal.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                strName = strFlowTypeName
                objsystemFlowObject = Josco.JsKernal.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, False) = False Then
                    GoTo errProc
                End If

                '����ļ��Ƿ��ܿ���
                Dim blnCanRead As Boolean
                If objsystemFlowObject.canReadFile(strErrMsg, MyBase.UserXM, blnCanRead) = False Then
                    GoTo errProc
                End If
                '������ܿ�����������Զ���MyBase.UserXM����
                If blnCanRead = False Then
                    If strNGR Is Nothing Then strNGR = ""
                    strNGR = strNGR.Trim
                    If strNGR = "" Then
                        strErrMsg = "�����޷�ȷ���ļ���ʼ�����ˣ�"
                        GoTo errProc
                    End If
                    If objsystemFlowObject.doSendBuyueJJD(strErrMsg, strNGR, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If
                End If

                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If
                strISessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)

                '����Url
                If objsystemFlowObject.doFileOpen( _
                    strErrMsg, _
                    strControlId, _
                    strWJBS, _
                    strMSessionId, _
                    strISessionId, _
                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect, _
                    Request, Session, _
                    strUrl) = False Then
                    GoTo errProc
                End If
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doOpenXGWJ_LJ = True
            Exit Function
errProc:
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ֱ�Ӵ򿪾��������ļ����ݽ��в鿴��༭
        '     strErrMsg            �����ش�����Ϣ
        '     strControlId         ������ÿؼ����뱾����
        '     blnEditMode          ��=True���༭,False-�鿴
        '     blnAutoSave          ��=True���˳���������ʱ�Զ����渽�����ݵ����ݿ⣬False-�����浽���ݿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Private Function doOpenXGWJ( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal blnEditMode As Boolean, _
            ByVal blnAutoSave As Boolean) As Boolean

            Dim strTable As String = Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            Dim objDataRow As System.Data.DataRow

            doOpenXGWJ = False

            Try
                '���
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "����û�е�ǰ������Ϣ��"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(Me.grdXGWJ.SelectedIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                End With
                If objDataRow Is Nothing Then
                    strErrMsg = "����û��ѡ��Ҫ�򿪵ĸ�����"
                    GoTo errProc
                End If
                Dim intLB As Integer
                intLB = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LBBS), 0)

                '���ദ��
                Select Case intLB
                    Case Josco.JsKernal.Common.Data.FlowData.enumXGWJLB.FlowFile
                        '�򿪹������ļ�
                        If Me.doOpenXGWJ_LJ(strErrMsg, strControlId) = False Then
                            GoTo errProc
                        End If
                    Case Josco.JsKernal.Common.Data.FlowData.enumXGWJLB.FujianFile
                        '������ļ�����
                        If Me.doOpenXGWJ_FJ(strErrMsg, strControlId, blnEditMode, blnAutoSave) = False Then
                            GoTo errProc
                        End If
                    Case Else
                        strErrMsg = "������Ч�����ͣ�"
                        GoTo errProc
                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doOpenXGWJ = True
            Exit Function

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Sub doOpenXGWJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowXgwj As Josco.JsKernal.BusinessFacade.IFlowXgwj
            Dim blnHasSendOnce As Boolean = False
            Dim strNewSessionId As String
            Dim strSessionId As String

            Try
                '�ļ����͹���
                If Me.m_objsystemFlowObjectRenshiLuyong.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
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
                objIFlowXgwj = New Josco.JsKernal.BusinessFacade.IFlowXgwj
                With objIFlowXgwj
                    'һ����Ϣ
                    If Me.m_blnEditMode = True Then
                        .iEditMode = Me.m_blnEditMode
                        .iAutoSave = False
                    Else
                        Dim blnAutoEnter As Boolean
                        If Me.m_objsystemFlowObjectRenshiLuyong.getCanAutoEnterEditMode( _
                            strErrMsg, _
                            MyBase.UserId, _
                            Me.m_blnEditMode, _
                            Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled, _
                            Me.m_blnEnforeEdit, _
                            blnAutoEnter) = False Then
                            GoTo errProc
                        End If
                        .iEditMode = blnAutoEnter
                        .iAutoSave = blnAutoEnter
                    End If
                    .iEnforeEdit = Me.m_blnEnforeEdit
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiLuyong.swgjShowTrackRevisions And blnHasSendOnce
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iDataSet_XGWJ = Me.m_objDataSet_XGWJ

                    .iSourceControlId = strControlId
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
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowXgwj)
                strUrl = ""
                strUrl += "../../flow/flow_xgwj.aspx"
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

        '----------------------------------------------------------------
        ' ����򿪸��������
        '     strControlId         �����ջط���Ϣ�Ŀؼ�ID
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Private Sub doOpenGJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowEditWord As Josco.JsKernal.BusinessFacade.IFlowEditWord
            Dim blnHasSendOnce As Boolean = False
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strGJFile As String = ""
            Dim strUrl As String

            Try
                '�ļ����͹���
                If Me.m_objsystemFlowObjectRenshiLuyong.isFileSendOnce(strErrMsg, blnHasSendOnce) = False Then
                    GoTo errProc
                End If

                '��ȡ���
                Dim strMBPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToWordTemplate)
                Dim strGJPath As String = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                Dim strCacheFile As String = Me.m_strGJFileName
                If Me.m_objsystemFlowObjectRenshiLuyong.getGJFile(strErrMsg, Me.m_blnEditMode, strCacheFile, strMBPath, strGJPath, strGJFile) = False Then
                    GoTo errProc
                End If
                Me.htxtZWNRFileName.Value = strCacheFile
                Me.m_strGJFileName = strCacheFile

                '�����ֳ�����
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                objIFlowEditWord = New Josco.JsKernal.BusinessFacade.IFlowEditWord
                With objIFlowEditWord
                    '************************************************************************************************
                    If Me.m_blnEditMode = True Then
                        .iEditMode = Me.m_blnEditMode
                        .iAutoSave = False
                    Else
                        '���Զ��༭��
                        Dim blnAutoEnter As Boolean
                        If Me.m_objsystemFlowObjectRenshiLuyong.getCanAutoEnterEditMode( _
                            strErrMsg, _
                            MyBase.UserId, _
                            Me.m_blnEditMode, _
                            Me.mnuMain.FindItemById("mnuFILE_XGWJ").Enabled, _
                            Me.m_blnEnforeEdit, _
                            blnAutoEnter) = False Then
                            GoTo errProc
                        End If
                        .iEditMode = blnAutoEnter
                        .iAutoSave = blnAutoEnter
                    End If
                    .iEnforeEdit = Me.m_blnEnforeEdit
                    '************************************************************************************************
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    '************************************************************************************************
                    .iGJFileSpec = strGJFile
                    .iobjDataSet_FJ = Me.m_objDataSet_FJ
                    .iobjDataSet_XGWJ = Me.m_objDataSet_XGWJ
                    .iobjNewData = Nothing
                    '************************************************************************************************
                    .iCanQSYJ = Me.m_objsystemFlowObjectRenshiLuyong.mlTXYJ
                    If .iCanQSYJ = False Then
                        .iCanQSYJ = Me.m_objsystemFlowObjectRenshiLuyong.mlBDPS
                        If .iCanQSYJ = False Then
                            '����ǩ��������ӿ�ȱʡ����
                        Else
                            '�����쵼��ʾ
                            .iDLR = MyBase.UserXM
                            .iDLRDM = MyBase.UserId
                            .iDLRBMDM = MyBase.UserBmdm
                            .iSPR = ""
                        End If
                    Else
                        '�Լ�ǩ�����
                        .iDLR = ""
                        .iDLRDM = ""
                        .iDLRBMDM = ""
                        .iSPR = MyBase.UserXM
                    End If
                    '************************************************************************************************
                    '���������Ʋ���
                    .iTrackRevisions = Me.m_objsystemFlowObjectRenshiLuyong.swgjShowTrackRevisions And blnHasSendOnce
                    .iCanExportGJ = Me.m_objsystemFlowObjectRenshiLuyong.swgjExportFile
                    .iCanImportGJ = Me.m_objsystemFlowObjectRenshiLuyong.swgjImportFile
                    .iCanSelectTGWJ = Me.m_objsystemFlowObjectRenshiLuyong.swgjSelectGJ
                    .iHasSendOnce = blnHasSendOnce

                    .iSourceControlId = strControlId
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
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowEditWord)
                strUrl = ""
                strUrl += "../../flow/flow_editword.aspx"
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

        Private Function doSendFile(ByRef strErrMsg As String, ByVal strControlId As String, ByVal blnWTFS As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doSendFile = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowSend As Josco.JsKernal.BusinessFacade.IFlowSend
                Dim strUrl As String
                objIFlowSend = New Josco.JsKernal.BusinessFacade.IFlowSend
                With objIFlowSend
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iBLR = MyBase.UserXM
                    .iWTFS = blnWTFS
                    .iDLR = ""

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowSend)
                strUrl = ""
                strUrl += "../../flow/flow_send.aspx"
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

            doSendFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doReceiveFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doReceiveFile = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowReceive As Josco.JsKernal.BusinessFacade.IFlowReceive
                Dim strUrl As String
                objIFlowReceive = New Josco.JsKernal.BusinessFacade.IFlowReceive
                With objIFlowReceive
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowReceive)
                strUrl = ""
                strUrl += "../../flow/flow_receive.aspx"
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

            doReceiveFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doShouhuiFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doShouhuiFile = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowShouhui As Josco.JsKernal.BusinessFacade.IFlowShouhui
                Dim strUrl As String
                objIFlowShouhui = New Josco.JsKernal.BusinessFacade.IFlowShouhui
                With objIFlowShouhui
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowShouhui)
                strUrl = ""
                strUrl += "../../flow/flow_shouhui.aspx"
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

            doShouhuiFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doTuihuiFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doTuihuiFile = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowTuihui As Josco.JsKernal.BusinessFacade.IFlowTuihui
                Dim strUrl As String
                objIFlowTuihui = New Josco.JsKernal.BusinessFacade.IFlowTuihui
                With objIFlowTuihui
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iCanReadFile = True

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowTuihui)
                strUrl = ""
                strUrl += "../../flow/flow_tuihui.aspx"
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

            doTuihuiFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doIReadFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            doIReadFile = False
            strErrMsg = ""

            Try
                '����
                If Me.m_objsystemFlowObjectRenshiLuyong.doIReadFile(strErrMsg, MyBase.UserXM) = False Then
                    GoTo errProc
                End If

                'ˢ������
                If Me.doRefreshData(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ��Ϣ
                objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ��֪ͨ��Ϣ���Ѿ��Ķ��ˣ�����Ϣ������ʾ��[δ������]�У�")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doIReadFile = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doIDoNotProcess(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doIDoNotProcess = False
            strErrMsg = ""

            Try
                'ѯ��
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ��[���˻ػ��ջص��ļ�]���ô�������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��������
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '����ҵ��
                    If Me.m_objsystemFlowObjectRenshiLuyong.doIDoNotProcess(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    'ˢ������
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾ��Ϣ
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ���Ѿ����˻ظ��ҵ��ļ������ջص��ļ��ɹ�����Ϊ[���ô���]��")

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doIDoNotProcess = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doICompleteTask(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doICompleteTask = False
            strErrMsg = ""

            Try
                'ѯ��
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ���Լ��������Ѿ�[�������]����/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��������
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '����ҵ��
                    If Me.m_objsystemFlowObjectRenshiLuyong.doICompleteTask(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    'ˢ������
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾ��Ϣ
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ���ɹ�����Ϊ[�������]�����ļ���������ʾ������[δ������]�У�")

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doICompleteTask = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doIStopFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doIStopFile = False
            strErrMsg = ""

            Try
                'ѯ��
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ���ļ��ݻ��������������˲��ܴ����ļ�,Ҫ��������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��������
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '����ҵ��
                    If Me.m_objsystemFlowObjectRenshiLuyong.doIStopFile(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    'ˢ������
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾ��Ϣ
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ���ļ��ɹ�����Ϊ[�ݻ�����]����������ʾ������[δ������]�У�����ʾ��[��������]�У�")

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doIStopFile = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doIContinueFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doIContinueFile = False
            strErrMsg = ""

            Try
                'ѯ��
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ���ļ��Ѿ��ݻ�������ȷ��׼�����������ļ�����/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��������
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '����ҵ��
                    If Me.m_objsystemFlowObjectRenshiLuyong.doIContinueFile(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    'ˢ������
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾ��Ϣ
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ���ļ����ڿ��Լ�������")

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doIContinueFile = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doIZuofeiFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doIZuofeiFile = False
            strErrMsg = ""

            Try
                'ѯ��
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ��Ҫ���ϱ��������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��������
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '����ҵ��
                    If Me.m_objsystemFlowObjectRenshiLuyong.doIZuofeiFile(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    'ˢ������
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾ��Ϣ
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ���Ѿ���������ϣ�������ɾ���ø����Ҳ���������øø����")

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doIZuofeiFile = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doIQiyongFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doIQiyongFile = False
            strErrMsg = ""

            Try
                'ѯ��
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ��Ҫ���ñ��������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��������
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '����ҵ��
                    If Me.m_objsystemFlowObjectRenshiLuyong.doIQiyongFile(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    'ˢ������
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾ��Ϣ
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ������Ѿ��������ã����Լ���������������")

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doIQiyongFile = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doCompleteFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doCompleteFile = False
            strErrMsg = ""

            Try
                '��鲢ѯ��
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '���
                    Dim strUserList As String
                    If Me.m_objsystemFlowObjectRenshiLuyong.getUncompleteTaskRY(strErrMsg, MyBase.UserXM, strUserList) = False Then
                        GoTo errProc
                    End If
                    If strUserList <> "" Then
                        strErrMsg = "����[" + strUserList + "]��û�д�����ϣ�����ʱ���ܰ�ᣡ"
                        GoTo errProc
                    End If

                    'ѯ��
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ���ļ�����Ͳ������κθĶ���Ҫ��������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��������
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '����ҵ��
                    If Me.m_objsystemFlowObjectRenshiLuyong.doCompleteFile(strErrMsg, MyBase.UserXM) = False Then
                        GoTo errProc
                    End If

                    'ˢ������
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾ��Ϣ
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ���ļ��ɹ���ᣡ")

                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doCompleteFile = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        Private Function doImportQPYJ(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doImportQPYJ = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowImportQP As Josco.JsKernal.BusinessFacade.IFlowImportQP
                Dim strUrl As String
                objIFlowImportQP = New Josco.JsKernal.BusinessFacade.IFlowImportQP
                With objIFlowImportQP
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iTitle = "����ǩ�����ĵ����ļ�"

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowImportQP)
                strUrl = ""
                strUrl += "../../flow/flow_importqp.aspx"
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

            doImportQPYJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doImportZSWJ(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doImportZSWJ = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowImportZS As Josco.JsKernal.BusinessFacade.IFlowImportZS
                Dim strUrl As String
                objIFlowImportZS = New Josco.JsKernal.BusinessFacade.IFlowImportZS
                With objIFlowImportZS
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iTitle = "����ǩ���ļ���ɨ���"

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowImportZS)
                strUrl = ""
                strUrl += "../../flow/flow_importzs.aspx"
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

            doImportZSWJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doCuiban(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doCuiban = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowCuiban As Josco.JsKernal.BusinessFacade.IFlowCuiban
                Dim strUrl As String
                objIFlowCuiban = New Josco.JsKernal.BusinessFacade.IFlowCuiban
                With objIFlowCuiban
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowCuiban)
                strUrl = ""
                strUrl += "../../flow/flow_cuiban.aspx"
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

            doCuiban = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doDuban(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doDuban = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowDuban As Josco.JsKernal.BusinessFacade.IFlowDuban
                Dim strUrl As String
                objIFlowDuban = New Josco.JsKernal.BusinessFacade.IFlowDuban
                With objIFlowDuban
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowDuban)
                strUrl = ""
                strUrl += "../../flow/flow_duban.aspx"
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

            doDuban = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doDubanjg(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doDubanjg = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowDubanjg As Josco.JsKernal.BusinessFacade.IFlowDubanjg
                Dim strUrl As String
                objIFlowDubanjg = New Josco.JsKernal.BusinessFacade.IFlowDubanjg
                With objIFlowDubanjg
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowDubanjg)
                strUrl = ""
                strUrl += "../../flow/flow_dubanjg.aspx"
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

            doDubanjg = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doChakanLZQK(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doChakanLZQK = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowLzqk As Josco.JsKernal.BusinessFacade.IFlowLzqk
                Dim strUrl As String
                objIFlowLzqk = New Josco.JsKernal.BusinessFacade.IFlowLzqk
                With objIFlowLzqk
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowLzqk)
                strUrl = ""
                strUrl += "../../flow/flow_lzqk.aspx"
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

            doChakanLZQK = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doChakanSPYJ(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doChakanSPYJ = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowSpyj As Josco.JsKernal.BusinessFacade.IFlowSpyj
                Dim strUrl As String
                objIFlowSpyj = New Josco.JsKernal.BusinessFacade.IFlowSpyj
                With objIFlowSpyj
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowSpyj)
                strUrl = ""
                strUrl += "../../flow/flow_spyj.aspx"
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

            doChakanSPYJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doChakanCZRZ(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doChakanCZRZ = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowCzrz As Josco.JsKernal.BusinessFacade.IFlowCzrz
                Dim strUrl As String
                objIFlowCzrz = New Josco.JsKernal.BusinessFacade.IFlowCzrz
                With objIFlowCzrz
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowCzrz)
                strUrl = ""
                strUrl += "../../flow/flow_czrz.aspx"
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

            doChakanCZRZ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doChakanCBQK(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doChakanCBQK = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowCkcbqk As Josco.JsKernal.BusinessFacade.IFlowCkcbqk
                Dim strUrl As String
                objIFlowCkcbqk = New Josco.JsKernal.BusinessFacade.IFlowCkcbqk
                With objIFlowCkcbqk
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowCkcbqk)
                strUrl = ""
                strUrl += "../../flow/flow_ckcbqk.aspx"
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

            doChakanCBQK = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doChakanDBQK(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doChakanDBQK = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowCkdbqk As Josco.JsKernal.BusinessFacade.IFlowCkdbqk
                Dim strUrl As String
                objIFlowCkdbqk = New Josco.JsKernal.BusinessFacade.IFlowCkdbqk
                With objIFlowCkdbqk
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowCkdbqk)
                strUrl = ""
                strUrl += "../../flow/flow_ckdbqk.aspx"
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

            doChakanDBQK = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doChakanBYQK(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doChakanBYQK = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowByqk As Josco.JsKernal.BusinessFacade.IFlowByqk
                Dim strUrl As String
                objIFlowByqk = New Josco.JsKernal.BusinessFacade.IFlowByqk
                With objIFlowByqk
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iBLR = MyBase.UserXM
                    .iYjjhList = ""

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowByqk)
                strUrl = ""
                strUrl += "../../flow/flow_byqk.aspx"
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

            doChakanBYQK = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doBuyue(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doBuyue = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowBycl As Josco.JsKernal.BusinessFacade.IFlowBycl
                Dim strUrl As String
                objIFlowBycl = New Josco.JsKernal.BusinessFacade.IFlowBycl
                With objIFlowBycl
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowBycl)
                strUrl = ""
                strUrl += "../../flow/flow_bycl.aspx"
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

            doBuyue = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doTianxieYijian( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal strYjlx As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            Dim blnEnabled(3) As Boolean

            doTianxieYijian = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowSpyjtx As Josco.JsKernal.BusinessFacade.IFlowSpyjtx
                Dim strUrl As String
                objIFlowSpyjtx = New Josco.JsKernal.BusinessFacade.IFlowSpyjtx
                With objIFlowSpyjtx
                    .iPromptInfo = "ע�⣺Ҫ��֤���������ȷ����ʾ����������Ӧ��Ŀ�У���ȷ������ѡ���Ƿ�ѡ����ȷ��лл��"
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iSPR = MyBase.UserXM
                    .iDLR = ""
                    .iInitYjlx = strYjlx
                    blnEnabled(0) = Me.lnkCZQSYJ_SH.Enabled
                    blnEnabled(1) = Me.lnkCZQSYJ_HQ.Enabled
                    blnEnabled(2) = Me.lnkCZQSYJ_FH.Enabled
                    blnEnabled(3) = Me.lnkCZQSYJ_QF.Enabled
                    .iYjlxEnabled = blnEnabled

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowSpyjtx)
                strUrl = ""
                strUrl += "../../flow/flow_spyjtx.aspx"
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

            doTianxieYijian = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doChakanBianjianyijian( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal strYjlx As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doChakanBianjianyijian = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowBjyj As Josco.JsKernal.BusinessFacade.IFlowBjyj
                Dim strUrl As String
                objIFlowBjyj = New Josco.JsKernal.BusinessFacade.IFlowBjyj
                With objIFlowBjyj
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iBLR = MyBase.UserXM
                    .iSPR = MyBase.UserXM
                    .iInitYjlx = strYjlx

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowBjyj)
                strUrl = ""
                strUrl += "../../flow/flow_bjyj.aspx"
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

            doChakanBianjianyijian = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doBudengYijian( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            Dim blnEnabled(3) As Boolean

            doBudengYijian = False
            strErrMsg = ""

            Try
                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowSpyjtx As Josco.JsKernal.BusinessFacade.IFlowSpyjtx
                Dim strUrl As String
                objIFlowSpyjtx = New Josco.JsKernal.BusinessFacade.IFlowSpyjtx
                With objIFlowSpyjtx
                    .iPromptInfo = "ע�⣺Ҫ��֤���������ȷ����ʾ����������Ӧ��Ŀ�У���ȷ������ѡ���Ƿ�ѡ����ȷ��лл��"
                    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS
                    .iSPR = ""
                    .iDLR = MyBase.UserXM
                    .iInitYjlx = ""
                    blnEnabled(0) = True
                    blnEnabled(1) = True
                    blnEnabled(2) = True
                    blnEnabled(3) = True
                    .iYjlxEnabled = blnEnabled

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                    strUrl += "="
                    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    strUrl += "&"
                    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                    strUrl += "="
                    strUrl += strMSessionId
                    .iReturnUrl = strUrl
                End With

                '����ģ��
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIFlowSpyjtx)
                strUrl = ""
                strUrl += "../../flow/flow_spyjtx.aspx"
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

            doBudengYijian = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doPrintGZ( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doPrintGZ = False
            strErrMsg = ""

            Try
                ''�����ֳ�����
                'strMSessionId = Me.saveModuleInformation()
                'If strMSessionId = "" Then
                '    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                '    GoTo errProc
                'End If

                ''׼�����ýӿ�
                'Dim objIEstateRsLuyongInfobpwj As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfoBpjgz
                'Dim strUrl As String
                'objIEstateRsLuyongInfobpwj = New Josco.JSOA.BusinessFacade.IEstateRsLuyongInfoBpjgz
                'With objIEstateRsLuyongInfobpwj
                '    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                '    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS

                '    .iSourceControlId = strControlId
                '    strUrl = ""
                '    strUrl += Request.Url.AbsolutePath
                '    strUrl += "?"
                '    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                '    strUrl += "="
                '    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                '    strUrl += "&"
                '    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                '    strUrl += "="
                '    strUrl += strMSessionId
                '    .iReturnUrl = strUrl
                'End With

                ''����ģ��
                'strNewSessionId = objPulicParameters.getNewGuid()
                'If strNewSessionId = "" Then
                '    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                '    GoTo errProc
                'End If
                'Session.Add(strNewSessionId, objIEstateRsLuyongInfobpwj)
                'strUrl = ""
                'strUrl += "estate_rs_luyong_info_bpjgz.aspx"
                'strUrl += "?"
                'strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                'strUrl += "="
                'strUrl += strNewSessionId
                'Response.Redirect(strUrl)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doPrintGZ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doPrintBJGZ( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            doPrintBJGZ = False
            strErrMsg = ""

            Try
                ''�����ֳ�����
                'strMSessionId = Me.saveModuleInformation()
                'If strMSessionId = "" Then
                '    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                '    GoTo errProc
                'End If

                ''׼�����ýӿ�
                'Dim objIEstateRsLuyongInfobpwj As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfoBjgz
                'Dim strUrl As String
                'objIEstateRsLuyongInfobpwj = New Josco.JSOA.BusinessFacade.IEstateRsLuyongInfoBjgz
                'With objIEstateRsLuyongInfobpwj
                '    .iFlowTypeName = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.FlowTypeName
                '    .iWJBS = Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS

                '    .iSourceControlId = strControlId
                '    strUrl = ""
                '    strUrl += Request.Url.AbsolutePath
                '    strUrl += "?"
                '    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                '    strUrl += "="
                '    strUrl += Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                '    strUrl += "&"
                '    strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                '    strUrl += "="
                '    strUrl += strMSessionId
                '    .iReturnUrl = strUrl
                'End With

                ''����ģ��
                'strNewSessionId = objPulicParameters.getNewGuid()
                'If strNewSessionId = "" Then
                '    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                '    GoTo errProc
                'End If
                'Session.Add(strNewSessionId, objIEstateRsLuyongInfobpwj)
                'strUrl = ""
                'strUrl += "estate_rs_luyong_info_bjgz.aspx"
                'strUrl += "?"
                'strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                'strUrl += "="
                'strUrl += strNewSessionId
                'Response.Redirect(strUrl)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doPrintBJGZ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doSetBwtx(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doSetBwtx = False
            strErrMsg = ""

            Try
                'ѯ��
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    'ѯ��
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ��Ҫ���б�����������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��������
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '����ҵ��
                    If Me.m_objsystemFlowObjectRenshiLuyong.doSetTaskBWTX(strErrMsg, MyBase.UserXM, True) = False Then
                        GoTo errProc
                    End If

                    '��ʾ��Ϣ
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ��ϵͳ������������ע�Ȿ�ļ��Ĵ��������")

                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doSetBwtx = True
            Exit Function
errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function












        Private Sub lnkCZQSYJ_QF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_QF.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_QF", Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_QFWJ) = False Then
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

        Private Sub lnkCZQSYJ_FH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_FH.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_FH", Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_FHWJ) = False Then
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

        Private Sub lnkCZQSYJ_HQ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_HQ.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_HQ", Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_HQWJ) = False Then
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

        Private Sub lnkCZQSYJ_SH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_SH.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doTianxieYijian(strErrMsg, "lnkCZQSYJ_SH", Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_SHWJ) = False Then
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














        Private Sub lnkCZQSYJ_SHBJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_SHBJ.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_SHBJ", Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_SHWJ) = False Then
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

        Private Sub lnkCZQSYJ_HQBJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_HQBJ.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_HQBJ", Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_HQWJ) = False Then
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

        Private Sub lnkCZQSYJ_FHBJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_FHBJ.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_FHBJ", Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_FHWJ) = False Then
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

        Private Sub lnkCZQSYJ_QFBJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZQSYJ_QFBJ.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If Me.doChakanBianjianyijian(strErrMsg, "lnkCZQSYJ_QFBJ", Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_QFWJ) = False Then
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














        Private Sub doOpenPJYJ(ByVal strControlId As String)

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon

            strErrMsg = ""

            Try
                '���
                Dim objBaseFlowRenshiLuyong As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.m_objsystemFlowObjectRenshiLuyong.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                If objBaseFlowRenshiLuyong.HJWJ = "" Then
                    strErrMsg = "���󣺻�û�е���ǩ�����ĵ����ļ���"
                    GoTo errProc
                End If

                'ǩ�����ĵ��Ӽ�
                Dim strFileSpec As String = ""
                Dim strFilePath As String = ""
                Dim strFileName As String = ""
                strFilePath = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, objBaseFlowRenshiLuyong.HJWJ, strFileSpec, strFilePath, strFileName) = False Then
                    GoTo errProc
                End If
                Dim strUrl As String
                strUrl = MyBase.UrlBase + Me.m_cstrUrlBaseToFileCache + strFileName

                '��¼���������־
                If Me.m_objsystemFlowObjectRenshiLuyong.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS + "]��[ǩ�����ĵ����ļ�]��") = False Then
                    '����
                End If

                'ǩ�����ĵ��Ӽ�
                objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doOpenZSWJ(ByVal strControlId As String)

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon

            strErrMsg = ""

            Try
                '���
                Dim objBaseFlowRenshiLuyong As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.m_objsystemFlowObjectRenshiLuyong.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                If objBaseFlowRenshiLuyong.PJYJ = "" Then
                    strErrMsg = "���󣺻�û�е���ǩ������ɨ�����"
                    GoTo errProc
                End If

                'ǩ������ɨ���
                Dim strFileSpec As String = ""
                Dim strFilePath As String = ""
                Dim strFileName As String = ""
                strFilePath = Server.MapPath(Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache)
                If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, objBaseFlowRenshiLuyong.PJYJ, strFileSpec, strFilePath, strFileName) = False Then
                    GoTo errProc
                End If
                Dim strUrl As String
                strUrl = MyBase.UrlBase + Me.m_cstrUrlBaseToFileCache + strFileName

                '��¼���������־
                If Me.m_objsystemFlowObjectRenshiLuyong.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + Me.m_objsystemFlowObjectRenshiLuyong.FlowData.WJBS + "]��[ǩ������ɨ���]��") = False Then
                    '����
                End If

                'ǩ������ɨ���
                objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub lnkCZCYFJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZCYFJ.Click
            Me.doOpenFJ("lnkCZCYFJ")
        End Sub

        Private Sub lnkCZCYGJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZCYGJ.Click
            Me.doOpenGJ("lnkCZCYGJ")
        End Sub

        Private Sub lnkCZCYXGWJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZCYXGWJ.Click
            Me.doOpenXGWJ("lnkCZCYXGWJ")
        End Sub

        Private Sub lnkCZCYQPWJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZCYQPWJ.Click
            Me.doOpenPJYJ("lnkCZCYQPWJ")
        End Sub

        Private Sub lnkCZCYZSWJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZCYZSWJ.Click
            Me.doOpenZSWJ("lnkCZCYZSWJ")
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

        Private Sub doSelect_JLBH(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
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
                Dim objIDmxzJbdm As Josco.JsKernal.BusinessFacade.IDmxzJbdm = Nothing
                Dim strUrl As String = ""
                objIDmxzJbdm = New Josco.JsKernal.BusinessFacade.IDmxzJbdm
                With objIDmxzJbdm
                    .iTitle = "ѡ��[��������]"
                    .iAllowInput = False
                    .iMultiSelect = False
                    .iAllowNull = False
                    .iRowSourceSQL = objsystemEstateRenshiXingye.getSearchSQL_JLBH()
                    .iCodeField = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYDM
                    .iNameField = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_JLBH
                    .iColWidth = "100px" + strSep + "100px" + strSep + "100px" + strSep + "80px" + strSep + "80px" + strSep + "160px" + strSep + "200px" + strSep + "140px" + strSep + "160px" + strSep + "160px" + strSep + "80px" + strSep + "160px"
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

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnSelect_ZZDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_ZZDM.Click
            Me.doSelect_ZZDM("btnSelect_ZZDM")
        End Sub

        Private Sub btnSelect_JLBH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect_JLBH.Click
            Me.doSelect_JLBH("btnSelect_JLBH")
        End Sub













        Private Sub doRYXX_AddNew(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI_RENYUANXINXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.txtRYDM.Text.Trim = "" Then
                    strErrMsg = "����û������[��Ա����]��"
                    GoTo errProc
                End If
                If Me.txtJLBH.Text.Trim = "" Then
                    strErrMsg = "����û������[�������]��"
                    GoTo errProc
                End If
                If Me.txtNBDRQ.Text.Trim <> "" Then
                    If objPulicParameters.isDatetimeString(Me.txtNBDRQ.Text) = False Then
                        strErrMsg = "����[�ⱨ������]����Ч�����ڣ�"
                        GoTo errProc
                    End If
                End If
                If Me.txtXYRYS.Text.Trim <> "" Then
                    If objPulicParameters.isIntegerString(Me.txtXYRYS.Text) = False Then
                        strErrMsg = "����[������Ա��]����Ч����ֵ��"
                        GoTo errProc
                    End If
                End If
                If Me.txtDBRYS.Text.Trim <> "" Then
                    If objPulicParameters.isIntegerString(Me.txtDBRYS.Text) = False Then
                        strErrMsg = "����[������Ա��]����Ч����ֵ��"
                        GoTo errProc
                    End If
                End If

                '����Ƿ����
                Dim strOldFilter As String = ""
                Dim strNewFilter As String = ""
                With Me.m_objDataSet_RYXX.Tables(strTable)
                    strOldFilter = .DefaultView.RowFilter

                    strNewFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_JLBH + " = '" + Me.txtJLBH.Text.Trim + "'"
                    .DefaultView.RowFilter = strNewFilter
                    If .DefaultView.Count > 0 Then
                        .DefaultView.RowFilter = strOldFilter
                        strErrMsg = "����[" + Me.txtJLBH.Text.Trim + "]�Ѿ����ڣ�"
                        GoTo errProc
                    End If

                    .DefaultView.RowFilter = strOldFilter
                End With

                '����
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_RYXX.Tables(strTable)
                    objDataRow = .NewRow()

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXH) = .Rows.Count + 1
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_WYBS) = ""
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_WJBS) = Me.htxtWJBS.Value

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYDM) = Me.txtRYDM.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_JLBH) = Me.txtJLBH.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXM) = Me.txtRYXM.Text
                    If Me.rblRYXB.SelectedIndex >= 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXB) = Me.rblRYXB.SelectedValue
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXB) = "��"
                    End If
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYNN) = objPulicParameters.getObjectValue(Me.txtRYNN.Text, 0)
                    If Me.ddlXL.SelectedIndex >= 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXL) = Me.ddlXL.SelectedValue
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXL) = ""
                    End If
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NFPBM) = Me.txtNFPBM.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NDRZW) = Me.txtNDRZW.Text
                    'zengxianglin 2008-12-17
                    If Me.txtNBDRQ.Text.Trim = "" Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NBDRQ) = System.DBNull.Value
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NBDRQ) = Me.txtNBDRQ.Text
                    End If
                    'zengxianglin 2008-12-17
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_ZPSM) = Me.txtZPSM.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_XYRYS) = objPulicParameters.getObjectValue(Me.txtXYRYS.Text, 0)
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_DBRYS) = objPulicParameters.getObjectValue(Me.txtDBRYS.Text, 0)

                    .Rows.Add(objDataRow)
                End With

                '��ʾ
                If Me.showDataGridInfo_RYXX(strErrMsg) = False Then
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

        Private Sub doRYXX_Update(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI_RENYUANXINXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.txtRYDM.Text.Trim = "" Then
                    strErrMsg = "����û������[��Ա����]��"
                    GoTo errProc
                End If
                If Me.txtJLBH.Text.Trim = "" Then
                    strErrMsg = "����û������[�������]��"
                    GoTo errProc
                End If
                If Me.txtNBDRQ.Text.Trim <> "" Then
                    If objPulicParameters.isDatetimeString(Me.txtNBDRQ.Text) = False Then
                        strErrMsg = "����[�ⱨ������]����Ч�����ڣ�"
                        GoTo errProc
                    End If
                End If
                If Me.txtXYRYS.Text.Trim <> "" Then
                    If objPulicParameters.isIntegerString(Me.txtXYRYS.Text) = False Then
                        strErrMsg = "����[������Ա��]����Ч����ֵ��"
                        GoTo errProc
                    End If
                End If
                If Me.txtDBRYS.Text.Trim <> "" Then
                    If objPulicParameters.isIntegerString(Me.txtDBRYS.Text) = False Then
                        strErrMsg = "����[������Ա��]����Ч����ֵ��"
                        GoTo errProc
                    End If
                End If
                If Me.grdRYXX.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ���У�"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdRYXX.SelectedIndex

                '��ȡ��¼λ��
                Dim intPos As Integer = 0
                intPos = objDataGridProcess.getRecordPosition(i, Me.grdRYXX.CurrentPageIndex, Me.grdRYXX.PageSize)

                '����
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_RYXX.Tables(strTable)
                    objDataRow = .DefaultView.Item(intPos).Row

                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYDM) = Me.txtRYDM.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_JLBH) = Me.txtJLBH.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXM) = Me.txtRYXM.Text
                    If Me.rblRYXB.SelectedIndex >= 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXB) = Me.rblRYXB.SelectedValue
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXB) = "��"
                    End If
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYNN) = objPulicParameters.getObjectValue(Me.txtRYNN.Text, 0)
                    If Me.ddlXL.SelectedIndex >= 0 Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXL) = Me.ddlXL.SelectedValue
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXL) = ""
                    End If
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NFPBM) = Me.txtNFPBM.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NDRZW) = Me.txtNDRZW.Text
                    'zengxianglin 2008-12-17
                    If Me.txtNBDRQ.Text.Trim = "" Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NBDRQ) = System.DBNull.Value
                    Else
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NBDRQ) = Me.txtNBDRQ.Text
                    End If
                    'zengxianglin 2008-12-17
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_ZPSM) = Me.txtZPSM.Text
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_XYRYS) = objPulicParameters.getObjectValue(Me.txtXYRYS.Text, 0)
                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_DBRYS) = objPulicParameters.getObjectValue(Me.txtDBRYS.Text, 0)

                End With

                '��ʾ
                If Me.showDataGridInfo_RYXX(strErrMsg) = False Then
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
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doRYXX_Delete(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI_RENYUANXINXI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 0

            Try
                intStep = 1
                '���ѡ��
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer
                intRows = Me.grdRYXX.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
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
                    Dim objDataRow As System.Data.DataRow = Nothing
                    Dim intPos As Integer = 0
                    intRows = Me.grdRYXX.Items.Count
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdRYXX.CurrentPageIndex, Me.grdRYXX.PageSize)
                            With Me.m_objDataSet_RYXX.Tables(strTable)
                                objDataRow = Nothing
                                objDataRow = .DefaultView.Item(intPos).Row
                                If Not (objDataRow Is Nothing) Then
                                    .Rows.Remove(objDataRow)
                                End If
                            End With
                        End If
                    Next

                    'ˢ����ʾ
                    If Me.showDataGridInfo_RYXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
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
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnRYXX_AddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRYXX_AddNew.Click
            Me.doRYXX_AddNew("btnRYXX_AddNew")
        End Sub

        Private Sub btnRYXX_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRYXX_Update.Click
            Me.doRYXX_Update("btnRYXX_Update")
        End Sub

        Private Sub btnRYXX_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRYXX_Delete.Click
            Me.doRYXX_Delete("btnRYXX_Delete")
        End Sub












        'zengxianglin 2009-05-16
        Private Sub doAccept(ByVal strControlId As String)

            Dim objsystemEstateRenshiGeneral As New Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 0

            Try
                intStep = 1
                '���
                Dim intSelected As Integer = 0
                Dim intColIndex(3) As Integer
                Dim intCount As Integer
                Dim i As Integer
                Dim strJLBH As String = ""
                Dim strRYDM As String = ""
                Dim strRYXM As String = ""
                Dim strNYBM As String = ""
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_JLBH)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYDM)
                intColIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXM)
                intColIndex(3) = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NFPBM)
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intCount = Me.grdRYXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
                            strJLBH = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(0))
                            strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(1))
                            strRYXM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(2))
                            strNYBM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(3))
                            If strRYDM = "" Or strRYXM = "" Or strNYBM = "" Then
                                strErrMsg = "����[�������]=[" + strJLBH + "]��[��Ա����]��[����]��[���õ�λ]�п�ֵ��"
                                GoTo errProc
                            End If
                            intSelected = intSelected + 1
                        End If
                    Next
                    If intSelected < 1 Then
                        strErrMsg = "����û�д�Ҫ¼�õ���Ա��"
                        GoTo errProc
                    End If
                End If

                intStep = 2
                'ѯ��
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ��ȷʵ׼��¼��ѡ����[" + intSelected.ToString + "]����Ա����/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '�������
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intCount = Me.grdRYXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRYXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_RYXX) = True Then
                            strJLBH = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(0))
                            strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(1))
                            strRYXM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(2))
                            strNYBM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex(3))

                            '¼�ô���
                            If objsystemEstateRenshiGeneral.doLuyong(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJLBH, Server, Request.ApplicationPath, Me.m_cstrPathRootToRskpImage) = False Then
                                GoTo errProc
                            End If
                        End If
                    Next

                    'ˢ������
                    If Me.doRefreshData(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾ�ɹ�
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ������ɹ���")
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiGeneral.SafeRelease(objsystemEstateRenshiGeneral)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        'zengxianglin 2009-05-21
        Private Sub doOpen_Grll(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.grdRYXX.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ����Ա��"
                    GoTo errProc
                End If
                Dim intColIndex As Integer = -1
                Dim strRYDM As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRYXX, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYDM)
                strRYDM = objDataGridProcess.getDataGridCellValue(Me.grdRYXX.Items(Me.grdRYXX.SelectedIndex), intColIndex)
                strRYDM = strRYDM.Trim
                If strRYDM = "" Then
                    strErrMsg = "����û��ѡ����Ա��"
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
                Dim objIEstateRsGrllInfo As Josco.JSOA.BusinessFacade.IEstateRsGrllInfo = Nothing
                Dim strUrl As String = ""
                objIEstateRsGrllInfo = New Josco.JSOA.BusinessFacade.IEstateRsGrllInfo
                With objIEstateRsGrllInfo
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iRYDM = strRYDM
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
                Session.Add(strNewSessionId, objIEstateRsGrllInfo)
                strUrl = ""
                strUrl += "estate_rs_grll_info.aspx"
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
        'zengxianglin 2009-05-21













        Private Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strMenuId As String = Me.htxtSelectMenuID.Value
                Select Case strMenuId.ToUpper()
                    Case "mnuFILE_SXWJ".ToUpper()
                        If Me.doRefresh(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuFILE_QXXG".ToUpper()
                        If Me.doCancel(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuFILE_BCWJ".ToUpper()
                        If Me.doSave(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuFILE_XGWJ".ToUpper()
                        If Me.doModify(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuJJCL_FSWJ".ToUpper()
                        If Me.doSendFile(strErrMsg, "lnkMenu", False) = False Then
                            GoTo errProc
                        End If
                    Case "mnuJJCL_WTBL".ToUpper()
                        If Me.doSendFile(strErrMsg, "lnkMenu", True) = False Then
                            GoTo errProc
                        End If
                    Case "mnuJJCL_SHWJ".ToUpper()
                        If Me.doShouhuiFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuJJCL_JSWJ".ToUpper()
                        If Me.doReceiveFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuJJCL_THWJ".ToUpper()
                        If Me.doTuihuiFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuSPCL_TXYJ".ToUpper()
                        If Me.doTianxieYijian(strErrMsg, "lnkMenu", "") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_BDPS".ToUpper()
                        If Me.doBudengYijian(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_BYBL".ToUpper()
                        If Me.doIDoNotProcess(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_BLWB".ToUpper()
                        If Me.doICompleteTask(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_WYYZ".ToUpper()
                        If Me.doIReadFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_ZHBL".ToUpper()
                        If Me.doIStopFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_JXBL".ToUpper()
                        If Me.doIContinueFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_ZFWJ".ToUpper()
                        If Me.doIZuofeiFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuSPCL_QYWJ".ToUpper()
                        If Me.doIQiyongFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuCBDB_CBWJ".ToUpper()
                        If Me.doCuiban(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuCBDB_DBWJ".ToUpper()
                        If Me.doDuban(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuCBDB_DBJG".ToUpper()
                        If Me.doDubanjg(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuXXCY_CYYJ".ToUpper()
                        If Me.doChakanSPYJ(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuXXCY_CKLZ".ToUpper()
                        If Me.doChakanLZQK(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuXXCY_CKBY".ToUpper()
                        If Me.doChakanBYQK(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuXXCY_CKRZ".ToUpper()
                        If Me.doChakanCZRZ(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuXXCY_CKCB".ToUpper()
                        If Me.doChakanCBQK(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuXXCY_CKDB".ToUpper()
                        If Me.doChakanDBQK(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuXXDY_DYGZ".ToUpper()
                        If Me.doPrintGZ(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuXXDY_DYBJ".ToUpper()
                        If Me.doPrintBJGZ(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuQTCL_WJBY".ToUpper()
                        If Me.doBuyue(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuQTCL_BWTX".ToUpper()
                        If Me.doSetBwtx(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuQTCL_DRQP".ToUpper()
                        If Me.doImportQPYJ(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuQTCL_DRZS".ToUpper()
                        If Me.doImportZSWJ(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuQTCL_WJBJ".ToUpper()
                        If Me.doCompleteFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuQTCL_RYLY".ToUpper()
                        Me.doAccept("lnkMenu")

                    Case "mnuFHSJ".ToUpper()
                        If Me.doClose(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case Else
                End Select
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

    End Class

End Namespace
