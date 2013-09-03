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
Imports Josco.JSOA.Common
Imports Josco.JSOA.Common.Data

Namespace Josco.JSOA.DataAccess

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.DataAccess
    ' 类名    ：dacKaoqinguanli
    '----------------------------------------------------------------

    Public Class dacKaoqinguanli
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.DataAccess.dacKaoqinguanli)
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
        ' 获取查看所有部门的对应的应休假标准
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     objkqglkqjlData            ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataYXJBZ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Dim objTempkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String = ""

            '初始化
            getDataYXJBZ = False
            objTempkaoqinguanliData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""

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
                    objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_VT_YUEYINGXIUJIA)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        Dim strYear As String
                        strYear = Year(Now).ToString

                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select * from dbo.uf_kaoqin_getYingxiujia_01(@year) "
                        strSQL = strSQL + " order by 组织代码"

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@year", strYear)
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_YUEYINGXIUJIA))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempkaoqinguanliData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            objkqglkqjlData = objTempkaoqinguanliData
            getDataYXJBZ = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function



        '----------------------------------------------------------------
        ' 获取查看所有部门的对应的应休假标准
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     objkqglkqjlData            ：信息数据集
        '     strWhere                   : 条件
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataYXJBZ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData, _
            ByVal strWhere As String) As Boolean

            Dim objTempkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String = ""

            '初始化
            getDataYXJBZ = False
            objTempkaoqinguanliData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""

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
                    objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_VT_YUEYINGXIUJIA)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        Dim strYear As String
                        strYear = Year(Now).ToString

                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select distinct 组织代码,组织名称 from dbo.uf_kaoqin_getYingxiujia_01(@year) "
                        strSQL = strSQL + " order by 组织代码"

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@year", strYear)
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_YUEYINGXIUJIA))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempkaoqinguanliData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            objkqglkqjlData = objTempkaoqinguanliData
            getDataYXJBZ = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 更新指定的单位的应休假标准
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doUpdate_YXJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_KAOQINJILU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            Dim strYear As String
            Dim strZZDM As String
            Dim strBZ As String
            Dim intBZ As Integer


            '初始化
            doUpdate_YXJ = False
            strErrMsg = ""

            Try

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If
                strZZDM = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_VT_YUEYINGXIUJIA_ZZDM), "")
                strBZ = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_VT_YUEYINGXIUJIA_YXJBZ), "")
                intBZ = CInt(strBZ)

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction()


                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '更新
                    strSQL = ""
                    strSQL = "update 公共_B_组织机构 set 应休假标准=@bz where 组织代码=@zzdm "

                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@bz", intBZ)
                    objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
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
            doUpdate_YXJ = True
            Exit Function
rollback:
            objSqlTransaction.Rollback()
            GoTo errProc
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function


        '----------------------------------------------------------------
        ' 更新指定的单位的应休假天数
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doSet_YXJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_YUEYINGXIUJIA
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            Dim strYear As String
            Dim strZZDM As String = ""
            Dim strRQ As String = ""
            Dim strTS As String = ""


            '初始化
            doSet_YXJ = False
            strErrMsg = ""

            Try

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                 strZZDM = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_YUEYINGXIUJIA_ZZDM), "")
                strRQ = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_YUEYINGXIUJIA_RQ), "")
                strTS = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_YUEYINGXIUJIA_TS), "")


                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction()


                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '更新
                    strSQL = ""
                    strSQL = "delete 考勤_B_月应休假 where 组织代码=@zzdm and 日期=@rq "

                    objSqlCommand.Parameters.Clear()
                    If strRQ <> "" Then
                        objSqlCommand.Parameters.AddWithValue("@rq", CType(strRQ, System.DateTime))
                    End If
                    objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    strSQL = ""
                    strSQL = "insert into 考勤_B_月应休假 (唯一标识,组织代码,日期,天数) values (newid(),@zzdm,@rq,@ts)"
                    objSqlCommand.Parameters.Clear()
                    If strRQ <> "" Then
                        objSqlCommand.Parameters.AddWithValue("@rq", CType(strRQ, System.DateTime))
                    End If
                    objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                    objSqlCommand.Parameters.AddWithValue("@ts", CType(strTS, System.Double))
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
            doSet_YXJ = True
            Exit Function
rollback:
            objSqlTransaction.Rollback()
            GoTo errProc
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function



        '----------------------------------------------------------------
        ' 生成指定月份的补休假
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strKSRQ              ：开始日期
        '     strJSRQ              ：结束日期
        '     strZZDM              ：生成的单位
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doSet_BXJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strJSRQ As String, _
            ByVal strZZDM As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_YUEYINGXIUJIA
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            '初始化
            doSet_BXJ = False
            strErrMsg = ""

            Try

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction()


                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '更新
                    If strZZDM.Trim <> "" Then
                        strSQL = ""
                        strSQL = "delete 考勤_B_补休表_产生 where 月份=@rq and 组织代码=@zzdm "

                        objSqlCommand.Parameters.Clear()
                        If strKSRQ <> "" Then
                            objSqlCommand.Parameters.AddWithValue("@rq", CType(strKSRQ, System.DateTime))
                        End If
                        objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.ExecuteNonQuery()

                        strSQL = ""
                        strSQL = strSQL + " insert into 考勤_B_补休表_产生(唯一标识,人员代码,组织代码,月份,天数)"
                        'strSQL = strSQL + " select newid(),b.人员代码,a.组织代码,@date,dbo.uf_kaoqin_getBuxiujia_summonth_01(@ksrq,b.人员代码,a.组织代码) from 公共_B_人员 a"
                        'strSQL = strSQL + " left join 考勤_B_考勤记录 b on a.人员代码=b.人员代码 where a.组织代码=@zzdm and b.日期 between @ksrq and  @jsrq"
                        strSQL = strSQL + " select newid(),a.人员代码,b.所属单位 as '组织代码',@date,dbo.uf_kaoqin_getBuxiujia_summonth_01(@ksrq,a.人员代码,b.所属单位) from "
                        strSQL = strSQL + " ("
                        strSQL = strSQL + " select distinct 人员代码 from 考勤_B_考勤记录 where 日期 between @ksrq and @jsrq "
                        strSQL = strSQL + " ) a "
                        strSQL = strSQL + " Left Join"
                        strSQL = strSQL + " ("
                        strSQL = strSQL + " select 人员代码,所属单位 from dbo.uf_estate_rs_getValidGuanliJiagou(@jsrq)"
                        strSQL = strSQL + " union"
                        strSQL = strSQL + " select 人员代码,所属单位 from dbo.uf_estate_rs_getValidZhuliJiagou(@jsrq) where 是否占编=1  "
                        strSQL = strSQL + " )b on a.人员代码=b.人员代码"

                        objSqlCommand.Parameters.Clear()
                        If strKSRQ <> "" Then
                            objSqlCommand.Parameters.AddWithValue("@ksrq", CType(strKSRQ, System.DateTime))
                        End If
                        If strJSRQ <> "" Then
                            objSqlCommand.Parameters.AddWithValue("@jsrq", CType(strJSRQ, System.DateTime))
                        End If
                        objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.ExecuteNonQuery()
                    Else
                        strSQL = ""
                        strSQL = "delete 考勤_B_补休表_产生 where 月份=@rq"

                        objSqlCommand.Parameters.Clear()
                        If strKSRQ <> "" Then
                            objSqlCommand.Parameters.AddWithValue("@rq", CType(strKSRQ, System.DateTime))
                        End If
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.ExecuteNonQuery()

                        strSQL = ""
                        strSQL = strSQL + " insert into 考勤_B_补休表_产生(唯一标识,人员代码,组织代码,月份,天数)"
                        strSQL = strSQL + " select newid(),a.人员代码,b.所属单位 as '组织代码',@ksrq,dbo.uf_kaoqin_getBuxiujia_summonth_01(@ksrq,a.人员代码,b.所属单位) from "
                        strSQL = strSQL + " ("
                        strSQL = strSQL + " select distinct 人员代码 from 考勤_B_考勤记录 where 日期 between @ksrq and @jsrq "
                        strSQL = strSQL + " ) a "
                        strSQL = strSQL + " Left Join"
                        strSQL = strSQL + " ("
                        strSQL = strSQL + " select 人员代码,所属单位 from dbo.uf_estate_rs_getValidGuanliJiagou(@jsrq)"
                        strSQL = strSQL + " union"
                        strSQL = strSQL + " select 人员代码,所属单位 from dbo.uf_estate_rs_getValidZhuliJiagou(@jsrq) where 是否占编=1  "
                        strSQL = strSQL + " )b on a.人员代码=b.人员代码"

                        objSqlCommand.Parameters.Clear()
                        If strKSRQ <> "" Then
                            objSqlCommand.Parameters.AddWithValue("@ksrq", CType(strKSRQ, System.DateTime))
                        End If
                        If strJSRQ <> "" Then
                            objSqlCommand.Parameters.AddWithValue("@jsrq", CType(strJSRQ, System.DateTime))
                        End If
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.ExecuteNonQuery()
                    End If

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
            doSet_BXJ = True
            Exit Function
rollback:
            objSqlTransaction.Rollback()
            GoTo errProc
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的补休假
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strZZDM                    ：组织代码
        '     objkqglkqjlData            ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataBuxiujia( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZZDM As String, _
            ByRef objkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Dim objTempkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String = ""

            '初始化
            getDataBuxiujia = False
            objTempkaoqinguanliData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""

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
                    objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_VT_BUXIUJIA)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select * from dbo.uf_kaoqin_getBuxiujia(@date,@zzdm) "
                        strSQL = strSQL + " order by 组织代码"

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@date", Now)
                        objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_BUXIUJIA))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempkaoqinguanliData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            objkaoqinguanliData = objTempkaoqinguanliData
            getDataBuxiujia = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的年休假完全数据的数据集(以“人员代码”降序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strNF                      ：年份
        '     strYF                      ：月份
        '     strZZDM                    ：组织代码
        '     objkqglkqjlData            ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataNianxiujia( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZZDM As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Dim objTempkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String = ""

            '初始化
            getDataNianxiujia = False
            objTempkaoqinguanliData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""

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
                    objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_VT_NIANXIUJIA)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select * from dbo.uf_kaoqin_getNiuxiujia(@nf,@zzdm) "
                        strSQL = strSQL + " order by 组织代码"

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@nf", Year(Now).ToString)
                        objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_NIANXIUJIA))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempkaoqinguanliData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            objkqglkqjlData = objTempkaoqinguanliData
            getDataNianxiujia = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 按指定的信息更新年休假
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doAdd_NXJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_KAOQINJILU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            Dim strRZSJ As String
            Dim intNXJ As Integer
            Dim intXW As Integer
            Dim strGXSJ As String
            Dim intCount As Integer
            Dim i As Integer
            Dim strNXJ As String
            Dim strNF As String
            Dim strRYDM As String
            Dim strKQJL As String

            '初始化
            doAdd_NXJ = False
            strErrMsg = ""

            Try

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取准备数据
                strRZSJ = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_NIANXIUJIA_RZSJ), "")
                strNXJ = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_NIANXIUJIA_NXJ), "")

                strNF = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_NIANXIUJIA_NF), "")
                strRYDM = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_NIANXIUJIA_RYDM), "")

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction()

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    If strNXJ.Trim <> "" Then
                        intNXJ = CInt(strNXJ)
                        '删除
                        strSQL = ""
                        strSQL = "delete 考勤_B_年休假 where 人员代码=@rydm and 年份=@nf"

                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                        objSqlCommand.Parameters.AddWithValue("@nf", strNF)
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.ExecuteNonQuery()

                        '插入
                        strSQL = ""
                        strSQL = "insert into 考勤_B_年休假 (唯一标识,人员代码,年份,年休假,更新时间,更新人员,入职时间) " + vbCr
                        strSQL = strSQL + "  values ( " + vbCr
                        strSQL = strSQL + "  newid(),@rydm,@nf,@nxj,@gxsj,@gxry,@rzsj) " + vbCr
                        objSqlCommand.Parameters.Clear()
                        If strGXSJ = "" Then
                            objSqlCommand.Parameters.AddWithValue("@rq", System.DBNull.Value)
                        Else
                            objSqlCommand.Parameters.AddWithValue("@rq", CType(strGXSJ, System.DateTime))
                        End If
                        objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                        objSqlCommand.Parameters.AddWithValue("@nf", strNF)
                        objSqlCommand.Parameters.AddWithValue("@nxj", intNXJ)
                        objSqlCommand.Parameters.AddWithValue("@gxsj", Now)
                        objSqlCommand.Parameters.AddWithValue("@gxry", strUserId)
                        If strRZSJ = "" Then
                            objSqlCommand.Parameters.AddWithValue("@rzsj", System.DBNull.Value)
                        Else
                            objSqlCommand.Parameters.AddWithValue("@rzsj", CType(strRZSJ, System.DateTime))
                        End If
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.ExecuteNonQuery()
                    End If

                    If strRZSJ <> "" Then
                        '插入
                        strSQL = ""
                        strSQL = "update 公共_B_人员 set 入职时间=@rq where 人员代码=@rydm"

                        objSqlCommand.Parameters.Clear()
                        If strRZSJ = "" Then
                            objSqlCommand.Parameters.AddWithValue("@rq", System.DBNull.Value)
                        Else
                            objSqlCommand.Parameters.AddWithValue("@rq", CType(strRZSJ, System.DateTime))
                        End If
                        objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.ExecuteNonQuery()
                    End If

                    

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
            doAdd_NXJ = True
            Exit Function
rollback:
            objSqlTransaction.Rollback()
            GoTo errProc
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function


        '----------------------------------------------------------------
        ' 按指定的信息更新年休假
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doUpdate_NXJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_KAOQINJILU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            Dim strYear As String
            Dim strRYDM As String


            '初始化
            doUpdate_NXJ = False
            strErrMsg = ""

            Try

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If
                strRYDM = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_NIANXIUJIA_RYDM), "")



                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction()

              
                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    strYear = Now.Year.ToString

                    '删除
                    strSQL = ""
                    strSQL = "delete 考勤_B_年休假 where 年份=@nf and 人员代码=@rydm"

                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@nf", strYear)
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()


                    '插入
                    strSQL = ""
                    strSQL = "insert into 考勤_B_年休假 (唯一标识,人员代码,入职时间,年份) " + vbCr
                    strSQL = strSQL + " select newid(),人员代码,入职时间,@nf from 公共_B_人员 where 是否有效=1 and 人员代码=@rydm and 是否考勤<>0 " + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@nf", strYear)
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '插入
                    strSQL = ""
                    strSQL = "update 考勤_B_年休假 set 更新时间=@gxsj,更新人员=@gxry,年休假=dbo.uf_kaoqin_compute_nxj(入职时间,@rq),有效期=dbo.uf_kaoqin_compute_yxq(入职时间,@rq) where 年份=@nf and 人员代码=@rydm "

                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@gxsj", Now)
                    objSqlCommand.Parameters.AddWithValue("@gxry", strUserId)
                    objSqlCommand.Parameters.AddWithValue("@rq", Now)
                    objSqlCommand.Parameters.AddWithValue("@nf", strYear)
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
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
            doUpdate_NXJ = True
            Exit Function
rollback:
            objSqlTransaction.Rollback()
            GoTo errProc
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function


        '----------------------------------------------------------------
        ' 按指定的信息更新年休假
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doUpdate_NXJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_KAOQINJILU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            Dim strYear As String


            '初始化
            doUpdate_NXJ = False
            strErrMsg = ""

            Try

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                
                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction()

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    strYear = Now.Year.ToString

                      '删除
                    strSQL = ""
                    strSQL = "delete 考勤_B_年休假 where 年份=@nf"

                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@nf", strYear)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    
                    '插入
                    strSQL = ""
                    strSQL = "insert into 考勤_B_年休假 (唯一标识,人员代码,入职时间,年份) " + vbCr
                    strSQL = strSQL + " select newid(),人员代码,入职时间,@nf from 公共_B_人员 where 是否有效=1  " + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@nf", strYear)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()
                    
                    '插入
                    strSQL = ""
                    strSQL = "update 考勤_B_年休假 set 更新时间=@gxsj,更新人员=@rydm,年休假=dbo.uf_kaoqin_compute_nxj(入职时间,@rq),有效期=dbo.uf_kaoqin_compute_yxq(入职时间,@rq) where 年份=@nf "

                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@gxsj", Now)
                    objSqlCommand.Parameters.AddWithValue("@rydm", strUserId)
                    objSqlCommand.Parameters.AddWithValue("@rq", Now)
                    objSqlCommand.Parameters.AddWithValue("@nf", strYear)
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
            doUpdate_NXJ = True
            Exit Function
rollback:
            objSqlTransaction.Rollback()
            GoTo errProc
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function





        '----------------------------------------------------------------
        ' 按指定的信息更新考勤记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doAdd_Kaoqinjilu( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_KAOQINJILU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            Dim strSJLX As String
            Dim intSJLX As Integer
            Dim intSw As Integer
            Dim intXW As Integer
            Dim strRQ As String
            Dim intCount As Integer
            Dim i As Integer
            Dim strKQDM As String
            Dim strZZDM As String
            Dim strRYDM As String
            Dim strKQJL As String

            '初始化
            doAdd_Kaoqinjilu = False
            strErrMsg = ""

            Try

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取准备数据
                Dim strBXYF As String = ""
                strRQ = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_RQ), "")
                strRQ = Mid(strRQ, 1, 4) + "-" + Mid(strRQ, 5, 2) + "-" + Mid(strRQ, 7, 2)
                strSJLX = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_SJLX), "")
                intSJLX = CInt(strSJLX)
                strKQDM = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_JLDM), "")
                strKQJL = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_KQJL), "")
                strZZDM = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_ZZDM), "")
                strRYDM = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_RYDM), "")



                '如果是补休的话，计算用的假期是那个月份的
                'If strKQDM = "101" Then
                '    Dim objDataSet As New System.Data.DataSet
                '    strSQL = ""
                '    strSQL = "select dbo.uf_kaoqin_getBuxiujia_month(convert(datetime," + Now.ToString + ")," + strRYDM + ") as 补休日期"
                '    If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                '        GoTo errProc
                '    End If

                '    '返回
                '    If objDataSet.Tables.Count > 0 Then
                '        If objDataSet.Tables(0).Rows.Count > 0 Then
                '            strBXYF = CType(objDataSet.Tables(0).Rows(0).Item(0), String)
                '        End If
                '    End If
                'End If

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction()

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '删除
                    strSQL = ""
                    strSQL = "delete 考勤_B_考勤记录 where 日期=@rq and 人员代码=@rydm and 组织代码=@zzdm and 时间类型=@sjlx"

                    objSqlCommand.Parameters.Clear()
                    If strRQ = "" Then
                        objSqlCommand.Parameters.AddWithValue("@rq", System.DBNull.Value)
                    Else
                        objSqlCommand.Parameters.AddWithValue("@rq", CType(strRQ, System.DateTime))
                    End If
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                    objSqlCommand.Parameters.AddWithValue("@sjlx", intSJLX)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    '插入
                    strSQL = ""
                    strSQL = "insert into 考勤_B_考勤记录 (唯一标识,日期,人员代码,组织代码,时间类型,记录代码,考勤记录,记录时间,记录人员,补休月份) " + vbCr
                    strSQL = strSQL + "  values ( " + vbCr
                    strSQL = strSQL + "  newid(),@rq,@rydm,@zzdm,@sjlx,@jldm,@kqjl,@jlsj,@jlry,@bxyf) " + vbCr
                    objSqlCommand.Parameters.Clear()
                    If strRQ = "" Then
                        objSqlCommand.Parameters.AddWithValue("@rq", System.DBNull.Value)
                    Else
                        objSqlCommand.Parameters.AddWithValue("@rq", CType(strRQ, System.DateTime))
                    End If
                    objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                    objSqlCommand.Parameters.AddWithValue("@sjlx", intSJLX)
                    objSqlCommand.Parameters.AddWithValue("@jldm", strKQDM)
                    objSqlCommand.Parameters.AddWithValue("@kqjl", strKQJL)
                    objSqlCommand.Parameters.AddWithValue("@jlsj", Now)
                    objSqlCommand.Parameters.AddWithValue("@jlry", strUserId)
                    If strBXYF = "" Then
                        objSqlCommand.Parameters.AddWithValue("@bxyf", System.DBNull.Value)
                    Else
                        objSqlCommand.Parameters.AddWithValue("@bxyf", CType(strBXYF, System.DateTime))
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
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
            doAdd_Kaoqinjilu = True
            Exit Function
rollback:
            objSqlTransaction.Rollback()
            GoTo errProc
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function


        '----------------------------------------------------------------
        '检查不能在两个以上的部门，在相同的日期也做了休假或者补休或者年假
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     blnMutilCheck        : 休息日、补休、年假、法定节假日检查=true else FALSE
        '     objNewData           ：检查数据
        '     blnExist             ：是否在其他部门已存在
        '     strBMMC              : 存在部门名称

        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doCheck_Kaoqinjilu( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal blnMutilCheck As Boolean, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByRef blnExist As Boolean, _
            ByRef strBMMC As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_KAOQINJILU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            Dim strSJLX As String
            Dim intSJLX As Integer
            Dim intSw As Integer
            Dim intXW As Integer
            Dim strRQ As String
            Dim intCount As Integer
            Dim i As Integer
            Dim strKQDM As String
            Dim strZZDM As String
            Dim strRYDM As String
            Dim strKQJL As String

            '初始化
            doCheck_Kaoqinjilu = False
            strErrMsg = ""

            Try

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取准备数据
                Dim strBXYF As String = ""
                strRQ = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_RQ), "")
                strRQ = Mid(strRQ, 1, 4) + "-" + Mid(strRQ, 5, 2) + "-" + Mid(strRQ, 7, 2)
                strSJLX = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_SJLX), "")
                intSJLX = CInt(strSJLX)
                strKQDM = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_JLDM), "")
                strKQJL = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_KQJL), "")
                strZZDM = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_ZZDM), "")
                strRYDM = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_RYDM), "")

                Dim objDataSet As New System.Data.DataSet
                strSQL = ""
                If blnMutilCheck = False Then
                    strSQL = "select distinct dbo.uf_gg_getZzmcByZzdm(组织代码) from 考勤_B_考勤记录 where 组织代码<>'" + strZZDM + "' and 日期=convert(datetime,'" + strRQ + "') and 人员代码='" + strRYDM + "' and 时间类型=convert(integer,'" + strSJLX + "') and 记录代码='" + strKQDM + "'"
                Else
                    strSQL = "select distinct dbo.uf_gg_getZzmcByZzdm(组织代码) from 考勤_B_考勤记录 where 组织代码<>'" + strZZDM + "' and 日期=convert(datetime,'" + strRQ + "') and 人员代码='" + strRYDM + "' and 时间类型=convert(integer,'" + strSJLX + "') and 记录代码 in ('100', '101', '102', '103')"
                End If

                If objdacCommon.getDataSetBySQL(strErrMsg, objSqlConnection, strSQL, objDataSet) = False Then
                    GoTo errProc
                End If

                '返回
                If objDataSet.Tables.Count > 0 Then
                    If objDataSet.Tables(0).Rows.Count > 0 Then
                        strBMMC = CType(objDataSet.Tables(0).Rows(0).Item(0), String)
                        blnExist = True
                    End If
                End If
               
            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
            doCheck_Kaoqinjilu = True
            Exit Function
rollback:
            objSqlTransaction.Rollback()
            GoTo errProc
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function


        End Function


        '----------------------------------------------------------------
        ' 按指定的信息更新考勤记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDelete_Kaoqinjilu( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_KAOQINJILU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            Dim strSJLX As String
            Dim intSJLX As Integer
            Dim intSw As Integer
            Dim intXW As Integer
            Dim strRQ As String
            Dim intCount As Integer
            Dim i As Integer
            Dim strKQDM As String
            Dim strZZDM As String
            Dim strRYDM As String
            Dim strKQJL As String

            '初始化
            doDelete_Kaoqinjilu = False
            strErrMsg = ""

            Try

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '获取准备数据
                strRQ = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_RQ), "")
                strRQ = Mid(strRQ, 1, 4) + "-" + Mid(strRQ, 5, 2) + "-" + Mid(strRQ, 7, 2)
                strSJLX = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_SJLX), "")

                strZZDM = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_ZZDM), "")
                strRYDM = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_KAOQINJILU_RYDM), "")

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction()

                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '删除
                    strSQL = ""
                    strSQL = "delete 考勤_B_考勤记录 where 日期=convert(datetime,'" + strRQ + "') and 人员代码='" + strRYDM + "' and 组织代码='" + strZZDM + "' and 时间类型=convert(int,'" + strSJLX + "') "

                    objSqlCommand.Parameters.Clear()
                    'If strRQ = "" Then
                    '    objSqlCommand.Parameters.AddWithValue("@rq", System.DBNull.Value)
                    'Else
                    '    objSqlCommand.Parameters.AddWithValue("@rq", CType(strRQ, System.DateTime))
                    'End If
                    'objSqlCommand.Parameters.AddWithValue("@rydm", strRYDM)
                    'objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                    'objSqlCommand.Parameters.AddWithValue("@sjlx", intSJLX)
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
            doDelete_Kaoqinjilu = True
            Exit Function
rollback:
            objSqlTransaction.Rollback()
            GoTo errProc
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function







        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的考勤记录完全数据的数据集(以“人员代码”降序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strNF                      ：年份
        '     strYF                      ：月份
        '     strZZDM                    ：组织代码
        '     objkqglkqjlData            ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSetKqjl_Main( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strNF As String, _
            ByVal strYF As String, _
            ByVal strZZDM As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Dim objTempkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String = ""


            '初始化
            getDataSetKqjl_Main = False
            objTempkaoqinguanliData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                Dim intTemp As Integer
                Dim temTime As DateTime
                temTime = CType(strNF + "-" + strYF + "-" + "01", System.DateTime)
                intTemp = CInt(DateDiff(DateInterval.Month, temTime, Now))

                '获取数据
                Try
                    '创建数据集
                    objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_VT_KAOQINJILU)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        If intTemp > 0 Then
                            strSQL = strSQL + "select * from dbo.uf_kaoqin_getKaoqinjilu_OLD(@NF,@YF,@zzdm) order by 类型,人员代码,时间类型 " + vbCr
                        Else
                            strSQL = strSQL + "select * from dbo.uf_kaoqin_getKaoqinjilu(@NF,@YF,@zzdm) order by 类型,人员代码,时间类型 " + vbCr
                        End If

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@NF", strNF)
                        objSqlCommand.Parameters.AddWithValue("@YF", strYF)
                        objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_KAOQINJILU))

                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempkaoqinguanliData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            objkqglkqjlData = objTempkaoqinguanliData
            getDataSetKqjl_Main = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function


        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的考勤记录完全数据的数据集(以“人员代码”降序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strNF                      ：年份
        '     strYF                      ：月份
        '     strZZDM                    ：组织代码
        '     objkqglkqjlData            ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSetKqjl_Print( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strNF As String, _
            ByVal strYF As String, _
            ByVal strZZDM As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Dim objTempkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String = ""


            '初始化
            getDataSetKqjl_Print = False
            objTempkaoqinguanliData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                Dim intTemp As Integer
                Dim temTime As DateTime
                Dim datPreviousMonth As DateTime
                Dim strPreviousMonthyear As String
                Dim strPreviousMonth As String

                temTime = CType(strNF + "-" + strYF + "-" + "01", System.DateTime)
                datPreviousMonth = DateAdd(DateInterval.Month, -1, temTime)
                strPreviousMonthyear = CType(Year(datPreviousMonth), String)
                strPreviousMonth = CType(Month(datPreviousMonth), String)
                intTemp = CInt(DateDiff(DateInterval.Month, temTime, Now))

                '获取数据
                Try
                    '创建数据集
                    objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_VT_KAOQINJILU)
                    'objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_VT_GONGZIBIAO)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout


                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        If intTemp > 0 Then
                            intTemp = 1
                        Else
                            intTemp = 0
                        End If

                        strSQL = strSQL + " select *,'' as '备注','' as '入离天数',''as '补休' from dbo.uf_kaoqin_getKaoqinjilu_Print(@NF,@YF,@zzdm,@intType) " + vbCr
                        strSQL = strSQL + " order by 类型,人员代码"

                        'strSQL = strSQL + " select * from dbo.uf_kaoqin_getKaoqinjilu_Print(@NF,@YF,@zzdm,@intType) " + vbCr
                        'strSQL = strSQL + " order by 类型,人员代码"

                        'strSQL = strSQL + " select a.* from dbo.uf_kaoqin_getKaoqinjilu_Print_bgs(@NF,@YF,@zzdm,@intType) a " + vbCr
                        'strSQL = strSQL + " left join 考勤_B_工资_单位排位 b on a.组织代码=b.组织代码 "
                        'strSQL = strSQL + " order by b.部门名称,a.类型2,职级代码,a.人员代码,a.类型"

                        'strSQL = strSQL + " select a.* from dbo.uf_kaoqin_getKaoqinjilu_GZ_2(@NF,@YF) a "
                        'strSQL = strSQL + " left join dbo.考勤_B_工资_单位排位 b "
                        'strSQL = strSQL + " on a.组织代码=b.组织代码 "
                        'strSQL = strSQL + "  order by b.部门名称,a.类型2,职级代码,a.人员代码,a.类型"

                        'strSQL = strSQL + " select a.*,c.上月工资 from dbo.uf_kaoqin_getKaoqinjilu_GZ_2(@NF,@YF) a "
                        'strSQL = strSQL + " left join dbo.考勤_B_工资_单位排位 b on a.组织代码=b.组织代码"
                        'strSQL = strSQL + " left join "
                        'strSQL = strSQL + " ("
                        'strSQL = strSQL + " select 人员代码,工资 as '上月工资' from dbo.uf_kaoqin_getKaoqinjilu_GZ_2(" + strPreviousMonthyear + "," + strPreviousMonth + ") where 人员代码 <>''"
                        'strSQL = strSQL + " )c on a.人员代码=c.人员代码 "
                        'strSQL = strSQL + " order by b.部门名称,a.类型2,a.职级代码,a.人员代码,a.类型"

                        'strSQL = strSQL + " select c.工作天数,a.*,c.职级名称,c.状态名称,工资标准,扣减天数,扣减工资,工资 from dbo.uf_kaoqin_getKaoqinjilu_Print_bgs(@NF,@YF,@zzdm,@intType) a "
                        'strSQL = strSQL + " left join 考勤_B_工资_单位排位 b on a.组织代码=b.组织代码 "
                        'strSQL = strSQL + " left join dbo.uf_kaoqin_getKaoqinjilu_GZ_2(@NF,@YF) c on a.组织代码=c.组织代码 and  a.人员代码=c.人员代码"
                        'strSQL = strSQL + " order by b.部门名称,a.人员代码,a.类型"

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@NF", strNF)
                        objSqlCommand.Parameters.AddWithValue("@YF", strYF)
                        objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                        objSqlCommand.Parameters.AddWithValue("@intType", intTemp)
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_KAOQINJILU))
                        '.Fill(objTempkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_GONGZIBIAO))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempkaoqinguanliData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            objkqglkqjlData = objTempkaoqinguanliData
            getDataSetKqjl_Print = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function





        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的全部考勤记录
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strNF                      ：年份
        '     strYF                      ：月份
        '     strZZDM                    ：组织代码
        '     objkqglkqjlData            ：信息数据集
        '     strAll                     :重载
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSetKqjl_Print( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strNF As String, _
            ByVal strYF As String, _
            ByVal strZZDM As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData, _
            ByVal strAll As String) As Boolean

            Dim objTempkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String = ""


            '初始化
            getDataSetKqjl_Print = False
            objTempkaoqinguanliData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                Dim intTemp As Integer
                Dim temTime As DateTime
                Dim datPreviousMonth As DateTime
                Dim strPreviousMonthyear As String
                Dim strPreviousMonth As String

                temTime = CType(strNF + "-" + strYF + "-" + "01", System.DateTime)
                datPreviousMonth = DateAdd(DateInterval.Month, -1, temTime)
                strPreviousMonthyear = CType(Year(datPreviousMonth), String)
                strPreviousMonth = CType(Month(datPreviousMonth), String)
                intTemp = CInt(DateDiff(DateInterval.Month, temTime, Now))

                '获取数据
                Try
                    '创建数据集
                    objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_VT_KAOQINJILU)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout


                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        If intTemp > 0 Then
                            intTemp = 1
                        Else
                            intTemp = 1
                        End If

                        strSQL = ""
                        strSQL = strSQL + " select * from ( "
                        strSQL = strSQL + " select c.*,排序=3 from ( "
                        strSQL = strSQL + " select a.*,b.部门名称 from gzcjxyDB_slb.dbo.uf_kaoqin_getKaoqinjilu_Print_bgs(@NF,@YF,@zzdm,@intType) a " + vbCr
                        strSQL = strSQL + " left join  gzcjxyDB_slb.dbo.考勤_B_工资_单位排位 b on a.组织代码=b.组织代码 "
                        strSQL = strSQL + " )c"
                        strSQL = strSQL + " )a"
                        strSQL = strSQL + " order by a.排序,a.部门名称,a.类型2,职级代码,a.人员代码,a.类型"

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@NF", strNF)
                        objSqlCommand.Parameters.AddWithValue("@YF", strYF)
                        objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                        objSqlCommand.Parameters.AddWithValue("@intType", intTemp)
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_KAOQINJILU))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempkaoqinguanliData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            objkqglkqjlData = objTempkaoqinguanliData
            getDataSetKqjl_Print = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的工资考勤记录
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strNF                      ：年份
        '     strYF                      ：月份
        '     strZZDM                    ：组织代码
        '     objkqglkqjlData            ：信息数据集
        '     intOption                  ：重载
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSetKqjl_Print( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strNF As String, _
            ByVal strYF As String, _
            ByVal strZZDM As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData, _
            ByVal intOption As Integer) As Boolean

            Dim objTempkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String = ""


            '初始化
            getDataSetKqjl_Print = False
            objTempkaoqinguanliData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                Dim intTemp As Integer
                Dim temTime As DateTime
                Dim datPreviousMonth As DateTime
                Dim strPreviousMonthyear As String
                Dim strPreviousMonth As String

                temTime = CType(strNF + "-" + strYF + "-" + "01", System.DateTime)
                datPreviousMonth = DateAdd(DateInterval.Month, -1, temTime)
                strPreviousMonthyear = CType(Year(datPreviousMonth), String)
                strPreviousMonth = CType(Month(datPreviousMonth), String)
                intTemp = CInt(DateDiff(DateInterval.Month, temTime, Now))

                '获取数据
                Try
                    '创建数据集
                    objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_VT_GONGZIBIAO)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout


                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        If intTemp > 0 Then
                            intTemp = 1
                        Else
                            intTemp = 1
                        End If

                        strSQL = ""
                        strSQL = strSQL + " select a.*,标准变化=case when 上月工资<>工资标准 then '本月工资标准有变化' else '' end  from ("
                        strSQL = strSQL + " select c.身份证号,c.用工模式,a.*,b.部门名称,gzcjxyDB_slb.dbo.uf_kaoqin_getGZBZFromRydm(@PreviousMonth,a.人员代码,a.组织代码) as '上月工资',排序=3 from gzcjxyDB_slb.dbo.uf_kaoqin_getKaoqinjilu_GZ_2(@NF,@YF) a "
                        strSQL = strSQL + " left join gzcjxyDB_slb.dbo.考勤_B_工资_单位排位 b on a.组织代码=b.组织代码"
                        strSQL = strSQL + " left join gzcjxyDB_slb.dbo.公共_b_人员 c on a.人员代码=c.人员代码"
                        strSQL = strSQL + " )a "
                        strSQL = strSQL + " order by a.排序,a.部门名称,a.类型2,a.职级代码,a.人员代码,a.类型"

                  
                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@PreviousMonth", datPreviousMonth)
                        objSqlCommand.Parameters.AddWithValue("@NF", strNF)
                        objSqlCommand.Parameters.AddWithValue("@YF", strYF)
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_GONGZIBIAO))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempkaoqinguanliData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            objkqglkqjlData = objTempkaoqinguanliData
            getDataSetKqjl_Print = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的全部考勤记录
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strNF                      ：年份
        '     strYF                      ：月份
        '     strStartDate               ：起始日期
        '     strEndDate                 ：结束日期
        '     strVacation                ：假期
        '     objkqglkqjlData            ：信息数据集
        '     strAll                     :重载
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSetKqjl_Print_DateInterval( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strNF As String, _
            ByVal strYF As String, _
            ByVal strStartDate As String, _
            ByVal strEndDate As String, _
            ByVal strVacation As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData, _
            ByVal strAll As String) As Boolean

            Dim objTempkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String = ""


            '初始化
            getDataSetKqjl_Print_DateInterval = False
            objTempkaoqinguanliData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                Dim intTemp As Integer
                Dim temTime As DateTime
                Dim datPreviousMonth As DateTime
                Dim strPreviousMonthyear As String
                Dim strPreviousMonth As String

                temTime = CType(strNF + "-" + strYF + "-" + "01", System.DateTime)
                datPreviousMonth = DateAdd(DateInterval.Month, -1, temTime)
                strPreviousMonthyear = CType(Year(datPreviousMonth), String)
                strPreviousMonth = CType(Month(datPreviousMonth), String)
                intTemp = CInt(DateDiff(DateInterval.Month, temTime, Now))

                '获取数据
                Try
                    '创建数据集
                    objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_VT_KAOQINJILU)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout


                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        If intTemp > 0 Then
                            intTemp = 1
                        Else
                            intTemp = 1
                        End If

                       
                        '时间段
                        strSQL = ""
                        strSQL = strSQL + " select * from ( "
                        strSQL = strSQL + " select c.*,排序=3 from ( "
                        strSQL = strSQL + " select a.*,b.部门名称 from gzcjxyDB_slb.dbo.uf_kaoqin_getKaoqinjilu_Print_bgs_interval(@NF,@YF,@ksrq,@jsrq,@intVacation) a " + vbCr
                        strSQL = strSQL + " left join  gzcjxyDB_slb.dbo.考勤_B_工资_单位排位 b on a.组织代码=b.组织代码 "
                        strSQL = strSQL + " )c"
                        strSQL = strSQL + " )a"
                        strSQL = strSQL + " order by a.排序,a.部门名称,a.类型2,职级代码,a.人员代码,a.类型"

                        Dim datStart As DateTime
                        Dim datEnd As DateTime
                        Dim dblintVacation As Double

                        'datStart = CType("2013-01-26", System.DateTime)
                        'datEnd = CType("2013-02-28", System.DateTime)
                        'dblintVacation = CType("11", System.Double)

                        datStart = CType(strStartDate, System.DateTime)
                        datEnd = CType(strEndDate, System.DateTime)
                        dblintVacation = CType(strVacation, System.Double)


                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@NF", strNF)
                        objSqlCommand.Parameters.AddWithValue("@YF", strYF)
                        objSqlCommand.Parameters.AddWithValue("@ksrq", datStart)
                        objSqlCommand.Parameters.AddWithValue("@jsrq", datEnd)
                        objSqlCommand.Parameters.AddWithValue("@intVacation", dblintVacation)
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_KAOQINJILU))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempkaoqinguanliData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            objkqglkqjlData = objTempkaoqinguanliData
            getDataSetKqjl_Print_DateInterval = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 获取strUserXM能够查看的工资考勤记录
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strNF                      ：年份
        '     strYF                      ：月份
        '     strStartDate               ：起始日期
        '     strEndDate                 ：结束日期
        '     strVacation                ：假期       
        '     objkqglkqjlData            ：信息数据集
        '     intOption                  ：重载
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSetKqjl_Print_DateInterval( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strNF As String, _
            ByVal strYF As String, _
            ByVal strStartDate As String, _
            ByVal strEndDate As String, _
            ByVal strVacation As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData, _
            ByVal intOption As Integer) As Boolean

            Dim objTempkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String = ""


            '初始化
            getDataSetKqjl_Print_DateInterval = False
            objTempkaoqinguanliData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                Dim intTemp As Integer
                Dim temTime As DateTime
                Dim datPreviousMonth As DateTime
                Dim strPreviousMonthyear As String
                Dim strPreviousMonth As String

                temTime = CType(strNF + "-" + strYF + "-" + "01", System.DateTime)
                datPreviousMonth = DateAdd(DateInterval.Month, -1, temTime)
                strPreviousMonthyear = CType(Year(datPreviousMonth), String)
                strPreviousMonth = CType(Month(datPreviousMonth), String)
                intTemp = CInt(DateDiff(DateInterval.Month, temTime, Now))

                '获取数据
                Try
                    '创建数据集
                    objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_VT_GONGZIBIAO)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout


                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        If intTemp > 0 Then
                            intTemp = 1
                        Else
                            intTemp = 1
                        End If

                        strSQL = ""
                        strSQL = strSQL + " select a.*,标准变化=case when 上月工资<>工资标准 then '本月工资标准有变化' else '' end  from ("
                        strSQL = strSQL + " select '' as 身份证号,a.*,b.部门名称,gzcjxyDB_slb.dbo.uf_kaoqin_getGZBZFromRydm(@PreviousMonth,a.人员代码,a.组织代码) as '上月工资',排序=3 from gzcjxyDB_slb.dbo.uf_kaoqin_getKaoqinjilu_GZ_2_interval(@NF,@YF,@ksrq,@jsrq,@intVacation) a "
                        strSQL = strSQL + " left join gzcjxyDB_slb.dbo.考勤_B_工资_单位排位 b on a.组织代码=b.组织代码"
                        strSQL = strSQL + " )a "
                        strSQL = strSQL + " order by a.排序,a.部门名称,a.类型2,a.职级代码,a.人员代码,a.类型"

                        Dim datStart As DateTime
                        Dim datEnd As DateTime
                        Dim dblintVacation As Double

                        'datStart = CType("2013-01-26", System.DateTime)
                        'datEnd = CType("2013-02-28", System.DateTime)
                        'dblintVacation = CType("11", System.Double)

                        datStart = CType(strStartDate, System.DateTime)
                        datEnd = CType(strEndDate, System.DateTime)
                        dblintVacation = CType(strVacation, System.Double)


                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        objSqlCommand.Parameters.AddWithValue("@PreviousMonth", datPreviousMonth)
                        objSqlCommand.Parameters.AddWithValue("@NF", strNF)
                        objSqlCommand.Parameters.AddWithValue("@YF", strYF)
                        objSqlCommand.Parameters.AddWithValue("@ksrq", datStart)
                        objSqlCommand.Parameters.AddWithValue("@jsrq", datEnd)
                        objSqlCommand.Parameters.AddWithValue("@intVacation", dblintVacation)
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_VT_GONGZIBIAO))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempkaoqinguanliData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            objkqglkqjlData = objTempkaoqinguanliData
            getDataSetKqjl_Print_DateInterval = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function






















        '----------------------------------------------------------------
        ' 获取“考勤_B_考勤类型”的SQL语句(以考勤类型代码升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getKaoqingleixingSQL() As String
            getKaoqingleixingSQL = "select * from 考勤_B_考勤类型 order by 考勤类型代码"
        End Function

        '----------------------------------------------------------------
        ' 获取“考勤_B_考勤类型”完全数据的数据集(以考勤类型代码升序排序)
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWhere             ：搜索字符串
        '     objKaoqinguanliData：信息数据集
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getKaoqingleixingData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objKaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objTempKaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand

            '初始化
            getKaoqingleixingData = False
            objKaoqinguanliData = Nothing
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
                Dim strSQL As String
                Try
                    '创建数据集
                    objTempKaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.B_KQ_KAOQINLEXING)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.* " + vbCr
                        strSQL = strSQL + " from 考勤_B_考勤类型 a " + vbCr
                        If strWhere <> "" Then
                            strSQL = strSQL + " where " + strWhere + vbCr
                        End If
                        strSQL = strSQL + " order by a.考勤类型代码 " + vbCr

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempKaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_B_KQ_KAOQINLEXING))
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempKaoqinguanliData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempKaoqinguanliData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
            objKaoqinguanliData = objTempKaoqinguanliData
            getKaoqingleixingData = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempKaoqinguanliData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 检查“考勤_B_考勤类型”的数据的合法性
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
        Public Function doVerifyKaoqingleixingData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet
            Dim objListDictionary As System.Collections.Specialized.ListDictionary

            doVerifyKaoqingleixingData = False

            Try
                Dim strOldKHLXDM As String
                Dim strKHLXDM As String
                Dim strKHLXMC As String
                Dim intLen As Integer
                Dim strSQL As String

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
                        strOldKHLXDM = objPulicParameters.getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_DM), "")
                End Select

                '获取表结构定义
                strSQL = "select top 0 * from 考勤_B_考勤类型"
                If objdacCommon.getDataSetWithSchemaBySQL(strErrMsg, strUserId, strPassword, strSQL, "考勤_B_考勤类型", objDataSet) = False Then
                    GoTo errProc
                End If

                '检查数据长度
                strKHLXDM = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_DM), "")
                If strKHLXDM = "" Then
                    strErrMsg = "错误：[考勤类型代码]不能为空！"
                    GoTo errProc
                End If
                With objDataSet.Tables(0).Columns(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_DM)
                    intLen = objPulicParameters.getStringLength(strKHLXDM)
                    If intLen > .MaxLength Then
                        strErrMsg = "错误：[考勤类型代码]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
                        GoTo errProc
                    End If
                End With

                strKHLXMC = objPulicParameters.getObjectValue(objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_MC), "")
                If strKHLXMC = "" Then
                    strErrMsg = "错误：[考勤类型名称]不能为空！"
                    GoTo errProc
                End If
                With objDataSet.Tables(0).Columns(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_MC)
                    intLen = objPulicParameters.getStringLength(strKHLXMC)
                    If intLen > .MaxLength Then
                        strErrMsg = "错误：[考勤类型名称]长度不能超过[" + .MaxLength.ToString() + "]，实际有[" + intLen.ToString() + "]！"
                        GoTo errProc
                    End If
                End With

                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objDataSet = Nothing

                '检查约束
                objListDictionary = New System.Collections.Specialized.ListDictionary
                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 考勤_B_考勤类型 where 考勤类型代码 = @KHLXDM"
                        objListDictionary.Add("@KHLXDM", strKHLXDM)
                    Case Else
                        strSQL = "select * from 考勤_B_考勤类型 where 考勤类型代码 = @KHLXDM and 考勤类型代码 <> @oldKHLXDM"
                        objListDictionary.Add("@KHLXDM", strKHLXDM)
                        objListDictionary.Add("@oldKHLXDM", strOldKHLXDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strKHLXDM + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objDataSet = Nothing
                objListDictionary.Clear()

                Select Case objenumEditType
                    Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                        strSQL = "select * from 考勤_B_考勤类型 where 考勤类型名称 = @KHLXMC"
                        objListDictionary.Add("@KHLXMC", strKHLXMC)
                    Case Else
                        strSQL = "select * from 考勤_B_考勤类型 where 考勤类型名称 = @KHLXMC and 考勤类型代码 <> @oldKHLXDM"
                        objListDictionary.Add("@KHLXMC", strKHLXMC)
                        objListDictionary.Add("@oldKHLXDM", strOldKHLXDM)
                End Select
                If objdacCommon.getDataSetBySQL(strErrMsg, strUserId, strPassword, strSQL, objListDictionary, objDataSet) = False Then
                    GoTo errProc
                End If
                If objDataSet.Tables(0).Rows.Count > 0 Then
                    strErrMsg = "错误：[" + strKHLXMC + "]已经存在！"
                    GoTo errProc
                End If
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
                objDataSet = Nothing
                objListDictionary.Clear()
                Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            doVerifyKaoqingleixingData = True
            Exit Function
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objListDictionary)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存“考勤_B_考勤类型”的数据
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
        Public Function doSaveKaoqingleixingData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand

            '初始化
            doSaveKaoqingleixingData = False
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""

                '检查
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
                Dim strSQL As String
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
                    Dim strOldKHLXDM As String
                    Dim strKHLXDM As String
                    Dim strKHLXMC As String
                    strKHLXDM = objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_DM)
                    strKHLXMC = objNewData(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_MC)
                    Select Case objenumEditType
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew
                            strSQL = ""
                            strSQL = strSQL + " insert into 考勤_B_考勤类型 (考勤类型代码,考勤类型名称)"
                            strSQL = strSQL + " values (@KHLXDM, @KHLXMC)"
                            objSqlCommand.Parameters.Clear()
                            objSqlCommand.Parameters.AddWithValue("@KHLXDM", strKHLXDM)
                            objSqlCommand.Parameters.AddWithValue("@KHLXMC", strKHLXMC)
                        Case Else
                            With New Josco.JsKernal.Common.Utilities.PulicParameters
                                strOldKHLXDM = .getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_DM), "")
                            End With
                            strSQL = ""
                            strSQL = strSQL + " update 考勤_B_考勤类型 set "
                            strSQL = strSQL + "   考勤类型代码 = @KHLXDM,"
                            strSQL = strSQL + "   考勤类型名称 = @KHLXMC"
                            strSQL = strSQL + " where 考勤类型代码 = @oldKHLXDM"
                            objSqlCommand.Parameters.Clear()
                            objSqlCommand.Parameters.AddWithValue("@KHLXDM", strKHLXDM)
                            objSqlCommand.Parameters.AddWithValue("@KHLXMC", strKHLXMC)
                            objSqlCommand.Parameters.AddWithValue("@oldKHLXDM", strOldKHLXDM)
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
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
            doSaveKaoqingleixingData = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 删除“考勤_B_考勤类型”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteKaoqingleixingData( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean

            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand

            '初始化
            doDeleteKaoqingleixingData = False
            strErrMsg = ""

            Try
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""

                '检查
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
                Dim strSQL As String
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '计算SQL
                    Dim strOldKHLXDM As String
                    With New Josco.JsKernal.Common.Utilities.PulicParameters
                        strOldKHLXDM = .getObjectValue(objOldData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_B_KQ_KAOQINLEXING_DM), "")
                    End With
                    strSQL = ""
                    strSQL = strSQL + " delete from 考勤_B_考勤类型 "
                    strSQL = strSQL + " where 考勤类型代码 = @oldKHLXDM"
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@oldKHLXDM", strOldKHLXDM)

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
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            '返回
            doDeleteKaoqingleixingData = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 保存记录
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objSqlTransaction      ：现有事务
        '     objNewData             ：记录新值(返回保存后的新值)
        '     strPriKeyName          ：表的主键名   
        '     strPriKeyValue         ：更新的主键的值
        '     strTable               ：更新的表名
        '     objenumEditType        ：编辑类型
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doSaveRecord( _
            ByRef strErrMsg As String, _
            ByVal objSqlTransaction As System.Data.SqlClient.SqlTransaction, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal strPriKeyName As String, _
            ByVal strPriKeyValue As String, _
            ByVal strTable As String, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean

            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim blnNewTrans As Boolean = False
            Dim strSQL As String

            '初始化
            doSaveRecord = False
            strErrMsg = ""

            Try
                '检查               
                If objNewData Is Nothing Then
                    strErrMsg = "错误：[doSaveRecord]未传入新的数据！"
                    GoTo errProc
                End If

                '获取现有信息
                If objSqlTransaction Is Nothing Then
                    objSqlConnection = objSqlTransaction.Connection
                End If

                '开始事务
                If objSqlTransaction Is Nothing Then
                    blnNewTrans = True
                    objSqlTransaction = objSqlConnection.BeginTransaction()
                Else
                    blnNewTrans = False
                End If

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
                        Case Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eAddNew, _
                            Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType.eCpyNew
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
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
                            Next

                            strSQL = ""
                            strSQL = strSQL + " insert into " + strTable + " (" + strFileds + ")"
                            strSQL = strSQL + " values (" + strValues + ")"

                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    '整型转换
                                    Case "整数"
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), 0)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), Integer))
                                        End If
                                        '日期转换
                                    Case "日期"
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), System.DateTime))
                                        End If

                                    Case Else
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), " ")
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), objNewData.Item(i))
                                        End If
                                End Select
                            Next

                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()

                        Case Else
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                If strFileds = "" Then
                                    strFileds = objNewData.GetKey(i) + " = @A" + i.ToString()
                                Else
                                    strFileds = strFileds + "," + objNewData.GetKey(i) + " = @A" + i.ToString()
                                End If
                            Next

                            strSQL = ""
                            strSQL = strSQL + " update " + strTable + " set "
                            strSQL = strSQL + "   " + strFileds
                            strSQL = strSQL + " where " + strPriKeyName + " = @oldwjbs"

                            objSqlCommand.Parameters.Clear()
                            intCount = objNewData.Count
                            For i = 0 To intCount - 1 Step 1
                                Select Case objNewData.GetKey(i)
                                    '整型转换
                                    Case "整数"
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), 0)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), Integer))
                                        End If
                                        '日期转换
                                    Case "日期"
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), System.DBNull.Value)
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), CType(objNewData.Item(i), System.DateTime))
                                        End If

                                    Case Else
                                        If objNewData.Item(i) = "" Then
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), " ")
                                        Else
                                            objSqlCommand.Parameters.AddWithValue("@A" + i.ToString(), objNewData.Item(i))
                                        End If
                                End Select
                            Next
                            objSqlCommand.Parameters.AddWithValue("@oldwjbs", strPriKeyValue)

                            objSqlCommand.CommandText = strSQL
                            objSqlCommand.ExecuteNonQuery()
                    End Select

                Catch ex As Exception
                    If blnNewTrans = True Then
                        objSqlTransaction.Rollback()
                    End If
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try

                '提交事务
                If blnNewTrans = True Then
                    objSqlTransaction.Commit()
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            doSaveRecord = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function


        '----------------------------------------------------------------
        ' 获取查看有职级变动的应休假标准
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     objkqglkqjlData            ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_KQZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objkqglkqjlData As Josco.JSOA.Common.Data.kaoqinguanliData) As Boolean

            Dim objTempkaoqinguanliData As Josco.JSOA.Common.Data.kaoqinguanliData = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand
            Dim strSQL As String = ""

            '初始化
            getDataSet_KQZJ = False
            objTempkaoqinguanliData = Nothing
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""

                '检查
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If

                '创建数据集
                objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_VT_YUEYINGXIUJIA)

                '创建SqlCommand
                objSqlCommand = New System.Data.SqlClient.SqlCommand
                objSqlCommand.Connection = objSqlConnection
                objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

             

                '获取数据
                Try
                    '创建数据集
                    objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI)
                    '创建数据集
                    'objTempkaoqinguanliData = New Josco.JSOA.Common.Data.kaoqinguanliData(Josco.JSOA.Common.Data.kaoqinguanliData.enumTableType.KQ_VT_YUEYINGXIUJIA)

                    '创建SqlCommand
                    objSqlCommand = New System.Data.SqlClient.SqlCommand
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '执行检索
                    With Me.m_objSqlDataAdapter
                        Dim strYear As String
                        strYear = Year(Now).ToString

                        '准备SQL
                        strSQL = ""
                        strSQL = strSQL + " select a.*,b.组织名称,c.职级名称 from 考勤_B_休假_标准变化_职级 a "
                        strSQL = strSQL + " left join 公共_B_组织机构 b on a.组织代码=b.组织代码 "
                        strSQL = strSQL + " left join 地产_B_人事_职级定义 c on a.职级代码=c.职级代码 "
                        strSQL = strSQL + " order by a.组织代码,a.职级代码,标准序列 "

                        '设置参数
                        objSqlCommand.CommandText = strSQL
                        objSqlCommand.Parameters.Clear()
                        .SelectCommand = objSqlCommand

                        '执行操作
                        .Fill(objTempkaoqinguanliData.Tables(Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI))
                       
                    End With
                Catch ex As Exception
                    strErrMsg = ex.Message
                    GoTo errProc
                End Try
                If objTempkaoqinguanliData.Tables.Count < 1 Then
                    Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
                End If

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)

            '返回
            objkqglkqjlData = objTempkaoqinguanliData
            getDataSet_KQZJ = True
            Exit Function

errProc:
            Josco.JSOA.Common.Data.kaoqinguanliData.SafeRelease(objTempkaoqinguanliData)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Exit Function

        End Function

        '----------------------------------------------------------------
        ' 更新指定的单位的职级应休假标准
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：更新数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doUpdate_YXJ_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_KAOQINJILU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            Dim strTime As String
            Dim strZZDM As String = ""
            Dim strZJDM As String = ""
            Dim strBZ As String
            Dim intBZ As Integer
            Dim objBDSJ As System.DateTime

            '初始化
            doUpdate_YXJ_ZJ = False
            strErrMsg = ""

            Try

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If
                strZZDM = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_ZZDM), "")
                strZJDM = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_ZJDM), "")
                strTime = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_KSSJ), "")
                objBDSJ = CType(strTime, System.DateTime)
                strBZ = objPulicParameters.getObjectValue(objNewData.Item(Josco.JSOA.Common.Data.kaoqinguanliData.FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_BZXL), "")
                intBZ = CType(strBZ, Integer)

                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction()


                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    '注销“考勤_B_休假_标准变化_职级”
                    strSQL = ""
                    strSQL = strSQL + " update 考勤_B_休假_标准变化_职级 set " + vbCr
                    strSQL = strSQL + "   失效时间 = dateadd(ss,-1,@kssj)" + vbCr
                    strSQL = strSQL + " where 职级代码 = @zjdm" + vbCr
                    strSQL = strSQL + " and   组织代码 = @zzdm" + vbCr
                    strSQL = strSQL + " and   失效时间 is null" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@kssj", objBDSJ)
                    objSqlCommand.Parameters.AddWithValue("@zjdm", strZJDM)
                    objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                    objSqlCommand.CommandText = strSQL
                    objSqlCommand.ExecuteNonQuery()

                    strSQL = ""
                    strSQL = strSQL + " insert into 考勤_B_休假_标准变化_职级 (" + vbCr
                    strSQL = strSQL + "   标准标识," + vbCr
                    strSQL = strSQL + "   标准序列," + vbCr
                    strSQL = strSQL + "   职级代码," + vbCr
                    strSQL = strSQL + "   组织代码," + vbCr
                    strSQL = strSQL + "   生效时间" + vbCr
                    strSQL = strSQL + " ) values (" + vbCr
                    strSQL = strSQL + "   newid()," + vbCr
                    strSQL = strSQL + "   @bzxl," + vbCr
                    strSQL = strSQL + "   @zjdm," + vbCr
                    strSQL = strSQL + "   @zzdm," + vbCr
                    strSQL = strSQL + "   @kssj" + vbCr
                    strSQL = strSQL + " ) " + vbCr

                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@kssj", objBDSJ)
                    objSqlCommand.Parameters.AddWithValue("@zjdm", strZJDM)
                    objSqlCommand.Parameters.AddWithValue("@zzdm", strZZDM)
                    objSqlCommand.Parameters.AddWithValue("@bzxl", intBZ)
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
            doUpdate_YXJ_ZJ = True
            Exit Function
rollback:
            objSqlTransaction.Rollback()
            GoTo errProc
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function


        '----------------------------------------------------------------
        ' 删除指定的单位的职级应休假标准
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strBZBS              ：标准标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDelete_YXJ_ZJ( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strBZBS As String) As Boolean

            Dim strTable As String = Josco.JSOA.Common.Data.kaoqinguanliData.TABLE_KQ_B_KAOQINJILU
            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objSqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim objSqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim objSqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim strSQL As String = ""

            Dim strTime As String
            Dim strZZDM As String = ""
            Dim strZJDM As String = ""
            Dim strBZ As String
            Dim intBZ As Integer
            Dim objBDSJ As System.DateTime

            '初始化
            doDelete_YXJ_ZJ = False
            strErrMsg = ""

            Try

                '获取连接
                If objdacCommon.getConnection(strErrMsg, strUserId, strPassword, objSqlConnection) = False Then
                    GoTo errProc
                End If
               
                '开始事务
                objSqlTransaction = objSqlConnection.BeginTransaction()


                '保存数据
                Try
                    objSqlCommand = objSqlConnection.CreateCommand()
                    objSqlCommand.Connection = objSqlConnection
                    objSqlCommand.Transaction = objSqlTransaction
                    objSqlCommand.CommandTimeout = Josco.JsKernal.Common.jsoaConfiguration.CommandTimeout

                    'delete“考勤_B_休假_标准变化_职级”
                    strSQL = ""
                    strSQL = strSQL + " delete 考勤_B_休假_标准变化_职级  " + vbCr
                    strSQL = strSQL + " where 标准标识 = @bsbz" + vbCr
                    objSqlCommand.Parameters.Clear()
                    objSqlCommand.Parameters.AddWithValue("@bsbz", strBZBS)
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
            doDelete_YXJ_ZJ = True
            Exit Function
rollback:
            objSqlTransaction.Rollback()
            GoTo errProc
errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlConnection)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objSqlCommand)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function

        '----------------------------------------------------------------
        '某月的人员应有假期是多少天
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strRydm                   ：人员代码
        '     sttZzdm                   ：部门代码
        '     strDate                   ：月份日期
        '     fltDay                    : 假期天数（返回）
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getMonthVacation( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRydm As String, _
            ByVal strZzdm As String, _
            ByVal strDate As String, _
            ByRef dblDay As Double) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getMonthVacation = False
            strErrMsg = ""
            dblDay = 0

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If


                '计算
                strSQL = "select dbo.uf_kaoqin_getVacation_Over('" + strRydm + "','" + strZzdm + "',convert(datetime,'" + strDate + "'))"
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
                    dblDay = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), 0)
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getMonthVacation = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function


        '----------------------------------------------------------------
        '某月的人员某个考勤有多少天
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strRydm                   ：人员代码
        '     strJldm                   ：记录代码
        '     strDate                   ：月份日期
        '     fltDay                    : 假期天数（返回）
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getMonthKaoqin( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRydm As String, _
            ByVal strJldm As String, _
            ByVal strDate As String, _
            ByRef dblDay As Double) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getMonthKaoqin = False
            strErrMsg = ""
            dblDay = 0

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If


                '计算
                strSQL = "select dbo.uf_kaoqin_getkqjl_Use('" + strRydm + "',convert(datetime,'" + strDate + "'),'" + strJldm + "')"
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
                    dblDay = objPulicParameters.getObjectValue(.Tables(0).Rows(0).Item(0), 0.0)
                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getMonthKaoqin = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function


        '----------------------------------------------------------------
        '检查当前日期当前人是否在本部门
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strRydm                   ：人员代码
        '     strZZDM                   ：组织代码
        '     strRQ                     ：日期
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getMonthKaoqin( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRydm As String, _
            ByVal strZZDM As String, _
            ByVal strRQ As String) As Boolean

            Dim objPulicParameters As New Josco.JsKernal.Common.Utilities.PulicParameters
            Dim objdacCommon As New Josco.JsKernal.DataAccess.dacCommon
            Dim objDataSet As System.Data.DataSet = Nothing
            Dim strSQL As String = ""

            getMonthKaoqin = False
            strErrMsg = ""

            Try
                '检查
                If strUserId Is Nothing Then strUserId = ""
                If strPassword Is Nothing Then strPassword = ""
                If strUserId.Trim = "" Then
                    strErrMsg = "错误：未指定要获取信息的用户！"
                    GoTo errProc
                End If


                '计算'
                strSQL = ""
                strSQL = strSQL + " select * from "
                strSQL = strSQL + " ("
                strSQL = strSQL + " select 人员代码,职级代码 from uf_estate_rs_getValidZhuliJiagou(@rq) where 人员代码=@rydm and 所属单位=@zzdm"
                strSQL = strSQL + " union "
                strSQL = strSQL + " select 人员代码,职级代码 from uf_estate_rs_getValidZhuliJiagou(@rq)  where 人员代码=@rydm and 所属单位=@zzdm"
                strSQL = strSQL + " ) a  "
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

                End With

            Catch ex As Exception
                strErrMsg = ex.Message
                GoTo errProc
            End Try

            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)

            getMonthKaoqin = True
            Exit Function

errProc:
            Josco.JsKernal.Common.Utilities.PulicParameters.SafeRelease(objPulicParameters)
            Josco.JsKernal.Common.Utilities.ResourceManager.SafeRelease(objDataSet)
            Josco.JsKernal.DataAccess.dacCommon.SafeRelease(objdacCommon)
            Exit Function

        End Function
    End Class
End Namespace
