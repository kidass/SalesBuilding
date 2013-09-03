Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateEsHetongQtList
    '
    ' 功能描述： 
    '     estate_es_hetong_qt_list.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsHetongQtList
        Implements IDisposable

        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody

        Private m_strhtxtDivLeftHT As String                        'htxtDivLeftHT
        Private m_strhtxtDivTopHT As String                         'htxtDivTopHT
        Private m_strhtxtSessionIdQuery As String                   'htxtSessionIdQuery
        Private m_strhtxtHTQuery As String                          'htxtHTQuery
        Private m_strhtxtHTRows As String                           'htxtHTRows
        Private m_strhtxtHTSort As String                           'htxtHTSort
        Private m_strhtxtHTSortColumnIndex As String                'htxtHTSortColumnIndex
        Private m_strhtxtHTSortType As String                       'htxtHTSortType

        Private m_strtxtHTPageIndex As String                       'txtHTPageIndex
        Private m_strtxtHTPageSize As String                        'txtHTPageSize

        Private m_strtxtHTSearch_QRSH As String                     'txtHTSearch_QRSH
        Private m_strtxtHTSearch_HTBH As String                     'txtHTSearch_HTBH
        Private m_strtxtHTSearch_JFMC As String                     'txtHTSearch_JFMC
        Private m_strtxtHTSearch_YFMC As String                     'txtHTSearch_YFMC
        Private m_strtxtHTSearch_FWDZ As String                     'txtHTSearch_FWDZ
        Private m_strtxtHTSearch_DGRQMin As String                  'txtHTSearch_DGRQMin
        Private m_strtxtHTSearch_DGRQMax As String                  'txtHTSearch_DGRQMax
        Private m_strtxtHTSearch_HTRQMin As String                  'txtHTSearch_HTRQMin
        Private m_strtxtHTSearch_HTRQMax As String                  'txtHTSearch_HTRQMax
        Private m_intSelectedIndex_ddlHTSearch_HTZT As Integer      'ddlHTSearch_HTZT_SelectedIndex
        Private m_intSelectedIndex_ddlHTSearch_SFQY As Integer      'ddlHTSearch_SFQY_SelectedIndex
        Private m_intSelectedIndex_ddlHTSearch_TSTJ As Integer      'ddlHTSearch_TSTJ_SelectedIndex

        '----------------------------------------------------------------
        'asp:datagrid - grdHT
        '----------------------------------------------------------------
        Private m_intPageSize_grdHT As Integer
        Private m_intSelectedIndex_grdHT As Integer
        Private m_intCurrentPageIndex_grdHT As Integer

        'zengxianglin 2011-01-04
        Private m_strhtxtHTQueryDG As String                        'htxtHTQueryDG
        Private m_strhtxtHTQueryHT As String                        'htxtHTQueryHT
        Private m_strhtxtHTQueryDY As String                        'htxtHTQueryDY
        Private m_strhtxtHTQueryRY As String                        'htxtHTQueryRY
        'zengxianglin 2011-01-04










        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftHT = ""
            m_strhtxtDivTopHT = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtHTQuery = ""
            m_strhtxtHTRows = ""
            m_strhtxtHTSort = ""
            m_strhtxtHTSortColumnIndex = ""
            m_strhtxtHTSortType = ""

            m_strhtxtSessionIdQuery = ""

            m_strtxtHTPageIndex = ""
            m_strtxtHTPageSize = ""

            m_strtxtHTSearch_HTBH = ""
            m_strtxtHTSearch_QRSH = ""
            m_strtxtHTSearch_JFMC = ""
            m_strtxtHTSearch_YFMC = ""
            m_strtxtHTSearch_FWDZ = ""
            m_strtxtHTSearch_DGRQMin = ""
            m_strtxtHTSearch_DGRQMax = ""
            m_strtxtHTSearch_HTRQMin = ""
            m_strtxtHTSearch_HTRQMax = ""
            m_intSelectedIndex_ddlHTSearch_HTZT = -1
            m_intSelectedIndex_ddlHTSearch_SFQY = -1
            m_intSelectedIndex_ddlHTSearch_TSTJ = -1

            m_intPageSize_grdHT = 0
            m_intCurrentPageIndex_grdHT = 0
            m_intSelectedIndex_grdHT = -1

            'zengxianglin 2011-01-04
            Me.m_strhtxtHTQueryDG = ""
            Me.m_strhtxtHTQueryHT = ""
            Me.m_strhtxtHTQueryDY = ""
            Me.m_strhtxtHTQueryRY = ""
            'zengxianglin 2011-01-04
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsHetongQtList)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtHTQuery属性
        '----------------------------------------------------------------
        Public Property htxtHTQuery() As String
            Get
                htxtHTQuery = m_strhtxtHTQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtHTQuery = Value
                Catch ex As Exception
                    m_strhtxtHTQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtHTRows属性
        '----------------------------------------------------------------
        Public Property htxtHTRows() As String
            Get
                htxtHTRows = m_strhtxtHTRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtHTRows = Value
                Catch ex As Exception
                    m_strhtxtHTRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtHTSort属性
        '----------------------------------------------------------------
        Public Property htxtHTSort() As String
            Get
                htxtHTSort = m_strhtxtHTSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtHTSort = Value
                Catch ex As Exception
                    m_strhtxtHTSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtHTSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtHTSortColumnIndex() As String
            Get
                htxtHTSortColumnIndex = m_strhtxtHTSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtHTSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtHTSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtHTSortType属性
        '----------------------------------------------------------------
        Public Property htxtHTSortType() As String
            Get
                htxtHTSortType = m_strhtxtHTSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtHTSortType = Value
                Catch ex As Exception
                    m_strhtxtHTSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftHT属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftHT() As String
            Get
                htxtDivLeftHT = m_strhtxtDivLeftHT
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftHT = Value
                Catch ex As Exception
                    m_strhtxtDivLeftHT = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopHT属性
        '----------------------------------------------------------------
        Public Property htxtDivTopHT() As String
            Get
                htxtDivTopHT = m_strhtxtDivTopHT
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopHT = Value
                Catch ex As Exception
                    m_strhtxtDivTopHT = ""
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
        ' txtHTPageIndex属性
        '----------------------------------------------------------------
        Public Property txtHTPageIndex() As String
            Get
                txtHTPageIndex = m_strtxtHTPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTPageIndex = Value
                Catch ex As Exception
                    m_strtxtHTPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTPageSize属性
        '----------------------------------------------------------------
        Public Property txtHTPageSize() As String
            Get
                txtHTPageSize = m_strtxtHTPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTPageSize = Value
                Catch ex As Exception
                    m_strtxtHTPageSize = ""
                End Try
            End Set
        End Property











        '----------------------------------------------------------------
        ' txtHTSearch_HTBH属性
        '----------------------------------------------------------------
        Public Property txtHTSearch_HTBH() As String
            Get
                txtHTSearch_HTBH = m_strtxtHTSearch_HTBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTSearch_HTBH = Value
                Catch ex As Exception
                    m_strtxtHTSearch_HTBH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTSearch_QRSH属性
        '----------------------------------------------------------------
        Public Property txtHTSearch_QRSH() As String
            Get
                txtHTSearch_QRSH = m_strtxtHTSearch_QRSH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTSearch_QRSH = Value
                Catch ex As Exception
                    m_strtxtHTSearch_QRSH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTSearch_JFMC属性
        '----------------------------------------------------------------
        Public Property txtHTSearch_JFMC() As String
            Get
                txtHTSearch_JFMC = m_strtxtHTSearch_JFMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTSearch_JFMC = Value
                Catch ex As Exception
                    m_strtxtHTSearch_JFMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTSearch_YFMC属性
        '----------------------------------------------------------------
        Public Property txtHTSearch_YFMC() As String
            Get
                txtHTSearch_YFMC = m_strtxtHTSearch_YFMC
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTSearch_YFMC = Value
                Catch ex As Exception
                    m_strtxtHTSearch_YFMC = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTSearch_FWDZ属性
        '----------------------------------------------------------------
        Public Property txtHTSearch_FWDZ() As String
            Get
                txtHTSearch_FWDZ = m_strtxtHTSearch_FWDZ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTSearch_FWDZ = Value
                Catch ex As Exception
                    m_strtxtHTSearch_FWDZ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTSearch_DGRQMin属性
        '----------------------------------------------------------------
        Public Property txtHTSearch_DGRQMin() As String
            Get
                txtHTSearch_DGRQMin = m_strtxtHTSearch_DGRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTSearch_DGRQMin = Value
                Catch ex As Exception
                    m_strtxtHTSearch_DGRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTSearch_DGRQMax属性
        '----------------------------------------------------------------
        Public Property txtHTSearch_DGRQMax() As String
            Get
                txtHTSearch_DGRQMax = m_strtxtHTSearch_DGRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTSearch_DGRQMax = Value
                Catch ex As Exception
                    m_strtxtHTSearch_DGRQMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTSearch_HTRQMin属性
        '----------------------------------------------------------------
        Public Property txtHTSearch_HTRQMin() As String
            Get
                txtHTSearch_HTRQMin = m_strtxtHTSearch_HTRQMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTSearch_HTRQMin = Value
                Catch ex As Exception
                    m_strtxtHTSearch_HTRQMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtHTSearch_HTRQMax属性
        '----------------------------------------------------------------
        Public Property txtHTSearch_HTRQMax() As String
            Get
                txtHTSearch_HTRQMax = m_strtxtHTSearch_HTRQMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtHTSearch_HTRQMax = Value
                Catch ex As Exception
                    m_strtxtHTSearch_HTRQMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlHTSearch_HTZT_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlHTSearch_HTZT_SelectedIndex() As Integer
            Get
                ddlHTSearch_HTZT_SelectedIndex = m_intSelectedIndex_ddlHTSearch_HTZT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlHTSearch_HTZT = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlHTSearch_HTZT = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlHTSearch_SFQY_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlHTSearch_SFQY_SelectedIndex() As Integer
            Get
                ddlHTSearch_SFQY_SelectedIndex = m_intSelectedIndex_ddlHTSearch_SFQY
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlHTSearch_SFQY = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlHTSearch_SFQY = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' ddlHTSearch_TSTJ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlHTSearch_TSTJ_SelectedIndex() As Integer
            Get
                ddlHTSearch_TSTJ_SelectedIndex = m_intSelectedIndex_ddlHTSearch_TSTJ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlHTSearch_TSTJ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlHTSearch_TSTJ = -1
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' grdHTPageSize属性
        '----------------------------------------------------------------
        Public Property grdHTPageSize() As Integer
            Get
                grdHTPageSize = m_intPageSize_grdHT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdHT = Value
                Catch ex As Exception
                    m_intPageSize_grdHT = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdHTCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdHTCurrentPageIndex() As Integer
            Get
                grdHTCurrentPageIndex = m_intCurrentPageIndex_grdHT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdHT = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdHT = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdHTSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdHTSelectedIndex() As Integer
            Get
                grdHTSelectedIndex = m_intSelectedIndex_grdHT
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdHT = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdHT = -1
                End Try
            End Set
        End Property











        'zengxianglin 2011-01-04
        '----------------------------------------------------------------
        ' htxtHTQueryDG属性
        '----------------------------------------------------------------
        Public Property htxtHTQueryDG() As String
            Get
                htxtHTQueryDG = Me.m_strhtxtHTQueryDG
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtHTQueryDG = Value
                Catch ex As Exception
                    Me.m_strhtxtHTQueryDG = ""
                End Try
            End Set
        End Property
        '----------------------------------------------------------------
        ' htxtHTQueryHT属性
        '----------------------------------------------------------------
        Public Property htxtHTQueryHT() As String
            Get
                htxtHTQueryHT = Me.m_strhtxtHTQueryHT
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtHTQueryHT = Value
                Catch ex As Exception
                    Me.m_strhtxtHTQueryHT = ""
                End Try
            End Set
        End Property
        '----------------------------------------------------------------
        ' htxtHTQueryDY属性
        '----------------------------------------------------------------
        Public Property htxtHTQueryDY() As String
            Get
                htxtHTQueryDY = Me.m_strhtxtHTQueryDY
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtHTQueryDY = Value
                Catch ex As Exception
                    Me.m_strhtxtHTQueryDY = ""
                End Try
            End Set
        End Property
        '----------------------------------------------------------------
        ' htxtHTQueryRY属性
        '----------------------------------------------------------------
        Public Property htxtHTQueryRY() As String
            Get
                htxtHTQueryRY = Me.m_strhtxtHTQueryRY
            End Get
            Set(ByVal Value As String)
                Try
                    Me.m_strhtxtHTQueryRY = Value
                Catch ex As Exception
                    Me.m_strhtxtHTQueryRY = ""
                End Try
            End Set
        End Property
        'zengxianglin 2011-01-04

    End Class

End Namespace
