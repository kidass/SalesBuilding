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
Imports System.Runtime.Serialization
Imports Josco.JsKernal.Common.Workflow.BaseFlowObject

Namespace Josco.JSOA.Common.Workflow

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.Common.Workflow
    ' ����    ��BaseFlowRenshiLuyong
    '
    ' ���������� 
    '     ��������¼��������������صĲ���
    '----------------------------------------------------------------
    Public Class BaseFlowRenshiLuyong
        Inherits Josco.JsKernal.Common.Workflow.BaseFlowObject

        Public Const FLOWCODE As String = "RsLuyong"
        Public Const FLOWNAME As String = "����¼��"
        Public Const FLOWBLLX As String = "����¼��"

        '���˶���
        Public Const TASK_CYCG As String = "�������"
        Public Const TASK_GJBJ As String = "���촦��"
        Public Const TASK_SHWJ As String = "����ļ�"
        Public Const TASK_HQWJ As String = "��ǩ�ļ�"
        Public Const TASK_FHWJ As String = "�����ļ�"
        Public Const TASK_QFWJ As String = "ǩ���ļ�"
        Public Const TASK_WJGD As String = "�ļ��鵵"

        'Ŀ¼�趨
        Public Const FILEDIR_FJ As String = "RS\LUYONG\FJ"          '����Ŀ¼
        Public Const FILEDIR_XG As String = "RS\LUYONG\XG"          '����ļ�Ŀ¼
        Public Const FILEDIR_GJ As String = "RS\LUYONG\GJ"          '���Ŀ¼
        Public Const FILEDIR_RO As String = "RS\LUYONG\RO"          'ǩ���ļ�(ɨ���)Ŀ¼
        Public Const FILEDIR_PJ As String = "RS\LUYONG\PJ"          'ǩ���ļ�(���Ӽ�)Ŀ¼

        '�ļ�ģ��
        Public Const FILEMBDIR_FJ_RTF As String = "�ո���.RTF"      '����ģ���ļ�(RTF)
        Public Const FILEMBDIR_GJ_RTF As String = "�ո��.RTF"      '���ģ���ļ�(RTF)
        Public Const FILEMBDIR_FJ As String = "�ո���.DOC"          '����ģ���ļ�(DOC)
        Public Const FILEMBDIR_GJ As String = "�ո��.DOC"          '���ģ���ļ�(DOC)

        '�����������
        Public Const SPYJ_BLYJ As String = "�������"
        Public Const SPYJ_BTY As String = "��ͬ��"
        Public Const SPYJ_TY As String = "ͬ��"

        '����
        '*******************************************************
        Private m_strJJCD As String
        Private m_strMMDJ As String
        '*******************************************************
        Private m_strWJBT As String
        Private m_strJGDZ As String
        Private m_strWJNF As String
        Private m_strWJXH As String
        '*******************************************************
        Private m_strJBDW As String
        Private m_strJBRY As String
        Private m_objJBRQ As System.DateTime
        '*******************************************************
        Private m_strZWNR As String
        Private m_strHJWJ As String
        Private m_strPJYJ As String
        '*******************************************************
        Private m_strBEIZ As String
        '*******************************************************
        Private m_intDBRS As Integer
        '*******************************************************









        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New(FLOWCODE)

            '���ù���������
            Me.FlowType = Me.FLOWCODE
            Me.FlowTypeName = Me.FLOWNAME
            Me.FlowTypeBLLX = Me.FLOWBLLX

            '��ʼ����������������
            '*******************************************************
            m_strJJCD = ""
            m_strMMDJ = ""
            '*******************************************************
            m_strWJBT = ""
            m_strJGDZ = ""
            m_strWJNF = ""
            m_strWJXH = ""
            '*******************************************************
            m_strJBDW = ""
            m_strJBRY = ""
            m_objJBRQ = Nothing
            '*******************************************************
            m_strZWNR = ""
            m_strHJWJ = ""
            m_strPJYJ = ""
            '*******************************************************
            m_strBEIZ = ""
            '*******************************************************
            m_intDBRS = 0
            '*******************************************************

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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub









        '----------------------------------------------------------------
        ' ��ȡ���������ˡ��İ�������SQLֵ�б�
        '----------------------------------------------------------------
        Public Overrides ReadOnly Property TaskBlzlSPSYList() As String
            Get
                TaskBlzlSPSYList = ""
                TaskBlzlSPSYList = TaskBlzlSPSYList + " " + "'" + TASK_LDCL + "'"
                TaskBlzlSPSYList = TaskBlzlSPSYList + "," + "'" + TASK_XGCL + "'"
                TaskBlzlSPSYList = TaskBlzlSPSYList + "," + "'" + TASK_SHWJ + "'"
                TaskBlzlSPSYList = TaskBlzlSPSYList + "," + "'" + TASK_HQWJ + "'"
                TaskBlzlSPSYList = TaskBlzlSPSYList + "," + "'" + TASK_FHWJ + "'"
                TaskBlzlSPSYList = TaskBlzlSPSYList + "," + "'" + TASK_QFWJ + "'"
            End Get
        End Property









        '----------------------------------------------------------------
        ' ǩ����
        '----------------------------------------------------------------
        Public Property QFR() As String
            Get
                QFR = Me.PZR
            End Get
            Set(ByVal Value As String)
                Me.PZR = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' ǩ������
        '----------------------------------------------------------------
        Public Property QFRQ() As System.DateTime
            Get
                QFRQ = Me.PZRQ
            End Get
            Set(ByVal Value As System.DateTime)
                Me.PZRQ = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' ����״̬
        '----------------------------------------------------------------
        Public Property BLZT() As String
            Get
                BLZT = Me.Status
            End Get
            Set(ByVal Value As String)
                Me.Status = Value
            End Set
        End Property










        '----------------------------------------------------------------
        ' �����̶�
        '----------------------------------------------------------------
        Public Property JJCD() As String
            Get
                JJCD = m_strJJCD
            End Get
            Set(ByVal Value As String)
                m_strJJCD = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' ���ܵȼ�
        '----------------------------------------------------------------
        Public Property MMDJ() As String
            Get
                MMDJ = m_strMMDJ
            End Get
            Set(ByVal Value As String)
                m_strMMDJ = Value
            End Set
        End Property










        '----------------------------------------------------------------
        ' �ļ�����
        '----------------------------------------------------------------
        Public Property WJBT() As String
            Get
                WJBT = m_strWJBT
            End Get
            Set(ByVal Value As String)
                m_strWJBT = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' ���ش���
        '----------------------------------------------------------------
        Public Property JGDZ() As String
            Get
                JGDZ = m_strJGDZ
            End Get
            Set(ByVal Value As String)
                m_strJGDZ = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' �ļ����
        '----------------------------------------------------------------
        Public Property WJNF() As String
            Get
                WJNF = m_strWJNF
            End Get
            Set(ByVal Value As String)
                m_strWJNF = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' �ļ����
        '----------------------------------------------------------------
        Public Property WJXH() As String
            Get
                WJXH = m_strWJXH
            End Get
            Set(ByVal Value As String)
                m_strWJXH = Value
            End Set
        End Property










        '----------------------------------------------------------------
        ' ���쵥λ
        '----------------------------------------------------------------
        Public Property ZBDW() As String
            Get
                ZBDW = m_strJBDW
            End Get
            Set(ByVal Value As String)
                m_strJBDW = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' ������Ա
        '----------------------------------------------------------------
        Public Property NGR() As String
            Get
                NGR = m_strJBRY
            End Get
            Set(ByVal Value As String)
                m_strJBRY = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' ��������
        '----------------------------------------------------------------
        Public Property NGRQ() As System.DateTime
            Get
                NGRQ = m_objJBRQ
            End Get
            Set(ByVal Value As System.DateTime)
                m_objJBRQ = Value
            End Set
        End Property










        '----------------------------------------------------------------
        ' ��������
        '----------------------------------------------------------------
        Public Property ZWNR() As String
            Get
                ZWNR = m_strZWNR
            End Get
            Set(ByVal Value As String)
                m_strZWNR = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' �ۼ��ļ� = ǩ�������Ӽ�
        '----------------------------------------------------------------
        Public Property HJWJ() As String
            Get
                HJWJ = m_strHJWJ
            End Get
            Set(ByVal Value As String)
                m_strHJWJ = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' ����ԭ�� = ǩ����ɨ���
        '----------------------------------------------------------------
        Public Property PJYJ() As String
            Get
                PJYJ = m_strPJYJ
            End Get
            Set(ByVal Value As String)
                m_strPJYJ = Value
            End Set
        End Property











        '----------------------------------------------------------------
        ' ��ע
        '----------------------------------------------------------------
        Public Property BEIZ() As String
            Get
                BEIZ = m_strBEIZ
            End Get
            Set(ByVal Value As String)
                m_strBEIZ = Value
            End Set
        End Property









        '----------------------------------------------------------------
        ' ��������
        '----------------------------------------------------------------
        Public Property DBRS() As Integer
            Get
                DBRS = m_intDBRS
            End Get
            Set(ByVal Value As Integer)
                m_intDBRS = Value
            End Set
        End Property

    End Class











    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.Common.Utilities
    ' ����    ��BaseFlowRenshiLuyongCreator
    '
    ' ���������� 
    '     BaseFlow�Ĵ����ӿ�ʵ��
    '----------------------------------------------------------------
    Public Class BaseFlowRenshiLuyongCreator
        Implements Josco.JsKernal.Common.Workflow.IBaseFlowCreate

        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
        End Sub

        '----------------------------------------------------------------
        ' ʵ�ֽӿ�
        '----------------------------------------------------------------
        Public Function Create(ByVal strFlowType As String) As Josco.JsKernal.Common.Workflow.BaseFlowObject _
            Implements Josco.JsKernal.Common.Workflow.IBaseFlowCreate.Create

            Try
                Create = New Josco.JSOA.Common.Workflow.BaseFlowRenshiLuyong
            Catch ex As Exception
                Throw ex
            End Try

        End Function

    End Class

End Namespace