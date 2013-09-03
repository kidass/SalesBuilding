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
    ' 命名空间：Josco.JSOA.DataAccess
    ' 类名    ：dacEstateCommon
    '
    ' 功能描述：
    '     提供对通用地产管理数据的相关数据层操作
    '----------------------------------------------------------------

    Public Class dacEstateCommon
        Implements IDisposable

        Private m_objSqlDataAdapter As System.Data.SqlClient.SqlDataAdapter








        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
            m_objSqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter
        End Sub

        '----------------------------------------------------------------
        ' 虚拟析构函数
        '----------------------------------------------------------------
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(True)
        End Sub

        '----------------------------------------------------------------
        ' 析构函数重载
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
        ' 安全释放本身资源
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
        ' 将数据从DataSet导出到Excel
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objDataSet             ：要导出的数据集
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strMacroName           ：宏名列表
        '     strMacroValue          ：宏值列表
        '     strDateFormat          ：日期格式字符串
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
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
        ' 将数据从DataSet导出到Excel
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objDataSet             ：要导出的数据集
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strColorFieldName      ：用来确定行颜色的字段名
        '     objColors              ：字段值对应的颜色集合
        '     strMacroName           ：宏名列表
        '     strMacroValue          ：宏值列表
        '     strDateFormat          ：日期格式字符串
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
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
        ' 检验代码字段的合法性
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strNewCode                ：新代码
        '     strOldCode                ：旧代码
        '     strFieldName              ：代码字段名
        '     strTableName              ：代码字段所在表名
        '     objenumEditType           ：编辑模式
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[doValidCode]没有指定[连接用户]！"
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
                    strErrMsg = "错误：[doValidCode]中没有指定[检测表名]！"
                    GoTo errProc
                End If
                If strFieldName = "" Then
                    strErrMsg = "错误：[doValidCode]中没有指定[检测字段名]！"
                    GoTo errProc
                End If

                '检查值nnn.nnn.nnn.nnn
                Dim strArray() As String
                strArray = strNewCode.Split(strSep.ToCharArray())
                Dim intCount As Integer = 0
                Dim intLen As Integer = 0
                Dim i As Integer = 0
                intCount = strArray.Length
                For i = 1 To intCount Step 1
                    intLen = objPulicParameters.getStringLength(strArray(i - 1))
                    If intLen <> intSegLen Then
                        strErrMsg = "错误：[doValidCode][" + strFieldName + "]必须是[" + intSegLen.ToString + "]位数字！"
                        GoTo errProc
                    End If
                    If objPulicParameters.isIntegerString(strArray(i - 1)) = False Then
                        strErrMsg = "错误：[doValidCode][" + strFieldName + "]必须是[" + intSegLen.ToString + "]位数字！"
                        GoTo errProc
                    End If
                Next

                '计算上级代码
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

                '是否发生更改
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
                            '未改变！
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
                            strErrMsg = "错误：[doValidCode]无法获取数据！"
                            GoTo errProc
                        End If
                        If .Tables(0).Rows.Count < 1 Then
                            strErrMsg = "错误：[doValidCode]中上级代码[" + strPrevCode + "]不存在！！"
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
        ' 检验区域划分代码字段的合法性
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strNewCode                ：新代码
        '     strOldCode                ：旧代码
        '     strFieldName              ：代码字段名
        '     strTableName              ：代码字段所在表名
        '     objenumEditType           ：编辑模式
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[doValidCode_QuyuHuafen]没有指定[连接用户]！"
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
                    strErrMsg = "错误：[doValidCode_QuyuHuafen]中没有指定[检测表名]！"
                    GoTo errProc
                End If
                If strFieldName = "" Then
                    strErrMsg = "错误：[doValidCode_QuyuHuafen]中没有指定[检测字段名]！"
                    GoTo errProc
                End If

                '检查值nnn.nnn.nnn.nnn
                Dim strArray() As String
                strArray = strNewCode.Split(strSep.ToCharArray())
                Dim intCount As Integer = 0
                Dim intLen As Integer = 0
                Dim i As Integer = 0
                intCount = strArray.Length
                For i = 1 To intCount Step 1
                    intLen = objPulicParameters.getStringLength(strArray(i - 1))
                    If intLen <> intSegLen Then
                        strErrMsg = "错误：[doValidCode_QuyuHuafen][" + strFieldName + "]必须是[" + intSegLen.ToString + "]位数字！"
                        GoTo errProc
                    End If
                    If objPulicParameters.isIntegerString(strArray(i - 1)) = False Then
                        strErrMsg = "错误：[doValidCode_QuyuHuafen][" + strFieldName + "]必须是[" + intSegLen.ToString + "]位数字！"
                        GoTo errProc
                    End If
                Next

                '计算上级代码
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

                '是否发生更改
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
                            '未改变！
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
                            strErrMsg = "错误：[doValidCode_QuyuHuafen]无法获取数据！"
                            GoTo errProc
                        End If
                        If .Tables(0).Rows.Count < 1 Then
                            strErrMsg = "错误：[doValidCode_QuyuHuafen]中上级代码[" + strPrevCode + "]不存在！！"
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
        ' 获取“地产_B_公共_税费目录”的SQL语句(以“税费代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ShuifeiMulu() As String
            getTableSQL_ShuifeiMulu = "select * from 地产_B_公共_税费目录 order by 税费代码"
        End Function

        '----------------------------------------------------------------
        ' 根据“税费代码”获取“税费名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strSfdm                   ：税费代码
        '     strSfmc                   ：税费名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strSfdm Is Nothing Then strSfdm = ""

                '计算
                strSQL = "select dbo.uf_estate_gg_getSfmc('" + strSfdm + "')"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
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
        ' 根据“税费名称”获取“税费代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strSfmc                   ：税费名称
        '     strSfdm                   ：税费代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strSfmc Is Nothing Then strSfmc = ""

                '计算
                strSQL = ""
                strSQL = strSQL + " select * from 地产_B_公共_税费目录" + vbCr
                strSQL = strSQL + " where 税费名称 = '" + strSfmc + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strSfdm = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("税费代码"), "")
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
        ' 获取“地产_B_公共_税费目录”完全数据的数据集(以“税费代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCommonData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_ShuifeiMulu = False
            objestateCommonData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateCommonData = New Josco.JSOA.Common.Data.estateCommonData(Josco.JSOA.Common.Data.estateCommonData.enumTableType.DC_B_GG_SHUIFEIMULU)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 地产_B_公共_税费目录 a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.税费代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“地产_B_公共_税费目录”的数据的合法性
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型

        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：未传入旧的数据！"
                            GoTo errProc
                        End If
                End Select

                '获取表结构定义
                strSQL = "select top 0 * from 地产_B_公共_税费目录"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "地产_B_公共_税费目录", objDataSet) = False Then
                    GoTo errProc
                End If

                '检查数据长度
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
                                strErrMsg = "错误：没有输入[" + strField + "]！"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "错误：[" + strField + "]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
                                    GoTo errProc
                                End If
                            End With
                    End Select
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '检查“税费代码”约束
                Dim strOldSFDM As String = ""
                Dim strNewSFDM As String = ""
                strNewSFDM = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 地产_B_公共_税费目录 where 税费代码 = @sfdm"
                        objListDictionary.Add("@sfdm", strNewSFDM)
                    Case Else
                        strOldSFDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFDM), "")
                        strSQL = "select * from 地产_B_公共_税费目录 where 税费代码 = @sfdm and 税费代码 <> @oldsfdm"
                        objListDictionary.Add("@sfdm", strNewSFDM)
                        objListDictionary.Add("@oldsfdm", strOldSFDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewSFDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查“税费名称”约束
                Dim strNewSFMC As String = ""
                strNewSFMC = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 地产_B_公共_税费目录 where 税费名称 = @sfmc"
                        objListDictionary.Add("@sfmc", strNewSFMC)
                    Case Else
                        strSQL = "select * from 地产_B_公共_税费目录 where 税费名称 = @sfmc and 税费代码 <> @oldsfdm"
                        objListDictionary.Add("@sfmc", strNewSFMC)
                        objListDictionary.Add("@oldsfdm", strOldSFDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewSFMC + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查代码字段
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewSFDM, strOldSFDM, "税费代码", "地产_B_公共_税费目录", objenumEditType) = False Then
                    GoTo errProc
                End If

                '释放资源
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
        ' 保存“地产_B_公共_税费目录”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doSaveData_ShuifeiMulu = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：未传入旧的数据！"
                            GoTo errProc
                        End If
                End Select

                '检查数据
                If Me.doVerifyData_ShuifeiMulu(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
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
                            '计算字段列表、字段值
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " insert into 地产_B_公共_税费目录 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFDM), "")

                            '计算字段列表、字段值
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " update 地产_B_公共_税费目录 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 税费代码 = @oldkey" + vbCr
                    End Select

                    '执行SQL
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 删除“地产_B_公共_税费目录”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_ShuifeiMulu = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objOldData Is Nothing Then
                    strErrMsg = "错误：未传入旧的数据！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '删除数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
                    Dim strOldKey As String
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_SHUIFEIMULU_SFDM), "")
                    '删除下级
                    strSQL = ""
                    strSQL = strSQL + " delete from 地产_B_公共_税费目录 "
                    strSQL = strSQL + " where 税费代码 like @oldkey +'.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 地产_B_公共_税费目录 "
                    strSQL = strSQL + " where 税费代码 = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 获取“地产_B_公共_物业间隔”的SQL语句(以“间隔代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_WuyeJiange() As String
            getTableSQL_WuyeJiange = "select * from 地产_B_公共_物业间隔 order by 间隔代码"
        End Function

        '----------------------------------------------------------------
        ' 根据“间隔代码”获取“间隔名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWyjgdm                 ：间隔代码
        '     strWyjgmc                 ：间隔名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strWyjgdm Is Nothing Then strWyjgdm = ""

                '计算
                strSQL = "select dbo.uf_estate_gg_getWyjgmc('" + strWyjgdm + "')"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
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
        ' 根据“间隔名称”获取“间隔代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWyjgmc                   ：间隔名称
        '     strWyjgdm                   ：间隔代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strWyjgmc Is Nothing Then strWyjgmc = ""

                '计算
                strSQL = ""
                strSQL = strSQL + " select * from 地产_B_公共_物业间隔" + vbCr
                strSQL = strSQL + " where 间隔名称 = '" + strWyjgmc + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strWyjgdm = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("间隔代码"), "")
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
        ' 获取“地产_B_公共_物业间隔”完全数据的数据集(以“间隔代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCommonData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_WuyeJiange = False
            objestateCommonData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateCommonData = New Josco.JSOA.Common.Data.estateCommonData(Josco.JSOA.Common.Data.estateCommonData.enumTableType.DC_B_GG_WUYEJIANGE)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 地产_B_公共_物业间隔 a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.间隔代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“地产_B_公共_物业间隔”的数据的合法性
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型

        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：未传入旧的数据！"
                            GoTo errProc
                        End If
                End Select

                '获取表结构定义
                strSQL = "select top 0 * from 地产_B_公共_物业间隔"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "地产_B_公共_物业间隔", objDataSet) = False Then
                    GoTo errProc
                End If

                '检查数据长度
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
                                strErrMsg = "错误：没有输入[" + strField + "]！"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "错误：[" + strField + "]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
                                    GoTo errProc
                                End If
                            End With
                    End Select
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '检查“间隔代码”约束
                Dim strOldWYJGDM As String = ""
                Dim strNewWYJGDM As String = ""
                strNewWYJGDM = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEJIANGE_WYJGDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 地产_B_公共_物业间隔 where 间隔代码 = @wyjgdm"
                        objListDictionary.Add("@wyjgdm", strNewWYJGDM)
                    Case Else
                        strOldWYJGDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEJIANGE_WYJGDM), "")
                        strSQL = "select * from 地产_B_公共_物业间隔 where 间隔代码 = @wyjgdm and 间隔代码 <> @oldwyjgdm"
                        objListDictionary.Add("@wyjgdm", strNewWYJGDM)
                        objListDictionary.Add("@oldwyjgdm", strOldWYJGDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewWYJGDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查“间隔名称”约束
                Dim strNewWYJGMC As String = ""
                strNewWYJGMC = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEJIANGE_WYJGMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 地产_B_公共_物业间隔 where 间隔名称 = @wyjgmc"
                        objListDictionary.Add("@wyjgmc", strNewWYJGMC)
                    Case Else
                        strSQL = "select * from 地产_B_公共_物业间隔 where 间隔名称 = @wyjgmc and 间隔代码 <> @oldwyjgdm"
                        objListDictionary.Add("@wyjgmc", strNewWYJGMC)
                        objListDictionary.Add("@oldwyjgdm", strOldWYJGDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewWYJGMC + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查代码字段
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewWYJGDM, strOldWYJGDM, "间隔代码", "地产_B_公共_物业间隔", objenumEditType) = False Then
                    GoTo errProc
                End If

                '释放资源
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
        ' 保存“地产_B_公共_物业间隔”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doSaveData_WuyeJiange = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：未传入旧的数据！"
                            GoTo errProc
                        End If
                End Select

                '检查数据
                If Me.doVerifyData_WuyeJiange(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
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
                            '计算字段列表、字段值
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " insert into 地产_B_公共_物业间隔 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEJIANGE_WYJGDM), "")

                            '计算字段列表、字段值
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " update 地产_B_公共_物业间隔 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 间隔代码 = @oldkey" + vbCr
                    End Select

                    '执行SQL
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 删除“地产_B_公共_物业间隔”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_WuyeJiange = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objOldData Is Nothing Then
                    strErrMsg = "错误：未传入旧的数据！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '删除数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
                    Dim strOldKey As String
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEJIANGE_WYJGDM), "")
                    '删除下级
                    strSQL = ""
                    strSQL = strSQL + " delete from 地产_B_公共_物业间隔 "
                    strSQL = strSQL + " where 间隔代码 like @oldkey +'.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 地产_B_公共_物业间隔 "
                    strSQL = strSQL + " where 间隔代码 = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 获取“地产_B_公共_物业性质”的SQL语句(以“性质代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_WuyeXingzhi() As String
            getTableSQL_WuyeXingzhi = "select * from 地产_B_公共_物业性质 order by 性质代码"
        End Function

        '----------------------------------------------------------------
        ' 根据“性质代码”获取“性质名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWyxzdm                 ：性质代码
        '     strWyxzmc                 ：性质名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strWyxzdm Is Nothing Then strWyxzdm = ""

                '计算
                strSQL = "select dbo.uf_estate_gg_getWyxzmc('" + strWyxzdm + "')"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
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
        ' 根据“性质名称”获取“性质代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strWyxzmc                 ：性质名称
        '     strWyxzdm                 ：性质代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strWyxzmc Is Nothing Then strWyxzmc = ""

                '计算
                strSQL = ""
                strSQL = strSQL + " select * from 地产_B_公共_物业性质" + vbCr
                strSQL = strSQL + " where 性质名称 = '" + strWyxzmc + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strWyxzdm = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("性质代码"), "")
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
        ' 获取“地产_B_公共_物业性质”完全数据的数据集(以“性质代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCommonData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_WuyeXingzhi = False
            objestateCommonData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateCommonData = New Josco.JSOA.Common.Data.estateCommonData(Josco.JSOA.Common.Data.estateCommonData.enumTableType.DC_B_GG_WUYEXINGZHI)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 地产_B_公共_物业性质 a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.性质代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“地产_B_公共_物业性质”的数据的合法性
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        ' 更改
        '     zengxianglin 2010-12-21 更改
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：未传入旧的数据！"
                            GoTo errProc
                        End If
                End Select

                '获取表结构定义
                strSQL = "select top 0 * from 地产_B_公共_物业性质"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "地产_B_公共_物业性质", objDataSet) = False Then
                    GoTo errProc
                End If

                '检查数据长度
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
                                    strErrMsg = "错误：输入[" + strField + "]项的值[" + strValue + "]无效！"
                                    GoTo errProc
                            End Select
                        Case Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_XSSX
                            If strValue = "" Then strValue = "0"
                            If objPulicParameters.isIntegerString(strValue) = False Then
                                strErrMsg = "错误：输入[" + strField + "]项的值[" + strValue + "]无效！"
                                GoTo errProc
                            End If

                        Case Else
                            If strValue = "" Then
                                strErrMsg = "错误：没有输入[" + strField + "]！"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "错误：[" + strField + "]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
                                    GoTo errProc
                                End If
                            End With
                    End Select
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '检查“性质代码”约束
                Dim strOldWYXZDM As String = ""
                Dim strNewWYXZDM As String = ""
                strNewWYXZDM = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_WYXZDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 地产_B_公共_物业性质 where 性质代码 = @wyxzdm"
                        objListDictionary.Add("@wyxzdm", strNewWYXZDM)
                    Case Else
                        strOldWYXZDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_WYXZDM), "")
                        strSQL = "select * from 地产_B_公共_物业性质 where 性质代码 = @wyxzdm and 性质代码 <> @oldwyxzdm"
                        objListDictionary.Add("@wyxzdm", strNewWYXZDM)
                        objListDictionary.Add("@oldwyxzdm", strOldWYXZDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewWYXZDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查“性质名称”约束
                Dim strNewWYXZMC As String = ""
                strNewWYXZMC = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_WYXZMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 地产_B_公共_物业性质 where 性质名称 = @wyxzmc"
                        objListDictionary.Add("@wyxzmc", strNewWYXZMC)
                    Case Else
                        strSQL = "select * from 地产_B_公共_物业性质 where 性质名称 = @wyxzmc and 性质代码 <> @oldwyxzdm"
                        objListDictionary.Add("@wyxzmc", strNewWYXZMC)
                        objListDictionary.Add("@oldwyxzdm", strOldWYXZDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewWYXZMC + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查代码字段
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewWYXZDM, strOldWYXZDM, "性质代码", "地产_B_公共_物业性质", objenumEditType) = False Then
                    GoTo errProc
                End If

                '释放资源
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
        ' 保存“地产_B_公共_物业性质”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2010-12-21 更改
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

            '初始化
            doSaveData_WuyeXingzhi = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：未传入旧的数据！"
                            GoTo errProc
                        End If
                End Select

                '检查数据
                If Me.doVerifyData_WuyeXingzhi(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
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
                            '计算字段列表、字段值
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " insert into 地产_B_公共_物业性质 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_WYXZDM), "")

                            '计算字段列表、字段值
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " update 地产_B_公共_物业性质 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 性质代码 = @oldkey" + vbCr
                    End Select

                    '执行SQL
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 删除“地产_B_公共_物业性质”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_WuyeXingzhi = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objOldData Is Nothing Then
                    strErrMsg = "错误：未传入旧的数据！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '删除数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
                    Dim strOldKey As String
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_WUYEXINGZHI_WYXZDM), "")
                    '删除下级
                    strSQL = ""
                    strSQL = strSQL + " delete from 地产_B_公共_物业性质 "
                    strSQL = strSQL + " where 性质代码 like @oldkey +'.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 地产_B_公共_物业性质 "
                    strSQL = strSQL + " where 性质代码 = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 获取“地产_B_公共_应收应付模版”的SQL语句(以“模版代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_YingshouYingfuMoban() As String
            getTableSQL_YingshouYingfuMoban = "select * from 地产_B_公共_应收应付模版 order by 模版代码"
        End Function

        '----------------------------------------------------------------
        ' 根据“模版代码”获取“模版名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strMbdm                   ：模版代码
        '     strMbmc                   ：模版名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strMbdm Is Nothing Then strMbdm = ""

                '计算
                strSQL = "select dbo.uf_estate_gg_getFkfsmbmc('" + strMbdm + "')"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
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
        ' 获取“地产_B_公共_应收应付模版”完全数据的数据集(以“模版代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCommonData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_YingshouYingfuMoban = False
            objestateCommonData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateCommonData = New Josco.JSOA.Common.Data.estateCommonData(Josco.JSOA.Common.Data.estateCommonData.enumTableType.DC_B_GG_YINGSHOUYINGFUMOBAN)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from" + vbCr
                        strSQL = strSQL + " (" + vbCr
                        strSQL = strSQL + "   select a.*," + vbCr
                        strSQL = strSQL + "     b.税费名称," + vbCr
                        strSQL = strSQL + "     是否明细名称 = case when a.是否明细 = 1 then @true else @false end" + vbCr
                        strSQL = strSQL + "   from 地产_B_公共_应收应付模版 a " + vbCr
                        strSQL = strSQL + "   left join 地产_B_公共_税费目录 b on a.税费代码 = b.税费代码" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.模版代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@true", Josco.JsKernal.Common.Utilities.PulicParameters.CharTrue)
                        objSqlCommand.Parameters.AddWithValue("@false", Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse)
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“地产_B_公共_应收应付模版”的数据的合法性
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型

        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：未传入旧的数据！"
                            GoTo errProc
                        End If
                End Select

                '获取表结构定义
                strSQL = "select top 0 * from 地产_B_公共_应收应付模版"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "地产_B_公共_应收应付模版", objDataSet) = False Then
                    GoTo errProc
                End If

                '检查数据长度
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
                            '计算列
                        Case Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMX
                            If strValue = "" Then
                                strErrMsg = "错误：没有输入[" + strField + "]！"
                                GoTo errProc
                            End If
                            If objPulicParameters.isIntegerString(strValue) = False Then
                                strErrMsg = "错误：[" + strField + "]只能输入0或1！"
                                GoTo errProc
                            End If
                            Select Case strValue
                                Case "0", "1"
                                Case Else
                                    strErrMsg = "错误：[" + strField + "]只能输入0或1！"
                                    GoTo errProc
                            End Select
                        Case Else
                            If strValue = "" Then
                                strValue = " "
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "错误：[" + strField + "]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
                                    GoTo errProc
                                End If
                            End With
                    End Select
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '检查“模版代码”约束
                Dim strOldMBDM As String = ""
                Dim strNewMBDM As String = ""
                strNewMBDM = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 地产_B_公共_应收应付模版 where 模版代码 = @mbdm"
                        objListDictionary.Add("@mbdm", strNewMBDM)
                    Case Else
                        strOldMBDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM), "")
                        strSQL = "select * from 地产_B_公共_应收应付模版 where 模版代码 = @mbdm and 模版代码 <> @oldmbdm"
                        objListDictionary.Add("@mbdm", strNewMBDM)
                        objListDictionary.Add("@oldmbdm", strOldMBDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewMBDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查代码字段
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewMBDM, strOldMBDM, "模版代码", "地产_B_公共_应收应付模版", objenumEditType) = False Then
                    GoTo errProc
                End If

                '释放资源
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
        ' 保存“地产_B_公共_应收应付模版”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doSaveData_YingshouYingfuMoban = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：未传入旧的数据！"
                            GoTo errProc
                        End If
                End Select

                '检查数据
                If Me.doVerifyData_YingshouYingfuMoban(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
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
                            '计算字段列表、字段值
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
                                        '计算列
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " insert into 地产_B_公共_应收应付模版 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM), "")

                            '计算字段列表、字段值
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
                                        '计算列
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " update 地产_B_公共_应收应付模版 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 模版代码 = @oldkey" + vbCr
                    End Select

                    '执行SQL
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 删除“地产_B_公共_应收应付模版”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_YingshouYingfuMoban = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objOldData Is Nothing Then
                    strErrMsg = "错误：未传入旧的数据！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '删除数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
                    Dim strOldKey As String
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM), "")
                    '删除下级
                    strSQL = ""
                    strSQL = strSQL + " delete from 地产_B_公共_应收应付模版 "
                    strSQL = strSQL + " where 模版代码 like @oldkey +'.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 地产_B_公共_应收应付模版 "
                    strSQL = strSQL + " where 模版代码 = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 获取“地产_B_公共_区域划分”的SQL语句(以“区域代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_QuyuHuafen() As String
            getTableSQL_QuyuHuafen = "select * from 地产_B_公共_区域划分 order by 区域代码"
        End Function

        '----------------------------------------------------------------
        ' 根据“区域代码”获取“区域名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strQydm                   ：区域代码
        '     strQymc                   ：区域名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strQydm Is Nothing Then strQydm = ""

                '计算
                strSQL = "select dbo.uf_estate_gg_getQyhfmc('" + strQydm + "')"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
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
        ' 根据“区域名称”获取“区域代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strQymc                   ：区域名称
        '     strQydm                   ：区域代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strQymc Is Nothing Then strQymc = ""

                '计算
                strSQL = ""
                strSQL = strSQL + " select * from 地产_B_公共_区域划分" + vbCr
                strSQL = strSQL + " where 区域名称 = '" + strQymc + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strQydm = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("区域代码"), "")
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
        ' 获取“地产_B_公共_区域划分”完全数据的数据集(以“区域代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCommonData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_QuyuHuafen = False
            objestateCommonData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateCommonData = New Josco.JSOA.Common.Data.estateCommonData(Josco.JSOA.Common.Data.estateCommonData.enumTableType.DC_B_GG_QUYUHUAFEN)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 地产_B_公共_区域划分 a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.区域代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“地产_B_公共_区域划分”的数据的合法性
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型

        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：未传入旧的数据！"
                            GoTo errProc
                        End If
                End Select

                '获取表结构定义
                strSQL = "select top 0 * from 地产_B_公共_区域划分"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "地产_B_公共_区域划分", objDataSet) = False Then
                    GoTo errProc
                End If

                '检查数据长度
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
                                strErrMsg = "错误：没有输入[" + strField + "]！"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "错误：[" + strField + "]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
                                    GoTo errProc
                                End If
                            End With
                    End Select
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '检查“区域代码”约束
                Dim strOldQYDM As String = ""
                Dim strNewQYDM As String = ""
                strNewQYDM = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_QUYUHUAFEN_QYDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 地产_B_公共_区域划分 where 区域代码 = @qydm"
                        objListDictionary.Add("@qydm", strNewQYDM)
                    Case Else
                        strOldQYDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_QUYUHUAFEN_QYDM), "")
                        strSQL = "select * from 地产_B_公共_区域划分 where 区域代码 = @qydm and 区域代码 <> @oldqydm"
                        objListDictionary.Add("@qydm", strNewQYDM)
                        objListDictionary.Add("@oldqydm", strOldQYDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewQYDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查“区域名称”约束
                Dim strNewQYMC As String = ""
                strNewQYMC = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_QUYUHUAFEN_QYMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 地产_B_公共_区域划分 where 区域名称 = @qymc"
                        objListDictionary.Add("@qymc", strNewQYMC)
                    Case Else
                        strSQL = "select * from 地产_B_公共_区域划分 where 区域名称 = @qymc and 区域代码 <> @oldqydm"
                        objListDictionary.Add("@qymc", strNewQYMC)
                        objListDictionary.Add("@oldqydm", strOldQYDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewQYMC + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查代码字段
                If Me.doValidCode_QuyuHuafen(strErrMsg, strUserId, strPassword, strNewQYDM, strOldQYDM, "区域代码", "地产_B_公共_区域划分", objenumEditType) = False Then
                    GoTo errProc
                End If

                '释放资源
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
        ' 保存“地产_B_公共_区域划分”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doSaveData_QuyuHuafen = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：未传入旧的数据！"
                            GoTo errProc
                        End If
                End Select

                '检查数据
                If Me.doVerifyData_QuyuHuafen(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
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
                            '计算字段列表、字段值
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " insert into 地产_B_公共_区域划分 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_QUYUHUAFEN_QYDM), "")

                            '计算字段列表、字段值
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " update 地产_B_公共_区域划分 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 区域代码 = @oldkey" + vbCr
                    End Select

                    '执行SQL
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 删除“地产_B_公共_区域划分”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_QuyuHuafen = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objOldData Is Nothing Then
                    strErrMsg = "错误：未传入旧的数据！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '删除数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
                    Dim strOldKey As String
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_QUYUHUAFEN_QYDM), "")
                    '删除下级
                    strSQL = ""
                    strSQL = strSQL + " delete from 地产_B_公共_区域划分 "
                    strSQL = strSQL + " where 区域代码 like @oldkey +'.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 地产_B_公共_区域划分 "
                    strSQL = strSQL + " where 区域代码 = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 获取“地产_B_公共_办案项目”的SQL语句(以“项目代码”升序排序)
        ' 返回
        '                          ：SQL
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function getTableSQL_BAXM() As String
            getTableSQL_BAXM = "select * from 地产_B_公共_办案项目 order by 项目代码"
        End Function

        '----------------------------------------------------------------
        ' 根据“项目代码”获取“项目名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strXmdm                   ：项目代码
        '     strXmmc                   ：项目名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strXmdm Is Nothing Then strXmdm = ""

                '计算
                strSQL = "select 项目名称 from 地产_B_公共_办案项目 where 项目代码 = '" + strXmdm + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
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
        ' 根据“项目名称”获取“项目代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strXmmc                   ：项目名称
        '     strXmdm                   ：项目代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strXmmc Is Nothing Then strXmmc = ""

                '计算
                strSQL = ""
                strSQL = strSQL + " select * from 地产_B_公共_办案项目" + vbCr
                strSQL = strSQL + " where 项目名称 = '" + strXmmc + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
                With objDataSet
                    If .Tables.Count < 1 Then
                        Exit Try
                    End If
                    If .Tables(0).Rows.Count < 1 Then
                        Exit Try
                    End If
                    strXmdm = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("项目代码"), "")
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
        ' 获取“地产_B_公共_办案项目”完全数据的数据集(以“项目代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCommonData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
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

            '初始化
            getDataSet_BAXM = False
            objestateCommonData = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateCommonData = New Josco.JSOA.Common.Data.estateCommonData(Josco.JSOA.Common.Data.estateCommonData.enumTableType.DC_B_GG_BAXM)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 地产_B_公共_办案项目 a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.项目代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“地产_B_公共_办案项目”的数据的合法性
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：合法
        '     False                ：不合法或其他程序错误
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：未传入旧的数据！"
                            GoTo errProc
                        End If
                End Select

                '获取表结构定义
                strSQL = "select top 0 * from 地产_B_公共_办案项目"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "地产_B_公共_办案项目", objDataSet) = False Then
                    GoTo errProc
                End If

                '检查数据长度
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
                                strErrMsg = "错误：没有输入[" + strField + "]！"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "错误：[" + strField + "]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
                                    GoTo errProc
                                End If
                            End With
                    End Select
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '检查“项目代码”约束
                Dim strOldXMDM As String = ""
                Dim strNewXMDM As String = ""
                strNewXMDM = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_BAXM_XMDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 地产_B_公共_办案项目 where 项目代码 = @xmdm"
                        objListDictionary.Add("@xmdm", strNewXMDM)
                    Case Else
                        strOldXMDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_BAXM_XMDM), "")
                        strSQL = "select * from 地产_B_公共_办案项目 where 项目代码 = @xmdm and 项目代码 <> @oldxmdm"
                        objListDictionary.Add("@xmdm", strNewXMDM)
                        objListDictionary.Add("@oldxmdm", strOldXMDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewXMDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查“项目名称”约束
                Dim strNewXMMC As String = ""
                strNewXMMC = objNewData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_BAXM_XMMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 地产_B_公共_办案项目 where 项目名称 = @xmmc"
                        objListDictionary.Add("@xmmc", strNewXMMC)
                    Case Else
                        strSQL = "select * from 地产_B_公共_办案项目 where 项目名称 = @xmmc and 项目代码 <> @oldxmdm"
                        objListDictionary.Add("@xmmc", strNewXMMC)
                        objListDictionary.Add("@oldxmdm", strOldXMDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewXMMC + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查代码字段
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewXMDM, strOldXMDM, "项目代码", "地产_B_公共_办案项目", objenumEditType) = False Then
                    GoTo errProc
                End If

                '释放资源
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
        ' 保存“地产_B_公共_办案项目”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
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

            '初始化
            doSaveData_BAXM = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：未传入旧的数据！"
                            GoTo errProc
                        End If
                End Select

                '检查数据
                If Me.doVerifyData_BAXM(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
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
                            '计算字段列表、字段值
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " insert into 地产_B_公共_办案项目 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_BAXM_XMDM), "")

                            '计算字段列表、字段值
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " update 地产_B_公共_办案项目 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 项目代码 = @oldkey" + vbCr
                    End Select

                    '执行SQL
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 删除“地产_B_公共_办案项目”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
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

            '初始化
            doDeleteData_BAXM = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If objOldData Is Nothing Then
                    strErrMsg = "错误：未传入旧的数据！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '删除数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
                    Dim strOldKey As String
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCommonData.FIELD_DC_B_GG_BAXM_XMDM), "")
                    '删除下级
                    strSQL = ""
                    strSQL = strSQL + " delete from 地产_B_公共_办案项目 "
                    strSQL = strSQL + " where 项目代码 like @oldkey +'.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 地产_B_公共_办案项目 "
                    strSQL = strSQL + " where 项目代码 = @oldkey"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    objSqlTransaction.Rollback()
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                objSqlTransaction.Commit()
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 获取“地产_B_公共_物业性质”选择列表数据集
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCommonData        ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改
        '     zengxianglin 2010-12-25 创建
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

            '初始化
            getDataSet_WuyeXingzhi_List = False
            objDataSet = Nothing
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempDataSet = New Josco.JSOA.Common.Data.estateCommonData(Josco.JSOA.Common.Data.estateCommonData.enumTableType.DC_B_GG_WUYEXINGZHI)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 地产_B_公共_物业性质 a " + vbCr
                        strSQL = strSQL + " where a.是否启用 = 1" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " and " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.显示顺序,a.性质代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
