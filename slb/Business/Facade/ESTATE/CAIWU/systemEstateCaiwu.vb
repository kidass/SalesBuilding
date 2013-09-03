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
    ' ����    ��systemEstateCaiwu
    '
    ' ���������� 
    '   ���ṩ�Բ�����ı��ֲ�֧��
    '----------------------------------------------------------------
    Public Class systemEstateCaiwu
        Implements System.IDisposable

        Private m_objrulesEstateCaiwu As Josco.JSOA.BusinessRules.rulesEstateCaiwu

        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
            m_objrulesEstateCaiwu = New Josco.JSOA.BusinessRules.rulesEstateCaiwu
        End Sub

        '----------------------------------------------------------------
        ' ��ȫ�ͷű�����Դ
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.systemEstateCaiwu)
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
            If Not (m_objrulesEstateCaiwu Is Nothing) Then
                m_objrulesEstateCaiwu.Dispose()
                m_objrulesEstateCaiwu = Nothing
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
            With Me.m_objrulesEstateCaiwu
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
            With Me.m_objrulesEstateCaiwu
                doExportToExcel = .doExportToExcel(strErrMsg, objDataSet, strExcelFile, strColorFieldName, objColors, strMacroName, strMacroValue, strDateFormat)
            End With
        End Function









        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_Ʊ��ʹ���������ȫ���ݵ����ݼ�
        ' �ԡ��������С�����Ʊ�����š�����Ʊ�ݺ��롱��������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     objestateCaiwuData         ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_PJSY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData) As Boolean
            With m_objrulesEstateCaiwu
                getDataSet_PJSY = .getDataSet_PJSY(strErrMsg, strUserId, strPassword, strWhere, objestateCaiwuData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����Ʊ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strPrefix            ��Ʊ��ǰ����
        '     intMin               ��������ʼ��
        '     intMax               ������������
        '     strPJLX              ��Ʊ������
        '     strFGFH              ���������еĴ���
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-18 add 
        '         ByVal strFFPC As String
        '----------------------------------------------------------------
        Public Function doPiaoju_Fafang( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strPrefix As String, _
            ByVal intMin As Integer, _
            ByVal intMax As Integer, _
            ByVal strPJLX As String, _
            ByVal strFGFH As String, _
            ByVal strFFPC As String) As Boolean
            With m_objrulesEstateCaiwu
                doPiaoju_Fafang = .doPiaoju_Fafang(strErrMsg, strUserId, strPassword, strPrefix, intMin, intMax, strPJLX, strFGFH, strFFPC)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���Ʊ�ݵ�ʹ�����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ҫ��ǵ�Ʊ�ݵġ�Ψһ��ʶ��
        '     objenumPiaojuStatus  ���������
        '     objParams            ���������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doPiaoju_Mark( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal objenumPiaojuStatus As Josco.JSOA.Common.Data.estateCaiwuData.enumPiaojuStatus, _
            ByVal objParams As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateCaiwu
                doPiaoju_Mark = .doPiaoju_Mark(strErrMsg, strUserId, strPassword, strWYBS, objenumPiaojuStatus, objParams)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ��Ʊ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ʊ�ݵ�Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doPiaoju_Delete( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateCaiwu
                doPiaoju_Delete = .doPiaoju_Delete(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' �жϸ�����Ʊ�ݺ����Ƿ�Ϊ�������ߣ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strFGFH              ����������
        '     strPJPH              ����������
        '     strPJHM              ��Ʊ�ݺ���
        '     blnIS                �������Ƿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function isPjhmContinue( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strFGFH As String, _
            ByVal strPJPH As String, _
            ByVal strPJHM As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateCaiwu
                isPjhmContinue = .isPjhmContinue(strErrMsg, strUserId, strPassword, strFGFH, strPJPH, strPJHM, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_����Ӧ��Ӧ������ȫ���ݵ����ݼ�
        ' �ԡ�Ӧ�����ڡ���������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateCaiwuData         ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_YSYF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData) As Boolean
            With m_objrulesEstateCaiwu
                getDataSet_ES_YSYF = .getDataSet_ES_YSYF(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateCaiwuData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_����Ӧ��Ӧ����������
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
        Public Function doSaveData_ES_YSYF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objrulesEstateCaiwu
                doSaveData_ES_YSYF = .doSaveData_ES_YSYF(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_����Ӧ��Ӧ����������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_YSYF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateCaiwu
                doDeleteData_ES_YSYF = .doDeleteData_ES_YSYF(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ģ�崴�����ز�_B_����_����Ӧ��Ӧ����������
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     strMBDM              ��ģ�����
        '     blnClear             �������־
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doMakeYSYF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strMBDM As String, _
            ByVal blnClear As Boolean) As Boolean
            With m_objrulesEstateCaiwu
                doMakeYSYF = .doMakeYSYF(strErrMsg, strUserId, strPassword, strQRSH, strMBDM, blnClear)
            End With
        End Function

        '----------------------------------------------------------------
        ' �жϸ�����ȷ������Ƿ�����ʵ����֧��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     blnIS                �������Ƿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function isFashengShishou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateCaiwu
                isFashengShishou = .isFashengShishou(strErrMsg, strUserId, strPassword, strQRSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���ݡ�ȷ����š���ȡ���ز�_B_����_����ʵ��ʵ������ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ���������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strQRSH                    ��ȷ�����
        '     strWhere                   �������ַ���
        '     objestateCaiwuData         ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData) As Boolean
            With m_objrulesEstateCaiwu
                getDataSet_ES_SSSF = .getDataSet_ES_SSSF(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateCaiwuData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ���桰�ز�_B_����_����ʵ��ʵ����������
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
        Public Function doSaveData_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objrulesEstateCaiwu
                doSaveData_ES_SSSF = .doSaveData_ES_SSSF(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' �����տ�ƻ���ȡ����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objNewData           ����ز���
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doAddNew_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateCaiwu
                doAddNew_ES_SSSF = .doAddNew_ES_SSSF(strErrMsg, strUserId, strPassword, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ָ�����ָ����ʽ��ת����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objNewData           ����ز���
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doJiezhuan_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateCaiwu
                doJiezhuan_ES_SSSF = .doJiezhuan_ES_SSSF(strErrMsg, strUserId, strPassword, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_����ʵ��ʵ������ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ���������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWhere                   �������ַ���
        '     blnUnused                  ���ӿ�����
        '     objestateCaiwuData         ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnUnused As Boolean, _
            ByRef objestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData) As Boolean
            With m_objrulesEstateCaiwu
                getDataSet_ES_SSSF = .getDataSet_ES_SSSF(strErrMsg, strUserId, strPassword, strWhere, blnUnused, objestateCaiwuData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ɾ�����ز�_B_����_����ʵ��ʵ����������(����û�����)
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ψһ��ʶ
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateCaiwu
                doDeleteData_ES_SSSF = .doDeleteData_ES_SSSF(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' �󶨿���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     blnTongguo           ��Trueͨ�����
        '     objNewData           ����ز���
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doShenhe_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal blnTongguo As Boolean, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateCaiwu
                doShenhe_ES_SSSF = .doShenhe_ES_SSSF(strErrMsg, strUserId, strPassword, blnTongguo, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ��ȷ����ı��ý����ݣ��׷����ҷ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     dblBYJ_JF            ���׷����ý�
        '     dblBYJ_YF            ���ҷ����ý�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function getHetongBeiyongjin( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef dblBYJ_JF As Double, _
            ByRef dblBYJ_YF As Double) As Boolean
            With m_objrulesEstateCaiwu
                getHetongBeiyongjin = .getHetongBeiyongjin(strErrMsg, strUserId, strPassword, strQRSH, dblBYJ_JF, dblBYJ_YF)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ��ȷ���顢ָ���ո���־��ָ��˰�ѵĲ���ʵ�����ݣ��׷����ҷ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     strSFBZ              ���ա���
        '     strSFDM              ��˰�Ѵ���
        '     dblBYJ_JF            ���׷����ý�
        '     dblBYJ_YF            ���ҷ����ý�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function getHetongBeiyongjin( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strSFBZ As String, _
            ByVal strSFDM As String, _
            ByRef dblBYJ_JF As Double, _
            ByRef dblBYJ_YF As Double) As Boolean
            With m_objrulesEstateCaiwu
                getHetongBeiyongjin = .getHetongBeiyongjin(strErrMsg, strUserId, strPassword, strQRSH, strSFBZ, strSFDM, dblBYJ_JF, dblBYJ_YF)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ��ȷ���顢ָ���ո���־������ָ��˰�ѵĲ���ʵ�����ݣ��׷����ҷ�
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     strSFBZ              ���ա���
        '     strSFDMList          ��Ҫ�޳���˰�Ѵ���
        '     blnUnused            ���ӿ�����
        '     dblBYJ_JF            ���׷����ý�
        '     dblBYJ_YF            ���ҷ����ý�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function getHetongBeiyongjin( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strSFBZ As String, _
            ByVal strSFDMList As String, _
            ByVal blnUnused As Boolean, _
            ByRef dblBYJ_JF As Double, _
            ByRef dblBYJ_YF As Double) As Boolean
            With m_objrulesEstateCaiwu
                getHetongBeiyongjin = .getHetongBeiyongjin(strErrMsg, strUserId, strPassword, strQRSH, strSFBZ, strSFDMList, blnUnused, dblBYJ_JF, dblBYJ_YF)
            End With
        End Function









        '----------------------------------------------------------------
        ' �����µ�[Ʊ������]
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strFGFH              ����������
        '     strPJPH              ����������(����)
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ��������
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function getNewPjph( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strFGFH As String, _
            ByRef strPJPH As String) As Boolean
            With m_objrulesEstateCaiwu
                getNewPjph = .getNewPjph(strErrMsg, strUserId, strPassword, strFGFH, strPJPH)
            End With
        End Function

        '----------------------------------------------------------------
        ' �жϸ�����Ʊ���Ƿ�Ϊ[��ʹ��]��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ψһ��ʶ
        '     blnIS                �������Ƿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2009-05-17 ����
        '----------------------------------------------------------------
        Public Function isPiaojuUsed( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateCaiwu
                isPiaojuUsed = .isPiaojuUsed(strErrMsg, strUserId, strPassword, strWYBS, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' �жϸ�����Ʊ���Ƿ�Ϊ[������]��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ψһ��ʶ
        '     blnIS                �������Ƿ�
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2009-05-17 ����
        '----------------------------------------------------------------
        Public Function isPiaojuZuofei( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateCaiwu
                isPiaojuZuofei = .isPiaojuZuofei(strErrMsg, strUserId, strPassword, strWYBS, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' Ʊ�ݺ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strWYBS              ��Ҫ��ǵ�Ʊ�ݵġ�Ψһ��ʶ��
        '     strHXRY              ��������Ա
        '     strHXRQ              ����������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ���ļ�¼
        '     zengxianglin 2009-05-17 ����
        '----------------------------------------------------------------
        Public Function doPiaoju_Hexiao( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal strHXRY As String, _
            ByVal strHXRQ As String) As Boolean
            With m_objrulesEstateCaiwu
                doPiaoju_Hexiao = .doPiaoju_Hexiao(strErrMsg, strUserId, strPassword, strWYBS, strHXRY, strHXRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ָ�����ָ����ʽ��ת����
        ' ��ͬ�ͻ�����->�շ���ʱ�Ľ�ת����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objNewData           ����ز���
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ����
        '     zengxianglin 2010-12-30 ����
        '----------------------------------------------------------------
        Public Function doJiezhuan_ES_SSSF_TFX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateCaiwu
                doJiezhuan_ES_SSSF_TFX = .doJiezhuan_ES_SSSF_TFX(strErrMsg, strUserId, strPassword, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ��ָ�����ָ����ʽ��ת����
        ' ��ͬ�ͻ�����->������ʱ�Ľ�ת����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objNewData           ����ز���
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ����
        '     zengxianglin 2010-12-30 ����
        '----------------------------------------------------------------
        Public Function doJiezhuan_ES_SSSF_BTFX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateCaiwu
                doJiezhuan_ES_SSSF_BTFX = .doJiezhuan_ES_SSSF_BTFX(strErrMsg, strUserId, strPassword, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' ����ָ��[ȷ�����][˰�Ѵ���][�ո�����]�����
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     strQRSH              ��ȷ�����
        '     strSFDM              ��˰�Ѵ���
        '     strSFDX              ���ո�����
        '     dblBalance           �����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        ' ����
        '     zengxianglin 2010-12-30 ����
        '----------------------------------------------------------------
        Public Function getBalance( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strSFDM As String, _
            ByVal strSFDX As String, _
            ByRef dblBalance As Double) As Boolean
            With m_objrulesEstateCaiwu
                getBalance = .getBalance(strErrMsg, strUserId, strPassword, strQRSH, strSFDM, strSFDX, dblBalance)
            End With
        End Function

    End Class

End Namespace
