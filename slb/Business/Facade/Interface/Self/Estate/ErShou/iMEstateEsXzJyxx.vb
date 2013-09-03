Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateEsXzJyxx
    '
    ' 功能描述： 
    '     estate_es_xz_jyxx.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsXzJyxx
        Implements IDisposable

        Private m_strhtxtDivLeftJYXX As String                      'htxtDivLeftJYXX
        Private m_strhtxtDivTopJYXX As String                       'htxtDivTopJYXX
        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody

        Private m_strhtxtJYXXQuery As String                        'htxtJYXXQuery
        Private m_strhtxtJYXXRows As String                         'htxtJYXXRows
        Private m_strhtxtJYXXSort As String                         'htxtJYXXSort
        Private m_strhtxtJYXXSortColumnIndex As String              'htxtJYXXSortColumnIndex
        Private m_strhtxtJYXXSortType As String                     'htxtJYXXSortType

        Private m_strhtxtSessionIdQuery As String                   'htxtSessionIdQuery

        Private m_strtxtJYXXPageIndex As String                     'txtJYXXPageIndex
        Private m_strtxtJYXXPageSize As String                      'txtJYXXPageSize

        Private m_strtxtJYXXSearch_JYBH As String                   'txtJYXXSearch_JYBH
        Private m_strtxtJYXXSearch_KHMC As String                   'txtJYXXSearch_KHMC
        Private m_strtxtJYXXSearch_YZMC As String                   'txtJYXXSearch_YZMC
        Private m_strtxtJYXXSearch_WYDZ As String                   'txtJYXXSearch_WYDZ
        Private m_strtxtJYXXSearch_JYRQMin As String                'txtJYXXSearch_JYRQMin
        Private m_strtxtJYXXSearch_JYRQMax As String                'txtJYXXSearch_JYRQMax
        Private m_strtxtJYXXSearch_HTRQMin As String                'txtJYXXSearch_HTRQMin
        Private m_strtxtJYXXSearch_HTRQMax As String                'txtJYXXSearch_HTRQMax

        '----------------------------------------------------------------
        'asp:datagrid - grdJYXX
        '----------------------------------------------------------------
        Private m_intPageSize_grdJYXX As Integer
        Private m_intSelectedIndex_grdJYXX As Integer
        Private m_intCurrentPageIndex_grdJYXX As Integer











        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftJYXX = ""
            m_strhtxtDivTopJYXX = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtJYXXQuery = ""
            m_strhtxtJYXXRows = ""
            m_strhtxtJYXXSort = ""
            m_strhtxtJYXXSortColumnIndex = ""
            m_strhtxtJYXXSortType = ""

            m_strhtxtSessionIdQuery = ""

            m_strtxtJYXXPageIndex = ""
            m_strtxtJYXXPageSize = ""

            m_strtxtJYXXSearch_JYBH = ""
            m_strtxtJYXXSearch_KHMC = ""
            m_strtxtJYXXSearch_YZMC = ""
            m_strtxtJYXXSearch_WYDZ = ""
            m_strtxtJYXXSearch_JYRQMin = ""
            m_strtxtJYXXSearch_JYRQMax = ""
            m_strtxtJYXXSearch_HTRQMin = ""
            m_strtxtJYXXSearch_HTRQMax = ""

            m_intPageSize_grdJYXX = 0
            m_intCurrentPageIndex_grdJYXX = 0
            m_intSelectedIndex_grdJYXX = -1

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsXzJyxx)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtJYXXQuery属性
        '----------------------------------------------------------------
        Public Property htxtJYXXQuery() As String
            Get
                htxtJYXXQuery = m_strhtxtJYXXQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJYXXQuery = Value
                Catch ex As Exception
                    m_strhtxtJYXXQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJYXXRows属性
        '----------------------------------------------------------------
        Public Property htxtJYXXRows() As String
            Get
                htxtJYXXRows = m_strhtxtJYXXRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJYXXRows = Value
                Catch ex As Exception
                    m_strhtxtJYXXRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJYXXSort属性
        '----------------------------------------------------------------
        Public Property htxtJYXXSort() As String
            Get
                htxtJYXXSort = m_strhtxtJYXXSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJYXXSort = Value
                Catch ex As Exception
                    m_strhtxtJYXXSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJYXXSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtJYXXSortColumnIndex() As String
            Get
                htxtJYXXSortColumnIndex = m_strhtxtJYXXSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJYXXSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtJYXXSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtJYXXSortType属性
        '----------------------------------------------------------------
        Public Property htxtJYXXSortType() As String
            Get
                htxtJYXXSortType = m_strhtxtJYXXSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtJYXXSortType = Value
                Catch ex As Exception
                    m_strhtxtJYXXSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftJYXX属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftJYXX() As String
            Get
                htxtDivLeftJYXX = m_strhtxtDivLeftJYXX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftJYXX = Value
                Catch ex As Exception
                    m_strhtxtDivLeftJYXX = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopJYXX属性
        '----------------------------------------------------------------
        Public Property htxtDivTopJYXX() As String
            Get
                htxtDivTopJYXX = m_strhtxtDivTopJYXX
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopJYXX = Value
                Catch ex As Exception
                    m_strhtxtDivTopJYXX = ""
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
        ' txtJYXXPageIndex属性
        '----------------------------------------------------------------
        Public Property txtJYXXPageIndex() As String
            Get
                txtJYXXPageIndex = m_strtxtJYXXPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYXXPageIndex = Value
                Catch ex As Exception
                    m_strtxtJYXXPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJYXXPageSize属性
        '----------------------------------------------------------------
        Public Property txtJYXXPageSize() As String
            Get
                txtJYXXPageSize = m_strtxtJYXXPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYXXPageSize = Value
                Catch ex As Exception
                    m_strtxtJYXXPageSize = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtJYXXSearch_JYBH属性
        '----------------------------------------------------------------
        Public Property txtJYXXSearch_JYBH() As String
            Get
                txtJYXXSearch_JYBH = m_strtxtJYXXSearch_JYBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYXXSearch_JYBH = Value
                Catch ex As Exception
                    m_strtxtJYXXSearch_JYBH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJYXXSearch_KHMC属性
        '----------------------------------------------------------------
        Public Property txtJYXXSearch_KHMC() As String
            Get
                txtJYXXSearch_KHMC = m_strtxtJYXXSearch_KHMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYXXSearch_KHMC = Value
                Catch ex As Exception
                    m_strtxtJYXXSearch_KHMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJYXXSearch_YZMC属性
        '----------------------------------------------------------------
        Public Property txtJYXXSearch_YZMC() As String
            Get
                txtJYXXSearch_YZMC = m_strtxtJYXXSearch_YZMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYXXSearch_YZMC = Value
                Catch ex As Exception
                    m_strtxtJYXXSearch_YZMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJYXXSearch_WYDZ属性
        '----------------------------------------------------------------
        Public Property txtJYXXSearch_WYDZ() As String
            Get
                txtJYXXSearch_WYDZ = m_strtxtJYXXSearch_WYDZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYXXSearch_WYDZ = Value
                Catch ex As Exception
                    m_strtxtJYXXSearch_WYDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJYXXSearch_JYRQMin属性
        '----------------------------------------------------------------
        Public Property txtJYXXSearch_JYRQMin() As String
            Get
                txtJYXXSearch_JYRQMin = m_strtxtJYXXSearch_JYRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYXXSearch_JYRQMin = Value
                Catch ex As Exception
                    m_strtxtJYXXSearch_JYRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJYXXSearch_JYRQMax属性
        '----------------------------------------------------------------
        Public Property txtJYXXSearch_JYRQMax() As String
            Get
                txtJYXXSearch_JYRQMax = m_strtxtJYXXSearch_JYRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYXXSearch_JYRQMax = Value
                Catch ex As Exception
                    m_strtxtJYXXSearch_JYRQMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJYXXSearch_HTRQMin属性
        '----------------------------------------------------------------
        Public Property txtJYXXSearch_HTRQMin() As String
            Get
                txtJYXXSearch_HTRQMin = m_strtxtJYXXSearch_HTRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYXXSearch_HTRQMin = Value
                Catch ex As Exception
                    m_strtxtJYXXSearch_HTRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJYXXSearch_HTRQMax属性
        '----------------------------------------------------------------
        Public Property txtJYXXSearch_HTRQMax() As String
            Get
                txtJYXXSearch_HTRQMax = m_strtxtJYXXSearch_HTRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYXXSearch_HTRQMax = Value
                Catch ex As Exception
                    m_strtxtJYXXSearch_HTRQMax = ""
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' grdJYXXPageSize属性
        '----------------------------------------------------------------
        Public Property grdJYXXPageSize() As Integer
            Get
                grdJYXXPageSize = m_intPageSize_grdJYXX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdJYXX = Value
                Catch ex As Exception
                    m_intPageSize_grdJYXX = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdJYXXCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdJYXXCurrentPageIndex() As Integer
            Get
                grdJYXXCurrentPageIndex = m_intCurrentPageIndex_grdJYXX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdJYXX = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdJYXX = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdJYXXSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdJYXXSelectedIndex() As Integer
            Get
                grdJYXXSelectedIndex = m_intSelectedIndex_grdJYXX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdJYXX = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdJYXX = -1
                End Try
            End Set
        End Property

    End Class

End Namespace
