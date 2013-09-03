Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRsBbEsLdjnbb
    '
    ' 功能描述： 
    '     estate_rs_bb_esldjnbb.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsBbEsLdjnbb
        Implements IDisposable

        '----------------------------------------------------------------
        Private m_strhtxtQuery As String                          'htxtQuery
        Private m_strhtxtRows As String                           'htxtRows
        Private m_strhtxtSort As String                           'htxtSort
        Private m_strhtxtSortColumnIndex As String                'htxtSortColumnIndex
        Private m_strhtxtSortType As String                       'htxtSortType
        '----------------------------------------------------------------
        Private m_strhtxtDivLeftContent As String                 'htxtDivLeftContent
        Private m_strhtxtDivTopContent As String                  'htxtDivTopContent
        Private m_strhtxtDivLeftBody As String                    'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                     'htxtDivTopBody
        '----------------------------------------------------------------
        Private m_strtxtPageIndex As String                       'txtPageIndex
        Private m_strtxtPageSize As String                        'txtPageSize
        '----------------------------------------------------------------
        Private m_strtxtND As String                              'txtND
        '----------------------------------------------------------------
        Private m_strhtxtSessionIdQuery As String                 'htxtSessionIdQuery
        Private m_strhtxtSessionIdBuffer As String                'htxtSessionIdBuffer
        '----------------------------------------------------------------
        Private m_intPageSize_grdContent As Integer
        Private m_intSelectedIndex_grdContent As Integer
        Private m_intCurrentPageIndex_grdContent As Integer









        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            '----------------------------------------------------------------
            m_strhtxtQuery = ""
            m_strhtxtRows = ""
            m_strhtxtSort = ""
            m_strhtxtSortColumnIndex = ""
            m_strhtxtSortType = ""
            '----------------------------------------------------------------
            m_strhtxtDivLeftContent = ""
            m_strhtxtDivTopContent = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""
            '----------------------------------------------------------------
            m_strtxtPageIndex = ""
            m_strtxtPageSize = ""
            '----------------------------------------------------------------
            m_strtxtND = ""
            '----------------------------------------------------------------
            m_strhtxtSessionIdQuery = ""
            m_strhtxtSessionIdBuffer = ""
            '----------------------------------------------------------------
            m_intPageSize_grdContent = 0
            m_intSelectedIndex_grdContent = -1
            m_intCurrentPageIndex_grdContent = 0

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsBbEsLdjnbb)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub








        '----------------------------------------------------------------
        ' htxtSessionIdQuery属性
        '----------------------------------------------------------------
        Public Property htxtSessionIdQuery() As String
            Get
                htxtSessionIdQuery = m_strhtxtSessionIdQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIdQuery = Value
                Catch ex As Exception
                    m_strhtxtSessionIdQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionIdBuffer属性
        '----------------------------------------------------------------
        Public Property htxtSessionIdBuffer() As String
            Get
                htxtSessionIdBuffer = m_strhtxtSessionIdBuffer
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIdBuffer = Value
                Catch ex As Exception
                    m_strhtxtSessionIdBuffer = ""
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' htxtQuery属性
        '----------------------------------------------------------------
        Public Property htxtQuery() As String
            Get
                htxtQuery = m_strhtxtQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtQuery = Value
                Catch ex As Exception
                    m_strhtxtQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRows属性
        '----------------------------------------------------------------
        Public Property htxtRows() As String
            Get
                htxtRows = m_strhtxtRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRows = Value
                Catch ex As Exception
                    m_strhtxtRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSort属性
        '----------------------------------------------------------------
        Public Property htxtSort() As String
            Get
                htxtSort = m_strhtxtSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSort = Value
                Catch ex As Exception
                    m_strhtxtSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtSortColumnIndex() As String
            Get
                htxtSortColumnIndex = m_strhtxtSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSortType属性
        '----------------------------------------------------------------
        Public Property htxtSortType() As String
            Get
                htxtSortType = m_strhtxtSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSortType = Value
                Catch ex As Exception
                    m_strhtxtSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftContent属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftContent() As String
            Get
                htxtDivLeftContent = m_strhtxtDivLeftContent
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftContent = Value
                Catch ex As Exception
                    m_strhtxtDivLeftContent = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopContent属性
        '----------------------------------------------------------------
        Public Property htxtDivTopContent() As String
            Get
                htxtDivTopContent = m_strhtxtDivTopContent
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopContent = Value
                Catch ex As Exception
                    m_strhtxtDivTopContent = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftBody属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftBody() As String
            Get
                htxtDivLeftBody = m_strhtxtDivLeftBody
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftBody = Value
                Catch ex As Exception
                    m_strhtxtDivLeftBody = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopBody属性
        '----------------------------------------------------------------
        Public Property htxtDivTopBody() As String
            Get
                htxtDivTopBody = m_strhtxtDivTopBody
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopBody = Value
                Catch ex As Exception
                    m_strhtxtDivTopBody = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtPageIndex属性
        '----------------------------------------------------------------
        Public Property txtPageIndex() As String
            Get
                txtPageIndex = m_strtxtPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPageIndex = Value
                Catch ex As Exception
                    m_strtxtPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPageSize属性
        '----------------------------------------------------------------
        Public Property txtPageSize() As String
            Get
                txtPageSize = m_strtxtPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtPageSize = Value
                Catch ex As Exception
                    m_strtxtPageSize = ""
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' grdContentPageSize属性
        '----------------------------------------------------------------
        Public Property grdContentPageSize() As Integer
            Get
                grdContentPageSize = m_intPageSize_grdContent
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdContent = Value
                Catch ex As Exception
                    m_intPageSize_grdContent = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdContentCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdContentCurrentPageIndex() As Integer
            Get
                grdContentCurrentPageIndex = m_intCurrentPageIndex_grdContent
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdContent = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdContent = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdContentSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdContentSelectedIndex() As Integer
            Get
                grdContentSelectedIndex = m_intSelectedIndex_grdContent
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdContent = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdContent = 0
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtND属性
        '----------------------------------------------------------------
        Public Property txtND() As String
            Get
                txtND = m_strtxtND
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtND = Value
                Catch ex As Exception
                    m_strtxtND = ""
                End Try
            End Set
        End Property

    End Class

End Namespace
