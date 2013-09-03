Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateEsHetongZlQry
    '
    ' 功能描述： 
    '     estate_es_hetongzl_qry.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsHetongZlQry
        Implements IDisposable

        '----------------------------------------------------------------
        ' 模块属性
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftBody As String                'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                 'htxtDivTopBody
        Private m_strhtxtDivLeftMain As String                'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String                 'htxtDivTopMain











        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            Me.m_strhtxtDivLeftBody = ""
            Me.m_strhtxtDivTopBody = ""
            Me.m_strhtxtDivLeftMain = ""
            Me.m_strhtxtDivTopMain = ""
        End Sub

        '----------------------------------------------------------------
        ' 虚拟析构函数
        '----------------------------------------------------------------
        Public Sub Dispose() Implements System.IDisposable.Dispose
            Dispose(True)
        End Sub

        '----------------------------------------------------------------
        ' 释放本身资源
        '----------------------------------------------------------------
        Protected Sub Dispose(ByVal disposing As Boolean)
            If (Not disposing) Then
                Exit Sub
            End If
        End Sub

        '----------------------------------------------------------------
        ' 安全释放本身资源
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsHetongZlQry)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub













        '----------------------------------------------------------------
        ' htxtDivLeftBody属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftBody() As String
            Get
                htxtDivLeftBody = Me.m_strhtxtDivLeftBody
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtDivLeftBody = Value
                Catch ex As Exception
                    Me.m_strhtxtDivLeftBody = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopBody属性
        '----------------------------------------------------------------
        Public Property htxtDivTopBody() As String
            Get
                htxtDivTopBody = Me.m_strhtxtDivTopBody
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtDivTopBody = Value
                Catch ex As Exception
                    Me.m_strhtxtDivTopBody = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftMain属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftMain() As String
            Get
                htxtDivLeftMain = Me.m_strhtxtDivLeftMain
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtDivLeftMain = Value
                Catch ex As Exception
                    Me.m_strhtxtDivLeftMain = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopMain属性
        '----------------------------------------------------------------
        Public Property htxtDivTopMain() As String
            Get
                htxtDivTopMain = Me.m_strhtxtDivTopMain
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtDivTopMain = Value
                Catch ex As Exception
                    Me.m_strhtxtDivTopMain = ""
                End Try
            End Set
        End Property

    End Class

End Namespace
