Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateEsJyndjhInfo
    '
    ' 功能描述： 
    '     estate_es_jyndjh_info.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsJyndjhInfo
        Implements IDisposable

        Private m_strhtxtDivLeftNDJH As String                        'htxtDivLeftNDJH
        Private m_strhtxtDivTopNDJH As String                         'htxtDivTopNDJH
        Private m_strhtxtDivLeftBody As String                        'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                         'htxtDivTopBody

        Private m_strhtxtNDJHQuery As String                          'htxtNDJHQuery
        Private m_strhtxtNDJHRows As String                           'htxtNDJHRows
        Private m_strhtxtNDJHSort As String                           'htxtNDJHSort
        Private m_strhtxtNDJHSortColumnIndex As String                'htxtNDJHSortColumnIndex
        Private m_strhtxtNDJHSortType As String                       'htxtNDJHSortType

        Private m_strhtxtSessionIdBuffer As String                    'htxtSessionIdBuffer
        Private m_strhtxtSessionIdQuery As String                     'htxtSessionIdQuery

        Private m_strtxtNDJHPageIndex As String                       'txtNDJHPageIndex
        Private m_strtxtNDJHPageSize As String                        'txtNDJHPageSize

        '----------------------------------------------------------------
        'asp:datagrid - grdNDJH
        '----------------------------------------------------------------
        Private m_intPageSize_grdNDJH As Integer
        Private m_intSelectedIndex_grdNDJH As Integer
        Private m_intCurrentPageIndex_grdNDJH As Integer











        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftNDJH = ""
            m_strhtxtDivTopNDJH = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtNDJHQuery = ""
            m_strhtxtNDJHRows = ""
            m_strhtxtNDJHSort = ""
            m_strhtxtNDJHSortColumnIndex = ""
            m_strhtxtNDJHSortType = ""

            m_strhtxtSessionIdBuffer = ""
            m_strhtxtSessionIdQuery = ""

            m_strtxtNDJHPageIndex = ""
            m_strtxtNDJHPageSize = ""

            m_intPageSize_grdNDJH = 0
            m_intCurrentPageIndex_grdNDJH = 0
            m_intSelectedIndex_grdNDJH = -1
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsJyndjhInfo)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtNDJHQuery属性
        '----------------------------------------------------------------
        Public Property htxtNDJHQuery() As String
            Get
                htxtNDJHQuery = m_strhtxtNDJHQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtNDJHQuery = Value
                Catch ex As Exception
                    m_strhtxtNDJHQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtNDJHRows属性
        '----------------------------------------------------------------
        Public Property htxtNDJHRows() As String
            Get
                htxtNDJHRows = m_strhtxtNDJHRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtNDJHRows = Value
                Catch ex As Exception
                    m_strhtxtNDJHRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtNDJHSort属性
        '----------------------------------------------------------------
        Public Property htxtNDJHSort() As String
            Get
                htxtNDJHSort = m_strhtxtNDJHSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtNDJHSort = Value
                Catch ex As Exception
                    m_strhtxtNDJHSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtNDJHSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtNDJHSortColumnIndex() As String
            Get
                htxtNDJHSortColumnIndex = m_strhtxtNDJHSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtNDJHSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtNDJHSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtNDJHSortType属性
        '----------------------------------------------------------------
        Public Property htxtNDJHSortType() As String
            Get
                htxtNDJHSortType = m_strhtxtNDJHSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtNDJHSortType = Value
                Catch ex As Exception
                    m_strhtxtNDJHSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftNDJH属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftNDJH() As String
            Get
                htxtDivLeftNDJH = m_strhtxtDivLeftNDJH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftNDJH = Value
                Catch ex As Exception
                    m_strhtxtDivLeftNDJH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopNDJH属性
        '----------------------------------------------------------------
        Public Property htxtDivTopNDJH() As String
            Get
                htxtDivTopNDJH = m_strhtxtDivTopNDJH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopNDJH = Value
                Catch ex As Exception
                    m_strhtxtDivTopNDJH = ""
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
        ' txtNDJHPageIndex属性
        '----------------------------------------------------------------
        Public Property txtNDJHPageIndex() As String
            Get
                txtNDJHPageIndex = m_strtxtNDJHPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtNDJHPageIndex = Value
                Catch ex As Exception
                    m_strtxtNDJHPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtNDJHPageSize属性
        '----------------------------------------------------------------
        Public Property txtNDJHPageSize() As String
            Get
                txtNDJHPageSize = m_strtxtNDJHPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtNDJHPageSize = Value
                Catch ex As Exception
                    m_strtxtNDJHPageSize = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' grdNDJHPageSize属性
        '----------------------------------------------------------------
        Public Property grdNDJHPageSize() As Integer
            Get
                grdNDJHPageSize = m_intPageSize_grdNDJH
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdNDJH = Value
                Catch ex As Exception
                    m_intPageSize_grdNDJH = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdNDJHCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdNDJHCurrentPageIndex() As Integer
            Get
                grdNDJHCurrentPageIndex = m_intCurrentPageIndex_grdNDJH
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdNDJH = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdNDJH = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdNDJHSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdNDJHSelectedIndex() As Integer
            Get
                grdNDJHSelectedIndex = m_intSelectedIndex_grdNDJH
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdNDJH = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdNDJH = -1
                End Try
            End Set
        End Property

    End Class

End Namespace
