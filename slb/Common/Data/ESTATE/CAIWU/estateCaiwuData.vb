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

Namespace Josco.JSOA.Common.Data

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.Common.Data
    ' ����    ��estateCaiwuData
    '
    ' ����������
    '     ��������������ر�����ݷ��ʸ�ʽ
    ' ���ļ�¼��
    '     zengxianglin 2009-05-17 ����
    '----------------------------------------------------------------
    <System.ComponentModel.DesignerCategory("ESTATE-CAIWU"), SerializableAttribute()> Public Class estateCaiwuData
        Inherits System.Data.DataSet

        '���ز�_B_����_Ʊ��ʹ�����������Ϣ����
        '������
        Public Const TABLE_DC_B_CW_PIAOJUSHIYONG As String = "�ز�_B_����_Ʊ��ʹ�����"
        '�ֶ�����
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_WYBS As String = "Ψһ��ʶ"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_PJPH As String = "Ʊ������"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_PJHM As String = "Ʊ�ݺ���"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_FGFH As String = "��������"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_PJLX As String = "Ʊ������"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_FFRY As String = "������Ա"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_FFRQ As String = "��������"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_KPJE As String = "��Ʊ���"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_KPRQ As String = "��Ʊ����"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_JBRY As String = "������Ա"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_YWBS As String = "ҵ���ʶ"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_ZYSM As String = "ժҪ˵��"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_ZFRY As String = "������Ա"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_ZFRQ As String = "��������"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_ZTBZ As String = "״̬��־"
        'zengxianglin 2008-11-18
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_BJRY As String = "�����Ա"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_BJRQ As String = "�������"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_SFDM As String = "˰�Ѵ���"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_SFDX As String = "�ո�����"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_SFBZ As String = "�ո���־"
        'zengxianglin 2008-11-18
        'zengxianglin 2009-05-17
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_HXBZ As String = "������־"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_HXRY As String = "������Ա"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_HXRQ As String = "��������"
        'zengxianglin 2009-05-17
        'Լ��������Ϣ
        '��ʾ�ֶ�����
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_FGFHMC As String = "������������"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_FFRYMC As String = "������Ա����"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_JBRYMC As String = "������Ա����"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_ZFRYMC As String = "������Ա����"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_ZTBZMC As String = "״̬��־����"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_WYPJHM As String = "ΨһƱ�ݺ���"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_JYBH As String = "���ױ��"
        'zengxianglin 2008-11-18
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_BJRYMC As String = "�����Ա����"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_SFMC As String = "˰������"
        'zengxianglin 2008-11-18
        'zengxianglin 2009-05-17
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_HXBZMC As String = "������־����"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_HXRYMC As String = "������Ա����"
        'zengxianglin 2009-05-17

        '���ز�_B_����_����Ӧ��Ӧ��������Ϣ����
        '������
        Public Const TABLE_DC_B_CW_ES_YINGSHOUYINGFU As String = "�ز�_B_����_����Ӧ��Ӧ��"
        '�ֶ�����
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS As String = "Ψһ��ʶ"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QRSH As String = "ȷ�����"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDM As String = "˰�Ѵ���"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDX As String = "�ո�����"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFBZ As String = "�ո���־"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSRQ As String = "Ӧ������"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE As String = "Ӧ�ս��"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFZT As String = "�ո�״̬"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QTMS As String = "��������"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_KSRQ As String = "��ʼ����"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JSRQ As String = "��������"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JZYF As String = "�����·�"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JZQJ As String = "��������"
        '��ʾ�ֶ�����
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFMC As String = "˰������"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SSJE As String = "ʵ�ս��"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_S As String = "Ӧ�ս����"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_F As String = "Ӧ�ս�"

        '���ز�_B_����_����ʵ��ʵ��������Ϣ����
        '������
        Public Const TABLE_DC_B_CW_ES_SHISHOUSHIFU As String = "�ز�_B_����_����ʵ��ʵ��"
        '�ֶ�����
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS As String = "Ψһ��ʶ"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH As String = "ȷ�����"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_PJHM As String = "Ʊ�ݺ���"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM As String = "˰�Ѵ���"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX As String = "�ո�����"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ As String = "�ո���־"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSRQ As String = "��������"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE As String = "�������"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_ZYSM As String = "ժҪ˵��"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_KHMC As String = "�ͻ�����"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRY As String = "������Ա"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDW As String = "�������"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZ As String = "��˱�־"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSH As String = "�������"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHRQ As String = "�������"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_JHBS As String = "�ƻ���ʶ"
        '��ʾ�ֶ�����
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC As String = "˰������"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRYMC As String = "������Ա����"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDWMC As String = "�����������"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSHMC As String = "�����������"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFSH As String = "�Ƿ����"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZMC As String = "��˱�־����"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_S As String = "���������"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_F As String = "������"










        '�����ʼ��������enum
        Public Enum enumTableType
            DC_B_CW_PIAOJUSHIYONG = 1
            DC_B_CW_ES_YINGSHOUYINGFU = 2
            DC_B_CW_ES_SHISHOUSHIFU = 3
        End Enum









        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub

        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
        End Sub

        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New(ByVal objenumTableType As enumTableType)
            MyBase.New()
            Try
                Dim objDataTable As System.Data.DataTable
                Dim strErrMsg As String
                objDataTable = Me.createDataTables(strErrMsg, objenumTableType)
                If Not (objDataTable Is Nothing) Then
                    Me.Tables.Add(objDataTable)
                End If
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' ��ȫ�ͷű�����Դ
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.Common.Data.estateCaiwuData)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub








        '----------------------------------------------------------------
        ' ר���б�
        '----------------------------------------------------------------
        '�ա���
        Public Const SFBZ_S As String = "��"
        Public Const SFBZ_F As String = "��"

        '�ס���
        Public Const SFDX_J As String = "��"
        Public Const SFDX_Y As String = "��"

        'Ʊ��״̬
        Public Enum enumPiaojuStatus
            Unused = 0
            Used = 1
            Zuofei = 2
            Shouhui = 4
        End Enum

        'Ӧ�ռƻ��еġ��ո�״̬���б�
        Public Enum enumSFZT
            Normal = 1
            Zujin = 2
        End Enum









        '----------------------------------------------------------------
        '������DataTable���뵽DataSet��
        '----------------------------------------------------------------
        Public Function appendDataTable(ByVal table As System.Data.DataTable) As String

            Dim strErrMsg As String = ""

            Try
                Me.Tables.Add(table)
            Catch ex As Exception
                strErrMsg = ex.Message
            End Try

            appendDataTable = strErrMsg

        End Function

        '----------------------------------------------------------------
        '����ָ�����ʹ���dataTable
        '----------------------------------------------------------------
        Public Function createDataTables( _
            ByRef strErrMsg As String, _
            ByVal enumType As enumTableType) As System.Data.DataTable

            Dim table As System.Data.DataTable

            Select Case enumType
                Case enumTableType.DC_B_CW_PIAOJUSHIYONG
                    table = createDataTables_PiaojuShiyong(strErrMsg)
                Case enumTableType.DC_B_CW_ES_YINGSHOUYINGFU
                    table = createDataTables_YingshouYingfu(strErrMsg)
                Case enumTableType.DC_B_CW_ES_SHISHOUSHIFU
                    table = createDataTables_ShishouShifu(strErrMsg)
                Case Else
                    strErrMsg = "��Ч�ı����ͣ�"
                    table = Nothing
            End Select

            createDataTables = table

        End Function










        '----------------------------------------------------------------
        '����TABLE_DC_B_CW_PIAOJUSHIYONG
        '----------------------------------------------------------------
        Private Function createDataTables_PiaojuShiyong(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_CW_PIAOJUSHIYONG)
                With table.Columns
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_PJPH, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_PJHM, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_FGFH, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_PJLX, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_FFRY, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_FFRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_KPJE, GetType(System.Double))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_KPRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_YWBS, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_ZYSM, GetType(System.String))

                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_ZFRY, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_ZFRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_ZTBZ, GetType(System.Int32))

                    'zengxianglin 2008-11-18
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_BJRY, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_BJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_SFDM, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_SFDX, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_SFBZ, GetType(System.String))
                    'zengxianglin 2008-11-18

                    'zengxianglin 2009-05-17
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_HXBZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_HXRY, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_HXRQ, GetType(System.DateTime))
                    'zengxianglin 2009-05-17


                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_FGFHMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_FFRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_ZFRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_ZTBZMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_WYPJHM, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_JYBH, GetType(System.String))
                    'zengxianglin 2008-11-18
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_BJRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_SFMC, GetType(System.String))
                    'zengxianglin 2008-11-18

                    'zengxianglin 2009-05-17
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_HXRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_HXBZMC, GetType(System.String))
                    'zengxianglin 2009-05-17
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_PiaojuShiyong = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_DC_B_CW_ES_YINGSHOUYINGFU
        '----------------------------------------------------------------
        Private Function createDataTables_YingshouYingfu(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_CW_ES_YINGSHOUYINGFU)
                With table.Columns
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QRSH, GetType(System.String))

                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDM, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDX, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFBZ, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE, GetType(System.Double))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFZT, GetType(System.Int32))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QTMS, GetType(System.String))

                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_KSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JZYF, GetType(System.Int32))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JZQJ, GetType(System.String))


                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SSJE, GetType(System.Double))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_S, GetType(System.Double))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_F, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_YingshouYingfu = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_DC_B_CW_ES_SHISHOUSHIFU
        '----------------------------------------------------------------
        Private Function createDataTables_ShishouShifu(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_CW_ES_SHISHOUSHIFU)
                With table.Columns
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH, GetType(System.String))

                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_PJHM, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE, GetType(System.Double))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_ZYSM, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_KHMC, GetType(System.String))

                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDW, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSH, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_JHBS, GetType(System.String))


                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSHMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFSH, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_S, GetType(System.Double))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_F, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_ShishouShifu = table

        End Function

    End Class 'estateCaiwuData

End Namespace 'Josco.JsKernal.Common.Data
