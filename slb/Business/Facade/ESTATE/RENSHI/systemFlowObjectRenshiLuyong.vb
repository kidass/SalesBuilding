'----------------------------------------------------------------
' Copyright (C) 2006-2016 Josco Software Corporation
' All rights reserved.
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation. See these other
' materials for detailed information regarding Microsoft code samples.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY 
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT 
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR 
' FITNESS FOR A PARTICULAR PURPOSE.
'----------------------------------------------------------------
Option Strict On
Option Explicit On 

Imports System
Imports System.Data
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic

Imports Josco.JsKernal.SystemFramework
Imports Josco.JsKernal.Common.Data
Imports Josco.JsKernal.BusinessRules

Namespace Josco.JSOA.BusinessFacade
    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��systemFlowObjectRenshiLuyong
    '
    ' ���������� 
    '   ������¼�������������ı��ֲ����
    ' ���ļ�¼��
    '     zengxianglin 2009-05-16 ����
    '----------------------------------------------------------------
    Public Class systemFlowObjectRenshiLuyong
        Inherits Josco.JsKernal.BusinessFacade.systemFlowObject

        'ģ������
        Private m_blnDRQP As Boolean        '����ǩ�����Ӽ�
        Private m_blnDRZS As Boolean        '����ǩ��ɨ���
        'zengxianglin 2009-05-16
        Private m_blnRYLY As Boolean        '��Ա¼�ô���
        'zengxianglin 2009-05-16

        'ģ�鸽����Ϣ
        Private m_blnQSYJ_SH As Boolean     '������
        Private m_blnQSYJ_HQ As Boolean     '��ǩ���
        Private m_blnQSYJ_FH As Boolean     '�������
        Private m_blnQSYJ_QF As Boolean     'ǩ�����









        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New(Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWCODE, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWNAME)

            m_blnDRQP = False
            m_blnDRZS = False
            'zengxianglin 2009-05-16
            m_blnRYLY = False
            'zengxianglin 2009-05-16

            m_blnQSYJ_SH = False
            m_blnQSYJ_HQ = False
            m_blnQSYJ_FH = False
            m_blnQSYJ_QF = False

        End Sub

        '----------------------------------------------------------------
        ' ��������
        '----------------------------------------------------------------
        Public Overloads Sub Dispose()
            MyBase.Dispose()
            Dispose(True)
        End Sub

        '----------------------------------------------------------------
        ' �ͷű�����Դ
        '----------------------------------------------------------------
        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            If (Not disposing) Then
                Exit Sub
            End If
        End Sub

        '----------------------------------------------------------------
        ' ��ȫ�ͷű�����Դ
        '----------------------------------------------------------------
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.systemFlowObjectRenshiLuyong)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        'zengxianglin 2009-05-16
        '----------------------------------------------------------------
        ' mlRYLY����
        '----------------------------------------------------------------
        Public ReadOnly Property mlRYLY() As Boolean
            Get
                mlRYLY = m_blnRYLY
            End Get
        End Property
        'zengxianglin 2009-05-16

        '----------------------------------------------------------------
        ' mlDRQP����
        '----------------------------------------------------------------
        Public ReadOnly Property mlDRQP() As Boolean
            Get
                mlDRQP = m_blnDRQP
            End Get
        End Property

        '----------------------------------------------------------------
        ' mlDRZS����
        '----------------------------------------------------------------
        Public ReadOnly Property mlDRZS() As Boolean
            Get
                mlDRZS = m_blnDRZS
            End Get
        End Property

        '----------------------------------------------------------------
        ' pmQSYJ_QF����
        '----------------------------------------------------------------
        Public ReadOnly Property pmQSYJ_QF() As Boolean
            Get
                pmQSYJ_QF = m_blnQSYJ_QF
            End Get
        End Property

        '----------------------------------------------------------------
        ' pmQSYJ_FH����
        '----------------------------------------------------------------
        Public ReadOnly Property pmQSYJ_FH() As Boolean
            Get
                pmQSYJ_FH = m_blnQSYJ_FH
            End Get
        End Property

        '----------------------------------------------------------------
        ' pmQSYJ_HQ����
        '----------------------------------------------------------------
        Public ReadOnly Property pmQSYJ_HQ() As Boolean
            Get
                pmQSYJ_HQ = m_blnQSYJ_HQ
            End Get
        End Property

        '----------------------------------------------------------------
        ' pmQSYJ_SH����
        '----------------------------------------------------------------
        Public ReadOnly Property pmQSYJ_SH() As Boolean
            Get
                pmQSYJ_SH = m_blnQSYJ_SH
            End Get
        End Property













        '----------------------------------------------------------------
        ' ��ȡ�������ļ�Ŀǰ�ܽ��е�����
        '     strErrMsg      �����ش�����Ϣ
        '     objTask        �������ܽ��е�����
        ' ���� 
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function getCanDoTaskList( _
            ByRef strErrMsg As String, _
            ByRef objTask As System.Collections.Specialized.NameValueCollection) As Boolean

            getCanDoTaskList = False
            strErrMsg = ""
            objTask = Nothing

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[getCanDoTaskList]����������δ��ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "����[getCanDoTaskList]����������δ������ݣ�����ʹ�ã�"
                    GoTo errProc
                End If

                '��������
                objTask = New System.Collections.Specialized.NameValueCollection

                '�����ļ�״̬����
                Dim objBaseFlowRenshiLuyong As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                Select Case objBaseFlowRenshiLuyong.BLZT
                    Case objBaseFlowRenshiLuyong.FILESTATUS_YQP
                        objTask.Add(objBaseFlowRenshiLuyong.TASK_LDCL, objBaseFlowRenshiLuyong.TASK_LDCL)
                        objTask.Add(objBaseFlowRenshiLuyong.TASK_XGCL, objBaseFlowRenshiLuyong.TASK_XGCL)
                        objTask.Add(objBaseFlowRenshiLuyong.TASK_GJBJ, objBaseFlowRenshiLuyong.TASK_GJBJ)
                        objTask.Add(objBaseFlowRenshiLuyong.TASK_WJGD, objBaseFlowRenshiLuyong.TASK_WJGD)

                    Case Else
                        objTask.Add(objBaseFlowRenshiLuyong.TASK_LDCL, objBaseFlowRenshiLuyong.TASK_LDCL)
                        objTask.Add(objBaseFlowRenshiLuyong.TASK_XGCL, objBaseFlowRenshiLuyong.TASK_XGCL)
                        objTask.Add(objBaseFlowRenshiLuyong.TASK_GJBJ, objBaseFlowRenshiLuyong.TASK_GJBJ)
                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getCanDoTaskList = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ָ���ļ��Ĺ�����ģ��
        ' ׼�����������ýӿڲ�����Ҫ���ʹ�������Url
        '     strErrMsg      �����ش�����Ϣ
        '     strControlId   ����ǰ�������ID
        '     strWJBS        ���ļ���ʶ
        '     strMSessionId  �����ñ�������ģ��ĸ�ģ���MSessionId
        '     strISessionId  �����ñ�������ģ��ĸ�ģ���ISessionId
        '     objEditType    ���������༭����
        '     Request        ����ǰHttpRequest
        '     Session        ����ǰHttpSessionState
        '     strUrl         ������Ҫ�򿪹������ļ���Url
        ' ���� 
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doFileOpen( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal strWJBS As String, _
            ByVal strMSessionId As String, _
            ByVal strISessionId As String, _
            ByVal objEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal Request As System.Web.HttpRequest, _
            ByVal Session As System.Web.SessionState.HttpSessionState, _
            ByRef strUrl As String) As Boolean

            Dim objIEstateRsLuyongInfo As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String = ""

            doFileOpen = False
            strErrMsg = ""
            strUrl = ""

            Try
                '������
                If Request Is Nothing Then
                    strErrMsg = "����[doFileOpen]δ����HTTP�������"
                    GoTo errProc
                End If
                If Session Is Nothing Then
                    strErrMsg = "����[doFileOpen]δ����HTTP�Ự����"
                    GoTo errProc
                End If
                If strWJBS Is Nothing Then strWJBS = ""
                strWJBS = strWJBS.Trim
                If strWJBS = "" Then
                    strErrMsg = "����[doFileOpen]δָ��Ҫ�򿪵��ļ���"
                    GoTo errProc
                End If
                If strControlId Is Nothing Then strControlId = ""
                strControlId = strControlId.Trim
                If strMSessionId Is Nothing Then strMSessionId = ""
                strMSessionId = strMSessionId.Trim
                If strISessionId Is Nothing Then strISessionId = ""
                strISessionId = strISessionId.Trim

                '׼�����ýӿ�
                objIEstateRsLuyongInfo = New Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo
                With objIEstateRsLuyongInfo
                    .iEditMode = objEditType
                    .iWJBS = strWJBS

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    If strISessionId = "" Then
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    Else
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += strISessionId
                        strUrl += "&"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    End If
                    .iReturnUrl = strUrl
                End With

                '����ӿ�
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateRsLuyongInfo)

                '����Url
                strUrl = ""
                strUrl += Request.ApplicationPath + Me.getPageUrl()
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFileOpen = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo.SafeRelease(objIEstateRsLuyongInfo)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���½��ļ��Ĺ�����ģ��
        ' ׼�����������ýӿڲ�����Ҫ���ʹ�������Url
        '     strErrMsg      �����ش�����Ϣ
        '     strControlId   ����ǰ�������ID
        '     strWJBS        ���ļ���ʶ=""
        '     strMSessionId  �����ñ�������ģ��ĸ�ģ���MSessionId
        '     strISessionId  �����ñ�������ģ��ĸ�ģ���ISessionId
        '     objEditType    ���������༭����
        '     Request        ����ǰHttpRequest
        '     Session        ����ǰHttpSessionState
        '     strUrl         ������Ҫ�򿪹������ļ���Url
        '     strRSessionId  �������´����ĻỰID
        ' ���� 
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doFileNew( _
            ByRef strErrMsg As String, _
            ByVal strControlId As String, _
            ByVal strWJBS As String, _
            ByVal strMSessionId As String, _
            ByVal strISessionId As String, _
            ByVal objEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal Request As System.Web.HttpRequest, _
            ByVal Session As System.Web.SessionState.HttpSessionState, _
            ByRef strUrl As String, _
            ByRef strRSessionId As String) As Boolean

            Dim objIEstateRsLuyongInfo As Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim strNewSessionId As String

            doFileNew = False
            strRSessionId = ""
            strErrMsg = ""
            strUrl = ""

            Try
                '������
                If Request Is Nothing Then
                    strErrMsg = "����δ����HTTP�������"
                    GoTo errProc
                End If
                If Session Is Nothing Then
                    strErrMsg = "����δ����HTTP�Ự����"
                    GoTo errProc
                End If
                If strControlId Is Nothing Then strControlId = ""
                strControlId = strControlId.Trim
                If strWJBS Is Nothing Then strWJBS = ""
                strWJBS = strWJBS.Trim
                If strMSessionId Is Nothing Then strMSessionId = ""
                strMSessionId = strMSessionId.Trim
                If strISessionId Is Nothing Then strISessionId = ""
                strISessionId = strISessionId.Trim

                '׼�����ýӿ�
                objIEstateRsLuyongInfo = New Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo
                With objIEstateRsLuyongInfo
                    .iEditMode = objEditType
                    .iWJBS = strWJBS

                    .iSourceControlId = strControlId
                    strUrl = ""
                    strUrl += Request.Url.AbsolutePath
                    strUrl += "?"
                    If strISessionId = "" Then
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    Else
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                        strUrl += "="
                        strUrl += strISessionId
                        strUrl += "&"
                        strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.MSessionId
                        strUrl += "="
                        strUrl += strMSessionId
                    End If
                    .iReturnUrl = strUrl
                End With

                '����ӿ�
                strNewSessionId = objPulicParameters.getNewGuid()
                If strNewSessionId = "" Then
                    strErrMsg = "���󣺲��ܳ�ʼ�����ýӿڣ�"
                    GoTo errProc
                End If
                Session.Add(strNewSessionId, objIEstateRsLuyongInfo)

                '����Url
                strUrl = ""
                strUrl += Request.ApplicationPath + Me.getPageUrl()
                strUrl += "?"
                strUrl += Josco.JsKernal.Common.Utilities.PulicParameters.ISessionId
                strUrl += "="
                strUrl += strNewSessionId

                strRSessionId = strNewSessionId

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFileNew = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.BusinessFacade.IEstateRsLuyongInfo.SafeRelease(objIEstateRsLuyongInfo)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡ��ǰ��������webҳ��Url(���Ӧ�õĸ�·��)
        ' ����
        '                    ����ǰ��������webҳ��Url
        '----------------------------------------------------------------
        Public Overrides Function getPageUrl() As String
            getPageUrl = "/secure/estate/renshi/estate_rs_luyong_info.aspx"
        End Function

        '----------------------------------------------------------------
        ' ����ɶԵ�ǰ�ļ����еĲ���
        '     strErrMsg      �����ش�����Ϣ
        '     strCzyId       ����ǰ�û�����
        '     strUserXM      ����ǰ�û�����
        '     strUserBMDM    ����ǰ�û���λ����
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function getCanExecuteCommand( _
            ByRef strErrMsg As String, _
            ByVal strCzyId As String, _
            ByVal strUserXM As String, _
            ByVal strUserBMDM As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objJiaojieDataWWC As Josco.JsKernal.Common.Data.FlowData

            Dim strSep As String = Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
            Dim objBaseFlowRenshiLuyong As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
            Dim blnEditMode As Boolean = False
            Dim blnDo As Boolean

            getCanExecuteCommand = False

            Try
                '��������ʼ��
                objBaseFlowRenshiLuyong = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                Dim strWJBS As String = objBaseFlowRenshiLuyong.WJBS
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim()
                If strCzyId Is Nothing Then strCzyId = ""
                strCzyId = strCzyId.Trim()
                If strUserBMDM Is Nothing Then strUserBMDM = ""
                strUserBMDM = strUserBMDM.Trim()
                Dim objrulesFlowObjectRenshiLuyong As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong = Nothing
                objrulesFlowObjectRenshiLuyong = CType(Me.m_objrulesFlowObject, Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong)

                '
                '�����ļ�Ӱ��Ĳ���
                '
                'ˢ���ļ�
                Me.m_blnSXWJ = Not blnEditMode
                '�����ϼ�
                Me.m_blnFHSJ = Not blnEditMode

                '
                'û���ļ�
                '
                If strWJBS = "" Then
                    Exit Try
                End If

                '
                '�ļ������ϣ�
                '
                If Me.isFileZuofei(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = True Then
                    '�ɴ�ӡ
                    Me.m_blnDYGZ = Not blnEditMode
                    Me.m_blnDYBJ = Not blnEditMode
                    '�ɲ鿴�ļ������Ϣ
                    Me.m_blnCYYJ = Not blnEditMode
                    Me.m_blnCKLZ = Not blnEditMode
                    Me.m_blnCKRZ = Not blnEditMode
                    Me.m_blnCKBY = Not blnEditMode
                    Me.m_blnCKCB = Not blnEditMode
                    Me.m_blnCKDB = Not blnEditMode
                    '����˿���������
                    If Me.isOriginalPeople(strErrMsg, strUserXM, blnDo) = False Then
                        GoTo errProc
                    End If
                    Me.m_blnQYWJ = Not blnEditMode And blnDo
                    Exit Try
                End If

                '
                '�ļ����������ꣿ
                '
                If Me.isFileComplete(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = True Then
                    '�ɴ�ӡ
                    Me.m_blnDYGZ = Not blnEditMode
                    Me.m_blnDYBJ = Not blnEditMode
                    '�ɲ鿴�ļ������Ϣ
                    Me.m_blnCYYJ = Not blnEditMode
                    Me.m_blnCKLZ = Not blnEditMode
                    Me.m_blnCKRZ = Not blnEditMode
                    Me.m_blnCKBY = Not blnEditMode
                    Me.m_blnCKCB = Not blnEditMode
                    Me.m_blnCKDB = Not blnEditMode
                    '���Բ���
                    Me.m_blnWJBY = Not blnEditMode
                    '���Դ���δ���֪ͨ����Ϣ
                    If Me.isHasNotCompleteTongzhi(strErrMsg, strUserXM, blnDo) = False Then
                        GoTo errProc
                    End If
                    Me.m_blnWYYZ = Not blnEditMode And blnDo
                    Exit Try
                End If

                '
                '��ǰ�ļ��Ƿ��͹���
                '
                If Me.isFileSendOnce(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = False Then
                    '�ɴ�ӡ
                    Me.m_blnDYGZ = Not blnEditMode
                    Me.m_blnDYBJ = Not blnEditMode
                    '���Բ���
                    Me.m_blnWJBY = Not blnEditMode
                    '���Է���
                    Me.m_blnFSWJ = Not blnEditMode
                    '�����޸�
                    Me.m_blnXGWJ = Not blnEditMode
                    '���Դ���δ���֪ͨ����Ϣ
                    If Me.isHasNotCompleteTongzhi(strErrMsg, strUserXM, blnDo) = False Then
                        GoTo errProc
                    End If
                    Me.m_blnWYYZ = Not blnEditMode And blnDo
                    Exit Try
                End If

                '
                '������ת�ļ�
                '
                '
                '�Ƿ��Զ������ļ���
                '
                If Me.isAutoReceive(strErrMsg, strUserXM, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = True Then
                    '�Զ������ļ�
                    If Me.doAutoReceive(strErrMsg, strUserXM) = False Then
                        GoTo errProc
                    End If
                End If

                '���Դ���δ���֪ͨ����Ϣ
                If Me.isHasNotCompleteTongzhi(strErrMsg, strUserXM, blnDo) = False Then
                    GoTo errProc
                End If
                Me.m_blnWYYZ = Not blnEditMode And blnDo

                '
                '�Ƿ���δ��������ˣ�(��֪ͨ������)
                '
                If Me.getNotCompletedTaskData(strErrMsg, strUserXM, objJiaojieDataWWC) = False Then
                    GoTo errProc
                End If

                '
                '�Ƿ���δ���յ����ˣ�
                '
                Dim strTaskStatusWJS As String = objBaseFlowRenshiLuyong.TASKSTATUS_WJS
                With objJiaojieDataWWC.Tables(Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_JIAOJIE)
                    .DefaultView.RowFilter = Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZT + " = '" + strTaskStatusWJS + "'"
                    If .DefaultView.Count > 0 Then
                        '����δ���յ����ˣ������Ƚ����ļ����ܼ�������
                        Me.m_blnJSWJ = Not blnEditMode
                        Me.m_blnMustJieshou = Not blnEditMode
                    End If
                    '��ԭ����
                    .DefaultView.RowFilter = ""
                End With

                '
                '������ת�ļ���һ���ִ�еĲ���
                '
                '�ɴ�ӡ
                Me.m_blnDYGZ = Not blnEditMode
                Me.m_blnDYBJ = Not blnEditMode
                '�ɲ鿴�ļ������Ϣ
                Me.m_blnCYYJ = Not blnEditMode
                Me.m_blnCKLZ = Not blnEditMode
                Me.m_blnCKRZ = Not blnEditMode
                Me.m_blnCKBY = Not blnEditMode
                Me.m_blnCKCB = Not blnEditMode
                Me.m_blnCKDB = Not blnEditMode
                '���Բ���
                Me.m_blnWJBY = Not blnEditMode

                '�ļ��Ƿ�ͣ�죿
                If Me.isFileTingban(strErrMsg, blnDo) = False Then
                    GoTo errProc
                End If
                If blnDo = True Then
                    '�ļ�ͣ��
                    With objJiaojieDataWWC.Tables(Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_JIAOJIE)
                        .DefaultView.RowFilter = Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZT + " = '" + Me.FlowData.TASKSTATUS_YTB + "'"
                        If .Rows.Count > 0 Then
                            '���ԡ���������
                            Me.m_blnJXBL = True
                            Exit Try
                        Else
                            '���ü����жϣ�
                            Exit Try
                        End If
                    End With
                End If

                '
                '������д��������
                '
                If Me.canWriteDubanResult(strErrMsg, strUserXM, blnDo) = False Then
                    GoTo errProc
                End If
                Me.m_blnDBJG = Not blnEditMode And blnDo

                '
                '���Բ����쵼�����(Ҳ���޸��ļ�)
                '
                If Me.canBuDengFile(strErrMsg, strCzyId, strUserBMDM, blnDo) = False Then
                    GoTo errProc
                End If
                Me.m_blnBDPS = Not blnEditMode And blnDo
                If Me.m_blnBDPS = True Then
                    Me.m_blnXGWJ = Me.m_blnBDPS
                End If

                '
                '���Զ��죿
                '
                If Me.canDubanFile(strErrMsg, strCzyId, strUserBMDM, blnDo) = False Then
                    GoTo errProc
                End If
                Me.m_blnDBWJ = Not blnEditMode And blnDo

                '
                '���Դ߰��ļ���(Ҳ���ջ��ļ�)
                '
                If Me.canCuibanFile(strErrMsg, strUserXM, blnDo) = False Then
                    GoTo errProc
                End If
                Me.m_blnCBWJ = Not blnEditMode And blnDo
                Me.m_blnSHWJ = Me.m_blnCBWJ

                'ȫ�����ꣿ
                With objJiaojieDataWWC.Tables(Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_JIAOJIE)
                    If .Rows.Count < 1 Then
                        'ȫ�����꣡
                        Exit Try
                    End If
                End With

                '�Ƿ���չ��ļ���
                With objJiaojieDataWWC.Tables(Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_JIAOJIE)
                    .DefaultView.RowFilter = Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZT + " = '" + strTaskStatusWJS + "'"
                    If .DefaultView.Count < 1 Then
                        'û��δ���գ����ܽ����ļ�
                        Me.m_blnJSWJ = blnEditMode
                    Else
                        '��δ���գ�
                        .DefaultView.RowFilter = Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZT + " <> '" + strTaskStatusWJS + "'"
                        If .DefaultView.Count < 1 Then
                            'ȫ��δ���գ������Ƚ����ļ���
                            Me.m_blnJSWJ = Not blnEditMode
                            Me.m_blnMustJieshou = Not blnEditMode
                            Exit Try
                        Else
                            '���Խ����ļ�
                            Me.m_blnJSWJ = Not blnEditMode
                        End If
                    End If
                    '��ȡ�ѽ��յ����ˣ�
                    .DefaultView.RowFilter = Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZT + " <> '" + strTaskStatusWJS + "'"
                End With
                'ͨ�ò��������Ѱ���
                Me.m_blnBLWB = Not blnEditMode

                '����δ�������жϿ�ִ�еĲ���
                Dim strBLZL As String
                Dim strJJBS As String
                Dim intCount As Integer
                Dim i As Integer
                With objJiaojieDataWWC.Tables(Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_JIAOJIE).DefaultView
                    intCount = .Count
                    For i = 0 To intCount - 1 Step 1
                        strJJBS = objPulicParameters.getObjectValue(.Item(i).Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_JJBS), "")
                        strBLZL = objPulicParameters.getObjectValue(.Item(i).Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_JIAOJIE_BLZL), "")

                        If Me.isTaskTuihui(strJJBS) = True Then
                            '�˻صģ����ð��������ļ�
                            Me.m_blnBYBL = Not blnEditMode
                            Me.m_blnZFWJ = Not blnEditMode
                        End If
                        If Me.isTaskShouhui(strJJBS) = True Then
                            '�ջصģ����ð��������ļ�
                            Me.m_blnBYBL = Not blnEditMode
                            Me.m_blnZFWJ = Not blnEditMode
                        End If
                        If Me.isTaskTongzhi(strJJBS) = True Then
                            '֪ͨ�����ˣ�������֪
                            Me.m_blnWYYZ = Not blnEditMode
                        End If

                        '��������ֹͣ����
                        Select Case objBaseFlowRenshiLuyong.BLZT
                            Case objBaseFlowRenshiLuyong.FILESTATUS_YTB
                                '��ִ�У���������
                                Me.m_blnJXBL = Not blnEditMode
                            Case objBaseFlowRenshiLuyong.FILESTATUS_YQP
                                '���ܣ�ֹͣ����
                            Case Else
                                Dim strTaskBYSYList As String = objBaseFlowRenshiLuyong.TaskBlzlBYSYList
                                Dim strTask As String = "'" + strBLZL + "'"
                                If strTaskBYSYList.IndexOf(strTask) >= 0 Then
                                Else
                                    '��ִ�У�ֹͣ����
                                    Me.m_blnZHBL = Not blnEditMode
                                End If
                        End Select

                        '���������ж�
                        Select Case strBLZL
                            Case objBaseFlowRenshiLuyong.TASK_CYCG, objBaseFlowRenshiLuyong.TASK_GJBJ
                                '�����ļ�
                                Me.m_blnFSWJ = Not blnEditMode
                                '�޸��ļ�
                                Me.m_blnXGWJ = Not blnEditMode
                                '��ǩ����
                                If objBaseFlowRenshiLuyong.QFR <> "" Then
                                    '����ˣ�
                                    If Me.isOriginalPeople(strErrMsg, strUserXM, blnDo) = False Then
                                        GoTo errProc
                                    End If
                                    If blnDo = True Then
                                        '�ļ����
                                        Me.m_blnWJBJ = Not blnEditMode
                                    End If
                                End If

                            Case objBaseFlowRenshiLuyong.TASK_SHWJ
                                '�����ļ�
                                Me.m_blnFSWJ = Not blnEditMode
                                '�޸��ļ�
                                Me.m_blnXGWJ = Not blnEditMode
                                '��д���
                                Me.m_blnTXYJ = Not blnEditMode
                                Me.m_blnQSYJ_SH = Not blnEditMode
                                '�˻��ļ�
                                Me.m_blnTHWJ = Not blnEditMode

                            Case objBaseFlowRenshiLuyong.TASK_HQWJ
                                '�����ļ�
                                Me.m_blnFSWJ = Not blnEditMode
                                '�޸��ļ�
                                Me.m_blnXGWJ = Not blnEditMode
                                '��д���
                                Me.m_blnTXYJ = Not blnEditMode
                                Me.m_blnQSYJ_HQ = Not blnEditMode
                                '�˻��ļ�
                                Me.m_blnTHWJ = Not blnEditMode

                            Case objBaseFlowRenshiLuyong.TASK_FHWJ
                                '�����ļ�
                                Me.m_blnFSWJ = Not blnEditMode
                                '�޸��ļ�
                                Me.m_blnXGWJ = Not blnEditMode
                                '��д���
                                Me.m_blnTXYJ = Not blnEditMode
                                Me.m_blnQSYJ_FH = Not blnEditMode
                                '�˻��ļ�
                                Me.m_blnTHWJ = Not blnEditMode

                            Case objBaseFlowRenshiLuyong.TASK_QFWJ
                                '�����ļ�
                                Me.m_blnFSWJ = Not blnEditMode
                                '�޸��ļ�
                                Me.m_blnXGWJ = Not blnEditMode
                                '��д���
                                Me.m_blnTXYJ = Not blnEditMode
                                Me.m_blnQSYJ_QF = Not blnEditMode
                                '�˻��ļ�
                                Me.m_blnTHWJ = Not blnEditMode

                            Case objBaseFlowRenshiLuyong.TASK_XGCL
                                '�����ļ�
                                Me.m_blnFSWJ = Not blnEditMode
                                '�޸��ļ�
                                Me.m_blnXGWJ = Not blnEditMode
                                '��д���
                                Me.m_blnTXYJ = Not blnEditMode
                                Me.m_blnQSYJ_QF = Not blnEditMode
                                Me.m_blnQSYJ_FH = Not blnEditMode
                                Me.m_blnQSYJ_HQ = Not blnEditMode
                                Me.m_blnQSYJ_SH = Not blnEditMode
                                '�˻��ļ�
                                Me.m_blnTHWJ = Not blnEditMode
                                '��ǩ����
                                If objBaseFlowRenshiLuyong.QFR <> "" Then
                                    '����ˣ�
                                    If Me.isOriginalPeople(strErrMsg, strUserXM, blnDo) = False Then
                                        GoTo errProc
                                    End If
                                    If blnDo = True Then
                                        '�ļ����
                                        Me.m_blnWJBJ = Not blnEditMode
                                    End If
                                End If

                            Case objBaseFlowRenshiLuyong.TASK_LDCL
                                '�����ļ�
                                Me.m_blnFSWJ = Not blnEditMode
                                '�޸��ļ�
                                Me.m_blnXGWJ = Not blnEditMode
                                '��д���
                                Me.m_blnTXYJ = Not blnEditMode
                                Me.m_blnQSYJ_QF = Not blnEditMode
                                Me.m_blnQSYJ_FH = Not blnEditMode
                                Me.m_blnQSYJ_HQ = Not blnEditMode
                                Me.m_blnQSYJ_SH = Not blnEditMode
                                '�˻��ļ�
                                Me.m_blnTHWJ = Not blnEditMode

                            Case objBaseFlowRenshiLuyong.TASK_MSCL, objBaseFlowRenshiLuyong.TASK_SMCL
                                '�����ļ�
                                Me.m_blnFSWJ = Not blnEditMode
                                '�˻��ļ�
                                Me.m_blnTHWJ = Not blnEditMode

                            Case objBaseFlowRenshiLuyong.TASK_WJGD
                                '�����ļ�
                                Me.m_blnFSWJ = Not blnEditMode
                                '�˻��ļ�
                                Me.m_blnTHWJ = Not blnEditMode
                                '�ļ����
                                Me.m_blnWJBJ = Not blnEditMode

                            Case Else
                        End Select
                    Next
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            '��������
            Dim strQFRList As String
            Dim strTemp As String
            Try
                '�ļ����꣬������Ķ�
                Select Case objBaseFlowRenshiLuyong.BLZT
                    Case objBaseFlowRenshiLuyong.FILESTATUS_YWC
                        Me.m_blnXGWJ = False
                        Me.m_blnEnforeEdit = False
                    Case Else
                End Select
                If Me.m_blnXGWJ = True Then
                    If objBaseFlowRenshiLuyong.QFR <> "" Then
                        strQFRList = objBaseFlowRenshiLuyong.QFR + strSep
                        strTemp = strUserXM + strSep
                        If strQFRList.IndexOf(strTemp) < 0 Then
                            '���˱��ǿ���޸�
                            Me.m_blnEnforeEdit = True
                        End If
                    End If
                End If

                '������������
                Select Case objBaseFlowRenshiLuyong.BLZT
                    Case objBaseFlowRenshiLuyong.FILESTATUS_YWC
                        'zengxianglin 2009-05-16
                        If objBaseFlowRenshiLuyong.QFR <> "" Then
                            Me.m_blnRYLY = Not blnEditMode
                        End If
                        'zengxianglin 2009-05-16
                        Me.m_blnDRQP = False
                        Me.m_blnDRZS = False
                    Case objBaseFlowRenshiLuyong.FILESTATUS_YQP
                        Me.m_blnDRQP = Not blnEditMode
                        Me.m_blnDRZS = Not blnEditMode
                    Case Else
                        Me.m_blnDRQP = False
                        Me.m_blnDRZS = False
                End Select
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.FlowData.SafeRelease(objJiaojieDataWWC)

            getCanExecuteCommand = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Data.FlowData.SafeRelease(objJiaojieDataWWC)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����strWJBS��ȡ���ز�_B_����_¼�������������ݼ�
        '     strErrMsg                     ����������򷵻ش�����Ϣ
        '     strUserId                     ���û���ʶ
        '     strPassword                   ���û�����
        '     strWJBS                       ���ļ���ʶ
        '     objestateRenshiXingyeData     ����Ϣ���ݼ�
        ' ����
        '     True                          ���ɹ�
        '     False                         ��ʧ��
        '----------------------------------------------------------------
        Public Function getMainData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            Try
                Dim objrulesFlowObjectRenshiLuyong As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong
                objrulesFlowObjectRenshiLuyong = CType(Me.m_objrulesFlowObject, Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong)
                getMainData = objrulesFlowObjectRenshiLuyong.getMainData(strErrMsg, strUserId, strPassword, strWJBS, objestateRenshiXingyeData)
            Catch ex As Exception
                getMainData = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' ����strWJBS��ȡ���ز�_B_����_¼�������������ݼ�
        '     strErrMsg                         ����������򷵻ش�����Ϣ
        '     objestateRenshiXingyeData         ����Ϣ���ݼ�
        ' ����
        '     True                              ���ɹ�
        '     False                             ��ʧ��
        '----------------------------------------------------------------
        Public Function getMainData( _
            ByRef strErrMsg As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            Try
                Dim objrulesFlowObjectRenshiLuyong As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong
                objrulesFlowObjectRenshiLuyong = CType(Me.m_objrulesFlowObject, Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong)
                getMainData = objrulesFlowObjectRenshiLuyong.getMainData(strErrMsg, objestateRenshiXingyeData)
            Catch ex As Exception
                getMainData = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' ��ȡָ�����ش���+�ļ�����µ��ļ����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strJGDZ              �����ش���
        '     strWJNF              ���ļ����
        '     strWJXH              ��(����)�ļ����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function getNewWjxh( _
            ByRef strErrMsg As String, _
            ByVal strJGDZ As String, _
            ByVal strWJNF As String, _
            ByRef strWJXH As String) As Boolean
            Try
                Dim objrulesFlowObjectRenshiLuyong As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong
                objrulesFlowObjectRenshiLuyong = CType(Me.m_objrulesFlowObject, Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong)
                getNewWjxh = objrulesFlowObjectRenshiLuyong.getNewWjxh(strErrMsg, strJGDZ, strWJNF, strWJXH)
            Catch ex As Exception
                strErrMsg = ex.Message
                getNewWjxh = False
            End Try
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_¼������_��Ա��Ϣ�����ݼ�(�ԡ���Ա��š���������)
        '     strErrMsg                        ����������򷵻ش�����Ϣ
        '     objestateRenshiXingyeData        ����������
        ' ����
        '     True                             ���ɹ�
        '     False                            ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_RYXX( _
            ByRef strErrMsg As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            Try
                Dim objrulesFlowObjectRenshiLuyong As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong
                objrulesFlowObjectRenshiLuyong = CType(Me.m_objrulesFlowObject, Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong)
                getDataSet_RYXX = objrulesFlowObjectRenshiLuyong.getDataSet_RYXX(strErrMsg, objestateRenshiXingyeData)
            Catch ex As Exception
                strErrMsg = ex.Message
                getDataSet_RYXX = False
            End Try
        End Function

        '----------------------------------------------------------------
        ' ��ȡstrUserXM�ܹ��鿴�ġ��ز�_B_����_¼����������ȫ���ݵ����ݼ�(�ԡ��������ڡ���������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserXM                  ���û�����
        '     strWhere                   �������ַ���
        '     objestateRenshiXingyeData  ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_Main( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            Try
                Dim objrulesFlowObjectRenshiLuyong As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong
                objrulesFlowObjectRenshiLuyong = CType(Me.m_objrulesFlowObject, Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong)
                getDataSet_Main = objrulesFlowObjectRenshiLuyong.getDataSet_Main(strErrMsg, strUserXM, strWhere, objestateRenshiXingyeData)
            Catch ex As Exception
                strErrMsg = ex.Message
                getDataSet_Main = False
            End Try
        End Function

    End Class









    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JsKernal.DataAccess
    ' ����    ��SystemFlowObjectBaopijianCreator
    '
    ' ���������� 
    '     SystemFlowObjectBaopijian�Ĵ����ӿ�ʵ��
    '----------------------------------------------------------------
    Public Class SystemFlowObjectBaopijianCreator
        Implements Josco.JsKernal.BusinessFacade.ISystemFlowObjectCreate

        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
        End Sub

        '----------------------------------------------------------------
        ' ʵ�ֽӿ�
        '----------------------------------------------------------------
        Public Function Create( _
            ByVal strFlowType As String, _
            ByVal strFlowTypeName As String) As Josco.JsKernal.BusinessFacade.systemFlowObject _
            Implements Josco.JsKernal.BusinessFacade.ISystemFlowObjectCreate.Create

            Try
                Create = New Josco.JSOA.BusinessFacade.systemFlowObjectRenshiLuyong
            Catch ex As Exception
                Throw ex
            End Try

        End Function

    End Class

End Namespace
