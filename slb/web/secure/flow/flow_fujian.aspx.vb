Imports System.Web.Security
Imports System.Threading
Imports System.Char
Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Permissions
Imports Microsoft.Win32
Imports System.Diagnostics


Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��flow_fujian
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã�����Ҳ��������ģ��
    '
    ' ���������� 
    '   �������ļ����������ӡ��޸ġ�ɾ�����鿴�������Ȳ���
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IFlowFujian����
    '----------------------------------------------------------------

    Public Class flow_fujian
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkMLAddNew As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLModify As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLDelete As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLSelect As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLMoveUp As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLMoveDn As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLAutoXH As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkMLExport As System.Web.UI.WebControls.LinkButton
        '2010-05-21 LJ
        Protected WithEvents lnkMLExportAll As System.Web.UI.WebControls.LinkButton
        '2010-05-21 LJ
        Protected WithEvents lnkMLClose As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFJDeSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFJSelectAll As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFJMoveFirst As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFJMovePrev As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFJMoveNext As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFJMoveLast As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkCZFJGotoPage As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtFJPageIndex As System.Web.UI.WebControls.TextBox
        Protected WithEvents lnkCZFJSetPageSize As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtFJPageSize As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblFJGridLocInfo As System.Web.UI.WebControls.Label
        Protected WithEvents grdFJ As System.Web.UI.WebControls.DataGrid
        Protected WithEvents panelMain As System.Web.UI.WebControls.Panel
        Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
        Protected WithEvents panelError As System.Web.UI.WebControls.Panel
        Protected WithEvents htxtFJFixed As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFJQuery As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFJRows As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFJSort As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFJSortColumnIndex As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtFJSortType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivLeftFJ As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents htxtDivTopFJ As System.Web.UI.HtmlControls.HtmlInputHidden
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMFlowFujian
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IFlowFujian
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        'ģ��������ݲ���
        '----------------------------------------------------------------
        Private m_objDataSet_FJ As Josco.JSOA.Common.Data.FlowData
        Private m_strQuery_FJ As String '��¼m_objDataSet_FJ������
        Private m_intRows_FJ As Integer '��¼m_objDataSet_FJ��DefaultView��¼��

        '----------------------------------------------------------------
        '����������grdFJ��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_FJ As String = "chkFJ"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_FJ As String = "divFJ"
        '����Ҫ����������
        Private m_intFixedColumns_FJ As Integer

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
                    Me.txtFJPageIndex.Text = .txtFJPageIndex
                    Me.txtFJPageSize.Text = .txtFJPageSize

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftFJ.Value = .htxtDivLeftFJ
                    Me.htxtDivTopFJ.Value = .htxtDivTopFJ

                    Me.htxtFJQuery.Value = .htxtFJQuery
                    Me.htxtFJRows.Value = .htxtFJRows
                    Me.htxtFJSort.Value = .htxtFJSort
                    Me.htxtFJSortColumnIndex.Value = .htxtFJSortColumnIndex
                    Me.htxtFJSortType.Value = .htxtFJSortType

                    Me.m_objDataSet_FJ = .objDataSet_FJ
                    Try
                        Me.grdFJ.PageSize = .grdFJ_PageSize
                        Me.grdFJ.SelectedIndex = .grdFJ_SelectedIndex
                    Catch ex As Exception
                    End Try

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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMFlowFujian

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .txtFJPageIndex = Me.txtFJPageIndex.Text
                    .txtFJPageSize = Me.txtFJPageSize.Text

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftFJ = Me.htxtDivLeftFJ.Value
                    .htxtDivTopFJ = Me.htxtDivTopFJ.Value

                    .htxtFJQuery = Me.htxtFJQuery.Value
                    .htxtFJRows = Me.htxtFJRows.Value
                    .htxtFJSort = Me.htxtFJSort.Value
                    .htxtFJSortColumnIndex = Me.htxtFJSortColumnIndex.Value
                    .htxtFJSortType = Me.htxtFJSortType.Value

                    .objDataSet_FJ = Me.m_objDataSet_FJ
                    .grdFJ_PageSize = Me.grdFJ.PageSize
                    .grdFJ_SelectedIndex = Me.grdFJ.SelectedIndex
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
            Dim objDataRow As System.Data.DataRow

            Try
                If Me.IsPostBack = True Then Exit Try

                '=================================================================
                Dim objIFlowFujianInfo As Josco.JSOA.BusinessFacade.IFlowFujianInfo
                Try
                    objIFlowFujianInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowFujianInfo)
                Catch ex As Exception
                    objIFlowFujianInfo = Nothing
                End Try
                If Not (objIFlowFujianInfo Is Nothing) Then
                    If objIFlowFujianInfo.oExitMode = True Then
                        '���ز�������
                        With Me.m_objInterface.iDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                            Select Case objIFlowFujianInfo.iEditType
                                Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                    JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                    objDataRow = .NewRow()
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XSXH) = objPulicParameters.getObjectValue(objIFlowFujianInfo.oWJXH, 1)
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS) = objPulicParameters.getObjectValue(objIFlowFujianInfo.oWJYS, 1)
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ) = objIFlowFujianInfo.oBDWJ
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ) = objIFlowFujianInfo.oWJWZ
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM) = objIFlowFujianInfo.oWJSM
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XZBZ) = intXZBZ.ToString()
                                    .Rows.Add(objDataRow)
                                Case JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                                    objDataRow = objIFlowFujianInfo.iRow
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS) = objPulicParameters.getObjectValue(objIFlowFujianInfo.oWJYS, 1)
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ) = objIFlowFujianInfo.oWJWZ
                                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM) = objIFlowFujianInfo.oWJSM
                                    If objIFlowFujianInfo.oBDWJ <> "" Then
                                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ) = objIFlowFujianInfo.oBDWJ
                                        objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XZBZ) = intXZBZ.ToString()
                                    End If
                            End Select
                        End With
                    End If
                    '�ͷ���Դ
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    objIFlowFujianInfo.Dispose()
                    objIFlowFujianInfo = Nothing
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IFlowFujian)
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMFlowFujian)
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
                Me.m_intFixedColumns_FJ = objPulicParameters.getObjectValue(Me.htxtFJFixed.Value, 0)
                Me.m_intRows_FJ = objPulicParameters.getObjectValue(Me.htxtFJRows.Value, 0)
                Me.m_strQuery_FJ = Me.htxtFJQuery.Value

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
        Private Function getModuleData_FJ( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            getModuleData_FJ = False

            Try
                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtFJSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '��ȡ����
                Me.m_objDataSet_FJ = Me.m_objInterface.iDataSet_FJ

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    .DefaultView.Sort = Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XSXH + " asc" 'ȱʡ���򣬲��ܸı�
                    .DefaultView.RowFilter = strWhere
                End With

                '�������
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    Me.htxtFJRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_FJ = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_FJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdFJ����������(RowFilter��ʽ)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_FJ( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_FJ = False
            strQuery = ""

            Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_FJ = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdFJ����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_FJ(ByRef strErrMsg As String) As Boolean

            searchModuleData_FJ = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_FJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_FJ(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_FJ = strQuery
                Me.htxtFJQuery.Value = Me.m_strQuery_FJ

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_FJ = True
            Exit Function

errProc:
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
                    With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                        Me.grdFJ.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
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

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdFJ, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_FJ) = False Then
                    GoTo errProc
                End If

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
        ' ��ʾgrdFJ���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_FJ(ByRef strErrMsg As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_FJ = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_FJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblFJGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdFJ, .Count)
                    '��ʾҳ���������
                    Me.lnkCZFJMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdFJ, .Count)
                    Me.lnkCZFJMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdFJ, .Count)
                    Me.lnkCZFJMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdFJ, .Count)
                    Me.lnkCZFJMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdFJ, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZFJDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZFJSelectAll.Enabled = blnEnabled
                    Me.lnkCZFJGotoPage.Enabled = blnEnabled
                    Me.lnkCZFJSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_FJ = True
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
                If Me.showModuleData_FJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ����
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
                        .doTranslateKey(Me.txtFJPageIndex)
                        .doTranslateKey(Me.txtFJPageSize)
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
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
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




        Private Sub grdFJ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFJ.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                With New Josco.JsKernal.web.DataGridProcess
                    Me.lblFJGridLocInfo.Text = .getDataGridLocation(Me.grdFJ, Me.m_intRows_FJ)
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




        Private Sub grdFJ_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdFJ.SortCommand

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
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                strOldCommand = Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN).DefaultView.Sort

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN).DefaultView.Sort = strFinalCommand

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtFJSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtFJSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtFJSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_FJ(strErrMsg) = False Then
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




        Private Sub doMoveFirst_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdFJ.PageCount)
                Me.grdFJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_FJ(strErrMsg) = False Then
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

        Private Sub doMoveLast_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFJ.PageCount - 1, Me.grdFJ.PageCount)
                Me.grdFJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_FJ(strErrMsg) = False Then
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

        Private Sub doMoveNext_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFJ.CurrentPageIndex + 1, Me.grdFJ.PageCount)
                Me.grdFJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_FJ(strErrMsg) = False Then
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

        Private Sub doMovePrevious_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdFJ.CurrentPageIndex - 1, Me.grdFJ.PageCount)
                Me.grdFJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_FJ(strErrMsg) = False Then
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

        Private Sub doGotoPage_FJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtFJPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdFJ.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_FJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtFJPageIndex.Text = (Me.grdFJ.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_FJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtFJPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdFJ.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_FJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtFJPageSize.Text = (Me.grdFJ.PageSize).ToString()

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

        Private Sub doSelectAll_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdFJ, 0, Me.m_cstrCheckBoxIdInDataGrid_FJ, True) = False Then
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

        Private Sub doDeSelectAll_FJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdFJ, 0, Me.m_cstrCheckBoxIdInDataGrid_FJ, False) = False Then
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

        Private Sub doSearch_FJ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_FJ(strErrMsg) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_FJ(strErrMsg) = False Then
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

        Private Sub lnkCZFJMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJMoveFirst.Click
            Me.doMoveFirst_FJ("lnkCZFJMoveFirst")
        End Sub

        Private Sub lnkCZFJMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJMoveLast.Click
            Me.doMoveLast_FJ("lnkCZFJMoveLast")
        End Sub

        Private Sub lnkCZFJMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJMovePrev.Click
            Me.doMovePrevious_FJ("lnkCZFJMovePrev")
        End Sub

        Private Sub lnkCZFJMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJMoveNext.Click
            Me.doMoveNext_FJ("lnkCZFJMoveNext")
        End Sub

        Private Sub lnkCZFJSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJSetPageSize.Click
            Me.doSetPageSize_FJ("lnkCZFJSetPageSize")
        End Sub

        Private Sub lnkCZFJGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJGotoPage.Click
            Me.doGotoPage_FJ("lnkCZFJGotoPage")
        End Sub

        Private Sub lnkCZFJSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJSelectAll.Click
            Me.doSelectAll_FJ("lnkCZFJSelectAll")
        End Sub

        Private Sub lnkCZFJDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZFJDeSelectAll.Click
            Me.doDeSelectAll_FJ("lnkCZFJDeSelectAll")
        End Sub




        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String
            Dim intStep As Integer

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objOldFJData As Josco.JSOA.Common.Data.FlowData
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
                    If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                        GoTo errProc
                    End If
                    Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN).DefaultView.RowFilter = ""

                    '�Ƿ��Զ�����?
                    If Me.m_objInterface.iEditMode = True Then
                        '�༭ģʽ��
                        If Me.m_objInterface.iAutoSave = True Then
                            '��Ҫ�Զ����棡
                            '��������ʼ��������
                            strFlowTypeName = Me.m_objInterface.iFlowTypeName
                            strFlowType = Josco.JSOA.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                            objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObject.Create(strFlowType, strFlowTypeName)
                            If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objInterface.iWJBS, False) = False Then
                                GoTo errProc
                            End If
                            If blnOK = True Then
                                '��ȡԭ��������
                                If objsystemFlowObject.getFujianData(strErrMsg, objOldFJData) = False Then
                                    GoTo errProc
                                End If

                                '�Զ����渽��
                                If objsystemFlowObject.doSaveFujian(strErrMsg, Me.m_objInterface.iEnforeEdit, MyBase.UserXM, Me.m_objDataSet_FJ) = False Then
                                    GoTo errProc
                                End If

                                'д�����־
                                If objsystemFlowObject.doWriteUserLog_Fujian(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, Me.m_objDataSet_FJ, objOldFJData) = False Then
                                    '����
                                End If
                            Else
                                '����Լ����ļ��ı༭����
                                If objsystemFlowObject.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                                    GoTo errProc
                                End If
                            End If
                            'ɾ�������ļ�
                            If objsystemFlowObject.doDeleteCacheFile_FJ(strErrMsg, Me.m_objDataSet_FJ) = False Then
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
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldFJData)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Josco.JSOA.Common.Data.FlowData.SafeRelease(objOldFJData)
            Exit Sub

        End Sub

        Private Sub doAddNewFJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowFujianInfo As Josco.JSOA.BusinessFacade.IFlowFujianInfo
            Dim strNewSessionId As String
            Dim strSessionId As String
            Dim strWJBS As String

            Try
                '�����ֳ�����
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim strUrl As String
                objIFlowFujianInfo = New Josco.JSOA.BusinessFacade.IFlowFujianInfo
                With objIFlowFujianInfo
                    Dim intXH As Integer
                    With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                        If .Rows.Count < 1 Then
                            intXH = 1
                        Else
                            'intXH = objPulicParameters.getObjectValue(.Rows(.Rows.Count - 1).Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XSXH), 1)
                            intXH = Me.grdFJ.Items.Count
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
                Session.Add(strNewSessionId, objIFlowFujianInfo)
                strUrl = ""
                strUrl += "flow_fujian_info.aspx"
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

        Private Sub doModifyFJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowFujianInfo As Josco.JSOA.BusinessFacade.IFlowFujianInfo
            Dim strNewSessionId As String
            Dim strSessionId As String
            Dim strWJBS As String

            Dim objDataRow As System.Data.DataRow

            Try
                '���
                If Me.grdFJ.SelectedIndex < 0 Then
                    strErrMsg = "����û�е�ǰ������Ϣ��"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    With New Josco.JsKernal.web.DataGridProcess
                        intRow = .getRecordPosition(Me.grdFJ.SelectedIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    End With
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
                objIFlowFujianInfo = New Josco.JSOA.BusinessFacade.IFlowFujianInfo
                With objIFlowFujianInfo
                    'һ����Ϣ
                    .iEditType = JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    .iTrackRevisions = Me.m_objInterface.iTrackRevisions
                    .iEnforeEdit = Me.m_objInterface.iEnforeEdit
                    .iAutoSave = False '�϶����ص���������ټ��б���!
                    .iFlowTypeName = Me.m_strFlowTypeName
                    .iWJBS = Me.m_strWJBS
                    .iRow = objDataRow
                    .iWJXH = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XSXH), "")
                    .iWJWZ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ), "")
                    .iWJSM = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM), "")
                    .iWJYS = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS), "")
                    .iBDWJ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ), "")

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
                strUrl += "flow_fujian_info.aspx"
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

        Private Sub doOpenFJ(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objIFlowFujianInfo As Josco.JSOA.BusinessFacade.IFlowFujianInfo

            Dim strNewSessionId As String
            Dim strSessionId As String
            Dim strWJBS As String

            Dim objDataRow As System.Data.DataRow

            Try
                '���
                If Me.grdFJ.SelectedIndex < 0 Then
                    strErrMsg = "����û�е�ǰ������Ϣ��"
                    GoTo errProc
                End If
                Dim intRow As Integer
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    With New Josco.JsKernal.web.DataGridProcess
                        intRow = .getRecordPosition(Me.grdFJ.SelectedIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    End With
                    objDataRow = .DefaultView.Item(intRow).Row
                End With

                '����ļ�����
                'LJ-2008-07-29
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
                        Me.doExport(strControlId)
                        Exit Try
                End Select
                'LJ-2008-07-29

                '�����ֳ�����
                strSessionId = Me.saveModuleInformation()
                If strSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim strUrl As String
                objIFlowFujianInfo = New Josco.JSOA.BusinessFacade.IFlowFujianInfo
                With objIFlowFujianInfo
                    'һ����Ϣ
                    .iEditType = JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iTrackRevisions = Me.m_objInterface.iTrackRevisions
                    .iEnforeEdit = Me.m_objInterface.iEnforeEdit
                    .iAutoSave = False '�϶����ص���������ټ��б���!
                    .iFlowTypeName = Me.m_strFlowTypeName
                    .iWJBS = Me.m_strWJBS
                    .iRow = objDataRow
                    .iWJXH = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_XSXH), "")
                    .iWJWZ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ), "")
                    .iWJSM = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM), "")
                    .iWJYS = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS), "")
                    .iBDWJ = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ), "")

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
                strUrl += "flow_fujian_info.aspx"
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
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doDeleteFJ(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject

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
                '    intCount = Me.grdFJ.Items.Count
                '    intSelected = 0
                '    For i = 0 To intCount - 1 Step 1
                '        blnSelected = objDataGridProcess.isDataGridItemChecked(Me.grdFJ.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_FJ)
                '        If blnSelected = True Then
                '            intSelected += 1
                '        End If
                '    Next
                '    If intSelected < 1 Then
                '        strErrMsg = "��ʾ������Ҫɾ�����ļ�ǰ��,�ٵ��ɾ����ť����ɾ���ļ���"
                '        GoTo errProc
                '    End If
                'End If
                '���
                If Me.grdFJ.SelectedIndex < 0 Then
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
                    If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                        GoTo errProc
                    End If

                    'ɾ��
                    With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                        intRow = objDataGridProcess.getRecordPosition(Me.grdFJ.SelectedIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                        objDataRow = .DefaultView.Item(intRow).Row
                        If objsystemFlowObject.doDeleteData_FJ(strErrMsg, objDataRow) = False Then
                            GoTo errProc
                        End If
                    End With

                    '��ȡ��������
                    If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                        GoTo errProc
                    End If

                    '�������
                    If objsystemFlowObject.doAutoAdjustXSXH_FJ(strErrMsg, Me.m_objDataSet_FJ) = False Then
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
                If Me.grdFJ.Items.Count < 1 Then
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
                    If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                        GoTo errProc
                    End If

                    '�������
                    If objsystemFlowObject.doAutoAdjustXSXH_FJ(strErrMsg, Me.m_objDataSet_FJ) = False Then
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

            Dim objSrcDataRow As System.Data.DataRow
            Dim objDesDataRow As System.Data.DataRow
            Dim intRow As Integer

            Try
                '���
                If Me.grdFJ.SelectedIndex < 0 Then
                    strErrMsg = "����δѡ��Ҫ�ƶ����ļ���"
                    GoTo errProc
                End If
                Dim intSrcIndex As Integer = Me.grdFJ.SelectedIndex
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
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '����
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    intRow = objDataGridProcess.getRecordPosition(intSrcIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    objSrcDataRow = .DefaultView.Item(intRow).Row

                    intRow = objDataGridProcess.getRecordPosition(intDesIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    objDesDataRow = .DefaultView.Item(intRow).Row

                    '�ƶ�
                    If objsystemFlowObject.doMoveTo_FJ(strErrMsg, objSrcDataRow, objDesDataRow) = False Then
                        GoTo errProc
                    End If

                    '���ĵ�ǰ����
                    Me.grdFJ.SelectedIndex = intDesIndex
                End With

                '��ȡ��������
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '�������
                If objsystemFlowObject.doAutoAdjustXSXH_FJ(strErrMsg, Me.m_objDataSet_FJ) = False Then
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

            Dim objSrcDataRow As System.Data.DataRow
            Dim objDesDataRow As System.Data.DataRow
            Dim intRow As Integer

            Try
                '���
                If Me.grdFJ.SelectedIndex < 0 Then
                    strErrMsg = "����δѡ��Ҫ�ƶ����ļ���"
                    GoTo errProc
                End If
                Dim intSrcIndex As Integer = Me.grdFJ.SelectedIndex
                If ((intSrcIndex >= Me.grdFJ.PageSize - 1) Or (intSrcIndex >= Me.grdFJ.Items.Count - 1)) And Me.grdFJ.AllowPaging = True Then
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
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '����
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    intRow = objDataGridProcess.getRecordPosition(intSrcIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    objSrcDataRow = .DefaultView.Item(intRow).Row

                    intRow = objDataGridProcess.getRecordPosition(intDesIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    objDesDataRow = .DefaultView.Item(intRow).Row

                    '�ƶ�
                    If objsystemFlowObject.doMoveTo_FJ(strErrMsg, objSrcDataRow, objDesDataRow) = False Then
                        GoTo errProc
                    End If

                    '���ĵ�ǰ����
                    Me.grdFJ.SelectedIndex = intDesIndex
                End With

                '��ȡ��������
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
                    GoTo errProc
                End If

                '�������
                If objsystemFlowObject.doAutoAdjustXSXH_FJ(strErrMsg, Me.m_objDataSet_FJ) = False Then
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

        Private Sub doExport(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon
            Dim objDataRow As System.Data.DataRow
            Dim intRowIndex As Integer
            Dim intRow As Integer
            Dim strFileName As String = ""

            Try
                '���
                If Me.grdFJ.SelectedIndex < 0 Then
                    strErrMsg = "����δѡ��Ҫ�������ļ���"
                    GoTo errProc
                End If
                intRowIndex = Me.grdFJ.SelectedIndex

                '��ȡ����
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
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
                    intColIndex(0) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ)
                    intColIndex(1) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ)
                    strFTPPath = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(0))
                    strDesSpec = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(1))
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
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    intRow = objDataGridProcess.getRecordPosition(intRowIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ) = strDesSpec
                End With

                '��¼���������־
                If objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + objsystemFlowObject.FlowData.WJBS + "]�ĵ�[" + (Me.grdFJ.SelectedIndex + 1).ToString + "]��������") = False Then
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

        'lj 2008-08-12
        Private Sub doExportFile(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon
            Dim objDataRow As System.Data.DataRow
            Dim intRowIndex As Integer
            Dim intRow As Integer

            Try
                '���
                If Me.grdFJ.SelectedIndex < 0 Then
                    strErrMsg = "����δѡ��Ҫ�������ļ���"
                    GoTo errProc
                End If
                intRowIndex = Me.grdFJ.SelectedIndex


                '��ȡ����
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
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
                Dim i As Integer

                With objDataGridProcess
                    intColIndex(0) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ)
                    intColIndex(1) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ)
                    intColIndex(2) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM)
                    strFTPPath = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(0))
                    strDesSpec = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(1))
                    strFileName = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(2))
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
                With Me.m_objDataSet_FJ.Tables(Josco.JSOA.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
                    intRow = objDataGridProcess.getRecordPosition(intRowIndex, Me.grdFJ.CurrentPageIndex, Me.grdFJ.PageSize)
                    objDataRow = .DefaultView.Item(intRow).Row
                    objDataRow.Item(Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ) = strDesSpec
                End With

                '��¼���������־
                If objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + objsystemFlowObject.FlowData.WJBS + "]�ĵ�[" + (Me.grdFJ.SelectedIndex + 1).ToString + "]��������") = False Then
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
                'Me.Response.Write(System.IO.File.OpenWrite(strFTPPath))
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

        Private Sub doCompressRAR(ByVal patch As String, ByVal rarPatch As String, ByVal rarName As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim the_rar As String
            Dim the_Reg As RegistryKey
            Dim the_Obj As Object
            Dim the_Info As String
            Dim the_StartInfo As ProcessStartInfo
            Dim the_Process As Process

            Try
                the_Reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe")
                the_Obj = the_Reg.GetValue("")
                the_rar = CStr(the_Obj)

                Dim FileString As String 'Shellָ���е��ַ���   
                Dim Result As Long
                FileString = the_rar + " a -EP1 " + rarName + " " + patch
                Result = Shell(FileString, vbHide)

                the_Reg.Close()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        'lj 2010-05-21
        Private Sub doExportFileAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JSOA.BusinessFacade.systemFlowObject
            Dim objsystemCommon As New Josco.JsKernal.BusinessFacade.systemCommon
            Dim objDataRow As System.Data.DataRow
            Dim intRowIndex As Integer
            Dim intRow As Integer
            Dim intCountRow As Integer

            Try
                '���
                If Me.grdFJ.Items.Count <= 0 Then
                    strErrMsg = "������û�и�����"
                    GoTo errProc
                End If


                '��ȡ����
                If Me.getModuleData_FJ(strErrMsg, Me.m_strQuery_FJ) = False Then
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
                Dim strDesSpec_0 As String
                Dim strDesSpec_1 As String = ""
                Dim strDesPath As String
                Dim strDesFile As String
                Dim strFileName As String = ""
                Dim strFileExt As String = ""
                Dim strUrl As String = ""
                Dim i As Integer = 0

                intCountRow = Me.grdFJ.Items.Count
                intRowIndex = 0
                With objDataGridProcess
                    intColIndex(0) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ)
                    intColIndex(1) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ)
                    intColIndex(2) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM)
                    strFTPPath = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(0))
                    strDesSpec = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(1))
                    strFileName = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(2))
                End With

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
                strDesSpec_0 = strDesSpec + ".rar"
                strDesSpec_1 = strDesSpec

                For i = 1 To intCountRow - 1 Step 1
                    strFTPPath = ""
                    strDesSpec = ""
                    strFileName = ""
                    strFileExt = ""
                    intRowIndex = i
                    With objDataGridProcess
                        intColIndex(0) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ)
                        intColIndex(1) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_BDWJ)
                        intColIndex(2) = .getDataGridColumnIndex(Me.grdFJ, Josco.JSOA.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM)
                        strFTPPath = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(0))
                        strDesSpec = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(1))
                        strFileName = .getDataGridCellValue(Me.grdFJ.Items(intRowIndex), intColIndex(2))
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
                    strDesSpec_1 = strDesSpec_1 + " " + strDesSpec
                Next

                'ѹ������ļ�
                doCompressRAR(strDesSpec_1, strDesPath, strDesSpec_0)

                Dim strPoint As String = "."
                Dim intCount As Integer
                Dim strTemp() As String = strFileName.Split(strPoint.ToCharArray)
                'intCount = strTemp.Length
                strFileName = strTemp(0)
                strFileName = strFileName + ".rar"
                strDesSpec_0 = objBaseLocalFile.getFileName(strDesSpec_0)
                strUrl = Request.ApplicationPath + Me.m_cstrUrlBaseToFileCache + strDesSpec_0


                '��¼���������־
                If objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "�������ļ�[" + objsystemFlowObject.FlowData.WJBS + "]��ȫ��������") = False Then
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

        Private Sub lnkMLClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLClose.Click
            Me.doClose("lnkMLClose")
        End Sub

        Private Sub lnkMLSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLSelect.Click
            Me.doOpenFJ("lnkMLSelect")
        End Sub

        Private Sub lnkMLAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLAddNew.Click
            Me.doAddNewFJ("lnkMLAddNew")
        End Sub

        Private Sub lnkMLModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLModify.Click
            Me.doModifyFJ("lnkMLModify")
        End Sub

        Private Sub lnkMLDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLDelete.Click
            Me.doDeleteFJ("lnkMLDelete")
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
            Me.doExportFile("lnkMLExport")
        End Sub

        Private Sub lnkMLExportAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMLExportAll.Click
            Me.doExportFileAll("lnkMLExportAll")
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
                        Me.doOpenFJ("lnkMLSelect")


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
