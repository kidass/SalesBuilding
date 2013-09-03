Imports System.Web.Security

Namespace Josco.JSOA.web

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.web
    ' ����    ��estate_rs_luyong_main
    ' 
    ' �������ʣ�
    '     �ɱ�����ģ����ã������������ģ��
    '
    ' ���������� 
    '   ������¼��������ģ��
    '
    ' �ӿڲ�����
    '     �μ��ӿ���IEstateRsLuyongMain����
    '----------------------------------------------------------------

    Partial Class estate_rs_luyong_main
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
        Private m_objSaveScence As Josco.JSOA.BusinessFacade.IMEstateRsLuyongMain
        Private m_blnSaveScence As Boolean

        '----------------------------------------------------------------
        'ģ��ӿڲ���
        '----------------------------------------------------------------
        Private m_objInterface As Josco.JSOA.BusinessFacade.IEstateRsLuyongMain
        Private m_blnInterface As Boolean

        '----------------------------------------------------------------
        '����������grdRSLYGL��صĲ���
        '----------------------------------------------------------------
        '������ģ�����еĿؼ�ID
        Private Const m_cstrCheckBoxIdInDataGrid_RSLYGL As String = "chkRSLYGL"
        '���������DIV����ID
        Private Const m_cstrDataGridInDIV_RSLYGL As String = "divRSLYGL"
        '����Ҫ����������
        Private m_intFixedColumns_RSLYGL As Integer

        '----------------------------------------------------------------
        'Ҫ���ʵ�����
        '----------------------------------------------------------------
        Private m_objDataSet_RSLYGL As Josco.JSOA.Common.Data.estateRenshiXingyeData
        Private m_strQuery_RSLYGL As String '��¼m_objDataSet_RSLYGL������
        Private m_intRows_RSLYGL As Integer '��¼m_objDataSet_RSLYGL��DefaultView��¼��

        '----------------------------------------------------------------
        '��������
        '----------------------------------------------------------------
        Private m_objsystemFlowObjectRenshiLuyong As Josco.JSOA.BusinessFacade.systemFlowObjectRenshiLuyong












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
                        Me.m_objInterface = CType(Session(strSessionId), Josco.JSOA.BusinessFacade.IEstateRsLuyongMain)
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
                If Me.m_objSaveScence Is Nothing Then Exit Try

                With Me.m_objSaveScence
                    Me.htxtRSLYGLQuery.Value = .htxtRSLYGLQuery
                    Me.htxtRSLYGLRows.Value = .htxtRSLYGLRows
                    Me.htxtRSLYGLSort.Value = .htxtRSLYGLSort
                    Me.htxtRSLYGLSortColumnIndex.Value = .htxtRSLYGLSortColumnIndex
                    Me.htxtRSLYGLSortType.Value = .htxtRSLYGLSortType

                    Me.htxtDivLeftBody.Value = .htxtDivLeftBody
                    Me.htxtDivTopBody.Value = .htxtDivTopBody
                    Me.htxtDivLeftRSLYGL.Value = .htxtDivLeftRSLYGL
                    Me.htxtDivTopRSLYGL.Value = .htxtDivTopRSLYGL

                    Me.htxtSessionIdQuery.Value = .htxtSessionIdQuery

                    Me.txtRSLYGLPageIndex.Text = .txtRSLYGLPageIndex
                    Me.txtRSLYGLPageSize.Text = .txtRSLYGLPageSize

                    Me.txtRSLYGLSearch_WJBT.Text = .txtRSLYGLSearch_WJBT
                    Me.txtRSLYGLSearch_JBRQMin.Text = .txtRSLYGLSearch_JBRQMin
                    Me.txtRSLYGLSearch_JBRQMax.Text = .txtRSLYGLSearch_JBRQMax
                    Me.txtRSLYGLSearch_QFRQMin.Text = .txtRSLYGLSearch_QFRQMin
                    Me.txtRSLYGLSearch_QFRQMax.Text = .txtRSLYGLSearch_QFRQMax
                    Me.ddlRSLYGLSearch_BLZT.SelectedIndex = .ddlRSLYGLSearch_BLZT_SelectedIndex

                    Try
                        Me.grdRSLYGL.PageSize = .grdRSLYGLPageSize
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdRSLYGL.CurrentPageIndex = .grdRSLYGLCurrentPageIndex
                    Catch ex As Exception
                    End Try
                    Try
                        Me.grdRSLYGL.SelectedIndex = .grdRSLYGLSelectedIndex
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
                If strSessionId = "" Then Exit Try

                '��������
                Me.m_objSaveScence = New Josco.JSOA.BusinessFacade.IMEstateRsLuyongMain

                '�����ֳ���Ϣ
                With Me.m_objSaveScence
                    .htxtRSLYGLQuery = Me.htxtRSLYGLQuery.Value
                    .htxtRSLYGLRows = Me.htxtRSLYGLRows.Value
                    .htxtRSLYGLSort = Me.htxtRSLYGLSort.Value
                    .htxtRSLYGLSortColumnIndex = Me.htxtRSLYGLSortColumnIndex.Value
                    .htxtRSLYGLSortType = Me.htxtRSLYGLSortType.Value

                    .htxtDivLeftBody = Me.htxtDivLeftBody.Value
                    .htxtDivTopBody = Me.htxtDivTopBody.Value
                    .htxtDivLeftRSLYGL = Me.htxtDivLeftRSLYGL.Value
                    .htxtDivTopRSLYGL = Me.htxtDivTopRSLYGL.Value

                    .htxtSessionIdQuery = Me.htxtSessionIdQuery.Value

                    .txtRSLYGLPageIndex = Me.txtRSLYGLPageIndex.Text
                    .txtRSLYGLPageSize = Me.txtRSLYGLPageSize.Text

                    .txtRSLYGLSearch_WJBT = Me.txtRSLYGLSearch_WJBT.Text
                    .txtRSLYGLSearch_JBRQMin = Me.txtRSLYGLSearch_JBRQMin.Text
                    .txtRSLYGLSearch_JBRQMax = Me.txtRSLYGLSearch_JBRQMax.Text
                    .txtRSLYGLSearch_QFRQMin = Me.txtRSLYGLSearch_QFRQMin.Text
                    .txtRSLYGLSearch_QFRQMax = Me.txtRSLYGLSearch_QFRQMax.Text
                    .ddlRSLYGLSearch_BLZT_SelectedIndex = Me.ddlRSLYGLSearch_BLZT.SelectedIndex

                    .grdRSLYGLPageSize = Me.grdRSLYGL.PageSize
                    .grdRSLYGLCurrentPageIndex = Me.grdRSLYGL.CurrentPageIndex
                    .grdRSLYGLSelectedIndex = Me.grdRSLYGL.SelectedIndex

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
                Dim objIEstateRsLuyongInfo As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo
                Try
                    objIEstateRsLuyongInfo = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo)
                Catch ex As Exception
                    objIEstateRsLuyongInfo = Nothing
                End Try
                If Not (objIEstateRsLuyongInfo Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo.SafeRelease(objIEstateRsLuyongInfo)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowCkdbqk As Josco.JSOA.BusinessFacade.IFlowCkdbqk
                Try
                    objIFlowCkdbqk = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowCkdbqk)
                Catch ex As Exception
                    objIFlowCkdbqk = Nothing
                End Try
                If Not (objIFlowCkdbqk Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowCkdbqk.SafeRelease(objIFlowCkdbqk)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowCkcbqk As Josco.JSOA.BusinessFacade.IFlowCkcbqk
                Try
                    objIFlowCkcbqk = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowCkcbqk)
                Catch ex As Exception
                    objIFlowCkcbqk = Nothing
                End Try
                If Not (objIFlowCkcbqk Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowCkcbqk.SafeRelease(objIFlowCkcbqk)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowByqk As Josco.JSOA.BusinessFacade.IFlowByqk
                Try
                    objIFlowByqk = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowByqk)
                Catch ex As Exception
                    objIFlowByqk = Nothing
                End Try
                If Not (objIFlowByqk Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowByqk.SafeRelease(objIFlowByqk)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowCzrz As Josco.JSOA.BusinessFacade.IFlowCzrz
                Try
                    objIFlowCzrz = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowCzrz)
                Catch ex As Exception
                    objIFlowCzrz = Nothing
                End Try
                If Not (objIFlowCzrz Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowCzrz.SafeRelease(objIFlowCzrz)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowSpyj As Josco.JSOA.BusinessFacade.IFlowSpyj
                Try
                    objIFlowSpyj = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowSpyj)
                Catch ex As Exception
                    objIFlowSpyj = Nothing
                End Try
                If Not (objIFlowSpyj Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowSpyj.SafeRelease(objIFlowSpyj)
                    Exit Try
                End If

                '==========================================================================================================================================================
                Dim objIFlowLzqk As Josco.JSOA.BusinessFacade.IFlowLzqk
                Try
                    objIFlowLzqk = CType(Session.Item(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId)), Josco.JSOA.BusinessFacade.IFlowLzqk)
                Catch ex As Exception
                    objIFlowLzqk = Nothing
                End Try
                If Not (objIFlowLzqk Is Nothing) Then
                    Session.Remove(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.OSessionId))
                    Josco.JSOA.BusinessFacade.IFlowLzqk.SafeRelease(objIFlowLzqk)
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
                        Dim objQueryData As Josco.JsKernal.Common.Data.QueryData = Nothing
                        Me.htxtRSLYGLQuery.Value = objISjcxCxtj.oQueryString
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
        ' ��ȡ�ӿڲ���
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
                    m_objInterface = CType(objTemp, Josco.JSOA.BusinessFacade.IEstateRsLuyongMain)
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

                '��ʼ��������
                If Me.doInitializeWorkflow(strErrMsg, "", False, Me.m_objsystemFlowObjectRenshiLuyong) = False Then
                    GoTo errProc
                End If

                '��ȡ�ָ��ֳ�����
                Me.m_blnSaveScence = False
                If Me.IsPostBack = False Then
                    Dim strSessionId As String
                    strSessionId = objPulicParameters.getObjectValue(Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId), "")
                    Try
                        Me.m_objSaveScence = CType(Session.Item(strSessionId), Josco.JSOA.BusinessFacade.IMEstateRsLuyongMain)
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
                Me.m_intFixedColumns_RSLYGL = objPulicParameters.getObjectValue(Me.htxtRSLYGLFixed.Value, 0)
                Me.m_intRows_RSLYGL = objPulicParameters.getObjectValue(Me.htxtRSLYGLRows.Value, 0)
                Me.m_strQuery_RSLYGL = Me.htxtRSLYGLQuery.Value

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
        ' ��ʼ������������
        '     strErrMsg                       �����ش�����Ϣ
        '     strWJBS                         ���ļ���ʶ
        '     blnFill                         ���������
        '     objsystemFlowObjectRenshiLuyong ������������
        ' ����
        '     True                            ���ɹ�
        '     False                           ��ʧ��
        '----------------------------------------------------------------
        Private Function doInitializeWorkflow( _
            ByRef strErrMsg As String, _
            ByVal strWJBS As String, _
            ByVal blnFill As Boolean, _
            ByRef objsystemFlowObjectRenshiLuyong As Josco.JSOA.BusinessFacade.systemFlowObjectRenshiLuyong) As Boolean

            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject = Nothing

            doInitializeWorkflow = False
            strErrMsg = ""

            Try
                '�ͷ�������Դ
                Josco.JSOA.BusinessFacade.systemFlowObjectRenshiLuyong.SafeRelease(objsystemFlowObjectRenshiLuyong)

                '��������������
                Dim strType As String = Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWCODE
                Dim strName As String = Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWNAME
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObjectRenshiLuyong.Create(strType, strName)

                '��ʼ��������
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, blnFill) = False Then
                    GoTo errProc
                End If

                '����
                objsystemFlowObjectRenshiLuyong = CType(objsystemFlowObject, Josco.JSOA.BusinessFacade.systemFlowObjectRenshiLuyong)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doInitializeWorkflow = True
            Exit Function
errProc:
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Exit Function

        End Function












        '----------------------------------------------------------------
        ' ��ȡgrdRSLYGL����������(Ĭ�ϱ�ǰ׺a.)
        '     strErrMsg      �����ش�����Ϣ
        '     strQuery       �����ص���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getQueryString_RSLYGL( _
            ByRef strErrMsg As String, _
            ByRef strQuery As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters

            getQueryString_RSLYGL = False
            strQuery = ""

            Try
                '�������⡱����
                Dim strWJBT As String
                strWJBT = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJBT
                If Me.txtRSLYGLSearch_WJBT.Text.Length > 0 Then Me.txtRSLYGLSearch_WJBT.Text = Me.txtRSLYGLSearch_WJBT.Text.Trim()
                If Me.txtRSLYGLSearch_WJBT.Text <> "" Then
                    Me.txtRSLYGLSearch_WJBT.Text = objPulicParameters.getNewSearchString(Me.txtRSLYGLSearch_WJBT.Text)
                    If strQuery = "" Then
                        strQuery = strWJBT + " like '" + Me.txtRSLYGLSearch_WJBT.Text + "%'"
                    Else
                        strQuery = strQuery + " and " + strWJBT + " like '" + Me.txtRSLYGLSearch_WJBT.Text + "%'"
                    End If
                End If

                '��������״̬������
                Dim strBLZT As String
                strBLZT = "a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_BLZT
                Select Case Me.ddlRSLYGLSearch_BLZT.SelectedIndex
                    Case Is > 0
                        If strQuery = "" Then
                            strQuery = strBLZT + " = '" + Me.ddlRSLYGLSearch_BLZT.SelectedValue + "'"
                        Else
                            strQuery = strQuery + " and " + strBLZT + " = '" + Me.ddlRSLYGLSearch_BLZT.SelectedValue + "'"
                        End If
                End Select

                Dim dateMin As System.DateTime
                Dim dateMax As System.DateTime

                '�����������ڡ�����
                Dim strJBRQ As String
                strJBRQ = "convert(varchar(10),a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JBRQ + ",120)"
                If Me.txtRSLYGLSearch_JBRQMin.Text.Length > 0 Then Me.txtRSLYGLSearch_JBRQMin.Text = Me.txtRSLYGLSearch_JBRQMin.Text.Trim()
                If Me.txtRSLYGLSearch_JBRQMax.Text.Length > 0 Then Me.txtRSLYGLSearch_JBRQMax.Text = Me.txtRSLYGLSearch_JBRQMax.Text.Trim()
                If Me.txtRSLYGLSearch_JBRQMin.Text <> "" And Me.txtRSLYGLSearch_JBRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtRSLYGLSearch_JBRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtRSLYGLSearch_JBRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtRSLYGLSearch_JBRQMin.Text = Format(dateMax, "yyyy-MM-dd")
                        Me.txtRSLYGLSearch_JBRQMax.Text = Format(dateMin, "yyyy-MM-dd")
                    Else
                        Me.txtRSLYGLSearch_JBRQMin.Text = Format(dateMin, "yyyy-MM-dd")
                        Me.txtRSLYGLSearch_JBRQMax.Text = Format(dateMax, "yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strJBRQ + " between '" + Me.txtRSLYGLSearch_JBRQMin.Text + "' and '" + Me.txtRSLYGLSearch_JBRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJBRQ + " between '" + Me.txtRSLYGLSearch_JBRQMin.Text + "' and '" + Me.txtRSLYGLSearch_JBRQMax.Text + "'"
                    End If
                ElseIf Me.txtRSLYGLSearch_JBRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtRSLYGLSearch_JBRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Me.txtRSLYGLSearch_JBRQMin.Text = Format(dateMin, "yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strJBRQ + " >= '" + Me.txtRSLYGLSearch_JBRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJBRQ + " >= '" + Me.txtRSLYGLSearch_JBRQMin.Text + "'"
                    End If
                ElseIf Me.txtRSLYGLSearch_JBRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtRSLYGLSearch_JBRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Me.txtRSLYGLSearch_JBRQMax.Text = Format(dateMax, "yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strJBRQ + " <= '" + Me.txtRSLYGLSearch_JBRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strJBRQ + " <= '" + Me.txtRSLYGLSearch_JBRQMax.Text + "'"
                    End If
                Else
                End If

                '����ǩ�����ڡ�����
                Dim strQFRQ As String
                strQFRQ = "convert(varchar(10),a." + Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_QFRQ + ",120)"
                If Me.txtRSLYGLSearch_QFRQMin.Text.Length > 0 Then Me.txtRSLYGLSearch_QFRQMin.Text = Me.txtRSLYGLSearch_QFRQMin.Text.Trim()
                If Me.txtRSLYGLSearch_QFRQMax.Text.Length > 0 Then Me.txtRSLYGLSearch_QFRQMax.Text = Me.txtRSLYGLSearch_QFRQMax.Text.Trim()
                If Me.txtRSLYGLSearch_QFRQMin.Text <> "" And Me.txtRSLYGLSearch_QFRQMax.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtRSLYGLSearch_QFRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Try
                        dateMax = CType(Me.txtRSLYGLSearch_QFRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    If dateMin > dateMax Then
                        Me.txtRSLYGLSearch_QFRQMin.Text = Format(dateMax, "yyyy-MM-dd")
                        Me.txtRSLYGLSearch_QFRQMax.Text = Format(dateMin, "yyyy-MM-dd")
                    Else
                        Me.txtRSLYGLSearch_QFRQMin.Text = Format(dateMin, "yyyy-MM-dd")
                        Me.txtRSLYGLSearch_QFRQMax.Text = Format(dateMax, "yyyy-MM-dd")
                    End If
                    If strQuery = "" Then
                        strQuery = strQFRQ + " between '" + Me.txtRSLYGLSearch_QFRQMin.Text + "' and '" + Me.txtRSLYGLSearch_QFRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strQFRQ + " between '" + Me.txtRSLYGLSearch_QFRQMin.Text + "' and '" + Me.txtRSLYGLSearch_QFRQMax.Text + "'"
                    End If
                ElseIf Me.txtRSLYGLSearch_QFRQMin.Text <> "" Then
                    Try
                        dateMin = CType(Me.txtRSLYGLSearch_QFRQMin.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Me.txtRSLYGLSearch_QFRQMin.Text = Format(dateMin, "yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strQFRQ + " >= '" + Me.txtRSLYGLSearch_QFRQMin.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strQFRQ + " >= '" + Me.txtRSLYGLSearch_QFRQMin.Text + "'"
                    End If
                ElseIf Me.txtRSLYGLSearch_QFRQMax.Text <> "" Then
                    Try
                        dateMax = CType(Me.txtRSLYGLSearch_QFRQMax.Text, System.DateTime)
                    Catch ex As Exception
                        strErrMsg = "������Ч�����ڣ�"
                        GoTo errProc
                    End Try
                    Me.txtRSLYGLSearch_QFRQMax.Text = Format(dateMax, "yyyy-MM-dd")
                    If strQuery = "" Then
                        strQuery = strQFRQ + " <= '" + Me.txtRSLYGLSearch_QFRQMax.Text + "'"
                    Else
                        strQuery = strQuery + " and " + strQFRQ + " <= '" + Me.txtRSLYGLSearch_QFRQMax.Text + "'"
                    End If
                Else
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            getQueryString_RSLYGL = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡgrdRSLYGLҪ��ʾ��������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        '     strWhere       ����������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function getModuleData_RSLYGL( _
            ByRef strErrMsg As String, _
            ByVal strWhere As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI

            getModuleData_RSLYGL = False

            Try
                '����Sort�ַ���
                Dim strSort As String
                strSort = Me.htxtRSLYGLSort.Value
                If strSort.Length > 0 Then strSort = strSort.Trim

                '�ͷ���Դ
                Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_RSLYGL)

                '���¼�������
                If Me.m_objsystemFlowObjectRenshiLuyong.getDataSet_Main(strErrMsg, MyBase.UserXM, strWhere, Me.m_objDataSet_RSLYGL) = False Then
                    GoTo errProc
                End If

                '�ָ�Sort�ַ���
                With Me.m_objDataSet_RSLYGL.Tables(strTable)
                    .DefaultView.Sort = strSort
                End With

                '�������
                With Me.m_objDataSet_RSLYGL.Tables(strTable)
                    Me.htxtRSLYGLRows.Value = .DefaultView.Count.ToString()
                    Me.m_intRows_RSLYGL = .DefaultView.Count
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getModuleData_RSLYGL = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ļ������������grdRSLYGL����
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function searchModuleData_RSLYGL(ByRef strErrMsg As String) As Boolean

            searchModuleData_RSLYGL = False

            Try
                '��ȡ�����ַ���
                Dim strQuery As String
                If Me.getQueryString_RSLYGL(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��������
                If Me.getModuleData_RSLYGL(strErrMsg, strQuery) = False Then
                    GoTo errProc
                End If

                '��¼�����ַ���
                Me.m_strQuery_RSLYGL = strQuery
                Me.htxtRSLYGLQuery.Value = Me.m_strQuery_RSLYGL

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            searchModuleData_RSLYGL = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdRSLYGL������
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showDataGridInfo_RSLYGL(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showDataGridInfo_RSLYGL = False

            '��ȡϵͳ�����������������
            Dim intSortColumnIndex As Integer
            intSortColumnIndex = objPulicParameters.getObjectValue(Me.htxtRSLYGLSortColumnIndex.Value, -1)
            Dim objSortType As Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType
            Try
                objSortType = CType(Me.htxtRSLYGLSortType.Value, Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType)
            Catch ex As Exception
                objSortType = Josco.JsKernal.Common.Utilities.PulicParameters.enumSortType.None
            End Try

            '������ʾ����
            Try
                '�ڻ�ȡ����ʱ�Ѿ��ָ���RowFilter��Sort���ֳ�
                '��������Դ
                If Me.m_objDataSet_RSLYGL Is Nothing Then
                    Me.grdRSLYGL.DataSource = Nothing
                Else
                    With Me.m_objDataSet_RSLYGL.Tables(strTable)
                        Me.grdRSLYGL.DataSource = .DefaultView
                    End With
                End If

                '�����������
                With Me.m_objDataSet_RSLYGL.Tables(strTable)
                    If objDataGridProcess.onBeforeDataGridBind(strErrMsg, Me.grdRSLYGL, .DefaultView.Count) = False Then
                        GoTo errProc
                    End If
                End With

                '�ָ��б����е�������Ϣ
                If intSortColumnIndex >= 0 Then
                    objDataGridProcess.doClearSortCharInDataGridHead(Me.grdRSLYGL)
                    With Me.grdRSLYGL.Columns(intSortColumnIndex)
                        .HeaderText = objDataGridProcess.getColumnSortHeadString(.HeaderText, objSortType)
                    End With
                End If

                '������
                Me.grdRSLYGL.DataBind()

                '----------------------------------------------------------------
                '��Ϊ��Щ��Ϣ�Ƿǰ󶨵ģ���������Ĳ�������Ȱ���ɺ�ִ�У�����
                'һ���ں���������ִ����DataBind������Ϣ�ᶪʧ������
                '----------------------------------------------------------------
                '�ָ������е�CheckBox״̬
                If objDataGridProcess.doRestoreDataGridCheckBoxStatus(strErrMsg, Me.grdRSLYGL, Request, 0, Me.m_cstrCheckBoxIdInDataGrid_RSLYGL) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showDataGridInfo_RSLYGL = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ʾgrdRSLYGL�������Ϣ
        '     strErrMsg      �����ش�����Ϣ
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function showModuleData_RSLYGL(ByRef strErrMsg As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI
            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            showModuleData_RSLYGL = False

            Try
                '��ʾ������Ϣ
                If Me.showDataGridInfo_RSLYGL(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ�����������صĲ�������Ϣ��ʾ
                With Me.m_objDataSet_RSLYGL.Tables(strTable).DefaultView
                    '��ʾ����λ����Ϣ
                    Me.lblRSLYGLGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdRSLYGL, .Count)

                    '��ʾҳ���������
                    Me.lnkCZRSLYGLMoveFirst.Enabled = objDataGridProcess.canDoMoveFirstPage(Me.grdRSLYGL, .Count)
                    Me.lnkCZRSLYGLMoveLast.Enabled = objDataGridProcess.canDoMoveLastPage(Me.grdRSLYGL, .Count)
                    Me.lnkCZRSLYGLMovePrev.Enabled = objDataGridProcess.canDoMovePreviousPage(Me.grdRSLYGL, .Count)
                    Me.lnkCZRSLYGLMoveNext.Enabled = objDataGridProcess.canDoMoveNextPage(Me.grdRSLYGL, .Count)

                    '��ʾ��ز���
                    Dim blnEnabled As Boolean
                    If .Count < 1 Then
                        blnEnabled = False
                    Else
                        blnEnabled = True
                    End If
                    Me.lnkCZRSLYGLDeSelectAll.Enabled = blnEnabled
                    Me.lnkCZRSLYGLSelectAll.Enabled = blnEnabled
                    Me.lnkCZRSLYGLGotoPage.Enabled = blnEnabled
                    Me.lnkCZRSLYGLSetPageSize.Enabled = blnEnabled
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            showModuleData_RSLYGL = True
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

                'ִ�м�ת��(�����Ƿ��ǡ��ط���)
                objControlProcess.doTranslateKey(Me.txtRSLYGLPageIndex)
                objControlProcess.doTranslateKey(Me.txtRSLYGLPageSize)
                '******************************************************************
                objControlProcess.doTranslateKey(Me.txtRSLYGLSearch_WJBT)
                objControlProcess.doTranslateKey(Me.txtRSLYGLSearch_JBRQMin)
                objControlProcess.doTranslateKey(Me.txtRSLYGLSearch_JBRQMax)
                objControlProcess.doTranslateKey(Me.txtRSLYGLSearch_QFRQMin)
                objControlProcess.doTranslateKey(Me.txtRSLYGLSearch_QFRQMax)
                objControlProcess.doTranslateKey(Me.ddlRSLYGLSearch_BLZT)

                '��ʾģ�鼶����
                If Me.showModuleData_MAIN(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��ʾ����
                If Me.m_blnSaveScence = False Then
                    Me.txtRSLYGLSearch_JBRQMin.Text = Now.Year.ToString + "-01-01"
                    Me.txtRSLYGLSearch_JBRQMax.Text = Now.Year.ToString + "-12-31"
                    If Me.searchModuleData_RSLYGL(strErrMsg) = False Then
                        GoTo errProc
                    End If
                Else
                    If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                        GoTo errProc
                    End If
                End If
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

            'Ԥ����
            If MyBase.doPagePreprocess(True, Me.IsPostBack And Me.m_blnSaveScence) = True Then
                Exit Sub
            End If

            '��ȡ�ӿڲ���
            Dim blnDo As Boolean
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

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Josco.JSOA.BusinessFacade.systemFlowObjectRenshiLuyong.SafeRelease(Me.m_objsystemFlowObjectRenshiLuyong)
            Josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(Me.m_objDataSet_RSLYGL)
        End Sub













        '----------------------------------------------------------------
        '�����¼�������
        '----------------------------------------------------------------
        'ʵ�ֶ�grdRSLYGL�����С��еĹ̶�
        Sub grdRSLYGL_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdRSLYGL.ItemDataBound

            Dim intCells As Integer
            Dim i As Integer

            Try
                If e.Item.ItemIndex < 0 Then
                    '������,�����������һ������
                    intCells = e.Item.Cells.Count
                    For i = 0 To intCells - 1 Step 1
                        e.Item.Cells(i).Attributes.CssStyle.Add("top", "expression(" + Me.m_cstrDataGridInDIV_RSLYGL + ".scrollTop)")
                    Next
                End If
                If Me.m_intFixedColumns_RSLYGL > 0 Then
                    '������
                    For i = 0 To Me.m_intFixedColumns_RSLYGL - 1 Step 1
                        e.Item.Cells(i).CssClass = Me.grdRSLYGL.ID + "Locked"
                    Next
                End If
            Catch ex As Exception
            End Try

        End Sub

        Private Sub grdRSLYGL_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdRSLYGL.ItemCommand

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��λ
                Me.grdRSLYGL.SelectedIndex = e.Item.ItemIndex

                '����
                Dim strControlId As String
                Select Case e.CommandName.ToUpper
                    Case "OpenDocument".ToUpper
                        strControlId = objDataGridProcess.getPostbackControlId(e.CommandSource)
                        If Me.doOpenFile(strErrMsg, strControlId) = False Then
                            GoTo errProc
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

        Private Sub grdRSLYGL_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRSLYGL.SelectedIndexChanged

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ʾ��¼λ��
                Me.lblRSLYGLGridLocInfo.Text = objDataGridProcess.getDataGridLocation(Me.grdRSLYGL, Me.m_intRows_RSLYGL)
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

        Private Sub grdRSLYGL_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdRSLYGL.SortCommand

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI
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
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If

                '��ȡԭ��������
                strOldCommand = Me.m_objDataSet_RSLYGL.Tables(strTable).DefaultView.Sort

                '��ȡҪִ�е���������
                objDataGridProcess.getColumnSortCommand(strErrMsg, strOldCommand, e.SortExpression, strFinalCommand, objenumSortType)
                If strErrMsg <> "" Then
                    GoTo errProc
                End If

                'ִ������
                Me.m_objDataSet_RSLYGL.Tables(strTable).DefaultView.Sort = strFinalCommand

                '��ȡ�����е�������
                objDataGridItem = CType(e.CommandSource, System.Web.UI.WebControls.DataGridItem)
                strUniqueId = Request.Form("__EVENTTARGET")
                intColumnIndex = objDataGridProcess.getColumnIndexByUniqueIdInRow(objDataGridItem, strUniqueId)

                '����������Ϣ
                Me.htxtRSLYGLSortColumnIndex.Value = intColumnIndex.ToString()
                Me.htxtRSLYGLSortType.Value = CType(objenumSortType, Integer).ToString()
                Me.htxtRSLYGLSort.Value = strFinalCommand

                '������ʾ����
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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












        Private Sub doMoveFirst_RSLYGL(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(0, Me.grdRSLYGL.PageCount)
                Me.grdRSLYGL.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

        Private Sub doMoveLast_RSLYGL(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRSLYGL.PageCount - 1, Me.grdRSLYGL.PageCount)
                Me.grdRSLYGL.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

        Private Sub doMoveNext_RSLYGL(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRSLYGL.CurrentPageIndex + 1, Me.grdRSLYGL.PageCount)
                Me.grdRSLYGL.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

        Private Sub doMovePrevious_RSLYGL(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim intPageIndex As Integer
            Try
                '��ȡ����
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                intPageIndex = objDataGridProcess.doMoveToPage(Me.grdRSLYGL.CurrentPageIndex - 1, Me.grdRSLYGL.PageCount)
                Me.grdRSLYGL.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

        Private Sub doGotoPage_RSLYGL(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageIndex As Integer
            intPageIndex = objPulicParameters.getObjectValue(Me.txtRSLYGLPageIndex.Text, 0)
            If intPageIndex <= 0 Then
                intPageIndex = 0
            Else
                intPageIndex -= 1
            End If

            Try
                '��ȡ����
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ
                Me.grdRSLYGL.CurrentPageIndex = intPageIndex

                'ˢ��������ʾ
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtRSLYGLPageIndex.Text = (Me.grdRSLYGL.CurrentPageIndex + 1).ToString()

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

        Private Sub doSetPageSize_RSLYGL(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            '��ȡ�µ�ҳ��С
            Dim intPageSize As Integer
            intPageSize = objPulicParameters.getObjectValue(Me.txtRSLYGLPageSize.Text, 100)
            If intPageSize <= 0 Then intPageSize = 100

            Try
                '��ȡ����
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If

                '�����µ�ҳ��С
                Me.grdRSLYGL.PageSize = intPageSize

                'ˢ��������ʾ
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
                    GoTo errProc
                End If

                '��Ϣͬ��
                Me.txtRSLYGLPageSize.Text = (Me.grdRSLYGL.PageSize).ToString()

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

        Private Sub doSelectAll_RSLYGL(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdRSLYGL, 0, Me.m_cstrCheckBoxIdInDataGrid_RSLYGL, True) = False Then
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

        Private Sub doDeSelectAll_RSLYGL(ByVal strControlId As String)

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                If objDataGridProcess.doCheckedDataGridCheckBox(strErrMsg, Me.grdRSLYGL, 0, Me.m_cstrCheckBoxIdInDataGrid_RSLYGL, False) = False Then
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

        Private Sub doSearch_RSLYGL(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��������
                If Me.searchModuleData_RSLYGL(strErrMsg) = False Then
                    GoTo errProc
                End If

                'ˢ��������ʾ
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

        Private Sub lnkCZRSLYGLMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLMoveFirst.Click
            Me.doMoveFirst_RSLYGL("lnkCZRSLYGLMoveFirst")
        End Sub

        Private Sub lnkCZRSLYGLMoveLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLMoveLast.Click
            Me.doMoveLast_RSLYGL("lnkCZRSLYGLMoveLast")
        End Sub

        Private Sub lnkCZRSLYGLMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLMoveNext.Click
            Me.doMoveNext_RSLYGL("lnkCZRSLYGLMoveNext")
        End Sub

        Private Sub lnkCZRSLYGLMovePrev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLMovePrev.Click
            Me.doMovePrevious_RSLYGL("lnkCZRSLYGLMovePrev")
        End Sub

        Private Sub lnkCZRSLYGLGotoPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLGotoPage.Click
            Me.doGotoPage_RSLYGL("lnkCZRSLYGLGotoPage")
        End Sub

        Private Sub lnkCZRSLYGLSetPageSize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLSetPageSize.Click
            Me.doSetPageSize_RSLYGL("lnkCZRSLYGLSetPageSize")
        End Sub

        Private Sub lnkCZRSLYGLSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLSelectAll.Click
            Me.doSelectAll_RSLYGL("lnkCZRSLYGLSelectAll")
        End Sub

        Private Sub lnkCZRSLYGLDeSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCZRSLYGLDeSelectAll.Click
            Me.doDeSelectAll_RSLYGL("lnkCZRSLYGLDeSelectAll")
        End Sub

        Private Sub btnRSLYGLSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRSLYGLSearch.Click
            Me.doSearch_RSLYGL("btnRSLYGLSearch")
        End Sub












        '----------------------------------------------------------------
        'ģ���������������
        '----------------------------------------------------------------
        Private Function doRefresh(ByRef strErrMsg As String) As Boolean

            doRefresh = False

            Try
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If
                If Me.showModuleData_RSLYGL(strErrMsg) = False Then
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

        Private Function doCreateWorkflow( _
            ByRef strErrMsg As String, _
            ByRef objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject) As Boolean

            Dim objDataGridProcess As New Josco.JsKernal.web.DataGridProcess

            doCreateWorkflow = False
            objsystemFlowObject = Nothing
            strErrMsg = ""

            Try
                '��鵱ǰѡ��
                If Me.grdRSLYGL.Items.Count < 1 Then
                    strErrMsg = "����û�е�ǰ�ļ���"
                    GoTo errProc
                End If
                If Me.grdRSLYGL.SelectedIndex < 0 Then
                    strErrMsg = "����û�е�ǰ�ļ���"
                    GoTo errProc
                End If

                '��ȡ�ļ���ʶ���ļ�����
                Dim intColIndex As Integer = -1
                Dim strWJBS As String = ""
                intColIndex = objDataGridProcess.getDataGridColumnIndex(Me.grdRSLYGL, Josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJBS)
                strWJBS = objDataGridProcess.getDataGridCellValue(Me.grdRSLYGL.Items(Me.grdRSLYGL.SelectedIndex), intColIndex)
                If strWJBS = "" Then
                    strErrMsg = "����û�е�ǰ�ļ���"
                    GoTo errProc
                End If

                '����ָ������������
                Dim strType As String = Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWCODE
                Dim strName As String = Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWNAME
                objsystemFlowObject = Josco.JSOA.BusinessFacade.systemFlowObjectRenshiLuyong.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, True) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)

            doCreateWorkflow = True
            Exit Function

errProc:
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.DataGridProcess.SafeRelease(objDataGridProcess)
            Exit Function

        End Function

        Private Sub doSearchFull(ByVal strControlId As String)

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim objISjcxCxtj As Josco.JsKernal.BusinessFacade.ISjcxCxtj
            Dim strNewSessionId As String
            Dim strSessionId As String

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI

            Try
                '��ȡ����
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
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
                    If Me.htxtSessionIdQuery.Value.Trim <> "" Then
                        .iDataSetTJ = CType(Session(Me.htxtSessionIdQuery.Value), Josco.JsKernal.Common.Data.QueryData)
                    Else
                        .iDataSetTJ = Nothing
                    End If
                    .iQueryTable = Me.m_objDataSet_RSLYGL.Tables(strTable)
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

        Private Sub doPrint(ByVal strControlId As String)

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Dim strTable As String = Josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject

            Try
                '��ȡ���ݼ�
                If Me.getModuleData_RSLYGL(strErrMsg, Me.m_strQuery_RSLYGL) = False Then
                    GoTo errProc
                End If
                If Me.m_objDataSet_RSLYGL.Tables(strTable) Is Nothing Then
                    strErrMsg = "���󣺻�δ��ȡ���ݣ�"
                    GoTo errProc
                End If
                With Me.m_objDataSet_RSLYGL.Tables(strTable)
                    If .Rows.Count < 1 Then
                        strErrMsg = "����û�����ݣ�"
                        GoTo errProc
                    End If
                End With

                '����ָ������������
                Dim strWJBS As String = ""
                Dim strType As String
                Dim strName As String
                strType = Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWBLLX
                strName = Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWNAME
                objsystemFlowObject = Josco.JsKernal.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, False) = False Then
                    GoTo errProc
                End If

                '���ģ���ļ�
                Dim strMBURL As String = Request.ApplicationPath + Me.m_cstrExcelMBRelativePathToAppRoot + "����_¼������һ����.xls"
                Dim strMBLOC As String = Server.MapPath(strMBURL)
                Dim blnFound As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strMBLOC, blnFound) = False Then
                    GoTo errProc
                End If
                If blnFound = False Then
                    strErrMsg = "����[" + strMBLOC + "]�����ڣ�"
                    GoTo errProc
                End If

                '����ģ���ļ�������Ŀ¼
                Dim strTempPath As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot
                Dim strTempFile As String
                strTempPath = Server.MapPath(strTempPath)
                If objBaseLocalFile.doCopyToTempFile(strErrMsg, strMBLOC, strTempPath, strTempFile) = False Then
                    GoTo errProc
                End If
                Dim strTempSpec As String
                strTempSpec = objBaseLocalFile.doMakePath(strTempPath, strTempFile)

                '�������
                If objsystemFlowObject.doExportToExcel(strErrMsg, Me.m_objDataSet_RSLYGL, strTempSpec) = False Then
                    GoTo errProc
                End If

                '��ʾExcel
                Dim strTempUrl As String = Request.ApplicationPath + Me.m_cstrPrintCacheRelativePathToAppRoot + strTempFile
                objMessageProcess.doOpenUrl(Me.popMessageObject, strTempUrl, "_blank", "titlebar=yes,menubar=yes,resizable=yes,scrollbars=yes,status=yes")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

errProc:
            objMessageProcess.doAlertMessage(Me.popMessageObject, strErrMsg)
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Sub

        End Sub

        '----------------------------------------------------------------
        ' �½��ļ�
        '     strErrMsg      �����ش�����Ϣ
        '     strControlId   ����ǰ�����ؼ�ID
        '     strFlowTypeName��Ҫ������������������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doNewFile( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal strFlowTypeName As String) As Boolean

            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject
            Dim strWJBS As String = ""

            Dim strRSessionId As String = ""
            Dim strMSessionId As String = ""
            Dim strISessionId As String = ""
            Dim strUrl As String

            doNewFile = False

            Try
                '����ָ������������
                Dim strType As String
                Dim strName As String
                strType = Josco.JsKernal.BusinessFacade.systemFlowObject.getFlowType(strFlowTypeName)
                strName = strFlowTypeName
                objsystemFlowObject = Josco.JsKernal.BusinessFacade.systemFlowObject.Create(strType, strName)
                If objsystemFlowObject.doInitialize(strErrMsg, MyBase.UserId, MyBase.UserPassword, strWJBS, False) = False Then
                    GoTo errProc
                End If

                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '��ȡUrl
                If Me.m_blnInterface = True Then
                    strISessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
                    If objsystemFlowObject.doFileNew( _
                        strErrMsg, _
                        strControlId, _
                        "", _
                        strMSessionId, _
                        strISessionId, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Request, Session, _
                        strUrl, _
                        strRSessionId) = False Then
                        GoTo errProc
                    End If
                Else
                    If objsystemFlowObject.doFileNew( _
                        strErrMsg, _
                        strControlId, _
                        "", _
                        strMSessionId, _
                        "", _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Request, Session, _
                        strUrl, _
                        strRSessionId) = False Then
                        GoTo errProc
                    End If
                End If
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)

            doNewFile = True
            Exit Function
errProc:
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
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
        Private Function doOpenFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject
            Dim strMSessionId As String = ""
            Dim strISessionId As String = ""
            Dim strUrl As String

            doOpenFile = False

            Try
                '����������
                Dim strWJBS As String
                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If
                strWJBS = objsystemFlowObject.FlowData.WJBS

                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '����Url
                If Me.m_blnInterface = True Then
                    strISessionId = Request.QueryString(Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId)
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
                Else
                    If objsystemFlowObject.doFileOpen( _
                        strErrMsg, _
                        strControlId, _
                        strWJBS, _
                        strMSessionId, _
                        "", _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eSelect, _
                        Request, Session, _
                        strUrl) = False Then
                        GoTo errProc
                    End If
                End If
                If strUrl <> "" Then
                    Response.Redirect(strUrl)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)

            doOpenFile = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ɾ���ļ�
        '     strErrMsg      �����ش�����Ϣ
        '     strControlId   ����ǰ�����ؼ�ID
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doDeleteFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject
            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim intStep As Integer

            doDeleteFile = False

            Try
                '����������
                Dim strWJBS As String
                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If
                strWJBS = objsystemFlowObject.FlowData.WJBS

                '�Ƿ���?
                Dim blnDo As Boolean
                If objsystemFlowObject.isFileSendOnce(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = True Then
                    If objsystemFlowObject.isFileZuofei(strErrMsg, blnDo) = False Then
                        GoTo errProc
                    End If
                    If blnDo = False Then
                        strErrMsg = "�����ļ��Ѿ����ͣ�����ɾ����"
                        GoTo errProc
                    End If

                    '�Ƿ��ʼ��
                    If objsystemFlowObject.isOriginalPeople(strErrMsg, MyBase.UserXM, blnDo) = False Then
                        GoTo errProc
                    End If
                    If blnDo = False Then
                        strErrMsg = "����ֻ�г�ʼ��������ɾ����"
                        GoTo errProc
                    End If
                End If

                'ѯ��
                intStep = 1
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    objMessageProcess.doConfirmMessage(Me.popMessageObject, "���棺һ��ɾ�����޷�������ȷ��Ҫɾ������/�񣩣�", strControlId, intStep)
                    Exit Try
                Else
                    objMessageProcess.doResetPopMessage(Me.popMessageObject)
                End If

                'ִ��ɾ������
                intStep = 2
                If objMessageProcess.isExecuteCode(Request, Me.popMessageObject.UniqueID, intStep) = True Then
                    'ִ�в���
                    If objsystemFlowObject.doDeleteFile(strErrMsg, MyBase.UserId, MyBase.UserPassword) = False Then
                        GoTo errProc
                    End If

                    '��¼���������־
                    If objsystemFlowObject.doWriteUserLog(strErrMsg, MyBase.UserId, MyBase.UserPassword, Request.UserHostAddress, Request.UserHostName, "ɾ�����ļ�[" + objsystemFlowObject.FlowData.WJBS + "]��[ȫ������]��") = False Then
                        '����
                    End If

                    'ˢ����ʾ
                    If Me.doRefresh(strErrMsg) = False Then
                        GoTo errProc
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)

            doDeleteFile = True
            Exit Function
errProc:
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �����ϼ�
        '     strErrMsg      �����ش�����Ϣ
        '     strControlId   ����ǰ�����ؼ�ID
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doClose(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strUrl As String

            doClose = False

            Try
                '���ص�����ģ�飬�����ӷ��ز���
                Dim strSessionId As String
                If Me.m_blnInterface = True Then
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
            doClose = True
            Exit Function

errProc:
            Josco.JsKernal.web.MessageProcess.SafeRelease(objMessageProcess)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �����������
        '     strErrMsg      �����ش�����Ϣ
        '     strControlId   ����ǰ�����ؼ�ID
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doQingchuBWTX(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject

            doQingchuBWTX = False

            Try
                '����������
                Dim strWJBS As String
                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If
                strWJBS = objsystemFlowObject.FlowData.WJBS

                '�������
                If objsystemFlowObject.doSetTaskBWTX(strErrMsg, MyBase.UserXM, False) = False Then
                    GoTo errProc
                End If

                'ˢ����ʾ
                If Me.doRefresh(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)

            doQingchuBWTX = True
            Exit Function
errProc:
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���ñ�������
        '     strErrMsg      �����ش�����Ϣ
        '     strControlId   ����ǰ�����ؼ�ID
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doSetBWTX(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject

            doSetBWTX = False

            Try
                '����������
                Dim strWJBS As String
                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If
                strWJBS = objsystemFlowObject.FlowData.WJBS

                '��������
                If objsystemFlowObject.doSetTaskBWTX(strErrMsg, MyBase.UserXM, True) = False Then
                    GoTo errProc
                End If

                'ˢ����ʾ
                If Me.doRefresh(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)

            doSetBWTX = True
            Exit Function
errProc:
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ˢ������
        '     strErrMsg      �����ش�����Ϣ
        '     strControlId   ����ǰ�����ؼ�ID
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doRefresh(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            doRefresh = False

            Try
                If Me.doRefresh(strErrMsg) = False Then
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

        Private Function doChakanSPYJ(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject

            doChakanSPYJ = False
            strErrMsg = ""

            Try
                '����������
                Dim strWJBS As String
                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If
                strWJBS = objsystemFlowObject.FlowData.WJBS

                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowSpyj As Josco.JSOA.BusinessFacade.IFlowSpyj
                Dim strUrl As String
                objIFlowSpyj = New Josco.JSOA.BusinessFacade.IFlowSpyj
                With objIFlowSpyj
                    .iFlowTypeName = objsystemFlowObject.FlowData.FlowTypeName
                    .iWJBS = objsystemFlowObject.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = False Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    Else
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
                    End If
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
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)

            doChakanSPYJ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Exit Function

        End Function

        Private Function doChakanLZQK(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject

            doChakanLZQK = False
            strErrMsg = ""

            Try
                '����������
                Dim strWJBS As String
                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If
                strWJBS = objsystemFlowObject.FlowData.WJBS

                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowLzqk As Josco.JSOA.BusinessFacade.IFlowLzqk
                Dim strUrl As String
                objIFlowLzqk = New Josco.JSOA.BusinessFacade.IFlowLzqk
                With objIFlowLzqk
                    .iFlowTypeName = objsystemFlowObject.FlowData.FlowTypeName
                    .iWJBS = objsystemFlowObject.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = False Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    Else
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
                    End If
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
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)

            doChakanLZQK = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Exit Function

        End Function

        Private Function doChakanBYQK(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject

            doChakanBYQK = False
            strErrMsg = ""

            Try
                '����������
                Dim strWJBS As String
                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If
                strWJBS = objsystemFlowObject.FlowData.WJBS

                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowByqk As Josco.JSOA.BusinessFacade.IFlowByqk
                Dim strUrl As String
                objIFlowByqk = New Josco.JSOA.BusinessFacade.IFlowByqk
                With objIFlowByqk
                    .iFlowTypeName = objsystemFlowObject.FlowData.FlowTypeName
                    .iWJBS = objsystemFlowObject.FlowData.WJBS
                    .iBLR = MyBase.UserXM
                    .iYjjhList = ""

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = False Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    Else
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
                    End If
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
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)

            doChakanBYQK = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Exit Function

        End Function

        Private Function doChakanCZRZ(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject

            doChakanCZRZ = False
            strErrMsg = ""

            Try
                '����������
                Dim strWJBS As String
                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If
                strWJBS = objsystemFlowObject.FlowData.WJBS

                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowCzrz As Josco.JSOA.BusinessFacade.IFlowCzrz
                Dim strUrl As String
                objIFlowCzrz = New Josco.JSOA.BusinessFacade.IFlowCzrz
                With objIFlowCzrz
                    .iFlowTypeName = objsystemFlowObject.FlowData.FlowTypeName
                    .iWJBS = objsystemFlowObject.FlowData.WJBS
                    .iBLR = MyBase.UserXM

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = False Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    Else
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
                    End If
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
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)

            doChakanCZRZ = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Exit Function

        End Function

        Private Function doChakanCBQK(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject

            doChakanCBQK = False
            strErrMsg = ""

            Try
                '����������
                Dim strWJBS As String
                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If
                strWJBS = objsystemFlowObject.FlowData.WJBS

                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowCkcbqk As Josco.JSOA.BusinessFacade.IFlowCkcbqk
                Dim strUrl As String
                objIFlowCkcbqk = New Josco.JSOA.BusinessFacade.IFlowCkcbqk
                With objIFlowCkcbqk
                    .iFlowTypeName = objsystemFlowObject.FlowData.FlowTypeName
                    .iWJBS = objsystemFlowObject.FlowData.WJBS

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = False Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    Else
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
                    End If
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
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)

            doChakanCBQK = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Exit Function

        End Function

        Private Function doChakanDBQK(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""
            Dim strMSessionId As String = ""

            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject

            doChakanDBQK = False
            strErrMsg = ""

            Try
                '����������
                Dim strWJBS As String
                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If
                strWJBS = objsystemFlowObject.FlowData.WJBS

                '�����ֳ�����
                strMSessionId = Me.saveModuleInformation()
                If strMSessionId = "" Then
                    strErrMsg = "���󣺲��ܱ����ֳ���Ϣ��"
                    GoTo errProc
                End If

                '׼�����ýӿ�
                Dim objIFlowCkdbqk As Josco.JSOA.BusinessFacade.IFlowCkdbqk
                Dim strUrl As String
                objIFlowCkdbqk = New Josco.JSOA.BusinessFacade.IFlowCkdbqk
                With objIFlowCkdbqk
                    .iFlowTypeName = objsystemFlowObject.FlowData.FlowTypeName
                    .iWJBS = objsystemFlowObject.FlowData.WJBS

                    .iSourceControlId = strControlId
                    If Me.m_blnInterface = False Then
                        strUrl = ""
                        strUrl += Request.Url.AbsolutePath
                        strUrl += "?"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    Else
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
                    End If
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
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)

            doChakanDBQK = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����ļ��༭����
        '     strErrMsg      �����ش�����Ϣ
        '     strControlId   ����ǰ�����ؼ�ID
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Private Function doUnlockFile(ByRef strErrMsg As String, ByVal strControlId As String) As Boolean

            Dim objsystemFlowObject As Josco.JsKernal.BusinessFacade.systemFlowObject

            doUnlockFile = False

            Try
                '����������
                Dim strWJBS As String
                If Me.doCreateWorkflow(strErrMsg, objsystemFlowObject) = False Then
                    GoTo errProc
                End If
                strWJBS = objsystemFlowObject.FlowData.WJBS

                '�������
                If objsystemFlowObject.doLockFile(strErrMsg, MyBase.UserId, False) = False Then
                    GoTo errProc
                End If

                'ˢ����ʾ
                If Me.doRefresh(strErrMsg) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)

            doUnlockFile = True
            Exit Function
errProc:
            Josco.JsKernal.BusinessFacade.systemFlowObject.SafeRelease(objsystemFlowObject)
            Exit Function

        End Function

        Private Sub lnkMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMenu.Click

            Dim objMessageProcess As New Josco.JsKernal.web.MessageProcess
            Dim strErrMsg As String

            Try
                '��ȡ����˵�
                Dim strMenuId As String = Me.htxtSelectMenuID.Value

                '����˵�����                
                Select Case strMenuId.ToUpper()
                    Case "mnuNew".ToUpper()
                        If Me.doNewFile(strErrMsg, "lnkMenu", Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWNAME) = False Then
                            GoTo errProc
                        End If
                    Case "mnuOpen".ToUpper()
                        If Me.doOpenFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuDelete".ToUpper()
                        If Me.doDeleteFile(strErrMsg, "lnkMenu") = False Then
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

                    Case "mnuRefresh".ToUpper()
                        If Me.doRefresh(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuUnlock".ToUpper()
                        If Me.doUnlockFile(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuPrint_QWJS".ToUpper()
                        Me.doSearchFull("lnkMenu")
                    Case "mnuPrint_DYQD".ToUpper()
                        Me.doPrint("lnkMenu")

                    Case "mnuBWTX_QCTX".ToUpper()
                        If Me.doQingchuBWTX(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If
                    Case "mnuBWTX_SZTX".ToUpper()
                        If Me.doSetBWTX(strErrMsg, "lnkMenu") = False Then
                            GoTo errProc
                        End If

                    Case "mnuClose".ToUpper()
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
