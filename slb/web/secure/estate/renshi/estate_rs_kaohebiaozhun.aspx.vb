Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_rs_kaohebiaozhun
    ' 
    ' �������ʣ�
    '     ��������
    '
    ' ���������� 
    '   �����¿��˱�׼(һ)
    '----------------------------------------------------------------

    Partial Class estate_rs_kaohebiaozhun
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
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_kaohebiaozhun_previlege_param"
        Private m_blnPrevilegeParams(2) As Boolean

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsKaoheBiaozhun
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsKaoheBiaozhun
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdXL��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdXL As String = "chkXL"
        Private Const m_cstrDataGridInDIV_grdXL As String = "divXL"
        Private m_intFixedColumns_grdXL As Integer
        Private Const m_cstrtxtZBNR01InDataGrid_grdXL As String = "txtZBNR01"
        Private Const m_cstrtxtZBNR02InDataGrid_grdXL As String = "txtZBNR02"
        Private Const m_cstrtxtZBNR03InDataGrid_grdXL As String = "txtZBNR03"

        '----------------------------------------------------------------
        '����������grdDWFH01��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdDWFH01 As String = "chkDWFH01"
        Private Const m_cstrDataGridInDIV_grdDWFH01 As String = "divDWFH01"
        Private m_intFixedColumns_grdDWFH01 As Integer
        '----------------------------------------------------------------
        '����������grdDWFH02��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdDWFH02 As String = "chkDWFH02"
        Private Const m_cstrDataGridInDIV_grdDWFH02 As String = "divDWFH02"
        Private m_intFixedColumns_grdDWFH02 As Integer
        '----------------------------------------------------------------
        '����������grdDWFH03��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdDWFH03 As String = "chkDWFH03"
        Private Const m_cstrDataGridInDIV_grdDWFH03 As String = "divDWFH03"
        Private m_intFixedColumns_grdDWFH03 As Integer

        '----------------------------------------------------------------
        '����������grdDWGLC01��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdDWGLC01 As String = "chkDWGLC01"
        Private Const m_cstrDataGridInDIV_grdDWGLC01 As String = "divDWGLC01"
        Private m_intFixedColumns_grdDWGLC01 As Integer
        '----------------------------------------------------------------
        '����������grdDWGLC02��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdDWGLC02 As String = "chkDWGLC02"
        Private Const m_cstrDataGridInDIV_grdDWGLC02 As String = "divDWGLC02"
        Private m_intFixedColumns_grdDWGLC02 As Integer
        '----------------------------------------------------------------
        '����������grdDWGLC03��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdDWGLC03 As String = "chkDWGLC03"
        Private Const m_cstrDataGridInDIV_grdDWGLC03 As String = "divDWGLC03"
        Private m_intFixedColumns_grdDWGLC03 As Integer

        '----------------------------------------------------------------
        '��ǰ��������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet_XL As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_DWFH01 As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_DWFH02 As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_DWFH03 As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_DWGLC01 As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_DWGLC02 As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_DWGLC03 As Josco.JSOA.Common.Data.estateRenshiXingyeData

        '----------------------------------------------------------------
        '��������
        '----------------------------------------------------------------
        Private m_blnReadOnly As Boolean










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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsKaoheBiaozhun)
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

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftMain.Value = .htxtDivLeftMain
                    Me.htxtDivTopMain.Value = .htxtDivTopMain

                    Me.htxtSessionId_XL.Value = .htxtSessionId_XL
                    Me.htxtSessionId_DWFH01.Value = .htxtSessionId_DWFH01
                    Me.htxtSessionId_DWFH02.Value = .htxtSessionId_DWFH02
                    Me.htxtSessionId_DWFH03.Value = .htxtSessionId_DWFH03
                    Me.htxtSessionId_DWGLC01.Value = .htxtSessionId_DWGLC01
                    Me.htxtSessionId_DWGLC02.Value = .htxtSessionId_DWGLC02
                    Me.htxtSessionId_DWGLC03.Value = .htxtSessionId_DWGLC03

                    Try
                        Me.grdXL.PageSize = .grdXL_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdXL.CurrentPageIndex = .grdXL_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdXL.SelectedIndex = .grdXL_SelectedIndex
                    Catch ex As Exception
                    End Try


                    Try
                        Me.grdDWFH01.PageSize = .grdDWFH01_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWFH01.CurrentPageIndex = .grdDWFH01_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWFH01.SelectedIndex = .grdDWFH01_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWFH02.PageSize = .grdDWFH02_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWFH02.CurrentPageIndex = .grdDWFH02_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWFH02.SelectedIndex = .grdDWFH02_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWFH03.PageSize = .grdDWFH03_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWFH03.CurrentPageIndex = .grdDWFH03_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWFH03.SelectedIndex = .grdDWFH03_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdDWGLC01.PageSize = .grdDWGLC01_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWGLC01.CurrentPageIndex = .grdDWGLC01_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWGLC01.SelectedIndex = .grdDWGLC01_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWGLC02.PageSize = .grdDWGLC02_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWGLC02.CurrentPageIndex = .grdDWGLC02_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWGLC02.SelectedIndex = .grdDWGLC02_SelectedIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWGLC03.PageSize = .grdDWGLC03_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWGLC03.CurrentPageIndex = .grdDWGLC03_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdDWGLC03.SelectedIndex = .grdDWGLC03_SelectedIndex
                    Catch ex As Exception
                    End Try
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsKaoheBiaozhun

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftMain = Me.htxtDivLeftMain.Value
                    .htxtDivTopMain = Me.htxtDivTopMain.Value

                    .htxtSessionId_XL = Me.htxtSessionId_XL.Value
                    .htxtSessionId_DWFH01 = Me.htxtSessionId_DWFH01.Value
                    .htxtSessionId_DWFH02 = Me.htxtSessionId_DWFH02.Value
                    .htxtSessionId_DWFH03 = Me.htxtSessionId_DWFH03.Value
                    .htxtSessionId_DWGLC01 = Me.htxtSessionId_DWGLC01.Value
                    .htxtSessionId_DWGLC02 = Me.htxtSessionId_DWGLC02.Value
                    .htxtSessionId_DWGLC03 = Me.htxtSessionId_DWGLC03.Value

                    .grdXL_PageSize = Me.grdXL.PageSize
                    .grdXL_CurrentPageIndex = Me.grdXL.CurrentPageIndex
                    .grdXL_SelectedIndex = Me.grdXL.SelectedIndex

                    .grdDWFH01_PageSize = Me.grdDWFH01.PageSize
                    .grdDWFH01_CurrentPageIndex = Me.grdDWFH01.CurrentPageIndex
                    .grdDWFH01_SelectedIndex = Me.grdDWFH01.SelectedIndex
                    .grdDWFH02_PageSize = Me.grdDWFH02.PageSize
                    .grdDWFH02_CurrentPageIndex = Me.grdDWFH02.CurrentPageIndex
                    .grdDWFH02_SelectedIndex = Me.grdDWFH02.SelectedIndex
                    .grdDWFH03_PageSize = Me.grdDWFH03.PageSize
                    .grdDWFH03_CurrentPageIndex = Me.grdDWFH03.CurrentPageIndex
                    .grdDWFH03_SelectedIndex = Me.grdDWFH03.SelectedIndex

                    .grdDWGLC01_PageSize = Me.grdDWGLC01.PageSize
                    .grdDWGLC01_CurrentPageIndex = Me.grdDWGLC01.CurrentPageIndex
                    .grdDWGLC01_SelectedIndex = Me.grdDWGLC01.SelectedIndex
                    .grdDWGLC02_PageSize = Me.grdDWGLC02.PageSize
                    .grdDWGLC02_CurrentPageIndex = Me.grdDWGLC02.CurrentPageIndex
                    .grdDWGLC02_SelectedIndex = Me.grdDWGLC02.SelectedIndex
                    .grdDWGLC03_PageSize = Me.grdDWGLC03.PageSize
                    .grdDWGLC03_CurrentPageIndex = Me.grdDWGLC03.CurrentPageIndex
                    .grdDWGLC03_SelectedIndex = Me.grdDWGLC03.SelectedIndex
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

            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer
            Dim objDataRow As System.Data.DataRow = Nothing
            Dim blnExisted As Boolean = False
            Dim strTable As String = ""

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
                        Select Case objIDmxzJbdm.iSourceControlId.ToUpper()
                            Case "btnAddNew_XL".ToUpper()
                                If Me.getModuleData_XL(strErrMsg) = True Then
                                    If Me.isExisted_XL(strErrMsg, objIDmxzJbdm.oCodeValue, Me.m_objDataSet_XL, blnExisted) = True Then
                                        If blnExisted = False Then
                                            strTable = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_XL
                                            With Me.m_objDataSet_XL.Tables(strTable)
                                                objDataRow = .NewRow()
                                            End With
                                            With objIDmxzJbdm
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZJDM) = .oCodeValue
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZJMC) = .oNameValue
                                            End With
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR01) = ""
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR02) = ""
                                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR03) = ""
                                            With Me.m_objDataSet_XL.Tables(strTable)
                                                .Rows.Add(objDataRow)
                                            End With
                                            '��¼�����־
                                            With objIDmxzJbdm
                                                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_���˱�׼]��������[" + .oNameValue + "]ְ��(��δ����)��")
                                            End With
                                        End If
                                    End If
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzJbdm.SafeRelease(objIDmxzJbdm)
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
                        Dim strArray() As String
                        Dim strList As String = ""
                        Dim strZZDM As String = ""
                        Dim strZZMC As String = ""
                        Dim intCount As Integer = 0
                        Dim i As Integer = 0
                        Select Case objIDmxzZzjg.iSourceControlId.ToUpper()
                            Case "btnAddNew_DWFH01".ToUpper()
                                If Me.getAllDataSet_DW(strErrMsg) = True Then
                                    strList = objIDmxzZzjg.oBumenList
                                    strArray = strList.Split(strSep.ToCharArray)
                                    intCount = strArray.Length
                                    For i = 0 To intCount - 1 Step 1
                                        strZZMC = strArray(i)
                                        If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                            If Me.isExisted_DW(strErrMsg, strZZDM, blnExisted) = True Then
                                                If blnExisted = False Then
                                                    strTable = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
                                                    With Me.m_objDataSet_DWFH01.Tables(strTable)
                                                        objDataRow = .NewRow()
                                                    End With
                                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_SYDW) = strZZDM
                                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_DWMC) = strZZMC
                                                    With Me.m_objDataSet_DWFH01.Tables(strTable)
                                                        .Rows.Add(objDataRow)
                                                    End With
                                                    '��¼�����־
                                                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_���˱�׼]��[ִ�з�������һ]��������[" + strZZMC + "]��λ(��δ����)��")
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            Case "btnAddNew_DWFH02".ToUpper()
                                If Me.getAllDataSet_DW(strErrMsg) = True Then
                                    strList = objIDmxzZzjg.oBumenList
                                    strArray = strList.Split(strSep.ToCharArray)
                                    intCount = strArray.Length
                                    For i = 0 To intCount - 1 Step 1
                                        strZZMC = strArray(i)
                                        If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                            If Me.isExisted_DW(strErrMsg, strZZDM, blnExisted) = True Then
                                                If blnExisted = False Then
                                                    strTable = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
                                                    With Me.m_objDataSet_DWFH02.Tables(strTable)
                                                        objDataRow = .NewRow()
                                                    End With
                                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_SYDW) = strZZDM
                                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_DWMC) = strZZMC
                                                    With Me.m_objDataSet_DWFH02.Tables(strTable)
                                                        .Rows.Add(objDataRow)
                                                    End With
                                                    '��¼�����־
                                                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_���˱�׼]��[ִ�з������ж�]��������[" + strZZMC + "]��λ(��δ����)��")
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            Case "btnAddNew_DWFH03".ToUpper()
                                If Me.getAllDataSet_DW(strErrMsg) = True Then
                                    strList = objIDmxzZzjg.oBumenList
                                    strArray = strList.Split(strSep.ToCharArray)
                                    intCount = strArray.Length
                                    For i = 0 To intCount - 1 Step 1
                                        strZZMC = strArray(i)
                                        If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                            If Me.isExisted_DW(strErrMsg, strZZDM, blnExisted) = True Then
                                                If blnExisted = False Then
                                                    strTable = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
                                                    With Me.m_objDataSet_DWFH03.Tables(strTable)
                                                        objDataRow = .NewRow()
                                                    End With
                                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_SYDW) = strZZDM
                                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_DWMC) = strZZMC
                                                    With Me.m_objDataSet_DWFH03.Tables(strTable)
                                                        .Rows.Add(objDataRow)
                                                    End With
                                                    '��¼�����־
                                                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_���˱�׼]��[ִ�з���������]��������[" + strZZMC + "]��λ(��δ����)��")
                                                End If
                                            End If
                                        End If
                                    Next
                                End If

                            Case "btnAddNew_DWGLC01".ToUpper()
                                If Me.getAllDataSet_DW(strErrMsg) = True Then
                                    strList = objIDmxzZzjg.oBumenList
                                    strArray = strList.Split(strSep.ToCharArray)
                                    intCount = strArray.Length
                                    For i = 0 To intCount - 1 Step 1
                                        strZZMC = strArray(i)
                                        If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                            If Me.isExisted_DW(strErrMsg, strZZDM, blnExisted) = True Then
                                                If blnExisted = False Then
                                                    strTable = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
                                                    With Me.m_objDataSet_DWGLC01.Tables(strTable)
                                                        objDataRow = .NewRow()
                                                    End With
                                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_SYDW) = strZZDM
                                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_DWMC) = strZZMC
                                                    With Me.m_objDataSet_DWGLC01.Tables(strTable)
                                                        .Rows.Add(objDataRow)
                                                    End With
                                                    '��¼�����־
                                                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_���˱�׼]��[ִ�й�������һ]��������[" + strZZMC + "]��λ(��δ����)��")
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            Case "btnAddNew_DWGLC02".ToUpper()
                                If Me.getAllDataSet_DW(strErrMsg) = True Then
                                    strList = objIDmxzZzjg.oBumenList
                                    strArray = strList.Split(strSep.ToCharArray)
                                    intCount = strArray.Length
                                    For i = 0 To intCount - 1 Step 1
                                        strZZMC = strArray(i)
                                        If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                            If Me.isExisted_DW(strErrMsg, strZZDM, blnExisted) = True Then
                                                If blnExisted = False Then
                                                    strTable = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
                                                    With Me.m_objDataSet_DWGLC02.Tables(strTable)
                                                        objDataRow = .NewRow()
                                                    End With
                                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_SYDW) = strZZDM
                                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_DWMC) = strZZMC
                                                    With Me.m_objDataSet_DWGLC02.Tables(strTable)
                                                        .Rows.Add(objDataRow)
                                                    End With
                                                    '��¼�����־
                                                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_���˱�׼]��[ִ�й������ж�]��������[" + strZZMC + "]��λ(��δ����)��")
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            Case "btnAddNew_DWGLC03".ToUpper()
                                If Me.getAllDataSet_DW(strErrMsg) = True Then
                                    strList = objIDmxzZzjg.oBumenList
                                    strArray = strList.Split(strSep.ToCharArray)
                                    intCount = strArray.Length
                                    For i = 0 To intCount - 1 Step 1
                                        strZZMC = strArray(i)
                                        If objsystemCustomer.getZzdmByZzmc(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZZMC, strZZDM) = True Then
                                            If Me.isExisted_DW(strErrMsg, strZZDM, blnExisted) = True Then
                                                If blnExisted = False Then
                                                    strTable = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
                                                    With Me.m_objDataSet_DWGLC03.Tables(strTable)
                                                        objDataRow = .NewRow()
                                                    End With
                                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_SYDW) = strZZDM
                                                    objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_DWMC) = strZZMC
                                                    With Me.m_objDataSet_DWGLC03.Tables(strTable)
                                                        .Rows.Add(objDataRow)
                                                    End With
                                                    '��¼�����־
                                                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_���˱�׼]��[ִ�й���������]��������[" + strZZMC + "]��λ(��δ����)��")
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                        End Select
                    End If
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JsKernal.BusinessFacade.IDmxzZzjg.SafeRelease(objIDmxzZzjg)
                    Exit Try
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)

            getDataFromCallModule = True
            Exit Function
errProc:
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsKaoheBiaozhun)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsKaoheBiaozhun)
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

                Me.m_intFixedColumns_grdXL = objPulicParameters.getObjectValue(Me.htxtXLFixed.Value, 0)
                Me.m_intFixedColumns_grdDWFH01 = objPulicParameters.getObjectValue(Me.htxtDWFH01Fixed.Value, 0)
                Me.m_intFixedColumns_grdDWFH02 = objPulicParameters.getObjectValue(Me.htxtDWFH02Fixed.Value, 0)
                Me.m_intFixedColumns_grdDWFH03 = objPulicParameters.getObjectValue(Me.htxtDWFH03Fixed.Value, 0)
                Me.m_intFixedColumns_grdDWGLC01 = objPulicParameters.getObjectValue(Me.htxtDWGLC01Fixed.Value, 0)
                Me.m_intFixedColumns_grdDWGLC02 = objPulicParameters.getObjectValue(Me.htxtDWGLC02Fixed.Value, 0)
                Me.m_intFixedColumns_grdDWGLC03 = objPulicParameters.getObjectValue(Me.htxtDWGLC03Fixed.Value, 0)

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
                If Me.htxtSessionId_XL.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_XL.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_XL.Value)
                End If

                If Me.htxtSessionId_DWFH01.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_DWFH01.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_DWFH01.Value)
                End If
                If Me.htxtSessionId_DWFH02.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_DWFH02.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_DWFH02.Value)
                End If
                If Me.htxtSessionId_DWFH03.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_DWFH03.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_DWFH03.Value)
                End If

                If Me.htxtSessionId_DWGLC01.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_DWGLC01.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_DWGLC01.Value)
                End If
                If Me.htxtSessionId_DWGLC02.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_DWGLC02.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_DWGLC02.Value)
                End If
                If Me.htxtSessionId_DWGLC03.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_DWGLC03.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_DWGLC03.Value)
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub










        '----------------------------------------------------------------
        ' ��ȡgrdXLҪ��ʾ������ - ���˱�׼����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_XL(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_XL
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_XL = False

            Try
                If Me.htxtSessionId_XL.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_XL = CType(Session.Item(Me.htxtSessionId_XL.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_XL)

                    '���¼�������
                    If objsystemEstateRenshiXingye.getDataSet_Khbz_XL(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_XL) = False Then
                        GoTo errProc
                    End If

                    '��������
                    Me.htxtSessionId_XL.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_XL.Value, Me.m_objDataSet_XL)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_XL = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdDWFH01Ҫ��ʾ������ - ������01�ж���ķ���
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_DWFH01(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_DWFH01 = False

            Try
                If Me.htxtSessionId_DWFH01.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_DWFH01 = CType(Session.Item(Me.htxtSessionId_DWFH01.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_DWFH01)

                    '���¼�������
                    Dim intZbxl As Integer = Josco.JSOA.Common.Data.estateRenshiXingyeData.enumKaoheXulie.x1
                    Dim intDwbz As Integer = Josco.JsKernal.Common.Data.CustomerData.enumDanweiLeixing.Fenhang
                    If objsystemEstateRenshiXingye.getDataSet_Khbz_DW(strErrMsg, MyBase.UserId, MyBase.UserPassword, intZbxl, intDwbz, Me.m_objDataSet_DWFH01) = False Then
                        GoTo errProc
                    End If

                    '��������
                    Me.htxtSessionId_DWFH01.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_DWFH01.Value, Me.m_objDataSet_DWFH01)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_DWFH01 = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdDWFH02Ҫ��ʾ������ - ������02�ж���ķ���
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_DWFH02(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_DWFH02 = False

            Try
                If Me.htxtSessionId_DWFH02.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_DWFH02 = CType(Session.Item(Me.htxtSessionId_DWFH02.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_DWFH02)

                    '���¼�������
                    Dim intZbxl As Integer = Josco.JSOA.Common.Data.estateRenshiXingyeData.enumKaoheXulie.x2
                    Dim intDwbz As Integer = Josco.JsKernal.Common.Data.CustomerData.enumDanweiLeixing.Fenhang
                    If objsystemEstateRenshiXingye.getDataSet_Khbz_DW(strErrMsg, MyBase.UserId, MyBase.UserPassword, intZbxl, intDwbz, Me.m_objDataSet_DWFH02) = False Then
                        GoTo errProc
                    End If

                    '��������
                    Me.htxtSessionId_DWFH02.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_DWFH02.Value, Me.m_objDataSet_DWFH02)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_DWFH02 = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdDWFH03Ҫ��ʾ������ - ������03�ж���ķ���
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_DWFH03(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_DWFH03 = False

            Try
                If Me.htxtSessionId_DWFH03.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_DWFH03 = CType(Session.Item(Me.htxtSessionId_DWFH03.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_DWFH03)

                    '���¼�������
                    Dim intZbxl As Integer = Josco.JSOA.Common.Data.estateRenshiXingyeData.enumKaoheXulie.x3
                    Dim intDwbz As Integer = Josco.JsKernal.Common.Data.CustomerData.enumDanweiLeixing.Fenhang
                    If objsystemEstateRenshiXingye.getDataSet_Khbz_DW(strErrMsg, MyBase.UserId, MyBase.UserPassword, intZbxl, intDwbz, Me.m_objDataSet_DWFH03) = False Then
                        GoTo errProc
                    End If

                    '��������
                    Me.htxtSessionId_DWFH03.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_DWFH03.Value, Me.m_objDataSet_DWFH03)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_DWFH03 = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdDWGLC01Ҫ��ʾ������ - ������01�ж���Ĺ���
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_DWGLC01(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_DWGLC01 = False

            Try
                If Me.htxtSessionId_DWGLC01.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_DWGLC01 = CType(Session.Item(Me.htxtSessionId_DWGLC01.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_DWGLC01)

                    '���¼�������
                    Dim intZbxl As Integer = Josco.JSOA.Common.Data.estateRenshiXingyeData.enumKaoheXulie.x1
                    Dim intDwbz As Integer = Josco.JsKernal.Common.Data.CustomerData.enumDanweiLeixing.Guanlichu
                    If objsystemEstateRenshiXingye.getDataSet_Khbz_DW(strErrMsg, MyBase.UserId, MyBase.UserPassword, intZbxl, intDwbz, Me.m_objDataSet_DWGLC01) = False Then
                        GoTo errProc
                    End If

                    '��������
                    Me.htxtSessionId_DWGLC01.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_DWGLC01.Value, Me.m_objDataSet_DWGLC01)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_DWGLC01 = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdDWGLC02Ҫ��ʾ������ - ������02�ж���Ĺ���
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_DWGLC02(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_DWGLC02 = False

            Try
                If Me.htxtSessionId_DWGLC02.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_DWGLC02 = CType(Session.Item(Me.htxtSessionId_DWGLC02.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_DWGLC02)

                    '���¼�������
                    Dim intZbxl As Integer = Josco.JSOA.Common.Data.estateRenshiXingyeData.enumKaoheXulie.x2
                    Dim intDwbz As Integer = Josco.JsKernal.Common.Data.CustomerData.enumDanweiLeixing.Guanlichu
                    If objsystemEstateRenshiXingye.getDataSet_Khbz_DW(strErrMsg, MyBase.UserId, MyBase.UserPassword, intZbxl, intDwbz, Me.m_objDataSet_DWGLC02) = False Then
                        GoTo errProc
                    End If

                    '��������
                    Me.htxtSessionId_DWGLC02.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_DWGLC02.Value, Me.m_objDataSet_DWGLC02)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_DWGLC02 = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdDWGLC03Ҫ��ʾ������ - ������03�ж���Ĺ���
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_DWGLC03(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_DWGLC03 = False

            Try
                If Me.htxtSessionId_DWGLC03.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_DWGLC03 = CType(Session.Item(Me.htxtSessionId_DWGLC03.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_DWGLC03)

                    '���¼�������
                    Dim intZbxl As Integer = Josco.JSOA.Common.Data.estateRenshiXingyeData.enumKaoheXulie.x3
                    Dim intDwbz As Integer = Josco.JsKernal.Common.Data.CustomerData.enumDanweiLeixing.Guanlichu
                    If objsystemEstateRenshiXingye.getDataSet_Khbz_DW(strErrMsg, MyBase.UserId, MyBase.UserPassword, intZbxl, intDwbz, Me.m_objDataSet_DWGLC03) = False Then
                        GoTo errProc
                    End If

                    '��������
                    Me.htxtSessionId_DWGLC03.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_DWGLC03.Value, Me.m_objDataSet_DWGLC03)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_DWGLC03 = True
            Exit Function

errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function












        '----------------------------------------------------------------
        ' ����grdXL�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnValid       ��true-ִ����Ч�Լ��,false-��ִ��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_XL(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_XL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_XL = False
            strErrMsg = ""

            Try
                '����δ������
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdXL.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdXL.CurrentPageIndex, Me.grdXL.PageSize)
                    objDataRow = Me.m_objDataSet_XL.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '����ZBNR01
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXL.Items(i).FindControl(Me.m_cstrtxtZBNR01InDataGrid_grdXL), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR01) = objTextBox.Text
                    End If

                    '����ZBNR02
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXL.Items(i).FindControl(Me.m_cstrtxtZBNR02InDataGrid_grdXL), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR02) = objTextBox.Text
                    End If

                    '����ZBNR03
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXL.Items(i).FindControl(Me.m_cstrtxtZBNR03InDataGrid_grdXL), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR03) = objTextBox.Text
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_XL = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdXL�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_XL(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_XL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_XL = False
            strErrMsg = ""

            Try
                '��ʾδ������
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdXL.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdXL.CurrentPageIndex, Me.grdXL.PageSize)
                    objDataRow = Me.m_objDataSet_XL.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���ZBNR01
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXL.Items(i).FindControl(Me.m_cstrtxtZBNR01InDataGrid_grdXL), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR01), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '���ZBNR02
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXL.Items(i).FindControl(Me.m_cstrtxtZBNR02InDataGrid_grdXL), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR02), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '���ZBNR03
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdXL.Items(i).FindControl(Me.m_cstrtxtZBNR03InDataGrid_grdXL), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR03), "")
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If
                Next

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showDataGridUnboundInfo_XL = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdXL������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_XL(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_XL
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_XL = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_XL Is Nothing Then
                    Me.grdXL.DataSource = Nothing
                Else
                    With Me.m_objDataSet_XL.Tables(strTable)
                        Me.grdXL.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_XL.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdXL, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdXL.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdXL, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdXL) = False Then
                    GoTo errProc
                End If

                '��ʾ����δ������
                If Me.showDataGridUnboundInfo_XL(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_XL = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdDWFH01������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_DWFH01(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_DWFH01 = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_DWFH01 Is Nothing Then
                    Me.grdDWFH01.DataSource = Nothing
                Else
                    With Me.m_objDataSet_DWFH01.Tables(strTable)
                        Me.grdDWFH01.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_DWFH01.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdDWFH01, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdDWFH01.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdDWFH01, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH01) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_DWFH01 = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdDWFH02������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_DWFH02(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_DWFH02 = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_DWFH02 Is Nothing Then
                    Me.grdDWFH02.DataSource = Nothing
                Else
                    With Me.m_objDataSet_DWFH02.Tables(strTable)
                        Me.grdDWFH02.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_DWFH02.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdDWFH02, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdDWFH02.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdDWFH02, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH02) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_DWFH02 = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdDWFH03������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_DWFH03(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_DWFH03 = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_DWFH03 Is Nothing Then
                    Me.grdDWFH03.DataSource = Nothing
                Else
                    With Me.m_objDataSet_DWFH03.Tables(strTable)
                        Me.grdDWFH03.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_DWFH03.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdDWFH03, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdDWFH03.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdDWFH03, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH03) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_DWFH03 = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdDWGLC01������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_DWGLC01(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_DWGLC01 = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_DWGLC01 Is Nothing Then
                    Me.grdDWGLC01.DataSource = Nothing
                Else
                    With Me.m_objDataSet_DWGLC01.Tables(strTable)
                        Me.grdDWGLC01.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_DWGLC01.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdDWGLC01, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdDWGLC01.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdDWGLC01, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC01) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_DWGLC01 = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdDWGLC02������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_DWGLC02(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_DWGLC02 = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_DWGLC02 Is Nothing Then
                    Me.grdDWGLC02.DataSource = Nothing
                Else
                    With Me.m_objDataSet_DWGLC02.Tables(strTable)
                        Me.grdDWGLC02.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_DWGLC02.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdDWGLC02, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdDWGLC02.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdDWGLC02, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC02) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_DWGLC02 = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdDWGLC03������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_DWGLC03(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_DWGLC03 = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_DWGLC03 Is Nothing Then
                    Me.grdDWGLC03.DataSource = Nothing
                Else
                    With Me.m_objDataSet_DWGLC03.Tables(strTable)
                        Me.grdDWGLC03.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_DWGLC03.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdDWGLC03, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdDWGLC03.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdDWGLC03, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC03) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_DWGLC03 = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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
                Me.btnAddNew_XL.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_XL.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_XL.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_XL.Visible = Not Me.m_blnReadOnly

                Me.btnAddNew_DWFH01.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_DWFH01.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_DWFH01.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_DWFH01.Visible = Not Me.m_blnReadOnly
                Me.btnAddNew_DWFH02.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_DWFH02.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_DWFH02.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_DWFH02.Visible = Not Me.m_blnReadOnly
                Me.btnAddNew_DWFH03.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_DWFH03.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_DWFH03.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_DWFH03.Visible = Not Me.m_blnReadOnly

                Me.btnAddNew_DWGLC01.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_DWGLC01.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_DWGLC01.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_DWGLC01.Visible = Not Me.m_blnReadOnly
                Me.btnAddNew_DWGLC02.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_DWGLC02.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_DWGLC02.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_DWGLC02.Visible = Not Me.m_blnReadOnly
                Me.btnAddNew_DWGLC03.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_DWGLC03.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_DWGLC03.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_DWGLC03.Visible = Not Me.m_blnReadOnly

                Me.btnOK.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnCancel.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnClose.Visible = Not Me.btnOK.Visible

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showModuleData_Main = True
            Exit Function

errProc:
            Exit Function

        End Function

        Private Function getAllDataSet_DW(ByRef strErrMsg As String) As Boolean

            getAllDataSet_DW = False
            strErrMsg = ""

            If Me.getModuleData_DWFH01(strErrMsg) = False Then
                GoTo errProc
            End If
            If Me.getModuleData_DWFH02(strErrMsg) = False Then
                GoTo errProc
            End If
            If Me.getModuleData_DWFH03(strErrMsg) = False Then
                GoTo errProc
            End If
            If Me.getModuleData_DWGLC01(strErrMsg) = False Then
                GoTo errProc
            End If
            If Me.getModuleData_DWGLC02(strErrMsg) = False Then
                GoTo errProc
            End If
            If Me.getModuleData_DWGLC03(strErrMsg) = False Then
                GoTo errProc
            End If

            getAllDataSet_DW = True
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

                    '��ʾMain
                    If Me.showModuleData_Main(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾgrdXL
                    If Me.getModuleData_XL(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_XL(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾgrdDWFH01
                    If Me.getModuleData_DWFH01(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_DWFH01(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    '��ʾgrdDWFH02
                    If Me.getModuleData_DWFH02(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_DWFH02(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    '��ʾgrdDWFH03
                    If Me.getModuleData_DWFH03(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_DWFH03(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʾgrdDWGLC01
                    If Me.getModuleData_DWGLC01(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_DWGLC01(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    '��ʾgrdDWGLC02
                    If Me.getModuleData_DWGLC02(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_DWGLC02(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    '��ʾgrdDWGLC03
                    If Me.getModuleData_DWGLC03(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showDataGridInfo_DWGLC03(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    '��ȡ��������
                    If Me.getModuleData_XL(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.getAllDataSet_DW(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '�������ڱ༭����Ϣ
                    If Me.saveDataGridUnboundInfo_XL(strErrMsg, False) = False Then
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
                Me.m_blnReadOnly = Not Me.m_blnPrevilegeParams(1)

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
        Sub grdXL_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdXL.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdXL + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdXL > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdXL - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdXL.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdDWFH01_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdDWFH01.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdDWFH01 + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdDWFH01 > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdDWFH01 - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdDWFH01.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdDWFH02_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdDWFH02.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdDWFH02 + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdDWFH02 > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdDWFH02 - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdDWFH02.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdDWFH03_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdDWFH03.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdDWFH03 + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdDWFH03 > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdDWFH03 - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdDWFH03.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdDWGLC01_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdDWGLC01.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdDWGLC01 + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdDWGLC01 > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdDWGLC01 - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdDWGLC01.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdDWGLC02_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdDWGLC02.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdDWGLC02 + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdDWGLC02 > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdDWGLC02 - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdDWGLC02.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdDWGLC03_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdDWGLC03.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdDWGLC03 + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdDWGLC03 > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdDWGLC03 - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdDWGLC03.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub











        Private Sub doSelectAll_XL(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdXL, 0, Me.m_cstrCheckBoxIdInDataGrid_grdXL, True) = False Then
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

        Private Sub doDeSelectAll_XL(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdXL, 0, Me.m_cstrCheckBoxIdInDataGrid_grdXL, False) = False Then
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

        Private Sub doSelectAll_DWFH01(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdDWFH01, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH01, True) = False Then
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

        Private Sub doDeSelectAll_DWFH01(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdDWFH01, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH01, False) = False Then
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

        Private Sub doSelectAll_DWFH02(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdDWFH02, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH02, True) = False Then
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

        Private Sub doDeSelectAll_DWFH02(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdDWFH02, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH02, False) = False Then
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

        Private Sub doSelectAll_DWFH03(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdDWFH03, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH03, True) = False Then
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

        Private Sub doDeSelectAll_DWFH03(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdDWFH03, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH03, False) = False Then
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

        Private Sub doSelectAll_DWGLC01(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdDWGLC01, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC01, True) = False Then
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

        Private Sub doDeSelectAll_DWGLC01(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdDWGLC01, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC01, False) = False Then
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

        Private Sub doSelectAll_DWGLC02(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdDWGLC02, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC02, True) = False Then
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

        Private Sub doDeSelectAll_DWGLC02(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdDWGLC02, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC02, False) = False Then
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

        Private Sub doSelectAll_DWGLC03(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdDWGLC03, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC03, True) = False Then
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

        Private Sub doDeSelectAll_DWGLC03(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdDWGLC03, 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC03, False) = False Then
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












        Private Sub doDelete_XL(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_XL
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '���ѡ��
                Dim intSelect As Integer = 0
                Dim intRows As Integer = 0
                Dim i As Integer = 0
                intRows = Me.grdXL.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdXL.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdXL) = True Then
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
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex As Integer = 0
                    Dim strName As String = ""
                    Dim intPos As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdXL, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZJMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdXL.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdXL) = True Then
                            strName = objDataGridProcess.getDataGridCellValue(Me.grdXL.Items(i), intColIndex)

                            '��ȡҪɾ��������
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdXL.CurrentPageIndex, Me.grdXL.PageSize)
                            objOldData = Nothing
                            With Me.m_objDataSet_XL.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            'ɾ������
                            With Me.m_objDataSet_XL.Tables(strTable)
                                .Rows.Remove(objOldData)
                            End With

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_���˱�׼]�ֵ���ɾ����[" + strName + "]ְ��(��û����)��")
                        End If
                    Next

                    'ˢ��������ʾ
                    If Me.showDataGridInfo_XL(strErrMsg) = False Then
                        GoTo errProc
                    End If
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

        Private Sub doDelete_DWFH01(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '���ѡ��
                Dim intSelect As Integer = 0
                Dim intRows As Integer = 0
                Dim i As Integer = 0
                intRows = Me.grdDWFH01.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdDWFH01.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH01) = True Then
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
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex As Integer = 0
                    Dim strName As String = ""
                    Dim intPos As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdDWFH01, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_DWMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdDWFH01.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH01) = True Then
                            strName = objDataGridProcess.getDataGridCellValue(Me.grdDWFH01.Items(i), intColIndex)

                            '��ȡҪɾ��������
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdDWFH01.CurrentPageIndex, Me.grdDWFH01.PageSize)
                            objOldData = Nothing
                            With Me.m_objDataSet_DWFH01.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            'ɾ������
                            With Me.m_objDataSet_DWFH01.Tables(strTable)
                                .Rows.Remove(objOldData)
                            End With

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_���˱�׼]�ֵ�[����һ]��ɾ����[" + strName + "]����(��û����)��")
                        End If
                    Next

                    'ˢ��������ʾ
                    If Me.showDataGridInfo_DWFH01(strErrMsg) = False Then
                        GoTo errProc
                    End If
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

        Private Sub doDelete_DWFH02(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '���ѡ��
                Dim intSelect As Integer = 0
                Dim intRows As Integer = 0
                Dim i As Integer = 0
                intRows = Me.grdDWFH02.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdDWFH02.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH02) = True Then
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
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex As Integer = 0
                    Dim strName As String = ""
                    Dim intPos As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdDWFH02, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_DWMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdDWFH02.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH02) = True Then
                            strName = objDataGridProcess.getDataGridCellValue(Me.grdDWFH02.Items(i), intColIndex)

                            '��ȡҪɾ��������
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdDWFH02.CurrentPageIndex, Me.grdDWFH02.PageSize)
                            objOldData = Nothing
                            With Me.m_objDataSet_DWFH02.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            'ɾ������
                            With Me.m_objDataSet_DWFH02.Tables(strTable)
                                .Rows.Remove(objOldData)
                            End With

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_���˱�׼]�ֵ�[���ж�]��ɾ����[" + strName + "]����(��û����)��")
                        End If
                    Next

                    'ˢ��������ʾ
                    If Me.showDataGridInfo_DWFH02(strErrMsg) = False Then
                        GoTo errProc
                    End If
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

        Private Sub doDelete_DWFH03(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '���ѡ��
                Dim intSelect As Integer = 0
                Dim intRows As Integer = 0
                Dim i As Integer = 0
                intRows = Me.grdDWFH03.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdDWFH03.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH03) = True Then
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
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex As Integer = 0
                    Dim strName As String = ""
                    Dim intPos As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdDWFH03, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_DWMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdDWFH03.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWFH03) = True Then
                            strName = objDataGridProcess.getDataGridCellValue(Me.grdDWFH03.Items(i), intColIndex)

                            '��ȡҪɾ��������
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdDWFH03.CurrentPageIndex, Me.grdDWFH03.PageSize)
                            objOldData = Nothing
                            With Me.m_objDataSet_DWFH03.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            'ɾ������
                            With Me.m_objDataSet_DWFH03.Tables(strTable)
                                .Rows.Remove(objOldData)
                            End With

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_���˱�׼]�ֵ�[������]��ɾ����[" + strName + "]����(��û����)��")
                        End If
                    Next

                    'ˢ��������ʾ
                    If Me.showDataGridInfo_DWFH03(strErrMsg) = False Then
                        GoTo errProc
                    End If
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

        Private Sub doDelete_DWGLC01(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '���ѡ��
                Dim intSelect As Integer = 0
                Dim intRows As Integer = 0
                Dim i As Integer = 0
                intRows = Me.grdDWGLC01.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdDWGLC01.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC01) = True Then
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
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex As Integer = 0
                    Dim strName As String = ""
                    Dim intPos As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdDWGLC01, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_DWMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdDWGLC01.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC01) = True Then
                            strName = objDataGridProcess.getDataGridCellValue(Me.grdDWGLC01.Items(i), intColIndex)

                            '��ȡҪɾ��������
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdDWGLC01.CurrentPageIndex, Me.grdDWGLC01.PageSize)
                            objOldData = Nothing
                            With Me.m_objDataSet_DWGLC01.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            'ɾ������
                            With Me.m_objDataSet_DWGLC01.Tables(strTable)
                                .Rows.Remove(objOldData)
                            End With

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_���˱�׼]�ֵ�[����һ]��ɾ����[" + strName + "]����(��û����)��")
                        End If
                    Next

                    'ˢ��������ʾ
                    If Me.showDataGridInfo_DWGLC01(strErrMsg) = False Then
                        GoTo errProc
                    End If
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

        Private Sub doDelete_DWGLC02(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '���ѡ��
                Dim intSelect As Integer = 0
                Dim intRows As Integer = 0
                Dim i As Integer = 0
                intRows = Me.grdDWGLC02.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdDWGLC02.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC02) = True Then
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
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex As Integer = 0
                    Dim strName As String = ""
                    Dim intPos As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdDWGLC02, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_DWMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdDWGLC02.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC02) = True Then
                            strName = objDataGridProcess.getDataGridCellValue(Me.grdDWGLC02.Items(i), intColIndex)

                            '��ȡҪɾ��������
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdDWGLC02.CurrentPageIndex, Me.grdDWGLC02.PageSize)
                            objOldData = Nothing
                            With Me.m_objDataSet_DWGLC02.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            'ɾ������
                            With Me.m_objDataSet_DWGLC02.Tables(strTable)
                                .Rows.Remove(objOldData)
                            End With

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_���˱�׼]�ֵ�[���ж�]��ɾ����[" + strName + "]����(��û����)��")
                        End If
                    Next

                    'ˢ��������ʾ
                    If Me.showDataGridInfo_DWGLC02(strErrMsg) = False Then
                        GoTo errProc
                    End If
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

        Private Sub doDelete_DWGLC03(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Try
                intStep = 1
                '���ѡ��
                Dim intSelect As Integer = 0
                Dim intRows As Integer = 0
                Dim i As Integer = 0
                intRows = Me.grdDWGLC03.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdDWGLC03.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC03) = True Then
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
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex As Integer = 0
                    Dim strName As String = ""
                    Dim intPos As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdDWGLC03, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_DWMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdDWGLC03.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdDWGLC03) = True Then
                            strName = objDataGridProcess.getDataGridCellValue(Me.grdDWGLC03.Items(i), intColIndex)

                            '��ȡҪɾ��������
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdDWGLC03.CurrentPageIndex, Me.grdDWGLC03.PageSize)
                            objOldData = Nothing
                            With Me.m_objDataSet_DWGLC03.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With

                            'ɾ������
                            With Me.m_objDataSet_DWGLC03.Tables(strTable)
                                .Rows.Remove(objOldData)
                            End With

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_���˱�׼]�ֵ�[������]��ɾ����[" + strName + "]����(��û����)��")
                        End If
                    Next

                    'ˢ��������ʾ
                    If Me.showDataGridInfo_DWGLC03(strErrMsg) = False Then
                        GoTo errProc
                    End If
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













        Private Sub doAddNew_XL(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
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
                    .iTitle = "ѡ��ְ��"
                    .iAllowInput = False
                    .iMultiSelect = False
                    .iAllowNull = False
                    .iInitValue = ""
                    .iCodeField = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJDM
                    .iNameField = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_ZHIJIDINGYI_ZJMC
                    .iRowSourceSQL = objsystemEstateRenshiXingye.getTableSQL_ZhijiDingyi()
                    Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                    .iColWidth = "30%" + strSep + "50%" + strSep + "20%"

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

        Private Sub doAddNew_DW(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
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
                    .iMultiSelect = True
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

        Private Function isExisted_XL( _
            ByRef strErrMsg As String, _
            ByVal strZJDM As String, _
            ByVal objDataSet_XL As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef blnExisted As Boolean) As Boolean

            isExisted_XL = False
            strErrMsg = ""
            blnExisted = True

            Try
                '���
                If strZJDM Is Nothing Then strZJDM = ""
                strZJDM = strZJDM.Trim
                If objDataSet_XL Is Nothing Then
                    Exit Try
                End If
                If strZJDM = "" Then
                    Exit Try
                End If

                '����
                Dim strOldFilter As String = ""
                Dim strNewFilter As String = ""
                With objDataSet_XL.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_XL)
                    '����
                    strOldFilter = .DefaultView.RowFilter

                    '������
                    strNewFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZJDM + " = '" + strZJDM + "'"
                    .DefaultView.RowFilter = strNewFilter

                    '�ж�
                    If .DefaultView.Count > 0 Then
                        blnExisted = True
                    Else
                        blnExisted = False
                    End If

                    '��ԭ
                    .DefaultView.RowFilter = strOldFilter
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            isExisted_XL = True
            Exit Function

errProc:
            Exit Function

        End Function

        Private Function isExisted_DW( _
            ByRef strErrMsg As String, _
            ByVal strZZDM As String, _
            ByRef blnExisted As Boolean) As Boolean

            Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing

            isExisted_DW = False
            strErrMsg = ""
            blnExisted = True

            Try
                '���
                If strZZDM Is Nothing Then strZZDM = ""
                strZZDM = strZZDM.Trim
                If strZZDM = "" Then
                    Exit Try
                End If

                '����
                Dim strOldFilter As String = ""
                Dim strNewFilter As String = ""
                Dim intCount As Integer = 6
                Dim i As Integer = 0
                For i = 0 To intCount - 1 Step 1
                    '��ȡ���ݼ�
                    Select Case i
                        Case 0
                            objTempDataSet = Me.m_objDataSet_DWFH01
                        Case 1
                            objTempDataSet = Me.m_objDataSet_DWFH02
                        Case 2
                            objTempDataSet = Me.m_objDataSet_DWFH03
                        Case 3
                            objTempDataSet = Me.m_objDataSet_DWGLC01
                        Case 4
                            objTempDataSet = Me.m_objDataSet_DWGLC02
                        Case 5
                            objTempDataSet = Me.m_objDataSet_DWGLC03
                    End Select
                    '���
                    With objTempDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW)
                        '����
                        strOldFilter = .DefaultView.RowFilter

                        '������
                        strNewFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_SYDW + " = '" + strZZDM + "'"
                        .DefaultView.RowFilter = strNewFilter

                        '�ж�
                        If .DefaultView.Count > 0 Then
                            blnExisted = True
                        Else
                            blnExisted = False
                        End If

                        '��ԭ
                        .DefaultView.RowFilter = strOldFilter

                        '׼���˳�
                        If blnExisted = True Then
                            Exit Try
                        End If
                    End With
                Next

                blnExisted = False

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            isExisted_DW = True
            Exit Function

errProc:
            Exit Function

        End Function

        Private Function isXulieValid(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            isXulieValid = False
            strErrMsg = ""

            Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            isXulieValid = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Sub doOK(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '������䣺ֵ��Ч��
                If Me.saveDataGridUnboundInfo_XL(strErrMsg, True) = False Then
                    GoTo errProc
                End If
                '������䣺������Ч��
                If Me.isXulieValid(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��������
                If objsystemEstateRenshiXingye.doSaveData_KaoheBiaozhun( _
                    strErrMsg, MyBase.UserId, MyBase.UserPassword, _
                    Me.m_objDataSet_XL, _
                    Me.m_objDataSet_DWFH01, Me.m_objDataSet_DWFH02, Me.m_objDataSet_DWFH03, _
                    Me.m_objDataSet_DWGLC01, Me.m_objDataSet_DWGLC02, Me.m_objDataSet_DWGLC03) = False Then
                    GoTo errProc
                End If

                '��¼�����־
                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]�ύ��������[����_���˱�׼]�ĸĶ���")

                '���ش���
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

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnSelAll_XL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_XL.Click
            Me.doSelectAll_XL("btnSelAll_XL")
        End Sub
        Private Sub btnDeSelAll_XL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_XL.Click
            Me.doDeSelectAll_XL("btnDeSelAll_XL")
        End Sub

        Private Sub btnSelAll_DWFH01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_DWFH01.Click
            Me.doSelectAll_DWFH01("btnSelAll_DWFH01")
        End Sub
        Private Sub btnDeSelAll_DWFH01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_DWFH01.Click
            Me.doDeSelectAll_DWFH01("btnDeSelAll_DWFH01")
        End Sub
        Private Sub btnSelAll_DWFH02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_DWFH02.Click
            Me.doSelectAll_DWFH02("btnSelAll_DWFH02")
        End Sub
        Private Sub btnDeSelAll_DWFH02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_DWFH02.Click
            Me.doDeSelectAll_DWFH02("btnDeSelAll_DWFH02")
        End Sub
        Private Sub btnSelAll_DWFH03_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_DWFH03.Click
            Me.doSelectAll_DWFH03("btnSelAll_DWFH03")
        End Sub
        Private Sub btnDeSelAll_DWFH03_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_DWFH03.Click
            Me.doDeSelectAll_DWFH03("btnDeSelAll_DWFH03")
        End Sub

        Private Sub btnSelAll_DWGLC01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_DWGLC01.Click
            Me.doSelectAll_DWGLC01("btnSelAll_DWGLC01")
        End Sub
        Private Sub btnDeSelAll_DWGLC01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_DWGLC01.Click
            Me.doDeSelectAll_DWGLC01("btnDeSelAll_DWGLC01")
        End Sub
        Private Sub btnSelAll_DWGLC02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_DWGLC02.Click
            Me.doSelectAll_DWGLC02("btnSelAll_DWGLC02")
        End Sub
        Private Sub btnDeSelAll_DWGLC02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_DWGLC02.Click
            Me.doDeSelectAll_DWGLC02("btnDeSelAll_DWGLC02")
        End Sub
        Private Sub btnSelAll_DWGLC03_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_DWGLC03.Click
            Me.doSelectAll_DWGLC03("btnSelAll_DWGLC03")
        End Sub
        Private Sub btnDeSelAll_DWGLC03_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_DWGLC03.Click
            Me.doDeSelectAll_DWGLC03("btnDeSelAll_DWGLC03")
        End Sub



        Private Sub btnDelete_XL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_XL.Click
            Me.doDelete_XL("btnDelete_XL")
        End Sub

        Private Sub btnDelete_DWFH01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_DWFH01.Click
            Me.doDelete_DWFH01("btnDelete_DWFH01")
        End Sub
        Private Sub btnDelete_DWFH02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_DWFH02.Click
            Me.doDelete_DWFH02("btnDelete_DWFH02")
        End Sub
        Private Sub btnDelete_DWFH03_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_DWFH03.Click
            Me.doDelete_DWFH03("btnDelete_DWFH03")
        End Sub

        Private Sub btnDelete_DWGLC01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_DWGLC01.Click
            Me.doDelete_DWGLC01("btnDelete_DWGLC01")
        End Sub
        Private Sub btnDelete_DWGLC02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_DWGLC02.Click
            Me.doDelete_DWGLC02("btnDelete_DWGLC02")
        End Sub
        Private Sub btnDelete_DWGLC03_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_DWGLC03.Click
            Me.doDelete_DWGLC03("btnDelete_DWGLC03")
        End Sub


        Private Sub btnAddNew_XL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_XL.Click
            Me.doAddNew_XL("btnAddNew_XL")
        End Sub

        Private Sub btnAddNew_DWFH01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_DWFH01.Click
            Me.doAddNew_DW("btnAddNew_DWFH01")
        End Sub
        Private Sub btnAddNew_DWFH02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_DWFH02.Click
            Me.doAddNew_DW("btnAddNew_DWFH02")
        End Sub
        Private Sub btnAddNew_DWFH03_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_DWFH03.Click
            Me.doAddNew_DW("btnAddNew_DWFH03")
        End Sub

        Private Sub btnAddNew_DWGLC01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_DWGLC01.Click
            Me.doAddNew_DW("btnAddNew_DWGLC01")
        End Sub
        Private Sub btnAddNew_DWGLC02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_DWGLC02.Click
            Me.doAddNew_DW("btnAddNew_DWGLC02")
        End Sub
        Private Sub btnAddNew_DWGLC03_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_DWGLC03.Click
            Me.doAddNew_DW("btnAddNew_DWGLC03")
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
