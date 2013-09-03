Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_es_jyndjh_info
    ' 
    ' �������ʣ�
    '     I/O
    '
    ' ���������� 
    '   ����ȼƻ��༭����ģ��
    '----------------------------------------------------------------

    Partial Class estate_es_jyndjh_info
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton







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
        '��ӡģ�������Ӧ�ø���·��
        Private m_cstrExcelMBRelativePathToAppRoot As String = "/template/excel/"
        '��ӡ�ļ�����Ŀ¼�����Ӧ�ø���·��
        Private m_cstrPrintCacheRelativePathToAppRoot As String = "/temp/printcache/"

        '----------------------------------------------------------------
        'ģ����Ȩ����
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsJyndjhInfo
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsJyndjhInfo
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdNDJH��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_NDJH As String = "chkNDJH"
        Private Const m_cstrDataGridInDIV_NDJH As String = "divNDJH"
        Private m_intFixedColumns_NDJH As Integer
        Private Const m_cstrControlInDataGrid_NDJH_txtJH_JHDLF As String = "txtJH_JHDLF"
        Private Const m_cstrControlInDataGrid_NDJH_txtJH_JHHTE As String = "txtJH_JHHTE"
        Private Const m_cstrControlInDataGrid_NDJH_txtJH_JHZS As String = "txtJH_JHZS"
        Private Const m_cstrControlInDataGrid_NDJH_txtJH_JHTS As String = "txtJH_JHTS"
        Private Const m_cstrControlInDataGrid_NDJH_txtJH_JHMJ As String = "txtJH_JHMJ"

        '----------------------------------------------------------------
        '��ǰ��������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet_NDJH As Josco.JSOA.Common.Data.estateErshouData
        Private m_strQuery_NDJH As String
        Private m_intRows_NDJH As Integer

        '----------------------------------------------------------------
        '����ģ��˽�ò���
        '----------------------------------------------------------------
        Private m_objEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType
        Private m_blnEditMode As Boolean
        Private m_blnEnforced As Boolean
        Private m_intJHND As Integer










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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsJyndjhInfo)
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
                    Me.htxtDivLeftNDJH.Value = .htxtDivLeftNDJH
                    Me.htxtDivTopNDJH.Value = .htxtDivTopNDJH

                    Me.htxtNDJHQuery.Value = .htxtNDJHQuery
                    Me.htxtNDJHRows.Value = .htxtNDJHRows
                    Me.htxtNDJHSort.Value = .htxtNDJHSort
                    Me.htxtNDJHSortColumnIndex.Value = .htxtNDJHSortColumnIndex
                    Me.htxtNDJHSortType.Value = .htxtNDJHSortType

                    Me.txtNDJHPageIndex.Text = .txtNDJHPageIndex
                    Me.txtNDJHPageSize.Text = .txtNDJHPageSize

                    Try
                        Me.grdNDJH.PageSize = .grdNDJHPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdNDJH.CurrentPageIndex = .grdNDJHCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdNDJH.SelectedIndex = .grdNDJHSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery
                    Me.htxtSessionIdBuffer.Value = .htxtSessionIdBuffer
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsJyndjhInfo

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftNDJH = Me.htxtDivLeftNDJH.Value
                    .htxtDivTopNDJH = Me.htxtDivTopNDJH.Value

                    .htxtNDJHQuery = Me.htxtNDJHQuery.Value
                    .htxtNDJHRows = Me.htxtNDJHRows.Value
                    .htxtNDJHSort = Me.htxtNDJHSort.Value
                    .htxtNDJHSortColumnIndex = Me.htxtNDJHSortColumnIndex.Value
                    .htxtNDJHSortType = Me.htxtNDJHSortType.Value

                    .txtNDJHPageIndex = Me.txtNDJHPageIndex.Text
                    .txtNDJHPageSize = Me.txtNDJHPageSize.Text

                    .grdNDJHPageSize = Me.grdNDJH.PageSize
                    .grdNDJHCurrentPageIndex = Me.grdNDJH.CurrentPageIndex
                    .grdNDJHSelectedIndex = Me.grdNDJH.SelectedIndex
                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value
                    .htxtSessionIdBuffer = Me.htxtSessionIdBuffer.Value
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

            getDataFromCallModule = False

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
        ' ��ȡ�ӿڲ���
        '----------------------------------------------------------------
        Private Function getInterfaceParameters( _
            ByRef strErrMsg As String, _
            ByRef blnContinue As Boolean) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getInterfaceParameters = False
            blnContinue = True

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsJyndjhInfo)
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
                If Me.m_blnInterface = False Then
                    blnContinue = False
                    Me.lblMessage.Text = "���󣺱�ģ������ṩ�ӿڲ�����"
                    Me.panelError.Visible = True
                    Me.panelMain.Visible = Not Me.panelError.Visible
                    Exit Try
                End If
                '����ӿڲ���
                Me.m_intJHND = CType(Me.m_objInterface.iJHND, Integer)
                Me.m_objEditType = Me.m_objInterface.iMode
                Me.lblJHND.Text = Me.m_intJHND.ToString
                Me.m_blnEnforced = False
                Select Case Me.m_objEditType
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
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsJyndjhInfo)
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

                Me.m_intFixedColumns_NDJH = objPulicParameters.getObjectValue(Me.htxtNDJHFixed.Value, 0)
                Me.m_intRows_NDJH = objPulicParameters.getObjectValue(Me.htxtNDJHRows.Value, 0)
                Me.m_strQuery_NDJH = Me.htxtNDJHQuery.Value
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)

            getInterfaceParameters = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemCustomer.SafeRelease(objsystemCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ͷű�ģ�黺��Ĳ���
        '----------------------------------------------------------------
        Private Sub releaseModuleParameters()

            Try
                If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQuery.Value)
                End If

                If Me.htxtSessionIdBuffer.Value.Trim <> "" Then
                    Dim objBufferData As Josco.JSOA.Common.Data.estateErshouData
                    Try
                        objBufferData = CType(Session(Me.htxtSessionIdBuffer.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        objBufferData = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objBufferData)
                    Session.Remove(Me.htxtSessionIdBuffer.Value)
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub














        '----------------------------------------------------------------
        ' ��ȡgrdNDJHҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     intJHND        ���ƻ����
        '     blnEnforced    ��ǿ�����»�ȡ����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_NDJH( _
            ByRef strErrMsg As String, _
            ByVal intJHND As Integer, _
            ByVal blnEnforced As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_JYNDJH
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_NDJH = False

            Try
                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtNDJHSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                'ǿ�����»�ȡ����
                If blnEnforced = True Then
                    If Me.htxtSessionIdBuffer.Value.Trim <> "" Then
                        Try
                            Me.m_objDataSet_NDJH = CType(Session(Me.htxtSessionIdBuffer.Value), Josco.JSOA.Common.Data.estateErshouData)
                        Catch ex As Exception
                            Me.m_objDataSet_NDJH = Nothing
                        End Try
                        Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_NDJH)
                        Session.Remove(Me.htxtSessionIdBuffer.Value)
                        Me.htxtSessionIdBuffer.Value = ""
                    End If
                End If

                '��������
                If Me.htxtSessionIdBuffer.Value.Trim <> "" Then
                    '�ӻ����ȡ����
                    Try
                        Me.m_objDataSet_NDJH = CType(Session(Me.htxtSessionIdBuffer.Value), Josco.JSOA.Common.Data.estateErshouData)
                    Catch ex As Exception
                        Me.m_objDataSet_NDJH = Nothing
                    End Try
                Else
                    '���»�ȡ����
                    Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_NDJH)
                    If objsystemEstateErshou.getDataSet_ES_JYNDJH(strErrMsg, MyBase.UserId, MyBase.UserPassword, intJHND, Me.m_objDataSet_NDJH) = False Then
                        GoTo errProc
                    End If
                    '��������
                    Me.htxtSessionIdBuffer.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionIdBuffer.Value, Me.m_objDataSet_NDJH)
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_NDJH.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_NDJH.Tables(strTable)
                    Me.htxtNDJHRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_NDJH = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_NDJH = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdNDJH�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_NDJH( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_JYNDJH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_NDJH = False
            strErrMsg = ""

            Try
                '��ʾδ������
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdNDJH.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdNDJH.CurrentPageIndex, Me.grdNDJH.PageSize)
                    objDataRow = Me.m_objDataSet_NDJH.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���txtJH_JHDLF
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdNDJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_NDJH_txtJH_JHDLF), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHDLF), "", "#,##0.00", True)
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���txtJH_JHHTE
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdNDJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_NDJH_txtJH_JHHTE), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHHTE), "", "#,##0.00", True)
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���txtJH_JHZS
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdNDJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_NDJH_txtJH_JHZS), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHZS), "", "#,##0.00", True)
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���txtJH_JHTS
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdNDJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_NDJH_txtJH_JHTS), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHTS), "", "#,##0.00", True)
                        objTextBox.Text = strValue
                        objControlProcess.doEnabledControl(objTextBox, blnEditMode)
                    End If

                    '���txtJH_JHMJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdNDJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_NDJH_txtJH_JHMJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHMJ), "", "#,##0.00", True)
                        objTextBox.Text = strValue
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

            showDataGridUnboundInfo_NDJH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����grdNDJH�еķǰ����ݵ����ݼ�
        '     strErrMsg      �����ش�����Ϣ
        '     blnCheck       �����������Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_NDJH( _
            ByRef strErrMsg As String, _
            ByVal blnCheck As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_JYNDJH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_NDJH = False
            strErrMsg = ""

            Try
                '��ʾδ������
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdNDJH.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdNDJH.CurrentPageIndex, Me.grdNDJH.PageSize)
                    objDataRow = Me.m_objDataSet_NDJH.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���txtJH_JHDLF
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdNDJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_NDJH_txtJH_JHDLF), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            If objTextBox.Text.Trim = "" Then objTextBox.Text = "0"
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "����[" + objTextBox.Text + "]����Ч�����֣�"
                                GoTo errProc
                            End If
                        End If
                        If objPulicParameters.isFloatString(objTextBox.Text) = True Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHDLF) = CType(objTextBox.Text, Double)
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHDLF) = 0.0
                        End If
                    End If

                    '���txtJH_JHHTE
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdNDJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_NDJH_txtJH_JHHTE), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            If objTextBox.Text.Trim = "" Then objTextBox.Text = "0"
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "����[" + objTextBox.Text + "]����Ч�����֣�"
                                GoTo errProc
                            End If
                        End If
                        If objPulicParameters.isFloatString(objTextBox.Text) = True Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHHTE) = CType(objTextBox.Text, Double)
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHHTE) = 0.0
                        End If
                    End If

                    '���txtJH_JHZS
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdNDJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_NDJH_txtJH_JHZS), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            If objTextBox.Text.Trim = "" Then objTextBox.Text = "0"
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "����[" + objTextBox.Text + "]����Ч�����֣�"
                                GoTo errProc
                            End If
                        End If
                        If objPulicParameters.isFloatString(objTextBox.Text) = True Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHZS) = CType(objTextBox.Text, Double)
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHZS) = 0.0
                        End If
                    End If

                    '���txtJH_JHTS
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdNDJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_NDJH_txtJH_JHTS), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            If objTextBox.Text.Trim = "" Then objTextBox.Text = "0"
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "����[" + objTextBox.Text + "]����Ч�����֣�"
                                GoTo errProc
                            End If
                        End If
                        If objPulicParameters.isFloatString(objTextBox.Text) = True Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHTS) = CType(objTextBox.Text, Double)
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHTS) = 0.0
                        End If
                    End If

                    '���txtJH_JHMJ
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdNDJH.Items(i).FindControl(Me.m_cstrControlInDataGrid_NDJH_txtJH_JHMJ), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If blnCheck = True Then
                            If objTextBox.Text.Trim = "" Then objTextBox.Text = "0"
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "����[" + objTextBox.Text + "]����Ч�����֣�"
                                GoTo errProc
                            End If
                        End If
                        If objPulicParameters.isFloatString(objTextBox.Text) = True Then
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHMJ) = CType(objTextBox.Text, Double)
                        Else
                            objDataRow.Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_JYNDJH_JHMJ) = 0.0
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

            saveDataGridUnboundInfo_NDJH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdNDJH������
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_NDJH( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_JYNDJH
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_NDJH = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtNDJHSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtNDJHSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_NDJH Is Nothing Then
                    Me.grdNDJH.DataSource = Nothing
                Else
                    With Me.m_objDataSet_NDJH.Tables(strTable)
                        Me.grdNDJH.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_NDJH.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdNDJH, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdNDJH)
                    With Me.grdNDJH.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdNDJH.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                ''�ָ������е�CheckBox״̬
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdNDJH, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_NDJH) = False Then
                '    GoTo errProc
                'End If
                '��ʾδ�󶨵�������
                If Me.showDataGridUnboundInfo_NDJH(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_NDJH = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdNDJH���������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     blnEditMode    ���༭ģʽ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_NDJH( _
            ByRef strErrMsg As String, _
            ByVal blnEditMode As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_JYNDJH
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_NDJH = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_NDJH(strErrMsg, blnEditMode) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_NDJH.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblNDJHGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdNDJH, .Count)

                    '��ʾҳ���������
                    Me.lnkCZNDJHMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdNDJH, .Count)
                    Me.lnkCZNDJHMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdNDJH, .Count)
                    Me.lnkCZNDJHMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdNDJH, .Count)
                    Me.lnkCZNDJHMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdNDJH, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZNDJHDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZNDJHSelectAll.Enabled = blnEnabled
                    Me.lnkCZNDJHGotoPage.Enabled = blnEnabled
                    Me.lnkCZNDJHSetPageSize.Enabled = blnEnabled
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_NDJH = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾģ���ܿ���Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_MAIN( _
            ByRef strErrMsg As String) As Boolean

            showModuleData_MAIN = False

            Try
                Me.btnOK.Visible = Me.m_blnEditMode
                Me.btnCancel.Visible = Me.m_blnEditMode
                Me.btnClose.Visible = Not Me.m_blnEditMode
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
                Try
                    '��ʾPannel(�����Ƿ�ص���ʼ����ʾpanelMain)
                    Me.panelMain.Visible = True
                    Me.panelError.Visible = Not Me.panelMain.Visible

                    'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                    '********************************************************
                    objControlProcess.doTranslateKey(Me.txtNDJHPageIndex)
                    objControlProcess.doTranslateKey(Me.txtNDJHPageSize)
                    '********************************************************

                    If Me.getModuleData_NDJH(strErrMsg, Me.m_intJHND, Me.m_blnEnforced) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_NDJH(strErrMsg, Me.m_blnEditMode) = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_MAIN(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            Else
                '��ȡ��������
                If Me.getModuleData_NDJH(strErrMsg, Me.m_intJHND, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If
                '�Զ����滺������
                If Me.saveDataGridUnboundInfo_NDJH(strErrMsg, False) = False Then
                    GoTo errProc
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
            Dim strErrMsg As String
            Dim strUrl As String
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
        'ʵ�ֶ������С��еĹ̶�
        Sub grdNDJH_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdNDJH.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_NDJH + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_NDJH > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_NDJH - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdNDJH.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdNDJH_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdNDJH.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblNDJHGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdNDJH, Me.m_intRows_NDJH)
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

        Private Sub grdNDJH_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdNDJH.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_JYNDJH
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
                If Me.getModuleData_NDJH(strErrMsg, Me.m_intJHND, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                With Me.m_objDataSet_NDJH.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                With Me.m_objDataSet_NDJH.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtNDJHSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtNDJHSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtNDJHSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_NDJH(strErrMsg, Me.m_blnEditMode) = False Then
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














        Private Sub doMoveFirst(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_NDJH(strErrMsg, Me.m_intJHND, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdNDJH.PageCount)
                Me.grdNDJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NDJH(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doMoveLast(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_NDJH(strErrMsg, Me.m_intJHND, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdNDJH.PageCount - 1, Me.grdNDJH.PageCount)
                Me.grdNDJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NDJH(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doMoveNext(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_NDJH(strErrMsg, Me.m_intJHND, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdNDJH.CurrentPageIndex + 1, Me.grdNDJH.PageCount)
                Me.grdNDJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NDJH(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doMovePrevious(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_NDJH(strErrMsg, Me.m_intJHND, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdNDJH.CurrentPageIndex - 1, Me.grdNDJH.PageCount)
                Me.grdNDJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NDJH(strErrMsg, Me.m_blnEditMode) = False Then
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

        Private Sub doGotoPage(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtNDJHPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_NDJH(strErrMsg, Me.m_intJHND, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdNDJH.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_NDJH(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtNDJHPageIndex.Text = (Me.grdNDJH.CurrentPageIndex + 1).ToString()
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

        Private Sub doSetPageSize(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtNDJHPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_NDJH(strErrMsg, Me.m_intJHND, Me.m_blnEnforced) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdNDJH.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_NDJH(strErrMsg, Me.m_blnEditMode) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtNDJHPageSize.Text = (Me.grdNDJH.PageSize).ToString()
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

        Private Sub doSelectAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdNDJH, 0, Me.m_cstrCheckBoxIdInDataGrid_NDJH, True) = False Then
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

        Private Sub doDeSelectAll(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdNDJH, 0, Me.m_cstrCheckBoxIdInDataGrid_NDJH, False) = False Then
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

        Private Sub lnkCZNDJHMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHMoveFirst.Click
            Me.doMoveFirst("lnkCZNDJHMoveFirst")
        End Sub

        Private Sub lnkCZNDJHMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHMoveLast.Click
            Me.doMoveLast("lnkCZNDJHMoveLast")
        End Sub

        Private Sub lnkCZNDJHMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHMoveNext.Click
            Me.doMoveNext("lnkCZNDJHMoveNext")
        End Sub

        Private Sub lnkCZNDJHMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHMovePrev.Click
            Me.doMovePrevious("lnkCZNDJHMovePrev")
        End Sub

        Private Sub lnkCZNDJHGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHGotoPage.Click
            Me.doGotoPage("lnkCZNDJHGotoPage")
        End Sub

        Private Sub lnkCZNDJHSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHSetPageSize.Click
            Me.doSetPageSize("lnkCZNDJHSetPageSize")
        End Sub

        Private Sub lnkCZNDJHSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHSelectAll.Click
            Me.doSelectAll("lnkCZNDJHSelectAll")
        End Sub

        Private Sub lnkCZNDJHDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZNDJHDeSelectAll.Click
            Me.doDeSelectAll("lnkCZNDJHDeSelectAll")
        End Sub











        '----------------------------------------------------------------
        'ģ���������������
        '----------------------------------------------------------------
        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strSessionId As String
                Dim strUrl As String
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

        Private Sub doOK(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.saveDataGridUnboundInfo_NDJH(strErrMsg, True) = False Then
                    GoTo errProc
                End If

                '����
                If objsystemEstateErshou.doSaveData_ES_JYNDJH(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_intJHND, Me.m_objDataSet_NDJH, Me.m_objEditType) = False Then
                    GoTo errProc
                End If

                '��¼�����־
                Select Case Me.m_objEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_��ȼƻ�]��[����]��[" + Me.m_intJHND.ToString + "]��ȵļƻ���")
                    Case Else
                        Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[����_��ȼƻ�]��[����]��[" + Me.m_intJHND.ToString + "]��ȵļƻ���")
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
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.doCancel("btnCancel")
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.doOK("btnOK")
        End Sub

    End Class

End Namespace
