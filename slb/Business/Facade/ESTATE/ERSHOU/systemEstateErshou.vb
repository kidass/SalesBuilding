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
    ' ����    ��systemEstateErshou
    '
    ' ���������� 
    '   ���ṩ�Զ���ҵ����ı��ֲ�֧��
    '----------------------------------------------------------------
    Public Class systemEstateErshou
        Implements System.IDisposable

        Private m_objrulesEstateErshou As Josco.JSOA.BusinessRules.rulesEstateErshou

        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
            m_objrulesEstateErshou = New Josco.JSOA.BusinessRules.rulesEstateErshou
        End Sub

        '----------------------------------------------------------------
        ' ��ȫ�ͷű�����Դ
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.systemEstateErshou)
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
            If Not (m_objrulesEstateErshou Is Nothing) Then
                m_objrulesEstateErshou.Dispose()
                m_objrulesEstateErshou = Nothing
            End If
        End Sub










        '----------------------------------------------------------------
        ' ��objDataTable�е�ѡ���е�����Excel�ĵ�ǰ�Sheet���Զ�д������
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     objDataTable           ��Ҫ���������ݱ�
        '     objFields              ��Ҫ��������
        '     strExcelFile           ��������WEB�������е�Excel�ļ�·��
        '     strDateFormat          �����ڸ�ʽ�ַ���
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        ' ����
        '     zengxianglin 2011-01-03 ����
        '----------------------------------------------------------------
        Public Function doExportToExcel( _
            ByRef strErrMsg As String, _
            ByVal objDataTable As System.Data.DataTable, _
            ByVal objFields As System.Collections.Specialized.NameValueCollection, _
            ByVal strExcelFile As String, _
            ByVal strDateFormat As String) As Boolean
            With Me.m_objrulesEstateErshou
                doExportToExcel = .doExportToExcel(strErrMsg, objDataTable, objFields, strExcelFile, strDateFormat)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����ݴ�DataSet������Excel
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     objDataTable           ��Ҫ����������
        '     strExcelFile           ��������WEB�������е�Excel�ļ�·��
        '     strSheetName           �����ݵ�����strSheetName
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doExportToExcel( _
            ByRef strErrMsg As String, _
            ByVal objDataTable As System.Data.DataTable, _
            ByVal strExcelFile As String, _
            ByVal strSheetName As String) As Boolean
            With Me.m_objrulesEstateErshou
                doExportToExcel = .doExportToExcel(strErrMsg, objDataTable, strExcelFile, strSheetName)
            End With
        End Function

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
            With Me.m_objrulesEstateErshou
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
            With Me.m_objrulesEstateErshou
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
            With Me.m_objrulesEstateErshou
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
            With Me.m_objrulesEstateErshou
                doExcelSheetDelete = .doExcelSheetDelete(strErrMsg, strSrcFile, strSrcSheet)
            End With
        End Function












        '----------------------------------------------------------------
        ' ��ȡ���ز�_V_ȫ�����ס�������SQL
        '----------------------------------------------------------------
        Public Function getSearchSQL_QBJY() As String
            With m_objrulesEstateErshou
                getSearchSQL_QBJY = .getSearchSQL_QBJY()
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_V_ȫ�����ס���ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ���������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateErshouData      ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX = .getDataSet_ES_JYXX(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' �жϸ�����ȷ������Ƿ���ڣ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     blnIS                �������Ƿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function isQrshExist( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isQrshExist = .isQrshExist(strErrMsg, strUserId, strPassword, strQRSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_V_ȫ�����ס���ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ���������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateErshouData      ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX = .getDataSet_ES_JYXX(strErrMsg, strUserId, strPassword, strWhere, objestateErshouData)
            End With
        End Function











        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_ȷ������������ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     blnControl                 �����в鿴����
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_MM = .getDataSet_ES_QRS_MM(strErrMsg, strUserId, strPassword, strWhere, blnControl, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_ȷ������������ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_MM = .getDataSet_ES_QRS_MM(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_��ҵ��������ȫ���ݵ����ݼ�
        ' �ԡ����ݵ�ַ������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_WUYE_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_WUYE_MM = .getDataSet_ES_WUYE_MM(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_���׺�ͬ�����������ȫ���ݵ����ݼ�
        ' �ԡ���Ա���롱����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_FPBL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_FPBL = .getDataSet_ES_HETONG_FPBL(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_ȷ�����������е��µġ�ȷ����š�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strJLBH              ��ȷ�����
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function getNewQRSH_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strQRSH As String) As Boolean
            With m_objrulesEstateErshou
                getNewQRSH_MM = .getNewQRSH_MM(strErrMsg, strUserId, strPassword, strQRSH)
            End With
        End Function



        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_ȷ�������ޡ��е��µġ�ȷ����š�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strJLBH              ��ȷ�����
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function getNewQRSH_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strQRSH As String) As Boolean
            With m_objrulesEstateErshou
                getNewQRSH_ZL = .getNewQRSH_ZL(strErrMsg, strUserId, strPassword, strQRSH)
            End With
        End Function


        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_���׺�ͬ���е��µ���������ͬ��š�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strHTBH              ����ͬ���
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function getNewHTBH_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strHTBH As String) As Boolean

            With m_objrulesEstateErshou
                getNewHTBH_MM = .getNewHTBH_MM(strErrMsg, strUserId, strPassword, strHTBH)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_���׺�ͬ���е��µ����ޡ���ͬ��š�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strHTBH              ����ͬ���
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function getNewHTBH_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strHTBH As String) As Boolean

            With m_objrulesEstateErshou
                getNewHTBH_ZL = .getNewHTBH_ZL(strErrMsg, strUserId, strPassword, strHTBH)
            End With
        End Function


        '----------------------------------------------------------------
        ' �жϸ�����ȷ������Ƿ���ǩ���ͬ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     blnIS                �������Ƿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function isQianHetong( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isQianHetong = .isQianHetong(strErrMsg, strUserId, strPassword, strQRSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��顰�ز�_B_����_��ҵ���������������͵ĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objNewData           ��������
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function doVerifyData_ES_WUYE_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateErshou
                doVerifyData_ES_WUYE_MM = .doVerifyData_ES_WUYE_MM(strErrMsg, strUserId, strPassword, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_ȷ�������������ݼ�¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        '     objOldData             ����¼��ֵ
        '     objenumEditType        ���༭����
        '     objDataSet_WYXX        ����ҵ��Ϣ���ݼ�
        '     objDataSet_YWRY        ��ҵ����Ա���ݼ�
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_ES_QRS_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal objDataSet_WYXX As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_YWRY As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_QRS_MM = .doSaveData_ES_QRS_MM(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, objDataSet_WYXX, objDataSet_YWRY)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_ȷ������������¼����ؼ�¼
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strWYBS              ��Ҫɾ����Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_QRS_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_QRS_MM = .doDeleteData_ES_QRS_MM(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ز�_B_����_ȷ����������̢������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strWYBS              ��Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doTading_ES_QRS_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doTading_ES_QRS_MM = .doTading_ES_QRS_MM(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_V_ȫ�����ס���ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     blnControl                 �����в鿴����
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX = .getDataSet_ES_JYXX(strErrMsg, strUserId, strPassword, strWhere, blnControl, objestateErshouData)
            End With
        End Function













        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_ȷ�������ޡ���ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     blnControl                 �����в鿴����
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_ZL = .getDataSet_ES_QRS_ZL(strErrMsg, strUserId, strPassword, strWhere, blnControl, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_��ҵ���ޡ���ȫ���ݵ����ݼ�
        ' �ԡ����ݵ�ַ������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_WUYE_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_WUYE_ZL = .getDataSet_ES_WUYE_ZL(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_ȷ�������ޡ���ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_ZL = .getDataSet_ES_QRS_ZL(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_ȷ�������ޡ���¼����ؼ�¼
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strWYBS              ��Ҫɾ����Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_QRS_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_QRS_ZL = .doDeleteData_ES_QRS_ZL(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ز�_B_����_ȷ�������ޡ�̢������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strWYBS              ��Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doTading_ES_QRS_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doTading_ES_QRS_ZL = .doTading_ES_QRS_ZL(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��顰�ز�_B_����_��ҵ���ޡ����������͵ĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objNewData           ��������
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function doVerifyData_ES_WUYE_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateErshou
                doVerifyData_ES_WUYE_ZL = .doVerifyData_ES_WUYE_ZL(strErrMsg, strUserId, strPassword, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_ȷ�������ޡ����ݼ�¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        '     objOldData             ����¼��ֵ
        '     objenumEditType        ���༭����
        '     objDataSet_WYXX        ����ҵ��Ϣ���ݼ�
        '     objDataSet_YWRY        ��ҵ����Ա���ݼ�
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_ES_QRS_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal objDataSet_WYXX As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_YWRY As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_QRS_ZL = .doSaveData_ES_QRS_ZL(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, objDataSet_WYXX, objDataSet_YWRY)
            End With
        End Function










        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_���׺�ͬ����ȫ���ݵ����ݼ�
        ' �ԡ���ͬ���ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG = .getDataSet_ES_HETONG(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_���׺�ͬ�����ݼ�¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     strYWLX                ��ҵ������
        '     objNewDataHT           ����ͬ��¼��ֵ(���ر�������ֵ)
        '     objOldDataHT           ����ͬ��¼��ֵ
        '     objNewDataQRS          ��ȷ�����¼��ֵ(���ر�������ֵ)
        '     objOldDataQRS          ��ȷ�����¼��ֵ
        '     objenumEditType        ���༭����
        '     objDataSet_WYXX        ����ҵ��Ϣ���ݼ�
        '     objDataSet_YWRY        ��ҵ����Ա���ݼ�
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strYWLX As String, _
            ByRef objNewDataHT As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldDataHT As System.Data.DataRow, _
            ByRef objNewDataQRS As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldDataQRS As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal objDataSet_WYXX As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_YWRY As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_HETONG = .doSaveData_ES_HETONG(strErrMsg, strUserId, strPassword, strYWLX, objNewDataHT, objOldDataHT, objNewDataQRS, objOldDataQRS, objenumEditType, objDataSet_WYXX, objDataSet_YWRY)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_���׺�ͬ����¼����ؼ�¼
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strWYBS              ��Ҫɾ����Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_HETONG = .doDeleteData_ES_HETONG(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_�������ޡ���ȫ���ݵ����ݼ�
        ' �ԡ���ʼ���ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_ZulinQixian( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_ZulinQixian = .getDataSet_ES_ZulinQixian(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_���׺�ͬ�����ݼ�¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     strYWLX                ��ҵ������
        '     objNewDataHT           ����ͬ��¼��ֵ(���ر�������ֵ)
        '     objOldDataHT           ����ͬ��¼��ֵ
        '     objNewDataQRS          ��ȷ�����¼��ֵ(���ر�������ֵ)
        '     objOldDataQRS          ��ȷ�����¼��ֵ
        '     objenumEditType        ���༭����
        '     objDataSet_WYXX        ����ҵ��Ϣ���ݼ�
        '     objDataSet_YWRY        ��ҵ����Ա���ݼ�
        '     objDataSet_ZLQX        �������������ݼ�
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strYWLX As String, _
            ByRef objNewDataHT As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldDataHT As System.Data.DataRow, _
            ByRef objNewDataQRS As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldDataQRS As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal objDataSet_WYXX As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_YWRY As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_ZLQX As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_HETONG = .doSaveData_ES_HETONG(strErrMsg, strUserId, strPassword, strYWLX, objNewDataHT, objOldDataHT, objNewDataQRS, objOldDataQRS, objenumEditType, objDataSet_WYXX, objDataSet_YWRY, objDataSet_ZLQX)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ʱ��Ρ�����𡢼��ⷽ������ö�ʱ�����������ڣ��£�
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strKSRQ                ����ʼ����
        '     strZZRQ                ����ֹ����
        '     dblYZJ                 �������
        '     intJZFF                �����ⷽ��(0-��Ȼ�� 1����Ȼ��)
        '     dblZZJ                 �������
        '     dblZZQ                 ������
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function getZujinAndZuqi( _
            ByRef strErrMsg As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal dblYZJ As Double, _
            ByVal intJZFF As Integer, _
            ByRef dblZZJ As Double, _
            ByRef dblZZQ As Double) As Boolean
            With m_objrulesEstateErshou
                getZujinAndZuqi = .getZujinAndZuqi(strErrMsg, strKSRQ, strZZRQ, dblYZJ, intJZFF, dblZZJ, dblZZQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' �жϸ����ĺ�ͬ�Ƿ�����ˣ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     blnIS                �������Ƿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function isHetongYiShen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isHetongYiShen = .isHetongYiShen(strErrMsg, strUserId, strPassword, strQRSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' �жϸ����ĺ�ͬ�Ƿ�����ɣ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     blnIS                �������Ƿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function isHetongComplete( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isHetongComplete = .isHetongComplete(strErrMsg, strUserId, strPassword, strQRSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡָ����Ա�ڵ�ǰʱ����ְ�����롢ְ������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strRYDM              ����Ա����
        '     strZJDM              ������ְ������
        '     strZJMC              ������ְ������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function getZjdmAndZjmc( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByRef strZJDM As String, _
            ByRef strZJMC As String) As Boolean
            With m_objrulesEstateErshou
                getZjdmAndZjmc = .getZjdmAndZjmc(strErrMsg, strUserId, strPassword, strRYDM, strZJDM, strZJMC)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡָ��˽Ӷ������Ϣ�Զ����㹫Ӷ��������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     objDataSet_SY        ��˽Ӷ������Ϣ
        '     objDataSet_GY        �����ع�Ӷ��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function getGongyongInfo( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal objDataSet_SY As Josco.JSOA.Common.Data.estateErshouData, _
            ByRef objDataSet_GY As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getGongyongInfo = .getGongyongInfo(strErrMsg, strUserId, strPassword, strQRSH, objDataSet_SY, objDataSet_GY)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_���׺�ͬ������������ݼ�¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     strQRSH                ��ȷ�����
        '     objDataSet_SYBL        ��˽Ӷ��Ϣ���ݼ�
        '     objDataSet_GYBL        ����Ӷ��Ϣ���ݼ�
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_ES_HETONG_FPBL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal objDataSet_SYBL As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_GYBL As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_HETONG_FPBL = .doSaveData_ES_HETONG_FPBL(strErrMsg, strUserId, strPassword, strQRSH, objDataSet_SYBL, objDataSet_GYBL)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��顰�ز�_B_����_���׺�ͬ���������˽Ӷ������=1��
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     objDataSet_SYBL        ��˽Ӷ��Ϣ���ݼ�
        '     blnValid               ���жϽ��
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doVerify_ES_HETONG_FPBL( _
            ByRef strErrMsg As String, _
            ByVal objDataSet_SYBL As Josco.JSOA.Common.Data.estateErshouData, _
            ByRef blnValid As Boolean) As Boolean
            With m_objrulesEstateErshou
                doVerify_ES_HETONG_FPBL = .doVerify_ES_HETONG_FPBL(strErrMsg, objDataSet_SYBL, blnValid)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���������ȷ����š�������ݡ�ȷ����š���ȡ���ز�_V_ȫ����ͬ����ȫ���ݵ����ݼ�
        ' �������������������strWhere������
        ' �ԡ���ͬ���ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     blnControl                 ���Ƿ����Ʋ鿴
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX = .getDataSet_ES_JYXX(strErrMsg, strUserId, strPassword, strQRSH, strWhere, blnControl, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_���׺�ͬ���ǩ������ȫ���ݵ����ݼ�
        ' �ԡ�������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_SHQK( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_SHQK = .getDataSet_ES_HETONG_SHQK(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ͬ��˴���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strQRSH              ��ȷ�����
        '     strSHRDM             ������˴���
        '     objSHLX              ���������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doShenHe_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strSHRDM As String, _
            ByVal objSHLX As Josco.JSOA.Common.Data.estateErshouData.enumShenheStatus) As Boolean
            With m_objrulesEstateErshou
                doShenHe_ES_HETONG = .doShenHe_ES_HETONG(strErrMsg, strUserId, strPassword, strQRSH, strSHRDM, objSHLX)
            End With
        End Function











        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_���׺�ͬ�참�ƻ�����ȫ���ݵ����ݼ�
        ' �ԡ��ƻ���ʼ������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_BAJH = .getDataSet_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š������ƻ���ʶ����ȡ���ز�_B_����_���׺�ͬ�참��¼����ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strJHBS                    ������ƻ���Ӧ��Ψһ��ʶ
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_BLJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strJHBS As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_BLJL = .getDataSet_ES_HETONG_BLJL(strErrMsg, strUserId, strPassword, strQRSH, strJHBS, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_���׺�ͬ�참�ƻ���������
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
        Public Function doSaveData_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_HETONG_BAJH = .doSaveData_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_���׺�ͬ�참�ƻ���������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_HETONG_BAJH = .doDeleteData_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_���׺�ͬ�참��¼��������
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
        Public Function doSaveData_ES_HETONG_BLJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_HETONG_BLJL = .doSaveData_ES_HETONG_BLJL(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_���׺�ͬ�참��¼��������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_HETONG_BLJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_HETONG_BLJL = .doDeleteData_ES_HETONG_BLJL(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ǡ��ز�_B_����_���׺�ͬ�참�ƻ���ҵ��ʼ����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ψһ��ʶ
        '     strKSRQ              ����ʼ����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doMarkBegin_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal strKSRQ As String) As Boolean
            With m_objrulesEstateErshou
                doMarkBegin_ES_HETONG_BAJH = .doMarkBegin_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, strWYBS, strKSRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ǡ��ز�_B_����_���׺�ͬ�참�ƻ���ҵ��������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ψһ��ʶ
        '     strJSRQ              ����������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doMarkComplete_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal strJSRQ As String) As Boolean
            With m_objrulesEstateErshou
                doMarkComplete_ES_HETONG_BAJH = .doMarkComplete_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, strWYBS, strJSRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ǡ��ز�_B_����_���׺�ͬ�����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doMarkComplete_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String) As Boolean
            With m_objrulesEstateErshou
                doMarkComplete_ES_HETONG = .doMarkComplete_ES_HETONG(strErrMsg, strUserId, strPassword, strQRSH)
            End With
        End Function

        '----------------------------------------------------------------
        ' �رա��ز�_B_����_���׺�ͬ�참�ƻ���ָ��ҵ�������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doClearTixing_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doClearTixing_ES_HETONG_BAJH = .doClearTixing_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' �򿪡��ز�_B_����_���׺�ͬ�참�ƻ���ָ��ҵ�������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ψһ��ʶ
        '     intKBTS              ����������
        '     intBWTS              ����������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doSetupTixing_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal intKBTS As Integer, _
            ByVal intBWTS As Integer) As Boolean
            With m_objrulesEstateErshou
                doSetupTixing_ES_HETONG_BAJH = .doSetupTixing_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, strWYBS, intKBTS, intBWTS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡָ��strQRSH��ָ���������intSHLX���ۿ����ǩ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     intSHLX              ���������
        '     strSHQM              �������ۿ����ǩ��
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function getHetongZhekouSHQM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal intSHLX As Integer, _
            ByRef strSHQM As String) As Boolean
            With m_objrulesEstateErshou
                getHetongZhekouSHQM = .getHetongZhekouSHQM(strErrMsg, strUserId, strPassword, strQRSH, intSHLX, strSHQM)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡָ��������͵����ޡ������ۿ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     intSHLX              ���������
        '     dblZKSX              �������ۿ�����
        '     dblZKXX              �������ۿ�����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function getHetongZhekouSXX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intSHLX As Integer, _
            ByRef dblZKSX As Double, _
            ByRef dblZKXX As Double) As Boolean
            With m_objrulesEstateErshou
                getHetongZhekouSXX = .getHetongZhekouSXX(strErrMsg, strUserId, strPassword, intSHLX, dblZKSX, dblZKXX)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡָ���ۿ۵���Ҫ���ۿ������߼���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     dblZK                ��ָ���ۿ�
        '     intSHLX              �������ۿ������߼���(0,1,2,4)
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function getHetongZhekouSHJB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal dblZK As Double, _
            ByRef intSHLX As Integer) As Boolean
            With m_objrulesEstateErshou
                getHetongZhekouSHJB = .getHetongZhekouSHJB(strErrMsg, strUserId, strPassword, dblZK, intSHLX)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ��ͬ�����н���ܶ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     dblSum               �������н���ܶ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function getHetongJiesuanSum( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef dblSum As Double) As Boolean
            With m_objrulesEstateErshou
                getHetongJiesuanSum = .getHetongJiesuanSum(strErrMsg, strUserId, strPassword, strQRSH, dblSum)
            End With
        End Function











        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_���׺�ͬ�����顱��ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_JSS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_JSS = .getDataSet_ES_HETONG_JSS(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�������š���ȡ���ز�_B_����_���׺�ͬ�����顱��ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strJSSH                    ���������
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_JSS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSSH As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_JSS = .getDataSet_ES_HETONG_JSS(strErrMsg, strUserId, strPassword, strJSSH, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�������š���ȡ���ز�_B_����_���׺�ͬ��������ϸ����ȫ���ݵ����ݼ�
        ' �ԡ�˰�Ѵ��롱����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strJSSH                    ���������
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_JSS_MX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSSH As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_JSS_MX = .getDataSet_ES_HETONG_JSS_MX(strErrMsg, strUserId, strPassword, strJSSH, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�������š���ȡ���ز�_B_����_���׺�ͬ������ҵ������ȫ���ݵ����ݼ�
        ' �ԡ���λ���롱������Աְ��������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strJSSH                    ���������
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_JSS_YEJI( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSSH As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_JSS_YEJI = .getDataSet_ES_HETONG_JSS_YEJI(strErrMsg, strUserId, strPassword, strJSSH, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_���׺�ͬ�����顱���ݼ�¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        '     objOldData             ����¼��ֵ
        '     objenumEditType        ���༭����
        '     objDataSet_JSMX        ��������ϸ���ݼ�
        '     objDataSet_YEJI        ������ҵ�����ݼ�
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_ES_HETONG_JSS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal objDataSet_JSMX As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_YEJI As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_HETONG_JSS = .doSaveData_ES_HETONG_JSS(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, objDataSet_JSMX, objDataSet_YEJI)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_���׺�ͬ�����顱��¼����ؼ�¼
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strWYBS              ��Ҫɾ����Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_HETONG_JSS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_HETONG_JSS = .doDeleteData_ES_HETONG_JSS(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ��ȷ����š���ȡ��������ۿۡ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     dblHTZK              ��(����)������ۿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function getHtzkByQrsh( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef dblHTZK As Double) As Boolean
            With m_objrulesEstateErshou
                getHtzkByQrsh = .getHtzkByQrsh(strErrMsg, strUserId, strPassword, strQRSH, dblHTZK)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š�������ͬ�ۿۡ������н�Ѷ�����������͡�����
        ' ˽Ӷ����Ӷ������ҵ��������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     dblHTZK              ��������ۿ�
        '     dblZJFE              ���н�Ѷ�
        '     intJSLX              ����������
        '     objDataSet_Yeji      ������ҵ�����ݼ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doComputeYeji( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal dblHTZK As Double, _
            ByVal dblZJFE As Double, _
            ByVal intJSLX As Integer, _
            ByRef objDataSet_Yeji As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doComputeYeji = .doComputeYeji(strErrMsg, strUserId, strPassword, strQRSH, dblHTZK, dblZJFE, intJSLX, objDataSet_Yeji)
            End With
        End Function











        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_���׺�ͬ�ۿ���ˡ���ȫ���ݵ����ݼ�
        ' �ԡ�������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_ZKSH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_ZKSH = .getDataSet_ES_HETONG_ZKSH(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ͬ�ۿ���˴���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strQRSH              ��ȷ�����
        '     strSHRDM             ������˴���
        '     objSHLX              ���������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doZhekouShenHe_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strSHRDM As String, _
            ByVal objSHLX As Josco.JSOA.Common.Data.estateErshouData.enumZhekouShenheType) As Boolean
            With m_objrulesEstateErshou
                doZhekouShenHe_ES_HETONG = .doZhekouShenHe_ES_HETONG(strErrMsg, strUserId, strPassword, strQRSH, strSHRDM, objSHLX)
            End With
        End Function











        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_���׺�ͬ�����顱��ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strJSSH                    ���������
        '     strWhere                   �������ַ���
        '     blnControl                 ��Ȩ�޿���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_JSS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSSH As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_JSS = .getDataSet_ES_HETONG_JSS(strErrMsg, strUserId, strPassword, strJSSH, strWhere, blnControl, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��������˴���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strQRSH              ��ȷ�����
        '     strJSSH              ���������
        '     strSHRDM             ������˴���
        '     objSHLX              ���������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doShenHe_ES_HETONG_JSS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strJSSH As String, _
            ByVal strSHRDM As String, _
            ByVal objSHLX As Josco.JSOA.Common.Data.estateErshouData.enumShenheStatus) As Boolean
            With m_objrulesEstateErshou
                doShenHe_ES_HETONG_JSS = .doShenHe_ES_HETONG_JSS(strErrMsg, strUserId, strPassword, strQRSH, strJSSH, strSHRDM, objSHLX)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�������š���ȡ���ز�_B_����_���׺�ͬ���������ǩ������ȫ���ݵ����ݼ�
        ' �ԡ�������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strJSSH                    ���������
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_HETONG_JSS_SHQK( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_HETONG_JSS_SHQK = .getDataSet_ES_HETONG_JSS_SHQK(strErrMsg, strUserId, strPassword, strJSSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' �жϸ����Ľ������Ƿ�����ˣ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strJSSH              ���������
        '     blnIS                �������Ƿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function isJiesuanshuYiShen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isJiesuanshuYiShen = .isJiesuanshuYiShen(strErrMsg, strUserId, strPassword, strJSSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ��ȷ����š���ȡ����ͬ���ڡ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ����Ա����
        '     strQRSH              ��ȷ�����
        '     strHTBH              ��(����)��ͬ���
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-10-14 ����
        '----------------------------------------------------------------
        Public Function getHtrqByQrsh( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef strHTRQ As String) As Boolean
            With m_objrulesEstateErshou
                getHtrqByQrsh = .getHtrqByQrsh(strErrMsg, strUserId, strPassword, strQRSH, strHTRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[��Ա����]��[ָ��ʱ��]����ҵ����Ա��������λ��ְ��������������Ϣ
        ' ������[����ܹ�]�е���Ա
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ����Ա����
        '     strRYDM              ��ȷ�����
        '     strJCSJ              ��ָ��ʱ��
        '     objRYJGXX            ��(����)ҵ����Ա��������λ��ְ��������������Ϣ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-10-14 ����
        '----------------------------------------------------------------
        Public Function getRYJGXX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strJCSJ As String, _
            ByRef objRYJGXX As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateErshou
                getRYJGXX = .getRYJGXX(strErrMsg, strUserId, strPassword, strRYDM, strJCSJ, objRYJGXX)
            End With
        End Function











        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_ȷ������������ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     blnControl                 �����в鿴����
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2008-11-17 ����
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_QT = .getDataSet_ES_QRS_QT(strErrMsg, strUserId, strPassword, strWhere, blnControl, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_ȷ������������ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2008-11-17 ����
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_QT = .getDataSet_ES_QRS_QT(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_��ҵ��������ȫ���ݵ����ݼ�
        ' �ԡ����ݵ�ַ������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2008-11-17 ����
        '----------------------------------------------------------------
        Public Function getDataSet_ES_WUYE_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_WUYE_QT = .getDataSet_ES_WUYE_QT(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_ȷ�����������е��µġ�ȷ����š�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        ' ���ļ�¼
        '     zengxianglin 2008-11-17 ����
        '----------------------------------------------------------------
        Public Function getNewQRSH_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strQRSH As String) As Boolean
            With m_objrulesEstateErshou
                getNewQRSH_QT = .getNewQRSH_QT(strErrMsg, strUserId, strPassword, strQRSH)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��顰�ز�_B_����_��ҵ���������������͵ĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objNewData           ��������
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        ' ���ļ�¼
        '     zengxianglin 2008-11-17 ����
        '----------------------------------------------------------------
        Public Function doVerifyData_ES_WUYE_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateErshou
                doVerifyData_ES_WUYE_QT = .doVerifyData_ES_WUYE_QT(strErrMsg, strUserId, strPassword, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_ȷ�������������ݼ�¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     objNewData             ����¼��ֵ(���ر�������ֵ)
        '     objOldData             ����¼��ֵ
        '     objenumEditType        ���༭����
        '     objDataSet_WYXX        ����ҵ��Ϣ���ݼ�
        '     objDataSet_YWRY        ��ҵ����Ա���ݼ�
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2008-11-17 ����
        '----------------------------------------------------------------
        Public Function doSaveData_ES_QRS_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal objDataSet_WYXX As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objDataSet_YWRY As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_QRS_QT = .doSaveData_ES_QRS_QT(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, objDataSet_WYXX, objDataSet_YWRY)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_ȷ������������¼����ؼ�¼
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strWYBS              ��Ҫɾ����Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2008-11-17 ����
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_QRS_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_QRS_QT = .doDeleteData_ES_QRS_QT(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ز�_B_����_ȷ����������̢������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strWYBS              ��Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2008-11-17 ����
        '----------------------------------------------------------------
        Public Function doTading_ES_QRS_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doTading_ES_QRS_QT = .doTading_ES_QRS_QT(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_���׺�ͬ���е��µ�����ҵ��ġ���ͬ��š�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strHTBH              ����ͬ���
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        ' ���ļ�¼
        '     zengxianglin 2008-11-17 ����
        '----------------------------------------------------------------
        Public Function getNewHTBH_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef strHTBH As String) As Boolean
            With m_objrulesEstateErshou
                getNewHTBH_QT = .getNewHTBH_QT(strErrMsg, strUserId, strPassword, strHTBH)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���㽻�׵Ŀͻ�����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strJYBH              �����ױ��
        '     strSFDX              ����/��
        '     strKHMC              ���ͻ�����(����)
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        ' ���ļ�¼
        '     zengxianglin 2008-11-17 ����
        '----------------------------------------------------------------
        Public Function getKHMC( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJYBH As String, _
            ByVal strSFDX As String, _
            ByRef strKHMC As String) As Boolean
            With m_objrulesEstateErshou
                getKHMC = .getKHMC(strErrMsg, strUserId, strPassword, strJYBH, strSFDX, strKHMC)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���㽻�׵�ҵ������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strJYBH              �����ױ��
        '     strYWLX              ��ҵ������(����)
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        ' ���ļ�¼
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function getYWLX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJYBH As String, _
            ByRef strYWLX As String) As Boolean
            With m_objrulesEstateErshou
                getYWLX = .getYWLX(strErrMsg, strUserId, strPassword, strJYBH, strYWLX)
            End With
        End Function

        '----------------------------------------------------------------
        ' �ж�ָ����Ա�Ƿ�Ϊָ����λ��ֱ�ܣ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strRYDM              ����Ա����
        '     strDWDM              ����λ����
        '     strJCSJ              �����ʱ��
        '     blnIS                ���Ƿ�(����)
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        ' ���ļ�¼
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function IsZhiguan( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strDWDM As String, _
            ByVal strJCSJ As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                IsZhiguan = .IsZhiguan(strErrMsg, strUserId, strPassword, strRYDM, strDWDM, strJCSJ, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_���׺�ͬ�참�ƻ���������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     objDataSet           ��Ҫ���������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function doSaveData_ES_HETONG_BAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_HETONG_BAJH = .doSaveData_ES_HETONG_BAJH(strErrMsg, strUserId, strPassword, strQRSH, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ����Ա�Ŀ������ѵ�ҵ����Ŀ
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strRYDM                   ����Ա����
        '     intYWSM                   ��ҵ����Ŀ(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function getCount_KBTX( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByRef intYWSM As Integer) As Boolean
            With m_objrulesEstateErshou
                getCount_KBTX = .getCount_KBTX(strErrMsg, strUserId, strPassword, strRYDM, intYWSM)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ����Ա�İ������ѵ�ҵ����Ŀ
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strRYDM                   ����Ա����
        '     intYWSM                   ��ҵ����Ŀ(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function getCount_BWTX( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByRef intYWSM As Integer) As Boolean
            With m_objrulesEstateErshou
                getCount_BWTX = .getCount_BWTX(strErrMsg, strUserId, strPassword, strRYDM, intYWSM)
            End With
        End Function

        '----------------------------------------------------------------
        ' �жϸ����ĺ�ͬ�Ƿ�������ˣ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     blnIS                �������Ƿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-22 ����
        '----------------------------------------------------------------
        Public Function isHetongDoneShenhe( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isHetongDoneShenhe = .isHetongDoneShenhe(strErrMsg, strUserId, strPassword, strQRSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' �жϸ����ĺ�ͬ�Ƿ������참�ƻ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     blnIS                �������Ƿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-22 ����
        '----------------------------------------------------------------
        Public Function isHetongDoneBAJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isHetongDoneBAJH = .isHetongDoneBAJH(strErrMsg, strUserId, strPassword, strQRSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' �жϸ����ĺ�ͬ�Ƿ�����ҵ�����䷽����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     blnIS_SY             �������Ƿ���˽ٸ
        '     blnIS_GY             �������Ƿ�����ٸ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-22 ����
        '----------------------------------------------------------------
        Public Function isHetongDoneFPBL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS_SY As Boolean, _
            ByRef blnIS_GY As Boolean) As Boolean
            With m_objrulesEstateErshou
                isHetongDoneFPBL = .isHetongDoneFPBL(strErrMsg, strUserId, strPassword, strQRSH, blnIS_SY, blnIS_GY)
            End With
        End Function

        '----------------------------------------------------------------
        ' �жϸ����Ľ������Ƿ�����ҵ�����䣿
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strJSSH              ���������
        '     blnIS                �������Ƿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-22 ����
        '----------------------------------------------------------------
        Public Function isJssDoneYJFP( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateErshou
                isJssDoneYJFP = .isJssDoneYJFP(strErrMsg, strUserId, strPassword, strJSSH, blnIS)
            End With
        End Function











        '----------------------------------------------------------------
        ' �����н鲿���ִ����������������У�������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-24 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESDLJSQKB_GFH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESDLJSQKB_GFH = .getDataSet_BB_ESDLJSQKB_GFH(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ġ��ز�_B_����_���׺�ͬ��ָ����¼��[���ҷ���]�ֶ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strQRSH              ��ȷ�����
        '     dblAJFH              �����ҷ�����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-25 ����
        '----------------------------------------------------------------
        Public Function doUpdateData_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal dblAJFH As Double) As Boolean
            With m_objrulesEstateErshou
                doUpdateData_ES_HETONG = .doUpdateData_ES_HETONG(strErrMsg, strUserId, strPassword, strQRSH, dblAJFH)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿���ִ�������������ҵ�񣩵�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-26 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESDLJSQKB_GYW( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESDLJSQKB_GYW = .getDataSet_BB_ESDLJSQKB_GYW(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿���ִ���Ӱ�����������У�������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-26 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESDLJAQKB_GFH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESDLJAQKB_GFH = .getDataSet_BB_ESDLJAQKB_GFH(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿���ִ���᰸����������У�������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-26 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESDLWCQKB_GFH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESDLWCQKB_GFH = .getDataSet_BB_ESDLWCQKB_GFH(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, objDataSet)
            End With
        End Function










        '----------------------------------------------------------------
        ' ��ȡ[�ز�_B_����_������ȼƻ�]����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   ����������
        '     objDataSet                 ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-28 ����
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYNDJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYNDJH = .getDataSet_ES_JYNDJH(strErrMsg, strUserId, strPassword, strWhere, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ[�ز�_B_����_������ȼƻ�]����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     intJHND                    ���ƻ����
        '     objDataSet                 ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-28 ����
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYNDJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intJHND As Integer, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYNDJH = .getDataSet_ES_JYNDJH(strErrMsg, strUserId, strPassword, intJHND, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_������ȼƻ������ݼ�¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     intJHND                ���ƻ����
        '     objDataSet             ���ƻ���ֵ
        '     objenumEditType        ���༭ģʽ
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-28 ����
        '----------------------------------------------------------------
        Public Function doSaveData_ES_JYNDJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intJHND As Integer, _
            ByVal objNewData As Josco.JSOA.Common.Data.estateErshouData, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_JYNDJH = .doSaveData_ES_JYNDJH(strErrMsg, strUserId, strPassword, intJHND, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_������ȼƻ�����¼
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strWYBS              ��Ҫɾ����Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-28 ����
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_JYNDJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_JYNDJH = .doDeleteData_ES_JYNDJH(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_������ȼƻ�����¼
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     intJHND              ��Ҫɾ���ļƻ����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-28 ����
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_JYNDJH( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intJHND As Integer) As Boolean
            With m_objrulesEstateErshou
                doDeleteData_ES_JYNDJH = .doDeleteData_ES_JYNDJH(strErrMsg, strUserId, strPassword, intJHND)
            End With
        End Function

        '----------------------------------------------------------------
        ' �ж�ָ����ȵ�[�ز�_B_����_������ȼƻ�]�Ƿ���ڣ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     intJHND              ���ƻ����
        '     blnHas               ���Ƿ����(����)
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        ' ���ļ�¼
        '     zengxianglin 2008-11-28 ����
        '----------------------------------------------------------------
        Public Function isJyndjhExisted( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intJHND As Integer, _
            ByRef blnHas As Boolean) As Boolean
            With m_objrulesEstateErshou
                isJyndjhExisted = .isJyndjhExisted(strErrMsg, strUserId, strPassword, intJHND, blnHas)
            End With
        End Function












        '----------------------------------------------------------------
        ' �����н鲿���ִ��������������¶ȣ�������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     intND                      �����
        '     intYD                      ���¶�
        '     intYJZR                    ���½�ֹ��
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-28 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESDLJSQKB_GYD( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intND As Integer, _
            ByVal intYD As Integer, _
            ByVal intYJZR As Integer, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESDLJSQKB_GYD = .getDataSet_BB_ESDLJSQKB_GYD(strErrMsg, strUserId, strPassword, intND, intYD, intYJZR, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ������嵥(�Ӱ�)������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     strBMDM                    �����Ŵ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-28 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_JA( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_JA = .getDataSet_BB_ESYWDLQD_JA(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ������嵥(�Ӱ�)������(δ���ͬ)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     strBMDM                    �����Ŵ���
        '     objDataSet                 ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2009-02-24 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_JA_WS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_JA_WS = .getDataSet_BB_ESYWDLQD_JA_WS(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ������嵥(�᰸)������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     strBMDM                    �����Ŵ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-28 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_WC( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_WC = .getDataSet_BB_ESYWDLQD_WC(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ������嵥(�ѽ�δ�᰸)������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     strBMDM                    �����Ŵ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-28 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_YJWJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_YJWJ = .getDataSet_BB_ESYWDLQD_YJWJ(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ���Ӷ�嵥(˽Ӷ)������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     strBMDM                    �����Ŵ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-12-01 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_SY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_SY = .getDataSet_BB_ESJYQD_SY(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ���Ӷ�嵥(��Ӷ)������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     strBMDM                    �����Ŵ���
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-12-01 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_GY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_GY = .getDataSet_BB_ESJYQD_GY(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function










        '----------------------------------------------------------------
        ' �����н鲿���ּ�Ӷ�嵥(��Ӷ����)������
        ' ���¼���ָ���µ�ʱӦ����������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     intND                      �����
        '     intYD                      ���¶�
        '     intYJZR                    ���½�ֹ��
        '     blnNew                     ���ӿ�����
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-12-01 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_GYBF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intND As Integer, _
            ByVal intYD As Integer, _
            ByVal intYJZR As Integer, _
            ByVal blnNew As Boolean, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_GYBF = .getDataSet_BB_ESJYQD_GYBF(strErrMsg, strUserId, strPassword, intND, intYD, intYJZR, blnNew, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿���ּ�Ӷ�嵥(��Ӷ����)������
        ' ��ȡ��������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     intND                      �����
        '     intYD                      ���¶�
        '     intYJZR                    ���½�ֹ��
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-12-01 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_GYBF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intND As Integer, _
            ByVal intYD As Integer, _
            ByVal intYJZR As Integer, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_GYBF = .getDataSet_BB_ESJYQD_GYBF(strErrMsg, strUserId, strPassword, intND, intYD, intYJZR, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �жϸ�����ȡ��¶ȵĹ�Ӷ����[�ز�_B_����_���׺�ͬ������ҵ������]�����Ƿ���ڣ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     intND                �����
        '     intYD                ���¶�
        '     intMode              ��0-����,1-����
        '     blnHas               �������Ƿ����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-12-01 ����
        '----------------------------------------------------------------
        Public Function isGYBFExisted( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intND As Integer, _
            ByVal intYD As Integer, _
            ByVal intMode As Integer, _
            ByRef blnHas As Boolean) As Boolean
            With m_objrulesEstateErshou
                isGYBFExisted = .isGYBFExisted(strErrMsg, strUserId, strPassword, intND, intYD, intMode, blnHas)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_���׺�ͬ������ҵ�����������ݼ�¼(�����������)
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     intND                  �����
        '     intYD                  ���¶�
        '     objDataSet_YJBF        ��Ҫ���������
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_ES_JYHTJSSYJBF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intND As Integer, _
            ByVal intYD As Integer, _
            ByVal objDataSet_YJBF As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_JYHTJSSYJBF = .doSaveData_ES_JYHTJSSYJBF(strErrMsg, strUserId, strPassword, intND, intYD, objDataSet_YJBF)
            End With
        End Function











        '----------------------------------------------------------------
        ' �����н鲿���ִ�����������������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     intType                    ��ͳ�����ͣ�0-�Ӱ���1-�᰸��2-�ѽ�δ�᰸
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-12-01 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESDLQYQKB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal intType As Integer, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESDLQYQKB = .getDataSet_BB_ESDLQYQKB(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, intType, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿��������ҵ�����а������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     intType                    ��ͳ�����ͣ�0-�Ӱ���1-�᰸��2-�ѽ�δ�᰸
        '     objDataSet                 ����Ϣ���ݼ�
        '                                  0-����:���
        '                                  1-����:����
        '                                  2-����:����
        '                                  3-����:�����
        '                                  4-����:���ҷ���
        '                                  5-����:���׽��
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-12-01 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESPHBQYYJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal intType As Integer, _
            ByRef objDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESPHBQYYJ = .getDataSet_BB_ESPHBQYYJ(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, intType, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿���ֲ���ҵ�����а������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     intType                    ��ͳ�����ͣ�0-�Ӱ���1-�᰸��2-�ѽ�δ�᰸
        '     objDataSet                 ����Ϣ���ݼ�
        '                                  0-����:���
        '                                  1-����:����
        '                                  2-����:����
        '                                  3-����:�����
        '                                  4-����:���ҷ���
        '                                  5-����:���׽��
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-12-01 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESPHBBMYJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal intType As Integer, _
            ByRef objDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESPHBBMYJ = .getDataSet_BB_ESPHBBMYJ(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, intType, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿������Աҵ�����а������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     intType                    ��ͳ�����ͣ�0-�Ӱ���1-�᰸��2-�ѽ�δ�᰸
        '     objDataSet                 ����Ϣ���ݼ�
        '                                  0-����:���
        '                                  1-����:����
        '                                  2-����:����
        '                                  3-����:�����
        '                                  4-����:���ҷ���
        '                                  5-����:���׽��
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-12-01 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESPHBRYYJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal intType As Integer, _
            ByRef objDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESPHBRYYJ = .getDataSet_BB_ESPHBRYYJ(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, intType, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ����ȶԱȵ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     intKSND                    ����ʼ���
        '     intZZND                    ����ֹ���
        '     intYJZR                    ���½�ֹ��
        '     intType                    ��ͳ�����ͣ�0-�Ӱ���1-�᰸
        '     strYWLX                    ��ҵ�����ͣ�����.����|����.����|����.����
        '     strBMDM                    ��ͳ�Ʋ���
        '     objDataSet                 ����Ϣ���ݼ�
        '                                  0-����:���
        '                                  1-����:����
        '                                  2-����:����
        '                                  3-����:�����
        '                                  4-����:���ҷ���
        '                                  5-����:���׽��
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-12-01 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESNDDB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal intKSND As Integer, _
            ByVal intZZND As Integer, _
            ByVal intYJZR As Integer, _
            ByVal intType As Integer, _
            ByVal strYWLX As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESNDDB = .getDataSet_BB_ESNDDB(strErrMsg, strUserId, strPassword, intKSND, intZZND, intYJZR, intType, strYWLX, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����Ӷ�����������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     strBMDM                    ��ͳ�Ʋ���
        '     dblLVBL                    ����ʦ����Ӷ����
        '     objDataSet                 ����Ϣ���ݼ�
        '                                  0-Ӷ������
        '                                  1-˽Ӷ������������
        '                                  2-��Ӷ��������
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2008-12-04 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYJFPB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByVal dblLVBL As Double, _
            ByRef objDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYJFPB = .getDataSet_BB_ESYJFPB(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, dblLVBL, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ġ��ز�_B_����_���׺�ͬ����[ͳ������]
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strQRSH              ��[ȷ�����]
        '     strTJRQ              ��[ͳ������]
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ���ļ�¼��
        '     zengxianglin 2009-02-24 ����
        '----------------------------------------------------------------
        Public Function doUpdateData_ES_HETONG_TJRQ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strTJRQ As String) As Boolean
            With m_objrulesEstateErshou
                doUpdateData_ES_HETONG_TJRQ = .doUpdateData_ES_HETONG_TJRQ(strErrMsg, strUserId, strPassword, strQRSH, strTJRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����[�ز�_B_����_���׺�ͬ]��[ͳ������]
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strQRSH                   ��ȷ�����
        '     strTJRQ                   ��ͳ������(����)
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        ' ��������
        '     zengxianglin 2009-02-24 ����
        '----------------------------------------------------------------
        Public Function getES_HETONG_TJRQ( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef strTJRQ As String) As Boolean
            With m_objrulesEstateErshou
                getES_HETONG_TJRQ = .getES_HETONG_TJRQ(strErrMsg, strUserId, strPassword, strQRSH, strTJRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ġ��ز�_B_����_���׺�ͬ����[��ע��Ϣ]
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strQRSH              ��[ȷ�����]
        '     strBZXX              ��[��ע��Ϣ]
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ���ļ�¼��
        '     zengxianglin 2009-02-24 ����
        '----------------------------------------------------------------
        Public Function doUpdateData_ES_HETONG_BZXX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strBZXX As String) As Boolean
            With m_objrulesEstateErshou
                doUpdateData_ES_HETONG_BZXX = .doUpdateData_ES_HETONG_BZXX(strErrMsg, strUserId, strPassword, strQRSH, strBZXX)
            End With
        End Function










        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_ȷ��������_��ӡ����ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     blnControl                 �����в鿴����
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2009-05-17 ����
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_MM_PRN( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_MM_PRN = .getDataSet_ES_QRS_MM_PRN(strErrMsg, strUserId, strPassword, strWhere, blnControl, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_ȷ��������_��ӡ����ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     blnControl                 �����в鿴����
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2009-05-17 ����
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_ZL_PRN( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_ZL_PRN = .getDataSet_ES_QRS_ZL_PRN(strErrMsg, strUserId, strPassword, strWhere, blnControl, objestateErshouData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_ȷ��������_��ӡ����ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     blnControl                 �����в鿴����
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2009-05-17 ����
        '----------------------------------------------------------------
        Public Function getDataSet_ES_QRS_QT_PRN( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnControl As Boolean, _
            ByRef objestateErshouData As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_QRS_QT_PRN = .getDataSet_ES_QRS_QT_PRN(strErrMsg, strUserId, strPassword, strWhere, blnControl, objestateErshouData)
            End With
        End Function











        '----------------------------------------------------------------
        ' ��ȡ���ز�_V_ȫ�����ס���[����.����]������ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     strQueryDG                 ��������������
        '     strQueryHT                 ����ͬ������
        '     strQueryDY                 ����ҵ������
        '     strQueryRY                 ��ҵ��Ա������
        '     blnControl                 �����в鿴����
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ����
        '     zengxianglin 2009-05-18 ����
        '     zengxianglin 2011-01-03 ����
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX_MM( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal strQueryDG As String, _
            ByVal strQueryHT As String, _
            ByVal strQueryDY As String, _
            ByVal strQueryRY As String, _
            ByVal blnControl As Boolean, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX_MM = .getDataSet_ES_JYXX_MM(strErrMsg, strUserId, strPassword, strWhere, strQueryDG, strQueryHT, strQueryDY, strQueryRY, blnControl, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_V_ȫ�����ס���[����.����]������ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     strQueryDG                 ��������������
        '     strQueryHT                 ����ͬ������
        '     strQueryDY                 ����ҵ������
        '     strQueryRY                 ��ҵ��Ա������
        '     blnControl                 �����в鿴����
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ����
        '     zengxianglin 2009-05-18 ����
        '     zengxianglin 2011-01-04 ����
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX_QT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal strQueryDG As String, _
            ByVal strQueryHT As String, _
            ByVal strQueryDY As String, _
            ByVal strQueryRY As String, _
            ByVal blnControl As Boolean, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX_QT = .getDataSet_ES_JYXX_QT(strErrMsg, strUserId, strPassword, strWhere, strQueryDG, strQueryHT, strQueryDY, strQueryRY, blnControl, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_V_ȫ�����ס���[����.����]������ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     strQueryDG                 ��������������
        '     strQueryHT                 ����ͬ������
        '     strQueryDY                 ����ҵ������
        '     strQueryRY                 ��ҵ��Ա������
        '     blnControl                 �����в鿴����
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ����
        '     zengxianglin 2009-05-18 ����
        '     zengxianglin 2011-01-05 ����
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX_ZL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal strQueryDG As String, _
            ByVal strQueryHT As String, _
            ByVal strQueryDY As String, _
            ByVal strQueryRY As String, _
            ByVal blnControl As Boolean, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX_ZL = .getDataSet_ES_JYXX_ZL(strErrMsg, strUserId, strPassword, strWhere, strQueryDG, strQueryHT, strQueryDY, strQueryRY, blnControl, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �Զ�������ͬ�ķ�����������Լ���ͬ�漰�Ľ������ҵ������
        ' ��[��ͬ����]ʱ�Ĺ���ܹ�����Ϊ��׼
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     strQRSH                ��ȷ�����
        '     strBZXX                ����ע��Ϣ
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2009-05-19 ����
        '----------------------------------------------------------------
        Public Function doUpdate_ES_HETONG_FPBL_JSYJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strBZXX As String) As Boolean
            With m_objrulesEstateErshou
                doUpdate_ES_HETONG_FPBL_JSYJ = .doUpdate_ES_HETONG_FPBL_JSYJ(strErrMsg, strUserId, strPassword, strQRSH, strBZXX)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ������嵥(�Ӱ�)(����״̬)������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     strBMDM                    �����Ŵ���
        '     objDataSet                 ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2009-05-21 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_JA_ALL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_JA_ALL = .getDataSet_BB_ESYWDLQD_JA_ALL(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ������嵥(�Ӱ�)(����״̬)������
        ' ��[�ܼ�][Ƭ��][����][��ϸ]�ּ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     strBMDM                    �����Ŵ���
        '     objDataSet                 ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2009-05-21 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_JA1_ALL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_JA1_ALL = .getDataSet_BB_ESYWDLQD_JA1_ALL(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ������嵥(�Ӱ�)(�����ͬ)������
        ' ��[�ܼ�][Ƭ��][����][��ϸ]�ּ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     strBMDM                    �����Ŵ���
        '     objDataSet                 ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2009-05-21 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_JA1_YS( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_JA1_YS = .getDataSet_BB_ESYWDLQD_JA1_YS(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ������嵥(�ѽ�δ����)������
        ' ��[�ܼ�][Ƭ��][����][��ϸ]�ּ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strKSRQ                    ����ʼ����
        '     strZZRQ                    ����ֹ����
        '     strBMDM                    �����Ŵ���
        '     objDataSet                 ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2009-05-21 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESYWDLQD_YJWJW( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strBMDM As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESYWDLQD_YJWJW = .getDataSet_BB_ESYWDLQD_YJWJW(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strBMDM, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ġ��ز�_B_����_���׺�ͬ�����顱��[��Ӷ����]
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strJSID              ��Ψһ��ʶ
        '     strJYRQ              ����Ӷ����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2009-12-26 ����
        '----------------------------------------------------------------
        Public Function doUpdate_ES_HETONG_JSS_JYRQ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJSID As String, _
            ByVal strJYRQ As String) As Boolean
            With m_objrulesEstateErshou
                doUpdate_ES_HETONG_JSS_JYRQ = .doUpdate_ES_HETONG_JSS_JYRQ(strErrMsg, strUserId, strPassword, strJSID, strJYRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ��ȷ����š���ȡ���������ڡ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ����Ա����
        '     strQRSH              ��ȷ�����
        '     strDGRQ              ��(����)��������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2010-01-13 ����
        '----------------------------------------------------------------
        Public Function getDgrqByQrsh( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef strDGRQ As String) As Boolean
            With m_objrulesEstateErshou
                getDgrqByQrsh = .getDgrqByQrsh(strErrMsg, strUserId, strPassword, strQRSH, strDGRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ���Ӷ�嵥(˽Ӷ)������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strCzyId                   ��������Ա
        '     intTJND                    ��ͳ�����
        '     intTJYD                    ��ͳ���¶�
        '     intYJZR                    ���½�ֹ��
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2010-01-18 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_SY_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strCzyId As String, _
            ByVal intTJND As Integer, _
            ByVal intTJYD As Integer, _
            ByVal intYJZR As Integer, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_SY_X2 = .getDataSet_BB_ESJYQD_SY_X2(strErrMsg, strUserId, strPassword, strCzyId, intTJND, intTJYD, intYJZR, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ���Ӷ�嵥(��Ӷ)������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strCzyId                   ��������Ա
        '     intTJND                    ��ͳ�����
        '     intTJYD                    ��ͳ���¶�
        '     intYJZR                    ���½�ֹ��
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2010-01-18 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_GY_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strCzyId As String, _
            ByVal intTJND As Integer, _
            ByVal intTJYD As Integer, _
            ByVal intYJZR As Integer, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_GY_X2 = .getDataSet_BB_ESJYQD_GY_X2(strErrMsg, strUserId, strPassword, strCzyId, intTJND, intTJYD, intYJZR, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ��Ӷ�����������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strCzyId                   ��������Ա
        '     intTJND                    ��ͳ�����
        '     intTJYD                    ��ͳ���¶�
        '     intYJZR                    ���½�ֹ��
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2010-01-20 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_YJFPB_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strCzyId As String, _
            ByVal intTJND As Integer, _
            ByVal intTJYD As Integer, _
            ByVal intYJZR As Integer, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_YJFPB_X2 = .getDataSet_BB_YJFPB_X2(strErrMsg, strUserId, strPassword, strCzyId, intTJND, intTJYD, intYJZR, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ���Ӷ�嵥(˽Ӷ)������(����Ȼ�¼���)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strCzyId                   ��������Ա
        '     strKSRQ                    ����ʼ����(�³�����)
        '     strZZRQ                    ����ֹ����(��ĩ����)
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ����
        '     zengxianglin 2010-04-27 ����
        '     zengxianglin 2011-01-18 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_SY_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strCzyId As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_SY_X2 = .getDataSet_BB_ESJYQD_SY_X2(strErrMsg, strUserId, strPassword, strCzyId, strKSRQ, strZZRQ, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ���Ӷ�嵥(��Ӷ)������(����Ȼ�¼���)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strCzyId                   ��������Ա
        '     strKSRQ                    ����ʼ����(�³�����)
        '     strZZRQ                    ����ֹ����(��ĩ����)
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ����
        '     zengxianglin 2010-04-27 ����
        '     zengxianglin 2011-01-18 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_ESJYQD_GY_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strCzyId As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_ESJYQD_GY_X2 = .getDataSet_BB_ESJYQD_GY_X2(strErrMsg, strUserId, strPassword, strCzyId, strKSRQ, strZZRQ, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����ҵ��Ӷ�����������(����Ȼ�¼���)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strCzyId                   ��������Ա
        '     strKSRQ                    ����ʼ����(�³�����)
        '     strZZRQ                    ����ֹ����(��ĩ����)
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ��������
        '     zengxianglin 2010-04-27 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_YJFPB_X2( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strCzyId As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_YJFPB_X2 = .getDataSet_BB_YJFPB_X2(strErrMsg, strUserId, strPassword, strCzyId, strKSRQ, strZZRQ, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ������ҵ��Ϣ���ݼ�����[��ҵ��Ϣ]��web��ʽ(����)
        '     objWYSJ��[�ز�_B_����_��ҵ����]����
        ' ����
        '     zengxianglin 2010-12-27 ����
        '----------------------------------------------------------------
        Public Function getWYXX_MM(ByVal objWYSJ As System.Collections.Specialized.NameValueCollection) As String
            With m_objrulesEstateErshou
                getWYXX_MM = .getWYXX_MM(objWYSJ)
            End With
        End Function

        '----------------------------------------------------------------
        ' ������ҵ��Ϣ���ݼ�����[��ҵ��Ϣ]��web��ʽ(����)
        '     objWYSJ��[�ز�_B_����_��ҵ����]����
        ' ����
        '     zengxianglin 2010-12-27 ����
        '----------------------------------------------------------------
        Public Function getWYXX_ZL(ByVal objWYSJ As System.Collections.Specialized.NameValueCollection) As String
            With m_objrulesEstateErshou
                getWYXX_ZL = .getWYXX_ZL(objWYSJ)
            End With
        End Function

        '----------------------------------------------------------------
        ' ������ҵ��Ϣ���ݼ�����[��ҵ��Ϣ]��web��ʽ(����)
        '     objWYSJ��[�ز�_B_����_��ҵ����]����
        ' ����
        '     zengxianglin 2010-12-27 ����
        '----------------------------------------------------------------
        Public Function getWYXX_QT(ByVal objWYSJ As System.Collections.Specialized.NameValueCollection) As String
            With m_objrulesEstateErshou
                getWYXX_QT = .getWYXX_QT(objWYSJ)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ǡ��ز�_B_����_���׺�ͬ�������ͬ
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ����
        '     zengxianglin 2010-12-30 ����
        '----------------------------------------------------------------
        Public Function doMarkJiechu_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String) As Boolean
            With m_objrulesEstateErshou
                doMarkJiechu_ES_HETONG = .doMarkJiechu_ES_HETONG(strErrMsg, strUserId, strPassword, strQRSH)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ǡ��ز�_B_����_���׺�ͬ�����ڻ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     dblHZJE              �����˽��
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ����
        '     zengxianglin 2010-12-30 ����
        '----------------------------------------------------------------
        Public Function doMarkHuaizhang_ES_HETONG( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal dblHZJE As Double) As Boolean
            With m_objrulesEstateErshou
                doMarkHuaizhang_ES_HETONG = .doMarkHuaizhang_ES_HETONG(strErrMsg, strUserId, strPassword, strQRSH, dblHZJE)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ҵ���б��ӡ�����ݼ�(1�������ʾ4����Ԫ9��ҵ��Ա)
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     strQueryDG                 ��������������
        '     strQueryHT                 ����ͬ������
        '     strQueryDY                 ����ҵ������
        '     strQueryRY                 ��ҵ��Ա������
        '     blnControl                 �����в鿴����
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ����
        '     zengxianglin 2011-01-03 ����
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX_MM_PRN( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal strQueryDG As String, _
            ByVal strQueryHT As String, _
            ByVal strQueryDY As String, _
            ByVal strQueryRY As String, _
            ByVal blnControl As Boolean, _
            ByRef objRetDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX_MM_PRN = .getDataSet_ES_JYXX_MM_PRN(strErrMsg, strUserId, strPassword, strWhere, strQueryDG, strQueryHT, strQueryDY, strQueryRY, blnControl, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��������ҵ���б��ӡ�����ݼ�(1�������ʾ4����Ԫ9��ҵ��Ա)
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     strQueryDG                 ��������������
        '     strQueryHT                 ����ͬ������
        '     strQueryDY                 ����ҵ������
        '     strQueryRY                 ��ҵ��Ա������
        '     blnControl                 �����в鿴����
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ����
        '     zengxianglin 2011-01-04 ����
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX_QT_PRN( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal strQueryDG As String, _
            ByVal strQueryHT As String, _
            ByVal strQueryDY As String, _
            ByVal strQueryRY As String, _
            ByVal blnControl As Boolean, _
            ByRef objRetDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX_QT_PRN = .getDataSet_ES_JYXX_QT_PRN(strErrMsg, strUserId, strPassword, strWhere, strQueryDG, strQueryHT, strQueryDY, strQueryRY, blnControl, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ҵ���б��ӡ�����ݼ�(1�������ʾ4����Ԫ9��ҵ��Ա)
        ' �ԡ��������ڡ�����
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     strQueryDG                 ��������������
        '     strQueryHT                 ����ͬ������
        '     strQueryDY                 ����ҵ������
        '     strQueryRY                 ��ҵ��Ա������
        '     blnControl                 �����в鿴����
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ����
        '     zengxianglin 2011-01-05 ����
        '----------------------------------------------------------------
        Public Function getDataSet_ES_JYXX_ZL_PRN( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal strQueryDG As String, _
            ByVal strQueryHT As String, _
            ByVal strQueryDY As String, _
            ByVal strQueryRY As String, _
            ByVal blnControl As Boolean, _
            ByRef objRetDataSet As System.Data.DataSet) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_JYXX_ZL_PRN = .getDataSet_ES_JYXX_ZL_PRN(strErrMsg, strUserId, strPassword, strWhere, strQueryDG, strQueryHT, strQueryDY, strQueryRY, blnControl, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿����Ӧ��δ��Ӷ��������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   ����������
        '     objestateErshouData        ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ����
        '     zengxianglin 2010-01-07 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_YSWSYJB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_YSWSYJB = .getDataSet_BB_YSWSYJB(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿���ֿ�Դ��Ϣ�������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   ����������
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ����
        '     zengxianglin 2010-01-09 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_KYXXB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_KYXXB = .getDataSet_BB_KYXXB(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����н鲿���ַ�Դ��Ϣ�������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   ����������
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ����
        '     zengxianglin 2010-01-09 ����
        '----------------------------------------------------------------
        Public Function getDataSet_BB_FYXXB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_BB_FYXXB = .getDataSet_BB_FYXXB(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_Ӷ����ᡱ��ȫ���ݵ����ݼ�
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_YJJT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateErshouData) As Boolean
            With m_objrulesEstateErshou
                getDataSet_ES_YJJT = .getDataSet_ES_YJJT(strErrMsg, strUserId, strPassword, strWhere, objRetDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_Ӷ����ᡱ����(X4)
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            �������û���
        '     strPassword          �������û�����
        '     strKSRQ              ����ʼ����
        '     strZZRQ              ����������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ����
        '     zengxianglin 2011-01-19 ����
        '----------------------------------------------------------------
        Public Function doSaveData_ES_YJJT_X4( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String) As Boolean
            With m_objrulesEstateErshou
                doSaveData_ES_YJJT_X4 = .doSaveData_ES_YJJT_X4(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ)
            End With
        End Function

    End Class

End Namespace
