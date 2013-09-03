Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_rs_renyuanjiagou_list
    ' 
    ' �������ʣ�
    '     I/O
    '
    ' ���������� 
    '   ������Ա�䶯���һ��������ģ��
    '
    ' ���ļ�¼��
    '     zengxianglin 2009-05-14 ����
    '     zengxianglin 2010-01-02 ����
    '     zengxianglin 2010-03-18 ����
    '----------------------------------------------------------------

    Partial Class estate_rs_renyuanjiagou_list
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub





        'zengxianglin 2008-11-18
        'zengxianglin 2008-11-18




        'zengxianglin 2010-01-02
        'zengxianglin 2010-01-02

        'zengxianglin 2010-03-18
        'zengxianglin 2010-03-18

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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_List
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_List
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdRY��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdRY As String = "chkRY"
        Private Const m_cstrDataGridInDIV_grdRY As String = "divRY"
        Private m_intFixedColumns_grdRY As Integer
        Private m_intRows_grdRY As Integer

        '----------------------------------------------------------------
        '��ǰ��������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet_TDZH As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_RY As Josco.JSOA.Common.Data.estateRenshiXingyeData

        '----------------------------------------------------------------
        '��������
        '----------------------------------------------------------------
        Public ReadOnly Property propEditMode() As Boolean
            Get
                propEditMode = Me.btnMidify.Visible
            End Get
        End Property












        Private Sub doGoBack(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                strSessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                If strSessionId Is Nothing Then strSessionId = ""
                If strSessionId <> "" Then
                    Try
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_List)
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

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData
            Dim strErrMsg As String

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

                    Me.htxtRYSessionIdQuery.Value = .htxtRYSessionIdQuery
                    Me.htxtRYQuery.Value = .htxtRYQuery
                    Me.htxtRYRows.Value = .htxtRYRows
                    Me.htxtRYSort.Value = .htxtRYSort
                    Me.htxtRYSortColumnIndex.Value = .htxtRYSortColumnIndex
                    Me.htxtRYSortType.Value = .htxtRYSortType

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

                    Me.txtSearch_RY_RYDM.Text = .txtSearch_RY_RYDM
                    Me.txtSearch_RY_RYMC.Text = .txtSearch_RY_RYMC
                    Me.txtSearch_RY_DWMC.Text = .txtSearch_RY_DWMC
                    Me.txtSearch_RY_BDSJ.Text = .txtSearch_RY_BDSJ
                    Me.txtSearch_RY_KSSJMin.Text = .txtSearch_RY_KSSJMin
                    Me.txtSearch_RY_KSSJMax.Text = .txtSearch_RY_KSSJMax
                    Me.txtSearch_RY_JSSJMin.Text = .txtSearch_RY_JSSJMin
                    Me.txtSearch_RY_JSSJMax.Text = .txtSearch_RY_JSSJMax

                    Me.txtRYPageIndex.Text = .txtRYPageIndex
                    Me.txtRYPageSize.Text = .txtRYPageSize

                    Me.txtKSSJ.Text = .txtKSSJ
                    Me.txtJSSJ.Text = .txtJSSJ
                    Me.txtSJLD.Text = .txtSJLD
                    Me.htxtSJLD.Value = .htxtSJLD
                    Me.txtZZDM.Text = .txtZZDM
                    Me.htxtZZDM.Value = .htxtZZDM
                    'zengxianglin 2008-11-18
                    Me.txtZGDW.Text = .txtZGDW
                    Me.htxtZGDW.Value = .htxtZGDW
                    'zengxianglin 2008-11-18

                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, Me.txtZZDM.Text)
                    Try
                        Me.ddlSSFZ.SelectedIndex = .ddlSSFZ_SelectedIndex
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

                    'zengxianglin 2010-01-02
                    Me.htxtSessionId_TDZH.Value = .htxtSessionId_TDZH
                    Me.htxtBZXL.Value = .htxtBZXL
                    Me.htxtZGTD.Value = .htxtZGTD
                    Me.htxtXGTD.Value = .htxtXGTD
                    Me.txtTDBH.Text = .txtTDBH
                    If Me.getModuleData_TDZH(strErrMsg) = True Then
                        If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH, objTempDataSet) = True Then
                            Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, objTempDataSet, Me.lstZGTD)
                        End If
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                        If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH, objTempDataSet) = True Then
                            Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, objTempDataSet, Me.lstXGTD)
                        End If
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                    End If
                    Try
                        Me.lstXGTD.SelectedIndex = .lstXGTD_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.lstZGTD.SelectedIndex = .lstZGTD_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.ddlYDYY.SelectedIndex = .ddlYDYY_SelectedIndex
                    Catch ex As Exception
                    End Try
                    'zengxianglin 2010-01-02
                End With

                '�ͷ���Դ
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing
            Catch ex As Exception
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_List

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value
                    .htxtDivLeftRY = Me.htxtDivLeftRY.Value
                    .htxtDivTopRY = Me.htxtDivTopRY.Value

                    .htxtRYSessionIdQuery = Me.htxtRYSessionIdQuery.Value
                    .htxtRYQuery = Me.htxtRYQuery.Value
                    .htxtRYRows = Me.htxtRYRows.Value
                    .htxtRYSort = Me.htxtRYSort.Value
                    .htxtRYSortColumnIndex = Me.htxtRYSortColumnIndex.Value
                    .htxtRYSortType = Me.htxtRYSortType.Value

                    .grdRY_PageSize = Me.grdRY.PageSize
                    .grdRY_CurrentPageIndex = Me.grdRY.CurrentPageIndex
                    .grdRY_SelectedIndex = Me.grdRY.SelectedIndex

                    .txtSearch_RY_RYDM = Me.txtSearch_RY_RYDM.Text
                    .txtSearch_RY_BDSJ = Me.txtSearch_RY_BDSJ.Text
                    .txtSearch_RY_RYMC = Me.txtSearch_RY_RYMC.Text
                    .txtSearch_RY_DWMC = Me.txtSearch_RY_DWMC.Text
                    .txtSearch_RY_KSSJMin = Me.txtSearch_RY_KSSJMin.Text
                    .txtSearch_RY_KSSJMax = Me.txtSearch_RY_KSSJMax.Text
                    .txtSearch_RY_JSSJMin = Me.txtSearch_RY_JSSJMin.Text
                    .txtSearch_RY_JSSJMax = Me.txtSearch_RY_JSSJMax.Text

                    .txtRYPageIndex = Me.txtRYPageIndex.Text
                    .txtRYPageSize = Me.txtRYPageSize.Text

                    .txtKSSJ = Me.txtKSSJ.Text
                    .txtJSSJ = Me.txtJSSJ.Text
                    .txtSJLD = Me.txtSJLD.Text
                    .htxtSJLD = Me.htxtSJLD.Value
                    .txtZZDM = Me.txtZZDM.Text
                    .htxtZZDM = Me.htxtZZDM.Value
                    'zengxianglin 2008-11-18
                    .txtZGDW = Me.txtZGDW.Text
                    .htxtZGDW = Me.htxtZGDW.Value
                    'zengxianglin 2008-11-18
                    .ddlSSFZ_SelectedIndex = Me.ddlSSFZ.SelectedIndex
                    .ddlZJDM_SelectedIndex = Me.ddlZJDM.SelectedIndex
                    .rblRYZT_SelectedIndex = Me.rblRYZT.SelectedIndex
                    .rblSFZB_SelectedIndex = Me.rblSFZB.SelectedIndex

                    'zengxianglin 2010-01-02
                    .htxtSessionId_TDZH = Me.htxtSessionId_TDZH.Value
                    .htxtBZXL = Me.htxtBZXL.Value
                    .htxtZGTD = Me.htxtZGTD.Value
                    .htxtXGTD = Me.htxtXGTD.Value
                    .txtTDBH = Me.txtTDBH.Text
                    .lstXGTD_SelectedIndex = Me.lstXGTD.SelectedIndex
                    .lstZGTD_SelectedIndex = Me.lstZGTD.SelectedIndex
                    .ddlYDYY_SelectedIndex = Me.ddlYDYY.SelectedIndex
                    'zengxianglin 2010-01-02
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

                'zengxianglin 2010-01-02
                '==========================================================================================================================================================
                Dim objIEstateRsXzTeam As Josco.JSOA.BusinessFacade.IEstateRsXzTeam = Nothing
                Try
                    objIEstateRsXzTeam = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsXzTeam)
                Catch ex As Exception
                    objIEstateRsXzTeam = Nothing
                End Try
                If Not (objIEstateRsXzTeam Is Nothing) Then
                    If objIEstateRsXzTeam.oExitMode = True Then
                        Dim strZBBS As String = ""
                        Select Case objIEstateRsXzTeam.iSourceControlId.ToUpper()
                            Case "btnSelectTDBH".ToUpper()
                                If objIEstateRsXzTeam.oDataSet Is Nothing Then
                                    Me.txtTDBH.Text = ""
                                Else
                                    With objIEstateRsXzTeam.oDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH)
                                        If .Rows.Count < 1 Then
                                            Me.txtTDBH.Text = ""
                                        Else
                                            Me.txtTDBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH), "")
                                        End If
                                    End With
                                End If
                            Case "btnSelectZGTD".ToUpper()
                                If Me.getModuleData_TDZH(strErrMsg) = True Then
                                    '�������Ŷ���
                                    If Me.doAddInBuffer_TDZH(strErrMsg, objIEstateRsXzTeam.oDataSet, Me.m_objDataSet_TDZH, strZBBS) = True Then
                                        '����ϴλ���
                                        If Me.htxtZGTD.Value.Trim <> "" Then
                                            Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH)
                                        End If
                                        '��ʾ�����б�
                                        Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstZGTD)
                                        '������ֵ
                                        Me.htxtZGTD.Value = strZBBS
                                    End If
                                End If
                            Case "btnSelectXGTD".ToUpper()
                                If Me.getModuleData_TDZH(strErrMsg) = True Then
                                    '�������Ŷ���
                                    If Me.doAddInBuffer_TDZH(strErrMsg, objIEstateRsXzTeam.oDataSet, Me.m_objDataSet_TDZH, strZBBS) = True Then
                                        '����ϴλ���
                                        If Me.htxtXGTD.Value.Trim <> "" Then
                                            Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH)
                                        End If
                                        '��ʾ�����б�
                                        Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstXGTD)
                                        '������ֵ
                                        Me.htxtXGTD.Value = strZBBS
                                    End If
                                End If

                                'zengxianglin 2010-03-18
                            Case "btnAddnewZGTD".ToUpper()
                                If Me.getModuleData_TDZH(strErrMsg) = True Then
                                    '�������Ŷ���(��ѡ��+ԭ������)
                                    If Me.doAddInBuffer_TDZH(strErrMsg, objIEstateRsXzTeam.oDataSet, Me.htxtZGTD.Value.Trim, Me.m_objDataSet_TDZH, strZBBS) = True Then
                                        '����ϴλ���
                                        If Me.htxtZGTD.Value.Trim <> "" Then
                                            Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH)
                                        End If
                                        '��ʾ�����б�
                                        Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstZGTD)
                                        '������ֵ
                                        Me.htxtZGTD.Value = strZBBS
                                    End If
                                End If
                            Case "btnAddnewXGTD".ToUpper()
                                If Me.getModuleData_TDZH(strErrMsg) = True Then
                                    '�������Ŷ���(��ѡ��+ԭ������)
                                    If Me.doAddInBuffer_TDZH(strErrMsg, objIEstateRsXzTeam.oDataSet, Me.htxtXGTD.Value.Trim, Me.m_objDataSet_TDZH, strZBBS) = True Then
                                        '����ϴλ���
                                        If Me.htxtXGTD.Value.Trim <> "" Then
                                            Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH)
                                        End If
                                        '��ʾ�����б�
                                        Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstXGTD)
                                        '������ֵ
                                        Me.htxtXGTD.Value = strZBBS
                                    End If
                                End If
                                'zengxianglin 2010-03-18
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsXzTeam.SafeRelease(objIEstateRsXzTeam)
                    Exit Try
                End If
                'zengxianglin 2010-01-02

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
                            Case "btnSelectZZDM".ToUpper()
                                Dim strZZMC As String = objIDmxzZzjg.oBumenList
                                Dim strZZDM As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                    Me.htxtZZDM.Value = strZZDM
                                    Me.txtZZDM.Text = strZZMC
                                    Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, strZZMC)
                                End If
                                'zengxianglin 2008-11-18
                            Case "btnSelectZGDW".ToUpper()
                                Dim strZZMC As String = objIDmxzZzjg.oBumenList
                                Dim strZGDW As String = ""
                                If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZGDW) = True Then
                                    Me.htxtZGDW.Value = strZGDW
                                    Me.txtZGDW.Text = strZZMC
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
                                Me.htxtRYQuery.Value = objISjcxCxtj.oQueryString
                                If Me.htxtRYSessionIdQuery.Value.Trim = "" Then
                                    Me.htxtRYSessionIdQuery.Value = objPulicParameters.getNewGuid()
                                Else
                                    Try
                                        objQueryData = CType(Session(Me.htxtRYSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                                    Catch ex As Exception
                                        objQueryData = Nothing
                                    End Try
                                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                                End If
                                Session.Add(Me.htxtRYSessionIdQuery.Value, objISjcxCxtj.oDataSetTJ)
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_List)
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

                '��ȡ�ָ��ֳ�����
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsRenyuanJiagou_List)
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
                Me.m_intRows_grdRY = objPulicParameters.getObjectValue(Me.htxtRYRows.Value, 0)
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
                Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
                If Me.htxtRYSessionIdQuery.Value.Trim <> "" Then
                    Try
                        objQueryData = CType(Session(Me.htxtRYSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtRYSessionIdQuery.Value)
                End If

                Dim objDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
                If Me.htxtSessionId_TDZH.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_TDZH.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_TDZH.Value)
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub










        '----------------------------------------------------------------
        ' ��lstTDZH��ѡ�����ŶӴ�strZBBS��Ӧ��������ɾ����
        ' ����ɾ��������ݼ�objDataSet_Des�����Ŷ����
        '     strErrMsg      �����ش�����Ϣ
        '     lstTDZH        ��Ҫ���������
        '     strZBBS_Old    ��ԭ����ʶ
        '     objDataSet_Des �����뵽������
        '     strZBBS        ��������ʶ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2010-03-18 ����
        '----------------------------------------------------------------
        Private Function doDelInBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal lstTDZH As System.Web.UI.WebControls.ListBox, _
            ByVal strZBBS_Old As String, _
            ByRef objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef strZBBS As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDataSet_Old As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataRow As System.Data.DataRow = Nothing
            Dim i, j, intRows, intCols As Integer
            Dim strZHBS As String = ""

            doDelInBuffer_TDZH = False
            strErrMsg = ""
            strZBBS = ""

            Try
                '���
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If lstTDZH Is Nothing Then
                    Exit Try
                End If
                '=====================================================================================================================

                '����strZBBS_Old��Ӧ���Ŷ�����[objDataSet_Old]
                If strZBBS_Old <> "" Then
                    If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZBBS_Old, objDataSet_Des, objDataSet_Old) = False Then
                        GoTo errProc
                    End If
                End If
                If objDataSet_Old Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Old.Tables(strTable) Is Nothing Then
                    Exit Try
                End If

                '��objDataSet_Old��ɾ��lstTDZHѡ�����Ŷ�
                Dim intCount As Integer = 0
                intCount = lstTDZH.Items.Count
                For i = 0 To intCount - 1 Step 1
                    If lstTDZH.Items(i).Selected = True Then
                        strZHBS = lstTDZH.Items(i).Value
                        With objDataSet_Old.Tables(strTable)
                            .DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS + " = '" + strZHBS + "'"
                            objDataRow = Nothing
                            If .DefaultView.Count > 0 Then
                                objDataRow = .DefaultView.Item(0).Row
                            End If
                            If Not (objDataRow Is Nothing) Then
                                .Rows.Remove(objDataRow)
                            End If
                            .DefaultView.RowFilter = ""
                        End With
                    End If
                Next

                '��[����ʶ]
                strZBBS = objPulicParameters.getNewGuid()

                '����objDataSet_Old��objDataSet_Des
                If Not (objDataSet_Old Is Nothing) Then
                    If Not (objDataSet_Old.Tables(strTable) Is Nothing) Then
                        With objDataSet_Old.Tables(strTable)
                            intCols = .Columns.Count
                            intRows = .Rows.Count
                            For i = 0 To intRows - 1 Step 1
                                '��[��ϱ�ʶ]
                                strZHBS = objPulicParameters.getNewGuid()
                                '��������
                                With objDataSet_Des.Tables(strTable)
                                    objDataRow = .NewRow
                                End With
                                For j = 0 To intCols - 1 Step 1
                                    objDataRow.Item(j) = .Rows(i).Item(j)
                                Next
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS) = strZHBS
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS) = strZBBS
                                With objDataSet_Des.Tables(strTable)
                                    .Rows.Add(objDataRow)
                                End With
                            Next
                        End With
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_Old)

            doDelInBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_Old)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��objDataSet_Srcд��objDataSet_Des�У�ֻ����objDataSet_Src��
        ' strZBBS_Old�в����ڵ��Ŷ�
        '     strErrMsg      �����ش�����Ϣ
        '     objDataSet_Src ��Ҫ���������
        '     strZBBS_Old    ��ԭ����ʶ
        '     objDataSet_Des �����뵽������
        '     strZBBS        ��������ʶ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2010-03-18 ����
        '----------------------------------------------------------------
        Private Function doAddInBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal objDataSet_Src As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal strZBBS_Old As String, _
            ByRef objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef strZBBS As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDataSet_Old As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataRow As System.Data.DataRow = Nothing
            Dim i, j, intRows, intCols As Integer
            Dim strZHBS As String = ""

            doAddInBuffer_TDZH = False
            strErrMsg = ""
            strZBBS = ""

            Try
                '���
                '=====================================================================================================================
                If objDataSet_Src Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Src.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Src.Tables(strTable).Rows.Count < 1 Then
                    Exit Try
                End If
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                '=====================================================================================================================

                '����strZBBS_Old��Ӧ���Ŷ�����[objDataSet_Old]
                If strZBBS_Old <> "" Then
                    If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZBBS_Old, objDataSet_Des, objDataSet_Old) = False Then
                        GoTo errProc
                    End If
                End If

                '��[����ʶ]
                strZBBS = objPulicParameters.getNewGuid()

                '����objDataSet_Old��objDataSet_Des
                If Not (objDataSet_Old Is Nothing) Then
                    If Not (objDataSet_Old.Tables(strTable) Is Nothing) Then
                        With objDataSet_Old.Tables(strTable)
                            intCols = .Columns.Count
                            intRows = .Rows.Count
                            For i = 0 To intRows - 1 Step 1
                                '��[��ϱ�ʶ]
                                strZHBS = objPulicParameters.getNewGuid()
                                '��������
                                With objDataSet_Des.Tables(strTable)
                                    objDataRow = .NewRow
                                End With
                                For j = 0 To intCols - 1 Step 1
                                    objDataRow.Item(j) = .Rows(i).Item(j)
                                Next
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS) = strZHBS
                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS) = strZBBS
                                With objDataSet_Des.Tables(strTable)
                                    .Rows.Add(objDataRow)
                                End With
                            Next
                        End With
                    End If
                End If

                '����objDataSet_Src��objDataSet_Des
                Dim blnExisted As Boolean = False
                Dim strFilterOld As String = ""
                Dim strFilter As String = ""
                Dim strSSDW As String = ""
                Dim intTDBH As Integer = 0
                With objDataSet_Src.Tables(strTable)
                    intCols = .Columns.Count
                    intRows = .Rows.Count
                    For i = 0 To intRows - 1 Step 1
                        '��[��ϱ�ʶ]
                        strZHBS = objPulicParameters.getNewGuid()
                        '������ѡ����
                        strSSDW = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_SSDW), "")
                        intTDBH = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH), 0)
                        '����Ƿ���ڣ�
                        blnExisted = False
                        With objDataSet_Des.Tables(strTable)
                            strFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS + " = '" + strZBBS + "'"
                            strFilter = strFilter + " and " + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_SSDW + " = '" + strSSDW + "'"
                            strFilter = strFilter + " and " + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH + " = " + intTDBH.ToString + ""
                            strFilterOld = .DefaultView.RowFilter
                            .DefaultView.RowFilter = strFilter
                            If .DefaultView.Count > 0 Then
                                blnExisted = True
                            End If
                            .DefaultView.RowFilter = strFilterOld
                        End With
                        '�����ڣ�����룡
                        If blnExisted = False Then
                            With objDataSet_Des.Tables(strTable)
                                objDataRow = .NewRow
                            End With
                            For j = 0 To intCols - 1 Step 1
                                objDataRow.Item(j) = .Rows(i).Item(j)
                            Next
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS) = strZHBS
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS) = strZBBS
                            With objDataSet_Des.Tables(strTable)
                                .Rows.Add(objDataRow)
                            End With
                        End If
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_Old)

            doAddInBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet_Old)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��objDataSet_Srcд��objDataSet_Des��
        '     strErrMsg      �����ش�����Ϣ
        '     objDataSet_Src ��Ҫ���������
        '     objDataSet_Des �����뵽������
        '     strZBBS        ��������ʶ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2010-01-02 ����
        '----------------------------------------------------------------
        Private Function doAddInBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal objDataSet_Src As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef strZBBS As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataRow As System.Data.DataRow = Nothing
            Dim i, j, intRows, intCols As Integer
            Dim strZHBS As String = ""

            doAddInBuffer_TDZH = False
            strErrMsg = ""
            strZBBS = ""

            Try
                '���
                '=====================================================================================================================
                If objDataSet_Src Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Src.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Src.Tables(strTable).Rows.Count < 1 Then
                    Exit Try
                End If
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                '=====================================================================================================================

                '������
                strZBBS = objPulicParameters.getNewGuid()
                With objDataSet_Src.Tables(strTable)
                    intCols = .Columns.Count
                    intRows = .Rows.Count
                    For i = 0 To intRows - 1 Step 1
                        strZHBS = objPulicParameters.getNewGuid()

                        With objDataSet_Des.Tables(strTable)
                            objDataRow = .NewRow
                        End With

                        For j = 0 To intCols - 1 Step 1
                            objDataRow.Item(j) = .Rows(i).Item(j)
                        Next
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS) = strZHBS
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS) = strZBBS

                        With objDataSet_Des.Tables(strTable)
                            .Rows.Add(objDataRow)
                        End With
                    Next
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doAddInBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��objDataSet_Desɾ��strZBBS��Ӧ������
        '     strErrMsg      �����ش�����Ϣ
        '     strZBBS        ������ʶ
        '     objDataSet_Des ����������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2010-01-02 ����
        '----------------------------------------------------------------
        Private Function doDeleteBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal strZBBS As String, _
            ByRef objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strOldRowFilter As String = ""
            Dim i, intRows As Integer

            doDeleteBuffer_TDZH = False
            strErrMsg = ""

            Try
                '���
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable).Rows.Count < 1 Then
                    Exit Try
                End If
                '=====================================================================================================================

                '����
                With objDataSet_Des.Tables(strTable)
                    strOldRowFilter = .DefaultView.RowFilter
                End With

                '����
                With objDataSet_Des.Tables(strTable)
                    .DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS + " = '" + strZBBS + "'"
                End With

                '������
                With objDataSet_Des.Tables(strTable)
                    intRows = .DefaultView.Count
                    For i = intRows - 1 To 0 Step -1
                        .Rows.Remove(.DefaultView.Item(i).Row)
                    Next
                End With

                '�ָ�
                With objDataSet_Des.Tables(strTable)
                    .DefaultView.RowFilter = strOldRowFilter
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doDeleteBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾstrZBBS��objDataSet_Des���ݵ�objListBox
        '     strErrMsg      �����ش�����Ϣ
        '     strZBBS        ������ʶ
        '     objDataSet_Des ����ʾ����
        '     objListBox     ����ʾ�ؼ�
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2010-01-02 ����
        '----------------------------------------------------------------
        Private Function doDisplayBuffer_TDZH( _
            ByRef strErrMsg As String, _
            ByVal strZBBS As String, _
            ByVal objDataSet_Des As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objListBox As System.Web.UI.WebControls.ListBox) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objListItem As System.Web.UI.WebControls.ListItem = Nothing
            Dim strOldRowFilter As String = ""
            Dim strZHBS As String = ""
            Dim strDWMC As String = ""
            Dim strTDBH As String = ""
            Dim i, intRows As Integer

            doDisplayBuffer_TDZH = False
            strErrMsg = ""

            Try
                '���
                '=====================================================================================================================
                If objDataSet_Des Is Nothing Then
                    Exit Try
                End If
                If objDataSet_Des.Tables(strTable) Is Nothing Then
                    Exit Try
                End If
                '=====================================================================================================================

                '���
                objListBox.Items.Clear()

                '����
                With objDataSet_Des.Tables(strTable)
                    strOldRowFilter = .DefaultView.RowFilter
                End With

                '����
                With objDataSet_Des.Tables(strTable)
                    .DefaultView.RowFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZBBS + " = '" + strZBBS + "'"
                End With

                '������
                With objDataSet_Des.Tables(strTable)
                    intRows = .DefaultView.Count
                    For i = 0 To intRows - 1 Step 1
                        strZHBS = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_ZHBS), "")
                        strDWMC = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_DWMC), "")
                        strTDBH = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH), "")

                        objListItem = New System.Web.UI.WebControls.ListItem
                        objListItem.Value = strZHBS
                        objListItem.Text = strDWMC + "_" + strTDBH

                        objListBox.Items.Add(objListItem)
                    Next
                End With

                '�ָ�
                With objDataSet_Des.Tables(strTable)
                    .DefaultView.RowFilter = strOldRowFilter
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doDisplayBuffer_TDZH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

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

                '���䶯ʱ������
                Dim strKSSJ As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ
                Dim strJSSJ As String = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_JSSJ
                Dim strNewT As String = ""
                If Me.txtSearch_RY_BDSJ.Text.Length > 0 Then Me.txtSearch_RY_BDSJ.Text = Me.txtSearch_RY_BDSJ.Text.Trim()
                If Me.txtSearch_RY_BDSJ.Text <> "" Then
                    If objPulicParameters.isDatetimeString(Me.txtSearch_RY_BDSJ.Text) = False Then
                        strErrMsg = "����[" + Me.txtSearch_RY_BDSJ.Text + "]����Ч��ʱ�䣡"
                        GoTo errProc
                    End If
                    Me.txtSearch_RY_BDSJ.Text = CType(Me.txtSearch_RY_BDSJ.Text, System.DateTime).ToString("yyyy-MM-dd HH:mm:ss")
                    strNewT = CType(Me.txtSearch_RY_BDSJ.Text, System.DateTime).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = ""
                        strQuery = strQuery + "(" + strKSSJ + " = '" + Me.txtSearch_RY_BDSJ.Text + "'"
                        strQuery = strQuery + " or "
                        strQuery = strQuery + " " + strJSSJ + " = '" + strNewT + "'" + ")"
                    Else
                        strQuery = strQuery + " and "
                        strQuery = strQuery + "(" + strKSSJ + " = '" + Me.txtSearch_RY_BDSJ.Text + "'"
                        strQuery = strQuery + " or "
                        strQuery = strQuery + " " + strJSSJ + " = '" + strNewT + "'" + ")"
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

                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime

                '��[��Чʱ��]����
                strKSSJ = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ
                If Me.txtSearch_RY_KSSJMin.Text.Length > 0 Then Me.txtSearch_RY_KSSJMin.Text = Me.txtSearch_RY_KSSJMin.Text.Trim()
                If Me.txtSearch_RY_KSSJMax.Text.Length > 0 Then Me.txtSearch_RY_KSSJMax.Text = Me.txtSearch_RY_KSSJMax.Text.Trim()
                If Me.txtSearch_RY_KSSJMin.Text <> "" And Me.txtSearch_RY_KSSJMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtSearch_RY_KSSJMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtSearch_RY_KSSJMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtSearch_RY_KSSJMin.Text = dateMax.ToString("yyyy-MM-dd HH:mm:ss")
                        Me.txtSearch_RY_KSSJMax.Text = dateMin.ToString("yyyy-MM-dd HH:mm:ss")
                    Else
                        Me.txtSearch_RY_KSSJMin.Text = dateMin.ToString("yyyy-MM-dd HH:mm:ss")
                        Me.txtSearch_RY_KSSJMax.Text = dateMax.ToString("yyyy-MM-dd HH:mm:ss")
                    End If
                    If strQuery = "" Then
                        strQuery = strKSSJ + " between '" + Me.txtSearch_RY_KSSJMin.Text + "' and '" + Me.txtSearch_RY_KSSJMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strKSSJ + " between '" + Me.txtSearch_RY_KSSJMin.Text + "' and '" + Me.txtSearch_RY_KSSJMax.Text + "'"
                    End If
                ElseIf Me.txtSearch_RY_KSSJMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtSearch_RY_KSSJMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtSearch_RY_KSSJMin.Text = dateMin.ToString("yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strKSSJ + " >= '" + Me.txtSearch_RY_KSSJMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strKSSJ + " >= '" + Me.txtSearch_RY_KSSJMin.Text + "'"
                    End If
                ElseIf Me.txtSearch_RY_KSSJMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtSearch_RY_KSSJMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtSearch_RY_KSSJMax.Text = dateMax.ToString("yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strKSSJ + " <= '" + Me.txtSearch_RY_KSSJMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strKSSJ + " <= '" + Me.txtSearch_RY_KSSJMax.Text + "'"
                    End If
                Else
                End If

                '��[ʧЧʱ��]����
                strJSSJ = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_JSSJ
                If Me.txtSearch_RY_JSSJMin.Text.Length > 0 Then Me.txtSearch_RY_JSSJMin.Text = Me.txtSearch_RY_JSSJMin.Text.Trim()
                If Me.txtSearch_RY_JSSJMax.Text.Length > 0 Then Me.txtSearch_RY_JSSJMax.Text = Me.txtSearch_RY_JSSJMax.Text.Trim()
                If Me.txtSearch_RY_JSSJMin.Text <> "" And Me.txtSearch_RY_JSSJMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtSearch_RY_JSSJMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtSearch_RY_JSSJMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtSearch_RY_JSSJMin.Text = dateMax.ToString("yyyy-MM-dd HH:mm:ss")
                        Me.txtSearch_RY_JSSJMax.Text = dateMin.ToString("yyyy-MM-dd HH:mm:ss")
                    Else
                        Me.txtSearch_RY_JSSJMin.Text = dateMin.ToString("yyyy-MM-dd HH:mm:ss")
                        Me.txtSearch_RY_JSSJMax.Text = dateMax.ToString("yyyy-MM-dd HH:mm:ss")
                    End If
                    If strQuery = "" Then
                        strQuery = strJSSJ + " between '" + Me.txtSearch_RY_JSSJMin.Text + "' and '" + Me.txtSearch_RY_JSSJMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJSSJ + " between '" + Me.txtSearch_RY_JSSJMin.Text + "' and '" + Me.txtSearch_RY_JSSJMax.Text + "'"
                    End If
                ElseIf Me.txtSearch_RY_JSSJMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtSearch_RY_JSSJMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtSearch_RY_JSSJMin.Text = dateMin.ToString("yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strJSSJ + " >= '" + Me.txtSearch_RY_JSSJMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJSSJ + " >= '" + Me.txtSearch_RY_JSSJMin.Text + "'"
                    End If
                ElseIf Me.txtSearch_RY_JSSJMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtSearch_RY_JSSJMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtSearch_RY_JSSJMax.Text = dateMax.ToString("yyyy-MM-dd HH:mm:ss")
                    If strQuery = "" Then
                        strQuery = strJSSJ + " <= '" + Me.txtSearch_RY_JSSJMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJSSJ + " <= '" + Me.txtSearch_RY_JSSJMax.Text + "'"
                    End If
                Else
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
                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtRYSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_RY)

                '���¼�������
                If objsystemEstateRenshiXingye.getDataSet_RYJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, Me.m_objDataSet_RY) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_RY.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_RY.Tables(strTable)
                    Me.htxtRYRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_grdRY = .DefaultView.Count
                End With
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
        ' ��ȡ�Ŷ������ʱ���ݼ�
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2010-01-02 ����
        '----------------------------------------------------------------
        Private Function getModuleData_TDZH(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_TDZH = False

            Try
                '������Ҫ��ȡ
                If Me.htxtSessionId_TDZH.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_TDZH = CType(Session.Item(Me.htxtSessionId_TDZH.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_TDZH)
                    '������
                    Me.m_objDataSet_TDZH = New Josco.JSOA.Common.Data.estateRenshiXingyeData(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_B_RS_TDZH)
                    '��������
                    Me.htxtSessionId_TDZH.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_TDZH.Value, Me.m_objDataSet_TDZH)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_TDZH = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ����������������
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
                Me.htxtRYQuery.Value = strQuery
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
        ' ��grdRY��ǰ����Ϣ��ʾ����������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2010-01-02 ����
        '     zengxianglin 2010-03-18 ����
        '----------------------------------------------------------------
        Private Function showEditPanel_RY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objRadioButtonListProcess As New Josco.JsKernal.web.RadioButtonListProcess
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showEditPanel_RY = False

            Try
                '���
                Me.txtKSSJ.Text = ""
                Me.txtJSSJ.Text = ""
                Me.htxtZZDM.Value = ""
                Me.txtZZDM.Text = ""
                'zengxianglin 2008-11-18
                Me.htxtZGDW.Value = ""
                Me.txtZGDW.Text = ""
                'zengxianglin 2008-11-18
                Me.ddlSSFZ.SelectedIndex = -1
                Me.ddlZJDM.SelectedIndex = -1
                Me.rblRYZT.SelectedIndex = -1
                Me.rblSFZB.SelectedIndex = -1
                'zengxianglin 2010-01-02
                Me.chkSFJZ.Checked = False
                Me.htxtBZXL.Value = ""
                Me.txtTDBH.Text = ""
                Me.htxtZGTD.Value = ""
                Me.lstZGTD.Items.Clear()
                Me.htxtXGTD.Value = ""
                Me.lstXGTD.Items.Clear()
                Me.ddlYDYY.SelectedIndex = -1
                'zengxianglin 2010-01-02

                '���
                If Me.grdRY.SelectedIndex < 0 Then
                    Exit Try
                End If
                Dim intIndex As Integer = Me.grdRY.SelectedIndex

                '��ʾ
                Dim intColIndex As Integer
                Dim strValue As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW)
                Me.htxtZZDM.Value = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC)
                Me.txtZZDM.Text = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, Me.txtZZDM.Text)

                'zengxianglin 2008-11-18
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW)
                Me.htxtZGDW.Value = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC)
                Me.txtZGDW.Text = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                'zengxianglin 2008-11-18

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD)
                Me.htxtSJLD.Value = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLDMC)
                Me.txtSJLD.Text = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.ddlZJDM.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlZJDM, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.rblRYZT.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblRYZT, strValue)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.rblSFZB.SelectedIndex = objRadioButtonListProcess.getCheckedItem(Me.rblSFZB, strValue)

                Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, Me.txtZZDM.Text)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.ddlSSFZ.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlSSFZ, strValue, True)

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.txtKSSJ.Text = strValue

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_JSSJ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.txtJSSJ.Text = strValue

                'zengxianglin 2010-01-02
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_BZXL)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.htxtBZXL.Value = strValue
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_TDBH)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.txtTDBH.Text = strValue
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGTD)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.htxtZGTD.Value = strValue
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_XGTD)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.htxtXGTD.Value = strValue
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYY)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                Me.ddlYDYY.SelectedIndex = objDropDownListProcess.getSelectedItem(Me.ddlYDYY, strValue)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                If strValue = "1" Then
                    Me.chkSFJZ.Checked = True
                Else
                    Me.chkSFJZ.Checked = False
                End If
                If Me.getModuleData_TDZH(strErrMsg) = True Then
                    If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH, objTempDataSet) = True Then
                        Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, objTempDataSet, Me.lstZGTD)
                    End If
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                    If objsystemEstateRenshiXingye.getDataSet_TDZH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH, objTempDataSet) = True Then
                        Me.doDisplayBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, objTempDataSet, Me.lstXGTD)
                    End If
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                End If
                'zengxianglin 2010-01-02

                'zengxianglin 2010-01-02
                '��������
                Dim intBZXL As Integer
                Dim blnVal As Boolean
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYLX)
                strValue = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex)
                If strValue = "1" Then
                    Me.chkSFJZ.Enabled = False
                Else
                    Me.chkSFJZ.Enabled = True
                End If
                If objsystemEstateRenshiXingye.getBZXL_RSJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtKSSJ.Text, intBZXL) = True Then
                    Select Case intBZXL
                        Case 1 '����ģʽһ
                            blnVal = True

                            Me.txtSJLD.Enabled = blnVal
                            Me.btnSelectSJLD.Visible = blnVal
                            Me.ddlSSFZ.Enabled = blnVal
                            Me.btnJSFZLB.Visible = blnVal
                            Me.txtZGDW.Enabled = blnVal
                            Me.btnSelectZGDW.Visible = blnVal

                            Me.txtTDBH.Enabled = Not blnVal
                            Me.btnSelectTDBH.Visible = Not blnVal
                            Me.btnSelectZGTD.Visible = Not blnVal
                            Me.btnSelectXGTD.Visible = Not blnVal
                            'zengxianglin 2010-03-18
                            Me.btnAddnewZGTD.Visible = Not blnVal
                            Me.btnDeleteZGTD.Visible = Not blnVal
                            Me.btnAddnewXGTD.Visible = Not blnVal
                            Me.btnDeleteXGTD.Visible = Not blnVal
                            'zengxianglin 2010-03-18
                        Case 2 '����ģʽ��
                            blnVal = False

                            Me.txtSJLD.Enabled = blnVal
                            Me.btnSelectSJLD.Visible = blnVal
                            Me.ddlSSFZ.Enabled = blnVal
                            Me.btnJSFZLB.Visible = blnVal
                            Me.txtZGDW.Enabled = blnVal
                            Me.btnSelectZGDW.Visible = blnVal

                            Me.txtTDBH.Enabled = Not blnVal
                            Me.btnSelectTDBH.Visible = Not blnVal
                            Me.btnSelectZGTD.Visible = Not blnVal
                            Me.btnSelectXGTD.Visible = Not blnVal
                            'zengxianglin 2010-03-18
                            Me.btnAddnewZGTD.Visible = Not blnVal
                            Me.btnDeleteZGTD.Visible = Not blnVal
                            Me.btnAddnewXGTD.Visible = Not blnVal
                            Me.btnDeleteXGTD.Visible = Not blnVal
                            'zengxianglin 2010-03-18
                        Case Else
                            blnVal = False

                            Me.txtSJLD.Enabled = blnVal
                            Me.btnSelectSJLD.Visible = blnVal
                            Me.ddlSSFZ.Enabled = blnVal
                            Me.btnJSFZLB.Visible = blnVal
                            Me.txtZGDW.Enabled = blnVal
                            Me.btnSelectZGDW.Visible = blnVal

                            Me.txtTDBH.Enabled = blnVal
                            Me.btnSelectTDBH.Visible = blnVal
                            Me.btnSelectZGTD.Visible = blnVal
                            Me.btnSelectXGTD.Visible = blnVal
                            'zengxianglin 2010-03-18
                            Me.btnAddnewZGTD.Visible = blnVal
                            Me.btnDeleteZGTD.Visible = blnVal
                            Me.btnAddnewXGTD.Visible = blnVal
                            Me.btnDeleteXGTD.Visible = blnVal
                            'zengxianglin 2010-03-18
                    End Select
                End If
                'zengxianglin 2010-01-02
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showEditPanel_RY = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.RadioButtonListProcess.SafeRelease(objRadioButtonListProcess)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
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

            showDataGridInfo_RY = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtRYSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtRYSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

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

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdRY)
                    With Me.grdRY.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdRY.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdRY, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_RY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdRY�����Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        ' ����˵��
        '     zengxianglin 2008-11-06 ����
        '       Optional ByVal blnTongbu As Boolean = True
        '----------------------------------------------------------------
        Private Function showModuleData_RY( _
            ByRef strErrMsg As String, _
            Optional ByVal blnTongbu As Boolean = True) As Boolean

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

                '��ʾ��ǰ����Ϣ
                'zengxianglin 2008-11-06
                If blnTongbu = True Then
                    If Me.showEditPanel_RY(strErrMsg) = False Then
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
                Me.btnMidify.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnDelete.Visible = Me.m_blnPrevilegeParams(1)
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
                'zengxianglin 2010-01-02
                'If objsystemEstateRenshiXingye.getDataSet_ZhijiDingyi(strErrMsg, MyBase.UserId, MyBase.UserPassword, "", objestateRenshiXingyeData) = False Then
                '    GoTo errProc
                'End If
                Dim strWhere As String = ""
                strWhere = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_JBSZ + " > 0"
                If objsystemEstateRenshiXingye.getDataSet_ZhijiDingyi(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiXingyeData) = False Then
                    GoTo errProc
                End If
                'zengxianglin 2010-01-02

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
        ' �����������б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        '     strZZMC        ����֯����
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
        ' ���䶯ԭ�������б��
        '     strErrMsg      �����ش�����Ϣ
        '     objDropDownList��Ҫ�����б��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        ' ����
        '     zengxianglin 2010-01-05 ����
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
                If objsystemEstateRenshiGeneral.getDataSet_BiandongYuanyin(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWhere, objestateRenshiGeneralData) = False Then
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
                        .doTranslateKey(Me.txtSearch_RY_BDSJ)
                        .doTranslateKey(Me.txtSearch_RY_RYMC)
                        .doTranslateKey(Me.txtSearch_RY_KSSJMin)
                        .doTranslateKey(Me.txtSearch_RY_KSSJMax)
                        .doTranslateKey(Me.txtSearch_RY_JSSJMin)
                        .doTranslateKey(Me.txtSearch_RY_JSSJMax)
                        '**************************************************
                        .doTranslateKey(Me.txtRYPageIndex)
                        .doTranslateKey(Me.txtRYPageSize)
                        '**************************************************
                        .doTranslateKey(Me.txtKSSJ)
                        .doTranslateKey(Me.txtJSSJ)
                        .doTranslateKey(Me.txtSJLD)
                        .doTranslateKey(Me.txtZZDM)
                        .doTranslateKey(Me.ddlSSFZ)
                        .doTranslateKey(Me.ddlZJDM)
                        '**************************************************
                        'zengxianglin 2010-01-02
                        .doTranslateKey(Me.txtTDBH)
                        'zengxianglin 2010-01-02
                        '**************************************************
                    End With

                    '���ʼֵ
                    If Me.m_blnSaveScence = False Then
                        Me.txtSearch_RY_KSSJMin.Text = Now.Year.ToString + "-01-01"
                        Me.txtSearch_RY_KSSJMax.Text = Now.Year.ToString + "-12-31"
                        If Me.searchModuleData_RY(strErrMsg) = False Then
                            GoTo errProc
                        End If
                    Else
                        If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                            GoTo errProc
                        End If
                    End If
                    'zengxianglin 2008-11-06
                    If Me.m_blnSaveScence = True Then
                        If Me.showModuleData_RY(strErrMsg, False) = False Then
                            GoTo errProc
                        End If
                    Else
                        If Me.showModuleData_RY(strErrMsg) = False Then
                            GoTo errProc
                        End If
                    End If
                    'zengxianglin 2008-11-06

                    '��ʾMain
                    If Me.showModuleData_Main(strErrMsg) = False Then
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
                    If Me.doFillZjdmList(strErrMsg, Me.ddlZJDM) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2010-01-05
                    If Me.doFillYdyyList(strErrMsg, Me.ddlYDYY, "") = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2010-01-05
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

        Private Sub grdRY_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRY.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblRYGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdRY, Me.m_intRows_grdRY)

                'ͬ����ʾ��Ϣ
                If Me.showEditPanel_RY(strErrMsg) = False Then
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

        Private Sub grdRY_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdRY.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim objenumSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
                Dim objDataGridItem As System.Web.UI.WebControls.DataGridItem
                Dim strFinalCommand As String = ""
                Dim strOldCommand As String = ""
                Dim strUniqueId As String = ""
                Dim intColumnIndex As Integer

                '��ȡ����
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                With Me.m_objDataSet_RY.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                With Me.m_objDataSet_RY.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtRYSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtRYSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtRYSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_RY(strErrMsg) = False Then
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











        Private Sub doMoveFirst_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_RY(strErrMsg) = False Then
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

        Private Sub doMoveLast_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.PageCount - 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_RY(strErrMsg) = False Then
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

        Private Sub doMoveNext_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.CurrentPageIndex + 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_RY(strErrMsg) = False Then
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

        Private Sub doMovePrevious_RY(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRY.CurrentPageIndex - 1, Me.grdRY.PageCount)
                Me.grdRY.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_RY(strErrMsg) = False Then
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
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdRY.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_RY(strErrMsg) = False Then
                    GoTo errProc
                End If

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
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdRY.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_RY(strErrMsg) = False Then
                    GoTo errProc
                End If

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











        Private Sub doSelectSJLD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                'zengxianglin 2008-11-22
                '���
                If Me.txtKSSJ.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[��Чʱ��]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSSJ.Text) = False Then
                    strErrMsg = "������Ч��[��Чʱ��]��"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-22

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
                    'zengxianglin 2008-11-22
                    '.iTime = Now.ToString("yyyy-MM-dd")
                    .iTime = Me.txtKSSJ.Text
                    'zengxianglin 2008-11-22
                    .iAllowNull = True
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

        Private Sub doJSFZLB(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If Me.doFillSsfzList(strErrMsg, Me.ddlSSFZ, Me.txtZZDM.Text) = False Then
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

        'zengxianglin 2010-01-02
        Private Sub doSelectTDBH(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.txtZZDM.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[�µĲ���]��"
                    GoTo errProc
                End If
                If Me.txtKSSJ.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[��Чʱ��]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSSJ.Text) = False Then
                    strErrMsg = "������Ч��[��Чʱ��][" + Me.txtKSSJ.Text + "]��"
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
                    .iJCSJ = Me.txtKSSJ.Text
                    .iFixQuery = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_SSDW + " = '" + Me.htxtZZDM.Value + "'"

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
                strUrl += "estate_rs_xz_team.aspx"
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
        'zengxianglin 2010-01-02

        'zengxianglin 2010-01-02
        Private Sub doSelectZGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.txtKSSJ.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[��Чʱ��]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSSJ.Text) = False Then
                    strErrMsg = "������Ч��[��Чʱ��][" + Me.txtKSSJ.Text + "]��"
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
                    .iMultiSelect = True
                    .iAllowNull = True
                    .iJCSJ = Me.txtKSSJ.Text
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
                Session.Add(strNewSessionId, objIEstateRsXzTeam)
                strUrl = ""
                strUrl += "estate_rs_xz_team.aspx"
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
        'zengxianglin 2010-01-02

        'zengxianglin 2010-01-02
        Private Sub doSelectXGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.txtKSSJ.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[��Чʱ��]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSSJ.Text) = False Then
                    strErrMsg = "������Ч��[��Чʱ��][" + Me.txtKSSJ.Text + "]��"
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
                    .iMultiSelect = True
                    .iAllowNull = True
                    .iJCSJ = Me.txtKSSJ.Text
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
                Session.Add(strNewSessionId, objIEstateRsXzTeam)
                strUrl = ""
                strUrl += "estate_rs_xz_team.aspx"
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
        'zengxianglin 2010-01-02

        'zengxianglin 2010-03-08
        Private Sub doAddnewZGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.txtKSSJ.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[��Чʱ��]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSSJ.Text) = False Then
                    strErrMsg = "������Ч��[��Чʱ��][" + Me.txtKSSJ.Text + "]��"
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
                    .iMultiSelect = True
                    .iAllowNull = False
                    .iJCSJ = Me.txtKSSJ.Text
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
                Session.Add(strNewSessionId, objIEstateRsXzTeam)
                strUrl = ""
                strUrl += "estate_rs_xz_team.aspx"
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
        'zengxianglin 2010-03-08

        'zengxianglin 2010-03-18
        Private Sub doAddnewXGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.txtKSSJ.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[��Чʱ��]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSSJ.Text) = False Then
                    strErrMsg = "������Ч��[��Чʱ��][" + Me.txtKSSJ.Text + "]��"
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
                    .iMultiSelect = True
                    .iAllowNull = False
                    .iJCSJ = Me.txtKSSJ.Text
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
                Session.Add(strNewSessionId, objIEstateRsXzTeam)
                strUrl = ""
                strUrl += "estate_rs_xz_team.aspx"
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
        'zengxianglin 2010-03-18

        'zengxianglin 2010-03-08
        Private Sub doDeleteZGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���ѡ��
                Dim i, intCount, intSelected As Integer
                intCount = Me.lstZGTD.Items.Count
                intSelected = 0
                For i = 0 To intCount - 1 Step 1
                    If Me.lstZGTD.Items(i).Selected = True Then
                        intSelected += 1
                    End If
                Next
                If intSelected < 1 Then
                    strErrMsg = "����û��ѡ���κ��Ŷӣ�"
                    GoTo errProc
                End If

                '�Ƴ�����
                Dim strZBBS As String = ""
                If Me.getModuleData_TDZH(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.doDelInBuffer_TDZH(strErrMsg, Me.lstZGTD, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH, strZBBS) = False Then
                    GoTo errProc
                End If
                If Me.htxtZGTD.Value.Trim <> "" Then
                    If Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtZGTD.Value, Me.m_objDataSet_TDZH) = False Then
                        GoTo errProc
                    End If
                End If
                If strZBBS <> "" Then
                    Me.htxtZGTD.Value = strZBBS
                End If
                If Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstZGTD) = False Then
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
        'zengxianglin 2010-03-08

        'zengxianglin 2010-03-08
        Private Sub doDeleteXGTD(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���ѡ��
                Dim i, intCount, intSelected As Integer
                intCount = Me.lstXGTD.Items.Count
                intSelected = 0
                For i = 0 To intCount - 1 Step 1
                    If Me.lstXGTD.Items(i).Selected = True Then
                        intSelected += 1
                    End If
                Next
                If intSelected < 1 Then
                    strErrMsg = "����û��ѡ���κ��Ŷӣ�"
                    GoTo errProc
                End If

                '�Ƴ�����
                Dim strZBBS As String = ""
                If Me.getModuleData_TDZH(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.doDelInBuffer_TDZH(strErrMsg, Me.lstXGTD, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH, strZBBS) = False Then
                    GoTo errProc
                End If
                If Me.htxtXGTD.Value.Trim <> "" Then
                    If Me.doDeleteBuffer_TDZH(strErrMsg, Me.htxtXGTD.Value, Me.m_objDataSet_TDZH) = False Then
                        GoTo errProc
                    End If
                End If
                If strZBBS <> "" Then
                    Me.htxtXGTD.Value = strZBBS
                End If
                If Me.doDisplayBuffer_TDZH(strErrMsg, strZBBS, Me.m_objDataSet_TDZH, Me.lstXGTD) = False Then
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
        'zengxianglin 2010-03-08

        Private Sub btnSelectSJLD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectSJLD.Click
            Me.doSelectSJLD("btnSelectSJLD")
        End Sub

        Private Sub btnSelectZZDM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZZDM.Click
            Me.doSelectZZDM("btnSelectZZDM")
        End Sub

        'zengxianglin 2008-11-18
        Private Sub btnSelectZGDW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZGDW.Click
            Me.doSelectZGDW("btnSelectZGDW")
        End Sub
        'zengxianglin 2008-11-18

        Private Sub btnJSFZLB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJSFZLB.Click
            Me.doJSFZLB("btnJSFZLB")
        End Sub

        'zengxianglin 2010-01-02
        Private Sub btnSelectTDBH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectTDBH.Click
            Me.doSelectTDBH("btnSelectTDBH")
        End Sub
        'zengxianglin 2010-01-02

        'zengxianglin 2010-01-02
        Private Sub btnSelectZGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectZGTD.Click
            Me.doSelectZGTD("btnSelectZGTD")
        End Sub
        'zengxianglin 2010-01-02

        'zengxianglin 2010-01-02
        Private Sub btnSelectXGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelectXGTD.Click
            Me.doSelectXGTD("btnSelectXGTD")
        End Sub
        'zengxianglin 2010-01-02

        'zengxianglin 2010-03-18
        Private Sub btnAddnewZGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddnewZGTD.Click
            Me.doAddnewZGTD("btnAddnewZGTD")
        End Sub
        'zengxianglin 2010-03-18

        'zengxianglin 2010-03-18
        Private Sub btnAddnewXGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddnewXGTD.Click
            Me.doAddnewXGTD("btnAddnewXGTD")
        End Sub
        'zengxianglin 2010-03-18

        'zengxianglin 2010-03-18
        Private Sub btnDeleteZGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteZGTD.Click
            Me.doDeleteZGTD("btnDeleteZGTD")
        End Sub
        'zengxianglin 2010-03-18

        'zengxianglin 2010-03-18
        Private Sub btnDeleteXGTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteXGTD.Click
            Me.doDeleteXGTD("btnDeleteXGTD")
        End Sub
        'zengxianglin 2010-03-18










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
                If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
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
                        If Me.htxtRYSessionIdQuery.Value.Trim <> "" Then
                            .iDataSetTJ = CType(Session(Me.htxtRYSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
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

        Private Sub btnSearchFull_RY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchFull_RY.Click
            Me.doSearchFull_RY("btnSearchFull_RY")
        End Sub















        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
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

        Private Sub doModify(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objNewDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                Dim intIndex As Integer = Me.grdRY.SelectedIndex
                Dim intColIndex As Integer
                Dim strWYBS As String = ""
                Dim strRYMC As String = ""
                Dim intRYLX As Integer

                intStep = 1
                '���
                '======================================================================================================================================================
                If Me.grdRY.SelectedIndex < 0 Then
                    strErrMsg = "����û��Ҫ���ĵ���Ϣ��"
                    GoTo errProc
                End If
                '======================================================================================================================================================
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYLX)
                intRYLX = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex), 0)
                '======================================================================================================================================================
                If Me.ddlZJDM.SelectedIndex < 0 Then
                    strErrMsg = "����û��ָ��[ְ��]��"
                    GoTo errProc
                End If
                '======================================================================================================================================================
                If Me.rblRYZT.SelectedIndex < 0 Then
                    strErrMsg = "����û��ָ��[��ʽְ��]��[������Ա]��"
                    GoTo errProc
                End If
                '======================================================================================================================================================
                If Me.rblSFZB.SelectedIndex < 0 Then
                    strErrMsg = "����û��ָ��[������Ա]��[������Ա]��"
                    GoTo errProc
                End If
                '======================================================================================================================================================
                If Me.htxtZZDM.Value.Trim = "" Then
                    strErrMsg = "����û��ָ��[������λ]��"
                    GoTo errProc
                End If
                '======================================================================================================================================================
                If Me.txtKSSJ.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[��Чʱ��]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtKSSJ.Text) = False Then
                    strErrMsg = "����[" + Me.txtKSSJ.Text + "]����Ч��ʱ�䣡"
                    GoTo errProc
                End If
                Me.txtKSSJ.Text = CType(Me.txtKSSJ.Text, System.DateTime).ToString("yyyy-MM-dd HH:mm:ss")
                If Me.txtJSSJ.Text.Trim <> "" Then
                    If objPulicParameters.isDatetimeString(Me.txtJSSJ.Text) = False Then
                        strErrMsg = "����[" + Me.txtJSSJ.Text + "]����Ч��ʱ�䣡"
                        GoTo errProc
                    End If
                    Me.txtJSSJ.Text = CType(Me.txtJSSJ.Text, System.DateTime).ToString("yyyy-MM-dd HH:mm:ss")
                    If CType(Me.txtKSSJ.Text, System.DateTime) >= CType(Me.txtJSSJ.Text, System.DateTime) Then
                        strErrMsg = "����[ʧЧʱ��]�������[��Чʱ��]��"
                        GoTo errProc
                    End If
                End If
                '======================================================================================================================================================
                'zengxianglin 2010-01-05
                If Me.ddlYDYY.SelectedIndex < 0 Then
                    strErrMsg = "���󣺱���ָ��[�䶯ԭ��]��"
                    GoTo errProc
                End If
                'zengxianglin 2010-01-05
                '======================================================================================================================================================
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_WYBS)
                strWYBS = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex), "")
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC)
                strRYMC = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex), "")
                '======================================================================================================================================================

                'zengxianglin 2010-01-02
                '����������׼�Ƿ�ƥ�䣿
                Dim strKSSJ_Old As String = ""
                Dim intBZXL(3) As Integer
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ)
                strKSSJ_Old = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(intIndex), intColIndex), "")
                If objsystemEstateRenshiXingye.getBZXL_RSJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtKSSJ.Text, intBZXL(0)) = False Then
                    GoTo errProc
                End If
                If objsystemEstateRenshiXingye.getBZXL_RSJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.txtJSSJ.Text, intBZXL(1)) = False Then
                    GoTo errProc
                End If
                If objsystemEstateRenshiXingye.getBZXL_RSJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, strKSSJ_Old, intBZXL(2)) = False Then
                    GoTo errProc
                End If
                If intBZXL(0) <> intBZXL(1) Or intBZXL(0) <> intBZXL(2) Or intBZXL(1) <> intBZXL(2) Then
                    strErrMsg = "����[��Чʱ��]��[ʧЧʱ��]�뵱ʱ����ģʽִ��ʱ�䲻ƥ�䣡"
                    GoTo errProc
                End If
                Select Case intBZXL(0)
                    Case 1 '����ģʽһ
                    Case 2 '����ģʽ��
                    Case Else
                        strErrMsg = "���󣺲�֧�ֵĹ���ģʽ��"
                        GoTo errProc
                End Select
                'zengxianglin 2010-01-02

                intStep = 2
                'ȷ��
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "���棺��ȷ���������������ȷ��ȷ��/ȡ������", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '����
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��ȡ���ݼ�
                    If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2010-01-02
                    If Me.getModuleData_TDZH(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2010-01-02

                    '��ȡ��ǰ��¼��
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intRecPos As Integer
                    With Me.grdRY
                        intRecPos = objDataGridProcess.getRecordPosition(.SelectedIndex, .CurrentPageIndex, .PageSize)
                    End With
                    With Me.m_objDataSet_RY.Tables(strTable)
                        objOldData = .DefaultView.Item(intRecPos).Row
                    End With

                    '��ȡҪ�ύ��������
                    Dim objNewData As System.Data.DataRow = Nothing
                    Dim intCols As Integer
                    Dim i As Integer
                    objNewDataSet = New Josco.JSOA.Common.Data.estateRenshiXingyeData(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_V_RS_RENYUANJIAGOU)
                    With objNewDataSet.Tables(strTable)
                        objNewData = .NewRow()
                        '****************************************************************************
                        intCols = .Columns.Count
                        For i = 0 To intCols - 1 Step 1
                            objNewData.Item(i) = objOldData.Item(i)
                        Next
                        '****************************************************************************
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ) = CType(Me.txtKSSJ.Text, System.DateTime)
                        If Me.txtJSSJ.Text.Trim = "" Then
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_JSSJ) = System.DBNull.Value
                        Else
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_JSSJ) = CType(Me.txtJSSJ.Text, System.DateTime)
                        End If
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDW) = Me.htxtZZDM.Value
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC) = Me.txtZZDM.Text
                        If Me.ddlZJDM.SelectedIndex < 0 Then
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM) = ""
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC) = ""
                        Else
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM) = Me.ddlZJDM.SelectedItem.Value
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC) = Me.ddlZJDM.SelectedItem.Text.Split("|".ToCharArray)(1)
                        End If
                        If Me.rblRYZT.SelectedIndex < 0 Then
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT) = 2
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZTMC) = "��ʽ"
                        Else
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZT) = CType(Me.rblRYZT.SelectedItem.Value, Integer)
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYZTMC) = Me.rblRYZT.SelectedItem.Text
                        End If
                        If Me.rblSFZB.SelectedIndex < 0 Then
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB) = 1
                        Else
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFZB) = CType(Me.rblSFZB.SelectedItem.Value, Integer)
                        End If
                        '****************************************************************************
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SJLD) = Me.htxtSJLD.Value
                        'zengxianglin 2008-11-18
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW) = Me.htxtZGDW.Value
                        'zengxianglin 2008-11-18
                        If Me.ddlSSFZ.SelectedIndex < 0 Then
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ) = ""
                        Else
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ) = Me.ddlSSFZ.SelectedItem.Text
                        End If
                        '****************************************************************************
                        'zengxianglin 2010-01-02
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_BZXL) = Me.htxtBZXL.Value
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_ZGTD) = Me.htxtZGTD.Value
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_XGTD) = Me.htxtXGTD.Value
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_TDBH) = Me.txtTDBH.Text
                        objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_YDYY) = Me.ddlYDYY.SelectedItem.Value
                        If Me.chkSFJZ.Enabled = False Then
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ) = "0"
                        ElseIf Me.chkSFJZ.Checked = True Then
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ) = "1"
                        Else
                            objNewData.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ) = "0"
                        End If
                        'zengxianglin 2010-01-02
                        '****************************************************************************
                        .Rows.Add(objNewData)
                    End With
                    objNewData = objNewDataSet.Tables(strTable).Rows(0)

                    '������Ϣ
                    'zengxianglin 2010-01-02
                    'If objsystemEstateRenshiXingye.doSaveData_RYJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData, objOldData, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate) = False Then
                    '    GoTo errProc
                    'End If
                    If objsystemEstateRenshiXingye.doSaveData_RYJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, objNewData, objOldData, Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate, Me.m_objDataSet_TDZH) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2010-01-02

                    'zengxianglin 2010-01-02
                    '�������
                    With Me.m_objDataSet_TDZH.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH)
                        .Rows.Clear()
                    End With
                    'zengxianglin 2010-01-02

                    '��¼�����־
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]������[" + strRYMC + "]��[��Ա�ܹ�]���ݣ���Ӧ��[Ψһ��ʶ]=" + strWYBS + "��")

                    '������ʾ��Ϣ
                    If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_RY(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objNewDataSet)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objNewDataSet)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doDelete(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_V_RS_RENYUANJIAGOU
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                Dim intSelect As Integer = 0
                Dim intRows As Integer
                Dim i As Integer

                intStep = 1
                '���ѡ��
                intRows = Me.grdRY.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY) = True Then
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
                    '��ȡ����
                    If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                        GoTo errProc
                    End If

                    '���ɾ��
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex(2) As Integer
                    Dim strWYBS As String = ""
                    Dim strRYMC As String = ""
                    Dim intPos As Integer
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_WYBS)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdRY, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_V_RS_RENYUANJIAGOU_RYMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdRY.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdRY) = True Then
                            strWYBS = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intColIndex(0))
                            strRYMC = objDataGridProcess.getDataGridCellValue(Me.grdRY.Items(i), intColIndex(1))

                            '��ȡҪɾ����������
                            With Me.grdRY
                                intPos = objDataGridProcess.getRecordPosition(i, .CurrentPageIndex, .PageSize)
                            End With
                            objOldData = Nothing
                            With Me.m_objDataSet_RY.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            'ɾ������
                            If objsystemEstateRenshiXingye.doDeleteData_RYJG(strErrMsg, MyBase.UserId, MyBase.UserPassword, objOldData) = False Then
                                GoTo errProc
                            End If

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]ɾ����[" + strRYMC + "]��[��Ա�ܹ�]���ݣ���Ӧ��[Ψһ��ʶ]=" + strWYBS + "��")
                        End If
                    Next

                    '������ʾ����
                    If Me.getModuleData_RY(strErrMsg, Me.htxtRYQuery.Value) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_RY(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnMidify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMidify.Click
            Me.doModify("btnMidify")
        End Sub

        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Me.doDelete("btnDelete")
        End Sub

    End Class

End Namespace
