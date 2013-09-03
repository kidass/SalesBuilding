Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateEsYjjt
    '
    ' 功能描述： 
    '     estate_es_yjjt.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsYjjt
        Implements IDisposable

        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody
        Private m_strhtxtDivLeftYJ As String                        'htxtDivLeftYJ
        Private m_strhtxtDivTopYJ As String                         'htxtDivTopYJ

        Private m_strhtxtYJQuery As String                          'htxtYJQuery
        Private m_strhtxtYJRows As String                           'htxtYJRows
        Private m_strhtxtYJSort As String                           'htxtYJSort
        Private m_strhtxtYJSortColumnIndex As String                'htxtYJSortColumnIndex
        Private m_strhtxtYJSortType As String                       'htxtYJSortType

        Private m_strhtxtSessionIdQueryYJ As String                 'htxtSessionIdQueryYJ

        Private m_strtxtYJPageIndex As String                       'txtYJPageIndex
        Private m_strtxtYJPageSize As String                        'txtYJPageSize

        Private m_strtxtYJSearch_RYDM As String                     'txtYJSearch_RYDM
        Private m_strtxtYJSearch_RYMC As String                     'txtYJSearch_RYMC
        Private m_strtxtYJSearch_JYNYMin As String                  'txtYJSearch_JYNYMin
        Private m_strtxtYJSearch_JYNYMax As String                  'txtYJSearch_JYNYMax
        Private m_strtxtYJSearch_JANYMin As String                  'txtYJSearch_JANYMin
        Private m_strtxtYJSearch_JANYMax As String                  'txtYJSearch_JANYMax

        Private m_intPageSize_grdYJ As Integer
        Private m_intSelectedIndex_grdYJ As Integer
        Private m_intCurrentPageIndex_grdYJ As Integer











        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            Me.m_strhtxtDivLeftYJ = ""
            Me.m_strhtxtDivTopYJ = ""
            Me.m_strhtxtDivLeftBody = ""
            Me.m_strhtxtDivTopBody = ""

            Me.m_strhtxtYJQuery = ""
            Me.m_strhtxtYJRows = ""
            Me.m_strhtxtYJSort = ""
            Me.m_strhtxtYJSortColumnIndex = ""
            Me.m_strhtxtYJSortType = ""

            Me.m_strhtxtSessionIdQueryYJ = ""

            Me.m_strtxtYJPageIndex = ""
            Me.m_strtxtYJPageSize = ""

            Me.m_strtxtYJSearch_RYDM = ""
            Me.m_strtxtYJSearch_RYMC = ""
            Me.m_strtxtYJSearch_JYNYMax = ""
            Me.m_strtxtYJSearch_JYNYMin = ""
            Me.m_strtxtYJSearch_JANYMin = ""
            Me.m_strtxtYJSearch_JANYMax = ""

            Me.m_intPageSize_grdYJ = 0
            Me.m_intCurrentPageIndex_grdYJ = 0
            Me.m_intSelectedIndex_grdYJ = -1
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsYjjt)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtYJQuery属性
        '----------------------------------------------------------------
        Public Property htxtYJQuery() As String
            Get
                htxtYJQuery = Me.m_strhtxtYJQuery
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtYJQuery = Value
                Catch ex As Exception
                    Me.m_strhtxtYJQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtYJRows属性
        '----------------------------------------------------------------
        Public Property htxtYJRows() As String
            Get
                htxtYJRows = Me.m_strhtxtYJRows
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtYJRows = Value
                Catch ex As Exception
                    Me.m_strhtxtYJRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtYJSort属性
        '----------------------------------------------------------------
        Public Property htxtYJSort() As String
            Get
                htxtYJSort = Me.m_strhtxtYJSort
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtYJSort = Value
                Catch ex As Exception
                    Me.m_strhtxtYJSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtYJSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtYJSortColumnIndex() As String
            Get
                htxtYJSortColumnIndex = Me.m_strhtxtYJSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtYJSortColumnIndex = Value
                Catch ex As Exception
                    Me.m_strhtxtYJSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtYJSortType属性
        '----------------------------------------------------------------
        Public Property htxtYJSortType() As String
            Get
                htxtYJSortType = Me.m_strhtxtYJSortType
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtYJSortType = Value
                Catch ex As Exception
                    Me.m_strhtxtYJSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftYJ属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftYJ() As String
            Get
                htxtDivLeftYJ = Me.m_strhtxtDivLeftYJ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtDivLeftYJ = Value
                Catch ex As Exception
                    Me.m_strhtxtDivLeftYJ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopYJ属性
        '----------------------------------------------------------------
        Public Property htxtDivTopYJ() As String
            Get
                htxtDivTopYJ = Me.m_strhtxtDivTopYJ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtDivTopYJ = Value
                Catch ex As Exception
                    Me.m_strhtxtDivTopYJ = ""
                End Try
            End Set
        End Property

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
        ' htxtSessionIdQueryYJ属性
        '----------------------------------------------------------------
        Public Property htxtSessionIdQueryYJ() As String
            Get
                htxtSessionIdQueryYJ = Me.m_strhtxtSessionIdQueryYJ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtSessionIdQueryYJ = Value
                Catch ex As Exception
                    Me.m_strhtxtSessionIdQueryYJ = ""
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' txtYJPageIndex属性
        '----------------------------------------------------------------
        Public Property txtYJPageIndex() As String
            Get
                txtYJPageIndex = Me.m_strtxtYJPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtYJPageIndex = Value
                Catch ex As Exception
                    Me.m_strtxtYJPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYJPageSize属性
        '----------------------------------------------------------------
        Public Property txtYJPageSize() As String
            Get
                txtYJPageSize = Me.m_strtxtYJPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtYJPageSize = Value
                Catch ex As Exception
                    Me.m_strtxtYJPageSize = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtYJSearch_RYDM属性
        '----------------------------------------------------------------
        Public Property txtYJSearch_RYDM() As String
            Get
                txtYJSearch_RYDM = Me.m_strtxtYJSearch_RYDM
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtYJSearch_RYDM = Value
                Catch ex As Exception
                    Me.m_strtxtYJSearch_RYDM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYJSearch_RYMC属性
        '----------------------------------------------------------------
        Public Property txtYJSearch_RYMC() As String
            Get
                txtYJSearch_RYMC = Me.m_strtxtYJSearch_RYMC
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtYJSearch_RYMC = Value
                Catch ex As Exception
                    Me.m_strtxtYJSearch_RYMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYJSearch_JYNYMax属性
        '----------------------------------------------------------------
        Public Property txtYJSearch_JYNYMax() As String
            Get
                txtYJSearch_JYNYMax = Me.m_strtxtYJSearch_JYNYMax
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtYJSearch_JYNYMax = Value
                Catch ex As Exception
                    Me.m_strtxtYJSearch_JYNYMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYJSearch_JYNYMin属性
        '----------------------------------------------------------------
        Public Property txtYJSearch_JYNYMin() As String
            Get
                txtYJSearch_JYNYMin = Me.m_strtxtYJSearch_JYNYMin
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtYJSearch_JYNYMin = Value
                Catch ex As Exception
                    Me.m_strtxtYJSearch_JYNYMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYJSearch_JANYMin属性
        '----------------------------------------------------------------
        Public Property txtYJSearch_JANYMin() As String
            Get
                txtYJSearch_JANYMin = Me.m_strtxtYJSearch_JANYMin
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtYJSearch_JANYMin = Value
                Catch ex As Exception
                    Me.m_strtxtYJSearch_JANYMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYJSearch_JANYMax属性
        '----------------------------------------------------------------
        Public Property txtYJSearch_JANYMax() As String
            Get
                txtYJSearch_JANYMax = Me.m_strtxtYJSearch_JANYMax
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtYJSearch_JANYMax = Value
                Catch ex As Exception
                    Me.m_strtxtYJSearch_JANYMax = ""
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' grdYJ_PageSize属性
        '----------------------------------------------------------------
        Public Property grdYJ_PageSize() As Integer
            Get
                grdYJ_PageSize = Me.m_intPageSize_grdYJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intPageSize_grdYJ = Value
                Catch ex As Exception
                    Me.m_intPageSize_grdYJ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdYJ_CurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdYJ_CurrentPageIndex() As Integer
            Get
                grdYJ_CurrentPageIndex = Me.m_intCurrentPageIndex_grdYJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intCurrentPageIndex_grdYJ = Value
                Catch ex As Exception
                    Me.m_intCurrentPageIndex_grdYJ = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdYJ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdYJ_SelectedIndex() As Integer
            Get
                grdYJ_SelectedIndex = Me.m_intSelectedIndex_grdYJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_grdYJ = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_grdYJ = -1
                End Try
            End Set
        End Property

    End Class

End Namespace
