Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_rs_yongjinjitibiaozhun_X2
    ' 
    ' �������ʣ�
    '     ��������
    '
    ' ���������� 
    '   ����Ӷ������׼X2������ģ��
    '----------------------------------------------------------------

    Partial Class estate_rs_yongjinjitibiaozhun_X2
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Protected WithEvents lnkBlank As System.Web.UI.WebControls.LinkButton
        '--------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------
        '--------------------------------------------------------------------------------------
        Protected WithEvents btnSelAll_GYXG As System.Web.UI.WebControls.Button
        Protected WithEvents btnDeSelAll_GYXG As System.Web.UI.WebControls.Button
        Protected WithEvents btnAddNew_GYXG As System.Web.UI.WebControls.Button
        Protected WithEvents btnDelete_GYXG As System.Web.UI.WebControls.Button
        '--------------------------------------------------------------------------------------


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
        Private m_cstrPrevilegeParamPrefix As String = "estate_rs_yongjinjitibiaozhun_previlege_param"
        Private m_blnPrevilegeParams(2) As Boolean

        '----------------------------------------------------------------
        'ģ���ֳ������������ָ���ɺ������ͷ�session��Դ
        '----------------------------------------------------------------
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsYongjinJitiBiaozhun_X2
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsYongjinJitiBiaozhun_X2
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdSYZB��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdSYZB As String = "chkSYZB"
        Private Const m_cstrDataGridInDIV_grdSYZB As String = "divSYZB"
        Private m_intFixedColumns_grdSYZB As Integer
        Private Const m_cstrtxtQJZXDataGrid_grdSYZB As String = "txtQJZX"
        Private Const m_cstrtxtQJZDDataGrid_grdSYZB As String = "txtQJZD"
        Private Const m_cstrtxtEDZXDataGrid_grdSYZB As String = "txtEDZX"
        Private Const m_cstrtxtEDZDDataGrid_grdSYZB As String = "txtEDZD"
        Private Const m_cstrtxtJTBLDataGrid_grdSYZB As String = "txtJTBL"

        '----------------------------------------------------------------
        '����������grdGYZG��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdGYZG As String = "chkGYZG"
        Private Const m_cstrDataGridInDIV_grdGYZG As String = "divGYZG"
        Private m_intFixedColumns_grdGYZG As Integer

        '----------------------------------------------------------------
        '����������grdGYZGZB��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdGYZGZB As String = "chkGYZGZB"
        Private Const m_cstrDataGridInDIV_grdGYZGZB As String = "divGYZGZB"
        Private m_intFixedColumns_grdGYZGZB As Integer
        Private Const m_cstrtxtZGQJZXDataGrid_grdGYZGZB As String = "txtZGQJZX"
        Private Const m_cstrtxtZGQJZDDataGrid_grdGYZGZB As String = "txtZGQJZD"
        Private Const m_cstrtxtZGZXRWBLDataGrid_grdGYZGZB As String = "txtZGZXRWBL"
        Private Const m_cstrtxtZGZDRWBLDataGrid_grdGYZGZB As String = "txtZGZDRWBL"
        Private Const m_cstrtxtZGJTBLDataGrid_grdGYZGZB As String = "txtZGJTBL"

        '----------------------------------------------------------------
        '����������grdGYZGZB��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdGYXGZB As String = "chkGYXGZB"
        Private Const m_cstrDataGridInDIV_grdGYXGZB As String = "divGYXGZB"
        Private m_intFixedColumns_grdGYXGZB As Integer
        Private Const m_cstrtxtXGQJZXDataGrid_grdGYXGZB As String = "txtXGQJZX"
        Private Const m_cstrtxtXGQJZDDataGrid_grdGYXGZB As String = "txtXGQJZD"
        Private Const m_cstrtxtXGJTBLDataGrid_grdGYXGZB As String = "txtXGJTBL"

        '----------------------------------------------------------------
        '����������grdGYZT��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_grdGYZT As String = "chkGYZTZB"
        Private Const m_cstrDataGridInDIV_grdGYZT As String = "divGYZT"
        Private m_intFixedColumns_grdGYZT As Integer
        Private Const m_cstrtxtZTJTBLDataGrid_grdGYZT As String = "txtZTJTBL"

        '----------------------------------------------------------------
        '��ǰ��������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet_SYZB As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_GYZG As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_GYZGZB As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_GYXGZB As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_objDataSet_GYZT As Josco.JSOA.Common.Data.estateRenshiXingyeData

        '----------------------------------------------------------------
        'ģ����������
        '----------------------------------------------------------------
        Private m_blnReadOnly As Boolean

        'propFunctionId
        '=1  ����˽Ӷ��׼
        '=2  ����ֱ�ܹ�Ӷ
        '=3  ����Э�ܹ�Ӷ
        '=4  ����ֱ�ṫӶ
        Public ReadOnly Property propFunctionId() As Integer
            Get
                Try
                    propFunctionId = CType(Me.htxtFunctionId.Value, Integer)
                Catch ex As Exception
                    propFunctionId = 1
                End Try
            End Get
        End Property








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
                    Me.htxtFunctionId.Value = .htxtFunctionId
                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody

                    Me.htxtSessionId_SY.Value = .htxtSessionId_SY
                    Me.htxtSessionId_GYZG.Value = .htxtSessionId_GYZG
                    Me.htxtSessionId_GYZGZB.Value = .htxtSessionId_GYZGZB
                    Me.htxtSessionId_GYXGZB.Value = .htxtSessionId_GYXGZB
                    Me.htxtSessionId_GYZT.Value = .htxtSessionId_GYZT

                    Try
                        Me.grdSYZB.PageSize = .grdSYZB_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSYZB.CurrentPageIndex = .grdSYZB_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdSYZB.SelectedIndex = .grdSYZB_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdGYZG.PageSize = .grdGYZG_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYZG.CurrentPageIndex = .grdGYZG_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYZG.SelectedIndex = .grdGYZG_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdGYZGZB.PageSize = .grdGYZGZB_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYZGZB.CurrentPageIndex = .grdGYZGZB_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYZGZB.SelectedIndex = .grdGYZGZB_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdGYXGZB.PageSize = .grdGYXGZB_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYXGZB.CurrentPageIndex = .grdGYXGZB_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYXGZB.SelectedIndex = .grdGYXGZB_SelectedIndex
                    Catch ex As Exception
                    End Try

                    Try
                        Me.grdGYZT.PageSize = .grdGYZT_PageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYZT.CurrentPageIndex = .grdGYZT_CurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdGYZT.SelectedIndex = .grdGYZT_SelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsYongjinJitiBiaozhun_X2

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtFunctionId = Me.htxtFunctionId.Value
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value

                    .htxtSessionId_SY = Me.htxtSessionId_SY.Value
                    .htxtSessionId_GYZG = Me.htxtSessionId_GYZG.Value
                    .htxtSessionId_GYZGZB = Me.htxtSessionId_GYZGZB.Value
                    .htxtSessionId_GYXGZB = Me.htxtSessionId_GYXGZB.Value
                    .htxtSessionId_GYZT = Me.htxtSessionId_GYZT.Value

                    .grdSYZB_PageSize = Me.grdSYZB.PageSize
                    .grdSYZB_CurrentPageIndex = Me.grdSYZB.CurrentPageIndex
                    .grdSYZB_SelectedIndex = Me.grdSYZB.SelectedIndex

                    .grdGYZG_PageSize = Me.grdGYZG.PageSize
                    .grdGYZG_CurrentPageIndex = Me.grdGYZG.CurrentPageIndex
                    .grdGYZG_SelectedIndex = Me.grdGYZG.SelectedIndex

                    .grdGYZGZB_PageSize = Me.grdGYZGZB.PageSize
                    .grdGYZGZB_CurrentPageIndex = Me.grdGYZGZB.CurrentPageIndex
                    .grdGYZGZB_SelectedIndex = Me.grdGYZGZB.SelectedIndex

                    .grdGYXGZB_PageSize = Me.grdGYXGZB.PageSize
                    .grdGYXGZB_CurrentPageIndex = Me.grdGYXGZB.CurrentPageIndex
                    .grdGYXGZB_SelectedIndex = Me.grdGYXGZB.SelectedIndex

                    .grdGYZT_PageSize = Me.grdGYZT.PageSize
                    .grdGYZT_CurrentPageIndex = Me.grdGYZT.CurrentPageIndex
                    .grdGYZT_SelectedIndex = Me.grdGYZT.SelectedIndex
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
                            Case "btnAddNew_GYZG".ToUpper()
                                If Me.getModuleData_GYZG(strErrMsg) = True Then
                                    If Me.isExisted_GYZG(strErrMsg, objIDmxzJbdm.oCodeValue, Me.m_objDataSet_GYZG, blnExisted) = True Then
                                        If blnExisted = False Then
                                            strTable = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ
                                            With Me.m_objDataSet_GYZG.Tables(strTable)
                                                objDataRow = .NewRow()
                                            End With
                                            With objIDmxzJbdm
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ_ZJDM) = .oCodeValue
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ_ZJMC) = .oNameValue
                                            End With
                                            With Me.m_objDataSet_GYZG.Tables(strTable)
                                                .Rows.Add(objDataRow)
                                            End With
                                        End If
                                    End If
                                End If

                            Case "btnAddNew_GYZT".ToUpper()
                                If Me.getModuleData_GYZT(strErrMsg) = True Then
                                    If Me.isExisted_GYZT(strErrMsg, objIDmxzJbdm.oCodeValue, Me.m_objDataSet_GYZT, blnExisted) = True Then
                                        If blnExisted = False Then
                                            strTable = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT
                                            With Me.m_objDataSet_GYZT.Tables(strTable)
                                                objDataRow = .NewRow()
                                            End With
                                            With objIDmxzJbdm
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_ZJDM) = .oCodeValue
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_ZJMC) = .oNameValue
                                                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_JTBL) = 0.0
                                            End With
                                            With Me.m_objDataSet_GYZT.Tables(strTable)
                                                .Rows.Add(objDataRow)
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
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getDataFromCallModule = True
            Exit Function
errProc:
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsYongjinJitiBiaozhun_X2)
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
                    Dim strSessionId As String = ""
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsYongjinJitiBiaozhun_X2)
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

                Me.m_intFixedColumns_grdSYZB = objPulicParameters.getObjectValue(Me.htxtSYZBFixed.Value, 0)
                Me.m_intFixedColumns_grdGYZG = objPulicParameters.getObjectValue(Me.htxtGYZGFixed.Value, 0)
                Me.m_intFixedColumns_grdGYZGZB = objPulicParameters.getObjectValue(Me.htxtGYZGZBFixed.Value, 0)
                Me.m_intFixedColumns_grdGYXGZB = objPulicParameters.getObjectValue(Me.htxtGYXGZBFixed.Value, 0)
                Me.m_intFixedColumns_grdGYZG = objPulicParameters.getObjectValue(Me.htxtGYZTFixed.Value, 0)
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

                If Me.htxtSessionId_SY.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_SY.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_SY.Value)
                    Me.htxtSessionId_SY.Value = ""
                End If

                If Me.htxtSessionId_GYZGZB.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_GYZGZB.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_GYZGZB.Value)
                    Me.htxtSessionId_GYZGZB.Value = ""
                End If

                If Me.htxtSessionId_GYZG.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_GYZG.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_GYZG.Value)
                    Me.htxtSessionId_GYZG.Value = ""
                End If

                If Me.htxtSessionId_GYXGZB.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_GYXGZB.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_GYXGZB.Value)
                    Me.htxtSessionId_GYXGZB.Value = ""
                End If

                If Me.htxtSessionId_GYZT.Value.Trim <> "" Then
                    Try
                        objDataSet = CType(Session(Me.htxtSessionId_GYZT.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    Catch ex As Exception
                        objDataSet = Nothing
                    End Try
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objDataSet)
                    Session.Remove(Me.htxtSessionId_GYZT.Value)
                    Me.htxtSessionId_GYZT.Value = ""
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub









        '----------------------------------------------------------------
        ' ��ȡgrdSYZBҪ��ʾ������ - ˽Ӷ��������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_SY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_SY = False

            Try
                If Me.htxtSessionId_SY.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_SYZB = CType(Session.Item(Me.htxtSessionId_SY.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_SYZB)

                    '���¼�������
                    If objsystemEstateRenshiXingye.getDataSet_Yjjtbz_SY(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_SYZB) = False Then
                        GoTo errProc
                    End If

                    '��������
                    Me.htxtSessionId_SY.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_SY.Value, Me.m_objDataSet_SYZB)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_SY = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdGYZGҪ��ʾ������ - ��Ӷֱ�ܼ�������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_GYZG(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_GYZG = False

            Try
                If Me.htxtSessionId_GYZG.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_GYZG = CType(Session.Item(Me.htxtSessionId_GYZG.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_GYZG)

                    '���¼�������
                    If objsystemEstateRenshiXingye.getDataSet_Yjjtbz_GYZG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_GYZG) = False Then
                        GoTo errProc
                    End If

                    '��������
                    Me.htxtSessionId_GYZG.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_GYZG.Value, Me.m_objDataSet_GYZG)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_GYZG = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdGYZGZBҪ��ʾ������ - ��Ӷֱ��ָ���������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_GYZGZB(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objDataRow As System.Data.DataRow = Nothing
            Dim intColIndex As Integer
            Dim intCount_2 As Integer
            Dim intCount As Integer
            Dim strWhere As String = ""
            Dim strZJDM As String = ""

            getModuleData_GYZGZB = False

            Try
                If Me.htxtSessionId_GYZGZB.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_GYZGZB = CType(Session.Item(Me.htxtSessionId_GYZGZB.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_GYZGZB)
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZG, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ_ZJDM)
                    strZJDM = objDataGridProcess.getDataGridCellValue(Me.grdGYZG.Items(Me.grdGYZG.SelectedIndex), intColIndex)
                    strWhere = " where ְ������ = '" + strZJDM + "'"
                    '���¼�������
                    If objsystemEstateRenshiXingye.getDataSet_Yjjtbz_GYZGZB(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_GYZGZB, strWhere) = False Then
                        GoTo errProc
                    End If
                    Me.htxtSessionId_GYZGZB.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_GYZGZB.Value, Me.m_objDataSet_GYZGZB)
                End If

                '��������
                With Me.m_objDataSet_GYZGZB.Tables(strTable)
                    intCount = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getModuleData_GYZGZB = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdGYXGZBҪ��ʾ������ - ��ӶЭ�ܼ�������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_GYXGZB(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_GYXGZB = False

            Try
                If Me.htxtSessionId_GYXGZB.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_GYXGZB = CType(Session.Item(Me.htxtSessionId_GYXGZB.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_GYXGZB)

                    '���¼�������
                    If objsystemEstateRenshiXingye.getDataSet_Yjjtbz_GYXGZB(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_GYXGZB) = False Then
                        GoTo errProc
                    End If

                    '��������
                    Me.htxtSessionId_GYXGZB.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_GYXGZB.Value, Me.m_objDataSet_GYXGZB)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_GYXGZB = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdGYZTҪ��ʾ������ - ��Ӷֱ���������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_GYZT(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getModuleData_GYZT = False

            Try
                If Me.htxtSessionId_GYZT.Value.Trim <> "" Then
                    '�ӻ����л�ȡ����
                    Me.m_objDataSet_GYZT = CType(Session.Item(Me.htxtSessionId_GYZT.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                Else
                    '�ͷ���Դ
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_GYZT)

                    '���¼�������
                    If objsystemEstateRenshiXingye.getDataSet_Yjjtbz_GYZT(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_GYZT) = False Then
                        GoTo errProc
                    End If

                    '��������
                    Me.htxtSessionId_GYZT.Value = objPulicParameters.getNewGuid()
                    Session.Add(Me.htxtSessionId_GYZT.Value, Me.m_objDataSet_GYZT)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getModuleData_GYZT = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function







        '----------------------------------------------------------------
        ' ����grdSYZB�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnValid       ��true-ִ����Ч�Լ��,false-��ִ��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_SY(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_SY = False
            strErrMsg = ""

            Try
                '����δ������
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdSYZB.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdSYZB.CurrentPageIndex, Me.grdSYZB.PageSize)
                    objDataRow = Me.m_objDataSet_SYZB.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '����BLJT
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtJTBLDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�������]����Ч��ֵ��"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�������]����>=0��"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_JTBL) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '����QJZX
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtQJZXDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[������С]����Ч��ֵ��"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[������С]����>=0��"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_QJZX) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '����QJZD
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtQJZDDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�������]����Ч��ֵ��"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�������]����>=0��"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_QJZD) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '����EDZX
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtEDZXDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[��С���]����Ч��ֵ��"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[��С���]����>=0��"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_ZXED) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '����EDZD
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtEDZDDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�����]����Ч��ֵ��"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�����]����>=0��"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_ZDED) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_SY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdSYZB�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_SY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_SY = False
            strErrMsg = ""

            Try
                '��ʾδ������
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdSYZB.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdSYZB.CurrentPageIndex, Me.grdSYZB.PageSize)
                    objDataRow = Me.m_objDataSet_SYZB.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���JTBL
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtJTBLDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_JTBL), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '���qjzx
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtQJZXDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_QJZX), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '���QJZD
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtQJZDDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_QJZD), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '���EDZX
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtEDZXDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_ZXED), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '���EDZD
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdSYZB.Items(i).FindControl(Me.m_cstrtxtEDZDDataGrid_grdSYZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_ZDED), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
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

            showDataGridUnboundInfo_SY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdSYZB������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_SY(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_SY = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_SYZB Is Nothing Then
                    Me.grdSYZB.DataSource = Nothing
                Else
                    With Me.m_objDataSet_SYZB.Tables(strTable)
                        Me.grdSYZB.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_SYZB.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdSYZB, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdSYZB.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdSYZB, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdSYZB) = False Then
                    GoTo errProc
                End If
                '��ʾ����δ������
                If Me.showDataGridUnboundInfo_SY(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_SY = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function












        '----------------------------------------------------------------
        ' ����grdGYZG�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnValid       ��true-ִ����Ч�Լ��,false-��ִ��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_GYZG(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            saveDataGridUnboundInfo_GYZG = False
            strErrMsg = ""

            Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            saveDataGridUnboundInfo_GYZG = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdGYZG�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_GYZG(ByRef strErrMsg As String) As Boolean

            showDataGridUnboundInfo_GYZG = False
            strErrMsg = ""

            Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            showDataGridUnboundInfo_GYZG = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdGYZG������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_GYZG(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_GYZG = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_GYZG Is Nothing Then
                    Me.grdGYZG.DataSource = Nothing
                Else
                    With Me.m_objDataSet_GYZG.Tables(strTable)
                        Me.grdGYZG.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_GYZG.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdGYZG, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdGYZG.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdGYZG, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZG) = False Then
                    GoTo errProc
                End If
                '��ʾ����δ������
                If Me.showDataGridUnboundInfo_GYZG(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_GYZG = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function










        '----------------------------------------------------------------
        ' ����grdGYZGZB�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnValid       ��true-ִ����Ч�Լ��,false-��ִ��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_GYZGZB(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_GYZGZB = False
            strErrMsg = ""

            Try
                '����δ������
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGYZGZB.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGYZGZB.CurrentPageIndex, Me.grdGYZGZB.PageSize)
                    objDataRow = Me.m_objDataSet_GYZGZB.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '����QJZX
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZGZB.Items(i).FindControl(Me.m_cstrtxtZGQJZXDataGrid_grdGYZGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[����Сֵ]����Ч��ֵ��"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[����Сֵ]����>=0��"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_QJZX) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '����QJZD
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZGZB.Items(i).FindControl(Me.m_cstrtxtZGQJZDDataGrid_grdGYZGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�����ֵ]����Ч��ֵ��"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�����ֵ]����>=0��"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_QJZD) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '����ZXRWBL
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZGZB.Items(i).FindControl(Me.m_cstrtxtZGZXRWBLDataGrid_grdGYZGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[��С�������]����Ч��ֵ��"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[��С�������]����>=0��"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_ZXBL) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '����ZDRWBL
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZGZB.Items(i).FindControl(Me.m_cstrtxtZGZDRWBLDataGrid_grdGYZGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[����������]����Ч��ֵ��"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[����������]����>=0��"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_ZDBL) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '����JTBL
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZGZB.Items(i).FindControl(Me.m_cstrtxtZGJTBLDataGrid_grdGYZGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�������]����Ч��ֵ��"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�������]����>=0��"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_JTBL) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_GYZGZB = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdGYZGZB�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_GYZGZB(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_GYZGZB = False
            strErrMsg = ""

            Try
                '��ʾδ������
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGYZGZB.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGYZGZB.CurrentPageIndex, Me.grdGYZGZB.PageSize)
                    objDataRow = Me.m_objDataSet_GYZGZB.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���QJZX
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZGZB.Items(i).FindControl(Me.m_cstrtxtZGQJZXDataGrid_grdGYZGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_QJZX), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        If i = 0 Then
                            objControlProcess.doEnabledControl(objTextBox, False)
                        Else
                            objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                        End If
                    End If

                    '���QJZD
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZGZB.Items(i).FindControl(Me.m_cstrtxtZGQJZDDataGrid_grdGYZGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_QJZD), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '���ZXRWBL
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZGZB.Items(i).FindControl(Me.m_cstrtxtZGZXRWBLDataGrid_grdGYZGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_ZXBL), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        If i = 0 Then
                            objControlProcess.doEnabledControl(objTextBox, False)
                        Else
                            objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                        End If
                    End If

                    '���ZDRWBL
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZGZB.Items(i).FindControl(Me.m_cstrtxtZGZDRWBLDataGrid_grdGYZGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_ZDBL), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '���JTBL
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZGZB.Items(i).FindControl(Me.m_cstrtxtZGJTBLDataGrid_grdGYZGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_JTBL), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
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

            showDataGridUnboundInfo_GYZGZB = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdGYZGZB������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_GYZGZB(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_GYZGZB = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_GYZGZB Is Nothing Then
                    Me.grdGYZGZB.DataSource = Nothing
                Else
                    With Me.m_objDataSet_GYZGZB.Tables(strTable)
                        Me.grdGYZGZB.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_GYZGZB.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdGYZGZB, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdGYZGZB.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdGYZGZB, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZGZB) = False Then
                    GoTo errProc
                End If

                '��ʾ����δ������
                If Me.showDataGridUnboundInfo_GYZGZB(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_GYZGZB = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function














        '----------------------------------------------------------------
        ' ����grdGYXGZB�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnValid       ��true-ִ����Ч�Լ��,false-��ִ��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_GYXGZB(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_GYXGZB = False
            strErrMsg = ""

            Try
                '����δ������
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGYXGZB.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGYXGZB.CurrentPageIndex, Me.grdGYXGZB.PageSize)
                    objDataRow = Me.m_objDataSet_GYXGZB.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '����BLJT
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYXGZB.Items(i).FindControl(Me.m_cstrtxtXGJTBLDataGrid_grdGYXGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�������]����Ч��ֵ��"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�������]����>=0��"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_JTBL) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '����QJZX
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYXGZB.Items(i).FindControl(Me.m_cstrtxtXGQJZXDataGrid_grdGYXGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[������С]����Ч��ֵ��"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[������С]����>=0��"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_QJZX) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If

                    '����QJZD
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYXGZB.Items(i).FindControl(Me.m_cstrtxtXGQJZDDataGrid_grdGYXGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�������]����Ч��ֵ��"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�������]����>=0��"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_QJZD) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_GYXGZB = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdGYXGZB�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_GYXGZB(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_GYXGZB = False
            strErrMsg = ""

            Try
                '��ʾδ������
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGYXGZB.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGYXGZB.CurrentPageIndex, Me.grdGYXGZB.PageSize)
                    objDataRow = Me.m_objDataSet_GYXGZB.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���JTBL
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYXGZB.Items(i).FindControl(Me.m_cstrtxtXGJTBLDataGrid_grdGYXGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_JTBL), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '���qjzx
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYXGZB.Items(i).FindControl(Me.m_cstrtxtXGQJZXDataGrid_grdGYXGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_QJZX), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
                        objControlProcess.doEnabledControl(objTextBox, Not Me.m_blnReadOnly)
                    End If

                    '���QJZD
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYXGZB.Items(i).FindControl(Me.m_cstrtxtXGQJZDDataGrid_grdGYXGZB), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_QJZD), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
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

            showDataGridUnboundInfo_GYXGZB = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdGYXGZB������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_GYXGZB(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_GYXGZB = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_GYXGZB Is Nothing Then
                    Me.grdGYXGZB.DataSource = Nothing
                Else
                    With Me.m_objDataSet_GYXGZB.Tables(strTable)
                        Me.grdGYXGZB.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_GYXGZB.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdGYXGZB, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdGYXGZB.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdGYXGZB, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYXGZB) = False Then
                    GoTo errProc
                End If
                '��ʾ����δ������
                If Me.showDataGridUnboundInfo_GYXGZB(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_GYXGZB = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function












        '----------------------------------------------------------------
        ' ����grdGYZT�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        '     blnValid       ��true-ִ����Ч�Լ��,false-��ִ��
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function saveDataGridUnboundInfo_GYZT(ByRef strErrMsg As String, ByVal blnValid As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            saveDataGridUnboundInfo_GYZT = False
            strErrMsg = ""

            Try
                '����δ������
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGYZT.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGYZT.CurrentPageIndex, Me.grdGYZT.PageSize)
                    objDataRow = Me.m_objDataSet_GYZT.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '����JTBL
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZT.Items(i).FindControl(Me.m_cstrtxtZTJTBLDataGrid_grdGYZT), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        If objTextBox.Text.Trim <> "" And blnValid = True Then
                            If objPulicParameters.isFloatString(objTextBox.Text) = False Then
                                strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�������]����Ч��ֵ��"
                                GoTo errProc
                            Else
                                If CType(objTextBox.Text, Double) < 0 Then
                                    strErrMsg = "���󣺵�[" + (i + 1).ToString + "]�е�[�������]����>=0��"
                                    GoTo errProc
                                End If
                            End If
                        End If
                        If objTextBox.Text = "" Then
                            objTextBox.Text = "0"
                        End If
                        Try
                            objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_JTBL) = CType(objTextBox.Text, Double)
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            saveDataGridUnboundInfo_GYZT = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdGYZT�еķǰ�����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridUnboundInfo_GYZT(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showDataGridUnboundInfo_GYZT = False
            strErrMsg = ""

            Try
                '��ʾδ������
                Dim objTextBox As System.Web.UI.WebControls.TextBox = Nothing
                Dim objDataRow As System.Data.DataRow = Nothing
                Dim intRecPos As Integer = 0
                Dim strValue As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                intCount = Me.grdGYZT.Items.Count
                For i = 0 To intCount - 1 Step 1
                    '��ȡ��Ӧ������
                    intRecPos = objDataGridProcess.getRecordPosition(i, Me.grdGYZT.CurrentPageIndex, Me.grdGYZT.PageSize)
                    objDataRow = Me.m_objDataSet_GYZT.Tables(strTable).DefaultView.Item(intRecPos).Row

                    '���JTBL
                    objTextBox = Nothing
                    objTextBox = CType(Me.grdGYZT.Items(i).FindControl(Me.m_cstrtxtZTJTBLDataGrid_grdGYZT), System.Web.UI.WebControls.TextBox)
                    If Not (objTextBox Is Nothing) Then
                        objControlProcess.doTranslateKey(objTextBox)
                        strValue = objPulicParameters.getObjectValue(objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_JTBL), "")
                        If strValue = "" Then
                            objTextBox.Text = "0"
                        Else
                            objTextBox.Text = strValue
                        End If
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

            showDataGridUnboundInfo_GYZT = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdGYZT������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_GYZT(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_GYZT = False

            '������ʾ����
            Try
                '��������Դ
                If Me.m_objDataSet_GYZT Is Nothing Then
                    Me.grdGYZT.DataSource = Nothing
                Else
                    With Me.m_objDataSet_GYZT.Tables(strTable)
                        Me.grdGYZT.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_GYZT.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdGYZT, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdGYZT.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdGYZT, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZT) = False Then
                    GoTo errProc
                End If
                '��ʾ����δ������
                If Me.showDataGridUnboundInfo_GYZT(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_GYZT = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function










        Private Function showFunctionData(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            showFunctionData = False
            strErrMsg = ""

            Try
                Select Case Me.propFunctionId
                    Case 1 '"lnkSYBZ"
                        '��ʾgrdSY
                        If Me.getModuleData_SY(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.showDataGridInfo_SY(strErrMsg) = False Then
                            GoTo errProc
                        End If

                    Case 2 '"lnkZGGY"
                        '��ʾgrdGYZG
                        If Me.getModuleData_GYZG(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.showDataGridInfo_GYZG(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        '��ʾgrdGYZGZB
                        If Me.getModuleData_GYZGZB(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.showDataGridInfo_GYZGZB(strErrMsg) = False Then
                            GoTo errProc
                        End If

                    Case 3 '"lnkXGGY"
                        '��ʾgrdGYXGZB
                        If Me.getModuleData_GYXGZB(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.showDataGridInfo_GYXGZB(strErrMsg) = False Then
                            GoTo errProc
                        End If

                    Case 4 '"lnkZTGY"
                        '��ʾgrdGYZT
                        If Me.getModuleData_GYZT(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.showDataGridInfo_GYZT(strErrMsg) = False Then
                            GoTo errProc
                        End If
                    Case Else
                End Select
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            showFunctionData = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Function doSaveFunctionData(ByRef strErrMsg As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess

            doSaveFunctionData = False
            strErrMsg = ""

            Try
                Select Case Me.propFunctionId
                    Case 1 '"lnkSYBZ"
                        If Me.getModuleData_SY(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.saveDataGridUnboundInfo_SY(strErrMsg, False) = False Then
                            GoTo errProc
                        End If

                    Case 2 '"lnkZGGY"
                        If Me.getModuleData_GYZG(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.getModuleData_GYZGZB(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.saveDataGridUnboundInfo_GYZGZB(strErrMsg, False) = False Then
                            GoTo errProc
                        End If

                    Case 3 '"lnkXGGY"
                        If Me.getModuleData_GYXGZB(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.saveDataGridUnboundInfo_GYXGZB(strErrMsg, False) = False Then
                            GoTo errProc
                        End If

                    Case 4 '"lnkZTGY"
                        If Me.getModuleData_GYZT(strErrMsg) = False Then
                            GoTo errProc
                        End If
                        If Me.saveDataGridUnboundInfo_GYZT(strErrMsg, False) = False Then
                            GoTo errProc
                        End If
                    Case Else
                End Select
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            doSaveFunctionData = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
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
                Me.btnAddNew_GYZG.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_GYZG.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_GYZG.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_GYZG.Visible = Not Me.m_blnReadOnly

                Me.btnAddNew_GYZT.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_GYZT.Visible = Not Me.m_blnReadOnly
                Me.btnSelAll_GYZT.Visible = Not Me.m_blnReadOnly
                Me.btnDeSelAll_GYZT.Visible = Not Me.m_blnReadOnly

                Me.btnAddNew_SYZB.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_SYZB.Visible = Not Me.m_blnReadOnly

                Me.btnAddNew_GYZGZB.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_GYZGZB.Visible = Not Me.m_blnReadOnly

                Me.btnAddNew_GYXGZB.Visible = Not Me.m_blnReadOnly
                Me.btnDelete_GYXGZB.Visible = Not Me.m_blnReadOnly

                Me.btnSave_SYZB.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnSave_GYZG.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnSave_GYXG.Visible = Me.m_blnPrevilegeParams(1)
                Me.btnSave_GYZT.Visible = Me.m_blnPrevilegeParams(1)
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

                    '��ʾ����
                    If Me.showFunctionData(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    '���浱ǰ��������
                    If Me.doSaveFunctionData(strErrMsg) = False Then
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
        Sub grdSYZB_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdSYZB.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdSYZB + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdSYZB > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdSYZB - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdSYZB.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdGYZG_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdGYZG.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdGYZG + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdGYZG > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdGYZG - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdGYZG.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdGYZGZB_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdGYZGZB.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdGYZGZB + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdGYZGZB > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdGYZGZB - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdGYZGZB.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdGYXGZB_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdGYXGZB.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdGYXGZB + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdGYXGZB > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdGYXGZB - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdGYXGZB.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Sub grdGYZT_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdGYZT.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_grdGYZT + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_grdGYZT > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_grdGYZT - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdGYZT.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdGYZG_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGYZG.SelectedIndexChanged

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                'ǿ�����»�ȡ����
                If Me.htxtSessionId_GYZGZB.Value.Trim <> "" Then
                    If Me.getModuleData_GYZGZB(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_GYZGZB)
                    Session.Remove(Me.htxtSessionId_GYZGZB.Value)
                    Me.htxtSessionId_GYZGZB.Value = ""
                End If

                '��ʾ����
                If Me.getModuleData_GYZGZB(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showDataGridInfo_GYZGZB(strErrMsg) = False Then
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









        Private Sub doSelectAll_GYZG(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdGYZG, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZG, True) = False Then
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

        Private Sub doDeSelectAll_GYZG(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdGYZG, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZG, False) = False Then
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

        Private Sub doSelectAll_GYZT(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdGYZT, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZT, True) = False Then
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

        Private Sub doDeSelectAll_GYZT(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdGYZT, 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZT, False) = False Then
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







        Private Sub doDelete_SYZB(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                '���
                Dim i As Integer = 0
                If Me.grdSYZB.Items.Count < 1 Then
                    strErrMsg = "����û�����ݿ�ɾ����"
                    GoTo errProc
                End If

                'ѯ��
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷʵ׼��ɾ�����һ����������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��ʾ��ش��ǡ����Ŵ���
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '���ɾ��
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex(2) As Integer
                    Dim strName(2) As String
                    Dim intPos As Integer = 0
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdSYZB, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_QJZX)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdSYZB, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_QJZD)
                    i = Me.grdSYZB.Items.Count - 1
                    strName(0) = objDataGridProcess.getDataGridCellValue(Me.grdSYZB.Items(i), intColIndex(0))
                    strName(1) = objDataGridProcess.getDataGridCellValue(Me.grdSYZB.Items(i), intColIndex(1))

                    '��ȡҪɾ��������
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdSYZB.CurrentPageIndex, Me.grdSYZB.PageSize)
                    objOldData = Nothing
                    With Me.m_objDataSet_SYZB.Tables(strTable)
                        objOldData = .DefaultView.Item(intPos).Row
                    End With
                    'ɾ������
                    With Me.m_objDataSet_SYZB.Tables(strTable)
                        .Rows.Remove(objOldData)
                    End With

                    '��¼�����־
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[�ز�_B_����_Ӷ���׼_X2_˽Ӷ]��ɾ����[" + strName(0) + "]-[" + strName(1) + "]����(��û����)��")

                    'ˢ��������ʾ
                    If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doDelete_GYZG(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ
            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                intStep = 1
                '���ѡ��
                Dim intSelect As Integer = 0
                Dim intRows As Integer = 0
                Dim i As Integer = 0
                If Me.grdGYZG.SelectedIndex < 0 Then
                    strErrMsg = "����û��ְ����ɾ����"
                    GoTo errProc
                End If

                intStep = 2
                'ѯ��
                Dim objOldData As System.Data.DataRow = Nothing
                Dim intColIndex As Integer = 0
                Dim strZJDM As String = ""
                Dim strZJMC As String = ""
                Dim intPos As Integer = 0
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZG, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ_ZJMC)
                    strZJMC = objDataGridProcess.getDataGridCellValue(Me.grdGYZG.Items(Me.grdGYZG.SelectedIndex), intColIndex)
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷʵ׼��ɾ��[" + strZJMC + "]��������������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                intStep = 3
                '��ʾ��ش��ǡ����Ŵ���
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��������
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZG, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ_ZJDM)
                    strZJDM = objDataGridProcess.getDataGridCellValue(Me.grdGYZG.Items(Me.grdGYZG.SelectedIndex), intColIndex)

                    'ɾ������
                    If objsystemEstateRenshiXingye.doDelete_GYZG(strErrMsg, MyBase.UserId, MyBase.UserPassword, strZJDM) = False Then
                        GoTo errProc
                    End If

                    '��¼�����־
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[�ز�_B_����_Ӷ���׼_X2_��Ӷ_ֱ��]��ɾ����[" + strZJMC + "]ְ��(��û����)��")

                    'ǿ�����»�ȡ����
                    Me.releaseModuleParameters()

                    'ˢ��������ʾ
                    If Me.showFunctionData(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub
errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JSOA.BusinessFacade.systemEstateRenshiXingye.SafeRelease(objsystemEstateRenshiXingye)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        Private Sub doDelete_GYZGZB(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                '���
                Dim i As Integer = 0
                If Me.grdGYZGZB.Items.Count < 1 Then
                    strErrMsg = "����û�����ݿ�ɾ����"
                    GoTo errProc
                End If

                'ѯ��
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷʵ׼��ɾ�����һ����������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��ʾ��ش��ǡ����Ŵ���
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '���ɾ��
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex(2) As Integer
                    Dim strName(2) As String
                    Dim intPos As Integer = 0
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZGZB, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_QJZX)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZGZB, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_QJZD)
                    i = Me.grdGYZGZB.Items.Count - 1
                    strName(0) = objDataGridProcess.getDataGridCellValue(Me.grdGYZGZB.Items(i), intColIndex(0))
                    strName(1) = objDataGridProcess.getDataGridCellValue(Me.grdGYZGZB.Items(i), intColIndex(1))

                    '��ȡҪɾ��������
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdGYZGZB.CurrentPageIndex, Me.grdGYZGZB.PageSize)
                    objOldData = Nothing
                    Me.m_objDataSet_GYZGZB = CType(Session.Item(Me.htxtSessionId_GYZGZB.Value), Josco.JSOA.Common.Data.estateRenshiXingyeData)
                    With Me.m_objDataSet_GYZGZB.Tables(strTable)
                        objOldData = .DefaultView.Item(intPos).Row
                    End With
                    'ɾ������
                    With Me.m_objDataSet_GYZGZB.Tables(strTable)
                        .Rows.Remove(objOldData)
                    End With

                    '��¼�����־
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[�ز�_B_����_Ӷ���׼_X2_��Ӷ_ֱ��]��ɾ����[" + strName(0) + "]-[" + strName(1) + "]����(��û����)��")

                    'ˢ��������ʾ
                    If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doDelete_GYXGZB(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                '���
                Dim i As Integer = 0
                If Me.grdGYXGZB.Items.Count < 1 Then
                    strErrMsg = "����û�����ݿ�ɾ����"
                    GoTo errProc
                End If

                'ѯ��
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷʵ׼��ɾ�����һ����������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                '��ʾ��ش��ǡ����Ŵ���
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '���ɾ��
                    Dim objOldData As System.Data.DataRow = Nothing
                    Dim intColIndex(2) As Integer
                    Dim strName(2) As String
                    Dim intPos As Integer = 0
                    intColIndex(0) = objDataGridProcess.getDataGridColumnIndex(Me.grdGYXGZB, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_QJZX)
                    intColIndex(1) = objDataGridProcess.getDataGridColumnIndex(Me.grdGYXGZB, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_QJZD)
                    i = Me.grdGYXGZB.Items.Count - 1
                    strName(0) = objDataGridProcess.getDataGridCellValue(Me.grdGYXGZB.Items(i), intColIndex(0))
                    strName(1) = objDataGridProcess.getDataGridCellValue(Me.grdGYXGZB.Items(i), intColIndex(1))

                    '��ȡҪɾ��������
                    intPos = objDataGridProcess.getRecordPosition(i, Me.grdGYXGZB.CurrentPageIndex, Me.grdGYXGZB.PageSize)
                    objOldData = Nothing
                    With Me.m_objDataSet_GYXGZB.Tables(strTable)
                        objOldData = .DefaultView.Item(intPos).Row
                    End With
                    'ɾ������
                    With Me.m_objDataSet_GYXGZB.Tables(strTable)
                        .Rows.Remove(objOldData)
                    End With

                    '��¼�����־
                    Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[�ز�_B_����_Ӷ���׼_X2_��Ӷ_Э��]��ɾ����[" + strName(0) + "]-[" + strName(1) + "]����(��û����)��")

                    'ˢ��������ʾ
                    If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doDelete_GYZT(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                intStep = 1
                '���ѡ��
                Dim intSelect As Integer = 0
                Dim intRows As Integer = 0
                Dim i As Integer = 0
                intRows = Me.grdGYZT.Items.Count
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    For i = 0 To intRows - 1 Step 1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdGYZT.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZT) = True Then
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
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZT, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_ZJMC)
                    For i = intRows - 1 To 0 Step -1
                        If objDataGridProcess.isDataGridItemChecked(Me.grdGYZT.Items(i), 0, Me.m_cstrCheckBoxIdInDataGrid_grdGYZT) = True Then
                            strName = objDataGridProcess.getDataGridCellValue(Me.grdGYZT.Items(i), intColIndex)

                            '��ȡҪɾ��������
                            intPos = objDataGridProcess.getRecordPosition(i, Me.grdGYZT.CurrentPageIndex, Me.grdGYZT.PageSize)
                            objOldData = Nothing
                            With Me.m_objDataSet_GYZT.Tables(strTable)
                                objOldData = .DefaultView.Item(intPos).Row
                            End With
                            'ɾ������
                            With Me.m_objDataSet_GYZT.Tables(strTable)
                                .Rows.Remove(objOldData)
                            End With

                            '��¼�����־
                            Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]��[�ز�_B_����_Ӷ���׼_X2_��Ӷ_ֱ��]��ɾ����[" + strName + "]ְ��(��û����)��")
                        End If
                    Next

                    'ˢ��������ʾ
                    If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doAddNew_SYZB(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '��������
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_SYZB.Tables(strTable)
                    objDataRow = .NewRow()
                End With

                '����ʼֵ
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_JTBL) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_QJZX) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_QJZD) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_ZXED) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_ZDED) = 0.0

                '��������
                With Me.m_objDataSet_SYZB.Tables(strTable)
                    .Rows.Add(objDataRow)
                End With

                'ˢ��������ʾ
                If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doAddNew_GYZG(ByVal strControlId As String)

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

        Private Sub doAddNew_GYZGZB(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '��������
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_GYZGZB.Tables(strTable)
                    objDataRow = .NewRow()
                End With

                '����ʼֵ
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_JTBL) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_QJZX) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_QJZD) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_ZXBL) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_ZDBL) = 0.0

                '��������
                With Me.m_objDataSet_GYZGZB.Tables(strTable)
                    .Rows.Add(objDataRow)
                End With

                'ˢ��������ʾ
                If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doAddNew_GYXGZB(ByVal strControlId As String)

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '��������
                Dim objDataRow As System.Data.DataRow = Nothing
                With Me.m_objDataSet_GYXGZB.Tables(strTable)
                    objDataRow = .NewRow()
                End With

                '����ʼֵ
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_JTBL) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_QJZX) = 0.0
                objDataRow.Item(Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_QJZD) = 0.0

                '��������
                With Me.m_objDataSet_GYXGZB.Tables(strTable)
                    .Rows.Add(objDataRow)
                End With

                'ˢ��������ʾ
                If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doAddNew_GYZT(ByVal strControlId As String)

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

        Private Function isExisted_GYZG( _
           ByRef strErrMsg As String, _
           ByVal strZJDM As String, _
           ByVal objDataSet_GYZG As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
           ByRef blnExisted As Boolean) As Boolean

            isExisted_GYZG = False
            strErrMsg = ""
            blnExisted = True

            Try
                '���
                If strZJDM Is Nothing Then strZJDM = ""
                strZJDM = strZJDM.Trim
                If objDataSet_GYZG Is Nothing Then
                    Exit Try
                End If
                If strZJDM = "" Then
                    Exit Try
                End If

                '����
                Dim strOldFilter As String = ""
                Dim strNewFilter As String = ""
                With objDataSet_GYZG.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ)
                    '����
                    strOldFilter = .DefaultView.RowFilter

                    '������
                    strNewFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ_ZJDM + " = '" + strZJDM + "'"
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

            isExisted_GYZG = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Function isExisted_GYZT( _
            ByRef strErrMsg As String, _
            ByVal strZJDM As String, _
            ByVal objDataSet_GYZT As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef blnExisted As Boolean) As Boolean

            isExisted_GYZT = False
            strErrMsg = ""
            blnExisted = True

            Try
                '���
                If strZJDM Is Nothing Then strZJDM = ""
                strZJDM = strZJDM.Trim
                If objDataSet_GYZT Is Nothing Then
                    Exit Try
                End If
                If strZJDM = "" Then
                    Exit Try
                End If

                '����
                Dim strOldFilter As String = ""
                Dim strNewFilter As String = ""
                With objDataSet_GYZT.Tables(Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT)
                    '����
                    strOldFilter = .DefaultView.RowFilter

                    '������
                    strNewFilter = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_ZJDM + " = '" + strZJDM + "'"
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

            isExisted_GYZT = True
            Exit Function
errProc:
            Exit Function

        End Function

        Private Function isQujianValid(ByRef strErrMsg As String) As Boolean

            Dim strFieldZX As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_QJZX
            Dim strFieldZD As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_QJZD
            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            isQujianValid = False
            strErrMsg = ""

            Try
                Dim dblValue(2) As Double
                Dim intCount As Integer = 0
                Dim i As Integer = 0

                '�����Сֵ�Ƿ�����Ҫ��?
                dblValue(1) = 0
                With Me.m_objDataSet_SYZB.Tables(strTable).DefaultView
                    intCount = .Count
                    For i = 0 To intCount - 1 Step 1

                        '������С
                        dblValue(0) = objPulicParameters.getObjectValue(.Item(i).Item(strFieldZX), 0.0)
                        If i > 0 Then
                            If dblValue(0) <= dblValue(1) + 1 Then
                                strErrMsg = "�������䲻�ǰ�����С����˳�����룡"
                                GoTo errProc
                            End If
                        End If
                        '����
                        dblValue(1) = dblValue(0)
                    Next
                End With

                '�Զ��������ֵ = ��һ�е���Сֵ - 1
                With Me.m_objDataSet_SYZB.Tables(strTable).DefaultView
                    intCount = .Count
                    For i = intCount - 1 To 0 Step -1
                        '������С
                        dblValue(0) = objPulicParameters.getObjectValue(.Item(i).Item(strFieldZX), 0.0)
                        '������� = ������С - 1
                        If i - 1 >= 0 Then
                            .Item(i - 1).Item(strFieldZD) = dblValue(0) - 1
                        End If
                    Next
                End With

                '���һ�е����ֵ=0
                With Me.m_objDataSet_SYZB.Tables(strTable).DefaultView
                    intCount = .Count
                    If intCount > 0 Then
                        .Item(intCount - 1).Item(strFieldZD) = 0.0
                    End If
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            isQujianValid = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        Private Sub doOK_SY(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '������䣺ֵ��Ч��
                If Me.saveDataGridUnboundInfo_SY(strErrMsg, True) = False Then
                    GoTo errProc
                End If

                '��������
                If objsystemEstateRenshiXingye.doSaveData_YongjinJitiBiaozhun_SY(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_SYZB) = False Then
                    GoTo errProc
                End If

                '��¼�����־
                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]�ύ��������[�ز�_B_����_Ӷ���׼_X2_˽Ӷ]�ĸĶ���")
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

        Private Sub doOK_GYZT(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '������䣺ֵ��Ч��
                If Me.saveDataGridUnboundInfo_GYZT(strErrMsg, True) = False Then
                    GoTo errProc
                End If

                '��������
                If objsystemEstateRenshiXingye.doSaveData_YongjinJitiBiaozhun_GYZT(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_GYZT) = False Then
                    GoTo errProc
                End If

                '��¼�����־
                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]�ύ��������[�ز�_B_����_Ӷ���׼_X2_��Ӷ_ֱ��]�ĸĶ���")
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

        Private Sub doOK_GYXG(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '������䣺ֵ��Ч��
                If Me.saveDataGridUnboundInfo_GYXGZB(strErrMsg, True) = False Then
                    GoTo errProc
                End If

                '��������
                If objsystemEstateRenshiXingye.doSaveData_YongjinJitiBiaozhun_GYXG(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_GYXGZB) = False Then
                    GoTo errProc
                End If

                '��¼�����־
                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]�ύ��������[�ز�_B_����_Ӷ���׼_X2_��Ӷ_Э��]�ĸĶ���")
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

        Private Sub doOK_GYZG(ByVal strControlId As String)

            Dim objsystemEstateRenshiXingye As New Josco.JSOA.BusinessFacade.systemEstateRenshiXingye
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intColIndex As Integer
            Dim strJJDM As String

            Try
                '������䣺ֵ��Ч��
                If Me.saveDataGridUnboundInfo_GYZGZB(strErrMsg, True) = False Then
                    GoTo errProc
                End If

                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdGYZG, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ_ZJDM)
                strJJDM = objDataGridProcess.getDataGridCellValue(Me.grdGYZG.Items(Me.grdGYZG.SelectedIndex), intColIndex)

                '��������
                If objsystemEstateRenshiXingye.doSaveData_YongjinJitiBiaozhun_GYZGZB(strErrMsg, MyBase.UserId, MyBase.UserPassword, Me.m_objDataSet_GYZGZB, strJJDM) = False Then
                    GoTo errProc
                End If

                '��¼�����־
                Josco.JsKernal.SystemFramework.ApplicationLog.WriteInfo(Request.UserHostAddress, Request.UserHostName, "[" + MyBase.UserId + "]�ύ��������[�ز�_B_����_Ӷ���׼_X2_��Ӷ_ֱ��]�ĸĶ���")

                'ǿ�����»�ȡ����
                Me.releaseModuleParameters()

                '��ʾ����
                If Me.showFunctionData(strErrMsg) = False Then
                    GoTo errProc
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

        Private Sub btnAddNew_GYZG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_GYZG.Click
            Me.doAddNew_GYZG("btnAddNew_GYZG")
        End Sub
        Private Sub btnDelete_GYZG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_GYZG.Click
            Me.doDelete_GYZG("btnDelete_GYZG")
        End Sub
        Private Sub btnAddNew_GYZGZB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_GYZGZB.Click
            Me.doAddNew_GYZGZB("btnAddNew_GYZGZB")
        End Sub
        Private Sub btnDelete_GYZGZB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_GYZGZB.Click
            Me.doDelete_GYZGZB("btnDelete_GYZGZB")
        End Sub
        Private Sub btnSelAll_GYZG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_GYZG.Click
            Me.doSelectAll_GYZG("btnSelAll_GYZG")
        End Sub
        Private Sub btnDeSelAll_GYZG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_GYZG.Click
            Me.doDeSelectAll_GYZG("btnDeSelAll_GYZG")
        End Sub
        Private Sub btnSave_GYZG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave_GYZG.Click
            Me.doOK_GYZG("btnSave_GYZG")
        End Sub

        Private Sub btnAddNew_GYZT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_GYZT.Click
            Me.doAddNew_GYZT("btnAddNew_GYZT")
        End Sub
        Private Sub btnDelete_GYZT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_GYZT.Click
            Me.doDelete_GYZT("btnDelete_GYZT")
        End Sub
        Private Sub btnSelAll_GYZT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelAll_GYZT.Click
            Me.doSelectAll_GYZT("btnSelAll_GYZT")
        End Sub
        Private Sub btnDeSelAll_GYZT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeSelAll_GYZT.Click
            Me.doDeSelectAll_GYZT("btnDeSelAll_GYZT")
        End Sub
        Private Sub btnSave_GYZT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave_GYZT.Click
            Me.doOK_GYZT("btnSave_GYZT")
        End Sub

        Private Sub btnAddNew_SYZB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_SYZB.Click
            Me.doAddNew_SYZB("btnAddNew_SYZB")
        End Sub
        Private Sub btnDelete_SYZB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_SYZB.Click
            Me.doDelete_SYZB("btnDelete_SYZB")
        End Sub
        Private Sub btnSave_SYZB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave_SYZB.Click
            Me.doOK_SY("btnSave_SYZ")
        End Sub

        Private Sub btnAddNew_GYXGZB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew_GYXGZB.Click
            Me.doAddNew_GYXGZB("btnAddNew_GYXGZB")
        End Sub
        Private Sub btnDelete_GYXGZB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete_GYXGZB.Click
            Me.doDelete_GYXGZB("btnDelete_GYXGZB")
        End Sub
        Private Sub btnSave_GYXG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave_GYXG.Click
            Me.doOK_GYXG("btnSave_GYXG")
        End Sub









        Private Sub doSYBZ(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '��¼��ǰ��������
                Me.htxtFunctionId.Value = "1"

                '�ͷŻ�������
                Me.releaseModuleParameters()

                '��ʾ����
                If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doZGGY(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '��¼��ǰ��������
                Me.htxtFunctionId.Value = "2"

                '�ͷŻ�������
                Me.releaseModuleParameters()

                '��ʾ����
                If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doXGGY(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '��¼��ǰ��������
                Me.htxtFunctionId.Value = "3"

                '�ͷŻ�������
                Me.releaseModuleParameters()

                '��ʾ����
                If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doZTGY(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '��¼��ǰ��������
                Me.htxtFunctionId.Value = "4"

                '�ͷŻ�������
                Me.releaseModuleParameters()

                '��ʾ����
                If Me.showFunctionData(strErrMsg) = False Then
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

        Private Sub doCancel(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer = 1

            Try
                '��ʾ��Ϣ
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "��ʾ����ȷʵ׼����������/�񣩣�", strControlId, intStep)
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

        Private Sub lnkSYBZ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSYBZ.Click
            Me.doSYBZ("lnkSYBZ")
        End Sub
        Private Sub lnkZGGY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkZGGY.Click
            Me.doZGGY("lnkZGGY")
        End Sub
        Private Sub lnkXGGY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkXGGY.Click
            Me.doXGGY("lnkXGGY")
        End Sub
        Private Sub lnkZTGY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkZTGY.Click
            Me.doZTGY("lnkZTGY")
        End Sub
        Private Sub lnkFHSJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFHSJ.Click
            Me.doCancel("lnkFHSJ")
        End Sub

    End Class

End Namespace
