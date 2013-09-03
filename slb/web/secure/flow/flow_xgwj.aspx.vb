Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_xgwj
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   �������ļ�������ӵ����ӡ��޸ġ�ɾ�����鿴�������Ȳ���
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowXgwj����
    '----------------------------------------------------------------

    Public Class flow_xgwj
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkMLAddNewWJ As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLAddNew As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLModify As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLDelete As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLSelect As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLMoveUp As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLMoveDn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLAutoXH As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLExport As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLClose As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZXGWJDeSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZXGWJSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZXGWJMoveFirst As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZXGWJMovePrev As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZXGWJMoveNext As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZXGWJMoveLast As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZXGWJGotoPage As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtXGWJPageIndex As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkCZXGWJSetPageSize As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtXGWJPageSize As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblXGWJGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdXGWJ As System.Web.UI.WebControls.DataGrid
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents htxtXGWJFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtXGWJQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtXGWJRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtXGWJSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtXGWJSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtXGWJSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftXGWJ As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopXGWJ As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopBody As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents popMessageObject As Josco.Web.PopMessage

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

        '----------------------------------------------------------------
        'ģ����Ȩ����
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowXgwj
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowXgwj
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        'ģ��������ݲ���
        '----------------------------------------------------------------
        Private m_objDataSet_XGWJ As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_XGWJ As String '��¼m_objDataSet_XGWJ������
        Private m_intRows_XGWJ As Integer '��¼m_objDataSet_XGWJ��DefaultView��¼��

        '----------------------------------------------------------------
        '����������grdXGWJ��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_XGWJ As String = "chkXGWJ"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_XGWJ As String = "divXGWJ"
        '����Ҫ����������
        Private m_intFixedColumns_XGWJ As Integer

        '----------------------------------------------------------------
        'ģ����������
        '----------------------------------------------------------------
        '��������������
        Private m_strFlowTypeName As String
        '�༭ģʽ
        Private m_blnEditMode As Boolean
        '�ļ���ʶ
        Private m_strWJBS As String











        '----------------------------------------------------------------
        ' ��ԭģ���ֳ���Ϣ���ͷ���Ӧ����Դ
        '----------------------------------------------------------------
        Private Sub restoreModuleInformation(ByVal strSessionId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Try
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    '*********************************************************************
                    Me.txtXGWJPageIndex.Text = .txtXGWJPageIndex
                    Me.txtXGWJPageSize.Text = .txtXGWJPageSize
                    '*********************************************************************
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftXGWJ.Value = .htxtDivLeftXGWJ
                    Me.htxtDivTopXGWJ.Value = .htxtDivTopXGWJ
                    '*********************************************************************
                    Me.htxtXGWJQuery.Value = .htxtXGWJQuery
                    Me.htxtXGWJRows.Value = .htxtXGWJRows
                    Me.htxtXGWJSort.Value = .htxtXGWJSort
                    Me.htxtXGWJSortColumnIndex.Value = .htxtXGWJSortColumnIndex
                    Me.htxtXGWJSortType.Value = .htxtXGWJSortType
                    '*********************************************************************
                    Me.m_objDataSet_XGWJ = .objDataSet_XGWJ
                    '*********************************************************************
                    Try
                        Me.grdXGWJ.PageSize = .grdXGWJ_PageSize
                        Me.grdXGWJ.SelectedIndex = .grdXGWJ_SelectedIndex
                    Catch ex As Exception
                    End Try
                    '*********************************************************************
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowXgwj

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    '*********************************************************************
                    .txtXGWJPageIndex = Me.txtXGWJPageIndex.Text
                    .txtXGWJPageSize = Me.txtXGWJPageSize.Text
                    '*********************************************************************
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftXGWJ = Me.htxtDivLeftXGWJ.Value
                    .htxtDivTopXGWJ = Me.htxtDivTopXGWJ.Value
                    '*********************************************************************
                    .htxtXGWJQuery = Me.htxtXGWJQuery.Value
                    .htxtXGWJRows = Me.htxtXGWJRows.Value
                    .htxtXGWJSort = Me.htxtXGWJSort.Value
                    .htxtXGWJSortColumnIndex = Me.htxtXGWJSortColumnIndex.Value
                    .htxtXGWJSortType = Me.htxtXGWJSortType.Value
                    '*********************************************************************
                    .objDataSet_XGWJ = Me.m_objDataSet_XGWJ
                    '*********************************************************************
                    .grdXGWJ_PageSize = Me.grdXGWJ.PageSize
                    .grdXGWJ_SelectedIndex = Me.grdXGWJ.SelectedIndex
                    '*********************************************************************
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
        Private Function getDataFromCallModule( _
            ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            Dim intXZBZ As Integer = Josco.JSOA.Common.Data.FlowData.enumFileDownloadStatus.HasDownload
            Dim intLBBS As Integer = Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FujianFile
            Dim objDataRow As System.Data.DataRow

            Try
                If Me.IsPostBack = True Then Exit Try

                '=================================================================
                Dim objIFlowXgwjljAdd As Josco.JSOA.BusinessFacade.IFlowXgwjljAdd
                Try
                    objIFlowXgwjljAdd = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowXgwjljAdd)
                Catch ex As Exception
                    objIFlowXgwjljAdd = Nothing
                End Try
                If Not (objIFlowXgwjljAdd Is Nothing) Then
                    '�ͷ���Դ
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIFlowXgwjljAdd.Dispose()
                    objIFlowXgwjljAdd = Nothing
                    Exit Try
                End If

                '=================================================================
                Dim objIFlowXgwjfjInfo As Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
                Try
                    objIFlowXgwjfjInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo)
                Catch ex As Exception
                    objIFlowXgwjfjInfo = Nothing
                End Try
                If Not (objIFlowXgwjfjInfo Is Nothing) Then
                    If objIFlowXgwjfjInfo.oExitMode = True Then
                        '���ز�������
                        With Me.m_objInterface.iDataSet_XGWJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN)
                            Select Case objIFlowXgwjfjInfo.iEditType
                                Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                    Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                    objDataRow = .NewRow()
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH) = objPulicParameters.getObjectValue(objIFlowXgwjfjInfo.oWJXH, 1)
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJYS) = objPulicParameters.getObjectValue(objIFlowXgwjfjInfo.oWJYS, 1)
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ) = objIFlowXgwjfjInfo.oBDWJ
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ) = objIFlowXgwjfjInfo.oWJWZ
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT) = objIFlowXgwjfjInfo.oWJSM
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XZBZ) = intXZBZ.ToString()
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LBBS) = intLBBS.ToString()
                                    .Rows.Add(objDataRow)
                                Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                                    objDataRow = objIFlowXgwjfjInfo.iRow
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJYS) = objPulicParameters.getObjectValue(objIFlowXgwjfjInfo.oWJYS, 1)
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ) = objIFlowXgwjfjInfo.oWJWZ
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT) = objIFlowXgwjfjInfo.oWJSM
                                    If objIFlowXgwjfjInfo.oBDWJ <> "" Then
                                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ) = objIFlowXgwjfjInfo.oBDWJ
                                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XZBZ) = intXZBZ.ToString()
                                    End If
                            End Select
                        End With
                    End If
                    '�ͷ���Դ
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIFlowXgwjfjInfo.Dispose()
                    objIFlowXgwjfjInfo = Nothing
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
        ' �ͷŽӿڲ���(ģ���޷�������ʱ��)
        '----------------------------------------------------------------
        Private Sub releaseInterfaceParameters()

            Try
                If Not (Me.m_objInterface Is Nothing) Then
                    If Me.m_objInterface.iInterfaceType = Josco.JSOA.BusinessFacade.ICallInterface.enumInterfaceType.InputOnly Then
                        '�ͷ�Session
                        Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                        '�ͷŶ���
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
        Private Function getInterfaceParameters(ByRef strErrMsg As String, ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getInterfaceParameters = False
            blnContinue = True

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowXgwj)
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

                '��ȡ�ָ��ֳ�����
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowXgwj)
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

                '����ģ����������
                Me.m_intFixedColumns_XGWJ = objPulicParameters.getObjectValue(Me.htxtXGWJFixed.Value, 0)
                Me.m_intRows_XGWJ = objPulicParameters.getObjectValue(Me.htxtXGWJRows.Value, 0)
                Me.m_strQuery_XGWJ = Me.htxtXGWJQuery.Value

                Me.m_strFlowTypeName = Me.m_objInterface.iFlowTypeName
                Me.m_blnEditMode = Me.m_objInterface.iEditMode
                Me.m_strWJBS = Me.m_objInterface.iWJBS

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
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' ��ȡ������Ϣ���ݼ�
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       ����������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_XGWJ( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            getModuleData_XGWJ = False

            Try
                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtXGWJSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '��ȡ����
                Me.m_objDataSet_XGWJ = Me.m_objInterface.iDataSet_XGWJ

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    .DefaultView.Sort = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH + " asc" 'ȱʡ���򣬲��ܸı�
                    .DefaultView.RowFilter = strWhere
                End With

                '�������
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    Me.htxtXGWJRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_XGWJ = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_XGWJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdXGWJ����������(RowFilter��ʽ)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_XGWJ( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_XGWJ = False
            strQuery = ""

            Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_XGWJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdXGWJ����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_XGWJ(ByRef strErrMsg As String) As Boolean

            searchModuleData_XGWJ = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_XGWJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_XGWJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_XGWJ = strQuery
                Me.htxtXGWJQuery.Value = Me.m_strQuery_XGWJ

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_XGWJ = True
            Exit Function

errProc:
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

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

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                'LJ 2008-07-30
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdXGWJ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_XGWJ) = False Then
                '    GoTo errProc
                'End If

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
        ' ��ʾgrdXGWJ���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_XGWJ(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            showModuleData_XGWJ = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_XGWJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_XGWJ.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblXGWJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdXGWJ, .Count)

                    '��ʾҳ���������
                    Me.lnkCZXGWJMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdXGWJ, .Count)
                    Me.lnkCZXGWJMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdXGWJ, .Count)
                    Me.lnkCZXGWJMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdXGWJ, .Count)
                    Me.lnkCZXGWJMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdXGWJ, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZXGWJDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZXGWJSelectAll.Enabled = blnEnabled
                    Me.lnkCZXGWJGotoPage.Enabled = blnEnabled
                    Me.lnkCZXGWJSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_XGWJ = True
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
        Private Function showModuleData_Main( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            showModuleData_Main = False

            Try
                '��ʾ����
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ����
                Me.lnkMLAddNewWJ.Enabled = blnEditMode
                Me.lnkMLAddNew.Enabled = blnEditMode
                Me.lnkMLModify.Enabled = blnEditMode
                Me.lnkMLDelete.Enabled = blnEditMode
                Me.lnkMLMoveUp.Enabled = blnEditMode
                Me.lnkMLMoveDn.Enabled = blnEditMode
                Me.lnkMLAutoXH.Enabled = blnEditMode

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
        ' ��ʼ���ؼ�
        '----------------------------------------------------------------
        Private Function initializeControls(ByRef strErrMsg As String) As Boolean

            initializeControls = False

            Try
                '���ڵ�һ�ε���ҳ��ʱִ��
                If Me.IsPostBack = False Then
                    '��ʾPannel(�����Ƿ�ص���ʼ����ʾpanelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                    With New Josco.JsKernal.web.ControlProcess
                        '***********************************************
                        .doTranslateKey(Me.txtXGWJPageIndex)
                        .doTranslateKey(Me.txtXGWJPageSize)
                        '***********************************************
                    End With

                    If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim strUrl As String

            Try
                'Ԥ����
                If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                    Exit Sub
                End If

                '��ȡ�ӿڲ���
                Dim blnContinue As Boolean
                If Me.getInterfaceParameters(strErrMsg, blnContinue) = False Then
                    GoTo errProc
                End If
                If blnContinue = False Then
                    Exit Try
                End If

                '��ȡ��������
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
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




        Private Sub grdXGWJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdXGWJ.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                With New Josco.JsKernal.web.DataGridProcess
                    Me.lblXGWJGridLocInfo.Text = .getDataGridLocation(Me.grdXGWJ, Me.m_intRows_XGWJ)
                End With
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




        Private Sub grdXGWJ_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdXGWJ.SortCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            Try
                Dim objenumSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
                Dim objDataGridItem As System.Web.UI.WebControls.DataGridItem
                Dim strFinalCommand As String
                Dim strOldCommand As String
                Dim strUniqueId As String
                Dim intColumnIndex As Integer

                '��ȡ����
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                strOldCommand = Me.m_objDataSet_XGWJ.Tables(strTable).DefaultView.Sort

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                Me.m_objDataSet_XGWJ.Tables(strTable).DefaultView.Sort = strFinalCommand

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtXGWJSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtXGWJSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtXGWJSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
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




        Private Sub doMoveFirst_XGWJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdXGWJ.PageCount)
                Me.grdXGWJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
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

        Private Sub doMoveLast_XGWJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdXGWJ.PageCount - 1, Me.grdXGWJ.PageCount)
                Me.grdXGWJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
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

        Private Sub doMoveNext_XGWJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdXGWJ.CurrentPageIndex + 1, Me.grdXGWJ.PageCount)
                Me.grdXGWJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
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

        Private Sub doMovePrevious_XGWJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdXGWJ.CurrentPageIndex - 1, Me.grdXGWJ.PageCount)
                Me.grdXGWJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
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

        Private Sub doGotoPage_XGWJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtXGWJPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdXGWJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtXGWJPageIndex.Text = (Me.grdXGWJ.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_XGWJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtXGWJPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdXGWJ.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtXGWJPageSize.Text = (Me.grdXGWJ.PageSize).ToString()

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

        Private Sub doSelectAll_XGWJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdXGWJ, 0, Me.m_cstrCheckBoxIdInDataGrid_XGWJ, True) = False Then
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

        Private Sub doDeSelectAll_XGWJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdXGWJ, 0, Me.m_cstrCheckBoxIdInDataGrid_XGWJ, False) = False Then
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

        Private Sub doSearch_XGWJ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_XGWJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_XGWJ(strErrMsg) = False Then
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

        Private Sub lnkCZXGWJMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJMoveFirst.Click
            Me.doMoveFirst_XGWJ("lnkCZXGWJMoveFirst")
        End Sub

        Private Sub lnkCZXGWJMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJMoveLast.Click
            Me.doMoveLast_XGWJ("lnkCZXGWJMoveLast")
        End Sub

        Private Sub lnkCZXGWJMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJMovePrev.Click
            Me.doMovePrevious_XGWJ("lnkCZXGWJMovePrev")
        End Sub

        Private Sub lnkCZXGWJMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJMoveNext.Click
            Me.doMoveNext_XGWJ("lnkCZXGWJMoveNext")
        End Sub

        Private Sub lnkCZXGWJSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJSetPageSize.Click
            Me.doSetPageSize_XGWJ("lnkCZXGWJSetPageSize")
        End Sub

        Private Sub lnkCZXGWJGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJGotoPage.Click
            Me.doGotoPage_XGWJ("lnkCZXGWJGotoPage")
        End Sub

        Private Sub lnkCZXGWJSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJSelectAll.Click
            Me.doSelectAll_XGWJ("lnkCZXGWJSelectAll")
        End Sub

        Private Sub lnkCZXGWJDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZXGWJDeSelectAll.Click
            Me.doDeSelectAll_XGWJ("lnkCZXGWJDeSelectAll")
        End Sub




        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objOldXGWJData As Josco.JSOA.Common.Data.FlowData
            Dim blnOK As Boolean = False
            Dim strFlowTypeName As String
            Dim strFlowType As String

            Try
                'ѯ���Ƿ񱣴�
                intStep = 1
                If Me.m_objInterface.iEditMode = True Then
                    If Me.m_objInterface.iAutoSave = True Then
                        If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                            objMessageProcess.doConfirmMessage(Me.popMessageObject, "���棺��ȷ��Ҫ���浱ǰ����¼�����������/�񣩣�", strControlId, intStep, True)
                            Exit Try
                        Else
                            objMessageProcess.doResetPopMessage(Me.popMessageObject)
                        End If
                    End If
                End If

                '��������
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��ȡӦ����Ϣ
                    blnOK = objMessageProcess.getConfirmBoxValue(Request, Me.popMessageObject.UniqueID)

                    '������˲���
                    If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                        GoTo errProc
                    End If
                    Me.m_objDataSet_XGWJ.Tables(strTable).DefaultView.RowFilter = ""

                    '�Ƿ��Զ�����?
                    If Me.m_objInterface.iEditMode = True Then
                        '�༭ģʽ��
                        If Me.m_objInterface.iAutoSave = True Then
                            '��������ʼ��������
                            strFlowTypeName = Me.m_objInterface.iFlowTypeName
                            strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                            objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)
                            If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objInterface.iWJBS, False) = False Then
                                GoTo errProc
                            End If
                            '��Ҫ�Զ����棡
                            If blnOK = True Then
                                '��ȡԭ����ļ�����
                                If objsystemFlowObject.getXgwjData(strErrMsg, objOldXGWJData) = False Then
                                    GoTo errProc
                                End If
                                '�Զ����渽��
                                If objsystemFlowObject.doSaveXgwj(strErrMsg, Me.m_objInterface.iEnforeEdit, MyBase.UserXM, Me.m_objDataSet_XGWJ) = False Then
                                    GoTo errProc
                                End If
                                'д�����־
                                If objsystemFlowObject.doWriteUserLog_XGWJ(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, Me.m_objDataSet_XGWJ, objOldXGWJData) = False Then
                                    '����
                                End If
                            Else
                                '����༭����
                                If objsystemFlowObject.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                                    GoTo errProc
                                End If
                            End If
                            'ɾ�������ļ�
                            If objsystemFlowObject.doDeleteCacheFile_XGWJ(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
                                '���Բ��ɹ����γ������ļ�
                            End If
                        End If
                    End If

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

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            Exit Sub

        End Sub

        Private Sub doAddNewXGWJ_FJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowXgwjfjInfo As Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
            Dim strNewSessionId As String
            Dim strSessionId As String
            Dim strWJBS As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            Try
                '�����ֳ�����
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim strUrl As String
                objIFlowXgwjfjInfo = New Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
                With objIFlowXgwjfjInfo
                    Dim intXH As Integer
                    With Me.m_objDataSet_XGWJ.Tables(strTable)
                        If .Rows.Count < 1 Then
                            intXH = 1
                        Else
                            'intXH = objPulicParameters.getObjectValue(.Rows(.Rows.Count - 1).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH), 1)
                            intXH = Me.grdXGWJ.Items.Count
                            intXH = intXH + 1
                        End If
                    End With

                    'һ����Ϣ
                    .iEditType = JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    .iTrackRevisions = Me.m_objInterface.iTrackRevisions
                    .iEnforeEdit = Me.m_objInterface.iEnforeEdit
                    .iAutoSave = False '�϶����ص���������ټ��б���!
                    .iFlowTypeName = Me.m_strFlowTypeName
                    .iWJBS = Me.m_strWJBS
                    .iRow = Nothing
                    .iWJXH = intXH.ToString()
                    .iWJWZ = ""
                    .iWJSM = ""
                    .iWJYS = "1"

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
                strUrl += "flow_xgwjfj_info.aspx"
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

        Private Sub doAddNewXGWJ_LJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowXgwjljAdd As Josco.JSOA.BusinessFacade.IFlowXgwjljAdd
            Dim strNewSessionId As String
            Dim strSessionId As String
            Dim strWJBS As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            Try
                '�����ֳ�����
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim strUrl As String
                objIFlowXgwjljAdd = New Josco.JSOA.BusinessFacade.IFlowXgwjljAdd
                With objIFlowXgwjljAdd
                    .iDataSet_XGWJ = Me.m_objDataSet_XGWJ
                    .iFlowTypeName = Me.m_strFlowTypeName
                    .iWJBS = Me.m_strWJBS

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
                Session.Add(strNewSessionId, objIFlowXgwjljAdd)
                strUrl = ""
                strUrl += "flow_xgwjlj_add.aspx"
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

        Private Sub doModifyXGWJ_FJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowXgwjfjInfo As Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
            Dim strNewSessionId As String
            Dim strSessionId As String
            Dim strWJBS As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objDataRow As System.Data.DataRow

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

                '�����ֳ�����
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim strUrl As String
                objIFlowXgwjfjInfo = New Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
                With objIFlowXgwjfjInfo
                    'һ����Ϣ
                    .iEditType = JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    .iTrackRevisions = Me.m_objInterface.iTrackRevisions
                    .iEnforeEdit = Me.m_objInterface.iEnforeEdit
                    .iAutoSave = False '�϶����ص���������ټ��б���!
                    .iFlowTypeName = Me.m_strFlowTypeName
                    .iWJBS = Me.m_strWJBS
                    .iRow = objDataRow
                    .iWJXH = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH), "")
                    .iWJWZ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ), "")
                    .iWJSM = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT), "")
                    .iWJYS = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJYS), "")
                    .iBDWJ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ), "")

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
                strUrl += "flow_xgwjfj_info.aspx"
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

        Private Sub doModifyXGWJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objDataRow As System.Data.DataRow

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
                Dim intLB As Integer
                intLB = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LBBS), 0)

                '�����ദ��
                Select Case intLB
                    Case Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FlowFile
                        '�����޸ģ�ֻ�ܲ鿴
                    Case Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FujianFile
                        '�޸�����ļ�����
                        Me.doModifyXGWJ_FJ(strControlId)
                    Case Else
                        strErrMsg = "���󣺲�֧�ֵ����ͣ�"
                        GoTo errProc
                End Select

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

        Private Sub doOpenXGWJ_FJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowXgwjfjInfo As Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
            Dim strNewSessionId As String
            Dim strSessionId As String
            Dim strWJBS As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objDataRow As System.Data.DataRow

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

                '����ļ�����
                'LJ-2008-07-30
                Dim strFileExt As String = ""
                Dim strBDWJ As String = ""
                Dim strWJWZ As String = ""
                strBDWJ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ), "")
                strWJWZ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ), "")
                If strBDWJ = "" Then
                    If strWJWZ = "" Then
                        strErrMsg = "����û�ж�Ӧ�ĵ����ļ���"
                        GoTo errProc
                    End If
                    strFileExt = objBaseLocalFile.getExtension(strWJWZ)
                Else
                    strFileExt = objBaseLocalFile.getExtension(strBDWJ)
                End If
                Select Case strFileExt.ToUpper
                    Case ".DOC", ".RTF", ".XLS"
                        '����Ƕ�봦��
                    Case Else
                        '�������ش���
                        Me.doExport_FJ(strControlId)
                        Exit Try
                End Select
                'LJ-2008-07-30

                '�����ֳ�����
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim strUrl As String
                objIFlowXgwjfjInfo = New Josco.JSOA.BusinessFacade.IFlowXgwjfjInfo
                With objIFlowXgwjfjInfo
                    'һ����Ϣ
                    .iEditType = JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iTrackRevisions = Me.m_objInterface.iTrackRevisions
                    .iEnforeEdit = Me.m_objInterface.iEnforeEdit
                    .iAutoSave = False '�϶����ص���������ټ��б���!
                    .iFlowTypeName = Me.m_strFlowTypeName
                    .iWJBS = Me.m_strWJBS
                    .iRow = objDataRow
                    .iWJXH = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_XSXH), "")
                    .iWJWZ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ), "")
                    .iWJSM = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT), "")
                    .iWJYS = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJYS), "")
                    .iBDWJ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ), "")

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
                strUrl += "flow_xgwjfj_info.aspx"
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
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

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

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

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
                intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBS)
                intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJLX)
                intColIndex(2) = objDataGridProcess.getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_NGR)
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
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                strName = strFlowTypeName
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
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

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doOpenXGWJ_LJ = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        Private Sub doOpenXGWJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objDataRow As System.Data.DataRow

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
                Dim intLB As Integer
                intLB = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LBBS), 0)

                '���������
                Select Case intLB
                    Case Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FlowFile
                        '�򿪹������ļ�
                        If Me.doOpenXGWJ_LJ(strErrMsg, strControlId) = False Then
                            GoTo errProc
                        End If
                    Case Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FujianFile
                        '������ļ�����
                        Me.doOpenXGWJ_FJ(strControlId)
                    Case Else
                        strErrMsg = "���󣺲�֧�ֵ����ͣ�"
                        GoTo errProc
                End Select

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

        Private Sub doDeleteXGWJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objDataRow As System.Data.DataRow
            Dim intStep As Integer
            Dim intRow As Integer

            Try
                '���ѡ��
                'Dim blnSelected As Boolean
                'Dim intSelected As Integer
                'Dim intCount As Integer
                'Dim i As Integer
                'intStep = 1
                'If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                '    intCount = Me.grdXGWJ.Items.Count
                '    intSelected = 0
                '    For i = 0 To intCount - 1 Step 1
                '        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdXGWJ.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_XGWJ)
                '        If blnSelected = True Then
                '            intSelected += 1
                '        End If
                '    Next
                '    If intSelected < 1 Then
                '        strErrMsg = "��ʾ������Ҫɾ�����ļ�ǰ��,�ٵ��ɾ����ť����ɾ���ļ���"
                '        GoTo errProc
                '    End If
                'End If
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "����û�е�ǰ������Ϣ��"
                    GoTo errProc
                End If

                'ѯ��
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ��Ҫɾ���ļ�����/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                'ɾ������
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��������������
                    Dim strFlowTypeName As String
                    Dim strFlowType As String
                    strFlowTypeName = Me.m_strFlowTypeName
                    strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                    objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                    '��ȡ����
                    If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                        GoTo errProc
                    End If

                    'ɾ��                 
                    With Me.m_objDataSet_XGWJ.Tables(strTable)
                        intRow = objDataGridProcess.getRecordPosition(Me.grdXGWJ.SelectedIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                        objDataRow = .DefaultView.Item(intRow).Row
                        If objsystemFlowObject.doDeleteData_XGWJ(strErrMsg, objDataRow) = False Then
                            GoTo errProc
                        End If
                    End With


                    '��ȡ��������
                    If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                        GoTo errProc
                    End If

                    '�������
                    If objsystemFlowObject.doAutoAdjustXSXH_XGWJ(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
                        GoTo errProc
                    End If

                    'ˢ����ʾ
                    If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    '��ʾ�ɹ���Ϣ
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ���ɹ�ɾ����")
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doAutoSetXH(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

            Dim objDataRow As System.Data.DataRow
            Dim intStep As Integer
            Dim intRow As Integer

            Try
                '���
                If Me.grdXGWJ.Items.Count < 1 Then
                    strErrMsg = "����û���ļ���"
                    GoTo errProc
                End If

                'ѯ��
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷ��Ҫ��ϵͳ�Զ������������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '����
                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��������������
                    Dim strFlowTypeName As String
                    Dim strFlowType As String
                    strFlowTypeName = Me.m_strFlowTypeName
                    strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                    objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                    '��ȡ��������
                    If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                        GoTo errProc
                    End If

                    '�������
                    If objsystemFlowObject.doAutoAdjustXSXH_XGWJ(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
                        GoTo errProc
                    End If

                    'ˢ����ʾ
                    If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If

                    '��ʾ�ɹ���Ϣ
                    objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ���ɹ�������ţ�")
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doMoveUp(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objSrcDataRow As System.Data.DataRow
            Dim objDesDataRow As System.Data.DataRow
            Dim intRow As Integer

            Try
                '���
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "����δѡ��Ҫ�ƶ����ļ���"
                    GoTo errProc
                End If
                Dim intSrcIndex As Integer = Me.grdXGWJ.SelectedIndex
                If intSrcIndex <= 0 Then
                    strErrMsg = "�����Ѿ��������棡"
                    GoTo errProc
                End If
                Dim intDesIndex As Integer = intSrcIndex - 1

                '��������������
                Dim strFlowTypeName As String
                Dim strFlowType As String
                strFlowTypeName = Me.m_strFlowTypeName
                strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                '��ȡ����
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '����
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(intSrcIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objSrcDataRow = .DefaultView.Item(intRow).Row

                    intRow = objDataGridProcess.getRecordPosition(intDesIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDesDataRow = .DefaultView.Item(intRow).Row

                    '�ƶ�
                    If objsystemFlowObject.doMoveTo_XGWJ(strErrMsg, objSrcDataRow, objDesDataRow) = False Then
                        GoTo errProc
                    End If

                    '���ĵ�ǰ����
                    Me.grdXGWJ.SelectedIndex = intDesIndex
                End With

                '��ȡ��������
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '�������
                If objsystemFlowObject.doAutoAdjustXSXH_XGWJ(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
                    GoTo errProc
                End If

                'ˢ����ʾ
                If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doMoveDown(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objSrcDataRow As System.Data.DataRow
            Dim objDesDataRow As System.Data.DataRow
            Dim intRow As Integer

            Try
                '���
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "����δѡ��Ҫ�ƶ����ļ���"
                    GoTo errProc
                End If
                Dim intSrcIndex As Integer = Me.grdXGWJ.SelectedIndex
                If ((intSrcIndex >= Me.grdXGWJ.PageSize - 1) Or (intSrcIndex >= Me.grdXGWJ.Items.Count - 1)) And Me.grdXGWJ.AllowPaging = True Then
                    strErrMsg = "�����Ѿ��������棡"
                    GoTo errProc
                End If
                Dim intDesIndex As Integer = intSrcIndex + 1

                '��������������
                Dim strFlowTypeName As String
                Dim strFlowType As String
                strFlowTypeName = Me.m_strFlowTypeName
                strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)

                '��ȡ����
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '����
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(intSrcIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objSrcDataRow = .DefaultView.Item(intRow).Row

                    intRow = objDataGridProcess.getRecordPosition(intDesIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDesDataRow = .DefaultView.Item(intRow).Row

                    '�ƶ�
                    If objsystemFlowObject.doMoveTo_XGWJ(strErrMsg, objSrcDataRow, objDesDataRow) = False Then
                        GoTo errProc
                    End If

                    '���ĵ�ǰ����
                    Me.grdXGWJ.SelectedIndex = intDesIndex
                End With

                '��ȡ��������
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '�������
                If objsystemFlowObject.doAutoAdjustXSXH_XGWJ(strErrMsg, Me.m_objDataSet_XGWJ) = False Then
                    GoTo errProc
                End If

                'ˢ����ʾ
                If Me.showModuleData_Main(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doExport_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon
            Dim objDataRow As System.Data.DataRow
            Dim intRowIndex As Integer
            Dim intRow As Integer

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            Try
                '���
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "����δѡ��Ҫ�������ļ���"
                    GoTo errProc
                End If
                intRowIndex = Me.grdXGWJ.SelectedIndex

                '��ȡ����
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '��ʼ��������
                Dim strName As String = Me.m_objInterface.iFlowTypeName
                Dim strType As String
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strName)
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objInterface.iWJBS, False) = False Then
                    GoTo errProc
                End If

                '��ȡ��Ϣ
                Dim intColIndex(2) As Integer
                Dim strFTPPath As String
                Dim strDesSpec As String
                Dim strDesPath As String
                Dim strDesFile As String
                Dim strUrl As String
                With objDataGridProcess
                    intColIndex(0) = .getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ)
                    intColIndex(1) = .getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ)
                    strFTPPath = .getDataGridCellValue(Me.grdXGWJ.Items(intRowIndex), intColIndex(0))
                    strDesSpec = .getDataGridCellValue(Me.grdXGWJ.Items(intRowIndex), intColIndex(1))
                End With
                If strFTPPath = "" And strDesSpec = "" Then
                    strErrMsg = "���󣺸��ļ�û�е����ļ���"
                    GoTo errProc
                End If

                '�����ļ�
                If strDesSpec <> "" Then
                    '���ֱ���б����ļ�����ֱ�ӽ�WEB�����ļ����ص��ͻ���
                    strDesFile = objBaseLocalFile.getFileName(strDesSpec)
                Else
                    '��FTP����������
                    strDesPath = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache
                    strDesPath = Server.MapPath(strDesPath)
                    If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, strFTPPath, strDesSpec, strDesPath, strDesFile) = False Then
                        GoTo errProc
                    End If
                    strDesSpec = objBaseLocalFile.doMakePath(strDesPath, strDesFile)
                End If
                strUrl = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache + strDesFile

                '��¼�����ļ�
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(intRowIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ) = strDesSpec
                End With

                '��¼���������־
                If objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + objsystemFlowObject.FlowData.WJBS + "]�ĵ�[" + (Me.grdXGWJ.SelectedIndex + 1).ToString + "]������ļ���") = False Then
                    '����
                End If

                '���ص��ͻ���
                objMessageProcess.doOpenUrl(Me.popMessageObject, strUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doExportFile_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon
            Dim objDataRow As System.Data.DataRow
            Dim intRowIndex As Integer
            Dim intRow As Integer

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN

            Try
                '���
                If Me.grdXGWJ.SelectedIndex < 0 Then
                    strErrMsg = "����δѡ��Ҫ�������ļ���"
                    GoTo errProc
                End If
                intRowIndex = Me.grdXGWJ.SelectedIndex

                '��ȡ����
                If Me.getModuleData_XGWJ(strErrMsg, Me.m_strQuery_XGWJ) = False Then
                    GoTo errProc
                End If

                '��ʼ��������
                Dim strName As String = Me.m_objInterface.iFlowTypeName
                Dim strType As String
                strType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strName)
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objInterface.iWJBS, False) = False Then
                    GoTo errProc
                End If

                '��ȡ��Ϣ
                Dim intColIndex(3) As Integer
                Dim strFTPPath As String
                Dim strDesSpec As String
                Dim strDesPath As String
                Dim strDesFile As String
                Dim strFileName As String = ""
                Dim strFileExt As String = ""
                Dim strUrl As String
                With objDataGridProcess
                    intColIndex(0) = .getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_FJWZ)
                    intColIndex(1) = .getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ)
                    intColIndex(2) = .getDataGridColumnIndex(Me.grdXGWJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_WJBT)
                    strFTPPath = .getDataGridCellValue(Me.grdXGWJ.Items(intRowIndex), intColIndex(0))
                    strDesSpec = .getDataGridCellValue(Me.grdXGWJ.Items(intRowIndex), intColIndex(1))
                    strFileName = .getDataGridCellValue(Me.grdXGWJ.Items(intRowIndex), intColIndex(2))
                End With
                'LJ 2008-08-12
                If strDesSpec = "" Then
                    If strFTPPath = "" Then
                        strErrMsg = "����û�ж�Ӧ�ĵ����ļ���"
                        GoTo errProc
                    End If
                    strFileExt = objBaseLocalFile.getExtension(strFTPPath)
                Else
                    strFileExt = objBaseLocalFile.getExtension(strDesSpec)
                End If
                strFileName = strFileName + strFileExt
                '�����ļ�
                If strDesSpec <> "" Then
                    '���ֱ���б����ļ�����ֱ�ӽ�WEB�����ļ����ص��ͻ���
                    strDesFile = objBaseLocalFile.getFileName(strDesSpec)
                Else
                    '��FTP����������
                    strDesPath = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache
                    strDesPath = Server.MapPath(strDesPath)
                    If objsystemCommon.doFTPDownLoadFile(strErrMsg, MyBase.UserId, MyBase.UserPassword, strFTPPath, strDesSpec, strDesPath, strDesFile) = False Then
                        GoTo errProc
                    End If
                    strDesSpec = objBaseLocalFile.doMakePath(strDesPath, strDesFile)
                End If
                strUrl = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache + strDesFile

                '��¼�����ļ�
                With Me.m_objDataSet_XGWJ.Tables(strTable)
                    intRow = objDataGridProcess.getRecordPosition(intRowIndex, Me.grdXGWJ.CurrentPageIndex, Me.grdXGWJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_BDWJ) = strDesSpec
                End With

                '��¼���������־
                If objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + objsystemFlowObject.FlowData.WJBS + "]�ĵ�[" + (Me.grdXGWJ.SelectedIndex + 1).ToString + "]������ļ���") = False Then
                    '����
                End If

                Me.Response.ClearHeaders()
                Me.Response.Clear()
                Me.Response.Expires = 0
                Me.Response.Buffer = True
                Me.Response.AddHeader("Accept-Language", "zh-tw")
                '�ļ����� 
                Me.Response.AddHeader("content-disposition", "attachment;filename=" + Chr(34) + System.Web.HttpUtility.UrlEncode(strFileName, System.Text.Encoding.UTF8) + Chr(34))
                Me.Response.ContentType = "Application/octet-stream"
                '�ļ����� 
                Me.Response.WriteFile(strUrl)
                Me.Response.End()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.BusinessFacade.systemCommon.SafeRelease(objsystemCommon)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doExport(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strTable As String = Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_SHENPIWENJIAN_FUJIAN
            Dim objDataRow As System.Data.DataRow

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
                Dim intLB As Integer
                intLB = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_SHENPIWENJIAN_FUJIAN_LBBS), 0)

                '�����ദ��
                Select Case intLB
                    Case Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FlowFile
                        '����Ĭ�Ϲ������ļ�
                        objMessageProcess.doAlertMessage(Me.popMessageObject, "��ʾ������[����]�ļ��й�������������ļ���ѡ��Ҫ���������ݣ�")
                        Exit Try
                    Case Josco.JSOA.Common.Data.FlowData.enumXGWJLB.FujianFile
                        '��������ļ�����
                        Me.doExportFile_FJ(strControlId)
                    Case Else
                        strErrMsg = "���󣺲�֧�ֵ����ͣ�"
                        GoTo errProc
                End Select

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

        Private Sub lnkMLClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLClose.Click
            Me.doClose("lnkMLClose")
        End Sub

        Private Sub lnkMLSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLSelect.Click
            Me.doOpenXGWJ("lnkMLSelect")
        End Sub

        Private Sub lnkMLAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLAddNew.Click
            Me.doAddNewXGWJ_FJ("lnkMLAddNew")
        End Sub

        Private Sub lnkMLAddNewWJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLAddNewWJ.Click
            Me.doAddNewXGWJ_LJ("lnkMLAddNewWJ")
        End Sub

        Private Sub lnkMLModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLModify.Click
            Me.doModifyXGWJ("lnkMLModify")
        End Sub

        Private Sub lnkMLDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLDelete.Click
            Me.doDeleteXGWJ("lnkMLDelete")
        End Sub

        Private Sub lnkMLAutoXH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLAutoXH.Click
            Me.doAutoSetXH("lnkMLAutoXH")
        End Sub

        Private Sub lnkMLMoveUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLMoveUp.Click
            Me.doMoveUp("lnkMLMoveUp")
        End Sub

        Private Sub lnkMLMoveDn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLMoveDn.Click
            Me.doMoveDown("lnkMLMoveDn")
        End Sub

        Private Sub lnkMLExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLExport.Click
            Me.doExport("lnkMLExport")
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
                        Me.doOpenXGWJ("lnkMLSelect")



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
    End Class

End Namespace
