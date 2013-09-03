Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IEstateEsHetongZlQry
    '
    ' 功能描述： 
    '     estate_es_hetongzl_qry.aspx模块调用接口的定义与处理
    '----------------------------------------------------------------
    <Serializable()> Public Class IEstateEsHetongZlQry
        Inherits Josco.JsKernal.BusinessFacade.ICallInterface

        '----------------------------------------------------------------
        'QueryString Parameters
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '输入参数
        '----------------------------------------------------------------

        '----------------------------------------------------------------
        '输出参数
        '----------------------------------------------------------------
        Private m_blnExitMode_O As Boolean
        Private m_strQuery_DG_O As String
        Private m_strQuery_HT_O As String
        Private m_strQuery_DY_O As String
        Private m_strQuery_RY_O As String











        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '初始化父类参数
            MyBase.iInterfaceType = Josco.JsKernal.BusinessFacade.ICallInterface.enumInterfaceType.InputAndOutput

            '初始化输入参数

            '初始化输出参数
            Me.m_blnExitMode_O = False
            Me.m_strQuery_DG_O = ""
            Me.m_strQuery_DY_O = ""
            Me.m_strQuery_HT_O = ""
            Me.m_strQuery_RY_O = ""
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
        Public Overloads Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IEstateEsHetongZlQry)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub










        '----------------------------------------------------------------
        ' oExitMode属性
        '----------------------------------------------------------------
        Public Property oExitMode() As Boolean
            Get
                oExitMode = Me.m_blnExitMode_O
            End Get
            Set(ByVal Value As Boolean)
                Try
                    Me.m_blnExitMode_O = Value
                Catch ex As Exception
                    Me.m_blnExitMode_O = False
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' oQuery_DG属性
        '----------------------------------------------------------------
        Public Property oQuery_DG() As String
            Get
                oQuery_DG = Me.m_strQuery_DG_O
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strQuery_DG_O = Value
                Catch ex As Exception
                    Me.m_strQuery_DG_O = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' oQuery_HT属性
        '----------------------------------------------------------------
        Public Property oQuery_HT() As String
            Get
                oQuery_HT = Me.m_strQuery_HT_O
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strQuery_HT_O = Value
                Catch ex As Exception
                    Me.m_strQuery_HT_O = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' oQuery_DY属性
        '----------------------------------------------------------------
        Public Property oQuery_DY() As String
            Get
                oQuery_DY = Me.m_strQuery_DY_O
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strQuery_DY_O = Value
                Catch ex As Exception
                    Me.m_strQuery_DY_O = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' oQuery_RY属性
        '----------------------------------------------------------------
        Public Property oQuery_RY() As String
            Get
                oQuery_RY = Me.m_strQuery_RY_O
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strQuery_RY_O = Value
                Catch ex As Exception
                    Me.m_strQuery_RY_O = ""
                End Try
            End Set
        End Property

    End Class

End Namespace
