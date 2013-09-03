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
    ' 类名    ：estateCaiwuData
    '
    ' 功能描述：
    '     定义与财务管理相关表的数据访问格式
    ' 更改记录：
    '     zengxianglin 2009-05-17 更改
    '----------------------------------------------------------------
    <System.ComponentModel.DesignerCategory("ESTATE-CAIWU"), SerializableAttribute()> Public Class estateCaiwuData
        Inherits System.Data.DataSet

        '“地产_B_财务_票据使用情况”表信息定义
        '表名称
        Public Const TABLE_DC_B_CW_PIAOJUSHIYONG As String = "地产_B_财务_票据使用情况"
        '字段序列
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_PJPH As String = "票据批号"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_PJHM As String = "票据号码"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_FGFH As String = "发给分行"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_PJLX As String = "票据类型"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_FFRY As String = "发放人员"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_FFRQ As String = "发放日期"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_KPJE As String = "开票金额"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_KPRQ As String = "开票日期"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_JBRY As String = "经办人员"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_YWBS As String = "业务标识"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_ZYSM As String = "摘要说明"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_ZFRY As String = "作废人员"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_ZFRQ As String = "作废日期"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_ZTBZ As String = "状态标志"
        'zengxianglin 2008-11-18
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_BJRY As String = "标记人员"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_BJRQ As String = "标记日期"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_SFDM As String = "税费代码"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_SFDX As String = "收付对象"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_SFBZ As String = "收付标志"
        'zengxianglin 2008-11-18
        'zengxianglin 2009-05-17
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_HXBZ As String = "核销标志"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_HXRY As String = "核销人员"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_HXRQ As String = "核销日期"
        'zengxianglin 2009-05-17
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_FGFHMC As String = "发给分行名称"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_FFRYMC As String = "发放人员名称"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_ZFRYMC As String = "作废人员名称"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_ZTBZMC As String = "状态标志名称"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_WYPJHM As String = "唯一票据号码"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_JYBH As String = "交易编号"
        'zengxianglin 2008-11-18
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_BJRYMC As String = "标记人员名称"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_SFMC As String = "税费名称"
        'zengxianglin 2008-11-18
        'zengxianglin 2009-05-17
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_HXBZMC As String = "核销标志名称"
        Public Const FIELD_DC_B_CW_PIAOJUSHIYONG_HXRYMC As String = "核销人员名称"
        'zengxianglin 2009-05-17

        '“地产_B_财务_二手应收应付”表信息定义
        '表名称
        Public Const TABLE_DC_B_CW_ES_YINGSHOUYINGFU As String = "地产_B_财务_二手应收应付"
        '字段序列
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDM As String = "税费代码"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDX As String = "收付对象"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFBZ As String = "收付标志"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSRQ As String = "应收日期"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE As String = "应收金额"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFZT As String = "收付状态"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QTMS As String = "其他描述"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_KSRQ As String = "开始日期"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JSRQ As String = "结束日期"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JZYF As String = "计租月份"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JZQJ As String = "计租区间"
        '显示字段序列
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFMC As String = "税费名称"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SSJE As String = "实收金额"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_S As String = "应收金额收"
        Public Const FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_F As String = "应收金额付"

        '“地产_B_财务_二手实收实付”表信息定义
        '表名称
        Public Const TABLE_DC_B_CW_ES_SHISHOUSHIFU As String = "地产_B_财务_二手实收实付"
        '字段序列
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_PJHM As String = "票据号码"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM As String = "税费代码"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX As String = "收付对象"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ As String = "收付标志"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSRQ As String = "发生日期"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE As String = "发生金额"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_ZYSM As String = "摘要说明"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_KHMC As String = "客户名称"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRY As String = "经办人员"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDW As String = "经办分行"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZ As String = "审核标志"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSH As String = "财务审核"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHRQ As String = "审核日期"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_JHBS As String = "计划标识"
        '显示字段序列
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC As String = "税费名称"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDWMC As String = "经办分行名称"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSHMC As String = "财务审核名称"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFSH As String = "是否审核"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZMC As String = "审核标志名称"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_S As String = "发生金额收"
        Public Const FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_F As String = "发生金额付"










        '定义初始化表类型enum
        Public Enum enumTableType
            DC_B_CW_PIAOJUSHIYONG = 1
            DC_B_CW_ES_YINGSHOUYINGFU = 2
            DC_B_CW_ES_SHISHOUSHIFU = 3
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.Common.Data.estateCaiwuData)
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
        '收、付
        Public Const SFBZ_S As String = "收"
        Public Const SFBZ_F As String = "付"

        '甲、乙
        Public Const SFDX_J As String = "甲"
        Public Const SFDX_Y As String = "乙"

        '票据状态
        Public Enum enumPiaojuStatus
            Unused = 0
            Used = 1
            Zuofei = 2
            Shouhui = 4
        End Enum

        '应收计划中的“收付状态”列表
        Public Enum enumSFZT
            Normal = 1
            Zujin = 2
        End Enum









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
                Case enumTableType.DC_B_CW_PIAOJUSHIYONG
                    table = createDataTables_PiaojuShiyong(strErrMsg)
                Case enumTableType.DC_B_CW_ES_YINGSHOUYINGFU
                    table = createDataTables_YingshouYingfu(strErrMsg)
                Case enumTableType.DC_B_CW_ES_SHISHOUSHIFU
                    table = createDataTables_ShishouShifu(strErrMsg)
                Case Else
                    strErrMsg = "无效的表类型！"
                    table = Nothing
            End Select

            createDataTables = table

        End Function










        '----------------------------------------------------------------
        '创建TABLE_DC_B_CW_PIAOJUSHIYONG
        '----------------------------------------------------------------
        Private Function createDataTables_PiaojuShiyong(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_CW_PIAOJUSHIYONG)
                With table.Columns
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_PJPH, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_PJHM, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_FGFH, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_PJLX, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_FFRY, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_FFRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_KPJE, GetType(System.Double))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_KPRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_YWBS, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_ZYSM, GetType(System.String))

                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_ZFRY, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_ZFRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_ZTBZ, GetType(System.Int32))

                    'zengxianglin 2008-11-18
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_BJRY, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_BJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_SFDM, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_SFDX, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_SFBZ, GetType(System.String))
                    'zengxianglin 2008-11-18

                    'zengxianglin 2009-05-17
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_HXBZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_HXRY, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_HXRQ, GetType(System.DateTime))
                    'zengxianglin 2009-05-17


                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_FGFHMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_FFRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_ZFRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_ZTBZMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_WYPJHM, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_JYBH, GetType(System.String))
                    'zengxianglin 2008-11-18
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_BJRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_SFMC, GetType(System.String))
                    'zengxianglin 2008-11-18

                    'zengxianglin 2009-05-17
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_HXRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_PIAOJUSHIYONG_HXBZMC, GetType(System.String))
                    'zengxianglin 2009-05-17
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_PiaojuShiyong = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_CW_ES_YINGSHOUYINGFU
        '----------------------------------------------------------------
        Private Function createDataTables_YingshouYingfu(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_CW_ES_YINGSHOUYINGFU)
                With table.Columns
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QRSH, GetType(System.String))

                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDM, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFDX, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFBZ, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE, GetType(System.Double))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFZT, GetType(System.Int32))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_QTMS, GetType(System.String))

                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_KSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JZYF, GetType(System.Int32))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_JZQJ, GetType(System.String))


                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SFMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_SSJE, GetType(System.Double))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_S, GetType(System.Double))
                    .Add(FIELD_DC_B_CW_ES_YINGSHOUYINGFU_YSJE_F, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_YingshouYingfu = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_CW_ES_SHISHOUSHIFU
        '----------------------------------------------------------------
        Private Function createDataTables_ShishouShifu(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_CW_ES_SHISHOUSHIFU)
                With table.Columns
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_QRSH, GetType(System.String))

                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_PJHM, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDM, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFDX, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFBZ, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE, GetType(System.Double))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_ZYSM, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_KHMC, GetType(System.String))

                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDW, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSH, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_JHBS, GetType(System.String))


                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_CWSHMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SFSH, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_SHBZMC, GetType(System.String))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_S, GetType(System.Double))
                    .Add(FIELD_DC_B_CW_ES_SHISHOUSHIFU_FSJE_F, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_ShishouShifu = table

        End Function

    End Class 'estateCaiwuData

End Namespace 'Josco.JsKernal.Common.Data
