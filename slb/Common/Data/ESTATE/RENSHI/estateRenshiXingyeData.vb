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
Imports System.Configuration

Namespace Josco.JSOA.Common.Data

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.Common.Data
    ' 类名    ：estateRenshiXingyeData
    '
    ' 功能描述：
    '     定义兴业公司特殊的人事管理相关表的数据访问格式
    '
    ' 更改记录：
    '----------------------------------------------------------------
    <System.ComponentModel.DesignerCategory("ESTATE-RENSHI"), SerializableAttribute()> Public Class estateRenshiXingyeData
        Inherits System.Data.DataSet

        '“地产_B_人事_职级定义”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_ZHIJIDINGYI As String = "地产_B_人事_职级定义"
        '字段序列
        Public Const FIELD_DC_B_RS_ZHIJIDINGYI_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_ZHIJIDINGYI_ZJMC As String = "职级名称"
        Public Const FIELD_DC_B_RS_ZHIJIDINGYI_JBSZ As String = "级别数值"
        '显示字段序列
        '约束错误信息

        '“地产_B_人事_佣金计提标准”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_YONGJINJITIBIAOZHUN As String = "地产_B_人事_佣金计提标准"
        '字段序列
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_SYFF As String = "适用方法"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZGBJ As String = "直管标记"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_YJBJ As String = "业绩标记"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_TJHH As String = "条件行号"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT As String = "直接计提"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_BLJT As String = "保留计提"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_QJZX As String = "区间最小"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_QJZD As String = "区间最大"
        '显示字段序列
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJMC As String = "职级名称"
        '约束错误信息

        '“地产_B_人事_业绩考核标准”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN As String = "地产_B_人事_业绩考核标准"
        '字段序列
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_SYDW As String = "适用单位"
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_SYFF As String = "适用方法"
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_ZBXL As String = "指标序列"
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_ZBSZ As String = "指标数值"
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_ZBGS As String = "指标公式"
        '显示字段序列
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_ZJMC As String = "职级名称"
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_SYDWMC As String = "适用单位名称"
        '约束错误信息

        '“地产_B_人事_管理架构”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_GUANLIJIAGOU As String = "地产_B_人事_管理架构"
        '字段序列
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_RYDM As String = "人员代码"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_RYZT As String = "人员状态"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_SSDW As String = "所属单位"
        'zengxianglin 2008-10-14
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_SSFZ As String = "所属分组"
        'zengxianglin 2008-10-14
        'zengxianglin 2008-11-17
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_ZGDW As String = "直管单位"
        'zengxianglin 2008-11-17
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_SFZB As String = "是否占编"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_SJLD As String = "上级领导"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_KSSJ As String = "生效时间"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_JSSJ As String = "失效时间"
        'zengxianglin 2009-12-28
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_BZXL As String = "标准序列"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_TDBH As String = "团队编号"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_ZGTD As String = "直管团队"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_XGTD As String = "协管团队"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_YDYY As String = "变动原因"
        'zengxianglin 2009-12-28
        '显示字段序列
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_RYMC As String = "人员名称"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_ZJMC As String = "职级名称"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_RYZTMC As String = "人员状态名称"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_SSDWMC As String = "所属单位名称"
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_SJLDMC As String = "上级领导名称"
        'zengxianglin 2008-11-17
        Public Const FIELD_DC_B_RS_GUANLIJIAGOU_ZGDWMC As String = "直管单位名称"
        'zengxianglin 2008-11-17
        '约束错误信息

        '“地产_B_人事_助理架构”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_ZHULIJIAGOU As String = "地产_B_人事_助理架构"
        '字段序列
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_RYDM As String = "人员代码"
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_RYZT As String = "人员状态"
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_SSDW As String = "所属单位"
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_SFZB As String = "是否占编"
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_KSSJ As String = "生效时间"
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_JSSJ As String = "失效时间"
        'zengxianglin 2009-12-28
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_BZXL As String = "标准序列"
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_SFJZ As String = "是否兼职"
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_YDYY As String = "变动原因"
        'zengxianglin 2009-12-28
        '显示字段序列
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_RYMC As String = "人员名称"
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_ZJMC As String = "职级名称"
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_RYZTMC As String = "人员状态名称"
        Public Const FIELD_DC_B_RS_ZHULIJIAGOU_SSDWMC As String = "所属单位名称"
        '约束错误信息

        '“地产_VT_人事_人员架构”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_V_RS_RENYUANJIAGOU As String = "地产_VT_人事_人员架构"
        '字段序列
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_WYBS As String = "唯一标识"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_RYLX As String = "人员类型"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_RYDM As String = "人员代码"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM As String = "职级代码"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_RYZT As String = "人员状态"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_SSDW As String = "所属单位"
        'zengxianglin 2008-10-14
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ As String = "所属分组"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_YDYY As String = "变动原因"
        'zengxianglin 2008-10-14
        'zengxianglin 2008-11-17
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW As String = "直管单位"
        'zengxianglin 2008-11-17
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_SFZB As String = "是否占编"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_SJLD As String = "上级领导"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ As String = "生效时间"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_JSSJ As String = "失效时间"
        'zengxianglin 2009-12-28
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_BZXL As String = "标准序列"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_TDBH As String = "团队编号"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_ZGTD As String = "直管团队"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_XGTD As String = "协管团队"
        'zengxianglin 2009-12-28
        'zengxianglin 2009-12-31
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ As String = "是否兼职"
        'zengxianglin 2009-12-31
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_RYMC As String = "人员名称"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC As String = "职级名称"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_RYZTMC As String = "人员状态名称"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC As String = "所属单位名称"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_SJLDMC As String = "上级领导名称"
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_YDYYMC As String = "变动原因名称"
        'zengxianglin 2008-11-17
        Public Const FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC As String = "直管单位名称"
        'zengxianglin 2008-11-17
        '约束错误信息

        '“地产_B_人事_个人履历”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_GERENLVLI As String = "地产_B_人事_个人履历"
        '字段序列
        Public Const FIELD_DC_B_RS_GERENLVLI_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_GERENLVLI_RYDM As String = "人员代码"
        Public Const FIELD_DC_B_RS_GERENLVLI_JLBH As String = "简历编号"
        Public Const FIELD_DC_B_RS_GERENLVLI_XM As String = "姓名"
        Public Const FIELD_DC_B_RS_GERENLVLI_XB As String = "性别"
        Public Const FIELD_DC_B_RS_GERENLVLI_CSRQ As String = "出生日期"
        Public Const FIELD_DC_B_RS_GERENLVLI_TBRQ As String = "填表日期"
        Public Const FIELD_DC_B_RS_GERENLVLI_YWXM As String = "英文姓名"
        Public Const FIELD_DC_B_RS_GERENLVLI_SFZH As String = "身份证号"
        Public Const FIELD_DC_B_RS_GERENLVLI_SG As String = "身高"
        Public Const FIELD_DC_B_RS_GERENLVLI_TZ As String = "体重"
        Public Const FIELD_DC_B_RS_GERENLVLI_MZ As String = "民族"
        Public Const FIELD_DC_B_RS_GERENLVLI_JG As String = "籍贯"
        Public Const FIELD_DC_B_RS_GERENLVLI_HJDZ As String = "户籍地址"
        Public Const FIELD_DC_B_RS_GERENLVLI_XZDZ As String = "现住地址"
        Public Const FIELD_DC_B_RS_GERENLVLI_SJHM As String = "手机号码"
        Public Const FIELD_DC_B_RS_GERENLVLI_ZZDH As String = "住宅电话"
        Public Const FIELD_DC_B_RS_GERENLVLI_RYXP As String = "人员相片"
        Public Const FIELD_DC_B_RS_GERENLVLI_HYZK As String = "婚姻状况"
        Public Const FIELD_DC_B_RS_GERENLVLI_SYQK As String = "生育情况"
        Public Const FIELD_DC_B_RS_GERENLVLI_ZGXL As String = "最高学历"
        Public Const FIELD_DC_B_RS_GERENLVLI_ZGXW As String = "最高学位"
        Public Const FIELD_DC_B_RS_GERENLVLI_BYYX As String = "毕业院校"
        Public Const FIELD_DC_B_RS_GERENLVLI_BYZY As String = "毕业专业"
        Public Const FIELD_DC_B_RS_GERENLVLI_BYSJ As String = "毕业时间"
        Public Const FIELD_DC_B_RS_GERENLVLI_JSZC As String = "技术职称"
        Public Const FIELD_DC_B_RS_GERENLVLI_ZCQDSJ As String = "职称取得时间"
        Public Const FIELD_DC_B_RS_GERENLVLI_ZZMM As String = "政治面貌"
        Public Const FIELD_DC_B_RS_GERENLVLI_RDSJ As String = "入党时间"
        Public Const FIELD_DC_B_RS_GERENLVLI_GRJJ As String = "个人简介"
        Public Const FIELD_DC_B_RS_GERENLVLI_JZDS As String = "居住地属"
        Public Const FIELD_DC_B_RS_GERENLVLI_YZGZ As String = "有执业证"
        Public Const FIELD_DC_B_RS_GERENLVLI_ZYZG As String = "执业资格"
        Public Const FIELD_DC_B_RS_GERENLVLI_YPZW As String = "应聘职位"
        Public Const FIELD_DC_B_RS_GERENLVLI_XJYQ As String = "薪金要求"
        Public Const FIELD_DC_B_RS_GERENLVLI_BZXX As String = "备注信息"
        'zengxianglin 2009-05-14
        Public Const FIELD_DC_B_RS_GERENLVLI_NYBM As String = "拟用部门"
        Public Const FIELD_DC_B_RS_GERENLVLI_XCYJ As String = "现场意见"
        Public Const FIELD_DC_B_RS_GERENLVLI_DJRY As String = "登记人员"
        Public Const FIELD_DC_B_RS_GERENLVLI_DJBM As String = "登记部门"
        Public Const FIELD_DC_B_RS_GERENLVLI_DJSJ As String = "登记时间"
        'zengxianglin 2009-05-14
        '显示字段序列
        Public Const FIELD_DC_B_RS_GERENLVLI_NN As String = "年龄"
        Public Const FIELD_DC_B_RS_GERENLVLI_HYZKMC As String = "婚姻状况名称"
        Public Const FIELD_DC_B_RS_GERENLVLI_SYQKMC As String = "生育情况名称"
        Public Const FIELD_DC_B_RS_GERENLVLI_ZGXLMC As String = "最高学历名称"
        Public Const FIELD_DC_B_RS_GERENLVLI_ZGXWMC As String = "最高学位名称"
        Public Const FIELD_DC_B_RS_GERENLVLI_JSZCMC As String = "技术职称名称"
        Public Const FIELD_DC_B_RS_GERENLVLI_ZZMMMC As String = "政治面貌名称"
        Public Const FIELD_DC_B_RS_GERENLVLI_ZYZGMC As String = "执业资格名称"
        Public Const FIELD_DC_B_RS_GERENLVLI_SFLY As String = "是否录用"
        'zengxianglin 2009-05-14
        Public Const FIELD_DC_B_RS_GERENLVLI_NYBMMC As String = "拟用部门名称"
        Public Const FIELD_DC_B_RS_GERENLVLI_DJRYMC As String = "登记人员名称"
        Public Const FIELD_DC_B_RS_GERENLVLI_DJBMMC As String = "登记部门名称"
        'zengxianglin 2009-05-14
        '约束错误信息

        '“地产_B_人事_学习经历”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_XUEXIJINGLI As String = "地产_B_人事_学习经历"
        '字段序列
        Public Const FIELD_DC_B_RS_XUEXIJINGLI_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_XUEXIJINGLI_RYDM As String = "人员代码"
        Public Const FIELD_DC_B_RS_XUEXIJINGLI_KSNY As String = "开始年月"
        Public Const FIELD_DC_B_RS_XUEXIJINGLI_ZZNY As String = "终止年月"
        Public Const FIELD_DC_B_RS_XUEXIJINGLI_XXLX As String = "学习类型"
        Public Const FIELD_DC_B_RS_XUEXIJINGLI_XXYX As String = "学习院校"
        Public Const FIELD_DC_B_RS_XUEXIJINGLI_XXZY As String = "学习专业"
        Public Const FIELD_DC_B_RS_XUEXIJINGLI_XXJG As String = "学习结果"
        Public Const FIELD_DC_B_RS_XUEXIJINGLI_YXLZ As String = "有学历证"
        Public Const FIELD_DC_B_RS_XUEXIJINGLI_YXWZ As String = "有学位证"
        Public Const FIELD_DC_B_RS_XUEXIJINGLI_BZXX As String = "备注信息"
        '显示字段序列
        Public Const FIELD_DC_B_RS_XUEXIJINGLI_YXLZMC As String = "有学历证名称"
        Public Const FIELD_DC_B_RS_XUEXIJINGLI_YXWZMC As String = "有学位证名称"
        '约束错误信息

        '“地产_B_人事_工作经历”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_GONGZUOJINGLI As String = "地产_B_人事_工作经历"
        '字段序列
        Public Const FIELD_DC_B_RS_GONGZUOJINGLI_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_GONGZUOJINGLI_RYDM As String = "人员代码"
        Public Const FIELD_DC_B_RS_GONGZUOJINGLI_KSNY As String = "开始年月"
        Public Const FIELD_DC_B_RS_GONGZUOJINGLI_ZZNY As String = "终止年月"
        Public Const FIELD_DC_B_RS_GONGZUOJINGLI_FWDW As String = "服务单位"
        Public Const FIELD_DC_B_RS_GONGZUOJINGLI_DRZW As String = "担任职务"
        Public Const FIELD_DC_B_RS_GONGZUOJINGLI_YX As String = "月薪"
        Public Const FIELD_DC_B_RS_GONGZUOJINGLI_LZYY As String = "离职原因"
        Public Const FIELD_DC_B_RS_GONGZUOJINGLI_ZMR As String = "证明人"
        Public Const FIELD_DC_B_RS_GONGZUOJINGLI_DH As String = "电话"
        Public Const FIELD_DC_B_RS_GONGZUOJINGLI_BZXX As String = "备注信息"
        '显示字段序列
        '约束错误信息

        '“地产_B_人事_录用审批”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_LUYONGSHENPI As String = "地产_B_人事_录用审批"
        '字段序列
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_WJBS As String = "文件标识"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_LSH As String = "流水号"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_DDSZ As String = "单独设置"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_BLZT As String = "办理状态"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_QFR As String = "签发人"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_QFRQ As String = "签发日期"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_JBRY As String = "经办人员"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_JBRQ As String = "经办日期"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_JBDW As String = "经办单位"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_JJCD As String = "紧急程度"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_MMDJ As String = "秘密等级"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_WJBT As String = "文件标题"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_JGDZ As String = "机关代字"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_WJNF As String = "文件年份"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_WJXH As String = "文件序号"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_ZWNR As String = "正文内容"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_HJWJ As String = "痕迹文件"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_PJYJ As String = "批件原件"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_BZXX As String = "备注信息"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_DBRS As String = "定编人数"
        '显示字段序列
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_BWTX As String = "备忘提醒"
        '约束错误信息

        '“地产_B_人事_录用审批_人员信息”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_LUYONGSHENPI_RENYUANXINXI As String = "地产_B_人事_录用审批_人员信息"
        '字段序列
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_WJBS As String = "文件标识"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXH As String = "人员序号"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYDM As String = "人员代码"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_JLBH As String = "简历编号"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXM As String = "人员姓名"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXB As String = "人员性别"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYNN As String = "人员年龄"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXL As String = "人员学历"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NFPBM As String = "拟分配部门"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NDRZW As String = "拟担任职位"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NBDRQ As String = "拟报到日期"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_ZPSM As String = "招聘说明"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_XYRYS As String = "现有人员数"
        Public Const FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_DBRYS As String = "定编人员数"
        '显示字段序列
        '约束错误信息

        '“地产_B_人事_佣金计提标准_公佣”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_YONGYINJITIBIAOZUN_GY As String = "地产_B_人事_佣金计提标准_公佣"
        '字段序列
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZJMC As String = "职级名称"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_SYFF As String = "适用方法"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_YJBJ As String = "业绩标记"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZGZJJT As String = "直管直接计提"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZGBLJT As String = "直管保留计提"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_XGZJJT As String = "协管直接计提"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_XGBLJT As String = "协管保留计提"
        '显示字段序列
        '约束错误信息

        '“地产_B_人事_佣金计提标准_私佣指标”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZB As String = "地产_B_人事_佣金计提标准_私佣指标"
        '字段序列
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_SYFF As String = "适用方法"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_ZBBJ As String = "直管标记"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_YJBJ As String = "业绩标记"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_QJZX As String = "区间最小"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_QJZD As String = "区间最大"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_JTBL As String = "计提比例"
        '约束错误信息
        '显示字段序列

        '“地产_B_人事_佣金计提标准_私佣职级”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ As String = "地产_B_人事_佣金计提标准_私佣职级"
        '字段序列
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_SYFF As String = "适用方法"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_ZBBJ As String = "直管标记"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_YJBJ As String = "业绩标记"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_ZJMC As String = "职级名称"
        '显示字段序列
        '约束错误信息

        '“地产_B_人事_业绩考核标准_职级”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_XL As String = "地产_B_人事_业绩考核标准_职级"
        '字段序列
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZJMC As String = "职级名称"
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR01 As String = "指标内容01"
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR02 As String = "指标内容02"
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR03 As String = "指标内容03"
        '显示字段序列
        '约束错误信息

        '“地产_B_人事_业绩考核标准_单位”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW As String = "地产_B_人事_业绩考核标准_单位"
        '字段序列
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_SYDW As String = "适用单位"
        Public Const FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_DWMC As String = "适用单位名称"
        '显示字段序列
        '约束错误信息

        '“地产_B_人事_人员架构_单位”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_RENYUANJIAGOU_DW As String = "地产_B_人事_人员架构_单位"
        '字段序列
        Public Const FIELD_DC_B_RS_RENYUANJIAGOU_DW_DWXH As String = "单位序号"
        Public Const FIELD_DC_B_RS_RENYUANJIAGOU_DW_SSDW As String = "所属单位"
        Public Const FIELD_DC_B_RS_RENYUANJIAGOU_DW_DWMC As String = "单位名称"
        Public Const FIELD_DC_B_RS_RENYUANJIAGOU_DW_BZRS As String = "编制人数"
        Public Const FIELD_DC_B_RS_RENYUANJIAGOU_DW_SJBZ As String = "实际编制"
        '显示字段序列
        '约束错误信息

        '“地产_B_人事_人员架构_人员”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_RENYUANJIAGOU_RY As String = "地产_B_人事_人员架构_人员"
        '字段序列
        Public Const FIELD_DC_B_RS_RENYUANJIAGOU_RY_RYDM As String = "人员代码"
        Public Const FIELD_DC_B_RS_RENYUANJIAGOU_RY_RYZM As String = "人员真名"
        Public Const FIELD_DC_B_RS_RENYUANJIAGOU_RY_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_RENYUANJIAGOU_RY_ZJMC As String = "职级名称"
        Public Const FIELD_DC_B_RS_RENYUANJIAGOU_RY_RYZT As String = "人员状态"
        Public Const FIELD_DC_B_RS_RENYUANJIAGOU_RY_SFZB As String = "是否占编"
        Public Const FIELD_DC_B_RS_RENYUANJIAGOU_RY_XGRY As String = "相关人员"
        '显示字段序列
        '约束错误信息

        'zengxianglin 2008-10-14
        '表名称
        Public Const TABLE_DC_V_RS_ZHIJIMAXRENYUAN As String = "地产_V_人事_职级序列最大人员数"
        '字段序列
        Public Const FIELD_DC_V_RS_ZHIJIMAXRENYUAN_XLHM As String = "序列号码" '0,1,2,3,...
        Public Const FIELD_DC_V_RS_ZHIJIMAXRENYUAN_ZJXL As String = "职级序列" '001.001.003|001.001.002
        Public Const FIELD_DC_V_RS_ZHIJIMAXRENYUAN_ZDSM As String = "最大数目"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-10-14

        'zengxianglin 2008-11-18
        '“地产_VT_人事_人员架构_报表参数”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_VT_RS_RYJG_BBCS As String = "地产_VT_人事_人员架构_报表参数"
        '字段序列
        Public Const FIELD_DC_VT_RS_RYJG_BBCS_BBHS As String = "报表行数"
        Public Const FIELD_DC_VT_RS_RYJG_BBCS_BBLS As String = "报表列数"
        Public Const FIELD_DC_VT_RS_RYJG_BBCS_QYZJLS As String = "总监列数"
        Public Const FIELD_DC_VT_RS_RYJG_BBCS_QYJLLS As String = "区经列数"
        Public Const FIELD_DC_VT_RS_RYJG_BBCS_YYJLLS As String = "营经列数"
        Public Const FIELD_DC_VT_RS_RYJG_BBCS_YWJLLS As String = "业经列数"
        Public Const FIELD_DC_VT_RS_RYJG_BBCS_WYGWLS As String = "顾问列数"
        Public Const FIELD_DC_VT_RS_RYJG_BBCS_XZZLLS As String = "文员列数"
        '显示字段序列
        '约束错误信息
        '“地产_VT_人事_人员架构_索引数据”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_VT_RS_RYJG_SYSJ As String = "地产_VT_人事_人员架构_索引数据"
        '字段序列
        Public Const FIELD_DC_VT_RS_RYJG_SYSJ_RYDM As String = "人员代码"
        Public Const FIELD_DC_VT_RS_RYJG_SYSJ_SSDW As String = "所属单位"
        Public Const FIELD_DC_VT_RS_RYJG_SYSJ_ZJDM As String = "职级代码"
        Public Const FIELD_DC_VT_RS_RYJG_SYSJ_DWXH As String = "单位序号"
        Public Const FIELD_DC_VT_RS_RYJG_SYSJ_DWHS As String = "单位行数"
        '显示字段序列
        '约束错误信息
        '“地产_VT_人事_人员架构_序列数据”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_VT_RS_RYJG_XLSJ As String = "地产_VT_人事_人员架构_序列数据"
        '字段序列
        Public Const FIELD_DC_VT_RS_RYJG_XLSJ_RYDM As String = "人员代码"
        Public Const FIELD_DC_VT_RS_RYJG_XLSJ_SSDW As String = "所属单位"
        Public Const FIELD_DC_VT_RS_RYJG_XLSJ_SJLD As String = "上级领导"
        Public Const FIELD_DC_VT_RS_RYJG_XLSJ_ZJDM As String = "职级代码"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-11-18

        'zengxianglin 2008-12-08
        '“地产_VT_人事_正式职工考核”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_VT_RS_ZSZGKH As String = "地产_VT_人事_正式职工考核"
        '字段序列
        Public Const FIELD_DC_VT_RS_ZSZGKH_RYDM As String = "人员代码"
        Public Const FIELD_DC_VT_RS_ZSZGKH_RYMC As String = "人员名称"
        Public Const FIELD_DC_VT_RS_ZSZGKH_JMZJ As String = "季末职级"
        Public Const FIELD_DC_VT_RS_ZSZGKH_ZJMC As String = "职级名称"
        Public Const FIELD_DC_VT_RS_ZSZGKH_SRYJ As String = "私人业绩"
        Public Const FIELD_DC_VT_RS_ZSZGKH_TDYJ As String = "团队业绩"
        Public Const FIELD_DC_VT_RS_ZSZGKH_SRPJ As String = "私人平均"
        Public Const FIELD_DC_VT_RS_ZSZGKH_TDPJ As String = "团队平均"
        Public Const FIELD_DC_VT_RS_ZSZGKH_GZQK As String = "工作情况"
        Public Const FIELD_DC_VT_RS_ZSZGKH_PJRS As String = "平均人数"
        Public Const FIELD_DC_VT_RS_ZSZGKH_KHYJ As String = "考核业绩"
        Public Const FIELD_DC_VT_RS_ZSZGKH_KHZB As String = "考核指标"
        Public Const FIELD_DC_VT_RS_ZSZGKH_DDDJ As String = "达到等级"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-12-08

        'zengxianglin 2008-12-08
        '“地产_VT_人事_试用职工考核”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_VT_RS_SYZGKH As String = "地产_VT_人事_试用职工考核"
        '字段序列
        '=============================================================================================
        Public Const FIELD_DC_VT_RS_SYZGKH_XSMC As String = "显示名称"
        Public Const FIELD_DC_VT_RS_SYZGKH_XSJB As String = "显示级别"
        Public Const FIELD_DC_VT_RS_SYZGKH_RYDM As String = "人员代码"
        Public Const FIELD_DC_VT_RS_SYZGKH_RYMC As String = "人员名称"
        Public Const FIELD_DC_VT_RS_SYZGKH_RZRQ As String = "入职日期"
        '=============================================================================================
        Public Const FIELD_DC_VT_RS_SYZGKH_JYLX As String = "交易类型"
        Public Const FIELD_DC_VT_RS_SYZGKH_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_RS_SYZGKH_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_RS_SYZGKH_DGRQ As String = "订购日期"
        Public Const FIELD_DC_VT_RS_SYZGKH_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_RS_SYZGKH_TJRQ As String = "统计日期"
        Public Const FIELD_DC_VT_RS_SYZGKH_JARQ As String = "结案日期"
        Public Const FIELD_DC_VT_RS_SYZGKH_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_RS_SYZGKH_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_RS_SYZGKH_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_RS_SYZGKH_JYJG As String = "交易价格"
        Public Const FIELD_DC_VT_RS_SYZGKH_JYMJ As String = "交易面积"
        Public Const FIELD_DC_VT_RS_SYZGKH_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_VT_RS_SYZGKH_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_VT_RS_SYZGKH_AJFH As String = "按揭返还"
        Public Const FIELD_DC_VT_RS_SYZGKH_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_RS_SYZGKH_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_VT_RS_SYZGKH_ZDLF As String = "总代理费"
        Public Const FIELD_DC_VT_RS_SYZGKH_KHYJ As String = "考核业绩"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2008-12-08

        'zengxianglin 2009-12-28
        '“地产_B_人事_团队组合”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_TDZH As String = "地产_B_人事_团队组合"
        '字段序列
        '=============================================================================================
        Public Const FIELD_DC_B_RS_TDZH_ZHBS As String = "组合标识"
        Public Const FIELD_DC_B_RS_TDZH_ZBBS As String = "组别标识"
        Public Const FIELD_DC_B_RS_TDZH_SSDW As String = "所属单位"
        Public Const FIELD_DC_B_RS_TDZH_TDBH As String = "团队编号"
        '=============================================================================================
        Public Const FIELD_DC_B_RS_TDZH_DWMC As String = "单位名称"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-12-28

        'zengxianglin 2010-01-13
        '“地产_B_人事_考核标准_X2_精英”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_X2_KHBZ_JY As String = "地产_B_人事_考核标准_X2_精英"
        '字段序列
        '=============================================================================================
        Public Const FIELD_DC_B_RS_X2_KHBZ_JY_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_X2_KHBZ_JY_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_X2_KHBZ_JY_ZSBZ As String = "正式标准"
        Public Const FIELD_DC_B_RS_X2_KHBZ_JY_SYBZ As String = "试用标准"
        '=============================================================================================
        '显示字段序列
        Public Const FIELD_DC_B_RS_X2_KHBZ_JY_ZJMC As String = "职级名称"
        '约束错误信息
        'zengxianglin 2010-01-13

        'zengxianglin 2010-01-13
        '“地产_B_人事_考核标准_X2_管理”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_X2_KHBZ_GL As String = "地产_B_人事_考核标准_X2_管理"
        '字段序列
        '=============================================================================================
        Public Const FIELD_DC_B_RS_X2_KHBZ_GL_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_X2_KHBZ_GL_TDSX As String = "团队属性"
        Public Const FIELD_DC_B_RS_X2_KHBZ_GL_JZZB As String = "基准指标"
        Public Const FIELD_DC_B_RS_X2_KHBZ_GL_JZRS As String = "基准人数"
        Public Const FIELD_DC_B_RS_X2_KHBZ_GL_TZZB As String = "调整指标"
        '=============================================================================================
        '显示字段序列
        Public Const FIELD_DC_B_RS_X2_KHBZ_GL_TDSXMC As String = "团队属性名称"
        '约束错误信息
        'zengxianglin 2010-01-13

        'zengxianglin 2010-01-13
        '“地产_VT_人事_X2_考核结果_精英”表信息定义
        '表名称
        Public Const TABLE_DC_VT_RS_X2_KHJG_JY As String = "地产_VT_人事_X2_考核结果_精英"
        '字段序列
        '=============================================================================================
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_XSJB As String = "显示级别"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_XSMC As String = "显示名称"
        '=============================================================================================
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_KHND As String = "考核年度"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_KHJD As String = "考核季度"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_KHYD As String = "考核月度"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_KSRQ As String = "开始日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_ZZRQ As String = "终止日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_CBRQ As String = "测编日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_RYDM As String = "人员代码"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_RYMC As String = "人员名称"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_DWDM As String = "单位代码"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_DWMC As String = "单位名称"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_DWXH As String = "单位序号"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_TDBH As String = "团队编号"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_ZGBJ As String = "直管标记"
        '=============================================================================================
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_RGBS As String = "认购标识"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_RGRQ As String = "订购日期"
        '=============================================================================================
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_HTBS As String = "合同标识"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_HTLX As String = "合同类型"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_JARQ As String = "结案日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_TJRQ As String = "统计日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_JYJG As String = "交易价格"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_JYMJ As String = "交易面积"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_JYYZJ As String = "交易月租金"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_ZDLF As String = "总代理费"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_ZLSF As String = "总律师费"
        '=============================================================================================
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_JSSH As String = "结算书号"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_JSRQ As String = "结算日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_JYRQ As String = "计佣日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_ZTBZ As String = "状态标志"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_SYRY As String = "试用人员"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_RYZJ As String = "人员职级"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_ZJMC As String = "职级名称"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_DLFE As String = "代理费额"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_LSFE As String = "律师费额"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_KHYJ As String = "考核业绩"
        '=============================================================================================
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_YDZB As String = "月度指标"
        Public Const FIELD_DC_VT_RS_X2_KHJG_JY_YDDB As String = "月度达标"
        '=============================================================================================
        '显示字段序列
        '约束错误信息
        'zengxianglin 2010-01-13

        'zengxianglin 2010-01-13
        '“地产_VT_人事_X2_考核结果_管理”表信息定义
        '表名称
        Public Const TABLE_DC_VT_RS_X2_KHJG_GL As String = "地产_VT_人事_X2_考核结果_管理"
        '字段序列
        '=============================================================================================
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_XSJB As String = "显示级别"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_XSMC As String = "显示名称"
        '=============================================================================================
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_KHND As String = "考核年度"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_KHJD As String = "考核季度"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_KHYD As String = "考核月度"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_KSRQ As String = "开始日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_ZZRQ As String = "终止日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_CBRQ As String = "测编日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_RYDM As String = "人员代码"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_RYMC As String = "人员名称"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_DWDM As String = "单位代码"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_DWMC As String = "单位名称"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_DWXH As String = "单位序号"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_TDBH As String = "团队编号"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_ZGBJ As String = "直管标记"
        '=============================================================================================
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_QRSH As String = "确认书号"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_RGBS As String = "认购标识"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_RGRQ As String = "订购日期"
        '=============================================================================================
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_HTBH As String = "合同编号"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_HTBS As String = "合同标识"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_HTLX As String = "合同类型"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_HTRQ As String = "合同日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_JARQ As String = "结案日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_TJRQ As String = "统计日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_YZMC As String = "业主名称"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_KHMC As String = "客户名称"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_WYDZ As String = "物业地址"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_JYJG As String = "交易价格"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_JYMJ As String = "交易面积"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_JYYZJ As String = "交易月租金"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_JFDLF As String = "甲方代理费"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_YFDLF As String = "乙方代理费"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_DLFZK As String = "代理费折扣"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_ZDLF As String = "总代理费"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_ZLSF As String = "总律师费"
        '=============================================================================================
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_JSSH As String = "结算书号"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_JSRQ As String = "结算日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_JYRQ As String = "计佣日期"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_SSFZ As String = "所属分组"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_ZTBZ As String = "状态标志"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_SYRY As String = "试用人员"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_RYZJ As String = "人员职级"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_ZJMC As String = "职级名称"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_FPBL As String = "分配比例"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_DLFE As String = "代理费额"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_LSFE As String = "律师费额"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_KHYJ As String = "考核业绩"
        '=============================================================================================
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_TDYJ As String = "团队业绩"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_TDLX As String = "团队类型"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_TDLXMC As String = "团队类型名称"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_TDRS As String = "团队人数"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_YDZB As String = "月度指标"
        Public Const FIELD_DC_VT_RS_X2_KHJG_GL_YDDB As String = "月度达标"
        '=============================================================================================
        '显示字段序列
        '约束错误信息
        'zengxianglin 2010-01-13

        'LJ 2010-1-16
        '“地产_B_人事_佣金标准_X2_私佣”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY As String = "地产_B_人事_佣金标准_X2_私佣"
        '字段序列
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_JTBL As String = "计提比例"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_QJZX As String = "区间最小"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_QJZD As String = "区间最大"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_ZXED As String = "最小额度"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_ZDED As String = "最大额度"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_SXRQ As String = "生效时间"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_SXSJ As String = "失效时间"
        'LJ 2010-1-16

        'LJ 2010-1-16
        '“地产_B_人事_佣金标准_X2_公佣_直管”表信息定义
        Public Const TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG As String = "地产_B_人事_佣金标准_X2_公佣_直管"
        '字段序列
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_JTBL As String = "计提比例"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_QJZX As String = "区间最小"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_QJZD As String = "区间最大"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_ZXRWBL As String = "最小任务比例"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_ZDRWBL As String = "最大任务比例"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_SXRQ As String = "生效时间"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_SXSJ As String = "失效时间"
        '显示字段序列
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_ZJMC As String = "职级名称"
        'LJ 2010-1-16

        'LJ 2010-1-16
        '“地产_B_人事_佣金标准_X2_公佣_协管”表信息定义
        Public Const TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG As String = "地产_B_人事_佣金标准_X2_公佣_协管"
        '字段序列
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_JTBL As String = "计提比例"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_QJZX As String = "区间最小"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_QJZD As String = "区间最大"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_SXRQ As String = "生效时间"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_SXSJ As String = "失效时间"
        'LJ 2010-1-16

        'LJ 2010-1-16
        '“地产_B_人事_佣金标准_X2_公佣_直提”表信息定义
        Public Const TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT As String = "地产_B_人事_佣金标准_X2_公佣_直提"
        '字段序列
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_JTBL As String = "计提比例"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_SXRQ As String = "生效时间"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_SXSJ As String = "失效时间"
        '显示字段序列
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_ZJMC As String = "职级名称"
        'LJ 2010-1-16

        'LJ 2010-1-16
        '“地产_B_人事_佣金标准_X2_公佣_直管指标”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB As String = "地产_B_人事_佣金标准_X2_公佣_直管指标"
        '字段序列
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_JTBL As String = "计提比例"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_QJZX As String = "区间最小"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_QJZD As String = "区间最大"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_ZXBL As String = "最小任务比例"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_ZDBL As String = "最大任务比例"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_SXRQ As String = "生效时间"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_SXSJ As String = "失效时间"
        '约束错误信息
        '显示字段序列
        'LJ 2010-1-16

        'LJ 2010-1-16
        '“地产_B_人事_佣金计提标准_私佣职级”虚拟表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ As String = "地产_B_人事_佣金标准_X2_公佣_直管职级"
        '字段序列
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ_ZJMC As String = "职级名称"
        '显示字段序列
        'LJ 2010-1-16

        'zengxianglin 2010-05-04
        '“地产_B_人事_佣金标准_X3_私佣”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_YJBZ_X3_SY As String = "地产_B_人事_佣金标准_X3_私佣"
        '字段序列
        Public Const FIELD_DC_B_RS_YJBZ_X3_SY_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_YJBZ_X3_SY_JTBL As String = "计提比例"
        Public Const FIELD_DC_B_RS_YJBZ_X3_SY_QJZX As String = "区间最小"
        Public Const FIELD_DC_B_RS_YJBZ_X3_SY_QJZD As String = "区间最大"
        Public Const FIELD_DC_B_RS_YJBZ_X3_SY_ZXED As String = "最小额度"
        Public Const FIELD_DC_B_RS_YJBZ_X3_SY_ZDED As String = "最大额度"
        'zengxianglin 2010-05-04

        'zengxianglin 2010-05-04
        '“地产_B_人事_佣金标准_X3_公佣_直管”表信息定义
        Public Const TABLE_DC_B_RS_YJBZ_X3_GY_ZG As String = "地产_B_人事_佣金标准_X3_公佣_直管"
        '字段序列
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_ZG_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_ZG_JTBL As String = "计提比例"
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_ZG_QJZX As String = "区间最小"
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_ZG_QJZD As String = "区间最大"
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZXED As String = "最小额度"
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZDED As String = "最大额度"
        '显示字段序列
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJMC As String = "职级名称"
        'zengxianglin 2010-05-04

        'zengxianglin 2010-05-04
        '“地产_B_人事_佣金标准_X3_公佣_协管”表信息定义
        Public Const TABLE_DC_B_RS_YJBZ_X3_GY_XG As String = "地产_B_人事_佣金标准_X3_公佣_协管"
        '字段序列
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_XG_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_XG_JTBL As String = "计提比例"
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_XG_QJZX As String = "区间最小"
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_XG_QJZD As String = "区间最大"
        'zengxianglin 2010-05-04

        'zengxianglin 2010-05-04
        '“地产_B_人事_佣金标准_X3_公佣_直提”表信息定义
        Public Const TABLE_DC_B_RS_YJBZ_X3_GY_ZT As String = "地产_B_人事_佣金标准_X3_公佣_直提"
        '字段序列
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_ZT_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_ZT_JTBL As String = "计提比例"
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_ZT_QJZX As String = "区间最小"
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_ZT_QJZD As String = "区间最大"
        '显示字段序列
        Public Const FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJMC As String = "职级名称"
        'zengxianglin 2010-05-04

        'zengxianglin 2011-01-10
        '“地产_B_人事_佣金标准_X4_私佣”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_YJBZ_X4_SY As String = "地产_B_人事_佣金标准_X4_私佣"
        '字段序列
        Public Const FIELD_DC_B_RS_YJBZ_X4_SY_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_YJBZ_X4_SY_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_YJBZ_X4_SY_JTBL As String = "计提比例"
        Public Const FIELD_DC_B_RS_YJBZ_X4_SY_QJZX As String = "区间最小"
        Public Const FIELD_DC_B_RS_YJBZ_X4_SY_QJZD As String = "区间最大"
        Public Const FIELD_DC_B_RS_YJBZ_X4_SY_ZXED As String = "最小额度"
        Public Const FIELD_DC_B_RS_YJBZ_X4_SY_ZDED As String = "最大额度"
        '显示字段序列
        Public Const FIELD_DC_B_RS_YJBZ_X4_SY_ZJMC As String = "职级名称"
        '“地产_B_人事_佣金标准_X4_公佣_直管”表信息定义
        Public Const TABLE_DC_B_RS_YJBZ_X4_GY_ZG As String = "地产_B_人事_佣金标准_X4_公佣_直管"
        '字段序列
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_ZG_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_ZG_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_ZG_JTBL As String = "计提比例"
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_ZG_QJZX As String = "区间最小"
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_ZG_QJZD As String = "区间最大"
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_ZG_ZXED As String = "最小额度"
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_ZG_ZDED As String = "最大额度"
        '显示字段序列
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_ZG_ZJMC As String = "职级名称"
        '“地产_B_人事_佣金标准_X4_公佣_协管”表信息定义
        Public Const TABLE_DC_B_RS_YJBZ_X4_GY_XG As String = "地产_B_人事_佣金标准_X4_公佣_协管"
        '字段序列
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_XG_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_XG_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_XG_JTBL As String = "计提比例"
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_XG_QJZX As String = "区间最小"
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_XG_QJZD As String = "区间最大"
        '显示字段序列
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_XG_ZJMC As String = "职级名称"
        '“地产_B_人事_佣金标准_X4_公佣_直提”表信息定义
        Public Const TABLE_DC_B_RS_YJBZ_X4_GY_ZT As String = "地产_B_人事_佣金标准_X4_公佣_直提"
        '字段序列
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_ZT_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_ZT_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_ZT_JTBL As String = "计提比例"
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_ZT_QJZX As String = "区间最小"
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_ZT_QJZD As String = "区间最大"
        '显示字段序列
        Public Const FIELD_DC_B_RS_YJBZ_X4_GY_ZT_ZJMC As String = "职级名称"
        'zengxianglin 2011-01-10



        '“地产_B_人事_入职审批_人员信息”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI As String = "地产_B_人事_入职审批_人员信息"
        '字段序列
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WJBS As String = "文件标识"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_JLBH As String = "简历编号"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPQD As String = "招聘渠道"

        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXH As String = "人员序号"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYDM As String = "人员代码"

        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXM As String = "人员姓名"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXB As String = "人员性别"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYNN As String = "人员年龄"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXL As String = "人员学历"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NFPBM As String = "拟分配部门"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NDRZW As String = "拟担任职位"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NBDRQ As String = "拟报到日期"

        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPSM As String = "招聘说明"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WLJN As String = "网络技能"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_XYRYS As String = "现有人员数"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DBRYS As String = "定编人员数"

        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPBS As String = "审批标识"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPSM As String = "审批说明"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPJG As String = "审批结果"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPR As String = "审批人"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPRQ As String = "审批日期"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZHM As String = "身份证号码"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_BMJL As String = "部门经理"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZJDM As String = "职级代码"
        Public Const FIELD_DC_b_RS_RUZHISHENPI_RENYUANXINXI_ZJMC As String = "职级名称"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_YYDM As String = "原因代码"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_YYMC As String = "原因名称"

        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_LXDH As String = "联系电话"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZT As String = "人员状态"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DWDM As String = "单位代码"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_TDBH As String = "团队编号"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZB As String = "是否占编"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFJZ As String = "是否兼职"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYLX As String = "人员类型"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_BZXL As String = "标准序列"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYLXMC As String = "人员类型名称"


        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZTMC As String = "人员状态名称"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZB As String = "占编"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPJGMC As String = "审批结果名称"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPZT As String = "审批状态"

        '即时计算显示
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_XYRY As String = "现有人员"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DBRS As String = "定编人数"

        '“地产_B_人事_入职审批”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_RUZHISHENPI As String = "地产_B_人事_入职审批"
        '字段序列

        Public Const FIELD_DC_B_RS_RUZHISHENPI_WJBS As String = "文件标识"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_LSH As String = "流水号"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_DDSZ As String = "单独设置"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_BLZT As String = "办理状态"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_QFR As String = "签发人"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_QFRQ As String = "签发日期"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_JBRY As String = "经办人员"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_JBRQ As String = "经办日期"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_JBDW As String = "经办单位"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_JJCD As String = "紧急程度"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_MMDJ As String = "秘密等级"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_WJBT As String = "文件标题"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_JGDZ As String = "机关代字"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_WJNF As String = "文件年份"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_WJXH As String = "文件序号"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_ZWNR As String = "正文内容"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_HJWJ As String = "痕迹文件"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_PJYJ As String = "批件原件"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_BZXX As String = "备注信息"
        Public Const FIELD_DC_B_RS_RUZHISHENPI_DBRS As String = "定编人数"
        '显示字段序列
        Public Const FIELD_DC_B_RS_RUZHISHENPI_BWTX As String = "备忘提醒"
        '约束错误信息

        '“地产_B_人事_调整审批”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_TIAOZHENGSHENPI As String = "地产_B_人事_调整审批"
        '字段序列

        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_WJBS As String = "文件标识"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_LSH As String = "流水号"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_DDSZ As String = "单独设置"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_BLZT As String = "办理状态"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_QFR As String = "签发人"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_QFRQ As String = "签发日期"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_JBRY As String = "经办人员"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_JBRQ As String = "经办日期"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_JBDW As String = "经办单位"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_JJCD As String = "紧急程度"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_MMDJ As String = "秘密等级"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_WJBT As String = "文件标题"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_JGDZ As String = "机关代字"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_WJNF As String = "文件年份"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_WJXH As String = "文件序号"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_ZWNR As String = "正文内容"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_HJWJ As String = "痕迹文件"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_PJYJ As String = "批件原件"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_BZXX As String = "备注信息"
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_DBRS As String = "定编人数"
        '显示字段序列
        Public Const FIELD_DC_B_RS_TIAOZHENGSHENPI_BWTX As String = "备忘提醒"
        '约束错误信息

        '“地产_B_人事_离职审批”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_LIZHISHENPI As String = "地产_B_人事_离职审批"
        '字段序列

        Public Const FIELD_DC_B_RS_LIZHISHENPI_WJBS As String = "文件标识"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_LSH As String = "流水号"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_DDSZ As String = "单独设置"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_BLZT As String = "办理状态"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_QFR As String = "签发人"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_QFRQ As String = "签发日期"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_JBRY As String = "经办人员"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_JBRQ As String = "经办日期"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_JBDW As String = "经办单位"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_JJCD As String = "紧急程度"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_MMDJ As String = "秘密等级"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_WJBT As String = "文件标题"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_JGDZ As String = "机关代字"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_WJNF As String = "文件年份"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_WJXH As String = "文件序号"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_ZWNR As String = "正文内容"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_HJWJ As String = "痕迹文件"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_PJYJ As String = "批件原件"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_BZXX As String = "备注信息"
        Public Const FIELD_DC_B_RS_LIZHISHENPI_DBRS As String = "定编人数"
        '显示字段序列
        Public Const FIELD_DC_B_RS_LIZHISHENPI_BWTX As String = "备忘提醒"
        '约束错误信息

        '“地产_B_人事_实习生审批”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_SHIXISHENGSHENPI As String = "地产_B_人事_实习生审批"
        '字段序列

        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_WJBS As String = "文件标识"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_LSH As String = "流水号"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_DDSZ As String = "单独设置"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_BLZT As String = "办理状态"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_QFR As String = "签发人"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_QFRQ As String = "签发日期"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_JBRY As String = "经办人员"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_JBRQ As String = "经办日期"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_JBDW As String = "经办单位"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_JJCD As String = "紧急程度"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_MMDJ As String = "秘密等级"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_WJBT As String = "文件标题"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_JGDZ As String = "机关代字"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_WJNF As String = "文件年份"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_WJXH As String = "文件序号"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_ZWNR As String = "正文内容"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_HJWJ As String = "痕迹文件"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_PJYJ As String = "批件原件"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_BZXX As String = "备注信息"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_DBRS As String = "定编人数"
        '显示字段序列
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_BWTX As String = "备忘提醒"
        '约束错误信息


        '地产_B_人事_招聘渠道表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_ZHAOPINQUDAO As String = "地产_B_人事_招聘渠道"
        '字段序列
        Public Const FIELD_DC_B_RS_ZHAOPINQUDAO_DM As String = "招聘渠道代码"
        Public Const FIELD_DC_B_RS_ZHAOPINQUDAO_MC As String = "招聘渠道名称"


        '“地产_B_人事_调整审批_人员信息”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_TIAOZHENG_RENYUANXINXI As String = "地产_B_人事_调整审批_人员信息"
        '字段序列
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YWYBS As String = "原唯一标识"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_WJBS As String = "文件标识"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYDM As String = "人员代码"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYXM As String = "人员姓名"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYXH As String = "人员序号"

        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZJDM As String = "原职级代码"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZJMC As String = "原职级名称"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZJMC As String = "职级名称"

        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YDWDM As String = "原单位代码"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YDWMC As String = "原单位名称"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_DWDM As String = "单位代码"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_DWMC As String = "单位名称"

        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YTDBH As String = "原团队编号"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_TDBH As String = "团队编号"

        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YRYZT As String = "原人员状态"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YRYZTMC As String = "原人员状态名称"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYZT As String = "人员状态"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYZTMC As String = "人员状态名称"

        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YSFZB As String = "原是否占编"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZB As String = "原占编"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SFZB As String = "是否占编"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZB As String = "占编"

        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YYDM As String = "原因代码"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YYMC As String = "原因名称"

        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZGTD As String = "原直管团队"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZGTDMC As String = "原直管团队名称"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGTD As String = "直管团队"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGTDMC As String = "直管团队名称"

        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YXGTD As String = "原协管团队"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YXGTDMC As String = "原协管团队名称"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_XGTD As String = "协管团队"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_XGTDMC As String = "协管团队名称"

        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPBS As String = "审批标识"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPSM As String = "审批说明"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPJG As String = "审批结果"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPR As String = "审批人"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPRQ As String = "审批日期"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPJGMC As String = "审批结果名称"

        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SFJZ As String = "是否兼职"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYLX As String = "人员类型"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_BZXL As String = "标准序列"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYLXMC As String = "人员类型名称"

        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGDWDM As String = "直管单位代码"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGDWMC As String = "直管单位名称"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SJLD As String = "上级领导"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YSJLDMC As String = "上级经理"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SJLDMC As String = "上级领导名称"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_BDRQ As String = "报到日期"

        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SXRQ As String = "生效日期"

        '即时计算显示
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPZT As String = "审批状态"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_XYRY As String = "现有人员"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_DBRS As String = "定编人数"
        Public Const FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_XH As String = "序号"


        '“地产_B_人事_离职审批_人员信息”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_LIZHI_RENYUANXINXI As String = "地产_B_人事_离职审批_人员信息"
        '字段序列
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_WJBS As String = "文件标识"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_RYDM As String = "人员代码"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_RYXM As String = "人员姓名"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_RYXH As String = "人员序号"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_ZJDM As String = "职级代码"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_ZJMC As String = "职级名称"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_DWDM As String = "单位代码"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_DWMC As String = "单位名称"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_TDBH As String = "团队编号"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_RYZT As String = "人员状态"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_RYZTMC As String = "人员状态名称"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SFZB As String = "是否占编"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_ZB As String = "占编"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_YYDM As String = "原因代码"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_YYMC As String = "原因名称"
        
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SPBS As String = "审批标识"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SPSM As String = "审批说明"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SPJG As String = "审批结果"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SPR As String = "审批人"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SPRQ As String = "审批日期"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SPJGMC As String = "审批结果名称"

        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SFJZ As String = "是否兼职"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_RYLX As String = "人员类型"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_BZXL As String = "标准序列"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_RYLXMC As String = "人员类型名称"

        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_ZGDWDM As String = "直管单位代码"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_ZGDWMC As String = "直管单位名称"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SJLD As String = "上级领导"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SJLDMC As String = "上级领导名称"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_LZRQ As String = "离职日期"

        '即时计算显示
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SPZT As String = "审批状态"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_XYRY As String = "现有人员"
        Public Const FIELD_DC_B_RS_LIZHI_RENYUANXINXI_DBRS As String = "定编人数"

        '“地产_B_人事_实习生审批_人员信息”表信息定义
        '表名称
        Public Const TABLE_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI As String = "地产_B_人事_实习生审批_人员信息"
        '字段序列
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_WYBS As String = "唯一标识"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_WJBS As String = "文件标识"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_JLBH As String = "简历编号"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_ZPQD As String = "招聘渠道"

        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYXH As String = "人员序号"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYDM As String = "人员代码"

        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYXM As String = "人员姓名"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYXB As String = "人员性别"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYNN As String = "人员年龄"

        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYXL As String = "人员学历"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_NFPBM As String = "拟分配部门"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_NDRZW As String = "拟担任职位"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_NBDRQ As String = "拟报到日期"

        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_ZPSM As String = "招聘说明"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_WLJN As String = "网络技能"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_XYRYS As String = "现有人员数"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_DBRYS As String = "定编人员数"

        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPBS As String = "审批标识"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPSM As String = "审批说明"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPJG As String = "审批结果"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPR As String = "审批人"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPRQ As String = "审批日期"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SFZHM As String = "身份证号码"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_BMJL As String = "部门经理"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_ZJDM As String = "职级代码"
        Public Const FIELD_DC_b_RS_SHIXISHENGSHENPI_RENYUANXINXI_ZJMC As String = "职级名称"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_YYDM As String = "原因代码"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_YYMC As String = "原因名称"

        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_LXDH As String = "联系电话"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYZT As String = "人员状态"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_DWDM As String = "单位代码"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_TDBH As String = "团队编号"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SFZB As String = "是否占编"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SFJZ As String = "是否兼职"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYLX As String = "人员类型"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_BZXL As String = "标准序列"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYLXMC As String = "人员类型名称"


        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYZTMC As String = "人员状态名称"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_ZB As String = "占编"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPJGMC As String = "审批结果名称"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPZT As String = "审批状态"

        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_JDXX As String = "就读学校"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_ZY As String = "专业"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_GZDY As String = "工资待遇"

        '即时计算显示
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_XYRY As String = "现有人员"
        Public Const FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_DBRS As String = "定编人数"


        '定义初始化表类型enum
        Public Enum enumTableType
            DC_B_RS_ZHIJIDINGYI = 1

            DC_B_RS_YONGJINJITIBIAOZHUN = 2
            DC_B_RS_YEJIKAOHEBIAOZHUN = 3

            DC_B_RS_GUANLIJIAGOU = 4
            DC_B_RS_ZHULIJIAGOU = 5
            DC_V_RS_RENYUANJIAGOU = 6

            DC_B_RS_GERENLVLI = 7
            DC_B_RS_XUEXIJINGLI = 8
            DC_B_RS_GONGZUOJINGLI = 9

            DC_B_RS_LUYONGSHENPI = 10
            DC_B_RS_LUYONGSHENPI_RENYUANXINXI = 11

            DC_B_RS_YONGYINJITIBIAOZUN_GY = 12
            DC_B_RS_YONGYINJITIBIAOZUN_SYZB = 13
            DC_B_RS_YONGYINJITIBIAOZUN_SYZJ = 14

            DC_B_RS_YEJIKAOHEBIAOZHUN_XL = 15
            DC_B_RS_YEJIKAOHEBIAOZHUN_DW = 16

            DC_B_RS_RENYUANJIAGOU_DW = 17
            DC_B_RS_RENYUANJIAGOU_RY = 18

            'zengxianglin 2008-10-14
            DC_V_RS_ZHIJIMAXRENYUAN = 19
            'zengxianglin 2008-10-14

            'zengxianglin 2008-11-18
            DC_VT_RS_RYJG_BBCS = 20
            DC_VT_RS_RYJG_SYSJ = 21
            DC_VT_RS_RYJG_XLSJ = 22
            'zengxianglin 2008-11-18

            'zengxianglin 2008-12-08
            DC_VT_RS_ZSZGKH = 23
            DC_VT_RS_SYZGKH = 24
            'zengxianglin 2008-12-08

            'zengxianglin 2009-12-28
            DC_B_RS_TDZH = 25
            'zengxianglin 2009-12-28

            'zengxianglin 2010-01-13
            DC_B_RS_X2_KHBZ_JY = 26
            DC_B_RS_X2_KHBZ_GL = 27
            DC_VT_RS_X2_KHJG_JY = 28
            DC_VT_RS_X2_KHJG_GL = 29
            'zengxianglin 2010-01-13

            'LJ 2010-1-16
            DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY = 30
            DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG = 31
            DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG = 32
            DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT = 33
            DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB = 34
            DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ = 35
            'LJ 2010-1-16

            'zengxianglin 2010-05-04
            DC_B_RS_YJBZ_X3_SY = 36
            DC_B_RS_YJBZ_X3_GY_ZG = 37
            DC_B_RS_YJBZ_X3_GY_XG = 38
            DC_B_RS_YJBZ_X3_GY_ZT = 39
            'zengxianglin 2010-05-04

            'zengxianglin 2011-01-10
            DC_B_RS_YJBZ_X4_SY = 40
            DC_B_RS_YJBZ_X4_GY_ZG = 41
            DC_B_RS_YJBZ_X4_GY_XG = 42
            DC_B_RS_YJBZ_X4_GY_ZT = 43
            'zengxianglin 2011-01-10

            DC_B_RS_RUZHISHENPI_RENYUANXINXI = 44
            DC_B_RS_RUZHISHENPI = 45
            DC_B_RS_ZHAOPINQUDAO = 46

            DC_B_RS_TIAOZHENGSHENPI = 47
            DC_B_RS_TIAOZHENG_RENYUANXINXI = 50

            DC_B_RS_LIZHISHENPI = 51
            DC_B_RS_LIZHI_RENYUANXINXI = 52

            DC_B_RS_SHIXISHENGSHENPI = 53
            DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI = 54
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.Common.Data.estateRenshiXingyeData)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub

        '----------------------------------------------------------------
        ' 从web.config的[appSettings]中获取职级变动审批人员(RS_ZHIJISP_RY)
        '----------------------------------------------------------------
        Public Shared ReadOnly Property RS_ZHIJISP_RY() As String

            Get
                Try
                    RS_ZHIJISP_RY = ConfigurationManager.AppSettings("RS_ZHIJISP_RY")
                Catch ex As Exception
                    RS_ZHIJISP_RY = ""
                End Try
                If RS_ZHIJISP_RY Is Nothing Then RS_ZHIJISP_RY = ""
            End Get

        End Property

        '----------------------------------------------------------------
        ' 从web.config的[appSettings]中获取入职自动补阅人员(RS_RUZHI_RYMC)
        '----------------------------------------------------------------
        Public Shared ReadOnly Property RS_RUZHI_RYMC() As String

            Get
                Try
                    RS_RUZHI_RYMC = ConfigurationManager.AppSettings("RS_RUZHI_RYMC")
                Catch ex As Exception
                    RS_RUZHI_RYMC = ""
                End Try
                If RS_RUZHI_RYMC Is Nothing Then RS_RUZHI_RYMC = ""
            End Get

        End Property

        '----------------------------------------------------------------
        ' 从web.config的[appSettings]中获取架构查看管理员(RS_JIAGOU_ADMIN)
        '----------------------------------------------------------------
        Public Shared ReadOnly Property RS_JIAGOU_ADMIN() As String

            Get
                Try
                    RS_JIAGOU_ADMIN = ConfigurationManager.AppSettings("RS_JIAGOU_ADMIN")
                Catch ex As Exception
                    RS_JIAGOU_ADMIN = ""
                End Try
                If RS_JIAGOU_ADMIN Is Nothing Then RS_JIAGOU_ADMIN = ""
            End Get

        End Property

        '----------------------------------------------------------------
        ' 从web.config的[appSettings]中获取入职自动补阅人员(RS_LIZHI_RYMC)
        '----------------------------------------------------------------
        Public Shared ReadOnly Property RS_LIZHI_RYMC() As String

            Get
                Try
                    RS_LIZHI_RYMC = ConfigurationManager.AppSettings("RS_LIZHI_RYMC")
                Catch ex As Exception
                    RS_LIZHI_RYMC = ""
                End Try
                If RS_LIZHI_RYMC Is Nothing Then RS_LIZHI_RYMC = ""
            End Get

        End Property



        '----------------------------------------------------------------
        ' 专用列表
        '----------------------------------------------------------------
        Public Const YJJT_SYFF_GY As Integer = 1
        Public Const YJJT_SYFF_SY As Integer = 2

        Public Const YJJT_ZGBJ_ZG As Integer = 1
        Public Const YJJT_ZGBJ_XG As Integer = 0
        Public Const YJJT_ZGBJ_WX As Integer = -1

        Public Const YJJT_YJBJ_GR As Integer = 1
        Public Const YJJT_YJBJ_TD As Integer = 0

        Public Enum enumKaoheXulie
            x1 = 1
            x2 = 2
            x3 = 3
        End Enum

        'zengxianglin 2010-01-02 add [Shixisheng]
        Public Enum enumRenyuanZhuangtai
            Shiyong = 1
            Ruzhi = 2
            Shixisheng = 4
        End Enum


        Public Shared Function getRenyuanZhuangtaiName(ByVal obj As enumRenyuanZhuangtai) As String
            Try
                Select Case obj
                    Case enumRenyuanZhuangtai.Ruzhi
                        getRenyuanZhuangtaiName = "正式"
                    Case enumRenyuanZhuangtai.Shiyong
                        getRenyuanZhuangtaiName = "试用"
                        'zengxianglin 2010-01-02 add [Shixisheng]
                    Case enumRenyuanZhuangtai.Shixisheng
                        getRenyuanZhuangtaiName = "实习生"
                        'zengxianglin 2010-01-02 add [Shixisheng]
                    Case Else
                End Select
            Catch ex As Exception
                getRenyuanZhuangtaiName = ""
            End Try
        End Function
        Public Shared Function getRenyuanZhuangtaiCode(ByVal blnBits() As Boolean) As Integer
            Try
                getRenyuanZhuangtaiCode = 0
                If blnBits.Length > 2 Then
                    If blnBits(0) = True Then getRenyuanZhuangtaiCode += 1
                    If blnBits(1) = True Then getRenyuanZhuangtaiCode += 2
                    If blnBits(2) = True Then getRenyuanZhuangtaiCode += 4
                End If
            Catch ex As Exception
                getRenyuanZhuangtaiCode = 0
            End Try
        End Function
        'zengxianglin 2010-01-05
        Public Shared Function getRYZTtoZGSXCode(ByVal intRYZT As Integer) As String
            Try
                getRYZTtoZGSXCode = ""
                If (intRYZT And 1) = 1 Then
                    getRYZTtoZGSXCode = "002"
                ElseIf (intRYZT And 2) = 2 Then
                    getRYZTtoZGSXCode = "003"
                ElseIf (intRYZT And 4) = 4 Then
                    getRYZTtoZGSXCode = "001"
                Else
                    getRYZTtoZGSXCode = ""
                End If
            Catch ex As Exception
                getRYZTtoZGSXCode = ""
            End Try
        End Function
        Public Shared Function getRYZTtoZGSXName(ByVal intRYZT As Integer) As String
            Try
                getRYZTtoZGSXName = ""
                If (intRYZT And 1) = 1 Then
                    getRYZTtoZGSXName = "试用"
                ElseIf (intRYZT And 2) = 2 Then
                    getRYZTtoZGSXName = "正式"
                ElseIf (intRYZT And 4) = 4 Then
                    getRYZTtoZGSXName = "实习生"
                Else
                    getRYZTtoZGSXName = ""
                End If
            Catch ex As Exception
                getRYZTtoZGSXName = ""
            End Try
        End Function
        'zengxianglin 2010-01-05









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
                Case enumTableType.DC_B_RS_ZHIJIDINGYI
                    table = createDataTables_ZhijiDingyi(strErrMsg)

                Case enumTableType.DC_B_RS_YONGJINJITIBIAOZHUN
                    table = createDataTables_YongjinJitiBiaozhun(strErrMsg)
                Case enumTableType.DC_B_RS_YEJIKAOHEBIAOZHUN
                    table = createDataTables_YejiKaoheBiaozhun(strErrMsg)

                Case enumTableType.DC_B_RS_GUANLIJIAGOU
                    table = createDataTables_GuanliJiagou(strErrMsg)
                Case enumTableType.DC_B_RS_ZHULIJIAGOU
                    table = createDataTables_ZhuliJiagou(strErrMsg)
                Case enumTableType.DC_V_RS_RENYUANJIAGOU
                    table = createDataTables_RenyuanJiagou(strErrMsg)

                Case enumTableType.DC_B_RS_GERENLVLI
                    table = createDataTables_GerenLvli(strErrMsg)
                Case enumTableType.DC_B_RS_XUEXIJINGLI
                    table = createDataTables_XuexiJingli(strErrMsg)
                Case enumTableType.DC_B_RS_GONGZUOJINGLI
                    table = createDataTables_GongzuoJingli(strErrMsg)

                Case enumTableType.DC_B_RS_LUYONGSHENPI
                    table = createDataTables_LuyongShenpi(strErrMsg)
                Case enumTableType.DC_B_RS_LUYONGSHENPI_RENYUANXINXI
                    table = createDataTables_LuyongShenpi_RenyuanXinxi(strErrMsg)

                Case enumTableType.DC_B_RS_YONGYINJITIBIAOZUN_GY
                    table = createDataTables_YongjinJitiBiaozhun_GY(strErrMsg)
                Case enumTableType.DC_B_RS_YONGYINJITIBIAOZUN_SYZB
                    table = createDataTables_YongjinJitiBiaozhun_SYZB(strErrMsg)
                Case enumTableType.DC_B_RS_YONGYINJITIBIAOZUN_SYZJ
                    table = createDataTables_YongjinJitiBiaozhun_SYZJ(strErrMsg)

                Case enumTableType.DC_B_RS_YEJIKAOHEBIAOZHUN_XL
                    table = createDataTables_YejiKaoheBiaozhun_XL(strErrMsg)
                Case enumTableType.DC_B_RS_YEJIKAOHEBIAOZHUN_DW
                    table = createDataTables_YejiKaoheBiaozhun_DW(strErrMsg)

                Case enumTableType.DC_B_RS_RENYUANJIAGOU_DW
                    table = createDataTables_RenyuanJiagou_DW(strErrMsg)
                Case enumTableType.DC_B_RS_RENYUANJIAGOU_RY
                    table = createDataTables_RenyuanJiagou_RY(strErrMsg)

                    'zengxianglin 2008-10-14
                Case enumTableType.DC_V_RS_ZHIJIMAXRENYUAN
                    table = createDataTables_ZhijiMaxRenyuan(strErrMsg)
                    'zengxianglin 2008-10-14

                    'zengxianglin 2008-11-18
                Case enumTableType.DC_VT_RS_RYJG_BBCS
                    table = createDataTables_DC_VT_RS_RYJG_BBCS(strErrMsg)
                Case enumTableType.DC_VT_RS_RYJG_SYSJ
                    table = createDataTables_DC_VT_RS_RYJG_SYSJ(strErrMsg)
                Case enumTableType.DC_VT_RS_RYJG_XLSJ
                    table = createDataTables_DC_VT_RS_RYJG_XLSJ(strErrMsg)
                    'zengxianglin 2008-11-18

                    'zengxianglin 2008-12-08
                Case enumTableType.DC_VT_RS_ZSZGKH
                    table = createDataTables_DC_VT_RS_ZSZGKH(strErrMsg)
                Case enumTableType.DC_VT_RS_SYZGKH
                    table = createDataTables_DC_VT_RS_SYZGKH(strErrMsg)
                    'zengxianglin 2008-12-08

                    'zengxianglin 2009-12-28
                Case enumTableType.DC_B_RS_TDZH
                    table = createDataTables_DC_B_RS_TDZH(strErrMsg)
                    'zengxianglin 2009-12-28

                    'zengxianglin 2010-01-13
                Case enumTableType.DC_B_RS_X2_KHBZ_JY
                    table = createDataTables_DC_B_RS_X2_KHBZ_JY(strErrMsg)
                Case enumTableType.DC_B_RS_X2_KHBZ_GL
                    table = createDataTables_DC_B_RS_X2_KHBZ_GL(strErrMsg)
                Case enumTableType.DC_VT_RS_X2_KHJG_JY
                    table = createDataTables_DC_VT_RS_X2_KHJG_JY(strErrMsg)
                Case enumTableType.DC_VT_RS_X2_KHJG_GL
                    table = createDataTables_DC_VT_RS_X2_KHJG_GL(strErrMsg)
                    'zengxianglin 2010-01-13

                    'LJ 2010-1-16
                Case enumTableType.DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY
                    table = createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_SY(strErrMsg)
                Case enumTableType.DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG
                    table = createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_ZG(strErrMsg)
                Case enumTableType.DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG
                    table = createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_XG(strErrMsg)
                Case enumTableType.DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT
                    table = createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_ZT(strErrMsg)
                Case enumTableType.DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB
                    table = createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_ZGZB(strErrMsg)
                Case enumTableType.DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ
                    table = createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_ZGZJ(strErrMsg)
                    'LJ 2010-1-16

                    'zengxianglin 2010-05-04
                Case enumTableType.DC_B_RS_YJBZ_X3_SY
                    table = createDataTables_DC_B_RS_YJBZ_X3_SY(strErrMsg)
                Case enumTableType.DC_B_RS_YJBZ_X3_GY_ZG
                    table = createDataTables_DC_B_RS_YJBZ_X3_GY_ZG(strErrMsg)
                Case enumTableType.DC_B_RS_YJBZ_X3_GY_XG
                    table = createDataTables_DC_B_RS_YJBZ_X3_GY_XG(strErrMsg)
                Case enumTableType.DC_B_RS_YJBZ_X3_GY_ZT
                    table = createDataTables_DC_B_RS_YJBZ_X3_GY_ZT(strErrMsg)
                    'zengxianglin 2010-05-04

                    'zengxianglin 2011-01-10
                Case enumTableType.DC_B_RS_YJBZ_X4_SY
                    table = createDataTables_DC_B_RS_YJBZ_X4_SY(strErrMsg)
                Case enumTableType.DC_B_RS_YJBZ_X4_GY_ZG
                    table = createDataTables_DC_B_RS_YJBZ_X4_GY_ZG(strErrMsg)
                Case enumTableType.DC_B_RS_YJBZ_X4_GY_XG
                    table = createDataTables_DC_B_RS_YJBZ_X4_GY_XG(strErrMsg)
                Case enumTableType.DC_B_RS_YJBZ_X4_GY_ZT
                    table = createDataTables_DC_B_RS_YJBZ_X4_GY_ZT(strErrMsg)
                    'zengxianglin 2011-01-10

                Case enumTableType.DC_B_RS_RUZHISHENPI_RENYUANXINXI
                    table = createDataTables_DC_B_RS_RUZHISHENPI_RENYUANXINXI(strErrMsg)
                Case enumTableType.DC_B_RS_RUZHISHENPI
                    table = createDataTables_RUZHISHENPI(strErrMsg)
                Case enumTableType.DC_B_RS_ZHAOPINQUDAO
                    table = createDataTables_ZHAOPINQUDAO(strErrMsg)

                Case enumTableType.DC_B_RS_TIAOZHENGSHENPI
                    table = createDataTables_TIAOZHENGSHENPI(strErrMsg)

                Case enumTableType.DC_B_RS_TIAOZHENG_RENYUANXINXI
                    table = createDataTables_TIAOZHENG_RENYUANXINXI(strErrMsg)

                Case enumTableType.DC_B_RS_LIZHISHENPI
                    table = createDataTables_LIZHISHENPI(strErrMsg)

                Case enumTableType.DC_B_RS_LIZHI_RENYUANXINXI
                    table = createDataTables_LIZHI_RENYUANXINXI(strErrMsg)

                Case enumTableType.DC_B_RS_SHIXISHENGSHENPI
                    table = createDataTables_SHIXISHENGSHENPI(strErrMsg)

                Case enumTableType.DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI
                    table = createDataTables_SHIXISHENGSHENPI_RENYUANXINXI(strErrMsg)

                Case Else
                    strErrMsg = "无效的表类型！"
                    table = Nothing
            End Select

            createDataTables = table

        End Function


        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_SHIXISHENGSHENPI
        '----------------------------------------------------------------
        Private Function createDataTables_SHIXISHENGSHENPI(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_SHIXISHENGSHENPI)
                With table.Columns
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_WJBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_LSH, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_DDSZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_BLZT, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_QFR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_QFRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_JBRQ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_JBDW, GetType(System.String))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_JJCD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_MMDJ, GetType(System.String))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_WJBT, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_JGDZ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_WJNF, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_WJXH, GetType(System.String))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_ZWNR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_HJWJ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_PJYJ, GetType(System.String))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_BZXX, GetType(System.String))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_DBRS, GetType(System.Int32))


                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_BWTX, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_SHIXISHENGSHENPI = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI
        '----------------------------------------------------------------
        Private Function createDataTables_SHIXISHENGSHENPI_RENYUANXINXI(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI)
                With table.Columns
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_WJBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_WYBS, GetType(System.String))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_JLBH, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_ZPQD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYXH, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYDM, GetType(System.String))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYXM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYXB, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYNN, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYXL, GetType(System.String))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_NFPBM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_NDRZW, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_NBDRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_ZPSM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_WLJN, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_XYRYS, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_DBRYS, GetType(System.Int32))


                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPSM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPJG, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SFZHM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_BMJL, GetType(System.String))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_b_RS_SHIXISHENGSHENPI_RENYUANXINXI_ZJMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_YYDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_YYMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_LXDH, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYZT, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_DWDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_TDBH, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SFZB, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SFJZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYLX, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_BZXL, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYLXMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_RYZTMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_ZB, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPJGMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_JDXX, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_ZY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_GZDY, GetType(System.String))

                    '显示
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_XYRY, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_DBRS, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_RENYUANXINXI_SPZT, GetType(System.String))

                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_BLZT, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_JBRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_SHIXISHENGSHENPI_JBDW, GetType(System.String))

                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_SHIXISHENGSHENPI_RENYUANXINXI = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_LIZHI_RENYUANXINXI
        '----------------------------------------------------------------
        Private Function createDataTables_LIZHI_RENYUANXINXI(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_LIZHI_RENYUANXINXI)
                With table.Columns
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_WJBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_RYDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_RYXM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_RYXH, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_ZJMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_DWDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_DWMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_TDBH, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_RYZT, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_RYZTMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SFZB, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_ZB, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_YYDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_YYMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SPBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SPSM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SPJG, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SPR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SPRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_LZRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SPJGMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SFJZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_RYLX, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_BZXL, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_RYLXMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_ZGDWDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_ZGDWMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SJLD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SJLDMC, GetType(System.String))

                    '显示
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_XYRY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_DBRS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHI_RENYUANXINXI_SPZT, GetType(System.String))


                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_LIZHI_RENYUANXINXI = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_LIZHISHENPI
        '----------------------------------------------------------------
        Private Function createDataTables_LIZHISHENPI(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_LIZHISHENPI)
                With table.Columns
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_WJBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_LSH, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_DDSZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_BLZT, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_QFR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_QFRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_RS_LIZHISHENPI_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_JBRQ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_JBDW, GetType(System.String))

                    .Add(FIELD_DC_B_RS_LIZHISHENPI_JJCD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_MMDJ, GetType(System.String))

                    .Add(FIELD_DC_B_RS_LIZHISHENPI_WJBT, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_JGDZ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_WJNF, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_WJXH, GetType(System.String))

                    .Add(FIELD_DC_B_RS_LIZHISHENPI_ZWNR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_HJWJ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_PJYJ, GetType(System.String))

                    .Add(FIELD_DC_B_RS_LIZHISHENPI_BZXX, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_DBRS, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_LIZHISHENPI_BWTX, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_LIZHISHENPI = table

        End Function


        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_TIAOZHENG_RENYUANXINXI
        '----------------------------------------------------------------
        Private Function createDataTables_TIAOZHENG_RENYUANXINXI(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_TIAOZHENG_RENYUANXINXI)
                With table.Columns
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YWYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_WJBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYXM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYXH, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZJDM, GetType(System.String))
                    .Add(FIELD_DC_b_RS_TIAOZHENG_RENYUANXINXI_YZJMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_b_RS_TIAOZHENG_RENYUANXINXI_ZJMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YDWDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YDWMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_DWDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_DWMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YTDBH, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_TDBH, GetType(System.Int32))

                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YRYZT, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YRYZTMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYZT, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYZTMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YSFZB, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZB, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SFZB, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZB, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YYDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YYMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZGTD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YZGTDMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGTD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGTDMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YXGTD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YXGTDMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_XGTD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_XGTDMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPSM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPJG, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_BDRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPJGMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SFJZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYLX, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_BZXL, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_RYLXMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGDWDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_ZGDWMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SJLD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SJLDMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_YSJLDMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SXRQ, GetType(System.DateTime))

                    '显示
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_XYRY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_DBRS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_SPZT, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENG_RENYUANXINXI_XH, GetType(System.Int32))

                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_BLZT, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_JBRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_JBDW, GetType(System.String))

                  
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_TIAOZHENG_RENYUANXINXI = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_TIAOZHENGSHENPI
        '----------------------------------------------------------------
        Private Function createDataTables_TIAOZHENGSHENPI(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_TIAOZHENGSHENPI)
                With table.Columns
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_WJBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_LSH, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_DDSZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_BLZT, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_QFR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_QFRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_JBRQ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_JBDW, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_JJCD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_MMDJ, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_WJBT, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_JGDZ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_WJNF, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_WJXH, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_ZWNR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_HJWJ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_PJYJ, GetType(System.String))

                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_BZXX, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_DBRS, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_TIAOZHENGSHENPI_BWTX, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_TIAOZHENGSHENPI = table

        End Function


        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_ZHAOPINQUDAO
        '----------------------------------------------------------------
        Private Function createDataTables_ZHAOPINQUDAO(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_ZHAOPINQUDAO)
                With table.Columns
                    .Add(FIELD_DC_B_RS_ZHAOPINQUDAO_DM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_ZHAOPINQUDAO_MC, GetType(System.String))

                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_ZHAOPINQUDAO = table

        End Function



        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_RUZHISHENPI
        '----------------------------------------------------------------
        Private Function createDataTables_RUZHISHENPI(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_RUZHISHENPI)
                With table.Columns
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_WJBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_LSH, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_DDSZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_BLZT, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_QFR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_QFRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_RS_RUZHISHENPI_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_JBRQ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_JBDW, GetType(System.String))

                    .Add(FIELD_DC_B_RS_RUZHISHENPI_JJCD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_MMDJ, GetType(System.String))

                    .Add(FIELD_DC_B_RS_RUZHISHENPI_WJBT, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_JGDZ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_WJNF, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_WJXH, GetType(System.String))

                    .Add(FIELD_DC_B_RS_RUZHISHENPI_ZWNR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_HJWJ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_PJYJ, GetType(System.String))

                    .Add(FIELD_DC_B_RS_RUZHISHENPI_BZXX, GetType(System.String))

                    .Add(FIELD_DC_B_RS_RUZHISHENPI_DBRS, GetType(System.Int32))


                    .Add(FIELD_DC_B_RS_RUZHISHENPI_BWTX, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RUZHISHENPI = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_RUZHISHENPI_RENYUANXINXI(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_RUZHISHENPI_RENYUANXINXI)
                With table.Columns
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WJBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WYBS, GetType(System.String))

                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_JLBH, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPQD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXH, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYDM, GetType(System.String))

                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXB, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYNN, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYXL, GetType(System.String))

                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NFPBM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NDRZW, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_NBDRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZPSM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_WLJN, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_XYRYS, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DBRYS, GetType(System.Int32))


                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPSM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPJG, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZHM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_BMJL, GetType(System.String))

                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_b_RS_RUZHISHENPI_RENYUANXINXI_ZJMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_YYDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_YYMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_LXDH, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZT, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DWDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_TDBH, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFZB, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SFJZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYLX, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_BZXL, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYLXMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_RYZTMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_ZB, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPJGMC, GetType(System.String))
                    
                    '显示
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_XYRY, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_DBRS, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_RENYUANXINXI_SPZT, GetType(System.String))


                    .Add(FIELD_DC_B_RS_RUZHISHENPI_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_JBRQ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_JBDW, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RUZHISHENPI_BLZT, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_RUZHISHENPI_RENYUANXINXI = table

        End Function



        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_ZHIJIDINGYI
        '----------------------------------------------------------------
        Private Function createDataTables_ZhijiDingyi(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_ZHIJIDINGYI)
                With table.Columns
                    .Add(FIELD_DC_B_RS_ZHIJIDINGYI_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_ZHIJIDINGYI_ZJMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_ZHIJIDINGYI_JBSZ, GetType(System.Int32))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_ZhijiDingyi = table

        End Function










        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_YONGJINJITIBIAOZHUN
        '----------------------------------------------------------------
        Private Function createDataTables_YongjinJitiBiaozhun(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YONGJINJITIBIAOZHUN)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_SYFF, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZGBJ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_YJBJ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_TJHH, GetType(System.Int32))

                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJJT, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_BLJT, GetType(System.Double))

                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_QJZX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_QJZD, GetType(System.Double))


                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_ZJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_YongjinJitiBiaozhun = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN
        '----------------------------------------------------------------
        Private Function createDataTables_YejiKaoheBiaozhun(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_SYDW, GetType(System.String))

                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_SYFF, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_ZBXL, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_ZBSZ, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_ZBGS, GetType(System.String))


                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_ZJMC, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_SYDWMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_YejiKaoheBiaozhun = table

        End Function









        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_GUANLIJIAGOU
        '----------------------------------------------------------------
        Private Function createDataTables_GuanliJiagou(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_GUANLIJIAGOU)
                With table.Columns
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_RYDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_RYZT, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_SSDW, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_SFZB, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_SJLD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_KSSJ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_JSSJ, GetType(System.DateTime))
                    'zengxianglin 2008-10-14
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_SSFZ, GetType(System.String))
                    'zengxianglin 2008-10-14
                    'zengxianglin 2008-11-17
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_ZGDW, GetType(System.String))
                    'zengxianglin 2008-11-17
                    'zengxianglin 2009-12-28
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_BZXL, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_TDBH, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_ZGTD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_XGTD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_YDYY, GetType(System.String))
                    'zengxianglin 2009-12-28

                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_RYMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_ZJMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_RYZTMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_SSDWMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_SJLDMC, GetType(System.String))
                    'zengxianglin 2008-11-17
                    .Add(FIELD_DC_B_RS_GUANLIJIAGOU_ZGDWMC, GetType(System.String))
                    'zengxianglin 2008-11-17
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_GuanliJiagou = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_ZHULIJIAGOU
        '----------------------------------------------------------------
        Private Function createDataTables_ZhuliJiagou(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_ZHULIJIAGOU)
                With table.Columns
                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_WYBS, GetType(System.String))

                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_RYDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_RYZT, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_SSDW, GetType(System.String))
                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_SFZB, GetType(System.Int32))

                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_KSSJ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_JSSJ, GetType(System.DateTime))
                    'zengxianglin 2009-12-28
                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_BZXL, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_SFJZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_YDYY, GetType(System.String))
                    'zengxianglin 2009-12-28


                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_RYMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_ZJMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_RYZTMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_ZHULIJIAGOU_SSDWMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_ZhuliJiagou = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_V_RS_RENYUANJIAGOU
        '----------------------------------------------------------------
        Private Function createDataTables_RenyuanJiagou(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_V_RS_RENYUANJIAGOU)
                With table.Columns
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_WYBS, GetType(System.String))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_RYLX, GetType(System.String))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_RYDM, GetType(System.String))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_RYZT, GetType(System.Int32))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_SSDW, GetType(System.String))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_SFZB, GetType(System.Int32))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_SJLD, GetType(System.String))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_KSSJ, GetType(System.DateTime))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_JSSJ, GetType(System.DateTime))
                    'zengxianglin 2008-10-14
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_YDYY, GetType(System.String))
                    'zengxianglin 2008-10-14
                    'zengxianglin 2008-11-17
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_ZGDW, GetType(System.String))
                    'zengxianglin 2008-11-17
                    'zengxianglin 2009-12-28
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_BZXL, GetType(System.Int32))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_TDBH, GetType(System.Int32))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_ZGTD, GetType(System.String))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_XGTD, GetType(System.String))
                    'zengxianglin 2009-12-28
                    'zengxianglin 2009-12-31
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_SFJZ, GetType(System.Int32))
                    'zengxianglin 2009-12-31

                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_RYMC, GetType(System.String))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_ZJMC, GetType(System.String))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_RYZTMC, GetType(System.String))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_SSDWMC, GetType(System.String))
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_SJLDMC, GetType(System.String))
                    'zengxianglin 2008-10-14
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_YDYYMC, GetType(System.String))
                    'zengxianglin 2008-10-14
                    'zengxianglin 2008-11-17
                    .Add(FIELD_DC_V_RS_RENYUANJIAGOU_ZGDWMC, GetType(System.String))
                    'zengxianglin 2008-11-17
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RenyuanJiagou = table

        End Function









        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_GERENLVLI
        '----------------------------------------------------------------
        Private Function createDataTables_GerenLvli(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_GERENLVLI)
                With table.Columns
                    .Add(FIELD_DC_B_RS_GERENLVLI_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_RYDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_JLBH, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_XM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_XB, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_CSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_GERENLVLI_TBRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_RS_GERENLVLI_YWXM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_SFZH, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_SG, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_GERENLVLI_TZ, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_GERENLVLI_MZ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_JG, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_HJDZ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_XZDZ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_SJHM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_ZZDH, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_RYXP, GetType(System.String))

                    .Add(FIELD_DC_B_RS_GERENLVLI_HYZK, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_GERENLVLI_SYQK, GetType(System.Int32))

                    .Add(FIELD_DC_B_RS_GERENLVLI_ZGXL, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_ZGXW, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_BYYX, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_BYZY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_BYSJ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_GERENLVLI_JSZC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_ZCQDSJ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_RS_GERENLVLI_ZZMM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_RDSJ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_RS_GERENLVLI_GRJJ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_JZDS, GetType(System.String))

                    .Add(FIELD_DC_B_RS_GERENLVLI_YZGZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_GERENLVLI_ZYZG, GetType(System.String))

                    .Add(FIELD_DC_B_RS_GERENLVLI_YPZW, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_XJYQ, GetType(System.String))

                    .Add(FIELD_DC_B_RS_GERENLVLI_BZXX, GetType(System.String))
                    'zengxianglin 2009-05-14
                    .Add(FIELD_DC_B_RS_GERENLVLI_NYBM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_XCYJ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_DJRY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_DJBM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_DJSJ, GetType(System.DateTime))
                    'zengxianglin 2009-05-14

                    .Add(FIELD_DC_B_RS_GERENLVLI_NN, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_GERENLVLI_HYZKMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_SYQKMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_ZGXLMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_ZGXWMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_JSZCMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_ZZMMMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_ZYZGMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_SFLY, GetType(System.String))
                    'zengxianglin 2009-05-14
                    .Add(FIELD_DC_B_RS_GERENLVLI_NYBMMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_DJRYMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GERENLVLI_DJBMMC, GetType(System.String))
                    'zengxianglin 2009-05-14
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_GerenLvli = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_XUEXIJINGLI
        '----------------------------------------------------------------
        Private Function createDataTables_XuexiJingli(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_XUEXIJINGLI)
                With table.Columns
                    .Add(FIELD_DC_B_RS_XUEXIJINGLI_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_XUEXIJINGLI_RYDM, GetType(System.String))

                    'zengxianglin 2009-01-12
                    '.Add(FIELD_DC_B_RS_XUEXIJINGLI_KSNY, GetType(System.String))
                    '.Add(FIELD_DC_B_RS_XUEXIJINGLI_ZZNY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_XUEXIJINGLI_KSNY, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_XUEXIJINGLI_ZZNY, GetType(System.DateTime))
                    'zengxianglin 2009-01-12
                    .Add(FIELD_DC_B_RS_XUEXIJINGLI_XXLX, GetType(System.String))
                    .Add(FIELD_DC_B_RS_XUEXIJINGLI_XXYX, GetType(System.String))
                    .Add(FIELD_DC_B_RS_XUEXIJINGLI_XXZY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_XUEXIJINGLI_XXJG, GetType(System.String))
                    .Add(FIELD_DC_B_RS_XUEXIJINGLI_YXLZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_XUEXIJINGLI_YXWZ, GetType(System.Int32))

                    .Add(FIELD_DC_B_RS_XUEXIJINGLI_BZXX, GetType(System.String))


                    .Add(FIELD_DC_B_RS_XUEXIJINGLI_YXLZMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_XUEXIJINGLI_YXWZMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_XuexiJingli = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_GONGZUOJINGLI
        '----------------------------------------------------------------
        Private Function createDataTables_GongzuoJingli(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_GONGZUOJINGLI)
                With table.Columns
                    .Add(FIELD_DC_B_RS_GONGZUOJINGLI_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GONGZUOJINGLI_RYDM, GetType(System.String))

                    .Add(FIELD_DC_B_RS_GONGZUOJINGLI_KSNY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GONGZUOJINGLI_ZZNY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GONGZUOJINGLI_FWDW, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GONGZUOJINGLI_DRZW, GetType(System.String))

                    .Add(FIELD_DC_B_RS_GONGZUOJINGLI_YX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_GONGZUOJINGLI_LZYY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GONGZUOJINGLI_ZMR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_GONGZUOJINGLI_DH, GetType(System.String))

                    .Add(FIELD_DC_B_RS_GONGZUOJINGLI_BZXX, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_GongzuoJingli = table

        End Function










        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_LUYONGSHENPI
        '----------------------------------------------------------------
        Private Function createDataTables_LuyongShenpi(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_LUYONGSHENPI)
                With table.Columns
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_WJBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_LSH, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_DDSZ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_BLZT, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_QFR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_QFRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_JBRY, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_JBRQ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_JBDW, GetType(System.String))

                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_JJCD, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_MMDJ, GetType(System.String))

                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_WJBT, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_JGDZ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_WJNF, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_WJXH, GetType(System.String))

                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_ZWNR, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_HJWJ, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_PJYJ, GetType(System.String))

                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_BZXX, GetType(System.String))

                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_DBRS, GetType(System.Int32))


                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_BWTX, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_LuyongShenpi = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_LUYONGSHENPI_RENYUANXINXI
        '----------------------------------------------------------------
        Private Function createDataTables_LuyongShenpi_RenyuanXinxi(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_LUYONGSHENPI_RENYUANXINXI)
                With table.Columns
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_WYBS, GetType(System.String))

                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_WJBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXH, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_JLBH, GetType(System.String))

                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXB, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYNN, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_RYXL, GetType(System.String))

                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NFPBM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NDRZW, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_NBDRQ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_ZPSM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_XYRYS, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_LUYONGSHENPI_RENYUANXINXI_DBRYS, GetType(System.Int32))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_LuyongShenpi_RenyuanXinxi = table

        End Function










        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_YONGYINJITIBIAOZUN_GY
        '----------------------------------------------------------------
        Private Function createDataTables_YongjinJitiBiaozhun_GY(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YONGYINJITIBIAOZUN_GY)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZJMC, GetType(System.String))

                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_SYFF, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_YJBJ, GetType(System.Int32))

                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZGZJJT, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_ZGBLJT, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_XGZJJT, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_GY_XGBLJT, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_YongjinJitiBiaozhun_GY = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZB
        '----------------------------------------------------------------
        Private Function createDataTables_YongjinJitiBiaozhun_SYZB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZB)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_SYFF, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_ZBBJ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_YJBJ, GetType(System.Int32))

                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_QJZX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_QJZD, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZB_JTBL, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_YongjinJitiBiaozhun_SYZB = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ
        '----------------------------------------------------------------
        Private Function createDataTables_YongjinJitiBiaozhun_SYZJ(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_SYFF, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_ZBBJ, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_YJBJ, GetType(System.Int32))

                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YONGYINJITIBIAOZUN_SYZJ_ZJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_YongjinJitiBiaozhun_SYZJ = table

        End Function











        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_XL
        '----------------------------------------------------------------
        Private Function createDataTables_YejiKaoheBiaozhun_XL(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_XL)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZJMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR01, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR02, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_XL_ZBNR03, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_YejiKaoheBiaozhun_XL = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW
        '----------------------------------------------------------------
        Private Function createDataTables_YejiKaoheBiaozhun_DW(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YEJIKAOHEBIAOZHUN_DW)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_SYDW, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YEJIKAOHEBIAOZHUN_DW_DWMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_YejiKaoheBiaozhun_DW = table

        End Function










        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_RENYUANJIAGOU_DW
        '----------------------------------------------------------------
        Private Function createDataTables_RenyuanJiagou_DW(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_RENYUANJIAGOU_DW)
                With table.Columns
                    .Add(FIELD_DC_B_RS_RENYUANJIAGOU_DW_DWXH, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RENYUANJIAGOU_DW_SSDW, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RENYUANJIAGOU_DW_DWMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RENYUANJIAGOU_DW_BZRS, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RENYUANJIAGOU_DW_SJBZ, GetType(System.Int32))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RenyuanJiagou_DW = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_RENYUANJIAGOU_RY
        '----------------------------------------------------------------
        Private Function createDataTables_RenyuanJiagou_RY(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_RENYUANJIAGOU_RY)
                With table.Columns
                    .Add(FIELD_DC_B_RS_RENYUANJIAGOU_RY_RYDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RENYUANJIAGOU_RY_RYZM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RENYUANJIAGOU_RY_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RENYUANJIAGOU_RY_ZJMC, GetType(System.String))
                    .Add(FIELD_DC_B_RS_RENYUANJIAGOU_RY_RYZT, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RENYUANJIAGOU_RY_SFZB, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_RENYUANJIAGOU_RY_XGRY, GetType(System.Int32))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RenyuanJiagou_RY = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_DC_V_RS_ZHIJIMAXRENYUAN
        '----------------------------------------------------------------
        Private Function createDataTables_ZhijiMaxRenyuan(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_V_RS_ZHIJIMAXRENYUAN)
                With table.Columns
                    .Add(FIELD_DC_V_RS_ZHIJIMAXRENYUAN_XLHM, GetType(System.Int32))
                    .Add(FIELD_DC_V_RS_ZHIJIMAXRENYUAN_ZJXL, GetType(System.String))
                    .Add(FIELD_DC_V_RS_ZHIJIMAXRENYUAN_ZDSM, GetType(System.Int32))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_ZhijiMaxRenyuan = table

        End Function

        'zengxianglin 2008-11-18
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_RS_RYJG_BBCS
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_RS_RYJG_BBCS(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_RS_RYJG_BBCS)
                With table.Columns
                    .Add(FIELD_DC_VT_RS_RYJG_BBCS_BBHS, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_RYJG_BBCS_BBLS, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_RYJG_BBCS_QYZJLS, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_RYJG_BBCS_QYJLLS, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_RYJG_BBCS_YYJLLS, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_RYJG_BBCS_YWJLLS, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_RYJG_BBCS_WYGWLS, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_RYJG_BBCS_XZZLLS, GetType(System.Int32))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_RS_RYJG_BBCS = table

        End Function
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_RS_RYJG_SYSJ
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_RS_RYJG_SYSJ(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_RS_RYJG_SYSJ)
                With table.Columns
                    .Add(FIELD_DC_VT_RS_RYJG_SYSJ_RYDM, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_RYJG_SYSJ_SSDW, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_RYJG_SYSJ_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_RYJG_SYSJ_DWXH, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_RYJG_SYSJ_DWHS, GetType(System.Int32))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_RS_RYJG_SYSJ = table

        End Function
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_RS_RYJG_XLSJ
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_RS_RYJG_XLSJ(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_RS_RYJG_XLSJ)
                With table.Columns
                    .Add(FIELD_DC_VT_RS_RYJG_XLSJ_RYDM, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_RYJG_XLSJ_SSDW, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_RYJG_XLSJ_SJLD, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_RYJG_XLSJ_ZJDM, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_RS_RYJG_XLSJ = table

        End Function
        'zengxianglin 2008-11-18

        'zengxianglin 2008-12-08
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_RS_ZSZGKH
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_RS_ZSZGKH(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_RS_ZSZGKH)
                With table.Columns
                    .Add(FIELD_DC_VT_RS_ZSZGKH_RYDM, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_ZSZGKH_RYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_ZSZGKH_JMZJ, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_ZSZGKH_ZJMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_ZSZGKH_SRYJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_ZSZGKH_TDYJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_ZSZGKH_SRPJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_ZSZGKH_TDPJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_ZSZGKH_GZQK, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_ZSZGKH_PJRS, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_ZSZGKH_KHYJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_ZSZGKH_KHZB, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_ZSZGKH_DDDJ, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_RS_ZSZGKH = table

        End Function
        'zengxianglin 2008-12-08

        'zengxianglin 2008-12-08
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_RS_SYZGKH
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_RS_SYZGKH(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_RS_SYZGKH)
                With table.Columns
                    '=============================================================================================
                    .Add(FIELD_DC_VT_RS_SYZGKH_XSMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_SYZGKH_XSJB, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_SYZGKH_RYDM, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_SYZGKH_RYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_SYZGKH_RZRQ, GetType(System.DateTime))
                    '=============================================================================================
                    .Add(FIELD_DC_VT_RS_SYZGKH_JYLX, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_SYZGKH_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_SYZGKH_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_SYZGKH_DGRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_SYZGKH_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_SYZGKH_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_SYZGKH_JARQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_SYZGKH_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_SYZGKH_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_SYZGKH_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_SYZGKH_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_SYZGKH_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_SYZGKH_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_SYZGKH_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_SYZGKH_AJFH, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_SYZGKH_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_SYZGKH_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_SYZGKH_ZDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_SYZGKH_KHYJ, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_RS_SYZGKH = table

        End Function
        'zengxianglin 2008-12-08

        'zengxianglin 2009-12-28
        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_TDZH
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_TDZH(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_TDZH)
                With table.Columns
                    '=============================================================================================
                    .Add(FIELD_DC_B_RS_TDZH_ZHBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TDZH_ZBBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TDZH_SSDW, GetType(System.String))
                    .Add(FIELD_DC_B_RS_TDZH_TDBH, GetType(System.Int32))
                    '=============================================================================================
                    .Add(FIELD_DC_B_RS_TDZH_DWMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_TDZH = table

        End Function
        'zengxianglin 2009-12-28

        'zengxianglin 2010-01-13
        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_X2_KHBZ_JY
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_X2_KHBZ_JY(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_X2_KHBZ_JY)
                With table.Columns
                    '=============================================================================================
                    .Add(FIELD_DC_B_RS_X2_KHBZ_JY_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_X2_KHBZ_JY_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_X2_KHBZ_JY_ZSBZ, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_X2_KHBZ_JY_SYBZ, GetType(System.Double))
                    '=============================================================================================
                    .Add(FIELD_DC_B_RS_X2_KHBZ_JY_ZJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_X2_KHBZ_JY = table

        End Function
        'zengxianglin 2010-01-13

        'zengxianglin 2010-01-13
        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_X2_KHBZ_GL
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_X2_KHBZ_GL(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_X2_KHBZ_GL)
                With table.Columns
                    '=============================================================================================
                    .Add(FIELD_DC_B_RS_X2_KHBZ_GL_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_X2_KHBZ_GL_TDSX, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_X2_KHBZ_GL_JZZB, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_X2_KHBZ_GL_JZRS, GetType(System.Int32))
                    .Add(FIELD_DC_B_RS_X2_KHBZ_GL_TZZB, GetType(System.Double))
                    '=============================================================================================
                    .Add(FIELD_DC_B_RS_X2_KHBZ_GL_TDSXMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_X2_KHBZ_GL = table

        End Function
        'zengxianglin 2010-01-13

        'zengxianglin 2010-01-13
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_RS_X2_KHJG_JY
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_RS_X2_KHJG_JY(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_RS_X2_KHJG_JY)
                With table.Columns
                    '=============================================================================================
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_XSJB, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_XSMC, GetType(System.String))
                    '=============================================================================================
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_KHND, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_KHJD, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_KHYD, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_KSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_ZZRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_CBRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_RYDM, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_RYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_DWDM, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_DWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_DWXH, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_TDBH, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_ZGBJ, GetType(System.Int32))
                    '=============================================================================================
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_RGBS, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_RGRQ, GetType(System.DateTime))
                    '=============================================================================================
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_HTBS, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_HTLX, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_JARQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_JYYZJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_ZDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_ZLSF, GetType(System.Double))
                    '=============================================================================================
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_JSSH, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_JSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_JYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_ZTBZ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_SYRY, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_RYZJ, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_ZJMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_DLFE, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_LSFE, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_KHYJ, GetType(System.Double))
                    '=============================================================================================
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_YDZB, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_JY_YDDB, GetType(System.String))
                    '=============================================================================================
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_RS_X2_KHJG_JY = table

        End Function
        'zengxianglin 2010-01-13

        'zengxianglin 2010-01-13
        '----------------------------------------------------------------
        '创建TABLE_DC_VT_RS_X2_KHJG_GL
        '----------------------------------------------------------------
        Private Function createDataTables_DC_VT_RS_X2_KHJG_GL(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_VT_RS_X2_KHJG_GL)
                With table.Columns
                    '=============================================================================================
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_XSJB, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_XSMC, GetType(System.String))
                    '=============================================================================================
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_KHND, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_KHJD, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_KHYD, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_KSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_ZZRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_CBRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_RYDM, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_RYMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_DWDM, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_DWMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_DWXH, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_TDBH, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_ZGBJ, GetType(System.Int32))
                    '=============================================================================================
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_QRSH, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_RGBS, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_RGRQ, GetType(System.DateTime))
                    '=============================================================================================
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_HTBH, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_HTBS, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_HTLX, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_HTRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_JARQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_TJRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_YZMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_KHMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_WYDZ, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_JYJG, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_JYMJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_JYYZJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_JFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_YFDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_DLFZK, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_ZDLF, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_ZLSF, GetType(System.Double))
                    '=============================================================================================
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_JSSH, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_JSRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_JYRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_SSFZ, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_ZTBZ, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_SYRY, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_RYZJ, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_ZJMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_FPBL, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_DLFE, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_LSFE, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_KHYJ, GetType(System.Double))
                    '=============================================================================================
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_TDYJ, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_TDLX, GetType(System.Int32))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_TDLXMC, GetType(System.String))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_TDRS, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_YDZB, GetType(System.Double))
                    .Add(FIELD_DC_VT_RS_X2_KHJG_GL_YDDB, GetType(System.String))
                    '=============================================================================================
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_VT_RS_X2_KHJG_GL = table

        End Function
        'zengxianglin 2010-01-13










        'LJ 2010-1-16
        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_SY(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_JTBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_QJZX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_QJZD, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_ZXED, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_ZDED, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_SXRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_SY_SXSJ, GetType(System.DateTime))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_SY = table

        End Function
        'LJ 2010-1-16

        'LJ 2010-1-16
        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_ZG(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_JTBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_QJZX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_QJZD, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_ZXRWBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_ZDRWBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_SXRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_SXSJ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZG_ZJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_ZG = table

        End Function
        'LJ 2010-1-16

        'LJ 2010-1-16
        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_XG(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_JTBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_QJZX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_QJZD, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_SXRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_XG_SXSJ, GetType(System.DateTime))

                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_XG = table

        End Function
        'LJ 2010-1-16

        'LJ 2010-1-16
        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_ZT(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_JTBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_SXRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_SXSJ, GetType(System.DateTime))

                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZT_ZJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_ZT = table

        End Function
        'LJ 2010-1-16

        'LJ 2010-1-16
        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_ZGZJ(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZJ_ZJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_ZGZJ = table

        End Function
        'LJ 2010-1-16

        'LJ 2010-1-16
        '----------------------------------------------------------------
        '创建TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_ZGZB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_JTBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_QJZX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_QJZD, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_ZXBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_ZDBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_SXRQ, GetType(System.DateTime))
                    .Add(FIELD_DC_B_RS_YONGJINJITIBIAOZHUN_X2_GY_ZGZB_SXSJ, GetType(System.DateTime))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_YongjinJitiBiaozhun_X2_GY_ZGZB = table

        End Function
        'LJ 2010-1-16











        'zengxianglin 2010-05-04
        '----------------------------------------------------------------
        '创建[TABLE_DC_B_RS_YJBZ_X3_SY]
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_YJBZ_X3_SY(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YJBZ_X3_SY)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YJBZ_X3_SY_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_SY_JTBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_SY_QJZX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_SY_QJZD, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_SY_ZXED, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_SY_ZDED, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_YJBZ_X3_SY = table

        End Function
        'zengxianglin 2010-05-04

        'zengxianglin 2010-05-04
        '----------------------------------------------------------------
        '创建[TABLE_DC_B_RS_YJBZ_X3_GY_ZG]
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_YJBZ_X3_GY_ZG(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YJBZ_X3_GY_ZG)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_ZG_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_ZG_JTBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_ZG_QJZX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_ZG_QJZD, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZXED, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZDED, GetType(System.Double))

                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_ZG_ZJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_YJBZ_X3_GY_ZG = table

        End Function
        'zengxianglin 2010-05-04

        'zengxianglin 2010-05-04
        '----------------------------------------------------------------
        '创建[TABLE_DC_B_RS_YJBZ_X3_GY_XG]
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_YJBZ_X3_GY_XG(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YJBZ_X3_GY_XG)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_XG_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_XG_JTBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_XG_QJZX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_XG_QJZD, GetType(System.Double))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_YJBZ_X3_GY_XG = table

        End Function
        'zengxianglin 2010-05-04

        'zengxianglin 2010-05-04
        '----------------------------------------------------------------
        '创建[TABLE_DC_B_RS_YJBZ_X3_GY_ZT]
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_YJBZ_X3_GY_ZT(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YJBZ_X3_GY_ZT)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_ZT_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_ZT_JTBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_ZT_QJZX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_ZT_QJZD, GetType(System.Double))

                    .Add(FIELD_DC_B_RS_YJBZ_X3_GY_ZT_ZJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_YJBZ_X3_GY_ZT = table

        End Function
        'zengxianglin 2010-05-04










        'zengxianglin 2011-01-10
        '----------------------------------------------------------------
        '创建[TABLE_DC_B_RS_YJBZ_X4_SY]
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_YJBZ_X4_SY(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YJBZ_X4_SY)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YJBZ_X4_SY_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_SY_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_SY_JTBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_SY_QJZX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_SY_QJZD, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_SY_ZXED, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_SY_ZDED, GetType(System.Double))

                    .Add(FIELD_DC_B_RS_YJBZ_X4_SY_ZJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_YJBZ_X4_SY = table

        End Function
        'zengxianglin 2011-01-10

        'zengxianglin 2011-01-10
        '----------------------------------------------------------------
        '创建[TABLE_DC_B_RS_YJBZ_X4_GY_ZG]
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_YJBZ_X4_GY_ZG(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YJBZ_X4_GY_ZG)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_ZG_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_ZG_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_ZG_JTBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_ZG_QJZX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_ZG_QJZD, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_ZG_ZXED, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_ZG_ZDED, GetType(System.Double))

                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_ZG_ZJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_YJBZ_X4_GY_ZG = table

        End Function
        'zengxianglin 2011-01-10

        'zengxianglin 2011-01-10
        '----------------------------------------------------------------
        '创建[TABLE_DC_B_RS_YJBZ_X4_GY_XG]
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_YJBZ_X4_GY_XG(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YJBZ_X4_GY_XG)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_XG_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_XG_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_XG_JTBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_XG_QJZX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_XG_QJZD, GetType(System.Double))

                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_XG_ZJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_YJBZ_X4_GY_XG = table

        End Function
        'zengxianglin 2011-01-10

        'zengxianglin 2011-01-10
        '----------------------------------------------------------------
        '创建[TABLE_DC_B_RS_YJBZ_X4_GY_ZT]
        '----------------------------------------------------------------
        Private Function createDataTables_DC_B_RS_YJBZ_X4_GY_ZT(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_DC_B_RS_YJBZ_X4_GY_ZT)
                With table.Columns
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_ZT_WYBS, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_ZT_ZJDM, GetType(System.String))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_ZT_JTBL, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_ZT_QJZX, GetType(System.Double))
                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_ZT_QJZD, GetType(System.Double))

                    .Add(FIELD_DC_B_RS_YJBZ_X4_GY_ZT_ZJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_DC_B_RS_YJBZ_X4_GY_ZT = table

        End Function
        'zengxianglin 2011-01-10

    End Class 'estateRenshiXingyeData

End Namespace 'Josco.JsKernal.Common.Data
