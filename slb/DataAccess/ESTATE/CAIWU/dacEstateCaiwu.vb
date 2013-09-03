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
    ' 类名    ：dacEstateCaiwu
    '
    ' 功能描述：
    '     提供对财务相关的数据层操作
    ' 更改记录：
    '     zengxianglin 2009-05-17 更改
    '----------------------------------------------------------------

    Public Class dacEstateCaiwu
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
        ' 获取“地产_B_财务_票据使用情况”完全数据的数据集
        ' 以“发给分行”、“票据批号”、“票据号码”升序排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCaiwuData         ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改记录
        '     zengxianglin 2009-05-17 更改
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

            '初始化
            getDataSet_PJSY = False
            objestateCaiwuData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
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
                    objTempestateCaiwuData = New Josco.JSOA.Common.Data.estateCaiwuData(Josco.JSOA.Common.Data.estateCaiwuData.enumTableType.DC_B_CW_PIAOJUSHIYONG)

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
                        strSQL = strSQL + "     发给分行名称 = dbo.uf_gg_getZzmcByZzdm(a.发给分行)," + vbCr
                        strSQL = strSQL + "     发放人员名称 = dbo.uf_gg_getRyzmByRydm(a.发放人员)," + vbCr
                        strSQL = strSQL + "     经办人员名称 = dbo.uf_gg_getRyzmByRydm(a.经办人员)," + vbCr
                        strSQL = strSQL + "     作废人员名称 = dbo.uf_gg_getRyzmByRydm(a.作废人员)," + vbCr
                        'zengxianglin 2008-11-18
                        strSQL = strSQL + "     标记人员名称 = dbo.uf_gg_getRyzmByRydm(a.标记人员)," + vbCr
                        strSQL = strSQL + "     税费名称     = dbo.uf_estate_gg_getSfmc(a.税费代码)," + vbCr
                        'zengxianglin 2008-11-18
                        'zengxianglin 2009-05-17
                        strSQL = strSQL + "     核销人员名称 = dbo.uf_gg_getRyzmByRydm(a.核销人员)," + vbCr
                        strSQL = strSQL + "     核销标志名称 = dbo.uf_estate_cw_getPiaojuHexiaoName(a.核销标志)," + vbCr
                        'zengxianglin 2009-05-17
                        strSQL = strSQL + "     状态标志名称 = dbo.uf_estate_cw_getPiaojuStatusName(a.状态标志)," + vbCr
                        strSQL = strSQL + "     唯一票据号码 = a.票据号码 + '|' + cast(a.票据批号 as varchar(10)) + '|' + a.发给分行," + vbCr
                        strSQL = strSQL + "     交易编号=b.交易编号" + vbCr
                        strSQL = strSQL + "   from 地产_B_财务_票据使用情况 a " + vbCr
                        strSQL = strSQL + "   left join 地产_V_全部交易 b on a.业务标识 = b.唯一标识" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.发给分行,a.票据批号,a.票据号码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 发放票据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strPrefix            ：票据前导符
        '     intMin               ：本批开始号
        '     intMax               ：本批结束号
        '     strPJLX              ：票据类型
        '     strFGFH              ：发给分行的代码
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
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

            '初始化
            doPiaoju_Fafang = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[doPiaoju_Fafang]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strFGFH Is Nothing Then strFGFH = ""
                strFGFH = strFGFH.Trim
                If strFGFH = "" Then
                    strErrMsg = "错误：[doPiaoju_Fafang]未指定[发放分行]！"
                    GoTo errProc
                End If
                If strPrefix Is Nothing Then strPrefix = ""
                strPrefix = strPrefix.Trim
                If strPJLX Is Nothing Then strPJLX = ""
                strPJLX = strPJLX.Trim
                If intMin <= 0 Or intMax <= 0 Then
                    strErrMsg = "错误：[doPiaoju_Fafang]指定无效的[号码区间]！"
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
                    strErrMsg = "错误：[doPiaoju_Fafang]没有指定[批次]！"
                    GoTo errProc
                End If
                If objPulicParameters.isIntegerString(strFFPC) = False Then
                    strErrMsg = "错误：[doPiaoju_Fafang]指定无效的[批次]！"
                    GoTo errProc
                End If
                Dim intFFPC As Integer
                intFFPC = CType(strFFPC, Integer)
                If intFFPC < 0 Then
                    strErrMsg = "错误：[doPiaoju_Fafang]指定无效的[批次]！"
                    GoTo errProc
                End If
                'zengxianglin 2008-11-18

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取新批次
                Dim strNewPC As String = ""
                'zengxianglin 2008-11-18
                'If objdacCommon.getNewCode(strErrMsg, objSqlConnection, "票据批号", "发给分行", strFGFH, "地产_B_财务_票据使用情况", True, strNewPC) = False Then
                '    GoTo errProc
                'End If
                strNewPC = strFFPC
                'zengxianglin 2008-11-18

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '处理
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '逐个发放
                    Dim intZTBZ As Integer = Josco.JSOA.Common.Data.estateCaiwuData.enumPiaojuStatus.Unused
                    Dim intLen As Integer = (intMax.ToString).Length
                    Dim i As Integer = 0
                    For i = intMin To intMax Step 1
                        strSQL = ""
                        strSQL = strSQL + " insert into 地产_B_财务_票据使用情况 (" + vbCr
                        strSQL = strSQL + "   唯一标识,票据批号,票据号码,发给分行,票据类型,状态标志,发放人员,发放日期" + vbCr
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
        ' 标记票据的使用情况
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：要标记的票据的“唯一标识”
        '     objenumPiaojuStatus  ：标记类型
        '     objParams            ：额外参数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doPiaoju_Mark = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[doPiaoju_Mark]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim
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

                '处理
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
                            strSQL = strSQL + " update 地产_B_财务_票据使用情况 set" + vbCr
                            strSQL = strSQL + "   状态标志 = @ztbz," + vbCr
                            strSQL = strSQL + "   经办人员 = @jbry," + vbCr
                            strSQL = strSQL + "   开票日期 = @kprq," + vbCr
                            'zengxianglin 2008-11-18
                            strSQL = strSQL + "   标记人员 = @bjry," + vbCr
                            strSQL = strSQL + "   标记日期 = @bjrq," + vbCr
                            strSQL = strSQL + "   税费代码 = @sfdm," + vbCr
                            strSQL = strSQL + "   收付对象 = @sfdx," + vbCr
                            strSQL = strSQL + "   收付标志 = @sfbz," + vbCr
                            'zengxianglin 2008-11-18
                            strSQL = strSQL + "   开票金额 = @kpje," + vbCr
                            strSQL = strSQL + "   摘要说明 = @zysm," + vbCr
                            strSQL = strSQL + "   业务标识 = @ywbs " + vbCr
                            strSQL = strSQL + " where 唯一标识 = @wybs" + vbCr
                            strSQL = strSQL + " and   状态标志 = 0" + vbCr           '必须是正常票据
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
                            strSQL = strSQL + " update 地产_B_财务_票据使用情况 set" + vbCr
                            strSQL = strSQL + "   状态标志 = @ztbz," + vbCr
                            strSQL = strSQL + "   作废人员 = @zfry," + vbCr
                            strSQL = strSQL + "   作废日期 = @zfrq " + vbCr
                            strSQL = strSQL + " where 唯一标识 = @wybs" + vbCr
                            strSQL = strSQL + " and   状态标志 = 1" + vbCr           '必须是已用票据
                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.Parameters.Clear()
                            objSqlCommand.Parameters.AddWithValue("@ztbz", CType(objenumPiaojuStatus, Integer))
                            objSqlCommand.Parameters.AddWithValue("@zfry", strUserId)
                            objSqlCommand.Parameters.AddWithValue("@zfrq", Now)
                            objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                            objSqlCommand.ExecuteNonQuery()
                        Case Josco.JSOA.Common.Data.estateCaiwuData.enumPiaojuStatus.Shouhui
                            strSQL = ""
                            strSQL = strSQL + " update 地产_B_财务_票据使用情况 set" + vbCr
                            strSQL = strSQL + "   状态标志 = @ztbz" + vbCr
                            strSQL = strSQL + " where 唯一标识 = @wybs" + vbCr
                            strSQL = strSQL + " and   状态标志 = 0" + vbCr           '必须是正常票据
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
        ' 删除票据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：票据的唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doPiaoju_Delete = False
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
                strWYBS = strWYBS.Trim
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

                    strSQL = ""
                    strSQL = strSQL + " delete from 地产_B_财务_票据使用情况 " + vbCr
                    strSQL = strSQL + " where 唯一标识 = @oldkey" + vbCr
                    strSQL = strSQL + " and   状态标志 in (0,4)" + vbCr     '必须是正常或已收回票据
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldkey", strWYBS)
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
        ' 判断给定的票据号码是否为连续开具？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strFGFH              ：发给分行
        '     strPJPH              ：发放批次
        '     strPJHM              ：票据号码
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strFGFH Is Nothing Then strFGFH = ""
                strFGFH = strFGFH.Trim
                If strPJPH Is Nothing Then strPJPH = ""
                strPJPH = strPJPH.Trim
                If strPJHM Is Nothing Then strPJHM = ""
                strPJHM = strPJHM.Trim
                If strFGFH = "" Or strPJPH = "" Or strPJHM = "" Then
                    strErrMsg = "错误：[发给分行]、[票据批号]、[票据号码]都必须提供！"
                    GoTo errProc
                End If

                '获取数据库连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '计算：号码之前的是否有“未使用”的票据？
                strSQL = ""
                strSQL = strSQL + " select count(*) from 地产_B_财务_票据使用情况" + vbCr
                strSQL = strSQL + " where 发给分行 = '" + strFGFH + "'" + vbCr
                strSQL = strSQL + " and   票据批号 =  " + strPJPH + " " + vbCr
                strSQL = strSQL + " and   票据号码 < '" + strPJHM + "'" + vbCr
                strSQL = strSQL + " and   状态标志 = 0" + vbCr '未使用
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
                If objDataSet.Tables.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Dim intCount As Integer = 0
                        intCount = CType(objDataSet.Tables(0).Rows(0).Item(0), Integer)
                        If intCount < 1 Then
                            '没有，是连续！
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
        ' 根据“确认书号”获取“地产_B_财务_二手应收应付”完全数据的数据集
        ' 以“应收日期”升序排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateCaiwuData         ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_ES_YSYF = False
            objestateCaiwuData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_ES_YSYF]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateCaiwuData = New Josco.JSOA.Common.Data.estateCaiwuData(Josco.JSOA.Common.Data.estateCaiwuData.enumTableType.DC_B_CW_ES_YINGSHOUYINGFU)
                    If strQRSH = "" Then
                        Exit Try
                    End If

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
                        strSQL = strSQL + "     税费名称   = dbo.uf_estate_gg_getSfmc(a.税费代码)," + vbCr
                        strSQL = strSQL + "     实收金额   = b.实收金额," + vbCr
                        strSQL = strSQL + "     应收金额收 = case when a.收付标志 = '收' then a.应收金额 else null end," + vbCr
                        strSQL = strSQL + "     应收金额付 = case when a.收付标志 = '收' then null else a.应收金额 end " + vbCr
                        strSQL = strSQL + "   from" + vbCr
                        strSQL = strSQL + "   (" + vbCr
                        strSQL = strSQL + "     select a.*" + vbCr
                        strSQL = strSQL + "     from 地产_B_财务_二手应收应付 a " + vbCr
                        strSQL = strSQL + "     where a.确认书号 = @qrsh" + vbCr
                        strSQL = strSQL + "   ) a" + vbCr
                        strSQL = strSQL + "   left join" + vbCr
                        strSQL = strSQL + "   (" + vbCr
                        strSQL = strSQL + "     select 确认书号,税费代码,收付对象,收付标志,实收金额=sum(发生金额)" + vbCr
                        strSQL = strSQL + "     from 地产_B_财务_二手实收实付" + vbCr
                        strSQL = strSQL + "     where 确认书号 = @qrsh" + vbCr
                        strSQL = strSQL + "     and   rtrim(isnull(财务审核,'')) <> ''" + vbCr
                        strSQL = strSQL + "     group by 确认书号,税费代码,收付对象,收付标志" + vbCr
                        strSQL = strSQL + "   ) b on a.确认书号=b.确认书号 and a.税费代码=b.税费代码 and a.收付对象=b.收付对象 and a.收付标志=b.收付标志" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.应收日期" + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@qrsh", strQRSH)
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“地产_B_财务_二手应收应付”的数据的合法性
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
                strSQL = "select top 0 * from 地产_B_财务_二手应收应付"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "地产_B_财务_二手应收应付", objDataSet) = False Then
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
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFMC, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SSJE, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_S, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_F
                            '计算列
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS
                            '自动列
                            If strValue = "" Then
                                If objdacCommon.getNewGUID(strErrMsg, strUserId, strPassword, strValue) = False Then
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSRQ
                            If strValue = "" Then
                                strErrMsg = "错误：没有输入[" + strField + "]！"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(strValue) = False Then
                                strErrMsg = "错误：[" + strValue + "]是无效的日期！"
                                GoTo errProc
                            End If
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_KSRQ, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JSRQ
                            If strValue <> "" Then
                                If objPulicParameters.isDatetimeString(strValue) = False Then
                                    strErrMsg = "错误：[" + strValue + "]是无效的日期！"
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFZT, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JZYF
                            If strValue <> "" Then
                                If objPulicParameters.isIntegerString(strValue) = False Then
                                    strErrMsg = "错误：[" + strValue + "]是无效的数字！"
                                    GoTo errProc
                                End If
                            End If
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE
                            If strValue <> "" Then
                                If objPulicParameters.isFloatString(strValue) = False Then
                                    strErrMsg = "错误：[" + strValue + "]是无效的数值！"
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QRSH, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDM, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDX, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFBZ
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
        ' 保存“地产_B_财务_二手应收应付”的数据
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

            '初始化
            doSaveData_ES_YSYF = False
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
                If Me.doVerifyData_ES_YSYF(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                                    Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SSJE, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_S, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_F
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " insert into 地产_B_财务_二手应收应付 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS), "")

                            '计算字段列表、字段值
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
                                        '计算列
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " update 地产_B_财务_二手应收应付 set " + vbCr
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
        ' 删除“地产_B_财务_二手应收应付”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_ES_YSYF = False
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
                    strSQL = strSQL + " delete from 地产_B_财务_二手应收应付 " + vbCr
                    strSQL = strSQL + " where 唯一标识 = @oldkey" + vbCr
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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 根据模板创建“地产_B_财务_二手应收应付”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     strMBDM              ：模版代码
        '     blnClear             ：清除标志
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doMakeYSYF = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
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

                '处理
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '清除一般计划
                    If blnClear = True Then
                        strSQL = ""
                        strSQL = strSQL + " delete from 地产_B_财务_二手应收应付 " + vbCr
                        strSQL = strSQL + " where 确认书号 = @qrsh" + vbCr
                        strSQL = strSQL + " and   isnull(收付状态,1) = 1" + vbCr
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@qrsh", strQRSH)
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.ExecuteNonQuery()
                    End If

                    '生成一般计划
                    strSQL = ""
                    strSQL = strSQL + " insert into 地产_B_财务_二手应收应付 (" + vbCr
                    strSQL = strSQL + "   唯一标识,确认书号," + vbCr
                    strSQL = strSQL + "   税费代码,收付对象,收付标志,应收日期," + vbCr
                    strSQL = strSQL + "   收付状态" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   唯一标识=newid(),确认书号=@qrsh," + vbCr
                    strSQL = strSQL + "   税费代码,收付对象,收付标志,应收日期=@ysrq," + vbCr
                    strSQL = strSQL + "   收付状态=@sfzt" + vbCr
                    strSQL = strSQL + " from 地产_B_公共_应收应付模版" + vbCr
                    strSQL = strSQL + " where 模版代码 like @mbdm + '.%'" + vbCr
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
        ' 判断给定的确认书号是否已有实际收支？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[isFashengShishou]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim
                If strQRSH = "" Then
                    Exit Try
                End If

                '获取数据库连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '计算
                strSQL = ""
                strSQL = strSQL + " select count(*) from 地产_B_财务_二手实收实付" + vbCr
                strSQL = strSQL + " where 确认书号 = '" + strQRSH + "'" + vbCr
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
                If objDataSet.Tables.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Dim intCount As Integer = 0
                        intCount = CType(objDataSet.Tables(0).Rows(0).Item(0), Integer)
                        If intCount > 0 Then
                            '已发生实际收支
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
        ' 根据“确认书号”获取“地产_B_财务_二手实收实付”完全数据的数据集
        ' 以“发生日期”升序排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateCaiwuData         ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_ES_SSSF = False
            objestateCaiwuData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_ES_SSSF]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateCaiwuData = New Josco.JSOA.Common.Data.estateCaiwuData(Josco.JSOA.Common.Data.estateCaiwuData.enumTableType.DC_B_CW_ES_SHISHOUSHIFU)
                    If strQRSH = "" Then
                        Exit Try
                    End If

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
                        strSQL = strSQL + "     税费名称     = dbo.uf_estate_gg_getSfmc(a.税费代码)," + vbCr
                        strSQL = strSQL + "     经办人员名称 = dbo.uf_gg_getRyzmByRydm(a.经办人员)," + vbCr
                        strSQL = strSQL + "     经办分行名称 = dbo.uf_gg_getZzmcByZzdm(a.经办分行)," + vbCr
                        strSQL = strSQL + "     财务审核名称 = dbo.uf_gg_getRyzmByRydm(a.财务审核)," + vbCr
                        strSQL = strSQL + "     是否审核     = case when rtrim(isnull(a.财务审核,'')) <> '' then @true else @false end," + vbCr
                        strSQL = strSQL + "     审核标志名称 = case when a.审核标志 = 1    then @true else @false end," + vbCr
                        strSQL = strSQL + "     发生金额收   = case when a.收付标志 = '收' then a.发生金额 else null end," + vbCr
                        strSQL = strSQL + "     发生金额付   = case when a.收付标志 = '收' then null else a.发生金额 end" + vbCr
                        strSQL = strSQL + "   from" + vbCr
                        strSQL = strSQL + "   (" + vbCr
                        strSQL = strSQL + "     select a.*" + vbCr
                        strSQL = strSQL + "     from 地产_B_财务_二手实收实付 a " + vbCr
                        strSQL = strSQL + "     where a.确认书号 = @qrsh" + vbCr
                        strSQL = strSQL + "   ) a" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.发生日期" + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@true", Josco.JsKernal.Common.Utilities.PulicParameters.CharTrue)
                        objSqlCommand.Parameters.AddWithValue("@false", Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse)
                        objSqlCommand.Parameters.AddWithValue("@qrsh", strQRSH)
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 根据“唯一标识”获取“地产_B_财务_二手实收实付”完全数据的数据集
        ' 以“发生日期”升序排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWYBS                    ：唯一标识
        '     objestateCaiwuData         ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_ES_SSSF = False
            objestateCaiwuData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_ES_SSSF]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateCaiwuData = New Josco.JSOA.Common.Data.estateCaiwuData(Josco.JSOA.Common.Data.estateCaiwuData.enumTableType.DC_B_CW_ES_SHISHOUSHIFU)
                    If strWYBS = "" Then
                        Exit Try
                    End If

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
                        strSQL = strSQL + "     税费名称     = dbo.uf_estate_gg_getSfmc(a.税费代码)," + vbCr
                        strSQL = strSQL + "     经办人员名称 = dbo.uf_gg_getRyzmByRydm(a.经办人员)," + vbCr
                        strSQL = strSQL + "     经办分行名称 = dbo.uf_gg_getZzmcByZzdm(a.经办分行)," + vbCr
                        strSQL = strSQL + "     财务审核名称 = dbo.uf_gg_getRyzmByRydm(a.财务审核)," + vbCr
                        strSQL = strSQL + "     是否审核     = case when rtrim(isnull(a.财务审核,'')) <> '' then @true else @false end," + vbCr
                        strSQL = strSQL + "     审核标志名称 = case when a.审核标志 = 1    then @true else @false end," + vbCr
                        strSQL = strSQL + "     发生金额收   = case when a.收付标志 = '收' then a.发生金额 else null end," + vbCr
                        strSQL = strSQL + "     发生金额付   = case when a.收付标志 = '收' then null else a.发生金额 end" + vbCr
                        strSQL = strSQL + "   from" + vbCr
                        strSQL = strSQL + "   (" + vbCr
                        strSQL = strSQL + "     select a.*" + vbCr
                        strSQL = strSQL + "     from 地产_B_财务_二手实收实付 a " + vbCr
                        strSQL = strSQL + "     where a.唯一标识 = @wybs" + vbCr
                        strSQL = strSQL + "   ) a" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        strSQL = strSQL + " order by a.发生日期" + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@true", Josco.JsKernal.Common.Utilities.PulicParameters.CharTrue)
                        objSqlCommand.Parameters.AddWithValue("@false", Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse)
                        objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 检查“地产_B_财务_二手实收实付”的数据的合法性
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[doVerifyData_ES_SSSF]未指定[连接用户]！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：[doVerifyData_ES_SSSF]未传入新的数据！"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：[doVerifyData_ES_SSSF]未传入旧的数据！"
                            GoTo errProc
                        End If
                End Select

                '获取表结构定义
                strSQL = "select top 0 * from 地产_B_财务_二手实收实付"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "地产_B_财务_二手实收实付", objDataSet) = False Then
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
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRYMC, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDWMC, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSHMC, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFSH, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZMC, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_S, _
                            Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_F
                            '显示列
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS
                            '自动列
                            If strValue = "" Then
                                If objdacCommon.getNewGUID(strErrMsg, strUserId, strPassword, strValue) = False Then
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSRQ
                            If strValue = "" Then
                                strErrMsg = "错误：没有输入[" + strField + "]！"
                                GoTo errProc
                            End If
                            If objPulicParameters.isDatetimeString(strValue) = False Then
                                strErrMsg = "错误：[" + strValue + "]是无效的日期！"
                                GoTo errProc
                            End If
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHRQ
                            If strValue <> "" Then
                                If objPulicParameters.isDatetimeString(strValue) = False Then
                                    strErrMsg = "错误：[" + strValue + "]是无效的日期！"
                                    GoTo errProc
                                End If
                            End If

                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZ
                            If strValue <> "" Then
                                If objPulicParameters.isIntegerString(strValue) = False Then
                                    strErrMsg = "错误：[" + strValue + "]是无效的数值！"
                                    GoTo errProc
                                End If
                            Else
                                strValue = "0"
                            End If
                        Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE
                            If strValue <> "" Then
                                If objPulicParameters.isFloatString(strValue) = False Then
                                    strErrMsg = "错误：[" + strValue + "]是无效的数值！"
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
        ' 保存“地产_B_财务_二手实收实付”的数据
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

            '初始化
            doSaveData_ES_SSSF = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[doSaveData_ES_SSSF]未指定[连接用户]！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    strErrMsg = "错误：[doSaveData_ES_SSSF]未传入新的数据！"
                    GoTo errProc
                End If
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                    Case Else
                        If objOldData Is Nothing Then
                            strErrMsg = "错误：[doSaveData_ES_SSSF]未传入旧的数据！"
                            GoTo errProc
                        End If
                End Select

                '检查数据
                If Me.doVerifyData_ES_SSSF(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType) = False Then
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
                                    Case Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRYMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDWMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSHMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFSH, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZMC, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_S, _
                                        Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_F
                                        '显示列
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " insert into 地产_B_财务_二手实收实付 (" + vbCr
                            strSQL = strSQL + "   " + strFields + vbCr
                            strSQL = strSQL + " ) values (" + vbCr
                            strSQL = strSQL + "   " + strValues + vbCr
                            strSQL = strSQL + " )" + vbCr

                        Case Else
                            '获取主键
                            strOldKey = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS), "")

                            '计算字段列表、字段值
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
                                        '显示列
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

                            '准备SQL语句
                            strSQL = ""
                            strSQL = strSQL + " update 地产_B_财务_二手实收实付 set " + vbCr
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
        ' 根据收款计划收取款项
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：相关参数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doAddNew_ES_SSSF = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[doAddNew_ES_SSSF]未指定[连接用户]！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    Exit Try
                End If
                If objNewData.Count < 1 Then
                    Exit Try
                End If

                '获取参数
                Dim strWYBS As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS), "")
                Dim strQRSH As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH), "")
                Dim strFSJE As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE), "")
                Dim strPJHM As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_PJHM), "")
                Dim strZYSM As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_ZYSM), "")
                Dim strKHMC As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_KHMC), "")
                Dim strJBRY As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRY), "")
                Dim strJBDW As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDW), "")

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

                '处理
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    strSQL = ""
                    strSQL = strSQL + " insert into 地产_B_财务_二手实收实付 (" + vbCr
                    strSQL = strSQL + "   唯一标识,确认书号,票据号码,税费代码,收付对象,收付标志," + vbCr
                    strSQL = strSQL + "   发生日期,发生金额,摘要说明,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员,经办分行,计划标识" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   唯一标识=newid(),确认书号,票据号码=@pjhm,税费代码,收付对象,收付标志," + vbCr
                    strSQL = strSQL + "   发生日期=@fsrq,发生金额=@fsje,摘要说明=@zysm,客户名称=@khmc," + vbCr
                    strSQL = strSQL + "   经办人员=@jbry,经办分行=@jbdw,计划标识=@wybs" + vbCr
                    strSQL = strSQL + " from 地产_B_财务_二手应收应付" + vbCr
                    strSQL = strSQL + " where 唯一标识 = @wybs" + vbCr
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
        ' 将指定款项按指定方式结转处理
        ' 同一客户、相同收付方向时的结转处理
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：相关参数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doJiezhuan_ES_SSSF = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[doJiezhuan_ES_SSSF]未指定[连接用户]！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    Exit Try
                End If
                If objNewData.Count < 1 Then
                    Exit Try
                End If

                '获取参数
                Dim strWYBS As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS), "")
                Dim strQRSH As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH), "")
                Dim strFSJE As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE), "")
                Dim strSFDM As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM), "")
                Dim strSFMC As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC), "")
                Dim strSFDX As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX), "")
                Dim strSFBZ As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ), "")
                Dim dblFSJE As Double = objPulicParameters.getObjectValue(strFSJE, 0.0)

                '获取要结转的数据信息
                If Me.getDataSet_ES_SSSF(strErrMsg, strUserId, strPassword, strWYBS, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU) Is Nothing Then
                    strErrMsg = "错误：要结转的数据不存在！"
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows.Count < 1 Then
                    strErrMsg = "错误：要结转的数据不存在！"
                    GoTo errProc
                End If
                Dim strSrcSFMC As String = ""
                Dim dblSrcFSJE As Double = 0
                With objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows(0)
                    strSrcSFMC = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC), "")
                    dblSrcFSJE = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE), 0.0)
                End With
                If dblSrcFSJE < dblFSJE Then
                    strErrMsg = "错误：余额不足！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取操作员的单位信息
                Dim strBMMC As String = ""
                Dim strJBDW As String = ""
                If objdacCustomer.getBmdmAndBmmcByRydm(strErrMsg, objSqlConnection, strUserId, strJBDW, strBMMC) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '处理
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '登记结转后款项
                    strSQL = ""
                    strSQL = strSQL + " insert into 地产_B_财务_二手实收实付 (" + vbCr
                    strSQL = strSQL + "   唯一标识,确认书号,票据号码,税费代码,收付对象,收付标志," + vbCr
                    strSQL = strSQL + "   发生日期,发生金额,摘要说明,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员,经办分行,计划标识" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   唯一标识=newid(),确认书号,票据号码,税费代码=@sfdm,收付对象=@sfdx,收付标志=@sfbz," + vbCr
                    strSQL = strSQL + "   发生日期=@fsrq,发生金额=@fsje,摘要说明=@zysm,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员=@jbry,经办分行=@jbdw,计划标识" + vbCr
                    strSQL = strSQL + " from 地产_B_财务_二手实收实付" + vbCr
                    strSQL = strSQL + " where 唯一标识 = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@sfdm", strSFDM)
                    objSqlCommand.Parameters.AddWithValue("@sfdx", strSFDX)
                    objSqlCommand.Parameters.AddWithValue("@sfbz", strSFBZ)
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", dblFSJE)
                    objSqlCommand.Parameters.AddWithValue("@zysm", "[" + strSFDX + "][" + strSrcSFMC + "]转入")
                    objSqlCommand.Parameters.AddWithValue("@jbry", strUserId)
                    objSqlCommand.Parameters.AddWithValue("@jbdw", strJBDW)
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '冲减原来款项
                    strSQL = ""
                    strSQL = strSQL + " insert into 地产_B_财务_二手实收实付 (" + vbCr
                    strSQL = strSQL + "   唯一标识,确认书号,票据号码,税费代码,收付对象,收付标志," + vbCr
                    strSQL = strSQL + "   发生日期,发生金额,摘要说明,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员,经办分行,计划标识" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   唯一标识=newid(),确认书号,票据号码,税费代码,收付对象,收付标志," + vbCr
                    strSQL = strSQL + "   发生日期=@fsrq,发生金额=@fsje,摘要说明=@zysm,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员=@jbry,经办分行=@jbdw,计划标识" + vbCr
                    strSQL = strSQL + " from 地产_B_财务_二手实收实付" + vbCr
                    strSQL = strSQL + " where 唯一标识 = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", -dblFSJE)
                    objSqlCommand.Parameters.AddWithValue("@zysm", "转入[" + strSFDX + "][" + strSFMC + "]")
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

                '提交事务
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

            '返回
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
        ' 获取“地产_B_财务_二手实收实付”完全数据的数据集
        ' 以“发生日期”升序排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     blnUnused                  ：接口重载
        '     objestateCaiwuData         ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
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

            '初始化
            getDataSet_ES_SSSF = False
            objestateCaiwuData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strWhere.Length > 0 Then strWhere = strWhere.Trim()
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getDataSet_ES_SSSF]未指定[连接用户]！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取数据
                Try
                    '创建数据集
                    objTempestateCaiwuData = New Josco.JSOA.Common.Data.estateCaiwuData(Josco.JSOA.Common.Data.estateCaiwuData.enumTableType.DC_B_CW_ES_SHISHOUSHIFU)

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
                        strSQL = strSQL + "     税费名称     = dbo.uf_estate_gg_getSfmc(a.税费代码)," + vbCr
                        strSQL = strSQL + "     经办人员名称 = dbo.uf_gg_getRyzmByRydm(a.经办人员)," + vbCr
                        strSQL = strSQL + "     经办分行名称 = dbo.uf_gg_getZzmcByZzdm(a.经办分行)," + vbCr
                        strSQL = strSQL + "     财务审核名称 = dbo.uf_gg_getRyzmByRydm(a.财务审核)," + vbCr
                        strSQL = strSQL + "     是否审核     = case when rtrim(isnull(a.财务审核,'')) <> '' then @true else @false end," + vbCr
                        strSQL = strSQL + "     审核标志名称 = case when a.审核标志 = 1    then @true else @false end," + vbCr
                        strSQL = strSQL + "     发生金额收   = case when a.收付标志 = '收' then a.发生金额 else null end," + vbCr
                        strSQL = strSQL + "     发生金额付   = case when a.收付标志 = '收' then null else a.发生金额 end" + vbCr
                        strSQL = strSQL + "   from" + vbCr
                        strSQL = strSQL + "   (" + vbCr
                        strSQL = strSQL + "     select a.*" + vbCr
                        strSQL = strSQL + "     from 地产_B_财务_二手实收实付 a " + vbCr
                        strSQL = strSQL + "   ) a" + vbCr
                        strSQL = strSQL + " ) a" + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.发生日期" + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@true", Josco.JsKernal.Common.Utilities.PulicParameters.CharTrue)
                        objSqlCommand.Parameters.AddWithValue("@false", Josco.JsKernal.Common.Utilities.PulicParameters.CharFalse)
                        .SelectCommand = objSqlCommand

                        '执行操作
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

            '返回
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
        ' 删除“地产_B_财务_二手实收实付”的数据(必须没有审过)
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doDeleteData_ES_SSSF = False
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
                    strSQL = strSQL + " delete from 地产_B_财务_二手实收实付 " + vbCr
                    strSQL = strSQL + " where 唯一标识 = @oldkey" + vbCr
                    strSQL = strSQL + " and   rtrim(isnull(财务审核,'')) = ''" + vbCr
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

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 审定款项
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     blnTongguo           ：True通过审核
        '     objNewData           ：相关参数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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

            '初始化
            doShenhe_ES_SSSF = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[doShenhe_ES_SSSF]未指定[连接用户]！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    Exit Try
                End If
                If objNewData.Count < 1 Then
                    Exit Try
                End If

                '获取参数
                Dim strWYBS As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS), "")
                Dim strQRSH As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH), "")
                Dim strFSJE As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE), "")
                Dim strSFDM As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM), "")
                Dim strSFMC As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC), "")
                Dim strSFDX As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX), "")
                Dim strSFBZ As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ), "")
                Dim strPJHM As String = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_PJHM), "")
                Dim dblFSJE As Double = objPulicParameters.getObjectValue(strFSJE, 0.0)

                '获取数据信息
                If Me.getDataSet_ES_SSSF(strErrMsg, strUserId, strPassword, strWYBS, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU) Is Nothing Then
                    strErrMsg = "错误：要审核的数据不存在！"
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows.Count < 1 Then
                    strErrMsg = "错误：要审核的数据不存在！"
                    GoTo errProc
                End If
                Dim intSHBZ As Integer = 0
                With objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows(0)
                    intSHBZ = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZ), 0)
                End With
                If intSHBZ = 1 Then
                    strErrMsg = "错误：该款项已经做过审核！"
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

                '处理
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    If blnTongguo = False Then
                        '不通过！
                        strSQL = ""
                        strSQL = strSQL + " update 地产_B_财务_二手实收实付 set" + vbCr
                        strSQL = strSQL + "   审核标志 = 1," + vbCr
                        strSQL = strSQL + "   审核日期 = @shrq" + vbCr
                        strSQL = strSQL + " from 地产_B_财务_二手实收实付" + vbCr
                        strSQL = strSQL + " where 唯一标识 = @wybs" + vbCr
                        strSQL = strSQL + " and   审核标志 <> 1" + vbCr
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@shrq", Now)
                        objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    Else
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@shrq", Now)
                        objSqlCommand.Parameters.AddWithValue("@cwsh", strUserId)
                        '通过！
                        strSQL = ""
                        strSQL = strSQL + " update 地产_B_财务_二手实收实付 set" + vbCr
                        strSQL = strSQL + "   审核标志 = 1" + vbCr
                        strSQL = strSQL + "  ,审核日期 = @shrq" + vbCr
                        strSQL = strSQL + "  ,财务审核 = @cwsh" + vbCr
                        If strPJHM <> "" Then
                            strSQL = strSQL + "  ,票据号码 = @pjhm" + vbCr
                            objSqlCommand.Parameters.AddWithValue("@pjhm", strPJHM)
                        End If
                        If strSFDM <> "" Then
                            strSQL = strSQL + "  ,税费代码 = @sfdm" + vbCr
                            objSqlCommand.Parameters.AddWithValue("@sfdm", strSFDM)
                        End If
                        If strSFDX <> "" Then
                            strSQL = strSQL + "  ,收付对象 = @sfdx" + vbCr
                            objSqlCommand.Parameters.AddWithValue("@sfdx", strSFDX)
                        End If
                        If strSFBZ <> "" Then
                            strSQL = strSQL + "  ,收付标志 = @sfbz" + vbCr
                            objSqlCommand.Parameters.AddWithValue("@sfbz", strSFBZ)
                        End If
                        If strFSJE <> "" Then
                            strSQL = strSQL + "  ,发生金额 = @fsje" + vbCr
                            objSqlCommand.Parameters.AddWithValue("@fsje", dblFSJE)
                        End If
                        strSQL = strSQL + " from 地产_B_财务_二手实收实付" + vbCr
                        strSQL = strSQL + " where 唯一标识 = @wybs" + vbCr
                        strSQL = strSQL + " and   审核标志 <> 1" + vbCr
                        objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    End If
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
            Josco.JSOA.Common.Data.estateCaiwuData.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
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
        ' 计算指定确认书的备用金数据：甲方、乙方
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     dblBYJ_JF            ：甲方备用金
        '     dblBYJ_YF            ：乙方备用金
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getHetongBeiyongjin]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim
                If strQRSH = "" Then
                    Exit Try
                End If

                '获取数据库连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '计算：去掉已审不通过的数据
                strSQL = ""
                strSQL = strSQL + " select 收付对象,收付标志,发生金额=sum(发生金额)" + vbCr
                strSQL = strSQL + " from 地产_B_财务_二手实收实付" + vbCr
                strSQL = strSQL + " where 确认书号 = '" + strQRSH + "'" + vbCr
                strSQL = strSQL + " and not (审核标志 = 1" + vbCr          '已审
                strSQL = strSQL + " and   rtrim(财务审核) = '')" + vbCr    '不通过
                strSQL = strSQL + " group by 收付对象,收付标志" + vbCr
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
                If objDataSet.Tables.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Dim dblValue As Double = 0.0
                        Dim strSFDX As String = ""
                        Dim strSFBZ As String = ""
                        Dim intCount As Integer = 0
                        Dim i As Integer = 0
                        intCount = objDataSet.Tables(0).Rows.Count
                        For i = 0 To intCount - 1 Step 1
                            strSFDX = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("收付对象"), "")
                            strSFBZ = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("收付标志"), "")
                            dblValue = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("发生金额"), 0.0)
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
        ' 计算指定确认书、指定收付标志、指定税费的财务实收数据：甲方、乙方
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     strSFBZ              ：收、付
        '     strSFDM              ：税费代码
        '     dblBYJ_JF            ：甲方备用金
        '     dblBYJ_YF            ：乙方备用金
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getHetongBeiyongjin]未指定[连接用户]！"
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

                '获取数据库连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '计算：去掉已审不通过的数据
                strSQL = ""
                strSQL = strSQL + " select 收付对象,发生金额=sum(发生金额)" + vbCr
                strSQL = strSQL + " from 地产_B_财务_二手实收实付" + vbCr
                strSQL = strSQL + " where 确认书号 = '" + strQRSH + "'" + vbCr
                strSQL = strSQL + " and   收付标志 = '" + strSFBZ + "'" + vbCr
                strSQL = strSQL + " and  (税费代码 = '" + strSFDM + "' or 税费代码 like '" + strSFDM + ".%')" + vbCr
                strSQL = strSQL + " and not (审核标志 = 1" + vbCr          '已审
                strSQL = strSQL + " and   rtrim(财务审核) = '')" + vbCr    '不通过
                strSQL = strSQL + " group by 收付对象" + vbCr
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
                If objDataSet.Tables.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Dim dblValue As Double = 0.0
                        Dim strSFDX As String = ""
                        Dim intCount As Integer = 0
                        Dim i As Integer = 0
                        intCount = objDataSet.Tables(0).Rows.Count
                        For i = 0 To intCount - 1 Step 1
                            strSFDX = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("收付对象"), "")
                            dblValue = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("发生金额"), 0.0)
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
        ' 计算指定确认书、指定收付标志、不是指定税费的财务实收数据：甲方、乙方
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     strSFBZ              ：收、付
        '     strSFDMList          ：要剔除的税费代码
        '     blnUnused            ：接口重载
        '     dblBYJ_JF            ：甲方备用金
        '     dblBYJ_YF            ：乙方备用金
        ' 返回
        '     True                 ：成功
        '     False                ：失败
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getHetongBeiyongjin]未指定[连接用户]！"
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

                '获取数据库连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '计算：去掉已审不通过的数据
                Dim intCount As Integer = strArray.Length
                Dim i As Integer = 0
                strSQL = ""
                strSQL = strSQL + " select 收付对象,发生金额=sum(发生金额)" + vbCr
                strSQL = strSQL + " from 地产_B_财务_二手实收实付" + vbCr
                strSQL = strSQL + " where 确认书号 = '" + strQRSH + "'" + vbCr
                strSQL = strSQL + " and   收付标志 = '" + strSFBZ + "'" + vbCr
                strSQL = strSQL + " and   not (" + vbCr
                For i = 0 To intCount - 1 Step 1
                    If i = 0 Then
                        strSQL = strSQL + " (税费代码 = '" + strArray(i) + "' or 税费代码 like '" + strArray(i) + ".%')" + vbCr
                    Else
                        strSQL = strSQL + " or  (税费代码 = '" + strArray(i) + "' or 税费代码 like '" + strArray(i) + ".%')" + vbCr
                    End If
                Next
                strSQL = strSQL + " )" + vbCr
                strSQL = strSQL + " and not (审核标志 = 1" + vbCr          '已审
                strSQL = strSQL + " and   rtrim(财务审核) = '')" + vbCr    '不通过
                strSQL = strSQL + " group by 收付对象" + vbCr
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
                If objDataSet.Tables.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        Dim dblValue As Double = 0.0
                        Dim strSFDX As String = ""
                        intCount = objDataSet.Tables(0).Rows.Count
                        For i = 0 To intCount - 1 Step 1
                            strSFDX = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("收付对象"), "")
                            dblValue = objPulicParameters.getObjectValue(objDataSet.Tables(0).Rows(i).Item("发生金额"), 0.0)
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
        ' 计算新的[票据批号]
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strFGFH              ：发给分行
        '     strPJPH              ：发放批次(返回)
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strFGFH Is Nothing Then strFGFH = ""
                strFGFH = strFGFH.Trim
                If strFGFH = "" Then
                    strErrMsg = "错误：[发给分行]必须提供！"
                    GoTo errProc
                End If

                '连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '计算
                If objdacCommon.getNewCode(strErrMsg, objSqlConnection, "票据批号", "发给分行", strFGFH, "地产_B_财务_票据使用情况", True, strPJPH) = False Then
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
        ' 判断给定的票据是否为[已使用]？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2009-05-17 创建
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[isPiaojuUsed]未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim
                If strWYBS = "" Then
                    strErrMsg = "错误：[isPiaojuUsed]未指定[唯一标识]！"
                    GoTo errProc
                End If

                '获取数据库连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '计算
                strSQL = ""
                strSQL = strSQL + " select count(*) from 地产_B_财务_票据使用情况" + vbCr
                strSQL = strSQL + " where 唯一标识 = '" + strWYBS + "'" + vbCr
                strSQL = strSQL + " and   状态标志 & 0x7 = 0x1" + vbCr '已使用
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
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
        ' 判断给定的票据是否为[已作废]？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改记录
        '     zengxianglin 2009-05-17 创建
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[isPiaojuZuofei]未指定要获取信息的用户！"
                    GoTo errProc
                End If
                If strWYBS Is Nothing Then strWYBS = ""
                strWYBS = strWYBS.Trim
                If strWYBS = "" Then
                    strErrMsg = "错误：[isPiaojuZuofei]未指定[唯一标识]！"
                    GoTo errProc
                End If

                '获取数据库连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '计算
                strSQL = ""
                strSQL = strSQL + " select count(*) from 地产_B_财务_票据使用情况" + vbCr
                strSQL = strSQL + " where 唯一标识 = '" + strWYBS + "'" + vbCr
                strSQL = strSQL + " and   状态标志 & 0x7 = 0x2" + vbCr '已作废
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
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
        ' 票据核销
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：要标记的票据的“唯一标识”
        '     strHXRY              ：核销人员
        '     strHXRQ              ：核销日期
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改记录
        '     zengxianglin 2009-05-17 创建
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

            '初始化
            doPiaoju_Hexiao = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[doPiaoju_Hexiao]未指定[连接用户]！"
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
                    strErrMsg = "错误：[doPiaoju_Hexiao]无效的[" + strHXRQ + "]！"
                    GoTo errProc
                End If
                Dim blnValue As Boolean = False

                '已使用？
                If Me.isPiaojuUsed(strErrMsg, strUserId, strPassword, strWYBS, blnValue) = False Then
                    GoTo errProc
                End If
                If blnValue = False Then
                    '已作废？
                    If Me.isPiaojuZuofei(strErrMsg, strUserId, strPassword, strWYBS, blnValue) = False Then
                        GoTo errProc
                    End If
                    If blnValue = False Then
                        strErrMsg = "错误：[doPiaoju_Hexiao]票据不是[已使用|已作废]，不用核销！"
                        GoTo errProc
                    End If
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

                '处理
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    strSQL = ""
                    strSQL = strSQL + " update 地产_B_财务_票据使用情况 set" + vbCr
                    strSQL = strSQL + "   核销标志 = 1," + vbCr
                    strSQL = strSQL + "   核销人员 = @hxry," + vbCr
                    strSQL = strSQL + "   核销日期 = @hxrq " + vbCr
                    strSQL = strSQL + " where 唯一标识 = @wybs" + vbCr
                    strSQL = strSQL + " and   核销标志 = 0" + vbCr
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
        ' 将指定款项按指定方式结转处理
        ' 不同客户、收->收方向时的结转处理
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：相关参数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2010-12-30 创建
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

            '初始化
            doJiezhuan_ES_SSSF_TFX = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[doJiezhuan_ES_SSSF_TFX]未指定[连接用户]！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    Exit Try
                End If
                If objNewData.Count < 1 Then
                    Exit Try
                End If

                '获取参数
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

                '获取要结转的数据信息
                If Me.getDataSet_ES_SSSF(strErrMsg, strUserId, strPassword, strWYBS, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU) Is Nothing Then
                    strErrMsg = "错误：要结转的数据不存在！"
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows.Count < 1 Then
                    strErrMsg = "错误：要结转的数据不存在！"
                    GoTo errProc
                End If
                Dim strSrcSFMC As String = ""
                Dim dblSrcFSJE As Double = 0
                With objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows(0)
                    strSrcSFMC = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC), "")
                    dblSrcFSJE = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE), 0.0)
                End With
                If dblSrcFSJE < dblFSJE Then
                    strErrMsg = "错误：余额不足！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取操作员的单位信息
                Dim strBMMC As String = ""
                Dim strJBDW As String = ""
                If objdacCustomer.getBmdmAndBmmcByRydm(strErrMsg, objSqlConnection, strUserId, strJBDW, strBMMC) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '处理
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '转入另一方收款
                    strSQL = ""
                    strSQL = strSQL + " insert into 地产_B_财务_二手实收实付 (" + vbCr
                    strSQL = strSQL + "   唯一标识,确认书号,票据号码,税费代码,收付对象,收付标志," + vbCr
                    strSQL = strSQL + "   发生日期,发生金额,摘要说明,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员,经办分行,计划标识" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   唯一标识=newid(),确认书号,票据号码,税费代码=@sfdm,收付对象=@sfdx,收付标志=@sfbz," + vbCr
                    strSQL = strSQL + "   发生日期=@fsrq,发生金额=@fsje,摘要说明=@zysm,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员=@jbry,经办分行=@jbdw,计划标识" + vbCr
                    strSQL = strSQL + " from 地产_B_财务_二手实收实付" + vbCr
                    strSQL = strSQL + " where 唯一标识 = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@sfdm", strSFDM)
                    objSqlCommand.Parameters.AddWithValue("@sfdx", strSFDX)
                    objSqlCommand.Parameters.AddWithValue("@sfbz", strSFBZ)
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", dblFSJE)
                    objSqlCommand.Parameters.AddWithValue("@zysm", "[" + strSFDX_Old + "][" + strSrcSFMC + "]转入[" + strSFDX + "]")
                    objSqlCommand.Parameters.AddWithValue("@jbry", strUserId)
                    objSqlCommand.Parameters.AddWithValue("@jbdw", strJBDW)
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '冲减原来收款
                    strSQL = ""
                    strSQL = strSQL + " insert into 地产_B_财务_二手实收实付 (" + vbCr
                    strSQL = strSQL + "   唯一标识,确认书号,票据号码,税费代码,收付对象,收付标志," + vbCr
                    strSQL = strSQL + "   发生日期,发生金额,摘要说明,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员,经办分行,计划标识" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   唯一标识=newid(),确认书号,票据号码,税费代码,收付对象,收付标志," + vbCr
                    strSQL = strSQL + "   发生日期=@fsrq,发生金额=@fsje,摘要说明=@zysm,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员=@jbry,经办分行=@jbdw,计划标识" + vbCr
                    strSQL = strSQL + " from 地产_B_财务_二手实收实付" + vbCr
                    strSQL = strSQL + " where 唯一标识 = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", -dblFSJE)
                    objSqlCommand.Parameters.AddWithValue("@zysm", "[" + strSFDX_Old + "]转入[" + strSFDX + "][" + strSFMC + "]")
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

                '提交事务
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

            '返回
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
        ' 将指定款项按指定方式结转处理
        ' 不同客户、收->付方向时的结转处理
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：相关参数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2010-12-30 创建
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

            '初始化
            doJiezhuan_ES_SSSF_BTFX = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[doJiezhuan_ES_SSSF_BTFX]未指定[连接用户]！"
                    GoTo errProc
                End If
                If objNewData Is Nothing Then
                    Exit Try
                End If
                If objNewData.Count < 1 Then
                    Exit Try
                End If

                '获取参数
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

                '获取要结转的数据信息
                If Me.getDataSet_ES_SSSF(strErrMsg, strUserId, strPassword, strWYBS, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU) Is Nothing Then
                    strErrMsg = "错误：要结转的数据不存在！"
                    GoTo errProc
                End If
                If objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows.Count < 1 Then
                    strErrMsg = "错误：要结转的数据不存在！"
                    GoTo errProc
                End If
                Dim strSrcSFMC As String = ""
                Dim dblSrcFSJE As Double = 0
                With objDataSet.Tables(Josco.JSOA.Common.Data.estateCaiwuData.TABLE_DC_B_CW_ES_SHISHOUSHIFU).Rows(0)
                    strSrcSFMC = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC), "")
                    dblSrcFSJE = objPulicParameters.getObjectValue(.Item(Josco.JSOA.Common.Data.estateCaiwuData.FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE), 0.0)
                End With
                If dblSrcFSJE < dblFSJE Then
                    strErrMsg = "错误：余额不足！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取操作员的单位信息
                Dim strBMMC As String = ""
                Dim strJBDW As String = ""
                If objdacCustomer.getBmdmAndBmmcByRydm(strErrMsg, objSqlConnection, strUserId, strJBDW, strBMMC) = False Then
                    GoTo errProc
                End If

                '开始事务
                Try
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '处理
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '先转收
                    strSQL = ""
                    strSQL = strSQL + " insert into 地产_B_财务_二手实收实付 (" + vbCr
                    strSQL = strSQL + "   唯一标识,确认书号,票据号码,税费代码,收付对象,收付标志," + vbCr
                    strSQL = strSQL + "   发生日期,发生金额,摘要说明,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员,经办分行,计划标识" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   唯一标识=newid(),确认书号,票据号码,税费代码=@sfdm,收付对象=@sfdx,收付标志=@sfbz," + vbCr
                    strSQL = strSQL + "   发生日期=@fsrq,发生金额=@fsje,摘要说明=@zysm,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员=@jbry,经办分行=@jbdw,计划标识" + vbCr
                    strSQL = strSQL + " from 地产_B_财务_二手实收实付" + vbCr
                    strSQL = strSQL + " where 唯一标识 = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@sfdm", strSFDM)
                    objSqlCommand.Parameters.AddWithValue("@sfdx", strSFDX)
                    objSqlCommand.Parameters.AddWithValue("@sfbz", strSFBZ_Old)
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", dblFSJE)
                    objSqlCommand.Parameters.AddWithValue("@zysm", "[" + strSFDX_Old + "][" + strSrcSFMC + "]转入[" + strSFDX + "]后支付")
                    objSqlCommand.Parameters.AddWithValue("@jbry", strUserId)
                    objSqlCommand.Parameters.AddWithValue("@jbdw", strJBDW)
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '再支付
                    strSQL = ""
                    strSQL = strSQL + " insert into 地产_B_财务_二手实收实付 (" + vbCr
                    strSQL = strSQL + "   唯一标识,确认书号,票据号码,税费代码,收付对象,收付标志," + vbCr
                    strSQL = strSQL + "   发生日期,发生金额,摘要说明,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员,经办分行,计划标识" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   唯一标识=newid(),确认书号,票据号码,税费代码=@sfdm,收付对象=@sfdx,收付标志=@sfbz," + vbCr
                    strSQL = strSQL + "   发生日期=@fsrq,发生金额=@fsje,摘要说明=@zysm,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员=@jbry,经办分行=@jbdw,计划标识" + vbCr
                    strSQL = strSQL + " from 地产_B_财务_二手实收实付" + vbCr
                    strSQL = strSQL + " where 唯一标识 = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@sfdm", strSFDM)
                    objSqlCommand.Parameters.AddWithValue("@sfdx", strSFDX)
                    objSqlCommand.Parameters.AddWithValue("@sfbz", strSFBZ)
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", dblFSJE)
                    objSqlCommand.Parameters.AddWithValue("@zysm", "[" + strSFDX_Old + "][" + strSrcSFMC + "]转入[" + strSFDX + "]后支付")
                    objSqlCommand.Parameters.AddWithValue("@jbry", strUserId)
                    objSqlCommand.Parameters.AddWithValue("@jbdw", strJBDW)
                    objSqlCommand.Parameters.AddWithValue("@wybs", strWYBS)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '冲减原来收款
                    strSQL = ""
                    strSQL = strSQL + " insert into 地产_B_财务_二手实收实付 (" + vbCr
                    strSQL = strSQL + "   唯一标识,确认书号,票据号码,税费代码,收付对象,收付标志," + vbCr
                    strSQL = strSQL + "   发生日期,发生金额,摘要说明,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员,经办分行,计划标识" + vbCr
                    strSQL = strSQL + " )" + vbCr
                    strSQL = strSQL + " select" + vbCr
                    strSQL = strSQL + "   唯一标识=newid(),确认书号,票据号码,税费代码,收付对象,收付标志," + vbCr
                    strSQL = strSQL + "   发生日期=@fsrq,发生金额=@fsje,摘要说明=@zysm,客户名称," + vbCr
                    strSQL = strSQL + "   经办人员=@jbry,经办分行=@jbdw,计划标识" + vbCr
                    strSQL = strSQL + " from 地产_B_财务_二手实收实付" + vbCr
                    strSQL = strSQL + " where 唯一标识 = @wybs" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@fsrq", Now.ToString("yyyy-MM-dd"))
                    objSqlCommand.Parameters.AddWithValue("@fsje", -dblFSJE)
                    objSqlCommand.Parameters.AddWithValue("@zysm", "[" + strSFDX_Old + "]转入[" + strSFDX + "]并支付[" + strSFMC + "]")
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

                '提交事务
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

            '返回
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
        ' 计算指定[确认书号][税费代码][收付对象]的余额
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     strSFDM              ：税费代码
        '     strSFDX              ：收付对象
        '     dblBalance           ：余额
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2010-12-30 创建
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
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：[getBalance]未指定[连接用户]！"
                    GoTo errProc
                End If
                If strQRSH Is Nothing Then strQRSH = ""
                strQRSH = strQRSH.Trim
                If strSFDM Is Nothing Then strSFDM = ""
                strSFDM = strSFDM.Trim
                If strSFDX Is Nothing Then strSFDX = ""
                strSFDX = strSFDX.Trim
                If strQRSH = "" Or strSFDM = "" Or strSFDX = "" Then
                    strErrMsg = "错误：[getBalance]未指定相关参数！"
                    GoTo errProc
                End If

                '获取数据库连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '计算
                strSQL = ""
                strSQL = strSQL + " select sum(发生金额) from 地产_B_财务_二手实收实付" + vbCr
                strSQL = strSQL + " where 确认书号 = '" + strQRSH + "'" + vbCr
                strSQL = strSQL + " and   税费代码 = '" + strSFDM + "'" + vbCr
                strSQL = strSQL + " and   收付对象 = '" + strSFDX + "'" + vbCr
                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
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
