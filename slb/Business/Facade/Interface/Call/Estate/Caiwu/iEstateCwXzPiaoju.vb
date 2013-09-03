Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IEstateCwXzPiaoju
    '
    ' 功能描述： 
    '     estate_cw_xz_piaoju.aspx模块调用接口的定义与处理
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateCwXzPiaoju
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        'zengxianglin 2008-11-22
        Public Enum enumYKPZ
            None = 0
            Ykpz = 1
            Wkpz = 2
        End Enum
        'zengxianglin 2008-11-22

        '----------------------------------------------------------------
        'QueryString Parameters
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '输入参数
        '----------------------------------------------------------------
        Private m_blnAllowNull_I As Boolean            '允许空输入?false-不能,true-能(缺省)
        Private m_strYWBH_I As String                  '业务编号
        'zengxianglin 2008-11-22
        Private m_objenumYKPZ As enumYKPZ              '已开凭证
        'zengxianglin 2008-11-22


        '----------------------------------------------------------------
        '输出参数
        '----------------------------------------------------------------
        Private m_blnExitMode_O As Boolean             '退出方式：True-确定，False-取消
        Private m_strWYBS_O As String                  '单选时返回














        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '初始化父类参数
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '初始化输入参数
            m_blnAllowNull_I = True
            m_strYWBH_I = ""
            'zengxianglin 2008-11-22
            m_objenumYKPZ = enumYKPZ.None
            'zengxianglin 2008-11-22

            '初始化输出参数
            m_blnExitMode_O = False
            m_strWYBS_O = ""

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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateCwXzPiaoju)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub









        '----------------------------------------------------------------
        ' iAllowNull属性
        '----------------------------------------------------------------
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

        '----------------------------------------------------------------
        ' iYWBH属性
        '----------------------------------------------------------------
        Public Property iYWBH() As String
            Get
                iYWBH = m_strYWBH_I
            End Get
            Set(ByVal Value As String)
                Try
                    m_strYWBH_I = Value
                Catch ex As Exception
                    m_strYWBH_I = ""
                End Try
            End Set
        End Property

        'zengxianglin 2008-11-22
        '----------------------------------------------------------------
        ' iYkpz属性
        '----------------------------------------------------------------
        Public Property iYkpz() As enumYKPZ
            Get
                iYkpz = m_objenumYKPZ
            End Get
            Set(ByVal Value As enumYKPZ)
                Try
                    m_objenumYKPZ = Value
                Catch ex As Exception
                    m_objenumYKPZ = enumYKPZ.None
                End Try
            End Set
        End Property
        'zengxianglin 2008-11-22










        '----------------------------------------------------------------
        ' oExitMode属性
        '----------------------------------------------------------------
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

        '----------------------------------------------------------------
        ' oWYBS属性
        '----------------------------------------------------------------
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
