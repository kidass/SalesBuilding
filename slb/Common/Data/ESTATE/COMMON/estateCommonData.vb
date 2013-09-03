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
    ' ����    ��estateCommonData
    '
    ' ����������
    '     ������ͨ�õز�������ر�����ݷ��ʸ�ʽ
    '----------------------------------------------------------------
    <System.ComponentModel.DesignerCategory("ESTATE-COMMON"), SerializableAttribute()> Public Class estateCommonData
        Inherits System.Data.DataSet

        '���ز�_B_����_˰��Ŀ¼������Ϣ����
        '������
        Public Const TABLE_DC_B_GG_SHUIFEIMULU As String = "�ز�_B_����_˰��Ŀ¼"
        '�ֶ�����
        Public Const FIELD_DC_B_GG_SHUIFEIMULU_SFDM As String = "˰�Ѵ���"
        Public Const FIELD_DC_B_GG_SHUIFEIMULU_SFMC As String = "˰������"
        'Լ��������Ϣ
        '��ʾ�ֶ�����

        '���ز�_B_����_Ӧ��Ӧ��ģ�桱����Ϣ����
        '������
        Public Const TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN As String = "�ز�_B_����_Ӧ��Ӧ��ģ��"
        '�ֶ�����
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM As String = "ģ�����"
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBMC As String = "ģ������"
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFDM As String = "˰�Ѵ���"
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFDX As String = "�ո�����"
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFBZ As String = "�ո���־"
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMX As String = "�Ƿ���ϸ"
        'Լ��������Ϣ
        '��ʾ�ֶ�����
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMC As String = "˰������"
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMXMC As String = "�Ƿ���ϸ����"

        '���ز�_B_����_��ҵ���������Ϣ����
        '������
        Public Const TABLE_DC_B_GG_WUYEJIANGE As String = "�ز�_B_����_��ҵ���"
        '�ֶ�����
        Public Const FIELD_DC_B_GG_WUYEJIANGE_WYJGDM As String = "�������"
        Public Const FIELD_DC_B_GG_WUYEJIANGE_WYJGMC As String = "�������"
        'Լ��������Ϣ
        '��ʾ�ֶ�����

        '���ز�_B_����_��ҵ���ʡ�����Ϣ����
        '������
        Public Const TABLE_DC_B_GG_WUYEXINGZHI As String = "�ز�_B_����_��ҵ����"
        '�ֶ�����
        Public Const FIELD_DC_B_GG_WUYEXINGZHI_WYXZDM As String = "���ʴ���"
        Public Const FIELD_DC_B_GG_WUYEXINGZHI_WYXZMC As String = "��������"
        'zengxianglin 2010-12-21
        Public Const FIELD_DC_B_GG_WUYEXINGZHI_SFQY As String = "�Ƿ�����"
        Public Const FIELD_DC_B_GG_WUYEXINGZHI_XSSX As String = "��ʾ˳��"
        'zengxianglin 2010-12-21
        'Լ��������Ϣ
        '��ʾ�ֶ�����

        '���ز�_B_����_���򻮷֡�����Ϣ����
        '������
        Public Const TABLE_DC_B_GG_QUYUHUAFEN As String = "�ز�_B_����_���򻮷�"
        '�ֶ�����
        Public Const FIELD_DC_B_GG_QUYUHUAFEN_QYDM As String = "�������"
        Public Const FIELD_DC_B_GG_QUYUHUAFEN_QYMC As String = "��������"
        'Լ��������Ϣ
        '��ʾ�ֶ�����

        'zengxianglin 2008-11-18
        '���ز�_B_����_�참��Ŀ������Ϣ����
        '������
        Public Const TABLE_DC_B_GG_BAXM As String = "�ز�_B_����_�참��Ŀ"
        '�ֶ�����
        Public Const FIELD_DC_B_GG_BAXM_XMDM As String = "��Ŀ����"
        Public Const FIELD_DC_B_GG_BAXM_XMMC As String = "��Ŀ����"
        'Լ��������Ϣ
        '��ʾ�ֶ�����
        'zengxianglin 2008-11-18









        '�����ʼ��������enum
        Public Enum enumTableType
            DC_B_GG_SHUIFEIMULU = 1
            DC_B_GG_YINGSHOUYINGFUMOBAN = 2

            DC_B_GG_WUYEJIANGE = 3
            DC_B_GG_WUYEXINGZHI = 4

            DC_B_GG_QUYUHUAFEN = 5

            'zengxianglin 2008-11-18
            DC_B_GG_BAXM = 6
            'zengxianglin 2008-11-18
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.Common.Data.estateCommonData)
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
                Case enumTableType.DC_B_GG_SHUIFEIMULU
                    table = createDataTables_ShuifeiMulu(strErrMsg)
                Case enumTableType.DC_B_GG_YINGSHOUYINGFUMOBAN
                    table = createDataTables_YingshouYingfuMoban(strErrMsg)
                Case enumTableType.DC_B_GG_WUYEJIANGE
                    table = createDataTables_WuyeJiange(strErrMsg)
                Case enumTableType.DC_B_GG_WUYEXINGZHI
                    table = createDataTables_WuyeXingzhi(strErrMsg)
                Case enumTableType.DC_B_GG_QUYUHUAFEN
                    table = createDataTables_QuyuHuafen(strErrMsg)

                    'zengxianglin 2008-11-18
                Case enumTableType.DC_B_GG_BAXM
                    table = createDataTables_DC_B_GG_BAXM(strErrMsg)
                    'zengxianglin 2008-11-18
                Case Else
                    strErrMsg = "��Ч�ı����ͣ�"
                    table = Nothing
            End Select

            createDataTables = table

        End Function










        '----------------------------------------------------------------
        '����TABLE_DC_B_GG_SHUIFEIMULU
        '----------------------------------------------------------------
        Private Function createDataTables_ShuifeiMulu(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_GG_SHUIFEIMULU)
                With table.Columns
                    .Add(FIELD_DC_B_GG_SHUIFEIMULU_SFDM, GetType(System.String))
                    .Add(FIELD_DC_B_GG_SHUIFEIMULU_SFMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_ShuifeiMulu = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN
        '----------------------------------------------------------------
        Private Function createDataTables_YingshouYingfuMoban(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN)
                With table.Columns
                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM, GetType(System.String))
                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBMC, GetType(System.String))
                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFDM, GetType(System.String))
                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFDX, GetType(System.String))
                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFBZ, GetType(System.String))
                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMX, GetType(System.Int32))


                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMC, GetType(System.String))
                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMXMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_YingshouYingfuMoban = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_DC_B_GG_WUYEJIANGE
        '----------------------------------------------------------------
        Private Function createDataTables_WuyeJiange(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_GG_WUYEJIANGE)
                With table.Columns
                    .Add(FIELD_DC_B_GG_WUYEJIANGE_WYJGDM, GetType(System.String))
                    .Add(FIELD_DC_B_GG_WUYEJIANGE_WYJGMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_WuyeJiange = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_DC_B_GG_WUYEXINGZHI
        '----------------------------------------------------------------
        Private Function createDataTables_WuyeXingzhi(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_GG_WUYEXINGZHI)
                With table.Columns
                    .Add(FIELD_DC_B_GG_WUYEXINGZHI_WYXZDM, GetType(System.String))
                    .Add(FIELD_DC_B_GG_WUYEXINGZHI_WYXZMC, GetType(System.String))
                    'zengxianglin 2010-12-21
                    .Add(FIELD_DC_B_GG_WUYEXINGZHI_SFQY, GetType(System.Int32))
                    .Add(FIELD_DC_B_GG_WUYEXINGZHI_XSSX, GetType(System.Int32))
                    'zengxianglin 2010-12-21
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_WuyeXingzhi = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_DC_B_GG_QUYUHUAFEN
        '----------------------------------------------------------------
        Private Function createDataTables_QuyuHuafen(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_GG_QUYUHUAFEN)
                With table.Columns
                    .Add(FIELD_DC_B_GG_QUYUHUAFEN_QYDM, GetType(System.String))
                    .Add(FIELD_DC_B_GG_QUYUHUAFEN_QYMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_QuyuHuafen = table

        End Function

        'zengxianglin 2008-11-18
        '----------------------------------------------------------------
        '����TABLE_DC_B_GG_BAXM
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_GG_BAXM(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_GG_BAXM)
                With table.Columns
                    .Add(FIELD_DC_B_GG_BAXM_XMDM, GetType(System.String))
                    .Add(FIELD_DC_B_GG_BAXM_XMMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_GG_BAXM = table

        End Function
        'zengxianglin 2008-11-18

    End Class 'estateCommonData

End Namespace 'Josco.JsKernal.Common.Data
