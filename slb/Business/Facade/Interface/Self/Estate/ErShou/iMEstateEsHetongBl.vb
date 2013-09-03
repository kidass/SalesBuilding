Imports System

Namespace Josco.JSOA.BusinessFacade

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：IMEstateEsHetongBl
    '
    ' 功能描述： 
    '     estate_es_hetong_bl.aspx模块本身恢复现场需要的信息
    '----------------------------------------------------------------
    <Serializable()> Public Class IMEstateEsHetongBl
        Implements IDisposable

        Private m_strhtxtDivLeftBLJL As String                      'htxtDivLeftBLJL
        Private m_strhtxtDivTopBLJL As String                       'htxtDivTopBLJL
        Private m_strhtxtDivLeftBAJH As String                      'htxtDivLeftBAJH
        Private m_strhtxtDivTopBAJH As String                       'htxtDivTopBAJH
        Private m_strhtxtDivLeftMain As String                      'htxtDivLeftMain
        Private m_strhtxtDivTopMain As String                       'htxtDivTopMain
        Private m_strhtxtDivLeftBody As String                      'htxtDivLeftBody
        Private m_strhtxtDivTopBody As String                       'htxtDivTopBody

        Private m_strhtxtBAJHQuery As String                        'htxtBAJHQuery
        Private m_strhtxtBAJHRows As String                         'htxtBAJHRows
        Private m_strhtxtBAJHSort As String                         'htxtBAJHSort
        Private m_strhtxtBAJHSortColumnIndex As String              'htxtBAJHSortColumnIndex
        Private m_strhtxtBAJHSortType As String                     'htxtBAJHSortType
        Private m_strhtxtBAJHSessionIdQuery As String               'htxtBAJHSessionIdQuery
        Private m_strtxtBAJHPageIndex As String                     'txtBAJHPageIndex
        Private m_strtxtBAJHPageSize As String                      'txtBAJHPageSize

        Private m_strhtxtBLJLQuery As String                        'htxtBLJLQuery
        Private m_strhtxtBLJLRows As String                         'htxtBLJLRows
        Private m_strhtxtBLJLSort As String                         'htxtBLJLSort
        Private m_strhtxtBLJLSortColumnIndex As String              'htxtBLJLSortColumnIndex
        Private m_strhtxtBLJLSortType As String                     'htxtBLJLSortType
        Private m_strhtxtBLJLSessionIdQuery As String               'htxtBLJLSessionIdQuery
        Private m_strtxtBLJLPageIndex As String                     'txtBLJLPageIndex
        Private m_strtxtBLJLPageSize As String                      'txtBLJLPageSize

        Private m_intSelectedIndex_ddlBAJHSearch_TXBZ As Integer    'ddlBAJHSearch_TXBZ
        Private m_strtxtBAJHSearch_JHKSMin As String                'txtBAJHSearch_JHKSMin
        Private m_strtxtBAJHSearch_JHKSMax As String                'txtBAJHSearch_JHKSMax
        Private m_strtxtBAJHSearch_JHJSMin As String                'txtBAJHSearch_JHJSMin
        Private m_strtxtBAJHSearch_JHJSMax As String                'txtBAJHSearch_JHJSMax
        Private m_strtxtBAJHSearch_JBRY As String                   'txtBAJHSearch_JBRY
        Private m_strtxtBAJHSearch_JBDW As String                   'txtBAJHSearch_JBDW
        Private m_strtxtBAJHSearch_GZNR As String                   'txtBAJHSearch_GZNR

        Private m_intPageSize_grdBAJH As Integer
        Private m_intSelectedIndex_grdBAJH As Integer
        Private m_intCurrentPageIndex_grdBAJH As Integer

        Private m_intPageSize_grdBLJL As Integer
        Private m_intSelectedIndex_grdBLJL As Integer
        Private m_intCurrentPageIndex_grdBLJL As Integer

        Private m_strhtxtCurrentPage As String                      'htxtCurrentPage
        Private m_strhtxtCurrentRow As String                       'htxtCurrentRow
        Private m_strhtxtEditMode As String                         'htxtEditMode
        Private m_strhtxtEditType As String                         'htxtEditType

        Private m_strhtxtSessionIdBAJH As String                    'htxtSessionIdBAJH
        Private m_strhtxtRowNoBAJH As String                        'htxtRowNoBAJH

        Private m_intSelectedIndex_rblJH_TX As Integer              'rblJH_TX
        Private m_strtxtJH_KBTS As String                           'txtJH_KBTS
        Private m_strtxtJH_BWTS As String                           'txtJH_BWTS

        Private m_strhtxtSJ_WYBS As String                          'htxtSJ_WYBS
        Private m_strhtxtSJ_QRSH As String                          'htxtSJ_QRSH
        Private m_strhtxtSJ_JHBS As String                          'htxtSJ_JHBS
        Private m_strhtxtSJ_JBRY As String                          'htxtSJ_JBRY
        Private m_strhtxtSJ_JBDW As String                          'htxtSJ_JBDW
        Private m_strtxtSJ_JBRY As String                           'txtSJ_JBRY
        Private m_strtxtSJ_JBDW As String                           'txtSJ_JBDW
        Private m_strtxtSJ_BLRQ As String                           'txtSJ_BLRQ
        Private m_strtxtSJ_BLQK As String                           'txtSJ_BLQK

        Private m_strtxtJYBH As String                              'txtJYBH












        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()

            m_strhtxtDivLeftBLJL = ""
            m_strhtxtDivTopBLJL = ""
            m_strhtxtDivLeftBAJH = ""
            m_strhtxtDivTopBAJH = ""
            m_strhtxtDivLeftMain = ""
            m_strhtxtDivTopMain = ""
            m_strhtxtDivLeftBody = ""
            m_strhtxtDivTopBody = ""

            m_strhtxtBAJHQuery = ""
            m_strhtxtBAJHRows = ""
            m_strhtxtBAJHSort = ""
            m_strhtxtBAJHSortColumnIndex = ""
            m_strhtxtBAJHSortType = ""
            m_strhtxtBAJHSessionIdQuery = ""
            m_strtxtBAJHPageIndex = ""
            m_strtxtBAJHPageSize = ""

            m_strhtxtBLJLQuery = ""
            m_strhtxtBLJLRows = ""
            m_strhtxtBLJLSort = ""
            m_strhtxtBLJLSortColumnIndex = ""
            m_strhtxtBLJLSortType = ""
            m_strhtxtBLJLSessionIdQuery = ""
            m_strtxtBLJLPageIndex = ""
            m_strtxtBLJLPageSize = ""

            m_intSelectedIndex_ddlBAJHSearch_TXBZ = -1
            m_strtxtBAJHSearch_JHKSMin = ""
            m_strtxtBAJHSearch_JHKSMax = ""
            m_strtxtBAJHSearch_JHJSMin = ""
            m_strtxtBAJHSearch_JHJSMax = ""
            m_strtxtBAJHSearch_JBRY = ""
            m_strtxtBAJHSearch_JBDW = ""
            m_strtxtBAJHSearch_GZNR = ""

            m_intPageSize_grdBAJH = 0
            m_intCurrentPageIndex_grdBAJH = 0
            m_intSelectedIndex_grdBAJH = -1

            m_intPageSize_grdBLJL = 0
            m_intCurrentPageIndex_grdBLJL = 0
            m_intSelectedIndex_grdBLJL = -1

            m_strhtxtCurrentPage = ""
            m_strhtxtCurrentRow = ""
            m_strhtxtEditMode = ""
            m_strhtxtEditType = ""

            m_strhtxtSessionIdBAJH = ""
            m_strhtxtRowNoBAJH = ""

            m_intSelectedIndex_rblJH_TX = -1
            m_strtxtJH_KBTS = ""
            m_strtxtJH_BWTS = ""

            m_strhtxtSJ_WYBS = ""
            m_strhtxtSJ_QRSH = ""
            m_strhtxtSJ_JHBS = ""
            m_strhtxtSJ_JBDW = ""
            m_strhtxtSJ_JBRY = ""
            m_strtxtSJ_JBRY = ""
            m_strtxtSJ_JBDW = ""
            m_strtxtSJ_BLRQ = ""
            m_strtxtSJ_BLQK = ""

            m_strtxtJYBH = ""
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
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.IMEstateEsHetongBl)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub












        '----------------------------------------------------------------
        ' htxtBAJHQuery属性
        '----------------------------------------------------------------
        Public Property htxtBAJHQuery() As String
            Get
                htxtBAJHQuery = m_strhtxtBAJHQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBAJHQuery = Value
                Catch ex As Exception
                    m_strhtxtBAJHQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtBAJHRows属性
        '----------------------------------------------------------------
        Public Property htxtBAJHRows() As String
            Get
                htxtBAJHRows = m_strhtxtBAJHRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBAJHRows = Value
                Catch ex As Exception
                    m_strhtxtBAJHRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtBAJHSort属性
        '----------------------------------------------------------------
        Public Property htxtBAJHSort() As String
            Get
                htxtBAJHSort = m_strhtxtBAJHSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBAJHSort = Value
                Catch ex As Exception
                    m_strhtxtBAJHSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtBAJHSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtBAJHSortColumnIndex() As String
            Get
                htxtBAJHSortColumnIndex = m_strhtxtBAJHSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBAJHSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtBAJHSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtBAJHSortType属性
        '----------------------------------------------------------------
        Public Property htxtBAJHSortType() As String
            Get
                htxtBAJHSortType = m_strhtxtBAJHSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBAJHSortType = Value
                Catch ex As Exception
                    m_strhtxtBAJHSortType = ""
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' htxtBLJLQuery属性
        '----------------------------------------------------------------
        Public Property htxtBLJLQuery() As String
            Get
                htxtBLJLQuery = m_strhtxtBLJLQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBLJLQuery = Value
                Catch ex As Exception
                    m_strhtxtBLJLQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtBLJLRows属性
        '----------------------------------------------------------------
        Public Property htxtBLJLRows() As String
            Get
                htxtBLJLRows = m_strhtxtBLJLRows
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBLJLRows = Value
                Catch ex As Exception
                    m_strhtxtBLJLRows = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtBLJLSort属性
        '----------------------------------------------------------------
        Public Property htxtBLJLSort() As String
            Get
                htxtBLJLSort = m_strhtxtBLJLSort
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBLJLSort = Value
                Catch ex As Exception
                    m_strhtxtBLJLSort = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtBLJLSortColumnIndex属性
        '----------------------------------------------------------------
        Public Property htxtBLJLSortColumnIndex() As String
            Get
                htxtBLJLSortColumnIndex = m_strhtxtBLJLSortColumnIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBLJLSortColumnIndex = Value
                Catch ex As Exception
                    m_strhtxtBLJLSortColumnIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtBLJLSortType属性
        '----------------------------------------------------------------
        Public Property htxtBLJLSortType() As String
            Get
                htxtBLJLSortType = m_strhtxtBLJLSortType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBLJLSortType = Value
                Catch ex As Exception
                    m_strhtxtBLJLSortType = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtDivLeftBLJL属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftBLJL() As String
            Get
                htxtDivLeftBLJL = m_strhtxtDivLeftBLJL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftBLJL = Value
                Catch ex As Exception
                    m_strhtxtDivLeftBLJL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopBLJL属性
        '----------------------------------------------------------------
        Public Property htxtDivTopBLJL() As String
            Get
                htxtDivTopBLJL = m_strhtxtDivTopBLJL
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopBLJL = Value
                Catch ex As Exception
                    m_strhtxtDivTopBLJL = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftBAJH属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftBAJH() As String
            Get
                htxtDivLeftBAJH = m_strhtxtDivLeftBAJH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftBAJH = Value
                Catch ex As Exception
                    m_strhtxtDivLeftBAJH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopBAJH属性
        '----------------------------------------------------------------
        Public Property htxtDivTopBAJH() As String
            Get
                htxtDivTopBAJH = m_strhtxtDivTopBAJH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopBAJH = Value
                Catch ex As Exception
                    m_strhtxtDivTopBAJH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivLeftMain属性
        '----------------------------------------------------------------
        Public Property htxtDivLeftMain() As String
            Get
                htxtDivLeftMain = m_strhtxtDivLeftMain
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivLeftMain = Value
                Catch ex As Exception
                    m_strhtxtDivLeftMain = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtDivTopMain属性
        '----------------------------------------------------------------
        Public Property htxtDivTopMain() As String
            Get
                htxtDivTopMain = m_strhtxtDivTopMain
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtDivTopMain = Value
                Catch ex As Exception
                    m_strhtxtDivTopMain = ""
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
        ' htxtBAJHSessionIdQuery属性
        '----------------------------------------------------------------
        Public Property htxtBAJHSessionIdQuery() As String
            Get
                htxtBAJHSessionIdQuery = m_strhtxtBAJHSessionIdQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBAJHSessionIdQuery = Value
                Catch ex As Exception
                    m_strhtxtBAJHSessionIdQuery = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtBLJLSessionIdQuery属性
        '----------------------------------------------------------------
        Public Property htxtBLJLSessionIdQuery() As String
            Get
                htxtBLJLSessionIdQuery = m_strhtxtBLJLSessionIdQuery
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtBLJLSessionIdQuery = Value
                Catch ex As Exception
                    m_strhtxtBLJLSessionIdQuery = ""
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' ddlBAJHSearch_TXBZ_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property ddlBAJHSearch_TXBZ_SelectedIndex() As Integer
            Get
                ddlBAJHSearch_TXBZ_SelectedIndex = m_intSelectedIndex_ddlBAJHSearch_TXBZ
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_ddlBAJHSearch_TXBZ = Value
                Catch ex As Exception
                    m_intSelectedIndex_ddlBAJHSearch_TXBZ = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBAJHSearch_JHKSMin属性
        '----------------------------------------------------------------
        Public Property txtBAJHSearch_JHKSMin() As String
            Get
                txtBAJHSearch_JHKSMin = m_strtxtBAJHSearch_JHKSMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBAJHSearch_JHKSMin = Value
                Catch ex As Exception
                    m_strtxtBAJHSearch_JHKSMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBAJHSearch_JHKSMax属性
        '----------------------------------------------------------------
        Public Property txtBAJHSearch_JHKSMax() As String
            Get
                txtBAJHSearch_JHKSMax = m_strtxtBAJHSearch_JHKSMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBAJHSearch_JHKSMax = Value
                Catch ex As Exception
                    m_strtxtBAJHSearch_JHKSMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBAJHSearch_JHJSMin属性
        '----------------------------------------------------------------
        Public Property txtBAJHSearch_JHJSMin() As String
            Get
                txtBAJHSearch_JHJSMin = m_strtxtBAJHSearch_JHJSMin
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBAJHSearch_JHJSMin = Value
                Catch ex As Exception
                    m_strtxtBAJHSearch_JHJSMin = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBAJHSearch_JHJSMax属性
        '----------------------------------------------------------------
        Public Property txtBAJHSearch_JHJSMax() As String
            Get
                txtBAJHSearch_JHJSMax = m_strtxtBAJHSearch_JHJSMax
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBAJHSearch_JHJSMax = Value
                Catch ex As Exception
                    m_strtxtBAJHSearch_JHJSMax = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBAJHSearch_JBRY属性
        '----------------------------------------------------------------
        Public Property txtBAJHSearch_JBRY() As String
            Get
                txtBAJHSearch_JBRY = m_strtxtBAJHSearch_JBRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBAJHSearch_JBRY = Value
                Catch ex As Exception
                    m_strtxtBAJHSearch_JBRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBAJHSearch_JBDW属性
        '----------------------------------------------------------------
        Public Property txtBAJHSearch_JBDW() As String
            Get
                txtBAJHSearch_JBDW = m_strtxtBAJHSearch_JBDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBAJHSearch_JBDW = Value
                Catch ex As Exception
                    m_strtxtBAJHSearch_JBDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBAJHSearch_GZNR属性
        '----------------------------------------------------------------
        Public Property txtBAJHSearch_GZNR() As String
            Get
                txtBAJHSearch_GZNR = m_strtxtBAJHSearch_GZNR
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBAJHSearch_GZNR = Value
                Catch ex As Exception
                    m_strtxtBAJHSearch_GZNR = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' txtBAJHPageIndex属性
        '----------------------------------------------------------------
        Public Property txtBAJHPageIndex() As String
            Get
                txtBAJHPageIndex = m_strtxtBAJHPageIndex
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBAJHPageIndex = Value
                Catch ex As Exception
                    m_strtxtBAJHPageIndex = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtBAJHPageSize属性
        '----------------------------------------------------------------
        Public Property txtBAJHPageSize() As String
            Get
                txtBAJHPageSize = m_strtxtBAJHPageSize
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtBAJHPageSize = Value
                Catch ex As Exception
                    m_strtxtBAJHPageSize = ""
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' grdBAJHPageSize属性
        '----------------------------------------------------------------
        Public Property grdBAJHPageSize() As Integer
            Get
                grdBAJHPageSize = m_intPageSize_grdBAJH
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdBAJH = Value
                Catch ex As Exception
                    m_intPageSize_grdBAJH = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdBAJHCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdBAJHCurrentPageIndex() As Integer
            Get
                grdBAJHCurrentPageIndex = m_intCurrentPageIndex_grdBAJH
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdBAJH = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdBAJH = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdBAJHSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdBAJHSelectedIndex() As Integer
            Get
                grdBAJHSelectedIndex = m_intSelectedIndex_grdBAJH
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdBAJH = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdBAJH = -1
                End Try
            End Set
        End Property













        '----------------------------------------------------------------
        ' grdBLJLPageSize属性
        '----------------------------------------------------------------
        Public Property grdBLJLPageSize() As Integer
            Get
                grdBLJLPageSize = m_intPageSize_grdBLJL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intPageSize_grdBLJL = Value
                Catch ex As Exception
                    m_intPageSize_grdBLJL = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdBLJLCurrentPageIndex属性
        '----------------------------------------------------------------
        Public Property grdBLJLCurrentPageIndex() As Integer
            Get
                grdBLJLCurrentPageIndex = m_intCurrentPageIndex_grdBLJL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intCurrentPageIndex_grdBLJL = Value
                Catch ex As Exception
                    m_intCurrentPageIndex_grdBLJL = 0
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' grdBLJLSelectedIndex属性
        '----------------------------------------------------------------
        Public Property grdBLJLSelectedIndex() As Integer
            Get
                grdBLJLSelectedIndex = m_intSelectedIndex_grdBLJL
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_grdBLJL = Value
                Catch ex As Exception
                    m_intSelectedIndex_grdBLJL = -1
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' htxtCurrentPage属性
        '----------------------------------------------------------------
        Public Property htxtCurrentPage() As String
            Get
                htxtCurrentPage = m_strhtxtCurrentPage
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtCurrentPage = Value
                Catch ex As Exception
                    m_strhtxtCurrentPage = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtCurrentRow属性
        '----------------------------------------------------------------
        Public Property htxtCurrentRow() As String
            Get
                htxtCurrentRow = m_strhtxtCurrentRow
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtCurrentRow = Value
                Catch ex As Exception
                    m_strhtxtCurrentRow = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtEditMode属性
        '----------------------------------------------------------------
        Public Property htxtEditMode() As String
            Get
                htxtEditMode = m_strhtxtEditMode
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtEditMode = Value
                Catch ex As Exception
                    m_strhtxtEditMode = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtEditType属性
        '----------------------------------------------------------------
        Public Property htxtEditType() As String
            Get
                htxtEditType = m_strhtxtEditType
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtEditType = Value
                Catch ex As Exception
                    m_strhtxtEditType = ""
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' htxtSessionIdBAJH属性
        '----------------------------------------------------------------
        Public Property htxtSessionIdBAJH() As String
            Get
                htxtSessionIdBAJH = m_strhtxtSessionIdBAJH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSessionIdBAJH = Value
                Catch ex As Exception
                    m_strhtxtSessionIdBAJH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtRowNoBAJH属性
        '----------------------------------------------------------------
        Public Property htxtRowNoBAJH() As String
            Get
                htxtRowNoBAJH = m_strhtxtRowNoBAJH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtRowNoBAJH = Value
                Catch ex As Exception
                    m_strhtxtRowNoBAJH = ""
                End Try
            End Set
        End Property












        '----------------------------------------------------------------
        ' rblJH_TX_SelectedIndex属性
        '----------------------------------------------------------------
        Public Property rblJH_TX_SelectedIndex() As Integer
            Get
                rblJH_TX_SelectedIndex = m_intSelectedIndex_rblJH_TX
            End Get
            Set(ByVal Value As Integer)
                Try
                    m_intSelectedIndex_rblJH_TX = Value
                Catch ex As Exception
                    m_intSelectedIndex_rblJH_TX = -1
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJH_KBTS属性
        '----------------------------------------------------------------
        Public Property txtJH_KBTS() As String
            Get
                txtJH_KBTS = m_strtxtJH_KBTS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJH_KBTS = Value
                Catch ex As Exception
                    m_strtxtJH_KBTS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtJH_BWTS属性
        '----------------------------------------------------------------
        Public Property txtJH_BWTS() As String
            Get
                txtJH_BWTS = m_strtxtJH_BWTS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJH_BWTS = Value
                Catch ex As Exception
                    m_strtxtJH_BWTS = ""
                End Try
            End Set
        End Property










        '----------------------------------------------------------------
        ' htxtSJ_WYBS属性
        '----------------------------------------------------------------
        Public Property htxtSJ_WYBS() As String
            Get
                htxtSJ_WYBS = m_strhtxtSJ_WYBS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSJ_WYBS = Value
                Catch ex As Exception
                    m_strhtxtSJ_WYBS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSJ_QRSH属性
        '----------------------------------------------------------------
        Public Property htxtSJ_QRSH() As String
            Get
                htxtSJ_QRSH = m_strhtxtSJ_QRSH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSJ_QRSH = Value
                Catch ex As Exception
                    m_strhtxtSJ_QRSH = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSJ_JHBS属性
        '----------------------------------------------------------------
        Public Property htxtSJ_JHBS() As String
            Get
                htxtSJ_JHBS = m_strhtxtSJ_JHBS
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSJ_JHBS = Value
                Catch ex As Exception
                    m_strhtxtSJ_JHBS = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSJ_JBRY属性
        '----------------------------------------------------------------
        Public Property htxtSJ_JBRY() As String
            Get
                htxtSJ_JBRY = m_strhtxtSJ_JBRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSJ_JBRY = Value
                Catch ex As Exception
                    m_strhtxtSJ_JBRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' htxtSJ_JBDW属性
        '----------------------------------------------------------------
        Public Property htxtSJ_JBDW() As String
            Get
                htxtSJ_JBDW = m_strhtxtSJ_JBDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strhtxtSJ_JBDW = Value
                Catch ex As Exception
                    m_strhtxtSJ_JBDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSJ_JBRY属性
        '----------------------------------------------------------------
        Public Property txtSJ_JBRY() As String
            Get
                txtSJ_JBRY = m_strtxtSJ_JBRY
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJ_JBRY = Value
                Catch ex As Exception
                    m_strtxtSJ_JBRY = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSJ_JBDW属性
        '----------------------------------------------------------------
        Public Property txtSJ_JBDW() As String
            Get
                txtSJ_JBDW = m_strtxtSJ_JBDW
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJ_JBDW = Value
                Catch ex As Exception
                    m_strtxtSJ_JBDW = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSJ_BLRQ属性
        '----------------------------------------------------------------
        Public Property txtSJ_BLRQ() As String
            Get
                txtSJ_BLRQ = m_strtxtSJ_BLRQ
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJ_BLRQ = Value
                Catch ex As Exception
                    m_strtxtSJ_BLRQ = ""
                End Try
            End Set
        End Property

        '----------------------------------------------------------------
        ' txtSJ_BLQK属性
        '----------------------------------------------------------------
        Public Property txtSJ_BLQK() As String
            Get
                txtSJ_BLQK = m_strtxtSJ_BLQK
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtSJ_BLQK = Value
                Catch ex As Exception
                    m_strtxtSJ_BLQK = ""
                End Try
            End Set
        End Property














        '----------------------------------------------------------------
        ' txtJYBH属性
        '----------------------------------------------------------------
        Public Property txtJYBH() As String
            Get
                txtJYBH = m_strtxtJYBH
            End Get
            Set(ByVal Value As String)
                Try
                    m_strtxtJYBH = Value
                Catch ex As Exception
                    m_strtxtJYBH = ""
                End Try
            End Set
        End Property

    End Class

End Namespace
