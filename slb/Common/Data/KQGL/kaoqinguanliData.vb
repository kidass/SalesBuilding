Option Strict On
Option Explicit On

Imports System
Imports System.Data
Imports System.Runtime.Serialization

Namespace Josco.JSOA.Common.Data

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.Common.Data
    ' 类名    ：kaoqinguanliData
    '
    ' 功能描述：
    '     定义兴业公司考勤管理管理相关表的数据访问格式
    '
    ' 更改记录：
    '----------------------------------------------------------------
    <System.ComponentModel.DesignerCategory("KQGL"), SerializableAttribute()> Public Class kaoqinguanliData
        Inherits System.Data.DataSet


        '考勤_B_考勤类型表信息定义
        '表名称
        Public Const TABLE_B_KQ_KAOQINLEXING As String = "考勤_B_考勤类型"
        '字段序列
        Public Const FIELD_B_KQ_KAOQINLEXING_DM As String = "考勤类型代码"
        Public Const FIELD_B_KQ_KAOQINLEXING_MC As String = "考勤类型名称"
        Public Const FIELD_B_KQ_KAOQINLEXING_JC As String = "考勤类型简称"

        '[考勤_B_考勤记录]表信息定义
        '表名称
        Public Const TABLE_KQ_B_KAOQINJILU As String = "考勤_B_考勤记录"
        '字段序列
        Public Const FIELD_KQ_B_KAOQINJILU_WYBS As String = "唯一标识"
        Public Const FIELD_KQ_B_KAOQINJILU_RQ As String = "日期"
        Public Const FIELD_KQ_B_KAOQINJILU_RYDM As String = "人员代码"
        Public Const FIELD_KQ_B_KAOQINJILU_ZZDM As String = "组织代码"
        Public Const FIELD_KQ_B_KAOQINJILU_SBSJ As String = "上班时间"
        Public Const FIELD_KQ_B_KAOQINJILU_XBSJ As String = "下班时间"
        Public Const FIELD_KQ_B_KAOQINJILU_JLDM As String = "记录代码"
        Public Const FIELD_KQ_B_KAOQINJILU_KQJL As String = "考勤记录"
        Public Const FIELD_KQ_B_KAOQINJILU_SJLX As String = "时间类型"
        Public Const FIELD_KQ_B_KAOQINJILU_JLSJ As String = "记录时间"
        Public Const FIELD_KQ_B_KAOQINJILU_JLRY As String = "记录人员"
        Public Const FIELD_KQ_B_KAOQINJILU_BXYF As String = "补休月份"

        '考勤_B_表信息定义
        '表名称
        Public Const TABLE_KQ_B_NIANXIUJIA As String = "考勤_B_年休假"
        '字段序列
        Public Const FIELD_KQ_B_NIANXIUJIA_WYBS As String = "唯一标识"
        Public Const FIELD_KQ_B_NIANXIUJIA_RYDM As String = "人员代码"
        Public Const FIELD_KQ_B_NIANXIUJIA_YXQ As String = "有效期"
        Public Const FIELD_KQ_B_NIANXIUJIA_NF As String = "年份"
        Public Const FIELD_KQ_B_NIANXIUJIA_NXJ As String = "年休假"
        Public Const FIELD_KQ_B_NIANXIUJIA_GXSJ As String = "更新时间"

        Public Const FIELD_KQ_B_NIANXIUJIA_YXSJ As String = "有效时间"
        Public Const FIELD_KQ_B_NIANXIUJIA_RZSJ As String = "入职时间"
        Public Const FIELD_KQ_B_NIANXIUJIA_RYMC As String = "人员名称"

        '考勤_VT_表信息定义
        Public Const TABLE_KQ_VT_NIANXIUJIA As String = "考勤_VT_年休假"
        '字段序列
        Public Const FIELD_KQ_VT_NIANXIUJIA_RYMC As String = "人员名称"
        Public Const FIELD_KQ_VT_NIANXIUJIA_RYDM As String = "人员代码"
        Public Const FIELD_KQ_VT_NIANXIUJIA_ZZDM As String = "组织代码"
        Public Const FIELD_KQ_VT_NIANXIUJIA_ZZMC As String = "组织名称"

        Public Const FIELD_KQ_VT_NIANXIUJIA_RZSJ As String = "入职时间"
        Public Const FIELD_KQ_VT_NIANXIUJIA_NXJ As String = "年休假"
        Public Const FIELD_KQ_VT_NIANXIUJIA_YXQ As String = "有效期"
        Public Const FIELD_KQ_VT_NIANXIUJIA_NF As String = "年份"
        Public Const FIELD_KQ_VT_NIANXIUJIA_GXSJ As String = "更新时间"
        Public Const FIELD_KQ_VT_NIANXIUJIA_SYTS As String = "剩余天数"

        Public Const FIELD_KQ_VT_NIANXIUJIA_YI As String = "yi"
        Public Const FIELD_KQ_VT_NIANXIUJIA_ER As String = "er"
        Public Const FIELD_KQ_VT_NIANXIUJIA_SAN As String = "san"
        Public Const FIELD_KQ_VT_NIANXIUJIA_SI As String = "si"
        Public Const FIELD_KQ_VT_NIANXIUJIA_WU As String = "wu"
        Public Const FIELD_KQ_VT_NIANXIUJIA_LIU As String = "liu"
        Public Const FIELD_KQ_VT_NIANXIUJIA_QI As String = "qi"
        Public Const FIELD_KQ_VT_NIANXIUJIA_BA As String = "ba"
        Public Const FIELD_KQ_VT_NIANXIUJIA_JIU As String = "jiu"
        Public Const FIELD_KQ_VT_NIANXIUJIA_SHI As String = "shi"

        Public Const FIELD_KQ_VT_NIANXIUJIA_SHIYI As String = "shiyi"
        Public Const FIELD_KQ_VT_NIANXIUJIA_SHIER As String = "shier"



        '[考勤_VT_考勤记录]表信息定义
        '表名称
        Public Const TABLE_KQ_VT_KAOQINJILU As String = "考勤_VT_考勤记录"
        '字段序列
        Public Const FIELD_KQ_VT_KAOQINJILU_RYMC As String = "人员名称"
        Public Const FIELD_KQ_VT_KAOQINJILU_RYDM As String = "人员代码"
        Public Const FIELD_KQ_VT_KAOQINJILU_ZZDM As String = "组织代码"
        Public Const FIELD_KQ_VT_KAOQINJILU_SJLX As String = "时间类型"

        Public Const FIELD_KQ_VT_KAOQINJILU_NXJ As String = "年休假"
        Public Const FIELD_KQ_VT_KAOQINJILU_YNXJ As String = "余年休假"
        Public Const FIELD_KQ_VT_KAOQINJILU_BXJ As String = "补休假"
        Public Const FIELD_KQ_VT_KAOQINJILU_YBXJ As String = "余补休假"
        Public Const FIELD_KQ_VT_KAOQINJILU_YYXJ As String = "月应休假"
        Public Const FIELD_KQ_VT_KAOQINJILU_YYYXJ As String = "余月应休假"
        Public Const FIELD_KQ_VT_KAOQINJILU_YXJBZ As String = "应休假标准"

        Public Const FIELD_KQ_VT_KAOQINJILU_YI As String = "yi"
        Public Const FIELD_KQ_VT_KAOQINJILU_ER As String = "er"
        Public Const FIELD_KQ_VT_KAOQINJILU_SAN As String = "san"
        Public Const FIELD_KQ_VT_KAOQINJILU_SI As String = "si"
        Public Const FIELD_KQ_VT_KAOQINJILU_WU As String = "wu"
        Public Const FIELD_KQ_VT_KAOQINJILU_LIU As String = "liu"
        Public Const FIELD_KQ_VT_KAOQINJILU_QI As String = "qi"
        Public Const FIELD_KQ_VT_KAOQINJILU_BA As String = "ba"
        Public Const FIELD_KQ_VT_KAOQINJILU_JIU As String = "jiu"
        Public Const FIELD_KQ_VT_KAOQINJILU_SHI As String = "shi"

        Public Const FIELD_KQ_VT_KAOQINJILU_SHIYI As String = "shiyi"
        Public Const FIELD_KQ_VT_KAOQINJILU_SHIER As String = "shier"
        Public Const FIELD_KQ_VT_KAOQINJILU_SHISAN As String = "shisan"
        Public Const FIELD_KQ_VT_KAOQINJILU_SHISI As String = "shisi"
        Public Const FIELD_KQ_VT_KAOQINJILU_SHIWU As String = "shiwu"
        Public Const FIELD_KQ_VT_KAOQINJILU_SHILIU As String = "shiliu"
        Public Const FIELD_KQ_VT_KAOQINJILU_SHIQI As String = "shiqi"
        Public Const FIELD_KQ_VT_KAOQINJILU_SHIBA As String = "shiba"
        Public Const FIELD_KQ_VT_KAOQINJILU_SHIJIU As String = "shijiu"
        Public Const FIELD_KQ_VT_KAOQINJILU_ERSHI As String = "ershi"

        Public Const FIELD_KQ_VT_KAOQINJILU_ERSHIYI As String = "ershiyi"
        Public Const FIELD_KQ_VT_KAOQINJILU_ERSHIER As String = "ershier"
        Public Const FIELD_KQ_VT_KAOQINJILU_ERSHISAN As String = "ershisan"
        Public Const FIELD_KQ_VT_KAOQINJILU_ERSHISI As String = "ershisi"
        Public Const FIELD_KQ_VT_KAOQINJILU_ERSHIWU As String = "ershiwu"
        Public Const FIELD_KQ_VT_KAOQINJILU_ERSHILIU As String = "ershiliu"
        Public Const FIELD_KQ_VT_KAOQINJILU_ERSHIQI As String = "ershiqi"
        Public Const FIELD_KQ_VT_KAOQINJILU_ERSHIBA As String = "ershiba"
        Public Const FIELD_KQ_VT_KAOQINJILU_ERSHIJIU As String = "ershijiu"
        Public Const FIELD_KQ_VT_KAOQINJILU_SANSHI As String = "sanshi"
        Public Const FIELD_KQ_VT_KAOQINJILU_SANSHIYI As String = "sanshiyi"

        Public Const strWCDM As String = "104"          '外出
        Public Const strXXR As String = "100"           '休息日
        Public Const strBX As String = "101"            '补休
        Public Const strNXJ As String = "102"           '年休假
        Public Const strCD As String = "203"           '迟到
        Public Const strDR As String = "800"           '调入
        Public Const strDC As String = "900"           '调出

        '“考勤_B_休假申请单”表信息定义
        '表名称
        Public Const TABLE_KQ_B_XIUJIASHENQINGDAN As String = "考勤_B_休假申请单"
        '字段序列

        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_WJBS As String = "文件标识"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_LSH As String = "流水号"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_DDSZ As String = "单独设置"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_BLZT As String = "办理状态"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_QFR As String = "签发人"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_QFRQ As String = "签发日期"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_JBRY As String = "经办人员"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_JBRQ As String = "经办日期"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_JBDW As String = "经办单位"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_JJCD As String = "紧急程度"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_MMDJ As String = "秘密等级"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_WJBT As String = "文件标题"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_JGDZ As String = "机关代字"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_WJNF As String = "文件年份"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_WJXH As String = "文件序号"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_ZWNR As String = "正文内容"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_HJWJ As String = "痕迹文件"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_PJYJ As String = "批件原件"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_BZXX As String = "备注信息"

        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_SQR As String = "申请人"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_SQRDM As String = "申请人代码"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_SQRQ As String = "申请日期"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_YY As String = "原因"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_ZZMC As String = "组织名称"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_ZZDM As String = "组织代码"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_ZW As String = "职务"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_DD As String = "地点"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_LXDH As String = "联系电话"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_KSRQ As String = "开始日期"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_JSRQ As String = "结束日期"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_TS As String = "天数"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_WTGZ As String = "委托工作"

        '显示字段序列
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_BWTX As String = "备忘提醒"
        '约束错误信息


        '“考勤_B_休假申请单_假期”表信息定义
        '表名称
        Public Const TABLE_KQ_B_XIUJIASHENQINGDAN_JIAQI As String = "考勤_B_休假申请单_假期"
        '字段序列
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_WYBS As String = "唯一标识"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_WJBS As String = "文件标识"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_JQDM As String = "记录代码"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_JQMC As String = "记录名称"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_TS As String = "天数"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_XH As String = "序号"
        Public Const FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_XSTS As String = "显示天数"

        '“考勤_B_休假_标准变化_职级”表信息定义
        '表名称
        Public Const TABLE_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI As String = "考勤_B_休假_标准变化_职级"
        '字段序列
        Public Const FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_BZBS As String = "标准标识"
        Public Const FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_BZXL As String = "标准序列"
        Public Const FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_ZZDM As String = "组织代码"
        Public Const FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_ZJDM As String = "职级代码"
        Public Const FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_KSSJ As String = "生效时间"
        Public Const FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_JSSJ As String = "失效时间"

        '显示字段序列
        Public Const FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_ZZMC As String = "组织名称"
        Public Const FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_ZJMC As String = "职级名称"

        '“考勤_B_月应休假”表信息定义
        '表名称
        Public Const TABLE_KQ_B_YUEYINGXIUJIA As String = "考勤_B_月应休假"
        '字段序列
        Public Const FIELD_KQ_B_YUEYINGXIUJIA_WYBS As String = "唯一标识"
        Public Const FIELD_KQ_B_YUEYINGXIUJIA_ZZDM As String = "组织代码"
        Public Const FIELD_KQ_B_YUEYINGXIUJIA_RQ As String = "日期"
        Public Const FIELD_KQ_B_YUEYINGXIUJIA_TS As String = "天数"



        '“考勤_VT_月应休假”表信息定义
        '表名称
        Public Const TABLE_KQ_VT_YUEYINGXIUJIA As String = "考勤_VT_月应休假"
        '字段序列
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_ZZDM As String = "组织代码"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_ZZMC As String = "组织名称"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_ZJDM As String = "职级代码"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_ZJMC As String = "职级名称"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_YXJBZ As String = "标准序列"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_BZSM As String = "标准说明"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_YI As String = "yi"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_ER As String = "er"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_SAN As String = "san"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_SI As String = "si"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_WU As String = "wu"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_LIU As String = "liu"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_QI As String = "qi"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_BA As String = "ba"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_JIU As String = "jiu"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_SHI As String = "shi"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_SHIYI As String = "shiyi"
        Public Const FIELD_KQ_VT_YUEYINGXIUJIA_SHIER As String = "shier"

        '[考勤_VT_补休一览表]表信息定义
        '表名称
        Public Const TABLE_KQ_VT_BUXIUJIA As String = "考勤_VT_补休一览表"
        '字段序列
        Public Const FIELD_KQ_VT_BUXIUJIA_RYMC As String = "人员名称"
        Public Const FIELD_KQ_VT_BUXIUJIA_RYDM As String = "人员代码"
        Public Const FIELD_KQ_VT_BUXIUJIA_ZZDM As String = "组织代码"
        Public Const FIELD_KQ_VT_BUXIUJIA_ZZMC As String = "组织名称"

        Public Const FIELD_KQ_VT_BUXIUJIA_YI As String = "yi"
        Public Const FIELD_KQ_VT_BUXIUJIA_YI1 As String = "yi1"
        Public Const FIELD_KQ_VT_BUXIUJIA_YI2 As String = "yi2"
        Public Const FIELD_KQ_VT_BUXIUJIA_ER As String = "er"
        Public Const FIELD_KQ_VT_BUXIUJIA_ER1 As String = "er1"
        Public Const FIELD_KQ_VT_BUXIUJIA_ER2 As String = "er2"
        Public Const FIELD_KQ_VT_BUXIUJIA_SAN As String = "san"
        Public Const FIELD_KQ_VT_BUXIUJIA_SAN1 As String = "san1"
        Public Const FIELD_KQ_VT_BUXIUJIA_SAN2 As String = "san2"

        '“考勤_VT_工资表”表信息定义
        '表名称
        Public Const TABLE_KQ_VT_GONGZIBIAO As String = "考勤_VT_工资表"
        '字段序列

        Public Const FIELD_KQ_VT_GONGZIBIAO_RYDM As String = "人员代码"
        Public Const FIELD_KQ_VT_GONGZIBIAO_RYMC As String = "人员名称"
        Public Const FIELD_KQ_VT_GONGZIBIAO_ZZDM As String = "组织代码"
        Public Const FIELD_KQ_VT_GONGZIBIAO_ZJDM As String = "职级代码"
        Public Const FIELD_KQ_VT_GONGZIBIAO_ZJMC As String = "职级名称"
        Public Const FIELD_KQ_VT_GONGZIBIAO_LX As String = "类型"
        Public Const FIELD_KQ_VT_GONGZIBIAO_LX2 As String = "类型2"
        Public Const FIELD_KQ_VT_GONGZIBIAO_ZTMC As String = "状态名称"
        Public Const FIELD_KQ_VT_GONGZIBIAO_GZTS As String = "工作天数"
        Public Const FIELD_KQ_VT_GONGZIBIAO_BZTS As String = "标准天数"
        Public Const FIELD_KQ_VT_GONGZIBIAO_RYZT As String = "人员状态"
        Public Const FIELD_KQ_VT_GONGZIBIAO_SYJQ As String = "使用假期"
        Public Const FIELD_KQ_VT_GONGZIBIAO_RLTS As String = "入离天数"
        Public Const FIELD_KQ_VT_GONGZIBIAO_RLBZ As String = "入离标识"
        Public Const FIELD_KQ_VT_GONGZIBIAO_RLMC As String = "入离名称"
        Public Const FIELD_KQ_VT_GONGZIBIAO_BX As String = "补休"
        Public Const FIELD_KQ_VT_GONGZIBIAO_GZBZ As String = "工资标准"
        Public Const FIELD_KQ_VT_GONGZIBIAO_KJTS As String = "扣减天数"
        Public Const FIELD_KQ_VT_GONGZIBIAO_KGZ As String = "扣工资"

        Public Const FIELD_KQ_VT_GONGZIBIAO_GZ As String = "工资"
        Public Const FIELD_KQ_VT_GONGZIBIAO_ZZMC As String = "组织名称"
        Public Const FIELD_KQ_VT_GONGZIBIAO_BMMC As String = "部门名称"
        Public Const FIELD_KQ_VT_GONGZIBIAO_SYGZ As String = "上月工资"


        '定义初始化表类型enum
        Public Enum enumTableType
            B_KQ_KAOQINLEXING = 1

            KQ_B_KAOQINJILU = 2
            KQ_VT_KAOQINJILU = 3

            KQ_B_NIANXIUJIA = 4
            KQ_VT_NIANXIUJIA = 5

            KQ_B_XIUJIASHENQINGDAN = 6
            KQ_B_XIUJIASHENQINGDAN_JIAQI = 7

            KQ_VT_YUEYINGXIUJIA = 8
            KQ_VT_BUXIUJIA = 9
            KQ_B_YUEYINGXIUJIA = 10

            KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI = 11

            KQ_VT_GONGZIBIAO = 12
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.Common.Data.kaoqinguanliData)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub














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

                Case enumTableType.B_KQ_KAOQINLEXING
                    table = createDataTables_KAOQINLEXING(strErrMsg)
                Case enumTableType.KQ_B_KAOQINJILU
                    table = createDataTables_KAOQINJILU(strErrMsg)

                Case enumTableType.KQ_VT_KAOQINJILU
                    table = createDataTables_KAOQINJILU_VT(strErrMsg)

                Case enumTableType.KQ_B_NIANXIUJIA
                    table = createDataTables_NIANXIUJIA(strErrMsg)
                Case enumTableType.KQ_VT_NIANXIUJIA
                    table = createDataTables_NIANXIUJIA_VT(strErrMsg)

                Case enumTableType.KQ_B_XIUJIASHENQINGDAN
                    table = createDataTables_XIUJIASHENQINGDAN(strErrMsg)
                Case enumTableType.KQ_B_XIUJIASHENQINGDAN_JIAQI
                    table = createDataTables_XIUJIASHENQINGDAN_JIAQI(strErrMsg)

                Case enumTableType.KQ_VT_YUEYINGXIUJIA
                    table = createDataTables_YUEYINGXIUJIA_VT(strErrMsg)
                Case enumTableType.KQ_VT_BUXIUJIA
                    table = createDataTables_BUXIUJIA_VT(strErrMsg)

                Case enumTableType.KQ_B_YUEYINGXIUJIA
                    table = createDataTables_KQ_B_YUEYINGXIUJIA(strErrMsg)

                Case enumTableType.KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI
                    table = createDataTables_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI(strErrMsg)


                Case enumTableType.KQ_VT_GONGZIBIAO
                    table = createDataTables_KQ_VT_GONGZIBIAO(strErrMsg)

                Case Else
                    strErrMsg = "无效的表类型！"
                    table = Nothing
            End Select

            createDataTables = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_KQ_VT_GONGZIBIAO
        '----------------------------------------------------------------
        Private Function createDataTables_KQ_VT_GONGZIBIAO(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_KQ_VT_GONGZIBIAO)
                With table.Columns

                    .Add(FIELD_KQ_VT_GONGZIBIAO_SYGZ, GetType(System.Double))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_BMMC, GetType(System.String))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_ZZMC, GetType(System.String))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_GZ, GetType(System.Double))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_KGZ, GetType(System.Double))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_KJTS, GetType(System.Double))

                    .Add(FIELD_KQ_VT_GONGZIBIAO_GZBZ, GetType(System.Double))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_BX, GetType(System.Double))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_RLMC, GetType(System.String))

                    .Add(FIELD_KQ_VT_GONGZIBIAO_RLBZ, GetType(System.Int32))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_RLTS, GetType(System.Double))

                    .Add(FIELD_KQ_VT_GONGZIBIAO_SYJQ, GetType(System.String))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_RYZT, GetType(System.Int32))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_BZTS, GetType(System.Int32))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_GZTS, GetType(System.Int32))

                    .Add(FIELD_KQ_VT_GONGZIBIAO_ZTMC, GetType(System.String))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_LX2, GetType(System.Int32))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_LX, GetType(System.Int32))

                    .Add(FIELD_KQ_VT_GONGZIBIAO_ZJMC, GetType(System.String))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_ZJDM, GetType(System.String))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_ZZDM, GetType(System.String))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_RYMC, GetType(System.String))
                    .Add(FIELD_KQ_VT_GONGZIBIAO_RYDM, GetType(System.String))

                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_KQ_VT_GONGZIBIAO = table

        End Function


        '----------------------------------------------------------------
        '创建TABLE_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI
        '----------------------------------------------------------------
        Private Function createDataTables_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI)
                With table.Columns
                    .Add(FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_BZBS, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_BZXL, GetType(System.Int32))
                    .Add(FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_ZZDM, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_ZJDM, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_KSSJ, GetType(System.DateTime))
                    .Add(FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_JSSJ, GetType(System.DateTime))

                    .Add(FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_ZZMC, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI_ZJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_KQ_B_XIUJIA_BIAOZHUNBIANHUA_ZHIJI = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_KQ_B_YUEYINGXIUJIA
        '----------------------------------------------------------------
        Private Function createDataTables_KQ_B_YUEYINGXIUJIA(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_KQ_B_YUEYINGXIUJIA)
                With table.Columns
                    .Add(FIELD_KQ_B_YUEYINGXIUJIA_WYBS, GetType(System.String))
                    .Add(FIELD_KQ_B_YUEYINGXIUJIA_ZZDM, GetType(System.String))
                    .Add(FIELD_KQ_B_YUEYINGXIUJIA_RQ, GetType(System.DateTime))
                    .Add(FIELD_KQ_B_YUEYINGXIUJIA_TS, GetType(System.Double))

                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_KQ_B_YUEYINGXIUJIA = table

        End Function


        '----------------------------------------------------------------
        '创建TABLE_KQ_VT_BUXIUJIA
        '----------------------------------------------------------------
        Private Function createDataTables_BUXIUJIA_VT(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_KQ_VT_BUXIUJIA)
                With table.Columns
                    .Add(FIELD_KQ_VT_BUXIUJIA_RYMC, GetType(System.String))
                    .Add(FIELD_KQ_VT_BUXIUJIA_RYDM, GetType(System.String))
                    .Add(FIELD_KQ_VT_BUXIUJIA_ZZDM, GetType(System.String))
                    .Add(FIELD_KQ_VT_BUXIUJIA_ZZMC, GetType(System.String))

                    .Add(FIELD_KQ_VT_BUXIUJIA_YI, GetType(System.Double))
                    .Add(FIELD_KQ_VT_BUXIUJIA_YI1, GetType(System.Double))
                    .Add(FIELD_KQ_VT_BUXIUJIA_YI2, GetType(System.Double))
                    .Add(FIELD_KQ_VT_BUXIUJIA_ER, GetType(System.Double))
                    .Add(FIELD_KQ_VT_BUXIUJIA_ER1, GetType(System.Double))
                    .Add(FIELD_KQ_VT_BUXIUJIA_ER2, GetType(System.Double))
                    .Add(FIELD_KQ_VT_BUXIUJIA_SAN, GetType(System.Double))
                    .Add(FIELD_KQ_VT_BUXIUJIA_SAN1, GetType(System.Double))
                    .Add(FIELD_KQ_VT_BUXIUJIA_SAN2, GetType(System.Double))

                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_BUXIUJIA_VT = table

        End Function

       
        '----------------------------------------------------------------
        '创建TABLE_KQ_VT_YUEYINGXIUJIA
        '----------------------------------------------------------------
        Private Function createDataTables_YUEYINGXIUJIA_VT(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_KQ_VT_YUEYINGXIUJIA)
                With table.Columns
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_ZZDM, GetType(System.String))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_ZZMC, GetType(System.String))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_ZJDM, GetType(System.String))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_ZJMC, GetType(System.String))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_YXJBZ, GetType(System.Int32))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_BZSM, GetType(System.String))

                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_YI, GetType(System.String))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_ER, GetType(System.String))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_SAN, GetType(System.String))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_SI, GetType(System.String))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_WU, GetType(System.String))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_LIU, GetType(System.String))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_QI, GetType(System.String))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_BA, GetType(System.String))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_JIU, GetType(System.String))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_SHI, GetType(System.String))

                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_SHIYI, GetType(System.String))
                    .Add(FIELD_KQ_VT_YUEYINGXIUJIA_SHIER, GetType(System.String))

                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_YUEYINGXIUJIA_VT = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_KQ_B_XIUJIASHENQINGDAN_JIAQI
        '----------------------------------------------------------------
        Private Function createDataTables_XIUJIASHENQINGDAN_JIAQI(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_KQ_B_XIUJIASHENQINGDAN_JIAQI)
                With table.Columns
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_WYBS, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_WJBS, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_JQDM, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_JQMC, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_TS, GetType(System.Int32))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_XH, GetType(System.Int32))

                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_JIAQI_XSTS, GetType(System.String))

                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_XIUJIASHENQINGDAN_JIAQI = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_KQ_B_XIUJIASHENQINGDAN
        '----------------------------------------------------------------
        Private Function createDataTables_XIUJIASHENQINGDAN(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_KQ_B_XIUJIASHENQINGDAN)
                With table.Columns
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_WJBS, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_LSH, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_DDSZ, GetType(System.Int32))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_BLZT, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_QFR, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_QFRQ, GetType(System.DateTime))

                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_JBRY, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_JBRQ, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_JBDW, GetType(System.String))

                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_JJCD, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_MMDJ, GetType(System.String))

                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_WJBT, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_JGDZ, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_WJNF, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_WJXH, GetType(System.String))

                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_ZWNR, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_HJWJ, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_PJYJ, GetType(System.String))

                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_BZXX, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_BWTX, GetType(System.String))

                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_SQR, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_SQRDM, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_SQRQ, GetType(System.DateTime))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_YY, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_ZZDM, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_ZZMC, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_ZW, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_DD, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_LXDH, GetType(System.String))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_KSRQ, GetType(System.DateTime))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_JSRQ, GetType(System.DateTime))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_TS, GetType(System.Double))
                    .Add(FIELD_KQ_B_XIUJIASHENQINGDAN_WTGZ, GetType(System.String))

                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_XIUJIASHENQINGDAN = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_KQ_VT_NIANXIUJIA
        '----------------------------------------------------------------
        Private Function createDataTables_NIANXIUJIA_VT(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_KQ_VT_NIANXIUJIA)
                With table.Columns
                    .Add(FIELD_KQ_VT_NIANXIUJIA_RYMC, GetType(System.String))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_RYDM, GetType(System.String))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_ZZDM, GetType(System.String))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_ZZMC, GetType(System.String))

                    .Add(FIELD_KQ_VT_NIANXIUJIA_RZSJ, GetType(System.DateTime))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_NXJ, GetType(System.Int32))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_YXQ, GetType(System.String))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_NF, GetType(System.String))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_GXSJ, GetType(System.DateTime))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_SYTS, GetType(System.Double))

                    .Add(FIELD_KQ_VT_NIANXIUJIA_YI, GetType(System.Double))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_ER, GetType(System.Double))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_SAN, GetType(System.Double))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_SI, GetType(System.Double))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_WU, GetType(System.Double))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_LIU, GetType(System.Double))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_QI, GetType(System.Double))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_BA, GetType(System.Double))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_JIU, GetType(System.Double))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_SHI, GetType(System.Double))

                    .Add(FIELD_KQ_VT_NIANXIUJIA_SHIYI, GetType(System.Double))
                    .Add(FIELD_KQ_VT_NIANXIUJIA_SHIER, GetType(System.Double))
                  
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_NIANXIUJIA_VT = table

        End Function


        '----------------------------------------------------------------
        '创建TABLE_KQ_B_NIANXIUJIA
        '----------------------------------------------------------------
        Private Function createDataTables_NIANXIUJIA(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_KQ_B_NIANXIUJIA)
                With table.Columns
                    .Add(FIELD_KQ_B_NIANXIUJIA_WYBS, GetType(System.String))
                    .Add(FIELD_KQ_B_NIANXIUJIA_RYDM, GetType(System.String))
                    .Add(FIELD_KQ_B_NIANXIUJIA_YXQ, GetType(System.String))
                    .Add(FIELD_KQ_B_NIANXIUJIA_NF, GetType(System.String))
                    .Add(FIELD_KQ_B_NIANXIUJIA_NXJ, GetType(System.Int32))
                    .Add(FIELD_KQ_B_NIANXIUJIA_GXSJ, GetType(System.DateTime))

                    .Add(FIELD_KQ_B_NIANXIUJIA_YXSJ, GetType(System.DateTime))
                    .Add(FIELD_KQ_B_NIANXIUJIA_RZSJ, GetType(System.DateTime))
                    .Add(FIELD_KQ_B_NIANXIUJIA_RYMC, GetType(System.String))

                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_NIANXIUJIA = table

        End Function


        '----------------------------------------------------------------
        '创建TABLE_KQ_VT_KAOQINJILU
        '----------------------------------------------------------------
        Private Function createDataTables_KAOQINJILU_VT(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_KQ_VT_KAOQINJILU)
                With table.Columns
                    .Add(FIELD_KQ_VT_KAOQINJILU_RYMC, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_RYDM, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_ZZDM, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_SJLX, GetType(System.Int32))

                    .Add(FIELD_KQ_VT_KAOQINJILU_NXJ, GetType(System.Double))
                    .Add(FIELD_KQ_VT_KAOQINJILU_YNXJ, GetType(System.Double))
                    .Add(FIELD_KQ_VT_KAOQINJILU_BXJ, GetType(System.Double))
                    .Add(FIELD_KQ_VT_KAOQINJILU_YBXJ, GetType(System.Double))
                    .Add(FIELD_KQ_VT_KAOQINJILU_YYXJ, GetType(System.Double))
                    .Add(FIELD_KQ_VT_KAOQINJILU_YYYXJ, GetType(System.Double))
                    .Add(FIELD_KQ_VT_KAOQINJILU_YXJBZ, GetType(System.Int32))

                    .Add(FIELD_KQ_VT_KAOQINJILU_YI, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_ER, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_SAN, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_SI, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_WU, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_LIU, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_QI, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_BA, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_JIU, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_SHI, GetType(System.String))

                    .Add(FIELD_KQ_VT_KAOQINJILU_SHIYI, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_SHIER, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_SHISAN, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_SHISI, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_SHIWU, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_SHILIU, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_SHIQI, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_SHIBA, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_SHIJIU, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_ERSHI, GetType(System.String))


                    .Add(FIELD_KQ_VT_KAOQINJILU_ERSHIYI, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_ERSHIER, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_ERSHISAN, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_ERSHISI, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_ERSHIWU, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_ERSHILIU, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_ERSHIQI, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_ERSHIBA, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_ERSHIJIU, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_SANSHI, GetType(System.String))
                    .Add(FIELD_KQ_VT_KAOQINJILU_SANSHIYI, GetType(System.String))

                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_KAOQINJILU_VT = table

        End Function

        '----------------------------------------------------------------
        '创建TABLE_B_KQ_KAOQINJILU
        '----------------------------------------------------------------
        Private Function createDataTables_KAOQINJILU(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_KQ_B_KAOQINJILU)
                With table.Columns
                    .Add(FIELD_KQ_B_KAOQINJILU_WYBS, GetType(System.String))
                    .Add(FIELD_KQ_B_KAOQINJILU_RQ, GetType(System.DateTime))
                    .Add(FIELD_KQ_B_KAOQINJILU_RYDM, GetType(System.String))

                    .Add(FIELD_KQ_B_KAOQINJILU_ZZDM, GetType(System.String))
                    .Add(FIELD_KQ_B_KAOQINJILU_SBSJ, GetType(System.DateTime))
                    .Add(FIELD_KQ_B_KAOQINJILU_XBSJ, GetType(System.DateTime))

                    .Add(FIELD_KQ_B_KAOQINJILU_JLDM, GetType(System.String))
                    .Add(FIELD_KQ_B_KAOQINJILU_KQJL, GetType(System.String))
                    .Add(FIELD_KQ_B_KAOQINJILU_SJLX, GetType(System.Int32))

                    .Add(FIELD_KQ_B_KAOQINJILU_JLSJ, GetType(System.DateTime))
                    .Add(FIELD_KQ_B_KAOQINJILU_JLRY, GetType(System.String))
                    .Add(FIELD_KQ_B_KAOQINJILU_BXYF, GetType(System.DateTime))

                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_KAOQINJILU = table

        End Function


        '----------------------------------------------------------------
        '创建TABLE_B_KQ_KAOQINLEXING
        '----------------------------------------------------------------
        Private Function createDataTables_KAOQINLEXING(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_B_KQ_KAOQINLEXING)
                With table.Columns
                    .Add(FIELD_B_KQ_KAOQINLEXING_DM, GetType(System.String))
                    .Add(FIELD_B_KQ_KAOQINLEXING_MC, GetType(System.String))
                    .Add(FIELD_B_KQ_KAOQINLEXING_JC, GetType(System.String))

                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_KAOQINLEXING = table

        End Function

    End Class
End Namespace
