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
    ' 类名    ：estateRenshiGeneralData
    '
    ' 功能描述：
    '     定义与通用人事管理相关表的数据访问格式
    '----------------------------------------------------------------
    <System.ComponentModel.DesignerCategory("RENSHI"), SerializableAttribute()> Public Class estateRenshiGeneralData
        Inherits System.Data.DataSet

        '“人事_B_技术职称”表信息定义
        '表名称
        Public Const TABLE_RS_B_JISHUZHICHENG As String = "人事_B_技术职称"
        '字段序列
        Public Const FIELD_RS_B_JISHUZHICHENG_ZCDM As String = "职称代码"
        Public Const FIELD_RS_B_JISHUZHICHENG_ZCMC As String = "职称名称"
        '显示字段序列
        '约束错误信息

        '“人事_B_学历划分”表信息定义
        '表名称
        Public Const TABLE_RS_B_XUELIHUAFEN As String = "人事_B_学历划分"
        '字段序列
        Public Const FIELD_RS_B_XUELIHUAFEN_XLDM As String = "学历代码"
        Public Const FIELD_RS_B_XUELIHUAFEN_XLMC As String = "学历名称"
        '显示字段序列
        '约束错误信息

        '“人事_B_学位划分”表信息定义
        '表名称
        Public Const TABLE_RS_B_XUEWEIHUAFEN As String = "人事_B_学位划分"
        '字段序列
        Public Const FIELD_RS_B_XUEWEIHUAFEN_XWDM As String = "学位代码"
        Public Const FIELD_RS_B_XUEWEIHUAFEN_XWMC As String = "学位名称"
        '显示字段序列
        '约束错误信息

        '“人事_B_政治面貌”表信息定义
        '表名称
        Public Const TABLE_RS_B_ZHENGZHIMIANMAO As String = "人事_B_政治面貌"
        '字段序列
        Public Const FIELD_RS_B_ZHENGZHIMIANMAO_MMDM As String = "面貌代码"
        Public Const FIELD_RS_B_ZHENGZHIMIANMAO_MMMC As String = "面貌名称"
        '显示字段序列
        '约束错误信息

        '“人事_B_执业资格”表信息定义
        '表名称
        Public Const TABLE_RS_B_ZHIYEZIGE As String = "人事_B_执业资格"
        '字段序列
        Public Const FIELD_RS_B_ZHIYEZIGE_ZGDM As String = "资格代码"
        Public Const FIELD_RS_B_ZHIYEZIGE_ZGMC As String = "资格名称"
        '显示字段序列
        '约束错误信息

        '“人事_B_变动原因”表信息定义
        '表名称
        Public Const TABLE_RS_B_BIANDONGYUANYIN As String = "人事_B_变动原因"
        '字段序列
        Public Const FIELD_RS_B_BIANDONGYUANYIN_YYDM As String = "原因代码"
        Public Const FIELD_RS_B_BIANDONGYUANYIN_YYMC As String = "原因名称"
        '显示字段序列
        '约束错误信息

        '“人事_B_职工属性”表信息定义
        '表名称
        Public Const TABLE_RS_B_ZHIGONGSHUXING As String = "人事_B_职工属性"
        '字段序列
        Public Const FIELD_RS_B_ZHIGONGSHUXING_SXDM As String = "属性代码"
        Public Const FIELD_RS_B_ZHIGONGSHUXING_SXMC As String = "属性名称"
        '显示字段序列
        '约束错误信息






        '“人事_B_人事卡片”表信息定义
        '表名称
        Public Const TABLE_RS_B_RENSHIKAPIAN As String = "人事_B_人事卡片"
        '字段序列
        Public Const FIELD_RS_B_RENSHIKAPIAN_WYBS As String = "唯一标识"
        Public Const FIELD_RS_B_RENSHIKAPIAN_RYDM As String = "人员代码"
        Public Const FIELD_RS_B_RENSHIKAPIAN_XM As String = "姓名"
        Public Const FIELD_RS_B_RENSHIKAPIAN_BMDM As String = "部门"
        Public Const FIELD_RS_B_RENSHIKAPIAN_XB As String = "性别"
        Public Const FIELD_RS_B_RENSHIKAPIAN_CSRQ As String = "出生日期"
        Public Const FIELD_RS_B_RENSHIKAPIAN_RBDWSJ As String = "入本单位时间"
        Public Const FIELD_RS_B_RENSHIKAPIAN_YWXM As String = "英文姓名"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SJHM As String = "手机号码"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZZDH As String = "住宅电话"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFZH As String = "身份证号"
        Public Const FIELD_RS_B_RENSHIKAPIAN_MZ As String = "民族"
        Public Const FIELD_RS_B_RENSHIKAPIAN_JG As String = "籍贯"
        Public Const FIELD_RS_B_RENSHIKAPIAN_HJDZ As String = "户籍地址"
        Public Const FIELD_RS_B_RENSHIKAPIAN_XZDZ As String = "现住地址"
        Public Const FIELD_RS_B_RENSHIKAPIAN_YJDZ As String = "邮寄地址"
        Public Const FIELD_RS_B_RENSHIKAPIAN_HKZT As String = "户口状态"
        Public Const FIELD_RS_B_RENSHIKAPIAN_RYXPWZ As String = "人员相片位置"
        Public Const FIELD_RS_B_RENSHIKAPIAN_HYZK As String = "婚姻状况"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SYZK As String = "生育情况"
        Public Const FIELD_RS_B_RENSHIKAPIAN_XXLX As String = "学习类型"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZGXL As String = "最高学历"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZGXW As String = "最高学位"
        Public Const FIELD_RS_B_RENSHIKAPIAN_BYYX As String = "毕业院校"
        Public Const FIELD_RS_B_RENSHIKAPIAN_BYZY As String = "毕业专业"
        Public Const FIELD_RS_B_RENSHIKAPIAN_BYSJ As String = "毕业时间"
        Public Const FIELD_RS_B_RENSHIKAPIAN_CJGZSJ As String = "参加工作时间"
        'zengxianglin 2009-01-12
        Public Const FIELD_RS_B_RENSHIKAPIAN_TXSJ As String = "退休时间"
        'zengxianglin 2009-01-12
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZCQDSJ As String = "职称取得时间"
        'zengxianglin 2009-01-07
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ As String = "资格取得时间"
        'zengxianglin 2009-01-07
        Public Const FIELD_RS_B_RENSHIKAPIAN_JSZC As String = "技术职称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZYZG As String = "执业资格"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZZMM As String = "政治面貌"
        Public Const FIELD_RS_B_RENSHIKAPIAN_RDSJ As String = "入党时间"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZZGX As String = "组织关系"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFGHCY As String = "是否工会成员"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFSGGB As String = "是否市管干部"
        Public Const FIELD_RS_B_RENSHIKAPIAN_RYQYTX As String = "人员区域特性"
        Public Const FIELD_RS_B_RENSHIKAPIAN_JZQK As String = "居住情况"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZJZG As String = "中介资格"
        Public Const FIELD_RS_B_RENSHIKAPIAN_BRSDSZ As String = "本人是独生子"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFLDSZ As String = "是否领独生证"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFJZGB As String = "是否军转干部"
        Public Const FIELD_RS_B_RENSHIKAPIAN_GRFYKS As String = "个人服役开始"
        Public Const FIELD_RS_B_RENSHIKAPIAN_GRFYJS As String = "个人服役结束"
        Public Const FIELD_RS_B_RENSHIKAPIAN_GRFYSM As String = "个人服役说明"
        Public Const FIELD_RS_B_RENSHIKAPIAN_GRFYZT As String = "个人服役状态"
        Public Const FIELD_RS_B_RENSHIKAPIAN_CYFYSM As String = "成员服役说明"
        Public Const FIELD_RS_B_RENSHIKAPIAN_CYFYZT As String = "成员服役状态"
        Public Const FIELD_RS_B_RENSHIKAPIAN_BZXX As String = "备注信息"
        '显示字段序列
        Public Const FIELD_RS_B_RENSHIKAPIAN_BMMC As String = "部门名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_NN As String = "年龄"
        Public Const FIELD_RS_B_RENSHIKAPIAN_HKZTMC As String = "户口状态名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_HYZKMC As String = "婚姻状况名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SYZKMC As String = "生育情况名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZGXLMC As String = "最高学历名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZGXWMC As String = "最高学位名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_JSZCMC As String = "技术职称名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZYZGMC As String = "执业资格名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZZMMMC As String = "政治面貌名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFGHCYMC As String = "是否工会成员名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFSGGBMC As String = "是否市管干部名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_RYQYTXMC As String = "人员区域特性名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_JZQKMC As String = "居住情况名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_BRSDSZMC As String = "本人是独生子名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFLDSZMC As String = "是否领独生证名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFJZGBMC As String = "是否军转干部名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_CYFYZTMC As String = "成员服役状态名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_GRFYZTMC As String = "个人服役状态名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_DRZW As String = "担任职务"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZJDM As String = "职级代码"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZJMC As String = "职级名称"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFZZ As String = "是否在职"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZZSJ As String = "转正时间"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZZZW As String = "转正职位"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZNSL As String = "子女数量"
        Public Const FIELD_RS_B_RENSHIKAPIAN_LZYY As String = "离职原因"
        '约束错误信息

        '“人事_B_家庭成员”表信息定义
        '表名称
        Public Const TABLE_RS_B_JIATINGCHENGYUAN As String = "人事_B_家庭成员"
        '字段序列
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_WYBS As String = "唯一标识"
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_RYDM As String = "人员代码"
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_CYXM As String = "成员姓名"
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_XYGX As String = "血缘关系"
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_CSNY As String = "出生年月"
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_FWDW As String = "服务单位"
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_DRZW As String = "担任职务"
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_XJDZ As String = "现居地址"
        '显示字段序列
        '约束错误信息

        '“人事_B_学习经历”表信息定义
        '表名称
        Public Const TABLE_RS_B_XUEXIJINGLI As String = "人事_B_学习经历"
        '字段序列
        Public Const FIELD_RS_B_XUEXIJINGLI_WYBS As String = "唯一标识"
        Public Const FIELD_RS_B_XUEXIJINGLI_RYDM As String = "人员代码"
        Public Const FIELD_RS_B_XUEXIJINGLI_KSNY As String = "开始年月"
        Public Const FIELD_RS_B_XUEXIJINGLI_ZZNY As String = "终止年月"
        Public Const FIELD_RS_B_XUEXIJINGLI_XXLX As String = "学习类型"
        Public Const FIELD_RS_B_XUEXIJINGLI_XXYX As String = "学习院校"
        Public Const FIELD_RS_B_XUEXIJINGLI_XXZY As String = "学习专业"
        Public Const FIELD_RS_B_XUEXIJINGLI_XXJG As String = "学习结果"
        Public Const FIELD_RS_B_XUEXIJINGLI_BZXX As String = "备注信息"
        '显示字段序列
        '约束错误信息

        '“人事_B_工作经历”表信息定义
        '表名称
        Public Const TABLE_RS_B_GONGZUOJINGLI As String = "人事_B_工作经历"
        '字段序列
        Public Const FIELD_RS_B_GONGZUOJINGLI_WYBS As String = "唯一标识"
        Public Const FIELD_RS_B_GONGZUOJINGLI_RYDM As String = "人员代码"
        Public Const FIELD_RS_B_GONGZUOJINGLI_KSNY As String = "开始年月"
        Public Const FIELD_RS_B_GONGZUOJINGLI_ZZNY As String = "终止年月"
        Public Const FIELD_RS_B_GONGZUOJINGLI_FWDW As String = "服务单位"
        Public Const FIELD_RS_B_GONGZUOJINGLI_DRZW As String = "担任职务"
        Public Const FIELD_RS_B_GONGZUOJINGLI_BZXX As String = "备注信息"
        '显示字段序列
        '约束错误信息

        '“人事_B_培训记录”表信息定义
        '表名称
        Public Const TABLE_RS_B_PEIXUNJILU As String = "人事_B_培训记录"
        '字段序列
        Public Const FIELD_RS_B_PEIXUNJILU_WYBS As String = "唯一标识"
        Public Const FIELD_RS_B_PEIXUNJILU_RYDM As String = "人员代码"
        Public Const FIELD_RS_B_PEIXUNJILU_PXMC As String = "培训名称"
        Public Const FIELD_RS_B_PEIXUNJILU_KSSJ As String = "开始时间"
        Public Const FIELD_RS_B_PEIXUNJILU_ZZSJ As String = "终止时间"
        Public Const FIELD_RS_B_PEIXUNJILU_NBPX As String = "内部培训"
        Public Const FIELD_RS_B_PEIXUNJILU_PXXG As String = "培训效果"
        Public Const FIELD_RS_B_PEIXUNJILU_BZXX As String = "备注信息"
        Public Const FIELD_RS_B_PEIXUNJILU_PXKS As String = "培训课时"
        '显示字段序列
        Public Const FIELD_RS_B_PEIXUNJILU_RYMC As String = "人员真名"
        Public Const FIELD_RS_B_PEIXUNJILU_NBPXMC As String = "内部培训名称"
        '约束错误信息

        '“人事_B_人事异动”表信息定义
        '表名称
        Public Const TABLE_RS_B_RENSHIYIDONG As String = "人事_B_人事异动"
        '字段序列
        Public Const FIELD_RS_B_RENSHIYIDONG_WYBS As String = "唯一标识"
        Public Const FIELD_RS_B_RENSHIYIDONG_RYDM As String = "人员代码"
        Public Const FIELD_RS_B_RENSHIYIDONG_KSSJ As String = "开始时间"
        Public Const FIELD_RS_B_RENSHIYIDONG_ZZSJ As String = "终止时间"
        Public Const FIELD_RS_B_RENSHIYIDONG_GLBS As String = "关联标识"
        Public Const FIELD_RS_B_RENSHIYIDONG_BDYY As String = "变动原因"
        Public Const FIELD_RS_B_RENSHIYIDONG_RZDW As String = "任职单位"
        Public Const FIELD_RS_B_RENSHIYIDONG_RZJB As String = "任职级别"
        Public Const FIELD_RS_B_RENSHIYIDONG_JBBZ As String = "级别标志"
        Public Const FIELD_RS_B_RENSHIYIDONG_FGGZ As String = "分管工作"
        Public Const FIELD_RS_B_RENSHIYIDONG_ZGSX As String = "职工属性"
        Public Const FIELD_RS_B_RENSHIYIDONG_GWSX As String = "岗位属性"
        Public Const FIELD_RS_B_RENSHIYIDONG_YRDW As String = "原任单位"
        Public Const FIELD_RS_B_RENSHIYIDONG_YRJB As String = "原任级别"
        Public Const FIELD_RS_B_RENSHIYIDONG_BZXX As String = "备注信息"
        'zengxianglin 2008-10-14
        Public Const FIELD_RS_B_RENSHIYIDONG_SSFZ As String = "所属分组"
        Public Const FIELD_RS_B_RENSHIYIDONG_YSFZ As String = "原属分组"
        'zengxianglin 2008-10-14
        'zengxianglin 2010-01-06
        Public Const FIELD_RS_B_RENSHIYIDONG_YGSX As String = "原岗属性"
        Public Const FIELD_RS_B_RENSHIYIDONG_YZSX As String = "原职属性"
        Public Const FIELD_RS_B_RENSHIYIDONG_BCZB As String = "本次占编"
        Public Const FIELD_RS_B_RENSHIYIDONG_SCZB As String = "上次占编"
        Public Const FIELD_RS_B_RENSHIYIDONG_XSTD As String = "现属团队"
        Public Const FIELD_RS_B_RENSHIYIDONG_YSTD As String = "原属团队"
        'zengxianglin 2010-01-06
        '显示字段序列
        Public Const FIELD_RS_B_RENSHIYIDONG_RYMC As String = "人员真名"
        Public Const FIELD_RS_B_RENSHIYIDONG_BDYYMC As String = "变动原因名称"
        Public Const FIELD_RS_B_RENSHIYIDONG_RZDWMC As String = "任职单位名称"
        Public Const FIELD_RS_B_RENSHIYIDONG_ZGSXMC As String = "职工属性名称"
        Public Const FIELD_RS_B_RENSHIYIDONG_GWSXMC As String = "岗位属性名称"
        Public Const FIELD_RS_B_RENSHIYIDONG_YRDWMC As String = "原任单位名称"
        Public Const FIELD_RS_B_RENSHIYIDONG_JBBZMC As String = "级别标志名称"
        'zengxianglin 2010-01-06
        Public Const FIELD_RS_B_RENSHIYIDONG_YGSXMC As String = "原岗属性名称"
        Public Const FIELD_RS_B_RENSHIYIDONG_YZSXMC As String = "原职属性名称"
        'zengxianglin 2010-01-06
        '约束错误信息

        '“人事_B_劳动合同”表信息定义
        '表名称
        Public Const TABLE_RS_B_LAODONGHETONG As String = "人事_B_劳动合同"
        '字段序列
        Public Const FIELD_RS_B_LAODONGHETONG_WYBS As String = "唯一标识"
        Public Const FIELD_RS_B_LAODONGHETONG_RYDM As String = "人员代码"
        Public Const FIELD_RS_B_LAODONGHETONG_KSSJ As String = "开始时间"
        Public Const FIELD_RS_B_LAODONGHETONG_JSSJ As String = "结束时间"
        'zengxianglin 2009-01-12
        Public Const FIELD_RS_B_LAODONGHETONG_SYKS As String = "试用开始"
        Public Const FIELD_RS_B_LAODONGHETONG_SYJS As String = "试用结束"
        'zengxianglin 2009-01-12
        Public Const FIELD_RS_B_LAODONGHETONG_HTLX As String = "合同类型"
        Public Const FIELD_RS_B_LAODONGHETONG_SFXY As String = "是否续约"
        Public Const FIELD_RS_B_LAODONGHETONG_HTWJ As String = "合同文件"
        '显示字段序列
        Public Const FIELD_RS_B_LAODONGHETONG_RYMC As String = "人员真名"
        Public Const FIELD_RS_B_LAODONGHETONG_HTLXMC As String = "合同类型名称"
        Public Const FIELD_RS_B_LAODONGHETONG_SFXYMC As String = "是否续约名称"
        Public Const FIELD_RS_B_LAODONGHETONG_HTWJMC As String = "合同文件名称"
        '约束错误信息
        '目录设定
        Public Const FILEDIR_RS_RSKP_LDHT As String = "RS\RSKP\LDHT"  '合同文件存放基准目录

        'zengxianglin 2009-01-07
        '“人事_VT_人员增减异动表”虚拟表信息定义
        '表名称
        Public Const TABLE_RS_VT_RYZJYDB As String = "人事_VT_人员增减异动表"
        '字段序列
        Public Const FIELD_RS_VT_RYZJYDB_TJNY As String = "统计年月"
        Public Const FIELD_RS_VT_RYZJYDB_JLXH As String = "记录序号"
        '***************************************************************************
        Public Const FIELD_RS_VT_RYZJYDB_RZXM As String = "入职姓名"
        Public Const FIELD_RS_VT_RYZJYDB_RZRQ As String = "入职日期"
        Public Const FIELD_RS_VT_RYZJYDB_RZBM As String = "入职部门"
        Public Const FIELD_RS_VT_RYZJYDB_RZZJ As String = "入职职级"
        '***************************************************************************
        Public Const FIELD_RS_VT_RYZJYDB_LZXM As String = "离职姓名"
        Public Const FIELD_RS_VT_RYZJYDB_LZJCHT As String = "离职解除合同"
        Public Const FIELD_RS_VT_RYZJYDB_LZQMZZ As String = "离职期满终止"
        Public Const FIELD_RS_VT_RYZJYDB_LZDC As String = "离职调出"
        Public Const FIELD_RS_VT_RYZJYDB_LZTX As String = "离职退休"
        Public Const FIELD_RS_VT_RYZJYDB_LZSW As String = "离职死亡"
        Public Const FIELD_RS_VT_RYZJYDB_LZQT As String = "离职其他"
        Public Const FIELD_RS_VT_RYZJYDB_LZRQ As String = "离职日期"
        Public Const FIELD_RS_VT_RYZJYDB_LZBM As String = "离职部门"
        '***************************************************************************
        Public Const FIELD_RS_VT_RYZJYDB_SXXM As String = "实习姓名"
        Public Const FIELD_RS_VT_RYZJYDB_SXYX As String = "实习院校"
        Public Const FIELD_RS_VT_RYZJYDB_SXRQ As String = "实习日期"
        Public Const FIELD_RS_VT_RYZJYDB_SXBM As String = "实习部门"
        '***************************************************************************
        Public Const FIELD_RS_VT_RYZJYDB_YDXM As String = "异动姓名"
        Public Const FIELD_RS_VT_RYZJYDB_YDRQ As String = "异动日期"
        Public Const FIELD_RS_VT_RYZJYDB_YDXBM As String = "异动新部门"
        Public Const FIELD_RS_VT_RYZJYDB_YDXZJ As String = "异动新职级"
        Public Const FIELD_RS_VT_RYZJYDB_YDYBM As String = "异动原部门"
        Public Const FIELD_RS_VT_RYZJYDB_YDYZJ As String = "异动原职级"
        Public Const FIELD_RS_VT_RYZJYDB_YDZZ As String = "异动转正"
        Public Const FIELD_RS_VT_RYZJYDB_YDCQCJ As String = "异动长期产假"
        '***************************************************************************
        Public Const FIELD_RS_VT_RYZJYDB_YDSBZY As String = "异动社保增员"
        Public Const FIELD_RS_VT_RYZJYDB_YDSBJY As String = "异动社保减员"
        Public Const FIELD_RS_VT_RYZJYDB_YDKJGJJ As String = "异动开缴公积金"
        Public Const FIELD_RS_VT_RYZJYDB_YDTJGJJ As String = "异动停缴公积金"
        Public Const FIELD_RS_VT_RYZJYDB_YDPXQK As String = "异动培训情况"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-01-07

        'zengxianglin 2009-01-08
        '“人事_VT_人力资源信息汇总表”虚拟表信息定义
        '表名称
        Public Const TABLE_RS_VT_RLZYXXHZB As String = "人事_VT_人力资源信息汇总表"
        '字段序列
        Public Const FIELD_RS_VT_RLZYXXHZB_DWDM As String = "单位代码"
        Public Const FIELD_RS_VT_RLZYXXHZB_DWMC As String = "单位名称"
        Public Const FIELD_RS_VT_RLZYXXHZB_DWXH As String = "单位序号"
        '***************************************************************************
        Public Const FIELD_RS_VT_RLZYXXHZB_RZRS As String = "入职人数"
        Public Const FIELD_RS_VT_RLZYXXHZB_DRRS As String = "调入人数"
        Public Const FIELD_RS_VT_RLZYXXHZB_DCRS As String = "调出人数"
        Public Const FIELD_RS_VT_RLZYXXHZB_LZRS As String = "离职人数"
        '***************************************************************************
        Public Const FIELD_RS_VT_RLZYXXHZB_PJRSY As String = "平均人数月"
        Public Const FIELD_RS_VT_RLZYXXHZB_PJRSJ As String = "平均人数季"
        Public Const FIELD_RS_VT_RLZYXXHZB_PJRSN As String = "平均人数年"
        '***************************************************************************
        Public Const FIELD_RS_VT_RLZYXXHZB_DWCSY As String = "单位创收月"
        Public Const FIELD_RS_VT_RLZYXXHZB_DWCSJ As String = "单位创收季"
        Public Const FIELD_RS_VT_RLZYXXHZB_DWCSN As String = "单位创收年"
        '***************************************************************************
        Public Const FIELD_RS_VT_RLZYXXHZB_PJCSY As String = "平均创收月"
        Public Const FIELD_RS_VT_RLZYXXHZB_PJCSJ As String = "平均创收季"
        Public Const FIELD_RS_VT_RLZYXXHZB_PJCSN As String = "平均创收年"
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-01-08

        'zengxianglin 2009-01-12
        '“人事_VT_劳动合同届满期限表”虚拟表信息定义
        '表名称
        Public Const TABLE_RS_VT_LDHTJMQXB As String = "人事_VT_劳动合同届满期限表"
        '字段序列
        Public Const FIELD_RS_VT_LDHTJMQXB_JLXH As String = "记录序号"
        Public Const FIELD_RS_VT_LDHTJMQXB_TJNY As String = "统计年月"
        '***************************************************************************
        Public Const FIELD_RS_VT_LDHTJMQXB_SLBRYDM As String = "售楼部人员代码"
        Public Const FIELD_RS_VT_LDHTJMQXB_SLBRYMC As String = "售楼部人员名称"
        Public Const FIELD_RS_VT_LDHTJMQXB_SLBHTQX As String = "售楼部合同期限"
        Public Const FIELD_RS_VT_LDHTJMQXB_SLBXYQK As String = "售楼部续约情况"
        Public Const FIELD_RS_VT_LDHTJMQXB_SLBRZSJ As String = "售楼部入职时间"
        '***************************************************************************
        Public Const FIELD_RS_VT_LDHTJMQXB_FHRYDM As String = "分行人员代码"
        Public Const FIELD_RS_VT_LDHTJMQXB_FHRYMC As String = "分行人员名称"
        Public Const FIELD_RS_VT_LDHTJMQXB_FHHTQX As String = "分行合同期限"
        Public Const FIELD_RS_VT_LDHTJMQXB_FHXYQK As String = "分行续约情况"
        Public Const FIELD_RS_VT_LDHTJMQXB_FHRZSJ As String = "分行入职时间"
        '***************************************************************************
        Public Const FIELD_RS_VT_LDHTJMQXB_ZBRYDM As String = "总部人员代码"
        Public Const FIELD_RS_VT_LDHTJMQXB_ZBRYMC As String = "总部人员名称"
        Public Const FIELD_RS_VT_LDHTJMQXB_ZBHTQX As String = "总部合同期限"
        Public Const FIELD_RS_VT_LDHTJMQXB_ZBXYQK As String = "总部续约情况"
        Public Const FIELD_RS_VT_LDHTJMQXB_ZBRZSJ As String = "总部入职时间"
        Public Const FIELD_RS_VT_LDHTJMQXB_ZBGWQX As String = "总部岗位期限"
        '***************************************************************************
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-01-12

        'zengxianglin 2009-01-12
        '“人事_VT_劳动局季报表”虚拟表信息定义
        '表名称
        Public Const TABLE_RS_VT_LDJJBB As String = "人事_VT_劳动局季报表"
        '字段序列
        Public Const FIELD_RS_VT_LDJJBB_JLXH As String = "记录序号"
        Public Const FIELD_RS_VT_LDJJBB_TJNJ As String = "统计年季"
        '***************************************************************************
        Public Const FIELD_RS_VT_LDJJBB_ZBMC As String = "指标名称"
        Public Const FIELD_RS_VT_LDJJBB_ZBDW As String = "指标单位"
        Public Const FIELD_RS_VT_LDJJBB_ZBDM As String = "指标代码"
        '***************************************************************************
        Public Const FIELD_RS_VT_LDJJBB_BJSJ As String = "本季实际"
        Public Const FIELD_RS_VT_LDJJBB_NCZBJZ As String = "年初至本季止"
        '***************************************************************************
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-01-12

        'zengxianglin 2009-01-12
        '“人事_VT_劳动局年报表”虚拟表信息定义
        '表名称
        Public Const TABLE_RS_VT_LDJNBB As String = "人事_VT_劳动局年报表"
        '字段序列
        Public Const FIELD_RS_VT_LDJNBB_JLXH As String = "记录序号"
        Public Const FIELD_RS_VT_LDJNBB_TJND As String = "统计年度"
        '***************************************************************************
        Public Const FIELD_RS_VT_LDJNBB_ZBMC As String = "指标名称"
        Public Const FIELD_RS_VT_LDJNBB_ZBDW As String = "指标单位"
        Public Const FIELD_RS_VT_LDJNBB_ZBDM As String = "指标代码"
        '***************************************************************************
        Public Const FIELD_RS_VT_LDJNBB_BNSJ As String = "本年实际"
        '***************************************************************************
        '显示字段序列
        '约束错误信息
        'zengxianglin 2009-01-12




       



        '定义初始化表类型enum
        Public Enum enumTableType
            RS_B_JISHUZHICHENG = 1
            RS_B_XUELIHUAFEN = 2
            RS_B_XUEWEIHUAFEN = 3
            RS_B_ZHENGZHIMIANMAO = 4
            RS_B_ZHIYEZIGE = 5
            RS_B_BIANDONGYUANYIN = 6
            RS_B_ZHIGONGSHUXING = 7

            RS_B_RENSHIKAPIAN = 8
            RS_B_JIATINGCHENGYUAN = 9
            RS_B_XUEXIJINGLI = 10
            RS_B_GONGZUOJINGLI = 11
            RS_B_PEIXUNJILU = 12
            RS_B_RENSHIYIDONG = 13
            RS_B_LAODONGHETONG = 14

            'zengxianglin 2009-01-07
            RS_VT_RYZJYDB = 15
            'zengxianglin 2009-01-07
            'zengxianglin 2009-01-08
            RS_VT_RLZYXXHZB = 16
            'zengxianglin 2009-01-08
            'zengxianglin 2009-01-12
            RS_VT_LDHTJMQXB = 17
            RS_VT_LDJJBB = 18
            RS_VT_LDJNBB = 19
            'zengxianglin 2009-01-12
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.Common.Data.estateRenshiGeneralData)
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
        ' 婚姻状态列表
        Public Enum enumHunyinZhuangtai
            WeiHun = 1
            YiHun = 2
            LiYi = 4
        End Enum
        '----------------------------------------------------------------
        ' 功能描述：
        '     根据婚姻状态intCodeValue判断是否为具体状态objenumHunyinZhuangtai
        ' 输入接口：
        '     intCodeValue - 婚姻状态
        '     objenumHunyinZhuangtai - 具体婚姻状态
        ' 输出接口：
        '     True - 是
        '     False - 否
        ' 备注信息：
        '     曾祥林 2008-05-19 设计
        '----------------------------------------------------------------
        Public Shared Function isHunyinZhuangtai( _
            ByVal intCodeValue As Integer, _
            ByVal objenumHunyinZhuangtai As enumHunyinZhuangtai) As Boolean

            isHunyinZhuangtai = False
            Try
                Dim intValue As Integer = objenumHunyinZhuangtai
                If (intCodeValue And intValue) = intValue Then
                    isHunyinZhuangtai = True
                End If
            Catch ex As Exception
            End Try

        End Function
        '----------------------------------------------------------------
        ' 功能描述：
        '     根据给定状态计算状态码
        ' 输入接口：
        '     blnWeiHun - 未婚状态
        '     blnYiHun - 已婚状态
        '     blnLiYi - 离异状态
        ' 输出接口：
        '     True - 是
        '     False - 否
        ' 备注信息：
        '     曾祥林 2008-05-19 设计
        '----------------------------------------------------------------
        Public Shared Function getHunyinZhuangtai( _
            ByVal blnWeiHun As Boolean, _
            ByVal blnYiHun As Boolean, _
            ByVal blnLiYi As Boolean) As Integer

            getHunyinZhuangtai = 0
            Try
                If blnWeiHun = True Then
                    getHunyinZhuangtai += enumHunyinZhuangtai.WeiHun
                End If
                If blnYiHun = True Then
                    getHunyinZhuangtai += enumHunyinZhuangtai.YiHun
                End If
                If blnLiYi = True Then
                    getHunyinZhuangtai += enumHunyinZhuangtai.LiYi
                End If
            Catch ex As Exception
            End Try

        End Function

        ' 生育状况列表
        Public Enum enumShengyuZhuangkuang
            WeiYu = 1
            YiYu = 2
        End Enum
        '----------------------------------------------------------------
        ' 功能描述：
        '     根据生育状况intCodeValue判断是否为具体状态objenumShengyuZhuangkuang
        ' 输入接口：
        '     intCodeValue - 生育状况
        '     objenumShengyuZhuangkuang - 具体生育状况
        ' 输出接口：
        '     True - 是
        '     False - 否
        ' 备注信息：
        '     曾祥林 2008-05-19 设计
        '----------------------------------------------------------------
        Public Shared Function isShengyuZhuangkuang( _
            ByVal intCodeValue As Integer, _
            ByVal objenumShengyuZhuangkuang As enumShengyuZhuangkuang) As Boolean

            isShengyuZhuangkuang = False
            Try
                Dim intValue As Integer = objenumShengyuZhuangkuang
                If (intCodeValue And intValue) = intValue Then
                    isShengyuZhuangkuang = True
                End If
            Catch ex As Exception
            End Try

        End Function
        '----------------------------------------------------------------
        ' 功能描述：
        '     根据给定状态计算状态码
        ' 输入接口：
        '     blnWeiYu - 未育状态
        '     blnYiYu - 已育状态
        ' 输出接口：
        '     True - 是
        '     False - 否
        ' 备注信息：
        '     曾祥林 2008-05-19 设计
        '----------------------------------------------------------------
        Public Shared Function getShengyuZhuangkuang( _
            ByVal blnWeiYu As Boolean, _
            ByVal blnYiYu As Boolean) As Integer

            getShengyuZhuangkuang = 0
            Try
                If blnWeiYu = True Then
                    getShengyuZhuangkuang += enumShengyuZhuangkuang.WeiYu
                End If
                If blnYiYu = True Then
                    getShengyuZhuangkuang += enumShengyuZhuangkuang.YiYu
                End If
            Catch ex As Exception
            End Try

        End Function


        ' 居住情况列表
        Public Enum enumJuzhuQingkuang
            ZiyouWuye = 1
            ZulinWuye = 2
            ShiAnjie = 4
            BushiAnjie = 8
        End Enum
        '----------------------------------------------------------------
        ' 功能描述：
        '     根据居住情况intCodeValue判断是否为具体状态objenumJuzhuQingkuang
        ' 输入接口：
        '     intCodeValue - 居住情况
        '     objenumJuzhuQingkuang - 具体居住情况
        ' 输出接口：
        '     True - 是
        '     False - 否
        ' 备注信息：
        '     曾祥林 2008-05-19 设计
        '----------------------------------------------------------------
        Public Shared Function isJuzhuQingkuang( _
            ByVal intCodeValue As Integer, _
            ByVal objenumJuzhuQingkuang As enumJuzhuQingkuang) As Boolean

            isJuzhuQingkuang = False
            Try
                Dim intValue As Integer = objenumJuzhuQingkuang
                Select Case intCodeValue
                    Case enumJuzhuQingkuang.ZiyouWuye, enumJuzhuQingkuang.ZulinWuye
                        If (intCodeValue And intValue) = intValue Then
                            isJuzhuQingkuang = True
                        End If
                    Case Else
                        If (intCodeValue And enumJuzhuQingkuang.ZiyouWuye) = enumJuzhuQingkuang.ZiyouWuye Then
                            If (intCodeValue And intValue) = intValue Then
                                isJuzhuQingkuang = True
                            End If
                        Else
                            isJuzhuQingkuang = False
                        End If
                End Select
            Catch ex As Exception
            End Try

        End Function
        '----------------------------------------------------------------
        ' 功能描述：
        '     根据给定状态计算状态码
        ' 输入接口：
        '     blnZiyouWuye - 自有物业
        '     blnZulinWuye - 租赁物业
        '     blnShiAnjie - 是按揭
        '     blnBushiAnjie - 否按揭
        ' 输出接口：
        '     True - 是
        '     False - 否
        ' 备注信息：
        '     曾祥林 2008-05-19 设计
        '----------------------------------------------------------------
        Public Shared Function getJuzhuQingkuang( _
            ByVal blnZiyouWuye As Boolean, _
            ByVal blnZulinWuye As Boolean, _
            ByVal blnShiAnjie As Boolean, _
            ByVal blnBushiAnjie As Boolean) As Integer

            getJuzhuQingkuang = 0
            Try
                If blnZiyouWuye = True Then
                    getJuzhuQingkuang += enumJuzhuQingkuang.ZiyouWuye
                End If
                If blnZulinWuye = True Then
                    getJuzhuQingkuang += enumJuzhuQingkuang.ZulinWuye
                End If
                If blnShiAnjie = True Then
                    getJuzhuQingkuang += enumJuzhuQingkuang.ShiAnjie
                End If
                If blnBushiAnjie = True Then
                    getJuzhuQingkuang += enumJuzhuQingkuang.BushiAnjie
                End If
            Catch ex As Exception
            End Try

        End Function

        ' 成员服役状态列表
        Public Enum enumChengyuanFuyuZhuangtai
            KongBai = 0
            XianYu = 1
            ZhuanYe = 2
            FuYuan = 3
        End Enum
        '----------------------------------------------------------------
        ' 功能描述：
        '     根据成员服役状态intCodeValue判断是否为具体状态objenumChengyuanFuyuZhuangtai
        ' 输入接口：
        '     intCodeValue - 成员服役状态
        '     objenumChengyuanFuyuZhuangtai - 具体成员服役状态
        ' 输出接口：
        '     True - 是
        '     False - 否
        ' 备注信息：
        '     曾祥林 2008-05-19 设计
        '----------------------------------------------------------------
        Public Shared Function isChengyuanFuyuZhuangtai( _
            ByVal intCodeValue As Integer, _
            ByVal objenumChengyuanFuyuZhuangtai As enumChengyuanFuyuZhuangtai) As Boolean

            isChengyuanFuyuZhuangtai = False
            Try
                Dim intValue As Integer = objenumChengyuanFuyuZhuangtai
                If intValue = intCodeValue Then
                    isChengyuanFuyuZhuangtai = True
                End If
            Catch ex As Exception
            End Try

        End Function
        '----------------------------------------------------------------
        ' 功能描述：
        '     根据给定状态计算状态码
        ' 输入接口：
        '     strValue - 选定值
        ' 输出接口：
        '     True - 是
        '     False - 否
        ' 备注信息：
        '     曾祥林 2008-05-19 设计
        '----------------------------------------------------------------
        Public Shared Function getChengyuanFuyuZhuangtai(ByVal strValue As String) As Integer

            getChengyuanFuyuZhuangtai = 0
            Try
                Select Case strValue
                    Case "空白"
                        getChengyuanFuyuZhuangtai = enumChengyuanFuyuZhuangtai.KongBai
                    Case "现役"
                        getChengyuanFuyuZhuangtai = enumChengyuanFuyuZhuangtai.XianYu
                    Case "转业"
                        getChengyuanFuyuZhuangtai = enumChengyuanFuyuZhuangtai.ZhuanYe
                    Case "复员"
                        getChengyuanFuyuZhuangtai = enumChengyuanFuyuZhuangtai.FuYuan
                    Case Else
                End Select
            Catch ex As Exception
            End Try

        End Function

        ' 人员区域特性列表
        Public Enum enumRenyuanQuyuTexing
            GuoNei = 0
            GuiQiao = 1
            XiangGang = 2
            AoMen = 3
            TaiWan = 4
            WaiJi = 5
        End Enum
        '----------------------------------------------------------------
        ' 功能描述：
        '     根据人员区域特性intCodeValue判断是否为具体状态objenumRenyuanQuyuTexing
        ' 输入接口：
        '     intCodeValue - 人员区域特性
        '     objenumRenyuanQuyuTexing - 具体人员区域特性
        ' 输出接口：
        '     True - 是
        '     False - 否
        ' 备注信息：
        '     曾祥林 2008-05-19 设计
        '----------------------------------------------------------------
        Public Shared Function isRenyuanQuyuTexing( _
            ByVal intCodeValue As Integer, _
            ByVal objenumRenyuanQuyuTexing As enumRenyuanQuyuTexing) As Boolean

            isRenyuanQuyuTexing = False
            Try
                Dim intValue As Integer = objenumRenyuanQuyuTexing
                If intValue = intCodeValue Then
                    isRenyuanQuyuTexing = True
                End If
            Catch ex As Exception
            End Try

        End Function
        '----------------------------------------------------------------
        ' 功能描述：
        '     根据给定状态计算状态码
        ' 输入接口：
        '     strValue - 选定值
        ' 输出接口：
        '     True - 是
        '     False - 否
        ' 备注信息：
        '     曾祥林 2008-05-19 设计
        '----------------------------------------------------------------
        Public Shared Function getRenyuanQuyuTexing(ByVal strValue As String) As Integer

            getRenyuanQuyuTexing = 0
            Try
                Select Case strValue
                    Case "国内"
                        getRenyuanQuyuTexing = enumRenyuanQuyuTexing.GuoNei
                    Case "归侨"
                        getRenyuanQuyuTexing = enumRenyuanQuyuTexing.GuiQiao
                    Case "香港"
                        getRenyuanQuyuTexing = enumRenyuanQuyuTexing.XiangGang
                    Case "澳门"
                        getRenyuanQuyuTexing = enumRenyuanQuyuTexing.AoMen
                    Case "台湾"
                        getRenyuanQuyuTexing = enumRenyuanQuyuTexing.TaiWan
                    Case "外籍人员"
                        getRenyuanQuyuTexing = enumRenyuanQuyuTexing.WaiJi
                    Case Else
                End Select
            Catch ex As Exception
            End Try

        End Function

        ' 人员级别标志列表
        Public Enum enumRenyuanJibieBiaozhi
            FeiGuanliRenyuan = 0
            ZhongcengGuanliRenyuan = 1
            GaocengGuanliRenyuan = 2
        End Enum
        '----------------------------------------------------------------
        ' 功能描述：
        '     根据人员区域特性intCodeValue判断是否为具体状态objenumRenyuanQuyuTexing
        ' 输入接口：
        '     intCodeValue - 人员级别标志
        '     objenumRenyuanJibieBiaozhi - 具体人员级别标志
        ' 输出接口：
        '     True - 是
        '     False - 否
        ' 备注信息：
        '     曾祥林 2008-05-19 设计
        '----------------------------------------------------------------
        Public Shared Function isRenyuanJibieBiaozhi( _
            ByVal intCodeValue As Integer, _
            ByVal objenumRenyuanJibieBiaozhi As enumRenyuanJibieBiaozhi) As Boolean

            isRenyuanJibieBiaozhi = False
            Try
                Dim intValue As Integer = objenumRenyuanJibieBiaozhi
                If intValue = intCodeValue Then
                    isRenyuanJibieBiaozhi = True
                End If
            Catch ex As Exception
            End Try

        End Function
        '----------------------------------------------------------------
        ' 功能描述：
        '     根据给定状态计算状态码
        ' 输入接口：
        '     strValue - 选定值
        ' 输出接口：
        '     True - 是
        '     False - 否
        ' 备注信息：
        '     曾祥林 2008-05-19 设计
        '----------------------------------------------------------------
        Public Shared Function getRenyuanJibieBiaozhi(ByVal strValue As String) As Integer

            getRenyuanJibieBiaozhi = 0
            Try
                Select Case strValue
                    Case "非管理人员"
                        getRenyuanJibieBiaozhi = enumRenyuanJibieBiaozhi.FeiGuanliRenyuan
                    Case "中层管理人员"
                        getRenyuanJibieBiaozhi = enumRenyuanJibieBiaozhi.ZhongcengGuanliRenyuan
                    Case "高层管理人员"
                        getRenyuanJibieBiaozhi = enumRenyuanJibieBiaozhi.GaocengGuanliRenyuan
                    Case Else
                End Select
            Catch ex As Exception
            End Try

        End Function









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
                Case enumTableType.RS_B_JISHUZHICHENG
                    table = createDataTables_JishuZhicheng(strErrMsg)
                Case enumTableType.RS_B_XUELIHUAFEN
                    table = createDataTables_XueliHuafen(strErrMsg)
                Case enumTableType.RS_B_XUEWEIHUAFEN
                    table = createDataTables_XueweiHuafen(strErrMsg)
                Case enumTableType.RS_B_ZHENGZHIMIANMAO
                    table = createDataTables_ZhengzhiMianmao(strErrMsg)
                Case enumTableType.RS_B_ZHIYEZIGE
                    table = createDataTables_ZhiyeZige(strErrMsg)
                Case enumTableType.RS_B_BIANDONGYUANYIN
                    table = createDataTables_BiandongYuanyin(strErrMsg)
                Case enumTableType.RS_B_ZHIGONGSHUXING
                    table = createDataTables_ZhigongShuxing(strErrMsg)

                Case enumTableType.RS_B_RENSHIKAPIAN
                    table = createDataTables_RenshiKapian(strErrMsg)
                Case enumTableType.RS_B_JIATINGCHENGYUAN
                    table = createDataTables_JiatingChengyuan(strErrMsg)
                Case enumTableType.RS_B_XUEXIJINGLI
                    table = createDataTables_XuexiJingli(strErrMsg)
                Case enumTableType.RS_B_GONGZUOJINGLI
                    table = createDataTables_GongzuoJingli(strErrMsg)
                Case enumTableType.RS_B_PEIXUNJILU
                    table = createDataTables_PeixunJilu(strErrMsg)
                Case enumTableType.RS_B_RENSHIYIDONG
                    table = createDataTables_RenshiYidong(strErrMsg)
                Case enumTableType.RS_B_LAODONGHETONG
                    table = createDataTables_LaodongHetong(strErrMsg)

                    'zengxianglin 2009-01-07
                Case enumTableType.RS_VT_RYZJYDB
                    table = createDataTables_RS_VT_RYZJYDB(strErrMsg)
                    'zengxianglin 2009-01-07

                    'zengxianglin 2009-01-08
                Case enumTableType.RS_VT_RLZYXXHZB
                    table = createDataTables_RS_VT_RLZYXXHZB(strErrMsg)
                    'zengxianglin 2009-01-08

                    'zengxianglin 2009-01-12
                Case enumTableType.RS_VT_LDHTJMQXB
                    table = createDataTables_RS_VT_LDHTJMQXB(strErrMsg)
                Case enumTableType.RS_VT_LDJJBB
                    table = createDataTables_RS_VT_LDJJBB(strErrMsg)
                Case enumTableType.RS_VT_LDJNBB
                    table = createDataTables_RS_VT_LDJNBB(strErrMsg)
                    'zengxianglin 2009-01-12

                Case Else
                    strErrMsg = "无效的表类型！"
                    table = Nothing
            End Select

            createDataTables = table

        End Function










        '----------------------------------------------------------------
        '创建TABLE_RS_B_JISHUZHICHENG
        '----------------------------------------------------------------
        Private Function createDataTables_JishuZhicheng(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_JISHUZHICHENG)
                With table.Columns
                    .Add(FIELD_RS_B_JISHUZHICHENG_ZCDM, GetType(System.String))
                    .Add(FIELD_RS_B_JISHUZHICHENG_ZCMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_JishuZhicheng = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_RS_B_XUELIHUAFEN
        '----------------------------------------------------------------
        Private Function createDataTables_XueliHuafen(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_XUELIHUAFEN)
                With table.Columns
                    .Add(FIELD_RS_B_XUELIHUAFEN_XLDM, GetType(System.String))
                    .Add(FIELD_RS_B_XUELIHUAFEN_XLMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_XueliHuafen = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_RS_B_XUEWEIHUAFEN
        '----------------------------------------------------------------
        Private Function createDataTables_XueweiHuafen(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_XUEWEIHUAFEN)
                With table.Columns
                    .Add(FIELD_RS_B_XUEWEIHUAFEN_XWDM, GetType(System.String))
                    .Add(FIELD_RS_B_XUEWEIHUAFEN_XWMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_XueweiHuafen = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_RS_B_ZHENGZHIMIANMAO
        '----------------------------------------------------------------
        Private Function createDataTables_ZhengzhiMianmao(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_ZHENGZHIMIANMAO)
                With table.Columns
                    .Add(FIELD_RS_B_ZHENGZHIMIANMAO_MMDM, GetType(System.String))
                    .Add(FIELD_RS_B_ZHENGZHIMIANMAO_MMMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_ZhengzhiMianmao = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_RS_B_ZHIYEZIGE
        '----------------------------------------------------------------
        Private Function createDataTables_ZhiyeZige(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_ZHIYEZIGE)
                With table.Columns
                    .Add(FIELD_RS_B_ZHIYEZIGE_ZGDM, GetType(System.String))
                    .Add(FIELD_RS_B_ZHIYEZIGE_ZGMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_ZhiyeZige = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_RS_B_BIANDONGYUANYIN
        '----------------------------------------------------------------
        Private Function createDataTables_BiandongYuanyin(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_BIANDONGYUANYIN)
                With table.Columns
                    .Add(FIELD_RS_B_BIANDONGYUANYIN_YYDM, GetType(System.String))
                    .Add(FIELD_RS_B_BIANDONGYUANYIN_YYMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_BiandongYuanyin = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_RS_B_ZHIGONGSHUXING
        '----------------------------------------------------------------
        Private Function createDataTables_ZhigongShuxing(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_ZHIGONGSHUXING)
                With table.Columns
                    .Add(FIELD_RS_B_ZHIGONGSHUXING_SXDM, GetType(System.String))
                    .Add(FIELD_RS_B_ZHIGONGSHUXING_SXMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_ZhigongShuxing = table

        End Function








        '----------------------------------------------------------------
        '创建TABLE_RS_B_RENSHIKAPIAN
        '----------------------------------------------------------------
        Private Function createDataTables_RenshiKapian(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_RENSHIKAPIAN)
                With table.Columns
                    .Add(FIELD_RS_B_RENSHIKAPIAN_WYBS, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_RYDM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_XM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_BMDM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_XB, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_CSRQ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_RBDWSJ, GetType(System.DateTime))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_YWXM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SJHM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZZDH, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFZH, GetType(System.String))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_MZ, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_JG, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_HJDZ, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_XZDZ, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_YJDZ, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_HKZT, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_RYXPWZ, GetType(System.String))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_HYZK, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SYZK, GetType(System.Int32))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_XXLX, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZGXL, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZGXW, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_BYYX, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_BYZY, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_BYSJ, GetType(System.DateTime))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_CJGZSJ, GetType(System.DateTime))
                    'zengxianglin 2009-01-12
                    .Add(FIELD_RS_B_RENSHIKAPIAN_TXSJ, GetType(System.DateTime))
                    'zengxianglin 2009-01-12
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZCQDSJ, GetType(System.DateTime))
                    'zengxianglin 2009-01-07
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ, GetType(System.DateTime))
                    'zengxianglin 2009-01-07
                    .Add(FIELD_RS_B_RENSHIKAPIAN_JSZC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZYZG, GetType(System.String))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZZMM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_RDSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZZGX, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFGHCY, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFSGGB, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_RYQYTX, GetType(System.Int32))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_JZQK, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZJZG, GetType(System.String))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_BRSDSZ, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFLDSZ, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFJZGB, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_GRFYKS, GetType(System.DateTime))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_GRFYJS, GetType(System.DateTime))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_GRFYSM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_CYFYSM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_CYFYZT, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_GRFYZT, GetType(System.Int32))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_BZXX, GetType(System.String))


                    .Add(FIELD_RS_B_RENSHIKAPIAN_BMMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_NN, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_HKZTMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_HYZKMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SYZKMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZGXLMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZGXWMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_JSZCMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZYZGMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZZMMMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFGHCYMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFSGGBMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_RYQYTXMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_JZQKMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_BRSDSZMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFLDSZMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFJZGBMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_CYFYZTMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_GRFYZTMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_DRZW, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZJDM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZJMC, GetType(System.String))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFZZ, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZZSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZZZW, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZNSL, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_LZYY, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RenshiKapian = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_RS_B_JIATINGCHENGYUAN
        '----------------------------------------------------------------
        Private Function createDataTables_JiatingChengyuan(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_JIATINGCHENGYUAN)
                With table.Columns
                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_WYBS, GetType(System.String))
                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_RYDM, GetType(System.String))

                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_CYXM, GetType(System.String))
                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_XYGX, GetType(System.String))
                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_CSNY, GetType(System.String))
                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_FWDW, GetType(System.String))
                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_DRZW, GetType(System.String))
                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_XJDZ, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_JiatingChengyuan = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_RS_B_XUEXIJINGLI
        '----------------------------------------------------------------
        Private Function createDataTables_XuexiJingli(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_XUEXIJINGLI)
                With table.Columns
                    .Add(FIELD_RS_B_XUEXIJINGLI_WYBS, GetType(System.String))
                    .Add(FIELD_RS_B_XUEXIJINGLI_RYDM, GetType(System.String))

                    'zengxianglin 2009-01-12
                    '.Add(FIELD_RS_B_XUEXIJINGLI_KSNY, GetType(System.String))
                    '.Add(FIELD_RS_B_XUEXIJINGLI_ZZNY, GetType(System.String))
                    .Add(FIELD_RS_B_XUEXIJINGLI_KSNY, GetType(System.DateTime))
                    .Add(FIELD_RS_B_XUEXIJINGLI_ZZNY, GetType(System.DateTime))
                    'zengxianglin 2009-01-12
                    .Add(FIELD_RS_B_XUEXIJINGLI_XXLX, GetType(System.String))
                    .Add(FIELD_RS_B_XUEXIJINGLI_XXYX, GetType(System.String))
                    .Add(FIELD_RS_B_XUEXIJINGLI_XXZY, GetType(System.String))
                    .Add(FIELD_RS_B_XUEXIJINGLI_XXJG, GetType(System.String))
                    .Add(FIELD_RS_B_XUEXIJINGLI_BZXX, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_XuexiJingli = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_RS_B_GONGZUOJINGLI
        '----------------------------------------------------------------
        Private Function createDataTables_GongzuoJingli(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_GONGZUOJINGLI)
                With table.Columns
                    .Add(FIELD_RS_B_GONGZUOJINGLI_WYBS, GetType(System.String))
                    .Add(FIELD_RS_B_GONGZUOJINGLI_RYDM, GetType(System.String))

                    .Add(FIELD_RS_B_GONGZUOJINGLI_KSNY, GetType(System.String))
                    .Add(FIELD_RS_B_GONGZUOJINGLI_ZZNY, GetType(System.String))
                    .Add(FIELD_RS_B_GONGZUOJINGLI_FWDW, GetType(System.String))
                    .Add(FIELD_RS_B_GONGZUOJINGLI_DRZW, GetType(System.String))
                    .Add(FIELD_RS_B_GONGZUOJINGLI_BZXX, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_GongzuoJingli = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_RS_B_PEIXUNJILU
        '----------------------------------------------------------------
        Private Function createDataTables_PeixunJilu(ByRef strErrMsg As String) As System.Data.DataTable


            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_PEIXUNJILU)
                With table.Columns
                    .Add(FIELD_RS_B_PEIXUNJILU_WYBS, GetType(System.String))
                    .Add(FIELD_RS_B_PEIXUNJILU_RYDM, GetType(System.String))

                    .Add(FIELD_RS_B_PEIXUNJILU_PXMC, GetType(System.String))
                    .Add(FIELD_RS_B_PEIXUNJILU_KSSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_PEIXUNJILU_ZZSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_PEIXUNJILU_NBPX, GetType(System.Int32))
                    .Add(FIELD_RS_B_PEIXUNJILU_PXXG, GetType(System.String))
                    .Add(FIELD_RS_B_PEIXUNJILU_BZXX, GetType(System.String))
                    .Add(FIELD_RS_B_PEIXUNJILU_PXKS, GetType(System.Int32))


                    .Add(FIELD_RS_B_PEIXUNJILU_RYMC, GetType(System.String))
                    .Add(FIELD_RS_B_PEIXUNJILU_NBPXMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_PeixunJilu = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_RS_B_RENSHIYIDONG
        '----------------------------------------------------------------
        Private Function createDataTables_RenshiYidong(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_RENSHIYIDONG)
                With table.Columns
                    .Add(FIELD_RS_B_RENSHIYIDONG_WYBS, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_RYDM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_KSSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_RENSHIYIDONG_ZZSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_RENSHIYIDONG_GLBS, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_BDYY, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_RZDW, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_RZJB, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_JBBZ, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIYIDONG_FGGZ, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_ZGSX, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_GWSX, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIYIDONG_YRDW, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_YRJB, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_BZXX, GetType(System.String))
                    'zengxianglin 2008-10-14
                    .Add(FIELD_RS_B_RENSHIYIDONG_SSFZ, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_YSFZ, GetType(System.String))
                    'zengxianglin 2008-10-14
                    'zengxianglin 2010-01-06
                    .Add(FIELD_RS_B_RENSHIYIDONG_YGSX, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIYIDONG_YZSX, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_BCZB, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIYIDONG_SCZB, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIYIDONG_XSTD, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIYIDONG_YSTD, GetType(System.Int32))
                    'zengxianglin 2010-01-06

                    .Add(FIELD_RS_B_RENSHIYIDONG_RYMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_BDYYMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_RZDWMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_ZGSXMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_GWSXMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_YRDWMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_JBBZMC, GetType(System.String))
                    'zengxianglin 2010-01-06
                    .Add(FIELD_RS_B_RENSHIYIDONG_YGSXMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_YZSXMC, GetType(System.String))
                    'zengxianglin 2010-01-06
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RenshiYidong = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_RS_B_LAODONGHETONG
        '----------------------------------------------------------------
        Private Function createDataTables_LaodongHetong(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_LAODONGHETONG)
                With table.Columns
                    .Add(FIELD_RS_B_LAODONGHETONG_WYBS, GetType(System.String))
                    .Add(FIELD_RS_B_LAODONGHETONG_RYDM, GetType(System.String))

                    .Add(FIELD_RS_B_LAODONGHETONG_KSSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_LAODONGHETONG_JSSJ, GetType(System.DateTime))
                    'zengxianglin 2009-01-12
                    .Add(FIELD_RS_B_LAODONGHETONG_SYKS, GetType(System.DateTime))
                    .Add(FIELD_RS_B_LAODONGHETONG_SYJS, GetType(System.DateTime))
                    'zengxianglin 2009-01-12

                    .Add(FIELD_RS_B_LAODONGHETONG_HTLX, GetType(System.Int32))
                    .Add(FIELD_RS_B_LAODONGHETONG_SFXY, GetType(System.Int32))

                    .Add(FIELD_RS_B_LAODONGHETONG_HTWJ, GetType(System.String))


                    .Add(FIELD_RS_B_LAODONGHETONG_RYMC, GetType(System.String))
                    .Add(FIELD_RS_B_LAODONGHETONG_HTLXMC, GetType(System.String))
                    .Add(FIELD_RS_B_LAODONGHETONG_SFXYMC, GetType(System.String))
                    .Add(FIELD_RS_B_LAODONGHETONG_HTWJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_LaodongHetong = table

        End Function

        'zengxianglin 2009-01-07
        '----------------------------------------------------------------
        '创建TABLE_RS_VT_RYZJYDB
        '----------------------------------------------------------------
        Private Function createDataTables_RS_VT_RYZJYDB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_VT_RYZJYDB)
                With table.Columns
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RYZJYDB_TJNY, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_JLXH, GetType(System.Int32))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RYZJYDB_RZXM, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_RZRQ, GetType(System.DateTime))
                    .Add(FIELD_RS_VT_RYZJYDB_RZBM, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_RZZJ, GetType(System.String))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RYZJYDB_LZXM, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_LZJCHT, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_LZQMZZ, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_LZDC, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_LZTX, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_LZSW, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_LZQT, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_LZRQ, GetType(System.DateTime))
                    .Add(FIELD_RS_VT_RYZJYDB_LZBM, GetType(System.String))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RYZJYDB_SXXM, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_SXYX, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_SXRQ, GetType(System.DateTime))
                    .Add(FIELD_RS_VT_RYZJYDB_SXBM, GetType(System.String))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RYZJYDB_YDXM, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_YDRQ, GetType(System.DateTime))
                    .Add(FIELD_RS_VT_RYZJYDB_YDXBM, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_YDXZJ, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_YDYBM, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_YDYZJ, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_YDZZ, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_YDCQCJ, GetType(System.Int32))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RYZJYDB_YDSBZY, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_YDSBJY, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_YDKJGJJ, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_YDTJGJJ, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_YDPXQK, GetType(System.String))
                    '***************************************************************************
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RS_VT_RYZJYDB = table

        End Function
        'zengxianglin 2009-01-07

        'zengxianglin 2009-01-08
        '----------------------------------------------------------------
        '创建TABLE_RS_VT_RLZYXXHZB
        '----------------------------------------------------------------
        Private Function createDataTables_RS_VT_RLZYXXHZB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_VT_RLZYXXHZB)
                With table.Columns
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RLZYXXHZB_DWDM, GetType(System.String))
                    .Add(FIELD_RS_VT_RLZYXXHZB_DWMC, GetType(System.String))
                    .Add(FIELD_RS_VT_RLZYXXHZB_DWXH, GetType(System.Int32))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RLZYXXHZB_RZRS, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RLZYXXHZB_DRRS, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RLZYXXHZB_DCRS, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RLZYXXHZB_LZRS, GetType(System.Int32))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RLZYXXHZB_PJRSY, GetType(System.Double))
                    .Add(FIELD_RS_VT_RLZYXXHZB_PJRSJ, GetType(System.Double))
                    .Add(FIELD_RS_VT_RLZYXXHZB_PJRSN, GetType(System.Double))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RLZYXXHZB_DWCSY, GetType(System.Double))
                    .Add(FIELD_RS_VT_RLZYXXHZB_DWCSJ, GetType(System.Double))
                    .Add(FIELD_RS_VT_RLZYXXHZB_DWCSN, GetType(System.Double))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RLZYXXHZB_PJCSY, GetType(System.Double))
                    .Add(FIELD_RS_VT_RLZYXXHZB_PJCSJ, GetType(System.Double))
                    .Add(FIELD_RS_VT_RLZYXXHZB_PJCSN, GetType(System.Double))
                    '***************************************************************************
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RS_VT_RLZYXXHZB = table

        End Function
        'zengxianglin 2009-01-08

        'zengxianglin 2009-01-12
        '----------------------------------------------------------------
        '创建TABLE_RS_VT_LDHTJMQXB
        '----------------------------------------------------------------
        Private Function createDataTables_RS_VT_LDHTJMQXB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_VT_LDHTJMQXB)
                With table.Columns
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDHTJMQXB_JLXH, GetType(System.Int32))
                    .Add(FIELD_RS_VT_LDHTJMQXB_TJNY, GetType(System.Int32))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDHTJMQXB_SLBRYDM, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_SLBRYMC, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_SLBHTQX, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_SLBXYQK, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_SLBRZSJ, GetType(System.DateTime))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDHTJMQXB_FHRYDM, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_FHRYMC, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_FHHTQX, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_FHXYQK, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_FHRZSJ, GetType(System.DateTime))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDHTJMQXB_ZBRYDM, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_ZBRYMC, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_ZBHTQX, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_ZBXYQK, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_ZBRZSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_VT_LDHTJMQXB_ZBGWQX, GetType(System.String))
                    '***************************************************************************
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RS_VT_LDHTJMQXB = table

        End Function
        'zengxianglin 2009-01-12

        'zengxianglin 2009-01-12
        '----------------------------------------------------------------
        '创建TABLE_RS_VT_LDJJBB
        '----------------------------------------------------------------
        Private Function createDataTables_RS_VT_LDJJBB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_VT_LDJJBB)
                With table.Columns
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDJJBB_JLXH, GetType(System.Int32))
                    .Add(FIELD_RS_VT_LDJJBB_TJNJ, GetType(System.Int32))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDJJBB_ZBMC, GetType(System.String))
                    .Add(FIELD_RS_VT_LDJJBB_ZBDW, GetType(System.String))
                    .Add(FIELD_RS_VT_LDJJBB_ZBDM, GetType(System.String))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDJJBB_BJSJ, GetType(System.Double))
                    .Add(FIELD_RS_VT_LDJJBB_NCZBJZ, GetType(System.Double))
                    '***************************************************************************
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RS_VT_LDJJBB = table

        End Function
        'zengxianglin 2009-01-12

        'zengxianglin 2009-01-12
        '----------------------------------------------------------------
        '创建TABLE_RS_VT_LDJNBB
        '----------------------------------------------------------------
        Private Function createDataTables_RS_VT_LDJNBB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_VT_LDJNBB)
                With table.Columns
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDJNBB_JLXH, GetType(System.Int32))
                    .Add(FIELD_RS_VT_LDJNBB_TJND, GetType(System.Int32))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDJNBB_ZBMC, GetType(System.String))
                    .Add(FIELD_RS_VT_LDJNBB_ZBDW, GetType(System.String))
                    .Add(FIELD_RS_VT_LDJNBB_ZBDM, GetType(System.String))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDJNBB_BNSJ, GetType(System.Double))
                    '***************************************************************************
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RS_VT_LDJNBB = table

        End Function
        'zengxianglin 2009-01-12

    End Class 'estateRenshiGeneralData

End Namespace 'Josco.JsKernal.Common.Data
