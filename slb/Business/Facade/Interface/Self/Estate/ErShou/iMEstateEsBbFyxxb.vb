Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateEsBbFyxxb
    '
    ' 功能描述： 
    '     estate_es_bb_fyxxb.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsBbFyxxb
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
        Private m_strtxtHTRQMin As String                         'txtHTRQMin
        Private m_strtxtHTRQMax As String                         'txtHTRQMax
        Private m_strtxtQRSH As String                            'txtQRSH
        Private m_strtxtHTBH As String                            'txtHTBH
        Private m_strtxtFWDZ As String                            'txtFWDZ
        Private m_strtxtYZMC As String                            'txtYZMC
        Private m_strtxtYZDZ As String                            'txtYZDZ
        Private m_strtxtLXDH As String                            'txtLXDH
        Private m_strtxtZZHM As String                            'txtZZHM
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
            Me.m_strhtxtQuery = ""
            Me.m_strhtxtRows = ""
            Me.m_strhtxtSort = ""
            Me.m_strhtxtSortColumnIndex = ""
            Me.m_strhtxtSortType = ""
            '----------------------------------------------------------------
            Me.m_strhtxtDivLeftContent = ""
            Me.m_strhtxtDivTopContent = ""
            Me.m_strhtxtDivLeftBody = ""
            Me.m_strhtxtDivTopBody = ""
            '----------------------------------------------------------------
            Me.m_strtxtPageIndex = ""
            Me.m_strtxtPageSize = ""
            '----------------------------------------------------------------
            Me.m_strtxtLXDH = ""
            Me.m_strtxtZZHM = ""
            Me.m_strtxtHTRQMin = ""
            Me.m_strtxtHTRQMax = ""
            Me.m_strtxtQRSH = ""
            Me.m_strtxtHTBH = ""
            Me.m_strtxtFWDZ = ""
            Me.m_strtxtYZDZ = ""
            Me.m_strtxtYZMC = ""
            '----------------------------------------------------------------
            Me.m_strhtxtSessionIdQuery = ""
            Me.m_strhtxtSessionIdBuffer = ""
            '----------------------------------------------------------------
            Me.m_intPageSize_grdContent = 0
            Me.m_intSelectedIndex_grdContent = -1
            Me.m_intCurrentPageIndex_grdContent = 0

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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsBbFyxxb)
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
                htxtSessionIdQuery = Me.m_strhtxtSessionIdQuery
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtSessionIdQuery = Value
                Catch ex As Exception
                    Me.m_strhtxtSessionIdQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSessionIdBuffer属性
        '----------------------------------------------------------------
        Public Property htxtSessionIdBuffer() As String
            Get
                htxtSessionIdBuffer = Me.m_strhtxtSessionIdBuffer
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtSessionIdBuffer = Value
                Catch ex As Exception
                    Me.m_strhtxtSessionIdBuffer = ""
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' htxtQuery属性
        '----------------------------------------------------------------
        Public Property htxtQuery() As String
            Get
                htxtQuery = Me.m_strhtxtQuery
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtQuery = Value
                Catch ex As Exception
                    Me.m_strhtxtQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRows属性
        '----------------------------------------------------------------
        Public Property htxtRows() As String
            Get
                htxtRows = Me.m_strhtxtRows
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtRows = Value
                Catch ex As Exception
                    Me.m_strhtxtRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSort属性
        '----------------------------------------------------------------
        Public Property htxtSort() As String
            Get
                htxtSort = Me.m_strhtxtSort
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtSort = Value
                Catch ex As Exception
                    Me.m_strhtxtSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtSortColumnIndex() As String
            Get
                htxtSortColumnIndex = Me.m_strhtxtSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtSortColumnIndex = Value
                Catch ex As Exception
                    Me.m_strhtxtSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSortType属性
        '----------------------------------------------------------------
        Public Property htxtSortType() As String
            Get
                htxtSortType = Me.m_strhtxtSortType
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtSortType = Value
                Catch ex As Exception
                    Me.m_strhtxtSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftContent属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftContent() As String
            Get
                htxtDivLeftContent = Me.m_strhtxtDivLeftContent
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtDivLeftContent = Value
                Catch ex As Exception
                    Me.m_strhtxtDivLeftContent = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopContent属性
        '----------------------------------------------------------------
        Public Property htxtDivTopContent() As String
            Get
                htxtDivTopContent = Me.m_strhtxtDivTopContent
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtDivTopContent = Value
                Catch ex As Exception
                    Me.m_strhtxtDivTopContent = ""
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
        ' txtPageIndex属性
        '----------------------------------------------------------------
        Public Property txtPageIndex() As String
            Get
                txtPageIndex = Me.m_strtxtPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtPageIndex = Value
                Catch ex As Exception
                    Me.m_strtxtPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtPageSize属性
        '----------------------------------------------------------------
        Public Property txtPageSize() As String
            Get
                txtPageSize = Me.m_strtxtPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtPageSize = Value
                Catch ex As Exception
                    Me.m_strtxtPageSize = ""
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' grdContentPageSize属性
        '----------------------------------------------------------------
        Public Property grdContentPageSize() As Integer
            Get
                grdContentPageSize = Me.m_intPageSize_grdContent
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intPageSize_grdContent = Value
                Catch ex As Exception
                    Me.m_intPageSize_grdContent = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdContentCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdContentCurrentPageIndex() As Integer
            Get
                grdContentCurrentPageIndex = Me.m_intCurrentPageIndex_grdContent
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intCurrentPageIndex_grdContent = Value
                Catch ex As Exception
                    Me.m_intCurrentPageIndex_grdContent = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdContentSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdContentSelectedIndex() As Integer
            Get
                grdContentSelectedIndex = Me.m_intSelectedIndex_grdContent
            End Get
            Set(ByVal Value As Integer)
                Try
                    Me.m_intSelectedIndex_grdContent = Value
                Catch ex As Exception
                    Me.m_intSelectedIndex_grdContent = 0
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtLXDH属性
        '----------------------------------------------------------------
        Public Property txtLXDH() As String
            Get
                txtLXDH = Me.m_strtxtLXDH
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtLXDH = Value
                Catch ex As Exception
                    Me.m_strtxtLXDH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtZZHM属性
        '----------------------------------------------------------------
        Public Property txtZZHM() As String
            Get
                txtZZHM = Me.m_strtxtZZHM
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtZZHM = Value
                Catch ex As Exception
                    Me.m_strtxtZZHM = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTRQMin属性
        '----------------------------------------------------------------
        Public Property txtHTRQMin() As String
            Get
                txtHTRQMin = Me.m_strtxtHTRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtHTRQMin = Value
                Catch ex As Exception
                    Me.m_strtxtHTRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTRQMax属性
        '----------------------------------------------------------------
        Public Property txtHTRQMax() As String
            Get
                txtHTRQMax = Me.m_strtxtHTRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtHTRQMax = Value
                Catch ex As Exception
                    Me.m_strtxtHTRQMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtQRSH属性
        '----------------------------------------------------------------
        Public Property txtQRSH() As String
            Get
                txtQRSH = Me.m_strtxtQRSH
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtQRSH = Value
                Catch ex As Exception
                    Me.m_strtxtQRSH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTBH属性
        '----------------------------------------------------------------
        Public Property txtHTBH() As String
            Get
                txtHTBH = Me.m_strtxtHTBH
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtHTBH = Value
                Catch ex As Exception
                    Me.m_strtxtHTBH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtFWDZ属性
        '----------------------------------------------------------------
        Public Property txtFWDZ() As String
            Get
                txtFWDZ = Me.m_strtxtFWDZ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtFWDZ = Value
                Catch ex As Exception
                    Me.m_strtxtFWDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYZDZ属性
        '----------------------------------------------------------------
        Public Property txtYZDZ() As String
            Get
                txtYZDZ = Me.m_strtxtYZDZ
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtYZDZ = Value
                Catch ex As Exception
                    Me.m_strtxtYZDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtYZMC属性
        '----------------------------------------------------------------
        Public Property txtYZMC() As String
            Get
                txtYZMC = Me.m_strtxtYZMC
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strtxtYZMC = Value
                Catch ex As Exception
                    Me.m_strtxtYZMC = ""
                End Try
            End Set
        End Property

    End Class

End Namespace
