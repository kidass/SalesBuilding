Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_rs_xz_team
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   ��ѡ���Ŷ���Ϣ
    '
    ' QueryString���������� 
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IEstateRsXzTeam����
    '
    ' ���ļ�¼��
    '     zengxianglin 2009-12-29 ����
    '----------------------------------------------------------------

    Partial Class estate_rs_xz_team
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

        '----------------------------------------------------------------
        'ģ����Ȩ����
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsXzTeam
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsXzTeam
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdTDXX��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_TDXX As String = "chkTDXX"
        Private Const m_cstrDataGridInDIV_TDXX As String = "divTDXX"
        Private m_intFixedColumns_TDXX As Integer

        '----------------------------------------------------------------
        'Ҫ���ʵ�����
        '----------------------------------------------------------------
        Private m_objDataSet_TDXX As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_strQuery_TDXX As String
        Private m_intRows_TDXX As Integer

        '----------------------------------------------------------------
        '�������
        '----------------------------------------------------------------
        Private m_blnMultiSelect_I As Boolean
        Private m_blnAllowNull_I As Boolean
        Private m_strFixQuery_I As String
        Private m_strJCSJ_I As String








        '----------------------------------------------------------------
        ' ��ԭģ���ֳ���Ϣ���ͷ���Ӧ����Դ
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Try
                If Me.m_objSaveScence Is Nothing Then
                    Exit Try
                End If

                With Me.m_objSaveScence
                    Me.htxtTDXXQuery.Value = .htxtTDXXQuery
                    Me.htxtTDXXRows.Value = .htxtTDXXRows
                    Me.htxtTDXXSort.Value = .htxtTDXXSort
                    Me.htxtTDXXSortColumnIndex.Value = .htxtTDXXSortColumnIndex
                    Me.htxtTDXXSortType.Value = .htxtTDXXSortType
                    Me.htxtDivLeftTDXX.Value = .htxtDivLeftTDXX
                    Me.htxtDivTopTDXX.Value = .htxtDivTopTDXX

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtTDXXPageIndex.Text = .txtTDXXPageIndex
                    Me.txtTDXXPageSize.Text = .txtTDXXPageSize

                    Me.txtTDXXSearch_TDBH.Text = .txtTDXXSearch_TDBH
                    Me.txtTDXXSearch_DWMC.Text = .txtTDXXSearch_DWMC
                    Me.txtTDXXSearch_SSDW.Text = .txtTDXXSearch_SSDW

                    Try
                        Me.grdTDXX.PageSize = .grdTDXXPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdTDXX.CurrentPageIndex = .grdTDXXCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdTDXX.SelectedIndex = .grdTDXXSelectedIndex
                    Catch ex As Exception
                    End Try
                End With

                '�ͷ���Դ
                Session.Remove(strSessionId)
                Me.m_objSaveScence.Dispose()
                Me.m_objSaveScence = Nothing

            Catch ex As Exception
            End Try

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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsXzTeam

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtTDXXQuery = Me.htxtTDXXQuery.Value
                    .htxtTDXXRows = Me.htxtTDXXRows.Value
                    .htxtTDXXSort = Me.htxtTDXXSort.Value
                    .htxtTDXXSortColumnIndex = Me.htxtTDXXSortColumnIndex.Value
                    .htxtTDXXSortType = Me.htxtTDXXSortType.Value
                    .htxtDivLeftTDXX = Me.htxtDivLeftTDXX.Value
                    .htxtDivTopTDXX = Me.htxtDivTopTDXX.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .txtTDXXPageIndex = Me.txtTDXXPageIndex.Text
                    .txtTDXXPageSize = Me.txtTDXXPageSize.Text

                    .txtTDXXSearch_TDBH = Me.txtTDXXSearch_TDBH.Text
                    .txtTDXXSearch_DWMC = Me.txtTDXXSearch_DWMC.Text
                    .txtTDXXSearch_SSDW = Me.txtTDXXSearch_SSDW.Text

                    .grdTDXXPageSize = Me.grdTDXX.PageSize
                    .grdTDXXCurrentPageIndex = Me.grdTDXX.CurrentPageIndex
                    .grdTDXXSelectedIndex = Me.grdTDXX.SelectedIndex
                End With

                '�������
                Session.Add(strSessionId, Me.m_objSaveScence)
            Catch ex As Exception
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            saveModuleInformation = strSessionId

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
                        Me.htxtTDXXQuery.Value = objISjcxCxtj.oQueryString
                        If Me.htxtSessionIdQuery.Value.Trim = "" Then
                            Me.htxtSessionIdQuery.Value = objPulicParameters.getNewGuid()
                        Else
                            Try
                                objQueryData = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                            Catch ex As Exception
                                objQueryData = Nothing
                            End Try
                            Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                        End If
                        Session.Add(Me.htxtSessionIdQuery.Value, objISjcxCxtj.oDataSetTJ)
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
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsXzTeam)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try

                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    'û���нӿڲ���
                Else
                    Me.m_blnInterface = True
                    '�нӿڲ���
                    Me.m_blnMultiSelect_I = Me.m_objInterface.iMultiSelect
                    Me.m_blnAllowNull_I = Me.m_objInterface.iAllowNull
                    Me.m_strFixQuery_I = Me.m_objInterface.iFixQuery
                    Me.m_strJCSJ_I = Me.m_objInterface.iJCSJ
                End If
                If Me.m_blnInterface = False Then
                    blnContinue = False
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Me.lblMessage.Text = "����û���ṩ��ģ����Ҫ�Ľӿ���Ϣ��"
                    Exit Try
                End If

                '��ȡ�ָ��ֳ�����
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String = ""
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsXzTeam)
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
                Me.m_intFixedColumns_TDXX = objPulicParameters.getObjectValue(Me.htxtTDXXFixed.Value, 0)
                Me.m_intRows_TDXX = objPulicParameters.getObjectValue(Me.htxtTDXXRows.Value, 0)
                Me.m_strQuery_TDXX = Me.htxtTDXXQuery.Value
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
                If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQuery.Value)
                End If
            Catch ex As Exception
            End Try

        End Sub













        '----------------------------------------------------------------
        ' ��ȡgrdTDXX����������(Ĭ�ϱ�ǰ׺a.)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_TDXX( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_TDXX = False
            strQuery = ""

            Try
                '�����Ŷӱ�š�����
                Dim strTDBH As String
                strTDBH = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_TDBH
                If Me.txtTDXXSearch_TDBH.Text.Length > 0 Then Me.txtTDXXSearch_TDBH.Text = Me.txtTDXXSearch_TDBH.Text.Trim()
                If Me.txtTDXXSearch_TDBH.Text <> "" Then
                    If strQuery = "" Then
                        strQuery = strTDBH + " = " + Me.txtTDXXSearch_TDBH.Text
                    Else
                        strQuery = strQuery + " and " + strTDBH + " = " + Me.txtTDXXSearch_TDBH.Text
                    End If
                End If

                '������λ���ơ�����
                Dim strDWMC As String
                strDWMC = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_DWMC
                If Me.txtTDXXSearch_DWMC.Text.Length > 0 Then Me.txtTDXXSearch_DWMC.Text = Me.txtTDXXSearch_DWMC.Text.Trim()
                If Me.txtTDXXSearch_DWMC.Text <> "" Then
                    Me.txtTDXXSearch_DWMC.Text = objPulicParameters.getNewSearchString(Me.txtTDXXSearch_DWMC.Text)
                    If strQuery = "" Then
                        strQuery = strDWMC + " like '" + Me.txtTDXXSearch_DWMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strDWMC + " like '" + Me.txtTDXXSearch_DWMC.Text + "%'"
                    End If
                End If

                '������λ���롱����
                Dim strSSDW As String
                strSSDW = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_TDZH_SSDW
                If Me.txtTDXXSearch_SSDW.Text.Length > 0 Then Me.txtTDXXSearch_SSDW.Text = Me.txtTDXXSearch_SSDW.Text.Trim()
                If Me.txtTDXXSearch_SSDW.Text <> "" Then
                    Me.txtTDXXSearch_SSDW.Text = objPulicParameters.getNewSearchString(Me.txtTDXXSearch_SSDW.Text)
                    If strQuery = "" Then
                        strQuery = strSSDW + " like '" + Me.txtTDXXSearch_SSDW.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strSSDW + " like '" + Me.txtTDXXSearch_SSDW.Text + "%'"
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_TDXX = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdTDXXҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       ����������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_TDXX( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye

            getModuleData_TDXX = False

            Try
                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtTDXXSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_TDXX)

                '���¼�������
                If Me.m_strFixQuery_I <> "" Then
                    If strWhere = "" Then
                        strWhere = Me.m_strFixQuery_I
                    Else
                        strWhere = strWhere + vbCr + " and " + Me.m_strFixQuery_I
                    End If
                End If
                If objsystemEstateRenshiXingye.getDataSet_TEAM(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_strJCSJ_I, strWhere, Me.m_objDataSet_TDXX) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_TDXX.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_TDXX.Tables(strTable)
                    Me.htxtTDXXRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_TDXX = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)

            getModuleData_TDXX = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdTDXX����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_TDXX(ByRef strErrMsg As String) As Boolean

            searchModuleData_TDXX = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_TDXX(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_TDXX(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_TDXX = strQuery
                Me.htxtTDXXQuery.Value = Me.m_strQuery_TDXX
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_TDXX = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdTDXX������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_TDXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_TDXX = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = 0
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtTDXXSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtTDXXSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_TDXX Is Nothing Then
                    Me.grdTDXX.DataSource = Nothing
                Else
                    With Me.m_objDataSet_TDXX.Tables(strTable)
                        Me.grdTDXX.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_TDXX.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdTDXX, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdTDXX)
                    With Me.grdTDXX.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '����ѡ����
                Me.grdTDXX.Columns(0).Visible = Me.m_blnMultiSelect_I

                '������
                Me.grdTDXX.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                If Me.m_blnMultiSelect_I = True Then
                    '�ָ������е�CheckBox״̬
                    If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdTDXX, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_TDXX) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_TDXX = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdTDXX�������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_TDXX(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_TDXX = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_TDXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_TDXX.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblTDXXGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdTDXX, .Count)

                    '��ʾҳ���������
                    Me.lnkCZTDXXMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdTDXX, .Count) And Me.grdTDXX.AllowPaging
                    Me.lnkCZTDXXMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdTDXX, .Count) And Me.grdTDXX.AllowPaging
                    Me.lnkCZTDXXMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdTDXX, .Count) And Me.grdTDXX.AllowPaging
                    Me.lnkCZTDXXMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdTDXX, .Count) And Me.grdTDXX.AllowPaging

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZTDXXDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZTDXXSelectAll.Enabled = blnEnabled
                    Me.lnkCZTDXXGotoPage.Enabled = blnEnabled And Me.grdTDXX.AllowPaging
                    Me.lnkCZTDXXSetPageSize.Enabled = blnEnabled And Me.grdTDXX.AllowPaging
                    Me.txtTDXXPageIndex.Enabled = Me.grdTDXX.AllowPaging
                    Me.txtTDXXPageSize.Enabled = Me.grdTDXX.AllowPaging
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_TDXX = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾģ�鼶�Ĳ���״̬
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_MAIN(ByRef strErrMsg As String) As Boolean

            showModuleData_MAIN = False

            Try
                Me.btnNull.Visible = Me.m_blnAllowNull_I

                Me.lnkCZTDXXSelectAll.Enabled = Me.m_blnMultiSelect_I
                Me.lnkCZTDXXDeSelectAll.Enabled = Me.m_blnMultiSelect_I
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

            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            initializeControls = False

            '���ڵ�һ�ε���ҳ��ʱִ��
            If Me.IsPostBack = False Then
                '��ʾPannel
                Me.panelMain.Visible = True
                Me.panelError.Visible = Not Me.panelMain.Visible

                '��ʾ��ʾ
                If Me.m_blnMultiSelect_I = True Then
                    Me.lblSelectMode.Text = "[��ѡ]"
                Else
                    Me.lblSelectMode.Text = "[��ѡ]"
                End If

                'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                '************************************************
                objControlProcess.doTranslateKey(Me.txtTDXXPageIndex)
                objControlProcess.doTranslateKey(Me.txtTDXXPageSize)
                '************************************************
                objControlProcess.doTranslateKey(Me.txtTDXXSearch_DWMC)
                objControlProcess.doTranslateKey(Me.txtTDXXSearch_TDBH)
                objControlProcess.doTranslateKey(Me.txtTDXXSearch_SSDW)
                '************************************************

                '��ʾģ�鼶����
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '���ʼֵ
                If Me.m_blnSaveScence = False Then
                    '��ʾ����
                    If Me.searchModuleData_TDXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_TDXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    '��ʾ����
                    If Me.getModuleData_TDXX(strErrMsg, Me.m_strQuery_TDXX) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_TDXX(strErrMsg) = False Then
                        GoTo errProc
                    End If
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
            Dim strErrMsg As String = ""
            Dim strUrl As String = ""
            Dim blnDo As Boolean

            'Ԥ����
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
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
        'ʵ�ֶ�grdTDXX�����С��еĹ̶�
        Sub grdTDXX_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdTDXX.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_TDXX + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_TDXX > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_TDXX - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdTDXX.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdTDXX_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTDXX.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblTDXXGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdTDXX, Me.m_intRows_TDXX)
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

        Private Sub grdTDXX_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdTDXX.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                Dim objenumSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
                Dim objDataGridItem As System.Web.UI.WebControls.DataGridItem
                Dim strFinalCommand As String
                Dim strOldCommand As String
                Dim strUniqueId As String
                Dim intColumnIndex As Integer

                '��ȡ����
                If Me.getModuleData_TDXX(strErrMsg, Me.m_strQuery_TDXX) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                strOldCommand = Me.m_objDataSet_TDXX.Tables(strTable).DefaultView.Sort

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                Me.m_objDataSet_TDXX.Tables(strTable).DefaultView.Sort = strFinalCommand

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtTDXXSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtTDXXSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtTDXXSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_TDXX(strErrMsg) = False Then
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












        Private Sub doMoveFirst_TDXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_TDXX(strErrMsg, Me.m_strQuery_TDXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdTDXX.PageCount)
                Me.grdTDXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_TDXX(strErrMsg) = False Then
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

        Private Sub doMoveLast_TDXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_TDXX(strErrMsg, Me.m_strQuery_TDXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdTDXX.PageCount - 1, Me.grdTDXX.PageCount)
                Me.grdTDXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_TDXX(strErrMsg) = False Then
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

        Private Sub doMoveNext_TDXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_TDXX(strErrMsg, Me.m_strQuery_TDXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdTDXX.CurrentPageIndex + 1, Me.grdTDXX.PageCount)
                Me.grdTDXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_TDXX(strErrMsg) = False Then
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

        Private Sub doMovePrevious_TDXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_TDXX(strErrMsg, Me.m_strQuery_TDXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdTDXX.CurrentPageIndex - 1, Me.grdTDXX.PageCount)
                Me.grdTDXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_TDXX(strErrMsg) = False Then
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

        Private Sub doGotoPage_TDXX(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtTDXXPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_TDXX(strErrMsg, Me.m_strQuery_TDXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdTDXX.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_TDXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtTDXXPageIndex.Text = (Me.grdTDXX.CurrentPageIndex + 1).ToString()
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

        Private Sub doSetPageSize_TDXX(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtTDXXPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_TDXX(strErrMsg, Me.m_strQuery_TDXX) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdTDXX.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_TDXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtTDXXPageSize.Text = (Me.grdTDXX.PageSize).ToString()
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

        Private Sub doSelectAll_TDXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdTDXX, 0, Me.m_cstrCheckBoxIdInDataGrid_TDXX, True) = False Then
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

        Private Sub doDeSelectAll_TDXX(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdTDXX, 0, Me.m_cstrCheckBoxIdInDataGrid_TDXX, False) = False Then
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

        Private Sub doSearch_TDXX(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_TDXX(strErrMsg) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_TDXX(strErrMsg) = False Then
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

        Private Sub lnkCZTDXXMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTDXXMoveFirst.Click
            Me.doMoveFirst_TDXX("lnkCZTDXXMoveFirst")
        End Sub

        Private Sub lnkCZTDXXMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTDXXMoveLast.Click
            Me.doMoveLast_TDXX("lnkCZTDXXMoveLast")
        End Sub

        Private Sub lnkCZTDXXMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTDXXMoveNext.Click
            Me.doMoveNext_TDXX("lnkCZTDXXMoveNext")
        End Sub

        Private Sub lnkCZTDXXMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTDXXMovePrev.Click
            Me.doMovePrevious_TDXX("lnkCZTDXXMovePrev")
        End Sub

        Private Sub lnkCZTDXXGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTDXXGotoPage.Click
            Me.doGotoPage_TDXX("lnkCZTDXXGotoPage")
        End Sub

        Private Sub lnkCZTDXXSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTDXXSetPageSize.Click
            Me.doSetPageSize_TDXX("lnkCZTDXXSetPageSize")
        End Sub

        Private Sub lnkCZTDXXSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTDXXSelectAll.Click
            Me.doSelectAll_TDXX("lnkCZTDXXSelectAll")
        End Sub

        Private Sub lnkCZTDXXDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZTDXXDeSelectAll.Click
            Me.doDeSelectAll_TDXX("lnkCZTDXXDeSelectAll")
        End Sub

        Private Sub btnTDXXSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTDXXSearch.Click
            Me.doSearch_TDXX("btnTDXXSearch")
        End Sub











        Private Sub doSearchFull(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj = Nothing
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strNewSessionId As String = ""
            Dim strSessionId As String = ""
            Dim strErrMsg As String = ""

            Try
                '��ȡ����
                If Me.getModuleData_TDXX(strErrMsg, Me.m_strQuery_TDXX) = False Then
                    GoTo errProc
                End If

                '�����ֳ�����
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim strUrl As String = ""
                objISjcxCxtj = New Josco.JsKernal.BusinessFacade.ISjcxCxtj
                With objISjcxCxtj
                    If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_TDXX.Tables(strTable)
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
                strUrl += "../sjcx/sjcx_cxtj.aspx"
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

        Private Sub btnTDXXSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTDXXSearch_Full.Click
            Me.doSearchFull("btnTDXXSearch_Full")
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

        Private Sub doOK(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_TDZH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                Dim objDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
                Dim objSrcDataRow As System.Data.DataRow = Nothing
                Dim objDesDataRow As System.Data.DataRow = Nothing
                Dim intSelected As Integer = 0
                Dim intColIndex As Integer = 0
                Dim intCount As Integer = 0
                Dim strValue As String = ""
                Dim intCols As Integer = 0
                Dim intPos As Integer = 0
                Dim i As Integer = 0
                Dim j As Integer = 0

                If Me.m_blnMultiSelect_I = True Then
                    '���ѡ��
                    intCount = Me.grdTDXX.Items.Count
                    For i = 0 To intCount - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdTDXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_TDXX) = True Then
                            intSelected += 1
                        End If
                    Next
                    If intSelected < 1 Then
                        strErrMsg = "����û��[��]ѡ��"
                        GoTo errProc
                    End If

                    '��ȡ����
                    If Me.getModuleData_TDXX(strErrMsg, Me.m_strQuery_TDXX) = False Then
                        GoTo errProc
                    End If

                    '�������ݼ�
                    objDataSet = New Josco.JSOA.Common.Data.estateRenshiXingyeData(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_B_RS_TDZH)
                    For i = 0 To intCount - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdTDXX.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_TDXX) = True Then
                            With objDataSet.Tables(strTable)
                                objDesDataRow = .NewRow()
                            End With
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdTDXX.CurrentPageIndex, Me.grdTDXX.PageSize)
                            objSrcDataRow = Nothing
                            With Me.m_objDataSet_TDXX.Tables(strTable)
                                intCols = .Columns.Count
                                objSrcDataRow = .DefaultView.Item(intPos).Row
                            End With
                            For j = 0 To intCols - 1 Step 1
                                objDesDataRow.Item(j) = objSrcDataRow.Item(j)
                            Next
                            With objDataSet.Tables(strTable)
                                .Rows.Add(objDesDataRow)
                            End With
                        End If
                    Next
                Else
                    '���ѡ��
                    If Me.grdTDXX.SelectedIndex < 0 Then
                        strErrMsg = "����û���κ��Ŷӣ�"
                        GoTo errProc
                    End If

                    '��ȡ����
                    If Me.getModuleData_TDXX(strErrMsg, Me.m_strQuery_TDXX) = False Then
                        GoTo errProc
                    End If

                    '�������ݼ�
                    objDataSet = New Josco.JSOA.Common.Data.estateRenshiXingyeData(Josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_B_RS_TDZH)
                    With objDataSet.Tables(strTable)
                        objDesDataRow = .NewRow()
                    End With
                    i = Me.grdTDXX.SelectedIndex
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdTDXX.CurrentPageIndex, Me.grdTDXX.PageSize)
                    objSrcDataRow = Nothing
                    With Me.m_objDataSet_TDXX.Tables(strTable)
                        intCols = .Columns.Count
                        objSrcDataRow = .DefaultView.Item(intPos).Row
                    End With
                    For j = 0 To intCols - 1 Step 1
                        objDesDataRow.Item(j) = objSrcDataRow.Item(j)
                    Next
                    With objDataSet.Tables(strTable)
                        .Rows.Add(objDesDataRow)
                    End With
                End If

                '���ش���
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                If Me.m_blnInterface = True Then
                    '���÷��ز���
                    Me.m_objInterface.oExitMode = True
                    Me.m_objInterface.oDataSet = objDataSet
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

        Private Sub doNull(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���ش���
                Dim strSessionId As String = ""
                Dim strUrl As String = ""
                If Me.m_blnInterface = True Then
                    '���÷��ز���
                    Me.m_objInterface.oExitMode = True
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

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

        Private Sub btnNull_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNull.Click
            Me.doNull("btnNull")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

    End Class

End Namespace
