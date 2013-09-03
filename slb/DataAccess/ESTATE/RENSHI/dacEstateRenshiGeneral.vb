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

Namespace Josco.JSOA.DataAccess

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.DataAccess
    ' ����    ��dacEstateRenshiGeneral
    '
    ' ����������
    '     �ṩ��ͨ�����¹������ݵ�������ݲ����
    ' ���ļ�¼��
    '     zengxianglin 2009-05-14 ����
    '     zengxianglin 2009-05-18 ����
    '     zengxianglin 2010-01-06 ����
    '----------------------------------------------------------------

    Public Class dacEstateRenshiGeneral
        Implements IDisposable

        Private m_objSqlDataAdapter As System.Data.SqlClient.SqlDataAdapter








        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
            m_objSqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        End Sub

        '----------------------------------------------------------------
        ' ������������
        '----------------------------------------------------------------
        Public Sub Dispose() Implements IDisposable.Dispose
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
            If Not m_objSqlDataAdapter Is Nothing Then
                m_objSqlDataAdapter.Dispose()
                m_objSqlDataAdapter = Nothing
            End If
        End Sub

        '----------------------------------------------------------------
        ' ��ȫ�ͷű�����Դ
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.DataAccess.dacEstateRenshiGeneral)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
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
            With New Josco.JsKernal.DataAccess.dacExcel
                doExportToExcel = .doExport(strErrMsg, objDataSet, strExcelFile, strMacroName, strMacroValue, strDateFormat)
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
            With New Josco.JsKernal.DataAccess.dacExcel
                doExportToExcel = .doExport(strErrMsg, objDataSet, strExcelFile, strColorFieldName, objColors, strMacroName, strMacroValue, strDateFormat)
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
            With New Josco.JsKernal.DataAccess.dacExcel
                doExcelAddCopy = .doSheetAddCopy(strErrMsg, strSrcFile, strSrcSheet, strDesFile, strDesSheet)
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
            With New Josco.JsKernal.DataAccess.dacExcel
                doExcelSheetDelete = .doSheetDelete(strErrMsg, strSrcFile, strSrcSheet)
            End With
        End Function










        '----------------------------------------------------------------
        ' ��������ֶεĺϷ���
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strNewCode                ���´���
        '     strOldCode                ���ɴ���
        '     strFieldName              �������ֶ���
        '     strTableName              �������ֶ����ڱ���
        '     objenumEditType           ���༭ģʽ
        ' ����
        '     True                      ���ɹ�
        '     False                     ��ʧ��
        '----------------------------------------------------------------
        Public Function doValidCode( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strNewCode As String, _
            ByVal strOldCode As String, _
            ByVal strFieldName As String, _
            ByVal strTableName As String, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim intSegLen As Integer = 3
            Dim strSep As String = "."

            doValidCode = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[doValidCode]û��ָ��[�����û�]��"
                    GoTo errProc
                End If
                If strNewCode Is Nothing Then strNewCode = ""
                strNewCode = strNewCode.Trim
                If strOldCode Is Nothing Then strOldCode = ""
                strOldCode = strOldCode.Trim
                If strFieldName Is Nothing Then strFieldName = ""
                strFieldName = strFieldName.Trim
                If strTableName Is Nothing Then strTableName = ""
                strTableName = strTableName.Trim
                If strTableName = "" Or strFieldName = "" Then
                    strErrMsg = "����[doValidCode]��û��ָ��[������]��"
                    GoTo errProc
                End If
                If strFieldName = "" Then
                    strErrMsg = "����[doValidCode]��û��ָ��[����ֶ���]��"
                    GoTo errProc
                End If

                '���ֵnnn.nnn.nnn.nnn
                Dim strArray() As String
                strArray = strNewCode.Split(strSep.ToCharArray())
                Dim intCount As Integer = 0
                Dim intLen As Integer = 0
                Dim i As Integer = 0
                intCount = strArray.Length
                For i = 1 To intCount Step 1
                    intLen = objPulicParameters.getStringLength(strArray(i - 1))
                    If intLen <> intSegLen Then
                        strErrMsg = "����[doValidCode][" + strFieldName + "]������[" + intSegLen.ToString + "]λ���֣�"
                        GoTo errProc
                    End If
                    If objPulicParameters.isIntegerString(strArray(i - 1)) = False Then
                        strErrMsg = "����[doValidCode][" + strFieldName + "]������[" + intSegLen.ToString + "]λ���֣�"
                        GoTo errProc
                    End If
                Next

                '�����ϼ�����
                Dim strPrevCode As String = ""
                If intCount <= 1 Then
                    strPrevCode = ""
                Else
                    For i = 0 To intCount - 2 Step 1
                        If strPrevCode = "" Then
                            strPrevCode = strArray(i)
                        Else
                            strPrevCode = strPrevCode + strSep + strArray(i)
                        End If
                    Next
                End If

                '�Ƿ�������
                Dim strSQL As String = ""
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                         Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        If strPrevCode <> "" Then
                            strSQL = ""
                            strSQL = strSQL + " select " + strFieldName + " from " + strTableName + vbCr
                            strSQL = strSQL + " where " + strFieldName + " = '" + strPrevCode + "'" + vbCr
                        End If
                    Case Else
                        If strOldCode = strNewCode Then
                            'δ�ı䣡
                            Exit Try
                        End If
                        If strPrevCode <> "" Then
                            strSQL = ""
                            strSQL = strSQL + " select " + strFieldName + " from " + strTableName + vbCr
                            strSQL = strSQL + " where " + strFieldName + " = '" + strPrevCode + "'" + vbCr
                            strSQL = strSQL + " and " + strFieldName + " <> '" + strOldCode + "'" + vbCr
                        End If
                End Select
                If strSQL <> "" Then
                    If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                        GoTo errProc
                    End If
                    With objDataSet
                        If .Tables.Count < 1 Then
                            strErrMsg = "����[doValidCode]�޷���ȡ���ݣ�"
                            GoTo errProc
                        End If
                        If .Tables(0).Rows.Count < 1 Then
                            strErrMsg = "����[doValidCode]���ϼ�����[" + strPrevCode + "]�����ڣ���"
                            GoTo errProc
                        End If
                    End With
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

normExit:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doValidCode = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function











        '----------------------------------------------------------------
        ' ��ȡ������_B_����ְ�ơ���SQL���(�ԡ�ְ�ƴ��롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_JishuZhicheng() As String
            getTableSQL_JishuZhicheng = "select * from ����_B_����ְ�� order by ְ�ƴ���"
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getZcmc = False
            strErrMsg = ""
            strZcmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strZcdm Is Nothing Then strZcdm = ""

                '����
                strSQL = "select dbo.uf_rs_getZhichengName('" + strZcdm + "')"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strZcmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getZcmc = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getZcdm = False
            strErrMsg = ""
            strZcmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strZcmc Is Nothing Then strZcmc = ""

                '����
                strSQL = ""
                strSQL = strSQL + " select * from ����_B_����ְ��" + vbCr
                strSQL = strSQL + " where ְ������ = '" + strZcmc + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strZcmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("ְ�ƴ���"), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getZcdm = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_JishuZhicheng = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '���
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_JISHUZHICHENG)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from ����_B_����ְ�� a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.ְ�ƴ��� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiGeneralData.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_JISHUZHICHENG))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiGeneralData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateRenshiGeneralData = objTempestateRenshiGeneralData
            getDataSet_JishuZhicheng = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰����_B_����ְ�ơ������ݵĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����

        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function doVerifyData_JishuZhicheng( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objListDictionary As System.Collections.Specialized.ListDictionary = Nothing
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim intLen As Integer = 0
            Dim strSQL As String = ""

            doVerifyData_JishuZhicheng = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '��ȡ��ṹ����
                strSQL = "select top 0 * from ����_B_����ְ��"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "����_B_����ְ��", objDataSet) = False Then
                    GoTo errProc
                End If

                '������ݳ���
                Dim intCount As Integer = 0
                Dim strValue As String = ""
                Dim strField As String = ""
                Dim i As Integer = 0
                intCount = objNewData.Count
                For i = 0 To intCount - 1 Step 1
                    strField = objNewData.GetKey(i).Trim
                    strValue = objNewData.Item(i).Trim
                    Select Case strField
                        Case Else
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "����[" + strField + "]���Ȳ��ܳ���[" + .MaxLength.ToString() + "]��ʵ����[" + intLen.ToString() + "]��"
                                    GoTo errProc
                                End If
                            End With
                    End Select
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '��顰ְ�ƴ��롱Լ��
                Dim strOldZCDM As String = ""
                Dim strNewZCDM As String = ""
                strNewZCDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JISHUZHICHENG_ZCDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from ����_B_����ְ�� where ְ�ƴ��� = @zcdm"
                        objListDictionary.Add("@zcdm", strNewZCDM)
                    Case Else
                        strOldZCDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JISHUZHICHENG_ZCDM), "")
                        strSQL = "select * from ����_B_����ְ�� where ְ�ƴ��� = @zcdm and ְ�ƴ��� <> @oldzcdm"
                        objListDictionary.Add("@zcdm", strNewZCDM)
                        objListDictionary.Add("@oldzcdm", strOldZCDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewZCDM + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '��顰ְ�����ơ�Լ��
                Dim strNewZCMC As String = ""
                strNewZCMC = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JISHUZHICHENG_ZCMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from ����_B_����ְ�� where ְ������ = @zcmc"
                        objListDictionary.Add("@zcmc", strNewZCMC)
                    Case Else
                        strSQL = "select * from ����_B_����ְ�� where ְ������ = @zcmc and ְ�ƴ��� <> @oldzcdm"
                        objListDictionary.Add("@zcmc", strNewZCMC)
                        objListDictionary.Add("@oldzcdm", strOldZCDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewZCMC + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '�������ֶ�
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewZCDM, strOldZCDM, "ְ�ƴ���", "����_B_����ְ��", objenumEditType) = False Then
                    GoTo errProc
                End If

                '�ͷ���Դ
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doVerifyData_JishuZhicheng = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_JishuZhicheng = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '�������
                If Me.doVerifyData_JishuZhicheng(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '��������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String = ""
                    Dim strFields As String = ""
                    Dim strValues As String = ""
                    Dim strField As String = ""
                    Dim strValue As String = ""
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField
                                            strValues = "@A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField
                                            strValues = strValues + "," + "@A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " insert into ����_B_����ְ�� (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JISHUZHICHENG_ZCDM), "")

                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField + " = @A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField + " = @A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " update ����_B_����ְ�� set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where ְ�ƴ��� = @oldkey" + vbCr
                    End Select

                    'ִ��SQL
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doSaveData_JishuZhicheng = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_JishuZhicheng = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objOldData Is Nothing Then
                    strErrMsg = "����δ����ɵ����ݣ�"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                'ɾ������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JISHUZHICHENG_ZCDM), "")
                    'ɾ���¼�
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_����ְ�� "
                    strSQL = strSQL + " where ְ�ƴ��� like @oldkey +'.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_����ְ�� "
                    strSQL = strSQL + " where ְ�ƴ��� = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doDeleteData_JishuZhicheng = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function









        '----------------------------------------------------------------
        ' ��ȡ������_B_ѧ�����֡���SQL���(�ԡ�ѧ�����롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_XueliHuafen() As String
            getTableSQL_XueliHuafen = "select * from ����_B_ѧ������ order by ѧ������"
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getXlmc = False
            strErrMsg = ""
            strXlmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strXldm Is Nothing Then strXldm = ""

                '����
                strSQL = "select dbo.uf_rs_getXueliName('" + strXldm + "')"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strXlmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getXlmc = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getXldm = False
            strErrMsg = ""
            strXlmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strXlmc Is Nothing Then strXlmc = ""

                '����
                strSQL = ""
                strSQL = strSQL + " select * from ����_B_ѧ������" + vbCr
                strSQL = strSQL + " where ѧ������ = '" + strXlmc + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strXlmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("ѧ������"), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getXldm = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_XueliHuafen = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '���
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_XUELIHUAFEN)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from ����_B_ѧ������ a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.ѧ������ " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiGeneralData.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUELIHUAFEN))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiGeneralData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateRenshiGeneralData = objTempestateRenshiGeneralData
            getDataSet_XueliHuafen = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰����_B_ѧ�����֡������ݵĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����

        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function doVerifyData_XueliHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objListDictionary As System.Collections.Specialized.ListDictionary = Nothing
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim intLen As Integer = 0
            Dim strSQL As String = ""

            doVerifyData_XueliHuafen = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '��ȡ��ṹ����
                strSQL = "select top 0 * from ����_B_ѧ������"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "����_B_ѧ������", objDataSet) = False Then
                    GoTo errProc
                End If

                '������ݳ���
                Dim intCount As Integer = 0
                Dim strValue As String = ""
                Dim strField As String = ""
                Dim i As Integer = 0
                intCount = objNewData.Count
                For i = 0 To intCount - 1 Step 1
                    strField = objNewData.GetKey(i).Trim
                    strValue = objNewData.Item(i).Trim
                    Select Case strField
                        Case Else
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "����[" + strField + "]���Ȳ��ܳ���[" + .MaxLength.ToString() + "]��ʵ����[" + intLen.ToString() + "]��"
                                    GoTo errProc
                                End If
                            End With
                    End Select
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '��顰ѧ�����롱Լ��
                Dim strOldXLDM As String = ""
                Dim strNewXLDM As String = ""
                strNewXLDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUELIHUAFEN_XLDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from ����_B_ѧ������ where ѧ������ = @xldm"
                        objListDictionary.Add("@xldm", strNewXLDM)
                    Case Else
                        strOldXLDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUELIHUAFEN_XLDM), "")
                        strSQL = "select * from ����_B_ѧ������ where ѧ������ = @xldm and ѧ������ <> @oldxldm"
                        objListDictionary.Add("@xldm", strNewXLDM)
                        objListDictionary.Add("@oldxldm", strOldXLDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewXLDM + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '��顰ѧ�����ơ�Լ��
                Dim strNewXLMC As String = ""
                strNewXLMC = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUELIHUAFEN_XLMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from ����_B_ѧ������ where ѧ������ = @xlmc"
                        objListDictionary.Add("@xlmc", strNewXLMC)
                    Case Else
                        strSQL = "select * from ����_B_ѧ������ where ѧ������ = @xlmc and ѧ������ <> @oldxldm"
                        objListDictionary.Add("@xlmc", strNewXLMC)
                        objListDictionary.Add("@oldxldm", strOldXLDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewXLMC + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '�������ֶ�
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewXLDM, strOldXLDM, "ѧ������", "����_B_ѧ������", objenumEditType) = False Then
                    GoTo errProc
                End If

                '�ͷ���Դ
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doVerifyData_XueliHuafen = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_XueliHuafen = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '�������
                If Me.doVerifyData_XueliHuafen(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '��������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String = ""
                    Dim strFields As String = ""
                    Dim strValues As String = ""
                    Dim strField As String = ""
                    Dim strValue As String = ""
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField
                                            strValues = "@A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField
                                            strValues = strValues + "," + "@A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " insert into ����_B_ѧ������ (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUELIHUAFEN_XLDM), "")

                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField + " = @A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField + " = @A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " update ����_B_ѧ������ set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where ѧ������ = @oldkey" + vbCr
                    End Select

                    'ִ��SQL
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doSaveData_XueliHuafen = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_XueliHuafen = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objOldData Is Nothing Then
                    strErrMsg = "����δ����ɵ����ݣ�"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                'ɾ������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUELIHUAFEN_XLDM), "")
                    'ɾ���¼�
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_ѧ������ "
                    strSQL = strSQL + " where ѧ������ like @oldkey + '.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_ѧ������ "
                    strSQL = strSQL + " where ѧ������ = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doDeleteData_XueliHuafen = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function










        '----------------------------------------------------------------
        ' ��ȡ������_B_ѧλ���֡���SQL���(�ԡ�ѧλ���롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_XueweiHuafen() As String
            getTableSQL_XueweiHuafen = "select * from ����_B_ѧλ���� order by ѧλ����"
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getXwmc = False
            strErrMsg = ""
            strXwmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strXwdm Is Nothing Then strXwdm = ""

                '����
                strSQL = "select dbo.uf_rs_getXueweiName('" + strXwdm + "')"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strXwmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getXwmc = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getXwdm = False
            strErrMsg = ""
            strXwmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strXwmc Is Nothing Then strXwmc = ""

                '����
                strSQL = ""
                strSQL = strSQL + " select * from ����_B_ѧλ����" + vbCr
                strSQL = strSQL + " where ѧλ���� = '" + strXwmc + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strXwmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("ѧλ����"), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getXwdm = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_XueweiHuafen = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '���
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_XUEWEIHUAFEN)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from ����_B_ѧλ���� a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.ѧλ���� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiGeneralData.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUEWEIHUAFEN))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiGeneralData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateRenshiGeneralData = objTempestateRenshiGeneralData
            getDataSet_XueweiHuafen = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰����_B_ѧλ���֡������ݵĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����

        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function doVerifyData_XueweiHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objListDictionary As System.Collections.Specialized.ListDictionary = Nothing
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim intLen As Integer = 0
            Dim strSQL As String = ""

            doVerifyData_XueweiHuafen = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '��ȡ��ṹ����
                strSQL = "select top 0 * from ����_B_ѧλ����"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "����_B_ѧλ����", objDataSet) = False Then
                    GoTo errProc
                End If

                '������ݳ���
                Dim intCount As Integer = 0
                Dim strValue As String = ""
                Dim strField As String = ""
                Dim i As Integer = 0
                intCount = objNewData.Count
                For i = 0 To intCount - 1 Step 1
                    strField = objNewData.GetKey(i).Trim
                    strValue = objNewData.Item(i).Trim
                    Select Case strField
                        Case Else
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "����[" + strField + "]���Ȳ��ܳ���[" + .MaxLength.ToString() + "]��ʵ����[" + intLen.ToString() + "]��"
                                    GoTo errProc
                                End If
                            End With
                    End Select
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '��顰ѧλ���롱Լ��
                Dim strOldXWDM As String = ""
                Dim strNewXWDM As String = ""
                strNewXWDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEWEIHUAFEN_XWDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from ����_B_ѧλ���� where ѧλ���� = @xwdm"
                        objListDictionary.Add("@xwdm", strNewXWDM)
                    Case Else
                        strOldXWDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEWEIHUAFEN_XWDM), "")
                        strSQL = "select * from ����_B_ѧλ���� where ѧλ���� = @xwdm and ѧλ���� <> @oldxwdm"
                        objListDictionary.Add("@xwdm", strNewXWDM)
                        objListDictionary.Add("@oldxwdm", strOldXWDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewXWDM + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '��顰ѧλ���ơ�Լ��
                Dim strNewXWMC As String = ""
                strNewXWMC = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEWEIHUAFEN_XWMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from ����_B_ѧλ���� where ѧλ���� = @xwmc"
                        objListDictionary.Add("@xwmc", strNewXWMC)
                    Case Else
                        strSQL = "select * from ����_B_ѧλ���� where ѧλ���� = @xwmc and ѧλ���� <> @oldxwdm"
                        objListDictionary.Add("@xwmc", strNewXWMC)
                        objListDictionary.Add("@oldxwdm", strOldXWDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewXWMC + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '�������ֶ�
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewXWDM, strOldXWDM, "ѧλ����", "����_B_ѧλ����", objenumEditType) = False Then
                    GoTo errProc
                End If

                '�ͷ���Դ
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doVerifyData_XueweiHuafen = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_XueweiHuafen = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '�������
                If Me.doVerifyData_XueweiHuafen(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '��������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String = ""
                    Dim strFields As String = ""
                    Dim strValues As String = ""
                    Dim strField As String = ""
                    Dim strValue As String = ""
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField
                                            strValues = "@A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField
                                            strValues = strValues + "," + "@A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " insert into ����_B_ѧλ���� (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEWEIHUAFEN_XWDM), "")

                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField + " = @A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField + " = @A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " update ����_B_ѧλ���� set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where ѧλ���� = @oldkey" + vbCr
                    End Select

                    'ִ��SQL
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doSaveData_XueweiHuafen = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_XueweiHuafen = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objOldData Is Nothing Then
                    strErrMsg = "����δ����ɵ����ݣ�"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                'ɾ������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEWEIHUAFEN_XWDM), "")
                    'ɾ���¼�
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_ѧλ���� "
                    strSQL = strSQL + " where ѧλ���� like @oldkey + '.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_ѧλ���� "
                    strSQL = strSQL + " where ѧλ���� = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doDeleteData_XueweiHuafen = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function








        '----------------------------------------------------------------
        ' ��ȡ������_B_������ò����SQL���(�ԡ���ò���롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ZhengzhiMianmao() As String
            getTableSQL_ZhengzhiMianmao = "select * from ����_B_������ò order by ��ò����"
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getMmmc = False
            strErrMsg = ""
            strMmmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strMmdm Is Nothing Then strMmdm = ""

                '����
                strSQL = "select dbo.uf_rs_getZhengzhimianmaoName('" + strMmdm + "')"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strMmmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getMmmc = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getMmdm = False
            strErrMsg = ""
            strMmmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strMmmc Is Nothing Then strMmmc = ""

                '����
                strSQL = ""
                strSQL = strSQL + " select * from ����_B_������ò" + vbCr
                strSQL = strSQL + " where ��ò���� = '" + strMmmc + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strMmmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("��ò����"), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getMmdm = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_ZhengzhiMianmao = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '���
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_ZHENGZHIMIANMAO)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from ����_B_������ò a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.��ò���� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiGeneralData.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_ZHENGZHIMIANMAO))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiGeneralData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateRenshiGeneralData = objTempestateRenshiGeneralData
            getDataSet_ZhengzhiMianmao = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰����_B_������ò�������ݵĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����

        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function doVerifyData_ZhengzhiMianmao( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objListDictionary As System.Collections.Specialized.ListDictionary = Nothing
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim intLen As Integer = 0
            Dim strSQL As String = ""

            doVerifyData_ZhengzhiMianmao = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '��ȡ��ṹ����
                strSQL = "select top 0 * from ����_B_������ò"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "����_B_������ò", objDataSet) = False Then
                    GoTo errProc
                End If

                '������ݳ���
                Dim intCount As Integer = 0
                Dim strValue As String = ""
                Dim strField As String = ""
                Dim i As Integer = 0
                intCount = objNewData.Count
                For i = 0 To intCount - 1 Step 1
                    strField = objNewData.GetKey(i).Trim
                    strValue = objNewData.Item(i).Trim
                    Select Case strField
                        Case Else
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "����[" + strField + "]���Ȳ��ܳ���[" + .MaxLength.ToString() + "]��ʵ����[" + intLen.ToString() + "]��"
                                    GoTo errProc
                                End If
                            End With
                    End Select
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '��顰��ò���롱Լ��
                Dim strOldMMDM As String = ""
                Dim strNewMMDM As String = ""
                strNewMMDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHENGZHIMIANMAO_MMDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from ����_B_������ò where ��ò���� = @mmdm"
                        objListDictionary.Add("@mmdm", strNewMMDM)
                    Case Else
                        strOldMMDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHENGZHIMIANMAO_MMDM), "")
                        strSQL = "select * from ����_B_������ò where ��ò���� = @mmdm and ��ò���� <> @oldmmdm"
                        objListDictionary.Add("@mmdm", strNewMMDM)
                        objListDictionary.Add("@oldmmdm", strOldMMDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewMMDM + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '��顰��ò���ơ�Լ��
                Dim strNewMMMC As String = ""
                strNewMMMC = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHENGZHIMIANMAO_MMMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from ����_B_������ò where ��ò���� = @mmmc"
                        objListDictionary.Add("@mmmc", strNewMMMC)
                    Case Else
                        strSQL = "select * from ����_B_������ò where ��ò���� = @mmmc and ��ò���� <> @oldmmdm"
                        objListDictionary.Add("@mmmc", strNewMMMC)
                        objListDictionary.Add("@oldmmdm", strOldMMDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewMMMC + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '�������ֶ�
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewMMDM, strOldMMDM, "��ò����", "����_B_������ò", objenumEditType) = False Then
                    GoTo errProc
                End If

                '�ͷ���Դ
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doVerifyData_ZhengzhiMianmao = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_ZhengzhiMianmao = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '�������
                If Me.doVerifyData_ZhengzhiMianmao(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '��������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String = ""
                    Dim strFields As String = ""
                    Dim strValues As String = ""
                    Dim strField As String = ""
                    Dim strValue As String = ""
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField
                                            strValues = "@A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField
                                            strValues = strValues + "," + "@A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " insert into ����_B_������ò (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHENGZHIMIANMAO_MMDM), "")

                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField + " = @A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField + " = @A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " update ����_B_������ò set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where ��ò���� = @oldkey" + vbCr
                    End Select

                    'ִ��SQL
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doSaveData_ZhengzhiMianmao = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_ZhengzhiMianmao = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objOldData Is Nothing Then
                    strErrMsg = "����δ����ɵ����ݣ�"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                'ɾ������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHENGZHIMIANMAO_MMDM), "")
                    'ɾ���¼�
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_������ò "
                    strSQL = strSQL + " where ��ò���� like @oldkey + '.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_������ò "
                    strSQL = strSQL + " where ��ò���� = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doDeleteData_ZhengzhiMianmao = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function











        '----------------------------------------------------------------
        ' ��ȡ������_B_ִҵ�ʸ񡱵�SQL���(�ԡ��ʸ���롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ZhiyeZige() As String
            getTableSQL_ZhiyeZige = "select * from ����_B_ִҵ�ʸ� order by �ʸ����"
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getZgmc = False
            strErrMsg = ""
            strZgmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strZgdm Is Nothing Then strZgdm = ""

                '����
                strSQL = "select dbo.uf_rs_getZhiyezigeName('" + strZgdm + "')"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strZgmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getZgmc = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getZgdm = False
            strErrMsg = ""
            strZgmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strZgmc Is Nothing Then strZgmc = ""

                '����
                strSQL = ""
                strSQL = strSQL + " select * from ����_B_ִҵ�ʸ�" + vbCr
                strSQL = strSQL + " where �ʸ����� = '" + strZgmc + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strZgmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("�ʸ����"), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getZgdm = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_ZhiyeZige = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '���
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_ZHIYEZIGE)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from ����_B_ִҵ�ʸ� a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.�ʸ���� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiGeneralData.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_ZHIYEZIGE))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiGeneralData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateRenshiGeneralData = objTempestateRenshiGeneralData
            getDataSet_ZhiyeZige = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰����_B_ִҵ�ʸ񡱵����ݵĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����

        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function doVerifyData_ZhiyeZige( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objListDictionary As System.Collections.Specialized.ListDictionary = Nothing
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim intLen As Integer = 0
            Dim strSQL As String = ""

            doVerifyData_ZhiyeZige = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '��ȡ��ṹ����
                strSQL = "select top 0 * from ����_B_ִҵ�ʸ�"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "����_B_ִҵ�ʸ�", objDataSet) = False Then
                    GoTo errProc
                End If

                '������ݳ���
                Dim intCount As Integer = 0
                Dim strValue As String = ""
                Dim strField As String = ""
                Dim i As Integer = 0
                intCount = objNewData.Count
                For i = 0 To intCount - 1 Step 1
                    strField = objNewData.GetKey(i).Trim
                    strValue = objNewData.Item(i).Trim
                    Select Case strField
                        Case Else
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "����[" + strField + "]���Ȳ��ܳ���[" + .MaxLength.ToString() + "]��ʵ����[" + intLen.ToString() + "]��"
                                    GoTo errProc
                                End If
                            End With
                    End Select
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '��顰�ʸ���롱Լ��
                Dim strOldZGDM As String = ""
                Dim strNewZGDM As String = ""
                strNewZGDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIYEZIGE_ZGDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from ����_B_ִҵ�ʸ� where �ʸ���� = @zgdm"
                        objListDictionary.Add("@zgdm", strNewZGDM)
                    Case Else
                        strOldZGDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIYEZIGE_ZGDM), "")
                        strSQL = "select * from ����_B_ִҵ�ʸ� where �ʸ���� = @zgdm and �ʸ���� <> @oldzgdm"
                        objListDictionary.Add("@zgdm", strNewZGDM)
                        objListDictionary.Add("@oldzgdm", strOldZGDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewZGDM + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '��顰�ʸ����ơ�Լ��
                Dim strNewZGMC As String = ""
                strNewZGMC = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIYEZIGE_ZGMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from ����_B_ִҵ�ʸ� where �ʸ����� = @zgmc"
                        objListDictionary.Add("@zgmc", strNewZGMC)
                    Case Else
                        strSQL = "select * from ����_B_ִҵ�ʸ� where �ʸ����� = @zgmc and �ʸ���� <> @oldzgdm"
                        objListDictionary.Add("@zgmc", strNewZGMC)
                        objListDictionary.Add("@oldzgdm", strOldZGDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewZGMC + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '�������ֶ�
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewZGDM, strOldZGDM, "�ʸ����", "����_B_ִҵ�ʸ�", objenumEditType) = False Then
                    GoTo errProc
                End If

                '�ͷ���Դ
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doVerifyData_ZhiyeZige = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_ZhiyeZige = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '�������
                If Me.doVerifyData_ZhiyeZige(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '��������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String = ""
                    Dim strFields As String = ""
                    Dim strValues As String = ""
                    Dim strField As String = ""
                    Dim strValue As String = ""
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField
                                            strValues = "@A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField
                                            strValues = strValues + "," + "@A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " insert into ����_B_ִҵ�ʸ� (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIYEZIGE_ZGDM), "")

                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField + " = @A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField + " = @A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " update ����_B_ִҵ�ʸ� set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where �ʸ���� = @oldkey" + vbCr
                    End Select

                    'ִ��SQL
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doSaveData_ZhiyeZige = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_ZhiyeZige = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objOldData Is Nothing Then
                    strErrMsg = "����δ����ɵ����ݣ�"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                'ɾ������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIYEZIGE_ZGDM), "")
                    'ɾ���¼�
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_ִҵ�ʸ� "
                    strSQL = strSQL + " where �ʸ���� like @oldkey + '.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_ִҵ�ʸ� "
                    strSQL = strSQL + " where �ʸ���� = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doDeleteData_ZhiyeZige = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function










        '----------------------------------------------------------------
        ' ��ȡ������_B_�䶯ԭ�򡱵�SQL���(�ԡ�ԭ����롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_BiandongYuanyin() As String
            getTableSQL_BiandongYuanyin = "select * from ����_B_�䶯ԭ�� order by ԭ�����"
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getYymc = False
            strErrMsg = ""
            strYymc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strYydm Is Nothing Then strYydm = ""

                '����
                strSQL = "select dbo.uf_rs_getBiandongyuanyinName('" + strYydm + "')"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strYymc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getYymc = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getYydm = False
            strErrMsg = ""
            strYymc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strYymc Is Nothing Then strYymc = ""

                '����
                strSQL = ""
                strSQL = strSQL + " select * from ����_B_�䶯ԭ��" + vbCr
                strSQL = strSQL + " where ԭ������ = '" + strYymc + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strYymc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("ԭ�����"), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getYydm = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_BiandongYuanyin = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '���
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_BIANDONGYUANYIN)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from ����_B_�䶯ԭ�� a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.ԭ����� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiGeneralData.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_BIANDONGYUANYIN))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiGeneralData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateRenshiGeneralData = objTempestateRenshiGeneralData
            getDataSet_BiandongYuanyin = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰����_B_�䶯ԭ�򡱵����ݵĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����

        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function doVerifyData_BiandongYuanyin( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objListDictionary As System.Collections.Specialized.ListDictionary = Nothing
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim intLen As Integer = 0
            Dim strSQL As String = ""

            doVerifyData_BiandongYuanyin = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '��ȡ��ṹ����
                strSQL = "select top 0 * from ����_B_�䶯ԭ��"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "����_B_�䶯ԭ��", objDataSet) = False Then
                    GoTo errProc
                End If

                '������ݳ���
                Dim intCount As Integer = 0
                Dim strValue As String = ""
                Dim strField As String = ""
                Dim i As Integer = 0
                intCount = objNewData.Count
                For i = 0 To intCount - 1 Step 1
                    strField = objNewData.GetKey(i).Trim
                    strValue = objNewData.Item(i).Trim
                    Select Case strField
                        Case Else
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "����[" + strField + "]���Ȳ��ܳ���[" + .MaxLength.ToString() + "]��ʵ����[" + intLen.ToString() + "]��"
                                    GoTo errProc
                                End If
                            End With
                    End Select
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '��顰ԭ����롱Լ��
                Dim strOldYYDM As String = ""
                Dim strNewYYDM As String = ""
                strNewYYDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from ����_B_�䶯ԭ�� where ԭ����� = @yydm"
                        objListDictionary.Add("@yydm", strNewYYDM)
                    Case Else
                        strOldYYDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM), "")
                        strSQL = "select * from ����_B_�䶯ԭ�� where ԭ����� = @yydm and ԭ����� <> @oldyydm"
                        objListDictionary.Add("@yydm", strNewYYDM)
                        objListDictionary.Add("@oldyydm", strOldYYDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewYYDM + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '��顰ԭ�����ơ�Լ��
                Dim strNewYYMC As String = ""
                strNewYYMC = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from ����_B_�䶯ԭ�� where ԭ������ = @yymc"
                        objListDictionary.Add("@yymc", strNewYYMC)
                    Case Else
                        strSQL = "select * from ����_B_�䶯ԭ�� where ԭ������ = @yymc and ԭ����� <> @oldyydm"
                        objListDictionary.Add("@yymc", strNewYYMC)
                        objListDictionary.Add("@oldyydm", strOldYYDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewYYMC + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '�������ֶ�
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewYYDM, strOldYYDM, "ԭ�����", "����_B_�䶯ԭ��", objenumEditType) = False Then
                    GoTo errProc
                End If

                '�ͷ���Դ
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doVerifyData_BiandongYuanyin = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_BiandongYuanyin = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '�������
                If Me.doVerifyData_BiandongYuanyin(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '��������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String = ""
                    Dim strFields As String = ""
                    Dim strValues As String = ""
                    Dim strField As String = ""
                    Dim strValue As String = ""
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField
                                            strValues = "@A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField
                                            strValues = strValues + "," + "@A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " insert into ����_B_�䶯ԭ�� (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM), "")

                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField + " = @A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField + " = @A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " update ����_B_�䶯ԭ�� set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where ԭ����� = @oldkey" + vbCr
                    End Select

                    'ִ��SQL
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doSaveData_BiandongYuanyin = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_BiandongYuanyin = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objOldData Is Nothing Then
                    strErrMsg = "����δ����ɵ����ݣ�"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                'ɾ������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM), "")
                    'ɾ���¼�
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_�䶯ԭ�� "
                    strSQL = strSQL + " where ԭ����� like @oldkey + '.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_�䶯ԭ�� "
                    strSQL = strSQL + " where ԭ����� = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doDeleteData_BiandongYuanyin = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function










        '----------------------------------------------------------------
        ' ��ȡ������_B_ְ�����ԡ���SQL���(�ԡ����Դ��롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ZhigongShuxing() As String
            getTableSQL_ZhigongShuxing = "select * from ����_B_ְ������ order by ���Դ���"
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getSxmc = False
            strErrMsg = ""
            strSxmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strSxdm Is Nothing Then strSxdm = ""

                '����
                strSQL = "select dbo.uf_rs_getZhigongshuxingName('" + strSxdm + "')"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strSxmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getSxmc = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getSxdm = False
            strErrMsg = ""
            strSxmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strSxmc Is Nothing Then strSxmc = ""

                '����
                strSQL = ""
                strSQL = strSQL + " select * from ����_B_ְ������" + vbCr
                strSQL = strSQL + " where �������� = '" + strSxmc + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strSxmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("���Դ���"), "")
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getSxdm = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_ZhigongShuxing = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '���
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_ZHIGONGSHUXING)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from ����_B_ְ������ a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.���Դ��� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiGeneralData.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_ZHIGONGSHUXING))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiGeneralData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateRenshiGeneralData = objTempestateRenshiGeneralData
            getDataSet_ZhigongShuxing = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰����_B_ְ�����ԡ������ݵĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����

        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function doVerifyData_ZhigongShuxing( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objListDictionary As System.Collections.Specialized.ListDictionary = Nothing
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim intLen As Integer = 0
            Dim strSQL As String = ""

            doVerifyData_ZhigongShuxing = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '��ȡ��ṹ����
                strSQL = "select top 0 * from ����_B_ְ������"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "����_B_ְ������", objDataSet) = False Then
                    GoTo errProc
                End If

                '������ݳ���
                Dim intCount As Integer = 0
                Dim strValue As String = ""
                Dim strField As String = ""
                Dim i As Integer = 0
                intCount = objNewData.Count
                For i = 0 To intCount - 1 Step 1
                    strField = objNewData.GetKey(i).Trim
                    strValue = objNewData.Item(i).Trim
                    Select Case strField
                        Case Else
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "����[" + strField + "]���Ȳ��ܳ���[" + .MaxLength.ToString() + "]��ʵ����[" + intLen.ToString() + "]��"
                                    GoTo errProc
                                End If
                            End With
                    End Select
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '��顰���Դ��롱Լ��
                Dim strOldSXDM As String = ""
                Dim strNewSXDM As String = ""
                strNewSXDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIGONGSHUXING_SXDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from ����_B_ְ������ where ���Դ��� = @sxdm"
                        objListDictionary.Add("@sxdm", strNewSXDM)
                    Case Else
                        strOldSXDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIGONGSHUXING_SXDM), "")
                        strSQL = "select * from ����_B_ְ������ where ���Դ��� = @sxdm and ���Դ��� <> @oldsxdm"
                        objListDictionary.Add("@sxdm", strNewSXDM)
                        objListDictionary.Add("@oldsxdm", strOldSXDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewSXDM + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '��顰�������ơ�Լ��
                Dim strNewSXMC As String = ""
                strNewSXMC = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIGONGSHUXING_SXMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from ����_B_ְ������ where �������� = @sxmc"
                        objListDictionary.Add("@sxmc", strNewSXMC)
                    Case Else
                        strSQL = "select * from ����_B_ְ������ where �������� = @sxmc and ���Դ��� <> @oldsxdm"
                        objListDictionary.Add("@sxmc", strNewSXMC)
                        objListDictionary.Add("@oldsxdm", strOldSXDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewSXMC + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '�������ֶ�
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewSXDM, strOldSXDM, "���Դ���", "����_B_ְ������", objenumEditType) = False Then
                    GoTo errProc
                End If

                '�ͷ���Դ
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doVerifyData_ZhigongShuxing = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_ZhigongShuxing = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '�������
                If Me.doVerifyData_ZhigongShuxing(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '��������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String = ""
                    Dim strFields As String = ""
                    Dim strValues As String = ""
                    Dim strField As String = ""
                    Dim strValue As String = ""
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField
                                            strValues = "@A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField
                                            strValues = strValues + "," + "@A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " insert into ����_B_ְ������ (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIGONGSHUXING_SXDM), "")

                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField + " = @A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField + " = @A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " update ����_B_ְ������ set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where ���Դ��� = @oldkey" + vbCr
                    End Select

                    'ִ��SQL
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doSaveData_ZhigongShuxing = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_ZhigongShuxing = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objOldData Is Nothing Then
                    strErrMsg = "����δ����ɵ����ݣ�"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                'ɾ������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIGONGSHUXING_SXDM), "")
                    'ɾ���¼�
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_ְ������ "
                    strSQL = strSQL + " where ���Դ��� like @oldkey + '.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_ְ������ "
                    strSQL = strSQL + " where ���Դ��� = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doDeleteData_ZhigongShuxing = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_RSKP = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_RSKP]δָ��[�����û�]��"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_RENSHIKAPIAN)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from" + vbCr
                        strSQL = strSQL + " (" + vbCr
                        strSQL = strSQL + "   select a.*," + vbCr
                        strSQL = strSQL + "     ��������         = dbo.uf_gg_getZzmcByZzdm(a.����)," + vbCr
                        strSQL = strSQL + "     ����             = abs(datediff(yyyy,getdate(),a.��������))," + vbCr
                        strSQL = strSQL + "     ����״̬����     = dbo.uf_rs_getHukouStatusName(a.����״̬)," + vbCr
                        strSQL = strSQL + "     ����״������     = dbo.uf_rs_getHunyinStatusName(a.����״��)," + vbCr
                        strSQL = strSQL + "     �����������     = dbo.uf_rs_getShengyuStatusName(a.�������)," + vbCr
                        strSQL = strSQL + "     ���ѧ������     = dbo.uf_rs_getXueliName(a.���ѧ��)," + vbCr
                        strSQL = strSQL + "     ���ѧλ����     = dbo.uf_rs_getXueweiName(a.���ѧλ)," + vbCr
                        strSQL = strSQL + "     ����ְ������     = dbo.uf_rs_getZhichengName(a.����ְ��)," + vbCr
                        strSQL = strSQL + "     ִҵ�ʸ�����     = dbo.uf_rs_getZhiyezigeName(a.ִҵ�ʸ�)," + vbCr
                        strSQL = strSQL + "     ������ò����     = dbo.uf_rs_getZhengzhimianmaoName(a.������ò)," + vbCr
                        strSQL = strSQL + "     �Ƿ񹤻��Ա���� = case when a.�Ƿ񹤻��Ա = 1 then @true else @false end," + vbCr
                        strSQL = strSQL + "     �Ƿ��йܸɲ����� = case when a.�Ƿ��йܸɲ� = 1 then @true else @false end," + vbCr
                        strSQL = strSQL + "     ��Ա������������ = dbo.uf_rs_getRenyuanTexingStatusName(a.��Ա��������)," + vbCr
                        strSQL = strSQL + "     ��ס�������     = dbo.uf_rs_getJuzhuStatusName(a.��ס���)," + vbCr
                        strSQL = strSQL + "     �����Ƕ��������� = case when a.�����Ƕ����� = 1 then @true else @false end," + vbCr
                        strSQL = strSQL + "     �Ƿ������֤���� = case when a.�Ƿ������֤ = 1 then @true else @false end," + vbCr
                        strSQL = strSQL + "     �Ƿ��ת�ɲ����� = case when a.�Ƿ��ת�ɲ� = 1 then @true else @false end," + vbCr
                        strSQL = strSQL + "     ��Ա����״̬���� = dbo.uf_rs_getFuyuStatusName(a.��Ա����״̬)," + vbCr
                        strSQL = strSQL + "     ���˷���״̬���� = dbo.uf_rs_getFuyuStatusName(a.���˷���״̬)," + vbCr
                        strSQL = strSQL + "     ����ְ��         = dbo.GetGWMCByRydm(a.��Ա����,@fgf)," + vbCr
                        strSQL = strSQL + "     ְ������         = b.ְ������," + vbCr
                        strSQL = strSQL + "     ְ������         = dbo.uf_estate_rs_getZjmc(b.ְ������)," + vbCr
                        strSQL = strSQL + "     �Ƿ���ְ         = dbo.uf_rs_getShifouZaizhi(a.��Ա����, @jcsj)," + vbCr
                        strSQL = strSQL + "     ת��ʱ��         = c.ת��ʱ��," + vbCr
                        strSQL = strSQL + "     ת��ְλ         = c.ת��ְλ," + vbCr
                        strSQL = strSQL + "     ��ְԭ��         = d.��ְԭ��," + vbCr
                        strSQL = strSQL + "     ��Ů����         = dbo.uf_rs_getZinvShuliang(a.��Ա����)" + vbCr
                        strSQL = strSQL + "   from ����_B_���¿�Ƭ a " + vbCr
                        strSQL = strSQL + "   left join dbo.uf_estate_rs_getValidGuanliJiagou(@jcsj) b on a.��Ա���� = b.��Ա����" + vbCr
                        strSQL = strSQL + "   left join dbo.uf_rs_getZhuanzhengInfo(@jcsj) c on a.��Ա���� = c.��Ա����" + vbCr
                        strSQL = strSQL + "   left join dbo.uf_rs_getLizhiInfo(@jcsj) d on a.��Ա���� = d.��Ա����" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.��Ա���� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@true", Josco.JsKernal.Common.Utilities.PulicParameters.CharTrue)
                        objSqlCommand.Parameters.AddWithValue("@false", Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse)
                        objSqlCommand.Parameters.AddWithValue("@fgf", Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate)
                        objSqlCommand.Parameters.AddWithValue("@jcsj", Now)
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiGeneralData.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_RENSHIKAPIAN))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiGeneralData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateRenshiGeneralData = objTempestateRenshiGeneralData
            getDataSet_RSKP = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_RSKP_JTCY = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_RSKP_JTCY]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_JIATINGCHENGYUAN)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from ����_B_��ͥ��Ա a" + vbCr
                        strSQL = strSQL + " where a.��Ա���� = @rydm" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " and " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.ѪԵ��ϵ " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiGeneralData.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_JIATINGCHENGYUAN))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiGeneralData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateRenshiGeneralData = objTempestateRenshiGeneralData
            getDataSet_RSKP_JTCY = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_RSKP_XXJL = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_RSKP_XXJL]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_XUEXIJINGLI)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from ����_B_ѧϰ���� a" + vbCr
                        strSQL = strSQL + " where a.��Ա���� = @rydm" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " and " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.��ʼ���� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiGeneralData.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUEXIJINGLI))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiGeneralData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateRenshiGeneralData = objTempestateRenshiGeneralData
            getDataSet_RSKP_XXJL = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_RSKP_GZJL = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_RSKP_GZJL]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_GONGZUOJINGLI)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from ����_B_�������� a" + vbCr
                        strSQL = strSQL + " where a.��Ա���� = @rydm" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " and " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.��ʼ���� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiGeneralData.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_GONGZUOJINGLI))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiGeneralData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateRenshiGeneralData = objTempestateRenshiGeneralData
            getDataSet_RSKP_GZJL = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰����_B_���¿�Ƭ�������ݵĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����

        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function doVerifyData_RSKP( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objListDictionary As System.Collections.Specialized.ListDictionary = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim intLen As Integer = 0
            Dim strSQL As String = ""

            doVerifyData_RSKP = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '��ȡ��ṹ����
                strSQL = "select top 0 * from ����_B_���¿�Ƭ"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "����_B_���¿�Ƭ", objDataSet) = False Then
                    GoTo errProc
                End If

                '������ݳ���
                Dim intCount As Integer = 0
                Dim strValue As String = ""
                Dim strField As String = ""
                Dim i As Integer = 0
                intCount = objNewData.Count
                For i = 0 To intCount - 1 Step 1
                    strField = objNewData.GetKey(i).Trim
                    strValue = objNewData.Item(i).Trim
                    Select Case strField
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BMMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_NN, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HKZTMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HYZKMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SYZKMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXLMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXWMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JSZCMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZYZGMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZMMMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFGHCYMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFSGGBMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYQYTXMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JZQKMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BRSDSZMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFLDSZMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFJZGBMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CYFYZTMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYZTMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_DRZW, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZJDM, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZJMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFZZ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZSJ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZZW, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZNSL, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_LZYY
                            '��ʾ��
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_WYBS
                            '�Զ���ֵ
                            If strValue = "" Then
                                If objdacCommon.getNewGUID(strErrMsg, strUserId, strPassword, strValue) = False Then
                                    GoTo errProc
                                End If
                            End If
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYDM, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_XM, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_XB
                            If strValue = "" Then
                                strErrMsg = "����[" + strField + "]û���������ݣ�"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "����[" + strField + "]���Ȳ��ܳ���[" + .MaxLength.ToString() + "]��ʵ����[" + intLen.ToString() + "]��"
                                    GoTo errProc
                                End If
                            End With
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CSRQ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RBDWSJ
                            If strValue = "" Then
                                strErrMsg = "����[" + strField + "]û���������ݣ�"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(strValue) = False Then
                                strErrMsg = "����[" + strField + "]û��������Ч�����ڣ�"
                                GoTo errProc
                            End If

                            'zengxianglin 2009-01-07
                            '����Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ
                            'zengxianglin 2009-01-07
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BYSJ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CJGZSJ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZCQDSJ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RDSJ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYKS, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYJS, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_TXSJ
                            'zengxianglin 2009-01-12
                            '���� Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_TXSJ
                            'zengxianglin 2009-01-12
                            If strValue <> "" Then
                                If objPulicParameters.isDatetimeString(strValue) = False Then
                                    strErrMsg = "����[" + strField + "]û��������Ч�����ڣ�"
                                    GoTo errProc
                                End If
                            End If
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HKZT, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HYZK, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SYZK, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFGHCY, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFSGGB, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYQYTX, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JZQK, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BRSDSZ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFLDSZ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFJZGB, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYZT, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CYFYZT
                            If strValue <> "" Then
                                If objPulicParameters.isIntegerString(strValue) = False Then
                                    strErrMsg = "����[" + strField + "]û��������Ч�����֣�"
                                    GoTo errProc
                                End If
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
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '��顰��Ա���롱Լ��
                Dim strOldRYDM As String = ""
                Dim strNewRYDM As String = ""
                strNewRYDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        strSQL = "select * from ����_B_���¿�Ƭ where ��Ա���� = @rydm"
                        objListDictionary.Add("@rydm", strNewRYDM)
                    Case Else
                        strOldRYDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYDM), "")
                        strSQL = "select * from ����_B_���¿�Ƭ where ��Ա���� = @rydm and ��Ա���� <> @oldrydm"
                        objListDictionary.Add("@rydm", strNewRYDM)
                        objListDictionary.Add("@oldrydm", strOldRYDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewRYDM + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '�ͷ���Դ
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)

                'zengxianglin 2009-01-07
                '�����������
                Dim strValues(2) As String
                strValues(0) = ""
                strValues(0) = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JSZC)
                If strValues(0) Is Nothing Then strValues(0) = ""
                strValues(1) = ""
                strValues(1) = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZCQDSJ)
                If strValues(1) Is Nothing Then strValues(1) = ""
                If strValues(0) <> "" And strValues(1) = "" Then
                    strErrMsg = "����������ָ��[" + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZCQDSJ + "]!"
                    GoTo errProc
                End If
                '***********************************************************************************************************
                strValues(0) = ""
                strValues(0) = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZYZG)
                If strValues(0) Is Nothing Then strValues(0) = ""
                strValues(1) = ""
                strValues(1) = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ)
                If strValues(1) Is Nothing Then strValues(1) = ""
                If strValues(0) <> "" And strValues(1) = "" Then
                    strErrMsg = "����������ָ��[" + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ + "]!"
                    GoTo errProc
                End If
                'zengxianglin 2009-01-07
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doVerifyData_RSKP = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����Http�ļ�
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strOldFileHttpSpec     ����Ƭ�ļ�����HTTP·��
        '     strAppRoot             ��Ӧ�ø�Http·��(����/)
        '     objServer              ������������
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Private Function doHttpBackupFiles( _
            ByRef strErrMsg As String, _
            ByVal strOldFileHttpSpec As String, _
            ByVal strAppRoot As String, _
            ByVal objServer As System.Web.HttpServerUtility) As Boolean

            Dim strBakExt As String = Josco.JsKernal.Common.Utilities.PulicParameters.BACKUPFILEEXT
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            doHttpBackupFiles = False
            strErrMsg = ""

            Try
                '���
                If strOldFileHttpSpec Is Nothing Then strOldFileHttpSpec = ""
                strOldFileHttpSpec = strOldFileHttpSpec.Trim
                If strOldFileHttpSpec = "" Then
                    Exit Try
                End If
                If objServer Is Nothing Then
                    Exit Try
                End If
                If strAppRoot Is Nothing Then strAppRoot = ""
                strAppRoot = strAppRoot.Trim

                '����
                Dim strLocalFile As String = ""
                Dim strHttpFile As String = ""
                strHttpFile = strAppRoot + Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP + strOldFileHttpSpec
                strLocalFile = objServer.MapPath(strHttpFile)
                Dim blnDo As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strLocalFile, blnDo) = False Then
                    Exit Try
                End If
                If blnDo = True Then
                    '�����ļ�
                    If objBaseLocalFile.doCopyFile(strErrMsg, strLocalFile, strLocalFile + strBakExt, True) = False Then
                        GoTo errProc
                    End If
                    'ɾ�������ļ�
                    If objBaseLocalFile.doDeleteFile(strErrMsg, strLocalFile) = False Then
                        '�γ������ļ���
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            doHttpBackupFiles = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ɾ��Http�����ļ�
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strOldFileHttpSpec     ����Ƭ�ļ���ԭHTTP·��
        '     strAppRoot             ��Ӧ�ø�Http·��(����/)
        '     objServer              ������������
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Private Function doHttpDeleteBackupFiles( _
            ByRef strErrMsg As String, _
            ByVal strOldFileHttpSpec As String, _
            ByVal strAppRoot As String, _
            ByVal objServer As System.Web.HttpServerUtility) As Boolean

            Dim strBakExt As String = Josco.JsKernal.Common.Utilities.PulicParameters.BACKUPFILEEXT
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            doHttpDeleteBackupFiles = False
            strErrMsg = ""

            Try
                '���
                If strOldFileHttpSpec Is Nothing Then strOldFileHttpSpec = ""
                strOldFileHttpSpec = strOldFileHttpSpec.Trim
                If strOldFileHttpSpec = "" Then
                    Exit Try
                End If
                If objServer Is Nothing Then
                    Exit Try
                End If
                If strAppRoot Is Nothing Then strAppRoot = ""
                strAppRoot = strAppRoot.Trim

                'ɾ������
                Dim strLocalFile As String = ""
                Dim strHttpFile As String = ""
                strHttpFile = strAppRoot + Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP + strOldFileHttpSpec
                strLocalFile = objServer.MapPath(strHttpFile)
                strLocalFile = strLocalFile + strBakExt
                If objBaseLocalFile.doDeleteFile(strErrMsg, strLocalFile) = False Then
                    '�γ������ļ���
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            doHttpDeleteBackupFiles = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ӱ����лָ�Http�ļ�
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strOldFileHttpSpec     ����Ƭ�ļ���ԭHTTP·��
        '     strAppRoot             ��Ӧ�ø�Http·��(����/)
        '     objServer              ������������
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Private Function doHttpRestoreFiles( _
            ByRef strErrMsg As String, _
            ByVal strOldFileHttpSpec As String, _
            ByVal strAppRoot As String, _
            ByVal objServer As System.Web.HttpServerUtility) As Boolean

            Dim strBakExt As String = Josco.JsKernal.Common.Utilities.PulicParameters.BACKUPFILEEXT
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            doHttpRestoreFiles = False
            strErrMsg = ""

            Try
                '���
                If strOldFileHttpSpec Is Nothing Then strOldFileHttpSpec = ""
                strOldFileHttpSpec = strOldFileHttpSpec.Trim
                If strOldFileHttpSpec = "" Then
                    Exit Try
                End If
                If objServer Is Nothing Then
                    Exit Try
                End If
                If strAppRoot Is Nothing Then strAppRoot = ""
                strAppRoot = strAppRoot.Trim

                '�ָ�
                Dim strLocalFile As String = ""
                Dim strHttpFile As String = ""
                strHttpFile = strAppRoot + Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP + strOldFileHttpSpec
                strLocalFile = objServer.MapPath(strHttpFile)
                '�ָ��ļ�
                If objBaseLocalFile.doCopyFile(strErrMsg, strLocalFile + strBakExt, strLocalFile, True) = False Then
                    GoTo errProc
                End If
                'ɾ������
                If objBaseLocalFile.doDeleteFile(strErrMsg, strLocalFile + strBakExt) = False Then
                    '�γ������ļ�
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            doHttpRestoreFiles = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_���¿�Ƭ��������(��������)
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     objSqlTransaction    ����������
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_RSKP( _
            ByRef strErrMsg As String, _
            ByVal objSqlTransaction As System.Data.SqlClient.SqlTransaction, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            '��ʼ��
            doSaveData_RSKP = False
            strErrMsg = ""

            Try
                '���
                If objSqlTransaction Is Nothing Then
                    strErrMsg = "����δ������������"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '��ȡ����
                objSqlConnection = objSqlTransaction.Connection

                '��������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strFileds As String = ""
                    Dim strValues As String = ""
                    Dim strField As String
                    Dim intCount As Integer
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            '��������ֶ��б�
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BMMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_NN, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HKZTMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HYZKMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SYZKMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXLMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXWMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JSZCMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZYZGMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZMMMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFGHCYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFSGGBMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYQYTXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JZQKMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BRSDSZMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFLDSZMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFJZGBMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CYFYZTMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYZTMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_DRZW, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZJDM, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZJMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFZZ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZZW, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZNSL, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_LZYY
                                        '��ʾ��
                                    Case Else
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
                                End Select
                            Next
                            '׼��SQL
                            strSQL = ""
                            strSQL = strSQL + " insert into ����_B_���¿�Ƭ (" + strFileds + ")"
                            strSQL = strSQL + " values (" + strValues + ")"
                            '׼������
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BMMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_NN, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HKZTMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HYZKMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SYZKMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXLMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXWMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JSZCMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZYZGMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZMMMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFGHCYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFSGGBMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYQYTXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JZQKMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BRSDSZMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFLDSZMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFJZGBMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CYFYZTMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYZTMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_DRZW, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZJDM, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZJMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFZZ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZZW, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZNSL, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_LZYY
                                        '��ʾ��

                                        'zengxianglin 2009-01-07
                                        '����Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ
                                        'zengxianglin 2009-01-07
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CSRQ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RBDWSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BYSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CJGZSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZCQDSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RDSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYKS, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYJS, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_TXSJ
                                        'zengxianglin 2009-01-12
                                        '���� Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_TXSJ
                                        'zengxianglin 2009-01-12
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), System.DateTime))
                                        End If
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HKZT, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HYZK, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SYZK, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFGHCY, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFSGGB, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYQYTX, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JZQK, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BRSDSZ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFLDSZ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFJZGB, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYZT, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CYFYZT
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), 0)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), System.Int32))
                                        End If
                                    Case Else
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), " ")
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), objNewData.Item(i))
                                        End If
                                End Select
                            Next
                            'ִ��SQL
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()

                        Case Else
                            '��ȡԭ��Ψһ��ʶ��
                            Dim strOldWYBS As String
                            strOldWYBS = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_WYBS), "")
                            '��������ֶ��б�
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BMMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_NN, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HKZTMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HYZKMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SYZKMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXLMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXWMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JSZCMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZYZGMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZMMMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFGHCYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFSGGBMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYQYTXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JZQKMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BRSDSZMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFLDSZMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFJZGBMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CYFYZTMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYZTMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_DRZW, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZJDM, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZJMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFZZ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZZW, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZNSL, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_LZYY
                                        '��ʾ��
                                    Case Else
                                        If strFileds = "" Then
                                            strFileds = objNewData.GetKey(i) + " = @A" + i.ToString()
                                        Else
                                            strFileds = strFileds + "," + objNewData.GetKey(i) + " = @A" + i.ToString()
                                        End If
                                End Select
                            Next
                            '׼��SQL
                            strSQL = ""
                            strSQL = strSQL + " update ����_B_���¿�Ƭ set " + vbCr
                            strSQL = strSQL + "   " + strFileds + vbCr
                            strSQL = strSQL + " where Ψһ��ʶ = @oldwybs" + vbCr
                            '׼������
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BMMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_NN, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HKZTMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HYZKMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SYZKMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXLMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGXWMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JSZCMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZYZGMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZMMMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFGHCYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFSGGBMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYQYTXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JZQKMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BRSDSZMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFLDSZMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFJZGBMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CYFYZTMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYZTMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_DRZW, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZJDM, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZJMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFZZ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZZZW, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZNSL, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_LZYY
                                        '��ʾ��

                                        'zengxianglin 2009-01-07
                                        '����Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ
                                        'zengxianglin 2009-01-07
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CSRQ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RBDWSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BYSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CJGZSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZCQDSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RDSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYKS, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYJS, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_TXSJ
                                        'zengxianglin 2009-01-12
                                        '���� Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_TXSJ
                                        'zengxianglin 2009-01-12
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), System.DateTime))
                                        End If
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HKZT, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_HYZK, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SYZK, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFGHCY, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFSGGB, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYQYTX, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JZQK, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_BRSDSZ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFLDSZ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_SFJZGB, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_GRFYZT, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CYFYZT
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), 0)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), System.Int32))
                                        End If
                                    Case Else
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), " ")
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), objNewData.Item(i))
                                        End If
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldwybs", strOldWYBS)
                            'ִ��SQL
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()
                    End Select

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doSaveData_RSKP = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���ݱ����ļ���ȡ��Ƭ�ļ���HTTP�������ļ�������
        ' ����������Ψһ��ʶ+�ļ���չ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strLocalFile         �������ļ���
        '     strWYBS              ��Ψһ��ʶ
        '     strBasePath          �����ļ���ŵ�HTTP��׼·��(/)
        '     strRemoteFile        ������HTTP�������ļ�·��(���ַ�����/)
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Private Function getHTTPNewFileName( _
            ByRef strErrMsg As String, _
            ByVal strLocalFile As String, _
            ByVal strWYBS As String, _
            ByVal strBasePath As String, _
            ByRef strRemoteFile As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            getHTTPNewFileName = False
            strRemoteFile = ""

            Try
                '���
                If strLocalFile Is Nothing Then strLocalFile = ""
                strLocalFile = strLocalFile.Trim()
                If strLocalFile = "" Then
                    Exit Try
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim()
                If strWYBS = "" Then
                    Exit Try
                End If
                If strBasePath Is Nothing Then strBasePath = ""
                strBasePath = strBasePath.Trim
                strBasePath = strBasePath.Replace(Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP, Josco.JsKernal.Common.Utilities.BaseLocalFile.DEFAULT_DIRSEP)

                '��ȡ�ļ���
                Dim strFileName As String = ""
                Dim strFileExt As String = ""
                strFileExt = objBaseLocalFile.getExtension(strLocalFile)

                '������������Դ��ʶ+�ļ���չ��
                strFileName = strWYBS + strFileExt

                '����Ŀ¼+�ļ�
                strFileName = objBaseLocalFile.doMakePath(strBasePath, strFileName)

                'ת���ָ���
                strFileName = strFileName.Replace(Josco.JsKernal.Common.Utilities.BaseLocalFile.DEFAULT_DIRSEP, Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP)
                If strFileName.Substring(0) = Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP Then
                    strFileName = strFileName.Substring(1)
                End If

                '����
                strRemoteFile = strFileName
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            getHTTPNewFileName = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ������Ƭ�ļ�
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     objSqlTransaction      ����������
        '     strUserId              ���û���ʶ
        '     strPassword            ���û�����
        '     strWYBS                ��Ψһ��ʶ
        '     strOldFile             �����ļ�·��(���HTTP��Ŀ¼·��)
        '     strNewFile             ��Ҫ������ļ��ı��ػ����ļ�����·��
        '     strAppRoot             ��Ӧ�ø�Http·��(����/)
        '     strBasePath            ����Ӧ�ø�����ŵص����HTTPĿ¼(��ͷ����/)
        '     objServer              ������������
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_RSKP_File( _
            ByRef strErrMsg As String, _
            ByVal objSqlTransaction As System.Data.SqlClient.SqlTransaction, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal strOldFile As String, _
            ByVal strNewFile As String, _
            ByVal strAppRoot As String, _
            ByVal strBasePath As String, _
            ByVal objServer As System.Web.HttpServerUtility) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim blnNewTrans As Boolean = False
            Dim strWJWZ As String
            Dim strSQL As String

            doSaveData_RSKP_File = False
            strErrMsg = ""

            Try
                '����������
                If objSqlTransaction Is Nothing Then
                    If strUserId Is Nothing Then strUserId = ""
                    strUserId = strUserId.Trim
                    If strUserId = "" Then
                        strErrMsg = "����δ���������û���"
                        GoTo errProc
                    End If
                End If
                If strNewFile Is Nothing Then strNewFile = ""
                strNewFile = strNewFile.Trim()
                If strNewFile = "" Then
                    '���ñ���
                    Exit Try
                End If
                If objServer Is Nothing Then
                    strErrMsg = "����δ����[System.Web.HttpServerUtility]��"
                    GoTo errProc
                End If
                If strAppRoot Is Nothing Then strAppRoot = ""
                strAppRoot = strAppRoot.Trim
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim
                If strWYBS = "" Then
                    Exit Try
                End If
                If strOldFile Is Nothing Then strOldFile = ""
                strOldFile = strOldFile.Trim
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strBasePath Is Nothing Then strBasePath = ""
                strBasePath = strBasePath.Trim

                '����ļ��Ƿ����?
                Dim blnExisted As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strNewFile, blnExisted) = False Then
                    GoTo errProc
                End If
                If blnExisted = False Then
                    strErrMsg = "������Ƭ�ļ�[" + strNewFile + "]�����ڣ�"
                    GoTo errProc
                End If

                '��ȡ�ļ���Ϣ
                strWJWZ = strOldFile

                '��ȡ�������ļ�
                Dim strDesFile As String
                If Me.getHTTPNewFileName(strErrMsg, strNewFile, strWYBS, strBasePath, strDesFile) = False Then
                    GoTo errProc
                End If

                '�����ļ�·��
                '��ȡ��������
                If objSqlTransaction Is Nothing Then
                    If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                        GoTo errProc
                    End If
                Else
                    objSqlConnection = objSqlTransaction.Connection
                End If

                '����ԭ�ļ�
                If Me.doHttpBackupFiles(strErrMsg, strWJWZ, strAppRoot, objServer) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                If objSqlTransaction Is Nothing Then
                    blnNewTrans = True
                    objSqlTransaction = objSqlConnection.BeginTransaction
                Else
                    blnNewTrans = False
                End If

                '�����ļ�
                Dim strHttpFile As String = strAppRoot + Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP + strDesFile
                Dim strLocalFile As String = objServer.MapPath(strHttpFile)
                '����·��
                If objBaseLocalFile.doCreateDirectory(strErrMsg, strLocalFile) = False Then
                    GoTo errProc
                End If
                '�ϴ���HTTP����λ��
                If objBaseLocalFile.doCopyFile(strErrMsg, strNewFile, strLocalFile, True) = False Then
                    GoTo rollDatabaseAndFile
                End If

                Try
                    '׼���������
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '׼��SQL
                    strSQL = ""
                    strSQL = strSQL + " update ����_B_���¿�Ƭ set " + vbCr
                    strSQL = strSQL + "   ��Ա��Ƭλ�� = @wjwz " + vbCr
                    strSQL = strSQL + " where Ψһ��ʶ  = @wjbs " + vbCr
                    strSQL = strSQL + " and   ��Ա��Ƭλ�� <> @wjwz " + vbCr

                    'ִ������
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@wjwz", strDesFile)
                    objSqlCommand.Parameters.AddWithValue("@wjbs", strWYBS)
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
                    If Me.doHttpDeleteBackupFiles(strErrMsg, strWJWZ, strAppRoot, objServer) = False Then
                        '���Բ��ɹ����γ������ļ���
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            If blnNewTrans = True Then
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            End If

            doSaveData_RSKP_File = True
            Exit Function

rollDatabaseAndFile:
            If blnNewTrans = True Then
                objSqlTransaction.Rollback()
                If Me.doHttpRestoreFiles(strSQL, strWJWZ, strAppRoot, objServer) = False Then
                    '���Բ��ɹ����γ���������
                End If
            End If
            GoTo errProc

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            If blnNewTrans = True Then
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            End If
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_��ͥ��Ա��������(��������)
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     objSqlTransaction    ����������
        '     strRYDM              ����Ա����
        '     objDataSet_JTCY      ��Ҫ���������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_RSKP_JTCY( _
            ByRef strErrMsg As String, _
            ByVal objSqlTransaction As System.Data.SqlClient.SqlTransaction, _
            ByVal strRYDM As String, _
            ByVal objDataSet_JTCY As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            '��ʼ��
            doSaveData_RSKP_JTCY = False
            strErrMsg = ""

            Try
                '���
                If objSqlTransaction Is Nothing Then
                    strErrMsg = "����δ������������"
                    GoTo errProc
                End If
                If objDataSet_JTCY Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '��ȡ����
                objSqlConnection = objSqlTransaction.Connection

                '��������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ɾ��ԭ������
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_��ͥ��Ա" + vbCr
                    strSQL = strSQL + " where ��Ա���� = @rydm" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '��������
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    With objDataSet_JTCY.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_JIATINGCHENGYUAN).DefaultView
                        intCount = .Count
                        For i = 0 To intCount - 1 Step 1
                            strSQL = ""
                            strSQL = strSQL + " insert into ����_B_��ͥ��Ա (" + vbCr
                            strSQL = strSQL + "   Ψһ��ʶ,��Ա����,��Ա����,ѪԵ��ϵ,��������,����λ,����ְ��,�־ӵ�ַ" + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   newid(), @rydm, @cyxm, @xygx, @csny, @fwdw, @drzw, @xzdz" + vbCr
                            strSQL = strSQL + " )" + vbCr
                            objSqlCommand.Parameters.Clear()
                            objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                            objSqlCommand.Parameters.AddWithValue("@cyxm", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_CYXM))
                            objSqlCommand.Parameters.AddWithValue("@xygx", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_XYGX))
                            objSqlCommand.Parameters.AddWithValue("@csny", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_CSNY))
                            objSqlCommand.Parameters.AddWithValue("@fwdw", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_FWDW))
                            objSqlCommand.Parameters.AddWithValue("@drzw", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_DRZW))
                            objSqlCommand.Parameters.AddWithValue("@xzdz", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JIATINGCHENGYUAN_XJDZ))
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()
                        Next
                    End With

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doSaveData_RSKP_JTCY = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_ѧϰ������������(��������)
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     objSqlTransaction    ����������
        '     strRYDM              ����Ա����
        '     objDataSet_XXJL      ��Ҫ���������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_RSKP_XXJL( _
            ByRef strErrMsg As String, _
            ByVal objSqlTransaction As System.Data.SqlClient.SqlTransaction, _
            ByVal strRYDM As String, _
            ByVal objDataSet_XXJL As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            '��ʼ��
            doSaveData_RSKP_XXJL = False
            strErrMsg = ""

            Try
                '���
                If objSqlTransaction Is Nothing Then
                    strErrMsg = "����δ������������"
                    GoTo errProc
                End If
                If objDataSet_XXJL Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '��ȡ����
                objSqlConnection = objSqlTransaction.Connection

                '��������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ɾ��ԭ������
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_ѧϰ����" + vbCr
                    strSQL = strSQL + " where ��Ա���� = @rydm" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '��������
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    With objDataSet_XXJL.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUEXIJINGLI).DefaultView
                        intCount = .Count
                        For i = 0 To intCount - 1 Step 1
                            strSQL = ""
                            strSQL = strSQL + " insert into ����_B_ѧϰ���� (" + vbCr
                            strSQL = strSQL + "   Ψһ��ʶ,��Ա����,��ʼ����,��ֹ����,ѧϰ����,ѧϰԺУ,ѧϰרҵ,ѧϰ���" + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   newid(), @rydm, @ksny, @zzny, @xxlx, @xxyx, @xxzy, @xxjg" + vbCr
                            strSQL = strSQL + " )" + vbCr
                            objSqlCommand.Parameters.Clear()
                            objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                            objSqlCommand.Parameters.AddWithValue("@ksny", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_KSNY))
                            objSqlCommand.Parameters.AddWithValue("@zzny", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_ZZNY))
                            objSqlCommand.Parameters.AddWithValue("@xxlx", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_XXLX))
                            objSqlCommand.Parameters.AddWithValue("@xxyx", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_XXYX))
                            objSqlCommand.Parameters.AddWithValue("@xxzy", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_XXZY))
                            objSqlCommand.Parameters.AddWithValue("@xxjg", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEXIJINGLI_XXJG))
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()
                        Next
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doSaveData_RSKP_XXJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_����������������(��������)
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     objSqlTransaction    ����������
        '     strRYDM              ����Ա����
        '     objDataSet_GZJL      ��Ҫ���������
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Public Function doSaveData_RSKP_GZJL( _
            ByRef strErrMsg As String, _
            ByVal objSqlTransaction As System.Data.SqlClient.SqlTransaction, _
            ByVal strRYDM As String, _
            ByVal objDataSet_GZJL As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            '��ʼ��
            doSaveData_RSKP_GZJL = False
            strErrMsg = ""

            Try
                '���
                If objSqlTransaction Is Nothing Then
                    strErrMsg = "����δ������������"
                    GoTo errProc
                End If
                If objDataSet_GZJL Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '��ȡ����
                objSqlConnection = objSqlTransaction.Connection

                '��������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ɾ��ԭ������
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_��������" + vbCr
                    strSQL = strSQL + " where ��Ա���� = @rydm" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '��������
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    With objDataSet_GZJL.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_GONGZUOJINGLI).DefaultView
                        intCount = .Count
                        For i = 0 To intCount - 1 Step 1
                            strSQL = ""
                            strSQL = strSQL + " insert into ����_B_�������� (" + vbCr
                            strSQL = strSQL + "   Ψһ��ʶ,��Ա����,��ʼ����,��ֹ����,����λ,����ְ��" + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   newid(), @rydm, @ksny, @zzny, @fwdw, @drzw" + vbCr
                            strSQL = strSQL + " )" + vbCr
                            objSqlCommand.Parameters.Clear()
                            objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                            objSqlCommand.Parameters.AddWithValue("@ksny", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_GONGZUOJINGLI_KSNY))
                            objSqlCommand.Parameters.AddWithValue("@zzny", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_GONGZUOJINGLI_ZZNY))
                            objSqlCommand.Parameters.AddWithValue("@fwdw", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_GONGZUOJINGLI_FWDW))
                            objSqlCommand.Parameters.AddWithValue("@drzw", .Item(i).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_GONGZUOJINGLI_DRZW))
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()
                        Next
                    End With

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doSaveData_RSKP_GZJL = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim strWJWZ As String = ""
            Dim strSQL As String

            doSaveData_RSKP = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "����δ���������û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����û��ָ��Ҫ��������ݣ�"
                    GoTo errProc
                End If
                If objServer Is Nothing Then
                    strErrMsg = "����û��ָ��[System.Web.HttpServerUtility]��"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strUploadFile Is Nothing Then strUploadFile = ""
                strUploadFile = strUploadFile.Trim
                If strAppRoot Is Nothing Then strAppRoot = ""
                strAppRoot = strAppRoot.Trim
                If strBasePath Is Nothing Then strBasePath = strBasePath.Trim
                strBasePath = strBasePath.Trim

                '�������¼
                If Me.doVerifyData_RSKP(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡ��������
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction

                'ִ������
                Try
                    '��������¼
                    If Me.doSaveData_RSKP(strErrMsg, objSqlTransaction, objOldData, objNewData, objenumEditType) = False Then
                        GoTo rollDatabase
                    End If

                    '��ȡΨһ��ʶ
                    Dim strWYBS As String = objNewData(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_WYBS)
                    Dim strRYDM As String = objNewData(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYDM)

                    '���桰��ͥ��Ա������
                    If Me.doSaveData_RSKP_JTCY(strErrMsg, objSqlTransaction, strRYDM, objDataSet_JTCY) = False Then
                        GoTo rollDatabase
                    End If

                    '���桰ѧϰ����������
                    If Me.doSaveData_RSKP_XXJL(strErrMsg, objSqlTransaction, strRYDM, objDataSet_XXJL) = False Then
                        GoTo rollDatabase
                    End If

                    '���桰��������������
                    If Me.doSaveData_RSKP_GZJL(strErrMsg, objSqlTransaction, strRYDM, objDataSet_GZJL) = False Then
                        GoTo rollDatabase
                    End If

                    '������ͼƬ�ļ�
                    If objOldData Is Nothing Then
                        strWJWZ = ""
                    Else
                        strWJWZ = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYXPWZ), "")
                    End If
                    If strUploadFile <> "" Then
                        If Me.doSaveData_RSKP_File(strErrMsg, objSqlTransaction, strUserId, strPassword, strWYBS, strWJWZ, strUploadFile, strAppRoot, strBasePath, objServer) = False Then
                            GoTo rollDatabaseAndFile
                        End If
                    End If

                    'ɾ�������ļ�
                    If Me.doHttpDeleteBackupFiles(strErrMsg, strWJWZ, strAppRoot, objServer) = False Then
                        '���Բ��ɹ����γ������ļ���
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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doSaveData_RSKP = True
            Exit Function

rollDatabaseAndFile:
            If Me.doHttpRestoreFiles(strSQL, strWJWZ, strAppRoot, objServer) = False Then
                '���Բ��ɹ����γ���������
            End If
            GoTo rollDatabase

rollDatabase:
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_RSKP_PXJL = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_RSKP_PXJL]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_PEIXUNJILU)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        objSqlCommand.Parameters.Clear()
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from" + vbCr
                        strSQL = strSQL + " (" + vbCr
                        strSQL = strSQL + "   select a.*," + vbCr
                        strSQL = strSQL + "     ��Ա���� = dbo.uf_gg_getRyzmByRydm(a.��Ա����)," + vbCr
                        strSQL = strSQL + "     �ڲ���ѵ���� = dbo.uf_rs_getPeixunLeixingName(a.�ڲ���ѵ)" + vbCr
                        strSQL = strSQL + "   from ����_B_��ѵ��¼ a" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strRYDM <> "" Then
                            objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                            strSQL = strSQL + " where a.��Ա���� = @rydm" + vbCr
                            If strWhere <> "" Then
                                strSQL = strSQL + " and " + strWhere + vbCr
                            End If
                        Else
                            If strWhere <> "" Then
                                strSQL = strSQL + " where " + strWhere + vbCr
                            End If
                        End If
                        strSQL = strSQL + " order by a.��ʼʱ�� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiGeneralData.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_PEIXUNJILU))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiGeneralData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateRenshiGeneralData = objTempestateRenshiGeneralData
            getDataSet_RSKP_PXJL = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ȡ������_B_�����춯����ȫ���ݵ����ݼ�(�ԡ���ʼʱ�䡱��������)
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strRYDM                    ����Ա����
        '     strWhere                   �������ַ���
        '     objRetDataSet              ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        ' ����
        '     zengxianglin 2010-01-06 ����
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP_YDJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objRetDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean

            Dim objTempestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_RSKP_YDJL = False
            objRetDataSet = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_RSKP_YDJL]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_RENSHIYIDONG)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        objSqlCommand.Parameters.Clear()
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from" + vbCr
                        strSQL = strSQL + " (" + vbCr
                        strSQL = strSQL + "   select a.*," + vbCr
                        strSQL = strSQL + "     ��Ա����     = dbo.uf_gg_getRyzmByRydm(a.��Ա����)," + vbCr
                        strSQL = strSQL + "     �䶯ԭ������ = dbo.uf_rs_getBiandongyuanyinName(a.�䶯ԭ��)," + vbCr
                        strSQL = strSQL + "     ��ְ��λ���� = dbo.uf_gg_getZzmcByZzdm(a.��ְ��λ)," + vbCr
                        strSQL = strSQL + "     ְ���������� = dbo.uf_rs_getZhigongshuxingName(a.ְ������)," + vbCr
                        strSQL = strSQL + "     ��λ�������� = dbo.uf_rs_getGangweiShuxingName(a.��λ����)," + vbCr
                        strSQL = strSQL + "     �����־���� = dbo.uf_rs_getYidongJibieName(a.�����־)," + vbCr
                        strSQL = strSQL + "     ԭ�ε�λ���� = dbo.uf_gg_getZzmcByZzdm(a.ԭ�ε�λ)," + vbCr
                        'zengxianglin 2010-01-06
                        strSQL = strSQL + "     ԭְ�������� = dbo.uf_rs_getZhigongshuxingName(a.ԭְ����)," + vbCr
                        strSQL = strSQL + "     ԭ���������� = dbo.uf_rs_getGangweiShuxingName(a.ԭ������) " + vbCr
                        'zengxianglin 2010-01-06
                        strSQL = strSQL + "   from ����_B_�����춯 a" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strRYDM <> "" Then
                            objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                            strSQL = strSQL + " where a.��Ա���� = @rydm" + vbCr
                            If strWhere <> "" Then
                                strSQL = strSQL + " and " + strWhere + vbCr
                            End If
                        Else
                            If strWhere <> "" Then
                                strSQL = strSQL + " where " + strWhere + vbCr
                            End If
                        End If
                        strSQL = strSQL + " order by a.��ʼʱ�� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiGeneralData.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_RENSHIYIDONG))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiGeneralData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objRetDataSet = objTempestateRenshiGeneralData
            getDataSet_RSKP_YDJL = True
            Exit Function
errProc:
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_RSKP_LDHT = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_RSKP_LDHT]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_LAODONGHETONG)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        objSqlCommand.Parameters.Clear()
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from" + vbCr
                        strSQL = strSQL + " (" + vbCr
                        strSQL = strSQL + "   select a.*," + vbCr
                        strSQL = strSQL + "     ��Ա����     = dbo.uf_gg_getRyzmByRydm(a.��Ա����)," + vbCr
                        strSQL = strSQL + "     ��ͬ�������� = dbo.uf_rs_getHetongLeixingName(a.��ͬ����)," + vbCr
                        strSQL = strSQL + "     �Ƿ���Լ���� = dbo.uf_rs_getHetongXuyueName(a.�Ƿ���Լ)," + vbCr
                        strSQL = strSQL + "     ��ͬ�ļ����� = case when rtrim(isnull(a.��ͬ�ļ�,'')) = '' then @false else @true end" + vbCr
                        strSQL = strSQL + "   from ����_B_�Ͷ���ͬ a" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strRYDM <> "" Then
                            objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                            strSQL = strSQL + " where a.��Ա���� = @rydm" + vbCr
                            If strWhere <> "" Then
                                strSQL = strSQL + " and " + strWhere + vbCr
                            End If
                        Else
                            If strWhere <> "" Then
                                strSQL = strSQL + " where " + strWhere + vbCr
                            End If
                        End If
                        strSQL = strSQL + " order by a.��ʼʱ�� " + vbCr
                        objSqlCommand.Parameters.AddWithValue("@false", Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse)
                        objSqlCommand.Parameters.AddWithValue("@true", Josco.JsKernal.Common.Utilities.PulicParameters.CharTrue)

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateRenshiGeneralData.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_LAODONGHETONG))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateRenshiGeneralData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateRenshiGeneralData = objTempestateRenshiGeneralData
            getDataSet_RSKP_LDHT = True
            Exit Function
errProc:
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempestateRenshiGeneralData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰����_B_��ѵ��¼�������ݵĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function doVerifyData_RSKP_PXJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objListDictionary As System.Collections.Specialized.ListDictionary = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim intLen As Integer = 0
            Dim strSQL As String = ""

            doVerifyData_RSKP_PXJL = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '��ȡ��ṹ����
                strSQL = "select top 0 * from ����_B_��ѵ��¼"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "����_B_��ѵ��¼", objDataSet) = False Then
                    GoTo errProc
                End If

                '������ݳ���
                Dim intCount As Integer = 0
                Dim strValue As String = ""
                Dim strField As String = ""
                Dim i As Integer = 0
                intCount = objNewData.Count
                For i = 0 To intCount - 1 Step 1
                    strField = objNewData.GetKey(i).Trim
                    strValue = objNewData.Item(i).Trim
                    Select Case strField
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_NBPXMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_RYMC
                            '��ʾ��
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_WYBS
                            '�Զ���
                            If strValue = "" Then
                                If objdacCommon.getNewGUID(strErrMsg, strUserId, strPassword, strValue) = False Then
                                    GoTo errProc
                                End If
                            End If
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_KSSJ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_ZZSJ
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(strValue) = False Then
                                strErrMsg = "����[" + strValue + "]����Ч�����ڣ�"
                                GoTo errProc
                            End If
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_NBPX
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            If objPulicParameters.isIntegerString(strValue) = False Then
                                strErrMsg = "����[" + strValue + "]����Ч�����֣�"
                                GoTo errProc
                            End If


                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_PXKS
                            If strValue <> "" Then
                                If objPulicParameters.isFloatString(strValue) = False Then
                                    strErrMsg = "����[" + strValue + "]����Ч�����֣�"
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_RYDM, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_PXMC
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "����[" + strField + "]���Ȳ��ܳ���[" + .MaxLength.ToString() + "]��ʵ����[" + intLen.ToString() + "]��"
                                    GoTo errProc
                                End If
                            End With
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
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doVerifyData_RSKP_PXJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_RSKP_PXJL = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '�������
                If Me.doVerifyData_RSKP_PXJL(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '��������
                Dim intDefaultInt As Integer = 0
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String = ""
                    Dim strFields As String = ""
                    Dim strValues As String = ""
                    Dim strField As String = ""
                    Dim strValue As String = ""
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_NBPXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_RYMC
                                        '������
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField
                                            strValues = "@A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField
                                            strValues = strValues + "," + "@A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_KSSJ, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_ZZSJ
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, System.DateTime))
                                                End If
                                            Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_NBPX
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), intDefaultInt)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, Integer))
                                                End If

                                            Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_PXKS
                                                If strValue <> "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, Double))
                                                End If
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " insert into ����_B_��ѵ��¼ (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_WYBS), "")

                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_NBPXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_RYMC
                                        '������
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField + " = @A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField + " = @A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_KSSJ, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_ZZSJ
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, System.DateTime))
                                                End If
                                            Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_NBPX
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), intDefaultInt)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, Integer))
                                                End If


                                            Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_PXKS
                                                If strValue <> "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, Double))
                                                End If

                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " update ����_B_��ѵ��¼ set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where Ψһ��ʶ = @oldkey" + vbCr
                    End Select

                    'ִ��SQL
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doSaveData_RSKP_PXJL = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_RSKP_PXJL = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                If strWYBS = "" Then
                    Exit Try
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                'ɾ������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String = strWYBS
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_��ѵ��¼ "
                    strSQL = strSQL + " where Ψһ��ʶ = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doDeleteData_RSKP_PXJL = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰����_B_�����춯�������ݵĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        ' ����
        '     zengxianglin 2010-01-06 ����
        '----------------------------------------------------------------
        Public Function doVerifyData_RSKP_YDJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objListDictionary As System.Collections.Specialized.ListDictionary = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim intLen As Integer = 0
            Dim strSQL As String = ""

            doVerifyData_RSKP_YDJL = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '��ȡ��ṹ����
                strSQL = "select top 0 * from ����_B_�����춯"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "����_B_�����춯", objDataSet) = False Then
                    GoTo errProc
                End If

                '������ݳ���
                Dim intCount As Integer = 0
                Dim strValue As String = ""
                Dim strField As String = ""
                Dim i As Integer = 0
                intCount = objNewData.Count
                For i = 0 To intCount - 1 Step 1
                    strField = objNewData.GetKey(i).Trim
                    strValue = objNewData.Item(i).Trim
                    Select Case strField
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RYMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BDYYMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RZDWMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZGSXMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_GWSXMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YRDWMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_JBBZMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSXMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YZSXMC
                            '��ʾ��
                            'zengxianglin 2010-01-06
                            'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSXMC, _
                            'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YZSXMC
                            'zengxianglin 2010-01-06

                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_WYBS
                            '�Զ���
                            If strValue = "" Then
                                If objdacCommon.getNewGUID(strErrMsg, strUserId, strPassword, strValue) = False Then
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_KSSJ
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(strValue) = False Then
                                strErrMsg = "����[" + strValue + "]����Ч�����ڣ�"
                                GoTo errProc
                            End If
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZZSJ
                            If strValue <> "" Then
                                If objPulicParameters.isDatetimeString(strValue) = False Then
                                    strErrMsg = "����[" + strValue + "]����Ч�����ڣ�"
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_JBBZ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_GWSX, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSX, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BCZB, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_SCZB, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_XSTD, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YSTD
                            'zengxianglin 2010-01-06
                            'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSX, _
                            'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BCZB, _
                            'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_SCZB, _
                            'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_XSTD, _
                            'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YSTD
                            'zengxianglin 2010-01-06
                            If strValue <> "" Then
                                If objPulicParameters.isIntegerString(strValue) = False Then
                                    strErrMsg = "����[" + strValue + "]����Ч�����֣�"
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RYDM, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BDYY, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RZDW
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "����[" + strField + "]���Ȳ��ܳ���[" + .MaxLength.ToString() + "]��ʵ����[" + intLen.ToString() + "]��"
                                    GoTo errProc
                                End If
                            End With

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
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doVerifyData_RSKP_YDJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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
        ' ����
        '     zengxianglin 2010-01-06 ����
        '----------------------------------------------------------------
        Public Function doSaveData_RSKP_YDJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_RSKP_YDJL = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '�������
                If Me.doVerifyData_RSKP_YDJL(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '��������
                Dim intDefaultInt As Integer = 0
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String = ""
                    Dim strFields As String = ""
                    Dim strValues As String = ""
                    Dim strField As String = ""
                    Dim strValue As String = ""
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BDYYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RZDWMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZGSXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_GWSXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YRDWMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_JBBZMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YZSXMC
                                        '��ʾ��
                                        'zengxianglin 2010-01-06
                                        'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSXMC, _
                                        'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YZSXMC
                                        'zengxianglin 2010-01-06

                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField
                                            strValues = "@A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField
                                            strValues = strValues + "," + "@A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_KSSJ, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZZSJ
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, System.DateTime))
                                                End If
                                            Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_JBBZ, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_GWSX, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSX, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BCZB, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_SCZB, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_XSTD, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YSTD
                                                'zengxianglin 2010-01-06
                                                'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSX, _
                                                'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BCZB, _
                                                'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_SCZB, _
                                                'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_XSTD, _
                                                'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YSTD
                                                'zengxianglin 2010-01-06
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), intDefaultInt)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, Integer))
                                                End If
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " insert into ����_B_�����춯 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_WYBS), "")

                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BDYYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RZDWMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZGSXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_GWSXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YRDWMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_JBBZMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YZSXMC
                                        '��ʾ��
                                        'zengxianglin 2010-01-06
                                        'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSXMC, _
                                        'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YZSXMC
                                        'zengxianglin 2010-01-06

                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField + " = @A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField + " = @A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_KSSJ, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZZSJ
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, System.DateTime))
                                                End If
                                            Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_JBBZ, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_GWSX, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSX, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BCZB, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_SCZB, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_XSTD, _
                                                Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YSTD
                                                'zengxianglin 2010-01-06
                                                'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSX, _
                                                'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BCZB, _
                                                'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_SCZB, _
                                                'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_XSTD, _
                                                'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YSTD
                                                'zengxianglin 2010-01-06
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), intDefaultInt)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, Integer))
                                                End If
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " update ����_B_�����춯 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where Ψһ��ʶ = @oldkey" + vbCr
                    End Select

                    'ִ��SQL
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doSaveData_RSKP_YDJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_RSKP_YDJL = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                If strWYBS = "" Then
                    Exit Try
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                'ɾ������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strOldKey As String = strWYBS
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from ����_B_�����춯 "
                    strSQL = strSQL + " where Ψһ��ʶ = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
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

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doDeleteData_RSKP_YDJL = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰����_B_�Ͷ���ͬ�������ݵĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        '----------------------------------------------------------------
        Public Function doVerifyData_RSKP_LDHT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objListDictionary As System.Collections.Specialized.ListDictionary = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim intLen As Integer = 0
            Dim strSQL As String = ""

            doVerifyData_RSKP_LDHT = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '��ȡ��ṹ����
                strSQL = "select top 0 * from ����_B_�Ͷ���ͬ"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "����_B_�Ͷ���ͬ", objDataSet) = False Then
                    GoTo errProc
                End If

                '������ݳ���
                Dim intCount As Integer = 0
                Dim strValue As String = ""
                Dim strField As String = ""
                Dim i As Integer = 0
                intCount = objNewData.Count
                For i = 0 To intCount - 1 Step 1
                    strField = objNewData.GetKey(i).Trim
                    strValue = objNewData.Item(i).Trim
                    Select Case strField
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_RYMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTLXMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SFXYMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTWJMC
                            '��ʾ��
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_WYBS
                            '�Զ���
                            If strValue = "" Then
                                If objdacCommon.getNewGUID(strErrMsg, strUserId, strPassword, strValue) = False Then
                                    GoTo errProc
                                End If
                            End If
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_KSSJ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_JSSJ
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(strValue) = False Then
                                strErrMsg = "����[" + strValue + "]����Ч�����ڣ�"
                                GoTo errProc
                            End If

                            'zengxianglin 2009-01-12
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SYKS, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SYJS
                            If strValue <> "" Then
                                If objPulicParameters.isDatetimeString(strValue) = False Then
                                    strErrMsg = "����[" + strValue + "]����Ч�����ڣ�"
                                    GoTo errProc
                                End If
                            End If
                            'zengxianglin 2009-01-12

                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTLX, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SFXY
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            If objPulicParameters.isIntegerString(strValue) = False Then
                                strErrMsg = "����[" + strValue + "]����Ч�����֣�"
                                GoTo errProc
                            End If
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_RYDM
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "����[" + strField + "]���Ȳ��ܳ���[" + .MaxLength.ToString() + "]��ʵ����[" + intLen.ToString() + "]��"
                                    GoTo errProc
                                End If
                            End With
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
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doVerifyData_RSKP_LDHT = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ɾ��Ftp�����ļ�
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strOldFTPSpec          ��ԭFTP·��
        '     objFTPProperty         ��FTP���Ӳ���
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Private Function doFtpDeleteBackupFiles( _
            ByRef strErrMsg As String, _
            ByVal strOldFTPSpec As String, _
            ByVal objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty) As Boolean

            Dim objBaseFTP As New Josco.JsKernal.Common.Utilities.BaseFTP

            doFtpDeleteBackupFiles = False
            strErrMsg = ""

            Try
                If objBaseFTP.doDeleteBackupFile(strErrMsg, objFTPProperty, strOldFTPSpec) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)

            doFtpDeleteBackupFiles = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' �ӱ�����Ftp�ļ�
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strOldFTPSpec          ��ԭFTP·��
        '     objFTPProperty         ��FTP���Ӳ���
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Private Function doFtpRestoreFiles( _
            ByRef strErrMsg As String, _
            ByVal strOldFTPSpec As String, _
            ByVal objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty) As Boolean

            Dim objBaseFTP As New Josco.JsKernal.Common.Utilities.BaseFTP

            doFtpRestoreFiles = False
            strErrMsg = ""

            Try
                If objBaseFTP.doRestoreFile(strErrMsg, objFTPProperty, strOldFTPSpec) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)

            doFtpRestoreFiles = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ����Ftp�ļ�
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strOldFTPSpec          ��ԭFTP·��
        '     objFTPProperty         ��FTP���Ӳ���
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Private Function doFtpBackupFiles( _
            ByRef strErrMsg As String, _
            ByVal strOldFTPSpec As String, _
            ByVal objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty) As Boolean

            Dim objBaseFTP As New Josco.JsKernal.Common.Utilities.BaseFTP

            doFtpBackupFiles = False
            strErrMsg = ""

            Try
                If objBaseFTP.doBackupFile(strErrMsg, objFTPProperty, strOldFTPSpec) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)

            doFtpBackupFiles = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_�Ͷ���ͬ��������(��������)
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     objSqlTransaction    ����������
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Private Function doSaveData_RSKP_LDHT( _
            ByRef strErrMsg As String, _
            ByVal objSqlTransaction As System.Data.SqlClient.SqlTransaction, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String

            '��ʼ��
            doSaveData_RSKP_LDHT = False
            strErrMsg = ""

            Try
                '���
                If objSqlTransaction Is Nothing Then
                    strErrMsg = "����δ������������"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '��ȡ����
                objSqlConnection = objSqlTransaction.Connection

                '��������
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '����SQL
                    Dim strFileds As String = ""
                    Dim strValues As String = ""
                    Dim strField As String
                    Dim intCount As Integer
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            '��������ֶ��б�
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_RYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTLXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SFXYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTWJMC
                                        '��ʾ��
                                    Case Else
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
                                End Select
                            Next
                            '׼��SQL
                            strSQL = ""
                            strSQL = strSQL + " insert into ����_B_�Ͷ���ͬ (" + strFileds + ")"
                            strSQL = strSQL + " values (" + strValues + ")"
                            '׼������
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_RYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTLXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SFXYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTWJMC
                                        '��ʾ��

                                        'zengxianglin 2009-01-12
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_KSSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_JSSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SYKS, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SYJS
                                        'zengxianglin 2009-01-12
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), System.DateTime))
                                        End If
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTLX, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SFXY
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), 0)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), System.Int32))
                                        End If
                                    Case Else
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), " ")
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), objNewData.Item(i))
                                        End If
                                End Select
                            Next
                            'ִ��SQL
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()

                        Case Else
                            '��ȡԭ��Ψһ��ʶ��
                            Dim strOldWYBS As String
                            strOldWYBS = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_WYBS), "")
                            '��������ֶ��б�
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_RYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTLXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SFXYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTWJMC
                                        '��ʾ��
                                    Case Else
                                        If strFileds = "" Then
                                            strFileds = objNewData.GetKey(i) + " = @A" + i.ToString()
                                        Else
                                            strFileds = strFileds + "," + objNewData.GetKey(i) + " = @A" + i.ToString()
                                        End If
                                End Select
                            Next
                            '׼��SQL
                            strSQL = ""
                            strSQL = strSQL + " update ����_B_�Ͷ���ͬ set " + vbCr
                            strSQL = strSQL + "   " + strFileds + vbCr
                            strSQL = strSQL + " where Ψһ��ʶ = @oldwybs" + vbCr
                            '׼������
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_RYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTLXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SFXYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTWJMC
                                        '��ʾ��

                                        'zengxianglin 2009-01-12
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_KSSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_JSSJ, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SYKS, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SYJS
                                        'zengxianglin 2009-01-12
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), System.DateTime))
                                        End If
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTLX, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SFXY
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), 0)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), System.Int32))
                                        End If
                                    Case Else
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), " ")
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), objNewData.Item(i))
                                        End If
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldwybs", strOldWYBS)
                            'ִ��SQL
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()
                    End Select
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doSaveData_RSKP_LDHT = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���ݱ����ļ���ȡFTP�������ļ�������
        ' ����������Ψһ��ʶ+�ļ���չ��
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strLocalFile         �������ļ���
        '     intWJND              ���ļ����
        '     strWYBS              ��Ψһ��ʶ
        '     strBasePath          ������Ŀ¼
        '     strRemoteFile        ������FTP�������ļ�·��
        ' ����
        '     True                 ���ɹ�
        '     False                ��ʧ��
        '----------------------------------------------------------------
        Private Function getFTPNewFileName( _
            ByRef strErrMsg As String, _
            ByVal strLocalFile As String, _
            ByVal intWJND As Integer, _
            ByVal strWYBS As String, _
            ByVal strBasePath As String, _
            ByRef strRemoteFile As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile

            getFTPNewFileName = False
            strRemoteFile = ""

            Try
                '���
                If strLocalFile Is Nothing Then strLocalFile = ""
                strLocalFile = strLocalFile.Trim()
                If strLocalFile = "" Then
                    Exit Try
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim()
                If strWYBS = "" Then
                    Exit Try
                End If
                If strBasePath Is Nothing Then strBasePath = ""
                strBasePath = strBasePath.Trim

                '��ȡ�ļ���
                Dim strFileName As String = ""
                Dim strFileExt As String = ""
                strFileExt = objBaseLocalFile.getExtension(strLocalFile)

                '�������������Ψһ��ʶ+�ļ���չ��
                strFileName = strWYBS + strFileExt
                strFileName = objBaseLocalFile.doMakePath(intWJND.ToString(), strFileName)

                '����Ŀ¼+�ļ�
                strFileName = objBaseLocalFile.doMakePath(strBasePath, strFileName)

                '����
                strRemoteFile = strFileName

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)

            getFTPNewFileName = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���桰����_B_�Ͷ���ͬ���ġ���ͬ�ļ���
        '     strErrMsg              ����������򷵻ش�����Ϣ
        '     strWYBS                ��Ψһ��ʶ
        '     strOldFtpFile          ��ԭFTP�ļ�
        '     intWJND                ��Ҫ���浽�����
        '     objSqlTransaction      ����������
        '     objFTPProperty         ��FTP���Ӳ���
        '     strNewLocFile          ��Ҫ����ı��ػ����ļ�����·��
        ' ����
        '     True                   ���ɹ�
        '     False                  ��ʧ��
        '----------------------------------------------------------------
        Private Function doSaveData_RSKP_LDHT_File( _
            ByRef strErrMsg As String, _
            ByVal strWYBS As String, _
            ByVal strOldFtpFile As String, _
            ByVal intWJND As Integer, _
            ByVal objSqlTransaction As System.Data.SqlClient.SqlTransaction, _
            ByVal objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty, _
            ByVal strNewLocFile As String) As Boolean

            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objBaseFTP As New Josco.JsKernal.Common.Utilities.BaseFTP
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim blnNewTrans As Boolean = False
            Dim strZWNR As String = ""
            Dim strSQL As String = ""

            doSaveData_RSKP_LDHT_File = False
            strErrMsg = ""

            Try
                '����������
                If strNewLocFile Is Nothing Then strNewLocFile = ""
                strNewLocFile = strNewLocFile.Trim()
                If strNewLocFile = "" Then
                    '���ñ���
                    Exit Try
                End If
                If objFTPProperty Is Nothing Then
                    strErrMsg = "����û��ָ��FTP�����Ӳ�����"
                    GoTo errProc
                End If
                If objSqlTransaction Is Nothing Then
                    strErrMsg = "����û��ָ������"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim
                If strWYBS = "" Then
                    strErrMsg = "����û��ָ��Ψһ��ʶ��"
                    GoTo errProc
                End If
                If strOldFtpFile Is Nothing Then strOldFtpFile = ""
                strOldFtpFile = strOldFtpFile.Trim

                '����ļ��Ƿ����?
                Dim blnExisted As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strNewLocFile, blnExisted) = False Then
                    GoTo errProc
                End If
                If blnExisted = False Then
                    strErrMsg = "���󣺸���ļ�[" + strNewLocFile + "]�����ڣ�"
                    GoTo errProc
                End If

                '��ȡ��Ϣ
                strZWNR = strOldFtpFile

                '��ȡ�������ļ�
                Dim strBasePath As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.FILEDIR_RS_RSKP_LDHT
                Dim strDesFile As String
                If Me.getFTPNewFileName(strErrMsg, strNewLocFile, intWJND, strWYBS, strBasePath, strDesFile) = False Then
                    GoTo errProc
                End If

                '����ԭ�ļ�
                If Me.doFtpBackupFiles(strErrMsg, strZWNR, objFTPProperty) = False Then
                    GoTo errProc
                End If

                '��ȡ��������
                objSqlConnection = objSqlTransaction.Connection

                '�ϴ��ļ�
                Dim strDesUrl As String
                With objFTPProperty
                    strDesUrl = .getUrl(strDesFile)
                    If objBaseFTP.doPutFile(strErrMsg, strNewLocFile, strDesUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        GoTo rollDatabaseAndFile
                    End If
                End With

                Try
                    '׼���������
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout
                    '׼��SQL
                    strSQL = ""
                    strSQL = strSQL + " update ����_B_�Ͷ���ͬ set "
                    strSQL = strSQL + "   ��ͬ�ļ� = @zwnr "
                    strSQL = strSQL + " where Ψһ��ʶ  = @wjbs "
                    strSQL = strSQL + " and   ��ͬ�ļ� <> @zwnr "
                    'ִ������
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@zwnr", strDesFile)
                    objSqlCommand.Parameters.AddWithValue("@wjbs", strWYBS)
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
                    If Me.doFtpDeleteBackupFiles(strErrMsg, strZWNR, objFTPProperty) = False Then
                        '���Բ��ɹ����γ������ļ���
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)

            doSaveData_RSKP_LDHT_File = True
            Exit Function

rollDatabaseAndFile:
            If blnNewTrans = True Then
                objSqlTransaction.Rollback()
                If Me.doFtpRestoreFiles(strSQL, strZWNR, objFTPProperty) = False Then
                    '���Բ��ɹ����γ���������
                End If
            End If
            GoTo errProc

errProc:
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strWJWZ As String = ""
            Dim strSQL As String

            Dim objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty = Nothing
            Dim objdacXitongpeizhi As New Josco.JsKernal.DataAccess.dacXitongpeizhi

            doSaveData_RSKP_LDHT = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "����δ���������û���"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����û��ָ��Ҫ��������ݣ�"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strUploadFile Is Nothing Then strUploadFile = ""
                strUploadFile = strUploadFile.Trim

                '�������¼
                If Me.doVerifyData_RSKP_LDHT(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '��ȡ��������
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡFTP����
                If objdacXitongpeizhi.getFtpServerParam(strErrMsg, strUserId, strPassword, objFTPProperty) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction

                'ִ������
                Try
                    '��������¼
                    If Me.doSaveData_RSKP_LDHT(strErrMsg, objSqlTransaction, objOldData, objNewData, objenumEditType) = False Then
                        GoTo rollDatabase
                    End If

                    '��ȡΨһ��ʶ
                    Dim strWYBS As String = objNewData(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_WYBS)
                    Dim strRYDM As String = objNewData(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYDM)
                    Dim intWJND As Integer = Now.Year

                    '�����ļ�����
                    If objOldData Is Nothing Then
                        strWJWZ = ""
                    Else
                        strWJWZ = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTWJ), "")
                    End If
                    If strUploadFile <> "" Then
                        If Me.doSaveData_RSKP_LDHT_File(strErrMsg, strWYBS, strWJWZ, intWJND, objSqlTransaction, objFTPProperty, strUploadFile) = False Then
                            GoTo rollDatabaseAndFile
                        End If
                    End If

                    'ɾ�������ļ�
                    If Me.doFtpDeleteBackupFiles(strErrMsg, strWJWZ, objFTPProperty) = False Then
                        '���Բ��ɹ����γ������ļ���
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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacXitongpeizhi.SafeRelease(objdacXitongpeizhi)
            Josco.JsKernal.Common.Utilities.FTPProperty.SafeRelease(objFTPProperty)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doSaveData_RSKP_LDHT = True
            Exit Function
rollDatabaseAndFile:
            If Me.doFtpRestoreFiles(strSQL, strWJWZ, objFTPProperty) = False Then
                '���Բ��ɹ����γ���������
            End If
            GoTo rollDatabase
rollDatabase:
            objSqlTransaction.Rollback()
            GoTo errProc
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacXitongpeizhi.SafeRelease(objdacXitongpeizhi)
            Josco.JsKernal.Common.Utilities.FTPProperty.SafeRelease(objFTPProperty)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objDataSet_MAIN As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseFTP As New Josco.JsKernal.Common.Utilities.BaseFTP
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon

            Dim objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty = Nothing
            Dim objdacXitongpeizhi As New Josco.JsKernal.DataAccess.dacXitongpeizhi

            doDeleteData_RSKP_LDHT = False
            strErrMsg = ""

            Try
                '���
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim
                If strWYBS = "" Then
                    '���ô���
                    Exit Try
                End If
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "����û��ָ�������û���"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡFTP����
                If objdacXitongpeizhi.getFtpServerParam(strErrMsg, objSqlConnection, objFTPProperty) = False Then
                    GoTo errProc
                End If

                '��ȡ����¼����
                strSQL = "select * from ����_B_�Ͷ���ͬ where Ψһ��ʶ = '" + strWYBS + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet_MAIN) = False Then
                    GoTo errProc
                End If

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '������
                Dim strFilePath As String = ""
                Dim strUrl As String = ""
                Try
                    'ɾ������¼
                    strSQL = "delete from ����_B_�Ͷ���ͬ where Ψһ��ʶ = '" + strWYBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ������¼�е�FTP�ļ�
                    With objDataSet_MAIN.Tables(0)
                        If .Rows.Count > 0 Then
                            'ɾ������ͬ�ļ�����Ӧ���ļ�
                            strFilePath = objPulicParameters.getObjectValue(.Rows(0).Item("��ͬ�ļ�"), "")
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
                    Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_MAIN)

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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_MAIN)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacXitongpeizhi.SafeRelease(objdacXitongpeizhi)
            Josco.JsKernal.Common.Utilities.FTPProperty.SafeRelease(objFTPProperty)
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doDeleteData_RSKP_LDHT = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_MAIN)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacXitongpeizhi.SafeRelease(objdacXitongpeizhi)
            Josco.JsKernal.Common.Utilities.FTPProperty.SafeRelease(objFTPProperty)
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objDataSet_MAIN As System.Data.DataSet = Nothing
            Dim objDataSet_LDHT As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objBaseFTP As New Josco.JsKernal.Common.Utilities.BaseFTP
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon

            Dim objFTPProperty As Josco.JsKernal.Common.Utilities.FTPProperty = Nothing
            Dim objdacXitongpeizhi As New Josco.JsKernal.DataAccess.dacXitongpeizhi

            doDeleteData_RSKP = False
            strErrMsg = ""

            Try
                '���
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim
                If strWYBS = "" Then
                    '���ô���
                    Exit Try
                End If
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "����û��ָ�������û���"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If objServer Is Nothing Then
                    strErrMsg = "����û��ָ��[System.Web.HttpServerUtility]��"
                    GoTo errProc
                End If
                If strHttpPathPrefix Is Nothing Then strHttpPathPrefix = ""
                strHttpPathPrefix = strHttpPathPrefix.Trim

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡFTP����
                If objdacXitongpeizhi.getFtpServerParam(strErrMsg, objSqlConnection, objFTPProperty) = False Then
                    GoTo errProc
                End If

                '��ȡ����¼����
                strSQL = "select * from ����_B_���¿�Ƭ where Ψһ��ʶ = '" + strWYBS + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet_MAIN) = False Then
                    GoTo errProc
                End If
                Dim strRYDM As String = ""
                With objDataSet_MAIN.Tables(0)
                    If .Rows.Count < 1 Then
                        Exit Try
                    End If
                    strRYDM = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYDM), "")
                End With
                '��ȡ������_B_�Ͷ���ͬ���������
                strSQL = "select * from ����_B_�Ͷ���ͬ where ��Ա���� = '" + strRYDM + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet_LDHT) = False Then
                    GoTo errProc
                End If

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '������
                Dim strFilePath As String = ""
                Dim strUrl As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                Try
                    'ɾ��������_B_��ͥ��Ա��
                    strSQL = "delete from ����_B_��ͥ��Ա where ��Ա���� = '" + strRYDM + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ��������_B_ѧϰ������
                    strSQL = "delete from ����_B_ѧϰ���� where ��Ա���� = '" + strRYDM + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ��������_B_����������
                    strSQL = "delete from ����_B_�������� where ��Ա���� = '" + strRYDM + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ��������_B_��ѵ��¼��
                    strSQL = "delete from ����_B_��ѵ��¼ where ��Ա���� = '" + strRYDM + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ��������_B_�����춯��
                    strSQL = "delete from ����_B_�����춯 where ��Ա���� = '" + strRYDM + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ��������_B_�Ͷ���ͬ��
                    strSQL = "delete from ����_B_�Ͷ���ͬ where ��Ա���� = '" + strRYDM + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ������¼
                    strSQL = "delete from ����_B_���¿�Ƭ where Ψһ��ʶ = '" + strWYBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    'ɾ��FTP�ļ�
                    With objDataSet_LDHT.Tables(0)
                        intCount = .Rows.Count
                        For i = 0 To intCount - 1 Step 1
                            'ɾ������ͬ�ļ�����Ӧ���ļ�
                            strFilePath = objPulicParameters.getObjectValue(.Rows(i).Item("��ͬ�ļ�"), "")
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
                    Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_LDHT)

                    'ɾ��Http�ļ�
                    With objDataSet_MAIN.Tables(0)
                        If .Rows.Count > 0 Then
                            strFilePath = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYXPWZ), "")
                            If strFilePath <> "" Then
                                strFilePath = strHttpPathPrefix + strFilePath
                                strFilePath = objServer.MapPath(strFilePath)
                                If objBaseLocalFile.doDeleteFile(strErrMsg, strFilePath) = False Then
                                    '���Բ��ɹ����γ������ļ���
                                End If
                            End If
                        End If
                    End With
                    Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_MAIN)
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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_MAIN)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_LDHT)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacXitongpeizhi.SafeRelease(objdacXitongpeizhi)
            Josco.JsKernal.Common.Utilities.FTPProperty.SafeRelease(objFTPProperty)
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doDeleteData_RSKP = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_MAIN)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_LDHT)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacXitongpeizhi.SafeRelease(objdacXitongpeizhi)
            Josco.JsKernal.Common.Utilities.FTPProperty.SafeRelease(objFTPProperty)
            Josco.JsKernal.Common.Utilities.BaseFTP.SafeRelease(objBaseFTP)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strDesFile As String = ""
            Dim strWJWZ As String = ""
            Dim strSQL As String

            doCopyFromGRLLToRSKP = False
            strErrMsg = ""

            Try
                '���
                If strGRLLRYDM Is Nothing Then strGRLLRYDM = ""
                strGRLLRYDM = strGRLLRYDM.Trim
                If strGRLLRYDM = "" Then
                    Exit Try
                End If
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "����δ���������û���"
                    GoTo errProc
                End If
                If objServer Is Nothing Then
                    strErrMsg = "����û��ָ��[System.Web.HttpServerUtility]��"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strUploadFile Is Nothing Then strUploadFile = ""
                strUploadFile = strUploadFile.Trim
                If strAppRoot Is Nothing Then strAppRoot = ""
                strAppRoot = strAppRoot.Trim
                If strBasePath Is Nothing Then strBasePath = strBasePath.Trim
                strBasePath = strBasePath.Trim

                '��ȡ��������
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡGUID
                Dim strWYBS As String = ""
                If objdacCommon.getNewGUID(strErrMsg, objSqlConnection, strWYBS) = False Then
                    GoTo errProc
                End If

                '�����ļ���Ŀ��Ŀ¼
                Dim strSep As String = Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP
                Dim strFileName As String = ""
                If strUploadFile <> "" Then
                    If Me.getHTTPNewFileName(strErrMsg, strUploadFile, strWYBS, strBasePath, strFileName) = False Then
                        GoTo errProc
                    End If
                    strDesFile = objServer.MapPath(strAppRoot + strSep + strFileName)
                    If objBaseLocalFile.doCopyFile(strErrMsg, strUploadFile, strDesFile, True) = False Then
                        GoTo errProc
                    End If
                End If

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                'ִ������
                Try
                    '�γɡ�����_B_���¿�Ƭ����¼
                    strSQL = ""
                    strSQL = strSQL + " insert into ����_B_���¿�Ƭ (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,��Ա����,����,�Ա�,��������,�뱾��λʱ��," + vbCr
                    strSQL = strSQL + "   Ӣ������,�ֻ�����,סլ�绰,���֤��," + vbCr
                    strSQL = strSQL + "   ����,����,������ַ,��ס��ַ,��Ա��Ƭλ��," + vbCr
                    strSQL = strSQL + "   ����״��,�������," + vbCr
                    strSQL = strSQL + "   ���ѧ��,���ѧλ,��ҵԺУ,��ҵרҵ,��ҵʱ��," + vbCr
                    strSQL = strSQL + "   ����ְ��,ְ��ȡ��ʱ��," + vbCr
                    strSQL = strSQL + "   ִҵ�ʸ�," + vbCr
                    strSQL = strSQL + "   ������ò,�뵳ʱ��" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=@wybs,��Ա����,����,�Ա�,��������,�뱾��λʱ��=getdate()," + vbCr
                    strSQL = strSQL + "   Ӣ������,�ֻ�����,סլ�绰,���֤��," + vbCr
                    strSQL = strSQL + "   ����,����,������ַ,��ס��ַ,��Ա��Ƭλ��=@ryxpwz," + vbCr
                    strSQL = strSQL + "   ����״��,�������," + vbCr
                    strSQL = strSQL + "   ���ѧ��,���ѧλ,��ҵԺУ,��ҵרҵ,��ҵʱ��," + vbCr
                    strSQL = strSQL + "   ����ְ��,ְ��ȡ��ʱ��," + vbCr
                    strSQL = strSQL + "   ִҵ�ʸ�," + vbCr
                    strSQL = strSQL + "   ������ò,�뵳ʱ��" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_��������" + vbCr
                    strSQL = strSQL + " where ��Ա���� = @rydm" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    objSqlCommand.Parameters.AddWithValue("@ryxpwz", strFileName)
                    objSqlCommand.Parameters.AddWithValue("@rydm", strGRLLRYDM)
                    objSqlCommand.ExecuteNonQuery()

                    '�γɡ�����_B_ѧϰ��������¼
                    strSQL = ""
                    strSQL = strSQL + " insert into ����_B_ѧϰ���� (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,��Ա����," + vbCr
                    strSQL = strSQL + "   ��ʼ����,��ֹ����,ѧϰ����,ѧϰԺУ,ѧϰרҵ,ѧϰ���," + vbCr
                    strSQL = strSQL + "   ��ע��Ϣ" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select " + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=newid(),��Ա����," + vbCr
                    strSQL = strSQL + "   ��ʼ����,��ֹ����,ѧϰ����,ѧϰԺУ,ѧϰרҵ,ѧϰ���," + vbCr
                    strSQL = strSQL + "   ��ע��Ϣ" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_ѧϰ����" + vbCr
                    strSQL = strSQL + " where ��Ա���� = @rydm" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strGRLLRYDM)
                    objSqlCommand.ExecuteNonQuery()

                    '�γɡ�����_B_������������¼
                    strSQL = ""
                    strSQL = strSQL + " insert into ����_B_�������� (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,��Ա����," + vbCr
                    strSQL = strSQL + "   ��ʼ����,��ֹ����,����λ,����ְ��," + vbCr
                    strSQL = strSQL + "   ��ע��Ϣ" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select " + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=newid(),��Ա����," + vbCr
                    strSQL = strSQL + "   ��ʼ����,��ֹ����,����λ,����ְ��," + vbCr
                    strSQL = strSQL + "   ��ע��Ϣ" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_��������" + vbCr
                    strSQL = strSQL + " where ��Ա���� = @rydm" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strGRLLRYDM)
                    objSqlCommand.ExecuteNonQuery()
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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doCopyFromGRLLToRSKP = True
            Exit Function
rollDatabase:
            'ɾ�������ļ�
            Dim strErrMsgA As String
            If strDesFile <> "" Then
                If objBaseLocalFile.doDeleteFile(strErrMsgA, strDesFile) = False Then
                    '����
                End If
            End If
            objSqlTransaction.Rollback()
            GoTo errProc

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objParamDataSet As Josco.JsKernal.Common.Data.DrdcData = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objdacExcel As New Josco.JsKernal.DataAccess.dacExcel
            Dim objExcelFile As New GemBox.ExcelLite.ExcelFile
            Dim strSQL As String = ""

            doPrint_RSBB_RLZYZKDCB = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "����[doPrint_RSBB_RLZYZKDCB]δָ����[�����û�]��"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strExcelFile Is Nothing Then strExcelFile = ""
                strExcelFile = strExcelFile.Trim
                If strExcelFile = "" Then
                    strErrMsg = "����[doPrint_RSBB_RLZYZKDCB]δָ����Excel�ļ���"
                    GoTo errProc
                End If
                Dim blnExisted As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strExcelFile, blnExisted) = False Then
                    GoTo errProc
                End If
                If blnExisted = False Then
                    strErrMsg = "����[doPrint_RSBB_RLZYZKDCB]Excel�ļ�[" + strExcelFile + "]�����ڣ�"
                    GoTo errProc
                End If
                If strJZRQ Is Nothing Then strJZRQ = ""
                strJZRQ = strJZRQ.Trim
                If objPulicParameters.isDatetimeString(strJZRQ) = False Then
                    strErrMsg = "����[doPrint_RSBB_RLZYZKDCB]�����[" + strJZRQ + "]����Ч�����ڣ�"
                    GoTo errProc
                End If
                strJZRQ = CType(strJZRQ, System.DateTime).ToString("yyyy-MM-dd")

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                'װ��Excel
                objExcelFile.LoadXls(strExcelFile)

                '��ȡģ��Sheet������Ϣ
                Dim objFormatSheet As GemBox.ExcelLite.ExcelWorksheet = Nothing
                Dim intSheetCount As Integer
                intSheetCount = objExcelFile.Worksheets.Count
                If intSheetCount < 2 Then
                    strErrMsg = "����[doPrint_RSBB_RLZYZKDCB][" + strExcelFile + "]�ļ���������[2]��Sheet��"
                    GoTo errProc
                End If
                objFormatSheet = objExcelFile.Worksheets(intSheetCount - 1)  '0,1,...
                If objdacExcel.getSheetParamDataSet(strErrMsg, objFormatSheet, intSheetCount, objParamDataSet) = False Then
                    GoTo errProc
                End If

                '�����������Sheet
                Dim objDataSheet As GemBox.ExcelLite.ExcelWorksheet = Nothing
                Dim strCellValue As String = ""
                Dim strSheetName As String = ""
                Dim strTemp As String = ""
                Dim intSheetIndex As Integer
                Dim intTitleRows As Integer
                Dim intDataCols As Integer
                Dim i As Integer
                Dim j As Integer
                Dim k As Integer
                For intSheetIndex = 0 To intSheetCount - 2 Step 1
                    objDataSheet = objExcelFile.Worksheets(intSheetIndex)

                    '��ȡ������
                    intTitleRows = 0
                    intDataCols = 0
                    With objParamDataSet.Tables(Josco.JsKernal.Common.Data.DrdcData.TABLE_TY_B_DRDC_EXCELFORMAT)
                        For i = 0 To .Rows.Count - 1 Step 1
                            strSheetName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.DrdcData.FIELD_TY_B_DRDC_EXCELFORMAT_DATASHEETNAME), "")
                            strSheetName = strSheetName.ToUpper
                            If strSheetName = objDataSheet.Name.ToUpper Then
                                intTitleRows = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.DrdcData.FIELD_TY_B_DRDC_EXCELFORMAT_TITLEROWS), 0)
                                intDataCols = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.DrdcData.FIELD_TY_B_DRDC_EXCELFORMAT_DATACOLS), 0)
                                Exit For
                            End If
                        Next
                    End With
                    If intTitleRows <= 0 Or intDataCols <= 0 Then
                        strErrMsg = "����[doPrint_RSBB_RLZYZKDCB]��ʽSheet�й�������Sheet�Ĳ������ò���ȷ��"
                        GoTo errProc
                    End If

                    '����������
                    If strMacroName <> "" Then
                        Dim strMacroNameArray() As String = strMacroName.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray)
                        Dim strMacroValueArray() As String = strMacroValue.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray)
                        For i = 0 To intTitleRows - 1 Step 1
                            For j = 0 To intDataCols - 1 Step 1
                                For k = 0 To strMacroNameArray.Length - 1 Step 1
                                    strTemp = objPulicParameters.getObjectValue(objDataSheet.Cells(i, j).Value, "")
                                    If strTemp <> "" Then
                                        objDataSheet.Cells(i, j).Value = strTemp.Replace(strMacroNameArray(k), strMacroValueArray(k))
                                    End If
                                Next
                            Next
                        Next
                    End If

                    '����������������
                    Dim strYXRYSql As String = ""
                    Dim dblZRS As Double = 0
                    Dim dblValue As Double

                    '���㱨������
                    For j = 0 To 9 Step 1
                        i = intTitleRows + j

                        Select Case j
                            Case 0 '[ְ��ṹ]�߼�������Ա
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select ��Ա����"
                                strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                                strSQL = strSQL + vbCr + "   where   �����־ = 2"
                                strSQL = strSQL + vbCr + "   and     ��λ���� = 1"
                                strSQL = strSQL + vbCr + "   and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                strSQL = strSQL + vbCr + "   or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "   group by ��Ա����"
                                strYXRYSql = strSQL
                            Case 1 '[ְ��ṹ]�в������Ա
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select ��Ա����"
                                strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                                strSQL = strSQL + vbCr + "   where   �����־ = 1"
                                strSQL = strSQL + vbCr + "   and     ��λ���� = 1"
                                strSQL = strSQL + vbCr + "   and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                strSQL = strSQL + vbCr + "   or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "   group by ��Ա����"
                                strYXRYSql = strSQL
                            Case 2 '[ְ��ṹ]һ��ҵ����Ա
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select ��Ա����"
                                strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                                strSQL = strSQL + vbCr + "   where   �����־ not in (1,2)"
                                strSQL = strSQL + vbCr + "   and     ��λ���� = 1"
                                strSQL = strSQL + vbCr + "   and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                strSQL = strSQL + vbCr + "   or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "   group by ��Ա����"
                                strYXRYSql = strSQL

                            Case 3 '[ѧ���ṹ]��ʿ�о���
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select a.��Ա����"
                                strSQL = strSQL + vbCr + "   from"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select ��Ա����"
                                strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                strSQL = strSQL + vbCr + "     where   ��λ���� = 1"
                                strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "     group by ��Ա����"
                                strSQL = strSQL + vbCr + "   ) a"
                                strSQL = strSQL + vbCr + "   left join"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select ��Ա����"
                                strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                strSQL = strSQL + vbCr + "     where ���ѧ�� = '008'"
                                strSQL = strSQL + vbCr + "     and   ��ҵʱ�� is not null"
                                strSQL = strSQL + vbCr + "     and   ��ҵʱ�� < '" + strJZRQ + "'"
                                strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                strYXRYSql = strSQL
                            Case 4 '[ѧ���ṹ]˶ʿ�о���
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select a.��Ա����"
                                strSQL = strSQL + vbCr + "   from"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select ��Ա����"
                                strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                strSQL = strSQL + vbCr + "     where   ��λ���� = 1"
                                strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "     group by ��Ա����"
                                strSQL = strSQL + vbCr + "   ) a"
                                strSQL = strSQL + vbCr + "   left join"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select ��Ա����"
                                strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                strSQL = strSQL + vbCr + "     where ���ѧ�� = '007'"
                                strSQL = strSQL + vbCr + "     and   ��ҵʱ�� is not null"
                                strSQL = strSQL + vbCr + "     and   ��ҵʱ�� < '" + strJZRQ + "'"
                                strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                strYXRYSql = strSQL
                            Case 5 '[ѧ���ṹ]����
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select a.��Ա����"
                                strSQL = strSQL + vbCr + "   from"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select ��Ա����"
                                strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                strSQL = strSQL + vbCr + "     where   ��λ���� = 1"
                                strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "     group by ��Ա����"
                                strSQL = strSQL + vbCr + "   ) a"
                                strSQL = strSQL + vbCr + "   left join"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select ��Ա����"
                                strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                strSQL = strSQL + vbCr + "     where ���ѧ�� = '006'"
                                strSQL = strSQL + vbCr + "     and   ��ҵʱ�� is not null"
                                strSQL = strSQL + vbCr + "     and   ��ҵʱ�� < '" + strJZRQ + "'"
                                strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                strYXRYSql = strSQL
                            Case 6 '[ѧ���ṹ]ר�Ƽ�����
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select a.��Ա����"
                                strSQL = strSQL + vbCr + "   from"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select ��Ա����"
                                strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                strSQL = strSQL + vbCr + "     where   ��λ���� = 1"
                                strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "     group by ��Ա����"
                                strSQL = strSQL + vbCr + "   ) a"
                                strSQL = strSQL + vbCr + "   left join"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select ��Ա����"
                                strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                strSQL = strSQL + vbCr + "     where ���ѧ�� not in ('008','007','006')"
                                strSQL = strSQL + vbCr + "     and   ��ҵʱ�� is not null"
                                strSQL = strSQL + vbCr + "     and   ��ҵʱ�� < '" + strJZRQ + "'"
                                strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                strYXRYSql = strSQL

                            Case 7 '[����ṹ]45������
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select a.��Ա����"
                                strSQL = strSQL + vbCr + "   from"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select ��Ա����"
                                strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                strSQL = strSQL + vbCr + "     where   ��λ���� = 1"
                                strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "     group by ��Ա����"
                                strSQL = strSQL + vbCr + "   ) a"
                                strSQL = strSQL + vbCr + "   left join"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select ��Ա����"
                                strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                strSQL = strSQL + vbCr + "     where �������� is not null"
                                strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,��������,'" + strJZRQ + "'))+1 >= 45"
                                strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                strYXRYSql = strSQL
                            Case 8 '[����ṹ]35��-45��
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select a.��Ա����"
                                strSQL = strSQL + vbCr + "   from"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select ��Ա����"
                                strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                strSQL = strSQL + vbCr + "     where   ��λ���� = 1"
                                strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "     group by ��Ա����"
                                strSQL = strSQL + vbCr + "   ) a"
                                strSQL = strSQL + vbCr + "   left join"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select ��Ա����"
                                strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                strSQL = strSQL + vbCr + "     where �������� is not null"
                                strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,��������,'" + strJZRQ + "'))+1 >= 35"
                                strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,��������,'" + strJZRQ + "'))+1 <  45"
                                strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                strYXRYSql = strSQL
                            Case 9 '[����ṹ]35������
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select a.��Ա����"
                                strSQL = strSQL + vbCr + "   from"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select ��Ա����"
                                strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                strSQL = strSQL + vbCr + "     where   ��λ���� = 1"
                                strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "     group by ��Ա����"
                                strSQL = strSQL + vbCr + "   ) a"
                                strSQL = strSQL + vbCr + "   left join"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select ��Ա����"
                                strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                strSQL = strSQL + vbCr + "     where �������� is not null"
                                strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,��������,'" + strJZRQ + "'))+1 <  35"
                                strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                strYXRYSql = strSQL
                        End Select

                        '����ָ��������
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 2).Value = dblValue

                        '����������
                        If j <= 2 Then dblZRS = dblZRS + dblValue

                        '���㵳Ա��
                        If j >= 7 And j <= 9 Then
                            '�������ݲ�����
                        Else
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select ��Ա����"
                            strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                            strSQL = strSQL + vbCr + "   where ������ò = '001'"
                            strSQL = strSQL + vbCr + "   and   �뵳ʱ�� is not null"
                            strSQL = strSQL + vbCr + "   and   �뵳ʱ�� <= '" + strJZRQ + "'"
                            strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                            strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 5).Value = dblValue
                        End If

                        '����������ʦ
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where ְ��ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   ְ��ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ����ְ�� = '003.003'"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 6).Value = dblValue
                        '���㾭��ʦ
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where ְ��ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   ְ��ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ����ְ�� = '003.002'"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 7).Value = dblValue
                        '����߼�����ʦ
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where ְ��ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   ְ��ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ����ְ�� = '003.001'"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 8).Value = dblValue

                        '����������ʦ
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where ְ��ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   ְ��ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ����ְ�� = '002.005'"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 9).Value = dblValue
                        '���㹤��ʦ
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where ְ��ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   ְ��ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ����ְ�� = '002.004'"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 10).Value = dblValue
                        '����߼�����ʦ
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where ְ��ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   ְ��ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ����ְ�� in ('002.001','002.002','002.003')"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 11).Value = dblValue

                        '����������ʦ
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where ְ��ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   ְ��ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ����ְ�� = '004.003'"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 12).Value = dblValue
                        '������ʦ
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where ְ��ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   ְ��ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ����ְ�� = '004.002'"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 13).Value = dblValue
                        '����߼����ʦ
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where ְ��ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   ְ��ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ����ְ�� = '004.001'"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 14).Value = dblValue

                        '��������-����
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where ְ��ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   ְ��ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ����ְ�� = '005.003'"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 15).Value = dblValue
                        '��������-�м�
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where ְ��ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   ְ��ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ����ְ�� = '005.002'"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 16).Value = dblValue
                        '��������-�߼�
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where ְ��ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   ְ��ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ����ְ�� = '005.001'"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 17).Value = dblValue

                        '����ִҵ�ʸ�-����
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where �ʸ�ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   �ʸ�ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ִҵ�ʸ� = '001.001.003'"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 18).Value = dblValue
                        '����ִҵ�ʸ�-�м�
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where �ʸ�ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   �ʸ�ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ִҵ�ʸ� = '001.001.002'"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 19).Value = dblValue
                        '����ִҵ�ʸ�-�߼�
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select ��Ա����"
                        strSQL = strSQL + vbCr + "   from ����_B_���¿�Ƭ"
                        strSQL = strSQL + vbCr + "   where �ʸ�ȡ��ʱ�� is not null"
                        strSQL = strSQL + vbCr + "   and   �ʸ�ȡ��ʱ�� <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   ִҵ�ʸ� = '001.001.001'"
                        strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                        strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 20).Value = dblValue
                    Next

                    '���������
                    objDataSheet.Cells(intTitleRows, 3).Value = dblZRS
                    objDataSheet.Cells(intTitleRows + 7, 4).Value = "n/a"
                    objDataSheet.Cells(intTitleRows + 7, 5).Value = "n/a"
                Next

                '����Excel
                objExcelFile.SaveXls(strExcelFile)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Data.DrdcData.SafeRelease(objParamDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Josco.JsKernal.DataAccess.dacExcel.SafeRelease(objdacExcel)
            objExcelFile = Nothing

            doPrint_RSBB_RLZYZKDCB = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Data.DrdcData.SafeRelease(objParamDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Josco.JsKernal.DataAccess.dacExcel.SafeRelease(objdacExcel)
            objExcelFile = Nothing
            Exit Function

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

            Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_BB_RYZJYDB = False
            objDataSet = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_BB_RYZJYDB]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strKSRQ Is Nothing Then strKSRQ = ""
                strKSRQ = strKSRQ.Trim
                If objPulicParameters.isDatetimeString(strKSRQ) = False Then
                    strErrMsg = "����[getDataSet_BB_RYZJYDB]ָ����[" + strKSRQ + "]��Ч��"
                    GoTo errProc
                End If
                If strZZRQ Is Nothing Then strZZRQ = ""
                strZZRQ = strZZRQ.Trim
                If objPulicParameters.isDatetimeString(strZZRQ) = False Then
                    strErrMsg = "����[getDataSet_BB_RYZJYDB]ָ����[" + strZZRQ + "]��Ч��"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempDataSet = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_VT_RYZJYDB)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        strSQL = ""
                        strSQL = strSQL + " select a.* from dbo.uf_rs_getRYZJYDB(@ksrq, @zzrq) a order by a.��¼���" + vbCr
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@ksrq", strKSRQ)
                        objSqlCommand.Parameters.AddWithValue("@zzrq", strZZRQ)
                        .SelectCommand = objSqlCommand
                        .Fill(objTempDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_VT_RYZJYDB))
                    End With
                    '���
                    If objTempDataSet.Tables.Count < 1 Then
                        Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempDataSet)
                    End If
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objDataSet = objTempDataSet
            getDataSet_BB_RYZJYDB = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempDataSet)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objParamDataSet As Josco.JsKernal.Common.Data.DrdcData = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objdacExcel As New Josco.JsKernal.DataAccess.dacExcel
            Dim objExcelFile As New GemBox.ExcelLite.ExcelFile
            Dim strSQL As String = ""

            doPrint_RSBB_RYZJYDB = False
            strErrMsg = ""

            Try
                '���
                If objDataSet Is Nothing Then
                    strErrMsg = "����[doPrint_RSBB_RYZJYDB]δָ���Ĵ�ӡ���ݣ�"
                    GoTo errProc
                End If
                If objDataSet.Tables.Count < 1 Then
                    strErrMsg = "����[doPrint_RSBB_RYZJYDB]δָ���Ĵ�ӡ���ݣ�"
                    GoTo errProc
                End If
                If strExcelFile Is Nothing Then strExcelFile = ""
                strExcelFile = strExcelFile.Trim
                If strExcelFile = "" Then
                    strErrMsg = "����[doPrint_RSBB_RYZJYDB]δָ����Excel�ļ���"
                    GoTo errProc
                End If
                Dim blnExisted As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strExcelFile, blnExisted) = False Then
                    GoTo errProc
                End If
                If blnExisted = False Then
                    strErrMsg = "����[doPrint_RSBB_RYZJYDB]Excel�ļ�[" + strExcelFile + "]�����ڣ�"
                    GoTo errProc
                End If

                'װ��Excel
                objExcelFile.LoadXls(strExcelFile)

                '��ȡģ��Sheet������Ϣ
                Dim objFormatSheet As GemBox.ExcelLite.ExcelWorksheet = Nothing
                Dim intSheetCount As Integer
                intSheetCount = objExcelFile.Worksheets.Count
                If intSheetCount < 2 Then
                    strErrMsg = "����[doPrint_RSBB_RYZJYDB][" + strExcelFile + "]�ļ���������[2]��Sheet��"
                    GoTo errProc
                End If
                objFormatSheet = objExcelFile.Worksheets(intSheetCount - 1)  '0,1,...
                If objdacExcel.getSheetParamDataSet(strErrMsg, objFormatSheet, intSheetCount, objParamDataSet) = False Then
                    GoTo errProc
                End If

                '�����������Sheet
                Dim objDataSheet As GemBox.ExcelLite.ExcelWorksheet = Nothing
                Dim strCellValue As String = ""
                Dim strSheetName As String = ""
                Dim strTemp As String = ""
                Dim intSheetIndex As Integer
                Dim intTitleRows As Integer
                Dim intDataCols As Integer
                Dim i As Integer
                Dim j As Integer
                Dim k As Integer
                For intSheetIndex = 0 To intSheetCount - 2 Step 1
                    objDataSheet = objExcelFile.Worksheets(intSheetIndex)

                    '��ȡ������
                    intTitleRows = 0
                    intDataCols = 0
                    With objParamDataSet.Tables(Josco.JsKernal.Common.Data.DrdcData.TABLE_TY_B_DRDC_EXCELFORMAT)
                        For i = 0 To .Rows.Count - 1 Step 1
                            strSheetName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.DrdcData.FIELD_TY_B_DRDC_EXCELFORMAT_DATASHEETNAME), "")
                            strSheetName = strSheetName.ToUpper
                            If strSheetName = objDataSheet.Name.ToUpper Then
                                intTitleRows = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.DrdcData.FIELD_TY_B_DRDC_EXCELFORMAT_TITLEROWS), 0)
                                intDataCols = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.DrdcData.FIELD_TY_B_DRDC_EXCELFORMAT_DATACOLS), 0)
                                Exit For
                            End If
                        Next
                    End With
                    If intTitleRows <= 0 Or intDataCols <= 0 Then
                        strErrMsg = "����[doPrint_RSBB_RYZJYDB]��ʽSheet�й�������Sheet�Ĳ������ò���ȷ��"
                        GoTo errProc
                    End If

                    '����������
                    If strMacroName <> "" Then
                        Dim strMacroNameArray() As String = strMacroName.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray)
                        Dim strMacroValueArray() As String = strMacroValue.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray)
                        For i = 0 To intTitleRows - 1 Step 1
                            For j = 0 To intDataCols - 1 Step 1
                                For k = 0 To strMacroNameArray.Length - 1 Step 1
                                    strTemp = objPulicParameters.getObjectValue(objDataSheet.Cells(i, j).Value, "")
                                    If strTemp <> "" Then
                                        objDataSheet.Cells(i, j).Value = strTemp.Replace(strMacroNameArray(k), strMacroValueArray(k))
                                    End If
                                Next
                            Next
                        Next
                    End If

                    '���������������
                    '��������
                    If objDataSet.Tables(0).Rows.Count > 3 Then
                        k = objDataSet.Tables(0).Rows.Count
                        objDataSheet.Rows(intTitleRows).InsertCopy(k - 3, objDataSheet.Rows(intTitleRows + 2))
                    Else
                        k = 3
                    End If
                    '�ϲ���1��
                    objDataSheet.Cells.GetSubrange("A" + (intTitleRows + 1).ToString, "A" + (intTitleRows + k).ToString).Merged = True
                    '�����������
                    Dim strValues(2) As String
                    For i = 0 To k - 1 Step 1
                        If i > objDataSet.Tables(0).Rows.Count - 1 Then
                            Exit For
                        End If
                        With objDataSet.Tables(0).Rows(i)
                            If i = 0 Then
                                objDataSheet.Cells(i + intTitleRows, 0).Value = .Item("ͳ������")
                            End If
                            '*******************************************************************
                            objDataSheet.Cells(i + intTitleRows, 1).Value = .Item("��ְ����")
                            objDataSheet.Cells(i + intTitleRows, 2).Value = objPulicParameters.getObjectValue(.Item("��ְ����"), "", "yyyy-MM-dd")
                            objDataSheet.Cells(i + intTitleRows, 3).Value = .Item("��ְ����")
                            objDataSheet.Cells(i + intTitleRows, 4).Value = .Item("��ְְ��")
                            '*******************************************************************
                            objDataSheet.Cells(i + intTitleRows, 5).Value = .Item("��ְ����")
                            objDataSheet.Cells(i + intTitleRows, 6).Value = .Item("��ְ�����ͬ")
                            objDataSheet.Cells(i + intTitleRows, 7).Value = .Item("��ְ������ֹ")
                            objDataSheet.Cells(i + intTitleRows, 8).Value = .Item("��ְ����")
                            objDataSheet.Cells(i + intTitleRows, 9).Value = .Item("��ְ����")
                            objDataSheet.Cells(i + intTitleRows, 10).Value = .Item("��ְ����")
                            objDataSheet.Cells(i + intTitleRows, 11).Value = .Item("��ְ����")
                            objDataSheet.Cells(i + intTitleRows, 12).Value = objPulicParameters.getObjectValue(.Item("��ְ����"), "", "yyyy-MM-dd")
                            objDataSheet.Cells(i + intTitleRows, 13).Value = .Item("��ְ����")
                            '*******************************************************************
                            objDataSheet.Cells(i + intTitleRows, 14).Value = .Item("ʵϰ����")
                            objDataSheet.Cells(i + intTitleRows, 15).Value = .Item("ʵϰԺУ")
                            objDataSheet.Cells(i + intTitleRows, 16).Value = objPulicParameters.getObjectValue(.Item("ʵϰ����"), "", "yyyy-MM-dd")
                            objDataSheet.Cells(i + intTitleRows, 17).Value = .Item("ʵϰ����")
                            '*******************************************************************
                            objDataSheet.Cells(i + intTitleRows, 18).Value = .Item("�춯����")
                            objDataSheet.Cells(i + intTitleRows, 19).Value = objPulicParameters.getObjectValue(.Item("�춯����"), "", "yyyy-MM-dd")
                            strValues(0) = objPulicParameters.getObjectValue(.Item("�춯�²���"), "")
                            strValues(1) = objPulicParameters.getObjectValue(.Item("�춯��ְ��"), "")
                            If strValues(0) <> "" And strValues(1) <> "" Then
                                strValues(2) = strValues(0) + "-" + strValues(1)
                            ElseIf strValues(0) <> "" Then
                                strValues(2) = strValues(0)
                            ElseIf strValues(1) <> "" Then
                                strValues(2) = strValues(1)
                            Else
                                strValues(2) = ""
                            End If
                            objDataSheet.Cells(i + intTitleRows, 20).Value = strValues(2)
                            strValues(0) = objPulicParameters.getObjectValue(.Item("�춯ԭ����"), "")
                            strValues(1) = objPulicParameters.getObjectValue(.Item("�춯ԭְ��"), "")
                            If strValues(0) <> "" And strValues(1) <> "" Then
                                strValues(2) = strValues(0) + "-" + strValues(1)
                            ElseIf strValues(0) <> "" Then
                                strValues(2) = strValues(0)
                            ElseIf strValues(1) <> "" Then
                                strValues(2) = strValues(1)
                            Else
                                strValues(2) = ""
                            End If
                            objDataSheet.Cells(i + intTitleRows, 21).Value = strValues(2)
                            objDataSheet.Cells(i + intTitleRows, 22).Value = .Item("�춯ת��")
                            '*******************************************************************
                            'objDataSheet.Cells(i + intTitleRows, 23).Value = .Item("�춯�籣��Ա")
                            'objDataSheet.Cells(i + intTitleRows, 24).Value = .Item("�춯�籣��Ա")
                            'objDataSheet.Cells(i + intTitleRows, 25).Value = .Item("�춯���ɹ�����")
                            'objDataSheet.Cells(i + intTitleRows, 26).Value = .Item("�춯ͣ�ɹ�����")
                            objDataSheet.Cells(i + intTitleRows, 27).Value = .Item("�춯���ڲ���")
                            'objDataSheet.Cells(i + intTitleRows, 28).Value = .Item("�춯��ѵ���")
                        End With
                    Next
                    '�������
                    objDataSheet.Cells(intTitleRows + k, 6).Formula = "=sum(G" + (intTitleRows + 1).ToString + ":G" + (intTitleRows + k).ToString + ")"
                    objDataSheet.Cells(intTitleRows + k, 7).Formula = "=sum(H" + (intTitleRows + 1).ToString + ":H" + (intTitleRows + k).ToString + ")"
                    objDataSheet.Cells(intTitleRows + k, 8).Formula = "=sum(I" + (intTitleRows + 1).ToString + ":I" + (intTitleRows + k).ToString + ")"
                    objDataSheet.Cells(intTitleRows + k, 9).Formula = "=sum(J" + (intTitleRows + 1).ToString + ":J" + (intTitleRows + k).ToString + ")"
                    objDataSheet.Cells(intTitleRows + k, 10).Formula = "=sum(K" + (intTitleRows + 1).ToString + ":K" + (intTitleRows + k).ToString + ")"
                    objDataSheet.Cells(intTitleRows + k, 11).Formula = "=sum(L" + (intTitleRows + 1).ToString + ":L" + (intTitleRows + k).ToString + ")"
                    '*******************************************************************
                    objDataSheet.Cells(intTitleRows + k, 22).Formula = "=sum(W" + (intTitleRows + 1).ToString + ":W" + (intTitleRows + k).ToString + ")"
                    objDataSheet.Cells(intTitleRows + k, 23).Formula = "=sum(X" + (intTitleRows + 1).ToString + ":X" + (intTitleRows + k).ToString + ")"
                    objDataSheet.Cells(intTitleRows + k, 24).Formula = "=sum(Y" + (intTitleRows + 1).ToString + ":Y" + (intTitleRows + k).ToString + ")"
                    objDataSheet.Cells(intTitleRows + k, 25).Formula = "=sum(Z" + (intTitleRows + 1).ToString + ":Z" + (intTitleRows + k).ToString + ")"
                    objDataSheet.Cells(intTitleRows + k, 26).Formula = "=sum(AA" + (intTitleRows + 1).ToString + ":AA" + (intTitleRows + k).ToString + ")"
                    objDataSheet.Cells(intTitleRows + k, 27).Formula = "=sum(AB" + (intTitleRows + 1).ToString + ":AB" + (intTitleRows + k).ToString + ")"
                Next

                '����Excel
                objExcelFile.SaveXls(strExcelFile)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Data.DrdcData.SafeRelease(objParamDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Josco.JsKernal.DataAccess.dacExcel.SafeRelease(objdacExcel)
            objExcelFile = Nothing

            doPrint_RSBB_RYZJYDB = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Data.DrdcData.SafeRelease(objParamDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Josco.JsKernal.DataAccess.dacExcel.SafeRelease(objdacExcel)
            objExcelFile = Nothing
            Exit Function

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

            Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_BB_RLZYXXHZB = False
            objDataSet = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_BB_RLZYXXHZB]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strKSRQ Is Nothing Then strKSRQ = ""
                strKSRQ = strKSRQ.Trim
                If objPulicParameters.isDatetimeString(strKSRQ) = False Then
                    strErrMsg = "����[getDataSet_BB_RLZYXXHZB]ָ����[" + strKSRQ + "]��Ч��"
                    GoTo errProc
                End If
                If strZZRQ Is Nothing Then strZZRQ = ""
                strZZRQ = strZZRQ.Trim
                If objPulicParameters.isDatetimeString(strZZRQ) = False Then
                    strErrMsg = "����[getDataSet_BB_RLZYXXHZB]ָ����[" + strZZRQ + "]��Ч��"
                    GoTo errProc
                End If
                If strYJZR Is Nothing Then strYJZR = ""
                strYJZR = strYJZR.Trim
                If strYJZR = "" Then
                    strErrMsg = "����[getDataSet_BB_RLZYXXHZB]û��ָ��[�½�ֹ��]��"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(strYJZR) = False Then
                    strErrMsg = "����[getDataSet_BB_RLZYXXHZB]ָ����[" + strYJZR + "]��Ч��"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempDataSet = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_VT_RLZYXXHZB)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        strSQL = ""
                        strSQL = strSQL + " select a.* from dbo.uf_rs_getRLZYXXHZB(@ksrq, @zzrq, @yjzr) a order by a.��λ���,a.��λ����" + vbCr
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@ksrq", strKSRQ)
                        objSqlCommand.Parameters.AddWithValue("@zzrq", strZZRQ)
                        objSqlCommand.Parameters.AddWithValue("@yjzr", CType(strYJZR, Integer))
                        .SelectCommand = objSqlCommand
                        .Fill(objTempDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_VT_RLZYXXHZB))
                    End With
                    '���
                    If objTempDataSet.Tables.Count < 1 Then
                        Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempDataSet)
                    End If
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objDataSet = objTempDataSet
            getDataSet_BB_RLZYXXHZB = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempDataSet)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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
        '     zengxianglin 2009-05-14 ����
        '----------------------------------------------------------------
        Public Function doPrint_RSBB_YXJTZGRYJQTSJTJB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJZRQ As String, _
            ByVal strExcelFile As String, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "") As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objParamDataSet As Josco.JsKernal.Common.Data.DrdcData = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objdacExcel As New Josco.JsKernal.DataAccess.dacExcel
            Dim objExcelFile As New GemBox.ExcelLite.ExcelFile
            Dim strSQL As String = ""

            doPrint_RSBB_YXJTZGRYJQTSJTJB = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "����[doPrint_RSBB_YXJTZGRYJQTSJTJB]δָ����[�����û�]��"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strExcelFile Is Nothing Then strExcelFile = ""
                strExcelFile = strExcelFile.Trim
                If strExcelFile = "" Then
                    strErrMsg = "����[doPrint_RSBB_YXJTZGRYJQTSJTJB]δָ����Excel�ļ���"
                    GoTo errProc
                End If
                Dim blnExisted As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strExcelFile, blnExisted) = False Then
                    GoTo errProc
                End If
                If blnExisted = False Then
                    strErrMsg = "����[doPrint_RSBB_YXJTZGRYJQTSJTJB]Excel�ļ�[" + strExcelFile + "]�����ڣ�"
                    GoTo errProc
                End If
                If strJZRQ Is Nothing Then strJZRQ = ""
                strJZRQ = strJZRQ.Trim
                If objPulicParameters.isDatetimeString(strJZRQ) = False Then
                    strErrMsg = "����[doPrint_RSBB_YXJTZGRYJQTSJTJB]�����[" + strJZRQ + "]����Ч�����ڣ�"
                    GoTo errProc
                End If
                strJZRQ = CType(strJZRQ, System.DateTime).ToString("yyyy-MM-dd")
                Dim objJZRQ As System.DateTime = CType(strJZRQ, System.DateTime)
                Dim strNCRQ As String = objJZRQ.Year.ToString + "-01-01"
                Dim strNMRQ As String = objJZRQ.Year.ToString + "-12-31"
                strNMRQ = strJZRQ

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                'װ��Excel
                objExcelFile.LoadXls(strExcelFile)

                '��ȡģ��Sheet������Ϣ
                Dim objFormatSheet As GemBox.ExcelLite.ExcelWorksheet = Nothing
                Dim intSheetCount As Integer
                intSheetCount = objExcelFile.Worksheets.Count
                If intSheetCount < 2 Then
                    strErrMsg = "����[doPrint_RSBB_YXJTZGRYJQTSJTJB][" + strExcelFile + "]�ļ���������[2]��Sheet��"
                    GoTo errProc
                End If
                objFormatSheet = objExcelFile.Worksheets(intSheetCount - 1)  '0,1,...
                If objdacExcel.getSheetParamDataSet(strErrMsg, objFormatSheet, intSheetCount, objParamDataSet) = False Then
                    GoTo errProc
                End If

                '�����������Sheet
                Dim objDataSheet As GemBox.ExcelLite.ExcelWorksheet = Nothing
                Dim strCellValue As String = ""
                Dim strSheetName As String = ""
                Dim strTemp As String = ""
                Dim intSheetIndex As Integer
                Dim intTitleRows As Integer
                Dim intDataCols As Integer
                Dim i As Integer
                Dim j As Integer
                Dim k As Integer
                For intSheetIndex = 0 To intSheetCount - 2 Step 1
                    objDataSheet = objExcelFile.Worksheets(intSheetIndex)

                    '��ȡ������
                    intTitleRows = 0
                    intDataCols = 0
                    With objParamDataSet.Tables(Josco.JsKernal.Common.Data.DrdcData.TABLE_TY_B_DRDC_EXCELFORMAT)
                        For i = 0 To .Rows.Count - 1 Step 1
                            strSheetName = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.DrdcData.FIELD_TY_B_DRDC_EXCELFORMAT_DATASHEETNAME), "")
                            strSheetName = strSheetName.ToUpper
                            If strSheetName = objDataSheet.Name.ToUpper Then
                                intTitleRows = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.DrdcData.FIELD_TY_B_DRDC_EXCELFORMAT_TITLEROWS), 0)
                                intDataCols = objPulicParameters.getObjectValue(.Rows(i).Item(Josco.JsKernal.Common.Data.DrdcData.FIELD_TY_B_DRDC_EXCELFORMAT_DATACOLS), 0)
                                Exit For
                            End If
                        Next
                    End With
                    If intTitleRows <= 0 Or intDataCols <= 0 Then
                        strErrMsg = "����[doPrint_RSBB_YXJTZGRYJQTSJTJB]��ʽSheet�й�������Sheet�Ĳ������ò���ȷ��"
                        GoTo errProc
                    End If

                    '����������
                    If strMacroName <> "" Then
                        Dim strMacroNameArray() As String = strMacroName.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray)
                        Dim strMacroValueArray() As String = strMacroValue.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray)
                        For i = 0 To intTitleRows - 1 Step 1
                            For j = 0 To intDataCols - 1 Step 1
                                For k = 0 To strMacroNameArray.Length - 1 Step 1
                                    strTemp = objPulicParameters.getObjectValue(objDataSheet.Cells(i, j).Value, "")
                                    If strTemp <> "" Then
                                        objDataSheet.Cells(i, j).Value = strTemp.Replace(strMacroNameArray(k), strMacroValueArray(k))
                                    End If
                                Next
                            Next
                        Next
                    End If

                    '����������������
                    Dim strYXRYSql As String = ""
                    Dim dblZRS As Double = 0
                    Dim dblValue As Double

                    '���㱨������
                    For k = 0 To 1 Step 1
                        'k=0��[  ������Ա]
                        'k=1��[�ǹ�����Ա]
                        For j = 0 To 16 Step 1
                            If k = 0 Then
                                i = intTitleRows + 1 + j
                            Else
                                i = intTitleRows + 1 + 17 + 1 + j
                            End If

                            Select Case j
                                Case 0 '[���䣺30������]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where �������� is not null"
                                    strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,��������,'" + strJZRQ + "'))+1 <= 30"
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                                Case 1 '[���䣺31����35��]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where �������� is not null"
                                    strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,��������,'" + strJZRQ + "'))+1 between 31 and 35"
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                                Case 2 '[���䣺36����40��]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where �������� is not null"
                                    strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,��������,'" + strJZRQ + "'))+1 between 36 and 40"
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                                Case 3 '[���䣺41����45��]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where �������� is not null"
                                    strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,��������,'" + strJZRQ + "'))+1 between 41 and 45"
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                                Case 4 '[���䣺46����50��]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where �������� is not null"
                                    strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,��������,'" + strJZRQ + "'))+1 between 46 and 50"
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                                Case 5 '[���䣺51����54��]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where �������� is not null"
                                    strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,��������,'" + strJZRQ + "'))+1 between 51 and 54"
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                                Case 6 '[���䣺55�꼰����]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where �������� is not null"
                                    strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,��������,'" + strJZRQ + "'))+1 >= 55"
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL

                                Case 7 '[ѧ������ʿ�о���]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where ���ѧ�� = '008'"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   ��ҵʱ�� is not null"
                                    'strSQL = strSQL + vbCr + "     and   ��ҵʱ�� < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                                Case 8 '[ѧ����˶ʿ�о���]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where ���ѧ�� = '007'"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   ��ҵʱ�� is not null"
                                    'strSQL = strSQL + vbCr + "     and   ��ҵʱ�� < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                                Case 9 '[ѧ������ѧ����]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where ���ѧ�� = '006'"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   ��ҵʱ�� is not null"
                                    'strSQL = strSQL + vbCr + "     and   ��ҵʱ�� < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                                Case 10 '[ѧ������ѧר��]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where ���ѧ�� = '005'"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   ��ҵʱ�� is not null"
                                    'strSQL = strSQL + vbCr + "     and   ��ҵʱ�� < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                                Case 11 '[ѧ������ר]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where ���ѧ�� = '004'"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   ��ҵʱ�� is not null"
                                    'strSQL = strSQL + vbCr + "     and   ��ҵʱ�� < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                                Case 12 '[ѧ�������м�����]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where ���ѧ�� not in ('004','005','006','007','008')"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   ��ҵʱ�� is not null"
                                    'strSQL = strSQL + vbCr + "     and   ��ҵʱ�� < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL

                                Case 13 '[ְ�ƣ��߼�]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where ����ְ�� in ('001.001','001.002','002.001','002.002','002.003','003.001','004.001','005.001')"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   ְ��ȡ��ʱ�� is not null"
                                    'strSQL = strSQL + vbCr + "     and   ְ��ȡ��ʱ�� < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                                Case 14 '[ְ�ƣ�����:����]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where ����ְ�� in ('001.001','002.001')"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   ְ��ȡ��ʱ�� is not null"
                                    'strSQL = strSQL + vbCr + "     and   ְ��ȡ��ʱ�� < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                                Case 15 '[ְ�ƣ��м�]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where ����ְ�� in ('001.003','002.004','003.002','004.002','005.002')"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   ְ��ȡ��ʱ�� is not null"
                                    'strSQL = strSQL + vbCr + "     and   ְ��ȡ��ʱ�� < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                                Case 16 '[ְ�ƣ�����]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.��Ա����"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_�����춯"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   �����־ in (1,2)"     '������Ա
                                    Else
                                        strSQL = strSQL + vbCr + "     where   �����־ not in (1,2)" '�ǹ�����Ա
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                    strSQL = strSQL + vbCr + "     or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by ��Ա����"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select ��Ա����"
                                    strSQL = strSQL + vbCr + "     from ����_B_���¿�Ƭ"
                                    strSQL = strSQL + vbCr + "     where ����ְ�� in ('001.004','002.005','003.003','004.003','005.003')"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   ְ��ȡ��ʱ�� is not null"
                                    'strSQL = strSQL + vbCr + "     and   ְ��ȡ��ʱ�� < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.��Ա����=b.��Ա����"
                                    strSQL = strSQL + vbCr + "   where b.��Ա���� is not null"
                                    strYXRYSql = strSQL
                            End Select

                            '*******************************************************************************
                            '����[�����ڸ�����]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select ��Ա����"
                            strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                            strSQL = strSQL + vbCr + "   where   ��λ���� = 1" '�ڸ�
                            strSQL = strSQL + vbCr + "   and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                            strSQL = strSQL + vbCr + "   or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                            strSQL = strSQL + vbCr + "   group by ��Ա����"
                            strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                            strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 4).Value = dblValue
                            '����[�����ڸ�����][�߲�]
                            If k = 0 Then
                                strSQL = ""
                                strSQL = strSQL + vbCr + " select count(*)"
                                strSQL = strSQL + vbCr + " from"
                                strSQL = strSQL + vbCr + " ("
                                strSQL = strSQL + vbCr + strYXRYSql
                                strSQL = strSQL + vbCr + " ) a"
                                strSQL = strSQL + vbCr + " left join"
                                strSQL = strSQL + vbCr + " ("
                                strSQL = strSQL + vbCr + "   select ��Ա����"
                                strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                                strSQL = strSQL + vbCr + "   where   ��λ���� = 1" '�ڸ�
                                strSQL = strSQL + vbCr + "   and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                strSQL = strSQL + vbCr + "   or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "   and     �����־ = 2" '�߲�
                                strSQL = strSQL + vbCr + "   group by ��Ա����"
                                strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                                strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                                If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                    GoTo errProc
                                End If
                                objDataSheet.Cells(i, 5).Value = dblValue
                            End If
                            '����[�����ڸ�����][�в�]
                            If k = 0 Then
                                strSQL = ""
                                strSQL = strSQL + vbCr + " select count(*)"
                                strSQL = strSQL + vbCr + " from"
                                strSQL = strSQL + vbCr + " ("
                                strSQL = strSQL + vbCr + strYXRYSql
                                strSQL = strSQL + vbCr + " ) a"
                                strSQL = strSQL + vbCr + " left join"
                                strSQL = strSQL + vbCr + " ("
                                strSQL = strSQL + vbCr + "   select ��Ա����"
                                strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                                strSQL = strSQL + vbCr + "   where   ��λ���� = 1" '�ڸ�
                                strSQL = strSQL + vbCr + "   and   ((��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� is null)"
                                strSQL = strSQL + vbCr + "   or     (��ʼʱ�� <= '" + strJZRQ + "' and ��ֹʱ�� > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "   and     �����־ = 1" '�в�
                                strSQL = strSQL + vbCr + "   group by ��Ա����"
                                strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                                strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                                If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                    GoTo errProc
                                End If
                                objDataSheet.Cells(i, 6).Value = dblValue
                            End If

                            '*******************************************************************************
                            '����[����������][����]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select ��Ա����"
                            strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                            strSQL = strSQL + vbCr + "   where  �䶯ԭ�� = '001.001'" '����
                            strSQL = strSQL + vbCr + "   and    ��ʼʱ�� between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by ��Ա����"
                            strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                            strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 8).Value = dblValue
                            '����[����������][��Ƹ]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select ��Ա����"
                            strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                            strSQL = strSQL + vbCr + "   where  �䶯ԭ�� = '001.002'" '��Ƹ
                            strSQL = strSQL + vbCr + "   and    ��ʼʱ�� between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by ��Ա����"
                            strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                            strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 9).Value = dblValue
                            '����[����������][����]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select ��Ա����"
                            strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                            strSQL = strSQL + vbCr + "   where  �䶯ԭ�� like '001%'"                  '��Ա����
                            strSQL = strSQL + vbCr + "   and    �䶯ԭ�� not in ('001.001','001.002')" '����
                            strSQL = strSQL + vbCr + "   and    ��ʼʱ�� between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by ��Ա����"
                            strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                            strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 10).Value = dblValue

                            '*******************************************************************************
                            '����[�����������][����]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select ��Ա����"
                            strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                            strSQL = strSQL + vbCr + "   where  �䶯ԭ�� = '002.006'" '����
                            strSQL = strSQL + vbCr + "   and    ��ʼʱ�� between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by ��Ա����"
                            strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                            strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 12).Value = dblValue
                            '����[�����������][����]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select ��Ա����"
                            strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                            strSQL = strSQL + vbCr + "   where  �䶯ԭ�� = '002.007'" '����
                            strSQL = strSQL + vbCr + "   and    ��ʼʱ�� between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by ��Ա����"
                            strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                            strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 13).Value = dblValue
                            '����[�����������][��ְ]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select ��Ա����"
                            strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                            strSQL = strSQL + vbCr + "   where  �䶯ԭ�� = '002.009'" '��ְ
                            strSQL = strSQL + vbCr + "   and    ��ʼʱ�� between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by ��Ա����"
                            strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                            strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 14).Value = dblValue
                            '����[�����������][����]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select ��Ա����"
                            strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                            strSQL = strSQL + vbCr + "   where  �䶯ԭ�� = '002.005'" '����
                            strSQL = strSQL + vbCr + "   and    ��ʼʱ�� between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by ��Ա����"
                            strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                            strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 15).Value = dblValue
                            '����[�����������][����]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select ��Ա����"
                            strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                            strSQL = strSQL + vbCr + "   where  �䶯ԭ�� = '002.012'" '����
                            strSQL = strSQL + vbCr + "   and    ��ʼʱ�� between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by ��Ա����"
                            strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                            strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 16).Value = dblValue
                            '����[�����������][����]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select ��Ա����"
                            strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                            strSQL = strSQL + vbCr + "   where  �䶯ԭ�� like '002%'" '����
                            strSQL = strSQL + vbCr + "   and    �䶯ԭ�� not in ('002.005','002.006','002.007','002.009','002.012')" '����
                            strSQL = strSQL + vbCr + "   and    ��ʼʱ�� between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by ��Ա����"
                            strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                            strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 17).Value = dblValue
                        Next
                    Next

                    '*******************************************************************************
                    '����[����ڸ�����]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where  ��λ���� = 1" '�ڸ�
                    strSQL = strSQL + vbCr + "   and  ((��ֹʱ�� is     null and ��ʼʱ�� <= '" + strNCRQ + "')"
                    strSQL = strSQL + vbCr + "   or    (��ֹʱ�� is not null and '" + strNCRQ + "' between ��ʼʱ�� and ��ֹʱ��))"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(8, 2).Value = dblValue

                    '*******************************************************************************
                    '����[��ְ�йܸɲ�]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where  ��λ���� = 1"   '�ڸ�
                    strSQL = strSQL + vbCr + "   and  ((��ֹʱ�� is     null and ��ʼʱ�� <= '" + strJZRQ + "')"
                    strSQL = strSQL + vbCr + "   or    (��ֹʱ�� is not null and '" + strJZRQ + "' between ��ʼʱ�� and ��ֹʱ��))"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from ����_B_���¿�Ƭ"
                    strSQL = strSQL + vbCr + "   where �Ƿ��йܸɲ� = 1" '�йܸɲ�
                    strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                    strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(28, 20).Value = dblValue

                    '*******************************************************************************
                    '����[�����йܸɲ�]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where  �䶯ԭ�� = '002.008'" '����
                    strSQL = strSQL + vbCr + "   and  ��ʼʱ�� <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from ����_B_���¿�Ƭ"
                    strSQL = strSQL + vbCr + "   where �Ƿ��йܸɲ� = 1" '�йܸɲ�
                    strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                    strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(29, 20).Value = dblValue
                    '����[��������]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where  �䶯ԭ�� = '002.008'" '����
                    strSQL = strSQL + vbCr + "   and  ��ʼʱ�� <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from ����_B_���¿�Ƭ"
                    strSQL = strSQL + vbCr + "   where �Ƿ��йܸɲ� = 1" '�йܸɲ�
                    strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                    strSQL = strSQL + vbCr + " where b.��Ա���� is null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(30, 20).Value = dblValue

                    '*******************************************************************************
                    '����[�����йܸɲ�]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where  �䶯ԭ�� = '002.007'" '����
                    strSQL = strSQL + vbCr + "   and  ��ʼʱ�� <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from ����_B_���¿�Ƭ"
                    strSQL = strSQL + vbCr + "   where �Ƿ��йܸɲ� = 1" '�йܸɲ�
                    strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                    strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(31, 20).Value = dblValue
                    '����[��������]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where  �䶯ԭ�� = '002.007'" '����
                    strSQL = strSQL + vbCr + "   and  ��ʼʱ�� <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from ����_B_���¿�Ƭ"
                    strSQL = strSQL + vbCr + "   where �Ƿ��йܸɲ� = 1" '�йܸɲ�
                    strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                    strSQL = strSQL + vbCr + " where b.��Ա���� is null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(32, 20).Value = dblValue

                    '*******************************************************************************
                    '����[�������]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where  �䶯ԭ�� = '002.010'" '�������
                    strSQL = strSQL + vbCr + "   and  ��ʼʱ�� <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(33, 20).Value = dblValue

                    '*******************************************************************************
                    '����[�й���Ա]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where ��ʼʱ�� <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from ����_B_���¿�Ƭ"
                    strSQL = strSQL + vbCr + "   where ������ò = '001'" '�й���Ա
                    strSQL = strSQL + vbCr + "   and   �뵳ʱ�� is not null"
                    strSQL = strSQL + vbCr + "   and   �뵳ʱ�� < '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                    strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(34, 20).Value = dblValue
                    '����[�й���Ա][����:�ڸڵ�Ա]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where  ��λ���� = 1"   '�ڸ�
                    strSQL = strSQL + vbCr + "   and  ((��ֹʱ�� is     null and ��ʼʱ�� <= '" + strJZRQ + "')"
                    strSQL = strSQL + vbCr + "   or    (��ֹʱ�� is not null and '" + strJZRQ + "' between ��ʼʱ�� and ��ֹʱ��))"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from ����_B_���¿�Ƭ"
                    strSQL = strSQL + vbCr + "   where ������ò = '001'" '�й���Ա
                    strSQL = strSQL + vbCr + "   and   �뵳ʱ�� is not null"
                    strSQL = strSQL + vbCr + "   and   �뵳ʱ�� < '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                    strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(35, 20).Value = dblValue

                    '*******************************************************************************
                    '����[������Ա]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where ��ʼʱ�� <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from ����_B_���¿�Ƭ"
                    strSQL = strSQL + vbCr + "   where ������ò = '002'" '������Ա
                    strSQL = strSQL + vbCr + "   and   �뵳ʱ�� is not null"
                    strSQL = strSQL + vbCr + "   and   �뵳ʱ�� < '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                    strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(37, 20).Value = dblValue

                    '*******************************************************************************
                    '����[��������]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where ��ʼʱ�� <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from ����_B_���¿�Ƭ"
                    strSQL = strSQL + vbCr + "   where ������ò = '003'" '��������
                    strSQL = strSQL + vbCr + "   and   �뵳ʱ�� is not null"
                    strSQL = strSQL + vbCr + "   and   �뵳ʱ�� < '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                    strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(38, 20).Value = dblValue

                    '*******************************************************************************
                    '����[��������]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where ��ʼʱ�� <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from ����_B_���¿�Ƭ"
                    strSQL = strSQL + vbCr + "   where ���� <> ''"
                    strSQL = strSQL + vbCr + "   and   ���� not like '%��%'"
                    strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                    strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(39, 20).Value = dblValue

                    '*******************************************************************************
                    '����[����]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where ��ʼʱ�� <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from ����_B_���¿�Ƭ"
                    strSQL = strSQL + vbCr + "   where ��Ա�������� = 1" '����
                    strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                    strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(41, 20).Value = dblValue

                    '*******************************************************************************
                    '����[��ת�ɲ�]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where ��ʼʱ�� <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from ����_B_���¿�Ƭ"
                    strSQL = strSQL + vbCr + "   where �Ƿ��ת�ɲ� = 1" '��ת�ɲ�
                    strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                    strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(42, 20).Value = dblValue

                    '*******************************************************************************
                    '����[�������]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select ��Ա����"
                    strSQL = strSQL + vbCr + "   from ����_B_�����춯"
                    strSQL = strSQL + vbCr + "   where ��ʼʱ�� <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by ��Ա����"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from ����_B_���¿�Ƭ"
                    strSQL = strSQL + vbCr + "   where ���˷���״̬ <> 0" '�������
                    strSQL = strSQL + vbCr + " ) b on a.��Ա����=b.��Ա����"
                    strSQL = strSQL + vbCr + " where b.��Ա���� is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(43, 20).Value = dblValue
                Next

                '����Excel
                objExcelFile.SaveXls(strExcelFile)
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Data.DrdcData.SafeRelease(objParamDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Josco.JsKernal.DataAccess.dacExcel.SafeRelease(objdacExcel)
            objExcelFile = Nothing

            doPrint_RSBB_YXJTZGRYJQTSJTJB = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Data.DrdcData.SafeRelease(objParamDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Josco.JsKernal.DataAccess.dacExcel.SafeRelease(objdacExcel)
            objExcelFile = Nothing
            Exit Function

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

            Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_BB_LDHTJMQXB = False
            objDataSet = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_BB_LDHTJMQXB]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strKSRQ Is Nothing Then strKSRQ = ""
                strKSRQ = strKSRQ.Trim
                If objPulicParameters.isDatetimeString(strKSRQ) = False Then
                    strErrMsg = "����[getDataSet_BB_LDHTJMQXB]ָ����[" + strKSRQ + "]��Ч��"
                    GoTo errProc
                End If
                If strZZRQ Is Nothing Then strZZRQ = ""
                strZZRQ = strZZRQ.Trim
                If objPulicParameters.isDatetimeString(strZZRQ) = False Then
                    strErrMsg = "����[getDataSet_BB_LDHTJMQXB]ָ����[" + strZZRQ + "]��Ч��"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempDataSet = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_VT_LDHTJMQXB)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        strSQL = ""
                        strSQL = strSQL + " select a.* from dbo.uf_rs_getLDHTJMQXB(@ksrq, @zzrq) a order by a.��¼���" + vbCr
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@ksrq", strKSRQ)
                        objSqlCommand.Parameters.AddWithValue("@zzrq", strZZRQ)
                        .SelectCommand = objSqlCommand
                        .Fill(objTempDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_VT_LDHTJMQXB))
                    End With
                    '���
                    If objTempDataSet.Tables.Count < 1 Then
                        Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempDataSet)
                    End If
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objDataSet = objTempDataSet
            getDataSet_BB_LDHTJMQXB = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempDataSet)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_BB_LDJJBB = False
            objDataSet = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_BB_LDJJBB]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strTJND Is Nothing Then strTJND = ""
                strTJND = strTJND.Trim
                If objPulicParameters.isIntegerString(strTJND) = False Then
                    strErrMsg = "����[getDataSet_BB_LDJJBB]ָ����[" + strTJND + "]��Ч��"
                    GoTo errProc
                End If
                Dim intTJND As Integer = CType(strTJND, Integer)
                If intTJND <= 0 Or intTJND > 9999 Then
                    strErrMsg = "����[getDataSet_BB_LDJJBB]ָ����[" + strTJND + "]��Ч��"
                    GoTo errProc
                End If
                If strTJJD Is Nothing Then strTJJD = ""
                strTJJD = strTJJD.Trim
                If objPulicParameters.isIntegerString(strTJJD) = False Then
                    strErrMsg = "����[getDataSet_BB_LDJJBB]ָ����[" + strTJJD + "]��Ч��"
                    GoTo errProc
                End If
                Dim intTJJD As Integer = CType(strTJJD, Integer)
                Select Case intTJJD
                    Case 1, 2, 3, 4
                    Case Else
                        strErrMsg = "����[getDataSet_BB_LDJJBB]ָ����[" + strTJJD + "]��Ч��"
                        GoTo errProc
                End Select

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempDataSet = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_VT_LDJJBB)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        strSQL = ""
                        strSQL = strSQL + " select a.* from dbo.uf_rs_getLDJJBB(@tjnd, @tjjd) a order by a.��¼���" + vbCr
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@tjnd", intTJND)
                        objSqlCommand.Parameters.AddWithValue("@tjjd", intTJJD)
                        .SelectCommand = objSqlCommand
                        .Fill(objTempDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_VT_LDJJBB))
                    End With
                    '���
                    If objTempDataSet.Tables.Count < 1 Then
                        Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempDataSet)
                    End If
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objDataSet = objTempDataSet
            getDataSet_BB_LDJJBB = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempDataSet)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_BB_LDJNBB = False
            objDataSet = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_BB_LDJNBB]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strTJND Is Nothing Then strTJND = ""
                strTJND = strTJND.Trim
                If objPulicParameters.isIntegerString(strTJND) = False Then
                    strErrMsg = "����[getDataSet_BB_LDJNBB]ָ����[" + strTJND + "]��Ч��"
                    GoTo errProc
                End If
                Dim intTJND As Integer = CType(strTJND, Integer)
                If intTJND <= 0 Or intTJND > 9999 Then
                    strErrMsg = "����[getDataSet_BB_LDJNBB]ָ����[" + strTJND + "]��Ч��"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempDataSet = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_VT_LDJNBB)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        strSQL = ""
                        strSQL = strSQL + " select a.* from dbo.uf_rs_getLDJNBB(@tjnd) a order by a.��¼���" + vbCr
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@tjnd", intTJND)
                        .SelectCommand = objSqlCommand
                        .Fill(objTempDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_VT_LDJNBB))
                    End With
                    '���
                    If objTempDataSet.Tables.Count < 1 Then
                        Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempDataSet)
                    End If
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objDataSet = objTempDataSet
            getDataSet_BB_LDJNBB = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JSOA.Common.Data.estateRenshiGeneralData.SafeRelease(objTempDataSet)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objBaseLocalFile As New Josco.JsKernal.Common.Utilities.BaseLocalFile
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCustomer As New Josco.JsKernal.DataAccess.dacCustomer
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strDesFile As String = ""
            Dim strWJWZ As String = ""
            Dim strSQL As String

            doLuyong = False
            strErrMsg = ""

            Try
                '���
                If strJLBH Is Nothing Then strJLBH = ""
                strJLBH = strJLBH.Trim
                If strJLBH = "" Then
                    Exit Try
                End If
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "����δ���������û���"
                    GoTo errProc
                End If
                If objServer Is Nothing Then
                    strErrMsg = "����û��ָ��[System.Web.HttpServerUtility]��"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strAppRoot Is Nothing Then strAppRoot = ""
                strAppRoot = strAppRoot.Trim
                If strBasePath Is Nothing Then strBasePath = strBasePath.Trim
                strBasePath = strBasePath.Trim

                '��ȡ��������
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '������Ա��Ϣ
                strSQL = "select * from �ز�_B_����_�������� where ������� = '" + strJLBH + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables.Count < 1 Then
                    strErrMsg = "�����޷�����[" + strJLBH + "][��������]��Ϣ"
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count < 1 Then
                    strErrMsg = "�����޷�����[" + strJLBH + "][��������]��Ϣ"
                    GoTo errProc
                End If
                Dim strRYXP As String = ""
                Dim strRYDM As String = ""
                Dim strBMDM As String = ""
                Dim strRYXM As String = ""
                With objDataSet.Tables(0).Rows(0)
                    strRYDM = objPulicParameters.getObjectValue(.Item("��Ա����"), "")
                    strRYXM = objPulicParameters.getObjectValue(.Item("����"), "")
                    strBMDM = objPulicParameters.getObjectValue(.Item("���ò���"), "")
                    strRYXP = objPulicParameters.getObjectValue(.Item("��Ա��Ƭ"), "")
                End With
                If strBMDM = "" Or strRYDM = "" Or strRYXM = "" Then
                    strErrMsg = "����[]û�и���[���ò���]��[��Ա����]��[����]��"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '���[��Ա����]
                '========================================================================================================
                strSQL = "select * from ����_B_���¿�Ƭ where ��Ա���� = '" + strRYDM + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables.Count < 1 Then
                    strErrMsg = "�����޷����[" + strRYDM + "]��Ψһ��!"
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strRYDM + "]��[��������]���Ѿ�����!"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                '========================================================================================================
                strSQL = "select * from ����_B_��Ա where ��Ա���� = '" + strRYDM + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables.Count < 1 Then
                    strErrMsg = "�����޷����[" + strRYDM + "]��Ψһ��!"
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strRYDM + "]��[��λ��Ա]���Ѿ�����!"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                '========================================================================================================
                strSQL = "select * from ����_B_��Ա where ��Ա���� = '" + strRYXM + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables.Count < 1 Then
                    strErrMsg = "�����޷����[" + strRYXM + "]��Ψһ��!"
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strRYXM + "]��[��λ��Ա]���Ѿ�����!"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '�����µ�[��Ա���]
                Dim strRYXH As String = ""
                If objdacCustomer.getNewRYXH(strErrMsg, strUserId, strPassword, strBMDM, strRYXH) = False Then
                    GoTo errProc
                End If

                '��ȡGUID
                Dim strWYBS As String = ""
                If objdacCommon.getNewGUID(strErrMsg, objSqlConnection, strWYBS) = False Then
                    GoTo errProc
                End If

                '����[��Ա��Ƭ]����ʱ�ļ���
                If strRYXP <> "" Then
                    If objServer Is Nothing Or strAppRoot = "" Or strBasePath = "" Then
                        strErrMsg = "����û��ָ���й�Ŀ¼������"
                        GoTo errProc
                    End If
                End If

                '�����ļ���Ŀ��Ŀ¼
                Dim strSep As String = Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP
                Dim strFileName As String = ""
                Dim strSrcFile As String = ""
                If strRYXP <> "" Then
                    strSrcFile = strAppRoot + strSep + strRYXP
                    strSrcFile = objServer.MapPath(strSrcFile)
                    If Me.getHTTPNewFileName(strErrMsg, strSrcFile, strWYBS, strBasePath, strFileName) = False Then
                        GoTo errProc
                    End If
                    strDesFile = objServer.MapPath(strAppRoot + strSep + strFileName)
                    If objBaseLocalFile.doCopyFile(strErrMsg, strSrcFile, strDesFile, True) = False Then
                        GoTo errProc
                    End If
                End If

                '����SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '��ʼ����
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                'ִ������
                Try
                    '�γɡ�����_B_���¿�Ƭ����¼
                    strSQL = ""
                    strSQL = strSQL + " insert into ����_B_���¿�Ƭ (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,��Ա����,����,�Ա�,��������,�뱾��λʱ��," + vbCr
                    strSQL = strSQL + "   Ӣ������,�ֻ�����,סլ�绰,���֤��," + vbCr
                    strSQL = strSQL + "   ����,����,������ַ,��ס��ַ,��Ա��Ƭλ��," + vbCr
                    strSQL = strSQL + "   ����״��,�������," + vbCr
                    strSQL = strSQL + "   ���ѧ��,���ѧλ,��ҵԺУ,��ҵרҵ,��ҵʱ��," + vbCr
                    strSQL = strSQL + "   ����ְ��,ְ��ȡ��ʱ��," + vbCr
                    strSQL = strSQL + "   ִҵ�ʸ�," + vbCr
                    strSQL = strSQL + "   ������ò,�뵳ʱ��" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=@wybs,��Ա����,����,�Ա�,��������,�뱾��λʱ��=getdate()," + vbCr
                    strSQL = strSQL + "   Ӣ������,�ֻ�����,סլ�绰,���֤��," + vbCr
                    strSQL = strSQL + "   ����,����,������ַ,��ס��ַ,��Ա��Ƭλ��=@ryxpwz," + vbCr
                    strSQL = strSQL + "   ����״��,�������," + vbCr
                    strSQL = strSQL + "   ���ѧ��,���ѧλ,��ҵԺУ,��ҵרҵ,��ҵʱ��," + vbCr
                    strSQL = strSQL + "   ����ְ��,ְ��ȡ��ʱ��," + vbCr
                    strSQL = strSQL + "   ִҵ�ʸ�," + vbCr
                    strSQL = strSQL + "   ������ò,�뵳ʱ��" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_��������" + vbCr
                    strSQL = strSQL + " where ��Ա���� = @rydm" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    objSqlCommand.Parameters.AddWithValue("@ryxpwz", strFileName)
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.ExecuteNonQuery()

                    '�γɡ�����_B_ѧϰ��������¼
                    strSQL = ""
                    strSQL = strSQL + " insert into ����_B_ѧϰ���� (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,��Ա����," + vbCr
                    strSQL = strSQL + "   ��ʼ����,��ֹ����,ѧϰ����,ѧϰԺУ,ѧϰרҵ,ѧϰ���," + vbCr
                    strSQL = strSQL + "   ��ע��Ϣ" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select " + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=newid(),��Ա����," + vbCr
                    strSQL = strSQL + "   ��ʼ����,��ֹ����,ѧϰ����,ѧϰԺУ,ѧϰרҵ,ѧϰ���," + vbCr
                    strSQL = strSQL + "   ��ע��Ϣ" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_ѧϰ����" + vbCr
                    strSQL = strSQL + " where ��Ա���� = @rydm" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.ExecuteNonQuery()

                    '�γɡ�����_B_������������¼
                    strSQL = ""
                    strSQL = strSQL + " insert into ����_B_�������� (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,��Ա����," + vbCr
                    strSQL = strSQL + "   ��ʼ����,��ֹ����,����λ,����ְ��," + vbCr
                    strSQL = strSQL + "   ��ע��Ϣ" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select " + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=newid(),��Ա����," + vbCr
                    strSQL = strSQL + "   ��ʼ����,��ֹ����,����λ,����ְ��," + vbCr
                    strSQL = strSQL + "   ��ע��Ϣ" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_��������" + vbCr
                    strSQL = strSQL + " where ��Ա���� = @rydm" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.ExecuteNonQuery()

                    'д[����_B_��Ա]
                    strSQL = ""
                    strSQL = strSQL + " insert into ����_B_��Ա (" + vbCr
                    strSQL = strSQL + "   ��Ա����,��Ա����,��Ա����,��Ա���,��֯����" + vbCr
                    strSQL = strSQL + " ) values (" + vbCr
                    strSQL = strSQL + "   @rydm, @ryxm, @ryzm, @ryxh, @zzdm" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.Parameters.AddWithValue("@ryxm", strRYXM)
                    objSqlCommand.Parameters.AddWithValue("@ryzm", strRYXM)
                    objSqlCommand.Parameters.AddWithValue("@ryxh", strRYXH)
                    objSqlCommand.Parameters.AddWithValue("@zzdm", strBMDM)
                    objSqlCommand.ExecuteNonQuery()
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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doLuyong = True
            Exit Function
rollDatabase:
            'ɾ�������ļ�
            Dim strErrMsgA As String
            If strDesFile <> "" Then
                If objBaseLocalFile.doDeleteFile(strErrMsgA, strDesFile) = False Then
                    '����
                End If
            End If
            objSqlTransaction.Rollback()
            GoTo errProc
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.BaseLocalFile.SafeRelease(objBaseLocalFile)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

    End Class

End Namespace
