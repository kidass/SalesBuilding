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
    ' 类名    ：dacEstateRenshiGeneral
    '
    ' 功能描述：
    '     提供对通用人事管理数据的相关数据层操作
    ' 更改记录：
    '     zengxianglin 2009-05-14 更改
    '     zengxianglin 2009-05-18 更改
    '     zengxianglin 2010-01-06 更改
    '----------------------------------------------------------------

    Public Class dacEstateRenshiGeneral
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
        ' 将strSrcFile中的strSrcSheet复制到strDesFile中的strDesSheet
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strSrcFile             ：源文件的完整路径
        '     strSrcSheet            ：源文件的sheet名
        '     strDesFile             ：目标文件的完整路径
        '     strDesSheet            ：目标文件的sheet名
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2009-05-18 创建
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
        ' 删除strSrcFile中的strSrcSheet
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strSrcFile             ：源文件的完整路径
        '     strSrcSheet            ：源文件的sheet名
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2009-05-18 创建
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
        ' 获取“人事_B_技术职称”的SQL语句(以“职称代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_JishuZhicheng() As String
            getTableSQL_JishuZhicheng = "select * from 人事_B_技术职称 order by 职称代码"
        End Function

        '----------------------------------------------------------------
        ' 根据“职称代码”获取“职称名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strZcdm                   ：职称代码
        '     strZcmc                   ：职称名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strZcdm Is Nothing Then strZcdm = ""

                '计算
                strSQL = "select dbo.uf_rs_getZhichengName('" + strZcdm + "')"
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
        ' 根据“职称名称”获取“职称代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strZcmc                   ：职称名称
        '     strZcdm                   ：职称代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strZcmc Is Nothing Then strZcmc = ""

                '计算
                strSQL = ""
                strSQL = strSQL + " select * from 人事_B_技术职称" + vbCr
                strSQL = strSQL + " where 职称名称 = '" + strZcmc + "'"
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
                    strZcmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("职称代码"), "")
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
        ' 获取“人事_B_技术职称”完全数据的数据集(以“职称代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_JishuZhicheng = False
            objestateRenshiGeneralData = Nothing
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
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_JISHUZHICHENG)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 人事_B_技术职称 a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.职称代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“人事_B_技术职称”的数据的合法性
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
                strSQL = "select top 0 * from 人事_B_技术职称"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "人事_B_技术职称", objDataSet) = False Then
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

                '检查“职称代码”约束
                Dim strOldZCDM As String = ""
                Dim strNewZCDM As String = ""
                strNewZCDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JISHUZHICHENG_ZCDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 人事_B_技术职称 where 职称代码 = @zcdm"
                        objListDictionary.Add("@zcdm", strNewZCDM)
                    Case Else
                        strOldZCDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JISHUZHICHENG_ZCDM), "")
                        strSQL = "select * from 人事_B_技术职称 where 职称代码 = @zcdm and 职称代码 <> @oldzcdm"
                        objListDictionary.Add("@zcdm", strNewZCDM)
                        objListDictionary.Add("@oldzcdm", strOldZCDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewZCDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查“职称名称”约束
                Dim strNewZCMC As String = ""
                strNewZCMC = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JISHUZHICHENG_ZCMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 人事_B_技术职称 where 职称名称 = @zcmc"
                        objListDictionary.Add("@zcmc", strNewZCMC)
                    Case Else
                        strSQL = "select * from 人事_B_技术职称 where 职称名称 = @zcmc and 职称代码 <> @oldzcdm"
                        objListDictionary.Add("@zcmc", strNewZCMC)
                        objListDictionary.Add("@oldzcdm", strOldZCDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewZCMC + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查代码字段
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewZCDM, strOldZCDM, "职称代码", "人事_B_技术职称", objenumEditType) = False Then
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
        ' 保存“人事_B_技术职称”的数据
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

            '初始化
            doSaveData_JishuZhicheng = False
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
                If Me.doVerifyData_JishuZhicheng(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                            strSQL = strSQL + " insert into 人事_B_技术职称 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JISHUZHICHENG_ZCDM), "")

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
                            strSQL = strSQL + " update 人事_B_技术职称 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 职称代码 = @oldkey" + vbCr
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
        ' 删除“人事_B_技术职称”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_JishuZhicheng = False
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
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_JISHUZHICHENG_ZCDM), "")
                    '删除下级
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_技术职称 "
                    strSQL = strSQL + " where 职称代码 like @oldkey +'.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_技术职称 "
                    strSQL = strSQL + " where 职称代码 = @oldkey"
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
        ' 获取“人事_B_学历划分”的SQL语句(以“学历代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_XueliHuafen() As String
            getTableSQL_XueliHuafen = "select * from 人事_B_学历划分 order by 学历代码"
        End Function

        '----------------------------------------------------------------
        ' 根据“学历代码”获取“学历名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strXldm                   ：学历代码
        '     strXlmc                   ：学历名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strXldm Is Nothing Then strXldm = ""

                '计算
                strSQL = "select dbo.uf_rs_getXueliName('" + strXldm + "')"
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
        ' 根据“学历名称”获取“学历代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strXlmc                   ：学历名称
        '     strXldm                   ：学历代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strXlmc Is Nothing Then strXlmc = ""

                '计算
                strSQL = ""
                strSQL = strSQL + " select * from 人事_B_学历划分" + vbCr
                strSQL = strSQL + " where 学历名称 = '" + strXlmc + "'"
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
                    strXlmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("学历代码"), "")
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
        ' 获取“人事_B_学历划分”完全数据的数据集(以“学历代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_XueliHuafen = False
            objestateRenshiGeneralData = Nothing
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
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_XUELIHUAFEN)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 人事_B_学历划分 a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.学历代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“人事_B_学历划分”的数据的合法性
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
                strSQL = "select top 0 * from 人事_B_学历划分"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "人事_B_学历划分", objDataSet) = False Then
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

                '检查“学历代码”约束
                Dim strOldXLDM As String = ""
                Dim strNewXLDM As String = ""
                strNewXLDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUELIHUAFEN_XLDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 人事_B_学历划分 where 学历代码 = @xldm"
                        objListDictionary.Add("@xldm", strNewXLDM)
                    Case Else
                        strOldXLDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUELIHUAFEN_XLDM), "")
                        strSQL = "select * from 人事_B_学历划分 where 学历代码 = @xldm and 学历代码 <> @oldxldm"
                        objListDictionary.Add("@xldm", strNewXLDM)
                        objListDictionary.Add("@oldxldm", strOldXLDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewXLDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查“学历名称”约束
                Dim strNewXLMC As String = ""
                strNewXLMC = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUELIHUAFEN_XLMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 人事_B_学历划分 where 学历名称 = @xlmc"
                        objListDictionary.Add("@xlmc", strNewXLMC)
                    Case Else
                        strSQL = "select * from 人事_B_学历划分 where 学历名称 = @xlmc and 学历代码 <> @oldxldm"
                        objListDictionary.Add("@xlmc", strNewXLMC)
                        objListDictionary.Add("@oldxldm", strOldXLDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewXLMC + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查代码字段
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewXLDM, strOldXLDM, "学历代码", "人事_B_学历划分", objenumEditType) = False Then
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
        ' 保存“人事_B_学历划分”的数据
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

            '初始化
            doSaveData_XueliHuafen = False
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
                If Me.doVerifyData_XueliHuafen(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                            strSQL = strSQL + " insert into 人事_B_学历划分 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUELIHUAFEN_XLDM), "")

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
                            strSQL = strSQL + " update 人事_B_学历划分 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 学历代码 = @oldkey" + vbCr
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
        ' 删除“人事_B_学历划分”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_XueliHuafen = False
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
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUELIHUAFEN_XLDM), "")
                    '删除下级
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_学历划分 "
                    strSQL = strSQL + " where 学历代码 like @oldkey + '.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_学历划分 "
                    strSQL = strSQL + " where 学历代码 = @oldkey"
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
        ' 获取“人事_B_学位划分”的SQL语句(以“学位代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_XueweiHuafen() As String
            getTableSQL_XueweiHuafen = "select * from 人事_B_学位划分 order by 学位代码"
        End Function

        '----------------------------------------------------------------
        ' 根据“学位代码”获取“学位名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strXwdm                   ：学位代码
        '     strXwmc                   ：学位名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strXwdm Is Nothing Then strXwdm = ""

                '计算
                strSQL = "select dbo.uf_rs_getXueweiName('" + strXwdm + "')"
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
        ' 根据“学位名称”获取“学位代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strXwmc                   ：学位名称
        '     strXwdm                   ：学位代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strXwmc Is Nothing Then strXwmc = ""

                '计算
                strSQL = ""
                strSQL = strSQL + " select * from 人事_B_学位划分" + vbCr
                strSQL = strSQL + " where 学位名称 = '" + strXwmc + "'"
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
                    strXwmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("学位代码"), "")
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
        ' 获取“人事_B_学位划分”完全数据的数据集(以“学位代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_XueweiHuafen = False
            objestateRenshiGeneralData = Nothing
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
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_XUEWEIHUAFEN)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 人事_B_学位划分 a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.学位代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“人事_B_学位划分”的数据的合法性
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
                strSQL = "select top 0 * from 人事_B_学位划分"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "人事_B_学位划分", objDataSet) = False Then
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

                '检查“学位代码”约束
                Dim strOldXWDM As String = ""
                Dim strNewXWDM As String = ""
                strNewXWDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEWEIHUAFEN_XWDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 人事_B_学位划分 where 学位代码 = @xwdm"
                        objListDictionary.Add("@xwdm", strNewXWDM)
                    Case Else
                        strOldXWDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEWEIHUAFEN_XWDM), "")
                        strSQL = "select * from 人事_B_学位划分 where 学位代码 = @xwdm and 学位代码 <> @oldxwdm"
                        objListDictionary.Add("@xwdm", strNewXWDM)
                        objListDictionary.Add("@oldxwdm", strOldXWDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewXWDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查“学位名称”约束
                Dim strNewXWMC As String = ""
                strNewXWMC = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEWEIHUAFEN_XWMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 人事_B_学位划分 where 学位名称 = @xwmc"
                        objListDictionary.Add("@xwmc", strNewXWMC)
                    Case Else
                        strSQL = "select * from 人事_B_学位划分 where 学位名称 = @xwmc and 学位代码 <> @oldxwdm"
                        objListDictionary.Add("@xwmc", strNewXWMC)
                        objListDictionary.Add("@oldxwdm", strOldXWDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewXWMC + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查代码字段
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewXWDM, strOldXWDM, "学位代码", "人事_B_学位划分", objenumEditType) = False Then
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
        ' 保存“人事_B_学位划分”的数据
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

            '初始化
            doSaveData_XueweiHuafen = False
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
                If Me.doVerifyData_XueweiHuafen(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                            strSQL = strSQL + " insert into 人事_B_学位划分 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEWEIHUAFEN_XWDM), "")

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
                            strSQL = strSQL + " update 人事_B_学位划分 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 学位代码 = @oldkey" + vbCr
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
        ' 删除“人事_B_学位划分”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_XueweiHuafen = False
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
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_XUEWEIHUAFEN_XWDM), "")
                    '删除下级
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_学位划分 "
                    strSQL = strSQL + " where 学位代码 like @oldkey + '.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_学位划分 "
                    strSQL = strSQL + " where 学位代码 = @oldkey"
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
        ' 获取“人事_B_政治面貌”的SQL语句(以“面貌代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ZhengzhiMianmao() As String
            getTableSQL_ZhengzhiMianmao = "select * from 人事_B_政治面貌 order by 面貌代码"
        End Function

        '----------------------------------------------------------------
        ' 根据“面貌代码”获取“面貌名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strMmdm                   ：面貌代码
        '     strMmmc                   ：面貌名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strMmdm Is Nothing Then strMmdm = ""

                '计算
                strSQL = "select dbo.uf_rs_getZhengzhimianmaoName('" + strMmdm + "')"
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
        ' 根据“面貌名称”获取“面貌代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strMmmc                   ：面貌名称
        '     strMmdm                   ：面貌代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strMmmc Is Nothing Then strMmmc = ""

                '计算
                strSQL = ""
                strSQL = strSQL + " select * from 人事_B_政治面貌" + vbCr
                strSQL = strSQL + " where 面貌名称 = '" + strMmmc + "'"
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
                    strMmmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("面貌代码"), "")
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
        ' 获取“人事_B_政治面貌”完全数据的数据集(以“面貌代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_ZhengzhiMianmao = False
            objestateRenshiGeneralData = Nothing
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
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_ZHENGZHIMIANMAO)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 人事_B_政治面貌 a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.面貌代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“人事_B_政治面貌”的数据的合法性
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
                strSQL = "select top 0 * from 人事_B_政治面貌"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "人事_B_政治面貌", objDataSet) = False Then
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

                '检查“面貌代码”约束
                Dim strOldMMDM As String = ""
                Dim strNewMMDM As String = ""
                strNewMMDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHENGZHIMIANMAO_MMDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 人事_B_政治面貌 where 面貌代码 = @mmdm"
                        objListDictionary.Add("@mmdm", strNewMMDM)
                    Case Else
                        strOldMMDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHENGZHIMIANMAO_MMDM), "")
                        strSQL = "select * from 人事_B_政治面貌 where 面貌代码 = @mmdm and 面貌代码 <> @oldmmdm"
                        objListDictionary.Add("@mmdm", strNewMMDM)
                        objListDictionary.Add("@oldmmdm", strOldMMDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewMMDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查“面貌名称”约束
                Dim strNewMMMC As String = ""
                strNewMMMC = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHENGZHIMIANMAO_MMMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 人事_B_政治面貌 where 面貌名称 = @mmmc"
                        objListDictionary.Add("@mmmc", strNewMMMC)
                    Case Else
                        strSQL = "select * from 人事_B_政治面貌 where 面貌名称 = @mmmc and 面貌代码 <> @oldmmdm"
                        objListDictionary.Add("@mmmc", strNewMMMC)
                        objListDictionary.Add("@oldmmdm", strOldMMDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewMMMC + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查代码字段
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewMMDM, strOldMMDM, "面貌代码", "人事_B_政治面貌", objenumEditType) = False Then
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
        ' 保存“人事_B_政治面貌”的数据
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

            '初始化
            doSaveData_ZhengzhiMianmao = False
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
                If Me.doVerifyData_ZhengzhiMianmao(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                            strSQL = strSQL + " insert into 人事_B_政治面貌 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHENGZHIMIANMAO_MMDM), "")

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
                            strSQL = strSQL + " update 人事_B_政治面貌 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 面貌代码 = @oldkey" + vbCr
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
        ' 删除“人事_B_政治面貌”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_ZhengzhiMianmao = False
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
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHENGZHIMIANMAO_MMDM), "")
                    '删除下级
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_政治面貌 "
                    strSQL = strSQL + " where 面貌代码 like @oldkey + '.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_政治面貌 "
                    strSQL = strSQL + " where 面貌代码 = @oldkey"
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
        ' 获取“人事_B_执业资格”的SQL语句(以“资格代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ZhiyeZige() As String
            getTableSQL_ZhiyeZige = "select * from 人事_B_执业资格 order by 资格代码"
        End Function

        '----------------------------------------------------------------
        ' 根据“资格代码”获取“资格名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strZgdm                   ：资格代码
        '     strZgmc                   ：资格名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strZgdm Is Nothing Then strZgdm = ""

                '计算
                strSQL = "select dbo.uf_rs_getZhiyezigeName('" + strZgdm + "')"
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
        ' 根据“资格名称”获取“资格代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strZgmc                   ：资格名称
        '     strZgdm                   ：资格代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strZgmc Is Nothing Then strZgmc = ""

                '计算
                strSQL = ""
                strSQL = strSQL + " select * from 人事_B_执业资格" + vbCr
                strSQL = strSQL + " where 资格名称 = '" + strZgmc + "'"
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
                    strZgmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("资格代码"), "")
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
        ' 获取“人事_B_执业资格”完全数据的数据集(以“资格代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_ZhiyeZige = False
            objestateRenshiGeneralData = Nothing
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
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_ZHIYEZIGE)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 人事_B_执业资格 a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.资格代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“人事_B_执业资格”的数据的合法性
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
                strSQL = "select top 0 * from 人事_B_执业资格"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "人事_B_执业资格", objDataSet) = False Then
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

                '检查“资格代码”约束
                Dim strOldZGDM As String = ""
                Dim strNewZGDM As String = ""
                strNewZGDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIYEZIGE_ZGDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 人事_B_执业资格 where 资格代码 = @zgdm"
                        objListDictionary.Add("@zgdm", strNewZGDM)
                    Case Else
                        strOldZGDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIYEZIGE_ZGDM), "")
                        strSQL = "select * from 人事_B_执业资格 where 资格代码 = @zgdm and 资格代码 <> @oldzgdm"
                        objListDictionary.Add("@zgdm", strNewZGDM)
                        objListDictionary.Add("@oldzgdm", strOldZGDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewZGDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查“资格名称”约束
                Dim strNewZGMC As String = ""
                strNewZGMC = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIYEZIGE_ZGMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 人事_B_执业资格 where 资格名称 = @zgmc"
                        objListDictionary.Add("@zgmc", strNewZGMC)
                    Case Else
                        strSQL = "select * from 人事_B_执业资格 where 资格名称 = @zgmc and 资格代码 <> @oldzgdm"
                        objListDictionary.Add("@zgmc", strNewZGMC)
                        objListDictionary.Add("@oldzgdm", strOldZGDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewZGMC + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查代码字段
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewZGDM, strOldZGDM, "资格代码", "人事_B_执业资格", objenumEditType) = False Then
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
        ' 保存“人事_B_执业资格”的数据
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

            '初始化
            doSaveData_ZhiyeZige = False
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
                If Me.doVerifyData_ZhiyeZige(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                            strSQL = strSQL + " insert into 人事_B_执业资格 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIYEZIGE_ZGDM), "")

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
                            strSQL = strSQL + " update 人事_B_执业资格 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 资格代码 = @oldkey" + vbCr
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
        ' 删除“人事_B_执业资格”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_ZhiyeZige = False
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
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIYEZIGE_ZGDM), "")
                    '删除下级
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_执业资格 "
                    strSQL = strSQL + " where 资格代码 like @oldkey + '.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_执业资格 "
                    strSQL = strSQL + " where 资格代码 = @oldkey"
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
        ' 获取“人事_B_变动原因”的SQL语句(以“原因代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_BiandongYuanyin() As String
            getTableSQL_BiandongYuanyin = "select * from 人事_B_变动原因 order by 原因代码"
        End Function

        '----------------------------------------------------------------
        ' 根据“原因代码”获取“原因名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strYydm                   ：原因代码
        '     strYymc                   ：原因名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strYydm Is Nothing Then strYydm = ""

                '计算
                strSQL = "select dbo.uf_rs_getBiandongyuanyinName('" + strYydm + "')"
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
        ' 根据“原因名称”获取“原因代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strYymc                   ：原因名称
        '     strYydm                   ：原因代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strYymc Is Nothing Then strYymc = ""

                '计算
                strSQL = ""
                strSQL = strSQL + " select * from 人事_B_变动原因" + vbCr
                strSQL = strSQL + " where 原因名称 = '" + strYymc + "'"
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
                    strYymc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("原因代码"), "")
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
        ' 获取“人事_B_变动原因”完全数据的数据集(以“原因代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_BiandongYuanyin = False
            objestateRenshiGeneralData = Nothing
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
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_BIANDONGYUANYIN)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 人事_B_变动原因 a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.原因代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“人事_B_变动原因”的数据的合法性
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
                strSQL = "select top 0 * from 人事_B_变动原因"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "人事_B_变动原因", objDataSet) = False Then
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

                '检查“原因代码”约束
                Dim strOldYYDM As String = ""
                Dim strNewYYDM As String = ""
                strNewYYDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 人事_B_变动原因 where 原因代码 = @yydm"
                        objListDictionary.Add("@yydm", strNewYYDM)
                    Case Else
                        strOldYYDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM), "")
                        strSQL = "select * from 人事_B_变动原因 where 原因代码 = @yydm and 原因代码 <> @oldyydm"
                        objListDictionary.Add("@yydm", strNewYYDM)
                        objListDictionary.Add("@oldyydm", strOldYYDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewYYDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查“原因名称”约束
                Dim strNewYYMC As String = ""
                strNewYYMC = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 人事_B_变动原因 where 原因名称 = @yymc"
                        objListDictionary.Add("@yymc", strNewYYMC)
                    Case Else
                        strSQL = "select * from 人事_B_变动原因 where 原因名称 = @yymc and 原因代码 <> @oldyydm"
                        objListDictionary.Add("@yymc", strNewYYMC)
                        objListDictionary.Add("@oldyydm", strOldYYDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewYYMC + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查代码字段
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewYYDM, strOldYYDM, "原因代码", "人事_B_变动原因", objenumEditType) = False Then
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
        ' 保存“人事_B_变动原因”的数据
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

            '初始化
            doSaveData_BiandongYuanyin = False
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
                If Me.doVerifyData_BiandongYuanyin(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                            strSQL = strSQL + " insert into 人事_B_变动原因 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM), "")

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
                            strSQL = strSQL + " update 人事_B_变动原因 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 原因代码 = @oldkey" + vbCr
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
        ' 删除“人事_B_变动原因”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_BiandongYuanyin = False
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
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_BIANDONGYUANYIN_YYDM), "")
                    '删除下级
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_变动原因 "
                    strSQL = strSQL + " where 原因代码 like @oldkey + '.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_变动原因 "
                    strSQL = strSQL + " where 原因代码 = @oldkey"
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
        ' 获取“人事_B_职工属性”的SQL语句(以“属性代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ZhigongShuxing() As String
            getTableSQL_ZhigongShuxing = "select * from 人事_B_职工属性 order by 属性代码"
        End Function

        '----------------------------------------------------------------
        ' 根据“属性代码”获取“属性名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strSxdm                   ：属性代码
        '     strSxmc                   ：属性名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strSxdm Is Nothing Then strSxdm = ""

                '计算
                strSQL = "select dbo.uf_rs_getZhigongshuxingName('" + strSxdm + "')"
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
        ' 根据“属性名称”获取“属性代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strSxmc                   ：属性名称
        '     strSxdm                   ：属性代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strSxmc Is Nothing Then strSxmc = ""

                '计算
                strSQL = ""
                strSQL = strSQL + " select * from 人事_B_职工属性" + vbCr
                strSQL = strSQL + " where 属性名称 = '" + strSxmc + "'"
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
                    strSxmc = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item("属性代码"), "")
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
        ' 获取“人事_B_职工属性”完全数据的数据集(以“属性代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_ZhigongShuxing = False
            objestateRenshiGeneralData = Nothing
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
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_ZHIGONGSHUXING)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 人事_B_职工属性 a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.属性代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“人事_B_职工属性”的数据的合法性
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
                strSQL = "select top 0 * from 人事_B_职工属性"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "人事_B_职工属性", objDataSet) = False Then
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

                '检查“属性代码”约束
                Dim strOldSXDM As String = ""
                Dim strNewSXDM As String = ""
                strNewSXDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIGONGSHUXING_SXDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 人事_B_职工属性 where 属性代码 = @sxdm"
                        objListDictionary.Add("@sxdm", strNewSXDM)
                    Case Else
                        strOldSXDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIGONGSHUXING_SXDM), "")
                        strSQL = "select * from 人事_B_职工属性 where 属性代码 = @sxdm and 属性代码 <> @oldsxdm"
                        objListDictionary.Add("@sxdm", strNewSXDM)
                        objListDictionary.Add("@oldsxdm", strOldSXDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewSXDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查“属性名称”约束
                Dim strNewSXMC As String = ""
                strNewSXMC = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIGONGSHUXING_SXMC)
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 人事_B_职工属性 where 属性名称 = @sxmc"
                        objListDictionary.Add("@sxmc", strNewSXMC)
                    Case Else
                        strSQL = "select * from 人事_B_职工属性 where 属性名称 = @sxmc and 属性代码 <> @oldsxdm"
                        objListDictionary.Add("@sxmc", strNewSXMC)
                        objListDictionary.Add("@oldsxdm", strOldSXDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewSXMC + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '检查代码字段
                If Me.doValidCode(strErrMsg, strUserId, strPassword, strNewSXDM, strOldSXDM, "属性代码", "人事_B_职工属性", objenumEditType) = False Then
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
        ' 保存“人事_B_职工属性”的数据
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

            '初始化
            doSaveData_ZhigongShuxing = False
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
                If Me.doVerifyData_ZhigongShuxing(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                            strSQL = strSQL + " insert into 人事_B_职工属性 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIGONGSHUXING_SXDM), "")

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
                            strSQL = strSQL + " update 人事_B_职工属性 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 属性代码 = @oldkey" + vbCr
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
        ' 删除“人事_B_职工属性”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_ZhigongShuxing = False
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
                    strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_ZHIGONGSHUXING_SXDM), "")
                    '删除下级
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_职工属性 "
                    strSQL = strSQL + " where 属性代码 like @oldkey + '.%'"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strOldKey)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_职工属性 "
                    strSQL = strSQL + " where 属性代码 = @oldkey"
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
        ' 获取“人事_B_人事卡片”完全数据的数据集(以“人员代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_RSKP = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_RSKP]未指定[连接用户]！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_RENSHIKAPIAN)

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
                        strSQL = strSQL + "     部门名称         = dbo.uf_gg_getZzmcByZzdm(a.部门)," + vbCr
                        strSQL = strSQL + "     年龄             = abs(datediff(yyyy,getdate(),a.出生日期))," + vbCr
                        strSQL = strSQL + "     户口状态名称     = dbo.uf_rs_getHukouStatusName(a.户口状态)," + vbCr
                        strSQL = strSQL + "     婚姻状况名称     = dbo.uf_rs_getHunyinStatusName(a.婚姻状况)," + vbCr
                        strSQL = strSQL + "     生育情况名称     = dbo.uf_rs_getShengyuStatusName(a.生育情况)," + vbCr
                        strSQL = strSQL + "     最高学历名称     = dbo.uf_rs_getXueliName(a.最高学历)," + vbCr
                        strSQL = strSQL + "     最高学位名称     = dbo.uf_rs_getXueweiName(a.最高学位)," + vbCr
                        strSQL = strSQL + "     技术职称名称     = dbo.uf_rs_getZhichengName(a.技术职称)," + vbCr
                        strSQL = strSQL + "     执业资格名称     = dbo.uf_rs_getZhiyezigeName(a.执业资格)," + vbCr
                        strSQL = strSQL + "     政治面貌名称     = dbo.uf_rs_getZhengzhimianmaoName(a.政治面貌)," + vbCr
                        strSQL = strSQL + "     是否工会成员名称 = case when a.是否工会成员 = 1 then @true else @false end," + vbCr
                        strSQL = strSQL + "     是否市管干部名称 = case when a.是否市管干部 = 1 then @true else @false end," + vbCr
                        strSQL = strSQL + "     人员区域特性名称 = dbo.uf_rs_getRenyuanTexingStatusName(a.人员区域特性)," + vbCr
                        strSQL = strSQL + "     居住情况名称     = dbo.uf_rs_getJuzhuStatusName(a.居住情况)," + vbCr
                        strSQL = strSQL + "     本人是独生子名称 = case when a.本人是独生子 = 1 then @true else @false end," + vbCr
                        strSQL = strSQL + "     是否领独生证名称 = case when a.是否领独生证 = 1 then @true else @false end," + vbCr
                        strSQL = strSQL + "     是否军转干部名称 = case when a.是否军转干部 = 1 then @true else @false end," + vbCr
                        strSQL = strSQL + "     成员服役状态名称 = dbo.uf_rs_getFuyuStatusName(a.成员服役状态)," + vbCr
                        strSQL = strSQL + "     个人服役状态名称 = dbo.uf_rs_getFuyuStatusName(a.个人服役状态)," + vbCr
                        strSQL = strSQL + "     担任职务         = dbo.GetGWMCByRydm(a.人员代码,@fgf)," + vbCr
                        strSQL = strSQL + "     职级代码         = b.职级代码," + vbCr
                        strSQL = strSQL + "     职级名称         = dbo.uf_estate_rs_getZjmc(b.职级代码)," + vbCr
                        strSQL = strSQL + "     是否在职         = dbo.uf_rs_getShifouZaizhi(a.人员代码, @jcsj)," + vbCr
                        strSQL = strSQL + "     转正时间         = c.转正时间," + vbCr
                        strSQL = strSQL + "     转正职位         = c.转正职位," + vbCr
                        strSQL = strSQL + "     离职原因         = d.离职原因," + vbCr
                        strSQL = strSQL + "     子女数量         = dbo.uf_rs_getZinvShuliang(a.人员代码)" + vbCr
                        strSQL = strSQL + "   from 人事_B_人事卡片 a " + vbCr
                        strSQL = strSQL + "   left join dbo.uf_estate_rs_getValidGuanliJiagou(@jcsj) b on a.人员代码 = b.人员代码" + vbCr
                        strSQL = strSQL + "   left join dbo.uf_rs_getZhuanzhengInfo(@jcsj) c on a.人员代码 = c.人员代码" + vbCr
                        strSQL = strSQL + "   left join dbo.uf_rs_getLizhiInfo(@jcsj) d on a.人员代码 = d.人员代码" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.人员代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@true", Josco.JsKernal.Common.Utilities.PulicParameters.CharTrue)
                        objSqlCommand.Parameters.AddWithValue("@false", Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse)
                        objSqlCommand.Parameters.AddWithValue("@fgf", Josco.JsKernal.Common.Utilities.PulicParameters.CharSeparate)
                        objSqlCommand.Parameters.AddWithValue("@jcsj", Now)
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 获取“人事_B_家庭成员”完全数据的数据集(以“血缘关系”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：人员代码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_RSKP_JTCY = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_RSKP_JTCY]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_JIATINGCHENGYUAN)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from 人事_B_家庭成员 a" + vbCr
                        strSQL = strSQL + " where a.人员代码 = @rydm" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " and " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.血缘关系 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 获取“人事_B_学习经历”完全数据的数据集(以“开始年月”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：人员代码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_RSKP_XXJL = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_RSKP_XXJL]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_XUEXIJINGLI)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from 人事_B_学习经历 a" + vbCr
                        strSQL = strSQL + " where a.人员代码 = @rydm" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " and " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.开始年月 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 获取“人事_B_工作经历”完全数据的数据集(以“开始年月”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：人员代码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_RSKP_GZJL = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_RSKP_GZJL]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_GONGZUOJINGLI)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from 人事_B_工作经历 a" + vbCr
                        strSQL = strSQL + " where a.人员代码 = @rydm" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " and " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.开始年月 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“人事_B_人事卡片”的数据的合法性
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
                strSQL = "select top 0 * from 人事_B_人事卡片"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "人事_B_人事卡片", objDataSet) = False Then
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
                            '显示列
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_WYBS
                            '自动赋值
                            If strValue = "" Then
                                If objdacCommon.getNewGUID(strErrMsg, strUserId, strPassword, strValue) = False Then
                                    GoTo errProc
                                End If
                            End If
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYDM, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_XM, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_XB
                            If strValue = "" Then
                                strErrMsg = "错误：[" + strField + "]没有输入内容！"
                                GoTo errProc
                            End If
                            With objDataSet.Tables(0).Columns(strField)
                                intLen = objPulicParameters.getStringLength(strValue)
                                If intLen > .MaxLength Then
                                    strErrMsg = "错误：[" + strField + "]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
                                    GoTo errProc
                                End If
                            End With
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_CSRQ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RBDWSJ
                            If strValue = "" Then
                                strErrMsg = "错误：[" + strField + "]没有输入内容！"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(strValue) = False Then
                                strErrMsg = "错误：[" + strField + "]没有输入无效的日期！"
                                GoTo errProc
                            End If

                            'zengxianglin 2009-01-07
                            '增加Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ
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
                            '增加 Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_TXSJ
                            'zengxianglin 2009-01-12
                            If strValue <> "" Then
                                If objPulicParameters.isDatetimeString(strValue) = False Then
                                    strErrMsg = "错误：[" + strField + "]没有输入无效的日期！"
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
                                    strErrMsg = "错误：[" + strField + "]没有输入无效的数字！"
                                    GoTo errProc
                                End If
                            End If
                        Case Else
                            If strValue <> "" Then
                                With objDataSet.Tables(0).Columns(strField)
                                    intLen = objPulicParameters.getStringLength(strValue)
                                    If intLen > .MaxLength Then
                                        strErrMsg = "错误：[" + strField + "]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
                                        GoTo errProc
                                    End If
                                End With
                            End If
                    End Select
                    objNewData(strField) = strValue
                Next
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '检查“人员代码”约束
                Dim strOldRYDM As String = ""
                Dim strNewRYDM As String = ""
                strNewRYDM = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYDM)
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                        Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                        strSQL = "select * from 人事_B_人事卡片 where 人员代码 = @rydm"
                        objListDictionary.Add("@rydm", strNewRYDM)
                    Case Else
                        strOldRYDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYDM), "")
                        strSQL = "select * from 人事_B_人事卡片 where 人员代码 = @rydm and 人员代码 <> @oldrydm"
                        objListDictionary.Add("@rydm", strNewRYDM)
                        objListDictionary.Add("@oldrydm", strOldRYDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strNewRYDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objListDictionary.Clear()

                '释放资源
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)

                'zengxianglin 2009-01-07
                '其他辅助检查
                Dim strValues(2) As String
                strValues(0) = ""
                strValues(0) = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_JSZC)
                If strValues(0) Is Nothing Then strValues(0) = ""
                strValues(1) = ""
                strValues(1) = objNewData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZCQDSJ)
                If strValues(1) Is Nothing Then strValues(1) = ""
                If strValues(0) <> "" And strValues(1) = "" Then
                    strErrMsg = "错误：您必须指定[" + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZCQDSJ + "]!"
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
                    strErrMsg = "错误：您必须指定[" + Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ + "]!"
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
        ' 备份Http文件
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strOldFileHttpSpec     ：相片文件的现HTTP路径
        '     strAppRoot             ：应用根Http路径(不带/)
        '     objServer              ：服务器对象
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
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
                '检查
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

                '备份
                Dim strLocalFile As String = ""
                Dim strHttpFile As String = ""
                strHttpFile = strAppRoot + Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP + strOldFileHttpSpec
                strLocalFile = objServer.MapPath(strHttpFile)
                Dim blnDo As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strLocalFile, blnDo) = False Then
                    Exit Try
                End If
                If blnDo = True Then
                    '备份文件
                    If objBaseLocalFile.doCopyFile(strErrMsg, strLocalFile, strLocalFile + strBakExt, True) = False Then
                        GoTo errProc
                    End If
                    '删除现有文件
                    If objBaseLocalFile.doDeleteFile(strErrMsg, strLocalFile) = False Then
                        '形成垃圾文件！
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
        ' 删除Http备份文件
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strOldFileHttpSpec     ：相片文件的原HTTP路径
        '     strAppRoot             ：应用根Http路径(不带/)
        '     objServer              ：服务器对象
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
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
                '检查
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

                '删除备份
                Dim strLocalFile As String = ""
                Dim strHttpFile As String = ""
                strHttpFile = strAppRoot + Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP + strOldFileHttpSpec
                strLocalFile = objServer.MapPath(strHttpFile)
                strLocalFile = strLocalFile + strBakExt
                If objBaseLocalFile.doDeleteFile(strErrMsg, strLocalFile) = False Then
                    '形成垃圾文件！
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
        ' 从备份中恢复Http文件
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strOldFileHttpSpec     ：相片文件的原HTTP路径
        '     strAppRoot             ：应用根Http路径(不带/)
        '     objServer              ：服务器对象
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
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
                '检查
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

                '恢复
                Dim strLocalFile As String = ""
                Dim strHttpFile As String = ""
                strHttpFile = strAppRoot + Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP + strOldFileHttpSpec
                strLocalFile = objServer.MapPath(strHttpFile)
                '恢复文件
                If objBaseLocalFile.doCopyFile(strErrMsg, strLocalFile + strBakExt, strLocalFile, True) = False Then
                    GoTo errProc
                End If
                '删除备份
                If objBaseLocalFile.doDeleteFile(strErrMsg, strLocalFile + strBakExt) = False Then
                    '形成垃圾文件
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
        ' 保存“人事_B_人事卡片”的数据(现有事务)
        '     strErrMsg            ：如果错误，则返回错误信息
        '     objSqlTransaction    ：现有事务
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doSaveData_RSKP = False
            strErrMsg = ""

            Try
                '检查
                If objSqlTransaction Is Nothing Then
                    strErrMsg = "错误：未传入现有事务！"
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

                '获取连接
                objSqlConnection = objSqlTransaction.Connection

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
                    Dim strFileds As String = ""
                    Dim strValues As String = ""
                    Dim strField As String
                    Dim intCount As Integer
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            '计算更新字段列表
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
                                        '显示列
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
                            '准备SQL
                            strSQL = ""
                            strSQL = strSQL + " insert into 人事_B_人事卡片 (" + strFileds + ")"
                            strSQL = strSQL + " values (" + strValues + ")"
                            '准备参数
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
                                        '显示列

                                        'zengxianglin 2009-01-07
                                        '增加Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ
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
                                        '增加 Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_TXSJ
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
                            '执行SQL
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()

                        Case Else
                            '获取原“唯一标识”
                            Dim strOldWYBS As String
                            strOldWYBS = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_WYBS), "")
                            '计算更新字段列表
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
                                        '显示列
                                    Case Else
                                        If strFileds = "" Then
                                            strFileds = objNewData.GetKey(i) + " = @A" + i.ToString()
                                        Else
                                            strFileds = strFileds + "," + objNewData.GetKey(i) + " = @A" + i.ToString()
                                        End If
                                End Select
                            Next
                            '准备SQL
                            strSQL = ""
                            strSQL = strSQL + " update 人事_B_人事卡片 set " + vbCr
                            strSQL = strSQL + "   " + strFileds + vbCr
                            strSQL = strSQL + " where 唯一标识 = @oldwybs" + vbCr
                            '准备参数
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
                                        '显示列

                                        'zengxianglin 2009-01-07
                                        '增加Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ
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
                                        '增加 Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_TXSJ
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
                            '执行SQL
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

            '返回
            doSaveData_RSKP = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据本地文件获取相片文件的HTTP服务器文件的命名
        ' 命名方案：唯一标识+文件扩展名
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strLocalFile         ：本地文件名
        '     strWYBS              ：唯一标识
        '     strBasePath          ：该文件存放的HTTP基准路径(/)
        '     strRemoteFile        ：返回HTTP服务器文件路径(首字符不带/)
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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
                '检查
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

                '获取文件名
                Dim strFileName As String = ""
                Dim strFileExt As String = ""
                strFileExt = objBaseLocalFile.getExtension(strLocalFile)

                '命名方案：资源标识+文件扩展名
                strFileName = strWYBS + strFileExt

                '复合目录+文件
                strFileName = objBaseLocalFile.doMakePath(strBasePath, strFileName)

                '转换分隔符
                strFileName = strFileName.Replace(Josco.JsKernal.Common.Utilities.BaseLocalFile.DEFAULT_DIRSEP, Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP)
                If strFileName.Substring(0) = Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP Then
                    strFileName = strFileName.Substring(1)
                End If

                '返回
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
        ' 保存相片文件
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objSqlTransaction      ：现有事务
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strWYBS                ：唯一标识
        '     strOldFile             ：旧文件路径(相对HTTP根目录路径)
        '     strNewFile             ：要保存的文件的本地缓存文件完整路径
        '     strAppRoot             ：应用根Http路径(不带/)
        '     strBasePath            ：从应用根到存放地的相对HTTP目录(开头不带/)
        '     objServer              ：服务器对象
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
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
                '检查输入参数
                If objSqlTransaction Is Nothing Then
                    If strUserId Is Nothing Then strUserId = ""
                    strUserId = strUserId.Trim
                    If strUserId = "" Then
                        strErrMsg = "错误：未传入连接用户！"
                        GoTo errProc
                    End If
                End If
                If strNewFile Is Nothing Then strNewFile = ""
                strNewFile = strNewFile.Trim()
                If strNewFile = "" Then
                    '不用保存
                    Exit Try
                End If
                If objServer Is Nothing Then
                    strErrMsg = "错误：未传入[System.Web.HttpServerUtility]！"
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

                '检查文件是否存在?
                Dim blnExisted As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strNewFile, blnExisted) = False Then
                    GoTo errProc
                End If
                If blnExisted = False Then
                    strErrMsg = "错误：相片文件[" + strNewFile + "]不存在！"
                    GoTo errProc
                End If

                '获取文件信息
                strWJWZ = strOldFile

                '获取服务器文件
                Dim strDesFile As String
                If Me.getHTTPNewFileName(strErrMsg, strNewFile, strWYBS, strBasePath, strDesFile) = False Then
                    GoTo errProc
                End If

                '更新文件路径
                '获取事务连接
                If objSqlTransaction Is Nothing Then
                    If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                        GoTo errProc
                    End If
                Else
                    objSqlConnection = objSqlTransaction.Connection
                End If

                '备份原文件
                If Me.doHttpBackupFiles(strErrMsg, strWJWZ, strAppRoot, objServer) = False Then
                    GoTo errProc
                End If

                '开始事务
                If objSqlTransaction Is Nothing Then
                    blnNewTrans = True
                    objSqlTransaction = objSqlConnection.BeginTransaction
                Else
                    blnNewTrans = False
                End If

                '保存文件
                Dim strHttpFile As String = strAppRoot + Josco.JsKernal.Common.Utilities.BaseURI.DEFAULT_DIRSEP + strDesFile
                Dim strLocalFile As String = objServer.MapPath(strHttpFile)
                '创建路径
                If objBaseLocalFile.doCreateDirectory(strErrMsg, strLocalFile) = False Then
                    GoTo errProc
                End If
                '上传到HTTP最终位置
                If objBaseLocalFile.doCopyFile(strErrMsg, strNewFile, strLocalFile, True) = False Then
                    GoTo rollDatabaseAndFile
                End If

                Try
                    '准备命令参数
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '准备SQL
                    strSQL = ""
                    strSQL = strSQL + " update 人事_B_人事卡片 set " + vbCr
                    strSQL = strSQL + "   人员相片位置 = @wjwz " + vbCr
                    strSQL = strSQL + " where 唯一标识  = @wjbs " + vbCr
                    strSQL = strSQL + " and   人员相片位置 <> @wjwz " + vbCr

                    '执行命令
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@wjwz", strDesFile)
                    objSqlCommand.Parameters.AddWithValue("@wjbs", strWYBS)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabaseAndFile
                End Try

                '提交事务
                If blnNewTrans = True Then
                    objSqlTransaction.Commit()
                End If

                '删除备份文件
                If blnNewTrans = True Then
                    If Me.doHttpDeleteBackupFiles(strErrMsg, strWJWZ, strAppRoot, objServer) = False Then
                        '可以不成功，形成垃圾文件！
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
                    '可以不成功，形成垃圾数据
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
        ' 保存“人事_B_家庭成员”的数据(现有事务)
        '     strErrMsg            ：如果错误，则返回错误信息
        '     objSqlTransaction    ：现有事务
        '     strRYDM              ：人员代码
        '     objDataSet_JTCY      ：要保存的数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doSaveData_RSKP_JTCY = False
            strErrMsg = ""

            Try
                '检查
                If objSqlTransaction Is Nothing Then
                    strErrMsg = "错误：未传入现有事务！"
                    GoTo errProc
                End If
                If objDataSet_JTCY Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '获取连接
                objSqlConnection = objSqlTransaction.Connection

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '删除原有数据
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_家庭成员" + vbCr
                    strSQL = strSQL + " where 人员代码 = @rydm" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '保存数据
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    With objDataSet_JTCY.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_JIATINGCHENGYUAN).DefaultView
                        intCount = .Count
                        For i = 0 To intCount - 1 Step 1
                            strSQL = ""
                            strSQL = strSQL + " insert into 人事_B_家庭成员 (" + vbCr
                            strSQL = strSQL + "   唯一标识,人员代码,成员姓名,血缘关系,出生年月,服务单位,担任职务,现居地址" + vbCr
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

            '返回
            doSaveData_RSKP_JTCY = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存“人事_B_学习经历”的数据(现有事务)
        '     strErrMsg            ：如果错误，则返回错误信息
        '     objSqlTransaction    ：现有事务
        '     strRYDM              ：人员代码
        '     objDataSet_XXJL      ：要保存的数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doSaveData_RSKP_XXJL = False
            strErrMsg = ""

            Try
                '检查
                If objSqlTransaction Is Nothing Then
                    strErrMsg = "错误：未传入现有事务！"
                    GoTo errProc
                End If
                If objDataSet_XXJL Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '获取连接
                objSqlConnection = objSqlTransaction.Connection

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '删除原有数据
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_学习经历" + vbCr
                    strSQL = strSQL + " where 人员代码 = @rydm" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '保存数据
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    With objDataSet_XXJL.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_XUEXIJINGLI).DefaultView
                        intCount = .Count
                        For i = 0 To intCount - 1 Step 1
                            strSQL = ""
                            strSQL = strSQL + " insert into 人事_B_学习经历 (" + vbCr
                            strSQL = strSQL + "   唯一标识,人员代码,开始年月,终止年月,学习类型,学习院校,学习专业,学习结果" + vbCr
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

            '返回
            doSaveData_RSKP_XXJL = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存“人事_B_工作经历”的数据(现有事务)
        '     strErrMsg            ：如果错误，则返回错误信息
        '     objSqlTransaction    ：现有事务
        '     strRYDM              ：人员代码
        '     objDataSet_GZJL      ：要保存的数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doSaveData_RSKP_GZJL = False
            strErrMsg = ""

            Try
                '检查
                If objSqlTransaction Is Nothing Then
                    strErrMsg = "错误：未传入现有事务！"
                    GoTo errProc
                End If
                If objDataSet_GZJL Is Nothing Then
                    strErrMsg = "错误：未传入新的数据！"
                    GoTo errProc
                End If
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '获取连接
                objSqlConnection = objSqlTransaction.Connection

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '删除原有数据
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_工作经历" + vbCr
                    strSQL = strSQL + " where 人员代码 = @rydm" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '保存数据
                    Dim intCount As Integer = 0
                    Dim i As Integer = 0
                    With objDataSet_GZJL.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_B_GONGZUOJINGLI).DefaultView
                        intCount = .Count
                        For i = 0 To intCount - 1 Step 1
                            strSQL = ""
                            strSQL = strSQL + " insert into 人事_B_工作经历 (" + vbCr
                            strSQL = strSQL + "   唯一标识,人员代码,开始年月,终止年月,服务单位,担任职务" + vbCr
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

            '返回
            doSaveData_RSKP_GZJL = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存“人事_B_人事卡片”数据记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     objNewData             ：记录新值(返回保存后的新值)
        '     objOldData             ：记录旧值
        '     objenumEditType        ：编辑类型
        '     strUploadFile          ：上载文件的WEB本地完全路径
        '     strAppRoot             ：应用根Http路径(不带/)
        '     strBasePath            ：从应用根到存放地的相对HTTP目录(开头不带/)
        '     objServer              ：服务器对象
        '     objDataSet_JTCY        ：家庭成员数据集
        '     objDataSet_XXJL        ：学习经历数据集
        '     objDataSet_GZJL        ：工作经历数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "错误：未传入连接用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：没有指定要保存的数据！"
                    GoTo errProc
                End If
                If objServer Is Nothing Then
                    strErrMsg = "错误：没有指定[System.Web.HttpServerUtility]！"
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

                '检查主记录
                If Me.doVerifyData_RSKP(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '获取连接事务
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction

                '执行事务
                Try
                    '保存主记录
                    If Me.doSaveData_RSKP(strErrMsg, objSqlTransaction, objOldData, objNewData, objenumEditType) = False Then
                        GoTo rollDatabase
                    End If

                    '获取唯一标识
                    Dim strWYBS As String = objNewData(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_WYBS)
                    Dim strRYDM As String = objNewData(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYDM)

                    '保存“家庭成员”数据
                    If Me.doSaveData_RSKP_JTCY(strErrMsg, objSqlTransaction, strRYDM, objDataSet_JTCY) = False Then
                        GoTo rollDatabase
                    End If

                    '保存“学习经历”数据
                    If Me.doSaveData_RSKP_XXJL(strErrMsg, objSqlTransaction, strRYDM, objDataSet_XXJL) = False Then
                        GoTo rollDatabase
                    End If

                    '保存“工作经历”数据
                    If Me.doSaveData_RSKP_GZJL(strErrMsg, objSqlTransaction, strRYDM, objDataSet_GZJL) = False Then
                        GoTo rollDatabase
                    End If

                    '保存新图片文件
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

                    '删除备份文件
                    If Me.doHttpDeleteBackupFiles(strErrMsg, strWJWZ, strAppRoot, objServer) = False Then
                        '可以不成功，形成垃圾文件！
                    End If
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabase
                End Try

                '提交事务
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
                '可以不成功，形成垃圾数据
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
        ' 获取“人事_B_培训记录”完全数据的数据集(以“开始时间”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：人员代码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_RSKP_PXJL = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_RSKP_PXJL]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_PEIXUNJILU)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        objSqlCommand.Parameters.Clear()
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from" + vbCr
                        strSQL = strSQL + " (" + vbCr
                        strSQL = strSQL + "   select a.*," + vbCr
                        strSQL = strSQL + "     人员真名 = dbo.uf_gg_getRyzmByRydm(a.人员代码)," + vbCr
                        strSQL = strSQL + "     内部培训名称 = dbo.uf_rs_getPeixunLeixingName(a.内部培训)" + vbCr
                        strSQL = strSQL + "   from 人事_B_培训记录 a" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strRYDM <> "" Then
                            objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                            strSQL = strSQL + " where a.人员代码 = @rydm" + vbCr
                            If strWhere <> "" Then
                                strSQL = strSQL + " and " + strWhere + vbCr
                            End If
                        Else
                            If strWhere <> "" Then
                                strSQL = strSQL + " where " + strWhere + vbCr
                            End If
                        End If
                        strSQL = strSQL + " order by a.开始时间 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 获取“人事_B_人事异动”完全数据的数据集(以“开始时间”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：人员代码
        '     strWhere                   ：搜索字符串
        '     objRetDataSet              ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改
        '     zengxianglin 2010-01-06 更改
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

            '初始化
            getDataSet_RSKP_YDJL = False
            objRetDataSet = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_RSKP_YDJL]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_RENSHIYIDONG)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        objSqlCommand.Parameters.Clear()
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from" + vbCr
                        strSQL = strSQL + " (" + vbCr
                        strSQL = strSQL + "   select a.*," + vbCr
                        strSQL = strSQL + "     人员真名     = dbo.uf_gg_getRyzmByRydm(a.人员代码)," + vbCr
                        strSQL = strSQL + "     变动原因名称 = dbo.uf_rs_getBiandongyuanyinName(a.变动原因)," + vbCr
                        strSQL = strSQL + "     任职单位名称 = dbo.uf_gg_getZzmcByZzdm(a.任职单位)," + vbCr
                        strSQL = strSQL + "     职工属性名称 = dbo.uf_rs_getZhigongshuxingName(a.职工属性)," + vbCr
                        strSQL = strSQL + "     岗位属性名称 = dbo.uf_rs_getGangweiShuxingName(a.岗位属性)," + vbCr
                        strSQL = strSQL + "     级别标志名称 = dbo.uf_rs_getYidongJibieName(a.级别标志)," + vbCr
                        strSQL = strSQL + "     原任单位名称 = dbo.uf_gg_getZzmcByZzdm(a.原任单位)," + vbCr
                        'zengxianglin 2010-01-06
                        strSQL = strSQL + "     原职属性名称 = dbo.uf_rs_getZhigongshuxingName(a.原职属性)," + vbCr
                        strSQL = strSQL + "     原岗属性名称 = dbo.uf_rs_getGangweiShuxingName(a.原岗属性) " + vbCr
                        'zengxianglin 2010-01-06
                        strSQL = strSQL + "   from 人事_B_人事异动 a" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strRYDM <> "" Then
                            objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                            strSQL = strSQL + " where a.人员代码 = @rydm" + vbCr
                            If strWhere <> "" Then
                                strSQL = strSQL + " and " + strWhere + vbCr
                            End If
                        Else
                            If strWhere <> "" Then
                                strSQL = strSQL + " where " + strWhere + vbCr
                            End If
                        End If
                        strSQL = strSQL + " order by a.开始时间 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 获取“人事_B_劳动合同”完全数据的数据集(以“开始时间”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：人员代码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_RSKP_LDHT = False
            objestateRenshiGeneralData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_RSKP_LDHT]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strRYDM Is Nothing Then strRYDM = ""
                strRYDM = strRYDM.Trim

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateRenshiGeneralData = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_B_LAODONGHETONG)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        objSqlCommand.Parameters.Clear()
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*" + vbCr
                        strSQL = strSQL + " from" + vbCr
                        strSQL = strSQL + " (" + vbCr
                        strSQL = strSQL + "   select a.*," + vbCr
                        strSQL = strSQL + "     人员真名     = dbo.uf_gg_getRyzmByRydm(a.人员代码)," + vbCr
                        strSQL = strSQL + "     合同类型名称 = dbo.uf_rs_getHetongLeixingName(a.合同类型)," + vbCr
                        strSQL = strSQL + "     是否续约名称 = dbo.uf_rs_getHetongXuyueName(a.是否续约)," + vbCr
                        strSQL = strSQL + "     合同文件名称 = case when rtrim(isnull(a.合同文件,'')) = '' then @false else @true end" + vbCr
                        strSQL = strSQL + "   from 人事_B_劳动合同 a" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strRYDM <> "" Then
                            objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                            strSQL = strSQL + " where a.人员代码 = @rydm" + vbCr
                            If strWhere <> "" Then
                                strSQL = strSQL + " and " + strWhere + vbCr
                            End If
                        Else
                            If strWhere <> "" Then
                                strSQL = strSQL + " where " + strWhere + vbCr
                            End If
                        End If
                        strSQL = strSQL + " order by a.开始时间 " + vbCr
                        objSqlCommand.Parameters.AddWithValue("@false", Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse)
                        objSqlCommand.Parameters.AddWithValue("@true", Josco.JsKernal.Common.Utilities.PulicParameters.CharTrue)

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“人事_B_培训记录”的数据的合法性
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
                strSQL = "select top 0 * from 人事_B_培训记录"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "人事_B_培训记录", objDataSet) = False Then
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
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_NBPXMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_RYMC
                            '显示列
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_WYBS
                            '自动列
                            If strValue = "" Then
                                If objdacCommon.getNewGUID(strErrMsg, strUserId, strPassword, strValue) = False Then
                                    GoTo errProc
                                End If
                            End If
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_KSSJ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_ZZSJ
                            If strValue = "" Then
                                strErrMsg = "错误：没有输入[" + strField + "]！"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(strValue) = False Then
                                strErrMsg = "错误：[" + strValue + "]是无效的日期！"
                                GoTo errProc
                            End If
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_NBPX
                            If strValue = "" Then
                                strErrMsg = "错误：没有输入[" + strField + "]！"
                                GoTo errProc
                            End If
                            If objPulicParameters.isIntegerString(strValue) = False Then
                                strErrMsg = "错误：[" + strValue + "]是无效的数字！"
                                GoTo errProc
                            End If


                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_PXKS
                            If strValue <> "" Then
                                If objPulicParameters.isFloatString(strValue) = False Then
                                    strErrMsg = "错误：[" + strValue + "]是无效的数字！"
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_RYDM, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_PXMC
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
                        Case Else
                            If strValue <> "" Then
                                With objDataSet.Tables(0).Columns(strField)
                                    intLen = objPulicParameters.getStringLength(strValue)
                                    If intLen > .MaxLength Then
                                        strErrMsg = "错误：[" + strField + "]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
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
        ' 保存“人事_B_培训记录”的数据
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

            '初始化
            doSaveData_RSKP_PXJL = False
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
                If Me.doVerifyData_RSKP_PXJL(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                Dim intDefaultInt As Integer = 0
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
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_NBPXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_RYMC
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " insert into 人事_B_培训记录 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_PEIXUNJILU_WYBS), "")

                            '计算字段列表、字段值
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
                                        '计算列
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " update 人事_B_培训记录 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 唯一标识 = @oldkey" + vbCr
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
        ' 删除“人事_B_培训记录”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_RSKP_PXJL = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                If strWYBS = "" Then
                    Exit Try
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
                    Dim strOldKey As String = strWYBS
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_培训记录 "
                    strSQL = strSQL + " where 唯一标识 = @oldkey"
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
        ' 检查“人事_B_人事异动”的数据的合法性
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
        '     zengxianglin 2010-01-06 更改
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
                strSQL = "select top 0 * from 人事_B_人事异动"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "人事_B_人事异动", objDataSet) = False Then
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
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RYMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BDYYMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RZDWMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZGSXMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_GWSXMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YRDWMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_JBBZMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSXMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YZSXMC
                            '显示列
                            'zengxianglin 2010-01-06
                            'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSXMC, _
                            'Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YZSXMC
                            'zengxianglin 2010-01-06

                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_WYBS
                            '自动列
                            If strValue = "" Then
                                If objdacCommon.getNewGUID(strErrMsg, strUserId, strPassword, strValue) = False Then
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_KSSJ
                            If strValue = "" Then
                                strErrMsg = "错误：没有输入[" + strField + "]！"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(strValue) = False Then
                                strErrMsg = "错误：[" + strValue + "]是无效的日期！"
                                GoTo errProc
                            End If
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZZSJ
                            If strValue <> "" Then
                                If objPulicParameters.isDatetimeString(strValue) = False Then
                                    strErrMsg = "错误：[" + strValue + "]是无效的日期！"
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
                                    strErrMsg = "错误：[" + strValue + "]是无效的数字！"
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RYDM, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BDYY, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RZDW
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

                        Case Else
                            If strValue <> "" Then
                                With objDataSet.Tables(0).Columns(strField)
                                    intLen = objPulicParameters.getStringLength(strValue)
                                    If intLen > .MaxLength Then
                                        strErrMsg = "错误：[" + strField + "]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
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
        ' 保存“人事_B_人事异动”的数据
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
        '     zengxianglin 2010-01-06 更改
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

            '初始化
            doSaveData_RSKP_YDJL = False
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
                If Me.doVerifyData_RSKP_YDJL(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                Dim intDefaultInt As Integer = 0
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
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_BDYYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_RZDWMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_ZGSXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_GWSXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YRDWMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_JBBZMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YGSXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_YZSXMC
                                        '显示列
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " insert into 人事_B_人事异动 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIYIDONG_WYBS), "")

                            '计算字段列表、字段值
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
                                        '显示列
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " update 人事_B_人事异动 set " + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " where 唯一标识 = @oldkey" + vbCr
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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 删除“人事_B_人事异动”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_RSKP_YDJL = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                If strWYBS = "" Then
                    Exit Try
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
                    Dim strOldKey As String = strWYBS
                    '删除自身
                    strSQL = ""
                    strSQL = strSQL + " delete from 人事_B_人事异动 "
                    strSQL = strSQL + " where 唯一标识 = @oldkey"
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
        ' 检查“人事_B_劳动合同”的数据的合法性
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
                strSQL = "select top 0 * from 人事_B_劳动合同"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "人事_B_劳动合同", objDataSet) = False Then
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
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_RYMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTLXMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SFXYMC, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTWJMC
                            '显示列
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_WYBS
                            '自动列
                            If strValue = "" Then
                                If objdacCommon.getNewGUID(strErrMsg, strUserId, strPassword, strValue) = False Then
                                    GoTo errProc
                                End If
                            End If
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_KSSJ, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_JSSJ
                            If strValue = "" Then
                                strErrMsg = "错误：没有输入[" + strField + "]！"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(strValue) = False Then
                                strErrMsg = "错误：[" + strValue + "]是无效的日期！"
                                GoTo errProc
                            End If

                            'zengxianglin 2009-01-12
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SYKS, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SYJS
                            If strValue <> "" Then
                                If objPulicParameters.isDatetimeString(strValue) = False Then
                                    strErrMsg = "错误：[" + strValue + "]是无效的日期！"
                                    GoTo errProc
                                End If
                            End If
                            'zengxianglin 2009-01-12

                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTLX, _
                            Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SFXY
                            If strValue = "" Then
                                strErrMsg = "错误：没有输入[" + strField + "]！"
                                GoTo errProc
                            End If
                            If objPulicParameters.isIntegerString(strValue) = False Then
                                strErrMsg = "错误：[" + strValue + "]是无效的数字！"
                                GoTo errProc
                            End If
                        Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_RYDM
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
                        Case Else
                            If strValue <> "" Then
                                With objDataSet.Tables(0).Columns(strField)
                                    intLen = objPulicParameters.getStringLength(strValue)
                                    If intLen > .MaxLength Then
                                        strErrMsg = "错误：[" + strField + "]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
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
        ' 删除Ftp备份文件
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strOldFTPSpec          ：原FTP路径
        '     objFTPProperty         ：FTP连接参数
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
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
        ' 从备份中Ftp文件
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strOldFTPSpec          ：原FTP路径
        '     objFTPProperty         ：FTP连接参数
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
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
        ' 备份Ftp文件
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strOldFTPSpec          ：原FTP路径
        '     objFTPProperty         ：FTP连接参数
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
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
        ' 保存“人事_B_劳动合同”的数据(现有事务)
        '     strErrMsg            ：如果错误，则返回错误信息
        '     objSqlTransaction    ：现有事务
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doSaveData_RSKP_LDHT = False
            strErrMsg = ""

            Try
                '检查
                If objSqlTransaction Is Nothing Then
                    strErrMsg = "错误：未传入现有事务！"
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

                '获取连接
                objSqlConnection = objSqlTransaction.Connection

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
                    Dim strFileds As String = ""
                    Dim strValues As String = ""
                    Dim strField As String
                    Dim intCount As Integer
                    Dim i As Integer = 0
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            '计算更新字段列表
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_RYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTLXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SFXYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTWJMC
                                        '显示列
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
                            '准备SQL
                            strSQL = ""
                            strSQL = strSQL + " insert into 人事_B_劳动合同 (" + strFileds + ")"
                            strSQL = strSQL + " values (" + strValues + ")"
                            '准备参数
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_RYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTLXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SFXYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTWJMC
                                        '显示列

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
                            '执行SQL
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()

                        Case Else
                            '获取原“唯一标识”
                            Dim strOldWYBS As String
                            strOldWYBS = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_WYBS), "")
                            '计算更新字段列表
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_RYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTLXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SFXYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTWJMC
                                        '显示列
                                    Case Else
                                        If strFileds = "" Then
                                            strFileds = objNewData.GetKey(i) + " = @A" + i.ToString()
                                        Else
                                            strFileds = strFileds + "," + objNewData.GetKey(i) + " = @A" + i.ToString()
                                        End If
                                End Select
                            Next
                            '准备SQL
                            strSQL = ""
                            strSQL = strSQL + " update 人事_B_劳动合同 set " + vbCr
                            strSQL = strSQL + "   " + strFileds + vbCr
                            strSQL = strSQL + " where 唯一标识 = @oldwybs" + vbCr
                            '准备参数
                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    Case Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_RYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTLXMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_SFXYMC, _
                                        Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_LAODONGHETONG_HTWJMC
                                        '显示列

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
                            '执行SQL
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

            '返回
            doSaveData_RSKP_LDHT = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 根据本地文件获取FTP服务器文件的命名
        ' 命名方案：唯一标识+文件扩展名
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strLocalFile         ：本地文件名
        '     intWJND              ：文件年度
        '     strWYBS              ：唯一标识
        '     strBasePath          ：基本目录
        '     strRemoteFile        ：返回FTP服务器文件路径
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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
                '检查
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

                '获取文件名
                Dim strFileName As String = ""
                Dim strFileExt As String = ""
                strFileExt = objBaseLocalFile.getExtension(strLocalFile)

                '稿件命名方案：唯一标识+文件扩展名
                strFileName = strWYBS + strFileExt
                strFileName = objBaseLocalFile.doMakePath(intWJND.ToString(), strFileName)

                '复合目录+文件
                strFileName = objBaseLocalFile.doMakePath(strBasePath, strFileName)

                '返回
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
        ' 保存“人事_B_劳动合同”的“合同文件”
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strWYBS                ：唯一标识
        '     strOldFtpFile          ：原FTP文件
        '     intWJND                ：要保存到的年度
        '     objSqlTransaction      ：现有事务
        '     objFTPProperty         ：FTP连接参数
        '     strNewLocFile          ：要保存的本地缓存文件完整路径
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
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
                '检查输入参数
                If strNewLocFile Is Nothing Then strNewLocFile = ""
                strNewLocFile = strNewLocFile.Trim()
                If strNewLocFile = "" Then
                    '不用保存
                    Exit Try
                End If
                If objFTPProperty Is Nothing Then
                    strErrMsg = "错误：没有指定FTP的连接参数！"
                    GoTo errProc
                End If
                If objSqlTransaction Is Nothing Then
                    strErrMsg = "错误：没有指定事务！"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim
                If strWYBS = "" Then
                    strErrMsg = "错误：没有指定唯一标识！"
                    GoTo errProc
                End If
                If strOldFtpFile Is Nothing Then strOldFtpFile = ""
                strOldFtpFile = strOldFtpFile.Trim

                '检查文件是否存在?
                Dim blnExisted As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strNewLocFile, blnExisted) = False Then
                    GoTo errProc
                End If
                If blnExisted = False Then
                    strErrMsg = "错误：稿件文件[" + strNewLocFile + "]不存在！"
                    GoTo errProc
                End If

                '获取信息
                strZWNR = strOldFtpFile

                '获取服务器文件
                Dim strBasePath As String = Josco.JSOA.Common.Data.estateRenshiGeneralData.FILEDIR_RS_RSKP_LDHT
                Dim strDesFile As String
                If Me.getFTPNewFileName(strErrMsg, strNewLocFile, intWJND, strWYBS, strBasePath, strDesFile) = False Then
                    GoTo errProc
                End If

                '备份原文件
                If Me.doFtpBackupFiles(strErrMsg, strZWNR, objFTPProperty) = False Then
                    GoTo errProc
                End If

                '获取事务连接
                objSqlConnection = objSqlTransaction.Connection

                '上传文件
                Dim strDesUrl As String
                With objFTPProperty
                    strDesUrl = .getUrl(strDesFile)
                    If objBaseFTP.doPutFile(strErrMsg, strNewLocFile, strDesUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                        GoTo rollDatabaseAndFile
                    End If
                End With

                Try
                    '准备命令参数
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout
                    '准备SQL
                    strSQL = ""
                    strSQL = strSQL + " update 人事_B_劳动合同 set "
                    strSQL = strSQL + "   合同文件 = @zwnr "
                    strSQL = strSQL + " where 唯一标识  = @wjbs "
                    strSQL = strSQL + " and   合同文件 <> @zwnr "
                    '执行命令
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@zwnr", strDesFile)
                    objSqlCommand.Parameters.AddWithValue("@wjbs", strWYBS)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabaseAndFile
                End Try
                '提交事务
                If blnNewTrans = True Then
                    objSqlTransaction.Commit()
                End If

                '删除备份文件
                If blnNewTrans = True Then
                    If Me.doFtpDeleteBackupFiles(strErrMsg, strZWNR, objFTPProperty) = False Then
                        '可以不成功，形成垃圾文件！
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
                    '可以不成功，形成垃圾数据
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
        ' 保存“人事_B_劳动合同”数据记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     objNewData             ：记录新值(返回保存后的新值)
        '     objOldData             ：记录旧值
        '     objenumEditType        ：编辑类型
        '     strUploadFile          ：上载文件的Web本地完全路径
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "错误：未传入连接用户！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：没有指定要保存的数据！"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strUploadFile Is Nothing Then strUploadFile = ""
                strUploadFile = strUploadFile.Trim

                '检查主记录
                If Me.doVerifyData_RSKP_LDHT(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
                    GoTo errProc
                End If

                '获取连接事务
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取FTP参数
                If objdacXitongpeizhi.getFtpServerParam(strErrMsg, strUserId, strPassword, objFTPProperty) = False Then
                    GoTo errProc
                End If

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction

                '执行事务
                Try
                    '保存主记录
                    If Me.doSaveData_RSKP_LDHT(strErrMsg, objSqlTransaction, objOldData, objNewData, objenumEditType) = False Then
                        GoTo rollDatabase
                    End If

                    '获取唯一标识
                    Dim strWYBS As String = objNewData(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_WYBS)
                    Dim strRYDM As String = objNewData(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYDM)
                    Dim intWJND As Integer = Now.Year

                    '保存文件数据
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

                    '删除备份文件
                    If Me.doFtpDeleteBackupFiles(strErrMsg, strWJWZ, objFTPProperty) = False Then
                        '可以不成功，形成垃圾文件！
                    End If
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabase
                End Try

                '提交事务
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
                '可以不成功，形成垃圾数据
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
        ' 删除“人事_B_劳动合同”记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strWYBS              ：要删除的唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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
                '检查
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim
                If strWYBS = "" Then
                    '不用处理
                    Exit Try
                End If
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "错误：没有指定连接用户！"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取FTP参数
                If objdacXitongpeizhi.getFtpServerParam(strErrMsg, objSqlConnection, objFTPProperty) = False Then
                    GoTo errProc
                End If

                '获取主记录内容
                strSQL = "select * from 人事_B_劳动合同 where 唯一标识 = '" + strWYBS + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet_MAIN) = False Then
                    GoTo errProc
                End If

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '事务处理
                Dim strFilePath As String = ""
                Dim strUrl As String = ""
                Try
                    '删除主记录
                    strSQL = "delete from 人事_B_劳动合同 where 唯一标识 = '" + strWYBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除主记录中的FTP文件
                    With objDataSet_MAIN.Tables(0)
                        If .Rows.Count > 0 Then
                            '删除“合同文件”对应的文件
                            strFilePath = objPulicParameters.getObjectValue(.Rows(0).Item("合同文件"), "")
                            If strFilePath <> "" Then
                                With objFTPProperty
                                    strUrl = .getUrl(strFilePath)
                                    If objBaseFTP.doDeleteFile(strErrMsg, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                        '可以不成功，形成垃圾文件！
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

                '提交事务
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
        ' 删除“人事_B_人事卡片”记录及相关记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strWYBS              ：要删除的唯一标识
        '     objServer            ：System.Web.HttpServerUtility
        '     strHttpPathPrefix    ：Http目录前缀部分(末尾=/)
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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
                '检查
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim
                If strWYBS = "" Then
                    '不用处理
                    Exit Try
                End If
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "错误：没有指定连接用户！"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If objServer Is Nothing Then
                    strErrMsg = "错误：没有指定[System.Web.HttpServerUtility]！"
                    GoTo errProc
                End If
                If strHttpPathPrefix Is Nothing Then strHttpPathPrefix = ""
                strHttpPathPrefix = strHttpPathPrefix.Trim

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取FTP参数
                If objdacXitongpeizhi.getFtpServerParam(strErrMsg, objSqlConnection, objFTPProperty) = False Then
                    GoTo errProc
                End If

                '获取主记录内容
                strSQL = "select * from 人事_B_人事卡片 where 唯一标识 = '" + strWYBS + "'"
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
                '获取“人事_B_劳动合同”相关内容
                strSQL = "select * from 人事_B_劳动合同 where 人员代码 = '" + strRYDM + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet_LDHT) = False Then
                    GoTo errProc
                End If

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '事务处理
                Dim strFilePath As String = ""
                Dim strUrl As String = ""
                Dim intCount As Integer = 0
                Dim i As Integer = 0
                Try
                    '删除“人事_B_家庭成员”
                    strSQL = "delete from 人事_B_家庭成员 where 人员代码 = '" + strRYDM + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除“人事_B_学习经历”
                    strSQL = "delete from 人事_B_学习经历 where 人员代码 = '" + strRYDM + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除“人事_B_工作经历”
                    strSQL = "delete from 人事_B_工作经历 where 人员代码 = '" + strRYDM + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除“人事_B_培训记录”
                    strSQL = "delete from 人事_B_培训记录 where 人员代码 = '" + strRYDM + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除“人事_B_人事异动”
                    strSQL = "delete from 人事_B_人事异动 where 人员代码 = '" + strRYDM + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除“人事_B_劳动合同”
                    strSQL = "delete from 人事_B_劳动合同 where 人员代码 = '" + strRYDM + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除主记录
                    strSQL = "delete from 人事_B_人事卡片 where 唯一标识 = '" + strWYBS + "'"
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.ExecuteNonQuery()

                    '删除FTP文件
                    With objDataSet_LDHT.Tables(0)
                        intCount = .Rows.Count
                        For i = 0 To intCount - 1 Step 1
                            '删除“合同文件”对应的文件
                            strFilePath = objPulicParameters.getObjectValue(.Rows(i).Item("合同文件"), "")
                            If strFilePath <> "" Then
                                With objFTPProperty
                                    strUrl = .getUrl(strFilePath)
                                    If objBaseFTP.doDeleteFile(strErrMsg, strUrl, .UserID, .Password, .ProxyUrl, .ProxyUserID, .ProxyPassword) = False Then
                                        '可以不成功，形成垃圾文件！
                                    End If
                                End With
                            End If
                        Next
                    End With
                    Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet_LDHT)

                    '删除Http文件
                    With objDataSet_MAIN.Tables(0)
                        If .Rows.Count > 0 Then
                            strFilePath = objPulicParameters.getObjectValue(.Rows(0).Item(Josco.JSOA.Common.Data.estateRenshiGeneralData.FIELD_RS_B_RENSHIKAPIAN_RYXPWZ), "")
                            If strFilePath <> "" Then
                                strFilePath = strHttpPathPrefix + strFilePath
                                strFilePath = objServer.MapPath(strFilePath)
                                If objBaseLocalFile.doDeleteFile(strErrMsg, strFilePath) = False Then
                                    '可以不成功，形成垃圾文件！
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

                '提交事务
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
        ' 根据“地产_B_人事_个人履历”创建“人事_B_人事卡片”信息
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strGRLLRYDM            ：“地产_B_人事_个人履历”中的“人员代码”
        '     strUploadFile          ：上载文件的WEB本地完全路径
        '     strAppRoot             ：应用根Http路径(不带/)
        '     strBasePath            ：从应用根到存放地的相对HTTP目录(开头不带/)
        '     objServer              ：服务器对象
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
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
                '检查
                If strGRLLRYDM Is Nothing Then strGRLLRYDM = ""
                strGRLLRYDM = strGRLLRYDM.Trim
                If strGRLLRYDM = "" Then
                    Exit Try
                End If
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "错误：未传入连接用户！"
                    GoTo errProc
                End If
                If objServer Is Nothing Then
                    strErrMsg = "错误：没有指定[System.Web.HttpServerUtility]！"
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

                '获取连接事务
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取GUID
                Dim strWYBS As String = ""
                If objdacCommon.getNewGUID(strErrMsg, objSqlConnection, strWYBS) = False Then
                    GoTo errProc
                End If

                '保存文件到目标目录
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

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '执行事务
                Try
                    '形成“人事_B_人事卡片”记录
                    strSQL = ""
                    strSQL = strSQL + " insert into 人事_B_人事卡片 (" + vbCr
                    strSQL = strSQL + "   唯一标识,人员代码,姓名,性别,出生日期,入本单位时间," + vbCr
                    strSQL = strSQL + "   英文姓名,手机号码,住宅电话,身份证号," + vbCr
                    strSQL = strSQL + "   民族,籍贯,户籍地址,现住地址,人员相片位置," + vbCr
                    strSQL = strSQL + "   婚姻状况,生育情况," + vbCr
                    strSQL = strSQL + "   最高学历,最高学位,毕业院校,毕业专业,毕业时间," + vbCr
                    strSQL = strSQL + "   技术职称,职称取得时间," + vbCr
                    strSQL = strSQL + "   执业资格," + vbCr
                    strSQL = strSQL + "   政治面貌,入党时间" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   唯一标识=@wybs,人员代码,姓名,性别,出生日期,入本单位时间=getdate()," + vbCr
                    strSQL = strSQL + "   英文姓名,手机号码,住宅电话,身份证号," + vbCr
                    strSQL = strSQL + "   民族,籍贯,户籍地址,现住地址,人员相片位置=@ryxpwz," + vbCr
                    strSQL = strSQL + "   婚姻状况,生育情况," + vbCr
                    strSQL = strSQL + "   最高学历,最高学位,毕业院校,毕业专业,毕业时间," + vbCr
                    strSQL = strSQL + "   技术职称,职称取得时间," + vbCr
                    strSQL = strSQL + "   执业资格," + vbCr
                    strSQL = strSQL + "   政治面貌,入党时间" + vbCr
                    strSQL = strSQL + " from 地产_B_人事_个人履历" + vbCr
                    strSQL = strSQL + " where 人员代码 = @rydm" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    objSqlCommand.Parameters.AddWithValue("@ryxpwz", strFileName)
                    objSqlCommand.Parameters.AddWithValue("@rydm", strGRLLRYDM)
                    objSqlCommand.ExecuteNonQuery()

                    '形成“人事_B_学习经历”记录
                    strSQL = ""
                    strSQL = strSQL + " insert into 人事_B_学习经历 (" + vbCr
                    strSQL = strSQL + "   唯一标识,人员代码," + vbCr
                    strSQL = strSQL + "   开始年月,终止年月,学习类型,学习院校,学习专业,学习结果," + vbCr
                    strSQL = strSQL + "   备注信息" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select " + vbCr
                    strSQL = strSQL + "   唯一标识=newid(),人员代码," + vbCr
                    strSQL = strSQL + "   开始年月,终止年月,学习类型,学习院校,学习专业,学习结果," + vbCr
                    strSQL = strSQL + "   备注信息" + vbCr
                    strSQL = strSQL + " from 地产_B_人事_学习经历" + vbCr
                    strSQL = strSQL + " where 人员代码 = @rydm" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strGRLLRYDM)
                    objSqlCommand.ExecuteNonQuery()

                    '形成“人事_B_工作经历”记录
                    strSQL = ""
                    strSQL = strSQL + " insert into 人事_B_工作经历 (" + vbCr
                    strSQL = strSQL + "   唯一标识,人员代码," + vbCr
                    strSQL = strSQL + "   开始年月,终止年月,服务单位,担任职务," + vbCr
                    strSQL = strSQL + "   备注信息" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select " + vbCr
                    strSQL = strSQL + "   唯一标识=newid(),人员代码," + vbCr
                    strSQL = strSQL + "   开始年月,终止年月,服务单位,担任职务," + vbCr
                    strSQL = strSQL + "   备注信息" + vbCr
                    strSQL = strSQL + " from 地产_B_人事_工作经历" + vbCr
                    strSQL = strSQL + " where 人员代码 = @rydm" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strGRLLRYDM)
                    objSqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo rollDatabase
                End Try

                '提交事务
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
            '删除上载文件
            Dim strErrMsgA As String
            If strDesFile <> "" Then
                If objBaseLocalFile.doDeleteFile(strErrMsgA, strDesFile) = False Then
                    '忽略
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
        ' 计算[广州兴业_人事管理_人力资源状况调查表]的数据
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strJZRQ                ：统计截止日期
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strMacroName           ：宏名列表
        '     strMacroValue          ：宏值列表
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2009-01-07 创建
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "错误：[doPrint_RSBB_RLZYZKDCB]未指定的[连接用户]！"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strExcelFile Is Nothing Then strExcelFile = ""
                strExcelFile = strExcelFile.Trim
                If strExcelFile = "" Then
                    strErrMsg = "错误：[doPrint_RSBB_RLZYZKDCB]未指定的Excel文件！"
                    GoTo errProc
                End If
                Dim blnExisted As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strExcelFile, blnExisted) = False Then
                    GoTo errProc
                End If
                If blnExisted = False Then
                    strErrMsg = "错误：[doPrint_RSBB_RLZYZKDCB]Excel文件[" + strExcelFile + "]不存在！"
                    GoTo errProc
                End If
                If strJZRQ Is Nothing Then strJZRQ = ""
                strJZRQ = strJZRQ.Trim
                If objPulicParameters.isDatetimeString(strJZRQ) = False Then
                    strErrMsg = "错误：[doPrint_RSBB_RLZYZKDCB]输入的[" + strJZRQ + "]是无效的日期！"
                    GoTo errProc
                End If
                strJZRQ = CType(strJZRQ, System.DateTime).ToString("yyyy-MM-dd")

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '装载Excel
                objExcelFile.LoadXls(strExcelFile)

                '获取模版Sheet参数信息
                Dim objFormatSheet As GemBox.ExcelLite.ExcelWorksheet = Nothing
                Dim intSheetCount As Integer
                intSheetCount = objExcelFile.Worksheets.Count
                If intSheetCount < 2 Then
                    strErrMsg = "错误：[doPrint_RSBB_RLZYZKDCB][" + strExcelFile + "]文件中至少有[2]个Sheet！"
                    GoTo errProc
                End If
                objFormatSheet = objExcelFile.Worksheets(intSheetCount - 1)  '0,1,...
                If objdacExcel.getSheetParamDataSet(strErrMsg, objFormatSheet, intSheetCount, objParamDataSet) = False Then
                    GoTo errProc
                End If

                '逐个处理数据Sheet
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

                    '获取数据列
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
                        strErrMsg = "错误：[doPrint_RSBB_RLZYZKDCB]格式Sheet中关于数据Sheet的参数设置不正确！"
                        GoTo errProc
                    End If

                    '解析标题区
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

                    '计算数据区的数据
                    Dim strYXRYSql As String = ""
                    Dim dblZRS As Double = 0
                    Dim dblValue As Double

                    '计算报表数据
                    For j = 0 To 9 Step 1
                        i = intTitleRows + j

                        Select Case j
                            Case 0 '[职别结构]高级管理人员
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select 人员代码"
                                strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                                strSQL = strSQL + vbCr + "   where   级别标志 = 2"
                                strSQL = strSQL + vbCr + "   and     岗位属性 = 1"
                                strSQL = strSQL + vbCr + "   and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                strSQL = strSQL + vbCr + "   or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "   group by 人员代码"
                                strYXRYSql = strSQL
                            Case 1 '[职别结构]中层管理人员
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select 人员代码"
                                strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                                strSQL = strSQL + vbCr + "   where   级别标志 = 1"
                                strSQL = strSQL + vbCr + "   and     岗位属性 = 1"
                                strSQL = strSQL + vbCr + "   and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                strSQL = strSQL + vbCr + "   or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "   group by 人员代码"
                                strYXRYSql = strSQL
                            Case 2 '[职别结构]一般业务人员
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select 人员代码"
                                strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                                strSQL = strSQL + vbCr + "   where   级别标志 not in (1,2)"
                                strSQL = strSQL + vbCr + "   and     岗位属性 = 1"
                                strSQL = strSQL + vbCr + "   and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                strSQL = strSQL + vbCr + "   or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "   group by 人员代码"
                                strYXRYSql = strSQL

                            Case 3 '[学历结构]博士研究生
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select a.人员代码"
                                strSQL = strSQL + vbCr + "   from"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select 人员代码"
                                strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                strSQL = strSQL + vbCr + "     where   岗位属性 = 1"
                                strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "     group by 人员代码"
                                strSQL = strSQL + vbCr + "   ) a"
                                strSQL = strSQL + vbCr + "   left join"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select 人员代码"
                                strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                strSQL = strSQL + vbCr + "     where 最高学历 = '008'"
                                strSQL = strSQL + vbCr + "     and   毕业时间 is not null"
                                strSQL = strSQL + vbCr + "     and   毕业时间 < '" + strJZRQ + "'"
                                strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                strYXRYSql = strSQL
                            Case 4 '[学历结构]硕士研究生
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select a.人员代码"
                                strSQL = strSQL + vbCr + "   from"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select 人员代码"
                                strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                strSQL = strSQL + vbCr + "     where   岗位属性 = 1"
                                strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "     group by 人员代码"
                                strSQL = strSQL + vbCr + "   ) a"
                                strSQL = strSQL + vbCr + "   left join"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select 人员代码"
                                strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                strSQL = strSQL + vbCr + "     where 最高学历 = '007'"
                                strSQL = strSQL + vbCr + "     and   毕业时间 is not null"
                                strSQL = strSQL + vbCr + "     and   毕业时间 < '" + strJZRQ + "'"
                                strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                strYXRYSql = strSQL
                            Case 5 '[学历结构]本科
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select a.人员代码"
                                strSQL = strSQL + vbCr + "   from"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select 人员代码"
                                strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                strSQL = strSQL + vbCr + "     where   岗位属性 = 1"
                                strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "     group by 人员代码"
                                strSQL = strSQL + vbCr + "   ) a"
                                strSQL = strSQL + vbCr + "   left join"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select 人员代码"
                                strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                strSQL = strSQL + vbCr + "     where 最高学历 = '006'"
                                strSQL = strSQL + vbCr + "     and   毕业时间 is not null"
                                strSQL = strSQL + vbCr + "     and   毕业时间 < '" + strJZRQ + "'"
                                strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                strYXRYSql = strSQL
                            Case 6 '[学历结构]专科及以下
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select a.人员代码"
                                strSQL = strSQL + vbCr + "   from"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select 人员代码"
                                strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                strSQL = strSQL + vbCr + "     where   岗位属性 = 1"
                                strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "     group by 人员代码"
                                strSQL = strSQL + vbCr + "   ) a"
                                strSQL = strSQL + vbCr + "   left join"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select 人员代码"
                                strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                strSQL = strSQL + vbCr + "     where 最高学历 not in ('008','007','006')"
                                strSQL = strSQL + vbCr + "     and   毕业时间 is not null"
                                strSQL = strSQL + vbCr + "     and   毕业时间 < '" + strJZRQ + "'"
                                strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                strYXRYSql = strSQL

                            Case 7 '[年龄结构]45岁以上
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select a.人员代码"
                                strSQL = strSQL + vbCr + "   from"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select 人员代码"
                                strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                strSQL = strSQL + vbCr + "     where   岗位属性 = 1"
                                strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "     group by 人员代码"
                                strSQL = strSQL + vbCr + "   ) a"
                                strSQL = strSQL + vbCr + "   left join"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select 人员代码"
                                strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                strSQL = strSQL + vbCr + "     where 出生日期 is not null"
                                strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,出生日期,'" + strJZRQ + "'))+1 >= 45"
                                strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                strYXRYSql = strSQL
                            Case 8 '[年龄结构]35岁-45岁
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select a.人员代码"
                                strSQL = strSQL + vbCr + "   from"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select 人员代码"
                                strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                strSQL = strSQL + vbCr + "     where   岗位属性 = 1"
                                strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "     group by 人员代码"
                                strSQL = strSQL + vbCr + "   ) a"
                                strSQL = strSQL + vbCr + "   left join"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select 人员代码"
                                strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                strSQL = strSQL + vbCr + "     where 出生日期 is not null"
                                strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,出生日期,'" + strJZRQ + "'))+1 >= 35"
                                strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,出生日期,'" + strJZRQ + "'))+1 <  45"
                                strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                strYXRYSql = strSQL
                            Case 9 '[年龄结构]35岁以下
                                strSQL = ""
                                strSQL = strSQL + vbCr + "   select a.人员代码"
                                strSQL = strSQL + vbCr + "   from"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select 人员代码"
                                strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                strSQL = strSQL + vbCr + "     where   岗位属性 = 1"
                                strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "     group by 人员代码"
                                strSQL = strSQL + vbCr + "   ) a"
                                strSQL = strSQL + vbCr + "   left join"
                                strSQL = strSQL + vbCr + "   ("
                                strSQL = strSQL + vbCr + "     select 人员代码"
                                strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                strSQL = strSQL + vbCr + "     where 出生日期 is not null"
                                strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,出生日期,'" + strJZRQ + "'))+1 <  35"
                                strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                strYXRYSql = strSQL
                        End Select

                        '计算指定项人数
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

                        '计算总人数
                        If j <= 2 Then dblZRS = dblZRS + dblValue

                        '计算党员数
                        If j >= 7 And j <= 9 Then
                            '本项数据不计算
                        Else
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select 人员代码"
                            strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                            strSQL = strSQL + vbCr + "   where 政治面貌 = '001'"
                            strSQL = strSQL + vbCr + "   and   入党时间 is not null"
                            strSQL = strSQL + vbCr + "   and   入党时间 <= '" + strJZRQ + "'"
                            strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                            strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 5).Value = dblValue
                        End If

                        '计算助理经济师
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 职称取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   职称取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   技术职称 = '003.003'"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 6).Value = dblValue
                        '计算经济师
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 职称取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   职称取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   技术职称 = '003.002'"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 7).Value = dblValue
                        '计算高级经济师
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 职称取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   职称取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   技术职称 = '003.001'"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 8).Value = dblValue

                        '计算助理工程师
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 职称取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   职称取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   技术职称 = '002.005'"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 9).Value = dblValue
                        '计算工程师
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 职称取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   职称取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   技术职称 = '002.004'"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 10).Value = dblValue
                        '计算高级工程师
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 职称取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   职称取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   技术职称 in ('002.001','002.002','002.003')"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 11).Value = dblValue

                        '计算助理会计师
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 职称取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   职称取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   技术职称 = '004.003'"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 12).Value = dblValue
                        '计算会计师
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 职称取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   职称取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   技术职称 = '004.002'"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 13).Value = dblValue
                        '计算高级会计师
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 职称取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   职称取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   技术职称 = '004.001'"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 14).Value = dblValue

                        '计算其他-初级
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 职称取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   职称取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   技术职称 = '005.003'"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 15).Value = dblValue
                        '计算其他-中级
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 职称取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   职称取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   技术职称 = '005.002'"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 16).Value = dblValue
                        '计算其他-高级
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 职称取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   职称取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   技术职称 = '005.001'"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 17).Value = dblValue

                        '计算执业资格-初级
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 资格取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   资格取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   执业资格 = '001.001.003'"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 18).Value = dblValue
                        '计算执业资格-中级
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 资格取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   资格取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   执业资格 = '001.001.002'"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 19).Value = dblValue
                        '计算执业资格-高级
                        strSQL = ""
                        strSQL = strSQL + vbCr + " select count(*)"
                        strSQL = strSQL + vbCr + " from"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + strYXRYSql
                        strSQL = strSQL + vbCr + " ) a"
                        strSQL = strSQL + vbCr + " left join"
                        strSQL = strSQL + vbCr + " ("
                        strSQL = strSQL + vbCr + "   select 人员代码"
                        strSQL = strSQL + vbCr + "   from 人事_B_人事卡片"
                        strSQL = strSQL + vbCr + "   where 资格取得时间 is not null"
                        strSQL = strSQL + vbCr + "   and   资格取得时间 <= '" + strJZRQ + "'"
                        strSQL = strSQL + vbCr + "   and   执业资格 = '001.001.001'"
                        strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                        strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                        If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                            GoTo errProc
                        End If
                        objDataSheet.Cells(i, 20).Value = dblValue
                    Next

                    '输出总人数
                    objDataSheet.Cells(intTitleRows, 3).Value = dblZRS
                    objDataSheet.Cells(intTitleRows + 7, 4).Value = "n/a"
                    objDataSheet.Cells(intTitleRows + 7, 5).Value = "n/a"
                Next

                '保存Excel
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
        ' 计算[人员增减异动表]数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-01-07 创建
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

            '初始化
            getDataSet_BB_RYZJYDB = False
            objDataSet = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_BB_RYZJYDB]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strKSRQ Is Nothing Then strKSRQ = ""
                strKSRQ = strKSRQ.Trim
                If objPulicParameters.isDatetimeString(strKSRQ) = False Then
                    strErrMsg = "错误：[getDataSet_BB_RYZJYDB]指定的[" + strKSRQ + "]无效！"
                    GoTo errProc
                End If
                If strZZRQ Is Nothing Then strZZRQ = ""
                strZZRQ = strZZRQ.Trim
                If objPulicParameters.isDatetimeString(strZZRQ) = False Then
                    strErrMsg = "错误：[getDataSet_BB_RYZJYDB]指定的[" + strZZRQ + "]无效！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempDataSet = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_VT_RYZJYDB)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        strSQL = ""
                        strSQL = strSQL + " select a.* from dbo.uf_rs_getRYZJYDB(@ksrq, @zzrq) a order by a.记录序号" + vbCr
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@ksrq", strKSRQ)
                        objSqlCommand.Parameters.AddWithValue("@zzrq", strZZRQ)
                        .SelectCommand = objSqlCommand
                        .Fill(objTempDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_VT_RYZJYDB))
                    End With
                    '检查
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

            '返回
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
        ' 打印[广州兴业_人事管理_人员增减异动表]的数据
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objDataSet             ：要打印的数据
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strMacroName           ：宏名列表
        '     strMacroValue          ：宏值列表
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2009-01-07 创建
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
                '检查
                If objDataSet Is Nothing Then
                    strErrMsg = "错误：[doPrint_RSBB_RYZJYDB]未指定的打印数据！"
                    GoTo errProc
                End If
                If objDataSet.Tables.Count < 1 Then
                    strErrMsg = "错误：[doPrint_RSBB_RYZJYDB]未指定的打印数据！"
                    GoTo errProc
                End If
                If strExcelFile Is Nothing Then strExcelFile = ""
                strExcelFile = strExcelFile.Trim
                If strExcelFile = "" Then
                    strErrMsg = "错误：[doPrint_RSBB_RYZJYDB]未指定的Excel文件！"
                    GoTo errProc
                End If
                Dim blnExisted As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strExcelFile, blnExisted) = False Then
                    GoTo errProc
                End If
                If blnExisted = False Then
                    strErrMsg = "错误：[doPrint_RSBB_RYZJYDB]Excel文件[" + strExcelFile + "]不存在！"
                    GoTo errProc
                End If

                '装载Excel
                objExcelFile.LoadXls(strExcelFile)

                '获取模版Sheet参数信息
                Dim objFormatSheet As GemBox.ExcelLite.ExcelWorksheet = Nothing
                Dim intSheetCount As Integer
                intSheetCount = objExcelFile.Worksheets.Count
                If intSheetCount < 2 Then
                    strErrMsg = "错误：[doPrint_RSBB_RYZJYDB][" + strExcelFile + "]文件中至少有[2]个Sheet！"
                    GoTo errProc
                End If
                objFormatSheet = objExcelFile.Worksheets(intSheetCount - 1)  '0,1,...
                If objdacExcel.getSheetParamDataSet(strErrMsg, objFormatSheet, intSheetCount, objParamDataSet) = False Then
                    GoTo errProc
                End If

                '逐个处理数据Sheet
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

                    '获取数据列
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
                        strErrMsg = "错误：[doPrint_RSBB_RYZJYDB]格式Sheet中关于数据Sheet的参数设置不正确！"
                        GoTo errProc
                    End If

                    '解析标题区
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

                    '输出数据区的数据
                    '调整行数
                    If objDataSet.Tables(0).Rows.Count > 3 Then
                        k = objDataSet.Tables(0).Rows.Count
                        objDataSheet.Rows(intTitleRows).InsertCopy(k - 3, objDataSheet.Rows(intTitleRows + 2))
                    Else
                        k = 3
                    End If
                    '合并第1列
                    objDataSheet.Cells.GetSubrange("A" + (intTitleRows + 1).ToString, "A" + (intTitleRows + k).ToString).Merged = True
                    '输出各行数据
                    Dim strValues(2) As String
                    For i = 0 To k - 1 Step 1
                        If i > objDataSet.Tables(0).Rows.Count - 1 Then
                            Exit For
                        End If
                        With objDataSet.Tables(0).Rows(i)
                            If i = 0 Then
                                objDataSheet.Cells(i + intTitleRows, 0).Value = .Item("统计年月")
                            End If
                            '*******************************************************************
                            objDataSheet.Cells(i + intTitleRows, 1).Value = .Item("入职姓名")
                            objDataSheet.Cells(i + intTitleRows, 2).Value = objPulicParameters.getObjectValue(.Item("入职日期"), "", "yyyy-MM-dd")
                            objDataSheet.Cells(i + intTitleRows, 3).Value = .Item("入职部门")
                            objDataSheet.Cells(i + intTitleRows, 4).Value = .Item("入职职级")
                            '*******************************************************************
                            objDataSheet.Cells(i + intTitleRows, 5).Value = .Item("离职姓名")
                            objDataSheet.Cells(i + intTitleRows, 6).Value = .Item("离职解除合同")
                            objDataSheet.Cells(i + intTitleRows, 7).Value = .Item("离职期满终止")
                            objDataSheet.Cells(i + intTitleRows, 8).Value = .Item("离职调出")
                            objDataSheet.Cells(i + intTitleRows, 9).Value = .Item("离职退休")
                            objDataSheet.Cells(i + intTitleRows, 10).Value = .Item("离职死亡")
                            objDataSheet.Cells(i + intTitleRows, 11).Value = .Item("离职其他")
                            objDataSheet.Cells(i + intTitleRows, 12).Value = objPulicParameters.getObjectValue(.Item("离职日期"), "", "yyyy-MM-dd")
                            objDataSheet.Cells(i + intTitleRows, 13).Value = .Item("离职部门")
                            '*******************************************************************
                            objDataSheet.Cells(i + intTitleRows, 14).Value = .Item("实习姓名")
                            objDataSheet.Cells(i + intTitleRows, 15).Value = .Item("实习院校")
                            objDataSheet.Cells(i + intTitleRows, 16).Value = objPulicParameters.getObjectValue(.Item("实习日期"), "", "yyyy-MM-dd")
                            objDataSheet.Cells(i + intTitleRows, 17).Value = .Item("实习部门")
                            '*******************************************************************
                            objDataSheet.Cells(i + intTitleRows, 18).Value = .Item("异动姓名")
                            objDataSheet.Cells(i + intTitleRows, 19).Value = objPulicParameters.getObjectValue(.Item("异动日期"), "", "yyyy-MM-dd")
                            strValues(0) = objPulicParameters.getObjectValue(.Item("异动新部门"), "")
                            strValues(1) = objPulicParameters.getObjectValue(.Item("异动新职级"), "")
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
                            strValues(0) = objPulicParameters.getObjectValue(.Item("异动原部门"), "")
                            strValues(1) = objPulicParameters.getObjectValue(.Item("异动原职级"), "")
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
                            objDataSheet.Cells(i + intTitleRows, 22).Value = .Item("异动转正")
                            '*******************************************************************
                            'objDataSheet.Cells(i + intTitleRows, 23).Value = .Item("异动社保增员")
                            'objDataSheet.Cells(i + intTitleRows, 24).Value = .Item("异动社保减员")
                            'objDataSheet.Cells(i + intTitleRows, 25).Value = .Item("异动开缴公积金")
                            'objDataSheet.Cells(i + intTitleRows, 26).Value = .Item("异动停缴公积金")
                            objDataSheet.Cells(i + intTitleRows, 27).Value = .Item("异动长期产假")
                            'objDataSheet.Cells(i + intTitleRows, 28).Value = .Item("异动培训情况")
                        End With
                    Next
                    '输出汇总
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

                '保存Excel
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
        ' 计算[人力资源信息汇总表]数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     strYJZR                    ：月截止日
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-01-08 创建
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

            '初始化
            getDataSet_BB_RLZYXXHZB = False
            objDataSet = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_BB_RLZYXXHZB]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strKSRQ Is Nothing Then strKSRQ = ""
                strKSRQ = strKSRQ.Trim
                If objPulicParameters.isDatetimeString(strKSRQ) = False Then
                    strErrMsg = "错误：[getDataSet_BB_RLZYXXHZB]指定的[" + strKSRQ + "]无效！"
                    GoTo errProc
                End If
                If strZZRQ Is Nothing Then strZZRQ = ""
                strZZRQ = strZZRQ.Trim
                If objPulicParameters.isDatetimeString(strZZRQ) = False Then
                    strErrMsg = "错误：[getDataSet_BB_RLZYXXHZB]指定的[" + strZZRQ + "]无效！"
                    GoTo errProc
                End If
                If strYJZR Is Nothing Then strYJZR = ""
                strYJZR = strYJZR.Trim
                If strYJZR = "" Then
                    strErrMsg = "错误：[getDataSet_BB_RLZYXXHZB]没有指定[月截止日]！"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(strYJZR) = False Then
                    strErrMsg = "错误：[getDataSet_BB_RLZYXXHZB]指定的[" + strYJZR + "]无效！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempDataSet = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_VT_RLZYXXHZB)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        strSQL = ""
                        strSQL = strSQL + " select a.* from dbo.uf_rs_getRLZYXXHZB(@ksrq, @zzrq, @yjzr) a order by a.单位序号,a.单位名称" + vbCr
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@ksrq", strKSRQ)
                        objSqlCommand.Parameters.AddWithValue("@zzrq", strZZRQ)
                        objSqlCommand.Parameters.AddWithValue("@yjzr", CType(strYJZR, Integer))
                        .SelectCommand = objSqlCommand
                        .Fill(objTempDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_VT_RLZYXXHZB))
                    End With
                    '检查
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

            '返回
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
        ' 计算[广州兴业_人事管理_越秀集团在岗人员及其他数据统计表]的数据
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strJZRQ                ：统计截止日期
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strMacroName           ：宏名列表
        '     strMacroValue          ：宏值列表
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2009-01-09 创建
        '     zengxianglin 2009-05-14 创建
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "错误：[doPrint_RSBB_YXJTZGRYJQTSJTJB]未指定的[连接用户]！"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strExcelFile Is Nothing Then strExcelFile = ""
                strExcelFile = strExcelFile.Trim
                If strExcelFile = "" Then
                    strErrMsg = "错误：[doPrint_RSBB_YXJTZGRYJQTSJTJB]未指定的Excel文件！"
                    GoTo errProc
                End If
                Dim blnExisted As Boolean
                If objBaseLocalFile.doFileExisted(strErrMsg, strExcelFile, blnExisted) = False Then
                    GoTo errProc
                End If
                If blnExisted = False Then
                    strErrMsg = "错误：[doPrint_RSBB_YXJTZGRYJQTSJTJB]Excel文件[" + strExcelFile + "]不存在！"
                    GoTo errProc
                End If
                If strJZRQ Is Nothing Then strJZRQ = ""
                strJZRQ = strJZRQ.Trim
                If objPulicParameters.isDatetimeString(strJZRQ) = False Then
                    strErrMsg = "错误：[doPrint_RSBB_YXJTZGRYJQTSJTJB]输入的[" + strJZRQ + "]是无效的日期！"
                    GoTo errProc
                End If
                strJZRQ = CType(strJZRQ, System.DateTime).ToString("yyyy-MM-dd")
                Dim objJZRQ As System.DateTime = CType(strJZRQ, System.DateTime)
                Dim strNCRQ As String = objJZRQ.Year.ToString + "-01-01"
                Dim strNMRQ As String = objJZRQ.Year.ToString + "-12-31"
                strNMRQ = strJZRQ

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '装载Excel
                objExcelFile.LoadXls(strExcelFile)

                '获取模版Sheet参数信息
                Dim objFormatSheet As GemBox.ExcelLite.ExcelWorksheet = Nothing
                Dim intSheetCount As Integer
                intSheetCount = objExcelFile.Worksheets.Count
                If intSheetCount < 2 Then
                    strErrMsg = "错误：[doPrint_RSBB_YXJTZGRYJQTSJTJB][" + strExcelFile + "]文件中至少有[2]个Sheet！"
                    GoTo errProc
                End If
                objFormatSheet = objExcelFile.Worksheets(intSheetCount - 1)  '0,1,...
                If objdacExcel.getSheetParamDataSet(strErrMsg, objFormatSheet, intSheetCount, objParamDataSet) = False Then
                    GoTo errProc
                End If

                '逐个处理数据Sheet
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

                    '获取数据列
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
                        strErrMsg = "错误：[doPrint_RSBB_YXJTZGRYJQTSJTJB]格式Sheet中关于数据Sheet的参数设置不正确！"
                        GoTo errProc
                    End If

                    '解析标题区
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

                    '计算数据区的数据
                    Dim strYXRYSql As String = ""
                    Dim dblZRS As Double = 0
                    Dim dblValue As Double

                    '计算报表数据
                    For k = 0 To 1 Step 1
                        'k=0：[  管理人员]
                        'k=1：[非管理人员]
                        For j = 0 To 16 Step 1
                            If k = 0 Then
                                i = intTitleRows + 1 + j
                            Else
                                i = intTitleRows + 1 + 17 + 1 + j
                            End If

                            Select Case j
                                Case 0 '[年龄：30岁以下]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 出生日期 is not null"
                                    strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,出生日期,'" + strJZRQ + "'))+1 <= 30"
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                                Case 1 '[年龄：31岁至35岁]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 出生日期 is not null"
                                    strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,出生日期,'" + strJZRQ + "'))+1 between 31 and 35"
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                                Case 2 '[年龄：36岁至40岁]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 出生日期 is not null"
                                    strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,出生日期,'" + strJZRQ + "'))+1 between 36 and 40"
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                                Case 3 '[年龄：41岁至45岁]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 出生日期 is not null"
                                    strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,出生日期,'" + strJZRQ + "'))+1 between 41 and 45"
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                                Case 4 '[年龄：46岁至50岁]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 出生日期 is not null"
                                    strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,出生日期,'" + strJZRQ + "'))+1 between 46 and 50"
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                                Case 5 '[年龄：51岁至54岁]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 出生日期 is not null"
                                    strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,出生日期,'" + strJZRQ + "'))+1 between 51 and 54"
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                                Case 6 '[年龄：55岁及以上]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 出生日期 is not null"
                                    strSQL = strSQL + vbCr + "     and   abs(datediff(yyyy,出生日期,'" + strJZRQ + "'))+1 >= 55"
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL

                                Case 7 '[学历：博士研究生]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 最高学历 = '008'"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   毕业时间 is not null"
                                    'strSQL = strSQL + vbCr + "     and   毕业时间 < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                                Case 8 '[学历：硕士研究生]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 最高学历 = '007'"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   毕业时间 is not null"
                                    'strSQL = strSQL + vbCr + "     and   毕业时间 < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                                Case 9 '[学历：大学本科]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 最高学历 = '006'"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   毕业时间 is not null"
                                    'strSQL = strSQL + vbCr + "     and   毕业时间 < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                                Case 10 '[学历：大学专科]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 最高学历 = '005'"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   毕业时间 is not null"
                                    'strSQL = strSQL + vbCr + "     and   毕业时间 < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                                Case 11 '[学历：中专]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 最高学历 = '004'"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   毕业时间 is not null"
                                    'strSQL = strSQL + vbCr + "     and   毕业时间 < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                                Case 12 '[学历：高中及以下]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 最高学历 not in ('004','005','006','007','008')"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   毕业时间 is not null"
                                    'strSQL = strSQL + vbCr + "     and   毕业时间 < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL

                                Case 13 '[职称：高级]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 技术职称 in ('001.001','001.002','002.001','002.002','002.003','003.001','004.001','005.001')"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   职称取得时间 is not null"
                                    'strSQL = strSQL + vbCr + "     and   职称取得时间 < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                                Case 14 '[职称：其中:正高]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 技术职称 in ('001.001','002.001')"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   职称取得时间 is not null"
                                    'strSQL = strSQL + vbCr + "     and   职称取得时间 < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                                Case 15 '[职称：中级]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 技术职称 in ('001.003','002.004','003.002','004.002','005.002')"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   职称取得时间 is not null"
                                    'strSQL = strSQL + vbCr + "     and   职称取得时间 < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                                Case 16 '[职称：初级]
                                    strSQL = ""
                                    strSQL = strSQL + vbCr + "   select a.人员代码"
                                    strSQL = strSQL + vbCr + "   from"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事异动"
                                    If k = 0 Then
                                        strSQL = strSQL + vbCr + "     where   级别标志 in (1,2)"     '管理人员
                                    Else
                                        strSQL = strSQL + vbCr + "     where   级别标志 not in (1,2)" '非管理人员
                                    End If
                                    strSQL = strSQL + vbCr + "     and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                    strSQL = strSQL + vbCr + "     or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                    strSQL = strSQL + vbCr + "     group by 人员代码"
                                    strSQL = strSQL + vbCr + "   ) a"
                                    strSQL = strSQL + vbCr + "   left join"
                                    strSQL = strSQL + vbCr + "   ("
                                    strSQL = strSQL + vbCr + "     select 人员代码"
                                    strSQL = strSQL + vbCr + "     from 人事_B_人事卡片"
                                    strSQL = strSQL + vbCr + "     where 技术职称 in ('001.004','002.005','003.003','004.003','005.003')"
                                    'zengxianglin 2009-05-14
                                    'strSQL = strSQL + vbCr + "     and   职称取得时间 is not null"
                                    'strSQL = strSQL + vbCr + "     and   职称取得时间 < '" + strJZRQ + "'"
                                    'zengxianglin 2009-05-14
                                    strSQL = strSQL + vbCr + "   ) b on a.人员代码=b.人员代码"
                                    strSQL = strSQL + vbCr + "   where b.人员代码 is not null"
                                    strYXRYSql = strSQL
                            End Select

                            '*******************************************************************************
                            '计算[现有在岗人数]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select 人员代码"
                            strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                            strSQL = strSQL + vbCr + "   where   岗位属性 = 1" '在岗
                            strSQL = strSQL + vbCr + "   and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                            strSQL = strSQL + vbCr + "   or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                            strSQL = strSQL + vbCr + "   group by 人员代码"
                            strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                            strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 4).Value = dblValue
                            '计算[现有在岗人数][高层]
                            If k = 0 Then
                                strSQL = ""
                                strSQL = strSQL + vbCr + " select count(*)"
                                strSQL = strSQL + vbCr + " from"
                                strSQL = strSQL + vbCr + " ("
                                strSQL = strSQL + vbCr + strYXRYSql
                                strSQL = strSQL + vbCr + " ) a"
                                strSQL = strSQL + vbCr + " left join"
                                strSQL = strSQL + vbCr + " ("
                                strSQL = strSQL + vbCr + "   select 人员代码"
                                strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                                strSQL = strSQL + vbCr + "   where   岗位属性 = 1" '在岗
                                strSQL = strSQL + vbCr + "   and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                strSQL = strSQL + vbCr + "   or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "   and     级别标志 = 2" '高层
                                strSQL = strSQL + vbCr + "   group by 人员代码"
                                strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                                strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                                If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                    GoTo errProc
                                End If
                                objDataSheet.Cells(i, 5).Value = dblValue
                            End If
                            '计算[现有在岗人数][中层]
                            If k = 0 Then
                                strSQL = ""
                                strSQL = strSQL + vbCr + " select count(*)"
                                strSQL = strSQL + vbCr + " from"
                                strSQL = strSQL + vbCr + " ("
                                strSQL = strSQL + vbCr + strYXRYSql
                                strSQL = strSQL + vbCr + " ) a"
                                strSQL = strSQL + vbCr + " left join"
                                strSQL = strSQL + vbCr + " ("
                                strSQL = strSQL + vbCr + "   select 人员代码"
                                strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                                strSQL = strSQL + vbCr + "   where   岗位属性 = 1" '在岗
                                strSQL = strSQL + vbCr + "   and   ((开始时间 <= '" + strJZRQ + "' and 终止时间 is null)"
                                strSQL = strSQL + vbCr + "   or     (开始时间 <= '" + strJZRQ + "' and 终止时间 > '" + strJZRQ + "'))"
                                strSQL = strSQL + vbCr + "   and     级别标志 = 1" '中层
                                strSQL = strSQL + vbCr + "   group by 人员代码"
                                strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                                strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                                If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                    GoTo errProc
                                End If
                                objDataSheet.Cells(i, 6).Value = dblValue
                            End If

                            '*******************************************************************************
                            '计算[今年新增数][调入]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select 人员代码"
                            strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                            strSQL = strSQL + vbCr + "   where  变动原因 = '001.001'" '调入
                            strSQL = strSQL + vbCr + "   and    开始时间 between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by 人员代码"
                            strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                            strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 8).Value = dblValue
                            '计算[今年新增数][招聘]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select 人员代码"
                            strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                            strSQL = strSQL + vbCr + "   where  变动原因 = '001.002'" '招聘
                            strSQL = strSQL + vbCr + "   and    开始时间 between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by 人员代码"
                            strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                            strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 9).Value = dblValue
                            '计算[今年新增数][其他]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select 人员代码"
                            strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                            strSQL = strSQL + vbCr + "   where  变动原因 like '001%'"                  '人员增加
                            strSQL = strSQL + vbCr + "   and    变动原因 not in ('001.001','001.002')" '其他
                            strSQL = strSQL + vbCr + "   and    开始时间 between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by 人员代码"
                            strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                            strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 10).Value = dblValue

                            '*******************************************************************************
                            '计算[今年减少人数][调出]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select 人员代码"
                            strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                            strSQL = strSQL + vbCr + "   where  变动原因 = '002.006'" '调出
                            strSQL = strSQL + vbCr + "   and    开始时间 between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by 人员代码"
                            strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                            strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 12).Value = dblValue
                            '计算[今年减少人数][退休]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select 人员代码"
                            strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                            strSQL = strSQL + vbCr + "   where  变动原因 = '002.007'" '退休
                            strSQL = strSQL + vbCr + "   and    开始时间 between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by 人员代码"
                            strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                            strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 13).Value = dblValue
                            '计算[今年减少人数][辞职]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select 人员代码"
                            strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                            strSQL = strSQL + vbCr + "   where  变动原因 = '002.009'" '辞职
                            strSQL = strSQL + vbCr + "   and    开始时间 between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by 人员代码"
                            strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                            strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 14).Value = dblValue
                            '计算[今年减少人数][辞退]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select 人员代码"
                            strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                            strSQL = strSQL + vbCr + "   where  变动原因 = '002.005'" '辞退
                            strSQL = strSQL + vbCr + "   and    开始时间 between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by 人员代码"
                            strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                            strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 15).Value = dblValue
                            '计算[今年减少人数][死亡]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select 人员代码"
                            strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                            strSQL = strSQL + vbCr + "   where  变动原因 = '002.012'" '死亡
                            strSQL = strSQL + vbCr + "   and    开始时间 between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by 人员代码"
                            strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                            strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 16).Value = dblValue
                            '计算[今年减少人数][其他]
                            strSQL = ""
                            strSQL = strSQL + vbCr + " select count(*)"
                            strSQL = strSQL + vbCr + " from"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + strYXRYSql
                            strSQL = strSQL + vbCr + " ) a"
                            strSQL = strSQL + vbCr + " left join"
                            strSQL = strSQL + vbCr + " ("
                            strSQL = strSQL + vbCr + "   select 人员代码"
                            strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                            strSQL = strSQL + vbCr + "   where  变动原因 like '002%'" '减少
                            strSQL = strSQL + vbCr + "   and    变动原因 not in ('002.005','002.006','002.007','002.009','002.012')" '其他
                            strSQL = strSQL + vbCr + "   and    开始时间 between '" + strNCRQ + "' and '" + strNMRQ + "'"
                            strSQL = strSQL + vbCr + "   group by 人员代码"
                            strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                            strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                            If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                                GoTo errProc
                            End If
                            objDataSheet.Cells(i, 17).Value = dblValue
                        Next
                    Next

                    '*******************************************************************************
                    '计算[年初在岗总数]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where  岗位属性 = 1" '在岗
                    strSQL = strSQL + vbCr + "   and  ((终止时间 is     null and 开始时间 <= '" + strNCRQ + "')"
                    strSQL = strSQL + vbCr + "   or    (终止时间 is not null and '" + strNCRQ + "' between 开始时间 and 终止时间))"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(8, 2).Value = dblValue

                    '*******************************************************************************
                    '计算[在职市管干部]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where  岗位属性 = 1"   '在岗
                    strSQL = strSQL + vbCr + "   and  ((终止时间 is     null and 开始时间 <= '" + strJZRQ + "')"
                    strSQL = strSQL + vbCr + "   or    (终止时间 is not null and '" + strJZRQ + "' between 开始时间 and 终止时间))"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from 人事_B_人事卡片"
                    strSQL = strSQL + vbCr + "   where 是否市管干部 = 1" '市管干部
                    strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                    strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(28, 20).Value = dblValue

                    '*******************************************************************************
                    '计算[离休市管干部]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where  变动原因 = '002.008'" '离休
                    strSQL = strSQL + vbCr + "   and  开始时间 <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from 人事_B_人事卡片"
                    strSQL = strSQL + vbCr + "   where 是否市管干部 = 1" '市管干部
                    strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                    strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(29, 20).Value = dblValue
                    '计算[离休其他]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where  变动原因 = '002.008'" '离休
                    strSQL = strSQL + vbCr + "   and  开始时间 <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from 人事_B_人事卡片"
                    strSQL = strSQL + vbCr + "   where 是否市管干部 = 1" '市管干部
                    strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                    strSQL = strSQL + vbCr + " where b.人员代码 is null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(30, 20).Value = dblValue

                    '*******************************************************************************
                    '计算[退休市管干部]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where  变动原因 = '002.007'" '退休
                    strSQL = strSQL + vbCr + "   and  开始时间 <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from 人事_B_人事卡片"
                    strSQL = strSQL + vbCr + "   where 是否市管干部 = 1" '市管干部
                    strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                    strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(31, 20).Value = dblValue
                    '计算[退休其他]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where  变动原因 = '002.007'" '退休
                    strSQL = strSQL + vbCr + "   and  开始时间 <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from 人事_B_人事卡片"
                    strSQL = strSQL + vbCr + "   where 是否市管干部 = 1" '市管干部
                    strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                    strSQL = strSQL + vbCr + " where b.人员代码 is null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(32, 20).Value = dblValue

                    '*******************************************************************************
                    '计算[离岗退养]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where  变动原因 = '002.010'" '离岗退养
                    strSQL = strSQL + vbCr + "   and  开始时间 <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(33, 20).Value = dblValue

                    '*******************************************************************************
                    '计算[中共党员]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where 开始时间 <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from 人事_B_人事卡片"
                    strSQL = strSQL + vbCr + "   where 政治面貌 = '001'" '中共党员
                    strSQL = strSQL + vbCr + "   and   入党时间 is not null"
                    strSQL = strSQL + vbCr + "   and   入党时间 < '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                    strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(34, 20).Value = dblValue
                    '计算[中共党员][其中:在岗党员]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where  岗位属性 = 1"   '在岗
                    strSQL = strSQL + vbCr + "   and  ((终止时间 is     null and 开始时间 <= '" + strJZRQ + "')"
                    strSQL = strSQL + vbCr + "   or    (终止时间 is not null and '" + strJZRQ + "' between 开始时间 and 终止时间))"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from 人事_B_人事卡片"
                    strSQL = strSQL + vbCr + "   where 政治面貌 = '001'" '中共党员
                    strSQL = strSQL + vbCr + "   and   入党时间 is not null"
                    strSQL = strSQL + vbCr + "   and   入党时间 < '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                    strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(35, 20).Value = dblValue

                    '*******************************************************************************
                    '计算[共青团员]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where 开始时间 <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from 人事_B_人事卡片"
                    strSQL = strSQL + vbCr + "   where 政治面貌 = '002'" '共青团员
                    strSQL = strSQL + vbCr + "   and   入党时间 is not null"
                    strSQL = strSQL + vbCr + "   and   入党时间 < '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                    strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(37, 20).Value = dblValue

                    '*******************************************************************************
                    '计算[民主党派]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where 开始时间 <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from 人事_B_人事卡片"
                    strSQL = strSQL + vbCr + "   where 政治面貌 = '003'" '民主党派
                    strSQL = strSQL + vbCr + "   and   入党时间 is not null"
                    strSQL = strSQL + vbCr + "   and   入党时间 < '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                    strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(38, 20).Value = dblValue

                    '*******************************************************************************
                    '计算[少数民族]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where 开始时间 <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from 人事_B_人事卡片"
                    strSQL = strSQL + vbCr + "   where 民族 <> ''"
                    strSQL = strSQL + vbCr + "   and   民族 not like '%汉%'"
                    strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                    strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(39, 20).Value = dblValue

                    '*******************************************************************************
                    '计算[归侨]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where 开始时间 <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from 人事_B_人事卡片"
                    strSQL = strSQL + vbCr + "   where 人员区域特性 = 1" '归侨
                    strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                    strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(41, 20).Value = dblValue

                    '*******************************************************************************
                    '计算[军转干部]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where 开始时间 <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from 人事_B_人事卡片"
                    strSQL = strSQL + vbCr + "   where 是否军转干部 = 1" '军转干部
                    strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                    strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(42, 20).Value = dblValue

                    '*******************************************************************************
                    '计算[退伍军人]
                    strSQL = ""
                    strSQL = strSQL + vbCr + " select count(*)"
                    strSQL = strSQL + vbCr + " from"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select 人员代码"
                    strSQL = strSQL + vbCr + "   from 人事_B_人事异动"
                    strSQL = strSQL + vbCr + "   where 开始时间 <= '" + strJZRQ + "'"
                    strSQL = strSQL + vbCr + "   group by 人员代码"
                    strSQL = strSQL + vbCr + " ) a"
                    strSQL = strSQL + vbCr + " left join"
                    strSQL = strSQL + vbCr + " ("
                    strSQL = strSQL + vbCr + "   select * from 人事_B_人事卡片"
                    strSQL = strSQL + vbCr + "   where 个人服役状态 <> 0" '退伍军人
                    strSQL = strSQL + vbCr + " ) b on a.人员代码=b.人员代码"
                    strSQL = strSQL + vbCr + " where b.人员代码 is not null"
                    If objdacCommon.getValueBySQL(strErrMsg, objSqlConnection, strSQL, dblValue) = False Then
                        GoTo errProc
                    End If
                    objDataSheet.Cells(43, 20).Value = dblValue
                Next

                '保存Excel
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
        ' 计算[劳动合同届满期限表]数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-01-12 创建
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

            '初始化
            getDataSet_BB_LDHTJMQXB = False
            objDataSet = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_BB_LDHTJMQXB]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strKSRQ Is Nothing Then strKSRQ = ""
                strKSRQ = strKSRQ.Trim
                If objPulicParameters.isDatetimeString(strKSRQ) = False Then
                    strErrMsg = "错误：[getDataSet_BB_LDHTJMQXB]指定的[" + strKSRQ + "]无效！"
                    GoTo errProc
                End If
                If strZZRQ Is Nothing Then strZZRQ = ""
                strZZRQ = strZZRQ.Trim
                If objPulicParameters.isDatetimeString(strZZRQ) = False Then
                    strErrMsg = "错误：[getDataSet_BB_LDHTJMQXB]指定的[" + strZZRQ + "]无效！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempDataSet = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_VT_LDHTJMQXB)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        strSQL = ""
                        strSQL = strSQL + " select a.* from dbo.uf_rs_getLDHTJMQXB(@ksrq, @zzrq) a order by a.记录序号" + vbCr
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@ksrq", strKSRQ)
                        objSqlCommand.Parameters.AddWithValue("@zzrq", strZZRQ)
                        .SelectCommand = objSqlCommand
                        .Fill(objTempDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_VT_LDHTJMQXB))
                    End With
                    '检查
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

            '返回
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
        ' 计算[劳动局季报表]数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strTJND                    ：统计年度
        '     strTJJD                    ：统计季度
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-01-12 创建
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

            '初始化
            getDataSet_BB_LDJJBB = False
            objDataSet = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_BB_LDJJBB]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strTJND Is Nothing Then strTJND = ""
                strTJND = strTJND.Trim
                If objPulicParameters.isIntegerString(strTJND) = False Then
                    strErrMsg = "错误：[getDataSet_BB_LDJJBB]指定的[" + strTJND + "]无效！"
                    GoTo errProc
                End If
                Dim intTJND As Integer = CType(strTJND, Integer)
                If intTJND <= 0 Or intTJND > 9999 Then
                    strErrMsg = "错误：[getDataSet_BB_LDJJBB]指定的[" + strTJND + "]无效！"
                    GoTo errProc
                End If
                If strTJJD Is Nothing Then strTJJD = ""
                strTJJD = strTJJD.Trim
                If objPulicParameters.isIntegerString(strTJJD) = False Then
                    strErrMsg = "错误：[getDataSet_BB_LDJJBB]指定的[" + strTJJD + "]无效！"
                    GoTo errProc
                End If
                Dim intTJJD As Integer = CType(strTJJD, Integer)
                Select Case intTJJD
                    Case 1, 2, 3, 4
                    Case Else
                        strErrMsg = "错误：[getDataSet_BB_LDJJBB]指定的[" + strTJJD + "]无效！"
                        GoTo errProc
                End Select

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempDataSet = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_VT_LDJJBB)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        strSQL = ""
                        strSQL = strSQL + " select a.* from dbo.uf_rs_getLDJJBB(@tjnd, @tjjd) a order by a.记录序号" + vbCr
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@tjnd", intTJND)
                        objSqlCommand.Parameters.AddWithValue("@tjjd", intTJJD)
                        .SelectCommand = objSqlCommand
                        .Fill(objTempDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_VT_LDJJBB))
                    End With
                    '检查
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

            '返回
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
        ' 计算[劳动局年报表]数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strTJND                    ：统计年度
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-01-12 创建
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

            '初始化
            getDataSet_BB_LDJNBB = False
            objDataSet = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_BB_LDJNBB]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strTJND Is Nothing Then strTJND = ""
                strTJND = strTJND.Trim
                If objPulicParameters.isIntegerString(strTJND) = False Then
                    strErrMsg = "错误：[getDataSet_BB_LDJNBB]指定的[" + strTJND + "]无效！"
                    GoTo errProc
                End If
                Dim intTJND As Integer = CType(strTJND, Integer)
                If intTJND <= 0 Or intTJND > 9999 Then
                    strErrMsg = "错误：[getDataSet_BB_LDJNBB]指定的[" + strTJND + "]无效！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempDataSet = New Josco.JSOA.Common.Data.estateRenshiGeneralData(Josco.JSOA.Common.Data.estateRenshiGeneralData.enumTableType.RS_VT_LDJNBB)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        strSQL = ""
                        strSQL = strSQL + " select a.* from dbo.uf_rs_getLDJNBB(@tjnd) a order by a.记录序号" + vbCr
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@tjnd", intTJND)
                        .SelectCommand = objSqlCommand
                        .Fill(objTempDataSet.Tables(Josco.JSOA.Common.Data.estateRenshiGeneralData.TABLE_RS_VT_LDJNBB))
                    End With
                    '检查
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

            '返回
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
        ' 录用[地产_B_人事_个人履历]指定[简历编号]对应的人员
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strJLBH                ：[地产_B_人事_个人履历][简历编号]
        '     objServer              ：服务器对象
        '     strAppRoot             ：应用根WEB路径(不带/)
        '     strBasePath            ：应用根到存放地的相对HTTP目录(开头不带/)
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改记录
        '     zengxianglin 2009-05-15 创建
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
                '检查
                If strJLBH Is Nothing Then strJLBH = ""
                strJLBH = strJLBH.Trim
                If strJLBH = "" Then
                    Exit Try
                End If
                If strUserId Is Nothing Then strUserId = ""
                strUserId = strUserId.Trim
                If strUserId = "" Then
                    strErrMsg = "错误：未传入连接用户！"
                    GoTo errProc
                End If
                If objServer Is Nothing Then
                    strErrMsg = "错误：没有指定[System.Web.HttpServerUtility]！"
                    GoTo errProc
                End If
                If strPassword Is Nothing Then strPassword = ""
                strPassword = strPassword.Trim
                If strAppRoot Is Nothing Then strAppRoot = ""
                strAppRoot = strAppRoot.Trim
                If strBasePath Is Nothing Then strBasePath = strBasePath.Trim
                strBasePath = strBasePath.Trim

                '获取连接事务
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '计算人员信息
                strSQL = "select * from 地产_B_人事_个人履历 where 简历编号 = '" + strJLBH + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables.Count < 1 Then
                    strErrMsg = "错误：无法计算[" + strJLBH + "][个人履历]信息"
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count < 1 Then
                    strErrMsg = "错误：无法计算[" + strJLBH + "][个人履历]信息"
                    GoTo errProc
                End If
                Dim strRYXP As String = ""
                Dim strRYDM As String = ""
                Dim strBMDM As String = ""
                Dim strRYXM As String = ""
                With objDataSet.Tables(0).Rows(0)
                    strRYDM = objPulicParameters.getObjectValue(.Item("人员代码"), "")
                    strRYXM = objPulicParameters.getObjectValue(.Item("姓名"), "")
                    strBMDM = objPulicParameters.getObjectValue(.Item("拟用部门"), "")
                    strRYXP = objPulicParameters.getObjectValue(.Item("人员相片"), "")
                End With
                If strBMDM = "" Or strRYDM = "" Or strRYXM = "" Then
                    strErrMsg = "错误：[]没有给出[拟用部门]、[人员代码]、[姓名]！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '检查[人员代码]
                '========================================================================================================
                strSQL = "select * from 人事_B_人事卡片 where 人员代码 = '" + strRYDM + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables.Count < 1 Then
                    strErrMsg = "错误：无法检查[" + strRYDM + "]的唯一性!"
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strRYDM + "]在[人事资料]中已经存在!"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                '========================================================================================================
                strSQL = "select * from 公共_B_人员 where 人员代码 = '" + strRYDM + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables.Count < 1 Then
                    strErrMsg = "错误：无法检查[" + strRYDM + "]的唯一性!"
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strRYDM + "]在[单位人员]中已经存在!"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                '========================================================================================================
                strSQL = "select * from 公共_B_人员 where 人员名称 = '" + strRYXM + "'"
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables.Count < 1 Then
                    strErrMsg = "错误：无法检查[" + strRYXM + "]的唯一性!"
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strRYXM + "]在[单位人员]中已经存在!"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)

                '计算新的[人员序号]
                Dim strRYXH As String = ""
                If objdacCustomer.getNewRYXH(strErrMsg, strUserId, strPassword, strBMDM, strRYXH) = False Then
                    GoTo errProc
                End If

                '获取GUID
                Dim strWYBS As String = ""
                If objdacCommon.getNewGUID(strErrMsg, objSqlConnection, strWYBS) = False Then
                    GoTo errProc
                End If

                '复制[人员相片]到临时文件中
                If strRYXP <> "" Then
                    If objServer Is Nothing Or strAppRoot = "" Or strBasePath = "" Then
                        strErrMsg = "错误：没有指定有关目录参数！"
                        GoTo errProc
                    End If
                End If

                '保存文件到目标目录
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

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction
                objSqlCommand.Transaction = objSqlTransaction

                '执行事务
                Try
                    '形成“人事_B_人事卡片”记录
                    strSQL = ""
                    strSQL = strSQL + " insert into 人事_B_人事卡片 (" + vbCr
                    strSQL = strSQL + "   唯一标识,人员代码,姓名,性别,出生日期,入本单位时间," + vbCr
                    strSQL = strSQL + "   英文姓名,手机号码,住宅电话,身份证号," + vbCr
                    strSQL = strSQL + "   民族,籍贯,户籍地址,现住地址,人员相片位置," + vbCr
                    strSQL = strSQL + "   婚姻状况,生育情况," + vbCr
                    strSQL = strSQL + "   最高学历,最高学位,毕业院校,毕业专业,毕业时间," + vbCr
                    strSQL = strSQL + "   技术职称,职称取得时间," + vbCr
                    strSQL = strSQL + "   执业资格," + vbCr
                    strSQL = strSQL + "   政治面貌,入党时间" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   唯一标识=@wybs,人员代码,姓名,性别,出生日期,入本单位时间=getdate()," + vbCr
                    strSQL = strSQL + "   英文姓名,手机号码,住宅电话,身份证号," + vbCr
                    strSQL = strSQL + "   民族,籍贯,户籍地址,现住地址,人员相片位置=@ryxpwz," + vbCr
                    strSQL = strSQL + "   婚姻状况,生育情况," + vbCr
                    strSQL = strSQL + "   最高学历,最高学位,毕业院校,毕业专业,毕业时间," + vbCr
                    strSQL = strSQL + "   技术职称,职称取得时间," + vbCr
                    strSQL = strSQL + "   执业资格," + vbCr
                    strSQL = strSQL + "   政治面貌,入党时间" + vbCr
                    strSQL = strSQL + " from 地产_B_人事_个人履历" + vbCr
                    strSQL = strSQL + " where 人员代码 = @rydm" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    objSqlCommand.Parameters.AddWithValue("@ryxpwz", strFileName)
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.ExecuteNonQuery()

                    '形成“人事_B_学习经历”记录
                    strSQL = ""
                    strSQL = strSQL + " insert into 人事_B_学习经历 (" + vbCr
                    strSQL = strSQL + "   唯一标识,人员代码," + vbCr
                    strSQL = strSQL + "   开始年月,终止年月,学习类型,学习院校,学习专业,学习结果," + vbCr
                    strSQL = strSQL + "   备注信息" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select " + vbCr
                    strSQL = strSQL + "   唯一标识=newid(),人员代码," + vbCr
                    strSQL = strSQL + "   开始年月,终止年月,学习类型,学习院校,学习专业,学习结果," + vbCr
                    strSQL = strSQL + "   备注信息" + vbCr
                    strSQL = strSQL + " from 地产_B_人事_学习经历" + vbCr
                    strSQL = strSQL + " where 人员代码 = @rydm" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.ExecuteNonQuery()

                    '形成“人事_B_工作经历”记录
                    strSQL = ""
                    strSQL = strSQL + " insert into 人事_B_工作经历 (" + vbCr
                    strSQL = strSQL + "   唯一标识,人员代码," + vbCr
                    strSQL = strSQL + "   开始年月,终止年月,服务单位,担任职务," + vbCr
                    strSQL = strSQL + "   备注信息" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select " + vbCr
                    strSQL = strSQL + "   唯一标识=newid(),人员代码," + vbCr
                    strSQL = strSQL + "   开始年月,终止年月,服务单位,担任职务," + vbCr
                    strSQL = strSQL + "   备注信息" + vbCr
                    strSQL = strSQL + " from 地产_B_人事_工作经历" + vbCr
                    strSQL = strSQL + " where 人员代码 = @rydm" + vbCr
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.ExecuteNonQuery()

                    '写[公共_B_人员]
                    strSQL = ""
                    strSQL = strSQL + " insert into 公共_B_人员 (" + vbCr
                    strSQL = strSQL + "   人员代码,人员名称,人员真名,人员序号,组织代码" + vbCr
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

                '提交事务
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
            '删除上载文件
            Dim strErrMsgA As String
            If strDesFile <> "" Then
                If objBaseLocalFile.doDeleteFile(strErrMsgA, strDesFile) = False Then
                    '忽略
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
