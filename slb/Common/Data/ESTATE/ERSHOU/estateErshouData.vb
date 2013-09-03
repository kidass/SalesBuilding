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
    ' 类名    ：estateErshouData
    '
    ' 功能描述：
    '     定义与二手业务相关表的数据访问格式
    '
    ' 更改记录：
    '     zengxianglin 2009-05-17 更改
    '     zengxianglin 2009-05-18 更改
    '     zengxianglin 2009-05-21 更改
    '     zengxianglin 2009-12-26 更改
    '     zengxianglin 2010-01-06 更改
    '     zengxianglin 2010-01-18 更改
    '     zengxianglin 2010-12-25 更改
    '     zengxianglin 2011-01-09 更改
    '     zengxianglin 2011-01-18 更改
    '     zengxianglin 2011-03-22 更改
    '----------------------------------------------------------------
    <System.ComponentModel.DesignerCategory("ESTATE-ERSHOU"), SerializableAttribute()> Public Class estateErshouData
        Inherits System.Data.DataSet

        '“地产_V_全部交易”表信息定义
        '表名称
        Public Const TABLE_DC_V_QUANBUJIAOYI As String = "地产_V_全部交易"
        '字段序列
        Public Const FIELD_DC_V_QUANBUJIAOYI_WYBS As String = "唯一标识"
        Public Const FIELD_DC_V_QUANBUJIAOYI_JYLX As String = "交易类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_JYBH As String = "交易编号"
        Public Const FIELD_DC_V_QUANBUJIAOYI_JYRQ As String = "交易日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_JYZT As String = "交易状态"
        Public Const FIELD_DC_V_QUANBUJIAOYI_YZMC As String = "业主名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_KHMC As String = "客户名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_WYDZ As String = "物业地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_JYJG As String = "交易价格"
        Public Const FIELD_DC_V_QUANBUJIAOYI_JYMJ As String = "交易面积"
        Public Const FIELD_DC_V_QUANBUJIAOYI_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_V_QUANBUJIAOYI_HTBH As String = "合同编号"
        Public Const FIELD_DC_V_QUANBUJIAOYI_HTLX As String = "合同类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_HTRQ As String = "合同日期"
        'zengxianglin 2008-11-22
        Public Const FIELD_DC_V_QUANBUJIAOYI_TJRQ As String = "统计日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_JARQ As String = "结案日期"
        'zengxianglin 2008-11-22
        'zengxianglin 2008-11-25
        Public Const FIELD_DC_V_QUANBUJIAOYI_AJFH As String = "按揭返还"
        'zengxianglin 2008-11-25
        Public Const FIELD_DC_V_QUANBUJIAOYI_HTZT As String = "合同状态"
        Public Const FIELD_DC_V_QUANBUJIAOYI_FKFS As String = "付款方式"
        Public Const FIELD_DC_V_QUANBUJIAOYI_HTWYBS As String = "合同唯一标识"
        Public Const FIELD_DC_V_QUANBUJIAOYI_HTZTMC As String = "合同状态名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_JFZJLX As String = "甲方证件类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_JFZZHM As String = "甲方证照号码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_JFDLR As String = "甲方代理人"
        Public Const FIELD_DC_V_QUANBUJIAOYI_JFLXDZ As String = "甲方联系地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_JFLXDH As String = "甲方联系电话"
        Public Const FIELD_DC_V_QUANBUJIAOYI_YFZJLX As String = "乙方证件类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_YFZZHM As String = "乙方证照号码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_YFDLR As String = "乙方代理人"
        Public Const FIELD_DC_V_QUANBUJIAOYI_YFLXDZ As String = "乙方联系地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_YFLXDH As String = "乙方联系电话"
        'zengxianglin 2010-12-25
        Public Const FIELD_DC_V_QUANBUJIAOYI_HTBZ As String = "合同标志"
        Public Const FIELD_DC_V_QUANBUJIAOYI_JCRQ As String = "解除日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_HZRQ As String = "坏账日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_HZJE As String = "坏账金额"
        Public Const FIELD_DC_V_QUANBUJIAOYI_HTJC As String = "合同解除"
        Public Const FIELD_DC_V_QUANBUJIAOYI_HZHT As String = "坏账合同"
        Public Const FIELD_DC_V_QUANBUJIAOYI_CCDZ As String = "查册地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_CCF As String = "查册费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_SSYJ As String = "实收佣金"
        Public Const FIELD_DC_V_QUANBUJIAOYI_HZYJ As String = "合作佣金"
        Public Const FIELD_DC_V_QUANBUJIAOYI_AJJG As String = "按揭机构"
        Public Const FIELD_DC_V_QUANBUJIAOYI_AJYH As String = "按揭银行"
        Public Const FIELD_DC_V_QUANBUJIAOYI_AJCS As String = "按揭成数"
        Public Const FIELD_DC_V_QUANBUJIAOYI_AJNX As String = "按揭年限"
        Public Const FIELD_DC_V_QUANBUJIAOYI_YZQC As String = "业主区码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_YZQN As String = "业主区名"
        Public Const FIELD_DC_V_QUANBUJIAOYI_YZLY As String = "业主来源"
        Public Const FIELD_DC_V_QUANBUJIAOYI_YYQT As String = "业源其他"
        Public Const FIELD_DC_V_QUANBUJIAOYI_YZDY As String = "业主电邮"
        Public Const FIELD_DC_V_QUANBUJIAOYI_SHYX As String = "售后意向"
        Public Const FIELD_DC_V_QUANBUJIAOYI_SYWY As String = "剩余物业"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MJQC As String = "买家区码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MJQN As String = "买家区名"
        Public Const FIELD_DC_V_QUANBUJIAOYI_KHLY As String = "客户来源"
        Public Const FIELD_DC_V_QUANBUJIAOYI_KYQT As String = "客源其他"
        Public Const FIELD_DC_V_QUANBUJIAOYI_KHDY As String = "客户电邮"
        Public Const FIELD_DC_V_QUANBUJIAOYI_GMMD As String = "购买目的"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZLKS As String = "租赁开始"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZLJS As String = "租赁结束"
        Public Const FIELD_DC_V_QUANBUJIAOYI_SDMQ As String = "水电煤气"
        Public Const FIELD_DC_V_QUANBUJIAOYI_DHF As String = "电话费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_GLF As String = "管理费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZLFP As String = "租赁发票"
        Public Const FIELD_DC_V_QUANBUJIAOYI_KYBH As String = "客源编号"
        'zengxianglin 2010-12-25
        '约束错误信息
        '显示字段序列

        'zengxianglin 2009-05-18
        '“地产_V_全部交易_买卖”表信息定义
        '表名称
        Public Const TABLE_DC_V_QUANBUJIAOYI_MM As String = "地产_V_全部交易_买卖"
        '字段序列
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_WYBS As String = "唯一标识"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JYLX As String = "交易类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JYBH As String = "交易编号"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JYRQ As String = "交易日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JYZT As String = "交易状态"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_YZMC As String = "业主名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_KHMC As String = "客户名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_WYDZ As String = "物业地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JYJG As String = "交易价格"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JYMJ As String = "交易面积"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_HTBH As String = "合同编号"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_HTLX As String = "合同类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_HTRQ As String = "合同日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_TJRQ As String = "统计日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JARQ As String = "结案日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_AJFH As String = "按揭返还"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_HTZT As String = "合同状态"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_FKFS As String = "付款方式"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_HTWYBS As String = "合同唯一标识"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_HTZTMC As String = "合同状态名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JFZJLX As String = "甲方证件类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JFZZHM As String = "甲方证照号码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JFDLR As String = "甲方代理人"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JFLXDZ As String = "甲方联系地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JFLXDH As String = "甲方联系电话"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_YFZJLX As String = "乙方证件类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_YFZZHM As String = "乙方证照号码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_YFDLR As String = "乙方代理人"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_YFLXDZ As String = "乙方联系地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_YFLXDH As String = "乙方联系电话"
        '==================================================================================
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JHJLRQ As String = "计划交楼日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_HTBZXX As String = "合同备注信息"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JLRQYDMC As String = "交楼日期约定名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JLZKYDMC As String = "交楼状况约定名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_SFZFYDMC As String = "税费支付约定名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_FKTGYDMC As String = "房款托管约定名称"
        '==================================================================================
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_HTLXMC As String = "合同类型名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_FKFSMC As String = "付款方式名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JFZJLXMC As String = "甲方证件类型名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_YFZJLXMC As String = "乙方证件类型名称"
        'zengxianglin 2010-12-25
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_HTBZ As String = "合同标志"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_JCRQ As String = "解除日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_HZRQ As String = "坏账日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_HZJE As String = "坏账金额"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_HTJC As String = "合同解除"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_HZHT As String = "坏账合同"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_CCDZ As String = "查册地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_CCF As String = "查册费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_SSYJ As String = "实收佣金"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_HZYJ As String = "合作佣金"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_AJJG As String = "按揭机构"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_AJYH As String = "按揭银行"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_AJCS As String = "按揭成数"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_AJNX As String = "按揭年限"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_YZQC As String = "业主区码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_YZQN As String = "业主区名"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_YZLY As String = "业主来源"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_YYQT As String = "业源其他"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_YZDY As String = "业主电邮"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_SHYX As String = "售后意向"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_SYWY As String = "剩余物业"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_MJQC As String = "买家区码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_MJQN As String = "买家区名"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_KHLY As String = "客户来源"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_KYQT As String = "客源其他"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_KHDY As String = "客户电邮"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_GMMD As String = "购买目的"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_ZLKS As String = "租赁开始"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_ZLJS As String = "租赁结束"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_SDMQ As String = "水电煤气"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_DHF As String = "电话费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_GLF As String = "管理费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_ZLFP As String = "租赁发票"
        Public Const FIELD_DC_V_QUANBUJIAOYI_MM_KYBH As String = "客源编号"
        'zengxianglin 2010-12-25
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-05-18

        'zengxianglin 2009-05-18
        '“地产_V_全部交易_租赁”表信息定义
        '表名称
        Public Const TABLE_DC_V_QUANBUJIAOYI_ZL As String = "地产_V_全部交易_租赁"
        '字段序列
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_WYBS As String = "唯一标识"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JYLX As String = "交易类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JYBH As String = "交易编号"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JYRQ As String = "交易日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JYZT As String = "交易状态"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_YZMC As String = "业主名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_KHMC As String = "客户名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_WYDZ As String = "物业地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JYJG As String = "交易价格"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JYMJ As String = "交易面积"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_HTBH As String = "合同编号"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_HTLX As String = "合同类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_HTRQ As String = "合同日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_TJRQ As String = "统计日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JARQ As String = "结案日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_AJFH As String = "按揭返还"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_HTZT As String = "合同状态"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_FKFS As String = "付款方式"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_HTWYBS As String = "合同唯一标识"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_HTZTMC As String = "合同状态名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JFZJLX As String = "甲方证件类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JFZZHM As String = "甲方证照号码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JFDLR As String = "甲方代理人"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JFLXDZ As String = "甲方联系地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JFLXDH As String = "甲方联系电话"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_YFZJLX As String = "乙方证件类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_YFZZHM As String = "乙方证照号码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_YFDLR As String = "乙方代理人"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_YFLXDZ As String = "乙方联系地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_YFLXDH As String = "乙方联系电话"
        '==================================================================================
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JYYZJ As String = "交易月租金"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_ZLBZJ As String = "租赁保证金"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_ZNJBL As String = "滞纳金比例"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_NDZBL As String = "年递增比例"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_ZQYS As String = "租期月数"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JZR As String = "缴租日"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JHJLRQ As String = "计划交楼日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_HTBZXX As String = "合同备注信息"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JLZKSM As String = "交楼状况说明"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_FZFSYDMC As String = "付租方式约定名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_SFZFYDMC As String = "税费支付约定名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_ZJTGYDMC As String = "租金托管约定名称"
        '==================================================================================
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_HTLXMC As String = "合同类型名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_FKFSMC As String = "付款方式名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JFZJLXMC As String = "甲方证件类型名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_YFZJLXMC As String = "乙方证件类型名称"
        'zengxianglin 2010-12-25
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_HTBZ As String = "合同标志"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_JCRQ As String = "解除日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_HZRQ As String = "坏账日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_HZJE As String = "坏账金额"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_HTJC As String = "合同解除"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_HZHT As String = "坏账合同"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_CCDZ As String = "查册地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_CCF As String = "查册费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_SSYJ As String = "实收佣金"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_HZYJ As String = "合作佣金"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_AJJG As String = "按揭机构"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_AJYH As String = "按揭银行"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_AJCS As String = "按揭成数"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_AJNX As String = "按揭年限"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_YZQC As String = "业主区码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_YZQN As String = "业主区名"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_YZLY As String = "业主来源"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_YYQT As String = "业源其他"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_YZDY As String = "业主电邮"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_SHYX As String = "售后意向"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_SYWY As String = "剩余物业"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_MJQC As String = "买家区码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_MJQN As String = "买家区名"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_KHLY As String = "客户来源"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_KYQT As String = "客源其他"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_KHDY As String = "客户电邮"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_GMMD As String = "购买目的"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_ZLKS As String = "租赁开始"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_ZLJS As String = "租赁结束"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_SDMQ As String = "水电煤气"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_DHF As String = "电话费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_GLF As String = "管理费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_ZLFP As String = "租赁发票"
        Public Const FIELD_DC_V_QUANBUJIAOYI_ZL_KYBH As String = "客源编号"
        'zengxianglin 2010-12-25
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-05-18

        'zengxianglin 2009-05-18
        '“地产_V_全部交易_其他”表信息定义
        '表名称
        Public Const TABLE_DC_V_QUANBUJIAOYI_QT As String = "地产_V_全部交易_其他"
        '字段序列
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_WYBS As String = "唯一标识"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JYLX As String = "交易类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JYBH As String = "交易编号"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JYRQ As String = "交易日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JYZT As String = "交易状态"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_YZMC As String = "业主名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_KHMC As String = "客户名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_WYDZ As String = "物业地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JYJG As String = "交易价格"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JYMJ As String = "交易面积"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_HTBH As String = "合同编号"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_HTLX As String = "合同类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_HTRQ As String = "合同日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_TJRQ As String = "统计日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JARQ As String = "结案日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_AJFH As String = "按揭返还"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_HTZT As String = "合同状态"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_FKFS As String = "付款方式"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_HTWYBS As String = "合同唯一标识"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_HTZTMC As String = "合同状态名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JFZJLX As String = "甲方证件类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JFZZHM As String = "甲方证照号码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JFDLR As String = "甲方代理人"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JFLXDZ As String = "甲方联系地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JFLXDH As String = "甲方联系电话"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_YFZJLX As String = "乙方证件类型"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_YFZZHM As String = "乙方证照号码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_YFDLR As String = "乙方代理人"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_YFLXDZ As String = "乙方联系地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_YFLXDH As String = "乙方联系电话"
        '==================================================================================
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JHJLRQ As String = "计划交楼日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_HTBZXX As String = "合同备注信息"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JLRQYDMC As String = "交楼日期约定名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JLZKYDMC As String = "交楼状况约定名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_SFZFYDMC As String = "税费支付约定名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_FKTGYDMC As String = "房款托管约定名称"
        '==================================================================================
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_HTLXMC As String = "合同类型名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_FKFSMC As String = "付款方式名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JFZJLXMC As String = "甲方证件类型名称"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_YFZJLXMC As String = "乙方证件类型名称"
        'zengxianglin 2010-12-25
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_HTBZ As String = "合同标志"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_JCRQ As String = "解除日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_HZRQ As String = "坏账日期"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_HZJE As String = "坏账金额"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_HTJC As String = "合同解除"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_HZHT As String = "坏账合同"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_CCDZ As String = "查册地址"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_CCF As String = "查册费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_SSYJ As String = "实收佣金"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_HZYJ As String = "合作佣金"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_AJJG As String = "按揭机构"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_AJYH As String = "按揭银行"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_AJCS As String = "按揭成数"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_AJNX As String = "按揭年限"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_YZQC As String = "业主区码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_YZQN As String = "业主区名"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_YZLY As String = "业主来源"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_YYQT As String = "业源其他"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_YZDY As String = "业主电邮"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_SHYX As String = "售后意向"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_SYWY As String = "剩余物业"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_MJQC As String = "买家区码"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_MJQN As String = "买家区名"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_KHLY As String = "客户来源"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_KYQT As String = "客源其他"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_KHDY As String = "客户电邮"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_GMMD As String = "购买目的"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_ZLKS As String = "租赁开始"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_ZLJS As String = "租赁结束"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_SDMQ As String = "水电煤气"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_DHF As String = "电话费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_GLF As String = "管理费"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_ZLFP As String = "租赁发票"
        Public Const FIELD_DC_V_QUANBUJIAOYI_QT_KYBH As String = "客源编号"
        'zengxianglin 2010-12-25
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-05-18

        '“地产_B_二手_确认书买卖”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_QUERENSHU_MM As String = "地产_B_二手_确认书买卖"
        '字段序列
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_DGRQ As String = "订购日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_DGZT As String = "订购状态"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_JFMC As String = "甲方名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_JFZJLX As String = "甲方证件类型"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_JFZZHM As String = "甲方证照号码"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_JFDLR As String = "甲方代理人"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_JFLXDZ As String = "甲方联系地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_JFLXDH As String = "甲方联系电话"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_YFMC As String = "乙方名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_YFZJLX As String = "乙方证件类型"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_YFZZHM As String = "乙方证照号码"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_YFDLR As String = "乙方代理人"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_YFLXDZ As String = "乙方联系地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_YFLXDH As String = "乙方联系电话"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_FWDZ As String = "房屋地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_JYZJG As String = "交易总价格"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_JYZMJ As String = "交易总面积"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_JHJYRQ As String = "计划交易日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_JLRQYD As String = "交楼日期约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_JHJLRQ As String = "计划交楼日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_JLZKYD As String = "交楼状况约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_FKFSYD As String = "付款方式约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_SFZFYD As String = "税费支付约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_FKTGYD As String = "房款托管约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_DJRDM As String = "登记人码"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_DJRMC As String = "登记人名"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_DJRQ As String = "登记日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_BZXX As String = "备注信息"
        'zengxianglin 2010-12-25
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_CCDZ As String = "查册地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_CCF As String = "查册费"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_SSYJ As String = "实收佣金"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_HZYJ As String = "合作佣金"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_AJJG As String = "按揭机构"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_AJYH As String = "按揭银行"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_AJCS As String = "按揭成数"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_AJNX As String = "按揭年限"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_YZQC As String = "业主区码"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_YZQN As String = "业主区名"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_YZLY As String = "业主来源"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_YYQT As String = "业源其他"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_YZDY As String = "业主电邮"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_SHYX As String = "售后意向"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_SYWY As String = "剩余物业"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_MJQC As String = "买家区码"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_MJQN As String = "买家区名"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_KHLY As String = "客户来源"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_KYQT As String = "客源其他"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_KHDY As String = "客户电邮"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_GMMD As String = "购买目的"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_KYBH As String = "客源编号"
        'zengxianglin 2010-12-25
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_DGZTMC As String = "订购状态名称"

        'zengxianglin 2009-05-17
        '“地产_B_二手_确认书买卖_打印”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_QUERENSHU_MM_PRN As String = "地产_B_二手_确认书买卖_打印"
        '字段序列
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_DGRQ As String = "订购日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_DGZT As String = "订购状态"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFMC As String = "甲方名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFZJLX As String = "甲方证件类型"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFZZHM As String = "甲方证照号码"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFDLR As String = "甲方代理人"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFLXDZ As String = "甲方联系地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFLXDH As String = "甲方联系电话"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFMC As String = "乙方名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFZJLX As String = "乙方证件类型"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFZZHM As String = "乙方证照号码"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFDLR As String = "乙方代理人"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFLXDZ As String = "乙方联系地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFLXDH As String = "乙方联系电话"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_FWDZ As String = "房屋地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JYZJG As String = "交易总价格"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JYZMJ As String = "交易总面积"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JHJYRQ As String = "计划交易日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JLRQYD As String = "交楼日期约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JHJLRQ As String = "计划交楼日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JLZKYD As String = "交楼状况约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_FKFSYD As String = "付款方式约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_SFZFYD As String = "税费支付约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_FKTGYD As String = "房款托管约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_DJRDM As String = "登记人码"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_DJRMC As String = "登记人名"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_DJRQ As String = "登记日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_BZXX As String = "备注信息"
        '=======================================================================================
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_DGZTMC As String = "订购状态名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFZJLXMC As String = "甲方证件类型名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFZJLXMC As String = "乙方证件类型名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JLRQYDMC As String = "交楼日期约定名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_JLZKYDMC As String = "交楼状况约定名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_FKFSYDMC As String = "付款方式约定名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_SFZFYDMC As String = "税费支付约定名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_FKTGYDMC As String = "房款托管约定名称"
        'zengxianglin 2010-12-25
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_CCDZ As String = "查册地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_CCF As String = "查册费"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_SSYJ As String = "实收佣金"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_HZYJ As String = "合作佣金"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_AJJG As String = "按揭机构"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_AJYH As String = "按揭银行"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_AJCS As String = "按揭成数"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_AJNX As String = "按揭年限"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_YZQC As String = "业主区码"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_YZQN As String = "业主区名"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_YZLY As String = "业主来源"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_YYQT As String = "业源其他"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_YZDY As String = "业主电邮"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_SHYX As String = "售后意向"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_SYWY As String = "剩余物业"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_MJQC As String = "买家区码"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_MJQN As String = "买家区名"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_KHLY As String = "客户来源"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_KYQT As String = "客源其他"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_KHDY As String = "客户电邮"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_GMMD As String = "购买目的"
        Public Const FIELD_DC_B_ES_QUERENSHU_MM_PRN_KYBH As String = "客源编号"
        'zengxianglin 2010-12-25
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-05-17

        '“地产_B_二手_物业买卖”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_WUYE_MM As String = "地产_B_二手_物业买卖"
        '字段序列
        Public Const FIELD_DC_B_ES_WUYE_MM_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_WUYE_MM_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_WUYE_MM_WYBM As String = "物业编码"
        Public Const FIELD_DC_B_ES_WUYE_MM_FWDZ As String = "房屋地址"
        Public Const FIELD_DC_B_ES_WUYE_MM_FCZH As String = "房产证号"
        Public Const FIELD_DC_B_ES_WUYE_MM_FCZDZ As String = "房产证地址"
        Public Const FIELD_DC_B_ES_WUYE_MM_MJ As String = "面积"
        Public Const FIELD_DC_B_ES_WUYE_MM_ZX As String = "座向"
        Public Const FIELD_DC_B_ES_WUYE_MM_LC As String = "楼层"
        Public Const FIELD_DC_B_ES_WUYE_MM_LL As String = "楼龄"
        Public Const FIELD_DC_B_ES_WUYE_MM_JG As String = "间隔"
        Public Const FIELD_DC_B_ES_WUYE_MM_WYXZ As String = "物业性质"
        Public Const FIELD_DC_B_ES_WUYE_MM_SZQY As String = "所在区域"
        Public Const FIELD_DC_B_ES_WUYE_MM_JYJE As String = "交易金额"
        Public Const FIELD_DC_B_ES_WUYE_MM_BZXX As String = "备注信息"
        'zengxianglin 2010-12-25
        Public Const FIELD_DC_B_ES_WUYE_MM_FYBH As String = "房源编号"
        Public Const FIELD_DC_B_ES_WUYE_MM_LP As String = "楼盘"
        Public Const FIELD_DC_B_ES_WUYE_MM_LD As String = "楼栋"
        Public Const FIELD_DC_B_ES_WUYE_MM_DY As String = "单元"
        Public Const FIELD_DC_B_ES_WUYE_MM_JCSJ As String = "建成时间"
        Public Const FIELD_DC_B_ES_WUYE_MM_KJLX As String = "空间类型"
        Public Const FIELD_DC_B_ES_WUYE_MM_FWXZ As String = "房屋性质"
        Public Const FIELD_DC_B_ES_WUYE_MM_ZXDC As String = "装修档次"
        Public Const FIELD_DC_B_ES_WUYE_MM_ZXNX As String = "装修年限"
        Public Const FIELD_DC_B_ES_WUYE_MM_ZYYX As String = "噪音影响"
        Public Const FIELD_DC_B_ES_WUYE_MM_JJSB As String = "家具设备"
        Public Const FIELD_DC_B_ES_WUYE_MM_LYJT As String = "楼宇交通"
        Public Const FIELD_DC_B_ES_WUYE_MM_FWJG As String = "房屋间隔"
        Public Const FIELD_DC_B_ES_WUYE_MM_JGLX As String = "景观类型"
        Public Const FIELD_DC_B_ES_WUYE_MM_JGFS As String = "景观房数"
        Public Const FIELD_DC_B_ES_WUYE_MM_LG As String = "楼高"
        Public Const FIELD_DC_B_ES_WUYE_MM_WSSL As String = "卧室数量"
        Public Const FIELD_DC_B_ES_WUYE_MM_YTSL As String = "阳台数量"
        Public Const FIELD_DC_B_ES_WUYE_MM_HYMJ As String = "花园面积"
        Public Const FIELD_DC_B_ES_WUYE_MM_DTSL As String = "电梯数量"
        Public Const FIELD_DC_B_ES_WUYE_MM_LCHS As String = "楼层户数"
        Public Const FIELD_DC_B_ES_WUYE_MM_LPQS As String = "楼盘期数"
        Public Const FIELD_DC_B_ES_WUYE_MM_WYXX As String = "物业信息"
        'zengxianglin 2010-12-25
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_WUYE_MM_JGMC As String = "间隔名称"
        Public Const FIELD_DC_B_ES_WUYE_MM_WYXZMC As String = "物业性质名称"
        Public Const FIELD_DC_B_ES_WUYE_MM_SZQYMC As String = "所在区域名称"

        '“地产_B_二手_确认书审核签名”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_QUERENSHU_SH As String = "地产_B_二手_确认书审核签名"
        '字段序列
        Public Const FIELD_DC_B_ES_QUERENSHU_SH_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_QUERENSHU_SH_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_QUERENSHU_SH_SHRDM As String = "审核人码"
        Public Const FIELD_DC_B_ES_QUERENSHU_SH_SHRMC As String = "审核人名"
        Public Const FIELD_DC_B_ES_QUERENSHU_SH_SHRQ As String = "审核日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_SH_ZTBZ As String = "状态标志"
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_QUERENSHU_SH_ZTBZMC As String = "状态标志名称"

        '“地产_B_二手_交易合同分配比例”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_HETONG_FPBL As String = "地产_B_二手_交易合同分配比例"
        '字段序列
        Public Const FIELD_DC_B_ES_HETONG_FPBL_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_HETONG_FPBL_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_HETONG_FPBL_RYDM As String = "人员代码"
        Public Const FIELD_DC_B_ES_HETONG_FPBL_DWDM As String = "单位代码"
        Public Const FIELD_DC_B_ES_HETONG_FPBL_FPBL As String = "分配比例"
        Public Const FIELD_DC_B_ES_HETONG_FPBL_RYZJ As String = "人员职级"
        Public Const FIELD_DC_B_ES_HETONG_FPBL_ZGBJ As String = "直管标记"
        Public Const FIELD_DC_B_ES_HETONG_FPBL_ZTBZ As String = "状态标志"
        'zengxianglin 2008-10-14
        Public Const FIELD_DC_B_ES_HETONG_FPBL_SSFZ As String = "所属分组"
        'zengxianglin 2008-10-14
        'zengxianglin 2010-01-06
        Public Const FIELD_DC_B_ES_HETONG_FPBL_TDBH As String = "团队编号"
        'zengxianglin 2010-01-06
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_HETONG_FPBL_RYMC As String = "人员名称"
        Public Const FIELD_DC_B_ES_HETONG_FPBL_DWMC As String = "单位名称"
        Public Const FIELD_DC_B_ES_HETONG_FPBL_RYZJMC As String = "人员职级名称"
        Public Const FIELD_DC_B_ES_HETONG_FPBL_ZGBJMC As String = "直管标记名称"
        Public Const FIELD_DC_B_ES_HETONG_FPBL_ZTBZMC As String = "状态标志名称"


        '“地产_B_二手_确认书租赁”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_QUERENSHU_ZL As String = "地产_B_二手_确认书租赁"
        '字段序列
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_DGRQ As String = "订购日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_DGZT As String = "订购状态"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_JFMC As String = "甲方名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_JFZJLX As String = "甲方证件类型"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_JFZZHM As String = "甲方证照号码"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_JFDLR As String = "甲方代理人"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_JFLXDZ As String = "甲方联系地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_JFLXDH As String = "甲方联系电话"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_YFMC As String = "乙方名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_YFZJLX As String = "乙方证件类型"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_YFZZHM As String = "乙方证照号码"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_YFDLR As String = "乙方代理人"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_YFLXDZ As String = "乙方联系地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_YFLXDH As String = "乙方联系电话"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_FWDZ As String = "房屋地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_JYZZJ As String = "交易总租金"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_JYYZJ As String = "交易月租金"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_ZLBZJ As String = "租赁保证金"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_JYZMJ As String = "交易总面积"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_ZNJBL As String = "滞纳金比例"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_NDZBL As String = "年递增比例"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_JHJYRQ As String = "计划交易日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_JHJLRQ As String = "计划交楼日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_JLZKSM As String = "交楼状况说明"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_FZFSYD As String = "付租方式约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_ZQYD As String = "租期约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_JZR As String = "缴租日"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_ZQYS As String = "租期月数"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_SFZFYD As String = "税费支付约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_ZJTGYD As String = "租金托管约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_DJRDM As String = "登记人码"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_DJRMC As String = "登记人名"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_DJRQ As String = "登记日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_BZXX As String = "备注信息"
        'zengxianglin 2010-12-25
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_CCDZ As String = "查册地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_CCF As String = "查册费"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_SSYJ As String = "实收佣金"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_HZYJ As String = "合作佣金"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_AJJG As String = "按揭机构"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_AJYH As String = "按揭银行"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_AJCS As String = "按揭成数"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_AJNX As String = "按揭年限"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_YZQC As String = "业主区码"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_YZQN As String = "业主区名"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_YZLY As String = "业主来源"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_YYQT As String = "业源其他"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_YZDY As String = "业主电邮"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_SHYX As String = "售后意向"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_SYWY As String = "剩余物业"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_MJQC As String = "买家区码"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_MJQN As String = "买家区名"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_KHLY As String = "客户来源"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_KYQT As String = "客源其他"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_KHDY As String = "客户电邮"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_GMMD As String = "购买目的"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_ZLKS As String = "租赁开始"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_ZLJS As String = "租赁结束"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_SDMQ As String = "水电煤气"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_DHF As String = "电话费"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_GLF As String = "管理费"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_ZLFP As String = "租赁发票"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_KYBH As String = "客源编号"
        'zengxianglin 2010-12-25
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_DGZTMC As String = "订购状态名称"

        'zengxianglin 2009-05-17
        '“地产_B_二手_确认书租赁_打印”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_QUERENSHU_ZL_PRN As String = "地产_B_二手_确认书租赁_打印"
        '字段序列
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DGRQ As String = "订购日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DGZT As String = "订购状态"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFMC As String = "甲方名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFZJLX As String = "甲方证件类型"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFZZHM As String = "甲方证照号码"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFDLR As String = "甲方代理人"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFLXDZ As String = "甲方联系地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFLXDH As String = "甲方联系电话"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFMC As String = "乙方名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFZJLX As String = "乙方证件类型"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFZZHM As String = "乙方证照号码"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFDLR As String = "乙方代理人"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFLXDZ As String = "乙方联系地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFLXDH As String = "乙方联系电话"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_FWDZ As String = "房屋地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JYZZJ As String = "交易总租金"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JYYZJ As String = "交易月租金"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZLBZJ As String = "租赁保证金"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JYZMJ As String = "交易总面积"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZNJBL As String = "滞纳金比例"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_NDZBL As String = "年递增比例"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JHJYRQ As String = "计划交易日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JHJLRQ As String = "计划交楼日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JLZKSM As String = "交楼状况说明"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_FZFSYD As String = "付租方式约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZQYD As String = "租期约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JZR As String = "缴租日"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZQYS As String = "租期月数"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_SFZFYD As String = "税费支付约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZJTGYD As String = "租金托管约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DJRDM As String = "登记人码"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DJRMC As String = "登记人名"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DJRQ As String = "登记日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_BZXX As String = "备注信息"
        '======================================================================================
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DGZTMC As String = "订购状态名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFZJLXMC As String = "甲方证件类型名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFZJLXMC As String = "乙方证件类型名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_FZFSYDMC As String = "付租方式约定名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZQYDMC As String = "租期约定名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZJTGYDMC As String = "租金托管约定名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_SFZFYDMC As String = "税费支付约定名称"
        'zengxianglin 2010-12-25
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_CCDZ As String = "查册地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_CCF As String = "查册费"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_SSYJ As String = "实收佣金"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_HZYJ As String = "合作佣金"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_AJJG As String = "按揭机构"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_AJYH As String = "按揭银行"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_AJCS As String = "按揭成数"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_AJNX As String = "按揭年限"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YZQC As String = "业主区码"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YZQN As String = "业主区名"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YZLY As String = "业主来源"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YYQT As String = "业源其他"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YZDY As String = "业主电邮"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_SHYX As String = "售后意向"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_SYWY As String = "剩余物业"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_MJQC As String = "买家区码"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_MJQN As String = "买家区名"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_KHLY As String = "客户来源"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_KYQT As String = "客源其他"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_KHDY As String = "客户电邮"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_GMMD As String = "购买目的"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZLKS As String = "租赁开始"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZLJS As String = "租赁结束"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_SDMQ As String = "水电煤气"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DHF As String = "电话费"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_GLF As String = "管理费"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZLFP As String = "租赁发票"
        Public Const FIELD_DC_B_ES_QUERENSHU_ZL_PRN_KYBH As String = "客源编号"
        'zengxianglin 2010-12-25
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-05-17


        '“地产_B_二手_物业租赁”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_WUYE_ZL As String = "地产_B_二手_物业租赁"
        '字段序列
        Public Const FIELD_DC_B_ES_WUYE_ZL_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_WUYE_ZL_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_WUYE_ZL_WYBM As String = "物业编码"
        Public Const FIELD_DC_B_ES_WUYE_ZL_FWDZ As String = "房屋地址"
        Public Const FIELD_DC_B_ES_WUYE_ZL_FCZH As String = "房产证号"
        Public Const FIELD_DC_B_ES_WUYE_ZL_FCZDZ As String = "房产证地址"
        Public Const FIELD_DC_B_ES_WUYE_ZL_MJ As String = "面积"
        Public Const FIELD_DC_B_ES_WUYE_ZL_ZX As String = "座向"
        Public Const FIELD_DC_B_ES_WUYE_ZL_LC As String = "楼层"
        Public Const FIELD_DC_B_ES_WUYE_ZL_LL As String = "楼龄"
        Public Const FIELD_DC_B_ES_WUYE_ZL_JG As String = "间隔"
        Public Const FIELD_DC_B_ES_WUYE_ZL_WYXZ As String = "物业性质"
        Public Const FIELD_DC_B_ES_WUYE_ZL_SZQY As String = "所在区域"
        Public Const FIELD_DC_B_ES_WUYE_ZL_YZJ As String = "月租金"
        Public Const FIELD_DC_B_ES_WUYE_ZL_BZXX As String = "备注信息"
        'zengxianglin 2010-12-25
        Public Const FIELD_DC_B_ES_WUYE_ZL_FYBH As String = "房源编号"
        Public Const FIELD_DC_B_ES_WUYE_ZL_LP As String = "楼盘"
        Public Const FIELD_DC_B_ES_WUYE_ZL_LD As String = "楼栋"
        Public Const FIELD_DC_B_ES_WUYE_ZL_DY As String = "单元"
        Public Const FIELD_DC_B_ES_WUYE_ZL_JCSJ As String = "建成时间"
        Public Const FIELD_DC_B_ES_WUYE_ZL_KJLX As String = "空间类型"
        Public Const FIELD_DC_B_ES_WUYE_ZL_FWXZ As String = "房屋性质"
        Public Const FIELD_DC_B_ES_WUYE_ZL_ZXDC As String = "装修档次"
        Public Const FIELD_DC_B_ES_WUYE_ZL_ZXNX As String = "装修年限"
        Public Const FIELD_DC_B_ES_WUYE_ZL_ZYYX As String = "噪音影响"
        Public Const FIELD_DC_B_ES_WUYE_ZL_JJSB As String = "家具设备"
        Public Const FIELD_DC_B_ES_WUYE_ZL_LYJT As String = "楼宇交通"
        Public Const FIELD_DC_B_ES_WUYE_ZL_FWJG As String = "房屋间隔"
        Public Const FIELD_DC_B_ES_WUYE_ZL_JGLX As String = "景观类型"
        Public Const FIELD_DC_B_ES_WUYE_ZL_JGFS As String = "景观房数"
        Public Const FIELD_DC_B_ES_WUYE_ZL_LG As String = "楼高"
        Public Const FIELD_DC_B_ES_WUYE_ZL_WSSL As String = "卧室数量"
        Public Const FIELD_DC_B_ES_WUYE_ZL_YTSL As String = "阳台数量"
        Public Const FIELD_DC_B_ES_WUYE_ZL_HYMJ As String = "花园面积"
        Public Const FIELD_DC_B_ES_WUYE_ZL_DTSL As String = "电梯数量"
        Public Const FIELD_DC_B_ES_WUYE_ZL_LCHS As String = "楼层户数"
        Public Const FIELD_DC_B_ES_WUYE_ZL_LPQS As String = "楼盘期数"
        Public Const FIELD_DC_B_ES_WUYE_ZL_WYXX As String = "物业信息"
        'zengxianglin 2010-12-25
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_WUYE_ZL_JGMC As String = "间隔名称"
        Public Const FIELD_DC_B_ES_WUYE_ZL_WYXZMC As String = "物业性质名称"
        Public Const FIELD_DC_B_ES_WUYE_ZL_SZQYMC As String = "所在区域名称"

        '“地产_B_二手_租赁期限”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_ZULINQIXIAN As String = "地产_B_二手_租赁期限"
        '字段序列
        Public Const FIELD_DC_B_ES_ZULINQIXIAN_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_ZULINQIXIAN_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_ZULINQIXIAN_KSRQ As String = "开始日期"
        Public Const FIELD_DC_B_ES_ZULINQIXIAN_ZZRQ As String = "终止日期"
        Public Const FIELD_DC_B_ES_ZULINQIXIAN_YZJE As String = "月租金额"
        Public Const FIELD_DC_B_ES_ZULINQIXIAN_JZR As String = "缴租日"
        Public Const FIELD_DC_B_ES_ZULINQIXIAN_JZFS As String = "缴租方式"
        Public Const FIELD_DC_B_ES_ZULINQIXIAN_YZZE As String = "月租总额"
        Public Const FIELD_DC_B_ES_ZULINQIXIAN_ZQYS As String = "租期月数"
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_ZULINQIXIAN_JZFSMC As String = "缴租方式名称"

        '“地产_B_二手_交易合同”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_HETONG As String = "地产_B_二手_交易合同"
        '字段序列
        Public Const FIELD_DC_B_ES_HETONG_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_HETONG_HTBH As String = "合同编号"
        Public Const FIELD_DC_B_ES_HETONG_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_HETONG_HTLX As String = "合同类型"
        Public Const FIELD_DC_B_ES_HETONG_HTRQ As String = "合同日期"
        'zengxianglin 2008-11-22
        Public Const FIELD_DC_B_ES_HETONG_TJRQ As String = "统计日期"
        Public Const FIELD_DC_B_ES_HETONG_JARQ As String = "结案日期"
        'zengxianglin 2008-11-22
        'zengxianglin 2008-11-25
        Public Const FIELD_DC_B_ES_HETONG_AJFH As String = "按揭返还"
        'zengxianglin 2008-11-25
        Public Const FIELD_DC_B_ES_HETONG_HTZT As String = "合同状态"
        Public Const FIELD_DC_B_ES_HETONG_FKFS As String = "付款方式"
        Public Const FIELD_DC_B_ES_HETONG_DJRDM As String = "登记人码"
        Public Const FIELD_DC_B_ES_HETONG_DJRMC As String = "登记人名"
        Public Const FIELD_DC_B_ES_HETONG_DJRQ As String = "登记日期"
        Public Const FIELD_DC_B_ES_HETONG_BZXX As String = "备注信息"
        'zengxianglin 2010-12-25
        Public Const FIELD_DC_B_ES_HETONG_HTBZ As String = "合同标志"
        Public Const FIELD_DC_B_ES_HETONG_JCRQ As String = "解除日期"
        Public Const FIELD_DC_B_ES_HETONG_HZJE As String = "坏账金额"
        Public Const FIELD_DC_B_ES_HETONG_HZRQ As String = "坏账日期"
        'zengxianglin 2010-12-25
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_HETONG_HTZTMC As String = "合同状态名称"

        '“地产_B_二手_交易合同审核签名”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_HETONG_SHENHE As String = "地产_B_二手_交易合同审核签名"
        '字段序列
        Public Const FIELD_DC_B_ES_HETONG_SHENHE_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_HETONG_SHENHE_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_HETONG_SHENHE_SHRDM As String = "审核人码"
        Public Const FIELD_DC_B_ES_HETONG_SHENHE_SHRMC As String = "审核人名"
        Public Const FIELD_DC_B_ES_HETONG_SHENHE_SHRQ As String = "审核日期"
        Public Const FIELD_DC_B_ES_HETONG_SHENHE_ZTBZ As String = "状态标志"
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_HETONG_SHENHE_ZTBZMC As String = "状态标志名称"

        '“地产_B_二手_交易合同折扣审核”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_HETONG_ZHEKOUSHENHE As String = "地产_B_二手_交易合同折扣审核"
        '字段序列
        Public Const FIELD_DC_B_ES_HETONG_ZHEKOUSHENHE_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_HETONG_ZHEKOUSHENHE_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_HETONG_ZHEKOUSHENHE_SHRDM As String = "审核人码"
        Public Const FIELD_DC_B_ES_HETONG_ZHEKOUSHENHE_SHRMC As String = "审核人名"
        Public Const FIELD_DC_B_ES_HETONG_ZHEKOUSHENHE_SHLX As String = "审核类型"
        Public Const FIELD_DC_B_ES_HETONG_ZHEKOUSHENHE_SHRQ As String = "审核日期"
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_HETONG_ZHEKOUSHENHE_SHLXMC As String = "审核类型名称"

        '“地产_B_二手_交易合同办案计划”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_HETONG_BANANJIHUA As String = "地产_B_二手_交易合同办案计划"
        '字段序列
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_JHKS As String = "计划开始"
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_JHJS As String = "计划结束"
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_GZNR As String = "工作内容"
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_JBRY As String = "经办人员"
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDW As String = "经办分行"
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_SJKS As String = "实际开始"
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_SJJS As String = "实际结束"
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_TXBZ As String = "提醒标志"
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_KBTS As String = "开办天数"
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_BWTS As String = "办完天数"
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDWMC As String = "经办分行名称"
        Public Const FIELD_DC_B_ES_HETONG_BANANJIHUA_TXBZMC As String = "提醒标志名称"

        '“地产_B_二手_交易合同办案记录”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_HETONG_BANLIJILU As String = "地产_B_二手_交易合同办案记录"
        '字段序列
        Public Const FIELD_DC_B_ES_HETONG_BANLIJILU_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_HETONG_BANLIJILU_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_HETONG_BANLIJILU_JHBS As String = "计划标识"
        Public Const FIELD_DC_B_ES_HETONG_BANLIJILU_BLRQ As String = "办理日期"
        Public Const FIELD_DC_B_ES_HETONG_BANLIJILU_BLQK As String = "办理情况"
        Public Const FIELD_DC_B_ES_HETONG_BANLIJILU_JBRY As String = "经办人员"
        Public Const FIELD_DC_B_ES_HETONG_BANLIJILU_JBDW As String = "经办分行"
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_HETONG_BANLIJILU_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_B_ES_HETONG_BANLIJILU_JBDWMC As String = "经办分行名称"

        '“地产_B_二手_交易合同结算书”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_HETONG_JIESUANSHU As String = "地产_B_二手_交易合同结算书"
        '字段序列
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_JSSH As String = "结算书号"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_JSDW As String = "结算单位"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_JSRQ As String = "结算日期"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_JBRY As String = "经办人员"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_JSLX As String = "结算类型"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_ZJFE As String = "中介费额"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_JSEJ As String = "结算额甲"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_JSEY As String = "结算额乙"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_SSEJ As String = "实收额甲"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_SSEY As String = "实收额乙"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_ZTBZ As String = "状态标志"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_BZXX As String = "备注信息"
        'zengxianglin 2009-12-26
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_JYRQ As String = "计佣日期"
        'zengxianglin 2009-12-26
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_JSDWMC As String = "结算单位名称"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_JSLXMC As String = "结算类型名称"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_ZTBZMC As String = "状态标志名称"

        '“地产_B_二手_交易合同结算书明细表”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_HETONG_JIESUANSHU_MINGXI As String = "地产_B_二手_交易合同结算书明细表"
        '字段序列
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSSH As String = "结算书号"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_SFDM As String = "税费代码"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSDX As String = "结算对象"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSJE As String = "结算金额"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSZY As String = "结算摘要"
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_SFMC As String = "税费名称"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSEJ As String = "结算额甲"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSEY As String = "结算额乙"

        '“地产_B_二手_交易合同结算书业绩”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_HETONG_JIESUANSHU_YEJI As String = "地产_B_二手_交易合同结算书业绩"
        '字段序列
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_JSSH As String = "结算书号"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_YJLY As String = "业绩来源"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_RYDM As String = "人员代码"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_DWDM As String = "单位代码"
        'zengxianglin 2008-10-14
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_SSFZ As String = "所属分组"
        'zengxianglin 2008-10-14
        'zengxianglin 2010-01-06
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_TDBH As String = "团队编号"
        'zengxianglin 2010-01-06
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_RYZJ As String = "人员职级"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_ZGBJ As String = "直管标记"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_ZTBZ As String = "状态标志"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_FPBL As String = "分配比例"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_KHYJ As String = "考核业绩"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_SYJS As String = "私佣基数"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_GYJS As String = "公佣基数"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCZE As String = "本次总额"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCJT As String = "本次计提"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCBL As String = "本次保留"
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_YJLYMC As String = "业绩来源名称"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_RYMC As String = "人员名称"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_DWMC As String = "单位名称"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_RYZJMC As String = "人员职级名称"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_ZGBJMC As String = "直管标记名称"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_ZTBZMC As String = "状态标志名称"

        '“地产_B_二手_交易合同结算书审核签名”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_HETONG_JIESUANSHU_SHENHE As String = "地产_B_二手_交易合同结算书审核签名"
        '字段序列
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_JSSH As String = "结算书号"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_SHRDM As String = "审核人码"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_SHRMC As String = "审核人名"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_SHRQ As String = "审核日期"
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_ZTBZ As String = "状态标志"
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_ZTBZMC As String = "状态标志名称"

        '“地产_B_二手_确认书其他”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_QUERENSHU_QT As String = "地产_B_二手_确认书其他"
        '字段序列
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_DGRQ As String = "订购日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_DGZT As String = "订购状态"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_JFMC As String = "甲方名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_JFZJLX As String = "甲方证件类型"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_JFZZHM As String = "甲方证照号码"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_JFDLR As String = "甲方代理人"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_JFLXDZ As String = "甲方联系地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_JFLXDH As String = "甲方联系电话"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_YFMC As String = "乙方名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_YFZJLX As String = "乙方证件类型"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_YFZZHM As String = "乙方证照号码"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_YFDLR As String = "乙方代理人"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_YFLXDZ As String = "乙方联系地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_YFLXDH As String = "乙方联系电话"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_FWDZ As String = "房屋地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_JYZJG As String = "交易总价格"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_JYZMJ As String = "交易总面积"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_JHJYRQ As String = "计划交易日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_JLRQYD As String = "交楼日期约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_JHJLRQ As String = "计划交楼日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_JLZKYD As String = "交楼状况约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_FKFSYD As String = "付款方式约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_SFZFYD As String = "税费支付约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_FKTGYD As String = "房款托管约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_DJRDM As String = "登记人码"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_DJRMC As String = "登记人名"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_DJRQ As String = "登记日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_BZXX As String = "备注信息"
        'zengxianglin 2010-12-25
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_CCDZ As String = "查册地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_CCF As String = "查册费"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_SSYJ As String = "实收佣金"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_HZYJ As String = "合作佣金"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_AJJG As String = "按揭机构"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_AJYH As String = "按揭银行"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_AJCS As String = "按揭成数"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_AJNX As String = "按揭年限"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_YZQC As String = "业主区码"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_YZQN As String = "业主区名"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_YZLY As String = "业主来源"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_YYQT As String = "业源其他"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_YZDY As String = "业主电邮"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_SHYX As String = "售后意向"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_SYWY As String = "剩余物业"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_MJQC As String = "买家区码"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_MJQN As String = "买家区名"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_KHLY As String = "客户来源"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_KYQT As String = "客源其他"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_KHDY As String = "客户电邮"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_GMMD As String = "购买目的"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_KYBH As String = "客源编号"
        'zengxianglin 2010-12-25
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_DGZTMC As String = "订购状态名称"

        'zengxianglin 2009-05-17
        '“地产_B_二手_确认书其他_打印”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_QUERENSHU_QT_PRN As String = "地产_B_二手_确认书其他_打印"
        '字段序列
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_DGRQ As String = "订购日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_DGZT As String = "订购状态"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFMC As String = "甲方名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFZJLX As String = "甲方证件类型"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFZZHM As String = "甲方证照号码"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFDLR As String = "甲方代理人"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFLXDZ As String = "甲方联系地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFLXDH As String = "甲方联系电话"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFMC As String = "乙方名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFZJLX As String = "乙方证件类型"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFZZHM As String = "乙方证照号码"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFDLR As String = "乙方代理人"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFLXDZ As String = "乙方联系地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFLXDH As String = "乙方联系电话"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_FWDZ As String = "房屋地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JYZJG As String = "交易总价格"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JYZMJ As String = "交易总面积"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JHJYRQ As String = "计划交易日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JLRQYD As String = "交楼日期约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JHJLRQ As String = "计划交楼日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JLZKYD As String = "交楼状况约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_FKFSYD As String = "付款方式约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_SFZFYD As String = "税费支付约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_FKTGYD As String = "房款托管约定"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_DJRDM As String = "登记人码"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_DJRMC As String = "登记人名"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_DJRQ As String = "登记日期"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_BZXX As String = "备注信息"
        '========================================================================================
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_DGZTMC As String = "订购状态名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFZJLXMC As String = "甲方证件类型名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFZJLXMC As String = "乙方证件类型名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JLRQYDMC As String = "交楼日期约定名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_JLZKYDMC As String = "交楼状况约定名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_FKFSYDMC As String = "付款方式约定名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_SFZFYDMC As String = "税费支付约定名称"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_FKTGYDMC As String = "房款托管约定名称"
        'zengxianglin 2010-12-25
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_CCDZ As String = "查册地址"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_CCF As String = "查册费"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_SSYJ As String = "实收佣金"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_HZYJ As String = "合作佣金"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_AJJG As String = "按揭机构"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_AJYH As String = "按揭银行"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_AJCS As String = "按揭成数"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_AJNX As String = "按揭年限"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_YZQC As String = "业主区码"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_YZQN As String = "业主区名"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_YZLY As String = "业主来源"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_YYQT As String = "业源其他"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_YZDY As String = "业主电邮"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_SHYX As String = "售后意向"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_SYWY As String = "剩余物业"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_MJQC As String = "买家区码"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_MJQN As String = "买家区名"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_KHLY As String = "客户来源"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_KYQT As String = "客源其他"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_KHDY As String = "客户电邮"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_GMMD As String = "购买目的"
        Public Const FIELD_DC_B_ES_QUERENSHU_QT_PRN_KYBH As String = "客源编号"
        'zengxianglin 2010-12-25
        '约束错误信息
        'zengxianglin 2009-05-17

        '“地产_B_二手_物业其他”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_WUYE_QT As String = "地产_B_二手_物业其他"
        '字段序列
        Public Const FIELD_DC_B_ES_WUYE_QT_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_WUYE_QT_QRSH As String = "确认书号"
        Public Const FIELD_DC_B_ES_WUYE_QT_WYBM As String = "物业编码"
        Public Const FIELD_DC_B_ES_WUYE_QT_FWDZ As String = "房屋地址"
        Public Const FIELD_DC_B_ES_WUYE_QT_FCZH As String = "房产证号"
        Public Const FIELD_DC_B_ES_WUYE_QT_FCZDZ As String = "房产证地址"
        Public Const FIELD_DC_B_ES_WUYE_QT_MJ As String = "面积"
        Public Const FIELD_DC_B_ES_WUYE_QT_ZX As String = "座向"
        Public Const FIELD_DC_B_ES_WUYE_QT_LC As String = "楼层"
        Public Const FIELD_DC_B_ES_WUYE_QT_LL As String = "楼龄"
        Public Const FIELD_DC_B_ES_WUYE_QT_JG As String = "间隔"
        Public Const FIELD_DC_B_ES_WUYE_QT_WYXZ As String = "物业性质"
        Public Const FIELD_DC_B_ES_WUYE_QT_SZQY As String = "所在区域"
        Public Const FIELD_DC_B_ES_WUYE_QT_JYJE As String = "交易金额"
        Public Const FIELD_DC_B_ES_WUYE_QT_BZXX As String = "备注信息"
        'zengxianglin 2010-12-25
        Public Const FIELD_DC_B_ES_WUYE_QT_FYBH As String = "房源编号"
        Public Const FIELD_DC_B_ES_WUYE_QT_LP As String = "楼盘"
        Public Const FIELD_DC_B_ES_WUYE_QT_LD As String = "楼栋"
        Public Const FIELD_DC_B_ES_WUYE_QT_DY As String = "单元"
        Public Const FIELD_DC_B_ES_WUYE_QT_JCSJ As String = "建成时间"
        Public Const FIELD_DC_B_ES_WUYE_QT_KJLX As String = "空间类型"
        Public Const FIELD_DC_B_ES_WUYE_QT_FWXZ As String = "房屋性质"
        Public Const FIELD_DC_B_ES_WUYE_QT_ZXDC As String = "装修档次"
        Public Const FIELD_DC_B_ES_WUYE_QT_ZXNX As String = "装修年限"
        Public Const FIELD_DC_B_ES_WUYE_QT_ZYYX As String = "噪音影响"
        Public Const FIELD_DC_B_ES_WUYE_QT_JJSB As String = "家具设备"
        Public Const FIELD_DC_B_ES_WUYE_QT_LYJT As String = "楼宇交通"
        Public Const FIELD_DC_B_ES_WUYE_QT_FWJG As String = "房屋间隔"
        Public Const FIELD_DC_B_ES_WUYE_QT_JGLX As String = "景观类型"
        Public Const FIELD_DC_B_ES_WUYE_QT_JGFS As String = "景观房数"
        Public Const FIELD_DC_B_ES_WUYE_QT_LG As String = "楼高"
        Public Const FIELD_DC_B_ES_WUYE_QT_WSSL As String = "卧室数量"
        Public Const FIELD_DC_B_ES_WUYE_QT_YTSL As String = "阳台数量"
        Public Const FIELD_DC_B_ES_WUYE_QT_HYMJ As String = "花园面积"
        Public Const FIELD_DC_B_ES_WUYE_QT_DTSL As String = "电梯数量"
        Public Const FIELD_DC_B_ES_WUYE_QT_LCHS As String = "楼层户数"
        Public Const FIELD_DC_B_ES_WUYE_QT_LPQS As String = "楼盘期数"
        Public Const FIELD_DC_B_ES_WUYE_QT_WYXX As String = "物业信息"
        'zengxianglin 2010-12-25
        '显示字段序列
        Public Const FIELD_DC_B_ES_WUYE_QT_JGMC As String = "间隔名称"
        Public Const FIELD_DC_B_ES_WUYE_QT_WYXZMC As String = "物业性质名称"
        Public Const FIELD_DC_B_ES_WUYE_QT_SZQYMC As String = "所在区域名称"
        '约束错误信息

        'zengxianglin 2008-11-24
        '“中介部二手代理结算情况表_各分行”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESDLJSQKB_GFH As String = "中介部二手代理结算情况表_各分行"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_XSJB As String = "显示级别"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_XSMC As String = "显示名称"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_QYMC As String = "区域名称"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_DWDM As String = "单位代码"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_DWMC As String = "单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_SSFZ As String = "所属分组"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJDLFAJ As String = "累计代理费按揭"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJDLFXS As String = "累计代理费销售"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJDLFZL As String = "累计代理费租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJDLFQT As String = "累计代理费其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJDLFXJ As String = "累计代理费小计"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJZSXS As String = "累计宗数销售"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJZSZL As String = "累计宗数租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJZSQT As String = "累计宗数其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJZSXJ As String = "累计宗数小计"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYDLFAJ As String = "本月代理费按揭"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYDLFXS As String = "本月代理费销售"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYDLFZL As String = "本月代理费租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYDLFQT As String = "本月代理费其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYDLFXJ As String = "本月代理费小计"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYZSXS As String = "本月宗数销售"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYZSZL As String = "本月宗数租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYZSQT As String = "本月宗数其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYZSXJ As String = "本月宗数小计"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-11-24

        'zengxianglin 2008-11-26
        '“中介部二手代理结算情况表_各业务”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESDLJSQKB_GYW As String = "中介部二手代理结算情况表_各业务"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_JYMC As String = "交易名称"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_XSXH As String = "显示序号"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WCDLF As String = "完成代理费"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WCHTJE As String = "完成合同金额"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WCDLMJ As String = "完成代理面积"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WCZS As String = "完成宗数"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WCTS As String = "完成套数"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WCAJFH As String = "完成按揭返还"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_BYDLF As String = "本月代理费"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_BYHTJE As String = "本月合同金额"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_BYDLMJ As String = "本月代理面积"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_BYZS As String = "本月宗数"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_BYTS As String = "本月套数"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_BYAJFH As String = "本月按揭返还"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WJDLF As String = "未结代理费"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WJHTJE As String = "未结合同金额"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WJDLMJ As String = "未结代理面积"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WJZS As String = "未结宗数"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WJTS As String = "未结套数"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WJAJFH As String = "未结按揭返还"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-11-26

        'zengxianglin 2008-11-26
        '“中介部二手代理接案情况表_各分行”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESDLJAQKB_GFH As String = "中介部二手代理接案情况表_各分行"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_XSJB As String = "显示级别"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_XSMC As String = "显示名称"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_QYMC As String = "区域名称"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_DWDM As String = "单位代码"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_DWMC As String = "单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_SSFZ As String = "所属分组"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJDLFAJ As String = "累计代理费按揭"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJDLFXS As String = "累计代理费销售"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJDLFZL As String = "累计代理费租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJDLFQT As String = "累计代理费其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJDLFXJ As String = "累计代理费小计"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJZSXS As String = "累计宗数销售"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJZSZL As String = "累计宗数租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJZSQT As String = "累计宗数其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJZSXJ As String = "累计宗数小计"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYDLFAJ As String = "本月代理费按揭"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYDLFXS As String = "本月代理费销售"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYDLFZL As String = "本月代理费租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYDLFQT As String = "本月代理费其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYDLFXJ As String = "本月代理费小计"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYZSXS As String = "本月宗数销售"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYZSZL As String = "本月宗数租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYZSQT As String = "本月宗数其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYZSXJ As String = "本月宗数小计"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-11-26

        'zengxianglin 2008-11-26
        '“中介部二手代理结案情况表_各分行”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESDLWCQKB_GFH As String = "中介部二手代理结案情况表_各分行"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_XSJB As String = "显示级别"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_XSMC As String = "显示名称"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_QYMC As String = "区域名称"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_DWDM As String = "单位代码"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_DWMC As String = "单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_SSFZ As String = "所属分组"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJDLFAJ As String = "累计代理费按揭"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJDLFXS As String = "累计代理费销售"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJDLFZL As String = "累计代理费租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJDLFQT As String = "累计代理费其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJDLFXJ As String = "累计代理费小计"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJZSXS As String = "累计宗数销售"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJZSZL As String = "累计宗数租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJZSQT As String = "累计宗数其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJZSXJ As String = "累计宗数小计"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYDLFAJ As String = "本月代理费按揭"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYDLFXS As String = "本月代理费销售"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYDLFZL As String = "本月代理费租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYDLFQT As String = "本月代理费其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYDLFXJ As String = "本月代理费小计"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYZSXS As String = "本月宗数销售"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYZSZL As String = "本月宗数租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYZSQT As String = "本月宗数其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYZSXJ As String = "本月宗数小计"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-11-26

        'zengxianglin 2008-11-28
        '“地产_B_二手_交易年度计划”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_JYNDJH As String = "地产_B_二手_交易年度计划"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_B_ES_JYNDJH_WYBS As String = "唯一标识"
        '===========================================================================================
        Public Const FIELD_DC_B_ES_JYNDJH_JHND As String = "计划年度"
        Public Const FIELD_DC_B_ES_JYNDJH_JHLX As String = "计划类型"
        '===========================================================================================
        Public Const FIELD_DC_B_ES_JYNDJH_JHDLF As String = "计划代理费"
        Public Const FIELD_DC_B_ES_JYNDJH_JHHTE As String = "计划合同额"
        Public Const FIELD_DC_B_ES_JYNDJH_JHZS As String = "计划宗数"
        Public Const FIELD_DC_B_ES_JYNDJH_JHTS As String = "计划套数"
        Public Const FIELD_DC_B_ES_JYNDJH_JHMJ As String = "计划面积"
        '===========================================================================================
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-11-28

        'zengxianglin 2008-11-28
        '“中介部二手代理结算情况表_各月度”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESDLJSQKB_GYD As String = "中介部二手代理结算情况表_各月度"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_XSJB As String = "显示级别"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_XSMC As String = "显示名称"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_ZBMC As String = "指标名称"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_ZBXH As String = "指标序号"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_JYMC As String = "交易名称"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_JSDW As String = "计算单位"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_NDJH As String = "年度计划"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_LJWC As String = "累计完成"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_WCBL As String = "完成比例"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M01 As String = "m01"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M02 As String = "m02"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M03 As String = "m03"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M04 As String = "m04"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M05 As String = "m05"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M06 As String = "m06"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M07 As String = "m07"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M08 As String = "m08"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M09 As String = "m09"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M10 As String = "m10"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M11 As String = "m11"
        Public Const FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M12 As String = "m12"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-11-28

        'zengxianglin 2008-11-28
        '“中介部二手业务代理清单_接案”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESYWDLQD_JA As String = "中介部二手业务代理清单_接案"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_XSJB As String = "显示级别"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JYPX As String = "交易排序"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_DGRQ As String = "订购日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_TJRQ As String = "统计日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ZQ As String = "租期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_YZJ As String = "月租金"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JYMJ As String = "交易面积"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JYJG As String = "交易价格"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ZDLF As String = "总代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_AJFH As String = "按揭返还"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JBDW As String = "经办单位"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JBDWMC As String = "经办单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JBRY As String = "经办人员"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_TS As String = "套数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ZS As String = "宗数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_SSK As String = "实收款"
        'zengxianglin 2009-02-24
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_SSDLF As String = "实收代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_SFBL As String = "收费比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_SFBZ As String = "收费标准"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_CYJ As String = "诚意金"
        'zengxianglin 2009-02-24
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-11-28

        'zengxianglin 2009-02-24
        '“中介部二手业务代理清单_接案_未审合同”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESYWDLQD_JA_WS As String = "中介部二手业务代理清单_接案_未审合同"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_XSJB As String = "显示级别"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JYPX As String = "交易排序"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_DGRQ As String = "订购日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_TJRQ As String = "统计日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_ZQ As String = "租期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_YZJ As String = "月租金"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JYMJ As String = "交易面积"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JYJG As String = "交易价格"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_ZDLF As String = "总代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_AJFH As String = "按揭返还"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JBDW As String = "经办单位"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JBDWMC As String = "经办单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JBRY As String = "经办人员"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_TS As String = "套数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_ZS As String = "宗数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_SSK As String = "实收款"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_SSDLF As String = "实收代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_SFBL As String = "收费比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_SFBZ As String = "收费标准"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_CYJ As String = "诚意金"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-02-24

        'zengxianglin 2009-05-21
        '“中介部二手业务代理清单_接案_全部”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESYWDLQD_JA_ALL As String = "中介部二手业务代理清单_接案_全部"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_XSJB As String = "显示级别"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JYPX As String = "交易排序"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_DGRQ As String = "订购日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_TJRQ As String = "统计日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JARQ As String = "结案日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_HTZT As String = "合同状态"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_ZQ As String = "租期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_YZJ As String = "月租金"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JYMJ As String = "交易面积"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JYJG As String = "交易价格"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_ZDLF As String = "总代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_AJFH As String = "按揭返还"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JBDW As String = "经办单位"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JBDWMC As String = "经办单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JBRY As String = "经办人员"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_TS As String = "套数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_ZS As String = "宗数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_SSK As String = "实收款"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_SSDLF As String = "实收代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_SFBL As String = "收费比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_SFBZ As String = "收费标准"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_CYJ As String = "诚意金"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-05-21

        'zengxianglin 2009-05-21
        '“中介部二手业务代理清单_接案1_全部”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESYWDLQD_JA1_ALL As String = "中介部二手业务代理清单_接案1_全部"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_XSJB As String = "显示级别"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_PQDM As String = "片区代码"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_PQMC As String = "片区名称"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JYPX As String = "交易排序"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_DGRQ As String = "订购日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_TJRQ As String = "统计日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JARQ As String = "结案日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_HTZT As String = "合同状态"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_ZQ As String = "租期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_YZJ As String = "月租金"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JYMJ As String = "交易面积"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JYJG As String = "交易价格"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_ZDLF As String = "总代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_AJFH As String = "按揭返还"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JBDW As String = "经办单位"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JBDWMC As String = "经办单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JBRY As String = "经办人员"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_TS As String = "套数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_ZS As String = "宗数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_SSK As String = "实收款"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_SSDLF As String = "实收代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_SFBL As String = "收费比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_SFBZ As String = "收费标准"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_CYJ As String = "诚意金"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-05-21

        'zengxianglin 2009-05-21
        '“中介部二手业务代理清单_接案1_已审”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESYWDLQD_JA1_YS As String = "中介部二手业务代理清单_接案1_已审"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_XSJB As String = "显示级别"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_PQDM As String = "片区代码"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_PQMC As String = "片区名称"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JYPX As String = "交易排序"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_DGRQ As String = "订购日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_TJRQ As String = "统计日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JARQ As String = "结案日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_HTZT As String = "合同状态"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_ZQ As String = "租期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_YZJ As String = "月租金"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JYMJ As String = "交易面积"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JYJG As String = "交易价格"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_ZDLF As String = "总代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_AJFH As String = "按揭返还"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JBDW As String = "经办单位"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JBDWMC As String = "经办单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JBRY As String = "经办人员"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_TS As String = "套数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_ZS As String = "宗数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_SSK As String = "实收款"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_SSDLF As String = "实收代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_SFBL As String = "收费比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_SFBZ As String = "收费标准"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_CYJ As String = "诚意金"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-05-21

        'zengxianglin 2009-05-21
        '“中介部二手业务代理清单_已接未结完”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESYWDLQD_YJWJW As String = "中介部二手业务代理清单_已接未结完"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_XSJB As String = "显示级别"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_PQDM As String = "片区代码"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_PQMC As String = "片区名称"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JYPX As String = "交易排序"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_DGRQ As String = "订购日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_TJRQ As String = "统计日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JARQ As String = "结案日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_HTZT As String = "合同状态"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_ZQ As String = "租期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_YZJ As String = "月租金"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JYMJ As String = "交易面积"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JYJG As String = "交易价格"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_ZDLF As String = "总代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_AJFH As String = "按揭返还"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JBDW As String = "经办单位"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JBDWMC As String = "经办单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JBRY As String = "经办人员"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_TS As String = "套数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_ZS As String = "宗数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_SSK As String = "实收款"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_SSDLF As String = "实收代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_SFBL As String = "收费比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_SFBZ As String = "收费标准"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_CYJ As String = "诚意金"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-05-21

        'zengxianglin 2008-11-28
        '“中介部二手业务代理清单_结案”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESYWDLQD_WC As String = "中介部二手业务代理清单_结案"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_XSJB As String = "显示级别"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JYPX As String = "交易排序"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_DGRQ As String = "订购日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_TJRQ As String = "统计日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JARQ As String = "结案日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_ZQ As String = "租期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_YZJ As String = "月租金"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JYMJ As String = "交易面积"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JYJG As String = "交易价格"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_ZDLF As String = "总代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_AJFH As String = "按揭返还"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JBDW As String = "经办单位"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JBDWMC As String = "经办单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JBRY As String = "经办人员"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_TS As String = "套数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_ZS As String = "宗数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_SSK As String = "实收款"
        'zengxianglin 2009-02-24
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_SSDLF As String = "实收代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_SFBL As String = "收费比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_SFBZ As String = "收费标准"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_WC_CYJ As String = "诚意金"
        'zengxianglin 2009-02-24
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-11-28

        'zengxianglin 2008-11-28
        '“中介部二手业务代理清单_已接未结案”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESYWDLQD_YJWJ As String = "中介部二手业务代理清单_已接未结案"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_XSJB As String = "显示级别"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JYPX As String = "交易排序"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_DGRQ As String = "订购日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_TJRQ As String = "统计日期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_ZQ As String = "租期"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_YZJ As String = "月租金"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JYMJ As String = "交易面积"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JYJG As String = "交易价格"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_ZDLF As String = "总代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_AJFH As String = "按揭返还"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JBDW As String = "经办单位"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JBDWMC As String = "经办单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JBRY As String = "经办人员"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_TS As String = "套数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_ZS As String = "宗数"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_SSK As String = "实收款"
        'zengxianglin 2009-02-24
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_SSDLF As String = "实收代理费"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_SFBL As String = "收费比例"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_SFBZ As String = "收费标准"
        Public Const FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_CYJ As String = "诚意金"
        'zengxianglin 2009-02-24
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-11-28

        'zengxianglin 2008-12-01
        '“中介部二手计佣清单_私佣”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESJYQD_SY As String = "中介部二手计佣清单_私佣"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_XSJB As String = "显示级别"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_DGRQ As String = "订购日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_JSRQ As String = "结算日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_JSSH As String = "结算书号"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_ZZJF As String = "总中介费"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_ZLSF As String = "总律师费"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_YJHJ As String = "佣金合计"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_JBDW As String = "经办单位"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_JBDWMC As String = "经办单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_JBRY As String = "经办人员"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_RYZJ As String = "人员职级"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_RYZJMC As String = "人员职级名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_SSYWJL As String = "所属业务经理"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_SSYYJL As String = "所属营业经理"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_SSZJYYJL As String = "所属中级营业经理"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_SSGJYYJL As String = "所属高级营业经理"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_SSZSYYJL As String = "所属资深营业经理"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_SSXZZL As String = "所属行政助理"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_SSQYJL As String = "所属区域经理"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_SSQYZJ As String = "所属区域总监"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_BZXX As String = "备注信息"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-12-01

        'zengxianglin 2008-12-01
        '“中介部二手计佣清单_公佣”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESJYQD_GY As String = "中介部二手计佣清单_公佣"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_XSJB As String = "显示级别"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_DGRQ As String = "订购日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_JSRQ As String = "结算日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_JSSH As String = "结算书号"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_ZZJF As String = "总中介费"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_ZLSF As String = "总律师费"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_YJHJ As String = "佣金合计"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_BCJT As String = "本次计提"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_BCBL As String = "本次保留"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_JTHJ As String = "计提合计"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_JBDW As String = "经办单位"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_JBDWMC As String = "经办单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_JBRY As String = "经办人员"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_RYZJ As String = "人员职级"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_RYZJMC As String = "人员职级名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_BZXX As String = "备注信息"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-12-01

        'zengxianglin 2008-12-01
        '“地产_B_二手_交易合同结算书业绩补发”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_JYHTJSSYJBF As String = "地产_B_二手_交易合同结算书业绩补发"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_B_ES_JYHTJSSYJBF_WYBS As String = "唯一标识"
        '===========================================================================================
        Public Const FIELD_DC_B_ES_JYHTJSSYJBF_BFYD As String = "补发月度"
        Public Const FIELD_DC_B_ES_JYHTJSSYJBF_RYDM As String = "人员代码"
        '===========================================================================================
        Public Const FIELD_DC_B_ES_JYHTJSSYJBF_BFJE As String = "补发金额"
        '显示字段序列
        Public Const FIELD_DC_B_ES_JYHTJSSYJBF_RYMC As String = "人员名称"
        Public Const FIELD_DC_B_ES_JYHTJSSYJBF_SJBF As String = "实际补发"
        '约束错误信息
        'zengxianglin 2008-12-01

        'zengxianglin 2008-12-01
        '“中介部二手代理区域情况表”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESDLQYQKB As String = "中介部二手代理区域情况表"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_XSJB As String = "显示级别"
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_XSMC As String = "显示名称"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_SZQY As String = "所在区域"
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_QYMC As String = "区域名称"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_MMMJ As String = "面积买卖"
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_MMTS As String = "套数买卖"
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_MMZS As String = "宗数买卖"
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_MMDLF As String = "代理费买卖"
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_MMJYJE As String = "交易金额买卖"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_ZLMJ As String = "面积租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_ZLTS As String = "套数租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_ZLZS As String = "宗数租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_ZLDLF As String = "代理费租赁"
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_ZLJYJE As String = "交易金额租赁"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_QTMJ As String = "面积其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_QTTS As String = "套数其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_QTZS As String = "宗数其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_QTDLF As String = "代理费其他"
        Public Const FIELD_DC_VT_ES_BB_ESDLQYQKB_QTJYJE As String = "交易金额其他"
        '===========================================================================================
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-12-01

        'zengxianglin 2008-12-01
        '“中介部二手区域业绩排行榜”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_PHBQYYJ As String = "中介部二手区域业绩排行榜"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_PHBQYYJ_SZQY As String = "所在区域"
        Public Const FIELD_DC_VT_ES_BB_PHBQYYJ_QYMC As String = "区域名称"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_PHBQYYJ_MJ As String = "面积"
        Public Const FIELD_DC_VT_ES_BB_PHBQYYJ_TS As String = "套数"
        Public Const FIELD_DC_VT_ES_BB_PHBQYYJ_ZS As String = "宗数"
        Public Const FIELD_DC_VT_ES_BB_PHBQYYJ_DLF As String = "代理费"
        Public Const FIELD_DC_VT_ES_BB_PHBQYYJ_AJFH As String = "按揭返还"
        Public Const FIELD_DC_VT_ES_BB_PHBQYYJ_JYJE As String = "交易金额"
        'zengxianglin 2009-05-21
        Public Const FIELD_DC_VT_ES_BB_PHBQYYJ_SJDLF As String = "实结代理费"
        'zengxianglin 2009-05-21
        '===========================================================================================
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-12-01

        'zengxianglin 2008-12-01
        '“中介部二手部门业绩排行榜”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_PHBBMYJ As String = "中介部二手部门业绩排行榜"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_PHBBMYJ_DWDM As String = "单位代码"
        Public Const FIELD_DC_VT_ES_BB_PHBBMYJ_DWMC As String = "单位名称"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_PHBBMYJ_MJ As String = "面积"
        Public Const FIELD_DC_VT_ES_BB_PHBBMYJ_TS As String = "套数"
        Public Const FIELD_DC_VT_ES_BB_PHBBMYJ_ZS As String = "宗数"
        Public Const FIELD_DC_VT_ES_BB_PHBBMYJ_DLF As String = "代理费"
        Public Const FIELD_DC_VT_ES_BB_PHBBMYJ_AJFH As String = "按揭返还"
        Public Const FIELD_DC_VT_ES_BB_PHBBMYJ_JYJE As String = "交易金额"
        'zengxianglin 2009-05-21
        Public Const FIELD_DC_VT_ES_BB_PHBBMYJ_SJDLF As String = "实结代理费"
        'zengxianglin 2009-05-21
        '===========================================================================================
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-12-01

        'zengxianglin 2008-12-01
        '“中介部二手人员业绩排行榜”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_PHBRYYJ As String = "中介部二手人员业绩排行榜"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_PHBRYYJ_RYDM As String = "人员代码"
        Public Const FIELD_DC_VT_ES_BB_PHBRYYJ_RYMC As String = "人员名称"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_PHBRYYJ_MJ As String = "面积"
        Public Const FIELD_DC_VT_ES_BB_PHBRYYJ_TS As String = "套数"
        Public Const FIELD_DC_VT_ES_BB_PHBRYYJ_ZS As String = "宗数"
        Public Const FIELD_DC_VT_ES_BB_PHBRYYJ_DLF As String = "代理费"
        Public Const FIELD_DC_VT_ES_BB_PHBRYYJ_AJFH As String = "按揭返还"
        Public Const FIELD_DC_VT_ES_BB_PHBRYYJ_JYJE As String = "交易金额"
        'zengxianglin 2009-05-21
        Public Const FIELD_DC_VT_ES_BB_PHBRYYJ_SJDLF As String = "实结代理费"
        'zengxianglin 2009-05-21
        '===========================================================================================
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-12-01

        'zengxianglin 2008-12-02
        '“中介部二手业绩年度对比”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_NDDB As String = "中介部二手业绩年度对比"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_NDDB_TJND As String = "统计年度"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_NDDB_M01 As String = "1月"
        Public Const FIELD_DC_VT_ES_BB_NDDB_M02 As String = "2月"
        Public Const FIELD_DC_VT_ES_BB_NDDB_M03 As String = "3月"
        Public Const FIELD_DC_VT_ES_BB_NDDB_M04 As String = "4月"
        Public Const FIELD_DC_VT_ES_BB_NDDB_M05 As String = "5月"
        Public Const FIELD_DC_VT_ES_BB_NDDB_M06 As String = "6月"
        Public Const FIELD_DC_VT_ES_BB_NDDB_M07 As String = "7月"
        Public Const FIELD_DC_VT_ES_BB_NDDB_M08 As String = "8月"
        Public Const FIELD_DC_VT_ES_BB_NDDB_M09 As String = "9月"
        Public Const FIELD_DC_VT_ES_BB_NDDB_M10 As String = "10月"
        Public Const FIELD_DC_VT_ES_BB_NDDB_M11 As String = "11月"
        Public Const FIELD_DC_VT_ES_BB_NDDB_M12 As String = "12月"
        '===========================================================================================
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-12-02

        'zengxianglin 2008-12-04
        '“中介部二手佣金分配表”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_YJFPB As String = "中介部二手佣金分配表"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_YJFPB_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_XSJB As String = "显示级别"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_YJFPB_JTNY As String = "计提年月"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_RYDM As String = "人员代码"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_RYMC As String = "人员名称"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_RYZJ As String = "人员职级"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_ZJMC As String = "职级名称"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_YJFPB_GRYJDLF As String = "个人业绩代理费"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_GRYJLSF As String = "个人业绩律师费"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_TDYJ As String = "团队业绩"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_YJFPB_YJHJ As String = "佣金合计"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_SYDLF As String = "私佣代理费"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_SYLSF As String = "私佣律师费"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_GYYWJL As String = "公佣业务经理"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_GYYYJLZG As String = "公佣营业经理直管"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_GYYYJLXG As String = "公佣营业经理协管"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_GYQYJL As String = "公佣区域经理"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_GYQYZJ As String = "公佣区域总监"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_GYXZZL As String = "公佣行政助理"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_FFTZ As String = "发放调整"
        '===========================================================================================
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-12-04

        'zengxianglin 2010-01-18
        '“中介部二手计佣清单_私佣_X2”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESJYQD_SY_X2 As String = "中介部二手计佣清单_私佣_X2"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_XSJB As String = "显示级别"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JYBZ As String = "计佣标准"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_DGRQ As String = "订购日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JSRQ As String = "结算日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JYRQ As String = "计佣日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JSSH As String = "结算书号"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_ZZJF As String = "总中介费"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_ZLSF As String = "总律师费"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_YJHJ As String = "佣金合计"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JBDW As String = "经办单位"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JBDWMC As String = "经办单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_TDBH As String = "团队编号"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JBRY As String = "经办人员"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_RYZJ As String = "人员职级"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_RYZJMC As String = "人员职级名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_YWJL As String = "业务经理"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_ZGYYJL As String = "直管营业经理"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_XGYYJL As String = "协管营业经理"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_XZZL As String = "行政助理"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_QYJL As String = "区域经理"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_QYZJ As String = "区域总监"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_BZXX As String = "备注信息"
        'zengxianglin 2011-03-22
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_YMZJ As String = "月末职级"
        'zengxianglin 2011-03-22
        '显示字段序列
        '约束错误信息
        'zengxianglin 2010-01-18

        'zengxianglin 2010-01-18
        '“中介部二手计佣清单_公佣_X2”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_ESJYQD_GY_X2 As String = "中介部二手计佣清单_公佣_X2"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_XSJB As String = "显示级别"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JYBZ As String = "计佣标准"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_DGRQ As String = "订购日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JSRQ As String = "结算日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JYRQ As String = "计佣日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JSSH As String = "结算书号"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_ZZJF As String = "总中介费"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_ZLSF As String = "总律师费"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_YJHJ As String = "佣金合计"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_BCJT As String = "本次计提"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_BCBL As String = "本次保留"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JTHJ As String = "计提合计"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JBDW As String = "经办单位"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JBDWMC As String = "经办单位名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_TDBH As String = "团队编号"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_ZGBJ As String = "直管标记"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JBRY As String = "经办人员"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_RYZJ As String = "人员职级"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_RYZJMC As String = "人员职级名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_BZXX As String = "备注信息"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_SYRY As String = "试用人员"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_TDRS As String = "团队人数"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_TDLX As String = "团队类型"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_SJWC As String = "实际完成"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_RWZB As String = "任务指标"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_WCBL As String = "完成比例"
        'zengxianglin 2011-01-18
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JYNY As String = "计佣年月"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JANY As String = "接案年月"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_YMRQ As String = "月末日期"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_YCYJ As String = "月初业绩"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_YCJT As String = "月初佣金"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_YMYJ As String = "月末佣金"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_RJYJ As String = "人均业绩"
        'zengxianglin 2011-01-18
        'zengxianglin 2011-03-22
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JYZJ As String = "计佣职级"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JYDJ As String = "计佣档级"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JYZJMC As String = "计佣职级名称"
        Public Const FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_YMZJ As String = "月末职级"
        'zengxianglin 2011-03-22
        '显示字段序列
        '约束错误信息
        'zengxianglin 2010-01-18

        'zengxianglin 2010-01-18
        '“中介部二手佣金分配表_X2”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_YJFPB_X2 As String = "中介部二手佣金分配表_X2"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_XSJB As String = "显示级别"
        '===========================================================================================
        'Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JTSD As String = "计提时段"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JBRY As String = "经办人员"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JBDW As String = "经办单位"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JBDWMC As String = "经办单位名称"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_TDBH As String = "团队编号"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_ZGBJ As String = "直管标记"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_RYZJ As String = "人员职级"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_RYZJMC As String = "人员职级名称"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JYBZ As String = "计佣标准"
        'Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_BYJY As String = "本月结佣"
        'Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_SYJS As String = "私佣业绩"
        'Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_SYYJ As String = "私佣佣金"
        'Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_GYJS As String = "公佣业绩"
        'Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_GYYJ As String = "公佣佣金"
        'Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_GYBL As String = "公佣保留"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_SYRY As String = "试用人员"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_TDRS As String = "团队人数"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_TDLX As String = "团队类型"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_SJWC As String = "实际完成"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_RWZB As String = "任务指标"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_WCBL As String = "完成比例"
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_DGRQ As String = "订购日期"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JSRQ As String = "结算日期"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JYRQ As String = "计佣日期"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JSSH As String = "结算书号"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_ZTBZ As String = "状态标志"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_ZZJF As String = "总中介费"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_ZLSF As String = "总律师费"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_YJHJ As String = "佣金合计"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_BCJT As String = "本次计提"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_BCBL As String = "本次保留"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JTHJ As String = "计提合计"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_FPBL As String = "分配比例"
        '===========================================================================================
        'zengxianglin 2011-01-18
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JYNY As String = "计佣年月"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JANY As String = "接案年月"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_YMRQ As String = "月末日期"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_YCYJ As String = "月初业绩"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_YCJT As String = "月初佣金"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_YMYJ As String = "月末佣金"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_RJYJ As String = "人均业绩"
        'zengxianglin 2011-01-18
        'zengxianglin 2011-03-22
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JYZJ As String = "计佣职级"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JYDJ As String = "计佣档级"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_JYZJMC As String = "计佣职级名称"
        Public Const FIELD_DC_VT_ES_BB_YJFPB_X2_YMZJ As String = "月末职级"
        'zengxianglin 2011-03-22

        'zengxianglin 2011-01-07
        '“中介部二手佣金分配表_X2”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_YSWSYJB As String = "中介部二手应收未收佣金报表"
        '字段序列
        '===========================================================================================
        Public Const FIELD_DC_VT_ES_BB_YSWSYJB_XYSS As String = "兴业实收"
        Public Const FIELD_DC_VT_ES_BB_YSWSYJB_SJYJ As String = "实结佣金"
        Public Const FIELD_DC_VT_ES_BB_YSWSYJB_WSYJ As String = "未收佣金"
        'zengxianglin 2011-01-07

        'zengxianglin 2011-01-09
        '“中介部客源信息表”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_KYXXB As String = "中介部客源信息表"
        '字段序列
        Public Const FIELD_DC_VT_ES_BB_KYXXB_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_KYBH As String = "客源编号"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_YFLXDZ As String = "乙方联系地址"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_YFLXDH As String = "乙方联系电话"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_YFZZHM As String = "乙方证照号码"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_YFDLR As String = "乙方代理人"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_YFZJLX As String = "乙方证件类型"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_MJQC As String = "买家区码"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_MJQN As String = "买家区名"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_KHLY As String = "客户来源"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_KYQT As String = "客源其他"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_KHDY As String = "客户电邮"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_GMMD As String = "购买目的"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_JYBH As String = "交易编号"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_JYRQ As String = "交易日期"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_TJRQ As String = "统计日期"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_JYJG As String = "交易价格"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_JYMJ As String = "交易面积"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_SSYJ As String = "实收佣金"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_JYZT As String = "交易状态"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_HTZT As String = "合同状态"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_HTJC As String = "合同解除"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_HZHT As String = "坏账合同"
        Public Const FIELD_DC_VT_ES_BB_KYXXB_HTZTMC As String = "合同状态名称"
        'zengxianglin 2011-01-09
        '约束错误信息
        '显示字段序列

        'zengxianglin 2011-01-09
        '“中介部房源信息表”表信息定义
        '表名称
        Public Const TABLE_DC_VT_ES_BB_FYXXB As String = "中介部房源信息表"
        '字段序列
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JYLX As String = "交易类型"
        '
        Public Const FIELD_DC_VT_ES_BB_FYXXB_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_FYBH As String = "房源编号"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JFLXDZ As String = "甲方联系地址"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JFLXDH As String = "甲方联系电话"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JFZZHM As String = "甲方证照号码"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JFDLR As String = "甲方代理人"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JFZJLX As String = "甲方证件类型"
        '
        Public Const FIELD_DC_VT_ES_BB_FYXXB_FWDZ As String = "房屋地址"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_FCZH As String = "房产证号"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_FCZDZ As String = "房产证地址"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_LP As String = "楼盘"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_LD As String = "楼栋"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_DY As String = "单元"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_MJ As String = "面积"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_ZX As String = "座向"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_LG As String = "楼高"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_LC As String = "楼层"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_LL As String = "楼龄"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JG As String = "间隔"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JGMC As String = "间隔名称"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_WYXZ As String = "物业性质"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_WYXZMC As String = "物业性质名称"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_SZQY As String = "所在区域"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_SZQYMC As String = "所在区域名称"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JCSJ As String = "建成时间"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_KJLX As String = "空间类型"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_FWXZ As String = "房屋性质"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_ZXDC As String = "装修档次"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_ZXNX As String = "装修年限"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_ZYYX As String = "噪音影响"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JJSB As String = "家具设备"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_LYJT As String = "楼宇交通"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_FWJG As String = "房屋间隔"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JGLX As String = "景观类型"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JGFS As String = "景观房数"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_WSSL As String = "卧室数量"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_YTSL As String = "阳台数量"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_DTSL As String = "电梯数量"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_LCHS As String = "楼层户数"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_LPQS As String = "楼盘期数"
        '
        Public Const FIELD_DC_VT_ES_BB_FYXXB_YZQC As String = "业主区码"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_YZQN As String = "业主区名"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_YZLY As String = "业主来源"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_YYQT As String = "业源其他"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_YZDY As String = "业主电邮"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_SHYX As String = "售后意向"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_SYWY As String = "剩余物业"
        '
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JYBH As String = "交易编号"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JYRQ As String = "交易日期"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_TJRQ As String = "统计日期"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JYJG As String = "交易价格"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JYMJ As String = "交易面积"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_SSYJ As String = "实收佣金"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_JYZT As String = "交易状态"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_HTZT As String = "合同状态"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_HTJC As String = "合同解除"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_HZHT As String = "坏账合同"
        Public Const FIELD_DC_VT_ES_BB_FYXXB_HTZTMC As String = "合同状态名称"
        'zengxianglin 2011-01-09
        '约束错误信息
        '显示字段序列

        'zengxianglin 2011-01-18
        '“地产_B_二手_佣金计提”表信息定义
        '表名称
        Public Const TABLE_DC_B_ES_YJJT As String = "地产_B_二手_佣金计提"
        '字段序列
        Public Const FIELD_DC_B_ES_YJJT_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_ES_YJJT_JYNY As String = "计佣年月"
        Public Const FIELD_DC_B_ES_YJJT_JANY As String = "接案年月"
        Public Const FIELD_DC_B_ES_YJJT_JYKS As String = "计佣开始"
        Public Const FIELD_DC_B_ES_YJJT_JYJS As String = "计佣结束"
        Public Const FIELD_DC_B_ES_YJJT_JBRY As String = "经办人员"
        Public Const FIELD_DC_B_ES_YJJT_JYBZ As String = "计佣标准"
        Public Const FIELD_DC_B_ES_YJJT_JBDW As String = "经办单位"
        Public Const FIELD_DC_B_ES_YJJT_TDBH As String = "团队编号"
        Public Const FIELD_DC_B_ES_YJJT_ZGBJ As String = "直管标记"
        Public Const FIELD_DC_B_ES_YJJT_RYZJ As String = "人员职级"
        Public Const FIELD_DC_B_ES_YJJT_YJBJ As String = "业绩标记"
        Public Const FIELD_DC_B_ES_YJJT_YCYJ As String = "月初业绩"
        Public Const FIELD_DC_B_ES_YJJT_BYYJ As String = "本月业绩"
        Public Const FIELD_DC_B_ES_YJJT_JTYJ As String = "计提佣金"
        '约束错误信息
        '显示字段序列
        Public Const FIELD_DC_B_ES_YJJT_JBRYMC As String = "经办人员名称"
        Public Const FIELD_DC_B_ES_YJJT_JBDWMC As String = "经办单位名称"
        Public Const FIELD_DC_B_ES_YJJT_RYZJMC As String = "人员职级名称"
        'zengxianglin 2011-01-18





        '定义初始化表类型enum
        Public Enum enumTableType
            DC_B_ES_QUERENSHU_MM = 1
            DC_B_ES_WUYE_MM = 2

            DC_B_ES_QUERENSHU_ZL = 3
            DC_B_ES_WUYE_ZL = 4

            DC_B_ES_QUERENSHU_SH = 5

            DC_B_ES_HETONG = 6
            DC_B_ES_HETONG_FPBL = 7
            DC_B_ES_HETONG_SHENHE = 8
            DC_B_ES_HETONG_ZHEKOUSHENHE = 9
            DC_B_ES_ZULINQIXIAN = 10

            DC_B_ES_HETONG_BANANJIHUA = 11
            DC_B_ES_HETONG_BANLIJILU = 12

            DC_B_ES_HETONG_JIESUANSHU = 13
            DC_B_ES_HETONG_JIESUANSHU_MINGXI = 14
            DC_B_ES_HETONG_JIESUANSHU_YEJI = 15
            DC_B_ES_HETONG_JIESUANSHU_SHENHE = 16

            DC_V_QUANBUJIAOYI = 17

            DC_B_ES_QUERENSHU_QT = 18
            DC_B_ES_WUYE_QT = 19

            'zengxianglin 2008-11-24
            DC_VT_ES_BB_ESDLJSQKB_GFH = 20
            'zengxianglin 2008-11-24

            'zengxianglin 2008-11-26
            DC_VT_ES_BB_ESDLJSQKB_GYW = 21
            DC_VT_ES_BB_ESDLJAQKB_GFH = 22
            DC_VT_ES_BB_ESDLWCQKB_GFH = 23
            'zengxianglin 2008-11-26

            'zengxianglin 2008-11-28
            DC_B_ES_JYNDJH = 24
            DC_VT_ES_BB_ESDLJSQKB_GYD = 25
            DC_VT_ES_BB_ESYWDLQD_JA = 26
            DC_VT_ES_BB_ESYWDLQD_WC = 27
            DC_VT_ES_BB_ESYWDLQD_YJWJ = 28
            'zengxianglin 2008-11-28

            'zengxianglin 2008-12-01
            DC_VT_ES_BB_ESJYQD_SY = 29
            DC_VT_ES_BB_ESJYQD_GY = 30
            DC_B_ES_JYHTJSSYJBF = 31
            DC_VT_ES_BB_ESDLQYQKB = 32
            DC_VT_ES_BB_PHBQYYJ = 33
            DC_VT_ES_BB_PHBBMYJ = 34
            DC_VT_ES_BB_PHBRYYJ = 35
            DC_VT_ES_BB_NDDB = 36
            DC_VT_ES_BB_YJFPB = 37
            'zengxianglin 2008-12-01

            'zengxianglin 2009-02-24
            DC_VT_ES_BB_ESYWDLQD_JA_WS = 38
            'zengxianglin 2009-02-24

            'zengxianglin 2009-05-17
            DC_B_ES_QUERENSHU_MM_PRN = 39
            DC_B_ES_QUERENSHU_ZL_PRN = 40
            DC_B_ES_QUERENSHU_QT_PRN = 41
            'zengxianglin 2009-05-17

            'zengxianglin 2009-05-18
            DC_V_QUANBUJIAOYI_MM = 42
            DC_V_QUANBUJIAOYI_ZL = 43
            DC_V_QUANBUJIAOYI_QT = 44
            'zengxianglin 2009-05-18

            'zengxianglin 2009-05-21
            DC_VT_ES_BB_ESYWDLQD_JA_ALL = 45
            DC_VT_ES_BB_ESYWDLQD_JA1_ALL = 46
            DC_VT_ES_BB_ESYWDLQD_JA1_YS = 47
            DC_VT_ES_BB_ESYWDLQD_YJWJW = 48
            'zengxianglin 2009-05-21

            'zengxianglin 2010-01-18
            DC_VT_ES_BB_ESJYQD_SY_X2 = 49
            DC_VT_ES_BB_ESJYQD_GY_X2 = 50
            DC_VT_ES_BB_YJFPB_X2 = 51
            'zengxianglin 2010-01-18

            'zengxianglin 2011-01-07
            DC_VT_ES_BB_YSWSYJB = 52
            DC_VT_ES_BB_KYXXB = 53
            DC_VT_ES_BB_FYXXB = 54
            'zengxianglin 2011-01-07

            'zengxianglin 2011-01-18
            DC_B_ES_YJJT = 55
            'zengxianglin 2011-01-18
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.Common.Data.estateErshouData)
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
        '折扣审核状态
        Public Enum enumZhekouShenheType
            YJ = 1 '一级审核
            EJ = 2 '二级审核
            SJ = 4 '三级审核
        End Enum

        '结算业绩类型
        Public Enum enumJiesuanYeji
            ZJF = 1 '中介费
            LSF = 2 '律师费
        End Enum

        '变更类型
        Public Const BGLX_TADING_QRS As String = "确认书挞定"
        Public Const BGLX_TADING_HT As String = "合同挞定"

        '业务类型
        Public Const YWLX_ES_MM As String = "二手.买卖"
        Public Const YWLX_ES_ZL As String = "二手.租赁"
        Public Const YWLX_ES_QT As String = "二手.其他"

        '结算类型
        Public Const JSLX_ZJF As String = "中介费"
        Public Const JSLX_LSF As String = "律师费"
        Public Shared Function getJiesuanLeixingStatusName(ByVal intStatus As Integer) As String
            Try
                If (intStatus And 1) = 1 Then
                    getJiesuanLeixingStatusName = "中介费"
                ElseIf (intStatus And 2) = 2 Then
                    getJiesuanLeixingStatusName = "律师费"
                Else
                    getJiesuanLeixingStatusName = ""
                End If
            Catch ex As Exception
                getJiesuanLeixingStatusName = ""
            End Try
        End Function

        '审核签名状态
        Public Enum enumShenheStatus
            Weishen = 0             '未审
            Quxiao = 1              '签名取消
            Shenhe = 4              '审核签名
            Shending = 8            '审定签名
        End Enum
        Public Shared Function getShenheStatus(ByVal intStatus As Integer) As enumShenheStatus
            Try
                If (intStatus And 1) = 1 Then
                    getShenheStatus = enumShenheStatus.Quxiao
                    Exit Try
                End If
                If (intStatus And 15) = 14 Then
                    getShenheStatus = enumShenheStatus.Shending
                    Exit Try
                End If
                If (intStatus And 15) = 6 Then
                    getShenheStatus = enumShenheStatus.Shenhe
                    Exit Try
                End If
                getShenheStatus = enumShenheStatus.Weishen
            Catch ex As Exception
                getShenheStatus = enumShenheStatus.Weishen
            End Try
        End Function

        '确认书状态
        Public Enum enumQuerenshuStatus
            Weishen = 0
            Yishen = 1
            Tading = 2
        End Enum
        Public Shared Function getQuerenshuStatus(ByVal intStatus As Integer) As enumQuerenshuStatus
            Try
                If (intStatus And 2) = 2 Then
                    getQuerenshuStatus = enumQuerenshuStatus.Tading
                    Exit Try
                End If
                If (intStatus And 3) = 1 Then
                    getQuerenshuStatus = enumQuerenshuStatus.Yishen
                    Exit Try
                End If
                getQuerenshuStatus = enumQuerenshuStatus.Weishen
            Catch ex As Exception
                getQuerenshuStatus = enumQuerenshuStatus.Weishen
            End Try
        End Function

        '合同状态
        Public Enum enumHetongStatus
            Weishen = 0
            Yishen = 1
            Wancheng = 2
        End Enum
        Public Shared Function getHetongStatus(ByVal intStatus As Integer) As enumHetongStatus
            Try
                If (intStatus And 2) = 2 Then
                    getHetongStatus = enumHetongStatus.Wancheng
                    Exit Try
                End If
                If (intStatus And 3) = 1 Then
                    getHetongStatus = enumHetongStatus.Yishen
                    Exit Try
                End If
                getHetongStatus = enumHetongStatus.Weishen
            Catch ex As Exception
                getHetongStatus = enumHetongStatus.Weishen
            End Try
        End Function

        '结算书状态
        Public Enum enumJiesuanshuStatus
            Weishen = 0
            Yishen = 1
        End Enum
        Public Shared Function getJiesuanshuStatus(ByVal intStatus As Integer) As enumJiesuanshuStatus
            Try
                If (intStatus And 1) = 1 Then
                    getJiesuanshuStatus = enumJiesuanshuStatus.Yishen
                    Exit Try
                End If
                getJiesuanshuStatus = enumJiesuanshuStatus.Weishen
            Catch ex As Exception
                getJiesuanshuStatus = enumJiesuanshuStatus.Weishen
            End Try
        End Function

        '直管标记状态
        Public Const ZGBJ_ZG As String = "直管"
        Public Const ZGBJ_XG As String = "协管"
        Public Const ZGBJ_WX As String = "无效"
        Public Shared Function getZhiguanStatusName(ByVal intStatus As Integer) As String
            Try
                Select Case intStatus
                    Case 0
                        getZhiguanStatusName = "协管"
                    Case 1
                        getZhiguanStatusName = "直管"
                    Case Else
                        getZhiguanStatusName = "无效"
                End Select
            Catch ex As Exception
                getZhiguanStatusName = "无效"
            End Try
        End Function
        Public Shared Function getZhiguanStatusName(ByVal strStatus As String) As String
            Try
                Dim intStatus As Integer = CType(strStatus, Integer)
                Select Case intStatus
                    Case 0
                        getZhiguanStatusName = "协管"
                    Case 1
                        getZhiguanStatusName = "直管"
                    Case Else
                        getZhiguanStatusName = "无效"
                End Select
            Catch ex As Exception
                getZhiguanStatusName = "无效"
            End Try
        End Function

        '业绩标记状态
        Public Const YJBJ_GY As String = "公佣"
        Public Const YJBJ_SY As String = "私佣"
        Public Const YJBJ_WX As String = "无效"
        Public Shared Function getYejiStatusName(ByVal intStatus As Integer) As String
            Try
                Select Case (intStatus And 1)
                    Case 0
                        getYejiStatusName = "公佣"
                    Case 1
                        getYejiStatusName = "私佣"
                    Case Else
                        getYejiStatusName = "无效"
                End Select
            Catch ex As Exception
                getYejiStatusName = "无效"
            End Try
        End Function
        Public Shared Function getYejiStatusName(ByVal strStatus As String) As String
            Try
                Dim intStatus As Integer = CType(strStatus, Integer)
                Select Case (intStatus And 1)
                    Case 0
                        getYejiStatusName = "公佣"
                    Case 1
                        getYejiStatusName = "私佣"
                    Case Else
                        getYejiStatusName = "无效"
                End Select
            Catch ex As Exception
                getYejiStatusName = "无效"
            End Try
        End Function

        'zengxianglin 2008-11-18
        ''是“买卖业务”
        'Public Shared Function isQuerenshu_Mm(ByVal strQRSH As String) As Boolean
        '    isQuerenshu_Mm = False
        '    Try
        '        If strQRSH Is Nothing Then
        '            Exit Try
        '        End If
        '        strQRSH = strQRSH.Trim
        '        If strQRSH = "" Then
        '            Exit Try
        '        End If
        '        If strQRSH.Substring(0, 2).ToUpper = "MD" Then
        '            isQuerenshu_Mm = True
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End Function
        ''是“租赁业务”
        'Public Shared Function isQuerenshu_Zl(ByVal strQRSH As String) As Boolean
        '    isQuerenshu_Zl = False
        '    Try
        '        If strQRSH Is Nothing Then
        '            Exit Try
        '        End If
        '        strQRSH = strQRSH.Trim
        '        If strQRSH = "" Then
        '            Exit Try
        '        End If
        '        If strQRSH.Substring(0, 2).ToUpper = "ZD" Then
        '            isQuerenshu_Zl = True
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End Function
        ''是“其他业务”
        'Public Shared Function isQuerenshu_Qt(ByVal strQRSH As String) As Boolean
        '    isQuerenshu_Qt = False
        '    Try
        '        If strQRSH Is Nothing Then
        '            Exit Try
        '        End If
        '        strQRSH = strQRSH.Trim
        '        If strQRSH = "" Then
        '            Exit Try
        '        End If
        '        If strQRSH.Substring(0, 2).ToUpper = "QD" Then
        '            isQuerenshu_Qt = True
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End Function
        'zengxianglin 2008-11-18











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
                Case enumTableType.DC_B_ES_QUERENSHU_MM
                    table = createDataTables_DC_B_ES_QUERENSHU_MM(strErrMsg)
                    'zengxianglin 2009-05-17
                Case enumTableType.DC_B_ES_QUERENSHU_MM_PRN
                    table = createDataTables_DC_B_ES_QUERENSHU_MM_PRN(strErrMsg)
                    'zengxianglin 2009-05-17
                Case enumTableType.DC_B_ES_WUYE_MM
                    table = createDataTables_DC_B_ES_WUYE_MM(strErrMsg)

                Case enumTableType.DC_B_ES_QUERENSHU_ZL
                    table = createDataTables_DC_B_ES_QUERENSHU_ZL(strErrMsg)
                    'zengxianglin 2009-05-17
                Case enumTableType.DC_B_ES_QUERENSHU_ZL_PRN
                    table = createDataTables_DC_B_ES_QUERENSHU_ZL_PRN(strErrMsg)
                    'zengxianglin 2009-05-17
                Case enumTableType.DC_B_ES_WUYE_ZL
                    table = createDataTables_DC_B_ES_WUYE_ZL(strErrMsg)

                Case enumTableType.DC_B_ES_QUERENSHU_QT
                    table = createDataTables_DC_B_ES_QUERENSHU_QT(strErrMsg)
                    'zengxianglin 2009-05-17
                Case enumTableType.DC_B_ES_QUERENSHU_QT_PRN
                    table = createDataTables_DC_B_ES_QUERENSHU_QT_PRN(strErrMsg)
                    'zengxianglin 2009-05-17
                Case enumTableType.DC_B_ES_WUYE_QT
                    table = createDataTables_DC_B_ES_WUYE_QT(strErrMsg)

                Case enumTableType.DC_B_ES_QUERENSHU_SH
                    table = createDataTables_DC_B_ES_QUERENSHU_SH(strErrMsg)

                Case enumTableType.DC_B_ES_HETONG_FPBL
                    table = createDataTables_DC_B_ES_HETONG_FPBL(strErrMsg)
                Case enumTableType.DC_B_ES_HETONG
                    table = createDataTables_DC_B_ES_HETONG(strErrMsg)
                Case enumTableType.DC_B_ES_HETONG_SHENHE
                    table = createDataTables_DC_B_ES_HETONG_SHENHE(strErrMsg)
                Case enumTableType.DC_B_ES_HETONG_ZHEKOUSHENHE
                    table = createDataTables_DC_B_ES_HETONG_ZHEKOUSHENHE(strErrMsg)
                Case enumTableType.DC_B_ES_ZULINQIXIAN
                    table = createDataTables_DC_B_ES_ZULINQIXIAN(strErrMsg)

                Case enumTableType.DC_B_ES_HETONG_BANANJIHUA
                    table = createDataTables_DC_B_ES_HETONG_BANANJIHUA(strErrMsg)
                Case enumTableType.DC_B_ES_HETONG_BANLIJILU
                    table = createDataTables_DC_B_ES_HETONG_BANLIJILU(strErrMsg)

                Case enumTableType.DC_B_ES_HETONG_JIESUANSHU
                    table = createDataTables_DC_B_ES_HETONG_JIESUANSHU(strErrMsg)
                Case enumTableType.DC_B_ES_HETONG_JIESUANSHU_MINGXI
                    table = createDataTables_DC_B_ES_HETONG_JIESUANSHU_MINGXI(strErrMsg)
                Case enumTableType.DC_B_ES_HETONG_JIESUANSHU_YEJI
                    table = createDataTables_DC_B_ES_HETONG_JIESUANSHU_YEJI(strErrMsg)
                Case enumTableType.DC_B_ES_HETONG_JIESUANSHU_SHENHE
                    table = createDataTables_DC_B_ES_HETONG_JIESUANSHU_SHENHE(strErrMsg)

                Case enumTableType.DC_V_QUANBUJIAOYI
                    table = createDataTables_DC_V_QUANBUJIAOYI(strErrMsg)
                    'zengxianglin 2009-05-18
                Case enumTableType.DC_V_QUANBUJIAOYI_MM
                    table = createDataTables_DC_V_QUANBUJIAOYI_MM(strErrMsg)
                Case enumTableType.DC_V_QUANBUJIAOYI_ZL
                    table = createDataTables_DC_V_QUANBUJIAOYI_ZL(strErrMsg)
                Case enumTableType.DC_V_QUANBUJIAOYI_QT
                    table = createDataTables_DC_V_QUANBUJIAOYI_QT(strErrMsg)
                    'zengxianglin 2009-05-18

                    'zengxianglin 2008-11-24
                Case enumTableType.DC_VT_ES_BB_ESDLJSQKB_GFH
                    table = createDataTables_DC_VT_ES_BB_ESDLJSQKB_GFH(strErrMsg)
                    'zengxianglin 2008-11-24

                    'zengxianglin 2008-11-26
                Case enumTableType.DC_VT_ES_BB_ESDLJSQKB_GYW
                    table = createDataTables_DC_VT_ES_BB_ESDLJSQKB_GYW(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_ESDLJAQKB_GFH
                    table = createDataTables_DC_VT_ES_BB_ESDLJAQKB_GFH(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_ESDLWCQKB_GFH
                    table = createDataTables_DC_VT_ES_BB_ESDLWCQKB_GFH(strErrMsg)
                    'zengxianglin 2008-11-26

                    'zengxianglin 2008-11-28
                Case enumTableType.DC_B_ES_JYNDJH
                    table = createDataTables_DC_B_ES_JYNDJH(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_ESDLJSQKB_GYD
                    table = createDataTables_DC_VT_ES_BB_ESDLJSQKB_GYD(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_ESYWDLQD_JA
                    table = createDataTables_DC_VT_ES_BB_ESYWDLQD_JA(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_ESYWDLQD_WC
                    table = createDataTables_DC_VT_ES_BB_ESYWDLQD_WC(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_ESYWDLQD_YJWJ
                    table = createDataTables_DC_VT_ES_BB_ESYWDLQD_YJWJ(strErrMsg)
                    'zengxianglin 2008-11-28
                    'zengxianglin 2009-02-24
                Case enumTableType.DC_VT_ES_BB_ESYWDLQD_JA_WS
                    table = createDataTables_DC_VT_ES_BB_ESYWDLQD_JA_WS(strErrMsg)
                    'zengxianglin 2009-02-24
                    'zengxianglin 2009-05-21
                Case enumTableType.DC_VT_ES_BB_ESYWDLQD_JA_ALL
                    table = createDataTables_DC_VT_ES_BB_ESYWDLQD_JA_ALL(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_ESYWDLQD_JA1_ALL
                    table = createDataTables_DC_VT_ES_BB_ESYWDLQD_JA1_ALL(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_ESYWDLQD_JA1_YS
                    table = createDataTables_DC_VT_ES_BB_ESYWDLQD_JA1_YS(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_ESYWDLQD_YJWJW
                    table = createDataTables_DC_VT_ES_BB_ESYWDLQD_YJWJW(strErrMsg)
                    'zengxianglin 2009-05-21

                    'zengxianglin 2008-12-01
                Case enumTableType.DC_VT_ES_BB_ESJYQD_SY
                    table = createDataTables_DC_VT_ES_BB_ESJYQD_SY(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_ESJYQD_GY
                    table = createDataTables_DC_VT_ES_BB_ESJYQD_GY(strErrMsg)
                Case enumTableType.DC_B_ES_JYHTJSSYJBF
                    table = createDataTables_DC_B_ES_JYHTJSSYJBF(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_ESDLQYQKB
                    table = createDataTables_DC_VT_ES_BB_ESDLQYQKB(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_PHBQYYJ
                    table = createDataTables_DC_VT_ES_BB_PHBQYYJ(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_PHBBMYJ
                    table = createDataTables_DC_VT_ES_BB_PHBBMYJ(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_PHBRYYJ
                    table = createDataTables_DC_VT_ES_BB_PHBRYYJ(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_NDDB
                    table = createDataTables_DC_VT_ES_BB_NDDB(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_YJFPB
                    table = createDataTables_DC_VT_ES_BB_YJFPB(strErrMsg)
                    'zengxianglin 2008-12-01

                    'zengxianglin 2010-01-18
                Case enumTableType.DC_VT_ES_BB_ESJYQD_SY_X2
                    table = createDataTables_DC_VT_ES_BB_ESJYQD_SY_X2(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_ESJYQD_GY_X2
                    table = createDataTables_DC_VT_ES_BB_ESJYQD_GY_X2(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_YJFPB_X2
                    table = createDataTables_DC_VT_ES_BB_YJFPB_X2(strErrMsg)
                    'zengxianglin 2010-01-18

                    'zengxianglin 2011-01-08
                Case enumTableType.DC_VT_ES_BB_YSWSYJB
                    table = createDataTables_DC_VT_ES_BB_YSWSYJB(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_KYXXB
                    table = createDataTables_DC_VT_ES_BB_KYXXB(strErrMsg)
                Case enumTableType.DC_VT_ES_BB_FYXXB
                    table = createDataTables_DC_VT_ES_BB_FYXXB(strErrMsg)
                    'zengxianglin 2011-01-08

                    'zengxianglin 2011-01-18
                Case enumTableType.DC_B_ES_YJJT
                    table = createDataTables_DC_B_ES_YJJT(strErrMsg)
                    'zengxianglin 2011-01-18
                Case Else
                    strErrMsg = "无效的表类型！"
                    table = Nothing
            End Select

            createDataTables = table

        End Function










        '----------------------------------------------------------------
        '创建TABLE_DC_V_QUANBUJIAOYI
        '----------------------------------------------------------------
        Private Function createDataTables_DC_V_QUANBUJIAOYI(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_V_QUANBUJIAOYI)
                With table.Columns
                    .Add(FIELD_DC_V_QUANBUJIAOYI_WYBS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JYLX, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JYBH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JYZT, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YZMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_KHMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_DLFZK, GetType(System.Double))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTBH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTLX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTRQ, GetType(System.DateTime))
                    'zengxianglin 2008-11-22
                    .Add(FIELD_DC_V_QUANBUJIAOYI_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JARQ, GetType(System.DateTime))
                    'zengxianglin 2008-11-22
                    'zengxianglin 2008-11-25
                    .Add(FIELD_DC_V_QUANBUJIAOYI_AJFH, GetType(System.Double))
                    'zengxianglin 2008-11-25
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTZT, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_FKFS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTWYBS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTZTMC, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_JFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JFZZHM, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JFDLR, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JFLXDH, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_YFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YFZZHM, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YFDLR, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YFLXDH, GetType(System.String))

                    'zengxianglin 2010-12-25
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTBZ, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JCRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HZRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HZJE, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTJC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HZHT, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_CCDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_CCF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_SSYJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HZYJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_AJJG, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_AJYH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_AJCS, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_AJNX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YZQC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YZQN, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YZLY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YYQT, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YZDY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_SHYX, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_SYWY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MJQC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MJQN, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_KHLY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_KYQT, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_KHDY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_GMMD, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZLKS, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZLJS, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_SDMQ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_DHF, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_GLF, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZLFP, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_KYBH, GetType(System.String))
                    'zengxianglin 2010-12-25
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_V_QUANBUJIAOYI = table

        End Function

        'zengxianglin 2009-05-18
        '----------------------------------------------------------------
        '创建TABLE_DC_V_QUANBUJIAOYI_MM
        '----------------------------------------------------------------
        Private Function createDataTables_DC_V_QUANBUJIAOYI_MM(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_V_QUANBUJIAOYI_MM)
                With table.Columns
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_WYBS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JYLX, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JYBH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JYZT, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_YZMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_KHMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_DLFZK, GetType(System.Double))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_HTBH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_HTLX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JARQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_HTZT, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_FKFS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_HTWYBS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_HTZTMC, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JFZZHM, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JFDLR, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JFLXDH, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_YFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_YFZZHM, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_YFDLR, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_YFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_YFLXDH, GetType(System.String))


                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JHJLRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_HTBZXX, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JLRQYDMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JLZKYDMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_SFZFYDMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_FKTGYDMC, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_HTLXMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_FKFSMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JFZJLXMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_YFZJLXMC, GetType(System.String))

                    'zengxianglin 2010-12-25
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_HTBZ, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_JCRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_HZRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_HZJE, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_HTJC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_HZHT, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_CCDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_CCF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_SSYJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_HZYJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_AJJG, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_AJYH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_AJCS, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_AJNX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_YZQC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_YZQN, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_YZLY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_YYQT, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_YZDY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_SHYX, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_SYWY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_MJQC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_MJQN, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_KHLY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_KYQT, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_KHDY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_GMMD, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_ZLKS, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_ZLJS, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_SDMQ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_DHF, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_GLF, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_ZLFP, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MM_KYBH, GetType(System.String))
                    'zengxianglin 2010-12-25
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_V_QUANBUJIAOYI_MM = table

        End Function
        'zengxianglin 2009-05-18

        'zengxianglin 2009-05-18
        '----------------------------------------------------------------
        '创建TABLE_DC_V_QUANBUJIAOYI_ZL
        '----------------------------------------------------------------
        Private Function createDataTables_DC_V_QUANBUJIAOYI_ZL(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_V_QUANBUJIAOYI_ZL)
                With table.Columns
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_WYBS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JYLX, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JYBH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JYZT, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_YZMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_KHMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_DLFZK, GetType(System.Double))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_HTBH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_HTLX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JARQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_HTZT, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_FKFS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_HTWYBS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_HTZTMC, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JFZZHM, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JFDLR, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JFLXDH, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_YFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_YFZZHM, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_YFDLR, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_YFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_YFLXDH, GetType(System.String))


                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JYYZJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_ZLBZJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_ZNJBL, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_NDZBL, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_ZQYS, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JZR, GetType(System.Int32))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JHJLRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_HTBZXX, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JLZKSM, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_FZFSYDMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_SFZFYDMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_ZJTGYDMC, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_HTLXMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_FKFSMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JFZJLXMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_YFZJLXMC, GetType(System.String))

                    'zengxianglin 2010-12-25
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_HTBZ, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_JCRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_HZRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_HZJE, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_HTJC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_HZHT, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_CCDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_CCF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_SSYJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_HZYJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_AJJG, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_AJYH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_AJCS, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_AJNX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_YZQC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_YZQN, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_YZLY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_YYQT, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_YZDY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_SHYX, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_SYWY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_MJQC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_MJQN, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_KHLY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_KYQT, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_KHDY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_GMMD, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_ZLKS, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_ZLJS, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_SDMQ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_DHF, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_GLF, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_ZLFP, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZL_KYBH, GetType(System.String))
                    'zengxianglin 2010-12-25
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_V_QUANBUJIAOYI_ZL = table

        End Function
        'zengxianglin 2009-05-18

        'zengxianglin 2009-05-18
        '----------------------------------------------------------------
        '创建TABLE_DC_V_QUANBUJIAOYI_QT
        '----------------------------------------------------------------
        Private Function createDataTables_DC_V_QUANBUJIAOYI_QT(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_V_QUANBUJIAOYI_QT)
                With table.Columns
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_WYBS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JYLX, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JYBH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JYZT, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_YZMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_KHMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_DLFZK, GetType(System.Double))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_HTBH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_HTLX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JARQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_HTZT, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_FKFS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_HTWYBS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_HTZTMC, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JFZZHM, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JFDLR, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JFLXDH, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_YFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_YFZZHM, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_YFDLR, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_YFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_YFLXDH, GetType(System.String))


                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JHJLRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_HTBZXX, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JLRQYDMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JLZKYDMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_SFZFYDMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_FKTGYDMC, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_HTLXMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_FKFSMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JFZJLXMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_YFZJLXMC, GetType(System.String))

                    'zengxianglin 2010-12-25
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_HTBZ, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_JCRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_HZRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_HZJE, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_HTJC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_HZHT, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_CCDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_CCF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_SSYJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_HZYJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_AJJG, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_AJYH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_AJCS, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_AJNX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_YZQC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_YZQN, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_YZLY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_YYQT, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_YZDY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_SHYX, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_SYWY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_MJQC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_MJQN, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_KHLY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_KYQT, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_KHDY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_GMMD, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_ZLKS, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_ZLJS, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_SDMQ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_DHF, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_GLF, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_ZLFP, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_QT_KYBH, GetType(System.String))
                    'zengxianglin 2010-12-25
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_V_QUANBUJIAOYI_QT = table

        End Function
        'zengxianglin 2009-05-18













        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_QUERENSHU_MM
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_QUERENSHU_MM(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_QUERENSHU_MM)
                With table.Columns
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_DGZT, GetType(System.Int32))

                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_JFMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_JFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_JFZZHM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_JFDLR, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_JFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_JFLXDH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_YFMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_YFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_YFZZHM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_YFDLR, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_YFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_YFLXDH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_FWDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_JYZJG, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_JYZMJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_DLFZK, GetType(System.Double))

                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_JHJYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_JLRQYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_JHJLRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_JLZKYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_FKFSYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_SFZFYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_FKTGYD, GetType(System.Int32))

                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_DJRDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_DJRMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_DJRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_BZXX, GetType(System.String))


                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_DGZTMC, GetType(System.String))

                    'zengxianglin 2010-12-25
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_CCDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_CCF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_SSYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_HZYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_AJJG, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_AJYH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_AJCS, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_AJNX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_YZQC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_YZQN, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_YZLY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_YYQT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_YZDY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_SHYX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_SYWY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_MJQC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_MJQN, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_KHLY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_KYQT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_KHDY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_GMMD, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_KYBH, GetType(System.String))
                    'zengxianglin 2010-12-25
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_QUERENSHU_MM = table

        End Function

        'zengxianglin 2009-05-17
        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_QUERENSHU_MM_PRN
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_QUERENSHU_MM_PRN(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_QUERENSHU_MM_PRN)
                With table.Columns
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_DGZT, GetType(System.Int32))

                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFZZHM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFDLR, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFLXDH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFZZHM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFDLR, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFLXDH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_FWDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JYZJG, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JYZMJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_DLFZK, GetType(System.Double))

                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JHJYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JLRQYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JHJLRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JLZKYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_FKFSYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_SFZFYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_FKTGYD, GetType(System.Int32))

                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_DJRDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_DJRMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_DJRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_BZXX, GetType(System.String))


                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_DGZTMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JFZJLXMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_YFZJLXMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JLRQYDMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_JLZKYDMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_FKFSYDMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_SFZFYDMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_FKTGYDMC, GetType(System.String))

                    'zengxianglin 2010-12-25
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_CCDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_CCF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_SSYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_HZYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_AJJG, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_AJYH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_AJCS, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_AJNX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_YZQC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_YZQN, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_YZLY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_YYQT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_YZDY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_SHYX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_SYWY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_MJQC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_MJQN, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_KHLY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_KYQT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_KHDY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_GMMD, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_MM_PRN_KYBH, GetType(System.String))
                    'zengxianglin 2010-12-25
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_QUERENSHU_MM_PRN = table

        End Function
        'zengxianglin 2009-05-17

        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_WUYE_MM
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_WUYE_MM(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_WUYE_MM)
                With table.Columns
                    .Add(FIELD_DC_B_ES_WUYE_MM_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_WYBM, GetType(System.String))

                    .Add(FIELD_DC_B_ES_WUYE_MM_FWDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_FCZH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_FCZDZ, GetType(System.String))

                    .Add(FIELD_DC_B_ES_WUYE_MM_MJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_WUYE_MM_JYJE, GetType(System.Double))

                    .Add(FIELD_DC_B_ES_WUYE_MM_ZX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_LC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_LL, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_MM_JG, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_WYXZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_SZQY, GetType(System.String))

                    .Add(FIELD_DC_B_ES_WUYE_MM_BZXX, GetType(System.String))


                    .Add(FIELD_DC_B_ES_WUYE_MM_JGMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_WYXZMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_SZQYMC, GetType(System.String))

                    'zengxianglin 2010-12-25
                    .Add(FIELD_DC_B_ES_WUYE_MM_FYBH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_LP, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_LD, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_DY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_JCSJ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_WUYE_MM_KJLX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_FWXZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_ZXDC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_ZXNX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_ZYYX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_JJSB, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_LYJT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_FWJG, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_JGLX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_MM_JGFS, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_MM_LG, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_MM_WSSL, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_MM_YTSL, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_MM_HYMJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_WUYE_MM_DTSL, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_MM_LCHS, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_MM_LPQS, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_MM_WYXX, GetType(System.String))
                    'zengxianglin 2010-12-25
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_WUYE_MM = table

        End Function












        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_QUERENSHU_SH
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_QUERENSHU_SH(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_QUERENSHU_SH)
                With table.Columns
                    .Add(FIELD_DC_B_ES_QUERENSHU_SH_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_SH_QRSH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_QUERENSHU_SH_SHRDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_SH_SHRMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_SH_SHRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_ES_QUERENSHU_SH_ZTBZ, GetType(System.Int32))


                    .Add(FIELD_DC_B_ES_QUERENSHU_SH_ZTBZMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_QUERENSHU_SH = table

        End Function












        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_HETONG_FPBL
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_HETONG_FPBL(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_HETONG_FPBL)
                With table.Columns
                    .Add(FIELD_DC_B_ES_HETONG_FPBL_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_FPBL_QRSH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_HETONG_FPBL_RYDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_FPBL_DWDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_FPBL_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_HETONG_FPBL_RYZJ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_FPBL_ZGBJ, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_HETONG_FPBL_ZTBZ, GetType(System.Int32))
                    'zengxianglin 2008-10-14
                    .Add(FIELD_DC_B_ES_HETONG_FPBL_SSFZ, GetType(System.String))
                    'zengxianglin 2008-10-14
                    'zengxianglin 2010-01-06
                    .Add(FIELD_DC_B_ES_HETONG_FPBL_TDBH, GetType(System.Int32))
                    'zengxianglin 2010-01-06


                    .Add(FIELD_DC_B_ES_HETONG_FPBL_RYMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_FPBL_DWMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_FPBL_RYZJMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_FPBL_ZGBJMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_FPBL_ZTBZMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_HETONG_FPBL = table

        End Function










        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_QUERENSHU_ZL
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_QUERENSHU_ZL(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_QUERENSHU_ZL)
                With table.Columns
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_DGZT, GetType(System.Int32))

                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_JFMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_JFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_JFZZHM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_JFDLR, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_JFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_JFLXDH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_YFMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_YFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_YFZZHM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_YFDLR, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_YFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_YFLXDH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_FWDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_JYZZJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_JYYZJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_ZLBZJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_JYZMJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_ZNJBL, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_NDZBL, GetType(System.Double))

                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_JHJYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_JHJLRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_JLZKSM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_FZFSYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_ZQYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_SFZFYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_ZJTGYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_JZR, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_ZQYS, GetType(System.Int32))

                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_DJRDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_DJRMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_DJRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_BZXX, GetType(System.String))


                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_DGZTMC, GetType(System.String))

                    'zengxianglin 2010-12-25
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_CCDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_CCF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_SSYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_HZYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_AJJG, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_AJYH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_AJCS, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_AJNX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_YZQC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_YZQN, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_YZLY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_YYQT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_YZDY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_SHYX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_SYWY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_MJQC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_MJQN, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_KHLY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_KYQT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_KHDY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_GMMD, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_ZLKS, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_ZLJS, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_SDMQ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_DHF, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_GLF, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_ZLFP, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_KYBH, GetType(System.String))
                    'zengxianglin 2010-12-25
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_QUERENSHU_ZL = table

        End Function

        'zengxianglin 2009-05-17
        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_QUERENSHU_ZL_PRN
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_QUERENSHU_ZL_PRN(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_QUERENSHU_ZL_PRN)
                With table.Columns
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DGZT, GetType(System.Int32))

                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFZZHM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFDLR, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFLXDH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFZZHM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFDLR, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFLXDH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_FWDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JYZZJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JYYZJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZLBZJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JYZMJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZNJBL, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_NDZBL, GetType(System.Double))

                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JHJYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JHJLRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JLZKSM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_FZFSYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZQYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_SFZFYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZJTGYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JZR, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZQYS, GetType(System.Int32))

                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DJRDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DJRMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DJRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_BZXX, GetType(System.String))


                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DGZTMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_JFZJLXMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YFZJLXMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_FZFSYDMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZQYDMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZJTGYDMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_SFZFYDMC, GetType(System.String))

                    'zengxianglin 2010-12-25
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_CCDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_CCF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_SSYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_HZYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_AJJG, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_AJYH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_AJCS, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_AJNX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YZQC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YZQN, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YZLY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YYQT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_YZDY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_SHYX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_SYWY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_MJQC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_MJQN, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_KHLY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_KYQT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_KHDY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_GMMD, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZLKS, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZLJS, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_SDMQ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_DHF, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_GLF, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_ZLFP, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_ZL_PRN_KYBH, GetType(System.String))
                    'zengxianglin 2010-12-25
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_QUERENSHU_ZL_PRN = table

        End Function
        'zengxianglin 2009-05-17

        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_WUYE_ZL
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_WUYE_ZL(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_WUYE_ZL)
                With table.Columns
                    .Add(FIELD_DC_B_ES_WUYE_ZL_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_WYBM, GetType(System.String))

                    .Add(FIELD_DC_B_ES_WUYE_ZL_FWDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_FCZH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_FCZDZ, GetType(System.String))

                    .Add(FIELD_DC_B_ES_WUYE_ZL_MJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_YZJ, GetType(System.Double))

                    .Add(FIELD_DC_B_ES_WUYE_ZL_ZX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_LC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_LL, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_JG, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_WYXZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_SZQY, GetType(System.String))

                    .Add(FIELD_DC_B_ES_WUYE_ZL_BZXX, GetType(System.String))


                    .Add(FIELD_DC_B_ES_WUYE_ZL_JGMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_WYXZMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_SZQYMC, GetType(System.String))

                    'zengxianglin 2010-12-25
                    .Add(FIELD_DC_B_ES_WUYE_ZL_FYBH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_LP, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_LD, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_DY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_JCSJ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_KJLX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_FWXZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_ZXDC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_ZXNX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_ZYYX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_JJSB, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_LYJT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_FWJG, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_JGLX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_JGFS, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_LG, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_WSSL, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_YTSL, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_HYMJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_DTSL, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_LCHS, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_LPQS, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_ZL_WYXX, GetType(System.String))
                    'zengxianglin 2010-12-25
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_WUYE_ZL = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_ZULINQIXIAN
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_ZULINQIXIAN(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_ZULINQIXIAN)
                With table.Columns
                    .Add(FIELD_DC_B_ES_ZULINQIXIAN_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_ZULINQIXIAN_QRSH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_ZULINQIXIAN_KSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_ZULINQIXIAN_ZZRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_ZULINQIXIAN_YZJE, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_ZULINQIXIAN_JZR, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_ZULINQIXIAN_JZFS, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_ZULINQIXIAN_YZZE, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_ZULINQIXIAN_ZQYS, GetType(System.Double))


                    .Add(FIELD_DC_B_ES_ZULINQIXIAN_JZFSMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_ZULINQIXIAN = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_HETONG
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_HETONG(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_HETONG)
                With table.Columns
                    .Add(FIELD_DC_B_ES_HETONG_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_HTBH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_HTLX, GetType(System.Int32))

                    .Add(FIELD_DC_B_ES_HETONG_HTRQ, GetType(System.DateTime))
                    'zengxianglin 2008-11-22
                    .Add(FIELD_DC_B_ES_HETONG_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_HETONG_JARQ, GetType(System.DateTime))
                    'zengxianglin 2008-11-22
                    'zengxianglin 2008-11-25
                    .Add(FIELD_DC_B_ES_HETONG_AJFH, GetType(System.Double))
                    'zengxianglin 2008-11-25
                    .Add(FIELD_DC_B_ES_HETONG_HTZT, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_HETONG_FKFS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_DJRDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_DJRMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_DJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_HETONG_BZXX, GetType(System.String))


                    .Add(FIELD_DC_B_ES_HETONG_HTZTMC, GetType(System.String))

                    'zengxianglin 2010-12-25
                    .Add(FIELD_DC_B_ES_HETONG_HTBZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_HETONG_JCRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_HETONG_HZJE, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_HETONG_HZRQ, GetType(System.DateTime))
                    'zengxianglin 2010-12-25
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_HETONG = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_HETONG_SHENHE
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_HETONG_SHENHE(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_HETONG_SHENHE)
                With table.Columns
                    .Add(FIELD_DC_B_ES_HETONG_SHENHE_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_SHENHE_QRSH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_HETONG_SHENHE_SHRDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_SHENHE_SHRMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_SHENHE_SHRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_HETONG_SHENHE_ZTBZ, GetType(System.Int32))


                    .Add(FIELD_DC_B_ES_HETONG_SHENHE_ZTBZMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_HETONG_SHENHE = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_HETONG_ZHEKOUSHENHE
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_HETONG_ZHEKOUSHENHE(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_HETONG_ZHEKOUSHENHE)
                With table.Columns
                    .Add(FIELD_DC_B_ES_HETONG_ZHEKOUSHENHE_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_ZHEKOUSHENHE_QRSH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_HETONG_ZHEKOUSHENHE_SHRDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_ZHEKOUSHENHE_SHRMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_ZHEKOUSHENHE_SHRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_HETONG_ZHEKOUSHENHE_SHLX, GetType(System.Int32))


                    .Add(FIELD_DC_B_ES_HETONG_ZHEKOUSHENHE_SHLXMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_HETONG_ZHEKOUSHENHE = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_HETONG_BANANJIHUA
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_HETONG_BANANJIHUA(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_HETONG_BANANJIHUA)
                With table.Columns
                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_QRSH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_JHKS, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_JHJS, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_GZNR, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDW, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_SJKS, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_SJJS, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_TXBZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_KBTS, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_BWTS, GetType(System.Int32))


                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_BANANJIHUA_TXBZMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_HETONG_BANANJIHUA = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_HETONG_BANLIJILU
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_HETONG_BANLIJILU(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_HETONG_BANLIJILU)
                With table.Columns
                    .Add(FIELD_DC_B_ES_HETONG_BANLIJILU_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_BANLIJILU_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_BANLIJILU_JHBS, GetType(System.String))

                    .Add(FIELD_DC_B_ES_HETONG_BANLIJILU_BLRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_HETONG_BANLIJILU_BLQK, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_BANLIJILU_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_BANLIJILU_JBDW, GetType(System.String))


                    .Add(FIELD_DC_B_ES_HETONG_BANLIJILU_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_BANLIJILU_JBDWMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_HETONG_BANLIJILU = table

        End Function















        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_HETONG_JIESUANSHU
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_HETONG_JIESUANSHU(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_HETONG_JIESUANSHU)
                With table.Columns
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_JSSH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_JSDW, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_JSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_JSLX, GetType(System.Int32))

                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_ZJFE, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_JSEJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_JSEY, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_SSEJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_SSEY, GetType(System.Double))

                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_ZTBZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_BZXX, GetType(System.String))
                    'zengxianglin 2009-12-26
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_JYRQ, GetType(System.DateTime))
                    'zengxianglin 2009-12-26


                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_JSDWMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_JSLXMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_ZTBZMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_HETONG_JIESUANSHU = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_HETONG_JIESUANSHU_MINGXI
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_HETONG_JIESUANSHU_MINGXI(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_HETONG_JIESUANSHU_MINGXI)
                With table.Columns
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSSH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_SFDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSDX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSJE, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSZY, GetType(System.String))


                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_SFMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSEJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_MINGXI_JSEY, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_HETONG_JIESUANSHU_MINGXI = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_HETONG_JIESUANSHU_YEJI
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_HETONG_JIESUANSHU_YEJI(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_HETONG_JIESUANSHU_YEJI)
                With table.Columns
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_JSSH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_YJLY, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_RYDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_DWDM, GetType(System.String))
                    'zengxianglin 2008-10-14
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_SSFZ, GetType(System.String))
                    'zengxianglin 2008-10-14
                    'zengxianglin 2010-01-06
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_TDBH, GetType(System.Int32))
                    'zengxianglin 2010-01-06
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_RYZJ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_ZGBJ, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_ZTBZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_FPBL, GetType(System.Double))

                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_KHYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_SYJS, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_GYJS, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCZE, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCJT, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_BCBL, GetType(System.Double))


                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_YJLYMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_RYMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_DWMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_RYZJMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_ZGBJMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_YEJI_ZTBZMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_HETONG_JIESUANSHU_YEJI = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_HETONG_JIESUANSHU_SHENHE
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_HETONG_JIESUANSHU_SHENHE(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_HETONG_JIESUANSHU_SHENHE)
                With table.Columns
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_JSSH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_SHRDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_SHRMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_SHRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_ZTBZ, GetType(System.Int32))


                    .Add(FIELD_DC_B_ES_HETONG_JIESUANSHU_SHENHE_ZTBZMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_HETONG_JIESUANSHU_SHENHE = table

        End Function









        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_QUERENSHU_QT
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_QUERENSHU_QT(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_QUERENSHU_QT)
                With table.Columns
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_DGZT, GetType(System.Int32))

                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_JFMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_JFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_JFZZHM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_JFDLR, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_JFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_JFLXDH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_YFMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_YFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_YFZZHM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_YFDLR, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_YFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_YFLXDH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_FWDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_JYZJG, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_JYZMJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_DLFZK, GetType(System.Double))

                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_JHJYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_JLRQYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_JHJLRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_JLZKYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_FKFSYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_SFZFYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_FKTGYD, GetType(System.Int32))

                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_DJRDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_DJRMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_DJRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_BZXX, GetType(System.String))


                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_DGZTMC, GetType(System.String))

                    'zengxianglin 2010-12-25
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_CCDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_CCF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_SSYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_HZYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_AJJG, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_AJYH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_AJCS, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_AJNX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_YZQC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_YZQN, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_YZLY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_YYQT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_YZDY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_SHYX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_SYWY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_MJQC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_MJQN, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_KHLY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_KYQT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_KHDY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_GMMD, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_KYBH, GetType(System.String))
                    'zengxianglin 2010-12-25
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_QUERENSHU_QT = table

        End Function

        'zengxianglin 2009-05-17
        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_QUERENSHU_QT_PRN
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_QUERENSHU_QT_PRN(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_QUERENSHU_QT_PRN)
                With table.Columns
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_DGZT, GetType(System.Int32))

                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFZZHM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFDLR, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFLXDH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFZJLX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFZZHM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFDLR, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFLXDH, GetType(System.String))

                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_FWDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JYZJG, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JYZMJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_DLFZK, GetType(System.Double))

                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JHJYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JLRQYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JHJLRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JLZKYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_FKFSYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_SFZFYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_FKTGYD, GetType(System.Int32))

                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_DJRDM, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_DJRMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_DJRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_BZXX, GetType(System.String))


                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_DGZTMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JFZJLXMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_YFZJLXMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JLRQYDMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_JLZKYDMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_FKFSYDMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_SFZFYDMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_FKTGYDMC, GetType(System.String))

                    'zengxianglin 2010-12-25
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_CCDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_CCF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_SSYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_HZYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_AJJG, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_AJYH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_AJCS, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_AJNX, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_YZQC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_YZQN, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_YZLY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_YYQT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_YZDY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_SHYX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_SYWY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_MJQC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_MJQN, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_KHLY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_KYQT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_KHDY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_GMMD, GetType(System.String))
                    .Add(FIELD_DC_B_ES_QUERENSHU_QT_PRN_KYBH, GetType(System.String))
                    'zengxianglin 2010-12-25
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_QUERENSHU_QT_PRN = table

        End Function
        'zengxianglin 2009-05-17

        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_WUYE_QT
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_WUYE_QT(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_WUYE_QT)
                With table.Columns
                    .Add(FIELD_DC_B_ES_WUYE_QT_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_QRSH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_WYBM, GetType(System.String))

                    .Add(FIELD_DC_B_ES_WUYE_QT_FWDZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_FCZH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_FCZDZ, GetType(System.String))

                    .Add(FIELD_DC_B_ES_WUYE_QT_MJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_WUYE_QT_JYJE, GetType(System.Double))

                    .Add(FIELD_DC_B_ES_WUYE_QT_ZX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_LC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_LL, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_QT_JG, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_WYXZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_SZQY, GetType(System.String))

                    .Add(FIELD_DC_B_ES_WUYE_QT_BZXX, GetType(System.String))


                    .Add(FIELD_DC_B_ES_WUYE_QT_JGMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_WYXZMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_SZQYMC, GetType(System.String))

                    'zengxianglin 2010-12-25
                    .Add(FIELD_DC_B_ES_WUYE_QT_FYBH, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_LP, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_LD, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_DY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_JCSJ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_WUYE_QT_KJLX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_FWXZ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_ZXDC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_ZXNX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_ZYYX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_JJSB, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_LYJT, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_FWJG, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_JGLX, GetType(System.String))
                    .Add(FIELD_DC_B_ES_WUYE_QT_JGFS, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_QT_LG, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_QT_WSSL, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_QT_YTSL, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_QT_HYMJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_WUYE_QT_DTSL, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_QT_LCHS, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_QT_LPQS, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_WUYE_QT_WYXX, GetType(System.String))
                    'zengxianglin 2010-12-25
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_WUYE_QT = table

        End Function

        'zengxianglin 2008-11-24
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESDLJSQKB_GFH
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESDLJSQKB_GFH(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESDLJSQKB_GFH)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_XSJB, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_XSMC, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_QYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_DWDM, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_DWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_SSFZ, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJDLFAJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJDLFXS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJDLFZL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJDLFQT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJDLFXJ, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJZSXS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJZSZL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJZSQT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_LJZSXJ, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYDLFAJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYDLFXS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYDLFZL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYDLFQT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYDLFXJ, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYZSXS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYZSZL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYZSQT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GFH_BYZSXJ, GetType(System.Double))
                    '===========================================================================================
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESDLJSQKB_GFH = table

        End Function
        'zengxianglin 2008-11-24

        'zengxianglin 2008-11-26
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESDLJSQKB_GYW
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESDLJSQKB_GYW(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESDLJSQKB_GYW)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_JYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_XSXH, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WCDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WCHTJE, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WCDLMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WCZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WCTS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WCAJFH, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_BYDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_BYHTJE, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_BYDLMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_BYZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_BYTS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_BYAJFH, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WJDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WJHTJE, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WJDLMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WJZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WJTS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYW_WJAJFH, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESDLJSQKB_GYW = table

        End Function
        'zengxianglin 2008-11-26

        'zengxianglin 2008-11-26
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESDLJAQKB_GFH
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESDLJAQKB_GFH(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESDLJAQKB_GFH)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_XSJB, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_XSMC, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_QYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_DWDM, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_DWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_SSFZ, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJDLFAJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJDLFXS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJDLFZL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJDLFQT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJDLFXJ, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJZSXS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJZSZL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJZSQT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_LJZSXJ, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYDLFAJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYDLFXS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYDLFZL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYDLFQT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYDLFXJ, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYZSXS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYZSZL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYZSQT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJAQKB_GFH_BYZSXJ, GetType(System.Double))
                    '===========================================================================================
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESDLJAQKB_GFH = table

        End Function
        'zengxianglin 2008-11-26

        'zengxianglin 2008-11-26
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESDLWCQKB_GFH
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESDLWCQKB_GFH(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESDLWCQKB_GFH)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_XSJB, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_XSMC, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_QYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_DWDM, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_DWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_SSFZ, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJDLFAJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJDLFXS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJDLFZL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJDLFQT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJDLFXJ, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJZSXS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJZSZL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJZSQT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_LJZSXJ, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYDLFAJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYDLFXS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYDLFZL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYDLFQT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYDLFXJ, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYZSXS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYZSZL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYZSQT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLWCQKB_GFH_BYZSXJ, GetType(System.Double))
                    '===========================================================================================
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESDLWCQKB_GFH = table

        End Function
        'zengxianglin 2008-11-26

        'zengxianglin 2008-11-28
        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_JYNDJH
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_JYNDJH(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_JYNDJH)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_B_ES_JYNDJH_WYBS, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_B_ES_JYNDJH_JHND, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_JYNDJH_JHLX, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_B_ES_JYNDJH_JHDLF, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_JYNDJH_JHHTE, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_JYNDJH_JHZS, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_JYNDJH_JHTS, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_JYNDJH_JHMJ, GetType(System.Double))
                    '===========================================================================================
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_JYNDJH = table

        End Function
        'zengxianglin 2008-11-28

        'zengxianglin 2008-11-28
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESDLJSQKB_GYD
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESDLJSQKB_GYD(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESDLJSQKB_GYD)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_XSJB, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_XSMC, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_ZBMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_ZBXH, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_JYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_JSDW, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_NDJH, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_LJWC, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_WCBL, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M01, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M02, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M03, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M04, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M05, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M06, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M07, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M08, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M09, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M10, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M11, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLJSQKB_GYD_M12, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESDLJSQKB_GYD = table

        End Function
        'zengxianglin 2008-11-28

        'zengxianglin 2008-11-28
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESYWDLQD_JA
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESYWDLQD_JA(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESYWDLQD_JA)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_XSJB, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JYPX, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ZQ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_YZJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ZDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JBDW, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JBRY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_TS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_SSK, GetType(System.Double))
                    'zengxianglin 2009-02-24
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_SSDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_SFBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_SFBZ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_CYJ, GetType(System.Double))
                    'zengxianglin 2009-02-24
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESYWDLQD_JA = table

        End Function
        'zengxianglin 2008-11-28

        'zengxianglin 2009-02-24
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESYWDLQD_JA_WS
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESYWDLQD_JA_WS(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESYWDLQD_JA_WS)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_XSJB, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JYPX, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_ZQ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_YZJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_ZDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JBDW, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JBRY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_TS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_ZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_SSK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_SSDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_SFBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_SFBZ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_WS_CYJ, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESYWDLQD_JA_WS = table

        End Function
        'zengxianglin 2009-02-24

        'zengxianglin 2008-11-28
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESYWDLQD_WC
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESYWDLQD_WC(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESYWDLQD_WC)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_XSJB, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JYPX, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JARQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_ZQ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_YZJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_ZDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JBDW, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JBRY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_TS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_ZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_SSK, GetType(System.Double))
                    'zengxianglin 2009-02-24
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_SSDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_SFBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_SFBZ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_WC_CYJ, GetType(System.Double))
                    'zengxianglin 2009-02-24
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESYWDLQD_WC = table

        End Function
        'zengxianglin 2008-11-28

        'zengxianglin 2008-11-28
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESYWDLQD_YJWJ
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESYWDLQD_YJWJ(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESYWDLQD_YJWJ)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_XSJB, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JYPX, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_ZQ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_YZJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_ZDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JBDW, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JBRY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_TS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_ZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_SSK, GetType(System.Double))
                    'zengxianglin 2009-02-24
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_SSDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_SFBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_SFBZ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJ_CYJ, GetType(System.Double))
                    'zengxianglin 2009-02-24
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESYWDLQD_YJWJ = table

        End Function
        'zengxianglin 2008-11-28

        'zengxianglin 2008-12-01
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESJYQD_SY
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESJYQD_SY(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESJYQD_SY)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_XSJB, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_JSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_JSSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_ZZJF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_ZLSF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_YJHJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_JBDW, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_JBRY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_RYZJ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_RYZJMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_SSYWJL, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_SSYYJL, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_SSZJYYJL, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_SSGJYYJL, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_SSZSYYJL, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_SSXZZL, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_SSQYJL, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_SSQYZJ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_BZXX, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESJYQD_SY = table

        End Function
        'zengxianglin 2008-12-01

        'zengxianglin 2008-12-01
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESJYQD_GY
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESJYQD_GY(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESJYQD_GY)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_XSJB, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_JSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_JSSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_ZZJF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_ZLSF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_YJHJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_BCJT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_BCBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_JTHJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_JBDW, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_JBRY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_RYZJ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_RYZJMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_BZXX, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESJYQD_GY = table

        End Function
        'zengxianglin 2008-12-01

        'zengxianglin 2008-12-01
        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_JYHTJSSYJBF
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_JYHTJSSYJBF(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_JYHTJSSYJBF)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_B_ES_JYHTJSSYJBF_WYBS, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_B_ES_JYHTJSSYJBF_BFYD, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_JYHTJSSYJBF_RYDM, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_B_ES_JYHTJSSYJBF_BFJE, GetType(System.Double))


                    .Add(FIELD_DC_B_ES_JYHTJSSYJBF_RYMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_JYHTJSSYJBF_SJBF, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_JYHTJSSYJBF = table

        End Function
        'zengxianglin 2008-12-01

        'zengxianglin 2008-12-01
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESDLQYQKB
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESDLQYQKB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESDLQYQKB)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_XSJB, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_XSMC, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_SZQY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_QYMC, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_MMMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_MMTS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_MMZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_MMDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_MMJYJE, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_ZLMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_ZLTS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_ZLZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_ZLDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_ZLJYJE, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_QTMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_QTTS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_QTZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_QTDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESDLQYQKB_QTJYJE, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESDLQYQKB = table

        End Function
        'zengxianglin 2008-12-01

        'zengxianglin 2008-12-01
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_PHBQYYJ
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_PHBQYYJ(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_PHBQYYJ)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_PHBQYYJ_SZQY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_PHBQYYJ_QYMC, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_PHBQYYJ_MJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBQYYJ_TS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBQYYJ_ZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBQYYJ_DLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBQYYJ_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBQYYJ_JYJE, GetType(System.Double))
                    'zengxianglin 2009-05-21
                    .Add(FIELD_DC_VT_ES_BB_PHBQYYJ_SJDLF, GetType(System.Double))
                    'zengxianglin 2009-05-21
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_PHBQYYJ = table

        End Function
        'zengxianglin 2008-12-01

        'zengxianglin 2008-12-01
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_PHBBMYJ
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_PHBBMYJ(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_PHBBMYJ)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_PHBBMYJ_DWDM, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_PHBBMYJ_DWMC, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_PHBBMYJ_MJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBBMYJ_TS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBBMYJ_ZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBBMYJ_DLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBBMYJ_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBBMYJ_JYJE, GetType(System.Double))
                    'zengxianglin 2009-05-21
                    .Add(FIELD_DC_VT_ES_BB_PHBBMYJ_SJDLF, GetType(System.Double))
                    'zengxianglin 2009-05-21
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_PHBBMYJ = table

        End Function
        'zengxianglin 2008-12-01

        'zengxianglin 2008-12-01
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_PHBRYYJ
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_PHBRYYJ(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_PHBRYYJ)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_PHBRYYJ_RYDM, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_PHBRYYJ_RYMC, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_PHBRYYJ_MJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBRYYJ_TS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBRYYJ_ZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBRYYJ_DLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBRYYJ_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_PHBRYYJ_JYJE, GetType(System.Double))
                    'zengxianglin 2009-05-21
                    .Add(FIELD_DC_VT_ES_BB_PHBRYYJ_SJDLF, GetType(System.Double))
                    'zengxianglin 2009-05-21
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_PHBRYYJ = table

        End Function
        'zengxianglin 2008-12-01

        'zengxianglin 2008-12-02
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_NDDB
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_NDDB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_NDDB)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_NDDB_TJND, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_NDDB_M01, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_NDDB_M02, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_NDDB_M03, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_NDDB_M04, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_NDDB_M05, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_NDDB_M06, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_NDDB_M07, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_NDDB_M08, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_NDDB_M09, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_NDDB_M10, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_NDDB_M11, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_NDDB_M12, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_NDDB = table

        End Function
        'zengxianglin 2008-12-02

        'zengxianglin 2008-12-04
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_YJFPB
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_YJFPB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_YJFPB)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_XSJB, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_JTNY, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_RYDM, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_RYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_RYZJ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_ZJMC, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_GRYJDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_GRYJLSF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_TDYJ, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_YJHJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_SYDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_SYLSF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_GYYWJL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_GYYYJLZG, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_GYYYJLXG, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_GYQYJL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_GYQYZJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_GYXZZL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_FFTZ, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_YJFPB = table

        End Function
        'zengxianglin 2008-12-04

        'zengxianglin 2009-05-21
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESYWDLQD_JA_ALL
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESYWDLQD_JA_ALL(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESYWDLQD_JA_ALL)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_XSJB, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JYPX, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JARQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_HTZT, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_ZQ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_YZJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_ZDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JBDW, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JBRY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_TS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_ZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_SSK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_SSDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_SFBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_SFBZ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA_ALL_CYJ, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESYWDLQD_JA_ALL = table

        End Function
        'zengxianglin 2009-05-21

        'zengxianglin 2009-05-21
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESYWDLQD_JA1_ALL
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESYWDLQD_JA1_ALL(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESYWDLQD_JA1_ALL)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_XSJB, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_PQDM, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_PQMC, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JYPX, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JARQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_HTZT, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_ZQ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_YZJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_ZDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JBDW, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JBRY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_TS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_ZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_SSK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_SSDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_SFBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_SFBZ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_ALL_CYJ, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESYWDLQD_JA1_ALL = table

        End Function
        'zengxianglin 2009-05-21

        'zengxianglin 2009-05-21
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESYWDLQD_JA1_YS
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESYWDLQD_JA1_YS(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESYWDLQD_JA1_YS)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_XSJB, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_PQDM, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_PQMC, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JYPX, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JARQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_HTZT, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_ZQ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_YZJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_ZDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JBDW, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JBRY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_TS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_ZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_SSK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_SSDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_SFBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_SFBZ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_JA1_YS_CYJ, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESYWDLQD_JA1_YS = table

        End Function
        'zengxianglin 2009-05-21

        'zengxianglin 2009-05-21
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESYWDLQD_YJWJW
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESYWDLQD_YJWJW(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESYWDLQD_YJWJW)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_XSJB, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_PQDM, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_PQMC, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JYPX, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JARQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_HTZT, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_ZQ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_YZJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_ZDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JBDW, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JBRY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_TS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_ZS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_SSK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_SSDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_SFBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_SFBZ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESYWDLQD_YJWJW_CYJ, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESYWDLQD_YJWJW = table

        End Function
        'zengxianglin 2009-05-21

        'zengxianglin 2010-01-18
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESJYQD_SY_X2
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESJYQD_SY_X2(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESJYQD_SY_X2)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_XSJB, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JYBZ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JSSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_ZZJF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_ZLSF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_YJHJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JBDW, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_TDBH, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JBRY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_RYZJ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_RYZJMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_YWJL, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_ZGYYJL, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_XGYYJL, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_XZZL, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_QYJL, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_QYZJ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_BZXX, GetType(System.String))
                    'zengxianglin 2011-03-22
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_SY_X2_YMZJ, GetType(System.String))
                    'zengxianglin 2011-03-22
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESJYQD_SY_X2 = table

        End Function
        'zengxianglin 2010-01-18

        'zengxianglin 2010-01-18
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_ESJYQD_GY_X2
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_ESJYQD_GY_X2(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_ESJYQD_GY_X2)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_XSJB, GetType(System.Int32))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JYBZ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JSSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_ZZJF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_ZLSF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_YJHJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_BCJT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_BCBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JTHJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JBDW, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_TDBH, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_ZGBJ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JBRY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_RYZJ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_RYZJMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_BZXX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_SYRY, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_TDRS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_TDLX, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_SJWC, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_RWZB, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_WCBL, GetType(System.Double))
                    'zengxianglin 2011-01-18
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JYNY, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JANY, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_YMRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_YCYJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_YCJT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_YMYJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_RJYJ, GetType(System.Double))
                    'zengxianglin 2011-01-18
                    'zengxianglin 2011-03-22
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JYZJ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JYDJ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_JYZJMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_ESJYQD_GY_X2_YMZJ, GetType(System.String))
                    'zengxianglin 2011-03-22
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_ESJYQD_GY_X2 = table

        End Function
        'zengxianglin 2010-01-18

        'zengxianglin 2010-01-18
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_YJFPB_X2
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_YJFPB_X2(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_YJFPB_X2)
                With table.Columns
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_XSJB, GetType(System.Int32))
                    '===========================================================================================
                    'zengxianglin 2011-01-18
                    '.Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JTSD, GetType(System.Int32))
                    'zengxianglin 2011-01-18
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JBRY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JBDW, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_TDBH, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_ZGBJ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_RYZJ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_RYZJMC, GetType(System.String))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JYBZ, GetType(System.Int32))
                    'zengxianglin 2011-01-18
                    '.Add(FIELD_DC_VT_ES_BB_YJFPB_X2_BYJY, GetType(System.Double))
                    '.Add(FIELD_DC_VT_ES_BB_YJFPB_X2_SYJS, GetType(System.Double))
                    '.Add(FIELD_DC_VT_ES_BB_YJFPB_X2_SYYJ, GetType(System.Double))
                    '.Add(FIELD_DC_VT_ES_BB_YJFPB_X2_GYJS, GetType(System.Double))
                    '.Add(FIELD_DC_VT_ES_BB_YJFPB_X2_GYYJ, GetType(System.Double))
                    '.Add(FIELD_DC_VT_ES_BB_YJFPB_X2_GYBL, GetType(System.Double))
                    'zengxianglin 2011-01-18
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_SYRY, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_TDRS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_TDLX, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_SJWC, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_RWZB, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_WCBL, GetType(System.Double))
                    '===========================================================================================
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JSSH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_ZTBZ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_ZZJF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_ZLSF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_YJHJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_BCJT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_BCBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JTHJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_FPBL, GetType(System.Double))
                    '===========================================================================================
                    'zengxianglin 2011-01-18
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JYNY, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JANY, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_YMRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_YCYJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_YCJT, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_YMYJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_RJYJ, GetType(System.Double))
                    'zengxianglin 2011-01-18
                    'zengxianglin 2011-03-22
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JYZJ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JYDJ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_JYZJMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_YJFPB_X2_YMZJ, GetType(System.String))
                    'zengxianglin 2011-03-22
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_YJFPB_X2 = table

        End Function
        'zengxianglin 2010-01-18

        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_YSWSYJB
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_YSWSYJB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_YSWSYJB)
                With table.Columns
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTBH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JYBH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_KYBH, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_JYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JARQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JCRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HZRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_YZMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_KHMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_WYDZ, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HZYJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YSWSYJB_XYSS, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YSWSYJB_SJYJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_YSWSYJB_WSYJ, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_CCF, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HZJE, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_AJFH, GetType(System.Double))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_JFZZHM, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JFDLR, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JFLXDH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JFZJLX, GetType(System.Int32))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_YFZZHM, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YFDLR, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YFLXDH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YFZJLX, GetType(System.Int32))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTZTMC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTJC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HZHT, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_CCDZ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_AJJG, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_AJYH, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_AJCS, GetType(System.Double))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_AJNX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YZQC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YZQN, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YZLY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YYQT, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_YZDY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_SHYX, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_SYWY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MJQC, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_MJQN, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_KHLY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_KYQT, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_KHDY, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_GMMD, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZLKS, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZLJS, GetType(System.DateTime))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_SDMQ, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_DHF, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_GLF, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_ZLFP, GetType(System.String))

                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTWYBS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_WYBS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JYLX, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_JYZT, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTLX, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTZT, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_HTBZ, GetType(System.Int32))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_FKFS, GetType(System.String))
                    .Add(FIELD_DC_V_QUANBUJIAOYI_SSYJ, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_YSWSYJB = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_KYXXB
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_KYXXB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_KYXXB)
                With table.Columns
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_JYLX, GetType(System.String))

                    .Add(FIELD_DC_VT_ES_BB_KYXXB_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_KYBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_YFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_YFLXDH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_YFZZHM, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_YFDLR, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_YFZJLX, GetType(System.Int32))

                    .Add(FIELD_DC_VT_ES_BB_KYXXB_MJQC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_MJQN, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_KHLY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_KYQT, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_KHDY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_GMMD, GetType(System.String))

                    .Add(FIELD_DC_VT_ES_BB_KYXXB_JYBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_JYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_TJRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_VT_ES_BB_KYXXB_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_SSYJ, GetType(System.Double))

                    .Add(FIELD_DC_VT_ES_BB_KYXXB_JYZT, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_HTZT, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_HTJC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_HZHT, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_KYXXB_HTZTMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_KYXXB = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_VT_ES_BB_KYXXB
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_ES_BB_FYXXB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_ES_BB_FYXXB)
                With table.Columns
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JYLX, GetType(System.String))

                    .Add(FIELD_DC_VT_ES_BB_FYXXB_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_FYBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JFLXDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JFLXDH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JFZZHM, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JFDLR, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JFZJLX, GetType(System.Int32))

                    .Add(FIELD_DC_VT_ES_BB_FYXXB_FWDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_FCZH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_FCZDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_LP, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_LD, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_DY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_MJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_ZX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_LC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_LG, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_LL, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JG, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JGMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_WYXZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_WYXZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_SZQY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_SZQYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JCSJ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_KJLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_FWXZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_ZXDC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_ZXNX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_ZYYX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JJSB, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_LYJT, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_FWJG, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JGLX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JGFS, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_WSSL, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_YTSL, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_DTSL, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_LCHS, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_LPQS, GetType(System.Int32))

                    .Add(FIELD_DC_VT_ES_BB_FYXXB_YZQC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_YZQN, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_YZLY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_YYQT, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_YZDY, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_SHYX, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_SYWY, GetType(System.String))

                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JYBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_TJRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_SSYJ, GetType(System.Double))

                    .Add(FIELD_DC_VT_ES_BB_FYXXB_JYZT, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_HTZT, GetType(System.Int32))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_HTJC, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_HZHT, GetType(System.String))
                    .Add(FIELD_DC_VT_ES_BB_FYXXB_HTZTMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_ES_BB_FYXXB = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_ES_YJJT
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_ES_YJJT(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_ES_YJJT)
                With table.Columns
                    .Add(FIELD_DC_B_ES_YJJT_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_ES_YJJT_JYNY, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_YJJT_JANY, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_YJJT_JYKS, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_YJJT_JYJS, GetType(System.DateTime))
                    .Add(FIELD_DC_B_ES_YJJT_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_ES_YJJT_JYBZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_YJJT_JBDW, GetType(System.String))
                    .Add(FIELD_DC_B_ES_YJJT_TDBH, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_YJJT_ZGBJ, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_YJJT_RYZJ, GetType(System.String))
                    .Add(FIELD_DC_B_ES_YJJT_YJBJ, GetType(System.Int32))
                    .Add(FIELD_DC_B_ES_YJJT_YCYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_YJJT_BYYJ, GetType(System.Double))
                    .Add(FIELD_DC_B_ES_YJJT_JTYJ, GetType(System.Double))

                    .Add(FIELD_DC_B_ES_YJJT_JBRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_YJJT_JBDWMC, GetType(System.String))
                    .Add(FIELD_DC_B_ES_YJJT_RYZJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_ES_YJJT = table

        End Function

    End Class 'estateErshouData

End Namespace 'Josco.JsKernal.Common.Data
