Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_es_hetong_jss_list
    ' 
    ' �������ʣ�
    '     I/O
    '
    ' ���������� 
    '   ������ͬ�������б�������ģ��
    ' ���ļ�¼��
    '     zengxianglin 2009-12-26 ����
    '----------------------------------------------------------------

    Partial Class estate_es_hetong_jss_list
        Inherits Josco.JsKernal.web.PageBase

#Region " Web ������������ɵĴ��� "

        '�õ����� Web ���������������ġ�
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub






        'zengxianglin 2009-12-26
        'zengxianglin 2009-12-26




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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateEsHetongJssList
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateEsHetongJssList
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdHT��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_HT As String = "chkHT"
        Private Const m_cstrDataGridInDIV_HT As String = "divHT"
        Private m_intFixedColumns_HT As Integer

        '----------------------------------------------------------------
        '����������grdJSS��صĲ���
        '----------------------------------------------------------------
        Private Const m_cstrCheckBoxIdInDataGrid_JSS As String = "chkJSS"
        Private Const m_cstrDataGridInDIV_JSS As String = "divJSS"
        Private m_intFixedColumns_JSS As Integer

        '----------------------------------------------------------------
        '��ǰ���������ݼ�
        '----------------------------------------------------------------
        Private m_objDataSet_JSS As Josco.JSOA.Common.Data.estateErshouData
        Private m_objDataSet_HT As Josco.JSOA.Common.Data.estateErshouData
        Private m_strQuery_HT As String
        Private m_intRows_HT As Integer

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_strQRSH As String

        '----------------------------------------------------------------
        '����ģ��˽�ò���
        '----------------------------------------------------------------
        Private m_blnQxControl As Boolean

        Public ReadOnly Property propQRSH() As String
            Get
                propQRSH = Me.m_strQRSH
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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateEsHetongJssList)
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
                Dim strFirstParamValue As String = ""
                Dim strParamValue As String = ""
                Dim strParamName As String = ""
                Dim strFilter As String = ""
                Dim strMKMC As String = ""
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
                If Me.m_blnPrevilegeParams(0) = True And Me.m_blnPrevilegeParams(9) = True Then
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
                    Me.htxtDivLeftHT.Value = .htxtDivLeftHT
                    Me.htxtDivTopHT.Value = .htxtDivTopHT
                    Me.htxtDivLeftJSS.Value = .htxtDivLeftJSS
                    Me.htxtDivTopJSS.Value = .htxtDivTopJSS

                    Me.htxtHTQuery.Value = .htxtHTQuery
                    Me.htxtHTRows.Value = .htxtHTRows
                    Me.htxtHTSort.Value = .htxtHTSort
                    Me.htxtHTSortColumnIndex.Value = .htxtHTSortColumnIndex
                    Me.htxtHTSortType.Value = .htxtHTSortType

                    Me.txtHTSearch_HTBH.Text = .txtHTSearch_HTBH
                    Me.txtHTSearch_QRSH.Text = .txtHTSearch_QRSH
                    Me.txtHTSearch_JFMC.Text = .txtHTSearch_JFMC
                    Me.txtHTSearch_YFMC.Text = .txtHTSearch_YFMC
                    Me.txtHTSearch_FWDZ.Text = .txtHTSearch_FWDZ
                    Me.txtHTSearch_HTRQMax.Text = .txtHTSearch_HTRQMax
                    Me.txtHTSearch_HTRQMin.Text = .txtHTSearch_HTRQMin
                    Me.ddlHTSearch_HTZT.SelectedIndex = .ddlHTSearch_HTZT_SelectedIndex

                    Me.txtHTPageIndex.Text = .txtHTPageIndex
                    Me.txtHTPageSize.Text = .txtHTPageSize

                    Try
                        Me.grdHT.PageSize = .grdHTPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdHT.CurrentPageIndex = .grdHTCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdHT.SelectedIndex = .grdHTSelectedIndex
                    Catch ex As Exception
                    End Try
                    Me.htxtSessionIdQueryHT.Value = .htxtSessionIdQueryHT

                    Try
                        Me.grdJSS.PageSize = .grdJSSPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJSS.CurrentPageIndex = .grdJSSCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdJSS.SelectedIndex = .grdJSSSelectedIndex
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
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateEsHetongJssList

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftHT = Me.htxtDivLeftHT.Value
                    .htxtDivTopHT = Me.htxtDivTopHT.Value
                    .htxtDivLeftJSS = Me.htxtDivLeftJSS.Value
                    .htxtDivTopJSS = Me.htxtDivTopJSS.Value

                    .htxtHTQuery = Me.htxtHTQuery.Value
                    .htxtHTRows = Me.htxtHTRows.Value
                    .htxtHTSort = Me.htxtHTSort.Value
                    .htxtHTSortColumnIndex = Me.htxtHTSortColumnIndex.Value
                    .htxtHTSortType = Me.htxtHTSortType.Value

                    .txtHTSearch_HTBH = Me.txtHTSearch_HTBH.Text
                    .txtHTSearch_QRSH = Me.txtHTSearch_QRSH.Text
                    .txtHTSearch_JFMC = Me.txtHTSearch_JFMC.Text
                    .txtHTSearch_YFMC = Me.txtHTSearch_YFMC.Text
                    .txtHTSearch_FWDZ = Me.txtHTSearch_FWDZ.Text
                    .txtHTSearch_HTRQMax = Me.txtHTSearch_HTRQMax.Text
                    .txtHTSearch_HTRQMin = Me.txtHTSearch_HTRQMin.Text
                    .ddlHTSearch_HTZT_SelectedIndex = Me.ddlHTSearch_HTZT.SelectedIndex

                    .txtHTPageIndex = Me.txtHTPageIndex.Text
                    .txtHTPageSize = Me.txtHTPageSize.Text

                    .grdHTPageSize = Me.grdHT.PageSize
                    .grdHTCurrentPageIndex = Me.grdHT.CurrentPageIndex
                    .grdHTSelectedIndex = Me.grdHT.SelectedIndex
                    .htxtSessionIdQueryHT = Me.htxtSessionIdQueryHT.Value

                    .grdJSSPageSize = Me.grdJSS.PageSize
                    .grdJSSCurrentPageIndex = Me.grdJSS.CurrentPageIndex
                    .grdJSSSelectedIndex = Me.grdJSS.SelectedIndex
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
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getDataFromCallModule = False

            Try
                If Me.IsPostBack = True Then
                    Exit Try
                End If

                'zengxianglin 2008-11-18
                '==========================================================================================================================================================
                Dim objIEstateEsHetongQtInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongQtInfo = Nothing
                Try
                    objIEstateEsHetongQtInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongQtInfo)
                Catch ex As Exception
                    objIEstateEsHetongQtInfo = Nothing
                End Try
                If Not (objIEstateEsHetongQtInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongQtInfo.SafeRelease(objIEstateEsHetongQtInfo)
                    Exit Try
                End If
                'zengxianglin 2008-11-18

                '==========================================================================================================================================================
                Dim objIEstateEsHetongJssSh As Josco.JSOA.BusinessFacade.IEstateEsHetongJssSh = Nothing
                Try
                    objIEstateEsHetongJssSh = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongJssSh)
                Catch ex As Exception
                    objIEstateEsHetongJssSh = Nothing
                End Try
                If Not (objIEstateEsHetongJssSh Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongJssSh.SafeRelease(objIEstateEsHetongJssSh)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsHetongJssInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo = Nothing
                Try
                    objIEstateEsHetongJssInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo)
                Catch ex As Exception
                    objIEstateEsHetongJssInfo = Nothing
                End Try
                If Not (objIEstateEsHetongJssInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo.SafeRelease(objIEstateEsHetongJssInfo)
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
                Dim objIEstateEsHetongZlInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo = Nothing
                Try
                    objIEstateEsHetongZlInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo)
                Catch ex As Exception
                    objIEstateEsHetongZlInfo = Nothing
                End Try
                If Not (objIEstateEsHetongZlInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo.SafeRelease(objIEstateEsHetongZlInfo)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIEstateEsHetongMmInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo = Nothing
                Try
                    objIEstateEsHetongMmInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo)
                Catch ex As Exception
                    objIEstateEsHetongMmInfo = Nothing
                End Try
                If Not (objIEstateEsHetongMmInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo.SafeRelease(objIEstateEsHetongMmInfo)
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
                        Me.htxtHTQuery.Value = objISjcxCxtj.oQueryString
                        If Me.htxtSessionIdQueryHT.Value.Trim = "" Then
                            Me.htxtSessionIdQueryHT.Value = objPulicParameters.getNewGuid()
                        Else
                            Try
                                objQueryData = CType(Session(Me.htxtSessionIdQueryHT.Value), Josco.JsKernal.Common.Data.QueryData)
                            Catch ex As Exception
                                objQueryData = Nothing
                            End Try
                            Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                        End If
                        Session.Add(Me.htxtSessionIdQueryHT.Value, objISjcxCxtj.oDataSetTJ)
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
            Dim objsystemCustomer As New Josco.JsKernal.BusinessFacade.systemCustomer

            getInterfaceParameters = False

            Try
                '��QueryString�н����ӿڲ���(�����Ƿ�ط�)
                Dim objTemp As Object = Nothing
                Try
                    objTemp = Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId))
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateEsHetongJssList)
                Catch ex As Exception
                    m_objInterface = Nothing
                End Try
                If m_objInterface Is Nothing Then
                    Me.m_blnInterface = False
                    'û���нӿڲ���
                    Me.m_strQRSH = ""
                Else
                    Me.m_blnInterface = True
                    '�нӿڲ���
                    Me.m_strQRSH = Me.m_objInterface.iQRSH
                End If

                '�жϵ�ǰ��Ա�Ƿ�Ϊ������Ա
                Dim blnIS As Boolean = True
                If objsystemCustomer.isFenghangRenyuan(strErrMsg, MyBase.UserId, MyBase.UserPassword, MyBase.UserId, blnIS) = False Then
                    GoTo errProc
                End If
                If blnIS = True Then
                    Me.m_blnQxControl = True '��������Ȩ�޿���
                Else
                    Me.m_blnQxControl = False
                End If

                '��ȡ�ָ��ֳ�����
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateEsHetongJssList)
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

                    '��������ģ�鷵�غ����Ϣ��ͬʱ�ͷ���Ӧ��Դ
                    If Me.getDataFromCallModule(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

                Me.m_strQuery_HT = Me.htxtHTQuery.Value
                Me.m_intRows_HT = objPulicParameters.getObjectValue(Me.htxtHTRows.Value, 0)
                Me.m_intFixedColumns_HT = objPulicParameters.getObjectValue(Me.htxtHTFixed.Value, 0)

                Me.m_intFixedColumns_JSS = objPulicParameters.getObjectValue(Me.htxtJSSFixed.Value, 0)
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
                If Me.htxtSessionIdQueryHT.Value.Trim <> "" Then
                    Dim objQueryData As Josco.JsKernal.Common.Data.QueryData
                    Try
                        objQueryData = CType(Session(Me.htxtSessionIdQueryHT.Value), Josco.JsKernal.Common.Data.QueryData)
                    Catch ex As Exception
                        objQueryData = Nothing
                    End Try
                    Josco.JsKernal.Common.Data.QueryData.SafeRelease(objQueryData)
                    Session.Remove(Me.htxtSessionIdQueryHT.Value)
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub














        '----------------------------------------------------------------
        ' ��ȡģ����������(Ĭ�ϱ�ǰ׺a.)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_HT( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_HT = False
            strQuery = ""

            Try
                '����ȷ����š�����
                Dim strQRSH As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH
                If Me.txtHTSearch_QRSH.Text.Length > 0 Then Me.txtHTSearch_QRSH.Text = Me.txtHTSearch_QRSH.Text.Trim()
                If Me.txtHTSearch_QRSH.Text <> "" Then
                    Me.txtHTSearch_QRSH.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_QRSH.Text)
                    If strQuery = "" Then
                        strQuery = strQRSH + " like '" + Me.txtHTSearch_QRSH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strQRSH + " like '" + Me.txtHTSearch_QRSH.Text + "%'"
                    End If
                End If

                '������ͬ��š�����
                Dim strHTBH As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTBH
                If Me.txtHTSearch_HTBH.Text.Length > 0 Then Me.txtHTSearch_HTBH.Text = Me.txtHTSearch_HTBH.Text.Trim()
                If Me.txtHTSearch_HTBH.Text <> "" Then
                    Me.txtHTSearch_HTBH.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_HTBH.Text)
                    If strQuery = "" Then
                        strQuery = strHTBH + " like '" + Me.txtHTSearch_HTBH.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strHTBH + " like '" + Me.txtHTSearch_HTBH.Text + "%'"
                    End If
                End If

                '�����׷����ơ�����
                Dim strJFMC As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_YZMC
                If Me.txtHTSearch_JFMC.Text.Length > 0 Then Me.txtHTSearch_JFMC.Text = Me.txtHTSearch_JFMC.Text.Trim()
                If Me.txtHTSearch_JFMC.Text <> "" Then
                    Me.txtHTSearch_JFMC.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_JFMC.Text)
                    If strQuery = "" Then
                        strQuery = strJFMC + " like '" + Me.txtHTSearch_JFMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strJFMC + " like '" + Me.txtHTSearch_JFMC.Text + "%'"
                    End If
                End If

                '�����ҷ����ơ�����
                Dim strYFMC As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_KHMC
                If Me.txtHTSearch_YFMC.Text.Length > 0 Then Me.txtHTSearch_YFMC.Text = Me.txtHTSearch_YFMC.Text.Trim()
                If Me.txtHTSearch_YFMC.Text <> "" Then
                    Me.txtHTSearch_YFMC.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_YFMC.Text)
                    If strQuery = "" Then
                        strQuery = strYFMC + " like '" + Me.txtHTSearch_YFMC.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strYFMC + " like '" + Me.txtHTSearch_YFMC.Text + "%'"
                    End If
                End If

                '�������ݵ�ַ������
                Dim strFWDZ As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_WYDZ
                If Me.txtHTSearch_FWDZ.Text.Length > 0 Then Me.txtHTSearch_FWDZ.Text = Me.txtHTSearch_FWDZ.Text.Trim()
                If Me.txtHTSearch_FWDZ.Text <> "" Then
                    Me.txtHTSearch_FWDZ.Text = objPulicParameters.getNewSearchString(Me.txtHTSearch_FWDZ.Text)
                    If strQuery = "" Then
                        strQuery = strFWDZ + " like '" + Me.txtHTSearch_FWDZ.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strFWDZ + " like '" + Me.txtHTSearch_FWDZ.Text + "%'"
                    End If
                End If

                '������ͬ״̬������
                Dim strHTZT As String = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTZT
                Select Case Me.ddlHTSearch_HTZT.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strHTZT + Me.ddlHTSearch_HTZT.SelectedValue
                        Else
                            strQuery = strQuery + " and " + strHTZT + Me.ddlHTSearch_HTZT.SelectedValue
                        End If
                    Case Else
                End Select

                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime

                '������ͬ���ڡ�����
                Dim strHTRQ As String
                strHTRQ = "a." + Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTRQ
                If Me.txtHTSearch_HTRQMin.Text.Length > 0 Then Me.txtHTSearch_HTRQMin.Text = Me.txtHTSearch_HTRQMin.Text.Trim()
                If Me.txtHTSearch_HTRQMax.Text.Length > 0 Then Me.txtHTSearch_HTRQMax.Text = Me.txtHTSearch_HTRQMax.Text.Trim()
                If Me.txtHTSearch_HTRQMin.Text <> "" And Me.txtHTSearch_HTRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtHTSearch_HTRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtHTSearch_HTRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtHTSearch_HTRQMin.Text = dateMax.ToString("yyyy-MM-dd")
                        Me.txtHTSearch_HTRQMax.Text = dateMin.ToString("yyyy-MM-dd")
                    Else
                        Me.txtHTSearch_HTRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                        Me.txtHTSearch_HTRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strHTRQ + " between '" + Me.txtHTSearch_HTRQMin.Text + "' and '" + Me.txtHTSearch_HTRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " between '" + Me.txtHTSearch_HTRQMin.Text + "' and '" + Me.txtHTSearch_HTRQMax.Text + "'"
                    End If
                ElseIf Me.txtHTSearch_HTRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtHTSearch_HTRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtHTSearch_HTRQMin.Text = dateMin.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strHTRQ + " >= '" + Me.txtHTSearch_HTRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " >= '" + Me.txtHTSearch_HTRQMin.Text + "'"
                    End If
                ElseIf Me.txtHTSearch_HTRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtHTSearch_HTRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч��ʱ�䣡"
                        GoTo errProc
                    End Try
                    Me.txtHTSearch_HTRQMax.Text = dateMax.ToString("yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strHTRQ + " <= '" + Me.txtHTSearch_HTRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strHTRQ + " <= '" + Me.txtHTSearch_HTRQMax.Text + "'"
                    End If
                Else
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_HT = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdHTҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     strWhere       �������ַ���
        '     blnControl     ������Ȩ�޿���
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_HT( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_HT = False

            Try
                '����Sort�ַ���
                Dim strSort As String = ""
                strSort = Me.htxtHTSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_HT)

                '���¼�������
                If objsystemEstateErshou.getDataSet_ES_JYXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, blnControl, Me.m_objDataSet_HT) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_HT.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_HT.Tables(strTable)
                    Me.htxtHTRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_HT = .DefaultView.Count
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_HT = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����grdHT�ĵ�ǰ�л�ȡQRSH
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQRSH( _
            ByRef strErrMsg As String, _
            ByRef strQRSH As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getQRSH = False
            strErrMsg = ""
            strQRSH = ""

            Try
                If Me.grdHT.SelectedIndex >= 0 Then
                    Dim i As Integer = Me.grdHT.SelectedIndex
                    Dim intColIndex As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH)
                    strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getQRSH = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����grdJSS�ĵ�ǰ�л�ȡQRSH
        '     strErrMsg      �����ش�����Ϣ
        '     strJSSH        ���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getJSSH( _
            ByRef strErrMsg As String, _
            ByRef strJSSH As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getJSSH = False
            strErrMsg = ""
            strJSSH = ""

            Try
                If Me.grdJSS.SelectedIndex >= 0 Then
                    Dim i As Integer = Me.grdJSS.SelectedIndex
                    Dim intColIndex As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJSS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_JSSH)
                    strJSSH = objDataGridProcess.getDataGridCellValue(Me.grdJSS.Items(i), intColIndex)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getJSSH = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����grdJSS�ĵ�ǰ�л�ȡstrJSBS
        '     strErrMsg      �����ش�����Ϣ
        '     strJSBS        �������ʶ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        ' ���ļ�¼
        '     zengxiaqnglin 2009-12-26 ����
        '----------------------------------------------------------------
        Private Function getJSBS( _
            ByRef strErrMsg As String, _
            ByRef strJSBS As String) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            getJSBS = False
            strErrMsg = ""
            strJSBS = ""

            Try
                If Me.grdJSS.SelectedIndex >= 0 Then
                    Dim i As Integer = Me.grdJSS.SelectedIndex
                    Dim intColIndex As Integer = 0
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJSS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_WYBS)
                    strJSBS = objDataGridProcess.getDataGridCellValue(Me.grdJSS.Items(i), intColIndex)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            getJSBS = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdJSSҪ��ʾ��������Ϣ(���ݺ�ͬ�б��ĵ�ǰ��ͬ��ȡ)
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       ����������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_JSS( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou

            getModuleData_JSS = False

            Try
                '���㵱ǰ��ͬ
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateErshouData.SafeRelease(Me.m_objDataSet_JSS)

                '���¼�������
                If objsystemEstateErshou.getDataSet_ES_HETONG_JSS(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, strWhere, Me.m_objDataSet_JSS) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)

            getModuleData_JSS = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdHT����
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        '     blnControl     ������Ȩ�޿���
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_HT( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String, _
            ByVal blnControl As Boolean) As Boolean

            searchModuleData_HT = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_HT(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_HT(strErrMsg, strQRSH, strQuery, blnControl) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_HT = strQuery
                Me.htxtHTQuery.Value = Me.m_strQuery_HT
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_HT = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdHT������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_HT( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_HT = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer = -1
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtHTSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtHTSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_HT Is Nothing Then
                    Me.grdHT.DataSource = Nothing
                Else
                    With Me.m_objDataSet_HT.Tables(strTable)
                        Me.grdHT.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_HT.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdHT, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdHT)
                    With Me.grdHT.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdHT.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                ''�ָ������е�CheckBox״̬
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdHT, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_HT) = False Then
                '    GoTo errProc
                'End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_HT = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdJSS������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_JSS( _
            ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_JSS = False

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_JSS Is Nothing Then
                    Me.grdJSS.DataSource = Nothing
                Else
                    With Me.m_objDataSet_JSS.Tables(strTable)
                        Me.grdJSS.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_JSS.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdJSS, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '������
                Me.grdJSS.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                ''�ָ������е�CheckBox״̬
                'If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdJSS, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_JSS) = False Then
                '    GoTo errProc
                'End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_JSS = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdHT�������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_HT(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_HT = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_HT(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_HT.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblHTGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdHT, .Count)

                    '��ʾҳ���������
                    Me.lnkCZHTMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdHT, .Count)
                    Me.lnkCZHTMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdHT, .Count)
                    Me.lnkCZHTMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdHT, .Count)
                    Me.lnkCZHTMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdHT, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZHTDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZHTSelectAll.Enabled = blnEnabled
                    Me.lnkCZHTGotoPage.Enabled = blnEnabled
                    Me.lnkCZHTSetPageSize.Enabled = blnEnabled
                End With

                'ͬ����ʾ
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_JSS(strErrMsg, "") = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_JSS(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showJiaoyiInfo(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_Main(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_HT = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdJSS�������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_JSS(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_B_ES_HETONG_JIESUANSHU
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objControlProcess As New Josco.JsKernal.web.ControlProcess

            showModuleData_JSS = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_JSS(strErrMsg) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)

            showModuleData_JSS = True
            Exit Function
errProc:
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Josco.JsKernal.web.ControlProcess.SafeRelease(objControlProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾ��ͬ��Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strQRSH        ��ȷ�����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showJiaoyiInfo( _
            ByRef strErrMsg As String, _
            ByVal strQRSH As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDropDownListProcess As New Josco.JsKernal.web.DropDownListProcess
            Dim objestateErshouData As Josco.JSOA.Common.Data.estateErshouData

            showJiaoyiInfo = False
            strErrMsg = ""

            Try
                '��ȡ��Ϣ
                If objsystemEstateErshou.getDataSet_ES_JYXX(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, "", objestateErshouData) = False Then
                    GoTo errProc
                End If

                '��ʼ����Ϣ
                Me.lblJYBH.Text = ""
                Me.lblJYRQ.Text = ""
                Me.lblJFMC.Text = ""
                Me.lblJYJG.Text = ""
                Me.lblHTBH.Text = ""
                Me.lblHTRQ.Text = ""
                Me.lblYFMC.Text = ""
                Me.lblJYMJ.Text = ""
                Me.lblWYDZ.Text = ""
                Me.lblJFDLF.Text = ""
                Me.lblYFDLF.Text = ""

                '��ʾ��Ϣ
                With objestateErshouData.Tables(strTable)
                    If .Rows.Count < 1 Then
                        Exit Try
                    End If
                    Me.lblJYBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH), "")
                    Me.lblJYRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYRQ), "", "yyyy-MM-dd")
                    Me.lblJFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_YZMC), "")
                    Me.lblJYJG.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYJG), 0.0).ToString("#,###.00")
                    Me.lblHTBH.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTBH), "")
                    Me.lblHTRQ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTRQ), "", "yyyy-MM-dd")
                    Me.lblYFMC.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_KHMC), "")
                    Me.lblJYMJ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYMJ), 0.0).ToString("#,###.00")
                    Me.lblWYDZ.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_WYDZ), "")
                    Me.lblJFDLF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JFDLF), 0.0).ToString("#,###.00")
                    Me.lblYFDLF.Text = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_YFDLF), 0.0).ToString("#,###.00")
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objestateErshouData)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)

            showJiaoyiInfo = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateErshouData.SafeRelease(objestateErshouData)
            Josco.JsKernal.web.DropDownListProcess.SafeRelease(objDropDownListProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾģ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_Main(ByRef strErrMsg As String) As Boolean

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_Main = False

            Try
                '��ͬ���?
                Dim blnComplete As Boolean = True
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If strQRSH <> "" Then
                    If objsystemEstateErshou.isHetongComplete(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, blnComplete) = False Then
                        GoTo errProc
                    End If
                End If

                '���������?
                Dim blnShenhe As Boolean = True
                Dim intColIndex As Integer = 0
                Dim strValue As String = ""
                If Me.grdJSS.SelectedIndex >= 0 Then
                    intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdJSS, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_B_ES_HETONG_JIESUANSHU_ZTBZ)
                    strValue = objDataGridProcess.getDataGridCellValue(Me.grdJSS.Items(Me.grdJSS.SelectedIndex), intColIndex)
                    Select Case Josco.JSOA.Common.Data.estateErshouData.getJiesuanshuStatus(objPulicParameters.getObjectValue(strValue, 0))
                        Case Josco.JSOA.Common.Data.estateErshouData.enumJiesuanshuStatus.Yishen
                            blnShenhe = True
                        Case Else
                            blnShenhe = False
                    End Select
                End If

                Me.btnAddNew.Visible = Me.m_blnPrevilegeParams(9) And (blnComplete = False) And (strQRSH <> "")
                Me.btnUpdate.Visible = Me.m_blnPrevilegeParams(9) And (blnComplete = False) And (strQRSH <> "") And (blnShenhe = False)
                Me.btnDelete.Visible = Me.m_blnPrevilegeParams(9) And (blnComplete = False) And (strQRSH <> "") And (blnShenhe = False)
                Me.btnSHQM.Visible = (strQRSH <> "")
                Me.btnSZTZ.Visible = (strQRSH <> "")
                'zengxianglin 2009-12-26
                Me.btnBJYJ.Visible = Me.m_blnPrevilegeParams(9) And (strQRSH <> "")
                'zengxianglin 2009-12-26
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_Main = True
            Exit Function
errProc:
            Josco.JSOA.BusinessFacade.systemEstateErshou.SafeRelease(objsystemEstateErshou)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
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
                    objControlProcess.doTranslateKey(Me.txtHTPageIndex)
                    objControlProcess.doTranslateKey(Me.txtHTPageSize)
                    '********************************************************
                    objControlProcess.doTranslateKey(Me.txtHTSearch_HTBH)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_QRSH)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_JFMC)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_YFMC)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_FWDZ)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_HTRQMin)
                    objControlProcess.doTranslateKey(Me.txtHTSearch_HTRQMax)
                    objControlProcess.doTranslateKey(Me.ddlHTSearch_HTZT)
                    '********************************************************

                    If Me.m_blnSaveScence = False Then
                        If Me.m_strQRSH = "" Then
                            Me.txtHTSearch_HTRQMin.Text = Now.Year.ToString + "-01-01"
                            'zengxianglin 2009-02-24
                            'Me.ddlHTSearch_HTZT.SelectedIndex = 2
                            'zengxianglin 2009-02-24
                            If Me.searchModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_blnQxControl) = False Then
                                GoTo errProc
                            End If
                        Else
                            If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                                GoTo errProc
                            End If
                        End If
                    Else
                        If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                            GoTo errProc
                        End If
                    End If
                    If Me.showModuleData_HT(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-06
                    If Me.showModuleData_Main(strErrMsg) = False Then
                        GoTo errProc
                    End If
                    'zengxianglin 2008-11-06
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
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

            '��ȡ�ӿڲ���
            If Me.getInterfaceParameters(strErrMsg) = False Then
                GoTo errProc
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
        Sub grdHT_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdHT.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_HT + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_HT > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_HT - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdHT.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Sub grdJSS_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdJSS.ItemDataBound

            Dim intCells As Integer = -1
            Dim i As Integer = 0

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_JSS + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_JSS > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_JSS - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdJSS.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

            Exit Sub

        End Sub

        Private Sub grdHT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdHT.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblHTGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdHT, Me.m_intRows_HT)

                'ͬ����ʾ
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If Me.getModuleData_JSS(strErrMsg, "") = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_JSS(strErrMsg) = False Then
                    GoTo errProc
                End If
                If Me.showJiaoyiInfo(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_Main(strErrMsg) = False Then
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

        Private Sub grdHT_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdHT.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI
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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                With Me.m_objDataSet_HT.Tables(strTable)
                    strOldCommand = .DefaultView.Sort
                End With

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                With Me.m_objDataSet_HT.Tables(strTable)
                    .DefaultView.Sort = strFinalCommand
                End With

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtHTSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtHTSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtHTSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_HT(strErrMsg) = False Then
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

        Private Sub grdHT_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdHT.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer

                '��λ
                Me.grdHT.SelectedIndex = e.Item.ItemIndex

                '����
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        Me.doOpen_Hetong(strControlId)
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

        Private Sub grdJSS_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdJSS.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strControlId As String
                Dim intColIndex As Integer
                '��λ
                Me.grdJSS.SelectedIndex = e.Item.ItemIndex

                '����
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        Me.doOpen(strControlId)
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














        Private Sub doMoveFirst(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdHT.PageCount)
                Me.grdHT.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_HT(strErrMsg) = False Then
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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdHT.PageCount - 1, Me.grdHT.PageCount)
                Me.grdHT.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_HT(strErrMsg) = False Then
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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdHT.CurrentPageIndex + 1, Me.grdHT.PageCount)
                Me.grdHT.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_HT(strErrMsg) = False Then
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
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdHT.CurrentPageIndex - 1, Me.grdHT.PageCount)
                Me.grdHT.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_HT(strErrMsg) = False Then
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
            intPageIndex = objPulicParameters.getObjectValue(Me.txtHTPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdHT.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_HT(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtHTPageIndex.Text = (Me.grdHT.CurrentPageIndex + 1).ToString()

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
            intPageSize = objPulicParameters.getObjectValue(Me.txtHTPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdHT.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_HT(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtHTPageSize.Text = (Me.grdHT.PageSize).ToString()
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdHT, 0, Me.m_cstrCheckBoxIdInDataGrid_HT, True) = False Then
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
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdHT, 0, Me.m_cstrCheckBoxIdInDataGrid_HT, False) = False Then
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

        Private Sub doSearch(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_blnQxControl) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_HT(strErrMsg) = False Then
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

        Private Sub lnkCZHTMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTMoveFirst.Click
            Me.doMoveFirst("lnkCZHTMoveFirst")
        End Sub

        Private Sub lnkCZHTMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTMoveLast.Click
            Me.doMoveLast("lnkCZHTMoveLast")
        End Sub

        Private Sub lnkCZHTMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTMoveNext.Click
            Me.doMoveNext("lnkCZHTMoveNext")
        End Sub

        Private Sub lnkCZHTMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTMovePrev.Click
            Me.doMovePrevious("lnkCZHTMovePrev")
        End Sub

        Private Sub lnkCZHTGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTGotoPage.Click
            Me.doGotoPage("lnkCZHTGotoPage")
        End Sub

        Private Sub lnkCZHTSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTSetPageSize.Click
            Me.doSetPageSize("lnkCZHTSetPageSize")
        End Sub

        Private Sub lnkCZHTSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTSelectAll.Click
            Me.doSelectAll("lnkCZHTSelectAll")
        End Sub

        Private Sub lnkCZHTDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZHTDeSelectAll.Click
            Me.doDeSelectAll("lnkCZHTDeSelectAll")
        End Sub

        Private Sub btnHTSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHTSearch.Click
            Me.doSearch("btnHTSearch")
        End Sub











        Private Sub doSearchFull(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.estateErshouData.TABLE_DC_V_QUANBUJIAOYI

            Try
                '��ȡ����
                If Me.getModuleData_HT(strErrMsg, Me.m_strQRSH, Me.m_strQuery_HT, Me.m_blnQxControl) = False Then
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
                objISjcxCxtj = New Josco.JsKernal.BusinessFacade.ISjcxCxtj
                With objISjcxCxtj
                    If Me.htxtSessionIdQueryHT.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtSessionIdQueryHT.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_HT.Tables(strTable)
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

        Private Sub btnHTSearch_Full_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHTSearch_Full.Click
            Me.doSearchFull("btnHTSearch_Full")
        End Sub













        '----------------------------------------------------------------
        'ģ���������������
        '----------------------------------------------------------------
        Private Sub doOpen_Hetong(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                If Me.grdHT.SelectedIndex < 0 Then
                    strErrMsg = "����û��ѡ��[��ͬ]��"
                    GoTo errProc
                End If
                Dim i As Integer = Me.grdHT.SelectedIndex
                Dim intColIndex As Integer = 0
                Dim strYWLX As String = ""
                Dim intHTZT As Integer = 0
                Dim strHTBH As String = ""
                Dim strQRSH As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYLX)
                strYWLX = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTZT)
                intHTZT = objPulicParameters.getObjectValue(objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex), 0)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_HTBH)
                strHTBH = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdHT, Josco.JSOA.Common.Data.estateErshouData.FIELD_DC_V_QUANBUJIAOYI_JYBH)
                strQRSH = objDataGridProcess.getDataGridCellValue(Me.grdHT.Items(i), intColIndex)
                If strHTBH = "" Then
                    strErrMsg = "����[" + strQRSH + "]��ûǩ��ͬ��"
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
                Select Case strYWLX
                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_MM
                        Dim strUrl As String = ""
                        Dim objIEstateEsHetongMmInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo = Nothing
                        objIEstateEsHetongMmInfo = New Josco.JSOA.BusinessFacade.IEstateEsHetongMmInfo
                        With objIEstateEsHetongMmInfo
                            .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                            .iQRSH = strQRSH
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
                        Session.Add(strNewSessionId, objIEstateEsHetongMmInfo)
                        strUrl = ""
                        strUrl += "estate_es_hetongmm_info.aspx"
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += strNewSessionId
                        Response.Redirect(strUrl)
                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_ZL
                        Dim strUrl As String = ""
                        Dim objIEstateEsHetongZlInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo = Nothing
                        objIEstateEsHetongZlInfo = New Josco.JSOA.BusinessFacade.IEstateEsHetongZlInfo
                        With objIEstateEsHetongZlInfo
                            .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                            .iQRSH = strQRSH
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
                        Session.Add(strNewSessionId, objIEstateEsHetongZlInfo)
                        strUrl = ""
                        strUrl += "estate_es_hetongzl_info.aspx"
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += strNewSessionId
                        Response.Redirect(strUrl)

                        'zengxianglin 2008-11-18
                    Case Josco.JSOA.Common.Data.estateErshouData.YWLX_ES_QT
                        Dim strUrl As String = ""
                        Dim objIEstateEsHetongQtInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongQtInfo = Nothing
                        objIEstateEsHetongQtInfo = New Josco.JSOA.BusinessFacade.IEstateEsHetongQtInfo
                        With objIEstateEsHetongQtInfo
                            .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                            .iQRSH = strQRSH
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
                        Session.Add(strNewSessionId, objIEstateEsHetongQtInfo)
                        strUrl = ""
                        strUrl += "estate_es_hetongqt_info.aspx"
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += strNewSessionId
                        Response.Redirect(strUrl)
                        'zengxianglin 2008-11-18
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

        Private Sub doClose(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                Dim strSessionId As String
                Dim strUrl As String
                If Me.m_blnInterface = True Then
                    '���÷��ز���
                    '���ص�����ģ�飬�����ӷ��ز���
                    Me.m_objInterface.oExitMode = False
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

        Private Sub doOpen_SZTZ(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If strQRSH = "" Then
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
                    .iQRSH = strQRSH
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

        Private Sub doAddNew(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If strQRSH = "" Then
                    strErrMsg = "����û��ѡ��[ȷ����]��"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-22
                '����?
                Dim blnIS_GY As Boolean
                Dim blnIS As Boolean
                If objsystemEstateErshou.isHetongYiShen(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, blnIS) = False Then
                    GoTo errProc
                End If
                If blnIS = False Then
                    strErrMsg = "����ȷ����[" + strQRSH + "]��û����ˣ�"
                    GoTo errProc
                End If
                If objsystemEstateErshou.isHetongDoneFPBL(strErrMsg, MyBase.UserId, MyBase.UserPassword, strQRSH, blnIS, blnIS_GY) = False Then
                    GoTo errProc
                End If
                If blnIS = False Then
                    strErrMsg = "����ȷ����[" + strQRSH + "]��û��ָ��[˽��ҵ�����䷽��]��"
                    GoTo errProc
                End If
                If blnIS_GY = False Then
                    strErrMsg = "����ȷ����[" + strQRSH + "]��û��ָ��[��Ӷҵ�����䷽��]��"
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
                Dim objIEstateEsHetongJssInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongJssInfo = New Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo
                With objIEstateEsHetongJssInfo
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    .iQRSH = strQRSH
                    .iJSSH = ""
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
                Session.Add(strNewSessionId, objIEstateEsHetongJssInfo)
                strUrl = ""
                strUrl += "estate_es_hetong_jss_info.aspx"
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

        Private Sub doUpdate(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If strQRSH = "" Then
                    strErrMsg = "����û��ѡ��[ȷ����]��"
                    GoTo errProc
                End If
                Dim strJSSH As String = ""
                If Me.getJSSH(strErrMsg, strJSSH) = False Then
                    GoTo errProc
                End If
                If strJSSH = "" Then
                    strErrMsg = "����û��ѡ��[������]��"
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
                Dim objIEstateEsHetongJssInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongJssInfo = New Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo
                With objIEstateEsHetongJssInfo
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eUpdate
                    .iQRSH = strQRSH
                    .iJSSH = strJSSH
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
                Session.Add(strNewSessionId, objIEstateEsHetongJssInfo)
                strUrl = ""
                strUrl += "estate_es_hetong_jss_info.aspx"
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

        Private Sub doOpen(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If strQRSH = "" Then
                    strErrMsg = "����û��ѡ��[ȷ����]��"
                    GoTo errProc
                End If
                Dim strJSSH As String = ""
                If Me.getJSSH(strErrMsg, strJSSH) = False Then
                    GoTo errProc
                End If
                If strJSSH = "" Then
                    strErrMsg = "����û��ѡ��[������]��"
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
                Dim objIEstateEsHetongJssInfo As Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongJssInfo = New Josco.JSOA.BusinessFacade.IEstateEsHetongJssInfo
                With objIEstateEsHetongJssInfo
                    .iMode = Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect
                    .iQRSH = strQRSH
                    .iJSSH = strJSSH
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
                Session.Add(strNewSessionId, objIEstateEsHetongJssInfo)
                strUrl = ""
                strUrl += "estate_es_hetong_jss_info.aspx"
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

        Private Sub doOpen_SHQM(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""

            Try
                '���
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If strQRSH = "" Then
                    strErrMsg = "����û��ѡ��[ȷ����]��"
                    GoTo errProc
                End If
                Dim strJSSH As String = ""
                If Me.getJSSH(strErrMsg, strJSSH) = False Then
                    GoTo errProc
                End If
                If strJSSH = "" Then
                    strErrMsg = "����û��ѡ��[������]��"
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
                Dim objIEstateEsHetongJssSh As Josco.JSOA.BusinessFacade.IEstateEsHetongJssSh = Nothing
                Dim strUrl As String = ""
                objIEstateEsHetongJssSh = New Josco.JSOA.BusinessFacade.IEstateEsHetongJssSh
                With objIEstateEsHetongJssSh
                    .iJSSH = strJSSH
                    .iQRSH = strQRSH
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
                Session.Add(strNewSessionId, objIEstateEsHetongJssSh)
                strUrl = ""
                strUrl += "estate_es_hetong_jss_sh.aspx"
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

        'zengxianglin 2009-12-26 ����
        Private Sub doBJYJ(ByVal strControlId As String)

            Dim objsystemEstateErshou As New Josco.JSOA.BusinessFacade.systemEstateErshou
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String = ""
            Dim intStep As Integer

            Try
                intStep = 1
                '���
                Dim strQRSH As String = ""
                If Me.getQRSH(strErrMsg, strQRSH) = False Then
                    GoTo errProc
                End If
                If strQRSH = "" Then
                    strErrMsg = "����û��ѡ��[ȷ����]��"
                    GoTo errProc
                End If
                Dim strJSBS As String = ""
                If Me.getJSBS(strErrMsg, strJSBS) = False Then
                    GoTo errProc
                End If
                If strJSBS = "" Then
                    strErrMsg = "����û��ѡ��[������]��"
                    GoTo errProc
                End If

                intStep = 2
                '�����Ӷ����
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doInputBox(Me.popMessageObject, "������׼���������Ӷ��", strControlId, intStep, Now.ToString("yyyy-MM-dd"))
                    Exit Try
                End If

                intStep = 3
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    '��ȡ������Ϣ
                    Dim strJYRQ As String = ""
                    strJYRQ = objMessageProcess.getInputBoxValue(Request, Me.popMessageObject.UniqueID)
                    If strJYRQ = "" Then
                        strErrMsg = "����û������[��Ӷ����]��"
                        GoTo errProc
                    End If
                    If objPulicParameters.isDatetimeString(strJYRQ) = False Then
                        strErrMsg = "������Ч��[��Ӷ����][" + strJYRQ + "]��"
                        GoTo errProc
                    End If

                    '������
                    If objsystemEstateErshou.doUpdate_ES_HETONG_JSS_JYRQ(strErrMsg, MyBase.UserId, MyBase.UserPassword, strJSBS, strJYRQ) = False Then
                        GoTo errProc
                    End If

                    'ˢ����ʾ
                    If Me.getModuleData_JSS(strErrMsg, "") = False Then
                        GoTo errProc
                    End If
                    If Me.showModuleData_JSS(strErrMsg) = False Then
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

        Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
            Me.doAddNew("btnAddNew")
        End Sub

        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Me.doUpdate("btnUpdate")
        End Sub

        Private Sub btnSZTZ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSZTZ.Click
            Me.doOpen_SZTZ("btnSZTZ")
        End Sub

        Private Sub btnSHQM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSHQM.Click
            Me.doOpen_SHQM("btnSHQM")
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.doClose("btnClose")
        End Sub

        'zengxianglin 2009-12-26
        Private Sub btnBJYJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBJYJ.Click
            Me.doBJYJ("btnBJYJ")
        End Sub
        'zengxianglin 2009-12-26

    End Class

End Namespace