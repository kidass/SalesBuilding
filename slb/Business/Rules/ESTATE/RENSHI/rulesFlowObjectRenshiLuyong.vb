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
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic

Imports Josco.JsKernal.SystemFramework
Imports Josco.JsKernal.Common
Imports Josco.JsKernal.Common.Data
Imports Josco.JsKernal.DataAccess

Namespace Josco.JSOA.BusinessRules

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessRules
    ' ����    ��rulesFlowObjectRenshiLuyong
    '
    ' ���������� 
    '   ������¼��������������ҵ���������
    '----------------------------------------------------------------
    Public Class rulesFlowObjectRenshiLuyong
        Inherits Josco.JsKernal.BusinessRules.rulesFlowObject

        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New(Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWCODE, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FLOWNAME)
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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub











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

            getMainData = False
            objestateRenshiXingyeData = Nothing

            Try
                '��ʼ������������
                If Me.m_objFlowObject.doInitialize(strErrMsg, strUserId, strPassword, strWJBS, False) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Dim objDataSet As System.Data.DataSet = Nothing
                Dim strTableName As String = ""
                If Me.m_objFlowObject.getMainFlowData(strErrMsg, objDataSet, strTableName) = False Then
                    GoTo errProc
                End If

                '����
                objestateRenshiXingyeData = CType(objDataSet, Josco.JSOA.Common.Data.estateRenshiXingyeData)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getMainData = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����strWJBS��ȡ���ز�_B_����_¼�������������ݼ�
        '     strErrMsg                     ����������򷵻ش�����Ϣ
        '     objestateRenshiXingyeData     ����Ϣ���ݼ�
        ' ����
        '     True                          ���ɹ�
        '     False                         ��ʧ��
        '----------------------------------------------------------------
        Public Function getMainData( _
            ByRef strErrMsg As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean

            getMainData = False
            objestateRenshiXingyeData = Nothing

            Try
                '��ȡ����
                Dim objDataSet As System.Data.DataSet = Nothing
                Dim strTableName As String = ""
                If Me.m_objFlowObject.getMainFlowData(strErrMsg, objDataSet, strTableName) = False Then
                    GoTo errProc
                End If

                '����
                objestateRenshiXingyeData = CType(objDataSet, Josco.JSOA.Common.Data.estateRenshiXingyeData)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            getMainData = True
            Exit Function
errProc:
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ģ���ļ���
        ' ����
        '                    �����ģ���ļ���
        '----------------------------------------------------------------
        Public Overrides Function getGJMBFile() As String

            Try
                getGJMBFile = Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong.FILEMBDIR_GJ
            Catch ex As Exception
                getGJMBFile = ""
            End Try

        End Function

        '----------------------------------------------------------------
        ' ��ȡ����ļ���FTP·����
        ' ����
        '                    ������ļ���FTP·����
        '----------------------------------------------------------------
        Public Overrides Function getGJFTPFile() As String

            Try
                Dim objBaseFlowRenshiLuyong As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                getGJFTPFile = objBaseFlowRenshiLuyong.ZWNR
            Catch ex As Exception
                getGJFTPFile = ""
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

            getNewWjxh = False
            Try
                Dim objBaseFlowRenshiLuyong As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
                objBaseFlowRenshiLuyong = CType(Me.FlowData, Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
                Dim objFlowObjectRenshiLuyong As Josco.JSOA.DataAccess.FlowObjectRenshiLuyong
                objFlowObjectRenshiLuyong = CType(Me.m_objFlowObject, Josco.JSOA.DataAccess.FlowObjectRenshiLuyong)
                getNewWjxh = objFlowObjectRenshiLuyong.getNewWjxh(strErrMsg, strJGDZ, strWJNF, strWJXH)
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
            getDataSet_RYXX = False
            Try
                Dim objFlowObjectRenshiLuyong As Josco.JSOA.DataAccess.FlowObjectRenshiLuyong
                objFlowObjectRenshiLuyong = CType(Me.m_objFlowObject, Josco.JSOA.DataAccess.FlowObjectRenshiLuyong)
                getDataSet_RYXX = objFlowObjectRenshiLuyong.getDataSet_RYXX(strErrMsg, objestateRenshiXingyeData)
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
            getDataSet_Main = False
            Try
                Dim objFlowObjectRenshiLuyong As Josco.JSOA.DataAccess.FlowObjectRenshiLuyong
                objFlowObjectRenshiLuyong = CType(Me.m_objFlowObject, Josco.JSOA.DataAccess.FlowObjectRenshiLuyong)
                getDataSet_Main = objFlowObjectRenshiLuyong.getDataSet_Main(strErrMsg, strUserXM, strWhere, objestateRenshiXingyeData)
            Catch ex As Exception
                strErrMsg = ex.Message
                getDataSet_Main = False
            End Try
        End Function

    End Class 'rulesFlowObjectRenshiLuyong



    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JsKernal.DataAccess
    ' ����    ��FlowObjectRenshiLuyongCreator
    '
    ' ���������� 
    '     FlowObjectRenshiLuyong�Ĵ����ӿ�ʵ��
    '----------------------------------------------------------------
    Public Class rulesFlowObjectRenshiLuyongCreator
        Implements Josco.JsKernal.BusinessRules.IRulesFlowObjectCreate

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
            ByVal strFlowTypeName As String) As Josco.JsKernal.BusinessRules.rulesFlowObject _
            Implements Josco.JsKernal.BusinessRules.IRulesFlowObjectCreate.Create

            Try
                Create = New Josco.JSOA.BusinessRules.rulesFlowObjectRenshiLuyong
            Catch ex As Exception
                Throw ex
            End Try

        End Function

    End Class

End Namespace 'Josco.JsKernal.BusinessRules
