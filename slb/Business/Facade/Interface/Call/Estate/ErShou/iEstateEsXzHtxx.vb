Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IEstateEsXzHtxx
    '
    ' 功能描述： 
    '     estate_es_xz_htxx.aspx模块调用接口的定义与处理
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateEsXzHtxx
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        '输入参数
        '----------------------------------------------------------------
        Private m_blnAllowNull_I As Boolean            '允许空输入?false-不能,true-能(缺省)

        '----------------------------------------------------------------
        '输出参数
        '----------------------------------------------------------------
        Private m_blnExitMode_O As Boolean             '退出方式：True-确定，False-取消
        Private m_strJYBH_O As String                  '单选时返回
        Private m_strHTBH_O As String                  '单选时返回
        Private m_strWYBS_O As String                  '单选时返回
        Private m_strHTWYBS_O As String                '单选时返回








        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '初始化父类参数
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '初始化输入参数
            m_blnAllowNull_I = True

            '初始化输出参数
            m_blnExitMode_O = False
            m_strJYBH_O = ""
            m_strHTBH_O = ""
            m_strWYBS_O = ""
            m_strHTWYBS_O = ""
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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateEsXzHtxx)
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
        ' oJYBH属性
        '----------------------------------------------------------------
        Public Property oJYBH() As String
            Get
                oJYBH = m_strJYBH_O
            End Get
            Set(ByVal Value As String)
                Try
                    m_strJYBH_O = Value
                Catch ex As Exception
                    m_strJYBH_O = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' oHTBH属性
        '----------------------------------------------------------------
        Public Property oHTBH() As String
            Get
                oHTBH = m_strHTBH_O
            End Get
            Set(ByVal Value As String)
                Try
                    m_strHTBH_O = Value
                Catch ex As Exception
                    m_strHTBH_O = ""
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

        '----------------------------------------------------------------
        ' oHTWYBS属性
        '----------------------------------------------------------------
        Public Property oHTWYBS() As String
            Get
                oHTWYBS = m_strHTWYBS_O
            End Get
            Set(ByVal Value As String)
                Try
                    m_strHTWYBS_O = Value
                Catch ex As Exception
                    m_strHTWYBS_O = ""
                End Try
            End Set
        End Property

    End Class

End Namespace
