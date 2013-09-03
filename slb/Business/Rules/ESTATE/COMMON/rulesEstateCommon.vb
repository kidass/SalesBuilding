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
    ' ����    ��rulesEstateCommon
    '
    ' ���������� 
    '   ���ṩ��ͨ�õز��������ҵ�����
    '----------------------------------------------------------------
    Public Class rulesEstateCommon
        Implements System.IDisposable

        Private m_objdacEstateCommon As Josco.JSOA.DataAccess.dacEstateCommon

        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
            m_objdacEstateCommon = New Josco.JSOA.DataAccess.dacEstateCommon
        End Sub

        '----------------------------------------------------------------
        ' ��ȫ�ͷű�����Դ
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessRules.rulesEstateCommon)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub

        '----------------------------------------------------------------
        ' ������������
        '----------------------------------------------------------------
        Public Sub Dispose() Implements System.IDisposable.Dispose

            Dispose(True)
            GC.SuppressFinalize(True)

        End Sub

        '----------------------------------------------------------------
        ' ������������
        '----------------------------------------------------------------
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If (Not disposing) Then
                Exit Sub
            End If
            If Not (m_objdacEstateCommon Is Nothing) Then
                m_objdacEstateCommon.Dispose()
                m_objdacEstateCommon = Nothing
            End If
        End Sub











        '----------------------------------------------------------------
        ' �����ݴ�DataSet������Excel
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     objDataSet             ��Ҫ���������ݼ�
        '     strExcelFile           ��������WEB�������е�Excel�ļ�·��
        '     strMacroName           �������б�
        '     strMacroValue          ����ֵ�б�
        '     strDateFormat          �����ڸ�ʽ�ַ���
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doExportToExcel( _
            ByRef strErrMsg As String, _
            ByVal objDataSet As System.Data.DataSet, _
            ByVal strExcelFile As String, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "", _
            Optional ByVal strDateFormat As String = "") As Boolean
            With Me.m_objdacEstateCommon
                doExportToExcel = .doExportToExcel(strErrMsg, objDataSet, strExcelFile, strMacroName, strMacroValue, strDateFormat)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����ݴ�DataSet������Excel
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     objDataSet             ��Ҫ���������ݼ�
        '     strExcelFile           ��������WEB�������е�Excel�ļ�·��
        '     strColorFieldName      ������ȷ������ɫ���ֶ���
        '     objColors              ���ֶ�ֵ��Ӧ����ɫ����
        '     strMacroName           �������б�
        '     strMacroValue          ����ֵ�б�
        '     strDateFormat          �����ڸ�ʽ�ַ���
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doExportToExcel( _
            ByRef strErrMsg As String, _
            ByVal objDataSet As System.Data.DataSet, _
            ByVal strExcelFile As String, _
            ByVal strColorFieldName As String, _
            ByVal objColors As System.Collections.Specialized.ListDictionary, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "", _
            Optional ByVal strDateFormat As String = "") As Boolean
            With Me.m_objdacEstateCommon
                doExportToExcel = .doExportToExcel(strErrMsg, objDataSet, strExcelFile, strColorFieldName, objColors, strMacroName, strMacroValue, strDateFormat)
            End With
        End Function










        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_˰��Ŀ¼����SQL���(�ԡ�˰�Ѵ��롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ShuifeiMulu() As String
            With m_objdacEstateCommon
                getTableSQL_ShuifeiMulu = .getTableSQL_ShuifeiMulu()
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�˰�Ѵ��롱��ȡ��˰�����ơ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strSfdm                   ��˰�Ѵ���
        '     strSfmc                   ��˰������(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getSfmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strSfdm As String, _
            ByRef strSfmc As String) As Boolean
            With m_objdacEstateCommon
                getSfmc = .getSfmc(strErrMsg, strUserId, strPassword, strSfdm, strSfmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�˰�����ơ���ȡ��˰�Ѵ��롱
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strSfmc                   ��˰������
        '     strSfdm                   ��˰�Ѵ���(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getSfdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strSfmc As String, _
            ByRef strSfdm As String) As Boolean
            With m_objdacEstateCommon
                getSfdm = .getSfdm(strErrMsg, strUserId, strPassword, strSfmc, strSfdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_˰��Ŀ¼����ȫ���ݵ����ݼ�(�ԡ�˰�Ѵ��롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateCommonData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ShuifeiMulu( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCommonData As Josco.JSOA.Common.Data.estateCommonData) As Boolean
            With m_objdacEstateCommon
                getDataSet_ShuifeiMulu = .getDataSet_ShuifeiMulu(strErrMsg, strUserId, strPassword, strWhere, objestateCommonData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_˰��Ŀ¼��������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_ShuifeiMulu( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateCommon
                doSaveData_ShuifeiMulu = .doSaveData_ShuifeiMulu(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_˰��Ŀ¼��������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_ShuifeiMulu( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateCommon
                doDeleteData_ShuifeiMulu = .doDeleteData_ShuifeiMulu(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_��ҵ�������SQL���(�ԡ�������롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_WuyeJiange() As String
            With m_objdacEstateCommon
                getTableSQL_WuyeJiange = .getTableSQL_WuyeJiange()
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�������롱��ȡ��������ơ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWyjgdm                 ���������
        '     strWyjgmc                 ���������(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getWyjgmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWyjgdm As String, _
            ByRef strWyjgmc As String) As Boolean
            With m_objdacEstateCommon
                getWyjgmc = .getWyjgmc(strErrMsg, strUserId, strPassword, strWyjgdm, strWyjgmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�������ơ���ȡ��������롱
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWyjgmc                 ���������
        '     strWyjgdm                 ���������(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getWyjgdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWyjgmc As String, _
            ByRef strWyjgdm As String) As Boolean
            With m_objdacEstateCommon
                getWyjgdm = .getWyjgdm(strErrMsg, strUserId, strPassword, strWyjgmc, strWyjgdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_��ҵ�������ȫ���ݵ����ݼ�(�ԡ�������롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateCommonData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_WuyeJiange( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCommonData As Josco.JSOA.Common.Data.estateCommonData) As Boolean
            With m_objdacEstateCommon
                getDataSet_WuyeJiange = .getDataSet_WuyeJiange(strErrMsg, strUserId, strPassword, strWhere, objestateCommonData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_��ҵ�����������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_WuyeJiange( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateCommon
                doSaveData_WuyeJiange = .doSaveData_WuyeJiange(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_��ҵ�����������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_WuyeJiange( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateCommon
                doDeleteData_WuyeJiange = .doDeleteData_WuyeJiange(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function












        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_��ҵ���ʡ���SQL���(�ԡ����ʴ��롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_WuyeXingzhi() As String
            With m_objdacEstateCommon
                getTableSQL_WuyeXingzhi = .getTableSQL_WuyeXingzhi()
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ����ʴ��롱��ȡ���������ơ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWyxzdm                 �����ʴ���
        '     strWyxzmc                 ����������(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getWyxzmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWyxzdm As String, _
            ByRef strWyxzmc As String) As Boolean
            With m_objdacEstateCommon
                getWyxzmc = .getWyxzmc(strErrMsg, strUserId, strPassword, strWyxzdm, strWyxzmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ��������ơ���ȡ�����ʴ��롱
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWyxzmc                 ����������
        '     strWyxzdm                 �����ʴ���(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getWyxzdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWyxzmc As String, _
            ByRef strWyxzdm As String) As Boolean
            With m_objdacEstateCommon
                getWyxzdm = .getWyxzdm(strErrMsg, strUserId, strPassword, strWyxzmc, strWyxzdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_��ҵ���ʡ���ȫ���ݵ����ݼ�(�ԡ����ʴ��롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateCommonData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_WuyeXingzhi( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCommonData As Josco.JSOA.Common.Data.estateCommonData) As Boolean
            With m_objdacEstateCommon
                getDataSet_WuyeXingzhi = .getDataSet_WuyeXingzhi(strErrMsg, strUserId, strPassword, strWhere, objestateCommonData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_��ҵ���ʡ�������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_WuyeXingzhi( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateCommon
                doSaveData_WuyeXingzhi = .doSaveData_WuyeXingzhi(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_��ҵ���ʡ�������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_WuyeXingzhi( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateCommon
                doDeleteData_WuyeXingzhi = .doDeleteData_WuyeXingzhi(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function











        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_Ӧ��Ӧ��ģ�桱��SQL���(�ԡ�ģ����롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_YingshouYingfuMoban() As String
            With m_objdacEstateCommon
                getTableSQL_YingshouYingfuMoban = .getTableSQL_YingshouYingfuMoban()
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ģ����롱��ȡ��ģ�����ơ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strMbdm                   ��ģ�����
        '     strMbmc                   ��ģ������(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getMbmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strMbdm As String, _
            ByRef strMbmc As String) As Boolean
            With m_objdacEstateCommon
                getMbmc = .getMbmc(strErrMsg, strUserId, strPassword, strMbdm, strMbmc)
            End With
        End Function

        ''----------------------------------------------------------------
        '' ���ݡ�ģ�����ơ���ȡ��ģ����롱
        ''     strErrMsg                 ����������򷵻ش�����Ϣ
        ''     strUserId                 ���û���ʶ
        ''     strPassword               ���û�����
        ''     strMbmc                   ��ģ������
        ''     strMbdm                   ��ģ�����(����)
        '' ����
        ''     True                      ���ɹ�
        ''     False                     ��ʧ��
        ''----------------------------------------------------------------
        'Public Function getMbdm( _
        '    ByVal strErrMsg As String, _
        '    ByVal strUserId As String, _
        '    ByVal strPassword As String, _
        '    ByVal strMbmc As String, _
        '    ByRef strMbdm As String) As Boolean
        '    With m_objdacEstateCommon
        '        getMbdm = .getMbdm(strErrMsg, strUserId, strPassword, strMbmc, strMbdm)
        '    End With
        'End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_Ӧ��Ӧ��ģ�桱��ȫ���ݵ����ݼ�(�ԡ�ģ����롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateCommonData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_YingshouYingfuMoban( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCommonData As Josco.JSOA.Common.Data.estateCommonData) As Boolean
            With m_objdacEstateCommon
                getDataSet_YingshouYingfuMoban = .getDataSet_YingshouYingfuMoban(strErrMsg, strUserId, strPassword, strWhere, objestateCommonData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_Ӧ��Ӧ��ģ�桱������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_YingshouYingfuMoban( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateCommon
                doSaveData_YingshouYingfuMoban = .doSaveData_YingshouYingfuMoban(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_Ӧ��Ӧ��ģ�桱������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_YingshouYingfuMoban( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateCommon
                doDeleteData_YingshouYingfuMoban = .doDeleteData_YingshouYingfuMoban(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_���򻮷֡���SQL���(�ԡ�������롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_QuyuHuafen() As String
            With m_objdacEstateCommon
                getTableSQL_QuyuHuafen = .getTableSQL_QuyuHuafen()
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�������롱��ȡ���������ơ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strQydm                   ���������
        '     strQymc                   ����������(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getQymc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQydm As String, _
            ByRef strQymc As String) As Boolean
            With m_objdacEstateCommon
                getQymc = .getQymc(strErrMsg, strUserId, strPassword, strQydm, strQymc)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ��������ơ���ȡ��������롱
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strQymc                   ����������
        '     strQydm                   ���������(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getQydm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQymc As String, _
            ByRef strQydm As String) As Boolean
            With m_objdacEstateCommon
                getQydm = .getQydm(strErrMsg, strUserId, strPassword, strQymc, strQydm)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_���򻮷֡���ȫ���ݵ����ݼ�(�ԡ�������롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateCommonData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_QuyuHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCommonData As Josco.JSOA.Common.Data.estateCommonData) As Boolean
            With m_objdacEstateCommon
                getDataSet_QuyuHuafen = .getDataSet_QuyuHuafen(strErrMsg, strUserId, strPassword, strWhere, objestateCommonData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_���򻮷֡�������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_QuyuHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateCommon
                doSaveData_QuyuHuafen = .doSaveData_QuyuHuafen(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_���򻮷֡�������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_QuyuHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateCommon
                doDeleteData_QuyuHuafen = .doDeleteData_QuyuHuafen(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function









        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_�참��Ŀ����SQL���(�ԡ���Ŀ���롱��������)
        ' ����
        '                          ��SQL
        ' ��������
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function getTableSQL_BAXM() As String
            With m_objdacEstateCommon
                getTableSQL_BAXM = .getTableSQL_BAXM()
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ���Ŀ���롱��ȡ����Ŀ���ơ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strXmdm                   ����Ŀ����
        '     strXmmc                   ����Ŀ����(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function getBaxm_Xmmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strXmdm As String, _
            ByRef strXmmc As String) As Boolean
            With m_objdacEstateCommon
                getBaxm_Xmmc = .getBaxm_Xmmc(strErrMsg, strUserId, strPassword, strXmdm, strXmmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ���Ŀ���ơ���ȡ����Ŀ���롱
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strXmmc                   ����Ŀ����
        '     strXmdm                   ����Ŀ����(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function getBaxm_Xmdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strXmmc As String, _
            ByRef strXmdm As String) As Boolean
            With m_objdacEstateCommon
                getBaxm_Xmdm = .getBaxm_Xmdm(strErrMsg, strUserId, strPassword, strXmmc, strXmdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_�참��Ŀ����ȫ���ݵ����ݼ�(�ԡ���Ŀ���롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateCommonData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BAXM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCommonData As Josco.JSOA.Common.Data.estateCommonData) As Boolean
            With m_objdacEstateCommon
                getDataSet_BAXM = .getDataSet_BAXM(strErrMsg, strUserId, strPassword, strWhere, objestateCommonData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_�참��Ŀ��������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function doSaveData_BAXM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateCommon
                doSaveData_BAXM = .doSaveData_BAXM(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_�참��Ŀ��������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function doDeleteData_BAXM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateCommon
                doDeleteData_BAXM = .doDeleteData_BAXM(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_��ҵ���ʡ�ѡ���б����ݼ�
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateCommonData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ����
        '     zengxianglin 2010-12-25 ����
        '----------------------------------------------------------------
        Public Function getDataSet_WuyeXingzhi_List( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateCommonData) As Boolean
            With m_objdacEstateCommon
                getDataSet_WuyeXingzhi_List = .getDataSet_WuyeXingzhi_List(strErrMsg, strUserId, strPassword, strWhere, objDataSet)
            End With
        End Function

    End Class 'rulesEstateCommon

End Namespace 'Josco.JsKernal.BusinessRules
