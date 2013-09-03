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
    ' ����    ��dacEstateCaiwu
    '
    ' ����������
    '     �ṩ�Բ�����ص����ݲ����
    ' ���ļ�¼��
    '     zengxianglin 2009-05-17 ����
    '----------------------------------------------------------------

    Public Class dacEstateCaiwu
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.DataAccess.dacEstateCaiwu)
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
        ' ���ļ�¼
        '     zengxianglin 2009-05-17 ����
        '----------------------------------------------------------------
        Public Function getDataSet_PJSY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData) As Boolean

            Dim objTempestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_PJSY = False
            objestateCaiwuData = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
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
                    objTempestateCaiwuData = New Josco.JSOA.Common.Data.estateCaiwuData(Josco.JSOA.Common.Data.estateCaiwuData.enumTableType.DC_B_CW_PIAOJUSHIYONG)

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
                        strSQL = strSQL + "     ������������ = dbo.uf_gg_getZzmcByZzdm(a.��������)," + vbCr
                        strSQL = strSQL + "     ������Ա���� = dbo.uf_gg_getRyzmByRydm(a.������Ա)," + vbCr
                        strSQL = strSQL + "     ������Ա���� = dbo.uf_gg_getRyzmByRydm(a.������Ա)," + vbCr
                        strSQL = strSQL + "     ������Ա���� = dbo.uf_gg_getRyzmByRydm(a.������Ա)," + vbCr
                        'zengxianglin 2008-11-18
                        strSQL = strSQL + "     �����Ա���� = dbo.uf_gg_getRyzmByRydm(a.�����Ա)," + vbCr
                        strSQL = strSQL + "     ˰������     = dbo.uf_estate_gg_getSfmc(a.˰�Ѵ���)," + vbCr
                        'zengxianglin 2008-11-18
                        'zengxianglin 2009-05-17
                        strSQL = strSQL + "     ������Ա���� = dbo.uf_gg_getRyzmByRydm(a.������Ա)," + vbCr
                        strSQL = strSQL + "     ������־���� = dbo.uf_estate_cw_getPiaojuHexiaoName(a.������־)," + vbCr
                        'zengxianglin 2009-05-17
                        strSQL = strSQL + "     ״̬��־���� = dbo.uf_estate_cw_getPiaojuStatusName(a.״̬��־)," + vbCr
                        strSQL = strSQL + "     ΨһƱ�ݺ��� = a.Ʊ�ݺ��� + '|' + cast(a.Ʊ������ as varchar(10)) + '|' + a.��������," + vbCr
                        strSQL = strSQL + "     ���ױ��=b.���ױ��" + vbCr
                        strSQL = strSQL + "   from �ز�_B_����_Ʊ��ʹ����� a " + vbCr
                        strSQL = strSQL + "   left join �ز�_V_ȫ������ b on a.ҵ���ʶ = b.Ψһ��ʶ" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.��������,a.Ʊ������,a.Ʊ�ݺ��� " + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateCaiwuData.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_PIAOJUSHIYONG))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateCaiwuData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objTempestateCaiwuData)
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateCaiwuData = objTempestateCaiwuData
            getDataSet_PJSY = True
            Exit Function
errProc:
            Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objTempestateCaiwuData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doPiaoju_Fafang = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[doPiaoju_Fafang]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strFGFH Is Nothing Then strFGFH = ""
                strFGFH = strFGFH.Trim
                If strFGFH = "" Then
                    strErrMsg = "����[doPiaoju_Fafang]δָ��[���ŷ���]��"
                    GoTo errProc
                End If
                If strPrefix Is Nothing Then strPrefix = ""
                strPrefix = strPrefix.Trim
                If strPJLX Is Nothing Then strPJLX = ""
                strPJLX = strPJLX.Trim
                If intMin <= 0 Or intMax <= 0 Then
                    strErrMsg = "����[doPiaoju_Fafang]ָ����Ч��[��������]��"
                    GoTo errProc
                End If
                Dim intTemp As Integer = 0
                If intMin > intMax Then
                    intTemp = intMax
                    intMax = intMin
                    intMin = intTemp
                End If
                'zengxianglin 2008-11-18
                If strFFPC Is Nothing Then strFFPC = ""
                strFFPC = strFFPC.Trim
                If strFFPC = "" Then
                    strErrMsg = "����[doPiaoju_Fafang]û��ָ��[����]��"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(strFFPC) = False Then
                    strErrMsg = "����[doPiaoju_Fafang]ָ����Ч��[����]��"
                    GoTo errProc
                End If
                Dim intFFPC As Integer
                intFFPC = CType(strFFPC, Integer)
                If intFFPC < 0 Then
                    strErrMsg = "����[doPiaoju_Fafang]ָ����Ч��[����]��"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-18

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ������
                Dim strNewPC As String = ""
                'zengxianglin 2008-11-18
                'If objdacCommon.getNewCode(strErrMsg, objSqlConnection, "Ʊ������", "��������", strFGFH, "�ز�_B_����_Ʊ��ʹ�����", True, strNewPC) = False Then
                '    GoTo errProc
                'End If
                strNewPC = strFFPC
                'zengxianglin 2008-11-18

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '����
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '�������
                    Dim intZTBZ As Integer = Josco.JSOA.Common.Data.estateCaiwuData.enumPiaojuStatus.Unused
                    Dim intLen As Integer = (intMax.ToString).Length
                    Dim i As Integer = 0
                    For i = intMin To intMax Step 1
                        strSQL = ""
                        strSQL = strSQL + " insert into �ز�_B_����_Ʊ��ʹ����� (" + vbCr
                        strSQL = strSQL + "   Ψһ��ʶ,Ʊ������,Ʊ�ݺ���,��������,Ʊ������,״̬��־,������Ա,��������" + vbCr
                        strSQL = strSQL + " ) values (" + vbCr
                        strSQL = strSQL + "   newid(), @pjph, @pjhm, @fgfh, @pjlx, @ztbz, @ffry, @ffrq" + vbCr
                        strSQL = strSQL + " )" + vbCr
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@pjph", CType(strNewPC, Integer))
                        objSqlCommand.Parameters.AddWithValue("@pjhm", strPrefix + i.ToString.PadLeft(intLen, "0".ToCharArray()(0)))
                        objSqlCommand.Parameters.AddWithValue("@fgfh", strFGFH)
                        objSqlCommand.Parameters.AddWithValue("@pjlx", strPJLX)
                        objSqlCommand.Parameters.AddWithValue("@ztbz", intZTBZ)
                        objSqlCommand.Parameters.AddWithValue("@ffry", strUserId)
                        objSqlCommand.Parameters.AddWithValue("@ffrq", Now)
                        objSqlCommand.ExecuteNonQuery()
                    Next
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
            doPiaoju_Fafang = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doPiaoju_Mark = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[doPiaoju_Mark]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim
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

                '����
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    Select Case objenumPiaojuStatus
                        Case Josco.JSOA.Common.Data.estateCaiwuData.enumPiaojuStatus.Used
                            Dim strZYSM As String = ""
                            Dim strJBRY As String = ""
                            'zengxianglin 2008-11-18
                            Dim strKPRQ As String = ""
                            Dim strBJRY As String = ""
                            Dim strSFDM As String = ""
                            Dim strSFDX As String = ""
                            Dim strSFBZ As String = ""
                            'zengxianglin 2008-11-18
                            Dim strYWBS As String = ""
                            Dim dblKPJE As Double = 0
                            If Not (objParams Is Nothing) Then
                                If objParams.Count > 0 Then
                                    dblKPJE = objPulicParameters.getObjectValue(objParams(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_KPJE), 0.0)
                                    strZYSM = objPulicParameters.getObjectValue(objParams(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_ZYSM), "")
                                    strYWBS = objPulicParameters.getObjectValue(objParams(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_YWBS), "")
                                    strJBRY = objPulicParameters.getObjectValue(objParams(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_JBRY), "")
                                    'zengxianglin 2008-11-18
                                    strBJRY = objPulicParameters.getObjectValue(objParams(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_BJRY), "")
                                    strKPRQ = objPulicParameters.getObjectValue(objParams(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_KPRQ), "", "yyyy-MM-dd")
                                    strSFDM = objPulicParameters.getObjectValue(objParams(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_SFDM), "")
                                    strSFDX = objPulicParameters.getObjectValue(objParams(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_SFDX), "")
                                    strSFBZ = objPulicParameters.getObjectValue(objParams(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_PIAOJUSHIYONG_SFBZ), "")
                                    'zengxianglin 2008-11-18
                                End If
                            End If
                            strSQL = ""
                            strSQL = strSQL + " update �ز�_B_����_Ʊ��ʹ����� set" + vbCr
                            strSQL = strSQL + "   ״̬��־ = @ztbz," + vbCr
                            strSQL = strSQL + "   ������Ա = @jbry," + vbCr
                            strSQL = strSQL + "   ��Ʊ���� = @kprq," + vbCr
                            'zengxianglin 2008-11-18
                            strSQL = strSQL + "   �����Ա = @bjry," + vbCr
                            strSQL = strSQL + "   ������� = @bjrq," + vbCr
                            strSQL = strSQL + "   ˰�Ѵ��� = @sfdm," + vbCr
                            strSQL = strSQL + "   �ո����� = @sfdx," + vbCr
                            strSQL = strSQL + "   �ո���־ = @sfbz," + vbCr
                            'zengxianglin 2008-11-18
                            strSQL = strSQL + "   ��Ʊ��� = @kpje," + vbCr
                            strSQL = strSQL + "   ժҪ˵�� = @zysm," + vbCr
                            strSQL = strSQL + "   ҵ���ʶ = @ywbs " + vbCr
                            strSQL = strSQL + " where Ψһ��ʶ = @wybs" + vbCr
                            strSQL = strSQL + " and   ״̬��־ = 0" + vbCr           '����������Ʊ��
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.Parameters.Clear()
                            objSqlCommand.Parameters.AddWithValue("@ztbz", CType(objenumPiaojuStatus, Integer))
                            objSqlCommand.Parameters.AddWithValue("@jbry", strJBRY)
                            'zengxianglin 2008-11-18
                            'objSqlCommand.Parameters.AddWithValue("@kprq", Now)
                            objSqlCommand.Parameters.AddWithValue("@kprq", CType(strKPRQ, System.DateTime))
                            objSqlCommand.Parameters.AddWithValue("@bjry", strBJRY)
                            objSqlCommand.Parameters.AddWithValue("@bjrq", Now)
                            objSqlCommand.Parameters.AddWithValue("@sfdm", strSFDM)
                            objSqlCommand.Parameters.AddWithValue("@sfdx", strSFDX)
                            objSqlCommand.Parameters.AddWithValue("@sfbz", strSFBZ)
                            'zengxianglin 2008-11-18
                            objSqlCommand.Parameters.AddWithValue("@kpje", dblKPJE)
                            objSqlCommand.Parameters.AddWithValue("@zysm", strZYSM)
                            objSqlCommand.Parameters.AddWithValue("@ywbs", strYWBS)
                            objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                            objSqlCommand.ExecuteNonQuery()
                        Case Josco.JSOA.Common.Data.estateCaiwuData.enumPiaojuStatus.Zuofei
                            strSQL = ""
                            strSQL = strSQL + " update �ز�_B_����_Ʊ��ʹ����� set" + vbCr
                            strSQL = strSQL + "   ״̬��־ = @ztbz," + vbCr
                            strSQL = strSQL + "   ������Ա = @zfry," + vbCr
                            strSQL = strSQL + "   �������� = @zfrq " + vbCr
                            strSQL = strSQL + " where Ψһ��ʶ = @wybs" + vbCr
                            strSQL = strSQL + " and   ״̬��־ = 1" + vbCr           '����������Ʊ��
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.Parameters.Clear()
                            objSqlCommand.Parameters.AddWithValue("@ztbz", CType(objenumPiaojuStatus, Integer))
                            objSqlCommand.Parameters.AddWithValue("@zfry", strUserId)
                            objSqlCommand.Parameters.AddWithValue("@zfrq", Now)
                            objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                            objSqlCommand.ExecuteNonQuery()
                        Case Josco.JSOA.Common.Data.estateCaiwuData.enumPiaojuStatus.Shouhui
                            strSQL = ""
                            strSQL = strSQL + " update �ز�_B_����_Ʊ��ʹ����� set" + vbCr
                            strSQL = strSQL + "   ״̬��־ = @ztbz" + vbCr
                            strSQL = strSQL + " where Ψһ��ʶ = @wybs" + vbCr
                            strSQL = strSQL + " and   ״̬��־ = 0" + vbCr           '����������Ʊ��
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.Parameters.Clear()
                            objSqlCommand.Parameters.AddWithValue("@ztbz", CType(objenumPiaojuStatus, Integer))
                            objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                            objSqlCommand.ExecuteNonQuery()
                    End Select
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
            doPiaoju_Mark = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doPiaoju_Delete = False
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
                strWYBS = strWYBS.Trim
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

                    strSQL = ""
                    strSQL = strSQL + " delete from �ز�_B_����_Ʊ��ʹ����� " + vbCr
                    strSQL = strSQL + " where Ψһ��ʶ = @oldkey" + vbCr
                    strSQL = strSQL + " and   ״̬��־ in (0,4)" + vbCr     '���������������ջ�Ʊ��
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strWYBS)
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
            doPiaoju_Delete = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            isPjhmContinue = False
            blnIS = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strFGFH Is Nothing Then strFGFH = ""
                strFGFH = strFGFH.Trim
                If strPJPH Is Nothing Then strPJPH = ""
                strPJPH = strPJPH.Trim
                If strPJHM Is Nothing Then strPJHM = ""
                strPJHM = strPJHM.Trim
                If strFGFH = "" Or strPJPH = "" Or strPJHM = "" Then
                    strErrMsg = "����[��������]��[Ʊ������]��[Ʊ�ݺ���]�������ṩ��"
                    GoTo errProc
                End If

                '��ȡ���ݿ�����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '���㣺����֮ǰ���Ƿ��С�δʹ�á���Ʊ�ݣ�
                strSQL = ""
                strSQL = strSQL + " select count(*) from �ز�_B_����_Ʊ��ʹ�����" + vbCr
                strSQL = strSQL + " where �������� = '" + strFGFH + "'" + vbCr
                strSQL = strSQL + " and   Ʊ������ =  " + strPJPH + " " + vbCr
                strSQL = strSQL + " and   Ʊ�ݺ��� < '" + strPJHM + "'" + vbCr
                strSQL = strSQL + " and   ״̬��־ = 0" + vbCr 'δʹ��
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                If objDataSet.Tables.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Dim intCount As Integer = 0
                        intCount = CType(objDataSet.Tables(0).Rows(0).Item(0), Integer)
                        If intCount < 1 Then
                            'û�У���������
                            blnIS = True
                        End If
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isPjhmContinue = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_ES_YSYF = False
            objestateCaiwuData = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_ES_YSYF]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateCaiwuData = New Josco.JSOA.Common.Data.estateCaiwuData(Josco.JSOA.Common.Data.estateCaiwuData.enumTableType.DC_B_CW_ES_YINGSHOUYINGFU)
                    If strQRSH = "" Then
                        Exit Try
                    End If

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
                        strSQL = strSQL + "     ˰������   = dbo.uf_estate_gg_getSfmc(a.˰�Ѵ���)," + vbCr
                        strSQL = strSQL + "     ʵ�ս��   = b.ʵ�ս��," + vbCr
                        strSQL = strSQL + "     Ӧ�ս���� = case when a.�ո���־ = '��' then a.Ӧ�ս�� else null end," + vbCr
                        strSQL = strSQL + "     Ӧ�ս� = case when a.�ո���־ = '��' then null else a.Ӧ�ս�� end " + vbCr
                        strSQL = strSQL + "   from" + vbCr
                        strSQL = strSQL + "   (" + vbCr
                        strSQL = strSQL + "     select a.*" + vbCr
                        strSQL = strSQL + "     from �ز�_B_����_����Ӧ��Ӧ�� a " + vbCr
                        strSQL = strSQL + "     where a.ȷ����� = @qrsh" + vbCr
                        strSQL = strSQL + "   ) a" + vbCr
                        strSQL = strSQL + "   left join" + vbCr
                        strSQL = strSQL + "   (" + vbCr
                        strSQL = strSQL + "     select ȷ�����,˰�Ѵ���,�ո�����,�ո���־,ʵ�ս��=sum(�������)" + vbCr
                        strSQL = strSQL + "     from �ز�_B_����_����ʵ��ʵ��" + vbCr
                        strSQL = strSQL + "     where ȷ����� = @qrsh" + vbCr
                        strSQL = strSQL + "     and   rtrim(isnull(�������,'')) <> ''" + vbCr
                        strSQL = strSQL + "     group by ȷ�����,˰�Ѵ���,�ո�����,�ո���־" + vbCr
                        strSQL = strSQL + "   ) b on a.ȷ�����=b.ȷ����� and a.˰�Ѵ���=b.˰�Ѵ��� and a.�ո�����=b.�ո����� and a.�ո���־=b.�ո���־" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.Ӧ������" + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@qrsh", strQRSH)
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateCaiwuData.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_YINGSHOUYINGFU))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateCaiwuData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objTempestateCaiwuData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateCaiwuData = objTempestateCaiwuData
            getDataSet_ES_YSYF = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objTempestateCaiwuData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰�ز�_B_����_����Ӧ��Ӧ���������ݵĺϷ���
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
        Public Function doVerifyData_ES_YSYF( _
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

            doVerifyData_ES_YSYF = False

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
                strSQL = "select top 0 * from �ز�_B_����_����Ӧ��Ӧ��"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "�ز�_B_����_����Ӧ��Ӧ��", objDataSet) = False Then
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
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFMC, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SSJE, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_S, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_F
                            '������
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS
                            '�Զ���
                            If strValue = "" Then
                                If objdacCommon.getNewGUID(strErrMsg, strUserId, strPassword, strValue) = False Then
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSRQ
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(strValue) = False Then
                                strErrMsg = "����[" + strValue + "]����Ч�����ڣ�"
                                GoTo errProc
                            End If
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_KSRQ, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JSRQ
                            If strValue <> "" Then
                                If objPulicParameters.isDatetimeString(strValue) = False Then
                                    strErrMsg = "����[" + strValue + "]����Ч�����ڣ�"
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFZT, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JZYF
                            If strValue <> "" Then
                                If objPulicParameters.isIntegerString(strValue) = False Then
                                    strErrMsg = "����[" + strValue + "]����Ч�����֣�"
                                    GoTo errProc
                                End If
                            End If
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE
                            If strValue <> "" Then
                                If objPulicParameters.isFloatString(strValue) = False Then
                                    strErrMsg = "����[" + strValue + "]����Ч����ֵ��"
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QRSH, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDM, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDX, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFBZ
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

            doVerifyData_ES_YSYF = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_ES_YSYF = False
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
                If Me.doVerifyData_ES_YSYF(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                                    Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SSJE, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_S, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_F
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
                                            Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSRQ, _
                                                Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_KSRQ, _
                                                Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JSRQ
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, System.DateTime))
                                                End If
                                            Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFZT, _
                                                Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JZYF
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), intDefaultInt)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, Integer))
                                                End If
                                            Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(intDefaultInt, Double))
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, Double))
                                                End If
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " insert into �ز�_B_����_����Ӧ��Ӧ�� (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS), "")

                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SSJE, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_S, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_F
                                        '������
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField + " = @A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField + " = @A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSRQ, _
                                                Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_KSRQ, _
                                                Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JSRQ
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, System.DateTime))
                                                End If
                                            Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFZT, _
                                                Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JZYF
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), intDefaultInt)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, Integer))
                                                End If
                                            Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(intDefaultInt, Double))
                                                Else
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
                            strSQL = strSQL + " update �ز�_B_����_����Ӧ��Ӧ�� set " + vbCr
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
            doSaveData_ES_YSYF = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_ES_YSYF = False
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
                    strSQL = strSQL + " delete from �ز�_B_����_����Ӧ��Ӧ�� " + vbCr
                    strSQL = strSQL + " where Ψһ��ʶ = @oldkey" + vbCr
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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doDeleteData_ES_YSYF = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doMakeYSYF = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strMBDM Is Nothing Then strMBDM = ""
                If strMBDM = "" Then
                    Exit Try
                End If
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim
                If strQRSH = "" Then
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

                '����
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '���һ��ƻ�
                    If blnClear = True Then
                        strSQL = ""
                        strSQL = strSQL + " delete from �ز�_B_����_����Ӧ��Ӧ�� " + vbCr
                        strSQL = strSQL + " where ȷ����� = @qrsh" + vbCr
                        strSQL = strSQL + " and   isnull(�ո�״̬,1) = 1" + vbCr
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@qrsh", strQRSH)
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.ExecuteNonQuery()
                    End If

                    '����һ��ƻ�
                    strSQL = ""
                    strSQL = strSQL + " insert into �ز�_B_����_����Ӧ��Ӧ�� (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,ȷ�����," + vbCr
                    strSQL = strSQL + "   ˰�Ѵ���,�ո�����,�ո���־,Ӧ������," + vbCr
                    strSQL = strSQL + "   �ո�״̬" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=newid(),ȷ�����=@qrsh," + vbCr
                    strSQL = strSQL + "   ˰�Ѵ���,�ո�����,�ո���־,Ӧ������=@ysrq," + vbCr
                    strSQL = strSQL + "   �ո�״̬=@sfzt" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_Ӧ��Ӧ��ģ��" + vbCr
                    strSQL = strSQL + " where ģ����� like @mbdm + '.%'" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@qrsh", strQRSH)
                    objSqlCommand.Parameters.AddWithValue("@ysrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@mbdm", strMBDM)
                    objSqlCommand.Parameters.AddWithValue("@sfzt", CType(Josco.JSOA.Common.Data.estateCaiwuData.enumSFZT.Normal, Integer))
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
            doMakeYSYF = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            isFashengShishou = False
            blnIS = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[isFashengShishou]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim
                If strQRSH = "" Then
                    Exit Try
                End If

                '��ȡ���ݿ�����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '����
                strSQL = ""
                strSQL = strSQL + " select count(*) from �ز�_B_����_����ʵ��ʵ��" + vbCr
                strSQL = strSQL + " where ȷ����� = '" + strQRSH + "'" + vbCr
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                If objDataSet.Tables.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Dim intCount As Integer = 0
                        intCount = CType(objDataSet.Tables(0).Rows(0).Item(0), Integer)
                        If intCount > 0 Then
                            '�ѷ���ʵ����֧
                            blnIS = True
                        End If
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isFashengShishou = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_ES_SSSF = False
            objestateCaiwuData = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_ES_SSSF]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateCaiwuData = New Josco.JSOA.Common.Data.estateCaiwuData(Josco.JSOA.Common.Data.estateCaiwuData.enumTableType.DC_B_CW_ES_SHISHOUSHIFU)
                    If strQRSH = "" Then
                        Exit Try
                    End If

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
                        strSQL = strSQL + "     ˰������     = dbo.uf_estate_gg_getSfmc(a.˰�Ѵ���)," + vbCr
                        strSQL = strSQL + "     ������Ա���� = dbo.uf_gg_getRyzmByRydm(a.������Ա)," + vbCr
                        strSQL = strSQL + "     ����������� = dbo.uf_gg_getZzmcByZzdm(a.�������)," + vbCr
                        strSQL = strSQL + "     ����������� = dbo.uf_gg_getRyzmByRydm(a.�������)," + vbCr
                        strSQL = strSQL + "     �Ƿ����     = case when rtrim(isnull(a.�������,'')) <> '' then @true else @false end," + vbCr
                        strSQL = strSQL + "     ��˱�־���� = case when a.��˱�־ = 1    then @true else @false end," + vbCr
                        strSQL = strSQL + "     ���������   = case when a.�ո���־ = '��' then a.������� else null end," + vbCr
                        strSQL = strSQL + "     ������   = case when a.�ո���־ = '��' then null else a.������� end" + vbCr
                        strSQL = strSQL + "   from" + vbCr
                        strSQL = strSQL + "   (" + vbCr
                        strSQL = strSQL + "     select a.*" + vbCr
                        strSQL = strSQL + "     from �ز�_B_����_����ʵ��ʵ�� a " + vbCr
                        strSQL = strSQL + "     where a.ȷ����� = @qrsh" + vbCr
                        strSQL = strSQL + "   ) a" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.��������" + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@true", Josco.JsKernal.Common.Utilities.PulicParameters.CharTrue)
                        objSqlCommand.Parameters.AddWithValue("@false", Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse)
                        objSqlCommand.Parameters.AddWithValue("@qrsh", strQRSH)
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateCaiwuData.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateCaiwuData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objTempestateCaiwuData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateCaiwuData = objTempestateCaiwuData
            getDataSet_ES_SSSF = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objTempestateCaiwuData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ���ݡ�Ψһ��ʶ����ȡ���ز�_B_����_����ʵ��ʵ������ȫ���ݵ����ݼ�
        ' �ԡ��������ڡ���������
        '     strErrMsg                  ����������򷵻ش�����Ϣ
        '     strUserId                  ���û���ʶ
        '     strPassword                ���û�����
        '     strWYBS                    ��Ψһ��ʶ
        '     objestateCaiwuData         ����Ϣ���ݼ�
        ' ����
        '     True                       ���ɹ�
        '     False                      ��ʧ��
        '----------------------------------------------------------------
        Public Function getDataSet_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByRef objestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData) As Boolean

            Dim objTempestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_ES_SSSF = False
            objestateCaiwuData = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_ES_SSSF]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateCaiwuData = New Josco.JSOA.Common.Data.estateCaiwuData(Josco.JSOA.Common.Data.estateCaiwuData.enumTableType.DC_B_CW_ES_SHISHOUSHIFU)
                    If strWYBS = "" Then
                        Exit Try
                    End If

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
                        strSQL = strSQL + "     ˰������     = dbo.uf_estate_gg_getSfmc(a.˰�Ѵ���)," + vbCr
                        strSQL = strSQL + "     ������Ա���� = dbo.uf_gg_getRyzmByRydm(a.������Ա)," + vbCr
                        strSQL = strSQL + "     ����������� = dbo.uf_gg_getZzmcByZzdm(a.�������)," + vbCr
                        strSQL = strSQL + "     ����������� = dbo.uf_gg_getRyzmByRydm(a.�������)," + vbCr
                        strSQL = strSQL + "     �Ƿ����     = case when rtrim(isnull(a.�������,'')) <> '' then @true else @false end," + vbCr
                        strSQL = strSQL + "     ��˱�־���� = case when a.��˱�־ = 1    then @true else @false end," + vbCr
                        strSQL = strSQL + "     ���������   = case when a.�ո���־ = '��' then a.������� else null end," + vbCr
                        strSQL = strSQL + "     ������   = case when a.�ո���־ = '��' then null else a.������� end" + vbCr
                        strSQL = strSQL + "   from" + vbCr
                        strSQL = strSQL + "   (" + vbCr
                        strSQL = strSQL + "     select a.*" + vbCr
                        strSQL = strSQL + "     from �ز�_B_����_����ʵ��ʵ�� a " + vbCr
                        strSQL = strSQL + "     where a.Ψһ��ʶ = @wybs" + vbCr
                        strSQL = strSQL + "   ) a" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        strSQL = strSQL + " order by a.��������" + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@true", Josco.JsKernal.Common.Utilities.PulicParameters.CharTrue)
                        objSqlCommand.Parameters.AddWithValue("@false", Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse)
                        objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateCaiwuData.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateCaiwuData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objTempestateCaiwuData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateCaiwuData = objTempestateCaiwuData
            getDataSet_ES_SSSF = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objTempestateCaiwuData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��顰�ز�_B_����_����ʵ��ʵ���������ݵĺϷ���
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
        Public Function doVerifyData_ES_SSSF( _
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

            doVerifyData_ES_SSSF = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[doVerifyData_ES_SSSF]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����[doVerifyData_ES_SSSF]δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����[doVerifyData_ES_SSSF]δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '��ȡ��ṹ����
                strSQL = "select top 0 * from �ز�_B_����_����ʵ��ʵ��"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "�ز�_B_����_����ʵ��ʵ��", objDataSet) = False Then
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
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRYMC, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDWMC, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSHMC, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFSH, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZMC, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_S, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_F
                            '��ʾ��
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS
                            '�Զ���
                            If strValue = "" Then
                                If objdacCommon.getNewGUID(strErrMsg, strUserId, strPassword, strValue) = False Then
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSRQ
                            If strValue = "" Then
                                strErrMsg = "����û������[" + strField + "]��"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(strValue) = False Then
                                strErrMsg = "����[" + strValue + "]����Ч�����ڣ�"
                                GoTo errProc
                            End If
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHRQ
                            If strValue <> "" Then
                                If objPulicParameters.isDatetimeString(strValue) = False Then
                                    strErrMsg = "����[" + strValue + "]����Ч�����ڣ�"
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZ
                            If strValue <> "" Then
                                If objPulicParameters.isIntegerString(strValue) = False Then
                                    strErrMsg = "����[" + strValue + "]����Ч����ֵ��"
                                    GoTo errProc
                                End If
                            Else
                                strValue = "0"
                            End If
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE
                            If strValue <> "" Then
                                If objPulicParameters.isFloatString(strValue) = False Then
                                    strErrMsg = "����[" + strValue + "]����Ч����ֵ��"
                                    GoTo errProc
                                End If
                            Else
                                strValue = "0"
                            End If

                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_PJHM, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRY
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

            doVerifyData_ES_SSSF = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doSaveData_ES_SSSF = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[doSaveData_ES_SSSF]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "����[doSaveData_ES_SSSF]δ�����µ����ݣ�"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "����[doSaveData_ES_SSSF]δ����ɵ����ݣ�"
                            GoTo errProc
                        End If
                End Select

                '�������
                If Me.doVerifyData_ES_SSSF(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                                    Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRYMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDWMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSHMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFSH, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_S, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_F
                                        '��ʾ��
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField
                                            strValues = "@A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField
                                            strValues = strValues + "," + "@A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSRQ, _
                                                Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHRQ
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, System.DateTime))
                                                End If
                                            Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZ
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), intDefaultInt)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, Integer))
                                                End If
                                            Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(intDefaultInt, Double))
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, Double))
                                                End If
                                            Case Else
                                                objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), strValue)
                                        End Select
                                End Select
                            Next

                            '׼��SQL���
                            strSQL = ""
                            strSQL = strSQL + " insert into �ز�_B_����_����ʵ��ʵ�� (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '��ȡ����
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS), "")

                            '�����ֶ��б��ֶ�ֵ
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            strFields = ""
                            strValues = ""
                            For i = 0 To intCount - 1 Step 1
                                strField = objPulicParameters.getObjectValue(objNewData.GetKey(i), "")
                                strValue = objPulicParameters.getObjectValue(objNewData.Item(i), "")
                                Select Case strField
                                    Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRYMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDWMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSHMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFSH, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_S, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_F
                                        '��ʾ��
                                    Case Else
                                        If strFields = "" Then
                                            strFields = strField + " = @A" + i.ToString()
                                        Else
                                            strFields = strFields + "," + strField + " = @A" + i.ToString()
                                        End If
                                        Select Case strField
                                            Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSRQ, _
                                                Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHRQ
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, System.DateTime))
                                                End If
                                            Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZ
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), intDefaultInt)
                                                Else
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(strValue, Integer))
                                                End If
                                            Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE
                                                If strValue = "" Then
                                                    objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(intDefaultInt, Double))
                                                Else
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
                            strSQL = strSQL + " update �ز�_B_����_����ʵ��ʵ�� set " + vbCr
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
            doSaveData_ES_SSSF = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doAddNew_ES_SSSF = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[doAddNew_ES_SSSF]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    Exit Try
                End If
                If objNewData.Count < 1 Then
                    Exit Try
                End If

                '��ȡ����
                Dim strWYBS As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS), "")
                Dim strQRSH As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH), "")
                Dim strFSJE As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE), "")
                Dim strPJHM As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_PJHM), "")
                Dim strZYSM As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_ZYSM), "")
                Dim strKHMC As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_KHMC), "")
                Dim strJBRY As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRY), "")
                Dim strJBDW As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDW), "")

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

                '����
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    strSQL = ""
                    strSQL = strSQL + " insert into �ز�_B_����_����ʵ��ʵ�� (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,ȷ�����,Ʊ�ݺ���,˰�Ѵ���,�ո�����,�ո���־," + vbCr
                    strSQL = strSQL + "   ��������,�������,ժҪ˵��,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա,�������,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=newid(),ȷ�����,Ʊ�ݺ���=@pjhm,˰�Ѵ���,�ո�����,�ո���־," + vbCr
                    strSQL = strSQL + "   ��������=@fsrq,�������=@fsje,ժҪ˵��=@zysm,�ͻ�����=@khmc," + vbCr
                    strSQL = strSQL + "   ������Ա=@jbry,�������=@jbdw,�ƻ���ʶ=@wybs" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_����Ӧ��Ӧ��" + vbCr
                    strSQL = strSQL + " where Ψһ��ʶ = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@pjhm", strPJHM)
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", CType(strFSJE, Double))
                    objSqlCommand.Parameters.AddWithValue("@zysm", strZYSM)
                    objSqlCommand.Parameters.AddWithValue("@khmc", strKHMC)
                    objSqlCommand.Parameters.AddWithValue("@jbry", strJBRY)
                    objSqlCommand.Parameters.AddWithValue("@jbdw", strJBDW)
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
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
            doAddNew_ES_SSSF = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' ��ָ�����ָ����ʽ��ת����
        ' ͬһ�ͻ�����ͬ�ո�����ʱ�Ľ�ת����
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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objDataSet As Josco.JSOA.Common.Data.estateCaiwuData = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCustomer As New Josco.JsKernal.DataAccess.dacCustomer
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doJiezhuan_ES_SSSF = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[doJiezhuan_ES_SSSF]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    Exit Try
                End If
                If objNewData.Count < 1 Then
                    Exit Try
                End If

                '��ȡ����
                Dim strWYBS As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS), "")
                Dim strQRSH As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH), "")
                Dim strFSJE As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE), "")
                Dim strSFDM As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM), "")
                Dim strSFMC As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC), "")
                Dim strSFDX As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX), "")
                Dim strSFBZ As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ), "")
                Dim dblFSJE As Double = objPulicParameters.getObjectValue(strFSJE, 0.0)

                '��ȡҪ��ת��������Ϣ
                If Me.getDataSet_ES_SSSF(strErrMsg, strUserId, strPassword, strWYBS, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU) Is Nothing Then
                    strErrMsg = "����Ҫ��ת�����ݲ����ڣ�"
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows.Count < 1 Then
                    strErrMsg = "����Ҫ��ת�����ݲ����ڣ�"
                    GoTo errProc
                End If
                Dim strSrcSFMC As String = ""
                Dim dblSrcFSJE As Double = 0
                With objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows(0)
                    strSrcSFMC = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC), "")
                    dblSrcFSJE = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE), 0.0)
                End With
                If dblSrcFSJE < dblFSJE Then
                    strErrMsg = "�������㣡"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����Ա�ĵ�λ��Ϣ
                Dim strBMMC As String = ""
                Dim strJBDW As String = ""
                If objdacCustomer.getBmdmAndBmmcByRydm(strErrMsg, objSqlConnection, strUserId, strJBDW, strBMMC) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '����
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '�Ǽǽ�ת�����
                    strSQL = ""
                    strSQL = strSQL + " insert into �ز�_B_����_����ʵ��ʵ�� (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,ȷ�����,Ʊ�ݺ���,˰�Ѵ���,�ո�����,�ո���־," + vbCr
                    strSQL = strSQL + "   ��������,�������,ժҪ˵��,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա,�������,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=newid(),ȷ�����,Ʊ�ݺ���,˰�Ѵ���=@sfdm,�ո�����=@sfdx,�ո���־=@sfbz," + vbCr
                    strSQL = strSQL + "   ��������=@fsrq,�������=@fsje,ժҪ˵��=@zysm,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա=@jbry,�������=@jbdw,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_����ʵ��ʵ��" + vbCr
                    strSQL = strSQL + " where Ψһ��ʶ = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@sfdm", strSFDM)
                    objSqlCommand.Parameters.AddWithValue("@sfdx", strSFDX)
                    objSqlCommand.Parameters.AddWithValue("@sfbz", strSFBZ)
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", dblFSJE)
                    objSqlCommand.Parameters.AddWithValue("@zysm", "[" + strSFDX + "][" + strSrcSFMC + "]ת��")
                    objSqlCommand.Parameters.AddWithValue("@jbry", strUserId)
                    objSqlCommand.Parameters.AddWithValue("@jbdw", strJBDW)
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '���ԭ������
                    strSQL = ""
                    strSQL = strSQL + " insert into �ز�_B_����_����ʵ��ʵ�� (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,ȷ�����,Ʊ�ݺ���,˰�Ѵ���,�ո�����,�ո���־," + vbCr
                    strSQL = strSQL + "   ��������,�������,ժҪ˵��,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա,�������,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=newid(),ȷ�����,Ʊ�ݺ���,˰�Ѵ���,�ո�����,�ո���־," + vbCr
                    strSQL = strSQL + "   ��������=@fsrq,�������=@fsje,ժҪ˵��=@zysm,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա=@jbry,�������=@jbdw,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_����ʵ��ʵ��" + vbCr
                    strSQL = strSQL + " where Ψһ��ʶ = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", -dblFSJE)
                    objSqlCommand.Parameters.AddWithValue("@zysm", "ת��[" + strSFDX + "][" + strSFMC + "]")
                    objSqlCommand.Parameters.AddWithValue("@jbry", strUserId)
                    objSqlCommand.Parameters.AddWithValue("@jbdw", strJBDW)
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
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
            Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doJiezhuan_ES_SSSF = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objTempestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            getDataSet_ES_SSSF = False
            objestateCaiwuData = Nothing
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getDataSet_ES_SSSF]δָ��[�����û�]��"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����
                Try
                    '�������ݼ�
                    objTempestateCaiwuData = New Josco.JSOA.Common.Data.estateCaiwuData(Josco.JSOA.Common.Data.estateCaiwuData.enumTableType.DC_B_CW_ES_SHISHOUSHIFU)

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
                        strSQL = strSQL + "     ˰������     = dbo.uf_estate_gg_getSfmc(a.˰�Ѵ���)," + vbCr
                        strSQL = strSQL + "     ������Ա���� = dbo.uf_gg_getRyzmByRydm(a.������Ա)," + vbCr
                        strSQL = strSQL + "     ����������� = dbo.uf_gg_getZzmcByZzdm(a.�������)," + vbCr
                        strSQL = strSQL + "     ����������� = dbo.uf_gg_getRyzmByRydm(a.�������)," + vbCr
                        strSQL = strSQL + "     �Ƿ����     = case when rtrim(isnull(a.�������,'')) <> '' then @true else @false end," + vbCr
                        strSQL = strSQL + "     ��˱�־���� = case when a.��˱�־ = 1    then @true else @false end," + vbCr
                        strSQL = strSQL + "     ���������   = case when a.�ո���־ = '��' then a.������� else null end," + vbCr
                        strSQL = strSQL + "     ������   = case when a.�ո���־ = '��' then null else a.������� end" + vbCr
                        strSQL = strSQL + "   from" + vbCr
                        strSQL = strSQL + "   (" + vbCr
                        strSQL = strSQL + "     select a.*" + vbCr
                        strSQL = strSQL + "     from �ز�_B_����_����ʵ��ʵ�� a " + vbCr
                        strSQL = strSQL + "   ) a" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.��������" + vbCr

                        '���ò���
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@true", Josco.JsKernal.Common.Utilities.PulicParameters.CharTrue)
                        objSqlCommand.Parameters.AddWithValue("@false", Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse)
                        .SelectCommand = objSqlCommand

                        'ִ�в���
                        .Fill(objTempestateCaiwuData.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempestateCaiwuData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objTempestateCaiwuData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            objestateCaiwuData = objTempestateCaiwuData
            getDataSet_ES_SSSF = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objTempestateCaiwuData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doDeleteData_ES_SSSF = False
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
                    strSQL = strSQL + " delete from �ز�_B_����_����ʵ��ʵ�� " + vbCr
                    strSQL = strSQL + " where Ψһ��ʶ = @oldkey" + vbCr
                    strSQL = strSQL + " and   rtrim(isnull(�������,'')) = ''" + vbCr
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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doDeleteData_ES_SSSF = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objDataSet As Josco.JSOA.Common.Data.estateCaiwuData = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doShenhe_ES_SSSF = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[doShenhe_ES_SSSF]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    Exit Try
                End If
                If objNewData.Count < 1 Then
                    Exit Try
                End If

                '��ȡ����
                Dim strWYBS As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS), "")
                Dim strQRSH As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH), "")
                Dim strFSJE As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE), "")
                Dim strSFDM As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM), "")
                Dim strSFMC As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC), "")
                Dim strSFDX As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX), "")
                Dim strSFBZ As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ), "")
                Dim strPJHM As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_PJHM), "")
                Dim dblFSJE As Double = objPulicParameters.getObjectValue(strFSJE, 0.0)

                '��ȡ������Ϣ
                If Me.getDataSet_ES_SSSF(strErrMsg, strUserId, strPassword, strWYBS, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU) Is Nothing Then
                    strErrMsg = "����Ҫ��˵����ݲ����ڣ�"
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows.Count < 1 Then
                    strErrMsg = "����Ҫ��˵����ݲ����ڣ�"
                    GoTo errProc
                End If
                Dim intSHBZ As Integer = 0
                With objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows(0)
                    intSHBZ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZ), 0)
                End With
                If intSHBZ = 1 Then
                    strErrMsg = "���󣺸ÿ����Ѿ�������ˣ�"
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

                '����
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    If blnTongguo = False Then
                        '��ͨ����
                        strSQL = ""
                        strSQL = strSQL + " update �ز�_B_����_����ʵ��ʵ�� set" + vbCr
                        strSQL = strSQL + "   ��˱�־ = 1," + vbCr
                        strSQL = strSQL + "   ������� = @shrq" + vbCr
                        strSQL = strSQL + " from �ز�_B_����_����ʵ��ʵ��" + vbCr
                        strSQL = strSQL + " where Ψһ��ʶ = @wybs" + vbCr
                        strSQL = strSQL + " and   ��˱�־ <> 1" + vbCr
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@shrq", Now)
                        objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    Else
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@shrq", Now)
                        objSqlCommand.Parameters.AddWithValue("@cwsh", strUserId)
                        'ͨ����
                        strSQL = ""
                        strSQL = strSQL + " update �ز�_B_����_����ʵ��ʵ�� set" + vbCr
                        strSQL = strSQL + "   ��˱�־ = 1" + vbCr
                        strSQL = strSQL + "  ,������� = @shrq" + vbCr
                        strSQL = strSQL + "  ,������� = @cwsh" + vbCr
                        If strPJHM <> "" Then
                            strSQL = strSQL + "  ,Ʊ�ݺ��� = @pjhm" + vbCr
                            objSqlCommand.Parameters.AddWithValue("@pjhm", strPJHM)
                        End If
                        If strSFDM <> "" Then
                            strSQL = strSQL + "  ,˰�Ѵ��� = @sfdm" + vbCr
                            objSqlCommand.Parameters.AddWithValue("@sfdm", strSFDM)
                        End If
                        If strSFDX <> "" Then
                            strSQL = strSQL + "  ,�ո����� = @sfdx" + vbCr
                            objSqlCommand.Parameters.AddWithValue("@sfdx", strSFDX)
                        End If
                        If strSFBZ <> "" Then
                            strSQL = strSQL + "  ,�ո���־ = @sfbz" + vbCr
                            objSqlCommand.Parameters.AddWithValue("@sfbz", strSFBZ)
                        End If
                        If strFSJE <> "" Then
                            strSQL = strSQL + "  ,������� = @fsje" + vbCr
                            objSqlCommand.Parameters.AddWithValue("@fsje", dblFSJE)
                        End If
                        strSQL = strSQL + " from �ز�_B_����_����ʵ��ʵ��" + vbCr
                        strSQL = strSQL + " where Ψһ��ʶ = @wybs" + vbCr
                        strSQL = strSQL + " and   ��˱�־ <> 1" + vbCr
                        objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    End If
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
            Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doShenhe_ES_SSSF = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getHetongBeiyongjin = False
            dblBYJ_JF = 0.0
            dblBYJ_YF = 0.0

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getHetongBeiyongjin]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim
                If strQRSH = "" Then
                    Exit Try
                End If

                '��ȡ���ݿ�����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '���㣺ȥ������ͨ��������
                strSQL = ""
                strSQL = strSQL + " select �ո�����,�ո���־,�������=sum(�������)" + vbCr
                strSQL = strSQL + " from �ز�_B_����_����ʵ��ʵ��" + vbCr
                strSQL = strSQL + " where ȷ����� = '" + strQRSH + "'" + vbCr
                strSQL = strSQL + " and not (��˱�־ = 1" + vbCr          '����
                strSQL = strSQL + " and   rtrim(�������) = '')" + vbCr    '��ͨ��
                strSQL = strSQL + " group by �ո�����,�ո���־" + vbCr
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                If objDataSet.Tables.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Dim dblValue As Double = 0.0
                        Dim strSFDX As String = ""
                        Dim strSFBZ As String = ""
                        Dim intCount As Integer = 0
                        Dim i As Integer = 0
                        intCount = objDataSet.Tables(0).Rows.Count
                        For i = 0 To intCount - 1 Step 1
                            strSFDX = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("�ո�����"), "")
                            strSFBZ = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("�ո���־"), "")
                            dblValue = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("�������"), 0.0)
                            Select Case strSFBZ
                                Case Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_S
                                Case Else
                                    dblValue = -dblValue
                            End Select
                            Select Case strSFDX
                                Case Josco.JSOA.Common.Data.estateCaiwuData.SFDX_J
                                    dblBYJ_JF += dblValue
                                Case Else
                                    dblBYJ_YF += dblValue
                            End Select
                        Next
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getHetongBeiyongjin = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getHetongBeiyongjin = False
            dblBYJ_JF = 0.0
            dblBYJ_YF = 0.0

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getHetongBeiyongjin]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim
                If strQRSH = "" Then
                    Exit Try
                End If
                If strSFBZ Is Nothing Then strSFBZ = ""
                strSFBZ = strSFBZ.Trim
                Select Case strSFBZ
                    Case Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_S, _
                        Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_F
                    Case Else
                        Exit Try
                End Select
                If strSFDM Is Nothing Then strSFDM = ""
                strSFDM = strSFDM.Trim
                If strSFDM = "" Then
                    Exit Try
                End If

                '��ȡ���ݿ�����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '���㣺ȥ������ͨ��������
                strSQL = ""
                strSQL = strSQL + " select �ո�����,�������=sum(�������)" + vbCr
                strSQL = strSQL + " from �ز�_B_����_����ʵ��ʵ��" + vbCr
                strSQL = strSQL + " where ȷ����� = '" + strQRSH + "'" + vbCr
                strSQL = strSQL + " and   �ո���־ = '" + strSFBZ + "'" + vbCr
                strSQL = strSQL + " and  (˰�Ѵ��� = '" + strSFDM + "' or ˰�Ѵ��� like '" + strSFDM + ".%')" + vbCr
                strSQL = strSQL + " and not (��˱�־ = 1" + vbCr          '����
                strSQL = strSQL + " and   rtrim(�������) = '')" + vbCr    '��ͨ��
                strSQL = strSQL + " group by �ո�����" + vbCr
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                If objDataSet.Tables.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Dim dblValue As Double = 0.0
                        Dim strSFDX As String = ""
                        Dim intCount As Integer = 0
                        Dim i As Integer = 0
                        intCount = objDataSet.Tables(0).Rows.Count
                        For i = 0 To intCount - 1 Step 1
                            strSFDX = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("�ո�����"), "")
                            dblValue = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("�������"), 0.0)
                            Select Case strSFDX
                                Case Josco.JSOA.Common.Data.estateCaiwuData.SFDX_J
                                    dblBYJ_JF += dblValue
                                Case Else
                                    dblBYJ_YF += dblValue
                            End Select
                        Next
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getHetongBeiyongjin = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getHetongBeiyongjin = False
            dblBYJ_JF = 0.0
            dblBYJ_YF = 0.0

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getHetongBeiyongjin]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim
                If strQRSH = "" Then
                    Exit Try
                End If
                If strSFBZ Is Nothing Then strSFBZ = ""
                strSFBZ = strSFBZ.Trim
                Select Case strSFBZ
                    Case Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_S, _
                        Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_F
                    Case Else
                        Exit Try
                End Select
                If strSFDMList Is Nothing Then strSFDMList = ""
                strSFDMList = strSFDMList.Trim
                If strSFDMList = "" Then
                    Exit Try
                End If
                Dim strArray() As String = strSFDMList.Split(Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate.ToCharArray)

                '��ȡ���ݿ�����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '���㣺ȥ������ͨ��������
                Dim intCount As Integer = strArray.Length
                Dim i As Integer = 0
                strSQL = ""
                strSQL = strSQL + " select �ո�����,�������=sum(�������)" + vbCr
                strSQL = strSQL + " from �ز�_B_����_����ʵ��ʵ��" + vbCr
                strSQL = strSQL + " where ȷ����� = '" + strQRSH + "'" + vbCr
                strSQL = strSQL + " and   �ո���־ = '" + strSFBZ + "'" + vbCr
                strSQL = strSQL + " and   not (" + vbCr
                For i = 0 To intCount - 1 Step 1
                    If i = 0 Then
                        strSQL = strSQL + " (˰�Ѵ��� = '" + strArray(i) + "' or ˰�Ѵ��� like '" + strArray(i) + ".%')" + vbCr
                    Else
                        strSQL = strSQL + " or  (˰�Ѵ��� = '" + strArray(i) + "' or ˰�Ѵ��� like '" + strArray(i) + ".%')" + vbCr
                    End If
                Next
                strSQL = strSQL + " )" + vbCr
                strSQL = strSQL + " and not (��˱�־ = 1" + vbCr          '����
                strSQL = strSQL + " and   rtrim(�������) = '')" + vbCr    '��ͨ��
                strSQL = strSQL + " group by �ո�����" + vbCr
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                If objDataSet.Tables.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Dim dblValue As Double = 0.0
                        Dim strSFDX As String = ""
                        intCount = objDataSet.Tables(0).Rows.Count
                        For i = 0 To intCount - 1 Step 1
                            strSFDX = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("�ո�����"), "")
                            dblValue = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("�������"), 0.0)
                            Select Case strSFDX
                                Case Josco.JSOA.Common.Data.estateCaiwuData.SFDX_J
                                    dblBYJ_JF += dblValue
                                Case Else
                                    dblBYJ_YF += dblValue
                            End Select
                        Next
                    End If
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getHetongBeiyongjin = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            getNewPjph = False
            strPJPH = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strFGFH Is Nothing Then strFGFH = ""
                strFGFH = strFGFH.Trim
                If strFGFH = "" Then
                    strErrMsg = "����[��������]�����ṩ��"
                    GoTo errProc
                End If

                '����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '����
                If objdacCommon.getNewCode(strErrMsg, objSqlConnection, "Ʊ������", "��������", strFGFH, "�ز�_B_����_Ʊ��ʹ�����", True, strPJPH) = False Then
                    GoTo errProc
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getNewPjph = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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
        ' ����
        '     zengxianglin 2009-05-17 ����
        '----------------------------------------------------------------
        Public Function isPiaojuUsed( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByRef blnIS As Boolean) As Boolean

            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            isPiaojuUsed = False
            blnIS = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[isPiaojuUsed]δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim
                If strWYBS = "" Then
                    strErrMsg = "����[isPiaojuUsed]δָ��[Ψһ��ʶ]��"
                    GoTo errProc
                End If

                '��ȡ���ݿ�����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '����
                strSQL = ""
                strSQL = strSQL + " select count(*) from �ز�_B_����_Ʊ��ʹ�����" + vbCr
                strSQL = strSQL + " where Ψһ��ʶ = '" + strWYBS + "'" + vbCr
                strSQL = strSQL + " and   ״̬��־ & 0x7 = 0x1" + vbCr '��ʹ��
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                If objDataSet.Tables.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Dim intCount As Integer = 0
                        intCount = CType(objDataSet.Tables(0).Rows(0).Item(0), Integer)
                        If intCount > 0 Then
                            blnIS = True
                        End If
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isPiaojuUsed = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            isPiaojuZuofei = False
            blnIS = False

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[isPiaojuZuofei]δָ��Ҫ��ȡ��Ϣ���û���"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim
                If strWYBS = "" Then
                    strErrMsg = "����[isPiaojuZuofei]δָ��[Ψһ��ʶ]��"
                    GoTo errProc
                End If

                '��ȡ���ݿ�����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '����
                strSQL = ""
                strSQL = strSQL + " select count(*) from �ز�_B_����_Ʊ��ʹ�����" + vbCr
                strSQL = strSQL + " where Ψһ��ʶ = '" + strWYBS + "'" + vbCr
                strSQL = strSQL + " and   ״̬��־ & 0x7 = 0x2" + vbCr '������
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                If objDataSet.Tables.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Dim intCount As Integer = 0
                        intCount = CType(objDataSet.Tables(0).Rows(0).Item(0), Integer)
                        If intCount > 0 Then
                            blnIS = True
                        End If
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            isPiaojuZuofei = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doPiaoju_Hexiao = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[doPiaoju_Hexiao]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim
                If strWYBS = "" Then
                    Exit Try
                End If
                If strHXRY Is Nothing Then strHXRY = ""
                strHXRY = strHXRY.Trim
                If strHXRY = "" Then
                    Exit Try
                End If
                If strHXRQ Is Nothing Then strHXRQ = ""
                strHXRQ = strHXRQ.Trim
                If strHXRQ = "" Then strHXRQ = Now.ToString("yyyy-MM-dd HH:mm:ss")
                If objPulicParameters.isDatetimeString(strHXRQ) = False Then
                    strErrMsg = "����[doPiaoju_Hexiao]��Ч��[" + strHXRQ + "]��"
                    GoTo errProc
                End If
                Dim blnValue As Boolean = False

                '��ʹ�ã�
                If Me.isPiaojuUsed(strErrMsg, strUserId, strPassword, strWYBS, blnValue) = False Then
                    GoTo errProc
                End If
                If blnValue = False Then
                    '�����ϣ�
                    If Me.isPiaojuZuofei(strErrMsg, strUserId, strPassword, strWYBS, blnValue) = False Then
                        GoTo errProc
                    End If
                    If blnValue = False Then
                        strErrMsg = "����[doPiaoju_Hexiao]Ʊ�ݲ���[��ʹ��|������]�����ú�����"
                        GoTo errProc
                    End If
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

                '����
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    strSQL = ""
                    strSQL = strSQL + " update �ز�_B_����_Ʊ��ʹ����� set" + vbCr
                    strSQL = strSQL + "   ������־ = 1," + vbCr
                    strSQL = strSQL + "   ������Ա = @hxry," + vbCr
                    strSQL = strSQL + "   �������� = @hxrq " + vbCr
                    strSQL = strSQL + " where Ψһ��ʶ = @wybs" + vbCr
                    strSQL = strSQL + " and   ������־ = 0" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@hxry", strHXRY)
                    objSqlCommand.Parameters.AddWithValue("@hxrq", CType(strHXRQ, System.DateTime))
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
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
            doPiaoju_Hexiao = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objDataSet As Josco.JSOA.Common.Data.estateCaiwuData = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCustomer As New Josco.JsKernal.DataAccess.dacCustomer
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doJiezhuan_ES_SSSF_TFX = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[doJiezhuan_ES_SSSF_TFX]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    Exit Try
                End If
                If objNewData.Count < 1 Then
                    Exit Try
                End If

                '��ȡ����
                Dim strWYBS As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS), "")
                Dim strQRSH As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH), "")
                Dim strFSJE As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE), "")
                Dim strSFDM As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM), "")
                Dim strSFMC As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC), "")
                Dim strSFDX As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX), "")
                Dim strSFBZ As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ), "")
                Dim dblFSJE As Double = objPulicParameters.getObjectValue(strFSJE, 0.0)
                Dim strSFDX_Old As String = ""
                If strSFDX = Josco.JSOA.Common.Data.estateCaiwuData.SFDX_J Then
                    strSFDX_Old = Josco.JSOA.Common.Data.estateCaiwuData.SFDX_Y
                Else
                    strSFDX_Old = Josco.JSOA.Common.Data.estateCaiwuData.SFDX_J
                End If

                '��ȡҪ��ת��������Ϣ
                If Me.getDataSet_ES_SSSF(strErrMsg, strUserId, strPassword, strWYBS, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU) Is Nothing Then
                    strErrMsg = "����Ҫ��ת�����ݲ����ڣ�"
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows.Count < 1 Then
                    strErrMsg = "����Ҫ��ת�����ݲ����ڣ�"
                    GoTo errProc
                End If
                Dim strSrcSFMC As String = ""
                Dim dblSrcFSJE As Double = 0
                With objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows(0)
                    strSrcSFMC = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC), "")
                    dblSrcFSJE = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE), 0.0)
                End With
                If dblSrcFSJE < dblFSJE Then
                    strErrMsg = "�������㣡"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����Ա�ĵ�λ��Ϣ
                Dim strBMMC As String = ""
                Dim strJBDW As String = ""
                If objdacCustomer.getBmdmAndBmmcByRydm(strErrMsg, objSqlConnection, strUserId, strJBDW, strBMMC) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '����
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'ת����һ���տ�
                    strSQL = ""
                    strSQL = strSQL + " insert into �ز�_B_����_����ʵ��ʵ�� (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,ȷ�����,Ʊ�ݺ���,˰�Ѵ���,�ո�����,�ո���־," + vbCr
                    strSQL = strSQL + "   ��������,�������,ժҪ˵��,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա,�������,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=newid(),ȷ�����,Ʊ�ݺ���,˰�Ѵ���=@sfdm,�ո�����=@sfdx,�ո���־=@sfbz," + vbCr
                    strSQL = strSQL + "   ��������=@fsrq,�������=@fsje,ժҪ˵��=@zysm,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա=@jbry,�������=@jbdw,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_����ʵ��ʵ��" + vbCr
                    strSQL = strSQL + " where Ψһ��ʶ = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@sfdm", strSFDM)
                    objSqlCommand.Parameters.AddWithValue("@sfdx", strSFDX)
                    objSqlCommand.Parameters.AddWithValue("@sfbz", strSFBZ)
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", dblFSJE)
                    objSqlCommand.Parameters.AddWithValue("@zysm", "[" + strSFDX_Old + "][" + strSrcSFMC + "]ת��[" + strSFDX + "]")
                    objSqlCommand.Parameters.AddWithValue("@jbry", strUserId)
                    objSqlCommand.Parameters.AddWithValue("@jbdw", strJBDW)
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '���ԭ���տ�
                    strSQL = ""
                    strSQL = strSQL + " insert into �ز�_B_����_����ʵ��ʵ�� (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,ȷ�����,Ʊ�ݺ���,˰�Ѵ���,�ո�����,�ո���־," + vbCr
                    strSQL = strSQL + "   ��������,�������,ժҪ˵��,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա,�������,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=newid(),ȷ�����,Ʊ�ݺ���,˰�Ѵ���,�ո�����,�ո���־," + vbCr
                    strSQL = strSQL + "   ��������=@fsrq,�������=@fsje,ժҪ˵��=@zysm,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա=@jbry,�������=@jbdw,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_����ʵ��ʵ��" + vbCr
                    strSQL = strSQL + " where Ψһ��ʶ = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", -dblFSJE)
                    objSqlCommand.Parameters.AddWithValue("@zysm", "[" + strSFDX_Old + "]ת��[" + strSFDX + "][" + strSFMC + "]")
                    objSqlCommand.Parameters.AddWithValue("@jbry", strUserId)
                    objSqlCommand.Parameters.AddWithValue("@jbdw", strJBDW)
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
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
            Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doJiezhuan_ES_SSSF_TFX = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objDataSet As Josco.JSOA.Common.Data.estateCaiwuData = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCustomer As New Josco.JsKernal.DataAccess.dacCustomer
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '��ʼ��
            doJiezhuan_ES_SSSF_BTFX = False
            strErrMsg = ""

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[doJiezhuan_ES_SSSF_BTFX]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    Exit Try
                End If
                If objNewData.Count < 1 Then
                    Exit Try
                End If

                '��ȡ����
                Dim strWYBS As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS), "")
                Dim strQRSH As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH), "")
                Dim strFSJE As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE), "")
                Dim strSFDM As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM), "")
                Dim strSFMC As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC), "")
                Dim strSFDX As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX), "")
                Dim strSFBZ As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ), "")
                Dim dblFSJE As Double = objPulicParameters.getObjectValue(strFSJE, 0.0)
                Dim strSFDX_Old As String = ""
                If strSFDX = Josco.JSOA.Common.Data.estateCaiwuData.SFDX_J Then
                    strSFDX_Old = Josco.JSOA.Common.Data.estateCaiwuData.SFDX_Y
                Else
                    strSFDX_Old = Josco.JSOA.Common.Data.estateCaiwuData.SFDX_J
                End If
                Dim strSFBZ_Old As String = ""
                If strSFBZ = Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_F Then
                    strSFBZ_Old = Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_S
                Else
                    strSFBZ_Old = Josco.JSOA.Common.Data.estateCaiwuData.SFBZ_F
                End If

                '��ȡҪ��ת��������Ϣ
                If Me.getDataSet_ES_SSSF(strErrMsg, strUserId, strPassword, strWYBS, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU) Is Nothing Then
                    strErrMsg = "����Ҫ��ת�����ݲ����ڣ�"
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows.Count < 1 Then
                    strErrMsg = "����Ҫ��ת�����ݲ����ڣ�"
                    GoTo errProc
                End If
                Dim strSrcSFMC As String = ""
                Dim dblSrcFSJE As Double = 0
                With objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows(0)
                    strSrcSFMC = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC), "")
                    dblSrcFSJE = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE), 0.0)
                End With
                If dblSrcFSJE < dblFSJE Then
                    strErrMsg = "�������㣡"
                    GoTo errProc
                End If

                '��ȡ����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '��ȡ����Ա�ĵ�λ��Ϣ
                Dim strBMMC As String = ""
                Dim strJBDW As String = ""
                If objdacCustomer.getBmdmAndBmmcByRydm(strErrMsg, objSqlConnection, strUserId, strJBDW, strBMMC) = False Then
                    GoTo errProc
                End If

                '��ʼ����
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '����
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '��ת��
                    strSQL = ""
                    strSQL = strSQL + " insert into �ز�_B_����_����ʵ��ʵ�� (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,ȷ�����,Ʊ�ݺ���,˰�Ѵ���,�ո�����,�ո���־," + vbCr
                    strSQL = strSQL + "   ��������,�������,ժҪ˵��,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա,�������,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=newid(),ȷ�����,Ʊ�ݺ���,˰�Ѵ���=@sfdm,�ո�����=@sfdx,�ո���־=@sfbz," + vbCr
                    strSQL = strSQL + "   ��������=@fsrq,�������=@fsje,ժҪ˵��=@zysm,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա=@jbry,�������=@jbdw,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_����ʵ��ʵ��" + vbCr
                    strSQL = strSQL + " where Ψһ��ʶ = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@sfdm", strSFDM)
                    objSqlCommand.Parameters.AddWithValue("@sfdx", strSFDX)
                    objSqlCommand.Parameters.AddWithValue("@sfbz", strSFBZ_Old)
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", dblFSJE)
                    objSqlCommand.Parameters.AddWithValue("@zysm", "[" + strSFDX_Old + "][" + strSrcSFMC + "]ת��[" + strSFDX + "]��֧��")
                    objSqlCommand.Parameters.AddWithValue("@jbry", strUserId)
                    objSqlCommand.Parameters.AddWithValue("@jbdw", strJBDW)
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '��֧��
                    strSQL = ""
                    strSQL = strSQL + " insert into �ز�_B_����_����ʵ��ʵ�� (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,ȷ�����,Ʊ�ݺ���,˰�Ѵ���,�ո�����,�ո���־," + vbCr
                    strSQL = strSQL + "   ��������,�������,ժҪ˵��,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա,�������,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=newid(),ȷ�����,Ʊ�ݺ���,˰�Ѵ���=@sfdm,�ո�����=@sfdx,�ո���־=@sfbz," + vbCr
                    strSQL = strSQL + "   ��������=@fsrq,�������=@fsje,ժҪ˵��=@zysm,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա=@jbry,�������=@jbdw,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_����ʵ��ʵ��" + vbCr
                    strSQL = strSQL + " where Ψһ��ʶ = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@sfdm", strSFDM)
                    objSqlCommand.Parameters.AddWithValue("@sfdx", strSFDX)
                    objSqlCommand.Parameters.AddWithValue("@sfbz", strSFBZ)
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", dblFSJE)
                    objSqlCommand.Parameters.AddWithValue("@zysm", "[" + strSFDX_Old + "][" + strSrcSFMC + "]ת��[" + strSFDX + "]��֧��")
                    objSqlCommand.Parameters.AddWithValue("@jbry", strUserId)
                    objSqlCommand.Parameters.AddWithValue("@jbdw", strJBDW)
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '���ԭ���տ�
                    strSQL = ""
                    strSQL = strSQL + " insert into �ز�_B_����_����ʵ��ʵ�� (" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ,ȷ�����,Ʊ�ݺ���,˰�Ѵ���,�ո�����,�ո���־," + vbCr
                    strSQL = strSQL + "   ��������,�������,ժҪ˵��,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա,�������,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   Ψһ��ʶ=newid(),ȷ�����,Ʊ�ݺ���,˰�Ѵ���,�ո�����,�ո���־," + vbCr
                    strSQL = strSQL + "   ��������=@fsrq,�������=@fsje,ժҪ˵��=@zysm,�ͻ�����," + vbCr
                    strSQL = strSQL + "   ������Ա=@jbry,�������=@jbdw,�ƻ���ʶ" + vbCr
                    strSQL = strSQL + " from �ز�_B_����_����ʵ��ʵ��" + vbCr
                    strSQL = strSQL + " where Ψһ��ʶ = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", -dblFSJE)
                    objSqlCommand.Parameters.AddWithValue("@zysm", "[" + strSFDX_Old + "]ת��[" + strSFDX + "]��֧��[" + strSFMC + "]")
                    objSqlCommand.Parameters.AddWithValue("@jbry", strUserId)
                    objSqlCommand.Parameters.AddWithValue("@jbdw", strJBDW)
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
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
            Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '����
            doJiezhuan_ES_SSSF_BTFX = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCustomer.SafeRelease(objdacCustomer)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

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

            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getBalance = False
            dblBalance = 0.0

            Try
                '���
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "����[getBalance]δָ��[�����û�]��"
                    GoTo errProc
                End If
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim
                If strSFDM Is Nothing Then strSFDM = ""
                strSFDM = strSFDM.Trim
                If strSFDX Is Nothing Then strSFDX = ""
                strSFDX = strSFDX.Trim
                If strQRSH = "" Or strSFDM = "" Or strSFDX = "" Then
                    strErrMsg = "����[getBalance]δָ����ز�����"
                    GoTo errProc
                End If

                '��ȡ���ݿ�����
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '����
                strSQL = ""
                strSQL = strSQL + " select sum(�������) from �ز�_B_����_����ʵ��ʵ��" + vbCr
                strSQL = strSQL + " where ȷ����� = '" + strQRSH + "'" + vbCr
                strSQL = strSQL + " and   ˰�Ѵ��� = '" + strSFDM + "'" + vbCr
                strSQL = strSQL + " and   �ո����� = '" + strSFDX + "'" + vbCr
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '����
                If objDataSet.Tables.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        dblBalance = CType(objDataSet.Tables(0).Rows(0).Item(0), Double)
                    End If
                End If
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getBalance = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

    End Class

End Namespace
