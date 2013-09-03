Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_rs_bb_kh_jy
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   ��ҵ��Ӣ���˱�
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IEstateRsBbKhJy����
    '
    ' ���ļ�¼
    '     zengxianglin 2010-01-14 ����
    '     zengxianglin 2010-05-06 ����
    '----------------------------------------------------------------

    Partial Class estate_rs_bb_kh_jy
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
        'Url����Excelģ��Ŀ¼·��
        Private m_cstrUrlBaseToExcelMB As String = "/template/excel/"
        'Url���������ļ�Ŀ¼·��
        Private m_cstrUrlBaseToDownloadFile As String = "/temp/downloadfile/"

        '----------------------------------------------------------------
        'ģ����Ȩ����
        '----------------------------------------------------------------
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_baobiao_previlege_param"
        Private m_blnPrevilegeParams(11) As Boolean

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsBbKhJy
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsBbKhJy
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdTJSJ��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_TJSJ As String = "chkTJSJ"
        Private Const m_cstrDataGridInDIV_TJSJ As String = "divTJSJ"
        Private m_intFixedColumns_TJSJ As Integer

        '----------------------------------------------------------------
        'Ҫ���ʵ�����
        '----------------------------------------------------------------
        Private m_objDataSet_TJSJ As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_strQuery_TJSJ As String
        Private m_intRows_TJSJ As Integer
        Private m_intColIndex_TJSJ(2) As Integer









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
                If Me.m_blnPrevilegeParams(0) = True And Me.m_blnPrevilegeParams(10) = True Then
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
                    Me.htxtTJSJSessionId.Value = .htxtTJSJSessionId
                    Me.htxtTJSJQuery.Value = .htxtTJSJQuery
                    Me.htxtTJSJRows.Value = .htxtTJSJRows
                    Me.htxtTJSJSort.Value = .htxtTJSJSort
                    Me.htxtTJSJSortColumnIndex.Value = .htxtTJSJSortColumnIndex
                    Me.htxtTJSJSortType.Value = .htxtTJSJSortType
                    Me.htxtDivLeftTJSJ.Value = .htxtDivLeftTJSJ
                    Me.htxtDivTopTJSJ.Value = .htxtDivTopTJSJ

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody

                    Me.txtTJSJPageIndex.Text = .txtTJSJPageIndex
                    Me.txtTJSJPageSize.Text = .txtTJSJPageSize

                    Try
                        Me.ddlTJSJSearch_XSJB.SelectedIndex = .ddlTJSJSearch_XSJB_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.txtTJND.Text = .txtTJND
                    Me.txtYJZR.Text = .txtYJZR
                    Try
                        Me.ddlTJJD.SelectedIndex = .ddlTJJD_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Me.txtJDKS.Text = .txtJDKS
                    Me.txtJDJS.Text = .txtJDJS

                    Try
                        Me.grdTJSJ.PageSize = .grdTJSJPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdTJSJ.CurrentPageIndex = .grdTJSJCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdTJSJ.SelectedIndex = .grdTJSJSelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsBbKhJy

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtTJSJSessionId = Me.htxtTJSJSessionId.Value
                    .htxtTJSJQuery = Me.htxtTJSJQuery.Value
                    .htxtTJSJRows = Me.htxtTJSJRows.Value
                    .htxtTJSJSort = Me.htxtTJSJSort.Value
                    .htxtTJSJSortColumnIndex = Me.htxtTJSJSortColumnIndex.Value
                    .htxtTJSJSortType = Me.htxtTJSJSortType.Value
                    .htxtDivLeftTJSJ = Me.htxtDivLeftTJSJ.Value
                    .htxtDivTopTJSJ = Me.htxtDivTopTJSJ.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value

                    .txtTJSJPageIndex = Me.txtTJSJPageIndex.Text
                    .txtTJSJPageSize = Me.txtTJSJPageSize.Text

                    .ddlTJSJSearch_XSJB_SelectedIndex = Me.ddlTJSJSearch_XSJB.SelectedIndex

                    .txtTJND = Me.txtTJND.Text
                    .txtYJZR = Me.txtYJZR.Text
                    .ddlTJJD_SelectedIndex = Me.ddlTJJD.SelectedIndex

                    .txtJDKS = Me.txtJDKS.Text
                    .txtJDJS = Me.txtJDJS.Text

                    .grdTJSJPageSize = Me.grdTJSJ.PageSize
                    .grdTJSJCurrentPageIndex = Me.grdTJSJ.CurrentPageIndex
                    .grdTJSJSelectedIndex = Me.grdTJSJ.SelectedIndex
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

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getDataFromCallModule = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
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
        ' ��ȡ�ӿڲ���(û�нӿڲ�������ʾ������Ϣҳ��)
        '----------------------------------------------------------------
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getInterfaceParameters = False
            blnContinue = True

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsBbKhJy)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    'û���нӿڲ���
                    Me.m_blnInterface = False
                Else
                    '�нӿڲ���
                    Me.m_blnInterface = True
                End If

                '����������
                Me.m_intColIndex_TJSJ(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdTJSJ, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_X2_KHJG_JY_XSJB)

                '��ȡ�ָ��ֳ�����
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsBbKhJy)
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

                '��ȡ�ֲ��ӿڲ���
                Me.m_intFixedColumns_TJSJ = objPulicParameters.getObjectValue(Me.htxtTJSJFixed.Value, 0)
                Me.m_intRows_TJSJ = objPulicParameters.getObjectValue(Me.htxtTJSJRows.Value, 0)
                Me.m_strQuery_TJSJ = Me.htxtTJSJQuery.Value
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getInterfaceParameters = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ͷű�ģ�黺��Ĳ���
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                If Me.htxtTJSJSessionId.Value.Trim <> "" Then
                    Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
                    Try
                        objTempDataSet = CType(Session(Me.htxtTJSJSessionId.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objTempDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
                    Session.Remove(Me.htxtTJSJSessionId.Value)
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub










        '----------------------------------------------------------------
        ' ��ȡgrdTJSJ����������(RowFilter��ʽ)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_TJSJ( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_TJSJ = False
            strQuery = ""

            Try
                '������ʾ��������
                Dim strXSJB As String = ""
                strXSJB = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_X2_KHJG_JY_XSJB
                Select Case Me.ddlTJSJSearch_XSJB.SelectedIndex
                    Case Is >= 1
                        If strQuery = "" Then
                            strQuery = strXSJB + Me.ddlTJSJSearch_XSJB.SelectedItem.Value
                        Else
                            strQuery = strQuery + vbCr + " and " + strXSJB + Me.ddlTJSJSearch_XSJB.SelectedItem.Value
                        End If
                End Select
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_TJSJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���㱨�����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getReportParams( _
            ByRef strErrMsg As String, _
            ByRef intTJND As Integer, _
            ByRef intTJJD As Integer, _
            ByRef intYJZR As Integer) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getReportParams = False
            strErrMsg = ""

            Try
                If Me.txtTJND.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[���]��"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtTJND.Text) = False Then
                    strErrMsg = "������Ч��[" + Me.txtTJND.Text + "]��"
                    GoTo errProc
                End If
                intTJND = objPulicParameters.getObjectValue(Me.txtTJND.Text, 0)
                If intTJND <= 0 Then
                    strErrMsg = "������Ч��[" + Me.txtTJND.Text + "]��"
                    GoTo errProc
                End If

                If Me.ddlTJJD.SelectedIndex < 0 Then
                    strErrMsg = "����û��ָ��[����]��"
                    GoTo errProc
                End If
                intTJJD = Me.ddlTJJD.SelectedIndex + 1

                If Me.txtYJZR.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[�½�ֹ��]��"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(Me.txtYJZR.Text) = False Then
                    strErrMsg = "������Ч��[" + Me.txtYJZR.Text + "]��"
                    GoTo errProc
                End If
                intYJZR = objPulicParameters.getObjectValue(Me.txtYJZR.Text, 0)
                If intYJZR <= 0 Then
                    strErrMsg = "������Ч��[" + Me.txtYJZR.Text + "]��"
                    GoTo errProc
                End If
                If intYJZR > 28 Then
                    strErrMsg = "������Ч��[" + Me.txtYJZR.Text + "]��"
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getReportParams = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���㱨�����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getReportParams( _
            ByRef strErrMsg As String, _
            ByRef strJDKS As String, _
            ByRef strJDJS As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getReportParams = False
            strErrMsg = ""
            strJDKS = ""
            strJDJS = ""

            Try
                If Me.txtJDKS.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[���˼��ȿ�ʼ����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtJDKS.Text) = False Then
                    strErrMsg = "������Ч��[" + Me.txtJDKS.Text + "]��"
                    GoTo errProc
                End If
                strJDKS = objPulicParameters.getObjectValue(Me.txtJDKS.Text, "", "yyyy-MM-dd")

                If Me.txtJDJS.Text.Trim = "" Then
                    strErrMsg = "����û��ָ��[���˼��Ƚ�������]��"
                    GoTo errProc
                End If
                If objPulicParameters.isDatetimeString(Me.txtJDJS.Text) = False Then
                    strErrMsg = "������Ч��[" + Me.txtJDJS.Text + "]��"
                    GoTo errProc
                End If
                strJDJS = objPulicParameters.getObjectValue(Me.txtJDJS.Text, "", "yyyy-MM-dd")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getReportParams = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdTJSJҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       ����������
        '     blnEnforced    ��ǿ�����¼���
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_TJSJ( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String, _
            ByVal blnEnforced As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_VT_RS_X2_KHJG_JY
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_TJSJ = False

            Try
                Dim strJDKS As String = ""
                Dim strJDJS As String = ""
                Dim intTJND As Integer
                Dim intTJJD As Integer
                Dim intYJZR As Integer

                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtTJSJSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '��������
                If blnEnforced = True Then
                    '�ͷ���Դ
                    If Me.htxtTJSJSessionId.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_TJSJ = CType(Session(Me.htxtTJSJSessionId.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                        Catch ex As Exception
                            Me.m_objDataSet_TJSJ = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_TJSJ)
                    Else
                        Me.htxtTJSJSessionId.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtTJSJSessionId.Value, Nothing)
                    End If
                    '��������
                    If Me.getReportParams(strErrMsg, strJDKS, strJDJS) = False Then
                        GoTo errProc
                    End If
                    If objsystemEstateRenshiXingye.getDataSet_TJBB_X2_KHJG_JY(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJDKS, strJDJS, "", Me.m_objDataSet_TJSJ) = False Then
                        GoTo errProc
                    End If
                    Session(Me.htxtTJSJSessionId.Value) = Me.m_objDataSet_TJSJ
                Else
                    If Me.htxtTJSJSessionId.Value.Trim = "" Then
                        '��ʼ����
                        Me.m_objDataSet_TJSJ = New Josco.JSOA.Common.Data.estateRenshiXingyeData(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_VT_RS_X2_KHJG_JY)
                        '��������
                        Me.htxtTJSJSessionId.Value = objPulicParameters.getNewGuid()
                        Session.Add(Me.htxtTJSJSessionId.Value, Me.m_objDataSet_TJSJ)
                    Else
                        '�����ȡ����
                        Try
                            Me.m_objDataSet_TJSJ = CType(Session(Me.htxtTJSJSessionId.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                        Catch ex As Exception
                            Me.m_objDataSet_TJSJ = Nothing
                        End Try
                    End If
                End If

                '�ָ�RowFilter
                With Me.m_objDataSet_TJSJ.Tables(strTable)
                    .DefaultView.RowFilter = strWhere
                End With

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_TJSJ.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_TJSJ.Tables(strTable)
                    Me.htxtTJSJRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_TJSJ = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_TJSJ = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdTJSJ����
        '     strErrMsg      �����ش�����Ϣ
        '     blnEnforced    ��ǿ�����¼���
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_TJSJ( _
            ByRef strErrMsg As String, _
            ByVal blnEnforced As Boolean) As Boolean

            searchModuleData_TJSJ = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String = ""
                If Me.getQueryString_TJSJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_TJSJ(strErrMsg, strQuery, blnEnforced) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_TJSJ = strQuery
                Me.htxtTJSJQuery.Value = Me.m_strQuery_TJSJ
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_TJSJ = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Function doRefresh_TJSJ(ByRef strErrMsg As String, ByVal blnEnforced As Boolean) As Boolean

            doRefresh_TJSJ = False
            strErrMsg = ""

            Try
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, blnEnforced) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doRefresh_TJSJ = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdTJSJ������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_TJSJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_VT_RS_X2_KHJG_JY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_TJSJ = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtTJSJSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtTJSJSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_TJSJ Is Nothing Then
                    Me.grdTJSJ.DataSource = Nothing
                Else
                    With Me.m_objDataSet_TJSJ.Tables(strTable)
                        Me.grdTJSJ.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_TJSJ.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdTJSJ, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdTJSJ)
                    With Me.grdTJSJ.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdTJSJ.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdTJSJ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_TJSJ) = False Then
                '    GoTo errProc
                'End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_TJSJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdTJSJ�������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_TJSJ(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_VT_RS_X2_KHJG_JY
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_TJSJ = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_TJSJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_TJSJ.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblTJSJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdTJSJ, .Count)

                    '��ʾҳ���������
                    Me.lnkCZTJSJMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdTJSJ, .Count)
                    Me.lnkCZTJSJMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdTJSJ, .Count)
                    Me.lnkCZTJSJMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdTJSJ, .Count)
                    Me.lnkCZTJSJMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdTJSJ, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZTJSJDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZTJSJSelectAll.Enabled = blnEnabled
                    Me.lnkCZTJSJGotoPage.Enabled = blnEnabled
                    Me.lnkCZTJSJSetPageSize.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_TJSJ = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���ƽ�������������ʾԪ��
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_MAIN(ByRef strErrMsg As String) As Boolean

            showModuleData_MAIN = False

            Try

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
        ' ��ʼ���ؼ�
        '----------------------------------------------------------------
        Private Function initializeControls(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            initializeControls = False

            Try
                '���ڵ�һ�ε���ҳ��ʱִ��
                If Me.IsPostBack = False Then
                    '��ʾPannel
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                    '====================================================================
                    objControlProcess.doTranslateKey(Me.txtTJSJPageIndex)
                    objControlProcess.doTranslateKey(Me.txtTJSJPageSize)
                    '====================================================================
                    objControlProcess.doTranslateKey(Me.ddlTJSJSearch_XSJB)
                    '====================================================================
                    objControlProcess.doTranslateKey(Me.txtTJND)
                    objControlProcess.doTranslateKey(Me.txtYJZR)
                    objControlProcess.doTranslateKey(Me.ddlTJJD)
                    '====================================================================
                    objControlProcess.doTranslateKey(Me.txtJDKS)
                    objControlProcess.doTranslateKey(Me.txtJDJS)
                    '====================================================================

                    '��ʾ����Ԫ��
                    If Me.showModuleData_MAIN(strErrMsg) = False Then
                        GoTo errProc
                    End If

                    '��ʼ��
                    If Me.m_blnSaveScence = False Then
                        Me.txtTJND.Text = Now.Year.ToString
                        Select Case Now.Month
                            Case 1, 2, 3
                                Me.ddlTJJD.SelectedIndex = 0
                            Case 4, 5, 6
                                Me.ddlTJJD.SelectedIndex = 1
                            Case 7, 8, 9
                                Me.ddlTJJD.SelectedIndex = 2
                            Case Else
                                Me.ddlTJJD.SelectedIndex = 3
                        End Select
                    End If
                    If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_TJSJ(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            initializeControls = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim strUrl As String = ""
            Dim blnDo As Boolean

            'Ԥ����
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
            End If

            '���Ȩ��(�����Ƿ�ط���)
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
        Sub grdTJSJ_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdTJSJ.ItemDataBound

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_TJSJ + ".scrollTop)")
                    Next
                Else
                    If Me.htxtTJSJColor.Value = "1" Then
                        '�������ݵ�����ʾ
                        Dim intColIndex(2) As Integer
                        Dim strValue(2) As String
                        Dim intValue(2) As Integer
                        intColIndex(0) = Me.m_intColIndex_TJSJ(0)
                        strValue(0) = objDataGridProcess.getDataGridCellValue(e.Item, intColIndex(0))
                        intValue(0) = objPulicParameters.getObjectValue(strValue(0), 0)
                        Select Case intValue(0)
                            Case 1
                                e.Item.BackColor = System.Drawing.Color.FromArgb(255, 102, 51)
                            Case 2
                                e.Item.BackColor = System.Drawing.Color.FromArgb(255, 153, 51)
                            Case 3
                                e.Item.BackColor = System.Drawing.Color.FromArgb(204, 255, 255)
                            Case Else
                                e.Item.BackColor = System.Drawing.Color.White
                        End Select
                    End If
                End If
                If Me.m_intFixedColumns_TJSJ > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_TJSJ - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdTJSJ.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub grdTJSJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTJSJ.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblTJSJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdTJSJ, Me.m_intRows_TJSJ)
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

        Private Sub grdTJSJ_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdTJSJ.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_VT_RS_X2_KHJG_JY
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
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                strOldCommand = Me.m_objDataSet_TJSJ.Tables(strTable).DefaultView.Sort

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                Me.m_objDataSet_TJSJ.Tables(strTable).DefaultView.Sort = strFinalCommand

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtTJSJSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtTJSJSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtTJSJSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub










        Private Sub doMoveFirst_TJSJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intPageIndex As Integer
            Dim strErrMsg As String

            Try
                '��ȡ����
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdTJSJ.PageCount)
                Me.grdTJSJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doMoveLast_TJSJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intPageIndex As Integer
            Dim strErrMsg As String

            Try
                '��ȡ����
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdTJSJ.PageCount - 1, Me.grdTJSJ.PageCount)
                Me.grdTJSJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doMoveNext_TJSJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intPageIndex As Integer
            Dim strErrMsg As String

            Try
                '��ȡ����
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdTJSJ.CurrentPageIndex + 1, Me.grdTJSJ.PageCount)
                Me.grdTJSJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doMovePrevious_TJSJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intPageIndex As Integer
            Dim strErrMsg As String

            Try
                '��ȡ����
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdTJSJ.CurrentPageIndex - 1, Me.grdTJSJ.PageCount)
                Me.grdTJSJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doGotoPage_TJSJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtTJSJPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdTJSJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtTJSJPageIndex.Text = (Me.grdTJSJ.CurrentPageIndex + 1).ToString()
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

        Private Sub doSetPageSize_TJSJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtTJSJPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdTJSJ.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtTJSJPageSize.Text = (Me.grdTJSJ.PageSize).ToString()
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

        Private Sub doSelectAll_TJSJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdTJSJ, 0, Me.m_cstrCheckBoxIdInDataGrid_TJSJ, True) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub doDeSelectAll_TJSJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdTJSJ, 0, Me.m_cstrCheckBoxIdInDataGrid_TJSJ, False) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Sub

        End Sub

        Private Sub lnkCZTJSJMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJMoveFirst.Click
            Me.doMoveFirst_TJSJ("lnkCZTJSJMoveFirst")
        End Sub

        Private Sub lnkCZTJSJMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJMoveLast.Click
            Me.doMoveLast_TJSJ("lnkCZTJSJMoveLast")
        End Sub

        Private Sub lnkCZTJSJMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJMoveNext.Click
            Me.doMoveNext_TJSJ("lnkCZTJSJMoveNext")
        End Sub

        Private Sub lnkCZTJSJMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJMovePrev.Click
            Me.doMovePrevious_TJSJ("lnkCZTJSJMovePrev")
        End Sub

        Private Sub lnkCZTJSJGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJGotoPage.Click
            Me.doGotoPage_TJSJ("lnkCZTJSJGotoPage")
        End Sub

        Private Sub lnkCZTJSJSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJSetPageSize.Click
            Me.doSetPageSize_TJSJ("lnkCZTJSJSetPageSize")
        End Sub

        Private Sub lnkCZTJSJSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJSelectAll.Click
            Me.doSelectAll_TJSJ("lnkCZTJSJSelectAll")
        End Sub

        Private Sub lnkCZTJSJDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTJSJDeSelectAll.Click
            Me.doDeSelectAll_TJSJ("lnkCZTJSJDeSelectAll")
        End Sub











        '----------------------------------------------------------------
        'ģ���������������
        '----------------------------------------------------------------
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

        Private Sub doCompute(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '�������
                Dim strJDKS As String = ""
                Dim strJDJS As String = ""
                Dim intTJND As Integer
                Dim intTJJD As Integer
                Dim intYJZR As Integer
                If Me.getReportParams(strErrMsg, strJDKS, strJDJS) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, True) = False Then
                    GoTo errProc
                End If

                '��ʾ����
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
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

        Private Sub doOK(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objColors As System.Collections.Specialized.ListDictionary = Nothing
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Dim strJDKS As String = ""
                Dim strJDJS As String = ""
                If Me.getReportParams(strErrMsg, strJDKS, strJDJS) = False Then
                    GoTo errProc
                End If
                '��ȡ����
                If Me.getModuleData_TJSJ(strErrMsg, Me.m_strQuery_TJSJ, False) = False Then
                    GoTo errProc
                End If

                '׼��Excel�ļ�
                Dim strDesExcelPath As String = Request.ApplicationPath + Me.m_cstrUrlBaseToDownloadFile
                Dim strSrcExcelSpec As String = Request.ApplicationPath + Me.m_cstrUrlBaseToExcelMB + "������ҵ_���¹���_ҵ��Ӣ���˱�.xls"
                Dim strDesExcelFile As String = ""
                Dim strDesExcelSpec As String = ""
                strDesExcelPath = Server.MapPath(strDesExcelPath)
                strSrcExcelSpec = Server.MapPath(strSrcExcelSpec)
                If objBaseLocalFile.doCopyToTempFile(strErrMsg, strSrcExcelSpec, strDesExcelPath, strDesExcelFile) = False Then
                    GoTo errProc
                End If
                strDesExcelSpec = objBaseLocalFile.doMakePath(strDesExcelPath, strDesExcelFile)

                '�����ļ�
                Dim strFName As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_VT_RS_X2_KHJG_JY_XSJB
                Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                Dim strMacroValue As String = ""
                Dim strMacroName As String = ""
                Dim objZZRQ As System.DateTime = CType(strJDJS, System.DateTime)
                Dim intTJJD As Integer
                Select Case objZZRQ.Month
                    Case 1, 2, 3
                        intTJJD = 1
                    Case 4, 5, 6
                        intTJJD = 2
                    Case 7, 8, 9
                        intTJJD = 3
                    Case Else
                        intTJJD = 4
                End Select
                strMacroName = "TJND"
                strMacroValue = objZZRQ.Year.ToString
                strMacroName = strMacroName + strSep + "TJJD"
                strMacroValue = strMacroValue + strSep + intTJJD.ToString
                objColors = New System.Collections.Specialized.ListDictionary
                objColors.Add("1", System.Drawing.Color.FromArgb(255, 102, 51))
                objColors.Add("2", System.Drawing.Color.FromArgb(255, 153, 51))
                objColors.Add("3", System.Drawing.Color.FromArgb(204, 255, 255))
                If objsystemEstateRenshiXingye.doExportToExcel(strErrMsg, Me.m_objDataSet_TJSJ, strDesExcelSpec, strFName, objColors, strMacroName, strMacroValue, "yyyy-MM-dd") = False Then
                    GoTo errProc
                End If

                '����ʱExcel�ļ�
                Dim strUrl As String = Request.ApplicationPath + Me.m_cstrUrlBaseToDownloadFile + strDesExcelFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doSearch_TJSJ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_TJSJ(strErrMsg, False) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_TJSJ(strErrMsg) = False Then
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

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnCompute_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCompute.Click
            Me.doCompute("btnCompute")
        End Sub

        Private Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
            Me.doSearch_TJSJ("btnDisplay")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

    End Class

End Namespace