Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateRsLuyongMain
    '
    ' 功能描述： 
    '     estate_rs_luyong_main.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateRsLuyongMain
        Implements IDisposable

        '----------------------------------------------------------------
        'hidden textbox
        '----------------------------------------------------------------
        Private m_strhtxtRSLYGLQuery As String                      'htxtRSLYGLQuery
        Private m_strhtxtRSLYGLRows As String                       'htxtRSLYGLRows
        Private m_strhtxtRSLYGLSort As String                       'htxtRSLYGLSort
        Private m_strhtxtRSLYGLSortColumnIndex As String            'htxtRSLYGLSortColumnIndex
        Private m_strhtxtRSLYGLSortType As String                   'htxtRSLYGLSortType
        Private m_strhtxtDivLeftRSLYGL As String                    'htxtDivLeftRSLYGL
        Private m_strhtxtDivTopRSLYGL As String                     'htxtDivTopRSLYGL
        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody

        Private m_strhtxtSessionIdQuery As String                   'htxtSessionIdQuery

        '----------------------------------------------------------------
        'asp:textbox
        '----------------------------------------------------------------
        Private m_strtxtRSLYGLPageIndex As String                   'txtRSLYGLPageIndex
        Private m_strtxtRSLYGLPageSize As String                    'txtRSLYGLPageSize

        Private m_strtxtRSLYGLSearch_WJBT As String                 'txtRSLYGLSearch_WJBT
        Private m_strtxtRSLYGLSearch_JBRQMin As String              'txtRSLYGLSearch_JBRQMin
        Private m_strtxtRSLYGLSearch_JBRQMax As String              'txtRSLYGLSearch_JBRQMax
        Private m_strtxtRSLYGLSearch_QFRQMin As String              'txtRSLYGLSearch_QFRQMin
        Private m_strtxtRSLYGLSearch_QFRQMax As String              'txtRSLYGLSearch_QFRQMax
        Private m_intSelectedIndex_ddlRSLYGLSearch_BLZT As Integer  'ddlRSLYGLSearch_BLZT

        '----------------------------------------------------------------
        'asp:datagrid - grdRSLYGL
        '----------------------------------------------------------------
        Private m_intPageSize_grdRSLYGL As Integer
        Private m_intSelectedIndex_grdRSLYGL As Integer
        Private m_intCurrentPageIndex_grdRSLYGL As Integer










        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            'hidden
            m_strhtxtRSLYGLQuery = ""
            m_strhtxtRSLYGLRows = ""
            m_strhtxtRSLYGLSort = ""
            m_strhtxtRSLYGLSortColumnIndex = ""
            m_strhtxtRSLYGLSortType = ""
            m_strhtxtDivLeftRSLYGL = ""
            m_strhtxtDivTopRSLYGL = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtSessionIdQuery = ""

            'textbox
            m_strtxtRSLYGLPageIndex = ""
            m_strtxtRSLYGLPageSize = ""

            m_strtxtRSLYGLSearch_WJBT = ""
            m_strtxtRSLYGLSearch_JBRQMin = ""
            m_strtxtRSLYGLSearch_JBRQMax = ""
            m_strtxtRSLYGLSearch_QFRQMin = ""
            m_strtxtRSLYGLSearch_QFRQMax = ""
            m_intSelectedIndex_ddlRSLYGLSearch_BLZT = -1

            'datagrid
            m_intPageSize_grdRSLYGL = 0
            m_intCurrentPageIndex_grdRSLYGL = 0
            m_intSelectedIndex_grdRSLYGL = -1

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateRsLuyongMain)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtRSLYGLQuery属性
        '----------------------------------------------------------------
        Public Property htxtRSLYGLQuery() As String
            Get
                htxtRSLYGLQuery = m_strhtxtRSLYGLQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRSLYGLQuery = Value
                Catch ex As Exception
                    m_strhtxtRSLYGLQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRSLYGLRows属性
        '----------------------------------------------------------------
        Public Property htxtRSLYGLRows() As String
            Get
                htxtRSLYGLRows = m_strhtxtRSLYGLRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRSLYGLRows = Value
                Catch ex As Exception
                    m_strhtxtRSLYGLRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRSLYGLSort属性
        '----------------------------------------------------------------
        Public Property htxtRSLYGLSort() As String
            Get
                htxtRSLYGLSort = m_strhtxtRSLYGLSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRSLYGLSort = Value
                Catch ex As Exception
                    m_strhtxtRSLYGLSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRSLYGLSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtRSLYGLSortColumnIndex() As String
            Get
                htxtRSLYGLSortColumnIndex = m_strhtxtRSLYGLSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRSLYGLSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtRSLYGLSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRSLYGLSortType属性
        '----------------------------------------------------------------
        Public Property htxtRSLYGLSortType() As String
            Get
                htxtRSLYGLSortType = m_strhtxtRSLYGLSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRSLYGLSortType = Value
                Catch ex As Exception
                    m_strhtxtRSLYGLSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftRSLYGL属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftRSLYGL() As String
            Get
                htxtDivLeftRSLYGL = m_strhtxtDivLeftRSLYGL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftRSLYGL = Value
                Catch ex As Exception
                    m_strhtxtDivLeftRSLYGL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopRSLYGL属性
        '----------------------------------------------------------------
        Public Property htxtDivTopRSLYGL() As String
            Get
                htxtDivTopRSLYGL = m_strhtxtDivTopRSLYGL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopRSLYGL = Value
                Catch ex As Exception
                    m_strhtxtDivTopRSLYGL = ""
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
        ' txtRSLYGLPageIndex属性
        '----------------------------------------------------------------
        Public Property txtRSLYGLPageIndex() As String
            Get
                txtRSLYGLPageIndex = m_strtxtRSLYGLPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRSLYGLPageIndex = Value
                Catch ex As Exception
                    m_strtxtRSLYGLPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRSLYGLPageSize属性
        '----------------------------------------------------------------
        Public Property txtRSLYGLPageSize() As String
            Get
                txtRSLYGLPageSize = m_strtxtRSLYGLPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRSLYGLPageSize = Value
                Catch ex As Exception
                    m_strtxtRSLYGLPageSize = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' txtRSLYGLSearch_WJBT属性
        '----------------------------------------------------------------
        Public Property txtRSLYGLSearch_WJBT() As String
            Get
                txtRSLYGLSearch_WJBT = m_strtxtRSLYGLSearch_WJBT
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRSLYGLSearch_WJBT = Value
                Catch ex As Exception
                    m_strtxtRSLYGLSearch_WJBT = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRSLYGLSearch_JBRQMin属性
        '----------------------------------------------------------------
        Public Property txtRSLYGLSearch_JBRQMin() As String
            Get
                txtRSLYGLSearch_JBRQMin = m_strtxtRSLYGLSearch_JBRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRSLYGLSearch_JBRQMin = Value
                Catch ex As Exception
                    m_strtxtRSLYGLSearch_JBRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRSLYGLSearch_JBRQMax属性
        '----------------------------------------------------------------
        Public Property txtRSLYGLSearch_JBRQMax() As String
            Get
                txtRSLYGLSearch_JBRQMax = m_strtxtRSLYGLSearch_JBRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRSLYGLSearch_JBRQMax = Value
                Catch ex As Exception
                    m_strtxtRSLYGLSearch_JBRQMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRSLYGLSearch_QFRQMin属性
        '----------------------------------------------------------------
        Public Property txtRSLYGLSearch_QFRQMin() As String
            Get
                txtRSLYGLSearch_QFRQMin = m_strtxtRSLYGLSearch_QFRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRSLYGLSearch_QFRQMin = Value
                Catch ex As Exception
                    m_strtxtRSLYGLSearch_QFRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtRSLYGLSearch_QFRQMax属性
        '----------------------------------------------------------------
        Public Property txtRSLYGLSearch_QFRQMax() As String
            Get
                txtRSLYGLSearch_QFRQMax = m_strtxtRSLYGLSearch_QFRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtRSLYGLSearch_QFRQMax = Value
                Catch ex As Exception
                    m_strtxtRSLYGLSearch_QFRQMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlRSLYGLSearch_BLZT_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlRSLYGLSearch_BLZT_SelectedIndex() As Integer
            Get
                ddlRSLYGLSearch_BLZT_SelectedIndex = m_intSelectedIndex_ddlRSLYGLSearch_BLZT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlRSLYGLSearch_BLZT = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlRSLYGLSearch_BLZT = -1
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' grdRSLYGLPageSize属性
        '----------------------------------------------------------------
        Public Property grdRSLYGLPageSize() As Integer
            Get
                grdRSLYGLPageSize = m_intPageSize_grdRSLYGL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdRSLYGL = Value
                Catch ex As Exception
                    m_intPageSize_grdRSLYGL = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdRSLYGLCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdRSLYGLCurrentPageIndex() As Integer
            Get
                grdRSLYGLCurrentPageIndex = m_intCurrentPageIndex_grdRSLYGL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdRSLYGL = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdRSLYGL = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdRSLYGLSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdRSLYGLSelectedIndex() As Integer
            Get
                grdRSLYGLSelectedIndex = m_intSelectedIndex_grdRSLYGL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdRSLYGL = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdRSLYGL = -1
                End Try
            End Set
        End Property

    End Class

End Namespace

