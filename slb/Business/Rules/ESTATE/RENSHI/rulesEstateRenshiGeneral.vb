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
    ' ����    ��rulesEstateRenshiGeneral
    '
    ' ���������� 
    '   ���ṩ��ͨ�����¹������ҵ�����
    '----------------------------------------------------------------
    Public Class rulesEstateRenshiGeneral
        Implements System.IDisposable

        Private m_objdacEstateRenshiGeneral As Josco.JSOA.DataAccess.dacEstateRenshiGeneral

        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
            m_objdacEstateRenshiGeneral = New Josco.JSOA.DataAccess.dacEstateRenshiGeneral
        End Sub

        '----------------------------------------------------------------
        ' ��ȫ�ͷű�����Դ
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessRules.rulesEstateRenshiGeneral)
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
            If Not (m_objdacEstateRenshiGeneral Is Nothing) Then
                m_objdacEstateRenshiGeneral.Dispose()
                m_objdacEstateRenshiGeneral = Nothing
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
            With Me.m_objdacEstateRenshiGeneral
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
            With Me.m_objdacEstateRenshiGeneral
                doExportToExcel = .doExportToExcel(strErrMsg, objDataSet, strExcelFile, strColorFieldName, objColors, strMacroName, strMacroValue, strDateFormat)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��strSrcFile�е�strSrcSheet���Ƶ�strDesFile�е�strDesSheet
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strSrcFile             ��Դ�ļ�������·��
        '     strSrcSheet            ��Դ�ļ���sheet��
        '     strDesFile             ��Ŀ���ļ�������·��
        '     strDesSheet            ��Ŀ���ļ���sheet��
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        ' ��������
        '     zengxianglin 2009-05-18 ����
        '----------------------------------------------------------------
        Public Function doExcelAddCopy( _
            ByRef strErrMsg As String, _
            ByVal strSrcFile As String, _
            ByVal strSrcSheet As String, _
            ByVal strDesFile As String, _
            ByVal strDesSheet As String) As Boolean
            With Me.m_objdacEstateRenshiGeneral
                doExcelAddCopy = .doExcelAddCopy(strErrMsg, strSrcFile, strSrcSheet, strDesFile, strDesSheet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ��strSrcFile�е�strSrcSheet
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strSrcFile             ��Դ�ļ�������·��
        '     strSrcSheet            ��Դ�ļ���sheet��
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        ' ��������
        '     zengxianglin 2009-05-18 ����
        '----------------------------------------------------------------
        Public Function doExcelSheetDelete( _
            ByRef strErrMsg As String, _
            ByVal strSrcFile As String, _
            ByVal strSrcSheet As String) As Boolean
            With Me.m_objdacEstateRenshiGeneral
                doExcelSheetDelete = .doExcelSheetDelete(strErrMsg, strSrcFile, strSrcSheet)
            End With
        End Function












        '----------------------------------------------------------------
        ' ��ȡ������_B_����ְ�ơ���SQL���(�ԡ�ְ�ƴ��롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_JishuZhicheng() As String
            With m_objdacEstateRenshiGeneral
                getTableSQL_JishuZhicheng = .getTableSQL_JishuZhicheng()
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ְ�ƴ��롱��ȡ��ְ�����ơ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strZcdm                   ��ְ�ƴ���
        '     strZcmc                   ��ְ������(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getZcmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZcdm As String, _
            ByRef strZcmc As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getZcmc = .getZcmc(strErrMsg, strUserId, strPassword, strZcdm, strZcmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ְ�����ơ���ȡ��ְ�ƴ��롱
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strZcmc                   ��ְ������
        '     strZcdm                   ��ְ�ƴ���(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getZcdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZcmc As String, _
            ByRef strZcdm As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getZcdm = .getZcdm(strErrMsg, strUserId, strPassword, strZcmc, strZcdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ������_B_����ְ�ơ���ȫ���ݵ����ݼ�(�ԡ�ְ�ƴ��롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateRenshiGeneralData ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_JishuZhicheng( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_JishuZhicheng = .getDataSet_JishuZhicheng(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_����ְ�ơ�������
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
        Public Function doSaveData_JishuZhicheng( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_JishuZhicheng = .doSaveData_JishuZhicheng(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ��������_B_����ְ�ơ�������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_JishuZhicheng( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_JishuZhicheng = .doDeleteData_JishuZhicheng(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function











        '----------------------------------------------------------------
        ' ��ȡ������_B_ѧ�����֡���SQL���(�ԡ�ѧ�����롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_XueliHuafen() As String
            With m_objdacEstateRenshiGeneral
                getTableSQL_XueliHuafen = .getTableSQL_XueliHuafen()
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ѧ�����롱��ȡ��ѧ�����ơ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strXldm                   ��ѧ������
        '     strXlmc                   ��ѧ������(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getXlmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strXldm As String, _
            ByRef strXlmc As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getXlmc = .getXlmc(strErrMsg, strUserId, strPassword, strXldm, strXlmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ѧ�����ơ���ȡ��ѧ�����롱
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strXlmc                   ��ѧ������
        '     strXldm                   ��ѧ������(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getXldm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strXlmc As String, _
            ByRef strXldm As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getXldm = .getXldm(strErrMsg, strUserId, strPassword, strXlmc, strXldm)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ������_B_ѧ�����֡���ȫ���ݵ����ݼ�(�ԡ�ѧ�����롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateRenshiGeneralData ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_XueliHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_XueliHuafen = .getDataSet_XueliHuafen(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_ѧ�����֡�������
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
        Public Function doSaveData_XueliHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_XueliHuafen = .doSaveData_XueliHuafen(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ��������_B_ѧ�����֡�������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_XueliHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_XueliHuafen = .doDeleteData_XueliHuafen(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' ��ȡ������_B_ѧλ���֡���SQL���(�ԡ�ѧλ���롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_XueweiHuafen() As String
            With m_objdacEstateRenshiGeneral
                getTableSQL_XueweiHuafen = .getTableSQL_XueweiHuafen()
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ѧλ���롱��ȡ��ѧλ���ơ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strXwdm                   ��ѧλ����
        '     strXwmc                   ��ѧλ����(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getXwmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strXwdm As String, _
            ByRef strXwmc As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getXwmc = .getXwmc(strErrMsg, strUserId, strPassword, strXwdm, strXwmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ѧλ���ơ���ȡ��ѧλ���롱
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strXwmc                   ��ѧλ����
        '     strXwdm                   ��ѧλ����(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getXwdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strXwmc As String, _
            ByRef strXwdm As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getXwdm = .getXwdm(strErrMsg, strUserId, strPassword, strXwmc, strXwdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ������_B_ѧλ���֡���ȫ���ݵ����ݼ�(�ԡ�ѧλ���롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateRenshiGeneralData ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_XueweiHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_XueweiHuafen = .getDataSet_XueweiHuafen(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_ѧλ���֡�������
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
        Public Function doSaveData_XueweiHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_XueweiHuafen = .doSaveData_XueweiHuafen(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ��������_B_ѧλ���֡�������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_XueweiHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_XueweiHuafen = .doDeleteData_XueweiHuafen(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function











        '----------------------------------------------------------------
        ' ��ȡ������_B_������ò����SQL���(�ԡ���ò���롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ZhengzhiMianmao() As String
            With m_objdacEstateRenshiGeneral
                getTableSQL_ZhengzhiMianmao = .getTableSQL_ZhengzhiMianmao()
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ���ò���롱��ȡ����ò���ơ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strMmdm                   ����ò����
        '     strMmmc                   ����ò����(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getMmmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strMmdm As String, _
            ByRef strMmmc As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getMmmc = .getMmmc(strErrMsg, strUserId, strPassword, strMmdm, strMmmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ���ò���ơ���ȡ����ò���롱
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strMmmc                   ����ò����
        '     strMmdm                   ����ò����(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getMmdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strMmmc As String, _
            ByRef strMmdm As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getMmdm = .getMmdm(strErrMsg, strUserId, strPassword, strMmmc, strMmdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ������_B_������ò����ȫ���ݵ����ݼ�(�ԡ���ò���롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateRenshiGeneralData ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ZhengzhiMianmao( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_ZhengzhiMianmao = .getDataSet_ZhengzhiMianmao(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_������ò��������
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
        Public Function doSaveData_ZhengzhiMianmao( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_ZhengzhiMianmao = .doSaveData_ZhengzhiMianmao(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ��������_B_������ò��������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_ZhengzhiMianmao( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_ZhengzhiMianmao = .doDeleteData_ZhengzhiMianmao(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' ��ȡ������_B_ִҵ�ʸ񡱵�SQL���(�ԡ��ʸ���롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ZhiyeZige() As String
            With m_objdacEstateRenshiGeneral
                getTableSQL_ZhiyeZige = .getTableSQL_ZhiyeZige()
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ��ʸ���롱��ȡ���ʸ����ơ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strZgdm                   ���ʸ����
        '     strZgmc                   ���ʸ�����(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getZgmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZgdm As String, _
            ByRef strZgmc As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getZgmc = .getZgmc(strErrMsg, strUserId, strPassword, strZgdm, strZgmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ��ʸ����ơ���ȡ���ʸ���롱
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strZgmc                   ���ʸ�����
        '     strZgdm                   ���ʸ����(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getZgdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZgmc As String, _
            ByRef strZgdm As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getZgdm = .getZgdm(strErrMsg, strUserId, strPassword, strZgmc, strZgdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ������_B_ִҵ�ʸ���ȫ���ݵ����ݼ�(�ԡ��ʸ���롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateRenshiGeneralData ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ZhiyeZige( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_ZhiyeZige = .getDataSet_ZhiyeZige(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_ִҵ�ʸ񡱵�����
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
        Public Function doSaveData_ZhiyeZige( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_ZhiyeZige = .doSaveData_ZhiyeZige(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ��������_B_ִҵ�ʸ񡱵�����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_ZhiyeZige( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_ZhiyeZige = .doDeleteData_ZhiyeZige(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' ��ȡ������_B_�䶯ԭ�򡱵�SQL���(�ԡ�ԭ����롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_BiandongYuanyin() As String
            With m_objdacEstateRenshiGeneral
                getTableSQL_BiandongYuanyin = .getTableSQL_BiandongYuanyin()
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ԭ����롱��ȡ��ԭ�����ơ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strYydm                   ��ԭ�����
        '     strYymc                   ��ԭ������(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getYymc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strYydm As String, _
            ByRef strYymc As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getYymc = .getYymc(strErrMsg, strUserId, strPassword, strYydm, strYymc)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ԭ�����ơ���ȡ��ԭ����롱
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strYymc                   ��ԭ������
        '     strYydm                   ��ԭ�����(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getYydm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strYymc As String, _
            ByRef strYydm As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getYydm = .getYydm(strErrMsg, strUserId, strPassword, strYymc, strYydm)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ������_B_�䶯ԭ����ȫ���ݵ����ݼ�(�ԡ�ԭ����롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateRenshiGeneralData ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_BiandongYuanyin( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_BiandongYuanyin = .getDataSet_BiandongYuanyin(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_�䶯ԭ�򡱵�����
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
        Public Function doSaveData_BiandongYuanyin( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_BiandongYuanyin = .doSaveData_BiandongYuanyin(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ��������_B_�䶯ԭ�򡱵�����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_BiandongYuanyin( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_BiandongYuanyin = .doDeleteData_BiandongYuanyin(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' ��ȡ������_B_ְ�����ԡ���SQL���(�ԡ����Դ��롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ZhigongShuxing() As String
            With m_objdacEstateRenshiGeneral
                getTableSQL_ZhigongShuxing = .getTableSQL_ZhigongShuxing()
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ����Դ��롱��ȡ���������ơ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strSxdm                   �����Դ���
        '     strSxmc                   ����������(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getSxmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strSxdm As String, _
            ByRef strSxmc As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getSxmc = .getSxmc(strErrMsg, strUserId, strPassword, strSxdm, strSxmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ��������ơ���ȡ�����Դ��롱
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strSxmc                   ����������
        '     strSxdm                   �����Դ���(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getSxdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strSxmc As String, _
            ByRef strSxdm As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getSxdm = .getSxdm(strErrMsg, strUserId, strPassword, strSxmc, strSxdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ������_B_ְ�����ԡ���ȫ���ݵ����ݼ�(�ԡ����Դ��롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateRenshiGeneralData ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ZhigongShuxing( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_ZhigongShuxing = .getDataSet_ZhigongShuxing(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_ְ�����ԡ�������
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
        Public Function doSaveData_ZhigongShuxing( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_ZhigongShuxing = .doSaveData_ZhigongShuxing(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ��������_B_ְ�����ԡ�������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_ZhigongShuxing( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_ZhigongShuxing = .doDeleteData_ZhigongShuxing(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' ��ȡ������_B_���¿�Ƭ����ȫ���ݵ����ݼ�(�ԡ���Ա���롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateRenshiGeneralData ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_RSKP = .getDataSet_RSKP(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ������_B_��ͥ��Ա����ȫ���ݵ����ݼ�(�ԡ�ѪԵ��ϵ����������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strRYDM                    ����Ա����
        '     strWhere                   �������ַ���
        '     objestateRenshiGeneralData ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP_JTCY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_RSKP_JTCY = .getDataSet_RSKP_JTCY(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ������_B_ѧϰ��������ȫ���ݵ����ݼ�(�ԡ���ʼ���¡���������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strRYDM                    ����Ա����
        '     strWhere                   �������ַ���
        '     objestateRenshiGeneralData ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP_XXJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_RSKP_XXJL = .getDataSet_RSKP_XXJL(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ������_B_������������ȫ���ݵ����ݼ�(�ԡ���ʼ���¡���������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strRYDM                    ����Ա����
        '     strWhere                   �������ַ���
        '     objestateRenshiGeneralData ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP_GZJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_RSKP_GZJL = .getDataSet_RSKP_GZJL(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_���¿�Ƭ�����ݼ�¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        '     objOldData             ����¼��ֵ
        '     objenumEditType        ���༭����
        '     strUploadFile          �������ļ���WEB������ȫ·��
        '     strAppRoot             ��Ӧ�ø�Http·��(����/)
        '     strBasePath            ����Ӧ�ø�����ŵص����HTTPĿ¼(��ͷ����/)
        '     objServer              ������������
        '     objDataSet_JTCY        ����ͥ��Ա���ݼ�
        '     objDataSet_XXJL        ��ѧϰ�������ݼ�
        '     objDataSet_GZJL        �������������ݼ�
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_RSKP( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal strUploadFile As String, _
            ByVal strAppRoot As String, _
            ByVal strBasePath As String, _
            ByVal objServer As System.Web.HttpServerUtility, _
            ByVal objDataSet_JTCY As Josco.JSOA.Common.Data.estateRenshiGeneralData, _
            ByVal objDataSet_XXJL As Josco.JSOA.Common.Data.estateRenshiGeneralData, _
            ByVal objDataSet_GZJL As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_RSKP = .doSaveData_RSKP(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, strUploadFile, strAppRoot, strBasePath, objServer, objDataSet_JTCY, objDataSet_XXJL, objDataSet_GZJL)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ������_B_��ѵ��¼����ȫ���ݵ����ݼ�(�ԡ���ʼʱ�䡱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strRYDM                    ����Ա����
        '     strWhere                   �������ַ���
        '     objestateRenshiGeneralData ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP_PXJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_RSKP_PXJL = .getDataSet_RSKP_PXJL(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ������_B_�����춯����ȫ���ݵ����ݼ�(�ԡ���ʼʱ�䡱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strRYDM                    ����Ա����
        '     strWhere                   �������ַ���
        '     objestateRenshiGeneralData ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP_YDJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_RSKP_YDJL = .getDataSet_RSKP_YDJL(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ������_B_�Ͷ���ͬ����ȫ���ݵ����ݼ�(�ԡ���ʼʱ�䡱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strRYDM                    ����Ա����
        '     strWhere                   �������ַ���
        '     objestateRenshiGeneralData ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP_LDHT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_RSKP_LDHT = .getDataSet_RSKP_LDHT(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_��ѵ��¼��������
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
        Public Function doSaveData_RSKP_PXJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_RSKP_PXJL = .doSaveData_RSKP_PXJL(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ��������_B_��ѵ��¼��������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_RSKP_PXJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_RSKP_PXJL = .doDeleteData_RSKP_PXJL(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_�����춯��������
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
        Public Function doSaveData_RSKP_YDJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_RSKP_YDJL = .doSaveData_RSKP_YDJL(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ��������_B_�����춯��������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_RSKP_YDJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_RSKP_YDJL = .doDeleteData_RSKP_YDJL(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_�Ͷ���ͬ�����ݼ�¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        '     objOldData             ����¼��ֵ
        '     objenumEditType        ���༭����
        '     strUploadFile          �������ļ���Web������ȫ·��
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_RSKP_LDHT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal strUploadFile As String) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_RSKP_LDHT = .doSaveData_RSKP_LDHT(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, strUploadFile)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ��������_B_�Ͷ���ͬ����¼
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strWYBS              ��Ҫɾ����Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_RSKP_LDHT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_RSKP_LDHT = .doDeleteData_RSKP_LDHT(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ��������_B_���¿�Ƭ����¼����ؼ�¼
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strWYBS              ��Ҫɾ����Ψһ��ʶ
        '     objServer            ��System.Web.HttpServerUtility
        '     strHttpPathPrefix    ��HttpĿ¼ǰ׺����(ĩβ=/)
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_RSKP( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal objServer As System.Web.HttpServerUtility, _
            ByVal strHttpPathPrefix As String) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_RSKP = .doDeleteData_RSKP(strErrMsg, strUserId, strPassword, strWYBS, objServer, strHttpPathPrefix)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ��ز�_B_����_��������������������_B_���¿�Ƭ����Ϣ
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     strGRLLRYDM            �����ز�_B_����_�����������еġ���Ա���롱
        '     strUploadFile          �������ļ���WEB������ȫ·��
        '     strAppRoot             ��Ӧ�ø�Http·��(����/)
        '     strBasePath            ����Ӧ�ø�����ŵص����HTTPĿ¼(��ͷ����/)
        '     objServer              ������������
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doCopyFromGRLLToRSKP( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strGRLLRYDM As String, _
            ByVal strUploadFile As String, _
            ByVal strAppRoot As String, _
            ByVal strBasePath As String, _
            ByVal objServer As System.Web.HttpServerUtility) As Boolean
            With m_objdacEstateRenshiGeneral
                doCopyFromGRLLToRSKP = .doCopyFromGRLLToRSKP(strErrMsg, strUserId, strPassword, strGRLLRYDM, strUploadFile, strAppRoot, strBasePath, objServer)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[������ҵ_���¹���_������Դ״�������]������
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     strJZRQ                ��ͳ�ƽ�ֹ����
        '     strExcelFile           ��������WEB�������е�Excel�ļ�·��
        '     strMacroName           �������б�
        '     strMacroValue          ����ֵ�б�
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        ' ��������
        '     zengxianglin 2009-01-07 ����
        '----------------------------------------------------------------
        Public Function doPrint_RSBB_RLZYZKDCB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJZRQ As String, _
            ByVal strExcelFile As String, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "") As Boolean
            With m_objdacEstateRenshiGeneral
                doPrint_RSBB_RLZYZKDCB = .doPrint_RSBB_RLZYZKDCB(strErrMsg, strUserId, strPassword, strJZRQ, strExcelFile, strMacroName, strMacroValue)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[��Ա�����춯��]����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     objDataSet                 ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2009-01-07 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_RYZJYDB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_BB_RYZJYDB = .getDataSet_BB_RYZJYDB(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ӡ[������ҵ_���¹���_��Ա�����춯��]������
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     objDataSet             ��Ҫ��ӡ������
        '     strExcelFile           ��������WEB�������е�Excel�ļ�·��
        '     strMacroName           �������б�
        '     strMacroValue          ����ֵ�б�
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        ' ��������
        '     zengxianglin 2009-01-07 ����
        '----------------------------------------------------------------
        Public Function doPrint_RSBB_RYZJYDB( _
            ByRef strErrMsg As String, _
            ByVal objDataSet As System.Data.DataSet, _
            ByVal strExcelFile As String, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "") As Boolean
            With m_objdacEstateRenshiGeneral
                doPrint_RSBB_RYZJYDB = .doPrint_RSBB_RYZJYDB(strErrMsg, objDataSet, strExcelFile, strMacroName, strMacroValue)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[������Դ��Ϣ���ܱ�]����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     strYJZR                    ���½�ֹ��
        '     objDataSet                 ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2009-01-08 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_RLZYXXHZB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strYJZR As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_BB_RLZYXXHZB = .getDataSet_BB_RLZYXXHZB(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strYJZR, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[������ҵ_���¹���_Խ�㼯���ڸ���Ա����������ͳ�Ʊ�]������
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     strJZRQ                ��ͳ�ƽ�ֹ����
        '     strExcelFile           ��������WEB�������е�Excel�ļ�·��
        '     strMacroName           �������б�
        '     strMacroValue          ����ֵ�б�
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        ' ��������
        '     zengxianglin 2009-01-09 ����
        '----------------------------------------------------------------
        Public Function doPrint_RSBB_YXJTZGRYJQTSJTJB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJZRQ As String, _
            ByVal strExcelFile As String, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "") As Boolean
            With m_objdacEstateRenshiGeneral
                doPrint_RSBB_YXJTZGRYJQTSJTJB = .doPrint_RSBB_YXJTZGRYJQTSJTJB(strErrMsg, strUserId, strPassword, strJZRQ, strExcelFile, strMacroName, strMacroValue)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[�Ͷ���ͬ�������ޱ�]����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     objDataSet                 ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2009-01-12 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_LDHTJMQXB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_BB_LDHTJMQXB = .getDataSet_BB_LDHTJMQXB(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[�Ͷ��ּ�����]����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strTJND                    ��ͳ�����
        '     strTJJD                    ��ͳ�Ƽ���
        '     objDataSet                 ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2009-01-12 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_LDJJBB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strTJND As String, _
            ByVal strTJJD As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_BB_LDJJBB = .getDataSet_BB_LDJJBB(strErrMsg, strUserId, strPassword, strTJND, strTJJD, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[�Ͷ����걨��]����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strTJND                    ��ͳ�����
        '     objDataSet                 ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2009-01-12 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_LDJNBB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strTJND As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_BB_LDJNBB = .getDataSet_BB_LDJNBB(strErrMsg, strUserId, strPassword, strTJND, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ¼��[�ز�_B_����_��������]ָ��[�������]��Ӧ����Ա
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     strJLBH                ��[�ز�_B_����_��������][�������]
        '     objServer              ������������
        '     strAppRoot             ��Ӧ�ø�WEB·��(����/)
        '     strBasePath            ��Ӧ�ø�����ŵص����HTTPĿ¼(��ͷ����/)
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2009-05-15 ����
        '----------------------------------------------------------------
        Public Function doLuyong( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJLBH As String, _
            ByVal objServer As System.Web.HttpServerUtility, _
            ByVal strAppRoot As String, _
            ByVal strBasePath As String) As Boolean
            With m_objdacEstateRenshiGeneral
                doLuyong = .doLuyong(strErrMsg, strUserId, strPassword, strJLBH, objServer, strAppRoot, strBasePath)
            End With
        End Function

    End Class 'rulesEstateRenshiGeneral

End Namespace 'Josco.JsKernal.BusinessRules
