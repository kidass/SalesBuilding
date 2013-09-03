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

Imports Microsoft.VisualBasic

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Imports Josco.JsKernal.Common
Imports Josco.JsKernal.Common.Data
Imports Josco.JsKernal.SystemFramework
Imports Josco.JsKernal.DataAccess.FlowObject

Namespace Josco.JSOA.DataAccess

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.DataAccess
    ' ����    ��FlowObjectRenshiLuyong
    '
    ' ���������� 
    '     ����¼������������
    ' ���ļ�¼
    '     zengxianglin 2009-05-15 ����
    '----------------------------------------------------------------
    Public Class FlowObjectRenshiLuyong
        Inherits josco.JsKernal.DataAccess.FlowObject

        '��ˮ�ŷ��ű�/��ͼ����
        Private TABLE_FOR_NEWLSH As String = "�ز�_B_����_¼������"












        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New(josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWCODE, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWNAME)
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
        Public Overloads Shared Sub SafeRelease(ByRef obj As josco.JSOA.DataAccess.FlowObjectRenshiLuyong)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub













        '----------------------------------------------------------------
        ' ��ȡȱʡ�������
        '     strYjlx              ����������
        ' ����
        '                          �������־
        '----------------------------------------------------------------
        Public Overrides Function getDefaultYJNR(ByVal strYJLX As String) As String
            getDefaultYJNR = "ͬ�⡣"
        End Function

        '----------------------------------------------------------------
        ' �ж�strUserXM�Ƿ������д�а�İ�����?
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserXM            ����Ա����
        '     blnCanWrite          �����أ��Ƿ����?
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function canWriteChengbanResult( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByRef blnCanWrite As Boolean) As Boolean
            strErrMsg = "����[" + MyBase.FlowTypeName + "]��֧��[canWriteChengbanResult]������"
            canWriteChengbanResult = False
        End Function

        '----------------------------------------------------------------
        ' �ж�strUserXM�Ƿ���Լ�ӡ�ļ�?
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserXM            ����Ա����
        '     blnCanJiayin         �����أ��Ƿ����?
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function canJiayinFile( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByRef blnCanJiayin As Boolean) As Boolean
            strErrMsg = "����[" + MyBase.FlowTypeName + "]��֧��[canJiayinFile]������"
            canJiayinFile = False
        End Function

        '----------------------------------------------------------------
        ' �ж�strUserXM�Ƿ�Ǽǰ�����?
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserXM            ����Ա����
        '     blnCan               �����أ��Ƿ����?
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function canDengjiBLJG( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByRef blnCan As Boolean) As Boolean
            canDengjiBLJG = Me.canWriteChengbanResult(strErrMsg, strUserXM, blnCan)
        End Function

        '----------------------------------------------------------------
        ' �ж�strUserXM�Ƿ�а���ļ�?
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserXM            ���û�����
        '     strXBBZ              ������а�����򷵻�Э���־
        '     blnHasChengban       �������Ƿ�а���ļ�?
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function isRenyuanHasChengban( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByRef strXBBZ As String, _
            ByRef blnHasChengban As Boolean) As Boolean
            strErrMsg = "����[" + MyBase.FlowTypeName + "]��֧��[isRenyuanHasChengban]������"
            isRenyuanHasChengban = False
        End Function













        '----------------------------------------------------------------
        ' �ж��ļ��Ƿ������������?
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     blnComplete          �������Ƿ�������?
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function isFileComplete( _
            ByRef strErrMsg As String, _
            ByRef blnComplete As Boolean) As Boolean

            Dim objdacCommon As New josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            isFileComplete = False
            blnComplete = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[isFileComplete]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If

                '��ȡ�ļ�������б�
                Dim strFileYWCStatus As String = Me.FlowData.FILESTATUS_YWC

                '��ȡ�ļ���ʶ
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '����
                If Me.IsFillData = False Then
                    '��ȡ����
                    strSQL = ""
                    strSQL = strSQL + " select * from �ز�_B_����_¼������ " + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "' " + vbCr
                    strSQL = strSQL + " and   ����״̬ = '" + strFileYWCStatus + "' " + vbCr
                    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        blnComplete = True
                    End If
                Else
                    Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                    objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                    Select Case objBaseFlowRenshiLuyong.BLZT
                        Case strFileYWCStatus
                            blnComplete = True
                        Case Else
                    End Select
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isFileComplete = True
            Exit Function
errProc:
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ж��ļ��Ƿ��Ѿ�����?
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     blnDinggao           �������Ƿ��Ѿ�����?
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function isFileDinggao( _
            ByRef strErrMsg As String, _
            ByRef blnDinggao As Boolean) As Boolean

            Dim objdacCommon As New josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet
            Dim strSQL As String

            isFileDinggao = False
            blnDinggao = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[isFileDinggao]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If

                '��ȡ�ļ��Ѷ����б�
                Dim strFileYDGList As String = Me.FlowData.FileStatusYDGList

                '��ȡ�ļ���ʶ
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '����
                If Me.IsFillData = False Then
                    '��ȡ����
                    strSQL = ""
                    strSQL = strSQL + " select * from �ز�_B_����_¼������ " + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "' " + vbCr
                    strSQL = strSQL + " and   ����״̬ in (" + strFileYDGList + ") " + vbCr
                    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        blnDinggao = True
                    End If
                Else
                    Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                    objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                    Dim strBLZT As String
                    strBLZT = "'" + objBaseFlowRenshiLuyong.BLZT + "'"
                    If strFileYDGList.IndexOf(strBLZT) >= 0 Then
                        blnDinggao = True
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isFileDinggao = True
            Exit Function

errProc:
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ж��ļ��Ƿ��Ѿ�����?
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     blnZuofei            �������Ƿ��Ѿ�����?
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function isFileZuofei( _
            ByRef strErrMsg As String, _
            ByRef blnZuofei As Boolean) As Boolean

            Dim objdacCommon As New josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet
            Dim strSQL As String

            isFileZuofei = False
            blnZuofei = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[isFileZuofei]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If

                '��ȡ�ļ��������б�
                Dim strFileYZFStatus As String = Me.FlowData.FILESTATUS_YZF

                '��ȡ�ļ���ʶ
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '����
                If Me.IsFillData = False Then
                    '��ȡ����
                    strSQL = ""
                    strSQL = strSQL + " select * from �ز�_B_����_¼������ " + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "' " + vbCr
                    strSQL = strSQL + " and   ����״̬ = '" + strFileYZFStatus + "' " + vbCr
                    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        blnZuofei = True
                    End If
                Else
                    Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                    objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                    Select Case objBaseFlowRenshiLuyong.BLZT
                        Case strFileYZFStatus
                            blnZuofei = True
                        Case Else
                    End Select
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isFileZuofei = True
            Exit Function

errProc:
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ж��ļ��Ƿ��Ѿ�ͣ��?
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     blnTingban           �������Ƿ��Ѿ�ͣ��?
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function isFileTingban( _
            ByRef strErrMsg As String, _
            ByRef blnTingban As Boolean) As Boolean

            Dim objdacCommon As New josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet
            Dim strSQL As String

            isFileTingban = False
            blnTingban = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[isFileTingban]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If

                '��ȡ�ļ��ѻ����б�
                Dim strFileYTBStatus As String = Me.FlowData.FILESTATUS_YTB

                '��ȡ�ļ���ʶ
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '����
                If Me.IsFillData = False Then
                    '��ȡ����
                    strSQL = ""
                    strSQL = strSQL + " select * from �ز�_B_����_¼������ " + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "' " + vbCr
                    strSQL = strSQL + " and   ����״̬ = '" + strFileYTBStatus + "' " + vbCr
                    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        blnTingban = True
                    End If
                Else
                    Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                    objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                    Select Case objBaseFlowRenshiLuyong.BLZT
                        Case strFileYTBStatus
                            blnTingban = True
                        Case Else
                    End Select
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isFileTingban = True
            Exit Function

errProc:
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ж�strUserXM�Ƿ����ļ���ԭʼ����?
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserXM            ����Ա����
        '     blnIs                �������Ƿ�?
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function isOriginalPeople( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByRef blnIs As Boolean) As Boolean

            Dim objdacCommon As New josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet
            Dim strSQL As String

            isOriginalPeople = False
            blnIs = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[isOriginalPeople]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If

                '��ȡ�ļ���ʶ
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '����
                If Me.IsFillData = False Then
                    '��ȡ����
                    strSQL = ""
                    strSQL = strSQL + " select * from �ز�_B_����_¼������ " + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "' " + vbCr
                    strSQL = strSQL + " and   ������Ա = '" + strUserXM + "' " + vbCr
                    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        blnIs = True
                    End If
                Else
                    Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                    objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                    Select Case objBaseFlowRenshiLuyong.NGR
                        Case strUserXM
                            blnIs = True
                        Case Else
                    End Select
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isOriginalPeople = True
            Exit Function

errProc:
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ж�strBLSY�Ƿ��Ѿ���׼?
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strBLSY              ����������
        '     blnApproved          �������Ƿ�?
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function isTaskApproved( _
            ByRef strErrMsg As String, _
            ByVal strBLSY As String, _
            ByRef blnApproved As Boolean) As Boolean

            Dim objdacCommon As New josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet
            Dim strSQL As String

            isTaskApproved = False
            blnApproved = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[isTaskApproved]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If strBLSY Is Nothing Then strBLSY = ""
                strBLSY = strBLSY.Trim()

                '��ȡ�ļ���ʶ
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS
                Dim strBLLX As String = Me.FlowTypeName

                '��ȡ����
                Select Case strBLSY
                    Case josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_QFWJ
                        If Me.IsFillData = False Then
                            strSQL = ""
                            strSQL = strSQL + " select * from �ز�_B_����_¼������ " + vbCr
                            strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "' " + vbCr
                            strSQL = strSQL + " and len(rtrim(isnull(ǩ����,' '))) > 0 " + vbCr
                        Else
                            Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                            objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                            Select Case objBaseFlowRenshiLuyong.QFR
                                Case ""
                                Case Else
                                    blnApproved = True
                            End Select
                            Exit Try
                        End If

                    Case Else
                        strSQL = ""
                        strSQL = strSQL + " select * from ����_B_���� " + vbCr
                        strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "' " + vbCr
                        strSQL = strSQL + " and   �������� = '" + strBLLX + "' " + vbCr
                        strSQL = strSQL + " and   �������� = '" + strBLSY + "' " + vbCr
                        strSQL = strSQL + " and   �Ƿ���׼ like '11%' " + vbCr
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    blnApproved = True
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isTaskApproved = True
            Exit Function

errProc:
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ж�strBLSY�Ƿ�Ϊ�������ˣ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strBLSY              ����������
        '     intLevel             �����˼���
        '     blnIsShenpi          �����أ��Ƿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overloads Overrides Function isShenpiTask( _
            ByRef strErrMsg As String, _
            ByVal strBLSY As String, _
            ByVal intLevel As Integer, _
            ByRef blnIsShenpi As Boolean) As Boolean

            isShenpiTask = False
            blnIsShenpi = False

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[isShenpiTask]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If strBLSY Is Nothing Then strBLSY = ""
                strBLSY = strBLSY.Trim()

                '����
                If intLevel <= 10 Then
                    blnIsShenpi = False
                Else
                    blnIsShenpi = True
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            isShenpiTask = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ж�strBLSY�Ƿ�Ϊ�������ˣ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strBLSY              ����������
        '     blnIsShenpi          �����أ��Ƿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overloads Overrides Function isShenpiTask( _
            ByRef strErrMsg As String, _
            ByVal strBLSY As String, _
            ByRef blnIsShenpi As Boolean) As Boolean

            Dim intLevel As Integer

            isShenpiTask = False
            blnIsShenpi = False

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[isShenpiTask]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If strBLSY Is Nothing Then strBLSY = ""
                strBLSY = strBLSY.Trim()

                '���㼶��
                If Me.getTaskLevel(strErrMsg, strBLSY, intLevel) = False Then
                    GoTo errProc
                End If

                '����
                If intLevel <= 10 Then
                    blnIsShenpi = False
                Else
                    blnIsShenpi = True
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            isShenpiTask = True
            Exit Function
errProc:
            Exit Function

        End Function












        '----------------------------------------------------------------
        ' ��ȡ����������ļ������Ļ���Ŀ¼
        '----------------------------------------------------------------
        Public Overrides Function getBasePath_XGWJFJ() As String
            getBasePath_XGWJFJ = josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FILEDIR_XG
        End Function

        '----------------------------------------------------------------
        ' ��ȡ����������Ļ���Ŀ¼
        '----------------------------------------------------------------
        Public Overrides Function getBasePath_GJ() As String
            getBasePath_GJ = josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FILEDIR_GJ
        End Function

        '----------------------------------------------------------------
        ' ��ȡ�����������Ļ���Ŀ¼
        '----------------------------------------------------------------
        Public Overrides Function getBasePath_FJ() As String
            getBasePath_FJ = josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FILEDIR_FJ
        End Function

        '----------------------------------------------------------------
        ' ��ȡ��������ʼ����������
        '----------------------------------------------------------------
        Public Overrides Function getInitTask() As String
            getInitTask = josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_CYCG
        End Function












        '----------------------------------------------------------------
        ' ���ݡ��ļ���ʶ����ȡ��������������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     objDataSet           �����ض�����������ݼ�
        '     strTableName         ���������������ݼ��еı���
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function getMainFlowData( _
            ByRef strErrMsg As String, _
            ByRef objDataSet As System.Data.DataSet, _
            ByRef strTableName As String) As Boolean

            Dim objTempDataSet As josco.JSOA.Common.Data.estateRenshiXingyeData
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strWJBS As String
            Dim strSQL As String

            getMainFlowData = False
            objDataSet = Nothing
            strTableName = ""
            strErrMsg = ""

            Try
                '��ȡ�ļ���ʶ
                objSqlConnection = Me.SqlConnection
                strWJBS = Me.WJBS
                If objSqlConnection Is Nothing Then
                    strErrMsg = "����[getMainFlowData]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If

                '�������ݼ�
                objTempDataSet = New josco.JSOA.Common.Data.estateRenshiXingyeData(josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_B_RS_LUYONGSHENPI)
                If strWJBS = "" Then
                    Exit Try
                End If

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                'ִ�м���
                With Me.SqlDataAdapter
                    strSQL = ""
                    strSQL = strSQL + " select * from �ز�_B_����_¼������ " + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr

                    '���ò���
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    .SelectCommand = objSqlCommand

                    'ִ�в���
                    .Fill(objTempDataSet.Tables(josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI))
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            strTableName = josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI
            objDataSet = objTempDataSet
            getMainFlowData = True
            Exit Function

errProc:
            josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempDataSet)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����strBLSY�ļ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strBLSY              ����������
        '     intLevel             �����ؼ���
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function getTaskLevel( _
            ByRef strErrMsg As String, _
            ByVal strBLSY As String, _
            ByRef intLevel As Integer) As Boolean

            getTaskLevel = False
            intLevel = 1

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[getTaskLevel]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If strBLSY Is Nothing Then strBLSY = ""
                strBLSY = strBLSY.Trim()

                '����
                Select Case strBLSY
                    Case josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_CYCG, _
                        josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_GJBJ
                        '������塢����༭
                        intLevel = 1

                    Case josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_SMCL
                        '˾�ش���
                        intLevel = 15
                    Case josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_SHWJ
                        '����ļ�
                        intLevel = 20
                    Case josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_HQWJ
                        '��ǩ�ļ�
                        intLevel = 22
                    Case josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_XGCL
                        '��ش���
                        intLevel = 25
                    Case josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_MSCL
                        '���鴦��
                        intLevel = 30
                    Case josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_QFWJ, _
                        josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_LDCL
                        'ǩ���ļ�,�����ļ�
                        intLevel = 40

                    Case josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_WJGD
                        '�ļ��鵵
                        intLevel = 5
                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getTaskLevel = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡstrUserXM���Ķ����������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserXM            ���û�����
        '     strWhere             ����������
        '     objOpinionData       �����أ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ���˵����
        '     ������ 2008-04-01 
        '       (1) ���������������ʾ˳��Ϊ��ʾ��š�����������֯���롢��Ա���
        '       (2) ���������Ϣ��������ʾ����ֶ�
        '----------------------------------------------------------------
        Public Overrides Function getCanReadOpinion( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String, _
            ByVal strWhere As String, _
            ByRef objOpinionData As josco.JsKernal.Common.Data.FlowData) As Boolean

            Dim objPulicParameters As New josco.JsKernal.Common.Utilities.PulicParameters
            Dim objTempOpinionData As josco.JsKernal.Common.Data.FlowData
            Dim objdacCommon As New josco.JsKernal.DataAccess.dacCommon
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim objDataSet As System.Data.DataSet
            Dim strSQL As String

            getCanReadOpinion = False
            objOpinionData = Nothing
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[getCanReadOpinion]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim()
                If strWhere Is Nothing Then strWhere = ""
                strWhere = strWhere.Trim

                '��ȡ�ļ���ʶ
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strSep As String = josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                Dim strTaskYWCStatusList As String = Me.FlowData.TaskStatusYWCList
                Dim strTaskSPSYList As String = Me.FlowData.TaskBlzlSPSYList
                Dim strTaskBSHStatus As String = Me.FlowData.TASKSTATUS_BSH
                Dim strBYQQ As String = Me.FlowData.TASK_BYQQ
                Dim strBYTZ As String = Me.FlowData.TASK_BYTZ
                Dim strBLLX As String = Me.FlowTypeName
                Dim strWJBS As String = Me.WJBS

                '�������е����������˺��������˲��õ���׼
                Dim strSearchList As String = ""
                Dim strUserList As String = ""
                Dim strBuffer As String = ""
                Dim strTemp As String = ""
                Dim blnFound As Boolean
                Dim intCount As Integer
                Dim i As Integer
                strSearchList = "'" + strUserXM + "'"
                strBuffer = strSearchList
                Do While True
                    blnFound = False

                    '������׼�������б�
                    strSQL = ""
                    strSQL = strSQL + " select a.������ " + vbCr
                    strSQL = strSQL + " from " + vbCr
                    strSQL = strSQL + " (" + vbCr
                    strSQL = strSQL + "   select a.* " + vbCr
                    strSQL = strSQL + "   from ����_B_���� a " + vbCr
                    strSQL = strSQL + "   where a.�ļ���ʶ = '" + strWJBS + "' " + vbCr           '��ǰ�ļ�
                    strSQL = strSQL + "   and   a.�������� = '" + strBYQQ + "' " + vbCr           '��������
                    strSQL = strSQL + "   and   a.������ in (" + strSearchList + ") " + vbCr      '���͵Ĳ�������
                    strSQL = strSQL + "   and   a.���ӱ�ʶ like '_____1%' " + vbCr                '֪ͨ��
                    strSQL = strSQL + "   and   a.����״̬ <> '" + strTaskBSHStatus + "' " + vbCr 'û�б��ջ�
                    strSQL = strSQL + " ) a " + vbCr
                    strSQL = strSQL + " left join " + vbCr
                    strSQL = strSQL + " (" + vbCr
                    strSQL = strSQL + "   select * from ����_B_���� " + vbCr
                    strSQL = strSQL + "   where �ļ���ʶ = '" + strWJBS + "' " + vbCr
                    strSQL = strSQL + "   and   �������� = '" + strBYQQ + "' " + vbCr
                    strSQL = strSQL + "   and   �Ƿ���׼ = '1100' " + vbCr
                    strSQL = strSQL + " ) b on a.�ļ���ʶ = b.�ļ���ʶ and a.������� = b.������� " + vbCr
                    strSQL = strSQL + " where b.�ļ���ʶ is not null " + vbCr                     '�Ѿ���׼�Ĳ�������
                    strSQL = strSQL + " group by a.������" + vbCr
                    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    intCount = objDataSet.Tables(0).Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strTemp = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("������"), "")
                        strTemp = "'" + strTemp + "'"
                        If strUserList = "" Then
                            strUserList = strTemp
                            strBuffer = strBuffer + "," + strTemp
                            blnFound = True
                        Else
                            If InStr(1, strUserList, strTemp) < 1 Then
                                strUserList = strUserList + "," + strTemp
                                strBuffer = strBuffer + "," + strTemp
                                blnFound = True
                            End If
                        End If
                    Next
                    josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                    objDataSet = Nothing

                    '���������������б�
                    strSQL = ""
                    strSQL = strSQL + " select a.������ " + vbCr
                    strSQL = strSQL + " from " + vbCr
                    strSQL = strSQL + " (" + vbCr
                    strSQL = strSQL + "   select a.* " + vbCr
                    strSQL = strSQL + "   from ����_B_���� a " + vbCr
                    strSQL = strSQL + "   where a.�ļ���ʶ = '" + strWJBS + "' " + vbCr             '��ǰ�ļ�
                    strSQL = strSQL + "   and   a.�������� = '" + strBYTZ + "' " + vbCr             '��������
                    strSQL = strSQL + "   and   a.������ in (" + strSearchList + ") " + vbCr        '������
                    strSQL = strSQL + "   and   a.���ӱ�ʶ like '_____1%' " + vbCr                  '֪ͨ��
                    strSQL = strSQL + "   and   a.����״̬ <> '" + strTaskBSHStatus + "' " + vbCr   'û�б��ջ�
                    strSQL = strSQL + "   and   a.ԭ���Ӻ� = -2 " + vbCr                            '��������
                    strSQL = strSQL + " ) a " + vbCr
                    strSQL = strSQL + " group by a.������" + vbCr
                    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    intCount = objDataSet.Tables(0).Rows.Count
                    For i = 0 To intCount - 1 Step 1
                        strTemp = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("������"), "")
                        strTemp = "'" + strTemp + "'"
                        If strUserList = "" Then
                            strUserList = strTemp
                            strBuffer = strBuffer + "," + strTemp
                            blnFound = True
                        Else
                            If InStr(1, strUserList, strTemp) < 1 Then
                                strUserList = strUserList + "," + strTemp
                                strBuffer = strBuffer + "," + strTemp
                                blnFound = True
                            End If
                        End If
                    Next
                    josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                    objDataSet = Nothing

                    If blnFound = False Then
                        Exit Do
                    End If
                    strSearchList = strBuffer
                Loop

                '�������ݼ�
                objTempOpinionData = New josco.JsKernal.Common.Data.FlowData(josco.JsKernal.Common.Data.FlowData.enumTableType.GW_B_SHENPIYIJIAN)
                If strWJBS = "" Then Exit Try

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                'ִ�м���
                With Me.SqlDataAdapter
                    strSQL = ""
                    strSQL = strSQL + " select a.*" + vbCr
                    strSQL = strSQL + " from" + vbCr
                    strSQL = strSQL + " (" + vbCr
                    strSQL = strSQL + "   select a.*, " + vbCr
                    strSQL = strSQL + "     �Ƿ�ͬ�� = case " + vbCr
                    strSQL = strSQL + "        when b.�Ƿ���׼ = '1100' then '" + josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.SPYJ_TY + "' " + vbCr
                    strSQL = strSQL + "        when b.�Ƿ���׼ = '1110' then '" + josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.SPYJ_BLYJ + "' " + vbCr
                    strSQL = strSQL + "        when b.�Ƿ���׼ = '1000' then '" + josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.SPYJ_BTY + "' " + vbCr
                    strSQL = strSQL + "        else ' ' end," + vbCr
                    strSQL = strSQL + "     b.��������, " + vbCr
                    strSQL = strSQL + "     b.�������, " + vbCr
                    strSQL = strSQL + "     b.�������, " + vbCr
                    strSQL = strSQL + "     b.������, " + vbCr
                    strSQL = strSQL + "     b.��������, " + vbCr
                    strSQL = strSQL + "     b.������, " + vbCr
                    strSQL = strSQL + "     b.��д����, " + vbCr
                    strSQL = strSQL + "     c.��Ա���, " + vbCr
                    strSQL = strSQL + "     c.��������, " + vbCr
                    strSQL = strSQL + "     c.��֯����, " + vbCr
                    '������ 2008-04-01
                    strSQL = strSQL + "     b.��ʾ���  " + vbCr
                    '������ 2008-04-01
                    strSQL = strSQL + "   from " + vbCr
                    strSQL = strSQL + "   (" + vbCr
                    strSQL = strSQL + "     select a.�ļ���ʶ, a.�������, a.��������, a.������, c.�������� as ��������, a.Э�� " + vbCr
                    strSQL = strSQL + "     from " + vbCr
                    strSQL = strSQL + "     (" + vbCr
                    strSQL = strSQL + "       select a.* " + vbCr
                    strSQL = strSQL + "       from ����_B_���� a " + vbCr
                    strSQL = strSQL + "       where a.�ļ���ʶ = '" + strWJBS + "' " + vbCr                 '��ǰ�ļ�
                    strSQL = strSQL + "       and   a.�������� in (" + strTaskSPSYList + ") " + vbCr        '����������
                    strSQL = strSQL + "       and   a.���ӱ�ʶ like '1_1__0%' " + vbCr                      '�ѷ���+�������ܿ�+��֪ͨ��
                    strSQL = strSQL + "     ) a " + vbCr
                    strSQL = strSQL + "     left join " + vbCr
                    strSQL = strSQL + "     (" + vbCr
                    strSQL = strSQL + "       select a.�ļ���ʶ, a.������, a.�������, isnull(max(a.�������),0) as ������� " + vbCr
                    strSQL = strSQL + "       from ����_B_���� a " + vbCr
                    strSQL = strSQL + "       where a.�ļ���ʶ = '" + strWJBS + "' " + vbCr                 '��ǰ�ļ�
                    strSQL = strSQL + "       and   a.���ӱ�ʶ like '1_1__0%' " + vbCr                      '�ѷ���+�������ܿ�+��֪ͨ��
                    If strUserList = "" Then
                        strSQL = strSQL + "       and   a.������   = '" + strUserXM + "' " + vbCr           'ֻ���Լ�
                    Else
                        strSQL = strSQL + "       and ((a.������   = '" + strUserXM + "') " + vbCr
                        strSQL = strSQL + "       or   (a.������   in (" + strUserList + "))) " + vbCr      '�Լ�+�����������ܿ�+�Լ�����������׼���ܿ�
                    End If
                    strSQL = strSQL + "       group by a.�ļ���ʶ, a.������, a.������� " + vbCr
                    strSQL = strSQL + "     ) b on a.�ļ���ʶ = b.�ļ���ʶ " + vbCr
                    strSQL = strSQL + "     left join " + vbCr
                    strSQL = strSQL + "     (" + vbCr
                    strSQL = strSQL + "       select * from ����_B_���� " + vbCr
                    strSQL = strSQL + "       where �ļ���ʶ = '" + strWJBS + "' " + vbCr
                    strSQL = strSQL + "     ) c on a.�ļ���ʶ = c.�ļ���ʶ and a.������� = c.������� " + vbCr
                    strSQL = strSQL + "     where ((a.������ = b.������) " + vbCr
                    strSQL = strSQL + "     or a.����״̬ in (" + strTaskYWCStatusList + ")) " + vbCr       '����ɻ���
                    strSQL = strSQL + "     group by a.�ļ���ʶ, a.�������, a.��������, a.������, c.��������, a.Э�� " + vbCr
                    strSQL = strSQL + "   ) a " + vbCr
                    strSQL = strSQL + "   left join " + vbCr
                    strSQL = strSQL + "   (" + vbCr
                    strSQL = strSQL + "     select * from ����_B_���� " + vbCr
                    strSQL = strSQL + "     where �ļ���ʶ = '" + strWJBS + "' " + vbCr                    '��ǰ�ļ�
                    strSQL = strSQL + "     and   CHARINDEX('" + strUserXM + strSep + "',rtrim(isnull(�����Ķ���Ա,' '))+'" + strSep + "',1) < 1 " + vbCr
                    strSQL = strSQL + "   ) b on a.�ļ���ʶ = b.�ļ���ʶ and a.������� = b.������� " + vbCr
                    strSQL = strSQL + "   left join " + vbCr
                    strSQL = strSQL + "   (" + vbCr
                    strSQL = strSQL + "     select a.��Ա����, a.��֯����, ��Ա���=convert(integer,a.��Ա���), b.�������� " + vbCr
                    strSQL = strSQL + "     from ����_B_��Ա a " + vbCr
                    strSQL = strSQL + "     left join ����_B_�������� b on a.������� = b.������� " + vbCr
                    strSQL = strSQL + "   ) c on a.������ = c.��Ա���� " + vbCr
                    strSQL = strSQL + "   where b.�ļ���ʶ is not null " + vbCr                            '�������Ķ�
                    strSQL = strSQL + " ) a" + vbCr
                    If strWhere <> "" Then
                        strSQL = strSQL + " where " + strWhere + vbCr
                    End If
                    '������ 2008-04-01
                    'strSQL = strSQL + " order by a.��֯����, a.��Ա���, a.�������� desc" + vbCr
                    strSQL = strSQL + " order by a.��ʾ���, a.��������, a.��֯����, a.��Ա���, a.�������� desc" + vbCr
                    '������ 2008-04-01

                    '���ò���
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    .SelectCommand = objSqlCommand

                    'ִ�в���
                    .Fill(objTempOpinionData.Tables(josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_SHENPIYIJIAN))
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            objOpinionData = objTempOpinionData
            getCanReadOpinion = True
            Exit Function

errProc:
            josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objTempOpinionData)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡ�µ��ļ���ˮ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strLSH               �������ļ���ˮ��
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function getNewLSH( _
            ByRef strErrMsg As String, _
            ByRef strLSH As String) As Boolean

            Dim objdacCommon As New josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String

            getNewLSH = False
            strLSH = ""
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[getNewLSH]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If

                '��ȡ�ļ���ʶ
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '��������
                Dim strWJLX As String = josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWNAME
                Dim strPrefix As String
                strPrefix = Format(Now, "yyyyMMdd") + "-"
                If objdacCommon.getNewCode(strErrMsg, objSqlConnection, "��ˮ��", Me.TABLE_FOR_NEWLSH, 14, strPrefix, True, strLSH) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getNewLSH = True
            Exit Function

errProc:
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function















        '----------------------------------------------------------------
        ' ɾ���ļ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     objFTPProperty       ��FTP���������Ӳ���
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doDeleteFile( _
            ByRef strErrMsg As String, _
            ByVal objFTPProperty As josco.JsKernal.Common.Utilities.FTPProperty) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objPulicParameters As New josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseFTP As New josco.JsKernal.Common.Utilities.BaseFTP
            Dim objdacCommon As New josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet_XGFJ As System.Data.DataSet
            Dim objDataSet_MAIN As System.Data.DataSet
            Dim objDataSet_FJ As System.Data.DataSet

            doDeleteFile = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doDeleteFile]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If

                '��ȡ�ļ���ʶ
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then Exit Try

                '��ȡ�����б�
                strSQL = "select * from ����_B_���� where �ļ���ʶ = '" + strWJBS + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet_FJ) = False Then
                    GoTo errProc
                End If

                '��ȡ����ļ������б�
                strSQL = "select * from ����_B_����ļ����� where �ļ���ʶ = '" + strWJBS + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet_XGFJ) = False Then
                    objSqlTransaction.Rollback()
                    GoTo errProc
                End If

                '��ȡ����¼����
                strSQL = "select * from �ز�_B_����_¼������ where �ļ���ʶ = '" + strWJBS + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet_MAIN) = False Then
                    objSqlTransaction.Rollback()
                    GoTo errProc
                End If

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '������
                Dim strFilePath As String
                Dim strUrl As String
                Dim intCount As Integer
                Dim i As Integer
                Try
                    'ɾ���ļ�������¼
                    strSQL = "delete from ����_B_�ļ����� where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ���ļ���־��¼
                    strSQL = "delete from ����_B_������־ where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ��������Ϣ
                    strSQL = "delete from ����_B_���� where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ���߰���Ϣ
                    strSQL = "delete from ����_B_�߰� where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ�����İ�����Ϣ
                    strSQL = "delete from ����_B_���� where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ�����ĳа���Ϣ
                    strSQL = "delete from ����_B_�а� where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ��������¼
                    strSQL = "delete from ����_B_���� where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ������ļ���Ϣ
                    strSQL = "delete from ����_B_����ļ� where ��ǰ�ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ������ļ�������¼
                    strSQL = "delete from ����_B_����ļ����� where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ�����Ľ�����Ϣ
                    strSQL = "delete from ����_B_���� where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ�����ز�_B_����_¼������_��Ա��Ϣ��
                    strSQL = "delete from �ز�_B_����_¼������_��Ա��Ϣ where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ������¼
                    strSQL = "delete from �ز�_B_����_¼������ where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ��������Ϣ
                    'ɾ����Ӧ��FTP�ļ�
                    With objDataSet_FJ.Tables(0)
                        intCount = .Rows.Count
                        For i = 0 To intCount - 1 Step 1
                            strFilePath = objPulicParameters.getObjectValue(.Rows(i).Item("λ��"), "")
                            If strFilePath <> "" Then
                                With objFTPProperty
                                    strUrl = .getUrl(strFilePath)
                                    If objBaseFTP.doDeleteFile(strErrMsg, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                        '���Բ��ɹ����γ������ļ���
                                    End If
                                End With
                            End If
                        Next
                    End With
                    objDataSet_FJ.Dispose()
                    objDataSet_FJ = Nothing

                    'ɾ������ļ�������Ϣ
                    'ɾ����Ӧ��FTP�ļ�
                    With objDataSet_XGFJ.Tables(0)
                        intCount = .Rows.Count
                        For i = 0 To intCount - 1 Step 1
                            strFilePath = objPulicParameters.getObjectValue(.Rows(i).Item("λ��"), "")
                            If strFilePath <> "" Then
                                With objFTPProperty
                                    strUrl = .getUrl(strFilePath)
                                    If objBaseFTP.doDeleteFile(strErrMsg, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                        '���Բ��ɹ����γ������ļ���
                                    End If
                                End With
                            End If
                        Next
                    End With
                    objDataSet_XGFJ.Dispose()
                    objDataSet_XGFJ = Nothing

                    'ɾ������¼�е�FTP�ļ�
                    With objDataSet_MAIN.Tables(0)
                        If .Rows.Count > 0 Then
                            'ɾ���������ݶ�Ӧ���ļ�
                            strFilePath = objPulicParameters.getObjectValue(.Rows(0).Item("��������"), "")
                            If strFilePath <> "" Then
                                With objFTPProperty
                                    strUrl = .getUrl(strFilePath)
                                    If objBaseFTP.doDeleteFile(strErrMsg, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                        '���Բ��ɹ����γ������ļ���
                                    End If
                                End With
                            End If
                            'ɾ���ۼ��ļ���Ӧ���ļ�
                            strFilePath = objPulicParameters.getObjectValue(.Rows(0).Item("�ۼ��ļ�"), "")
                            If strFilePath <> "" Then
                                With objFTPProperty
                                    strUrl = .getUrl(strFilePath)
                                    If objBaseFTP.doDeleteFile(strErrMsg, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                        '���Բ��ɹ����γ������ļ���
                                    End If
                                End With
                            End If
                            'ɾ������ԭ����Ӧ���ļ�
                            strFilePath = objPulicParameters.getObjectValue(.Rows(0).Item("����ԭ��"), "")
                            If strFilePath <> "" Then
                                With objFTPProperty
                                    strUrl = .getUrl(strFilePath)
                                    If objBaseFTP.doDeleteFile(strErrMsg, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                        '���Բ��ɹ����γ������ļ���
                                    End If
                                End With
                            End If
                        End If
                    End With
                    objDataSet_MAIN.Dispose()
                    objDataSet_MAIN = Nothing

                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '�ύ����
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_MAIN)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_FJ)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_XGFJ)
            josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doDeleteFile = True
            Exit Function

errProc:
            josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_MAIN)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_FJ)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_XGFJ)
            josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���ݡ��ļ���ʶ����乤������������(����������ʵ��)
        '     strErrMsg            ����������򷵻ش�����Ϣ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doFillFlowData( _
            ByRef strErrMsg As String) As Boolean

            Dim objestateRenshiXingyeData As josco.JSOA.Common.Data.estateRenshiXingyeData
            Dim objPulicParameters As New josco.JsKernal.Common.Utilities.PulicParameters
            Dim objDataSet As System.Data.DataSet

            doFillFlowData = False
            strErrMsg = ""

            Try
                '��ȡ��ǰ��¼
                Dim strTableName As String
                If Me.getMainFlowData(strErrMsg, objDataSet, strTableName) = False Then
                    GoTo errProc
                End If
                objestateRenshiXingyeData = CType(objDataSet, josco.JSOA.Common.Data.estateRenshiXingyeData)
                If objestateRenshiXingyeData.Tables(strTableName).Rows.Count < 1 Then
                    Exit Try
                End If

                '��ȡ��������
                Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)

                '�������
                Dim objDate As System.DateTime = Nothing
                With objestateRenshiXingyeData.Tables(strTableName).Rows(0)
                    '*****************************************************************************************************************************
                    objBaseFlowRenshiLuyong.WJBS = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJBS), "")
                    objBaseFlowRenshiLuyong.LSH = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_LSH), "")
                    objBaseFlowRenshiLuyong.Status = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_BLZT), "")
                    objBaseFlowRenshiLuyong.PZR = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_QFR), "")
                    objBaseFlowRenshiLuyong.PZRQ = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_QFRQ), objDate)
                    objBaseFlowRenshiLuyong.DDSZ = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_DDSZ), 0)
                    '*****************************************************************************************************************************
                    objBaseFlowRenshiLuyong.WJBT = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJBT), "")
                    objBaseFlowRenshiLuyong.JJCD = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JJCD), "")
                    objBaseFlowRenshiLuyong.MMDJ = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_MMDJ), "")
                    objBaseFlowRenshiLuyong.JGDZ = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JGDZ), "")
                    objBaseFlowRenshiLuyong.WJNF = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJNF), "")
                    objBaseFlowRenshiLuyong.WJXH = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJXH), "")
                    '*****************************************************************************************************************************
                    objBaseFlowRenshiLuyong.ZBDW = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JBDW), "")
                    objBaseFlowRenshiLuyong.NGR = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JBRY), "")
                    objBaseFlowRenshiLuyong.NGRQ = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JBRQ), objDate)
                    '*****************************************************************************************************************************
                    objBaseFlowRenshiLuyong.QFR = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_QFR), "")
                    objBaseFlowRenshiLuyong.QFRQ = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_QFRQ), objDate)
                    '*****************************************************************************************************************************
                    objBaseFlowRenshiLuyong.ZWNR = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_ZWNR), "")
                    objBaseFlowRenshiLuyong.HJWJ = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_HJWJ), "")
                    objBaseFlowRenshiLuyong.PJYJ = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_PJYJ), "")
                    '*****************************************************************************************************************************
                    objBaseFlowRenshiLuyong.BLZT = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_BLZT), "")
                    '*****************************************************************************************************************************
                    objBaseFlowRenshiLuyong.DBRS = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_DBRS), 0)
                    objBaseFlowRenshiLuyong.BEIZ = objPulicParameters.getObjectValue(.Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_BZXX), "")
                    '*****************************************************************************************************************************
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)

            doFillFlowData = True
            Exit Function
errProc:
            josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objestateRenshiXingyeData)
            josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �жϼ�¼�����Ƿ���Ч��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     objNewData           ����¼��ֵ(�����Ƽ�ֵ)
        '     objOldData           ����¼��ֵ
        '     objenumEditType      ���༭����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doVerifyFile( _
            ByRef strErrMsg As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As josco.JsKernal.Common.Workflow.BaseFlowObject, _
            ByVal objenumEditType As josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objPulicParameters As New josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet

            Dim objListDictionary As System.Collections.Specialized.ListDictionary
            Dim strSQL As String

            doVerifyFile = False

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doVerifyFile]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����[doVerifyFile]δ�����µ����ݣ�"
                    GoTo errProc
                End If
                objOldData = CType(objOldData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                Dim strOldWJBS As String
                Dim strOldLSH As String
                Select Case objenumEditType
                    Case josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, Utilities.PulicParameters.enumEditType.eCpyNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����[doVerifyFile]δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                        strOldWJBS = objOldData.WJBS
                        strOldLSH = objOldData.LSH
                End Select

                '��ȡ������Ϣ
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection

                '��ȡ��ṹ����
                strSQL = "select top 0 * from �ز�_B_����_¼������"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, objSqlConnection, strSQL, "�ز�_B_����_¼������", objDataSet) = False Then
                    GoTo errProc
                End If

                '������ݳ���
                Dim intCount As Integer = objNewData.Count
                Dim strField As String
                Dim strValue As String
                Dim intLen As Integer
                Dim i As Integer
                For i = 0 To intCount - 1 Step 1
                    strField = objNewData.GetKey(i).Trim()
                    strValue = objNewData.Item(i).Trim()
                    Select Case strField
                        Case josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJBS
                            Select Case objenumEditType
                                Case josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                    josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                    '����ȱʡֵ
                                    If Me.getNewWJBS(strErrMsg, strValue) = False Then
                                        GoTo errProc
                                    End If
                                Case Else
                            End Select
                        Case josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_LSH
                            Select Case objenumEditType
                                Case josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                                    josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                                    '����ȱʡֵ
                                    If Me.getNewLSH(strErrMsg, strValue) = False Then
                                        GoTo errProc
                                    End If
                                Case Else
                            End Select
                        Case josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_BLZT
                            If strValue = "" Then
                                '����ȱʡֵ
                                strValue = Me.FlowData.FILESTATUS_ZJB
                            End If

                        Case josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJBT, _
                            josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JGDZ, _
                            josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJNF
                            If strValue = "" Then
                                strErrMsg = "����[" + strField + "]����Ϊ�գ�"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "����[" + strField + "]���Ȳ��ܳ���[" + .MaxLength.ToString() + "]��ʵ����[" + intLen.ToString() + "]��"
                                    GoTo errProc
                                End If
                            End With

                        Case josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_DDSZ
                            If strValue = "" Then strValue = "0"
                            If objPulicParameters.isIntegerString(strValue) = False Then
                                strErrMsg = "����[" + strField + "]���������֣�"
                                GoTo errProc
                            End If
                            intLen = CType(strValue, Integer)
                            Select Case intLen
                                Case 0, 1
                                Case Else
                                    strErrMsg = "����[" + strField + "]������0��1��"
                                    GoTo errProc
                            End Select
                            strValue = intLen.ToString()
                        Case josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_DBRS
                            If strValue = "" Then strValue = "0"
                            If objPulicParameters.isIntegerString(strValue) = False Then
                                strErrMsg = "����[" + strField + "]���������֣�"
                                GoTo errProc
                            End If
                            intLen = CType(strValue, Integer)
                            If intLen < 0 Then
                                strErrMsg = "����[" + strField + "]����>0��"
                                GoTo errProc
                            End If
                            strValue = intLen.ToString()

                        Case josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JBRQ
                            If strValue = "" Then
                                strErrMsg = "����[" + strField + "]����Ϊ�գ�"
                                GoTo errProc
                            End If
                            Dim objDate As System.DateTime
                            Try
                                objDate = CType(strValue, System.DateTime)
                            Catch ex As Exception
                                strErrMsg = "����[" + strField + "]ֵ[" + strValue + "]��Ч��"
                                GoTo errProc
                            End Try
                            strValue = Format(objDate, "yyyy-MM-dd HH:mm")
                        Case josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_QFRQ
                            If strValue <> "" Then
                                Dim objDate As System.DateTime
                                Try
                                    objDate = CType(strValue, System.DateTime)
                                Catch ex As Exception
                                    strErrMsg = "����[" + strField + "]ֵ[" + strValue + "]��Ч��"
                                    GoTo errProc
                                End Try
                                strValue = Format(objDate, "yyyy-MM-dd HH:mm")
                            End If

                        Case Else
                            If strValue <> "" Then
                                With objDataSet.Tables(0).Columns(strField)
                                    intLen = objPulicParameters.getStringLength(strValue)
                                    If intLen > .MaxLength Then
                                        strErrMsg = "����[" + strField + "]���Ȳ��ܳ���[" + .MaxLength.ToString() + "]��ʵ����[" + intLen.ToString() + "]��"
                                        GoTo errProc
                                    End If
                                End With
                            End If
                    End Select

                    objNewData(strField) = strValue
                Next
                josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objDataSet = Nothing

                '���ɡ��ļ���š�
                Dim strJGDZ As String = objNewData(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JGDZ)
                Dim strWJNF As String = objNewData(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJNF)
                Select Case objenumEditType
                    Case josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        '����ȱʡֵ
                        If Me.getNewWjxh(strErrMsg, strJGDZ, strWJNF, strValue) = False Then
                            GoTo errProc
                        End If
                        objNewData(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJXH) = strValue
                    Case Else
                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doVerifyFile = True
            Exit Function
errProc:
            josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �����¼
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     objSqlTransaction      ����������
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        '     objOldData             ����¼��ֵ
        '     objenumEditType        ���༭����
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doSaveFile( _
            ByRef strErrMsg As String, _
            ByVal objSqlTransaction As System.Data.SqlClient.SqlTransaction, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As josco.JsKernal.Common.Workflow.BaseFlowObject, _
            ByVal objenumEditType As josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim blnNewTrans As Boolean = False
            Dim strSQL As String

            '��ʼ��
            doSaveFile = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doSaveFile]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����[doSaveFile]δ�����µ����ݣ�"
                    GoTo errProc
                End If
                objOldData = CType(objOldData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                Dim strOldWJBS As String
                Dim strOldLSH As String
                Select Case objenumEditType
                    Case josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����[doSaveFile]δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                        strOldWJBS = objOldData.WJBS
                        strOldLSH = objOldData.LSH
                End Select

                '��ȡ������Ϣ
                If objSqlTransaction Is Nothing Then
                    objSqlConnection = Me.SqlConnection
                Else
                    objSqlConnection = objSqlTransaction.Connection
                End If

                '��ʼ����
                If objSqlTransaction Is Nothing Then
                    blnNewTrans = True
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Else
                    blnNewTrans = False
                End If

                '��������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strFileds As String = ""
                    Dim strValues As String = ""
                    Dim strField As String
                    Dim intCount As Integer
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                If strFileds = "" Then
                                    strFileds = objNewData.GetKey(i)
                                Else
                                    strFileds = strFileds + "," + objNewData.GetKey(i)
                                End If
                                If strValues = "" Then
                                    strValues = "@A" + i.ToString()
                                Else
                                    strValues = strValues + "," + "@A" + i.ToString()
                                End If
                            Next

                            strSQL = ""
                            strSQL = strSQL + " insert into �ز�_B_����_¼������ (" + strFileds + ")"
                            strSQL = strSQL + " values (" + strValues + ")"

                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_DDSZ, _
                                        josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_DBRS
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), 0)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), Integer))
                                        End If

                                    Case josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JBRQ, _
                                        josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_QFRQ
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), System.DateTime))
                                        End If

                                    Case Else
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), " ")
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), objNewData.Item(i))
                                        End If
                                End Select
                            Next

                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()

                        Case Else
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                If strFileds = "" Then
                                    strFileds = objNewData.GetKey(i) + " = @A" + i.ToString()
                                Else
                                    strFileds = strFileds + "," + objNewData.GetKey(i) + " = @A" + i.ToString()
                                End If
                            Next

                            strSQL = ""
                            strSQL = strSQL + " update �ز�_B_����_¼������ set "
                            strSQL = strSQL + "   " + strFileds
                            strSQL = strSQL + " where �ļ���ʶ = @oldwjbs"

                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_DDSZ, _
                                        josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_DBRS
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), 0)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), Integer))
                                        End If

                                    Case josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_JBRQ, _
                                        josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_QFRQ
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), System.DateTime))
                                        End If

                                    Case Else
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), " ")
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), objNewData.Item(i))
                                        End If
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldwjbs", strOldWJBS)

                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()
                    End Select

                Catch ex As Exception
                    If blnNewTrans = True Then
                        objSqlTransaction.Rollback()
                    End If
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '�ύ����
                If blnNewTrans = True Then
                    objSqlTransaction.Commit()
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '����
            doSaveFile = True
            Exit Function

errProc:
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �������ļ�
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     intWJND                ��Ҫ���浽�����
        '     objSqlTransaction      ����������
        '     objConnectionProperty  ��FTP���Ӳ���
        '     strGJFile              ��Ҫ����ĸ���ļ��ı��ػ����ļ�����·��
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doSaveGJFile( _
            ByRef strErrMsg As String, _
            ByVal intWJND As Integer, _
            ByVal objSqlTransaction As System.Data.SqlClient.SqlTransaction, _
            ByVal objFTPProperty As josco.JsKernal.Common.Utilities.FTPProperty, _
            ByVal strGJFile As String) As Boolean

            Dim objBaseLocalFile As New josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objBaseFTP As New josco.JsKernal.Common.Utilities.BaseFTP

            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim blnNewTrans As Boolean = False
            Dim strZWNR As String
            Dim strWJBS As String
            Dim strSQL As String

            doSaveGJFile = False
            strErrMsg = ""

            Try
                '����������
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doSaveGJFile]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "����[doSaveGJFile]����û��������ݣ�����ʹ�ã�"
                    GoTo errProc
                End If
                If objFTPProperty Is Nothing Then
                    strErrMsg = "����[doSaveGJFile]û��ָ��FTP�����Ӳ�����"
                    GoTo errProc
                End If
                If strGJFile Is Nothing Then strGJFile = ""
                strGJFile = strGJFile.Trim()
                If strGJFile = "" Then
                    '���ñ���
                    Exit Try
                End If

                '����ļ��Ƿ����?
                Dim blnExisted As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strGJFile, blnExisted) = False Then
                    GoTo errProc
                End If
                If blnExisted = False Then
                    strErrMsg = "���󣺸���ļ�[" + strGJFile + "]�����ڣ�"
                    GoTo errProc
                End If

                '��ȡ�ļ���Ϣ
                Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                strZWNR = objBaseFlowRenshiLuyong.ZWNR
                strWJBS = objBaseFlowRenshiLuyong.WJBS

                '��ȡ�������ļ�
                Dim strBasePath As String = Me.getBasePath_GJ
                Dim strDesFile As String
                If Me.getFTPFileName_GJ(strErrMsg, strGJFile, intWJND, strWJBS, strBasePath, strDesFile) = False Then
                    GoTo errProc
                End If

                '����ԭ�ļ�
                If Me.doBackupFiles_GJ(strErrMsg, strZWNR, objFTPProperty) = False Then
                    GoTo errProc
                End If

                '�����ļ�·��
                '��ȡ��������
                If objSqlTransaction Is Nothing Then
                    objSqlConnection = Me.SqlConnection
                Else
                    objSqlConnection = objSqlTransaction.Connection
                End If
                '��ʼ����
                If objSqlTransaction Is Nothing Then
                    blnNewTrans = True
                    objSqlTransaction = objSqlConnection.BeginTransaction
                Else
                    blnNewTrans = False
                End If

                '�ϴ��ļ�
                Dim strDesUrl As String
                With objFTPProperty
                    strDesUrl = .getUrl(strDesFile)
                    If objBaseFTP.doPutFile(strErrMsg, strGJFile, strDesUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        GoTo rollDatabaseAndFile
                    End If
                End With

                Try
                    '׼���������
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout
                    '׼��SQL
                    strSQL = ""
                    strSQL = strSQL + " update �ز�_B_����_¼������ set "
                    strSQL = strSQL + "   �������� = @zwnr "
                    strSQL = strSQL + " where �ļ���ʶ  = @wjbs "
                    strSQL = strSQL + " and   �������� <> @zwnr "
                    'ִ������
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@zwnr", strDesFile)
                    objSqlCommand.Parameters.AddWithValue("@wjbs", strWJBS)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabaseAndFile
                End Try
                '�ύ����
                If blnNewTrans = True Then
                    objSqlTransaction.Commit()
                End If

                'ɾ�������ļ�
                If blnNewTrans = True Then
                    If Me.doDeleteBackupFiles_GJ(strErrMsg, strZWNR, objFTPProperty) = False Then
                        '���Բ��ɹ����γ������ļ���
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)

            doSaveGJFile = True
            Exit Function

rollDatabaseAndFile:
            If blnNewTrans = True Then
                objSqlTransaction.Rollback()
                If Me.doRestoreFiles_GJ(strSQL, strZWNR, objFTPProperty) = False Then
                    '���Բ��ɹ����γ���������
                End If
            End If
            GoTo errProc

errProc:
            josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���湤������¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        '     objOldData             ����¼��ֵ
        '     objenumEditType        ���༭����
        '     strGJFile              ��Ҫ����ĸ���ļ��ı��ػ����ļ�����·��
        '     objDataSet_FJ          ��Ҫ����ĸ�������
        '     objDataSet_XGWJ        ��Ҫ���������ļ�����
        '     strUserXM              ����ǰ������Ա
        '     blnEnforeEdit          ��ǿ�Ʊ༭�ļ�����
        '     objConnectionProperty  ��FTP���Ӳ���
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doSaveFileTransaction( _
            ByRef strErrMsg As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As josco.JsKernal.Common.Workflow.BaseFlowObject, _
            ByVal objenumEditType As josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal strGJFile As String, _
            ByVal objDataSet_FJ As josco.JsKernal.Common.Data.FlowData, _
            ByVal objDataSet_XGWJ As josco.JsKernal.Common.Data.FlowData, _
            ByVal strUserXM As String, _
            ByVal blnEnforeEdit As Boolean, _
            ByVal objFTPProperty As josco.JsKernal.Common.Utilities.FTPProperty) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection

            Dim objOldFJData As josco.JsKernal.Common.Data.FlowData
            Dim objOldXGWJData As josco.JsKernal.Common.Data.FlowData
            Dim objNewXGWJFJData As josco.JsKernal.Common.Data.FlowData
            Dim objOldXGWJFJData As josco.JsKernal.Common.Data.FlowData

            Dim strCZSM As String = josco.JsKernal.Common.Workflow.BaseFlowObject.LOGO_QXBJ
            Dim intWJND As Integer = Year(Now)
            Dim strOldZWNR As String
            Dim strWJBS As String
            Dim strSQL As String

            doSaveFileTransaction = False

            Try
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doSaveFileTransaction]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "����[doSaveFileTransaction]����û��������ݣ�����ʹ�ã�"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����[doSaveFileTransaction]û��ָ��Ҫ��������ݣ�"
                    GoTo errProc
                End If
                If objFTPProperty Is Nothing Then
                    strErrMsg = "����[doSaveFileTransaction]û��ָ��FTP���Ӳ�����"
                    GoTo errProc
                End If
                If strGJFile Is Nothing Then strGJFile = ""
                strGJFile = strGJFile.Trim
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '�������¼
                If Me.doVerifyFile(strErrMsg, objNewData, objOldData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡ��������
                objSqlConnection = Me.SqlConnection

                '��ȡԭ��������
                Select Case objenumEditType
                    Case josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        strOldZWNR = ""
                        objOldFJData = Nothing
                        objOldXGWJData = Nothing
                        objOldXGWJFJData = Nothing

                    Case Else
                        strOldZWNR = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong).ZWNR
                        If Me.getFujianData(strErrMsg, objOldFJData) = False Then
                            GoTo errProc
                        End If
                        If Me.getXgwjData(strErrMsg, objOldXGWJData) = False Then
                            GoTo errProc
                        End If
                        If Me.doSplitXGWJDataSet(strErrMsg, objOldXGWJData, objOldXGWJFJData) = False Then
                            GoTo errProc
                        End If
                End Select
                If Me.doSplitXGWJDataSet(strErrMsg, objDataSet_XGWJ, objNewXGWJFJData) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction

                'ִ������
                Try
                    '��������¼
                    If Me.doSaveFile(strErrMsg, objSqlTransaction, objNewData, objOldData, objenumEditType) = False Then
                        GoTo rollDatabase
                    End If

                    '�������ļ���ʶ
                    strWJBS = objNewData(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJBS)
                    Me.FlowData.WJBS = strWJBS

                    '���������
                    Select Case objenumEditType
                        Case josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '�����ʼ��������
                            If Me.doSaveInitJJD(strErrMsg, objSqlTransaction, strUserXM, strUserXM) = False Then
                                GoTo rollDatabase
                            End If
                        Case Else
                    End Select

                    '�������ļ�
                    If Me.doSaveGJFile(strErrMsg, intWJND, objSqlTransaction, objFTPProperty, strGJFile) = False Then
                        GoTo rollGJFile
                    End If

                    '���渽���ļ�
                    If Me.doSaveFujian(strErrMsg, strWJBS, intWJND, objSqlTransaction, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                        GoTo rollGJAndFJFile
                    End If

                    '��������ļ�����
                    If Me.doSaveXgwj(strErrMsg, strWJBS, intWJND, objSqlTransaction, objFTPProperty, objDataSet_XGWJ, objOldXGWJData, objNewXGWJFJData, objOldXGWJFJData) = False Then
                        GoTo rollGJAndFJAndXGWJFile
                    End If

                    '�����ǿ�Ʊ༭
                    If blnEnforeEdit = True Then
                        If Me.doWriteFileLogo(strErrMsg, objSqlTransaction, strUserXM, strCZSM) = False Then
                            GoTo rollGJAndFJAndXGWJFile
                        End If
                    End If

                    '����ļ��༭����
                    If Me.doLockFile(strErrMsg, objSqlTransaction, "", False) = False Then
                        GoTo rollGJAndFJAndXGWJFile
                    End If

                    '��������ļ�
                    If Me.doDeleteBackupFiles_GJ(strErrMsg, strOldZWNR, objFTPProperty) = False Then
                        '���Բ��ɹ����γ������ļ�
                    End If
                    If Me.doDeleteBackupFiles_FJ(strErrMsg, objFTPProperty, objOldFJData) = False Then
                        '���Բ��ɹ����γ������ļ�
                    End If
                    If Me.doDeleteBackupFiles_XGWJFJ(strErrMsg, objFTPProperty, objOldXGWJFJData) = False Then
                        '���Բ��ɹ����γ������ļ�
                    End If

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabase
                End Try

                '�ύ����
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldFJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldXGWJFJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objNewXGWJFJData)

            doSaveFileTransaction = True
            Exit Function

rollGJAndFJAndXGWJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '�Ѿ������ˣ�
            End If
            If Me.doRestoreFiles_FJ(strSQL, strWJBS, intWJND, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                '�Ѿ������ˣ�
            End If
            If Me.doRestoreFiles_XGWJFJ(strSQL, strWJBS, intWJND, objFTPProperty, objNewXGWJFJData, objOldXGWJFJData) = False Then
                '�Ѿ������ˣ�
            End If
            GoTo errProc

rollGJAndFJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '�Ѿ������ˣ�
            End If
            If Me.doRestoreFiles_FJ(strSQL, strWJBS, intWJND, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                '�Ѿ������ˣ�
            End If
            GoTo errProc

rollGJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '�Ѿ������ˣ�
            End If
            GoTo errProc

rollDatabase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldFJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldXGWJFJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objNewXGWJFJData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_¼������_��Ա��Ϣ������
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strWJBS                ���ļ���ʶ
        '     objSqlTransaction      ����������
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Private Function doSaveRyxx( _
            ByRef strErrMsg As String, _
            ByVal strWJBS As String, _
            ByVal objSqlTransaction As System.Data.SqlClient.SqlTransaction, _
            ByRef objNewData As josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean

            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand

            Dim strTable As String = josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI_RENYUANXINXI
            Dim blnNewTrans As Boolean = False
            Dim strSQL As String

            Dim objPulicParameters As New josco.JsKernal.Common.Utilities.PulicParameters

            '��ʼ��
            doSaveRyxx = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "���󣺶���û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                If strWJBS Is Nothing Then strWJBS = ""
                strWJBS = strWJBS.Trim
                If strWJBS = "" Then
                    Exit Try
                End If

                '��ȡ������Ϣ
                If objSqlTransaction Is Nothing Then
                    objSqlConnection = Me.SqlConnection
                Else
                    objSqlConnection = objSqlTransaction.Connection
                End If

                '��ʼ����
                If objSqlTransaction Is Nothing Then
                    blnNewTrans = True
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Else
                    blnNewTrans = False
                End If

                '��������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ɾ�����ز�_B_����_¼������_��Ա��Ϣ������
                    strSQL = ""
                    strSQL = strSQL + " delete from �ز�_B_����_¼������_��Ա��Ϣ " + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = @wjbs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@wjbs", strWJBS)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    Try
                        '����������
                        Dim strValue As String = ""
                        Dim intCount As Integer
                        Dim i As Integer
                        With objNewData.Tables(strTable)
                            intCount = .DefaultView.Count
                            For i = 0 To intCount - 1 Step 1
                                'д����
                                strSQL = ""
                                strSQL = strSQL + " insert into �ز�_B_����_¼������_��Ա��Ϣ (" + vbCr
                                strSQL = strSQL + "   Ψһ��ʶ,�ļ���ʶ,��Ա���,��Ա����,�������,��Ա����,��Ա�Ա�,��Ա����,��Աѧ��,����䲿��,�ⵣ��ְλ,�ⱨ������,��Ƹ˵��,������Ա��,������Ա��" + vbCr
                                strSQL = strSQL + " ) values (" + vbCr
                                strSQL = strSQL + "   newid(),@wjbs,@ryxh,@rydm,@jlbh,@ryxm,@ryxb,@rynn,@ryxl,@nfpbm,@ndrzw,@nbdrq,@zpsm,@xyrys,@dbrys" + vbCr
                                strSQL = strSQL + " )" + vbCr
                                objSqlCommand.Parameters.Clear()
                                objSqlCommand.Parameters.AddWithValue("@wjbs", strWJBS)
                                objSqlCommand.Parameters.AddWithValue("@ryxh", (i + 1))
                                objSqlCommand.Parameters.AddWithValue("@rydm", objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYDM), ""))
                                objSqlCommand.Parameters.AddWithValue("@jlbh", objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_JLBH), ""))
                                objSqlCommand.Parameters.AddWithValue("@ryxm", objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXM), ""))
                                objSqlCommand.Parameters.AddWithValue("@ryxb", objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXB), ""))
                                objSqlCommand.Parameters.AddWithValue("@rynn", objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYNN), 0))
                                objSqlCommand.Parameters.AddWithValue("@ryxl", objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXL), ""))
                                objSqlCommand.Parameters.AddWithValue("@nfpbm", objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NFPBM), ""))
                                objSqlCommand.Parameters.AddWithValue("@ndrzw", objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NDRZW), ""))
                                strValue = objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NBDRQ), "")
                                If strValue = "" Then
                                    objSqlCommand.Parameters.AddWithValue("@nbdrq", System.DBNull.Value)
                                Else
                                    objSqlCommand.Parameters.AddWithValue("@nbdrq", CType(strValue, System.DateTime))
                                End If
                                objSqlCommand.Parameters.AddWithValue("@zpsm", objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_ZPSM), ""))
                                objSqlCommand.Parameters.AddWithValue("@xyrys", objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_XYRYS), 0))
                                objSqlCommand.Parameters.AddWithValue("@dbrys", objPulicParameters.getObjectValue(.DefaultView.Item(i).Item(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_DBRYS), 0))
                                objSqlCommand.CommandText = strSQL
                                objSqlCommand.ExecuteNonQuery()
                            Next
                        End With
                    Catch ex As Exception
                        strErrMsg = ex.Message
                        GoTo rollDatabase
                    End Try
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabase
                End Try

                '�ύ����
                If blnNewTrans = True Then
                    objSqlTransaction.Commit()
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '����
            doSaveRyxx = True
            Exit Function

rollDatabase:
            If blnNewTrans = True Then
                objSqlTransaction.Rollback()
            End If
            GoTo errProc

errProc:
            josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���湤������¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        '     objOldData             ����¼��ֵ
        '     objenumEditType        ���༭����
        '     strGJFile              ��Ҫ����ĸ���ļ��ı��ػ����ļ�����·��
        '     objDataSet_FJ          ��Ҫ����ĸ�������
        '     objDataSet_XGWJ        ��Ҫ���������ļ�����
        '     strUserXM              ����ǰ������Ա
        '     blnEnforeEdit          ��ǿ�Ʊ༭�ļ�����
        '     objConnectionProperty  ��FTP���Ӳ���
        '     objParams              ������Ҫ�������ύ������
        '                              0 - ���ز�_B_����_¼������_��Ա��Ϣ�����ݼ�
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doSaveFileTransactionVariantParam( _
            ByRef strErrMsg As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As josco.JsKernal.Common.Workflow.BaseFlowObject, _
            ByVal objenumEditType As josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal strGJFile As String, _
            ByVal objDataSet_FJ As josco.JsKernal.Common.Data.FlowData, _
            ByVal objDataSet_XGWJ As josco.JsKernal.Common.Data.FlowData, _
            ByVal strUserXM As String, _
            ByVal blnEnforeEdit As Boolean, _
            ByVal objFTPProperty As josco.JsKernal.Common.Utilities.FTPProperty, _
            ByVal objParams As System.Collections.Specialized.ListDictionary) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection

            Dim objOldFJData As josco.JsKernal.Common.Data.FlowData
            Dim objOldXGWJData As josco.JsKernal.Common.Data.FlowData
            Dim objNewXGWJFJData As josco.JsKernal.Common.Data.FlowData
            Dim objOldXGWJFJData As josco.JsKernal.Common.Data.FlowData

            Dim strCZSM As String = josco.JsKernal.Common.Workflow.BaseFlowObject.LOGO_QXBJ
            Dim intWJND As Integer = Year(Now)
            Dim strOldZWNR As String
            Dim strWJBS As String
            Dim strSQL As String

            doSaveFileTransactionVariantParam = False

            Try
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doSaveFileTransactionVariantParam]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "����[doSaveFileTransactionVariantParam]����û��������ݣ�����ʹ�ã�"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����[doSaveFileTransactionVariantParam]û��ָ��Ҫ��������ݣ�"
                    GoTo errProc
                End If
                If objFTPProperty Is Nothing Then
                    strErrMsg = "����[doSaveFileTransactionVariantParam]û��ָ��FTP���Ӳ�����"
                    GoTo errProc
                End If
                If strGJFile Is Nothing Then strGJFile = ""
                strGJFile = strGJFile.Trim
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '�������¼
                If Me.doVerifyFile(strErrMsg, objNewData, objOldData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡ��������
                objSqlConnection = Me.SqlConnection

                '��ȡԭ��������
                Select Case objenumEditType
                    Case josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        strOldZWNR = ""
                        objOldFJData = Nothing
                        objOldXGWJData = Nothing
                        objOldXGWJFJData = Nothing

                    Case Else
                        strOldZWNR = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong).ZWNR
                        If Me.getFujianData(strErrMsg, objOldFJData) = False Then
                            GoTo errProc
                        End If
                        If Me.getXgwjData(strErrMsg, objOldXGWJData) = False Then
                            GoTo errProc
                        End If
                        If Me.doSplitXGWJDataSet(strErrMsg, objOldXGWJData, objOldXGWJFJData) = False Then
                            GoTo errProc
                        End If
                End Select
                If Me.doSplitXGWJDataSet(strErrMsg, objDataSet_XGWJ, objNewXGWJFJData) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction

                'ִ������
                Try
                    '��������¼
                    If Me.doSaveFile(strErrMsg, objSqlTransaction, objNewData, objOldData, objenumEditType) = False Then
                        GoTo rollDatabase
                    End If

                    '�������ļ���ʶ
                    strWJBS = objNewData(josco.JSOA.Common.Data.estateRenshiXingyeData.FIELD_DC_B_RS_LUYONGSHENPI_WJBS)
                    Me.FlowData.WJBS = strWJBS

                    '���������
                    Select Case objenumEditType
                        Case josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '�����ʼ��������
                            If Me.doSaveInitJJD(strErrMsg, objSqlTransaction, strUserXM, strUserXM) = False Then
                                GoTo rollDatabase
                            End If
                        Case Else
                    End Select

                    '������������
                    If Not (objParams Is Nothing) Then
                        If objParams.Count > 0 Then
                            Dim objDataSet_RYXX As josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
                            Try
                                objDataSet_RYXX = CType(objParams.Item(0), josco.JSOA.Common.Data.estateRenshiXingyeData)
                            Catch ex As Exception
                                objDataSet_RYXX = Nothing
                            End Try
                            If Not (objDataSet_RYXX Is Nothing) Then
                                If Me.doSaveRyxx(strErrMsg, strWJBS, objSqlTransaction, objDataSet_RYXX) = False Then
                                    GoTo rollDatabase
                                End If
                            End If
                        End If
                    End If

                    '�������ļ�
                    If Me.doSaveGJFile(strErrMsg, intWJND, objSqlTransaction, objFTPProperty, strGJFile) = False Then
                        GoTo rollGJFile
                    End If

                    '���渽���ļ�
                    If Me.doSaveFujian(strErrMsg, strWJBS, intWJND, objSqlTransaction, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                        GoTo rollGJAndFJFile
                    End If

                    '��������ļ�����
                    If Me.doSaveXgwj(strErrMsg, strWJBS, intWJND, objSqlTransaction, objFTPProperty, objDataSet_XGWJ, objOldXGWJData, objNewXGWJFJData, objOldXGWJFJData) = False Then
                        GoTo rollGJAndFJAndXGWJFile
                    End If

                    '�����ǿ�Ʊ༭
                    If blnEnforeEdit = True Then
                        If Me.doWriteFileLogo(strErrMsg, objSqlTransaction, strUserXM, strCZSM) = False Then
                            GoTo rollGJAndFJAndXGWJFile
                        End If
                    End If

                    '����ļ��༭����
                    If Me.doLockFile(strErrMsg, objSqlTransaction, "", False) = False Then
                        GoTo rollGJAndFJAndXGWJFile
                    End If

                    '��������ļ�
                    If Me.doDeleteBackupFiles_GJ(strErrMsg, strOldZWNR, objFTPProperty) = False Then
                        '���Բ��ɹ����γ������ļ�
                    End If
                    If Me.doDeleteBackupFiles_FJ(strErrMsg, objFTPProperty, objOldFJData) = False Then
                        '���Բ��ɹ����γ������ļ�
                    End If
                    If Me.doDeleteBackupFiles_XGWJFJ(strErrMsg, objFTPProperty, objOldXGWJFJData) = False Then
                        '���Բ��ɹ����γ������ļ�
                    End If

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabase
                End Try

                '�ύ����
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldFJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldXGWJFJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objNewXGWJFJData)

            doSaveFileTransactionVariantParam = True
            Exit Function

rollGJAndFJAndXGWJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '�Ѿ������ˣ�
            End If
            If Me.doRestoreFiles_FJ(strSQL, strWJBS, intWJND, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                '�Ѿ������ˣ�
            End If
            If Me.doRestoreFiles_XGWJFJ(strSQL, strWJBS, intWJND, objFTPProperty, objNewXGWJFJData, objOldXGWJFJData) = False Then
                '�Ѿ������ˣ�
            End If
            GoTo errProc

rollGJAndFJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '�Ѿ������ˣ�
            End If
            If Me.doRestoreFiles_FJ(strSQL, strWJBS, intWJND, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                '�Ѿ������ˣ�
            End If
            GoTo errProc

rollGJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '�Ѿ������ˣ�
            End If
            GoTo errProc

rollDatabase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldFJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldXGWJFJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objNewXGWJFJData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���湤�������������������ļ���¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strGJFile              ��Ҫ����ĸ���ļ��ı��ػ����ļ�����·��
        '     objDataSet_FJ          ��Ҫ����ĸ�������
        '     objDataSet_XGWJ        ��Ҫ���������ļ�����
        '     strUserXM              ����ǰ������Ա
        '     blnEnforeEdit          ��ǿ�Ʊ༭�ļ�����
        '     objFTPProperty         ��FTP���Ӳ���
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doSaveFileTransactionZDBC( _
            ByRef strErrMsg As String, _
            ByVal strGJFile As String, _
            ByVal objDataSet_FJ As josco.JsKernal.Common.Data.FlowData, _
            ByVal objDataSet_XGWJ As josco.JsKernal.Common.Data.FlowData, _
            ByVal strUserXM As String, _
            ByVal blnEnforeEdit As Boolean, _
            ByVal objFTPProperty As josco.JsKernal.Common.Utilities.FTPProperty) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection

            Dim objOldFJData As josco.JsKernal.Common.Data.FlowData
            Dim objOldXGWJData As josco.JsKernal.Common.Data.FlowData
            Dim objOldXGWJFJData As josco.JsKernal.Common.Data.FlowData
            Dim objNewXGWJFJData As josco.JsKernal.Common.Data.FlowData

            Dim strCZSM As String = josco.JsKernal.Common.Workflow.BaseFlowObject.LOGO_QXBJ
            Dim intWJND As Integer = Year(Now)
            Dim strOldZWNR As String
            Dim strWJBS As String
            Dim strSQL As String

            doSaveFileTransactionZDBC = False

            Try
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doSaveFileTransactionZDBC]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "����[doSaveFileTransactionZDBC]����û�л�ȡ���ݣ�����ʹ�ã�"
                    GoTo errProc
                End If
                If objFTPProperty Is Nothing Then
                    strErrMsg = "����[doSaveFileTransactionZDBC]û��ָ��FTP���Ӳ�����"
                    GoTo errProc
                End If
                If strGJFile Is Nothing Then strGJFile = ""
                strGJFile = strGJFile.Trim
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '��ȡ����
                strOldZWNR = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong).ZWNR
                objSqlConnection = Me.SqlConnection
                strWJBS = Me.WJBS

                '��ȡԭ��������
                If Me.getFujianData(strErrMsg, objOldFJData) = False Then
                    GoTo errProc
                End If

                '��ȡԭ����ļ�����
                If Me.getXgwjData(strErrMsg, objOldXGWJData) = False Then
                    GoTo errProc
                End If
                '�����ԭ��ظ���
                If Me.doSplitXGWJDataSet(strErrMsg, objOldXGWJData, objOldXGWJFJData) = False Then
                    GoTo errProc
                End If
                '���������ظ���
                If Me.doSplitXGWJDataSet(strErrMsg, objDataSet_XGWJ, objNewXGWJFJData) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction

                'ִ������
                Try
                    '�������ļ�
                    If Me.doSaveGJFile(strErrMsg, intWJND, objSqlTransaction, objFTPProperty, strGJFile) = False Then
                        GoTo rollGJFile
                    End If

                    '���渽���ļ�
                    If Me.doSaveFujian(strErrMsg, strWJBS, intWJND, objSqlTransaction, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                        GoTo rollGJAndFJFile
                    End If

                    '��������ļ�����
                    If Me.doSaveXgwj(strErrMsg, strWJBS, intWJND, objSqlTransaction, objFTPProperty, objDataSet_XGWJ, objOldXGWJData, objNewXGWJFJData, objOldXGWJFJData) = False Then
                        GoTo rollGJAndFJAndXGWJFile
                    End If

                    '�����ǿ�Ʊ༭
                    If blnEnforeEdit = True Then
                        If Me.doWriteFileLogo(strErrMsg, objSqlTransaction, strUserXM, strCZSM) = False Then
                            GoTo rollGJAndFJAndXGWJFile
                        End If
                    End If

                    '����ļ��༭����
                    If Me.doLockFile(strErrMsg, objSqlTransaction, "", False) = False Then
                        GoTo rollGJAndFJAndXGWJFile
                    End If

                    '��������ļ�
                    If Me.doDeleteBackupFiles_GJ(strErrMsg, strOldZWNR, objFTPProperty) = False Then
                        '���Բ��ɹ����γ������ļ�
                    End If
                    If Me.doDeleteBackupFiles_FJ(strErrMsg, objFTPProperty, objOldFJData) = False Then
                        '���Բ��ɹ����γ������ļ�
                    End If
                    If Me.doDeleteBackupFiles_XGWJFJ(strErrMsg, objFTPProperty, objOldXGWJFJData) = False Then
                        '���Բ��ɹ����γ������ļ�
                    End If

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabase
                End Try

                '�ύ����
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldFJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldXGWJFJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objNewXGWJFJData)

            doSaveFileTransactionZDBC = True
            Exit Function

rollGJAndFJAndXGWJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '�Ѿ������ˣ�
            End If
            If Me.doRestoreFiles_FJ(strSQL, strWJBS, intWJND, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                '�Ѿ������ˣ�
            End If
            If Me.doRestoreFiles_XGWJFJ(strSQL, strWJBS, intWJND, objFTPProperty, objNewXGWJFJData, objOldXGWJFJData) = False Then
                '�Ѿ������ˣ�
            End If
            GoTo errProc

rollGJAndFJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '�Ѿ������ˣ�
            End If
            If Me.doRestoreFiles_FJ(strSQL, strWJBS, intWJND, objFTPProperty, objDataSet_FJ, objOldFJData) = False Then
                '�Ѿ������ˣ�
            End If
            GoTo errProc

rollGJFile:
            objSqlTransaction.Rollback()
            If Me.doRestoreFiles_GJ(strSQL, strOldZWNR, objFTPProperty) = False Then
                '�Ѿ������ˣ�
            End If
            GoTo errProc

rollDatabase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldFJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldXGWJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objOldXGWJFJData)
            josco.JsKernal.Common.Data.FlowData.SafeRelease(objNewXGWJFJData)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���湤�������������������ļ���¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strGJFile              ��Ҫ����ĸ���ļ��ı��ػ����ļ�����·��
        '     objDataSet_FJ          ��Ҫ����ĸ�������
        '     objDataSet_XGWJ        ��Ҫ���������ļ�����
        '     strUserXM              ����ǰ������Ա
        '     blnEnforeEdit          ��ǿ�Ʊ༭�ļ�����
        '     objFTPProperty         ��FTP���Ӳ���
        '     objParams              ������Ҫ�������ύ������
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doSaveFileTransactionZDBCVariantParam( _
            ByRef strErrMsg As String, _
            ByVal strGJFile As String, _
            ByVal objDataSet_FJ As josco.JsKernal.Common.Data.FlowData, _
            ByVal objDataSet_XGWJ As josco.JsKernal.Common.Data.FlowData, _
            ByVal strUserXM As String, _
            ByVal blnEnforeEdit As Boolean, _
            ByVal objFTPProperty As josco.JsKernal.Common.Utilities.FTPProperty, _
            ByVal objParams As System.Collections.Specialized.ListDictionary) As Boolean

            doSaveFileTransactionZDBCVariantParam = False

            Try
                doSaveFileTransactionZDBCVariantParam = Me.doSaveFileTransactionZDBC(strErrMsg, strGJFile, objDataSet_FJ, objDataSet_XGWJ, strUserXM, blnEnforeEdit, objFTPProperty)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doSaveFileTransactionZDBCVariantParam = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �����������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strOldBlsy           ������ǰ�İ�������
        '     strNewBlsy           �������İ�������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doTranslateTask( _
            ByRef strErrMsg As String, _
            ByVal strOldBlsy As String, _
            ByRef strNewBlsy As String) As Boolean

            doTranslateTask = False
            strErrMsg = ""
            strNewBlsy = strOldBlsy

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doTranslateTask]������û�г�ʼ����"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "����[doTranslateTask]������û��������ݣ�"
                    GoTo errProc
                End If
                If strOldBlsy Is Nothing Then
                    Exit Try
                End If
                strOldBlsy = strOldBlsy.Trim

                '����
                Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                Select Case strOldBlsy
                    Case objBaseFlowRenshiLuyong.TASK_CYCG
                        strNewBlsy = objBaseFlowRenshiLuyong.TASK_GJBJ
                    Case Else
                        strNewBlsy = strOldBlsy
                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            doTranslateTask = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �����ݻ�����ҵ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserXM            ���û�����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doIStopFile( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objdacCustomer As New josco.JsKernal.DataAccess.dacCustomer

            doIStopFile = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doIStopFile]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '��ȡ�ļ���Ϣ
                Dim strTaskStatusYWCList As String = Me.FlowData.TaskStatusYWCList
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '��ȡ��������
                objSqlConnection = Me.SqlConnection

                '��ȡ��Ա����
                Dim strUserId As String
                If objdacCustomer.getRydmByRymc(strErrMsg, objSqlConnection, strUserXM, strUserId) = False Then
                    GoTo errProc
                End If
                If strUserId <> "" Then
                    '����Լ����ļ�����
                    If Me.doLockFile(strErrMsg, strUserId, False) = False Then
                        GoTo errProc
                    End If
                End If

                '����Ƿ������ڱ༭���ļ���
                Dim blnLocked As Boolean
                Dim strBMMC As String
                Dim strRYMC As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If
                If blnLocked = True Then
                    strErrMsg = "����[" + strBMMC + "]��[" + strRYMC + "]�����޸ı��ļ�[" + strWJBS + "]�����Ժ��ٽ��д���"
                    GoTo errProc
                End If

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '������
                Try
                    strSQL = ""
                    strSQL = strSQL + " update ����_B_���� set" + vbCr
                    strSQL = strSQL + "   ����״̬ = '" + Me.FlowData.TASKSTATUS_YTB + "'," + vbCr
                    strSQL = strSQL + "   ������� = '" + Format(Now, "yyyy-MM-dd HH:mm:ss") + "'" + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr                       '��ǰ�ļ�
                    strSQL = strSQL + " and   ������   = '" + strUserXM + "'" + vbCr                     '������
                    strSQL = strSQL + " and   ���ӱ�ʶ like '_____0%'" + vbCr                            '��֪ͨ��
                    strSQL = strSQL + " and   ����״̬ not in (" + strTaskStatusYWCList + ")" + vbCr     'δ���
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    strSQL = ""
                    strSQL = strSQL + " update �ز�_B_����_¼������ set" + vbCr
                    strSQL = strSQL + "   ����״̬ = '" + Me.FlowData.FILESTATUS_YTB + "'" + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr                       '��ǰ�ļ�
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '�ύ����
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)

            doIStopFile = True
            Exit Function

errProc:
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������������ҵ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserXM            ���û�����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doIContinueFile( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objdacCustomer As New josco.JsKernal.DataAccess.dacCustomer

            doIContinueFile = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doIContinueFile]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '��ȡ�ļ���Ϣ
                Dim strTaskStatusYWCList As String = Me.FlowData.TaskStatusYWCList
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '��ȡ��������
                objSqlConnection = Me.SqlConnection

                '��ȡ��Ա����
                Dim strUserId As String
                If objdacCustomer.getRydmByRymc(strErrMsg, objSqlConnection, strUserXM, strUserId) = False Then
                    GoTo errProc
                End If
                If strUserId <> "" Then
                    '����Լ����ļ�����
                    If Me.doLockFile(strErrMsg, strUserId, False) = False Then
                        GoTo errProc
                    End If
                End If

                '����Ƿ������ڱ༭���ļ���
                Dim blnLocked As Boolean
                Dim strBMMC As String
                Dim strRYMC As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If
                If blnLocked = True Then
                    strErrMsg = "����[" + strBMMC + "]��[" + strRYMC + "]�����޸ı��ļ�[" + strWJBS + "]�����Ժ��ٽ��д���"
                    GoTo errProc
                End If

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '������
                Try
                    strSQL = ""
                    strSQL = strSQL + " update ����_B_���� set" + vbCr
                    strSQL = strSQL + "   ����״̬ = '" + Me.FlowData.TASKSTATUS_ZJB + "'" + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr                       '��ǰ�ļ�
                    strSQL = strSQL + " and   ������   = '" + strUserXM + "'" + vbCr                     '������
                    strSQL = strSQL + " and   ����״̬ = '" + Me.FlowData.TASKSTATUS_YTB + "'" + vbCr    '��ͣ��
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    strSQL = ""
                    strSQL = strSQL + " update �ز�_B_����_¼������ set" + vbCr
                    strSQL = strSQL + "   ����״̬ = '" + Me.FlowData.FILESTATUS_ZJB + "'" + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr                       '��ǰ�ļ�
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '�ύ����
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)

            doIContinueFile = True
            Exit Function

errProc:
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���������ļ���ҵ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserXM            ���û�����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doIZuofeiFile( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objdacCustomer As New josco.JsKernal.DataAccess.dacCustomer

            doIZuofeiFile = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doIZuofeiFile]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '��ȡ�ļ���Ϣ
                Dim strTaskStatusYWCList As String = Me.FlowData.TaskStatusYWCList
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '��ȡ��������
                objSqlConnection = Me.SqlConnection

                '��ȡ��Ա����
                Dim strUserId As String
                If objdacCustomer.getRydmByRymc(strErrMsg, objSqlConnection, strUserXM, strUserId) = False Then
                    GoTo errProc
                End If
                If strUserId <> "" Then
                    '����Լ����ļ�����
                    If Me.doLockFile(strErrMsg, strUserId, False) = False Then
                        GoTo errProc
                    End If
                End If

                '����Ƿ������ڱ༭���ļ���
                Dim blnLocked As Boolean
                Dim strBMMC As String
                Dim strRYMC As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If
                If blnLocked = True Then
                    strErrMsg = "����[" + strBMMC + "]��[" + strRYMC + "]�����޸ı��ļ�[" + strWJBS + "]�����Ժ��ٽ��д���"
                    GoTo errProc
                End If

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '������
                Try
                    strSQL = ""
                    strSQL = strSQL + " update �ز�_B_����_¼������ set" + vbCr
                    strSQL = strSQL + "   ����״̬ = '" + Me.FlowData.FILESTATUS_YZF + "'" + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr                       '��ǰ�ļ�
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '�ύ����
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)

            doIZuofeiFile = True
            Exit Function

errProc:
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���������ļ���ҵ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserXM            ���û�����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doIQiyongFile( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objdacCustomer As New josco.JsKernal.DataAccess.dacCustomer

            doIQiyongFile = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doIQiyongFile]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '��ȡ�ļ���Ϣ
                Dim strTaskStatusYWCList As String = Me.FlowData.TaskStatusYWCList
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '��ȡ��������
                objSqlConnection = Me.SqlConnection

                '��ȡ��Ա����
                Dim strUserId As String
                If objdacCustomer.getRydmByRymc(strErrMsg, objSqlConnection, strUserXM, strUserId) = False Then
                    GoTo errProc
                End If
                If strUserId <> "" Then
                    '����Լ����ļ�����
                    If Me.doLockFile(strErrMsg, strUserId, False) = False Then
                        GoTo errProc
                    End If
                End If

                '����Ƿ������ڱ༭���ļ���
                Dim blnLocked As Boolean
                Dim strBMMC As String
                Dim strRYMC As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If
                If blnLocked = True Then
                    strErrMsg = "����[" + strBMMC + "]��[" + strRYMC + "]�����޸ı��ļ�[" + strWJBS + "]�����Ժ��ٽ��д���"
                    GoTo errProc
                End If

                'ֻ�г�ʼ��������
                If Me.isOriginalPeople(strErrMsg, strUserXM, blnLocked) = False Then
                    GoTo errProc
                End If
                If blnLocked = False Then
                    strErrMsg = "����ֻ������˲������ø����"
                    GoTo errProc
                End If

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '������
                Try
                    'ɾ���ļ�������Ϣ
                    strSQL = "delete from ����_B_�ļ����� where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ��������Ϣ
                    strSQL = "delete from ����_B_���� where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ���߰���Ϣ
                    strSQL = "delete from ����_B_�߰� where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ�����İ�����Ϣ
                    strSQL = "delete from ����_B_���� where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ�����ĳа���Ϣ
                    strSQL = "delete from ����_B_�а� where �ļ���ʶ = '" + strWJBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ�����Ľ�����Ϣ
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_����" + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr  '��ǰ�ļ�
                    strSQL = strSQL + " and   ���ӱ�ʶ like '1%' " + vbCr           '�ǳ�ʼ����
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '���³�ʼ������Ϣ
                    strSQL = ""
                    strSQL = strSQL + " update ����_B_���� set" + vbCr
                    strSQL = strSQL + "   ������� = NULL," + vbCr
                    strSQL = strSQL + "   ����״̬ = '" + Me.FlowData.TASKSTATUS_ZJB + "'" + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr  '��ǰ�ļ�
                    strSQL = strSQL + " and   ���ӱ�ʶ like '0%'" + vbCr            '��ʼ����
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '�����������
                    strSQL = ""
                    strSQL = strSQL + " update �ز�_B_����_¼������ set" + vbCr
                    strSQL = strSQL + "   �������� = '" + Format(Now, "yyyy-MM-dd HH:mm:ss") + "'," + vbCr
                    strSQL = strSQL + "   ǩ���� = ' '," + vbCr
                    strSQL = strSQL + "   ǩ������ = NULL," + vbCr
                    strSQL = strSQL + "   ����״̬ = '" + Me.FlowData.FILESTATUS_ZJB + "'" + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '�ύ����
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)

            doIQiyongFile = True
            Exit Function

errProc:
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �����ļ���ᡱҵ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserXM            ���û�����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ���ļ�¼
        '     ������ 2008-04-01 
        '       (1) д�롰��ʾ��š�������
        '     zengxianglin 2009-05-15 ����
        '----------------------------------------------------------------
        Public Overrides Function doCompleteFile( _
            ByRef strErrMsg As String, _
            ByVal strUserXM As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objdacCustomer As New josco.JsKernal.DataAccess.dacCustomer

            doCompleteFile = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doCompleteFile]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "����[doCompleteFile]����û��������ݣ�����ʹ�ã�"
                    GoTo errProc
                End If
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '��ȡ�ļ���Ϣ
                Dim strTaskStatusYWCList As String = Me.FlowData.TaskStatusYWCList
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '��ȡ��������
                objSqlConnection = Me.SqlConnection

                '��ȡ��Ա����
                Dim strUserId As String
                If objdacCustomer.getRydmByRymc(strErrMsg, objSqlConnection, strUserXM, strUserId) = False Then
                    GoTo errProc
                End If
                If strUserId <> "" Then
                    '����Լ����ļ�����
                    If Me.doLockFile(strErrMsg, strUserId, False) = False Then
                        GoTo errProc
                    End If
                End If

                '����Ƿ������ڱ༭���ļ���
                Dim blnLocked As Boolean
                Dim strBMMC As String
                Dim strRYMC As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If
                If blnLocked = True Then
                    strErrMsg = "����[" + strBMMC + "]��[" + strRYMC + "]�����޸ı��ļ�[" + strWJBS + "]�����Ժ��ٽ��д���"
                    GoTo errProc
                End If

                ''����������Ӽ�������ɨ���
                'Dim objBaseFlowRenshiLuyong As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                'objBaseFlowRenshiLuyong = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                'If objBaseFlowRenshiLuyong.QFR <> "" Then      '��ǩ����
                '    If objBaseFlowRenshiLuyong.HJWJ = "" Then  '�������Ӽ�
                '        strErrMsg = "����ǩ���ļ����Ӽ�û�е��룬�����ܰ�ᣡ"
                '        GoTo errProc
                '    End If
                '    If objBaseFlowRenshiLuyong.PJYJ = "" Then  '����ɨ���
                '        strErrMsg = "����ǩ���ļ�ɨ���û�е��룬�����ܰ�ᣡ"
                '        GoTo errProc
                '    End If
                'End If

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '������
                Try
                    '�����Լ���ȫ�����˰������
                    strSQL = ""
                    strSQL = strSQL + " update ����_B_���� set " + vbCr
                    strSQL = strSQL + "   ����״̬ = '" + Me.FlowData.TASKSTATUS_YWC + "'," + vbCr
                    strSQL = strSQL + "   ������� = '" + Format(Now, "yyyy-MM-dd HH:mm:ss") + "'" + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr                      '��ǰ�ļ�
                    strSQL = strSQL + " and   ������   = '" + strUserXM + "'" + vbCr                    '������
                    strSQL = strSQL + " and   ����״̬ not in (" + strTaskStatusYWCList + ")" + vbCr    'δ����
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'zengxianglin 2009-05-15
                    '[�ز�_B_����_¼������_��Ա��Ϣ][����䲿��]д��[�ز�_B_����_��������][���ò���]
                    strSQL = ""
                    strSQL = strSQL + " update �ز�_B_����_�������� set" + vbCr
                    strSQL = strSQL + "   ���ò��� = b.��֯����" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_�������� a" + vbCr
                    strSQL = strSQL + " left join" + vbCr
                    strSQL = strSQL + " (" + vbCr
                    strSQL = strSQL + "   select a.*,b.��֯����" + vbCr
                    strSQL = strSQL + "   from" + vbCr
                    strSQL = strSQL + "   (" + vbCr
                    strSQL = strSQL + "     select *" + vbCr
                    strSQL = strSQL + "     from �ز�_B_����_¼������_��Ա��Ϣ" + vbCr
                    strSQL = strSQL + "     where �ļ���ʶ = @wjbs" + vbCr
                    strSQL = strSQL + "     and   ����䲿�� <> ''" + vbCr
                    strSQL = strSQL + "   ) a" + vbCr
                    strSQL = strSQL + "   left join ����_B_��֯���� b on a.����䲿��=b.��֯����" + vbCr
                    strSQL = strSQL + "   where b.��֯���� is not null" + vbCr
                    strSQL = strSQL + " ) b on a.�������=b.�������" + vbCr
                    strSQL = strSQL + " where b.������� is not null" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@wjbs", strWJBS)
                    objSqlCommand.ExecuteNonQuery()
                    'zengxianglin 2009-05-15

                    'д�ļ���ɱ�ʶ
                    strSQL = ""
                    strSQL = strSQL + " update �ز�_B_����_¼������ set " + vbCr
                    strSQL = strSQL + "   ����״̬ = '" + Me.FlowData.FILESTATUS_YWC + "'" + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '�ύ����
                objSqlTransaction.Commit()

                '������ 2008-04-01
                'д�롰��ʾ��š�����
                If Me.doWriteXSXH(strErrMsg) = False Then
                    '�����ɹ�
                    '���Դ���
                End If
                '������ 2008-04-01
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)

            doCompleteFile = True
            Exit Function
errProc:
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ۼ��ļ����ֶ�ֵ
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strPJYJ              ��(����)����ԭ���ֶ�ֵ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function getPJYJ( _
            ByRef strErrMsg As String, _
            ByRef strPJYJ As String) As Boolean

            getPJYJ = False
            strErrMsg = ""
            strPJYJ = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[getPJYJ]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "����[getPJYJ]����û��������ݣ�����ʹ�ã�"
                    GoTo errProc
                End If

                '����
                Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                strPJYJ = objBaseFlowRenshiLuyong.HJWJ

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getPJYJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��������ǩ�����Ӽ���ҵ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strFileSpec          ��Ҫ������ļ�·��(WEB������������ȫ·��)
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doImportQP( _
            ByRef strErrMsg As String, _
            ByVal strFileSpec As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objBaseLocalFile As New josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objdacCustomer As New josco.JsKernal.DataAccess.dacCustomer

            Dim objdacXitongpeizhi As New josco.JsKernal.DataAccess.dacXitongpeizhi
            Dim objFTPProperty As josco.JsKernal.Common.Utilities.FTPProperty
            Dim objBaseFTP As New josco.JsKernal.Common.Utilities.BaseFTP

            Dim strBakExt As String = josco.JsKernal.Common.Utilities.PulicParameters.BACKUPFILEEXT
            Dim strFromUrl As String = ""
            Dim strToUrl As String = ""
            Dim strHJWJ As String = ""

            doImportQP = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doImportQP]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "����[doImportQP]����û��������ݣ�����ʹ�ã�"
                    GoTo errProc
                End If
                If strFileSpec Is Nothing Then strFileSpec = ""
                strFileSpec = strFileSpec.Trim
                If strFileSpec = "" Then
                    strErrMsg = "����[doImportQP]δָ��Ҫ������ļ���"
                    GoTo errProc
                End If

                '��ȡ�ļ���Ϣ
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '��ȡ��������
                objSqlConnection = Me.SqlConnection

                '��ȡFTP����
                If objdacXitongpeizhi.getFtpServerParam(strErrMsg, objSqlConnection, objFTPProperty) = False Then
                    GoTo errProc
                End If

                '��ȡ��Ա����
                Dim strUserId As String
                If objdacCustomer.getRydmByRymc(strErrMsg, objSqlConnection, strFileSpec, strUserId) = False Then
                    GoTo errProc
                End If
                If strUserId <> "" Then
                    '����Լ����ļ�����
                    If Me.doLockFile(strErrMsg, strUserId, False) = False Then
                        GoTo errProc
                    End If
                End If

                '����Ƿ������ڱ༭���ļ���
                Dim blnLocked As Boolean
                Dim strBMMC As String
                Dim strRYMC As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If
                If blnLocked = True Then
                    strErrMsg = "����[" + strBMMC + "]��[" + strRYMC + "]�����޸ı��ļ�[" + strWJBS + "]�����Ժ��ٽ��д���"
                    GoTo errProc
                End If

                '��ȡ�ļ����ݶ���
                Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                strHJWJ = objBaseFlowRenshiLuyong.HJWJ
                '�����ϴ��ļ�
                Dim strFileType As String
                strFileType = objBaseLocalFile.getExtension(strFileSpec)
                Dim strDesSpec As String
                If strFileType <> "" Then
                    strDesSpec = objBaseFlowRenshiLuyong.FILEDIR_PJ + "\" + Year(Now).ToString + "\" + strWJBS + strFileType
                Else
                    strDesSpec = objBaseFlowRenshiLuyong.FILEDIR_PJ + "\" + Year(Now).ToString + "\" + strWJBS
                End If
                '�����ļ�
                If strHJWJ <> "" Then
                    With objFTPProperty
                        strFromUrl = .getUrl(strHJWJ)
                        strToUrl = .getUrl(strHJWJ + strBakExt)
                        If objBaseFTP.doRenameFile(strErrMsg, strFromUrl, strToUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                            GoTo errProc
                        End If
                    End With
                End If
                '�ϴ��ļ�
                Dim strUrl As String = ""
                With objFTPProperty
                    strUrl = .getUrl(strDesSpec)
                    If objBaseFTP.doPutFile(strErrMsg, strFileSpec, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        GoTo rollWJ
                    End If
                End With

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '������
                Try
                    'д����
                    strSQL = ""
                    strSQL = strSQL + " update �ز�_B_����_¼������ set " + vbCr
                    strSQL = strSQL + "   �ۼ��ļ� = '" + strDesSpec + "'" + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '�����ʱ�ļ�
                    If strHJWJ <> "" Then
                        With objFTPProperty
                            If objBaseFTP.doDeleteFile(strErrMsg, strToUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                '���Բ��ɹ�,�γ������ļ�
                            End If
                        End With
                    End If

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabaseAndWJ
                End Try

                '�ύ����
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacXitongpeizhi.SafeRelease(objdacXitongpeizhi)
            josco.JsKernal.Common.Utilities.FTPProperty.SafeRelease(objFTPProperty)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)

            doImportQP = True
            Exit Function

rollWJ:
            '������ԭ�ļ�
            Dim strTempMsgA As String = ""
            If strHJWJ <> "" Then
                With objFTPProperty
                    If objBaseFTP.doRenameFile(strTempMsgA, strToUrl, strFromUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        '�Ѿ������ˣ�
                    End If
                End With
            End If
            GoTo errProc

rollDatabaseAndWJ:
            '������ԭ�ļ�
            Dim strTempMsgB As String = ""
            If strHJWJ <> "" Then
                With objFTPProperty
                    If objBaseFTP.doRenameFile(strTempMsgB, strToUrl, strFromUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        '�Ѿ������ˣ�
                    End If
                End With
            End If
            GoTo rollDataBase

rollDataBase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacXitongpeizhi.SafeRelease(objdacXitongpeizhi)
            josco.JsKernal.Common.Utilities.FTPProperty.SafeRelease(objFTPProperty)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡ������ԭ�����ֶ�ֵ
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strZSWJ              ��(����)��ʽ�ļ��ֶ�ֵ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function getZSWJ( _
            ByRef strErrMsg As String, _
            ByRef strZSWJ As String) As Boolean

            getZSWJ = False
            strErrMsg = ""
            strZSWJ = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[getZSWJ]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "����[getZSWJ]����û��������ݣ�����ʹ�ã�"
                    GoTo errProc
                End If

                '����
                Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                strZSWJ = objBaseFlowRenshiLuyong.PJYJ

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getZSWJ = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��������ǩ��ɨ�����ҵ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strFileSpec          ��Ҫ������ļ�·��(WEB������������ȫ·��)
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doImportZS( _
            ByRef strErrMsg As String, _
            ByVal strFileSpec As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objBaseLocalFile As New josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objdacCustomer As New josco.JsKernal.DataAccess.dacCustomer

            Dim objdacXitongpeizhi As New josco.JsKernal.DataAccess.dacXitongpeizhi
            Dim objFTPProperty As josco.JsKernal.Common.Utilities.FTPProperty
            Dim objBaseFTP As New josco.JsKernal.Common.Utilities.BaseFTP

            Dim strBakExt As String = josco.JsKernal.Common.Utilities.PulicParameters.BACKUPFILEEXT
            Dim strFromUrl As String = ""
            Dim strToUrl As String = ""
            Dim strPJYJ As String = ""

            doImportZS = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doImportZS]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "����[doImportZS]����û��������ݣ�����ʹ�ã�"
                    GoTo errProc
                End If
                If strFileSpec Is Nothing Then strFileSpec = ""
                strFileSpec = strFileSpec.Trim
                If strFileSpec = "" Then
                    strErrMsg = "����[doImportZS]δָ��Ҫ������ļ���"
                    GoTo errProc
                End If

                '��ȡ�ļ���Ϣ
                Dim strWJBS As String = Me.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '��ȡ��������
                objSqlConnection = Me.SqlConnection

                '��ȡFTP����
                If objdacXitongpeizhi.getFtpServerParam(strErrMsg, objSqlConnection, objFTPProperty) = False Then
                    GoTo errProc
                End If

                '��ȡ��Ա����
                Dim strUserId As String
                If objdacCustomer.getRydmByRymc(strErrMsg, objSqlConnection, strFileSpec, strUserId) = False Then
                    GoTo errProc
                End If
                If strUserId <> "" Then
                    '����Լ����ļ�����
                    If Me.doLockFile(strErrMsg, strUserId, False) = False Then
                        GoTo errProc
                    End If
                End If

                '����Ƿ������ڱ༭���ļ���
                Dim blnLocked As Boolean
                Dim strBMMC As String
                Dim strRYMC As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBMMC, strRYMC) = False Then
                    GoTo errProc
                End If
                If blnLocked = True Then
                    strErrMsg = "����[" + strBMMC + "]��[" + strRYMC + "]�����޸ı��ļ�[" + strWJBS + "]�����Ժ��ٽ��д���"
                    GoTo errProc
                End If

                '��ȡ�ļ����ݶ���
                Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                strPJYJ = objBaseFlowRenshiLuyong.PJYJ
                '�����ϴ��ļ�
                Dim strFileType As String
                strFileType = objBaseLocalFile.getExtension(strFileSpec)
                Dim strDesSpec As String
                If strFileType <> "" Then
                    strDesSpec = objBaseFlowRenshiLuyong.FILEDIR_RO + "\" + Year(Now).ToString + "\" + strWJBS + strFileType
                Else
                    strDesSpec = objBaseFlowRenshiLuyong.FILEDIR_RO + "\" + Year(Now).ToString + "\" + strWJBS
                End If
                '�����ļ�
                If strPJYJ <> "" Then
                    With objFTPProperty
                        strFromUrl = .getUrl(strPJYJ)
                        strToUrl = .getUrl(strPJYJ + strBakExt)
                        If objBaseFTP.doRenameFile(strErrMsg, strFromUrl, strToUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                            GoTo errProc
                        End If
                    End With
                End If
                '�ϴ��ļ�
                Dim strUrl As String = ""
                With objFTPProperty
                    strUrl = .getUrl(strDesSpec)
                    If objBaseFTP.doPutFile(strErrMsg, strFileSpec, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        GoTo rollWJ
                    End If
                End With

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '������
                Try
                    'д����
                    strSQL = ""
                    strSQL = strSQL + " update �ز�_B_����_¼������ set " + vbCr
                    strSQL = strSQL + "   ����ԭ�� = '" + strDesSpec + "'" + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '�����ʱ�ļ�
                    If strPJYJ <> "" Then
                        With objFTPProperty
                            If objBaseFTP.doDeleteFile(strErrMsg, strToUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                '���Բ��ɹ�,�γ������ļ�
                            End If
                        End With
                    End If

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabaseAndWJ
                End Try

                '�ύ����
                objSqlTransaction.Commit()

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacXitongpeizhi.SafeRelease(objdacXitongpeizhi)
            josco.JsKernal.Common.Utilities.FTPProperty.SafeRelease(objFTPProperty)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)

            doImportZS = True
            Exit Function

rollWJ:
            '������ԭ�ļ�
            Dim strTempMsgA As String = ""
            If strPJYJ <> "" Then
                With objFTPProperty
                    If objBaseFTP.doRenameFile(strTempMsgA, strToUrl, strFromUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        '�Ѿ������ˣ�
                    End If
                End With
            End If
            GoTo errProc

rollDatabaseAndWJ:
            '������ԭ�ļ�
            Dim strTempMsgB As String = ""
            If strPJYJ <> "" Then
                With objFTPProperty
                    If objBaseFTP.doRenameFile(strTempMsgB, strToUrl, strFromUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        '�Ѿ������ˣ�
                    End If
                End With
            End If
            GoTo rollDataBase

rollDataBase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacXitongpeizhi.SafeRelease(objdacXitongpeizhi)
            josco.JsKernal.Common.Utilities.FTPProperty.SafeRelease(objFTPProperty)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡ�������ܽ��е�ǩ������б�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     objYjlx              ��ǩ���������+��ʾ���Ƽ���
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function getAllYjlx( _
            ByRef strErrMsg As String, _
            ByRef objYjlx As System.Collections.Specialized.NameValueCollection) As Boolean

            getAllYjlx = False
            strErrMsg = ""
            objYjlx = Nothing

            Try
                '��ȡ��������ϸ����
                Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)

                '�����ʼ��
                objYjlx = New System.Collections.Specialized.NameValueCollection

                objYjlx.Add(objBaseFlowRenshiLuyong.TASK_SHWJ, "���ž������")
                objYjlx.Add(objBaseFlowRenshiLuyong.TASK_HQWJ, "�칫���������")
                objYjlx.Add(objBaseFlowRenshiLuyong.TASK_FHWJ, "���ܾ������")
                objYjlx.Add(objBaseFlowRenshiLuyong.TASK_QFWJ, "�ܾ�����ʾ")

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getAllYjlx = True
            Exit Function

errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ȡ��ǩ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strYjlx              ��Ҫȡ�����������
        '     strSPR               ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doQianminCancel( _
            ByRef strErrMsg As String, _
            ByVal strYjlx As String, _
            ByVal strSPR As String) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand

            Dim strWJBS As String
            Dim strSQL As String

            '��ʼ��
            doQianminCancel = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doQianminCancel]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "����[doQianminCancel]����û��������ݣ�����ʹ�ã�"
                    GoTo errProc
                End If
                If strYjlx Is Nothing Then strYjlx = ""
                strYjlx = strYjlx.Trim
                If strYjlx = "" Then
                    Exit Try
                End If
                If strSPR Is Nothing Then strSPR = ""
                strSPR = strSPR.Trim
                If strSPR = "" Then
                    Exit Try
                End If

                '��ȡ������Ϣ
                objSqlConnection = Me.SqlConnection
                strWJBS = Me.FlowData.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '���༭����
                Dim blnLocked As Boolean
                Dim strBmmc As String
                Dim strRymc As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBmmc, strRymc) = False Then
                    GoTo errProc
                End If

                '��������
                Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)

                '����ȡ��ǩ����SQL
                strSQL = ""
                Select Case strYjlx
                    Case josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_QFWJ
                        Dim strQFR As String = objBaseFlowRenshiLuyong.QFR
                        Dim strTmp As String = strSPR

                        'ȡ��ǩ��
                        If strQFR <> "" Then
                            strQFR += josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                            strTmp += josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate

                            strQFR = strQFR.Replace(strTmp, "")
                            If strQFR.Length > 0 Then
                                strQFR = strQFR.Substring(0, strQFR.Length - 1)
                            End If

                            '����
                            strSQL = ""
                            strSQL = strSQL + " update �ز�_B_����_¼������ set" + vbCr
                            strSQL = strSQL + "   ǩ���� = '" + strQFR + "'" + vbCr
                            If strQFR = "" Then
                                strSQL = strSQL + ",����״̬ = '" + Me.FlowData.FILESTATUS_ZJB + "'" + vbCr
                                strSQL = strSQL + ",ǩ������ = NULL " + vbCr
                            End If
                            strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr
                        End If

                    Case Else
                End Select

                If strSQL <> "" Then
                    If blnLocked = True Then
                        strErrMsg = "����[" + strBmmc + "]��λ��[" + strRymc + "]�����ڱ༭���ļ������Ժ��ٴ���"
                        GoTo errProc
                    End If

                    '��ʼ����
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                    Try
                        objSqlCommand = objSqlConnection.CreateCommand()
                        objSqlCommand.Connection = objSqlConnection
                        objSqlCommand.Transaction = objSqlTransaction
                        objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.ExecuteNonQuery()
                    Catch ex As Exception
                        GoTo rollDatabase
                    End Try
                    '�ύ����
                    objSqlTransaction.Commit()
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '����
            doQianminCancel = True
            Exit Function

rollDatabase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ǩ��ȷ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strYjlx              ��Ҫȷ�ϵ��������
        '     strSPR               ��������
        '     intMode              ��ǩ��ģʽ��0-����ǩ��1-��ͬǩ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function doQianminQueren( _
            ByRef strErrMsg As String, _
            ByVal strYjlx As String, _
            ByVal strSPR As String, _
            ByVal intMode As Integer) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand

            Dim objdacCustomer As New josco.JsKernal.DataAccess.dacCustomer

            Dim strWJBS As String
            Dim strSQL As String

            '��ʼ��
            doQianminQueren = False
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[doQianminQueren]����û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If Me.IsFillData = False Then
                    strErrMsg = "����[doQianminQueren]����û��������ݣ�����ʹ�ã�"
                    GoTo errProc
                End If
                If strYjlx Is Nothing Then strYjlx = ""
                strYjlx = strYjlx.Trim
                If strYjlx = "" Then
                    Exit Try
                End If
                If strSPR Is Nothing Then strSPR = ""
                strSPR = strSPR.Trim
                If strSPR = "" Then
                    Exit Try
                End If

                '��ȡ������Ϣ
                objSqlConnection = Me.SqlConnection
                strWJBS = Me.FlowData.WJBS
                If strWJBS = "" Then
                    Exit Try
                End If

                '���༭����
                Dim blnLocked As Boolean
                Dim strBmmc As String
                Dim strRymc As String
                If Me.getFileLocked(strErrMsg, blnLocked, strBmmc, strRymc) = False Then
                    GoTo errProc
                End If

                '��������
                Dim strSep As String = josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)

                '����ǩ��SQL
                strSQL = ""
                Select Case strYjlx
                    Case josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_QFWJ
                        Dim strQFR As String = objBaseFlowRenshiLuyong.QFR
                        Dim strTmp As String = strSPR
                        Dim strNewQFR As String = ""

                        'ȷ��ǩ��
                        If strQFR <> "" Then
                            strQFR += strSep
                            strTmp += strSep

                            If strQFR.IndexOf(strTmp) >= 0 Then
                                '��ǩ��
                            Else
                                'û��ǩ��
                                strQFR += strTmp
                            End If
                            strQFR = strQFR.Substring(0, strQFR.Length - 1)
                        Else
                            strQFR = strSPR
                        End If

                        '����
                        If objdacCustomer.doSortRenyuanList(strErrMsg, objSqlConnection, strQFR, strSep, strNewQFR) = False Then
                            GoTo errProc
                        End If
                        strQFR = strNewQFR

                        '����
                        Select Case intMode
                            Case 0 '����
                                strSQL = ""
                                strSQL = strSQL + " update �ز�_B_����_¼������ set" + vbCr
                                strSQL = strSQL + "   ����״̬ = '" + Me.FlowData.FILESTATUS_YQP + "'," + vbCr
                                strSQL = strSQL + "   ǩ����   = '" + strSPR + "'," + vbCr
                                strSQL = strSQL + "   ǩ������ = '" + Format(Now, "yyyy-MM-dd HH:mm:ss") + "'" + vbCr
                                strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr

                            Case 1 '��ͬ
                                strSQL = ""
                                strSQL = strSQL + " update �ز�_B_����_¼������ set" + vbCr
                                strSQL = strSQL + "   ����״̬ = '" + Me.FlowData.FILESTATUS_YQP + "'," + vbCr
                                strSQL = strSQL + "   ǩ����   = '" + strQFR + "'," + vbCr
                                strSQL = strSQL + "   ǩ������ = '" + Format(Now, "yyyy-MM-dd HH:mm:ss") + "'" + vbCr
                                strSQL = strSQL + " where �ļ���ʶ = '" + strWJBS + "'" + vbCr

                            Case Else
                                '��ǩ��
                        End Select

                    Case Else
                End Select

                If strSQL <> "" Then
                    If blnLocked = True Then
                        strErrMsg = "����[" + strBmmc + "]��λ��[" + strRymc + "]�����ڱ༭���ļ������Ժ��ٴ���"
                        GoTo errProc
                    End If

                    '��ʼ����
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                    Try
                        objSqlCommand = objSqlConnection.CreateCommand()
                        objSqlCommand.Connection = objSqlConnection
                        objSqlCommand.Transaction = objSqlTransaction
                        objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.ExecuteNonQuery()
                    Catch ex As Exception
                        GoTo rollDatabase
                    End Try
                    '�ύ����
                    objSqlTransaction.Commit()
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)

            '����
            doQianminQueren = True
            Exit Function

rollDatabase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���롰�Ƿ���׼����־
        ' ����
        '                          ���������ַ���
        '----------------------------------------------------------------
        Public Overrides Function doTranslateSFPZ(ByVal strSFPZ As String) As String

            doTranslateSFPZ = ""

            Try
                If strSFPZ Is Nothing Then
                    Exit Try
                End If
                strSFPZ = strSFPZ.Trim

                Select Case strSFPZ
                    Case "1000"
                        doTranslateSFPZ = "��ͬ��"
                    Case "1100"
                        doTranslateSFPZ = "ͬ��"
                    Case "1110"
                        doTranslateSFPZ = "һ�����"
                    Case Else
                End Select

            Catch ex As Exception
                doTranslateSFPZ = ""
            End Try

        End Function

        '----------------------------------------------------------------
        ' ��Ҫǩ��ȷ����ʾ?
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strYjlx              ��Ҫȷ�ϵ��������
        '     strSPR               ��������
        '     blnNeed              ��(����)�Ƿ���Ҫ��ʾ
        '     strXyrList           ��(����)����ǩ�����б�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Overrides Function isNeedQianminQuerenPrompt( _
            ByRef strErrMsg As String, _
            ByVal strYjlx As String, _
            ByVal strSPR As String, _
            ByRef blnNeed As Boolean, _
            ByRef strXyrList As String) As Boolean

            isNeedQianminQuerenPrompt = False
            strErrMsg = ""
            blnNeed = False
            strXyrList = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    Exit Try
                End If
                If Me.IsFillData = False Then
                    Exit Try
                End If
                If strYjlx Is Nothing Then strYjlx = ""
                strYjlx = strYjlx.Trim
                If strYjlx = "" Then
                    Exit Try
                End If
                If strSPR Is Nothing Then strSPR = ""
                strSPR = strSPR.Trim
                If strSPR = "" Then
                    Exit Try
                End If

                '�ж�
                Dim strSep As String = josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                Dim objBaseFlowRenshiLuyong As josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                Select Case strYjlx
                    Case josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_QFWJ
                        Dim strQFR As String = objBaseFlowRenshiLuyong.QFR
                        Dim strTmp As String = strSPR

                        If strQFR <> "" Then
                            strQFR += strSep
                            strTmp += strSep
                            If strQFR.IndexOf(strTmp) >= 0 Then
                                blnNeed = False
                            Else
                                blnNeed = True
                            End If
                        Else
                            blnNeed = True
                        End If
                        strXyrList = objBaseFlowRenshiLuyong.QFR

                End Select

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            isNeedQianminQuerenPrompt = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����Ҫǩ��ȷ�ϵ���������?
        '     strYjlx              ����������
        ' ����
        '     True                 ����Ҫǩ��
        '     False                ������Ҫǩ��
        '----------------------------------------------------------------
        Public Overrides Function isQianminTask(ByVal strYjlx As String) As Boolean

            Try
                Select Case strYjlx
                    Case josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_QFWJ
                        isQianminTask = True

                    Case Else
                        isQianminTask = False
                End Select
            Catch ex As Exception
                isQianminTask = False
            End Try

        End Function

        '----------------------------------------------------------------
        ' �Ƕ������ļ�ǩ�����������?����ǣ����������ַ���
        '     strYjlx              ����������
        ' ����
        '     True                 ����Ҫǩ��
        '     False                ������Ҫǩ��
        '----------------------------------------------------------------
        Public Overrides Function isFileQianminTask( _
            ByVal strYjlx As String, _
            ByRef strPrompt As String) As Boolean

            Try
                Select Case strYjlx
                    Case josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.TASK_QFWJ
                        strPrompt = "�ر����ѣ���ȷ�ϱ��ļ�������ְ��Χ�ھͿ���[��]����ȷ��/ȡ����������[��]�밴[ȷ��]�������밴[ȡ��]��"
                        isFileQianminTask = True

                    Case Else
                        isFileQianminTask = False
                        strPrompt = ""
                End Select
            Catch ex As Exception
                isFileQianminTask = False
                strPrompt = ""
            End Try

        End Function

        '----------------------------------------------------------------
        ' ��ȡ����׼�������־
        ' ����
        '                          �������־
        '----------------------------------------------------------------
        Public Overrides Function getPizhunBLBZ() As String
            getPizhunBLBZ = "1100"
        End Function

        '----------------------------------------------------------------
        ' ��ȡ����������������־
        ' ����
        '                          �������־
        '----------------------------------------------------------------
        Public Overrides Function getBaocunYijianBLBZ() As String
            getBaocunYijianBLBZ = "1110"
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

            Dim objPulicParameters As New josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New josco.JsKernal.DataAccess.dacCommon
            Dim strWJBS As String

            getNewWjxh = False
            strErrMsg = ""
            strWJXH = "0"

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "����[getNewWjxh]������û�г�ʼ����"
                    GoTo errProc
                End If
                If strJGDZ Is Nothing Then strJGDZ = ""
                strJGDZ = strJGDZ.Trim
                If strJGDZ = "" Then
                    strErrMsg = "����[getNewWjxh]û������[���ش���]��"
                    GoTo errProc
                End If
                If strWJNF Is Nothing Then strWJNF = ""
                strWJNF = strWJNF.Trim
                If strWJNF = "" Then
                    strErrMsg = "����[getNewWjxh]û������[�ļ����]��"
                    GoTo errProc
                End If

                '��ȡ��Ϣ
                objSqlConnection = Me.SqlConnection
                strWJBS = Me.WJBS

                '��ȡ���
                Dim strSep As String = josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate
                If objdacCommon.getNewCode(strErrMsg, objSqlConnection, "�ļ����", "���ش���,�ļ����", strJGDZ + strSep + strWJNF, "�ز�_B_����_¼������", True, strWJXH) = False Then
                    GoTo errProc
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getNewWjxh = True
            Exit Function

errProc:
            josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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
            ByRef objestateRenshiXingyeData As josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean

            Dim objTempobjestateRenshiXingyeData As josco.JSOA.Common.Data.estateRenshiXingyeData
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            Dim objPulicParameters As New josco.JsKernal.Common.Utilities.PulicParameters

            getDataSet_RYXX = False
            objestateRenshiXingyeData = Nothing
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "���󣺶���û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If

                '��ȡ�ļ���ʶ
                Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Me.SqlConnection
                Dim strWJBS As String = Me.WJBS

                '�������ݼ�
                objTempobjestateRenshiXingyeData = New josco.JSOA.Common.Data.estateRenshiXingyeData(josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_B_RS_LUYONGSHENPI_RENYUANXINXI)
                If strWJBS = "" Then
                    Exit Try
                End If

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                'ִ�м���
                With Me.SqlDataAdapter
                    '��ȡ��������
                    strSQL = ""
                    strSQL = strSQL + " select a.*" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_¼������_��Ա��Ϣ a" + vbCr
                    strSQL = strSQL + " where �ļ���ʶ = @wjbs" + vbCr
                    strSQL = strSQL + " order by a.��Ա���" + vbCr

                    '���ò���
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@wjbs", strWJBS)
                    .SelectCommand = objSqlCommand

                    'ִ�в���
                    .Fill(objTempobjestateRenshiXingyeData.Tables(josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI_RENYUANXINXI))
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            objestateRenshiXingyeData = objTempobjestateRenshiXingyeData
            getDataSet_RYXX = True
            Exit Function

errProc:
            josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempobjestateRenshiXingyeData)
            josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

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
            ByRef objestateRenshiXingyeData As josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean

            Dim objTempestateRenshiXingyeData As josco.JSOA.Common.Data.estateRenshiXingyeData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_Main = False
            objestateRenshiXingyeData = Nothing
            strErrMsg = ""

            Try
                '���
                If Me.IsInitialized = False Then
                    strErrMsg = "���󣺶���û�г�ʼ��������ʹ�ã�"
                    GoTo errProc
                End If
                If strUserXM Is Nothing Then strUserXM = ""
                strUserXM = strUserXM.Trim

                '��ȡ����
                objSqlConnection = Me.SqlConnection

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiXingyeData = New josco.JSOA.Common.Data.estateRenshiXingyeData(josco.JSOA.Common.Data.estateRenshiXingyeData.enumTableType.DC_B_RS_LUYONGSHENPI)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.SqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from" + vbCr
                        strSQL = strSQL + " (" + vbCr
                        strSQL = strSQL + "   select a.*," + vbCr
                        strSQL = strSQL + "     �������� = dbo.GetFileBWTX(a.�ļ���ʶ,@userxm)" + vbCr
                        strSQL = strSQL + "   from �ز�_B_����_¼������ a" + vbCr
                        strSQL = strSQL + "   where dbo.Flow_CanReadFile(a.�ļ���ʶ,@userxm) = 1" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.�������� desc " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@userxm", strUserXM)
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiXingyeData.Tables(josco.JSOA.Common.Data.estateRenshiXingyeData.TABLE_DC_B_RS_LUYONGSHENPI))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiXingyeData.Tables.Count < 1 Then
                    josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempestateRenshiXingyeData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '����
            objestateRenshiXingyeData = objTempestateRenshiXingyeData
            getDataSet_Main = True
            Exit Function

errProc:
            josco.JSOA.Common.Data.estateRenshiXingyeData.SafeRelease(objTempestateRenshiXingyeData)
            josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function












        '----------------------------------------------------------------
        ' �����������ļ����뵽ָ���İ�����
        '     strErrMsg            �����ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strAJBS              ��ָ�������ʶ
        '     strTempPath          �������ļ���ʱ���·��
        ' ����
        '     True                 ���ɹ�
        '     False                �����ɹ�
        ' ��ע
        '     ����                 ������
        '     ��������             ������
        '     ��������             �����鵵��
        '----------------------------------------------------------------
        Public Overrides Function doAddToAnjuan( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strAJBS As String, _
            ByVal strTempPath As String) As Boolean
            strErrMsg = "����[doAddToAnjuan]û��ʵ�֣�"
            doAddToAnjuan = False
        End Function
        '        Public Overrides Function doAddToAnjuan( _
        '            ByRef strErrMsg As String, _
        '            ByVal strUserId As String, _
        '            ByVal strPassword As String, _
        '            ByVal strAJBS As String, _
        '            ByVal strTempPath As String) As Boolean

        '            Dim objAnjuanDataSet As Josco.JsKernal.Common.Data.daglDanganData
        '            Dim objFujianDataSet As Josco.JsKernal.Common.Data.FlowData

        '            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
        '            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
        '            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
        '            Dim strSQL As String

        '            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
        '            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
        '            Dim objdacCustomer As New Josco.JsKernal.DataAccess.dacCustomer
        '            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
        '            Dim objdacDangan As New Josco.JsKernal.DataAccess.dacDangan

        '            doAddToAnjuan = False
        '            strErrMsg = ""

        '            Try
        '                '���
        '                If strAJBS Is Nothing Then strAJBS = ""
        '                strAJBS = strAJBS.Trim
        '                If strAJBS = "" Then
        '                    strErrMsg = "����û��ָ��Ŀ��[����]��"
        '                    GoTo errProc
        '                End If
        '                If Me.IsInitialized = False Then
        '                    strErrMsg = "���󣺹�����δ��ʼ����"
        '                    GoTo errProc
        '                End If
        '                If Me.IsFillData = False Then
        '                    strErrMsg = "���󣺹�����δ��ȡ���ݣ�"
        '                    GoTo errProc
        '                End If
        '                If strUserId Is Nothing Then strUserId = ""
        '                strUserId = strUserId.Trim
        '                If strUserId = "" Then
        '                    strErrMsg = "����δָ��[�����û�]��"
        '                    GoTo errProc
        '                End If
        '                If strPassword Is Nothing Then strPassword = ""
        '                strPassword = strPassword.Trim
        '                If strTempPath Is Nothing Then strTempPath = ""
        '                strTempPath = strTempPath.Trim
        '                If strTempPath = "" Then
        '                    strErrMsg = "����δָ�������ļ���ʱ���·����"
        '                    GoTo errProc
        '                End If
        '                objSqlConnection = Me.SqlConnection

        '                '��ȡĿ�갸����Ϣ
        '                If objdacDangan.getDataSet_Anjuan(strErrMsg, strUserId, strPassword, strAJBS, objAnjuanDataSet) = False Then
        '                    GoTo errProc
        '                End If
        '                Dim strMLBS As String
        '                Dim strDALX As String
        '                Dim strWJND As String
        '                Dim strSSDW As String
        '                With objAnjuanDataSet.Tables(Josco.JsKernal.Common.Data.daglDanganData.TABLE_DA_B_ANJUANMULU)
        '                    If .Rows.Count < 1 Then
        '                        strErrMsg = "����[����]�����ڣ�"
        '                        GoTo errProc
        '                    End If
        '                    strMLBS = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JsKernal.Common.Data.daglDanganData.FIELD_DA_B_ANJUANMULU_ZABS), "")
        '                    strDALX = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JsKernal.Common.Data.daglDanganData.FIELD_DA_B_ANJUANMULU_DALX), "")
        '                    strWJND = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JsKernal.Common.Data.daglDanganData.FIELD_DA_B_ANJUANMULU_WJND), "")
        '                    strSSDW = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JsKernal.Common.Data.daglDanganData.FIELD_DA_B_ANJUANMULU_SSDW), "")
        '                End With
        '                Josco.JsKernal.Common.Data.daglDanganData.SafeRelease(objAnjuanDataSet)

        '                '���Ȩ��(��������Ȩ��)
        '                Dim blnIS As Boolean
        '                If objdacDangan.isRole(strErrMsg, strUserId, strPassword, strUserId, strSSDW, strDALX, 6, blnIS) = False Then
        '                    GoTo errProc
        '                End If
        '                If blnIS = False Then
        '                    strErrMsg = "���󣺲��߱�[" + strSSDW + "]��������Ȩ�ޣ�"
        '                    GoTo errProc
        '                End If

        '                '��ȡ��������¼
        '                Dim objBaseFlowRenshiLuyong As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
        '                Try
        '                    objBaseFlowRenshiLuyong = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
        '                Catch ex As Exception
        '                    strErrMsg = ex.Message
        '                    GoTo errProc
        '                End Try
        '                If objBaseFlowRenshiLuyong Is Nothing Then
        '                    strErrMsg = "�����޷���ȷ��ȡ�ļ����ݣ�"
        '                    GoTo errProc
        '                End If

        '                '��ȡ�û����ڵ�λ
        '                Dim strBMDM As String
        '                Dim strBMMC As String
        '                If objdacCustomer.getBmdmAndBmmcByRydm(strErrMsg, objSqlConnection, strUserId, strBMDM, strBMMC) = False Then
        '                    GoTo errProc
        '                End If

        '                '��ȡ��������
        '                If Me.getFujianData(strErrMsg, objFujianDataSet) = False Then
        '                    GoTo errProc
        '                End If

        '                '���ء�����ԭ����
        '                Dim strPJYJ As String = objBaseFlowRenshiLuyong.PJYJ
        '                Dim strDesPath As String = strTempPath
        '                Dim strDesSpec As String = ""
        '                Dim strDesFile As String = ""
        '                If strPJYJ <> "" Then
        '                    If objdacCommon.doFTPDownLoadFile(strErrMsg, strUserId, strPassword, strPJYJ, strDesSpec, strDesPath, strDesFile) = False Then
        '                        GoTo errProc
        '                    End If
        '                    strPJYJ = strDesSpec
        '                End If

        '                '���ء��������ݡ�
        '                Dim strZWNR As String = objBaseFlowRenshiLuyong.ZWNR
        '                strDesPath = strTempPath
        '                strDesSpec = ""
        '                strDesFile = ""
        '                If strZWNR <> "" Then
        '                    If objdacCommon.doFTPDownLoadFile(strErrMsg, strUserId, strPassword, strZWNR, strDesSpec, strDesPath, strDesFile) = False Then
        '                        GoTo errProc
        '                    End If
        '                    strZWNR = strDesSpec
        '                End If

        '                '���ء������ļ���
        '                Dim strHJWJ As String = objBaseFlowRenshiLuyong.HJWJ
        '                strDesPath = strTempPath
        '                strDesSpec = ""
        '                strDesFile = ""
        '                If strHJWJ <> "" Then
        '                    If objdacCommon.doFTPDownLoadFile(strErrMsg, strUserId, strPassword, strHJWJ, strDesSpec, strDesPath, strDesFile) = False Then
        '                        GoTo errProc
        '                    End If
        '                    strHJWJ = strDesSpec
        '                End If

        '                '��ȡ�µľ������
        '                Dim intJNXH As Integer
        '                If objdacDangan.getNewJNXH(strErrMsg, strUserId, strPassword, strMLBS, strAJBS, intJNXH) = False Then
        '                    GoTo errProc
        '                End If

        '                '��ȡ�µľ����ļ���ʶ
        '                Dim strJNBS As String
        '                If objdacCommon.getNewGUID(strErrMsg, objSqlConnection, strJNBS) = False Then
        '                    GoTo errProc
        '                End If

        '                '�����ĺ�
        '                Dim strWJZH As String = ""

        '                '��ʼ����
        '                Try
        '                    objSqlCommand = New System.Data.SqlClient.SqlCommand
        '                    objSqlCommand.Connection = objSqlConnection
        '                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout
        '                    objSqlTransaction = objSqlConnection.BeginTransaction
        '                    objSqlCommand.Transaction = objSqlTransaction
        '                Catch ex As Exception
        '                    strErrMsg = ex.Message
        '                    GoTo errProc
        '                End Try

        '                'ִ������
        '                Dim strBasePath As String = Josco.JsKernal.Common.Data.daglDanganData.FILEDIR_WJ
        '                Dim intWJND As Integer = objPulicParameters.getObjectValue(strWJND, 0)
        '                Dim strFileUrl As String
        '                Dim intXH As Integer = 1
        '                Try
        '                    'д��ָ������
        '                    strSQL = ""
        '                    strSQL = strSQL + " insert into ����_B_����Ŀ¼ (" + vbCr
        '                    strSQL = strSQL + "   �ļ���ʶ,������ʶ,�����ʶ," + vbCr
        '                    strSQL = strSQL + "   ��������,�ļ����,������λ,������,�鵵��λ," + vbCr
        '                    strSQL = strSQL + "   �������,�ļ�����,�ļ��ֺ�,�ļ�����,��������," + vbCr
        '                    strSQL = strSQL + "   �ļ�����,�շ�����,�����,����,���ĵ�λ,�ܼ�,�����̶�," + vbCr
        '                    strSQL = strSQL + "   ����,��������,�鵵����,��Ӧ�ļ�" + vbCr
        '                    strSQL = strSQL + " ) values (" + vbCr
        '                    '---------------------------------------------------------------
        '                    strSQL = strSQL + "   '" + strJNBS + "'," + vbCr
        '                    strSQL = strSQL + "   '" + strMLBS + "'," + vbCr
        '                    strSQL = strSQL + "   '" + strAJBS + "'," + vbCr
        '                    '---------------------------------------------------------------
        '                    strSQL = strSQL + "   '" + strDALX + "'," + vbCr
        '                    strSQL = strSQL + "   '" + strWJND + "'," + vbCr
        '                    strSQL = strSQL + "   '" + strSSDW + "'," + vbCr
        '                    strSQL = strSQL + "   '" + strSSDW + "'," + vbCr
        '                    strSQL = strSQL + "   '" + strBMMC + "'," + vbCr
        '                    '---------------------------------------------------------------
        '                    strSQL = strSQL + "    " + intJNXH.ToString + "," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowRenshiLuyong.WJBT + "'," + vbCr
        '                    strSQL = strSQL + "   '" + strWJZH + "'," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowRenshiLuyong.QFRQ.ToString("yyyy-MM-dd HH:mm:ss") + "'," + vbCr
        '                    strSQL = strSQL + "   '" + "���鵵��" + "'," + vbCr
        '                    '---------------------------------------------------------------
        '                    strSQL = strSQL + "   '" + " " + "'," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowRenshiLuyong.FLOWNAME + "'," + vbCr
        '                    strSQL = strSQL + "   '" + " " + "'," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowRenshiLuyong.ZBDW + "'," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowRenshiLuyong.ZBDW + "'," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowRenshiLuyong.MMDJ + "'," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowRenshiLuyong.JJCD + "'," + vbCr
        '                    '---------------------------------------------------------------
        '                    strSQL = strSQL + "   '" + "����" + "'," + vbCr
        '                    strSQL = strSQL + "   '" + "����" + "'," + vbCr
        '                    strSQL = strSQL + "   '" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + vbCr
        '                    strSQL = strSQL + "   '" + objBaseFlowRenshiLuyong.WJBS + "'" + vbCr
        '                    strSQL = strSQL + " ) " + vbCr
        '                    objSqlCommand.CommandText = strSQL
        '                    objSqlCommand.Parameters.Clear()
        '                    objSqlCommand.ExecuteNonQuery()

        '                    'д������
        '                    strSQL = ""
        '                    strSQL = strSQL + " insert into ����_B_������Ա (�ļ���ʶ,������Ա) " + vbCr
        '                    strSQL = strSQL + " select �ļ���ʶ = '" + strJNBS + "',��Ա���� " + vbCr
        '                    strSQL = strSQL + " from " + vbCr
        '                    strSQL = strSQL + " (" + vbCr
        '                    strSQL = strSQL + "   select ������ as ��Ա���� from ����_B_���� " + vbCr
        '                    strSQL = strSQL + "   where �ļ���ʶ = '" + objBaseFlowRenshiLuyong.WJBS + "' " + vbCr
        '                    strSQL = strSQL + "   and ���ӱ�ʶ like '__1%' " + vbCr
        '                    strSQL = strSQL + "   group by ������ " + vbCr
        '                    strSQL = strSQL + "   union " + vbCr
        '                    strSQL = strSQL + "   select ������ as ��Ա���� from ����_B_���� " + vbCr
        '                    strSQL = strSQL + "   where �ļ���ʶ = '" + objBaseFlowRenshiLuyong.WJBS + "' " + vbCr
        '                    strSQL = strSQL + "   and ���ӱ�ʶ like '_1%' " + vbCr
        '                    strSQL = strSQL + "   group by ������ " + vbCr
        '                    strSQL = strSQL + " ) a " + vbCr
        '                    strSQL = strSQL + " group by a.��Ա����" + vbCr
        '                    objSqlCommand.CommandText = strSQL
        '                    objSqlCommand.Parameters.Clear()
        '                    objSqlCommand.ExecuteNonQuery()

        '                    'д�����ļ�
        '                    If strHJWJ <> "" Then
        '                        '�����ļ�
        '                        If objdacDangan.getFTPFileName_JNML_FILE(strErrMsg, strHJWJ, intWJND, strJNBS, intXH, strBasePath, strFileUrl) = False Then
        '                            GoTo rollDatabase
        '                        End If
        '                        If objdacCommon.doFTPUploadFile(strErrMsg, strUserId, strPassword, strHJWJ, strFileUrl) = False Then
        '                            GoTo rollDatabase
        '                        End If
        '                        '��������
        '                        strSQL = ""
        '                        strSQL = strSQL + " insert into ����_B_�����ļ� (" + vbCr
        '                        strSQL = strSQL + "   �ļ���ʶ,���,����,��ʽ,����,ҳ��,λ��" + vbCr
        '                        strSQL = strSQL + " ) values (" + vbCr
        '                        strSQL = strSQL + "   '" + strJNBS + "'," + vbCr
        '                        strSQL = strSQL + "    " + intXH.ToString + " ," + vbCr
        '                        strSQL = strSQL + "   '" + Josco.JsKernal.Common.Data.daglDanganData.TYPE_ZSWJ + "'," + vbCr
        '                        strSQL = strSQL + "   '" + Josco.JsKernal.Common.Data.daglDanganData.STYLE_FYJ + "'," + vbCr
        '                        strSQL = strSQL + "   '" + "�����ļ�" + "'," + vbCr
        '                        strSQL = strSQL + "    " + "1" + " ," + vbCr
        '                        strSQL = strSQL + "   '" + strFileUrl + "' " + vbCr
        '                        strSQL = strSQL + " )" + vbCr
        '                        objSqlCommand.CommandText = strSQL
        '                        objSqlCommand.Parameters.Clear()
        '                        objSqlCommand.ExecuteNonQuery()
        '                        '************************************************
        '                        intXH += 1
        '                    End If

        '                    'дǩ���ļ�
        '                    If strPJYJ <> "" Then
        '                        '�����ļ�
        '                        If objdacDangan.getFTPFileName_JNML_FILE(strErrMsg, strPJYJ, intWJND, strJNBS, intXH, strBasePath, strFileUrl) = False Then
        '                            GoTo rollDatabase
        '                        End If
        '                        If objdacCommon.doFTPUploadFile(strErrMsg, strUserId, strPassword, strPJYJ, strFileUrl) = False Then
        '                            GoTo rollDatabase
        '                        End If
        '                        '��������
        '                        strSQL = ""
        '                        strSQL = strSQL + " insert into ����_B_�����ļ� (" + vbCr
        '                        strSQL = strSQL + "   �ļ���ʶ,���,����,��ʽ,����,ҳ��,λ��" + vbCr
        '                        strSQL = strSQL + " ) values (" + vbCr
        '                        strSQL = strSQL + "   '" + strJNBS + "'," + vbCr
        '                        strSQL = strSQL + "    " + intXH.ToString + " ," + vbCr
        '                        strSQL = strSQL + "   '" + Josco.JsKernal.Common.Data.daglDanganData.TYPE_ZSWJ + "'," + vbCr
        '                        strSQL = strSQL + "   '" + Josco.JsKernal.Common.Data.daglDanganData.STYLE_YJ + "'," + vbCr
        '                        strSQL = strSQL + "   '" + "��ʽ�ļ�" + "'," + vbCr
        '                        strSQL = strSQL + "    " + "1" + " ," + vbCr
        '                        strSQL = strSQL + "   '" + strFileUrl + "' " + vbCr
        '                        strSQL = strSQL + " )" + vbCr
        '                        objSqlCommand.CommandText = strSQL
        '                        objSqlCommand.Parameters.Clear()
        '                        objSqlCommand.ExecuteNonQuery()
        '                        '************************************************
        '                        intXH += 1
        '                    End If

        '                    'д����ļ�
        '                    If strZWNR <> "" Then
        '                        '�����ļ�
        '                        If objdacDangan.getFTPFileName_JNML_FILE(strErrMsg, strZWNR, intWJND, strJNBS, intXH, strBasePath, strFileUrl) = False Then
        '                            GoTo rollDatabase
        '                        End If
        '                        If objdacCommon.doFTPUploadFile(strErrMsg, strUserId, strPassword, strZWNR, strFileUrl) = False Then
        '                            GoTo rollDatabase
        '                        End If
        '                        '��������
        '                        strSQL = ""
        '                        strSQL = strSQL + " insert into ����_B_�����ļ� (" + vbCr
        '                        strSQL = strSQL + "   �ļ���ʶ,���,����,��ʽ,����,ҳ��,λ��" + vbCr
        '                        strSQL = strSQL + " ) values (" + vbCr
        '                        strSQL = strSQL + "   '" + strJNBS + "'," + vbCr
        '                        strSQL = strSQL + "    " + intXH.ToString + " ," + vbCr
        '                        strSQL = strSQL + "   '" + Josco.JsKernal.Common.Data.daglDanganData.TYPE_PIJIAN + "'," + vbCr
        '                        strSQL = strSQL + "   '" + Josco.JsKernal.Common.Data.daglDanganData.STYLE_FYJ + "'," + vbCr
        '                        strSQL = strSQL + "   '" + "ԭ������" + "'," + vbCr
        '                        strSQL = strSQL + "    " + "1" + " ," + vbCr
        '                        strSQL = strSQL + "   '" + strFileUrl + "' " + vbCr
        '                        strSQL = strSQL + " )" + vbCr
        '                        objSqlCommand.CommandText = strSQL
        '                        objSqlCommand.Parameters.Clear()
        '                        objSqlCommand.ExecuteNonQuery()
        '                        '************************************************
        '                        intXH += 1
        '                    End If

        '                    'д��������
        '                    Dim strFJSM As String
        '                    Dim strWJWZ As String
        '                    Dim intFJXH As Integer
        '                    Dim intFJYS As Integer
        '                    Dim intCount As Integer
        '                    Dim i As Integer
        '                    With objFujianDataSet.Tables(Josco.JsKernal.Common.Data.FlowData.TABLE_GW_B_FUJIAN)
        '                        intCount = .Rows.Count
        '                        For i = 0 To intCount - 1 Step 1
        '                            '���㸽������
        '                            strFJSM = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJSM), "")
        '                            strWJWZ = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJWZ), "")
        '                            intFJXH = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJXH), 0)
        '                            intFJYS = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.FlowData.FIELD_GW_B_FUJIAN_WJYS), 0)
        '                            '�����ļ�
        '                            strDesPath = strTempPath
        '                            strDesSpec = ""
        '                            strDesFile = ""
        '                            If objdacCommon.doFTPDownLoadFile(strErrMsg, strUserId, strPassword, strWJWZ, strDesSpec, strDesPath, strDesFile) = False Then
        '                                GoTo rollDatabase
        '                            End If
        '                            '�����ļ�
        '                            If objdacDangan.getFTPFileName_JNML_FILE(strErrMsg, strDesSpec, intWJND, strJNBS, intXH, strBasePath, strFileUrl) = False Then
        '                                GoTo rollDatabase
        '                            End If
        '                            If objdacCommon.doFTPUploadFile(strErrMsg, strUserId, strPassword, strDesSpec, strFileUrl) = False Then
        '                                GoTo rollDatabase
        '                            End If
        '                            '��������
        '                            strSQL = ""
        '                            strSQL = strSQL + " insert into ����_B_�����ļ� (" + vbCr
        '                            strSQL = strSQL + "   �ļ���ʶ,���,����,��ʽ,����,ҳ��,λ��" + vbCr
        '                            strSQL = strSQL + " ) values (" + vbCr
        '                            strSQL = strSQL + "   '" + strJNBS + "'," + vbCr
        '                            strSQL = strSQL + "    " + intXH.ToString + " ," + vbCr
        '                            strSQL = strSQL + "   '" + Josco.JsKernal.Common.Data.daglDanganData.TYPE_PIJIAN + "'," + vbCr
        '                            strSQL = strSQL + "   '" + Josco.JsKernal.Common.Data.daglDanganData.STYLE_FYJ + "'," + vbCr
        '                            strSQL = strSQL + "   '" + "����" + intFJXH.ToString + "��" + strFJSM + "'," + vbCr
        '                            strSQL = strSQL + "    " + intFJYS.ToString + " ," + vbCr
        '                            strSQL = strSQL + "   '" + strFileUrl + "' " + vbCr
        '                            strSQL = strSQL + " )" + vbCr
        '                            objSqlCommand.CommandText = strSQL
        '                            objSqlCommand.Parameters.Clear()
        '                            objSqlCommand.ExecuteNonQuery()
        '                            '************************************************
        '                            intXH += 1
        '                        Next
        '                    End With

        '                Catch ex As Exception
        '                    strErrMsg = ex.Message
        '                    GoTo rollDatabase
        '                End Try

        '                '�ύ����
        '                objSqlTransaction.Commit()

        '            Catch ex As Exception
        '                strErrMsg = ex.Message
        '                GoTo errProc
        '            End Try

        '            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
        '            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
        '            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
        '            Josco.JsKernal.Common.Data.daglDanganData.SafeRelease(objAnjuanDataSet)
        '            Josco.JsKernal.Common.Data.FlowData.SafeRelease(objFujianDataSet)
        '            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
        '            Josco.JsKernal.DataAccess.dacDangan.SafeRelease(objdacDangan)
        '            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

        '            doAddToAnjuan = True
        '            Exit Function

        'rollDatabase:
        '            objSqlTransaction.Rollback()
        '            GoTo errProc

        'errProc:
        '            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
        '            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
        '            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
        '            Josco.JsKernal.Common.Data.daglDanganData.SafeRelease(objAnjuanDataSet)
        '            Josco.JsKernal.Common.Data.FlowData.SafeRelease(objFujianDataSet)
        '            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
        '            Josco.JsKernal.DataAccess.dacDangan.SafeRelease(objdacDangan)
        '            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
        '            Exit Function

        '        End Function

    End Class

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JsKernal.DataAccess
    ' ����    ��FlowObjectRenshiLuyongCreator
    '
    ' ���������� 
    '     FlowObjectRenshiLuyong�Ĵ����ӿ�ʵ��
    '----------------------------------------------------------------
    Public Class FlowObjectRenshiLuyongCreator
        Implements josco.JsKernal.DataAccess.IFlowObjectCreate

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
            ByVal strFlowTypeName As String) As josco.JsKernal.DataAccess.FlowObject _
            Implements josco.JsKernal.DataAccess.IFlowObjectCreate.Create

            Try
                Create = New josco.JSOA.DataAccess.FlowObjectRenshiLuyong
            Catch ex As Exception
                Throw ex
            End Try

        End Function

    End Class

End Namespace