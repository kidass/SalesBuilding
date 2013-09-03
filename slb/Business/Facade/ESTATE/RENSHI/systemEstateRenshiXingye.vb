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
Imports Josco.JSOA.BusinessRules

Namespace Josco.JSOA.BusinessFacade
    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.BusinessFacade
    ' ����    ��systemEstateRenshiXingye
    '
    ' ���������� 
    '   ���ṩ����ҵ��˾��������¹�����ı��ֲ�֧��
    '----------------------------------------------------------------
    Public Class systemEstateRenshiXingye
        Implements System.IDisposable

        Private m_objrulesEstateRenshiXingye As Josco.JSOA.BusinessRules.rulesEstateRenshiXingye

        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
            m_objrulesEstateRenshiXingye = New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
        End Sub

        '----------------------------------------------------------------
        ' ��ȫ�ͷű�����Դ
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.systemEstateRenshiXingye)
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
            If Not (m_objrulesEstateRenshiXingye Is Nothing) Then
                m_objrulesEstateRenshiXingye.Dispose()
                m_objrulesEstateRenshiXingye = Nothing
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
            With Me.m_objrulesEstateRenshiXingye
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
            With Me.m_objrulesEstateRenshiXingye
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
            With m_objrulesEstateRenshiXingye
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
            With Me.m_objrulesEstateRenshiXingye
                doExcelSheetDelete = .doExcelSheetDelete(strErrMsg, strSrcFile, strSrcSheet)
            End With
        End Function












        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_ְ�����塱��SQL���(�ԡ�ְ�����롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ZhijiDingyi() As String
            With m_objrulesEstateRenshiXingye
                getTableSQL_ZhijiDingyi = .getTableSQL_ZhijiDingyi()
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_ְ�����塱��ȫ���ݵ����ݼ�(�ԡ�ְ�����롱��������)
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  �������ַ���
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ZhijiDingyi( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_ZhijiDingyi = .getDataSet_ZhijiDingyi(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ְ�����롱��ȡ��ְ�����ơ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strZjdm                   ��ְ������
        '     strZjmc                   ��ְ������(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getZjmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZjdm As String, _
            ByRef strZjmc As String) As Boolean
            With m_objrulesEstateRenshiXingye
                getZjmc = .getZjmc(strErrMsg, strUserId, strPassword, strZjdm, strZjmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_ְ�����塱������
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
        Public Function doSaveData_ZhijiDingyi( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_ZhijiDingyi = .doSaveData_ZhijiDingyi(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_ְ�����塱������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_ZhijiDingyi( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objrulesEstateRenshiXingye
                doDeleteData_ZhijiDingyi = .doDeleteData_ZhijiDingyi(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function













        '----------------------------------------------------------------
        ' ����Ӷ������׼-��Ӷ����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_GY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_GY = .getDataSet_Yjjtbz_GY(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼-˽Ӷ����-�����ְ���б�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_SYZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_SYZJ = .getDataSet_Yjjtbz_SYZJ(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼-˽Ӷ����-����ĸ�ְ��ָ�궨����ͬ��ָ���б�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_SYZB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_SYZB = .getDataSet_Yjjtbz_SYZB(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objDataSet_GY             ����Ӷָ�����ݼ�
        '     objDataSet_SYZJ           ��˽Ӷָ�����ݼ�-ְ������
        '     objDataSet_SYZB           ��˽Ӷָ�����ݼ�-ָ�겿��
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_YongjinJitiBiaozhun( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GY As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_SYZJ As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_SYZB As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YongjinJitiBiaozhun = .doSaveData_YongjinJitiBiaozhun(strErrMsg, strUserId, strPassword, objDataSet_GY, objDataSet_SYZJ, objDataSet_SYZB)
            End With
        End Function












        '----------------------------------------------------------------
        ' ���㿼��ָ�궨���������������
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_Khbz_XL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Khbz_XL = .getDataSet_Khbz_XL(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���㶨����ָ�����˱�׼�����µĵ�λ����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     intZbxl                   ��ָ������(1,2,3����ֵ)
        '     intDwbz                   ��ָ����λ��־(1-����,3-����)
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_Khbz_DW( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intZbxl As Integer, _
            ByVal intDwbz As Integer, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Khbz_DW = .getDataSet_Khbz_DW(strErrMsg, strUserId, strPassword, intZbxl, intDwbz, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ҵ�����˱�׼����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objDataSet_XL             ���������ݼ�
        '     objDataSet_DWFH01         ��ָ��һ����ķ���
        '     objDataSet_DWFH02         ��ָ�������ķ���
        '     objDataSet_DWFH03         ��ָ��������ķ���
        '     objDataSet_DWGLC01        ��ָ��һ����Ĺ���
        '     objDataSet_DWGLC02        ��ָ�������Ĺ���
        '     objDataSet_DWGLC03        ��ָ��������Ĺ���
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_KaoheBiaozhun( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_XL As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_DWFH01 As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_DWFH02 As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_DWFH03 As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_DWGLC01 As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_DWGLC02 As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_DWGLC03 As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_KaoheBiaozhun = .doSaveData_KaoheBiaozhun(strErrMsg, strUserId, strPassword, objDataSet_XL, objDataSet_DWFH01, objDataSet_DWFH02, objDataSet_DWFH03, objDataSet_DWGLC01, objDataSet_DWGLC02, objDataSet_DWGLC03)
            End With
        End Function










        '----------------------------------------------------------------
        ' ����ָ��ʱ������Ա�ܹ��ĵ�λ����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objTime                   ��ʱ���
        '     strWhere                  ����������
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG_DW( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objTime As System.DateTime, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG_DW = .getDataSet_RYJG_DW(strErrMsg, strUserId, strPassword, objTime, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ��ʱ����ָ����λ����Ա�ܹ���������Ա����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objTime                   ��ʱ���
        '     strZZDM                   ����֯����
        '     strWhere                  ����������
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG_RY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objTime As System.DateTime, _
            ByVal strZZDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG_RY = .getDataSet_RYJG_RY(strErrMsg, strUserId, strPassword, objTime, strZZDM, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ��ʱ����ָ��ְ���б����Ա�ܹ��������Ա��Ŀ
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objTime                   ��ʱ���
        '     strZJLIST                 ��ְ���б�(��׼SQL�б��ʽ)
        '     intMaxCount               �������Ŀ
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getRYJG_MaxRYSM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objTime As System.DateTime, _
            ByVal strZJLIST As String, _
            ByRef intMaxCount As Integer) As Boolean
            With m_objrulesEstateRenshiXingye
                getRYJG_MaxRYSM = .getRYJG_MaxRYSM(strErrMsg, strUserId, strPassword, objTime, strZJLIST, intMaxCount)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡû���ڼܹ��ж������Ա�б�
        ' ��������Ա����ģʽһ
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG_RY_NotIn( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG_RY_NotIn = .getDataSet_RYJG_RY_NotIn(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ��ָ��ʱ��Ĺ���ܹ����ݼ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objTime                   ��ָ��ʱ��
        '     strWhere                  ����������
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_GuanliJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objTime As System.DateTime, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_GuanliJiagou = .getDataSet_GuanliJiagou(strErrMsg, strUserId, strPassword, objTime, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ��ָ��ʱ�������ܹ����ݼ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objTime                   ��ָ��ʱ��
        '     strWhere                  ����������
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ZhuliJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objTime As System.DateTime, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_ZhuliJiagou = .getDataSet_ZhuliJiagou(strErrMsg, strUserId, strPassword, objTime, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ�ڼܹ����ж������Ա�б�(��������ܹ�������ܹ�)
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG_RY_In( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG_RY_In = .getDataSet_RYJG_RY_In(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ�ڼܹ����ж������Ա�б�(��������ܹ�������ܹ�)
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG_RY_In( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal blnOption As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG_RY_In = .getDataSet_RYJG_RY_In(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiXingyeData, blnOption)
            End With
        End Function











        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_������������ȫ���ݵ����ݼ�(�ԡ���Ա���롱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateRenshiXingyeData  ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_GRLL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_GRLL = .getDataSet_GRLL(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_ѧϰ��������ȫ���ݵ����ݼ�(�ԡ���ʼ���¡���������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strRYDM                    ����Ա����
        '     strWhere                   �������ַ���
        '     objestateRenshiXingyeData  ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_GRLL_XXJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_GRLL_XXJL = .getDataSet_GRLL_XXJL(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_������������ȫ���ݵ����ݼ�(�ԡ���ʼ���¡���������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strRYDM                    ����Ա����
        '     strWhere                   �������ַ���
        '     objestateRenshiXingyeData  ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_GRLL_GZJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_GRLL_GZJL = .getDataSet_GRLL_GZJL(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_�������������ݼ�¼(�����������)
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
        '     objDataSet_XXJL        ��ѧϰ�������ݼ�
        '     objDataSet_GZJL        �������������ݼ�
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_GRLL( _
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
            ByVal objDataSet_XXJL As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_GZJL As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_GRLL = .doSaveData_GRLL(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, strUploadFile, strAppRoot, strBasePath, objServer, objDataSet_XXJL, objDataSet_GZJL)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_������������¼����ؼ�¼
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
        Public Function doDeleteData_GRLL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal objServer As System.Web.HttpServerUtility, _
            ByVal strHttpPathPrefix As String) As Boolean
            With m_objrulesEstateRenshiXingye
                doDeleteData_GRLL = .doDeleteData_GRLL(strErrMsg, strUserId, strPassword, strWYBS, objServer, strHttpPathPrefix)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ�����������SQL
        '----------------------------------------------------------------
        Public Function getSearchSQL_JLBH() As String
            With m_objrulesEstateRenshiXingye
                getSearchSQL_JLBH = .getSearchSQL_JLBH()
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ����Ա��ָ��ʱ��������������Ա
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strRYDM              ����Ա����
        '     objJCSJ              ��ʱ���
        '     objXJRY              ��������Ա�Ĵ����б�
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function getAllXiashuRenyuan( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal objJCSJ As System.DateTime, _
            ByRef objXJRY As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateRenshiXingye
                getAllXiashuRenyuan = .getAllXiashuRenyuan(strErrMsg, strUserId, strPassword, strRYDM, objJCSJ, objXJRY)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ����Ա��ָ��ʱ�������е�����������ĵ�λ�б�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strRYDM              ����Ա����
        '     objJCSJ              ��ʱ���
        '     objDWLB              ����λ�б�
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function getAllXingzhengZhuliDanwei( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal objJCSJ As System.DateTime, _
            ByRef objDWLB As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateRenshiXingye
                getAllXingzhengZhuliDanwei = .getAllXingzhengZhuliDanwei(strErrMsg, strUserId, strPassword, strRYDM, objJCSJ, objDWLB)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ����Ա��ָ��ʱ���������ε�ְ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strRYDM              ����Ա����
        '     objJCSJ              ��ʱ���
        '     strZJDM              ��ְ������
        '     strZJMC              ��ְ������
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function getRenyuanZhiji( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal objJCSJ As System.DateTime, _
            ByRef strZJDM As String, _
            ByRef strZJMC As String) As Boolean
            With m_objrulesEstateRenshiXingye
                getRenyuanZhiji = .getRenyuanZhiji(strErrMsg, strUserId, strPassword, strRYDM, objJCSJ, strZJDM, strZJMC)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ָ����Ϣ����Ա�Ӽܹ���ע��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objEnvInfo           ���䶯ͨ�ò�����BDLX,BDSJ,BDYY,BDYYMC��
        '     objMainInfo          �����䶯�˵�ǰ��Ա�ܹ�����
        '     objDataSet_XJ        ����Ӱ���ֱ���������������Ϣ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ���ı�ע
        '     zengxianglin 2008-10-14����
        '----------------------------------------------------------------
        Public Function doDelete_RenyuanJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objEnvInfo As System.Collections.Specialized.NameValueCollection, _
            ByVal objMainInfo As System.Data.DataRow, _
            ByVal objDataSet_XJ As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doDelete_RenyuanJiagou = .doDelete_RenyuanJiagou(strErrMsg, strUserId, strPassword, objEnvInfo, objMainInfo, objDataSet_XJ)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����ְ�����ʱ����Ч��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     intRYLX              ����Ա����(1-ҵ����Ա��0-��������
        '     strRYDM              ����Ա����
        '     strRYMC              ����Ա����
        '     strSSDW              ��������λ����
        '     strBDSJ              ���䶯ʱ��
        '     blnValid             ������True-��Ч False-��Ч
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        ' ���˵��
        '     zengxianglin 2008-10-14 ����
        '----------------------------------------------------------------
        Public Function doValidParamsJG_Add( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intRYLX As Integer, _
            ByVal strRYDM As String, _
            ByVal strRYMC As String, _
            ByVal strSSDW As String, _
            ByVal strBDSJ As String, _
            ByRef blnValid As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                doValidParamsJG_Add = .doValidParamsJG_Add(strErrMsg, strUserId, strPassword, intRYLX, strRYDM, strRYMC, strSSDW, strBDSJ, blnValid)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ָ������Ϣ������Ա�ܹ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objEnvInfo           ���䶯ͨ�ò�����BDSJ,BDYY,BDYYMC��
        '     objOldData           �����䶯�˾�����
        '     objNewData           �����䶯��������
        '     objDataSet_XJ        ��Ҫ�������¼���Ա��Ϣ�б�
        '     objDataSet_TDZH      ���Ŷ���ϻ�������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ����
        '     zengxianglin 2008-10-14 ����
        '     zengxianglin 2010-01-05 ����
        '----------------------------------------------------------------
        Public Function doAdjust_RenyuanJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objEnvInfo As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Data.DataRow, _
            ByVal objDataSet_XJ As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_TDZH As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doAdjust_RenyuanJiagou = .doAdjust_RenyuanJiagou(strErrMsg, strUserId, strPassword, objEnvInfo, objOldData, objNewData, objDataSet_XJ, objDataSet_TDZH)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ��ʱ����ָ��ְ�����м��и����е���Ա�ܹ��������Ա��Ŀ���ݼ�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objTime                   ��ʱ���
        '     strZJLIST                 ��ְ���б�(��׼SQL�б��ʽ)
        '     objRetDataSet             �������Ա��Ŀ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ��������
        '     zengxianglin 2008-10-14 ����
        '----------------------------------------------------------------
        Public Function getRYJG_MaxRYSM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objTime As System.DateTime, _
            ByVal strZJLIST As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getRYJG_MaxRYSM = .getRYJG_MaxRYSM(strErrMsg, strUserId, strPassword, objTime, strZJLIST, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ�ڼܹ����ж������Ա�б�(��������ܹ��е���Ա)
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     blnOnlyGLJG               ���ӿ�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ��������
        '     zengxianglin 2008-10-14 ����
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG_RY_In( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal blnOnlyGLJG As Boolean, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG_RY_In = .getDataSet_RYJG_RY_In(strErrMsg, strUserId, strPassword, blnOnlyGLJG, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ�ڼܹ����ж������Ա�б�(��������ܹ�������ܹ�)
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ��(����)��Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ��������
        '     zengxianglin 2008-10-14 ����
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG = .getDataSet_RYJG(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_����ܹ����򡰵ز�_B_����_����ܹ������ݼ�¼(�����������)
        ' ���ù���ģʽһ����
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     objNewData             ����¼��ֵ(TABLE_DC_V_RS_RENYUANJIAGOU��¼��ʽ)
        '     objOldData             ����¼��ֵ(TABLE_DC_V_RS_RENYUANJIAGOU��¼��ʽ)
        '     objenumEditType        ���༭����
        '     objDataSet_TDZH        ���Ŷ���ϻ�������
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        ' ��������
        '     zengxianglin 2008-10-14 ����
        '     zengxianglin 2010-01-04 ����
        '----------------------------------------------------------------
        Public Function doSaveData_RYJG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Data.DataRow, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal objDataSet_TDZH As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_RYJG = .doSaveData_RYJG(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, objDataSet_TDZH)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_����ܹ����򡰵ز�_B_����_����ܹ�����¼����ؼ�¼
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     objOldData           ����¼��ֵ(TABLE_DC_V_RS_RENYUANJIAGOU��¼��ʽ)
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-10-14 ����
        '----------------------------------------------------------------
        Public Function doDeleteData_RYJG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objrulesEstateRenshiXingye
                doDeleteData_RYJG = .doDeleteData_RYJG(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' ��[��Ա�ܹ�]�е�[������λ]��[��������]ͬ����[����_B_��Ա]
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strJCSJ              �����ʱ��
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function doTongbuRyxx( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJCSJ As String) As Boolean
            With m_objrulesEstateRenshiXingye
                doTongbuRyxx = .doTongbuRyxx(strErrMsg, strUserId, strPassword, strJCSJ)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡָ��ʱ�����Ա�ܹ��������������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strJCSJ                    �����ʱ��
        '     objRetDataSet              �����ݼ�(����)
        '                        table(0)���������
        '                        table(1)����������
        '                        table(2)��ҵ����
        '                        table(3)��Ӫҵ����
        '                        table(4)��������
        '                        table(5)�������ܼ�
        '                        table(6)������ܹ�
        '                        table(7)������ܹ�
        '                        table(8)����λ��Ϣ
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJCSJ As String, _
            ByRef objRetDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG = .getDataSet_RYJG(strErrMsg, strUserId, strPassword, strJCSJ, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡָ����Ա��ָ��ʱ��ɲ����Ĳ���SQL�б�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strRYDM              ����Ա����
        '     strJCSJ              �����ʱ��
        '     strList              �����ز���SQL�б�
        '     blnSFFH              �������Ƿ���¥����Ա
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-22 ����
        '----------------------------------------------------------------
        Public Function getBumenSqlList( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strJCSJ As String, _
            ByRef strList As String, _
            ByRef blnSFFH As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                getBumenSqlList = .getBumenSqlList(strErrMsg, strUserId, strPassword, strRYDM, strJCSJ, strList, blnSFFH)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡָ����Ա��ָ��ʱ�����ڲ����Լ�����Ĳ���SQL�б�
        ' ����������Ƿ��еĵ�λ������ֹ����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strRYDM              ����Ա����
        '     strJCSJ              �����ʱ��
        '     blnSZBM_GLBM         ���ӿ�����
        '     strList              �����ز���SQL�б�
        '     blnSFFH              �������Ƿ���¥����Ա
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-22 ����
        '----------------------------------------------------------------
        Public Function getBumenSqlList( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strJCSJ As String, _
            ByVal blnSZBM_GLBM As Boolean, _
            ByRef strList As String, _
            ByRef blnSFFH As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                getBumenSqlList = .getBumenSqlList(strErrMsg, strUserId, strPassword, strRYDM, strJCSJ, blnSZBM_GLBM, strList, blnSFFH)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ������ָ���ꡢ���ȵ���ʽְ��ҵ����������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strBMDM                    ��ͳ�Ʋ���
        '     intND                      ���������
        '     intJD                      �����˼���
        '     intYJZR                    ���½�ֹ��
        '     strCHCR                    �������ַ���
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-12-08 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_RSRYKH_ZSZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strBMDM As String, _
            ByVal intND As Integer, _
            ByVal intJD As Integer, _
            ByVal intYJZR As Integer, _
            ByVal strCHCR As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_BB_RSRYKH_ZSZG = .getDataSet_BB_RSRYKH_ZSZG(strErrMsg, strUserId, strPassword, strBMDM, intND, intJD, intYJZR, strCHCR, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����ʽְ���Ŀ��˱���
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     strBMDM                �����˵�λ����
        '     intND                  ���������
        '     intJD                  �����˼���
        '     intYJZR                ���½�ֹ��
        '     objDataSet             ��Ҫ���������ݼ�
        '     strExcelFile           ��������WEB�������е�Excel�ļ�·��
        '     strMacroName           �������б�
        '     strMacroValue          ����ֵ�б�
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-09 ����
        '----------------------------------------------------------------
        Public Function doPrint_BB_RSRYKH_ZSZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strBMDM As String, _
            ByVal intND As Integer, _
            ByVal intJD As Integer, _
            ByVal intYJZR As Integer, _
            ByVal objDataSet As System.Data.DataSet, _
            ByVal strExcelFile As String, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "") As Boolean
            With m_objrulesEstateRenshiXingye
                doPrint_BB_RSRYKH_ZSZG = .doPrint_BB_RSRYKH_ZSZG(strErrMsg, strUserId, strPassword, strBMDM, intND, intJD, intYJZR, objDataSet, strExcelFile, strMacroName, strMacroValue)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ����Ա��ָ��ʱ����ڵ�������ְ����������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strRYDM                    ��������Ա
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     intSYQY                    ��������(��)
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-12-08 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_RSRYKH_SYZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal intSYQY As Integer, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_BB_RSRYKH_SYZG = .getDataSet_BB_RSRYKH_SYZG(strErrMsg, strUserId, strPassword, strRYDM, strKSRQ, strZZRQ, intSYQY, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ��ʱ����ڵķ������õ���Ա����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     intSYQY                    ��������(��)
        '     objRetDataSet              ����Ϣ���ݼ�(Table(0))
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-12-08 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_RSRYKH_SYZG_RY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal intSYQY As Integer, _
            ByRef objRetDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_BB_RSRYKH_SYZG_RY = .getDataSet_BB_RSRYKH_SYZG_RY(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, intSYQY, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ�µġ�������š�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strJLBH              ���������
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        ' ���ļ�¼��
        '     zengxianglin 2009-05-14 ����
        '----------------------------------------------------------------
        Public Function getNewJLBH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strJLBH As String) As Boolean
            With m_objrulesEstateRenshiXingye
                getNewJLBH = .getNewJLBH(strErrMsg, strUserId, strPassword, strJLBH)
            End With
        End Function







        '----------------------------------------------------------------
        ' ���ӡ��ز�_B_����_����ܹ�����������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objNewData           ��������
        '     strYDYY              ���䶯ԭ�����
        '     blnSFJZ              ��True-��ְ,False-���Ǽ�ְ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doAddNew_GuanliJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal strYDYY As String, _
            ByVal blnSFJZ As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                doAddNew_GuanliJiagou = .doAddNew_GuanliJiagou(strErrMsg, strUserId, strPassword, objNewData, strYDYY, blnSFJZ)
            End With
        End Function


        '----------------------------------------------------------------
        ' ���ӡ��ز�_B_����_����ܹ�����������
        ' �����ڹ���ģʽһ����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objNewData           ��������
        '     strYDYY              ���䶯ԭ�����
        '     blnSFJZ              ��True-��ְ,False-���Ǽ�ְ
        '     objDataSet_TDZH      ��Ҫ�������Ŷ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ����
        '     zengxianglin 2010-01-04 ����
        '     zengxianglin 2009-12-31 �������
        '----------------------------------------------------------------
        Public Function doAddNew_GuanliJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal strYDYY As String, _
            ByVal blnSFJZ As Boolean, _
            ByVal objDataSet_TDZH As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doAddNew_GuanliJiagou = .doAddNew_GuanliJiagou(strErrMsg, strUserId, strPassword, objNewData, strYDYY, blnSFJZ, objDataSet_TDZH)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ӡ��ز�_B_����_����ܹ�����������
        ' ���������¹���ģʽһ����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objNewData           ��������
        '     strYDYY              ���䶯ԭ�����
        '     blnSFJZ              ��True-��ְ,False-���Ǽ�ְ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ����
        '     zengxianglin 2010-01-04 ����
        '     zengxianglin 2009-12-31 �������
        '----------------------------------------------------------------
        Public Function doAddNew_ZhuliJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal strYDYY As String, _
            ByVal blnSFJZ As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                doAddNew_ZhuliJiagou = .doAddNew_ZhuliJiagou(strErrMsg, strUserId, strPassword, objNewData, strYDYY, blnSFJZ)
            End With
        End Function













        '----------------------------------------------------------------
        ' ����ָ��ʱ��ִ�е���Ա����ģʽ
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strJCSJ                   �����ʱ��
        '     intBZXL                   ����׼����(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2009-12-29 ����
        '----------------------------------------------------------------
        Public Function getBZXL_RSJG( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJCSJ As String, _
            ByRef intBZXL As Integer) As Boolean
            With m_objrulesEstateRenshiXingye
                getBZXL_RSJG = .getBZXL_RSJG(strErrMsg, strUserId, strPassword, strJCSJ, intBZXL)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����strZBBSָ�����Ŷ��������(������ݿ��в�����,��ӻ������ݼ��м���)
        ' ��������Ա����ģʽ��
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strZBBS                   ������ʶ
        '     objBufDataSet             ���������ݼ�
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2009-12-29 ����
        '----------------------------------------------------------------
        Public Function getDataSet_TDZH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZBBS As String, _
            ByVal objBufDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_TDZH = .getDataSet_TDZH(strErrMsg, strUserId, strPassword, strZBBS, objBufDataSet, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ��ʱ����Ч���Ŷ��б�
        ' ��������Ա����ģʽ��
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strJCSJ                   �����ʱ��
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2009-12-29 ����
        '----------------------------------------------------------------
        Public Function getDataSet_TEAM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJCSJ As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_TEAM = .getDataSet_TEAM(strErrMsg, strUserId, strPassword, strJCSJ, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����ְ�����ʱ����Ч��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     intRYLX              ����Ա����(1-ҵ����Ա��0-��������)
        '     strRYDM              ����Ա����
        '     strRYMC              ����Ա����
        '     strSSDW              ��������λ����
        '     strBDSJ              ���䶯ʱ��
        '     blnValid             ������True-��Ч False-��Ч
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        ' ���˵��
        '     zengxianglin 2009-12-31 ����
        '----------------------------------------------------------------
        Public Function doValidParamsJG_Add_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intRYLX As Integer, _
            ByVal strRYDM As String, _
            ByVal strRYMC As String, _
            ByVal strSSDW As String, _
            ByVal strBDSJ As String, _
            ByRef blnValid As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                doValidParamsJG_Add_X2 = .doValidParamsJG_Add_X2(strErrMsg, strUserId, strPassword, intRYLX, strRYDM, strRYMC, strSSDW, strBDSJ, blnValid)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡָ��ʱ�����Ա�ܹ��������������
        ' ���������¹���ģʽ��
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strJCSJ                    �����ʱ��
        '     objRetDataSet              �����ݼ�(����)
        '                        table(0)���������
        '                        table(1)����������
        '                        table(2)��ҵ����
        '                        table(3)��Ӫҵ����Э��
        '                        table(4)��Ӫҵ����ֱ��
        '                        table(5)��������
        '                        table(6)�������ܼ�
        '                        table(7)������ܹ�
        '                        table(8)������ܹ�
        '                        table(9)����λ��Ϣ
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2010-01-01 ����
        '----------------------------------------------------------------
        Public Function getDataSet_RYJG_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJCSJ As String, _
            ByRef objRetDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_RYJG_X2 = .getDataSet_RYJG_X2(strErrMsg, strUserId, strPassword, strJCSJ, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ[�ز�_B_����_���˱�׼_X2_��Ӣ]����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2010-01-13 ����
        '----------------------------------------------------------------
        Public Function getDataSet_X2_KHBZ_JY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_X2_KHBZ_JY = .getDataSet_X2_KHBZ_JY(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ[�ز�_B_����_���˱�׼_X2_����]����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2010-01-13 ����
        '----------------------------------------------------------------
        Public Function getDataSet_X2_KHBZ_GL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_X2_KHBZ_GL = .getDataSet_X2_KHBZ_GL(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �������񱣴�
        '     [�ز�_B_����_���˱�׼_X2_��Ӣ]
        '     [�ز�_B_����_���˱�׼_X2_����]
        ' ����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objDataSet_JY        ��Ҫ�����[�ز�_B_����_���˱�׼_X2_��Ӣ]
        '     objDataSet_GL        ��Ҫ�����[�ز�_B_����_���˱�׼_X2_����]
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ����
        '     zengxianglin 2010-01-13 ����
        '----------------------------------------------------------------
        Public Function doSave_X2_KHBZ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_JY As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal objDataSet_GL As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSave_X2_KHBZ = .doSave_X2_KHBZ(strErrMsg, strUserId, strPassword, objDataSet_JY, objDataSet_GL)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ҵ��Ӣ�ļ��ȿ��˽��
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strJDKS                   �����˼��ȿ�ʼ����
        '     strJDJS                   �����˼��Ƚ�������
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2010-01-13 ����
        '     zengxianglin 2010-05-06 ����(ָ����ȡ����ȡ��½�ֹ�� -> ���ȿ�ʼ���ڡ����Ƚ�������)
        '----------------------------------------------------------------
        Public Function getDataSet_TJBB_X2_KHJG_JY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJDKS As String, _
            ByVal strJDJS As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_TJBB_X2_KHJG_JY = .getDataSet_TJBB_X2_KHJG_JY(strErrMsg, strUserId, strPassword, strJDKS, strJDJS, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ҵ�����ܵļ��ȿ��˽��
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strJDKS                   �����˼��ȿ�ʼ����
        '     strJDJS                   �����˼��Ƚ�������
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2010-01-13 ����
        '     zengxianglin 2010-05-06 ����(ָ����ȡ����ȡ��½�ֹ�� -> ���ȿ�ʼ���ڡ����Ƚ�������)
        '----------------------------------------------------------------
        Public Function getDataSet_TJBB_X2_KHJG_GL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJDKS As String, _
            ByVal strJDJS As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_TJBB_X2_KHJG_GL = .getDataSet_TJBB_X2_KHJG_GL(strErrMsg, strUserId, strPassword, strJDKS, strJDJS, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼-��Ӷֱ�Ჿ��
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     lijie 2010-1-17 ����
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_GYZT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_GYZT = .getDataSet_Yjjtbz_GYZT(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼-��ӶЭ�ܲ���
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     lijie 2010-1-17 ����
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_GYXGZB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_GYXGZB = .getDataSet_Yjjtbz_GYXGZB(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼-��Ӷֱ�ܱ�׼����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     lijie 2010-1-17 ����
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_GYZGZB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal strWhere As String) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_GYZGZB = .getDataSet_Yjjtbz_GYZGZB(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData, strWhere)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼-��Ӷֱ��ְ����׼����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     lijie 2010-1-17 ����
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_GYZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_GYZG = .getDataSet_Yjjtbz_GYZG(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼-˽Ӷ��׼����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objestateRenshiXingyeData ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     lijie 2010-1-17 ����
        '----------------------------------------------------------------
        Public Function getDataSet_Yjjtbz_SY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_Yjjtbz_SY = .getDataSet_Yjjtbz_SY(strErrMsg, strUserId, strPassword, objestateRenshiXingyeData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ز�_B_����_Ӷ���׼_X2_˽Ӷ�����׼����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objDataSet_SYZB           ��˽Ӷָ�����ݼ�-ָ�겿��
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     lijie 2010-1-17 ����
        '----------------------------------------------------------------
        Public Function doSaveData_YongjinJitiBiaozhun_SY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_SYZB As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YongjinJitiBiaozhun_SY = .doSaveData_YongjinJitiBiaozhun_SY(strErrMsg, strUserId, strPassword, objDataSet_SYZB)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ز�_B_����_Ӷ���׼_X2_��Ӷ_ֱ������׼����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objDataSet_GYZT           ��ֱ��ָ�����ݼ�-ָ�겿��
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     lijie 2010-1-17 ����
        '----------------------------------------------------------------
        Public Function doSaveData_YongjinJitiBiaozhun_GYZT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GYZT As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YongjinJitiBiaozhun_GYZT = .doSaveData_YongjinJitiBiaozhun_GYZT(strErrMsg, strUserId, strPassword, objDataSet_GYZT)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ز�_B_����_Ӷ���׼_X2_��Ӷ_Э�ܼ����׼����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objDataSet_GYXGZB         ��Э��ָ�����ݼ�-ָ�겿��
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     lijie 2010-1-17 ����
        '----------------------------------------------------------------
        Public Function doSaveData_YongjinJitiBiaozhun_GYXG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GYXGZB As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YongjinJitiBiaozhun_GYXG = .doSaveData_YongjinJitiBiaozhun_GYXG(strErrMsg, strUserId, strPassword, objDataSet_GYXGZB)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ز�_B_����_Ӷ���׼_X2_��Ӷ_ֱ�ܼ����׼����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objDataSet_GYXGZB         ��ֱ��ָ�����ݼ�-ָ�겿��
        '     strJJDM                   ��ְ������
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     lijie 2010-1-17 ����
        '----------------------------------------------------------------
        Public Function doSaveData_YongjinJitiBiaozhun_GYZGZB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GYZGZB As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal strJJDM As String) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YongjinJitiBiaozhun_GYZGZB = .doSaveData_YongjinJitiBiaozhun_GYZGZB(strErrMsg, strUserId, strPassword, objDataSet_GYZGZB, strJJDM)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ���ز�_B_����_Ӷ���׼_X2_��Ӷ_ֱ�ܼ����׼����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strJJDM                   ��ְ������
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     lijie 2010-1-17 ����
        '----------------------------------------------------------------
        Public Function doDelete_GYZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJJDM As String) As Boolean
            With m_objrulesEstateRenshiXingye
                doDelete_GYZG = .doDelete_GYZG(strErrMsg, strUserId, strPassword, strJJDM)
            End With
        End Function









        '----------------------------------------------------------------
        ' ����Ӷ������׼[X3]-˽Ӷ��׼����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2010-05-04 ����
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X3_SY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X3_SY = .getDataSet_YJBZ_X3_SY(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼[X3]-ֱ�ܹ�Ӷ��׼���ֵ��漰ְ������
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2010-05-04 ����
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X3_GY_ZG_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X3_GY_ZG_ZJ = .getDataSet_YJBZ_X3_GY_ZG_ZJ(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼[X3]-ֱ�ܹ�Ӷ��׼���ֵ��漰ָ������
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2010-05-04 ����
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X3_GY_ZG_ZB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X3_GY_ZG_ZB = .getDataSet_YJBZ_X3_GY_ZG_ZB(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼[X3]-Э�ܹ�Ӷ��׼����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2010-05-04 ����
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X3_GY_XG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X3_GY_XG = .getDataSet_YJBZ_X3_GY_XG(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼[X3]-ֱ�ṫӶ��׼���ֵ��漰ְ������
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2010-05-04 ����
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X3_GY_ZT_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X3_GY_ZT_ZJ = .getDataSet_YJBZ_X3_GY_ZT_ZJ(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼[X3]-ֱ�ṫӶ��׼���ֵ��漰ָ������
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2010-05-04 ����
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X3_GY_ZT_ZB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X3_GY_ZT_ZB = .getDataSet_YJBZ_X3_GY_ZT_ZB(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[�ز�_B_����_Ӷ���׼_X3_˽Ӷ]
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objDataSet_SY             ��˽Ӷָ��
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2010-05-04 ����
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X3_SY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_SY As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X3_SY = .doSaveData_YJBZ_X3_SY(strErrMsg, strUserId, strPassword, objDataSet_SY)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[�ز�_B_����_Ӷ���׼_X3_��Ӷ_ֱ��]
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objDataSet_GY_ZG_ZB       ��ָ������
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2010-05-04 ����
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X3_GY_ZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GY_ZG_ZB As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X3_GY_ZG = .doSaveData_YJBZ_X3_GY_ZG(strErrMsg, strUserId, strPassword, objDataSet_GY_ZG_ZB)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[�ز�_B_����_Ӷ���׼_X3_��Ӷ_Э��]
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objDataSet_GY_XG          ��˽Ӷָ��
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2010-05-04 ����
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X3_GY_XG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GY_XG As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X3_GY_XG = .doSaveData_YJBZ_X3_GY_XG(strErrMsg, strUserId, strPassword, objDataSet_GY_XG)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[�ز�_B_����_Ӷ���׼_X3_��Ӷ_ֱ��]
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objDataSet_GY_ZT_ZB       ��ָ������
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2010-05-04 ����
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X3_GY_ZT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GY_ZT_ZB As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X3_GY_ZT = .doSaveData_YJBZ_X3_GY_ZT(strErrMsg, strUserId, strPassword, objDataSet_GY_ZT_ZB)
            End With
        End Function












        '----------------------------------------------------------------
        ' ����Ӷ������׼[X4]-˽Ӷ��׼����-ְ���б�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2011-01-10 ����
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_SY_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_SY_ZJ = .getDataSet_YJBZ_X4_SY_ZJ(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼[X4]-˽Ӷ��׼����-ȫ������
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2011-01-10 ����
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_SY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_SY = .getDataSet_YJBZ_X4_SY(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼[X4]-ֱ�ܹ�Ӷ��׼����-ְ���б�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2011-01-10 ����
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_GY_ZG_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_GY_ZG_ZJ = .getDataSet_YJBZ_X4_GY_ZG_ZJ(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼[X4]-ֱ�ܹ�Ӷ��׼����-ȫ������
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2011-01-10 ����
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_GY_ZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_GY_ZG = .getDataSet_YJBZ_X4_GY_ZG(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼[X4]-Э�ܹ�Ӷ��׼����-ְ���б�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2011-01-10 ����
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_GY_XG_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_GY_XG_ZJ = .getDataSet_YJBZ_X4_GY_XG_ZJ(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼[X4]-Э�ܹ�Ӷ��׼����-ȫ������
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2011-01-10 ����
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_GY_XG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_GY_XG = .getDataSet_YJBZ_X4_GY_XG(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼[X4]-ֱ�Ӽ��ṫӶ��׼����-ְ���б�
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2011-01-10 ����
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_GY_ZT_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_GY_ZT_ZJ = .getDataSet_YJBZ_X4_GY_ZT_ZJ(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ӷ������׼[X4]-ֱ�Ӽ��ṫӶ��׼����-ȫ������
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWhere                  ����������
        '     objRetDataSet             ����Ϣ���ݼ�
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2011-01-10 ����
        '----------------------------------------------------------------
        Public Function getDataSet_YJBZ_X4_GY_ZT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                getDataSet_YJBZ_X4_GY_ZT = .getDataSet_YJBZ_X4_GY_ZT(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[�ز�_B_����_Ӷ���׼_X4_˽Ӷ]
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objDataSet_SY             ��˽Ӷָ��
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2011-01-10 ����
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X4_SY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_SY As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X4_SY = .doSaveData_YJBZ_X4_SY(strErrMsg, strUserId, strPassword, objDataSet_SY)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[�ز�_B_����_Ӷ���׼_X4_��Ӷ_ֱ��]
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objDataSet_GY_ZG          ��ֱ�ܹ�Ӷָ��
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2011-01-10 ����
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X4_GY_ZG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GY_ZG As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X4_GY_ZG = .doSaveData_YJBZ_X4_GY_ZG(strErrMsg, strUserId, strPassword, objDataSet_GY_ZG)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[�ز�_B_����_Ӷ���׼_X4_��Ӷ_Э��]
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objDataSet_GY_XG          ��Э�ܹ�Ӷָ��
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2011-01-10 ����
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X4_GY_XG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GY_XG As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X4_GY_XG = .doSaveData_YJBZ_X4_GY_XG(strErrMsg, strUserId, strPassword, objDataSet_GY_XG)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[�ز�_B_����_Ӷ���׼_X4_��Ӷ_Э��]
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objDataSet_GY_ZT          ��ֱ�Ӽ��ṫӶָ��
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ����
        '     zengxianglin 2011-01-10 ����
        '----------------------------------------------------------------
        Public Function doSaveData_YJBZ_X4_GY_ZT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objDataSet_GY_ZT As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            With m_objrulesEstateRenshiXingye
                doSaveData_YJBZ_X4_GY_ZT = .doSaveData_YJBZ_X4_GY_ZT(strErrMsg, strUserId, strPassword, objDataSet_GY_ZT)
            End With
        End Function





        '----------------------------------------------------------------
        ' ��ȡ���ͻ�_B_�ͻ����͡���SQL���(�Ը�λ������������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getZhaopinqudaoSQL() As String
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    getZhaopinqudaoSQL = .getZhaopinqudaoSQL()
                End With
            Catch ex As Exception
                getZhaopinqudaoSQL = ""
            End Try
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ͻ�_B_�ͻ����͡���ȫ���ݵ����ݼ�(�Ը�λ������������)
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWhere             �������ַ���(Ĭ�ϱ�ǰ׺a.)
        '     objKehuguanliData����λ������Ϣ���ݼ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function getZhaopinqudaoData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiXingyeData As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    getZhaopinqudaoData = .getZhaopinqudaoData(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiXingyeData)
                End With
            Catch ex As Exception
                getZhaopinqudaoData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' ���桰�ͻ�_B_�ͻ����͡�������
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
        Public Function doSaveZhaopinqudaoData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveZhaopinqudaoData = .doSaveZhaopinqudaoData(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
                End With
            Catch ex As Exception
                doSaveZhaopinqudaoData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' ɾ�����ͻ�_B_�ͻ����͡�������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteZhaopinqudaoData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doDeleteZhaopinqudaoData = .doDeleteZhaopinqudaoData(strErrMsg, strUserId, strPassword, objOldData)
                End With
            Catch ex As Exception
                doDeleteZhaopinqudaoData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        '��ȡ��ְ��Ϣ�ļ������
        '     strErrMsg      ����������򷵻ش�����Ϣ
        '     strUserId      ���û���ʶ
        '     strPassword    ���û�����
        '     strJLBH        ���������
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Public Function getNewRZJLBH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strJLBH As String) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    getNewRZJLBH = .getNewRZJLBH(strErrMsg, strUserId, strPassword, strJLBH)
                End With
            Catch ex As Exception
                getNewRZJLBH = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' ���治ͨ�����ز�_B_����_��ְ����_��Ա��Ϣ������
        '     strErrMsg      ����������򷵻ش�����Ϣ
        '     strUserId      ���û���ʶ
        '     strPassword    ���û�����
        '     strWJBS                ���ļ���ʶ
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveRyxx_BTG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_BTG = .doSaveRyxx_BTG(strErrMsg, strUserId, strPassword, strWJBS, objNewData)
                End With
            Catch ex As Exception
                doSaveRyxx_BTG = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' ���治ͨ�����ز�_B_����_��������_��Ա��Ϣ������
        '     strErrMsg      ����������򷵻ش�����Ϣ
        '     strUserId      ���û���ʶ
        '     strPassword    ���û�����
        '     strWJBS                ���ļ���ʶ
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveRyxx_BTG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal blnTZ As Boolean) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_BTG = .doSaveRyxx_BTG(strErrMsg, strUserId, strPassword, strWJBS, objNewData, blnTZ)
                End With
            Catch ex As Exception
                doSaveRyxx_BTG = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' ���治ͨ�����ز�_B_����_��ְ����_��Ա��Ϣ������
        '     strErrMsg      ����������򷵻ش�����Ϣ
        '     strUserId      ���û���ʶ
        '     strPassword    ���û�����
        '     strWJBS                ���ļ���ʶ
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveRyxx_BTG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal strLZ As String) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_BTG = .doSaveRyxx_BTG(strErrMsg, strUserId, strPassword, strWJBS, objNewData, strLZ)
                End With
            Catch ex As Exception
                doSaveRyxx_BTG = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' ���治ͨ�����ز�_B_����_ʵϰ������_��Ա��Ϣ������
        '     strErrMsg      ����������򷵻ش�����Ϣ
        '     strUserId      ���û���ʶ
        '     strPassword    ���û�����
        '     strWJBS                ���ļ���ʶ
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveRyxx_BTG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal intSXS As Integer) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_BTG = .doSaveRyxx_BTG(strErrMsg, strUserId, strPassword, strWJBS, objNewData, intSXS)
                End With
            Catch ex As Exception
                doSaveRyxx_BTG = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' ����ͨ�����ز�_B_����_��ְ����_��Ա��Ϣ������
        '     strErrMsg      ����������򷵻ش�����Ϣ
        '     strUserId      ���û���ʶ
        '     strPassword    ���û�����
        '     strWJBS                ���ļ���ʶ
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveRyxx_TG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal strLZ As String) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_TG = .doSaveRyxx_TG(strErrMsg, strUserId, strPassword, strWJBS, objNewData, strLZ)
                End With
            Catch ex As Exception
                doSaveRyxx_TG = False
                strErrMsg = ex.Message
            End Try

        End Function


        '----------------------------------------------------------------
        ' ����ͨ�����ز�_B_����_��ְ����_��Ա��Ϣ������
        '     strErrMsg      ����������򷵻ش�����Ϣ
        '     strUserId      ���û���ʶ
        '     strPassword    ���û�����
        '     strWJBS                ���ļ���ʶ
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveRyxx_TG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_TG = .doSaveRyxx_TG(strErrMsg, strUserId, strPassword, strWJBS, objNewData)
                End With
            Catch ex As Exception
                doSaveRyxx_TG = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' ����ͨ�����ز�_B_����_��������_��Ա��Ϣ������
        '     strErrMsg      ����������򷵻ش�����Ϣ
        '     strUserId      ���û���ʶ
        '     strPassword    ���û�����
        '     strWJBS                ���ļ���ʶ
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveRyxx_TG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal blnTZ As Boolean) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_TG = .doSaveRyxx_TG(strErrMsg, strUserId, strPassword, strWJBS, objNewData, blnTZ)
                End With
            Catch ex As Exception
                doSaveRyxx_TG = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' ����ͨ�����ز�_B_����_ʵϰ������_��Ա��Ϣ������
        '     strErrMsg      ����������򷵻ش�����Ϣ
        '     strUserId      ���û���ʶ
        '     strPassword    ���û�����
        '     strWJBS                ���ļ���ʶ
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveRyxx_TG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWJBS As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal intSXS As Integer) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveRyxx_TG = .doSaveRyxx_TG(strErrMsg, strUserId, strPassword, strWJBS, objNewData, intSXS)
                End With
            Catch ex As Exception
                doSaveRyxx_TG = False
                strErrMsg = ex.Message
            End Try

        End Function


        '----------------------------------------------------------------
        ' ��ȡ������Ա��ӡ����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strUserXM                 :��ӡ������
        '     strWhere                  ����������
        '     objDataSet                ����Ϣ���ݼ�

        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getPrintRyxxData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strUserXM As String, _
            ByVal strWhere As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    getPrintRyxxData = .getPrintRyxxData(strErrMsg, strUserId, strPassword, strUserXM, strWhere, objDataSet)
                End With
            Catch ex As Exception
                getPrintRyxxData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' ��ȡ����������Ա��ӡ����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strUserXM                 :��ӡ������
        '     strWhere                  ����������
        '     objDataSet                ����Ϣ���ݼ�

        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getPrintRyxxData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strUserXM As String, _
            ByVal strWhere As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal strTZ As String) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    getPrintRyxxData = .getPrintRyxxData(strErrMsg, strUserId, strPassword, strUserXM, strWhere, objDataSet, strTZ)
                End With
            Catch ex As Exception
                getPrintRyxxData = False
                strErrMsg = ex.Message
            End Try

        End Function


        '----------------------------------------------------------------
        ' ��ȡʵϰ��������Ա��ӡ����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strUserXM                 :��ӡ������
        '     strWhere                  ����������
        '     objDataSet                ����Ϣ���ݼ�

        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getPrintRyxxData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strUserXM As String, _
            ByVal strWhere As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal intSXS As Integer) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    getPrintRyxxData = .getPrintRyxxData(strErrMsg, strUserId, strPassword, strUserXM, strWhere, objDataSet, intSXS)
                End With
            Catch ex As Exception
                getPrintRyxxData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' �����Ŷ���ʱ����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objNewData                :׼������
        '     intZTLX                   :����״̬����
        '     objDataSet_TDZH           ���Ŷ�����

        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveTDTempData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intZTLX As Integer, _
            ByVal objNewData As System.Data.DataRow, _
            ByRef objDataSet_TDZH As Josco.JSOA.Common.Data.estateRenshiXingyeData) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doSaveTDTempData = .doSaveTDTempData(strErrMsg, strUserId, strPassword, intZTLX, objNewData, objDataSet_TDZH)
                End With
            Catch ex As Exception
                doSaveTDTempData = False
                strErrMsg = ex.Message
            End Try

        End Function


        '----------------------------------------------------------------
        'ɾ���Ŷ���ʱ����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strZBBS                   :����ʶ
        '     intZTLX                   :����״̬����
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteTDTempData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZBBS As String, _
            ByVal intZTLX As Integer) As Boolean
            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    doDeleteTDTempData = .doDeleteTDTempData(strErrMsg, strUserId, strPassword, strZBBS, intZTLX)
                End With
            Catch ex As Exception
                doDeleteTDTempData = False
                strErrMsg = ex.Message
            End Try

        End Function

        '----------------------------------------------------------------
        ' ��ָ����Ϣ����Ա�Ӽܹ���ע��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objEnvInfo           ���䶯ͨ�ò�����BDLX,BDSJ,BDYY,BDYYMC��
        '     objMainInfo          �����䶯�˵�ǰ��Ա�ܹ�����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ���ı�ע
        '     zengxianglin 2008-10-14����
        '----------------------------------------------------------------
        Public Function doDelete_RenyuanJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objEnvInfo As System.Collections.Specialized.NameValueCollection, _
            ByVal objMainInfo As System.Data.DataRow) As Boolean
            With m_objrulesEstateRenshiXingye
                doDelete_RenyuanJiagou = .doDelete_RenyuanJiagou(strErrMsg, strUserId, strPassword, objEnvInfo, objMainInfo)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ָ������Ϣ������Ա�ܹ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objEnvInfo           ���䶯ͨ�ò�����BDSJ,BDYY,BDYYMC��
        '     objOldData           �����䶯�˾�����
        '     objNewData           �����䶯��������
        '     objDataSet_XJ        ��Ҫ�������¼���Ա��Ϣ�б�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doAdjust_RenyuanJiagou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objEnvInfo As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Data.DataRow, _
            ByVal objDataSet_XJ As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal blnTZ As Boolean) As Boolean
            With m_objrulesEstateRenshiXingye
                doAdjust_RenyuanJiagou = .doAdjust_RenyuanJiagou(strErrMsg, strUserId, strPassword, objEnvInfo, objOldData, objNewData, objDataSet_XJ, blnTZ)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����Ա����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strRYDM                   : ��Ա����
        '     strSFZHM                  : ���֤����
        '     strRYXM                   : ��Ա����
        '     intReturn                 : 0-ͨ����1-��ID�����֤���벻ͬ��2-��ID�����֤������ͬ��3-��ID,���֤������ͬ��
        '     intLXTable                : 0-��ְ��1-ʵϰ��
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function doCheckRydmData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strSFZHM As String, _
            ByVal strRYXM As String, _
            ByRef intReturn As Integer, _
            ByVal intLXTable As Integer) As Boolean

            With m_objrulesEstateRenshiXingye
                doCheckRydmData = .doCheckRydmData(strErrMsg, strUserId, strPassword, strRYDM, strSFZHM, strRYXM, intReturn, intLXTable)
            End With
        End Function


        '----------------------------------------------------------------
        ' �����Ա����
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     objenumEditType           : �༭����
        '     strRYDM                   ����Ա����
        '     strSFZHM                  : ���֤����

        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveSFZHM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strSFZHM As String, _
            ByVal intLXTable As Integer) As Boolean

            With m_objrulesEstateRenshiXingye
                doSaveSFZHM = .doSaveSFZHM(strErrMsg, strUserId, strPassword, strRYDM, strSFZHM, intLXTable)
            End With
        End Function



        '----------------------------------------------------------------
        ' ����strRYDM��ȡ�û���Ϣ���ݼ�
        '     strErrMsg      ����������򷵻ش�����Ϣ
        '     strUserId      ���û���ʶ
        '     strPassword    ���û�����
        '     strRYDM        ����Ա����
        '     strOptions     ����ȡ����ѡ��ABCD
        '                      A=1 ��ȡ��Ա��������
        '                      B=1 ��ȡ��Ա����֯������������
        '                      C=1 ��ȡ��Ա���ϸڵ�������
        '                      D=1 ��ȡ��Ա����ȫ���ӵı�����
        '     objCustomerData���û���Ϣ���ݼ�
        ' ����
        '     True           ���ɹ�
        '     False          ��ʧ��
        '----------------------------------------------------------------
        Public Function getRenyuanData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strOptions As String, _
            ByRef objCustomerData As Josco.JsKernal.Common.Data.CustomerData) As Boolean

            Try
                With New Josco.JsKernal.BusinessRules.rulesCustomer
                    getRenyuanData = .getRenyuanData(strErrMsg, strUserId, strPassword, strRYDM, strOptions, objCustomerData)
                End With
            Catch ex As Exception
                getRenyuanData = False
                strErrMsg = ex.Message
            End Try

        End Function


        '----------------------------------------------------------------
        ' ��ȡ�ϼ��쵼
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strRYDM                   : ��Ա����
        '     strZZDM                   : ��֯����
        '     strZJDM                   : ְ������
        '     strTDBH                   : �Ŷӱ��
        '     strSJLD                   : ���ص��ϼ��쵼����
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function getSJLD( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strZZDM As String, _
            ByVal strZJDM As String, _
            ByVal strTDBH As String, _
            ByRef strSJLD As String) As Boolean


            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    getSJLD = .getSJLD(strErrMsg, strUserId, strPassword, strRYDM, strZZDM, strZJDM, strTDBH, strSJLD)
                End With
            Catch ex As Exception
                getSJLD = False
                strErrMsg = ex.Message
            End Try

        End Function



        '----------------------------------------------------------------
        ' ����strZBBS�����е��Ŷ��������
        ' ���ù���ģʽ��
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strZBBS                   ������ʶ
        '     objBufDataSet             ���������ݼ�
        '     objRetDataSet             ����Ϣ���ݼ�
        '     blnOption                 : ����
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ���ļ�¼
        '     LJ 2011-07-19 ����
        '----------------------------------------------------------------
        Public Function getDataSet_TDZH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZBBS As String, _
            ByVal objBufDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiXingyeData, _
            ByVal blnOption As Boolean) As Boolean

            With m_objrulesEstateRenshiXingye
                getDataSet_TDZH = .getDataSet_TDZH(strErrMsg, strUserId, strPassword, strZBBS, objBufDataSet, objRetDataSet, blnOption)
            End With
        End Function


        '----------------------------------------------------------------
        ' ������������ְʱ���Ƿ���Ч
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strRYDM                   : ��Ա����
        '     strZZDM                   : ��֯���루�������������ı�ʶ��
        '     strRYLX                   : ��Ա���� 1-ҵ����Ա��0-��������
        '     strSPSJ                   : ����ʱ��
        '     blnSJ                     : ��Ч-true;��Ч-false
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function checkBDSJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strZZDM As String, _
            ByVal strRYLX As String, _
            ByVal strSPSJ As String, _
            ByRef blnSJ As Boolean) As Boolean


            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    checkBDSJ = .checkBDSJ(strErrMsg, strUserId, strPassword, strRYDM, strZZDM, strRYLX, strSPSJ, blnSJ)
                End With
            Catch ex As Exception
                checkBDSJ = False
                strErrMsg = ex.Message
            End Try
        End Function

        '----------------------------------------------------------------
        ' ���������Ա�Ƿ���������
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strRYDM                   : ��Ա����
        '     blnSJ                     : ��-true;��-false
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function checkFlowRy( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByRef blnSJ As Boolean) As Boolean

            Try
                With New Josco.JSOA.BusinessRules.rulesEstateRenshiXingye
                    checkFlowRy = .checkFlowRy(strErrMsg, strUserId, strPassword, strRYDM, blnSJ)
                End With
            Catch ex As Exception
                checkFlowRy = False
                strErrMsg = ex.Message
            End Try
        End Function
    End Class

End Namespace
