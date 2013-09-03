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
Imports System.Runtime.Serialization

Namespace Josco.JSOA.Common.Data

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.Common.Data
    ' 类名    ：estateCommonData
    '
    ' 功能描述：
    '     定义与通用地产管理相关表的数据访问格式
    '----------------------------------------------------------------
    <System.ComponentModel.DesignerCategory("ESTATE-COMMON"), SerializableAttribute()> Public Class estateCommonData
        Inherits System.Data.DataSet

        '“地产_B_公共_税费目录”表信息定义
        '表名称
        Public Const TABLE_DC_B_GG_SHUIFEIMULU As String = "地产_B_公共_税费目录"
        '字段序列
        Public Const FIELD_DC_B_GG_SHUIFEIMULU_SFDM As String = "税费代码"
        Public Const FIELD_DC_B_GG_SHUIFEIMULU_SFMC As String = "税费名称"
        '约束错误信息
        '显示字段序列

        '“地产_B_公共_应收应付模版”表信息定义
        '表名称
        Public Const TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN As String = "地产_B_公共_应收应付模版"
        '字段序列
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM As String = "模版代码"
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBMC As String = "模版名称"
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFDM As String = "税费代码"
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFDX As String = "收付对象"
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFBZ As String = "收付标志"
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMX As String = "是否明细"
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMC As String = "税费名称"
        Public Const FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMXMC As String = "是否明细名称"

        '“地产_B_公共_物业间隔”表信息定义
        '表名称
        Public Const TABLE_DC_B_GG_WUYEJIANGE As String = "地产_B_公共_物业间隔"
        '字段序列
        Public Const FIELD_DC_B_GG_WUYEJIANGE_WYJGDM As String = "间隔代码"
        Public Const FIELD_DC_B_GG_WUYEJIANGE_WYJGMC As String = "间隔名称"
        '约束错误信息
        '显示字段序列

        '“地产_B_公共_物业性质”表信息定义
        '表名称
        Public Const TABLE_DC_B_GG_WUYEXINGZHI As String = "地产_B_公共_物业性质"
        '字段序列
        Public Const FIELD_DC_B_GG_WUYEXINGZHI_WYXZDM As String = "性质代码"
        Public Const FIELD_DC_B_GG_WUYEXINGZHI_WYXZMC As String = "性质名称"
        'zengxianglin 2010-12-21
        Public Const FIELD_DC_B_GG_WUYEXINGZHI_SFQY As String = "是否启用"
        Public Const FIELD_DC_B_GG_WUYEXINGZHI_XSSX As String = "显示顺序"
        'zengxianglin 2010-12-21
        '约束错误信息
        '显示字段序列

        '“地产_B_公共_区域划分”表信息定义
        '表名称
        Public Const TABLE_DC_B_GG_QUYUHUAFEN As String = "地产_B_公共_区域划分"
        '字段序列
        Public Const FIELD_DC_B_GG_QUYUHUAFEN_QYDM As String = "区域代码"
        Public Const FIELD_DC_B_GG_QUYUHUAFEN_QYMC As String = "区域名称"
        '约束错误信息
        '显示字段序列

        'zengxianglin 2008-11-18
        '“地产_B_公共_办案项目”表信息定义
        '表名称
        Public Const TABLE_DC_B_GG_BAXM As String = "地产_B_公共_办案项目"
        '字段序列
        Public Const FIELD_DC_B_GG_BAXM_XMDM As String = "项目代码"
        Public Const FIELD_DC_B_GG_BAXM_XMMC As String = "项目名称"
        '约束错误信息
        '显示字段序列
        'zengxianglin 2008-11-18









        '定义初始化表类型enum
        Public Enum enumTableType
            DC_B_GG_SHUIFEIMULU = 1
            DC_B_GG_YINGSHOUYINGFUMOBAN = 2

            DC_B_GG_WUYEJIANGE = 3
            DC_B_GG_WUYEXINGZHI = 4

            DC_B_GG_QUYUHUAFEN = 5

            'zengxianglin 2008-11-18
            DC_B_GG_BAXM = 6
            'zengxianglin 2008-11-18
        End Enum










        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub

        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
        End Sub

        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New(ByVal objenumTableType As enumTableType)
            MyBase.New()
            Try
                Dim objDataTable As System.Data.DataTable
                Dim strErrMsg As String
                objDataTable = Me.createDataTables(strErrMsg, objenumTableType)
                If Not (objDataTable Is Nothing) Then
                    Me.Tables.Add(objDataTable)
                End If
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' 安全释放本身资源
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.Common.Data.estateCommonData)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub








        '----------------------------------------------------------------
        ' 专用列表
        '----------------------------------------------------------------









        '----------------------------------------------------------------
        '将给定DataTable加入到DataSet中
        '----------------------------------------------------------------
        Public Function appendDataTable(ByVal table As System.Data.DataTable) As String

            Dim strErrMsg As String = ""

            Try
                Me.Tables.Add(table)
            Catch ex As Exception
                strErrMsg = ex.Message
            End Try

            appendDataTable = strErrMsg

        End Function

        '----------------------------------------------------------------
        '根据指定类型创建dataTable
        '----------------------------------------------------------------
        Public Function createDataTables( _
            ByRef strErrMsg As String, _
            ByVal enumType As enumTableType) As System.Data.DataTable

            Dim table As System.Data.DataTable

            Select Case enumType
                Case enumTableType.DC_B_GG_SHUIFEIMULU
                    table = createDataTables_ShuifeiMulu(strErrMsg)
                Case enumTableType.DC_B_GG_YINGSHOUYINGFUMOBAN
                    table = createDataTables_YingshouYingfuMoban(strErrMsg)
                Case enumTableType.DC_B_GG_WUYEJIANGE
                    table = createDataTables_WuyeJiange(strErrMsg)
                Case enumTableType.DC_B_GG_WUYEXINGZHI
                    table = createDataTables_WuyeXingzhi(strErrMsg)
                Case enumTableType.DC_B_GG_QUYUHUAFEN
                    table = createDataTables_QuyuHuafen(strErrMsg)

                    'zengxianglin 2008-11-18
                Case enumTableType.DC_B_GG_BAXM
                    table = createDataTables_DC_B_GG_BAXM(strErrMsg)
                    'zengxianglin 2008-11-18
                Case Else
                    strErrMsg = "无效的表类型！"
                    table = Nothing
            End Select

            createDataTables = table

        End Function










        '----------------------------------------------------------------
        '创建TABLE_DC_B_GG_SHUIFEIMULU
        '----------------------------------------------------------------
        Private Function createDataTables_ShuifeiMulu(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_GG_SHUIFEIMULU)
                With table.Columns
                    .Add(FIELD_DC_B_GG_SHUIFEIMULU_SFDM, GetType(System.String))
                    .Add(FIELD_DC_B_GG_SHUIFEIMULU_SFMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_ShuifeiMulu = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN
        '----------------------------------------------------------------
        Private Function createDataTables_YingshouYingfuMoban(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_GG_YINGSHOUYINGFUMOBAN)
                With table.Columns
                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBDM, GetType(System.String))
                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_MBMC, GetType(System.String))
                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFDM, GetType(System.String))
                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFDX, GetType(System.String))
                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFBZ, GetType(System.String))
                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMX, GetType(System.Int32))


                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMC, GetType(System.String))
                    .Add(FIELD_DC_B_GG_YINGSHOUYINGFUMOBAN_SFMXMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_YingshouYingfuMoban = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_GG_WUYEJIANGE
        '----------------------------------------------------------------
        Private Function createDataTables_WuyeJiange(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_GG_WUYEJIANGE)
                With table.Columns
                    .Add(FIELD_DC_B_GG_WUYEJIANGE_WYJGDM, GetType(System.String))
                    .Add(FIELD_DC_B_GG_WUYEJIANGE_WYJGMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_WuyeJiange = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_GG_WUYEXINGZHI
        '----------------------------------------------------------------
        Private Function createDataTables_WuyeXingzhi(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_GG_WUYEXINGZHI)
                With table.Columns
                    .Add(FIELD_DC_B_GG_WUYEXINGZHI_WYXZDM, GetType(System.String))
                    .Add(FIELD_DC_B_GG_WUYEXINGZHI_WYXZMC, GetType(System.String))
                    'zengxianglin 2010-12-21
                    .Add(FIELD_DC_B_GG_WUYEXINGZHI_SFQY, GetType(System.Int32))
                    .Add(FIELD_DC_B_GG_WUYEXINGZHI_XSSX, GetType(System.Int32))
                    'zengxianglin 2010-12-21
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_WuyeXingzhi = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_GG_QUYUHUAFEN
        '----------------------------------------------------------------
        Private Function createDataTables_QuyuHuafen(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_GG_QUYUHUAFEN)
                With table.Columns
                    .Add(FIELD_DC_B_GG_QUYUHUAFEN_QYDM, GetType(System.String))
                    .Add(FIELD_DC_B_GG_QUYUHUAFEN_QYMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_QuyuHuafen = table

        End Function

        'zengxianglin 2008-11-18
        '----------------------------------------------------------------
        '创建TABLE_DC_B_GG_BAXM
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_GG_BAXM(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_GG_BAXM)
                With table.Columns
                    .Add(FIELD_DC_B_GG_BAXM_XMDM, GetType(System.String))
                    .Add(FIELD_DC_B_GG_BAXM_XMMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_GG_BAXM = table

        End Function
        'zengxianglin 2008-11-18

    End Class 'estateCommonData

End Namespace 'Josco.JsKernal.Common.Data
