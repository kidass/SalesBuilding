Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IEstateRsRenyuanJiagou_Rela
    '
    ' 功能描述： 
    '     estate_rs_renyuanjiagou_rela.aspx模块调用接口的定义与处理
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateRsRenyuanJiagou_Rela
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        'QueryString Parameters
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '输入参数
        '----------------------------------------------------------------
        Private m_intMode_I As Integer       '0-一般显示，1-选择节点
        Private m_strTime_I As String        '检测时间
        'zengxianglin 2008-10-14
        Private m_blnAllowNull_I As Boolean  'true-允许，False-不允许
        'zengxianglin 2008-10-14
        '----------------------------------------------------------------
        '输出参数
        '----------------------------------------------------------------
        Private m_blnExitMode_O As Boolean 'True-选定返回，false-取消/关闭
        Private m_strRYDM_O As String      '返回的人员代码
        Private m_strWYBS_O As String      '返回的组织架构唯一标识
        Private m_strRYZM_O As String      '返回的人员真名












        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '初始化父类参数
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '初始化输入参数
            m_intMode_I = 0
            'zengxianglin 2008-10-14
            m_blnAllowNull_I = False
            'zengxianglin 2008-10-14

            '初始化输出参数
            m_blnExitMode_O = False
            m_strRYDM_O = ""
            m_strWYBS_O = ""
            m_strRYZM_O = ""

        End Sub

        '----------------------------------------------------------------
        ' 重载父类的析构函数
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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateRsRenyuanJiagou_Rela)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub









        'zengxianglin 2008-10-14
        Public Property iAllowNull() As Boolean
            Get
                iAllowNull = m_blnAllowNull_I
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnAllowNull_I = Value
                Catch ex As Exception
                    m_blnAllowNull_I = False
                End Try
            End Set
        End Property
        'zengxianglin 2008-10-14

        Public Property iMode() As Integer
            Get
                iMode = m_intMode_I
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intMode_I = Value
                Catch ex As Exception
                    m_intMode_I = 0
                End Try
            End Set
        End Property

        Public Property iTime() As String
            Get
                iTime = m_strTime_I
            End Get
            Set(ByVal Value As String)
                Try
                    m_strTime_I = Value
                Catch ex As Exception
                    m_strTime_I = ""
                End Try
            End Set
        End Property









        Public Property oExitMode() As Boolean
            Get
                oExitMode = m_blnExitMode_O
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_blnExitMode_O = Value
                Catch ex As Exception
                    m_blnExitMode_O = False
                End Try
            End Set
        End Property

        Public Property oRYDM() As String
            Get
                oRYDM = m_strRYDM_O
            End Get
            Set(ByVal Value As String)
                Try
                    m_strRYDM_O = Value
                Catch ex As Exception
                    m_strRYDM_O = ""
                End Try
            End Set
        End Property

        Public Property oRYZM() As String
            Get
                oRYZM = m_strRYZM_O
            End Get
            Set(ByVal Value As String)
                Try
                    m_strRYZM_O = Value
                Catch ex As Exception
                    m_strRYZM_O = ""
                End Try
            End Set
        End Property

        Public Property oWYBS() As String
            Get
                oWYBS = m_strWYBS_O
            End Get
            Set(ByVal Value As String)
                Try
                    m_strWYBS_O = Value
                Catch ex As Exception
                    m_strWYBS_O = ""
                End Try
            End Set
        End Property

    End Class

End Namespace
