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
    ' ����    ��dacEstateCommon
    '
    ' ����������
    '     �ṩ��ͨ�õز��������ݵ�������ݲ����
    '----------------------------------------------------------------

    Public Class dacEstateCommon
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.DataAccess.dacEstateCommon)
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
        ' �������򻮷ִ����ֶεĺϷ���
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
        Public Function doValidCode_QuyuHuafen( _
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
            Dim intSegLen As Integer = 2
            Dim strSep As String = "."

            doValidCode_QuyuHuafen = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[doValidCode_QuyuHuafen]û��ָ��[�����û�]��"
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
                    strErrMsg = "����[doValidCode_QuyuHuafen]��û��ָ��[������]��"
                    GoTo errProc
                End If
                If strFieldName = "" Then
                    strErrMsg = "����[doValidCode_QuyuHuafen]��û��ָ��[����ֶ���]��"
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
                        strErrMsg = "����[doValidCode_QuyuHuafen][" + strFieldName + "]������[" + intSegLen.ToString + "]λ���֣�"
                        GoTo errProc
                    End If
                    If objPulicParameters.isIntegerString(strArray(i - 1)) = False Then
                        strErrMsg = "����[doValidCode_QuyuHuafen][" + strFieldName + "]������[" + intSegLen.ToString + "]λ���֣�"
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
                            strErrMsg = "����[doValidCode_QuyuHuafen]�޷���ȡ���ݣ�"
                            GoTo errProc
                        End If
                        If .Tables(0).Rows.Count < 1 Then
                            strErrMsg = "����[doValidCode_QuyuHuafen]���ϼ�����[" + strPrevCode + "]�����ڣ���"
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

            doValidCode_QuyuHuafen = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function











        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_˰��Ŀ¼����SQL���(�ԡ�˰�Ѵ��롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ShuifeiMulu() As String
            getTableSQL_ShuifeiMulu = "select * from �ز�_B_����_˰��Ŀ¼ order by ˰�Ѵ���"
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getSfmc = False
            strErrMsg = ""
            strSfmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strSfdm Is Nothing Then strSfdm = ""

                '����
                strSQL = "select dbo.uf_estate_gg_getSfmc('" + strSfdm + "')"
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
                    strSfmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), "")
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getSfmc = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getSfdm = False
            strErrMsg = ""
            strSfdm = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strSfmc Is Nothing Then strSfmc = ""

                '����
                strSQL = ""
                strSQL = strSQL + " select * from �ز�_B_����_˰��Ŀ¼" + vbCr
                strSQL = strSQL + " where ˰������ = '" + strSfmc + "'"
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
                    strSfdm = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("˰�Ѵ���"), "")
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getSfdm = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_ShuifeiMulu = False
            objestateCommonData = Nothing
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
                    objTempestateCommonData = New Josco.JSOA.Common.Data.estateCommonData(Josco.JSOA.Common.Data.estateCommonData.enumTableType.DC_B_GG_SHUIFEIMULU)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from �ز�_B_����_˰��Ŀ¼ a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.˰�Ѵ��� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateCommonData.Tables(Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_SHUIFEIMULU))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateCommonData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objTempestateCommonData)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateCommonData = objTempestateCommonData
            getDataSet_ShuifeiMulu = True
            Exit Function
errProc:
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objTempestateCommonData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰�ز�_B_����_˰��Ŀ¼�������ݵĺϷ���
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
        Public Function doVerifyData_ShuifeiMulu( _
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

            doVerifyData_ShuifeiMulu = False

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
                strSQL = "select top 0 * from �ز�_B_����_˰��Ŀ¼"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "�ز�_B_����_˰��Ŀ¼", objDataSet) = False Then
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

                '��顰˰�Ѵ��롱Լ��
                Dim strOldSFDM As String = ""
                Dim strNewSFDM As String = ""
                strNewSFDM = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from �ز�_B_����_˰��Ŀ¼ where ˰�Ѵ��� = @sfdm"
                        objListDictionary.Add("@sfdm", strNewSFDM)
                    Case Else
                        strOldSFDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFDM), "")
                        strSQL = "select * from �ز�_B_����_˰��Ŀ¼ where ˰�Ѵ��� = @sfdm and ˰�Ѵ��� <> @oldsfdm"
                        objListDictionary.Add("@sfdm", strNewSFDM)
                        objListDictionary.Add("@oldsfdm", strOldSFDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewSFDM + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '��顰˰�����ơ�Լ��
                Dim strNewSFMC As String = ""
                strNewSFMC = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from �ز�_B_����_˰��Ŀ¼ where ˰������ = @sfmc"
                        objListDictionary.Add("@sfmc", strNewSFMC)
                    Case Else
                        strSQL = "select * from �ز�_B_����_˰��Ŀ¼ where ˰������ = @sfmc and ˰�Ѵ��� <> @oldsfdm"
                        objListDictionary.Add("@sfmc", strNewSFMC)
                        objListDictionary.Add("@oldsfdm", strOldSFDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewSFMC + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '�������ֶ�
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewSFDM, strOldSFDM, "˰�Ѵ���", "�ز�_B_����_˰��Ŀ¼", objenumEditType) = False Then
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

            doVerifyData_ShuifeiMulu = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_ShuifeiMulu = False
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
                If Me.doVerifyData_ShuifeiMulu(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                            strSQL = strSQL + " insert into �ز�_B_����_˰��Ŀ¼ (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFDM), "")

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
                            strSQL = strSQL + " update �ز�_B_����_˰��Ŀ¼ set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where ˰�Ѵ��� = @oldkey" + vbCr
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
            doSaveData_ShuifeiMulu = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_ShuifeiMulu = False
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
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFDM), "")
                    'ɾ���¼�
                    strSQL = ""
                    strSQL = strSQL + " delete from �ز�_B_����_˰��Ŀ¼ "
                    strSQL = strSQL + " where ˰�Ѵ��� like @oldkey +'.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from �ز�_B_����_˰��Ŀ¼ "
                    strSQL = strSQL + " where ˰�Ѵ��� = @oldkey"
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
            doDeleteData_ShuifeiMulu = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function













        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_��ҵ�������SQL���(�ԡ�������롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_WuyeJiange() As String
            getTableSQL_WuyeJiange = "select * from �ز�_B_����_��ҵ��� order by �������"
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getWyjgmc = False
            strErrMsg = ""
            strWyjgmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strWyjgdm Is Nothing Then strWyjgdm = ""

                '����
                strSQL = "select dbo.uf_estate_gg_getWyjgmc('" + strWyjgdm + "')"
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
                    strWyjgmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), "")
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getWyjgmc = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���ݡ�������ơ���ȡ��������롱
        '     strErrMsg                 ����������򷵻ش�����Ϣ
        '     strUserId                 ���û���ʶ
        '     strPassword               ���û�����
        '     strWyjgmc                   ���������
        '     strWyjgdm                   ���������(����)
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getWyjgdm = False
            strErrMsg = ""
            strWyjgdm = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strWyjgmc Is Nothing Then strWyjgmc = ""

                '����
                strSQL = ""
                strSQL = strSQL + " select * from �ز�_B_����_��ҵ���" + vbCr
                strSQL = strSQL + " where ������� = '" + strWyjgmc + "'"
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
                    strWyjgdm = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("�������"), "")
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getWyjgdm = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_WuyeJiange = False
            objestateCommonData = Nothing
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
                    objTempestateCommonData = New Josco.JSOA.Common.Data.estateCommonData(Josco.JSOA.Common.Data.estateCommonData.enumTableType.DC_B_GG_WUYEJIANGE)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from �ز�_B_����_��ҵ��� a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.������� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateCommonData.Tables(Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_WUYEJIANGE))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateCommonData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objTempestateCommonData)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateCommonData = objTempestateCommonData
            getDataSet_WuyeJiange = True
            Exit Function
errProc:
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objTempestateCommonData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰�ز�_B_����_��ҵ����������ݵĺϷ���
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
        Public Function doVerifyData_WuyeJiange( _
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

            doVerifyData_WuyeJiange = False

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
                strSQL = "select top 0 * from �ز�_B_����_��ҵ���"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "�ز�_B_����_��ҵ���", objDataSet) = False Then
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

                '��顰������롱Լ��
                Dim strOldWYJGDM As String = ""
                Dim strNewWYJGDM As String = ""
                strNewWYJGDM = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEJIANGE_WYJGDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from �ز�_B_����_��ҵ��� where ������� = @wyjgdm"
                        objListDictionary.Add("@wyjgdm", strNewWYJGDM)
                    Case Else
                        strOldWYJGDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEJIANGE_WYJGDM), "")
                        strSQL = "select * from �ز�_B_����_��ҵ��� where ������� = @wyjgdm and ������� <> @oldwyjgdm"
                        objListDictionary.Add("@wyjgdm", strNewWYJGDM)
                        objListDictionary.Add("@oldwyjgdm", strOldWYJGDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewWYJGDM + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '��顰������ơ�Լ��
                Dim strNewWYJGMC As String = ""
                strNewWYJGMC = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEJIANGE_WYJGMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from �ز�_B_����_��ҵ��� where ������� = @wyjgmc"
                        objListDictionary.Add("@wyjgmc", strNewWYJGMC)
                    Case Else
                        strSQL = "select * from �ز�_B_����_��ҵ��� where ������� = @wyjgmc and ������� <> @oldwyjgdm"
                        objListDictionary.Add("@wyjgmc", strNewWYJGMC)
                        objListDictionary.Add("@oldwyjgdm", strOldWYJGDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewWYJGMC + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '�������ֶ�
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewWYJGDM, strOldWYJGDM, "�������", "�ز�_B_����_��ҵ���", objenumEditType) = False Then
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

            doVerifyData_WuyeJiange = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_WuyeJiange = False
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
                If Me.doVerifyData_WuyeJiange(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                            strSQL = strSQL + " insert into �ز�_B_����_��ҵ��� (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEJIANGE_WYJGDM), "")

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
                            strSQL = strSQL + " update �ز�_B_����_��ҵ��� set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where ������� = @oldkey" + vbCr
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
            doSaveData_WuyeJiange = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_WuyeJiange = False
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
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEJIANGE_WYJGDM), "")
                    'ɾ���¼�
                    strSQL = ""
                    strSQL = strSQL + " delete from �ز�_B_����_��ҵ��� "
                    strSQL = strSQL + " where ������� like @oldkey +'.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from �ز�_B_����_��ҵ��� "
                    strSQL = strSQL + " where ������� = @oldkey"
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
            doDeleteData_WuyeJiange = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function










        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_��ҵ���ʡ���SQL���(�ԡ����ʴ��롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_WuyeXingzhi() As String
            getTableSQL_WuyeXingzhi = "select * from �ز�_B_����_��ҵ���� order by ���ʴ���"
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getWyxzmc = False
            strErrMsg = ""
            strWyxzmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strWyxzdm Is Nothing Then strWyxzdm = ""

                '����
                strSQL = "select dbo.uf_estate_gg_getWyxzmc('" + strWyxzdm + "')"
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
                    strWyxzmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), "")
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getWyxzmc = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getWyxzdm = False
            strErrMsg = ""
            strWyxzdm = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strWyxzmc Is Nothing Then strWyxzmc = ""

                '����
                strSQL = ""
                strSQL = strSQL + " select * from �ز�_B_����_��ҵ����" + vbCr
                strSQL = strSQL + " where �������� = '" + strWyxzmc + "'"
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
                    strWyxzdm = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("���ʴ���"), "")
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getWyxzdm = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_WuyeXingzhi = False
            objestateCommonData = Nothing
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
                    objTempestateCommonData = New Josco.JSOA.Common.Data.estateCommonData(Josco.JSOA.Common.Data.estateCommonData.enumTableType.DC_B_GG_WUYEXINGZHI)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from �ز�_B_����_��ҵ���� a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.���ʴ��� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateCommonData.Tables(Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_WUYEXINGZHI))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateCommonData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objTempestateCommonData)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateCommonData = objTempestateCommonData
            getDataSet_WuyeXingzhi = True
            Exit Function
errProc:
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objTempestateCommonData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰�ز�_B_����_��ҵ���ʡ������ݵĺϷ���
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
        '     zengxianglin 2010-12-21 ����
        '----------------------------------------------------------------
        Public Function doVerifyData_WuyeXingzhi( _
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

            doVerifyData_WuyeXingzhi = False

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
                strSQL = "select top 0 * from �ز�_B_����_��ҵ����"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "�ز�_B_����_��ҵ����", objDataSet) = False Then
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
                        'zengxianglin 2010-12-21
                        Case Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_SFQY
                            If strValue = "" Then strValue = "0"
                            Select Case strValue
                                Case "0", "1"
                                Case Else
                                    strErrMsg = "��������[" + strField + "]���ֵ[" + strValue + "]��Ч��"
                                    GoTo errProc
                            End Select
                        Case Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_XSSX
                            If strValue = "" Then strValue = "0"
                            If objPulicParameters.isIntegerString(strValue) = False Then
                                strErrMsg = "��������[" + strField + "]���ֵ[" + strValue + "]��Ч��"
                                GoTo errProc
                            End If

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

                '��顰���ʴ��롱Լ��
                Dim strOldWYXZDM As String = ""
                Dim strNewWYXZDM As String = ""
                strNewWYXZDM = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_WYXZDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from �ز�_B_����_��ҵ���� where ���ʴ��� = @wyxzdm"
                        objListDictionary.Add("@wyxzdm", strNewWYXZDM)
                    Case Else
                        strOldWYXZDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_WYXZDM), "")
                        strSQL = "select * from �ز�_B_����_��ҵ���� where ���ʴ��� = @wyxzdm and ���ʴ��� <> @oldwyxzdm"
                        objListDictionary.Add("@wyxzdm", strNewWYXZDM)
                        objListDictionary.Add("@oldwyxzdm", strOldWYXZDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewWYXZDM + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '��顰�������ơ�Լ��
                Dim strNewWYXZMC As String = ""
                strNewWYXZMC = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_WYXZMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from �ز�_B_����_��ҵ���� where �������� = @wyxzmc"
                        objListDictionary.Add("@wyxzmc", strNewWYXZMC)
                    Case Else
                        strSQL = "select * from �ز�_B_����_��ҵ���� where �������� = @wyxzmc and ���ʴ��� <> @oldwyxzdm"
                        objListDictionary.Add("@wyxzmc", strNewWYXZMC)
                        objListDictionary.Add("@oldwyxzdm", strOldWYXZDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewWYXZMC + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '�������ֶ�
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewWYXZDM, strOldWYXZDM, "���ʴ���", "�ز�_B_����_��ҵ����", objenumEditType) = False Then
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

            doVerifyData_WuyeXingzhi = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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
        ' ����
        '     zengxianglin 2010-12-21 ����
        '----------------------------------------------------------------
        Public Function doSaveData_WuyeXingzhi( _
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
            doSaveData_WuyeXingzhi = False
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
                If Me.doVerifyData_WuyeXingzhi(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                                            'zengxianglin 2010-12-21
                                            Case Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_SFQY, _
                                                Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_XSSX
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), objPulicParameters.getObjectValue(strValue, 0))

                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " insert into �ز�_B_����_��ҵ���� (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_WYXZDM), "")

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
                                            'zengxianglin 2010-12-21
                                            Case Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_SFQY, _
                                                Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_XSSX
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), objPulicParameters.getObjectValue(strValue, 0))

                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " update �ز�_B_����_��ҵ���� set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where ���ʴ��� = @oldkey" + vbCr
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
            doSaveData_WuyeXingzhi = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_WuyeXingzhi = False
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
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_WYXZDM), "")
                    'ɾ���¼�
                    strSQL = ""
                    strSQL = strSQL + " delete from �ز�_B_����_��ҵ���� "
                    strSQL = strSQL + " where ���ʴ��� like @oldkey +'.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from �ز�_B_����_��ҵ���� "
                    strSQL = strSQL + " where ���ʴ��� = @oldkey"
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
            doDeleteData_WuyeXingzhi = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function










        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_Ӧ��Ӧ��ģ�桱��SQL���(�ԡ�ģ����롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_YingshouYingfuMoban() As String
            getTableSQL_YingshouYingfuMoban = "select * from �ز�_B_����_Ӧ��Ӧ��ģ�� order by ģ�����"
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getMbmc = False
            strErrMsg = ""
            strMbmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strMbdm Is Nothing Then strMbdm = ""

                '����
                strSQL = "select dbo.uf_estate_gg_getFkfsmbmc('" + strMbdm + "')"
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
                    strMbmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), "")
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getMbmc = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

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

            Dim objTempestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_YingshouYingfuMoban = False
            objestateCommonData = Nothing
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
                    objTempestateCommonData = New Josco.JSOA.Common.Data.estateCommonData(Josco.JSOA.Common.Data.estateCommonData.enumTableType.DC_B_GG_YINGSHOUYINGFUMOBAN)

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
                        strSQL = strSQL + "     b.˰������," + vbCr
                        strSQL = strSQL + "     �Ƿ���ϸ���� = case when a.�Ƿ���ϸ = 1 then @true else @false end" + vbCr
                        strSQL = strSQL + "   from �ز�_B_����_Ӧ��Ӧ��ģ�� a " + vbCr
                        strSQL = strSQL + "   left join �ز�_B_����_˰��Ŀ¼ b on a.˰�Ѵ��� = b.˰�Ѵ���" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.ģ����� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@true", Josco.JsKernal.Common.Utilities.PulicParameters.CharTrue)
                        objSqlCommand.Parameters.AddWithValue("@false", Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse)
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateCommonData.Tables(Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateCommonData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objTempestateCommonData)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateCommonData = objTempestateCommonData
            getDataSet_YingshouYingfuMoban = True
            Exit Function
errProc:
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objTempestateCommonData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰�ز�_B_����_Ӧ��Ӧ��ģ�桱�����ݵĺϷ���
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
        Public Function doVerifyData_YingshouYingfuMoban( _
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

            doVerifyData_YingshouYingfuMoban = False

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
                strSQL = "select top 0 * from �ز�_B_����_Ӧ��Ӧ��ģ��"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "�ز�_B_����_Ӧ��Ӧ��ģ��", objDataSet) = False Then
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
                        Case Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMC, _
                            Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMXMC
                            '������
                        Case Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMX
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            If objPulicParameters.isIntegerString(strValue) = False Then
                                strErrMsg = "����[" + strField + "]ֻ������0��1��"
                                GoTo errProc
                            End If
                            Select Case strValue
                                Case "0", "1"
                                Case Else
                                    strErrMsg = "����[" + strField + "]ֻ������0��1��"
                                    GoTo errProc
                            End Select
                        Case Else
                            If strValue = "" Then
                                strValue = " "
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

                '��顰ģ����롱Լ��
                Dim strOldMBDM As String = ""
                Dim strNewMBDM As String = ""
                strNewMBDM = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from �ز�_B_����_Ӧ��Ӧ��ģ�� where ģ����� = @mbdm"
                        objListDictionary.Add("@mbdm", strNewMBDM)
                    Case Else
                        strOldMBDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM), "")
                        strSQL = "select * from �ز�_B_����_Ӧ��Ӧ��ģ�� where ģ����� = @mbdm and ģ����� <> @oldmbdm"
                        objListDictionary.Add("@mbdm", strNewMBDM)
                        objListDictionary.Add("@oldmbdm", strOldMBDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewMBDM + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '�������ֶ�
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewMBDM, strOldMBDM, "ģ�����", "�ز�_B_����_Ӧ��Ӧ��ģ��", objenumEditType) = False Then
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

            doVerifyData_YingshouYingfuMoban = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_YingshouYingfuMoban = False
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
                If Me.doVerifyData_YingshouYingfuMoban(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                                    Case Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMC, _
                                        Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMXMC
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
                                            Case Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMX
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), objPulicParameters.getObjectValue(strValue, 0))
                                            Case Else
                                                If strValue = "" Then strValue = " "
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " insert into �ز�_B_����_Ӧ��Ӧ��ģ�� (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM), "")

                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMC, _
                                        Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMXMC
                                        '������
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField + " = @A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField + " = @A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMX
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), objPulicParameters.getObjectValue(strValue, 0))
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " update �ز�_B_����_Ӧ��Ӧ��ģ�� set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where ģ����� = @oldkey" + vbCr
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
            doSaveData_YingshouYingfuMoban = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_YingshouYingfuMoban = False
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
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM), "")
                    'ɾ���¼�
                    strSQL = ""
                    strSQL = strSQL + " delete from �ز�_B_����_Ӧ��Ӧ��ģ�� "
                    strSQL = strSQL + " where ģ����� like @oldkey +'.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from �ز�_B_����_Ӧ��Ӧ��ģ�� "
                    strSQL = strSQL + " where ģ����� = @oldkey"
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
            doDeleteData_YingshouYingfuMoban = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function










        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_���򻮷֡���SQL���(�ԡ�������롱��������)
        ' ����
        '                          ��SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_QuyuHuafen() As String
            getTableSQL_QuyuHuafen = "select * from �ز�_B_����_���򻮷� order by �������"
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getQymc = False
            strErrMsg = ""
            strQymc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strQydm Is Nothing Then strQydm = ""

                '����
                strSQL = "select dbo.uf_estate_gg_getQyhfmc('" + strQydm + "')"
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
                    strQymc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), "")
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getQymc = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getQydm = False
            strErrMsg = ""
            strQydm = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strQymc Is Nothing Then strQymc = ""

                '����
                strSQL = ""
                strSQL = strSQL + " select * from �ز�_B_����_���򻮷�" + vbCr
                strSQL = strSQL + " where �������� = '" + strQymc + "'"
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
                    strQydm = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("�������"), "")
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getQydm = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_QuyuHuafen = False
            objestateCommonData = Nothing
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
                    objTempestateCommonData = New Josco.JSOA.Common.Data.estateCommonData(Josco.JSOA.Common.Data.estateCommonData.enumTableType.DC_B_GG_QUYUHUAFEN)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from �ز�_B_����_���򻮷� a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.������� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateCommonData.Tables(Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_QUYUHUAFEN))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateCommonData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objTempestateCommonData)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateCommonData = objTempestateCommonData
            getDataSet_QuyuHuafen = True
            Exit Function
errProc:
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objTempestateCommonData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰�ز�_B_����_���򻮷֡������ݵĺϷ���
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
        Public Function doVerifyData_QuyuHuafen( _
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

            doVerifyData_QuyuHuafen = False

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
                strSQL = "select top 0 * from �ز�_B_����_���򻮷�"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "�ز�_B_����_���򻮷�", objDataSet) = False Then
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

                '��顰������롱Լ��
                Dim strOldQYDM As String = ""
                Dim strNewQYDM As String = ""
                strNewQYDM = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_QUYUHUAFEN_QYDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from �ز�_B_����_���򻮷� where ������� = @qydm"
                        objListDictionary.Add("@qydm", strNewQYDM)
                    Case Else
                        strOldQYDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_QUYUHUAFEN_QYDM), "")
                        strSQL = "select * from �ز�_B_����_���򻮷� where ������� = @qydm and ������� <> @oldqydm"
                        objListDictionary.Add("@qydm", strNewQYDM)
                        objListDictionary.Add("@oldqydm", strOldQYDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewQYDM + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '��顰�������ơ�Լ��
                Dim strNewQYMC As String = ""
                strNewQYMC = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_QUYUHUAFEN_QYMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from �ز�_B_����_���򻮷� where �������� = @qymc"
                        objListDictionary.Add("@qymc", strNewQYMC)
                    Case Else
                        strSQL = "select * from �ز�_B_����_���򻮷� where �������� = @qymc and ������� <> @oldqydm"
                        objListDictionary.Add("@qymc", strNewQYMC)
                        objListDictionary.Add("@oldqydm", strOldQYDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewQYMC + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '�������ֶ�
                If Me.doValidCode_QuyuHuafen(strErrMsg, strUserId, strPassword, strNewQYDM, strOldQYDM, "�������", "�ز�_B_����_���򻮷�", objenumEditType) = False Then
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

            doVerifyData_QuyuHuafen = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_QuyuHuafen = False
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
                If Me.doVerifyData_QuyuHuafen(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                            strSQL = strSQL + " insert into �ز�_B_����_���򻮷� (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_QUYUHUAFEN_QYDM), "")

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
                            strSQL = strSQL + " update �ز�_B_����_���򻮷� set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where ������� = @oldkey" + vbCr
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
            doSaveData_QuyuHuafen = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_QuyuHuafen = False
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
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_QUYUHUAFEN_QYDM), "")
                    'ɾ���¼�
                    strSQL = ""
                    strSQL = strSQL + " delete from �ز�_B_����_���򻮷� "
                    strSQL = strSQL + " where ������� like @oldkey +'.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from �ز�_B_����_���򻮷� "
                    strSQL = strSQL + " where ������� = @oldkey"
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
            doDeleteData_QuyuHuafen = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function











        '----------------------------------------------------------------
        ' ��ȡ���ز�_B_����_�참��Ŀ����SQL���(�ԡ���Ŀ���롱��������)
        ' ����
        '                          ��SQL
        ' ��������
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function getTableSQL_BAXM() As String
            getTableSQL_BAXM = "select * from �ز�_B_����_�참��Ŀ order by ��Ŀ����"
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getBaxm_Xmmc = False
            strErrMsg = ""
            strXmmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strXmdm Is Nothing Then strXmdm = ""

                '����
                strSQL = "select ��Ŀ���� from �ز�_B_����_�참��Ŀ where ��Ŀ���� = '" + strXmdm + "'"
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
                    strXmmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), "")
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getBaxm_Xmmc = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getBaxm_Xmdm = False
            strErrMsg = ""
            strXmmc = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strXmmc Is Nothing Then strXmmc = ""

                '����
                strSQL = ""
                strSQL = strSQL + " select * from �ز�_B_����_�참��Ŀ" + vbCr
                strSQL = strSQL + " where ��Ŀ���� = '" + strXmmc + "'"
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
                    strXmdm = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("��Ŀ����"), "")
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getBaxm_Xmdm = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateCommonData As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_BAXM = False
            objestateCommonData = Nothing
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
                    objTempestateCommonData = New Josco.JSOA.Common.Data.estateCommonData(Josco.JSOA.Common.Data.estateCommonData.enumTableType.DC_B_GG_BAXM)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from �ز�_B_����_�참��Ŀ a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.��Ŀ���� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateCommonData.Tables(Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_BAXM))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateCommonData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objTempestateCommonData)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateCommonData = objTempestateCommonData
            getDataSet_BAXM = True
            Exit Function
errProc:
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objTempestateCommonData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰�ز�_B_����_�참��Ŀ�������ݵĺϷ���
        '     strErrMsg            ����������򷵻ش�����Ϣ
        '     strUserId            ���û���ʶ
        '     strPassword          ���û�����
        '     objOldData           ��������
        '     objNewData           ��������
        '     objenumEditType      ���༭����
        ' ����
        '     True                 ���Ϸ�
        '     False                �����Ϸ��������������
        ' ��������
        '     zengxianglin 2008-11-18 ����
        '----------------------------------------------------------------
        Public Function doVerifyData_BAXM( _
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

            doVerifyData_BAXM = False

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
                strSQL = "select top 0 * from �ز�_B_����_�참��Ŀ"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "�ز�_B_����_�참��Ŀ", objDataSet) = False Then
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

                '��顰��Ŀ���롱Լ��
                Dim strOldXMDM As String = ""
                Dim strNewXMDM As String = ""
                strNewXMDM = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_BAXM_XMDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from �ز�_B_����_�참��Ŀ where ��Ŀ���� = @xmdm"
                        objListDictionary.Add("@xmdm", strNewXMDM)
                    Case Else
                        strOldXMDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_BAXM_XMDM), "")
                        strSQL = "select * from �ز�_B_����_�참��Ŀ where ��Ŀ���� = @xmdm and ��Ŀ���� <> @oldxmdm"
                        objListDictionary.Add("@xmdm", strNewXMDM)
                        objListDictionary.Add("@oldxmdm", strOldXMDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewXMDM + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '��顰��Ŀ���ơ�Լ��
                Dim strNewXMMC As String = ""
                strNewXMMC = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_BAXM_XMMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from �ز�_B_����_�참��Ŀ where ��Ŀ���� = @xmmc"
                        objListDictionary.Add("@xmmc", strNewXMMC)
                    Case Else
                        strSQL = "select * from �ز�_B_����_�참��Ŀ where ��Ŀ���� = @xmmc and ��Ŀ���� <> @oldxmdm"
                        objListDictionary.Add("@xmmc", strNewXMMC)
                        objListDictionary.Add("@oldxmdm", strOldXMDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "����[" + strNewXMMC + "]�Ѿ����ڣ�"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '�������ֶ�
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewXMDM, strOldXMDM, "��Ŀ����", "�ز�_B_����_�참��Ŀ", objenumEditType) = False Then
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

            doVerifyData_BAXM = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_BAXM = False
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
                If Me.doVerifyData_BAXM(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                            strSQL = strSQL + " insert into �ز�_B_����_�참��Ŀ (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_BAXM_XMDM), "")

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
                            strSQL = strSQL + " update �ز�_B_����_�참��Ŀ set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where ��Ŀ���� = @oldkey" + vbCr
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
            doSaveData_BAXM = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_BAXM = False
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
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_BAXM_XMDM), "")
                    'ɾ���¼�
                    strSQL = ""
                    strSQL = strSQL + " delete from �ز�_B_����_�참��Ŀ "
                    strSQL = strSQL + " where ��Ŀ���� like @oldkey +'.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    'ɾ������
                    strSQL = ""
                    strSQL = strSQL + " delete from �ز�_B_����_�참��Ŀ "
                    strSQL = strSQL + " where ��Ŀ���� = @oldkey"
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
            doDeleteData_BAXM = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempDataSet As Josco.JSOA.Common.Data.estateCommonData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_WuyeXingzhi_List = False
            objDataSet = Nothing
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
                    objTempDataSet = New Josco.JSOA.Common.Data.estateCommonData(Josco.JSOA.Common.Data.estateCommonData.enumTableType.DC_B_GG_WUYEXINGZHI)

                    '����SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ִ�м���
                    With Me.m_objSqlDataAdapter
                        '׼��SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from �ز�_B_����_��ҵ���� a " + vbCr
                        strSQL = strSQL + " where a.�Ƿ����� = 1" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " and " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.��ʾ˳��,a.���ʴ��� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempDataSet.Tables(Josco.JSOA.Common.Data.estateCommonData.TABLE_DC_B_GG_WUYEXINGZHI))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempDataSet.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objTempDataSet)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objDataSet = objTempDataSet
            getDataSet_WuyeXingzhi_List = True
            Exit Function
errProc:
            Josco.JSOA.Common.Data.estateCommonData.SafeRelease(objTempDataSet)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

    End Class

End Namespace
