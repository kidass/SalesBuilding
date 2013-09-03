
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
Imports Josco.JsKernal.Common.Workflow.BaseFlowObject

Namespace Josco.JSOA.Common.Workflow

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.Common.Workflow
    ' 类名    ：BaseFlowKqglQJD
    '
    ' 功能描述： 
    '     定义人事请假单审批工作流相关的参数
    '----------------------------------------------------------------
    Public Class BaseFlowKqglQJD
        Inherits Josco.JSOA.Common.Workflow.BaseFlowObject

        Public Const FLOWCODE As String = "qingjiadan"
        Public Const FLOWNAME As String = "请假单"
        Public Const FLOWBLLX As String = "请假单"

        '事宜定义
        Public Const TASK_CYCG As String = "草拟初稿"
        Public Const TASK_GJBJ As String = "主办处理"
        Public Const TASK_SHWJ As String = "审核文件"
        Public Const TASK_HQWJ As String = "会签文件"
        Public Const TASK_FHWJ As String = "复核文件"
        Public Const TASK_QFWJ As String = "签批文件"
        Public Const TASK_WJGD As String = "文件归档"
        Public Const TASK_CSWJ As String = "抄送文件"
        Public Const TASK_FGLD As String = "分管领导"
        Public Const TASK_ZJL As String = "总经理"

        '目录设定
        Public Const FILEDIR_FJ As String = "KQGL\QJD\FJ"          '附件目录
        Public Const FILEDIR_XG As String = "KQGL\QJD\XG"          '相关文件目录
        Public Const FILEDIR_GJ As String = "KQGL\QJD\GJ"          '稿件目录
        Public Const FILEDIR_RO As String = "KQGL\QJD\RO"          '签批文件(扫描件)目录
        Public Const FILEDIR_PJ As String = "KQGL\QJD\PJ"          '签批文件(电子件)目录

        '文件模板
        Public Const FILEMBDIR_FJ_RTF As String = "空附件.RTF"      '附件模板文件(RTF)
        Public Const FILEMBDIR_GJ_RTF As String = "空稿件.RTF"      '稿件模板文件(RTF)
        Public Const FILEMBDIR_FJ As String = "空附件.DOC"          '附件模板文件(DOC)
        Public Const FILEMBDIR_GJ As String = "空稿件.DOC"          '稿件模板文件(DOC)

        '审批意见类型
        Public Const SPYJ_BLYJ As String = "保留意见"
        Public Const SPYJ_BTY As String = "不同意"
        Public Const SPYJ_TY As String = "同意"

        '属性
        '*******************************************************
        Private m_strJJCD As String
        Private m_strMMDJ As String
        '*******************************************************
        Private m_strWJBT As String
        Private m_strJGDZ As String
        Private m_strWJNF As String
        Private m_strWJXH As String
        '*******************************************************
        Private m_strJBDW As String
        Private m_strJBRY As String
        Private m_objJBRQ As System.DateTime
        '*******************************************************
        Private m_strZWNR As String
        Private m_strHJWJ As String
        Private m_strPJYJ As String
        '*******************************************************
        Private m_strBEIZ As String
        '*******************************************************
        Private m_intDBRS As Integer
        '*******************************************************
        Private m_strSQR As String
        Private m_strSQRDM As String
        Private m_strSQRQ As System.DateTime
        Private m_strYY As String
        Private m_strZZDM As String
        Private m_strZZMC As String
        Private m_strZW As String
        Private m_strDD As String
        Private m_strLXDH As String
        Private m_strKSRQ As System.DateTime
        Private m_strJSRQ As System.DateTime
        Private m_strTS As Integer
        Private m_strWTGZ As String








        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New(FLOWCODE)

            '设置工作流参数
            Me.FlowType = Me.FLOWCODE
            Me.FlowTypeName = Me.FLOWNAME
            Me.FlowTypeBLLX = Me.FLOWBLLX

            '初始化工作流对象属性
            '*******************************************************
            m_strJJCD = ""
            m_strMMDJ = ""
            '*******************************************************
            m_strWJBT = ""
            m_strJGDZ = ""
            m_strWJNF = ""
            m_strWJXH = ""
            '*******************************************************
            m_strJBDW = ""
            m_strJBRY = ""
            m_objJBRQ = Nothing
            '*******************************************************
            m_strZWNR = ""
            m_strHJWJ = ""
            m_strPJYJ = ""
            '*******************************************************
            m_strBEIZ = ""
            '*******************************************************
            m_intDBRS = 0
            '*******************************************************
            m_strSQR = ""
            m_strSQRDM = ""
            m_strSQRQ = Nothing
            m_strYY = ""
            m_strZZDM = ""
            m_strZZMC = ""
            m_strZW = ""
            m_strDD = ""
            m_strLXDH = ""
            m_strKSRQ = Nothing
            m_strJSRQ = Nothing
            m_strTS = 0
            m_strWTGZ = ""
            '*******************************************************


        End Sub

        '----------------------------------------------------------------
        ' 析构函数
        '----------------------------------------------------------------
        Public Overloads Sub Dispose()
            MyBase.Dispose()
            Dispose(True)
        End Sub

        '----------------------------------------------------------------
        ' 释放本身资源
        '----------------------------------------------------------------
        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            If (Not disposing) Then
                Exit Sub
            End If
        End Sub

        '----------------------------------------------------------------
        ' 安全释放本身资源
        '----------------------------------------------------------------
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.Common.Workflow.BaseFlowKqglQJD)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub









        '----------------------------------------------------------------
        ' 获取“审批事宜”的办理子类SQL值列表
        '----------------------------------------------------------------
        Public Overrides ReadOnly Property TaskBlzlSPSYList() As String
            Get
                TaskBlzlSPSYList = ""
                TaskBlzlSPSYList = TaskBlzlSPSYList + " " + "'" + TASK_LDCL + "'"
                TaskBlzlSPSYList = TaskBlzlSPSYList + "," + "'" + TASK_XGCL + "'"
                TaskBlzlSPSYList = TaskBlzlSPSYList + "," + "'" + TASK_SHWJ + "'"
                TaskBlzlSPSYList = TaskBlzlSPSYList + "," + "'" + TASK_HQWJ + "'"
                TaskBlzlSPSYList = TaskBlzlSPSYList + "," + "'" + TASK_FHWJ + "'"
                TaskBlzlSPSYList = TaskBlzlSPSYList + "," + "'" + TASK_QFWJ + "'"
            End Get
        End Property









        '----------------------------------------------------------------
        ' 签发人
        '----------------------------------------------------------------
        Public Property QFR() As String
            Get
                QFR = Me.PZR
            End Get
            Set(ByVal Value As String)
                Me.PZR = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' 签发日期
        '----------------------------------------------------------------
        Public Property QFRQ() As System.DateTime
            Get
                QFRQ = Me.PZRQ
            End Get
            Set(ByVal Value As System.DateTime)
                Me.PZRQ = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' 办理状态
        '----------------------------------------------------------------
        Public Property BLZT() As String
            Get
                BLZT = Me.Status
            End Get
            Set(ByVal Value As String)
                Me.Status = Value
            End Set
        End Property










        '----------------------------------------------------------------
        ' 紧急程度
        '----------------------------------------------------------------
        Public Property JJCD() As String
            Get
                JJCD = m_strJJCD
            End Get
            Set(ByVal Value As String)
                m_strJJCD = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' 秘密等级
        '----------------------------------------------------------------
        Public Property MMDJ() As String
            Get
                MMDJ = m_strMMDJ
            End Get
            Set(ByVal Value As String)
                m_strMMDJ = Value
            End Set
        End Property










        '----------------------------------------------------------------
        ' 文件标题
        '----------------------------------------------------------------
        Public Property WJBT() As String
            Get
                WJBT = m_strWJBT
            End Get
            Set(ByVal Value As String)
                m_strWJBT = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' 机关代字
        '----------------------------------------------------------------
        Public Property JGDZ() As String
            Get
                JGDZ = m_strJGDZ
            End Get
            Set(ByVal Value As String)
                m_strJGDZ = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' 文件年份
        '----------------------------------------------------------------
        Public Property WJNF() As String
            Get
                WJNF = m_strWJNF
            End Get
            Set(ByVal Value As String)
                m_strWJNF = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' 文件序号
        '----------------------------------------------------------------
        Public Property WJXH() As String
            Get
                WJXH = m_strWJXH
            End Get
            Set(ByVal Value As String)
                m_strWJXH = Value
            End Set
        End Property










        '----------------------------------------------------------------
        ' 经办单位
        '----------------------------------------------------------------
        Public Property ZBDW() As String
            Get
                ZBDW = m_strJBDW
            End Get
            Set(ByVal Value As String)
                m_strJBDW = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' 经办人员
        '----------------------------------------------------------------
        Public Property NGR() As String
            Get
                NGR = m_strJBRY
            End Get
            Set(ByVal Value As String)
                m_strJBRY = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' 经办日期
        '----------------------------------------------------------------
        Public Property NGRQ() As System.DateTime
            Get
                NGRQ = m_objJBRQ
            End Get
            Set(ByVal Value As System.DateTime)
                m_objJBRQ = Value
            End Set
        End Property










        '----------------------------------------------------------------
        ' 正文内容
        '----------------------------------------------------------------
        Public Property ZWNR() As String
            Get
                ZWNR = m_strZWNR
            End Get
            Set(ByVal Value As String)
                m_strZWNR = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' 痕迹文件 = 签批件电子件
        '----------------------------------------------------------------
        Public Property HJWJ() As String
            Get
                HJWJ = m_strHJWJ
            End Get
            Set(ByVal Value As String)
                m_strHJWJ = Value
            End Set
        End Property

        '----------------------------------------------------------------
        ' 批件原件 = 签批件扫描件
        '----------------------------------------------------------------
        Public Property PJYJ() As String
            Get
                PJYJ = m_strPJYJ
            End Get
            Set(ByVal Value As String)
                m_strPJYJ = Value
            End Set
        End Property











        '----------------------------------------------------------------
        ' 备注
        '----------------------------------------------------------------
        Public Property BEIZ() As String
            Get
                BEIZ = m_strBEIZ
            End Get
            Set(ByVal Value As String)
                m_strBEIZ = Value
            End Set
        End Property

        '申请人
        Public Property SQR() As String
            Get
                SQR = m_strSQR
            End Get
            Set(ByVal Value As String)
                m_strSQR = Value
            End Set
        End Property

        '申请人代码
        Public Property SQRDM() As String
            Get
                SQRDM = m_strSQRDM
            End Get
            Set(ByVal Value As String)
                m_strSQRDM = Value
            End Set
        End Property

        '申请日期
        Public Property SQRQ() As System.DateTime
            Get
                SQRQ = m_strSQRQ
            End Get
            Set(ByVal Value As System.DateTime)
                m_strSQRQ = Value
            End Set
        End Property

        '原因
        Public Property YY() As String
            Get
                YY = m_strYY
            End Get
            Set(ByVal Value As String)
                m_strYY = Value
            End Set
        End Property

        '组织代码
        Public Property ZZDM() As String
            Get
                ZZDM = m_strZZDM
            End Get
            Set(ByVal Value As String)
                m_strZZDM = Value
            End Set
        End Property

        '组织名称
        Public Property ZZMC() As String
            Get
                ZZMC = m_strZZMC
            End Get
            Set(ByVal Value As String)
                m_strZZMC = Value
            End Set
        End Property

        '职务
        Public Property ZW() As String
            Get
                ZW = m_strZW
            End Get
            Set(ByVal Value As String)
                m_strZW = Value
            End Set
        End Property

        '地点
        Public Property DD() As String
            Get
                DD = m_strDD
            End Get
            Set(ByVal Value As String)
                m_strDD = Value
            End Set
        End Property

        '联系电话
        Public Property LXDH() As String
            Get
                LXDH = m_strLXDH
            End Get
            Set(ByVal Value As String)
                m_strLXDH = Value
            End Set
        End Property

        '开始日期
        Public Property KSRQ() As System.DateTime
            Get
                KSRQ = m_strKSRQ
            End Get
            Set(ByVal Value As System.DateTime)
                m_strKSRQ = Value
            End Set
        End Property

        '结束日期
        Public Property JSRQ() As System.DateTime
            Get
                JSRQ = m_strJSRQ
            End Get
            Set(ByVal Value As System.DateTime)
                m_strJSRQ = Value
            End Set
        End Property


        '天数
        Public Property TS() As Integer
            Get
                TS = m_strTS
            End Get
            Set(ByVal Value As Integer)
                m_strTS = Value
            End Set
        End Property


        '委托工作
        Public Property WTGZ() As String
            Get
                WTGZ = m_strWTGZ
            End Get
            Set(ByVal Value As String)
                m_strWTGZ = Value
            End Set
        End Property



        '----------------------------------------------------------------
        ' 定编人数
        '----------------------------------------------------------------
        Public Property DBRS() As Integer
            Get
                DBRS = m_intDBRS
            End Get
            Set(ByVal Value As Integer)
                m_intDBRS = Value
            End Set
        End Property

    End Class











    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.Common.Utilities
    ' 类名    ：BaseFlowKqglQJDCreator
    '
    ' 功能描述： 
    '     BaseFlow的创建接口实现
    '----------------------------------------------------------------
    Public Class BaseFlowKqglQJDCreator
        Implements Josco.JSOA.Common.Workflow.IBaseFlowCreate

        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
        End Sub

        '----------------------------------------------------------------
        ' 实现接口
        '----------------------------------------------------------------
        Public Function Create(ByVal strFlowType As String) As Josco.JSOA.Common.Workflow.BaseFlowObject _
            Implements Josco.JSOA.Common.Workflow.IBaseFlowCreate.Create

            Try
                Create = New Josco.JSOA.Common.Workflow.BaseFlowKqglQJD
            Catch ex As Exception
                Throw ex
            End Try

        End Function

    End Class

End Namespace

